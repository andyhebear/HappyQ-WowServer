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
        #region zh-CHS �������� | en Public Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
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

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
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

        #region zh-CHS �ڲ���̬���� | en Internal Static Properties
        #region zh-CHS ˽�о�̬��Ա���� | en Private Static Member Variables
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

        #region zh-CHS �ڲ����� | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        internal bool ConnectToZoneClusterServer( string strCharHost, long iCharPort )
        {
            if ( m_SocketClient.IsConnected )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "�Ѿ�������ZoneCluster����� ����!" );

                return false;
            }

            m_SocketClient.ThreadEventProcessMessageBlock += new EventHandler<ProcessMessageBlockAtClientEventArgs>( ReceiveFromZoneClusterServer );
            
            // ���ӵ�½�����
            string l_strHostNamePort = strCharHost + ":" + iCharPort;

            if ( m_SocketClient.StartConnectServer( l_strHostNamePort ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "����ZoneCluster�����({0}) ����!", l_strHostNamePort );

                return false;
            }

            return true;
        }

        /// <summary>
        /// �������ݵ�ZoneCluster������
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

            // ��ȡ������
            byte[] l_PacketBuffer = s_ProcessorBuffers.AcquireBuffer();
            {
                Marshal.Copy( eventArgs.MessageBlock.ReadPointer(), l_PacketBuffer, 0, eventArgs.MessageBlock.Length );

                m_NetState.Send( new BufferPacket( l_PacketBuffer, 0, eventArgs.MessageBlock.Length ) );
            }
            s_ProcessorBuffers.ReleaseBuffer( l_PacketBuffer ); // �����ڴ��
        }
        #endregion
    }
}
#endregion