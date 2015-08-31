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
using Demo.Mmose.Net;
using Demo.Mmose.Core.Common.Atom;
#endregion

namespace Demo.Mmose.Core.Network
{
    /// <summary>
    /// ���ӹ����Ŀͻ���
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "��ǰ�������г�Ա��������,֧�ֶ��̲߳���" )]
    public sealed class ClientSocketManager
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        internal ClientSocketManager( Listener listener, ServiceHandler serviceHandler, ReceiveQueue receiveBuffer )
        {
            if ( listener == null )
                throw new Exception( "ClientSocketHandler.ClientSocketManager(...) - listener == null error!" );

            if ( serviceHandler == null )
                throw new Exception( "ClientSocketHandler.ClientSocketManager(...) - serviceHandle == null error!" );

            if ( receiveBuffer == null )
                throw new Exception( "ClientSocketHandler.ClientSocketManager(...) - receiveBuffer == null error!" );

            m_Listener = listener;
            m_ServiceHandle = serviceHandler;
            m_ReceiveBuffer = receiveBuffer;
            {
                // �������
                m_ReceiveBuffer.Clear();
            }

            m_ServiceHandle.EventProcessData += new EventHandler<ProcessDataAtServerEventArgs>( this.OnListenerProcessMessageBlock );
            m_ServiceHandle.EventDisconnect += new EventHandler<DisconnectAtServerEventArgs>( this.OnListenerDisconnect );

            // ��ʼ������ ��ʾ��û���ù�Free(...)����
            m_LockFree.SetValid();
        }

        /// <summary>
        /// 
        /// </summary>
        internal ClientSocketManager( Connecter connecter, ConnectHandler connectHandler, ReceiveQueue receiveBuffer  )
        {
            if ( connecter == null )
                throw new Exception( "ClientSocketHandler.ClientSocketManager(...) - listener == null error!" );

            if ( connectHandler == null )
                throw new Exception( "ClientSocketHandler.ClientSocketManager(...) - serviceHandle == null error!" );

            if ( receiveBuffer == null )
                throw new Exception( "ClientSocketHandler.ClientSocketManager(...) - receiveBuffer == null error!" );

            m_Connecter = connecter;
            m_ConnectHandle = connectHandler;
            m_ReceiveBuffer = receiveBuffer;
            {
                // �������
                m_ReceiveBuffer.Clear();
            }

            // ��ʼ������ ��ʾ��û���ù�Free(...)����
            m_LockFree.SetValid();
        }
        #endregion

        #region zh-CHS �ڲ����� | en Internal Properties

        #region zh-CHS �ڲ� Listener ���� | en Internal  Listener Properties

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ����������
        /// </summary>
        private ServiceHandler m_ServiceHandle = null;
        #endregion
        /// <summary>
        /// ������������
        /// </summary>
        internal ServiceHandler ListenerSocket
        {
            get { return m_ServiceHandle; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private volatile Listener m_Listener = null;
        #endregion
        /// <summary>
        /// ������������
        /// </summary>
        internal Listener Listener
        {
            get { return m_Listener; }
        }
        #endregion

        #region zh-CHS �ڲ� Connecter ���� | en Internal Connecter Properties

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �����Ӵ���
        /// </summary>
        private ConnectHandler m_ConnectHandle;
        #endregion
        /// <summary>
        /// ���ӵ�������
        /// </summary>
        internal ConnectHandler ConnecterSocket
        {
            get { return m_ConnectHandle; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private volatile Connecter m_Connecter = null;
        #endregion
        /// <summary>
        /// ���ӵ�������
        /// </summary>
        internal Connecter Connecter
        {
            get { return m_Connecter; }
        }
        #endregion

        #endregion

        #region zh-CHS �������� | en Public Properties
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsOnline
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.IsOnline;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.IsOnline;
                else
                    throw new Exception( "ClientSocketHandler.IsOnline(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        /// <summary>
        /// Զ�̶˿�
        /// </summary>
        public int RemotePort
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.RemotePort;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.RemotePort;
                else
                    throw new Exception( "ClientSocketHandler.RemotePort(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        /// <summary>
        /// ��һ�����ݰ���ʱ��
        /// </summary>
        public DateTime FirstTime
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.FirstTime;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.FirstTime;
                else
                    throw new Exception( "ClientSocketHandler.FirstTime(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        /// <summary>
        /// Զ�̵ĵ�ַ
        /// </summary>
        public string RemoteOnlyIP
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.RemoteOnlyIP;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.RemoteOnlyIP;
                else
                    throw new Exception( "ClientSocketHandler.RemoteOnlyIP(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public TimeSpan OnlineTime
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.OnlineTime;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.OnlineTime;
                else
                    throw new Exception( "ClientSocketHandler.OnlineTime(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        /// <summary>
        /// �ͻ��εĵ�ַ��˿�
        /// </summary>
        public string Address
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.ClientAddress;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.ServerAddress;
                else
                    throw new Exception( "ClientSocketHandler.Address(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        /// <summary>
        /// ��Ϣ����������
        /// </summary>
        public long MessageBlockNumbers
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.MessageBlockNumbers;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.MessageBlockNumbers;
                else
                    throw new Exception( "ClientSocketHandler.MessageBlockNumbers(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        /// <summary>
        /// 60���ڵ����ݰ�������
        /// </summary>
        public long MessageBlockNumbers60sec
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.MessageBlockNumbers60sec;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.MessageBlockNumbers60sec;
                else
                    throw new Exception( "ClientSocketHandler.MessageBlockNumbers60sec(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        /// <summary>
        /// ������ݰ���ʱ��
        /// </summary>
        public DateTime LastMessageBlockTime
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.LastMessageBlockTime;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.LastMessageBlockTime;
                else
                    throw new Exception( "ClientSocketHandler.LastMessageBlockTime(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        /// <summary>
        /// ���ݰ������ʱ��
        /// </summary>
        public TimeSpan MessageBlockSpacingTime
        {
            get
            {
                if ( m_ServiceHandle != null )
                    return m_ServiceHandle.MessageBlockSpacingTime;
                else if ( m_ConnectHandle != null )
                    return m_ConnectHandle.MessageBlockSpacingTime;
                else
                    throw new Exception( "ClientSocketHandler.MessageBlockSpacingTime(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
            }
        }

        #region zh-CHS NetState���� | en NetState Properties

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NetState m_NetState = null;
        #endregion
        /// <summary>
        /// ���ù���ǰ���������
        /// </summary>
        public NetState NetState
        {
            get { return m_NetState; }
            set
            {
                if ( m_NetState == value )
                    return;
                else
                    m_NetState = value;

                // ����Ƿ�����״̬
                if ( this.IsOnline == false )
                {
                    this.DisconnectSignal();
                    return;
                }

                // ����Ƿ��Ѿ������ݹ���
                if ( m_ReceiveBuffer.Length > 0 )
                    this.ReceiveSignal();
            }
        }

        #endregion

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ���ܵ������ݰ�
        /// </summary>
        private ReceiveQueue m_ReceiveBuffer = null;
        #endregion
        /// <summary>
        /// ���ܵ������ݴ�Ŵ�
        /// </summary>
        public ReceiveQueue ReceiveBuffer
        {
            get { return m_ReceiveBuffer; }
        }
        #endregion

        #region zh-CHS �ڲ����� | en Internal Methods
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private LockCheck m_LockFree = new LockCheck( false );
        #endregion
        /// <summary>
        /// �ڲ��Ͽ�(���ú���಻���ٽ����κδ���,��Ϊ�ѷ��ؽ��ڴ��)
        /// </summary>
        internal void Free()
        {
            // �����û�е��ù�Free(...)����
            if ( m_LockFree.SetInvalid() == false )
                return;

            // �ȵ���Clear(...)
            m_ReceiveBuffer.Clear();

            // ȡ���ص�
            if ( m_ServiceHandle != null )
            {
                m_ServiceHandle.EventProcessData -= new EventHandler<ProcessDataAtServerEventArgs>( this.OnListenerProcessMessageBlock );
                m_ServiceHandle.EventDisconnect -= new EventHandler<DisconnectAtServerEventArgs>( this.OnListenerDisconnect );
            }

            // �����Listener������Ҫ�ͷ����ڴ����...
            if ( m_Listener != null )
                m_Listener.Free( m_ReceiveBuffer );
        }
        #endregion

        #region zh-CHS ���з��� | en Public Methods
        /// <summary>
        /// �ر�����
        /// </summary>
        public void CloseSocket()
        {
            if ( m_ServiceHandle != null )
                m_ServiceHandle.CloseSocket();
            else if ( m_ConnectHandle != null )
                m_ConnectHandle.CloseSocket();
            else
                throw new Exception( "ClientSocketHandler.CloseSocket(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sendMessageBlock"></param>
        public void SendTo( MessageBlock sendMessageBlock )
        {
            if ( m_ServiceHandle != null )
                m_ServiceHandle.SendTo( sendMessageBlock );
            else if ( m_ConnectHandle != null )
                m_ConnectHandle.SendTo( sendMessageBlock );
            else
                throw new Exception( "ClientSocketHandler.SendTo(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MessageBlock GetNewSendMessageBlock()
        {
            if ( m_ServiceHandle != null )
                return m_ServiceHandle.Owner.ServiceHandleManager.GetNewSendMessageBlock();
            else if ( m_ConnectHandle != null )
                return m_ConnectHandle.Owner.ConnectHandlerManager.GetNewSendMessageBlock();
            else
                throw new Exception( "ClientSocketHandler.GetNewSendMessageBlock(...) - m_SocketClientAtServer == null || m_SocketClientAtClient == null error!" );
        }
        #endregion

        #region zh-CHS �ڲ�֪ͨ�źŷ��� | en Internal Signal Method
        /// <summary>
        /// �����ź�
        /// </summary>
        internal void ReceiveSignal()
        {
            // ��Ҫ��⣬���ܻ�û������m_NetState���Ϳ�ʼ���ô�����
            if ( m_NetState != null )
                m_NetState.OnReceive();
        }

        /// <summary>
        /// �Ͽ��ź�
        /// </summary>
        internal void DisconnectSignal()
        {
            // ��Ҫ��⣬���ܻ�û������m_NetState���Ϳ�ʼ���ô�����
            if ( m_NetState != null )
                m_NetState.OnDisconnect();
        }
        #endregion

        #region zh-CHS ˽�е��¼������� | en Private Event Handlers
        /// <summary>
        /// ���ܵ��µ����ݰ�
        /// </summary>
        /// <param name="RecvMessageBlock"></param>
        private void OnListenerProcessMessageBlock( object sender, ProcessDataAtServerEventArgs recvMessageBlock )
        {
            // �ڲ��Ѿ�������(Listener)
            m_ReceiveBuffer.Enqueue( recvMessageBlock.ProcessData.ReadPointer(), 0, recvMessageBlock.ProcessData.WriteLength );

            this.ReceiveSignal();
        }

        /// <summary>
        /// �Ͽ�
        /// </summary>
        private void OnListenerDisconnect( object sender, DisconnectAtServerEventArgs emptyEventArgs )
        {
            this.DisconnectSignal();
        }
        #endregion
    }
}
#endregion