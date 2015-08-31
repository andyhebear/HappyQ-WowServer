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
using System.Text;
using System.Collections.Generic;
using Demo_G.O.S.E.ServerEngine.Network.DLL;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_R.O.S.E.CharServer.Common;
using System.Threading;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_R.O.S.E.Common;
#endregion

namespace Demo_R.O.S.E.CharServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal class CharServerExtendData
    {
        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iAccountGuid = -1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long AccountGuid
        {
            get { return m_iAccountGuid; }
            set { m_iAccountGuid = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iLastServerGuid = -1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ServerGuid
        {
            get { return m_iLastServerGuid; }
            set { m_iLastServerGuid = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bLogout = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool Logout
        {
            get { return m_bLogout; }
            set { m_bLogout = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// Char info
        /// </summary>
        private long m_CharacterGuid;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long CharacterGuid
        {
            get { return m_CharacterGuid; }
            set { m_CharacterGuid = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_CharacterName;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string CharacterName
        {
            get { return m_CharacterName; }
            set { m_CharacterName = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ClanGuid;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClanGuid
        {
            get { return m_ClanGuid; }
            set { m_ClanGuid = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ClanRank;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClanRank
        {
            get { return m_ClanRank; }
            set { m_ClanRank = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iLevel;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long Level
        {
            get { return m_iLevel; }
            set { m_iLevel = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iClassId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClassId
        {
            get { return m_iClassId; }
            set { m_iClassId = value; }
        }

        #region zh-CHS FriendList属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private List<Friend> m_FriendList = new List<Friend>(); //friend list
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal List<Friend> FriendList
        {
            get { return m_FriendList; }
            set { m_FriendList = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private object m_LockFriendList = new object();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public object SyncFriendList
        {
            get { return m_LockFriendList; }
        }

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal void AddFriendList( Friend friendList )
        {
            Monitor.Enter( m_LockFriendList );
            {
                m_FriendList.Add( friendList );
            }
            Monitor.Exit( m_LockFriendList );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal void RemoveFriendList( Friend friendList )
        {
            Monitor.Enter( m_LockFriendList );
            {
                m_FriendList.Remove( friendList );
            }
            Monitor.Exit( m_LockFriendList );
        }

        /// <summary>
        /// 
        /// </summary>
        internal Friend[] FriendListToArray()
        {
            Friend[] friendListArray = null;

            Monitor.Enter( m_LockFriendList );
            {
                if ( m_FriendList.Count > 0 )
                    friendListArray = m_FriendList.ToArray();
            }
            Monitor.Exit( m_LockFriendList );

            return friendListArray;
        }
        #endregion

        #endregion

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    internal class LoginServerExtendData
    {
        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
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
    /// 
    /// </summary>
    internal class WorldServerExtendData
    {
        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NetState m_NetState = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal NetState NetState
        {
            get { return m_NetState; }
            set { m_NetState = value; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
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

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ACESocketClient s_SocketClient = new ACESocketClient();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal ACESocketClient SocketClient
        {
            get { return s_SocketClient; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
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

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iWorldGUID = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long WorldGUID
        {
            get { return m_iWorldGUID; }
            set { m_iWorldGUID = value; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strWorldHost = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string WorldHost
        {
            get { return m_strWorldHost; }
            set { m_strWorldHost = value; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iWorldPort = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long WorldPort
        {
            get { return m_iWorldPort; }
            set { m_iWorldPort = value; }
        }
        #endregion

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        internal void ConnectToWorldServer( string strWorldHost, long iWorldPort )
        {
            // 初始化连接服务段的数据加密种子
            Buffer.BlockCopy( ROSECrypt.Instance().CryptTableBuffer, 0, s_Seed, 0, ROSECrypt.Instance().CryptTableBuffer.Length );

            // 连接登陆服务端
            string l_strHostNamePort = strWorldHost + ":" + iWorldPort;

            if ( s_SocketClient.StartConnectServer( l_strHostNamePort ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "连接世界服务端({0}) 错误!", l_strHostNamePort );

                return;
            }

            // 获取需要发送的数据
            byte[] l_PacketBuffer = Encoding.ASCII.GetBytes( Program.ConfigInfo.WorldPassword );

            int l_SendBufferLength = l_PacketBuffer.Length + 6;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0x00;
            l_SendBuffer[3] = 0x05;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;

            Buffer.BlockCopy( l_PacketBuffer, 0, l_SendBuffer, 6, l_PacketBuffer.Length );

            // 加密数据包
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            s_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SendToWorldServer_0x502_Action01( long accountGUID )
        {
            // 获取需要发送的数据
            int l_SendBufferLength = 11/*6 + 5*/;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0x02;
            l_SendBuffer[3] = 0x05;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;

            l_SendBuffer[6] = 0x01;

            l_SendBuffer[7] = (byte)accountGUID;
            l_SendBuffer[8] = (byte)( accountGUID >> 8 );
            l_SendBuffer[9] = (byte)( accountGUID >> 16 );
            l_SendBuffer[10] = (byte)( accountGUID >> 24 );

            // 加密数据包
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            s_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SendToWorldServer_0x505( long accountGUID )
        {
            // 获取需要发送的数据
            int l_SendBufferLength = 10/*6 + 4*/;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0x05;
            l_SendBuffer[3] = 0x05;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;

            l_SendBuffer[7] = (byte)accountGUID;
            l_SendBuffer[8] = (byte)( accountGUID >> 8 );
            l_SendBuffer[9] = (byte)( accountGUID >> 16 );
            l_SendBuffer[10] = (byte)( accountGUID >> 24 );

            // 加密数据包
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            s_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SendToWorldServer_0x7E1_Action0xFB( string strCharName )
        {
            // 获取需要发送的数据
            byte[] l_PacketBuffer = Encoding.ASCII.GetBytes( strCharName );

            int l_SendBufferLength = l_PacketBuffer.Length + 7/*6 + 1*/;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0xE1;
            l_SendBuffer[3] = 0x07;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;

            l_SendBuffer[6] = 0xFB;

            Buffer.BlockCopy( l_PacketBuffer, 0, l_SendBuffer, 7, l_PacketBuffer.Length );

            // 加密数据包
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            s_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SendToWorldServer_0x7E1_Action0xFC( long iClanRank, string strCharName )
        {
            // 获取需要发送的数据
            byte[] l_PacketBuffer = Encoding.ASCII.GetBytes( strCharName );

            int l_SendBufferLength = l_PacketBuffer.Length + 7/*6 + 1*/;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0xE1;
            l_SendBuffer[3] = 0x07;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;

            l_SendBuffer[6] = (byte)0xFC;

            l_SendBuffer[7] = (byte)iClanRank;

            Buffer.BlockCopy( l_PacketBuffer, 0, l_SendBuffer, 7, l_PacketBuffer.Length );

            // 加密数据包
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            s_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SendToWorldServer_0x7E1_Action0xFA( long iCharGuid, long iClanGuid )
        {
            // 获取需要发送的数据
            int l_SendBufferLength = 10/*6 + 4*/;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0xE1;
            l_SendBuffer[3] = 0x07;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;

            l_SendBuffer[6] = 0xFA;

            l_SendBuffer[7] = (byte)iCharGuid;
            l_SendBuffer[8] = (byte)( iCharGuid >> 8 );

            l_SendBuffer[9] = (byte)iClanGuid;
            l_SendBuffer[10] = (byte)( iClanGuid >> 8 );

            // 加密数据包
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            s_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );
        }
        #endregion
    }
}
#endregion