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
#endregion

namespace Demo.Mmose.Core.World.DomainWorld
{
    /// <summary>
    /// 
    /// </summary>
    public class Domain<T> where T : BaseWorld, new ()
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// Domain 的数据头大小
        /// </summary>
        private const int PACKAGE_HEAD = 4;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public Domain()
        {
            m_World.EventInitOnceWorld += new EventHandler<BaseWorldEventArgs>( DomainWorld_InitOnceServer );
            m_World.EventExitWorld += new EventHandler<BaseWorldEventArgs>( DomainWorld_ExitWorld );
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
            // 开始注册协议

            // 客户端的协议
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
        private T m_World = new T();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T World
        {
            get { return m_World; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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
        private bool ListenerDomainServer()
        {
            if ( m_ConfigDomain == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.DomainString001 );

                return false;
            }

            //////////////////////////////////////////////////////////////////////////
            // 开始监听端口

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

        #region zh-CHS 共有方法 | en Public Methods
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
                Domain_ListenerExtendData extendData = new Domain_ListenerExtendData();

                // 保存扩展的数据到NetState
                netStateInit.NetStateInit.RegisterComponent<Domain_ListenerExtendData>( Domain_ListenerExtendData.COMPONENT_ID, extendData );

                // 获取包的长度
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
                // 初始化客户端
                Domain_ConnecterExtendData extendData = new Domain_ConnecterExtendData();
                extendData.NetState = netStateInit.NetStateInit;

                // 保存扩展的数据到NetState
                netStateInit.NetStateInit.RegisterComponent<Domain_ConnecterExtendData>( Domain_ConnecterExtendData.COMPONENT_ID, extendData );

                // 获取包的长度
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
            if ( receiveQueueBuffer.Length < PACKAGE_HEAD )　// 等待数据包的完整
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据
            while ( iReceiveBufferLength >= PACKAGE_HEAD )
            {
                // ReceiveQueue内部已经有锁定
                long iPacketSize = receiveQueueBuffer.GetPacketLength();
                if ( iPacketSize < PACKAGE_HEAD )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ListenerProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )　// 等待数据包的完整
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // 数据包过大
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ListenerProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ListenerProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

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
                PacketHandler packetHandler = DomainPacketHandlers.GetHandler( iPacketID );
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
                throw new Exception( "Domain.ConnecterProcessReceive(...) - netState == null error!" );

            if ( eventArgs.NetState.ReceiveBuffer == null )
                throw new Exception( "Domain.ConnecterProcessReceive(...) - eventArgs.NetState.ReceiveBuffer == null error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ConnecterProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )　// 等待数据包的完整
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // 数据包过大
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ConnecterProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Domain.ConnecterProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

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
                PacketHandler packetHandler = DomainPacketHandlers.GetHandler( iPacketID );
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