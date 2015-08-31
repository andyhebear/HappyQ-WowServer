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
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Network;
using System.Diagnostics;
using Demo.Mmose.Core.Common;
using System.Threading;
using System.IO;
using Demo.Mmose.Core.Util;
using Demo.Wow.RealmServer.Network.Common;
using Demo.Wow.RealmServer.Server;
#endregion

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessNet
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// Realm 的数据头大小(3个字节)
        /// </summary>
        internal const int REALM_HEAD_SIZE = 3;
        /// <summary>
        /// Auth 的数据头大小(1个字节)
        /// </summary>
        internal const int AUTH_ID_SIZE = 1;
        #endregion

        #region zh-CHS 私有静态属性 | en Private Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// ZoneServer 的数据缓存的大小
        /// </summary>
        private const int BUFFER_SIZE = 4096;
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
            get { return s_ProcessorBuffers; }
        }
        #endregion

        #region zh-CHS LogPack静态方法 | en LogPack Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetBuffer"></param>
        /// <param name="iLength"></param>
        /// <param name="strFileName"></param>
        /// <param name="strClientInfo"></param>
        /// <param name="iOpcode"></param>
        /// <param name="strOpcode"></param>
        private static void LogClientPack( byte[] packetBuffer, long iLength, string strFileName, string strNetAddressInfo, long iOpcode, string strOpcode )
        {
            //////////////////////////////////////////////////////////////////////////
            using ( StreamWriter streamWriter = new StreamWriter( strFileName, true ) )
            {
                byte[] byteBuffer = packetBuffer;

                if ( byteBuffer.Length > 0 )
                {
                    streamWriter.WriteLine( ">>>客户端<--发送数据<<<" );
                    streamWriter.WriteLine( "--------------------" );
                    streamWriter.WriteLine( "发送数据地址： {0}", strNetAddressInfo );
                    streamWriter.WriteLine( "长度：         十六进制(0x{0:X4})，十进制({1})", iLength, iLength );
                    streamWriter.WriteLine( "操作码：       名称({0})，十六进制(0x{1:X4})，十进制({2})", strOpcode, iOpcode, iOpcode );
                    streamWriter.WriteLine( "数据：" );
                }

                using ( MemoryStream memoryStream = new MemoryStream( byteBuffer ) )
                    Utility.FormatBuffer( streamWriter, memoryStream, iLength );

                streamWriter.WriteLine();
                streamWriter.WriteLine();
            }
            //////////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetBuffer"></param>
        /// <param name="iLength"></param>
        /// <param name="strFileName"></param>
        /// <param name="strServerInfo"></param>
        /// <param name="iOpcode"></param>
        /// <param name="strOpcode"></param>
        private static void LogServerPack( byte[] packetBuffer, long iLength, string strFileName, string strNetAddressInfo, long iOpcode, string strOpcode )
        {
            //////////////////////////////////////////////////////////////////////////
            using ( StreamWriter streamWriter = new StreamWriter( strFileName, true ) )
            {
                byte[] byteBuffer = packetBuffer;

                if ( byteBuffer.Length > 0 )
                {
                    streamWriter.WriteLine( ">>>服务端-->接收数据<<<" );
                    streamWriter.WriteLine( "--------------------" );
                    streamWriter.WriteLine( "接收数据地址： {0}", strNetAddressInfo );
                    streamWriter.WriteLine( "长度：         十六进制(0x{0:X4})，十进制({1})", iLength, iLength );
                    streamWriter.WriteLine( "操作码：       名称({0})，十六进制(0x{1:X4})，十进制({2})", strOpcode, iOpcode, iOpcode );
                    streamWriter.WriteLine( "数据：" );
                }

                using ( MemoryStream memoryStream = new MemoryStream( byteBuffer ) )
                    Utility.FormatBuffer( streamWriter, memoryStream, iLength );

                streamWriter.WriteLine();
                streamWriter.WriteLine();
            }
            //////////////////////////////////////////////////////////////////////////
        }
        #endregion

        #region zh-CHS RealmInitializeNetState静态方法 | en RealmInitializeNetState Static Methods

        #region zh-CHS Packet Info 静态方法 | en Packet Info Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void RealmGetPacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 1/*Packet ID 大小*/ ) // 这是W.O.W协议的实现(因为是环绕环冲区,所以需要取模)
                eventArgs.PacketId = (byte)( ( eventArgs.Buffer[eventArgs.HeadIndex % eventArgs.Buffer.Length] ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void RealmGetPacketLength( object sender, PacketLengthInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 3/*Packet ID + Length 大小*/ ) // 这是W.O.W协议的实现(因为是环绕环冲区,所以需要取模)
                eventArgs.PacketLength = (ushort)( ( eventArgs.Buffer[( eventArgs.HeadIndex + 1 ) % eventArgs.Buffer.Length] ) | eventArgs.Buffer[( eventArgs.HeadIndex + 2 ) % eventArgs.Buffer.Length] << 8 );
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        internal static void RealmInitializeNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            if ( netStateInit.NetStateInit != null )
            {
                // 初始化客户端
                RealmExtendData extendData = new RealmExtendData();

                netStateInit.NetStateInit.RegisterComponent<RealmExtendData>( RealmExtendData.COMPONENT_ID, extendData );

                // 获取包的ID
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketID += new EventHandler<PacketIdInfoEventArgs>( RealmGetPacketID );

                // 获取包的长度
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( RealmGetPacketLength );

                // 截获输出的信息包
                netStateInit.NetStateInit.EventSendPacket += new EventHandler<NetStateSendPacketEventArgs>( RealmSendPacket );
            }
            else
                Debug.WriteLine( "ProcessNet.Realm_InitializeNetState(...) - newNetState != null && newNetState.ExtendData == null error!" );
        }

        /// <summary>
        /// 输出发送信息包的日志
        /// </summary>
        private static void RealmSendPacket( object sender, NetStateSendPacketEventArgs eventArgs )
        {
            PacketBuffer sendBuffer = eventArgs.SendPacket.AcquireBuffer();

            //////////////////////////////////////////////////////////////////////////
            // 输出信息包的日志
            //////////////////////////////////////////////////////////////////////////
            ProcessNet.LogClientPack( sendBuffer.Buffer, sendBuffer.Length, "Realm_Out_Packets.log", eventArgs.SendNetState.ToString(), eventArgs.SendPacket.PacketID, RealmOpCodeName.GetRealmOpCodeName( eventArgs.SendPacket.PacketID ) );
            //////////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal static void RealmProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "Realm_ProcessReceive......= {0}", eventArgs.NetState.ReceiveBuffer.Length );
            
            if ( eventArgs.NetState == null )
            {
                Debug.WriteLine( "ProcessNet.Realm_ProcessReceive(...) - eventArgs.NetState == null error!" );
                return;
            }

            ReceiveQueue receiveQueueBuffer = eventArgs.NetState.ReceiveBuffer;
            if ( receiveQueueBuffer == null )
            {
                Debug.WriteLine( "ProcessNet.Realm_ProcessReceive(...) - receiveQueueBuffer == null error!" );
                return;
            }

            if ( receiveQueueBuffer.Length < REALM_HEAD_SIZE )　// 等待数据包的完整
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据
            while ( iReceiveBufferLength >= REALM_HEAD_SIZE )
            {
                // 获取包的 ID
                long iPacketID = receiveQueueBuffer.GetPacketID();

                // 获取包的 命令ID长度
                long iPacketLength = receiveQueueBuffer.GetPacketLength();

                // 获取包的全部长度
                long iPacketFullLength = iPacketLength + REALM_HEAD_SIZE;

                // 等待数据包的完整
                if ( iReceiveBufferLength < iPacketFullLength )
                    break;

                if ( iPacketLength > BUFFER_SIZE ) // 数据包过大
                {
                    Debug.WriteLine( "ProcessNet.Realm_ProcessReceive(...) - iPacketLength > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 获取空数据
                byte[] packetBuffer = s_ProcessorBuffers.AcquireBuffer();

                // 获取数据内容
                long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, iPacketFullLength );

                // 获取的数据不相同
                if ( iReturnPacketSize != iPacketFullLength )
                {
                    Debug.WriteLine( "ProcessNet.Realm_ProcessReceive(...) - iReturnPacketSize != iPacketFullLength error!" );

                    // 返回内存池
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }


                //////////////////////////////////////////////////////////////////////////
                // 输出信息包的日志
                //////////////////////////////////////////////////////////////////////////
                ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "Realm_In_Packets.log", eventArgs.NetState.ToString(), iPacketID, RealmOpCodeName.GetRealmOpCodeName( iPacketID ) );
                //////////////////////////////////////////////////////////////////////////


                // 读取的数据包
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketFullLength, REALM_HEAD_SIZE/*包的ID大小-1个字节、长度大小-2个字节, 3个字节跳过*/);

                // 获取处理数据包的实例
                PacketHandler packetHandler = ProcessServer.RealmPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // 说明还没有解开当前的数据包内容
                {
                    //////////////////////////////////////////////////////////////////////////
                    // 输出信息包的日志
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "Realm_Unknown_Packets.log", eventArgs.NetState.ToString(), iPacketID, RealmOpCodeName.GetRealmOpCodeName( iPacketID ) );
                    //////////////////////////////////////////////////////////////////////////

                    // 返回内存池
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    // 获取剩下的数据长度
                    iReceiveBufferLength = receiveQueueBuffer.Length;

                    continue;
                }

                // 当前需处理的数据包的大小
                long iPacketHandlerLength = packetHandler.Length;
                if ( iPacketHandlerLength > iReturnPacketSize ) // 包需求的数据大小大于得到的数据大小
                {
                    // 返回内存池
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 处理数据
                packetHandler.OnReceive( eventArgs.NetState, packetReader );

                // 返回内存池
                s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                // 获取剩下的数据长度
                iReceiveBufferLength = receiveQueueBuffer.Length;
            }
        }
        #endregion

        #region zh-CHS AuthInitializeNetState静态方法 | en AuthInitializeNetState Static Methods

        #region zh-CHS Packet Info 静态方法 | en Packet Info Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void AuthGetPacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 1 ) // 这是W.O.W协议的实现(因为是环绕环冲区,所以需要取模)
                eventArgs.PacketId = (byte)( ( eventArgs.Buffer[( eventArgs.HeadIndex ) % eventArgs.Buffer.Length] ) );
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        internal static void AuthInitializeNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            if ( netStateInit.NetStateInit != null )
            {
                // 初始化客户端
                AuthExtendData extendData = new AuthExtendData();

                netStateInit.NetStateInit.RegisterComponent<AuthExtendData>( AuthExtendData.COMPONENT_ID, extendData );

                // 获取包的ID
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketID += new EventHandler<PacketIdInfoEventArgs>( AuthGetPacketID );
                
                // 截获输出的信息包
                netStateInit.NetStateInit.EventSendPacket += new EventHandler<NetStateSendPacketEventArgs>( AuthSendPacket );
            }
            else
                Debug.WriteLine( "ProcessNet.Auth_InitializeNetState(...) - newNetState != null && newNetState.ExtendData == null error!" );
        }

        /// <summary>
        /// 输出发送信息包的日志
        /// </summary>
        private static void AuthSendPacket( object sender, NetStateSendPacketEventArgs eventArgs )
        {
            PacketBuffer sendBuffer = eventArgs.SendPacket.AcquireBuffer();

            //////////////////////////////////////////////////////////////////////////
            // 输出信息包的日志
            //////////////////////////////////////////////////////////////////////////
            ProcessNet.LogClientPack( sendBuffer.Buffer, sendBuffer.Length, "Auth_Out_Packets.log", eventArgs.SendNetState.ToString(), eventArgs.SendPacket.PacketID, AuthOpCodeName.GetAuthOpCodeName( eventArgs.SendPacket.PacketID ) );
            //////////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal static void AuthProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "Auth_ProcessReceive......= {0}", eventArgs.NetState.ReceiveBuffer.Length );

            if ( eventArgs.NetState == null )
            {
                Debug.WriteLine( "ProcessNet.Auth_ProcessReceive(...) - eventArgs.NetState == null error!" );
                return;
            }

            ReceiveQueue receiveQueueBuffer = eventArgs.NetState.ReceiveBuffer;
            if ( receiveQueueBuffer == null )
            {
                Debug.WriteLine( "ProcessNet.Auth_ProcessReceive(...) - receiveQueueBuffer == null error!" );
                return;
            }

            if ( receiveQueueBuffer.Length < AUTH_ID_SIZE )　// 等待数据包的完整
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据
            while ( iReceiveBufferLength >= AUTH_ID_SIZE )
            {
                // 获取包的 ID
                long iPacketID = receiveQueueBuffer.GetPacketID();

                // 获取包的长度(数据包里面没有带数据包大小的字段)
                long iPacketLength = receiveQueueBuffer.Length;

                if ( iPacketLength > BUFFER_SIZE ) // 数据包过大
                {
                    Debug.WriteLine( "ProcessNet.Auth_ProcessReceive(...) - iPacketLength > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 获取空数据
                byte[] packetBuffer = s_ProcessorBuffers.AcquireBuffer();

                // 获取数据内容
                long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, iPacketLength );

                // 获取的数据不相同
                if ( iReturnPacketSize != iPacketLength )
                {
                    Debug.WriteLine( "ProcessNet.Auth_ProcessReceive(...) - iReturnPacketSize != iPacketLength error!" );

                    // 返回内存池
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }


                //////////////////////////////////////////////////////////////////////////
                // 输出信息包的日志
                //////////////////////////////////////////////////////////////////////////
                ProcessNet.LogServerPack( packetBuffer, iPacketLength, "Auth_In_Packets.log", eventArgs.NetState.ToString(), iPacketID, AuthOpCodeName.GetAuthOpCodeName( iPacketID ) );
                //////////////////////////////////////////////////////////////////////////


                // 读取的数据包
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketLength, 0 ); // 不跳过数据包头

                // 获取处理数据包的实例
                PacketHandler packetHandler = ProcessServer.AuthPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // 说明还没有解开当前的数据包内容
                {
                    //////////////////////////////////////////////////////////////////////////
                    // 输出信息包的日志
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketLength, "Auth_Unknown_Packets.log", eventArgs.NetState.ToString(), iPacketID, AuthOpCodeName.GetAuthOpCodeName( iPacketID ) );
                    //////////////////////////////////////////////////////////////////////////

                    // 返回内存池
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    // 获取剩下的数据长度
                    iReceiveBufferLength = receiveQueueBuffer.Length;

                    continue;
                }

                // 当前需处理的数据包的大小
                long iPacketHandlerLength = packetHandler.Length;
                if ( iPacketHandlerLength > iReturnPacketSize ) // 包需求的数据大小大于得到的数据大小
                {
                    // 返回内存池
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }

                // 处理数据
                packetHandler.OnReceive( eventArgs.NetState, packetReader );

                // 返回内存池
                s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                // 获取剩下的数据长度
                iReceiveBufferLength = receiveQueueBuffer.Length;
            }
        }
        #endregion
    }
}
#endregion