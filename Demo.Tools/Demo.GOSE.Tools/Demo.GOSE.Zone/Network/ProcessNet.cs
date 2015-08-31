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
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Demo.GOSE.ServerEngine.Network;
using Demo.GOSE.ServerEngine.Common;
using Demo.GOSE.ServerEngine.Network.DLL;
using Demo.WOW.Zone.Server;
using Demo.WOW.Zone.Common;
#endregion

namespace Demo.WOW.Zone.Network
{
    /// <summary>
    /// 
    /// </summary>
    class ProcessNet
    {
        #region zh-CHS 内部常量 | en Internal Constants
        /// <summary>
        /// ZoneServer 的数据缓存的大小
        /// </summary>
        internal const int BUFFER_SIZE = 4096;
        #endregion

        #region zh-CHS 内部静态属性 | en Internal Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static BufferPool s_ProcessorBuffers = new BufferPool( "ProcessNet - ProcessorBuffers", 1024, BUFFER_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private static BufferPool ProcessorBuffers
        {
            get { return ProcessNet.s_ProcessorBuffers; }
        }
        #endregion

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        internal static void Zone_InitializeNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            if ( netStateInit.NetStateInit != null && netStateInit.NetStateInit.ExtendData == null )
            {
                // 初始化客户端
                ZoneExtendData l_ExtendData = new ZoneExtendData();
                l_ExtendData.NetState = netStateInit.NetStateInit;

                bool l_bCheck = l_ExtendData.ConnectToZoneClusterServer( ProcessServer.ConfigInfo.ZoneClusterHost, ProcessServer.ConfigInfo.ZoneClusterPort );

                if ( l_bCheck )
                    netStateInit.NetStateInit.ExtendData = l_ExtendData;
                else
                    Debug.WriteLine( "ProcessNet.NetState_InitializeNetState(...) - l_bCheck == false error!" );
            }
            else
                Debug.WriteLine( "ProcessNet.NetState_InitializeNetState(...) - newNetState != null && newNetState.ExtendData == null error!" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal static void Zone_ProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "ProcessNet.MessagePump_ProcessReceive(...) {0}", Thread.CurrentThread.Name );

            if ( eventArgs.NetState == null )
            {
                Debug.WriteLine( "ProcessNet.EventDelegateProcessReceive(...) - netState == null error!" );
                return;
            }

            ZoneExtendData l_ExtendData = null;
            if ( eventArgs.NetState.ExtendData == null )
            {
                Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - eventArgs.NetState.ExtendData == null error!" );

                eventArgs.NetState.Dispose( false );
                return;
            }
            else
            {
                l_ExtendData = eventArgs.NetState.ExtendData as ZoneExtendData;
                if ( l_ExtendData == null )
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - l_ExtendData == null error!" );
                    
                    eventArgs.NetState.Dispose( false );
                    return;
                }
            }

            ReceiveQueue l_ReceiveQueueBuffer = eventArgs.NetState.ReceiveBuffer;
            if ( l_ReceiveQueueBuffer == null )
            {
                Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - byteQueueBuffer == null error!" );
                return;
            }

            LOGs.WriteLine( LogMessageType.MSG_HACK, "ProcessNet.MessagePump_ProcessReceive(...) Length = {0},{1}", l_ReceiveQueueBuffer.Length, Thread.CurrentThread.Name );

            long l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据
            while ( l_iReceiveBufferLength > 0 )
            {
                // 获取空数据
                byte[] l_PacketBuffer = s_ProcessorBuffers.AcquireBuffer();

                // ReceiveQueue内部已经有锁定
                long l_iReturnPacketSize = l_ReceiveQueueBuffer.Dequeue( ref l_PacketBuffer, 0, l_iReceiveBufferLength );

                // 获取的数据不相同
                if ( l_iReturnPacketSize != l_iReceiveBufferLength )
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // 返回内存池
                    s_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    eventArgs.NetState.Dispose( false ); // 断开
                    return;
                }

                // 发送数据
                l_ExtendData.SendToZoneClusterServer( l_PacketBuffer, l_iReturnPacketSize );

                // 返回内存池
                s_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                // 获取剩下的数据长度
                l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length;
            }
        }
        #endregion
    }
}
#endregion