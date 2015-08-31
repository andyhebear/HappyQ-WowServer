#region zh-CHS ��Ȩ���� (C) 2006 - 2007 DemoSoft Corporation. ��������Ȩ�� | en Copyright (C) 2006 - 2007 DemoSoft Corporation. All Rights Reserved.

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

#region zh-CHS �������ֿռ� | en Include namespace
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
        #region zh-CHS ˽�г��� | en Private Constants
        /// <summary>
        /// Realm ������ͷ��С(3���ֽ�)
        /// </summary>
        internal const int REALM_HEAD_SIZE = 3;
        /// <summary>
        /// Auth ������ͷ��С(1���ֽ�)
        /// </summary>
        internal const int AUTH_ID_SIZE = 1;
        #endregion

        #region zh-CHS ˽�о�̬���� | en Private Static Properties
        #region zh-CHS ˽�о�̬��Ա���� | en Private Static Member Variables
        /// <summary>
        /// ZoneServer �����ݻ���Ĵ�С
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

        #region zh-CHS LogPack��̬���� | en LogPack Static Methods
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
                    streamWriter.WriteLine( ">>>�ͻ���<--��������<<<" );
                    streamWriter.WriteLine( "--------------------" );
                    streamWriter.WriteLine( "�������ݵ�ַ�� {0}", strNetAddressInfo );
                    streamWriter.WriteLine( "���ȣ�         ʮ������(0x{0:X4})��ʮ����({1})", iLength, iLength );
                    streamWriter.WriteLine( "�����룺       ����({0})��ʮ������(0x{1:X4})��ʮ����({2})", strOpcode, iOpcode, iOpcode );
                    streamWriter.WriteLine( "���ݣ�" );
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
                    streamWriter.WriteLine( ">>>�����-->��������<<<" );
                    streamWriter.WriteLine( "--------------------" );
                    streamWriter.WriteLine( "�������ݵ�ַ�� {0}", strNetAddressInfo );
                    streamWriter.WriteLine( "���ȣ�         ʮ������(0x{0:X4})��ʮ����({1})", iLength, iLength );
                    streamWriter.WriteLine( "�����룺       ����({0})��ʮ������(0x{1:X4})��ʮ����({2})", strOpcode, iOpcode, iOpcode );
                    streamWriter.WriteLine( "���ݣ�" );
                }

                using ( MemoryStream memoryStream = new MemoryStream( byteBuffer ) )
                    Utility.FormatBuffer( streamWriter, memoryStream, iLength );

                streamWriter.WriteLine();
                streamWriter.WriteLine();
            }
            //////////////////////////////////////////////////////////////////////////
        }
        #endregion

        #region zh-CHS RealmInitializeNetState��̬���� | en RealmInitializeNetState Static Methods

        #region zh-CHS Packet Info ��̬���� | en Packet Info Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void RealmGetPacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 1/*Packet ID ��С*/ ) // ����W.O.WЭ���ʵ��(��Ϊ�ǻ��ƻ�����,������Ҫȡģ)
                eventArgs.PacketId = (byte)( ( eventArgs.Buffer[eventArgs.HeadIndex % eventArgs.Buffer.Length] ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void RealmGetPacketLength( object sender, PacketLengthInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 3/*Packet ID + Length ��С*/ ) // ����W.O.WЭ���ʵ��(��Ϊ�ǻ��ƻ�����,������Ҫȡģ)
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
                // ��ʼ���ͻ���
                RealmExtendData extendData = new RealmExtendData();

                netStateInit.NetStateInit.RegisterComponent<RealmExtendData>( RealmExtendData.COMPONENT_ID, extendData );

                // ��ȡ����ID
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketID += new EventHandler<PacketIdInfoEventArgs>( RealmGetPacketID );

                // ��ȡ���ĳ���
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( RealmGetPacketLength );

                // �ػ��������Ϣ��
                netStateInit.NetStateInit.EventSendPacket += new EventHandler<NetStateSendPacketEventArgs>( RealmSendPacket );
            }
            else
                Debug.WriteLine( "ProcessNet.Realm_InitializeNetState(...) - newNetState != null && newNetState.ExtendData == null error!" );
        }

        /// <summary>
        /// ���������Ϣ������־
        /// </summary>
        private static void RealmSendPacket( object sender, NetStateSendPacketEventArgs eventArgs )
        {
            PacketBuffer sendBuffer = eventArgs.SendPacket.AcquireBuffer();

            //////////////////////////////////////////////////////////////////////////
            // �����Ϣ������־
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

            if ( receiveQueueBuffer.Length < REALM_HEAD_SIZE )��// �ȴ����ݰ�������
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // ����ʱ��ͻ������ݹ��������Կ��Բ��������ģ�������Ҳû��,���ѱ�֤���߳��д��������е�����
            while ( iReceiveBufferLength >= REALM_HEAD_SIZE )
            {
                // ��ȡ���� ID
                long iPacketID = receiveQueueBuffer.GetPacketID();

                // ��ȡ���� ����ID����
                long iPacketLength = receiveQueueBuffer.GetPacketLength();

                // ��ȡ����ȫ������
                long iPacketFullLength = iPacketLength + REALM_HEAD_SIZE;

                // �ȴ����ݰ�������
                if ( iReceiveBufferLength < iPacketFullLength )
                    break;

                if ( iPacketLength > BUFFER_SIZE ) // ���ݰ�����
                {
                    Debug.WriteLine( "ProcessNet.Realm_ProcessReceive(...) - iPacketLength > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��ȡ������
                byte[] packetBuffer = s_ProcessorBuffers.AcquireBuffer();

                // ��ȡ��������
                long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, iPacketFullLength );

                // ��ȡ�����ݲ���ͬ
                if ( iReturnPacketSize != iPacketFullLength )
                {
                    Debug.WriteLine( "ProcessNet.Realm_ProcessReceive(...) - iReturnPacketSize != iPacketFullLength error!" );

                    // �����ڴ��
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }


                //////////////////////////////////////////////////////////////////////////
                // �����Ϣ������־
                //////////////////////////////////////////////////////////////////////////
                ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "Realm_In_Packets.log", eventArgs.NetState.ToString(), iPacketID, RealmOpCodeName.GetRealmOpCodeName( iPacketID ) );
                //////////////////////////////////////////////////////////////////////////


                // ��ȡ�����ݰ�
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketFullLength, REALM_HEAD_SIZE/*����ID��С-1���ֽڡ����ȴ�С-2���ֽ�, 3���ֽ�����*/);

                // ��ȡ�������ݰ���ʵ��
                PacketHandler packetHandler = ProcessServer.RealmPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // ˵����û�н⿪��ǰ�����ݰ�����
                {
                    //////////////////////////////////////////////////////////////////////////
                    // �����Ϣ������־
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "Realm_Unknown_Packets.log", eventArgs.NetState.ToString(), iPacketID, RealmOpCodeName.GetRealmOpCodeName( iPacketID ) );
                    //////////////////////////////////////////////////////////////////////////

                    // �����ڴ��
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    // ��ȡʣ�µ����ݳ���
                    iReceiveBufferLength = receiveQueueBuffer.Length;

                    continue;
                }

                // ��ǰ�账������ݰ��Ĵ�С
                long iPacketHandlerLength = packetHandler.Length;
                if ( iPacketHandlerLength > iReturnPacketSize ) // ����������ݴ�С���ڵõ������ݴ�С
                {
                    // �����ڴ��
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��������
                packetHandler.OnReceive( eventArgs.NetState, packetReader );

                // �����ڴ��
                s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                // ��ȡʣ�µ����ݳ���
                iReceiveBufferLength = receiveQueueBuffer.Length;
            }
        }
        #endregion

        #region zh-CHS AuthInitializeNetState��̬���� | en AuthInitializeNetState Static Methods

        #region zh-CHS Packet Info ��̬���� | en Packet Info Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void AuthGetPacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 1 ) // ����W.O.WЭ���ʵ��(��Ϊ�ǻ��ƻ�����,������Ҫȡģ)
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
                // ��ʼ���ͻ���
                AuthExtendData extendData = new AuthExtendData();

                netStateInit.NetStateInit.RegisterComponent<AuthExtendData>( AuthExtendData.COMPONENT_ID, extendData );

                // ��ȡ����ID
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketID += new EventHandler<PacketIdInfoEventArgs>( AuthGetPacketID );
                
                // �ػ��������Ϣ��
                netStateInit.NetStateInit.EventSendPacket += new EventHandler<NetStateSendPacketEventArgs>( AuthSendPacket );
            }
            else
                Debug.WriteLine( "ProcessNet.Auth_InitializeNetState(...) - newNetState != null && newNetState.ExtendData == null error!" );
        }

        /// <summary>
        /// ���������Ϣ������־
        /// </summary>
        private static void AuthSendPacket( object sender, NetStateSendPacketEventArgs eventArgs )
        {
            PacketBuffer sendBuffer = eventArgs.SendPacket.AcquireBuffer();

            //////////////////////////////////////////////////////////////////////////
            // �����Ϣ������־
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

            if ( receiveQueueBuffer.Length < AUTH_ID_SIZE )��// �ȴ����ݰ�������
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // ����ʱ��ͻ������ݹ��������Կ��Բ��������ģ�������Ҳû��,���ѱ�֤���߳��д��������е�����
            while ( iReceiveBufferLength >= AUTH_ID_SIZE )
            {
                // ��ȡ���� ID
                long iPacketID = receiveQueueBuffer.GetPacketID();

                // ��ȡ���ĳ���(���ݰ�����û�д����ݰ���С���ֶ�)
                long iPacketLength = receiveQueueBuffer.Length;

                if ( iPacketLength > BUFFER_SIZE ) // ���ݰ�����
                {
                    Debug.WriteLine( "ProcessNet.Auth_ProcessReceive(...) - iPacketLength > BUFFER_SIZE error!" );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��ȡ������
                byte[] packetBuffer = s_ProcessorBuffers.AcquireBuffer();

                // ��ȡ��������
                long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, iPacketLength );

                // ��ȡ�����ݲ���ͬ
                if ( iReturnPacketSize != iPacketLength )
                {
                    Debug.WriteLine( "ProcessNet.Auth_ProcessReceive(...) - iReturnPacketSize != iPacketLength error!" );

                    // �����ڴ��
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }


                //////////////////////////////////////////////////////////////////////////
                // �����Ϣ������־
                //////////////////////////////////////////////////////////////////////////
                ProcessNet.LogServerPack( packetBuffer, iPacketLength, "Auth_In_Packets.log", eventArgs.NetState.ToString(), iPacketID, AuthOpCodeName.GetAuthOpCodeName( iPacketID ) );
                //////////////////////////////////////////////////////////////////////////


                // ��ȡ�����ݰ�
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketLength, 0 ); // ���������ݰ�ͷ

                // ��ȡ�������ݰ���ʵ��
                PacketHandler packetHandler = ProcessServer.AuthPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // ˵����û�н⿪��ǰ�����ݰ�����
                {
                    //////////////////////////////////////////////////////////////////////////
                    // �����Ϣ������־
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketLength, "Auth_Unknown_Packets.log", eventArgs.NetState.ToString(), iPacketID, AuthOpCodeName.GetAuthOpCodeName( iPacketID ) );
                    //////////////////////////////////////////////////////////////////////////

                    // �����ڴ��
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    // ��ȡʣ�µ����ݳ���
                    iReceiveBufferLength = receiveQueueBuffer.Length;

                    continue;
                }

                // ��ǰ�账������ݰ��Ĵ�С
                long iPacketHandlerLength = packetHandler.Length;
                if ( iPacketHandlerLength > iReturnPacketSize ) // ����������ݴ�С���ڵõ������ݴ�С
                {
                    // �����ڴ��
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }

                // ��������
                packetHandler.OnReceive( eventArgs.NetState, packetReader );

                // �����ڴ��
                s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                // ��ȡʣ�µ����ݳ���
                iReceiveBufferLength = receiveQueueBuffer.Length;
            }
        }
        #endregion
    }
}
#endregion