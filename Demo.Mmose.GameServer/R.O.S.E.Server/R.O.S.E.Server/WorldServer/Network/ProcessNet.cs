#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2006 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.IO;
using System.Diagnostics;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_G.O.S.E.ServerEngine.Util;
using System.Threading;
using System.Collections.Generic;
using Demo_R.O.S.E.Mobile;
using Demo_R.O.S.E.Common;
#endregion

namespace Demo_R.O.S.E.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessNet
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// R.O.S.E 的数据缓存的大小
        /// </summary>
        private const int BUFFER_SIZE = 4096;
        /// <summary>
        /// R.O.S.E 的数据头大小
        /// </summary>
        private const int PACKAGE_HEAD = 6;
        #endregion

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCharGuid"></param>
        /// <returns></returns>
        internal static NetState GetClientByCharGuid( long iCharGuid )
        {
            NetState[] netStateArray = Program.BaseWorld.NetStateToArray();

            foreach ( NetState netState in netStateArray )
            {
                WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
                if ( l_ExtendData == null )
                    continue;

                if ( l_ExtendData.ROSEMobile.CharacterGuid == iCharGuid )
                    return netState;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCharName"></param>
        /// <returns></returns>
        internal static NetState GetClientByCharName( string strCharName )
        {
            NetState[] netStateArray = Program.BaseWorld.NetStateToArray();

            foreach ( NetState netState in netStateArray )
            {
                WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
                if ( l_ExtendData == null )
                    continue;

                if ( l_ExtendData.ROSEMobile.CharacterName == strCharName )
                    return netState;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAccount"></param>
        /// <returns></returns>
        internal static NetState GetClientByAccountGuid( long iAccount )
        {
            NetState[] netStateArray = Program.BaseWorld.NetStateToArray();

            foreach ( NetState netState in netStateArray )
            {
                WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
                if ( l_ExtendData == null )
                    continue;

                if ( l_ExtendData.ROSEMobile.AccountGuid == iAccount )
                    return netState;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iClanGuid"></param>
        /// <returns></returns>
        internal static NetState[] GetClientsByClanGuid( long iClanGuid )
        {
            List<NetState> netStateList = new List<NetState>();

            NetState[] netStateArray = Program.BaseWorld.NetStateToArray();

            foreach ( NetState netState in netStateArray )
            {
                WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
                if ( l_ExtendData == null )
                    continue;

                if ( l_ExtendData.ROSEMobile.ClanGuid == iClanGuid )
                    netStateList.Add( netState );
            }

            return netStateList.ToArray();
        }
        #endregion

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static BufferPool m_CryptTableBuffers = new BufferPool( "ProcessNet - CryptTableBuffers", 2048, ROSECrypt.Instance().CryptTableBuffer.Length );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        public static void NetState_InitializeNetState( NetState newNetState )
        {
            if ( newNetState.EncoderSeed == null && newNetState.ExtendData == null )
            {
                // 初始化客户端加密的数据种子
                newNetState.EncoderSeed = m_CryptTableBuffers.AcquireBuffer();
                Buffer.BlockCopy( ROSECrypt.Instance().CryptTableBuffer, 0, newNetState.EncoderSeed, 0, ROSECrypt.Instance().CryptTableBuffer.Length );

                ROSEMobile l_ROSEMobile = new ROSEMobile();
                newNetState.Mobile = l_ROSEMobile;

                l_ROSEMobile.Player = true;
                l_ROSEMobile.NetState = newNetState;

                WorldServerExtendData l_ExtendData = new WorldServerExtendData();
                l_ExtendData.ROSEMobile = l_ROSEMobile;

                newNetState.ExtendData = l_ExtendData;
            }
            else
                Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - newNetState.Seed != null error!" );
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static BufferPool m_ProcessorBuffers = new BufferPool( "ProcessNet - ProcessorBuffers", 2048, BUFFER_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal static void MessagePump_ProcessReceive( object sender, NetStateEventArgs eventArgs )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "ProcessNet.MessagePump_ProcessReceive(...){0}", Thread.CurrentThread.Name );

            if ( eventArgs.NetState == null )
            {
                Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - netState == null error!" );
                return;
            }

            ReceiveQueue l_ReceiveQueueBuffer = eventArgs.NetState.ReceiveBuffer;
            if ( l_ReceiveQueueBuffer == null )
            {
                Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - byteQueueBuffer == null error!" );
                return;
            }

            //// 检测是否已经在处理数据中,防止多线程读取里面的数据
            //if ( Utility.Lock( netState.ReceiveBuffer ) == false )
            //    return;

            LOGs.WriteLine( LogMessageType.MSG_HACK, "ProcessNet.MessagePump_ProcessReceive(...)-Lock(...){0}", Thread.CurrentThread.Name );

            if ( l_ReceiveQueueBuffer.Length < PACKAGE_HEAD )　// 等待数据包的完整
            {
                //Utility.Free( netState.ReceiveBuffer );
                return;
            }

            long l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length; // 隔段时间就会有数据过来，所以可以不用锁定的，锁定了也没用,很难保证多线程中处理了所有的数据
            while ( l_iReceiveBufferLength >= PACKAGE_HEAD )
            {
                // ReceiveQueue内部已经有锁定
                long l_iPacketSize = l_ReceiveQueueBuffer.GetPacketLength();
                if ( l_iPacketSize < PACKAGE_HEAD )
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - iPacketSize <= 0 error!" );

                    eventArgs.NetState.Dispose( true ); // 断开
                    //Utility.Free( netState.ReceiveBuffer );
                    return;
                }

                if ( l_iReceiveBufferLength < l_iPacketSize )　// 等待数据包的完整
                    break;

                if ( l_iPacketSize > BUFFER_SIZE ) // 数据包过大
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose( true ); // 断开
                    //Utility.Free( netState.ReceiveBuffer );
                    return;
                }

                // 获取空数据
                byte[] l_PacketBuffer = m_ProcessorBuffers.AcquireBuffer();

                // ReceiveQueue内部已经有锁定
                long l_iReturnPacketSize = l_ReceiveQueueBuffer.Dequeue( ref l_PacketBuffer, 0, l_iPacketSize );

                // 获取的数据不相同
                if ( l_iReturnPacketSize != l_iPacketSize )
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    eventArgs.NetState.Dispose( true ); // 断开
                    //Utility.Free( netState.ReceiveBuffer );
                    return;
                }

                //////////////////////////////////////////////////////////////////////////
                using ( StreamWriter streamWriter = new StreamWriter( "PreIn_Packets.log", true ) )
                {
                    byte[] byteBuffer = l_PacketBuffer;

                    if ( byteBuffer.Length > 0 )
                    {
                        streamWriter.WriteLine( "客户端:  {0}  未经解密过的信息包 长度 = 0x{1:X4} ID = Unknown", eventArgs.NetState, l_iPacketSize );
                        streamWriter.WriteLine( "--------------------------------------------------------------------------" );
                    }

                    using ( MemoryStream memoryStream = new MemoryStream( byteBuffer ) )
                        Utility.FormatBuffer( streamWriter, memoryStream, l_iPacketSize );

                    streamWriter.WriteLine();
                    streamWriter.WriteLine();
                }
                //////////////////////////////////////////////////////////////////////////

                try
                {
                    // 解密数据包
                    ROSECrypt.CryptPacket( ref l_PacketBuffer, eventArgs.NetState.EncoderSeed );
                }
                catch
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - ROSECrypt.CryptPacket(...) Exception error!" );

                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    eventArgs.NetState.Dispose( true ); // 断开
                    //Utility.Free( netState.ReceiveBuffer );
                    return;
                }

                // 读取的数据包
                PacketReader l_PacketReader = new PacketReader( l_PacketBuffer, l_iPacketSize, PACKAGE_HEAD/*包的长度大小-2个字节、ID大小-2个字节、未用数据大小-2个字节, 6个字节跳过*/);

                //////////////////////////////////////////////////////////////////////////
                using ( StreamWriter streamWriter = new StreamWriter( "In_Packets.log", true ) )
                {
                    byte[] byteBuffer = l_PacketBuffer;

                    if ( byteBuffer.Length > 0 )
                    {
                        streamWriter.WriteLine( "客户端:  {0}  经解密过的信息包 长度 = 0x{1:X4} ID = 0x{2:X4}", eventArgs.NetState, l_iPacketSize, l_PacketReader.GetPacketID() );
                        streamWriter.WriteLine( "--------------------------------------------------------------------------" );
                    }

                    using ( MemoryStream memoryStream = new MemoryStream( byteBuffer ) )
                        Utility.FormatBuffer( streamWriter, memoryStream, l_iPacketSize );

                    streamWriter.WriteLine();
                    streamWriter.WriteLine();
                }
                //////////////////////////////////////////////////////////////////////////

                // 获取数据包命令的ID
                long l_iPacketID = l_PacketReader.GetPacketID();

                LOGs.WriteLine( LogMessageType.MSG_HACK, "ProcessNet.MessagePump_ProcessReceive(...)-Packet ID = 0x{0:X4}", l_iPacketID );

                // 获取处理数据包的实例
                PacketHandler l_PacketHandler = PacketHandlers.GetHandler( l_iPacketID );
                if ( l_PacketHandler == null ) // 说明还没有解开当前的数据包内容
                {
                    l_PacketReader.Trace( eventArgs.NetState );

                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    // 获取剩下的数据长度
                    l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length;

                    continue;
                }

                // 当前需处理的数据包的大小
                long l_iPacketHandlerLength = l_PacketHandler.Length;
                if ( l_iPacketHandlerLength > l_iReturnPacketSize ) // 包需求的数据大小大于得到的数据大小
                {
                    // 返回内存池
                    m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    eventArgs.NetState.Dispose( true ); // 断开
                    //Utility.Free( netState.ReceiveBuffer );
                    return;
                }

                //ThrottlePacketCallback l_ThrottlePacketCallback = l_PacketHandler.ThrottleCallback;
                //if ( l_ThrottlePacketCallback != null )
                //{
                //    if ( l_ThrottlePacketCallback( netState ) == false )
                //    {
                //        Monitor.Enter( m_LockNetStateThrottled );
                //        {
                //            m_NetStateThrottled.Enqueue( netState );
                //        }
                //        Monitor.Exit( m_LockNetStateThrottled );

                //        // 返回内存池
                //        m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                //        return;
                //    }
                //}

                PacketProfile l_PacketProfile = PacketProfile.GetIncomingProfile( l_iPacketID );
                DateTime dateTimeStart = ( l_PacketProfile == null ? DateTime.MinValue : DateTime.Now );
                {

                    l_PacketHandler.OnReceive( eventArgs.NetState, l_PacketReader );
                }
                if ( l_PacketProfile != null )
                    l_PacketProfile.Record( l_iPacketHandlerLength, DateTime.Now - dateTimeStart );

                // 返回内存池
                m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                // 获取剩下的数据长度
                l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length;
            }

            //Utility.Free( netState.ReceiveBuffer );
        }
        #endregion
    }
}
#endregion