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
using System.Diagnostics;
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server.Language;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.World;
using Demo.Mmose.Net;
using Demo.Mmose.Core.Common.Atom;
#endregion

namespace Demo.Mmose.Core.Network
{
    /// <summary>
    /// 
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
    public class Connecter : IDisposable
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 连接出去的客户端句柄
        /// </summary>
        private ClientSocketManager m_ClientSocketManager = null;
        #endregion
        /// <summary>
        /// 初始化构造
        /// </summary>
        public Connecter()
        {
            m_SocketClient.EventProcessData += new EventHandler<ProcessDataAtClientEventArgs>( this.OnConnecterProcessMessageBlock );
            m_SocketClient.EventDisconnect += new EventHandler<DisconnectAtClientEventArgs>( this.OnConnecterDisconnect );

            m_ClientSocketManager = new ClientSocketManager( this, m_SocketClient.ConnectHandlerManager.ConnectHandler, new ReceiveQueue() );
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

            m_SocketClient.StopConnect();
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主监听处理
        /// </summary>
        private SocketClient m_SocketClient = new SocketClient();
        #endregion
        /// <summary>
        /// 监听的主处理
        /// </summary>
        public SocketClient ConnecterSocket
        {
            get { return m_SocketClient; }
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
        /// 开始连接服务端
        /// </summary>
        /// <param name="strHostNamePort">地址和端口</param>
        /// <returns></returns>
        public bool StartConnectServer( string strHostNamePort )
        {
            if ( string.IsNullOrEmpty( strHostNamePort ) == true )
                throw new ArgumentException( "Connecter.StartConnectServer(...) - string.IsNullOrEmpty(...) == true error!", "strHostNamePort" );

            if ( m_World == null )
                throw new Exception( "Connecter.StartConnectServer(...) - m_World == null error!" );
      
            if ( m_SocketClient.IsConnected == true )
                throw new Exception( "Connecter.StartConnectServer(...) - m_SocketClient.IsConnected == true error!" );

            if ( m_SocketClient.StartConnectServer( strHostNamePort ) == true )
            {
                // 初始化Disposed
                m_LockDisposed.SetValid();
                m_IsNeedSlice = true;

                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.ConnecterString001, m_ClientSocketManager.Address );

                // 有新的连接出去需要发送全局信号处理新的连接
                m_World.SetWorldSignal();

                return true;
            }

            return false;
        }
        #endregion

        #region zh-CHS 内部方法 | en Internal Method

        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsNeedSlice = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsNeedSlice
        {
            get { return m_IsNeedSlice; }
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 锁
        /// </summary>
        private SpinLock m_LockSliceSocket = new SpinLock();
        #endregion
        /// <summary>
        /// 获取新的连接出去的客户端
        /// </summary>
        /// <returns></returns>
        internal ClientSocketManager Slice()
        {
            ClientSocketManager returnSocket = null;

            m_LockSliceSocket.Enter();
            {
                if ( m_IsNeedSlice == true )
                {
                    m_IsNeedSlice = false;
                    returnSocket = m_ClientSocketManager;
                }
            }
            m_LockSliceSocket.Exit();

            return returnSocket;
        }

        #endregion

        #region zh-CHS 私有的事件处理函数 | en Private Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnConnecterProcessMessageBlock( object sender, ProcessDataAtClientEventArgs eventArgs )
        {
            // 内部已经有锁定(Connecter)
            m_ClientSocketManager.ReceiveBuffer.Enqueue( eventArgs.ProcessData.ReadPointer(), 0, eventArgs.ProcessData.WriteLength );

            // 接受信号
            m_ClientSocketManager.ReceiveSignal();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnConnecterDisconnect( object sender, DisconnectAtClientEventArgs eventArgs )
        {
            // 断开信号
            m_ClientSocketManager.DisconnectSignal();
        }
        #endregion
    }
}
#endregion