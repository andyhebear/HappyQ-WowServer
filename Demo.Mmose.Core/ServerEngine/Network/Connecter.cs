#region zh-CHS 2006 - 2008 DemoSoft �Ŷ� | en 2006 - 2008 DemoSoft Team

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

#region zh-CHS �������ֿռ� | en Include namespace
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
    [MultiThreadedSupport( "zh-CHS", "��ǰ�������г�Ա��������,֧�ֶ��̲߳���" )]
    public class Connecter : IDisposable
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ���ӳ�ȥ�Ŀͻ��˾��
        /// </summary>
        private ClientSocketManager m_ClientSocketManager = null;
        #endregion
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public Connecter()
        {
            m_SocketClient.EventProcessData += new EventHandler<ProcessDataAtClientEventArgs>( this.OnConnecterProcessMessageBlock );
            m_SocketClient.EventDisconnect += new EventHandler<DisconnectAtClientEventArgs>( this.OnConnecterDisconnect );

            m_ClientSocketManager = new ClientSocketManager( this, m_SocketClient.ConnectHandlerManager.ConnectHandler, new ReceiveQueue() );
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �Ƿ��Ѿ�������Ͽ�
        /// </summary>
        private LockCheck m_LockDisposed = new LockCheck( false );
        #endregion
        /// <summary>
        /// �Ͽ�
        /// </summary>
        public void Dispose()
        {
            if ( m_LockDisposed.SetInvalid() == false )
                return;

            m_SocketClient.StopConnect();
        }
        #endregion

        #region zh-CHS �������� | en Public Properties

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ����������
        /// </summary>
        private SocketClient m_SocketClient = new SocketClient();
        #endregion
        /// <summary>
        /// ������������
        /// </summary>
        public SocketClient ConnecterSocket
        {
            get { return m_SocketClient; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ����ǰ���������
        /// </summary>
        private BaseWorld m_World = null;
        #endregion
        /// <summary>
        /// ����ǰ���������
        /// </summary>
        public BaseWorld World
        {
            get { return m_World; }
            internal set { m_World = value; }
        }

        #endregion

        #region zh-CHS ���з��� | en Public Methods
        /// <summary>
        /// ��ʼ���ӷ����
        /// </summary>
        /// <param name="strHostNamePort">��ַ�Ͷ˿�</param>
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
                // ��ʼ��Disposed
                m_LockDisposed.SetValid();
                m_IsNeedSlice = true;

                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.ConnecterString001, m_ClientSocketManager.Address );

                // ���µ����ӳ�ȥ��Ҫ����ȫ���źŴ����µ�����
                m_World.SetWorldSignal();

                return true;
            }

            return false;
        }
        #endregion

        #region zh-CHS �ڲ����� | en Internal Method

        #region zh-CHS �ڲ����� | en Internal Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
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

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ��
        /// </summary>
        private SpinLock m_LockSliceSocket = new SpinLock();
        #endregion
        /// <summary>
        /// ��ȡ�µ����ӳ�ȥ�Ŀͻ���
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

        #region zh-CHS ˽�е��¼������� | en Private Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnConnecterProcessMessageBlock( object sender, ProcessDataAtClientEventArgs eventArgs )
        {
            // �ڲ��Ѿ�������(Connecter)
            m_ClientSocketManager.ReceiveBuffer.Enqueue( eventArgs.ProcessData.ReadPointer(), 0, eventArgs.ProcessData.WriteLength );

            // �����ź�
            m_ClientSocketManager.ReceiveSignal();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnConnecterDisconnect( object sender, DisconnectAtClientEventArgs eventArgs )
        {
            // �Ͽ��ź�
            m_ClientSocketManager.DisconnectSignal();
        }
        #endregion
    }
}
#endregion