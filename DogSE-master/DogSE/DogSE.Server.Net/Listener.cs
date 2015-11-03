﻿using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using DogSE.Library.Common;
using DogSE.Library.Log;

namespace DogSE.Server.Net
{
    /// <summary>
    /// 重写的监听器
    /// </summary>
    public class Listener<T>
    {
        private TcpListener serverSocket;

        /// <summary>
        /// 客户端连接上的Session组合
        /// </summary>
        private readonly ConcurrentDictionary<ClientSession<T>, int> connectSessions = new ConcurrentDictionary<ClientSession<T>, int>();


        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <param name="port"></param>
        public void StartServer(int port)
        {
            StartServer("127.0.0.1", port);
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public void StartServer(string host, int port)
        {
            if (serverSocket != null)
            {
                return;
            }

            serverSocket = new TcpListener(IPAddress.Parse(host),  port);
            serverSocket.Start(50);
            serverSocket.Server.UseOnlyOverlappedIO = true;
            serverSocket.BeginAcceptSocket(OnSocketAccept, null);

            isRun = true;
        }


        /// <summary>
        /// 触发socket的连接
        /// </summary>
        /// <param name="result"></param>
        void OnSocketAccept(IAsyncResult result)
        {
            Socket acceptSocket = null;

            try
            {
                acceptSocket = serverSocket.EndAcceptSocket(result);
            }
            catch (Exception ex)
            {
                if (!result.IsCompleted)
                    Logs.Error(ex.ToString());
            }

            if (!isRun)
                return;

            //  这里在触发socket开始后，又重新抛一个异步连接，
            //  目的是如果下面的操作就算超时，也不会影响socket的正常连接
            serverSocket.BeginAcceptSocket(OnSocketAccept, null);

            if (acceptSocket != null)
            {

                var session = new ClientSession<T>(acceptSocket);
                var ev = SocketConnect;
                if (ev != null)
                {
                    var arg = m_connectArgsPool.AcquireContent();
                    arg.Session = session;
                    arg.AllowConnection = true;

                    try
                    {
                        ev(this, arg);
                    }
                    catch (Exception ex)
                    {
                        Logs.Error("On accept socket event error.", ex);
                        arg.AllowConnection = false;
                    }

                    if (!arg.AllowConnection)
                    {
                        session.Close();  //  如果业务逻辑不允许连接，则自己关闭
                    }
                    else
                    {
                        NetProfile.Instatnce.AcceptCount++;

                        connectSessions.GetOrAdd(session, 1);

                        session.ReceiveEventArgs.UserToken = session;
                        session.ReceiveEventArgs.Completed += OnRecvCompleted;

                        session.SyncRecvData();
                    }

                    arg.Session = null;
                    m_connectArgsPool.ReleaseContent(arg);  //  事件完成后就进行回收
                }
                else
                {
                    //  如果没有响应连接事件，目前是直接把客户端关闭
                    Logs.Error("Linster SocketConnect event not invoke.");
                    session.Close();
                }
            }
        }

        private void OnRecvCompleted(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                var session = e.UserToken as ClientSession<T>;
                if (session == null)
                {
                    Logs.Error("OnRecvCompleted UserToken is not " + typeof (ClientSession<T>).Name);
                    return;
                }

                if (e.BytesTransferred == 0 || e.SocketError != SocketError.Success)
                {
                    //  传输为0，表示客户端已经被关闭
                    CloseSession(session);
                }
                else
                {
                    //  正常收到数据
                    var buff = session.RecvBuffer;
                    buff.Length = e.BytesTransferred; //  设置buff的有效长度

                    //  在处理逻辑前，先重新抛一个接收的请求到系统，这样就可以及时的收到消息
                    //  不必等系统逻辑完成操作后，才能继续接收消息。

                    NetProfile.Instatnce.RecvCount++;
                    NetProfile.Instatnce.RecvLength += buff.Length;

                    NotifySocketRecvEvent(session, buff);

                    session.SyncRecvData();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("OnRecvCompleted fail. ", ex);
            }
        }


        /// <summary>
        /// 抛出收到数据事件
        /// </summary>
        /// <param name="session"></param>
        /// <param name="buff"></param>
        private void NotifySocketRecvEvent(ClientSession<T> session, DogBuffer buff)
        {
            var recvTemp = SocketRecv;
            if (recvTemp != null)
            {
                var ev = m_recvEventArgsPool.AcquireContent();
                ev.Buffer = buff;
                ev.Session = session;
                try
                {
                    recvTemp(this, ev);
                }
                catch (Exception ex)
                {
                    Logs.Error("OnSocketRecv event error.", ex);
                }

                ev.Buffer = null;
                ev.Session = null;
                m_recvEventArgsPool.ReleaseContent(ev);
            }
        }

        private void CloseSession(ClientSession<T> session)
        {
            int outValue;
            if (!connectSessions.TryRemove(session, out outValue))
            {
                Logs.Error("connectSessions.TryTake(out session) fail.");
                return;
            }

            NetProfile.Instatnce.DisconnectCount++;
            session.ReceiveEventArgs.Completed -= OnRecvCompleted;

            //  触发关闭连接事件
            var disconnectTemp = SocketDisconnect;
            if (disconnectTemp != null)
            {
                var arg = m_disconnectArgsPool.AcquireContent();
                arg.Session = session;

                try
                {
                    disconnectTemp(this, arg);
                }
                catch (Exception ex)
                {
                    Logs.Error("On socket close event error.", ex);
                }

                arg.Session = null;
                m_disconnectArgsPool.ReleaseContent(arg);

                //  清理工作由内部的发送缓冲检查出错误后内部进行处理
            }

            session.Close();
        }

        /// <summary>
        /// 关闭所有的客户端连接
        /// </summary>
        public void DisconnectAll()
        {
            var sessions = connectSessions.ToArray();
            foreach (var s in sessions)
            {
                s.Key.CloseSocket();
            }
        }

        private bool isRun = true;
        /// <summary>
        /// 关闭并停止服务器的socket操作
        /// </summary>
        public void Close()
        {
            DisconnectAll();

            isRun = false;
            serverSocket.Stop();
        }


        /// <summary>
        /// 关闭所有的session
        /// </summary>
        public void CloseAllSession()
        {
            var sessions = connectSessions.ToArray();
            foreach (var s in sessions)
            {
                CloseSession(s.Key);
            }
        }

        /// <summary>
        /// 当有客户端socket连接上服务器时，触发当前事件
        /// </summary>
        public event EventHandler<SocketConnectEventArgs<T>> SocketConnect;

        private readonly ObjectPool<SocketConnectEventArgs<T>> m_connectArgsPool = new ObjectPool<SocketConnectEventArgs<T>>();

        /// <summary>
        /// socket发生关闭连接事件
        /// </summary>
        /// <remarks>
        /// 不管是客户端主动关闭，还是客户端关闭，事件都是会触发到的
        /// </remarks>
        public event EventHandler<SocketDisconnectEventArgs<T>> SocketDisconnect;


        private readonly ObjectPool<SocketDisconnectEventArgs<T>> m_disconnectArgsPool = new ObjectPool<SocketDisconnectEventArgs<T>>();


        /// <summary>
        /// socket有数据送达
        /// 注意，这个buffer不要持有，要复制到自己的接收缓冲区
        /// 这个buffer的数据将在事件完成后，重新进行投递
        /// </summary>
        public event EventHandler<SocketRecvEventArgs<T>> SocketRecv;


        private readonly ObjectPool<SocketRecvEventArgs<T>> m_recvEventArgsPool = new ObjectPool<SocketRecvEventArgs<T>>(1024 * 8);


    }

}
