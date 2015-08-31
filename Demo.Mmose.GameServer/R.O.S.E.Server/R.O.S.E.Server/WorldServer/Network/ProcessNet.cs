#region zh-CHS ��Ȩ���� (C) 2006 - 2006 DemoSoft Corporation. ��������Ȩ�� | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

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

#region zh-CHS �������ֿռ� | en Include namespace
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
        #region zh-CHS ˽�г��� | en Private Constants
        /// <summary>
        /// R.O.S.E �����ݻ���Ĵ�С
        /// </summary>
        private const int BUFFER_SIZE = 4096;
        /// <summary>
        /// R.O.S.E ������ͷ��С
        /// </summary>
        private const int PACKAGE_HEAD = 6;
        #endregion

        #region zh-CHS �ڲ���̬���� | en Internal Static Methods
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

        #region zh-CHS �ڲ���̬���� | en Internal Static Methods
        #region zh-CHS ��̬��Ա���� | en Static Member Variables
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
                // ��ʼ���ͻ��˼��ܵ���������
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

        #region zh-CHS ��̬��Ա���� | en Static Member Variables
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

            //// ����Ƿ��Ѿ��ڴ���������,��ֹ���̶߳�ȡ���������
            //if ( Utility.Lock( netState.ReceiveBuffer ) == false )
            //    return;

            LOGs.WriteLine( LogMessageType.MSG_HACK, "ProcessNet.MessagePump_ProcessReceive(...)-Lock(...){0}", Thread.CurrentThread.Name );

            if ( l_ReceiveQueueBuffer.Length < PACKAGE_HEAD )��// �ȴ����ݰ�������
            {
                //Utility.Free( netState.ReceiveBuffer );
                return;
            }

            long l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length; // ����ʱ��ͻ������ݹ��������Կ��Բ��������ģ�������Ҳû��,���ѱ�֤���߳��д��������е�����
            while ( l_iReceiveBufferLength >= PACKAGE_HEAD )
            {
                // ReceiveQueue�ڲ��Ѿ�������
                long l_iPacketSize = l_ReceiveQueueBuffer.GetPacketLength();
                if ( l_iPacketSize < PACKAGE_HEAD )
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - iPacketSize <= 0 error!" );

                    eventArgs.NetState.Dispose( true ); // �Ͽ�
                    //Utility.Free( netState.ReceiveBuffer );
                    return;
                }

                if ( l_iReceiveBufferLength < l_iPacketSize )��// �ȴ����ݰ�������
                    break;

                if ( l_iPacketSize > BUFFER_SIZE ) // ���ݰ�����
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - iPacketSize > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose( true ); // �Ͽ�
                    //Utility.Free( netState.ReceiveBuffer );
                    return;
                }

                // ��ȡ������
                byte[] l_PacketBuffer = m_ProcessorBuffers.AcquireBuffer();

                // ReceiveQueue�ڲ��Ѿ�������
                long l_iReturnPacketSize = l_ReceiveQueueBuffer.Dequeue( ref l_PacketBuffer, 0, l_iPacketSize );

                // ��ȡ�����ݲ���ͬ
                if ( l_iReturnPacketSize != l_iPacketSize )
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    eventArgs.NetState.Dispose( true ); // �Ͽ�
                    //Utility.Free( netState.ReceiveBuffer );
                    return;
                }

                //////////////////////////////////////////////////////////////////////////
                using ( StreamWriter streamWriter = new StreamWriter( "PreIn_Packets.log", true ) )
                {
                    byte[] byteBuffer = l_PacketBuffer;

                    if ( byteBuffer.Length > 0 )
                    {
                        streamWriter.WriteLine( "�ͻ���:  {0}  δ�����ܹ�����Ϣ�� ���� = 0x{1:X4} ID = Unknown", eventArgs.NetState, l_iPacketSize );
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
                    // �������ݰ�
                    ROSECrypt.CryptPacket( ref l_PacketBuffer, eventArgs.NetState.EncoderSeed );
                }
                catch
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - ROSECrypt.CryptPacket(...) Exception error!" );

                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    eventArgs.NetState.Dispose( true ); // �Ͽ�
                    //Utility.Free( netState.ReceiveBuffer );
                    return;
                }

                // ��ȡ�����ݰ�
                PacketReader l_PacketReader = new PacketReader( l_PacketBuffer, l_iPacketSize, PACKAGE_HEAD/*���ĳ��ȴ�С-2���ֽڡ�ID��С-2���ֽڡ�δ�����ݴ�С-2���ֽ�, 6���ֽ�����*/);

                //////////////////////////////////////////////////////////////////////////
                using ( StreamWriter streamWriter = new StreamWriter( "In_Packets.log", true ) )
                {
                    byte[] byteBuffer = l_PacketBuffer;

                    if ( byteBuffer.Length > 0 )
                    {
                        streamWriter.WriteLine( "�ͻ���:  {0}  �����ܹ�����Ϣ�� ���� = 0x{1:X4} ID = 0x{2:X4}", eventArgs.NetState, l_iPacketSize, l_PacketReader.GetPacketID() );
                        streamWriter.WriteLine( "--------------------------------------------------------------------------" );
                    }

                    using ( MemoryStream memoryStream = new MemoryStream( byteBuffer ) )
                        Utility.FormatBuffer( streamWriter, memoryStream, l_iPacketSize );

                    streamWriter.WriteLine();
                    streamWriter.WriteLine();
                }
                //////////////////////////////////////////////////////////////////////////

                // ��ȡ���ݰ������ID
                long l_iPacketID = l_PacketReader.GetPacketID();

                LOGs.WriteLine( LogMessageType.MSG_HACK, "ProcessNet.MessagePump_ProcessReceive(...)-Packet ID = 0x{0:X4}", l_iPacketID );

                // ��ȡ�������ݰ���ʵ��
                PacketHandler l_PacketHandler = PacketHandlers.GetHandler( l_iPacketID );
                if ( l_PacketHandler == null ) // ˵����û�н⿪��ǰ�����ݰ�����
                {
                    l_PacketReader.Trace( eventArgs.NetState );

                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    // ��ȡʣ�µ����ݳ���
                    l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length;

                    continue;
                }

                // ��ǰ�账������ݰ��Ĵ�С
                long l_iPacketHandlerLength = l_PacketHandler.Length;
                if ( l_iPacketHandlerLength > l_iReturnPacketSize ) // ����������ݴ�С���ڵõ������ݴ�С
                {
                    // �����ڴ��
                    m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    eventArgs.NetState.Dispose( true ); // �Ͽ�
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

                //        // �����ڴ��
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

                // �����ڴ��
                m_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                // ��ȡʣ�µ����ݳ���
                l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length;
            }

            //Utility.Free( netState.ReceiveBuffer );
        }
        #endregion
    }
}
#endregion