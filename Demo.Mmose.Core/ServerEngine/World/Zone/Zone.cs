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

namespace Demo.Mmose.Core.World.Zone
{
    /// <summary>
    /// 
    /// </summary>
    public class Zone<T> where T : BaseWorld, new()
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// Zone 的数据头大小
        /// </summary>
        private const int PACKAGE_HEAD = 4;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public Zone()
        {
            m_World.EventInitOnceWorld += new EventHandler<BaseWorldEventArgs>( this.ZoneInitOnceServer );
            m_World.EventExitWorld += new EventHandler<BaseWorldEventArgs>( this.ZoneExitWorld );
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
            // 开始注册协议

            // 客户端的协议
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

        #region zh-CHS 私有属性 | en Private Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// ZoneWorld 的数据缓存的大小
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
        private ConfigZone m_ConfigZone = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ConfigZone ConfigZone
        {
            get { return m_ConfigZone; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有方法 | en Private Methods
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
            // 开始监听端口

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
            // 连接ZoneCluster服务端

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

        #region zh-CHS 共有方法 | en Public Methods
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
        /// 反登陆至ZoneCluster
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
        /// 注册到ZoneCluster
        /// </summary>
        public bool RegToZoneCluster( NetState netState, Option option )
        {
            return false;
        }

        /// <summary>
        /// 取消注册到ZoneCluster
        /// </summary>
        public bool UnRegToZoneCluster( NetState netState, Option option )
        {
            return false;
        }

        //event LoginZoneCluster;
        //event LogoutZoneCluster;

        #endregion

        #region zh-CHS 私有的事件处理函数 | en Private Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void GetPacketLength( object sender, PacketLengthInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 2 ) // 这是ZoneWorld的实现(因为是环绕环冲区,所以需要取模)
                eventArgs.PacketLength = (ushort)( ( eventArgs.Buffer[( eventArgs.HeadIndex ) % eventArgs.Buffer.Length] ) | eventArgs.Buffer[( eventArgs.HeadIndex + 1 ) % eventArgs.Buffer.Length] << 8 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void GetPacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 4 ) // 这是ZoneWorld的实现
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
                // 初始化客户端
                Zone_ListenerExtendData extendData = new Zone_ListenerExtendData();
                extendData.NetState = netStateInit.NetStateInit;

                // 保存扩展的数据到NetState
                netStateInit.NetStateInit.RegisterComponent<Zone_ListenerExtendData>( Zone_ListenerExtendData.COMPONENT_ID, extendData );

                // 获取包的长度
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
                // 初始化客户端
                Zone_ConnecterExtendData extendData = new Zone_ConnecterExtendData();

                // 保存扩展的数据到NetState
                netStateInit.NetStateInit.RegisterComponent<Zone_ConnecterExtendData>( Zone_ConnecterExtendData.COMPONENT_ID, extendData );

                // 获取包的长度
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( this.GetPacketLength );

                // 连接的时候启动登陆ZoneCluster服务
                netStateInit.NetStateInit.EventConnect += new EventHandler<NetStateConnectEventArgs>( this.OnLoginZoneCluster );
            }
            else
                throw new Exception( "ZoneCluster.ConnecterIniNetState(...) - newNetState == null || newNetState.ExtendData != null || netStateInit.NetStateInit.World != m_World error!" );
        }

        /// <summary>
        /// 开始登陆ZoneCluster服务
        /// </summary>
        private void OnLoginZoneCluster( object sender, NetStateConnectEventArgs eventArgs )
        {
            if ( eventArgs.NetStateConnect == null )
                throw new Exception( "Zone.OnLoginZoneCluster(...) - eventArgs.NetStateConnect == null error!" );

            NetState netState = eventArgs.NetStateConnect;

            // 发送登陆信息
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
            if ( receiveQueueBuffer.Length < PACKAGE_HEAD )　// 等待数据包的完整
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据
            while ( iReceiveBufferLength >= PACKAGE_HEAD )
            {
                // ReceiveQueue内部已经有锁定
                long iPacketSize = receiveQueueBuffer.GetPacketLength();
                if ( iPacketSize < PACKAGE_HEAD )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ListenerProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )　// 等待数据包的完整
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // 数据包过大
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ListenerProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ListenerProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

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
                PacketHandler packetHandler = ZonePacketHandlers.GetHandler( iPacketID );
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
        private void ConnecterProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            if ( eventArgs.NetState == null )
                throw new Exception( "Zone.ConnecterProcessReceive(...) - netState == null error!" );

            if ( eventArgs.NetState.ReceiveBuffer == null )
                throw new Exception( "Zone.ConnecterProcessReceive(...) - eventArgs.NetState.ReceiveBuffer == null error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ConnecterProcessReceive(...) - iPacketSize < PACKAGE_HEAD error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                if ( iReceiveBufferLength < iPacketSize )　// 等待数据包的完整
                    break;

                if ( iPacketSize > BUFFER_SIZE ) // 数据包过大
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ConnecterProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

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
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone.ConnecterProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 读取的数据包
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketSize,
                    PACKAGE_HEAD/*包的长度大小-2个字节、ID大小-2个字节, 4个字节跳过*/
                    , new EventHandler<PacketIdInfoEventArgs>( this.GetPacketID ) );

                // 获取数据包命令的ID
                long iPacketID = packetReader.GetPacketID();

                // 获取处理数据包的实例
                PacketHandler packetHandler = ZonePacketHandlers.GetHandler( iPacketID );
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