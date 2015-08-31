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
using Demo.Mmose.Core.World.DomainWorld;
#endregion

namespace Demo.Mmose.Core.World.ZoneClusterWorld
{
    /// <summary>
    /// 
    /// </summary>
    public class ZoneCluster<WorldT> where WorldT : BaseWorld, new ()
    {
        #region zh-CHS ˽�г��� | en Private Constants
        /// <summary>
        /// ZoneCluster ������ͷ��С
        /// </summary>
        private const int PACKAGE_HEAD = 4;
        #endregion

        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public ZoneCluster()
        {
            m_World.EventInitOnceWorld += new EventHandler<BaseWorldEventArgs>( this.ZoneClusterInitOnceServer );
            m_World.EventExitWorld += new EventHandler<BaseWorldEventArgs>( this.ZoneClusterExitWorld );
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
        private void ZoneClusterInitOnceServer( object sender, BaseWorldEventArgs eventArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 
            m_ListenerMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( ListenerInitNetState );
            m_ConnecterMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( ConnecterInitNetState );

            m_ListenerMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( ListenerProcessReceive );
            m_ConnecterMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( ConnecterProcessReceive );

            m_ListenerMessagePump.AddListener( m_Listener );
            m_ConnecterMessagePump.AddConnecter( m_Connecter );

            m_World.AddMessagePump( m_ListenerMessagePump );
            m_World.AddMessagePump( m_ConnecterMessagePump );

            //////////////////////////////////////////////////////////////////////////
            // ��ʼע��Э��

            // �ͻ��˵�Э��
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeToZone.SMSG_LOGIN_ZONE_RESULT, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerLoginZoneResult ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeToZone.SMSG_NOTIFY_ADD_ZONE_RESULT, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerNotifyAddZoneResult ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeToZone.SMSG_NOTIFY_REMOVE_ZONE_RESULT, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerNotifyRemoveZoneResult ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeToZone.SMSG_PONG_ZONE, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerPongZone ) );

            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeToDomain.SMSG_LOGIN_DOMAIN_RESULT, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerLoginDomainResult ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeToDomain.SMSG_ADD_CURRENT_ZONE_CLUSTER_RESULT, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerAddCurrentZoneClusterResult ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeToDomain.SMSG_REMOVE_CURRENT_ZONE_CLUSTER_RESULT, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerRemoveCurrentZoneClusterResult ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeToDomain.SMSG_PONG_DOMAIN, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerPongDomain ) );

            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeFromZone.SMSG_LOGIN_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerLoginZoneCluster ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeFromZone.SMSG_ADD_CURRENT_ZONE, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerAddCurrentZone ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeFromZone.SMSG_REMOVE_CURRENT_ZONE, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerRemoveCurrentZone ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeFromZone.SMSG_ZONE_PING_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerZonePingZoneCluster ) );

            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeFromDomain.SMSG_LOGIN_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerLoginZoneCluster ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeFromDomain.SMSG_NOTIFY_ADD_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerNotifyAddZoneCluster ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeFromDomain.SMSG_NOTIFY_REMOVE_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerNotifyRemoveZoneCluster ) );
            ZoneClusterPacketHandlers.Register( (long)ZoneClusterOpCodeFromDomain.SMSG_DOMAIN_PING_ZONE_CLUSTER, 4 + 0, false, new PacketReceiveCallback( ZoneClusterPacketHandlers.ZoneCluster_HandlerDomainPingZoneCluster ) );

            ConnectToDomainServer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void ZoneClusterExitWorld( object sender, BaseWorldEventArgs eventArgs )
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
        private WorldT m_World = new WorldT();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WorldT World
        {
            get { return m_World; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ZoneHandler m_ZoneHandler = new ZoneHandler();
                #endregion
        /// <summary>
        /// 
        /// </summary>
        public ZoneHandler ZoneHandler
        {
            get { return m_ZoneHandler; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ZoneClusterHandler m_DomainHandler = new ZoneClusterHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ZoneClusterHandler DomainHandler
        {
            get { return m_DomainHandler; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ConfigZoneCluster m_ConfigZoneCluster = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ConfigZoneCluster ConfigZoneCluster
        {
            get { return m_ConfigZoneCluster; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ZoneClusterPacketHandlers m_ZoneClusterPacketHandlers = new ZoneClusterPacketHandlers();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private ZoneClusterPacketHandlers ZoneClusterPacketHandlers
        {
            get { return m_ZoneClusterPacketHandlers; }
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
        private bool ConnectToDomainServer()
        {
            if ( m_ConfigZoneCluster == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneClusterString001 );

                return false;
            }

            //////////////////////////////////////////////////////////////////////////
            // ��ʼ�����˿�

            if ( m_ConfigZoneCluster.ZoneClusterHost == string.Empty )
            {
                if ( m_Listener.StartServer( m_ConfigZoneCluster.ZoneClusterPort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneClusterString002, m_ConfigZoneCluster.ZoneClusterPort );

                    return false;
                }
            }
            else
            {
                string strHostNamePort = m_ConfigZoneCluster.ZoneClusterHost + ":" + m_ConfigZoneCluster.ZoneClusterPort;

                if ( m_Listener.StartServer( strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneClusterString003, strHostNamePort );

                    return false;
                }
            }


            //////////////////////////////////////////////////////////////////////////
            // ����Domain�����

            string strHostNamePort2 = m_ConfigZoneCluster.DomainHost + ":" + m_ConfigZoneCluster.DomainPort;

            if ( m_Connecter.StartConnectServer( strHostNamePort2 ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneClusterString004, strHostNamePort2 );

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
        /// <param name="configZoneWorld"></param>
        /// <returns></returns>
        public void InitZoneCluster( ConfigZoneCluster configZoneCluster )
        {
            if ( configZoneCluster == null )
                throw new Exception( "ZoneCluster.InitZoneCluster(...) - configZoneCluster == null error!" );

            m_ConfigZoneCluster = configZoneCluster;
        }

        /// <summary>
        /// 
        /// </summary>
        public void unInitZoneCluster()
        {
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public Zone[] ToArray()
        //{
        //    return null;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <returns></returns>
        public ZoneID GetZoneId( NetState netState )
        {
            return null;
        }

        public int SentToZone( NetState toNetState, string strMessage )
        {
            return 0;
        }

        public class ZoneID
        {
            public int id;



            NetState[] ToArray()
            {
                return null;
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        public class Channel
        {
            public int id;

            public void Add (NetState netState)
            {
            }

            public void remove( NetState netState )
            {
            }

            public void Broadcast()
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Channel CreateChannel()
        {
            return null;
        }

        //event LoginZone;
        //event LogoutZone;

        //event LoginNetStateOnZone;
        //event LogoutNetStateOnZone;

        //event RegToZoneCluster;

        //event UnRegToZoneCluster;

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
                ZoneCluster_ListenerExtendData extendData = new ZoneCluster_ListenerExtendData();
                extendData.ConfigZoneCluster = m_ConfigZoneCluster;

                // ������չ�����ݵ�NetState
                netStateInit.NetStateInit.RegisterComponent<ZoneCluster_ListenerExtendData>( ZoneCluster_ListenerExtendData.COMPONENT_ID, extendData );

                // ��ȡ���ĳ���
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( this.GetPacketLength );
            }
            else
                throw new Exception( "ZoneCluster.ListenerInitNetState(...) - newNetState == null || newNetState.ExtendData != null || netStateInit.NetStateInit.World != m_World error!" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        internal void ConnecterInitNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            if ( netStateInit.NetStateInit != null && netStateInit.NetStateInit.World == m_World )
            {
                // ��ʼ���ͻ���
                ZoneCluster_ConnecterExtendData extendData = new ZoneCluster_ConnecterExtendData();
                extendData.NetState = netStateInit.NetStateInit;

                // ������չ�����ݵ�NetState
                netStateInit.NetStateInit.RegisterComponent<ZoneCluster_ConnecterExtendData>( ZoneCluster_ConnecterExtendData.COMPONENT_ID, extendData );

                // ��ȡ���ĳ���
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( this.GetPacketLength );
               
                // ���ӵ�ʱ��������½ZoneCluster����
                netStateInit.NetStateInit.EventConnect += new EventHandler<NetStateConnectEventArgs>( this.OnLoginDomain );
            }
            else
                throw new Exception( "ZoneCluster.ConnecterIniNetState(...) - newNetState == null || newNetState.ExtendData != null || netStateInit.NetStateInit.World != m_World error!" );
        }

        /// <summary>
        /// ��ʼ��½ZoneCluster����
        /// </summary>
        private void OnLoginDomain( object sender, NetStateConnectEventArgs eventArgs )
        {
            if ( eventArgs.NetStateConnect == null )
                throw new Exception( "ZoneCluster.OnLoginDomain(...) - eventArgs.NetStateConnect == null error!" );

            NetState netState = eventArgs.NetStateConnect;

            // ���͵�½��Ϣ
            if ( netState.Running == true )
                netState.Send( new ZoneCluster_LoginDomain( m_ConfigZoneCluster.DomainPassword, m_ConfigZoneCluster.ZoneClusterPassword ) );
            else
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ZoneClusterString005 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal void ListenerProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            if ( eventArgs.NetState == null )
                throw new Exception( "ZoneCluster.ListenerProcessReceive(...) - netState == null error!" );

            if ( eventArgs.NetState.ReceiveBuffer == null )
                throw new Exception( "ZoneCluster.ListenerProcessReceive(...) - eventArgs.NetState.ReceiveBuffer == null error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ListenerProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )��// �ȴ����ݰ�������
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // ���ݰ�����
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ListenerProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ListenerProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

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
                PacketHandler packetHandler = ZoneClusterPacketHandlers.GetHandler( iPacketID );
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
                throw new Exception( "ZoneCluster.ConnecterProcessReceive(...) - netState == null error!" );

            if ( eventArgs.NetState.ReceiveBuffer == null )
                throw new Exception( "ZoneCluster.ConnecterProcessReceive(...) - eventArgs.NetState.ReceiveBuffer == null error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ConnecterProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )��// �ȴ����ݰ�������
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // ���ݰ�����
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ConnecterProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ConnecterProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

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
                PacketHandler packetHandler = ZoneClusterPacketHandlers.GetHandler( iPacketID );
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