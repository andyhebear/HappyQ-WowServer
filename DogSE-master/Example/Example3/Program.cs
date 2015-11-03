﻿using DogSE.Library.Log;
using DogSE.Server.Core.Net;
using DogSE.Server.Core.Task;
using DogSE.Server.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DogSE.Server.Core.TaskT;

namespace Example2
{
    /// <summary>
    /// 加锁处理demo
    /// </summary>
    class Program
    {
        
        static void Main(string[] args)
        {
            Logs.AddConsoleAppender();

            //  注册网络消息
            packetHandlersManager.Register((ushort) OpCode.Login, OnLogin);
            packetHandlersManager.Register((ushort)OpCode.SendMessage, OnSendMessage);
            packetHandlersManager.Register((ushort)OpCode.RecvPrivateMessage, OnSendPrivateMessage);

            var servers = new Listener<Session>();
            servers.SocketConnect += OnSocketConnect;
            servers.SocketDisconnect += OnSocketDisconnect;
            servers.SocketRecv += OnSocketRecv;
            servers.StartServer(10086);

            Logs.Info("服务器启动，等待客户端连接。按Esc键退出");
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    break;

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// socket连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnSocketConnect(object sender, SocketConnectEventArgs<Session> e)
        {
            //  互相绑定
            var s = new Session();
            s.Client = e.Session;
            e.Session.Data = s;

            lock (sessions)
            {
                nologinSessions.Add(s);
            }
        }

        /// <summary>
        /// Socket关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnSocketDisconnect(object sender, SocketDisconnectEventArgs<Session> e)
        {
            var s = e.Session.Data;
            lock (sessions)
            {
                if (s.IsLogin)
                    sessions.Remove(s);
                else
                    nologinSessions.Remove(s);
            }

            //  解除互相的引用关系
            s.Client = null;
            e.Session.Data = null;
        }

        /// <summary>
        /// 收到Socket数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnSocketRecv(object sender, SocketRecvEventArgs<Session> e)
        {
            var session = e.Session.Data;
            session.RQ.Enqueue(e.Buffer.Bytes, 0, e.Buffer.Length);

            var packetlen = session.RQ.GetPacketLength();
            while (packetlen >= session.RQ.Length)
            {
                var dogBuffer = new DogBuffer();
                session.RQ.Dequeue(dogBuffer.Bytes, 0, packetlen);

                var reader = new PacketReader();
                reader.SetBuffer(dogBuffer);

                var pid = reader.GetPacketID();
                var handler = packetHandlersManager.GetHandler(pid);
                if (handler == null)
                {
                    Logs.Error("未知消息ID {0}", pid);
                }
                else
                {
                    handler.OnReceive(session, reader);
                }

                packetlen = session.RQ.GetPacketLength();
            }

        }

        /// <summary>
        /// 客户端连接列表
        /// </summary>
        private static readonly List<Session> sessions = new List<Session>();

        /// <summary>
        /// 未验证过的Session
        /// </summary>
        private static readonly List<Session> nologinSessions = new List<Session>();


        private static readonly PacketHandlersBaseT<Session> packetHandlersManager = new PacketHandlersBaseT<Session>();

        /// <summary>
        /// 登录服务器
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reader"></param>
        static void OnLogin(Session session, PacketReader reader)
        {
            var userName = reader.ReadUTF8String();
            var pwd = reader.ReadUTF8String();

            if (string.IsNullOrEmpty(userName))
            {
                Logs.Error("连接的用户名是空");
                session.Client.CloseSocket();
            }

            if (pwd != "123")
            {
                Logs.Error("用户名 {0} 速度的密码错误", userName);
                var writer = new PacketWriter();
                writer.SetNetCode((ushort)OpCode.LoginResult);
                writer.Write(1);    //  0表示登录成功 1表示密码错误
                session.Client.SendPackage(writer.GetBuffer());
                return;
            }

            lock (sessions)
            {
                //  如果玩家之前登录过，则把之前的客户端踢下线
                var exists = sessions.FirstOrDefault(o => o.Name == userName);
                if (exists != null)
                {
                    exists.IsLogin = false;
                    sessions.Remove(exists);
                    exists.Client.CloseSocket();
                }

                //  登录完成
                session.IsLogin = true;
                nologinSessions.Remove(session);
                sessions.Add(session);
            }

            session.Name = userName;
            session.Pwd = pwd;

            var writer2 = new PacketWriter();
            writer2.SetNetCode((ushort)OpCode.LoginResult);
            writer2.Write(0);    //  0表示登录成功 1表示密码错误
            session.Client.SendPackage(writer2.GetBuffer());
        }

        /// <summary>
        /// 给聊天室里的人都发消息
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reader"></param>
        static void OnSendMessage(Session session, PacketReader reader)
        {
            var message = reader.ReadUTF8String();
            if (string.IsNullOrEmpty(message))
            {
                //  空消息
                return;
            }

            //  广播给所有在线的用户
            var writer = new PacketWriter();
            writer.SetNetCode((ushort)OpCode.RecvMessage);
            lock (sessions)
            {
                foreach (var ss in sessions)
                {
                    ss.Client.SendPackage(writer.GetBuffer());
                }
            }
        }

        /// <summary>
        /// 给聊天室里的某人单独发消息
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reader"></param>
        static void OnSendPrivateMessage(Session session, PacketReader reader)
        {
            var userName = reader.ReadUTF8String();
            var message = reader.ReadUTF8String();

            if (message == null)
                return;
            Session target = null;

            lock (sessions)
            {
                 target = sessions.FirstOrDefault(o => o.Name == userName);
                if (target == null)
                    return;
            }

            var writer = new PacketWriter();
            writer.SetNetCode((ushort) OpCode.RecvPrivateMessage);
            writer.WriteUTF8Null(session.Name);
            writer.WriteUTF8Null(message);

            target.Client.SendPackage(writer.GetBuffer());
        }

    }

    public class Session
    {
        public Session()
        {
            RQ = new ReceiveQueue();
        }

        public string Name { get; set; }

        public string Pwd { get; set; }

        /// <summary>
        /// 是否已经登录验证过
        /// </summary>
        public bool IsLogin { get; set; }

        public ClientSession<Session> Client { get; set; }

        public ReceiveQueue RQ { get; set; }
    

    }
}
