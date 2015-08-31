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
        #region zh-CHS �ڲ����� | en Internal Constants
        /// <summary>
        /// ZoneServer �����ݻ���Ĵ�С
        /// </summary>
        internal const int BUFFER_SIZE = 4096;
        #endregion

        #region zh-CHS �ڲ���̬���� | en Internal Static Properties
        #region zh-CHS ˽�о�̬��Ա���� | en Private Static Member Variables
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

        #region zh-CHS �ڲ���̬���� | en Internal Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNetState"></param>
        internal static void Zone_InitializeNetState( object sender, NetStateInitEventArgs netStateInit )
        {
            if ( netStateInit.NetStateInit != null && netStateInit.NetStateInit.ExtendData == null )
            {
                // ��ʼ���ͻ���
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

            long l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length; // ����ʱ��ͻ������ݹ��������Կ��Բ��������ģ�������Ҳû��,���ѱ�֤���߳��д��������е�����
            while ( l_iReceiveBufferLength > 0 )
            {
                // ��ȡ������
                byte[] l_PacketBuffer = s_ProcessorBuffers.AcquireBuffer();

                // ReceiveQueue�ڲ��Ѿ�������
                long l_iReturnPacketSize = l_ReceiveQueueBuffer.Dequeue( ref l_PacketBuffer, 0, l_iReceiveBufferLength );

                // ��ȡ�����ݲ���ͬ
                if ( l_iReturnPacketSize != l_iReceiveBufferLength )
                {
                    Debug.WriteLine( "ProcessNet.MessagePump_ProcessReceive(...) - iReturnPacketSize != iPacketSize error!" );

                    // �����ڴ��
                    s_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                    eventArgs.NetState.Dispose( false ); // �Ͽ�
                    return;
                }

                // ��������
                l_ExtendData.SendToZoneClusterServer( l_PacketBuffer, l_iReturnPacketSize );

                // �����ڴ��
                s_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer );

                // ��ȡʣ�µ����ݳ���
                l_iReceiveBufferLength = l_ReceiveQueueBuffer.Length;
            }
        }
        #endregion
    }
}
#endregion