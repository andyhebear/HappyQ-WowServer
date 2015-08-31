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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server.Language;
using Demo.Mmose.Core.Network;
#endregion

namespace Demo.Mmose.Core.World.DomainWorld
{
    /// <summary>
    /// 
    /// </summary>
    public class Domain<T> where T : BaseWorld, new ()
    {
        #region zh-CHS ˽�г��� | en Private Constants
        /// <summary>
        /// Domain ������ͷ��С
        /// </summary>
        private const int PACKAGE_HEAD = 4;
        #endregion

        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public Domain()
        {
            m_World.EventInitOnceWorld += new EventHandler<BaseWorldEventArgs>( DomainWorld_InitOnceServer );
            m_World.EventExitWorld += new EventHandler<BaseWorldEventArgs>( DomainWorld_ExitWorld );
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Listener m_Listener = new Listener();
        /// <summary>
        /// 
        /// </summary>
        private Connecter m_Connecter = new Connecter();
        /// <summary>
        /// 
        /// </summary>
        private MessagePump m_ListenerMessagePump = new MessagePump();
        /// <summary>
        /// 
        /// </summary>
        private MessagePump m_ConnecterMessagePump = new MessagePump();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void DomainWorld_InitOnceServer( object sender, BaseWorldEventArgs eventArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 
            m_ListenerMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( ListenerInitNetState );
            m_ConnecterMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( ConnecterIniNetState );

            m_ListenerMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( ListenerProcessReceive );
            m_ConnecterMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( ConnecterProcessReceive );

            m_ListenerMessagePump.AddListener( m_Listener );
            m_ConnecterMessagePump.AddConnecter( m_Connecter );

            m_World.AddMessagePump( m_ListenerMessagePump );
            m_World.AddMessagePump( m_ConnecterMessagePump );

            //////////////////////////////////////////////////////////////////////////
            // ��ʼע��Э��

            // �ͻ��˵�Э��
            DomainPacketHandlers.Register( (long)DomainOpCodeToZoneCluster.SMSG_LOGIN_ZONE_CLUSTER_RESULT, 4 + 0, false, new PacketReceiveCallback( DomainPacketHandlers.Domain_HandlerLoginZoneClusterResult ) );
            DomainPacketHandlers.Register( (long)DomainOpCodeToZoneCluster.SMSG_NOTIFY_ADD_ZONE_CLUSTER_RESULT, 4 + 0, false, new PacketReceiveCallback( DomainPacketHandlers.Domain_HandlerNotifyAddZoneClusterResult ) );
            DomainPacketHandlers.Register( (long)DomainOpCodeToZoneCluster.SMSG_NOTIFY_REMOVE_ZONE_CLUSTER_RESULT, 4 + 0, false, new PacketReceiveCallback( DomainPacketHandlers.Domain_HandlerNotifyRemoveZoneClusterResult ) );
            DomainPacketHandlers.Register( (long)DomainOpCodeToZoneCluster.SMSG_PONG_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( DomainPacketHandlers.Domain_HandlerPongZoneCluster ) );

            DomainPacketHandlers.Register( (long)DomainOpCodeFromZoneCluster.SMSG_LOGIN_DOMAIN, 4 + 0, false, new PacketReceiveCallback( DomainPacketHandlers.Domain_HandlerLoginDomain ) );
            DomainPacketHandlers.Register( (long)DomainOpCodeFromZoneCluster.SMSG_ADD_CURRENT_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( DomainPacketHandlers.Domain_HandlerAddCurrentZoneCluster ) );
            DomainPacketHandlers.Register( (long)DomainOpCodeFromZoneCluster.SMSG_REMOVE_CURRENT_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( DomainPacketHandlers.Domain_HandlerRemoveCurrentZoneCluster ) );
            DomainPacketHandlers.Register( (long)DomainOpCodeFromZoneCluster.SMSG_PING_DOMAIN, 4 + 0, false, new PacketReceiveCallback( DomainPacketHandlers.Domain_HandlerPingDomain ) );

            ListenerDomainServer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void DomainWorld_ExitWorld( object sender, BaseWorldEventArgs eventArgs )
        {
            m_Connecter.Dispose();
            m_Listener.Dispose();
        }
        #endregion

        #region zh-CHS ˽������ | en Private Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ZoneWorld �����ݻ���Ĵ�С
        /// </summary>
        private const int BUFFER_SIZE = 4096;
        /// <summary>
        /// 
        /// </summary>
        private BufferPool m_ProcessorBuffers = new BufferPool( "ZoneClusterWorld - ProcessorBuffers", 1024, BUFFER_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private BufferPool ProcessorBuffers
        {
            get { return m_ProcessorBuffers; }
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_World = new T();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T World
        {
            get { return m_World; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ZoneClusterHandler m_ZoneClusterHandler = new ZoneClusterHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ZoneClusterHandler ZoneClusterHandler
        {
            get { return m_ZoneClusterHandler; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ConfigDomain m_ConfigDomain = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ConfigDomain ConfigDomain
        {
            get { return m_ConfigDomain; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DomainPacketHandlers m_DomainPacketHandlers = new DomainPacketHandlers();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public DomainPacketHandlers DomainPacketHandlers
        {
            get { return m_DomainPacketHandlers; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsLoginDomain = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsLoginDomain
        {
            get { return m_IsLoginDomain; }
        }
        #endregion

        #region zh-CHS ˽�з��� | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        private bool ListenerDomainServer()
        {
            if ( m_ConfigDomain == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.DomainString001 );

                return false;
            }

            //////////////////////////////////////////////////////////////////////////
            // ��ʼ�����˿�

            if ( m_ConfigDomain.DomainHost == string.Empty )
            {
                if ( m_Listener.StartServer( m_ConfigDomain.DomainPort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.DomainString002, m_ConfigDomain.DomainPort );

                    return false;
                }
            }
            else
            {
                string strHostNamePort = m_ConfigDomain.DomainHost + ":" + m_ConfigDomain.DomainPort;

                if ( m_Listener.StartServer( strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.DomainString003, strHostNamePort );

                    return false;
                }
            }

            return true;
        }
        #endregion

        #region zh-CHS ���з��� | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configZoneWorld"></param>
        /// <returns></returns>
        public void InitDomain( ConfigDomain configDomain )
        {
            if ( configDomain == null )
                throw new Exception( "Domain.InitDomain(...) - configDomain == null error!" );

            m_ConfigDomain = configDomain;
        }
        #endregion

        #region zh-CHS ˽�е��¼������� | en Private Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void GetPacketLength( object sender, PacketLengthInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 2 ) // ����ZoneCluster��ʵ��(��Ϊ�ǻ��ƻ�����,������Ҫȡģ)
                eventArgs.PacketLength = (ushort)( ( eventArgs.Buffer[( eventArgs.HeadIndex ) % eventArgs.Buffer.Length] ) | eventArgs.Buffer[( eventArgs.HeadIndex + 1 ) % eventArgs.Buffer.Length] << 8 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void GetPacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 4 ) // ����ZoneCluster��ʵ��
                eventArgs.PacketId = (ushort)( eventArgs.Buffer[2] | eventArgs.Buffer[3] << 8 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        internal void ListenerInitNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            if ( netStateInit.NetStateInit != null && netStateInit.NetStateInit.World == m_World )
            {
                // ��ʼ���ͻ���
                Domain_ListenerExtendData extendData = new Domain_ListenerExtendData();

                // ������չ�����ݵ�NetState
                netStateInit.NetStateInit.RegisterComponent<Domain_ListenerExtendData>( Domain_ListenerExtendData.COMPONENT_ID, extendData );

                // ��ȡ���ĳ���
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( this.GetPacketLength );
            }
            else
                throw new Exception( "Domain.ListenerInitNetState(...) - newNetState == null || newNetState.ExtendData != null || netStateInit.NetStateInit.World != m_World error!" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        internal void ConnecterIniNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            if ( netStateInit.NetStateInit != null && netStateInit.NetStateInit.World == m_World )
            {
                // ��ʼ���ͻ���
                Domain_ConnecterExtendData extendData = new Domain_ConnecterExtendData();
                extendData.NetState = netStateInit.NetStateInit;

                // ������չ�����ݵ�NetState
                netStateInit.NetStateInit.RegisterComponent<Domain_ConnecterExtendData>( Domain_ConnecterExtendData.COMPONENT_ID, extendData );

                // ��ȡ���ĳ���
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( this.GetPacketLength );
            }
            else
                throw new Exception( "Domain.ConnecterIniNetState(...) - newNetState == null || newNetState.ExtendData != null || netStateInit.NetStateInit.World != m_World error!" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal void ListenerProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            if ( eventArgs.NetState == null )
                throw new Exception( "Domain.ListenerProcessReceive(...) - netState == null error!" );

            if ( eventArgs.NetState.ReceiveBuffer == null )
                throw new Exception( "Domain.ListenerProcessReceive(...) - eventArgs.NetState.ReceiveBuffer == null error!" );

            ReceiveQueue receiveQueueBuffer = eventArgs.NetState.ReceiveBuffer;
            if ( receiveQueueBuffer.Length < PACKAGE_HEAD )��// �ȴ����ݰ�������
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // ����ʱ��ͻ������ݹ��������Կ��Բ��������ģ�������Ҳû��,���ѱ�֤���߳��д��������е�����
            while ( iReceiveBufferLength >= PACKAGE_HEAD )
            {
                // ReceiveQueue�ڲ��Ѿ�������
                long iPacketSize = receiveQueueBuffer.GetPacketLength();
                if ( iPacketSize < PACKAGE_HEAD )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ListenerProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )��// �ȴ����ݰ�������
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // ���ݰ�����
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ListenerProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��ȡ������
                byte[] packetBuffer = m_ProcessorBuffers.AcquireBuffer();

                // ReceiveQueue�ڲ��Ѿ�������
                long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, iPacketSize );

                // ��ȡ�����ݲ���ͬ
                if ( iReturnPacketSize != iPacketSize )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ListenerProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��ȡ�����ݰ�
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketSize,
                    PACKAGE_HEAD/*���ĳ��ȴ�С-2���ֽڡ�ID��С-2���ֽ�, 4���ֽ�����*/,
                    new EventHandler<PacketIdInfoEventArgs>( this.GetPacketID ) );

                // ��ȡ���ݰ������ID
                long iPacketID = packetReader.GetPacketID();

                // ��ȡ�������ݰ���ʵ��
                PacketHandler packetHandler = DomainPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // ˵����û�н⿪��ǰ�����ݰ�����
                {
                    packetReader.Trace( eventArgs.NetState );

                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    // ��ȡʣ�µ����ݳ���
                    iReceiveBufferLength = receiveQueueBuffer.Length;

                    continue;
                }

                // ��ǰ�账������ݰ��Ĵ�С
                long iPacketHandlerLength = packetHandler.Length;
                if ( iPacketHandlerLength > iReturnPacketSize ) // ����������ݴ�С���ڵõ������ݴ�С
                {
                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��������
                packetHandler.OnReceive( eventArgs.NetState, packetReader );

                // �����ڴ��
                m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                // ��ȡʣ�µ����ݳ���
                iReceiveBufferLength = receiveQueueBuffer.Length;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal void ConnecterProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            if ( eventArgs.NetState == null )
                throw new Exception( "Domain.ConnecterProcessReceive(...) - netState == null error!" );

            if ( eventArgs.NetState.ReceiveBuffer == null )
                throw new Exception( "Domain.ConnecterProcessReceive(...) - eventArgs.NetState.ReceiveBuffer == null error!" );

            ReceiveQueue receiveQueueBuffer = eventArgs.NetState.ReceiveBuffer;
            if ( receiveQueueBuffer.Length < PACKAGE_HEAD )��// �ȴ����ݰ�������
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // ����ʱ��ͻ������ݹ��������Կ��Բ��������ģ�������Ҳû��,���ѱ�֤���߳��д��������е�����
            while ( iReceiveBufferLength >= PACKAGE_HEAD )
            {
                // ReceiveQueue�ڲ��Ѿ�������
                long iPacketSize = receiveQueueBuffer.GetPacketLength();
                if ( iPacketSize < PACKAGE_HEAD )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ConnecterProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )��// �ȴ����ݰ�������
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // ���ݰ�����
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ConnecterProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��ȡ������
                byte[] packetBuffer = m_ProcessorBuffers.AcquireBuffer();

                // ReceiveQueue�ڲ��Ѿ�������
                long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, iPacketSize );

                // ��ȡ�����ݲ���ͬ
                if ( iReturnPacketSize != iPacketSize )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ConnecterProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��ȡ�����ݰ�
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketSize,
                    PACKAGE_HEAD/*���ĳ��ȴ�С-2���ֽڡ�ID��С-2���ֽ�, 4���ֽ�����*/,
                    new EventHandler<PacketIdInfoEventArgs>( this.GetPacketID ) );

                // ��ȡ���ݰ������ID
                long iPacketID = packetReader.GetPacketID();

                // ��ȡ�������ݰ���ʵ��
                PacketHandler packetHandler = DomainPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // ˵����û�н⿪��ǰ�����ݰ�����
                {
                    packetReader.Trace( eventArgs.NetState );

                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    // ��ȡʣ�µ����ݳ���
                    iReceiveBufferLength = receiveQueueBuffer.Length;

                    continue;
                }

                // ��ǰ�账������ݰ��Ĵ�С
                long iPacketHandlerLength = packetHandler.Length;
                if ( iPacketHandlerLength > iReturnPacketSize ) // ����������ݴ�С���ڵõ������ݴ�С
                {
                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��������
                packetHandler.OnReceive( eventArgs.NetState, packetReader );

                // �����ڴ��
                m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                // ��ȡʣ�µ����ݳ���
                iReceiveBufferLength = receiveQueueBuffer.Length;
            }
        }
        #endregion
    }
}
#endregion