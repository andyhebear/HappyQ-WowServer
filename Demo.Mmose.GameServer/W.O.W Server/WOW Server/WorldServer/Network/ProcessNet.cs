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
        #region zh-CHS ˽�г��� | en Private Constants
        /// <summary>
        /// Realm ������ͷ��С(3�ֽ�)
        /// </summary>
        internal const int REALM_HEAD_SIZE = 3;
        /// <summary>
        /// World ������ͷ��С(6�ֽ�)
        /// </summary>
        internal const int WORLD_HEAD_SIZE = WowCrypt.CRYPTED_RECV_LEN;
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

        #region zh-CHS WorldInitializeNetState��̬���� | en WorldInitializeNetState Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        internal static void WorldInitializeNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "World_InitializeNetState...... 0" );

            if ( netStateInit.NetStateInit != null )
            {
                // ��ʼ���ͻ���
                WorldExtendData extendData = new WorldExtendData();

                // �ͻ��˱������չ����
                netStateInit.NetStateInit.RegisterComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID, extendData );

                // �ӽ������ݵĽӿ�
                netStateInit.NetStateInit.PacketEncoder = extendData;

                // ��ʼ���ͷ������������Ӹ��ͻ���
                netStateInit.NetStateInit.EventConnect += new EventHandler<NetStateConnectEventArgs>( WorldInitConnect );

                // �ػ��������Ϣ��
                netStateInit.NetStateInit.EventSendPacket += new EventHandler<NetStateSendPacketEventArgs>( WorldSendPacket );
            }
            else
                Debug.WriteLine( "ProcessNet.World_InitializeNetState(...) - newNetState != null && newNetState.ExtendData == null error!" );
        }

        /// <summary>
        /// ��ʼ���ͷ������������Ӹ��ͻ���
        /// </summary>
        private static void WorldInitConnect( object sender, NetStateConnectEventArgs eventArgs )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "World_InitConnect...... 0" );

            NetState netState = eventArgs.NetStateConnect;
            if ( netState == null )
                Debug.WriteLine( "ProcessNet.World_InitConnect(...) - netState == null error!" );
            else
            {
                // ���ͷ���������������Ϣ
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
        /// ���������Ϣ������־
        /// </summary>
        private static void WorldSendPacket( object sender, NetStateSendPacketEventArgs eventArgs )
        {
            PacketBuffer sendBuffer = eventArgs.SendPacket.AcquireBuffer();

            //////////////////////////////////////////////////////////////////////////
            // �����Ϣ������־
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

            if ( receiveQueueBuffer.Length < extendData.ProcessReceiveData.Remaining )��// �ȴ����ݰ�������(Remaining Ĭ�ϵĴ�СΪWORLD_HEAD_SIZE)
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // ����ʱ��ͻ������ݹ��������Կ��Բ��������ģ�������Ҳû��,���ѱ�֤���߳��д��������е�����(ָ Length)
            while ( iReceiveBufferLength >= extendData.ProcessReceiveData.Remaining )
            {
                if ( extendData.ProcessReceiveData.PacketBuffer == null ) // ����� ��������Ҫ��ȡ�µ����ݰ��Ͱ�ͷ(Remaining == WORLD_HEAD_SIZE)
                {
                    // ��ȡ������
                    byte[] packetBuffer = s_ProcessorBuffers.AcquireBuffer();

                    // ��ȡ���ݰ�ͷ������
                    long iReturnPacketHeadSize = receiveQueueBuffer.Dequeue( ref packetBuffer, 0, WORLD_HEAD_SIZE );

                    // ��ȡ�����ݲ���ͬ
                    if ( iReturnPacketHeadSize != WORLD_HEAD_SIZE )
                    {
                        Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - iReturnPacketHeadSize != WORLD_HEAD_SIZE error!" );

                        // �����ڴ��
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // �Ͽ�
                        return;
                    }

                    IPacketEncoder packetEncoder = eventArgs.NetState.PacketEncoder as IPacketEncoder;
                    if ( packetEncoder == null )
                    {
                        Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - packetEncoder == null error!" );

                        // �����ڴ��
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // �Ͽ�
                        return;
                    }

                    // �������ݰ�ͷ
                    long iClientPacketHeader = WORLD_HEAD_SIZE;
                    packetEncoder.DecodeIncomingPacket( eventArgs.NetState, ref packetBuffer, ref iClientPacketHeader );

                    // ����������Ϣͷ
                    WOWClientPacketHeader clientPacketHeader = WOWClientPacketHeader.GetClientPacketHeader( packetBuffer );

                    int iRemaining = clientPacketHeader.PacketSize - 4; // -4 �Ǵ���ʣ������ݰ���С(Ϊʲô���Ǽ�6�أ�)
                    if ( receiveQueueBuffer.Length < iRemaining )��// �ȴ����ݰ�������
                    {
                        extendData.ProcessReceiveData.PacketBuffer = packetBuffer;
                        extendData.ProcessReceiveData.Remaining = (uint)iRemaining;

                        return;
                    }

                    // ��ȡ��Ϣ�����ݵ�ʣ������
                    long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, WORLD_HEAD_SIZE, iRemaining /*��ȡʣ�����ݰ���С���ֽ���*/ );
                    
                    // ��ȡ�����ݲ���ͬ
                    if ( iReturnPacketSize != iRemaining )
                    {
                        Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - iReturnPacketSize != iRemaining error!" );

                        // �����ڴ��
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // �Ͽ�
                        return;
                    }

                    // ��ȡ����ȫ������
                    long iPacketFullLength = iRemaining + WORLD_HEAD_SIZE;

                    // ��ȡ�����ݰ�
                    PacketReader packetReader = new PacketReader( packetBuffer, iPacketFullLength, WORLD_HEAD_SIZE/*����ID��С-4���ֽڡ����ȴ�С-2���ֽ�, 6���ֽ�����*/);


                    //////////////////////////////////////////////////////////////////////////
                    // �����Ϣ������־
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "World_In_Packets.log", eventArgs.NetState.ToString(), clientPacketHeader.PacketID, WordOpCodeName.GetWordOpCodeName( clientPacketHeader.PacketID ) );
                    //////////////////////////////////////////////////////////////////////////


                    // ��ȡ�������ݰ���ʵ��
                    PacketHandler packetHandler = ProcessServer.WorldPacketHandlers.GetHandler( clientPacketHeader.PacketID );
                    if ( packetHandler == null ) // ˵����û�н⿪��ǰ�����ݰ�����
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // ���δ֪��Ϣ������־
                        //////////////////////////////////////////////////////////////////////////
                        ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "World_In_Unknown_Packets.log", eventArgs.NetState.ToString(), clientPacketHeader.PacketID, WordOpCodeName.GetWordOpCodeName( clientPacketHeader.PacketID ) );
                        //////////////////////////////////////////////////////////////////////////

                        // �����ڴ��
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        // ��ȡʣ�µ����ݳ���
                        iReceiveBufferLength = receiveQueueBuffer.Length;

                        continue;
                    }

                    // ��ǰ�账������ݰ��Ĵ�С
                    long iPacketHandlerLength = packetHandler.Length;
                    if ( iPacketHandlerLength > iPacketFullLength ) // ����������ݴ�С���ڵõ������ݴ�С
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
                else    //�������ݰ�ͷ��ȡʣ������
                {
                    byte[] packetBuffer = extendData.ProcessReceiveData.PacketBuffer;

                    // ��ȡ��Ϣ�����ݵ�ʣ������
                    long iReturnPacketSize = receiveQueueBuffer.Dequeue( ref packetBuffer, WORLD_HEAD_SIZE, extendData.ProcessReceiveData.Remaining /*��ȡʣ�����ݰ���С���ֽ���*/ );

                    // ��ȡ�����ݲ���ͬ
                    if ( iReturnPacketSize != extendData.ProcessReceiveData.Remaining )
                    {
                        Debug.WriteLine( "ProcessNet.World_ProcessReceive(...) - iReturnPacketSize != Remaining error!" );

                        // �ָ�ԭʼ����״̬
                        extendData.ProcessReceiveData.PacketBuffer = null;
                        extendData.ProcessReceiveData.Remaining = WORLD_HEAD_SIZE;

                        // �����ڴ��
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // �Ͽ�
                        return;
                    }

                    // ��ȡ����ȫ������
                    long iPacketFullLength = extendData.ProcessReceiveData.Remaining + WORLD_HEAD_SIZE;

                    // ��ȡ�����ݰ�
                    PacketReader packetReader = new PacketReader( extendData.ProcessReceiveData.PacketBuffer, iPacketFullLength, WORLD_HEAD_SIZE/*����ID��С-4���ֽڡ����ȴ�С-2���ֽ�, 6���ֽ�����*/);

                    // ����������Ϣͷ
                    WOWClientPacketHeader clientPacketHeader = WOWClientPacketHeader.GetClientPacketHeader( extendData.ProcessReceiveData.PacketBuffer );


                    //////////////////////////////////////////////////////////////////////////
                    // �����Ϣ������־
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "World_In_Packets.log", eventArgs.NetState.ToString(), clientPacketHeader.PacketID, WordOpCodeName.GetWordOpCodeName( clientPacketHeader.PacketID ) );
                    //////////////////////////////////////////////////////////////////////////


                    // ��ȡ�������ݰ���ʵ��
                    PacketHandler packetHandler = ProcessServer.WorldPacketHandlers.GetHandler( clientPacketHeader.PacketID );
                    if ( packetHandler == null ) // ˵����û�н⿪��ǰ�����ݰ�����
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // ���δ֪��Ϣ������־
                        //////////////////////////////////////////////////////////////////////////
                        ProcessNet.LogServerPack( packetBuffer, iPacketFullLength, "World_In_Unknown_Packets.log", eventArgs.NetState.ToString(), clientPacketHeader.PacketID, WordOpCodeName.GetWordOpCodeName( clientPacketHeader.PacketID ) );
                        //////////////////////////////////////////////////////////////////////////

                        // �ָ�ԭʼ����״̬
                        extendData.ProcessReceiveData.PacketBuffer = null;
                        extendData.ProcessReceiveData.Remaining = WORLD_HEAD_SIZE;

                        // �����ڴ��
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        // ��ȡʣ�µ����ݳ���
                        iReceiveBufferLength = receiveQueueBuffer.Length;

                        continue;
                    }

                    // ��ǰ�账������ݰ��Ĵ�С
                    long iPacketHandlerLength = packetHandler.Length;
                    if ( iPacketHandlerLength > iPacketFullLength ) // ����������ݴ�С���ڵõ������ݴ�С
                    {
                        // �ָ�ԭʼ����״̬
                        extendData.ProcessReceiveData.PacketBuffer = null;
                        extendData.ProcessReceiveData.Remaining = WORLD_HEAD_SIZE;

                        // �����ڴ��
                        s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                        eventArgs.NetState.Dispose(); // �Ͽ�
                        return;
                    }

                    // ��������
                    packetHandler.OnReceive( eventArgs.NetState, packetReader );

                    // �����ڴ��
                    s_ProcessorBuffers.ReleaseBuffer( extendData.ProcessReceiveData.PacketBuffer );

                    // �ָ�ԭʼ����״̬
                    extendData.ProcessReceiveData.PacketBuffer = null;
                    extendData.ProcessReceiveData.Remaining = WORLD_HEAD_SIZE;

                    // ��ȡʣ�µ����ݳ���
                    iReceiveBufferLength = receiveQueueBuffer.Length;
                }
            }
        }
        #endregion

        #region zh-CHS RealmInitializeNetState��̬���� | en RealmInitializeNetState Static Methods

        #region zh-CHS Packet Info ��̬���� | en Packet Info Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void RealmReceiveQueue_PacketID( object sender, PacketIdInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 1 ) // ����W.O.WЭ���ʵ��(��Ϊ�ǻ��ƻ�����,������Ҫȡģ)
                eventArgs.PacketId = (byte)( ( eventArgs.Buffer[( eventArgs.HeadIndex ) % eventArgs.Buffer.Length] ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void RealmReceiveQueue_PacketLength( object sender, PacketLengthInfoEventArgs eventArgs )
        {
            if ( eventArgs.BufferSize >= 3 ) // ����W.O.WЭ���ʵ��(��Ϊ�ǻ��ƻ�����,������Ҫȡģ)
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
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketID += new EventHandler<PacketIdInfoEventArgs>( RealmReceiveQueue_PacketID );
                
                // ��ȡ���ĳ���
                netStateInit.NetStateInit.ReceiveBuffer.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( RealmReceiveQueue_PacketLength );

                // ������½Realm����
                netStateInit.NetStateInit.EventConnect += new EventHandler<NetStateConnectEventArgs>( RealmInitConnect );

                // �ػ��������Ϣ��
                netStateInit.NetStateInit.EventSendPacket += new EventHandler<NetStateSendPacketEventArgs>( RealmSendPacket );

                // ֻ��һ�����ӵ�RealmServer��NetStateʵ��
                ProcessServer.RealmNetState = netStateInit.NetStateInit;
            }
            else
                Debug.WriteLine( "ProcessNet.RealmList_InitializeNetState(...) - newNetState != null && newNetState.ExtendData == null error!" );
        }

        /// <summary>
        /// ��ʼ��½Realm����
        /// </summary>
        private static void RealmInitConnect( object sender, NetStateConnectEventArgs eventArgs )
        {
            NetState netState = eventArgs.NetStateConnect;
            if ( netState == null )
                Debug.WriteLine( "ProcessNet.OnLoginRealmServer(...) - netState == null error!" );
            else
            {
                // ���͵�½��Ϣ
                if ( netState.Running )
                    netState.Send( new Realm_LoginRealmServer() );
                else
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "RealmServer�� �޷���½RealmServer������ ����" );
            }
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

            if ( receiveQueueBuffer.Length < REALM_HEAD_SIZE )��// �ȴ����ݰ�������
                return;

            long iReceiveBufferLength = receiveQueueBuffer.Length; // ����ʱ��ͻ������ݹ��������Կ��Բ��������ģ�������Ҳû��,���ѱ�֤���߳��д��������е�����
            while ( iReceiveBufferLength >= REALM_HEAD_SIZE )
            {
                // ��ȡ���� ID
                long iPacketID = receiveQueueBuffer.GetPacketID();

                // ��ȡ���ĳ���
                long iPacketLength = receiveQueueBuffer.Length;

                if ( iPacketLength > BUFFER_SIZE ) // ���ݰ�����
                {
                    Debug.WriteLine( "ProcessNet.RealmList_ProcessReceive(...) - iPacketLength > BUFFER_SIZE error!" );

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
                    Debug.WriteLine( "ProcessNet.RealmList_ProcessReceive(...) - iReturnPacketSize != iPacketLength error!" );

                    // �����ڴ��
                    s_ProcessorBuffers.ReleaseBuffer( packetBuffer );

                    eventArgs.NetState.Dispose(); // �Ͽ�
                    return;
                }


                //////////////////////////////////////////////////////////////////////////
                // �����Ϣ������־
                //////////////////////////////////////////////////////////////////////////
                ProcessNet.LogServerPack( packetBuffer, iPacketLength, "Realm_In_Packets.log", eventArgs.NetState.ToString(), iPacketID, RealmOpCodeName.GetRealmOpCodeName( iPacketID ) );
                //////////////////////////////////////////////////////////////////////////


                // ��ȡ�����ݰ�
                PacketReader packetReader = new PacketReader( packetBuffer, iPacketLength, REALM_HEAD_SIZE/*����ID��С-1���ֽڡ����ȴ�С-2���ֽ�, 3���ֽ�����*/);

                // ��ȡ�������ݰ���ʵ��
                PacketHandler packetHandler = ProcessServer.RealmPacketHandlers.GetHandler( iPacketID );
                if ( packetHandler == null ) // ˵����û�н⿪��ǰ�����ݰ�����
                {
                    //////////////////////////////////////////////////////////////////////////
                    // ���δ֪��Ϣ������־
                    //////////////////////////////////////////////////////////////////////////
                    ProcessNet.LogServerPack( packetBuffer, iPacketLength, "Realm_In_Unknown_Packets.log", eventArgs.NetState.ToString(), iPacketID, RealmOpCodeName.GetRealmOpCodeName( iPacketID ) );
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