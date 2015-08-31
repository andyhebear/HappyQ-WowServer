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
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// ZoneCluster 的数据头大小
        /// </summary>
        private const int PACKAGE_HEAD = 4;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public ZoneCluster()
        {
            m_World.EventInitOnceWorld += new EventHandler<BaseWorldEventArgs>( this.ZoneClusterInitOnceServer );
            m_World.EventExitWorld += new EventHandler<BaseWorldEventArgs>( this.ZoneClusterExitWorld );
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
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
            // 开始注册协议

            // 客户端的协议
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

        #region zh-CHS 私有属性 | en Private Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// ZoneWorld 的数据缓存的大小
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

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有方法 | en Private Methods
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
            // 开始监听端口

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
            // 连接Domain服务端

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

        #region zh-CHS 共有方法 | en Public Methods
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

        #region zh-CHS 私有的事件处理函数 | en Private Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void GetPacketLength( object sender, PacketLengthInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 2 ) // 这是ZoneCluster的实现(因为是环绕环冲区,所以需要取模)
                eventArgs.PacketLength = (ushort)( ( eventArgs.Buffer[( eventArgs.HeadIndex ) % eventArgs.Buffer.Length] ) | eventArgs.Buffer[( eventArgs.HeadIndex + 1 ) % eventArgs.Buffer.Length] << 8 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void GetPacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 4 ) // 这是ZoneCluster的实现
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
                // 初始化客户端
                ZoneCluster_ListenerExtendData extendData = new ZoneCluster_ListenerExtendData();
                extendData.ConfigZoneCluster = m_ConfigZoneCluster;

                // 保存扩展的数据到NetState
                netStateInit.NetStateInit.RegisterComponent<ZoneCluster_ListenerExtendData>( ZoneCluster_ListenerExtendData.COMPONENT_ID, extendData );

                // 获取包的长度
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
                // 初始化客户端
                ZoneCluster_ConnecterExtendData extendData = new ZoneCluster_ConnecterExtendData();
                extendData.NetState = netStateInit.NetStateInit;

                // 保存扩展的数据到NetState
                netStateInit.NetStateInit.RegisterComponent<ZoneCluster_ConnecterExtendData>( ZoneCluster_ConnecterExtendData.COMPONENT_ID, extendData );

                // 获取包的长度
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( this.GetPacketLength );
               
                // 连接的时候启动登陆ZoneCluster服务
                netStateInit.NetStateInit.EventConnect += new EventHandler<NetStateConnectEventArgs>( this.OnLoginDomain );
            }
            else
                throw new Exception( "ZoneCluster.ConnecterIniNetState(...) - newNetState == null || newNetState.ExtendData != null || netStateInit.NetStateInit.World != m_World error!" );
        }

        /// <summary>
        /// 开始登陆ZoneCluster服务
        /// </summary>
        private void OnLoginDomain( object sender, NetStateConnectEventArgs eventArgs )
        {
            if ( eventArgs.NetStateConnect == null )
                throw new Exception( "ZoneCluster.OnLoginDomain(...) - eventArgs.NetStateConnect == null error!" );

            NetState netState = eventArgs.NetStateConnect;

            // 发送登陆信息
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
            if ( receiveQueueBuffer.Length < PACKAGE_HEAD )　// 等待数据包的完整
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据
            while ( iReceiveBufferLength >= PACKAGE_HEAD )
            {
                // ReceiveQueue内部已经有锁定
                long iPacketSize = receiveQueueBuffer.GetPacketLength();
                if ( iPacketSize < PACKAGE_HEAD )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ListenerProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )　// 等待数据包的完整
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // 数据包过大
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ListenerProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 获取空数据
                byte[] packetBuffer = m_ProcessorBuffers.AcquireBuffer();

                // ReceiveQueue内部已经有锁定
                long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, iPacketSize );

                // 获取的数据不相同
                if ( iReturnPacketSize != iPacketSize )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ListenerProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 读取的数据包
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketSize,
                    PACKAGE_HEAD/*包的长度大小-2个字节、ID大小-2个字节, 4个字节跳过*/,
                    new EventHandler<PacketIdInfoEventArgs>( this.GetPacketID ) );

                // 获取数据包命令的ID
                long iPacketID = packetReader.GetPacketID();

                // 获取处理数据包的实例
                PacketHandler packetHandler = ZoneClusterPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // 说明还没有解开当前的数据包内容
                {
                    packetReader.Trace( eventArgs.NetState );

                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    // 获取剩下的数据长度
                    iReceiveBufferLength = receiveQueueBuffer.Length;

                    continue;
                }

                // 当前需处理的数据包的大小
                long iPacketHandlerLength = packetHandler.Length;
                if ( iPacketHandlerLength > iReturnPacketSize ) // 包需求的数据大小大于得到的数据大小
                {
                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 处理数据
                packetHandler.OnReceive( eventArgs.NetState, packetReader );

                // 返回内存池
                m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                // 获取剩下的数据长度
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
            if ( receiveQueueBuffer.Length < PACKAGE_HEAD )　// 等待数据包的完整
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据
            while ( iReceiveBufferLength >= PACKAGE_HEAD )
            {
                // ReceiveQueue内部已经有锁定
                long iPacketSize = receiveQueueBuffer.GetPacketLength();
                if ( iPacketSize < PACKAGE_HEAD )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ConnecterProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )　// 等待数据包的完整
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // 数据包过大
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ConnecterProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 获取空数据
                byte[] packetBuffer = m_ProcessorBuffers.AcquireBuffer();

                // ReceiveQueue内部已经有锁定
                long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, iPacketSize );

                // 获取的数据不相同
                if ( iReturnPacketSize != iPacketSize )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster.ConnecterProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 读取的数据包
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketSize,
                    PACKAGE_HEAD/*包的长度大小-2个字节、ID大小-2个字节, 4个字节跳过*/,
                    new EventHandler<PacketIdInfoEventArgs>( this.GetPacketID ) );

                // 获取数据包命令的ID
                long iPacketID = packetReader.GetPacketID();

                // 获取处理数据包的实例
                PacketHandler packetHandler = ZoneClusterPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // 说明还没有解开当前的数据包内容
                {
                    packetReader.Trace( eventArgs.NetState );

                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    // 获取剩下的数据长度
                    iReceiveBufferLength = receiveQueueBuffer.Length;

                    continue;
                }

                // 当前需处理的数据包的大小
                long iPacketHandlerLength = packetHandler.Length;
                if ( iPacketHandlerLength > iReturnPacketSize ) // 包需求的数据大小大于得到的数据大小
                {
                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 处理数据
                packetHandler.OnReceive( eventArgs.NetState, packetReader );

                // 返回内存池
                m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                // 获取剩下的数据长度
                iReceiveBufferLength = receiveQueueBuffer.Length;
            }
        }
        #endregion
    }
}
#endregion