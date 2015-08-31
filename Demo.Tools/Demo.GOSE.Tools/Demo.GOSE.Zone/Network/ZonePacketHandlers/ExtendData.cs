#region zh-CHS 版权所有 (C) 2006 - 2007 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2007 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2007 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Demo.GOSE.ServerEngine.Common;
using Demo.GOSE.ServerEngine.Network;
using Demo.GOSE.ServerEngine.Network.DLL;
using Demo.WOW.Zone.Network;
#endregion

namespace Demo.WOW.Zone.Common
{
    /// <summary>
    /// 
    /// </summary>
    internal class ZoneExtendData
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SocketClient m_SocketClient = new SocketClient();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal SocketClient SocketClient
        {
            get { return m_SocketClient; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NetState m_NetState = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public NetState NetState
        {
            get { return m_NetState; }
            set { m_NetState = value; }
        }
        #endregion

        #region zh-CHS 内部静态属性 | en Internal Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static BufferPool s_ProcessorBuffers = new BufferPool( "ZoneExtendData - ProcessorBuffers", 1024, ProcessNet.BUFFER_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private static BufferPool ProcessorBuffers
        {
            get { return s_ProcessorBuffers; }
        }
        #endregion

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        internal bool ConnectToZoneClusterServer( string strCharHost, long iCharPort )
        {
            if ( m_SocketClient.IsConnected )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "已经连接至ZoneCluster服务端 错误!" );

                return false;
            }

            m_SocketClient.ThreadEventProcessMessageBlock += new EventHandler<ProcessMessageBlockAtClientEventArgs>( ReceiveFromZoneClusterServer );
            
            // 连接登陆服务端
            string l_strHostNamePort = strCharHost + ":" + iCharPort;

            if ( m_SocketClient.StartConnectServer( l_strHostNamePort ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "连接ZoneCluster服务端({0}) 错误!", l_strHostNamePort );

                return false;
            }

            return true;
        }

        /// <summary>
        /// 发送数据到ZoneCluster服务器
        /// </summary>
        internal void SendToZoneClusterServer( byte[] byteBuffer, long iSize )
        {
            m_SocketClient.SendBuffer( byteBuffer, (int)iSize );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void ReceiveFromZoneClusterServer( object sender, ProcessMessageBlockAtClientEventArgs eventArgs )
        {
            if ( m_NetState == null )
            {
                Debug.WriteLine( "ZoneExtendData.SocketClient_ProcessReceive(...) - m_NetState == null error!" );
                return;
            }

            // 获取空数据
            byte[] l_PacketBuffer = s_ProcessorBuffers.AcquireBuffer();
            {
                Marshal.Copy( eventArgs.MessageBlock.ReadPointer(), l_PacketBuffer, 0, eventArgs.MessageBlock.Length );

                m_NetState.Send( new BufferPacket( l_PacketBuffer, 0, eventArgs.MessageBlock.Length ) );
            }
            s_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer ); // 返回内存池
        }
        #endregion
    }
}
#endregion