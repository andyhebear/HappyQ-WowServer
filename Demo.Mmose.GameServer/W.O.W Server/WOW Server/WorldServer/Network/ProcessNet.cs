using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Timer;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.Common;
using Demo.Wow.WorldServer.Network.Common;
using Demo.Wow.WorldServer.Server;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProcessNet
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// Realm 的数据头大小(3字节)
        /// </summary>
        internal const int REALM_HEAD_SIZE = 3;
        /// <summary>
        /// World 的数据头大小(6字节)
        /// </summary>
        internal const int WORLD_HEAD_SIZE = WowCrypt.CRYPTED_RECV_LEN;
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

        #region zh-CHS WorldInitializeNetState静态方法 | en WorldInitializeNetState Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        internal static void WorldInitializeNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "World_InitializeNetState...... 0" );

            if ( netStateInit.NetStateInit != null )
            {
                // 初始化客户端
                WorldExtendData extendData = new WorldExtendData();

                // 客户端保存的扩展数据
                netStateInit.NetStateInit.RegisterComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID, extendData );

                // 加解密数据的接口
                netStateInit.NetStateInit.PacketEncoder = extendData;

                // 开始发送服务端随机的种子给客户端
                netStateInit.NetStateInit.EventConnect += new EventHandler<NetStateConnectEventArgs>( WorldInitConnect );

                // 截获输出的信息包
                netStateInit.NetStateInit.EventSendPacket += new EventHandler<NetStateSendPacketEventArgs>( WorldSendPacket );
            }
            else
                Debug.WriteLine( "ProcessNet.World_InitializeNetState(...) - newNetState != null && newNetState.ExtendData == null error!" );
        }

        /// <summary>
        /// 开始发送服务端随机的种子给客户端
        /// </summary>
        private static void WorldInitConnect( object sender, NetStateConnectEventArgs eventArgs )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "World_InitConnect...... 0" );

            NetState netState = eventArgs.NetStateConnect;
            if ( netState == null )
                Debug.WriteLine( "ProcessNet.World_InitConnect(...) - netState == null error!" );
            else
            {
                // 发送服务端随机的种子信息
                if ( netState.Running )
                {
                    WorldExtendData extendData = netState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
                    if ( extendData == null )
                    {
                        Debug.WriteLine( "ProcessNet.World_InitConnect(...) - extendData == null error!" );
                        return;
                    }

                    netState.Send( new Word_AuthChallenge( extendData.ServerSeed ) );
                }
            }
        }

        /// <summary>
        /// 输出发送信息包的日志
        /// </summary>
        private static void WorldSendPacket( object sender, NetStateSendPacketEventArgs eventArgs )
        {
            PacketBuffer sendBuffer = eventArgs.SendPacket.AcquireBuffer();

            //////////////////////////////////////////////////////////////////////////
            // 输出信息包的日志
            //////////////////////////////////////////////////////////////////////////
            ProcessNet.LogClientPack( sendBuffer.Buffer, sendBuffer.Length, "World_Out_Packets.log", eventArgs.SendNetState.ToString(), eventArgs.SendPacket.PacketID, WordOpCodeName.GetWordOpCodeName( eventArgs.SendPacket.PacketID ) );
            //////////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal static void WorldProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "World_ProcessReceive...... 0 = {0}", eventArgs.NetState.ReceiveBuffer.Length );

            if ( eventArgs.NetState == null )
            {
                Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - eventArgs.NetState == null error!" );
                return;
            }

            ReceiveQueue receiveQueueBuffer = eventArgs.NetState.ReceiveBuffer;
            if ( receiveQueueBuffer == null )
            {
                Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - receiveQueueBuffer == null error!" );
                return;
            }

            WorldExtendData extendData = eventArgs.NetState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - extendData == null error!" );
                return;
            }

            if ( receiveQueueBuffer.Length < extendData.ProcessReceiveData.Remaining )　// 等待数据包的完整(Remaining 默认的大小为WORLD_HEAD_SIZE)
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据(指 Length)
            while ( iReceiveBufferLength >= extendData.ProcessReceiveData.Remaining )
            {
                if ( extendData.ProcessReceiveData.PacketBuffer == null ) // 如果空 代表是需要获取新的数据包和包头(Remaining == WORLD_HEAD_SIZE)
                {
                    // 获取空数据
                    byte[] packetBuffer = s_ProcessorBuffers.AcquireBuffer();

                    // 获取数据包头的内容
                    long iReturnPacketHeadSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, WORLD_HEAD_SIZE );

                    // 获取的数据不相同
                    if ( iReturnPacketHeadSize != WORLD_HEAD_SIZE )
                    {
                        Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - iReturnPacketHeadSize != WORLD_HEAD_SIZE error!" );

                        // 返回内存池
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // 断开
                        return;
                    }

                    IPacketEncoder packetEncoder = eventArgs.NetState.PacketEncoder as IPacketEncoder;
                    if ( packetEncoder == null )
                    {
                        Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - packetEncoder == null error!" );

                        // 返回内存池
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // 断开
                        return;
                    }

                    // 解密数据包头
                    long iClientPacketHeader = WORLD_HEAD_SIZE;
                    packetEncoder.DecodeIncomingPacket( eventArgs.NetState, ref packetBuffer, ref iClientPacketHeader );

                    // 给出数据信息头
                    WOWClientPacketHeader clientPacketHeader = WOWClientPacketHeader.GetClientPacketHeader( packetBuffer );

                    int iRemaining = clientPacketHeader.PacketSize - 4; // -4 是代表剩余的数据包大小(为什么不是减6呢？)
                    if ( receiveQueueBuffer.Length < iRemaining )　// 等待数据包的完整
                    {
                        extendData.ProcessReceiveData.PacketBuffer = packetBuffer;
                        extendData.ProcessReceiveData.Remaining = (uint)iRemaining;

                        return;
                    }

                    // 获取信息包数据的剩余内容
                    long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, WORLD_HEAD_SIZE, iRemaining /*获取剩余数据包大小的字节数*/ );
                    
                    // 获取的数据不相同
                    if ( iReturnPacketSize != iRemaining )
                    {
                        Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - iReturnPacketSize != iRemaining error!" );

                        // 返回内存池
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // 断开
                        return;
                    }

                    // 获取包的全部长度
                    long iPacketFullLength = iRemaining + WORLD_HEAD_SIZE;

                    // 读取的数据包
                    PacketReader packetReader = new PacketReader( packetBuffer, iPacketFullLength, WORLD_HEAD_SIZE/*包的ID大小-4个字节、长度大小-2个字节, 6个字节跳过*/);


                    //////////////////////////////////////////////////////////////////////////
                    // 输出信息包的日志
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "World_In_Packets.log", eventArgs.NetState.ToString(), clientPacketHeader.PacketID, WordOpCodeName.GetWordOpCodeName( clientPacketHeader.PacketID ) );
                    //////////////////////////////////////////////////////////////////////////


                    // 获取处理数据包的实例
                    PacketHandler packetHandler = ProcessServer.WorldPacketHandlers.GetHandler( clientPacketHeader.PacketID );
                    if ( packetHandler == null ) // 说明还没有解开当前的数据包内容
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // 输出未知信息包的日志
                        //////////////////////////////////////////////////////////////////////////
                        ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "World_In_Unknown_Packets.log", eventArgs.NetState.ToString(), clientPacketHeader.PacketID, WordOpCodeName.GetWordOpCodeName( clientPacketHeader.PacketID ) );
                        //////////////////////////////////////////////////////////////////////////

                        // 返回内存池
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        // 获取剩下的数据长度
                        iReceiveBufferLength = receiveQueueBuffer.Length;

                        continue;
                    }

                    // 当前需处理的数据包的大小
                    long iPacketHandlerLength = packetHandler.Length;
                    if ( iPacketHandlerLength > iPacketFullLength ) // 包需求的数据大小大于得到的数据大小
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
                else    //已有数据包头获取剩余数据
                {
                    byte[] packetBuffer = extendData.ProcessReceiveData.PacketBuffer;

                    // 获取信息包数据的剩余内容
                    long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, WORLD_HEAD_SIZE, extendData.ProcessReceiveData.Remaining /*获取剩余数据包大小的字节数*/ );

                    // 获取的数据不相同
                    if ( iReturnPacketSize != extendData.ProcessReceiveData.Remaining )
                    {
                        Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - iReturnPacketSize != Remaining error!" );

                        // 恢复原始数据状态
                        extendData.ProcessReceiveData.PacketBuffer = null;
                        extendData.ProcessReceiveData.Remaining = WORLD_HEAD_SIZE;

                        // 返回内存池
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // 断开
                        return;
                    }

                    // 获取包的全部长度
                    long iPacketFullLength = extendData.ProcessReceiveData.Remaining + WORLD_HEAD_SIZE;

                    // 读取的数据包
                    PacketReader packetReader = new PacketReader( extendData.ProcessReceiveData.PacketBuffer, iPacketFullLength, WORLD_HEAD_SIZE/*包的ID大小-4个字节、长度大小-2个字节, 6个字节跳过*/);

                    // 给出数据信息头
                    WOWClientPacketHeader clientPacketHeader = WOWClientPacketHeader.GetClientPacketHeader( extendData.ProcessReceiveData.PacketBuffer );


                    //////////////////////////////////////////////////////////////////////////
                    // 输出信息包的日志
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "World_In_Packets.log", eventArgs.NetState.ToString(), clientPacketHeader.PacketID, WordOpCodeName.GetWordOpCodeName( clientPacketHeader.PacketID ) );
                    //////////////////////////////////////////////////////////////////////////


                    // 获取处理数据包的实例
                    PacketHandler packetHandler = ProcessServer.WorldPacketHandlers.GetHandler( clientPacketHeader.PacketID );
                    if ( packetHandler == null ) // 说明还没有解开当前的数据包内容
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // 输出未知信息包的日志
                        //////////////////////////////////////////////////////////////////////////
                        ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "World_In_Unknown_Packets.log", eventArgs.NetState.ToString(), clientPacketHeader.PacketID, WordOpCodeName.GetWordOpCodeName( clientPacketHeader.PacketID ) );
                        //////////////////////////////////////////////////////////////////////////

                        // 恢复原始数据状态
                        extendData.ProcessReceiveData.PacketBuffer = null;
                        extendData.ProcessReceiveData.Remaining = WORLD_HEAD_SIZE;

                        // 返回内存池
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        // 获取剩下的数据长度
                        iReceiveBufferLength = receiveQueueBuffer.Length;

                        continue;
                    }

                    // 当前需处理的数据包的大小
                    long iPacketHandlerLength = packetHandler.Length;
                    if ( iPacketHandlerLength > iPacketFullLength ) // 包需求的数据大小大于得到的数据大小
                    {
                        // 恢复原始数据状态
                        extendData.ProcessReceiveData.PacketBuffer = null;
                        extendData.ProcessReceiveData.Remaining = WORLD_HEAD_SIZE;

                        // 返回内存池
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // 断开
                        return;
                    }

                    // 处理数据
                    packetHandler.OnReceive( eventArgs.NetState, packetReader );

                    // 返回内存池
                    s_ProcessorBuffers.ReleaseBuffer( extendData.ProcessReceiveData.PacketBuffer );

                    // 恢复原始数据状态
                    extendData.ProcessReceiveData.PacketBuffer = null;
                    extendData.ProcessReceiveData.Remaining = WORLD_HEAD_SIZE;

                    // 获取剩下的数据长度
                    iReceiveBufferLength = receiveQueueBuffer.Length;
                }
            }
        }
        #endregion

        #region zh-CHS RealmInitializeNetState静态方法 | en RealmInitializeNetState Static Methods

        #region zh-CHS Packet Info 静态方法 | en Packet Info Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void RealmReceiveQueue_PacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 1 ) // 这是W.O.W协议的实现(因为是环绕环冲区,所以需要取模)
                eventArgs.PacketId = (byte)( ( eventArgs.Buffer[( eventArgs.HeadIndex ) % eventArgs.Buffer.Length] ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void RealmReceiveQueue_PacketLength( object sender, PacketLengthInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 3 ) // 这是W.O.W协议的实现(因为是环绕环冲区,所以需要取模)
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
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketID += new EventHandler<PacketIdInfoEventArgs>( RealmReceiveQueue_PacketID );
                
                // 获取包的长度
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( RealmReceiveQueue_PacketLength );

                // 启动登陆Realm服务
                netStateInit.NetStateInit.EventConnect += new EventHandler<NetStateConnectEventArgs>( RealmInitConnect );

                // 截获输出的信息包
                netStateInit.NetStateInit.EventSendPacket += new EventHandler<NetStateSendPacketEventArgs>( RealmSendPacket );

                // 只有一个连接到RealmServer的NetState实例
                ProcessServer.RealmNetState = netStateInit.NetStateInit;
            }
            else
                Debug.WriteLine( "ProcessNet.RealmList_InitializeNetState(...) - newNetState != null && newNetState.ExtendData == null error!" );
        }

        /// <summary>
        /// 开始登陆Realm服务
        /// </summary>
        private static void RealmInitConnect( object sender, NetStateConnectEventArgs eventArgs )
        {
            NetState netState = eventArgs.NetStateConnect;
            if ( netState == null )
                Debug.WriteLine( "ProcessNet.OnLoginRealmServer(...) - netState == null error!" );
            else
            {
                // 发送登陆信息
                if ( netState.Running )
                    netState.Send( new Realm_LoginRealmServer() );
                else
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "RealmServer： 无法登陆RealmServer服务器 错误！" );
            }
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
            LOGs.WriteLine( LogMessageType.MSG_HACK, "Realm_ProcessReceive...... 0 = {0}", eventArgs.NetState.ReceiveBuffer.Length );

            if ( eventArgs.NetState == null )
            {
                Debug.WriteLine( "ProcessNet.RealmList_ProcessReceive(...) - eventArgs.NetState == null error!" );
                return;
            }

            ReceiveQueue receiveQueueBuffer = eventArgs.NetState.ReceiveBuffer;
            if ( receiveQueueBuffer == null )
            {
                Debug.WriteLine( "ProcessNet.RealmList_ProcessReceive(...) - receiveQueueBuffer == null error!" );
                return;
            }

            if ( receiveQueueBuffer.Length < REALM_HEAD_SIZE )　// 等待数据包的完整
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据
            while ( iReceiveBufferLength >= REALM_HEAD_SIZE )
            {
                // 获取包的 ID
                long iPacketID = receiveQueueBuffer.GetPacketID();

                // 获取包的长度
                long iPacketLength = receiveQueueBuffer.Length;

                if ( iPacketLength > BUFFER_SIZE ) // 数据包过大
                {
                    Debug.WriteLine( "ProcessNet.RealmList_ProcessReceive(...) - iPacketLength > BUFFER_SIZE error!" );

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
                    Debug.WriteLine( "ProcessNet.RealmList_ProcessReceive(...) - iReturnPacketSize != iPacketLength error!" );

                    // 返回内存池
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // 断开
                    return;
                }


                //////////////////////////////////////////////////////////////////////////
                // 输出信息包的日志
                //////////////////////////////////////////////////////////////////////////
                ProcessNet.LogServerPack( packetBuffer, iPacketLength, "Realm_In_Packets.log", eventArgs.NetState.ToString(), iPacketID, RealmOpCodeName.GetRealmOpCodeName( iPacketID ) );
                //////////////////////////////////////////////////////////////////////////


                // 读取的数据包
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketLength, REALM_HEAD_SIZE/*包的ID大小-1个字节、长度大小-2个字节, 3个字节跳过*/);

                // 获取处理数据包的实例
                PacketHandler packetHandler = ProcessServer.RealmPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // 说明还没有解开当前的数据包内容
                {
                    //////////////////////////////////////////////////////////////////////////
                    // 输出未知信息包的日志
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketLength, "Realm_In_Unknown_Packets.log", eventArgs.NetState.ToString(), iPacketID, RealmOpCodeName.GetRealmOpCodeName( iPacketID ) );
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