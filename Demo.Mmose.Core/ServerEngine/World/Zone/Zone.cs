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

namespace Demo.Mmose.Core.World.Zone
{
    /// <summary>
    /// 
    /// </summary>
    public class Zone<T> where T : BaseWorld, new()
    {
        #region zh-CHS ˽�г��� | en Private Constants
        /// <summary>
        /// Zone ������ͷ��С
        /// </summary>
        private const int PACKAGE_HEAD = 4;
        #endregion

        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public Zone()
        {
            m_World.EventInitOnceWorld += new EventHandler<BaseWorldEventArgs>( this.ZoneInitOnceServer );
            m_World.EventExitWorld += new EventHandler<BaseWorldEventArgs>( this.ZoneExitWorld );
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
        private void ZoneInitOnceServer( object sender, BaseWorldEventArgs eventArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 
            m_ListenerMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( this.ListenerInitNetState );
            m_ConnecterMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( this.ConnecterIniNetState );

            m_ListenerMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( this.ListenerProcessReceive );
            m_ConnecterMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( this.ConnecterProcessReceive );

            m_ListenerMessagePump.AddListener( m_Listener );
            m_ConnecterMessagePump.AddConnecter( m_Connecter );

            m_World.AddMessagePump( m_ListenerMessagePump );
            m_World.AddMessagePump( m_ConnecterMessagePump );

            //////////////////////////////////////////////////////////////////////////
            // ��ʼע��Э��

            // �ͻ��˵�Э��
            ZonePacketHandlers.Register( (long)ZoneOpCodeToZoneCluster.SMSG_LOGIN_ZONE_CLUSTER_RESULT, 4 + 0, false, new PacketReceiveCallback( ZonePacketHandlers.Zone_HandlerLoginZoneClusterResult ) );
            ZonePacketHandlers.Register( (long)ZoneOpCodeToZoneCluster.SMSG_ADD_CURRENT_ZONE_RESULT, 4 + 0, false, new PacketReceiveCallback( ZonePacketHandlers.Zone_HandlerAddCurrentZoneResult ) );
            ZonePacketHandlers.Register( (long)ZoneOpCodeToZoneCluster.SMSG_REMOVE_CURRENT_ZONE_RESULT, 4 + 0, false, new PacketReceiveCallback( ZonePacketHandlers.Zone_HandlerRemoveCurrentZoneResult ) );
            ZonePacketHandlers.Register( (long)ZoneOpCodeToZoneCluster.SMSG_PONG_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( ZonePacketHandlers.Zone_HandlerPongZoneResult ) );

            ZonePacketHandlers.Register( (long)ZoneOpCodeFromZoneCluster.SMSG_LOGIN_ZONE, 4 + 0, false, new PacketReceiveCallback( ZonePacketHandlers.Zone_HandlerLoginZone ) );
            ZonePacketHandlers.Register( (long)ZoneOpCodeFromZoneCluster.SMSG_NOTIFY_ADD_ZONE, 4 + 0, false, new PacketReceiveCallback( ZonePacketHandlers.Zone_HandlerNotifyAddZone ) );
            ZonePacketHandlers.Register( (long)ZoneOpCodeFromZoneCluster.SMSG_NOTIFY_REMOVE_ZONE, 4 + 0, false, new PacketReceiveCallback( ZonePacketHandlers.Zone_HandlerNotifyRemoveZone ) );
            ZonePacketHandlers.Register( (long)ZoneOpCodeFromZoneCluster.SMSG_PING_ZONE, 4 + 0, false, new PacketReceiveCallback( ZonePacketHandlers.Zone_HandlerPingZone ) );

            ConnectToZoneClusterServer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void ZoneExitWorld( object sender, BaseWorldEventArgs eventArgs )
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
        private BufferPool m_ProcessorBuffers = new BufferPool( "ZoneWorld - ProcessorBuffers", 1024, BUFFER_SIZE );
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
        private ConfigZone m_ConfigZone = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ConfigZone ConfigZone
        {
            get { return m_ConfigZone; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ZonePacketHandlers m_ZonePacketHandlers = new ZonePacketHandlers();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ZonePacketHandlers ZonePacketHandlers
        {
            get { return m_ZonePacketHandlers; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsLoginZoneCluster = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsLoginZoneCluster
        {
            get { return m_IsLoginZoneCluster; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_LogInId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Serial LogInId
        {
            get { return m_LogInId; }
        }
        #endregion

        #region zh-CHS ˽�з��� | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        private bool ConnectToZoneClusterServer()
        {
            if ( m_ConfigZone == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneString001 );

                return false;
            }

            //////////////////////////////////////////////////////////////////////////
            // ��ʼ�����˿�

            if ( m_ConfigZone.ZoneHost == string.Empty )
            {
                if ( m_Listener.StartServer( m_ConfigZone.ZonePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneString002, m_ConfigZone.ZonePort );

                    return false;
                }
            }
            else
            {
                string strHostNamePort = m_ConfigZone.ZoneHost + ":" + m_ConfigZone.ZonePort;

                if ( m_Listener.StartServer( strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneString003, strHostNamePort );

                    return false;
                }
            }

            //////////////////////////////////////////////////////////////////////////
            // ����ZoneCluster�����

            string strHostNamePort2 = m_ConfigZone.ZoneClusterHost + ":" + m_ConfigZone.ZoneClusterPort;

            if ( m_Connecter.StartConnectServer( strHostNamePort2 ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneString004, strHostNamePort2 );

                m_Listener.Dispose();
                return false;
            }

            return true;
        }
        #endregion

        #region zh-CHS ���з��� | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configZone"></param>
        /// <returns></returns>
        public void InitZone( ConfigZone configZone )
        {
            if ( configZone == null )
                throw new Exception( "Zone.InitZone(...) - configZone == null error!" );

            m_ConfigZone = configZone;
        }

        /// <summary>
        /// ����½��ZoneCluster
        /// </summary>
        public void LogoutZone()
        {
        }


        public enum Option
        {
            Asynchronism,
            Synchronization
        }

        /// <summary>
        /// ע�ᵽZoneCluster
        /// </summary>
        public bool RegToZoneCluster( NetState netState, Option option )
        {
            return false;
        }

        /// <summary>
        /// ȡ��ע�ᵽZoneCluster
        /// </summary>
        public bool UnRegToZoneCluster( NetState netState, Option option )
        {
            return false;
        }

        //event LoginZoneCluster;
        //event LogoutZoneCluster;

        #endregion

        #region zh-CHS ˽�е��¼������� | en Private Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void GetPacketLength( object sender, PacketLengthInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 2 ) // ����ZoneWorld��ʵ��(��Ϊ�ǻ��ƻ�����,������Ҫȡģ)
                eventArgs.PacketLength = (ushort)( ( eventArgs.Buffer[( eventArgs.HeadIndex ) % eventArgs.Buffer.Length] ) | eventArgs.Buffer[( eventArgs.HeadIndex + 1 ) % eventArgs.Buffer.Length] << 8 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void GetPacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 4 ) // ����ZoneWorld��ʵ��
                eventArgs.PacketId = (ushort)( eventArgs.Buffer[2] | eventArgs.Buffer[3] << 8 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        private void ListenerInitNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            if ( netStateInit.NetStateInit != null && netStateInit.NetStateInit.World == m_World )
            {
                // ��ʼ���ͻ���
                Zone_ListenerExtendData extendData = new Zone_ListenerExtendData();
                extendData.NetState = netStateInit.NetStateInit;

                // ������չ�����ݵ�NetState
                netStateInit.NetStateInit.RegisterComponent<Zone_ListenerExtendData>( Zone_ListenerExtendData.COMPONENT_ID, extendData );

                // ��ȡ���ĳ���
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( this.GetPacketLength );
            }
            else
                throw new Exception( "Zone.ListenerInitNetState(...) - newNetState == null || newNetState.ExtendData != null || netStateInit.NetStateInit.World != m_World error!" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        private void ConnecterIniNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            if ( netStateInit.NetStateInit != null && netStateInit.NetStateInit.World == m_World )
            {
                // ��ʼ���ͻ���
                Zone_ConnecterExtendData extendData = new Zone_ConnecterExtendData();

                // ������չ�����ݵ�NetState
                netStateInit.NetStateInit.RegisterComponent<Zone_ConnecterExtendData>( Zone_ConnecterExtendData.COMPONENT_ID, extendData );

                // ��ȡ���ĳ���
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( this.GetPacketLength );

                // ���ӵ�ʱ��������½ZoneCluster����
                netStateInit.NetStateInit.EventConnect += new EventHandler<NetStateConnectEventArgs>( this.OnLoginZoneCluster );
            }
            else
                throw new Exception( "ZoneCluster.ConnecterIniNetState(...) - newNetState == null || newNetState.ExtendData != null || netStateInit.NetStateInit.World != m_World error!" );
        }

        /// <summary>
        /// ��ʼ��½ZoneCluster����
        /// </summary>
        private void OnLoginZoneCluster( object sender, NetStateConnectEventArgs eventArgs )
        {
            if ( eventArgs.NetStateConnect == null )
                throw new Exception( "Zone.OnLoginZoneCluster(...) - eventArgs.NetStateConnect == null error!" );

            NetState netState = eventArgs.NetStateConnect;

            // ���͵�½��Ϣ
            if ( netState.Running == true )
                netState.Send( new Zone_LoginZoneCluster( m_ConfigZone.ZoneClusterPassword, m_ConfigZone.ZonePassword ) );
            else
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneString005 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        private void ListenerProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            if ( eventArgs.NetState == null )
                throw new Exception( "Zone.ListenerProcessReceive(...) - netState == null error!" );

            if ( eventArgs.NetState.ReceiveBuffer == null )
                throw new Exception( "Zone.ListenerProcessReceive(...) - eventArgs.NetState.ReceiveBuffer == null error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ListenerProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )��// �ȴ����ݰ�������
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // ���ݰ�����
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ListenerProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ListenerProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

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
                PacketHandler packetHandler = ZonePacketHandlers.GetHandler( iPacketID );
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
        private void ConnecterProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            if ( eventArgs.NetState == null )
                throw new Exception( "Zone.ConnecterProcessReceive(...) - netState == null error!" );

            if ( eventArgs.NetState.ReceiveBuffer == null )
                throw new Exception( "Zone.ConnecterProcessReceive(...) - eventArgs.NetState.ReceiveBuffer == null error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ConnecterProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )��// �ȴ����ݰ�������
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // ���ݰ�����
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ConnecterProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ConnecterProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��ȡ�����ݰ�
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketSize,
                    PACKAGE_HEAD/*���ĳ��ȴ�С-2���ֽڡ�ID��С-2���ֽ�, 4���ֽ�����*/
                    , new EventHandler<PacketIdInfoEventArgs>( this.GetPacketID ) );

                // ��ȡ���ݰ������ID
                long iPacketID = packetReader.GetPacketID();

                // ��ȡ�������ݰ���ʵ��
                PacketHandler packetHandler = ZonePacketHandlers.GetHandler( iPacketID );
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