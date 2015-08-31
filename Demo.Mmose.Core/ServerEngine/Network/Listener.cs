#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.EventSkin;
using Demo.Mmose.Core.Server.Language;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.World;
using Demo.Mmose.Net;
using Demo.Mmose.Core.Common.Atom;
#endregion

namespace Demo.Mmose.Core.Network
{
    /// <summary>
    /// 服务端监听
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
    public class Listener : IDisposable
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int QUEUE_CAPACITY_SIZE = 1024;
        #endregion
        /// <summary>
        /// 监听到的客户端
        /// </summary>
        private Queue<ClientSocketManager> m_Accepted = new Queue<ClientSocketManager>( QUEUE_CAPACITY_SIZE );
        /// <summary>
        /// 监听到的客户端的锁
        /// </summary>
        private SpinLock m_LockAccepted = new SpinLock();
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        public Listener()
        {
            m_SocketServer.EventAcceptor += new EventHandler<AcceptorEventArgs>( this.OnAcceptor );
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否已经处理过断开
        /// </summary>
        private LockCheck m_LockDisposed = new LockCheck( false );
        #endregion
        /// <summary>
        /// 断开
        /// </summary>
        public void Dispose()
        {
            if ( m_LockDisposed.SetInvalid() == false )
                return;

            m_SocketServer.StopServer();
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主监听处理
        /// </summary>
        private SocketServer m_SocketServer = new SocketServer();
        #endregion
        /// <summary>
        /// 监听的主处理
        /// </summary>
        public SocketServer ListenerSocket
        {
            get { return m_SocketServer; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 管理当前的世界服务
        /// </summary>
        private BaseWorld m_World = null;
        #endregion
        /// <summary>
        /// 管理当前的世界服务
        /// </summary>
        public BaseWorld World
        {
            get { return m_World; }
            internal set { m_World = value; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 开始服务
        /// </summary>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public bool StartServer( uint port )
        {
            if ( m_SocketServer.IsListened == true )
                throw new Exception( "Listener.StartServer(...) - m_SocketServer.IsConnected == true error!" );

            if ( m_SocketServer.StartServer( port ) == true )
            {
                // 初始化Disposed
                m_LockDisposed.SetValid();

                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.ListenerString001, port );

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 开始服务
        /// </summary>
        /// <param name="strHostNamePort">地址和端口</param>
        /// <returns></returns>
        public bool StartServer( string strHostNamePort )
        {
            if ( string.IsNullOrEmpty( strHostNamePort ) == true )
                throw new ArgumentException( "Listener.StartServer(...) - string.IsNullOrEmpty(...) == true error!", "strHostNamePort" );

            if ( m_SocketServer.IsListened == true )
                throw new Exception( "Listener.StartServer(...) - m_SocketServer.IsConnected == true error!" );

            if ( m_SocketServer.StartServer( strHostNamePort ) == true )
            {
                // 初始化Disposed
                m_LockDisposed.SetValid();

                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.ListenerString002, strHostNamePort );

                return true;
            }
            else
                return false;
        }
        #endregion

        #region zh-CHS 内部方法 | en Internal Method
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 空的ClientSocketHandler数组
        /// </summary>
        private static ClientSocketManager[] s_EmptySockets = new ClientSocketManager[0];
        #endregion
        /// <summary>
        /// 获取新的联接过来的客户端
        /// </summary>
        /// <returns></returns>
        internal ClientSocketManager[] Slice()
        {
            ClientSocketManager[] arrayReturn = s_EmptySockets;

            if ( m_Accepted.Count == 0 )
                return s_EmptySockets;

            m_LockAccepted.Enter();
            {
                if ( m_Accepted.Count > 0 )
                {
                    arrayReturn = m_Accepted.ToArray();

                    // 清空数据,让它的调用着来处理这些数据
                    m_Accepted.Clear();
                }
            }
            m_LockAccepted.Exit();

            return arrayReturn;
        }

        /// <summary>
        /// 释放指定的客户端到内存池里面
        /// </summary>
        /// <param name="clientSocketHandler"></param>
        internal void Free( ReceiveQueue receiveQueue )
        {
            // 返回至内存池(ClientSocketHandler)
            m_ReceiveQueuePool.ReleasePoolContent( receiveQueue );
        }
        #endregion

        #region zh-CHS 私有的事件处理函数 | en Private Event Handlers
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主要是需要保留ReceiveQueue
        /// </summary>
        private MemoryPool<ReceiveQueue> m_ReceiveQueuePool = new MemoryPool<ReceiveQueue>( "Listener - ReceiveQueue", 1024 );
        #endregion
        /// <summary>
        /// 连接新的客户端的处理
        /// </summary>
        /// <param name="NonceClientHandler"></param>
        /// <param name="AllHandlerManager"></param>
        /// <param name="ClientHandlerAtServer"></param>
        private void OnAcceptor( object sender, AcceptorEventArgs eventArgs )
        {
            SocketConnectEventArgs socketConnectEventArgs = new SocketConnectEventArgs( eventArgs.AcceptorHandle );
            GlobalEvent.InvokeSocketConnect( socketConnectEventArgs );

            // 如果允许连接
            if ( socketConnectEventArgs.AllowConnection == true )
            {
                ClientSocketManager newClientSocketHandler = new ClientSocketManager( this, eventArgs.AcceptorHandle, m_ReceiveQueuePool.AcquirePoolContent() );

                m_LockAccepted.Enter();
                {
                    m_Accepted.Enqueue( newClientSocketHandler );
                }
                m_LockAccepted.Exit();

                LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.ListenerString003, eventArgs.AcceptorHandle.ClientAddress, eventArgs.AcceptorHandleManager.OnlineClients, eventArgs.AcceptorHandleManager.TotalClients );

                // 有新的连接过来需要发送全局信号处理新的连接
                m_World.SetWorldSignal();
            }
            else // 不允许连接
            {
                try
                {
                    eventArgs.AcceptorHandle.CloseSocket();
                }
                catch
                {
                    Debug.WriteLine( "Listener.OnAcceptor(...) - NonceClientHandler.CloseSocket(...) Exception error!" );
                }

                LOGs.WriteLine( LogMessageType.MSG_WARNING, LanguageString.SingletonInstance.ListenerString004, eventArgs.AcceptorHandle.ClientAddress, eventArgs.AcceptorHandleManager.OnlineClients, eventArgs.AcceptorHandleManager.TotalClients );
            }
        }
        #endregion
    }
}
#endregion

