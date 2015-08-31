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
using System.Text;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_G.O.S.E.ServerEngine.Network.DLL;
using Demo_R.O.S.E.Common;
#endregion

namespace Demo_R.O.S.E.LoginServer.Common
{
    /// <summary>
    /// Login Server �ͻ������ӹ����洢������
    /// </summary>
    internal class LoginServerExtendData
    {
        #region zh-CHS �ڲ����� | en Internal Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iAccountsGuid = -1;
        #endregion
        internal long AccountsGuid
        {
            get { return m_iAccountsGuid; }
            set { m_iAccountsGuid = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsLoggedIn = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsLoggedIn
        {
            get { return m_bIsLoggedIn; }
            set { m_bIsLoggedIn = value; }
        }
        #endregion
    }

    /// <summary>
    /// Char Server �����������ӹ����洢������
    /// </summary>
    internal class CharServerExtendData
    {
        #region zh-CHS �ڲ����� | en Internal Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] s_Seed = new byte[ROSECrypt.Instance().CryptTableBuffer.Length];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal byte[] Seed
        {
            get { return s_Seed; }
        }

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
        private bool m_bIsLoggedIn = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsLoggedIn
        {
            get { return m_bIsLoggedIn; }
            set { m_bIsLoggedIn = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strCharHost = "127.0.0.1";
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string CharHost
        {
            get { return m_strCharHost; }
            set { m_strCharHost = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iCharPort = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long CharPort
        {
            get { return m_iCharPort; }
            set { m_iCharPort = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iCharGUID = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long CharGUID
        {
            get { return m_iCharGUID; }
            set { m_iCharGUID = value; }
        }
        #endregion

        #region zh-CHS �ڲ����� | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        internal void ConnectToCharServer( string strCharHost, long iCharPort )
        {
            // ��ʼ�����ӷ���ε����ݼ�������
            Buffer.BlockCopy( ROSECrypt.Instance().CryptTableBuffer, 0, s_Seed, 0, ROSECrypt.Instance().CryptTableBuffer.Length );

            // ���ӵ�½�����
            string l_strHostNamePort = strCharHost + ":" + iCharPort;

            if ( m_SocketClient.StartConnectServer( l_strHostNamePort ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "������������({0}) ����!", l_strHostNamePort );

                return;
            }

            // ��ȡ��Ҫ���͵�����
            byte[] l_PacketBuffer = Encoding.ASCII.GetBytes( Program.ConfigInfo.CharPassword );

            int l_SendBufferLength = l_PacketBuffer.Length + 6;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            // Э��� 0x501
            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0x01;
            l_SendBuffer[3] = 0x05;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;

            Buffer.BlockCopy( l_PacketBuffer, 0, l_SendBuffer, 6, l_PacketBuffer.Length );

            // �������ݰ�
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            m_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );
        }

        /// <summary>
        /// �����ʺ��ѵ�½����Ϣ�����������
        /// </summary>
        internal void SendToCharServer( int accountsGuid )
        {
            // ��ȡ��Ҫ���͵�����
            int l_SendBufferLength = 11/*4 + 7*/;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            // Э��� 0x502
            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0x02;
            l_SendBuffer[3] = 0x05;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;

            l_SendBuffer[6] = 0x01; // Action

            l_SendBuffer[7] = (byte)accountsGuid;
            l_SendBuffer[8] = (byte)( accountsGuid >> 8 );
            l_SendBuffer[9] = (byte)( accountsGuid >> 16 );
            l_SendBuffer[10] = (byte)( accountsGuid >> 24 );

            // �������ݰ�
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            m_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );
        }
        #endregion
    }
}
#endregion