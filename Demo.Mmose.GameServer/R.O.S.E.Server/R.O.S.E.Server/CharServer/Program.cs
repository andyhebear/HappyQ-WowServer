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
using System.Text;
using System.Xml;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using Demo_G.O.S.E.Data;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_R.O.S.E.Database;
using Demo_R.O.S.E.Database.Model;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_G.O.S.E.ServerEngine.Network.DLL;
using Demo_G.O.S.E.ServerEngine.Server;
using Demo_G.O.S.E.ServerEngine.World;
using Demo_R.O.S.E.CharServer.Common;
using Demo_R.O.S.E.CharServer.Network;
using System.Threading;
using Demo_R.O.S.E.Common;
using Demo_G.O.S.E.ServerEngine.BuildScripts;
#endregion

namespace Demo_R.O.S.E.CharServer
{
    /// <summary>
    /// zh-CHS Program 是主入口程序的类
    /// </summary>
    internal class Program
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Listener s_Listener = new Listener();
        /// <summary>
        /// 
        /// </summary>
        private static MessagePump s_MessagePump = new MessagePump();
        #endregion

        #region zh-CHS 内部静态属性 | en Internal Static Properties
        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static BaseWorld s_BaseWorld = new BaseWorld();
        /// <summary>
        /// 
        /// </summary>
        #endregion
        public static BaseWorld BaseWorld
        {
            get { return Program.s_BaseWorld; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static int m_CharServerPort = 29100;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static int CharServerPort
        {
            get { return m_CharServerPort; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static ConfigInfo s_ConfigInfo = new ConfigInfo();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static ConfigInfo ConfigInfo
        {
            get { return s_ConfigInfo; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static byte[] s_Seed = new byte[ROSECrypt.Instance().CryptTableBuffer.Length];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static byte[] LoginServerSeed
        {
            get { return s_Seed; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static ACESocketClient s_SocketClient = new ACESocketClient();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static ACESocketClient LoginServerSocket
        {
            get { return s_SocketClient; }
        }

        #region zh-CHS CharServerList属性 | en Public Properties

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<CharServerExtendData> s_CharServerList = new List<CharServerExtendData>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static List<CharServerExtendData> CharServerList
        {
            get { return s_CharServerList; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static object s_LockCharServerList = new object();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static object SyncCharServerList
        {
            get { return s_LockCharServerList; }
        }

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal static void AddCharServerList( CharServerExtendData extendData )
        {
            Monitor.Enter( s_LockCharServerList );
            {
                s_CharServerList.Add( extendData );
            }
            Monitor.Exit( s_LockCharServerList );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal static void RemoveCharServerList( CharServerExtendData extendData )
        {
            Monitor.Enter( s_LockCharServerList );
            {
                s_CharServerList.Remove( extendData );
            }
            Monitor.Exit( s_LockCharServerList );
        }

        /// <summary>
        /// 
        /// </summary>
        internal static CharServerExtendData[] CharServerListToArray()
        {
            CharServerExtendData[] extendDataArray = null;

            Monitor.Enter( s_LockCharServerList );
            {
                if ( s_CharServerList.Count > 0 )
                    extendDataArray = s_CharServerList.ToArray();
            }
            Monitor.Exit( s_LockCharServerList );

            return extendDataArray;
        }
        #endregion

        #endregion

        #region zh-CHS WorldServerList属性 | en Public Properties

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<WorldServerExtendData> s_WorldServerList = new List<WorldServerExtendData>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static List<WorldServerExtendData> WorldServerList
        {
            get { return s_WorldServerList; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static object s_LockWorldServerList = new object();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static object SyncWorldServerList
        {
            get { return s_LockWorldServerList; }
        }

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal static void AddWorldServerList( WorldServerExtendData extendData )
        {
            Monitor.Enter( s_LockWorldServerList );
            {
                s_WorldServerList.Add( extendData );
            }
            Monitor.Exit( s_LockWorldServerList );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal static void RemoveWorldServerList( WorldServerExtendData extendData )
        {
            Monitor.Enter( s_LockWorldServerList );
            {
                s_WorldServerList.Remove( extendData );
            }
            Monitor.Exit( s_LockWorldServerList );
        }

        /// <summary>
        /// 
        /// </summary>
        internal static WorldServerExtendData[] WorldServerListToArray()
        {
            WorldServerExtendData[] extendDataArray = null;

            Monitor.Enter( s_LockWorldServerList );
            {
                if ( s_WorldServerList.Count > 0 )
                    extendDataArray = s_WorldServerList.ToArray();
            }
            Monitor.Exit( s_LockWorldServerList );

            return extendDataArray;
        }
        #endregion

        #endregion

        #region zh-CHS ClanList属性 | en Public Properties

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<Clan> s_ClanList = new List<Clan>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static List<Clan> ClanList
        {
            get { return s_ClanList; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static object s_LockClanList = new object();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static object SyncClanList
        {
            get { return s_LockClanList; }
        }

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal static void AddClanList( Clan clan )
        {
            Monitor.Enter( s_LockClanList );
            {
                s_ClanList.Add( clan );
            }
            Monitor.Exit( s_LockClanList );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal static void RemoveClanList( Clan clan )
        {
            Monitor.Enter( s_LockClanList );
            {
                s_ClanList.Remove( clan );
            }
            Monitor.Exit( s_LockClanList );
        }

        /// <summary>
        /// 
        /// </summary>
        internal static Clan[] ClanListToArray()
        {
            Clan[] clanArray = null;

            Monitor.Enter( s_LockClanList );
            {
                if ( s_ClanList.Count > 0 )
                    clanArray = s_ClanList.ToArray();
            }
            Monitor.Exit( s_LockClanList );

            return clanArray;
        }
        #endregion

        #endregion

        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        private static void Main(string[] strArgs)
        {
            //////////////////////////////////////////////////////////////////////////
            // 初始化一些工作

            BaseServer.EventConfigServer        += new ConfigServerEventHandler( BaseServer_ConfigServer );
            BaseServer.EventInitOnceServer      += new InitOnceServerEventHandler( BaseServer_InitOnceServer );
            BaseServer.EventExitServer          += new ExitServerEventHandler( BaseServer_ExitServer );

            NetState.EventCreatedCallback       += new CreatedNetStateEventHandler( ProcessNet.NetState_InitializeNetState );

            s_MessagePump.ThreadEventProcessReceive += new EventHandler<NetStateEventArgs>( ProcessNet.MessagePump_ProcessReceive );
           
            ReceiveQueue.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( ProcessNet.ReceiveQueue_PacketLength );

            PacketReader.EventPacketID += new EventHandler<PacketIdInfoEventArgs>( ProcessNet.PacketReader_PacketID );

            s_MessagePump.AddListener( s_Listener );
            s_BaseWorld.AddMessagePump( s_MessagePump );

            //////////////////////////////////////////////////////////////////////////
            // 开始运行服务

            BaseServer.RunServer( strArgs, s_BaseWorld );
        }

        #region zh-CHS 私有静态方法 | en Private Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configServer"></param>
        private static void BaseServer_ConfigServer( ref ConfigServer configServer )
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            LoadVariables();

            configServer.Service = s_ConfigInfo.Service;
            configServer.LogFile = s_ConfigInfo.LogFile;
            configServer.Cache = s_ConfigInfo.Cache;
            configServer.Debug = s_ConfigInfo.Debug;
            configServer.HaltOnWarning = s_ConfigInfo.HaltOnWarning;
            configServer.Profiling = s_ConfigInfo.Profiling;
            configServer.WorldThreadCount = (byte)s_ConfigInfo.WorldThreadCount;

            if ( s_ConfigInfo.ServerCachedSize > 0
                 && s_ConfigInfo.ServerBufferSize > 0
                 && s_ConfigInfo.ServerManageThreadPoolSize > 0
                && s_ConfigInfo.ServerSendThreadPoolSize > 0
                && s_ConfigInfo.ServerReceiveThreadPoolSize > 0
                && s_ConfigInfo.ServerProcessThreadPoolSize > 0
                && s_ConfigInfo.ServerMaxClients > 0
                && s_ConfigInfo.ServerOutTimeInterval >= 0 )
            {
                configServer.SetServerNetConfig( (int)s_ConfigInfo.ServerCachedSize
                    , (int)s_ConfigInfo.ServerBufferSize
                    , (int)s_ConfigInfo.ServerManageThreadPoolSize
                    , (int)s_ConfigInfo.ServerSendThreadPoolSize
                    , (int)s_ConfigInfo.ServerReceiveThreadPoolSize
                    , (int)s_ConfigInfo.ServerProcessThreadPoolSize
                    , (int)s_ConfigInfo.ServerMaxClients
                    , (int)s_ConfigInfo.ServerOutTimeInterval );
            }


            if ( s_ConfigInfo.ClientCachedSize > 0
                && s_ConfigInfo.ClientBufferSize > 0
                && s_ConfigInfo.ClientManageThreadPoolSize > 0
                && s_ConfigInfo.ClientSendThreadPoolSize > 0
                && s_ConfigInfo.ClientReceiveThreadPoolSize > 0
                && s_ConfigInfo.ClientProcessThreadPoolSize > 0
                && s_ConfigInfo.ClientOutTimeInterval >= 0 )
            {
                configServer.SetClientNetConfig( (int)s_ConfigInfo.ClientCachedSize
                    , (int)s_ConfigInfo.ClientBufferSize
                    , (int)s_ConfigInfo.ClientManageThreadPoolSize
                    , (int)s_ConfigInfo.ClientSendThreadPoolSize
                    , (int)s_ConfigInfo.ClientReceiveThreadPoolSize
                    , (int)s_ConfigInfo.ClientProcessThreadPoolSize
                    , (int)s_ConfigInfo.ClientOutTimeInterval );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void BaseServer_InitOnceServer()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码, 并初始化SQL

            //InitSQL();

            //////////////////////////////////////////////////////////////////////////
            // 读取部落列表

            //LoadClanList();

            //////////////////////////////////////////////////////////////////////////
            // 开始注册协议

            // 服务端之间的协议
            PacketHandlers.Register( 0x0500, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.CharServerConnectToWorld ) );
            PacketHandlers.Register( 0x0501, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.LoginServerConnected ) );
            PacketHandlers.Register( 0x0502, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.LoginServerAction ) );
            PacketHandlers.Register( 0x0505, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.WorldServerAction ) );

            // 客户端的协议
            PacketHandlers.Register( 0x070B, 6 + 36, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerDoIdentify ) );
            PacketHandlers.Register( 0x0712, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerGetCharacters ) );
            PacketHandlers.Register( 0x0713, 6 + 7, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerCreateCharacter ) );
            PacketHandlers.Register( 0x0714, 6 + 2, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerDeleteCharacter ) );
            PacketHandlers.Register( 0x0715, 6 + 3, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerRequestWorld ) );
            PacketHandlers.Register( 0x0787, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerClanChat ) );
            PacketHandlers.Register( 0x07E0, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerClanManager ) );
            PacketHandlers.Register( 0x07E1, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerMessengerManager ) );
            PacketHandlers.Register( 0x07E2, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerMessengerChat ) );
            PacketHandlers.Register( 0x07E3, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerChatRooms ) );
            PacketHandlers.Register( 0x07E5, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerUnknown0x07E5 ) );
            PacketHandlers.Register( 0x079E, 6 + 0, false, new PacketReceiveCallback( CharPacketHandlers.CharacterServerUpdateLevel ) );

            //////////////////////////////////////////////////////////////////////////
            // 开始监听端口

            if ( s_ConfigInfo.CharHost == string.Empty )
            {
                if ( s_Listener.StartServer( CharServerPort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听端口：{0} 失败!", CharServerPort );
                    return;
                }
            }
            else
            {
                string l_strHostNamePort = s_ConfigInfo.CharHost + ":" + s_ConfigInfo.CharPort;

                if ( s_Listener.StartServer( l_strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听IP地址与端口：{0} 失败!", l_strHostNamePort );
                    return;
                }
            }

            //////////////////////////////////////////////////////////////////////////
            // 连接登陆服务端

            ConnectToLoginServer();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void BaseServer_ExitServer()
        {
            s_Listener.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void ConnectToLoginServer()
        {
            // 初始化连接服务段的数据加密种子
            Buffer.BlockCopy( ROSECrypt.Instance().CryptTableBuffer, 0, s_Seed, 0, ROSECrypt.Instance().CryptTableBuffer.Length );

            // 连接登陆服务端
            string l_strHostNamePort = s_ConfigInfo.LoginHost + ":" + s_ConfigInfo.LoginPort;

            if ( s_SocketClient.StartConnectServer( l_strHostNamePort ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "连接登陆服务端({0}) 错误!", l_strHostNamePort );

                throw new Exception( "连接登陆服务端 错误!" );
            }

            // 获取需要发送的数据
            byte[] l_PacketBuffer = Encoding.ASCII.GetBytes( ConfigInfo.LoginPassword );

            int l_SendBufferLength = l_PacketBuffer.Length + 14;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0x00;
            l_SendBuffer[3] = 0x05;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;


            long iCharServerGuid = 0;

            //bool l_bIsReturn = false;
            //bool l_bIsFind = false;
            //Session l_Session = new Session( BaseDatabase.Domain );
            //l_Session.BeginTransaction();
            //{
            //    do
            //    {
            //        Query l_QueryChannels = new Query( l_Session, "Select Channels instances" );
            //        QueryResult l_ChannelsResult = l_QueryChannels.Execute();

            //        if ( l_ChannelsResult == null )
            //        {
            //            Debug.WriteLine( "Program.ConnectToLoginServer(...) - l_ChannelsResult == null error!" );

            //            l_bIsReturn = true;
            //            break;
            //        }

            //        foreach ( DataObject dataObject in l_ChannelsResult )
            //        {
            //            Channels l_Channels = dataObject as Channels;
            //            if ( l_Channels == null )
            //            {
            //                Debug.WriteLine( "Program.ConnectToLoginServer(...) - l_Channels == null error!" );

            //                l_bIsReturn = true;
            //                break;
            //            }

            //            if ( l_Channels.Host == Program.ConfigInfo.CharHost && l_Channels.Port == Program.ConfigInfo.CharPort )
            //            {
            //                iCharServerGuid = l_Channels.ServerGuid;

            //                l_bIsFind = true;
            //                break;
            //            }
            //        }
            //    } while ( false );
            //}
            //l_Session.Commit();

            //if ( l_bIsReturn == true )
            //    throw new Exception( "读取数据库字段Channels时产生错误！" );

            //if ( l_bIsFind == false )
            //    throw new Exception( "数据库字段Channels中没有找到和当前监听匹配的地址和端口！" );

            // CharServer GUID
            l_SendBuffer[6] = (byte)iCharServerGuid;
            l_SendBuffer[7] = (byte)( iCharServerGuid >> 8 );
            l_SendBuffer[8] = (byte)( iCharServerGuid >> 16 );
            l_SendBuffer[9] = (byte)( iCharServerGuid >> 24 );

            l_SendBuffer[10] = (byte)Program.ConfigInfo.CharPort;
            l_SendBuffer[11] = (byte)( Program.ConfigInfo.CharPort >> 8 );
            l_SendBuffer[12] = (byte)( Program.ConfigInfo.CharPort >> 16 );
            l_SendBuffer[13] = (byte)( Program.ConfigInfo.CharPort >> 24 );

            Buffer.BlockCopy( l_PacketBuffer, 0, l_SendBuffer, 14, l_PacketBuffer.Length );

            // 加密数据包
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            s_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );

            LOGs.WriteLine( LogMessageType.MSG_INFO, "信息: 连接登陆服务端完成！" );
        }

        /// <summary>
        /// 读取部落列表
        /// </summary>
        private static void LoadClanList()
        {
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryListClan = new Query( l_Session, "Select ListClan instances" );
                    QueryResult l_ListClanResult = l_QueryListClan.Execute();

                    if ( l_ListClanResult == null )
                    {
                        Debug.WriteLine( "Program.LoadClanList(...) - l_ListClanResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    for ( int iIndex = 0; iIndex < l_ListClanResult.Count; iIndex++ )
                    {
                        ListClan l_ListClan = l_ListClanResult[iIndex] as ListClan;
                        if ( l_ListClan == null )
                        {
                            Debug.WriteLine( "Program.LoadClanList(...) - l_ListClan == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        Clan l_Clan = new Clan();
                        l_Clan.ClanGuid = l_ListClan.ClanGuid;
                        l_Clan.ClanName = l_ListClan.ClanName;
                        l_Clan.Logo = l_ListClan.Logo;
                        l_Clan.Back = l_ListClan.Back;
                        l_Clan.Grade = l_ListClan.Grade;
                        l_Clan.CP = l_ListClan.CP;
                        l_Clan.Slogan = l_ListClan.Slogan;
                        l_Clan.News = l_ListClan.News;

                        //////////////////////////////////////////////////////////////////////////
                        // 获取部落的成员信息

                        Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {ClanGuid}=@ClanGuid" );
                        l_QueryCharacters.Parameters.Add( "@ClanGuid", l_ListClan.ClanGuid );
                        QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                        if ( l_CharactersResult == null )
                        {
                            Debug.WriteLine( "Program.LoadClanList(...) - l_CharactersResult == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        for ( int iIndex2 = 0; iIndex2 < l_CharactersResult.Count; iIndex2++ )
                        {
                            Characters l_Characters = l_CharactersResult[iIndex2] as Characters;
                            if ( l_Characters == null )
                            {
                                Debug.WriteLine( "Program.LoadClanList(...) - l_Characters == null error!" );

                                l_bIsReturn = true;
                                break;
                            }

                            ClanMember l_ClanMember = new ClanMember();

                            l_ClanMember.CharacterName = l_Characters.CharacterName;
                            l_ClanMember.ClanGuid = l_Characters.ClanGuid;
                            l_ClanMember.ClanRank = l_Characters.ClanRank;

                            l_Clan.AddClanMemberList( l_ClanMember );
                        }

                        if ( l_bIsReturn == true)
                            break;

                        Program.AddClanList( l_Clan );
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                throw new Exception( "读取部落列表 错误！" );

            LOGs.WriteLine( LogMessageType.MSG_INFO, "信息: 部落列表读取完成！" );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void LoadVariables()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            XmlReaderSettings l_xmlSettings = new XmlReaderSettings();
            l_xmlSettings.ConformanceLevel = ConformanceLevel.Fragment;
            l_xmlSettings.IgnoreWhitespace = true;
            l_xmlSettings.IgnoreComments = true;

            if ( File.Exists( "R.O.S.E.config" ) == false )
                return;

            XmlReader l_xmlReader = XmlReader.Create( "R.O.S.E.config", l_xmlSettings );

            while ( l_xmlReader.Read() == true )
            {
                switch ( l_xmlReader.NodeType )
                {
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Element:

                        if ( Insensitive.Equals( l_xmlReader.Name, "R.O.S.E" ) == true )
                        {
                            if ( l_xmlReader.HasAttributes == true )
                            {
                                while ( l_xmlReader.MoveToNextAttribute() == true )
                                {
                                    if ( Insensitive.Equals( l_xmlReader.Name, "Author" ) == true )
                                    {
                                        string l_strAuthor = l_xmlReader.Value;

                                        if ( Insensitive.Equals( l_strAuthor, "H.Q.Cai" ) == false )
                                            throw new Exception( "R.O.S.E.config File - XML - Author != H.Q.Cai" );
                                    }
                                    else if ( Insensitive.Equals( l_xmlReader.Name, "Version" ) == true )
                                    {
                                        string l_strVersion = l_xmlReader.Value;

                                        if ( Insensitive.Equals( l_strVersion, "0.1" ) == false )
                                            throw new Exception( "R.O.S.E.config File - XML - Version != 0.1" );
                                    }
                                }

                                l_xmlReader.MoveToElement();
                            }
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "CharHost" ) == true )
                        {
                            string l_strCharHost = l_xmlReader.ReadString();

                            s_ConfigInfo.CharHost = l_strCharHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "CharPort" ) == true )
                        {
                            string l_strCharPort = l_xmlReader.ReadString();

                            int iCharPort = 0;
                            int.TryParse( l_strCharPort, out iCharPort );

                            s_ConfigInfo.CharPort = iCharPort;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "LoginHost" ) == true )
                        {
                            string l_strLoginHost = l_xmlReader.ReadString();

                            s_ConfigInfo.LoginHost = l_strLoginHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "LoginPort" ) == true )
                        {
                            string l_strLoginPort = l_xmlReader.ReadString();

                            int iLoginPort = 0;
                            int.TryParse( l_strLoginPort, out iLoginPort );

                            s_ConfigInfo.LoginPort = iLoginPort;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "WorldHost" ) == true )
                        {
                            string l_strWorldHost = l_xmlReader.ReadString();

                            s_ConfigInfo.WorldHost = l_strWorldHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "WorldPort" ) == true )
                        {
                            string l_strWorldPort = l_xmlReader.ReadString();

                            int iWorldPort = 0;
                            int.TryParse( l_strWorldPort, out iWorldPort );

                            s_ConfigInfo.WorldPort = iWorldPort;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SQLUser" ) == true )
                        {
                            string l_strSQLUser = l_xmlReader.ReadString();

                            s_ConfigInfo.SQLUser = l_strSQLUser;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SQLHost" ) == true )
                        {
                            string l_strSQLHost = l_xmlReader.ReadString();

                            s_ConfigInfo.SQLHost = l_strSQLHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SQLPort" ) == true )
                        {
                            string l_strSQLPort = l_xmlReader.ReadString();

                            int iSQLPort = 0;
                            int.TryParse( l_strSQLPort, out iSQLPort );

                            s_ConfigInfo.SQLPort = iSQLPort;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SQLDatabase" ) == true )
                        {
                            string l_strSQLDatabase = l_xmlReader.ReadString();

                            s_ConfigInfo.SQLDatabase = l_strSQLDatabase;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SQLConnection" ) == true )
                        {
                            string l_strSQLConnection = l_xmlReader.ReadString();

                            s_ConfigInfo.SQLConnection = l_strSQLConnection;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SERVER_CACHED_SIZE" ) == true )
                        {
                            string l_strServerCachedSize = l_xmlReader.ReadString();

                            int iServerCachedSize = 0;
                            int.TryParse( l_strServerCachedSize, out iServerCachedSize );

                            s_ConfigInfo.ServerCachedSize = iServerCachedSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SERVER_BUFFER_SIZE" ) == true )
                        {
                            string l_strServerBufferSize = l_xmlReader.ReadString();

                            int iServerBufferSize = 0;
                            int.TryParse( l_strServerBufferSize, out iServerBufferSize );

                            s_ConfigInfo.ServerBufferSize = iServerBufferSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SERVER_MANAGE_THREAD_POOL_SIZE" ) == true )
                        {
                            string l_strServerManageThreadPoolSize = l_xmlReader.ReadString();

                            int iServerManageThreadPoolSize = 0;
                            int.TryParse( l_strServerManageThreadPoolSize, out iServerManageThreadPoolSize );

                            s_ConfigInfo.ServerManageThreadPoolSize = iServerManageThreadPoolSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SERVER_SEND_THREAD_POOL_SIZE" ) == true )
                        {
                            string l_strServerSendThreadPoolSize = l_xmlReader.ReadString();

                            int iServerSendThreadPoolSize = 0;
                            int.TryParse( l_strServerSendThreadPoolSize, out iServerSendThreadPoolSize );

                            s_ConfigInfo.ServerSendThreadPoolSize = iServerSendThreadPoolSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SERVER_RECEIVE_THREAD_POOL_SIZE" ) == true )
                        {
                            string l_strServerReceiveThreadPoolSize = l_xmlReader.ReadString();

                            int iServerReceiveThreadPoolSize = 0;
                            int.TryParse( l_strServerReceiveThreadPoolSize, out iServerReceiveThreadPoolSize );

                            s_ConfigInfo.ServerReceiveThreadPoolSize = iServerReceiveThreadPoolSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SERVER_PROCESS_THREAD_POOL_SIZE" ) == true )
                        {
                            string l_strServerProcessThreadPoolSize = l_xmlReader.ReadString();

                            int iServerProcessThreadPoolSize = 0;
                            int.TryParse( l_strServerProcessThreadPoolSize, out iServerProcessThreadPoolSize );

                            s_ConfigInfo.ServerProcessThreadPoolSize = iServerProcessThreadPoolSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SERVER_MAX_CLIENTS" ) == true )
                        {
                            string l_strServerMaxClients = l_xmlReader.ReadString();

                            int iServerMaxClients = 0;
                            int.TryParse( l_strServerMaxClients, out iServerMaxClients );

                            s_ConfigInfo.ServerMaxClients = iServerMaxClients;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "SERVER_OUT_TIME_INTERVAL" ) == true )
                        {
                            string l_strServerOutTimeInterval = l_xmlReader.ReadString();

                            int iServerOutTimeInterval = 0;
                            int.TryParse( l_strServerOutTimeInterval, out iServerOutTimeInterval );

                            s_ConfigInfo.ServerOutTimeInterval = iServerOutTimeInterval;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "CLIENT_CACHED_SIZE" ) == true )
                        {
                            string l_strClientCachedSize = l_xmlReader.ReadString();

                            int iClientCachedSize = 0;
                            int.TryParse( l_strClientCachedSize, out iClientCachedSize );

                            s_ConfigInfo.ClientCachedSize = iClientCachedSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "CLIENT_BUFFER_SIZE" ) == true )
                        {
                            string l_strClientBufferSize = l_xmlReader.ReadString();

                            int iClientBufferSize = 0;
                            int.TryParse( l_strClientBufferSize, out iClientBufferSize );

                            s_ConfigInfo.ClientBufferSize = iClientBufferSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "CLIENT_MANAGE_THREAD_POOL_SIZE" ) == true )
                        {
                            string l_strClientManageThreadPoolSize = l_xmlReader.ReadString();

                            int iClientManageThreadPoolSize = 0;
                            int.TryParse( l_strClientManageThreadPoolSize, out iClientManageThreadPoolSize );

                            s_ConfigInfo.ClientManageThreadPoolSize = iClientManageThreadPoolSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "CLIENT_SEND_THREAD_POOL_SIZE" ) == true )
                        {
                            string l_strClientSendThreadPoolSize = l_xmlReader.ReadString();

                            int iClientSendThreadPoolSize = 0;
                            int.TryParse( l_strClientSendThreadPoolSize, out iClientSendThreadPoolSize );

                            s_ConfigInfo.ClientSendThreadPoolSize = iClientSendThreadPoolSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "CLIENT_RECEIVE_THREAD_POOL_SIZE" ) == true )
                        {
                            string l_strClientReceiveThreadPoolSize = l_xmlReader.ReadString();

                            int iClientReceiveThreadPoolSize = 0;
                            int.TryParse( l_strClientReceiveThreadPoolSize, out iClientReceiveThreadPoolSize );

                            s_ConfigInfo.ClientReceiveThreadPoolSize = iClientReceiveThreadPoolSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "CLIENT_PROCESS_THREAD_POOL_SIZE" ) == true )
                        {
                            string l_strClientProcessThreadPoolSize = l_xmlReader.ReadString();

                            int iClientProcessThreadPoolSize = 0;
                            int.TryParse( l_strClientProcessThreadPoolSize, out iClientProcessThreadPoolSize );

                            s_ConfigInfo.ClientProcessThreadPoolSize = iClientProcessThreadPoolSize;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "CLIENT_OUT_TIME_INTERVAL" ) == true )
                        {
                            string l_strClientOutTimeInterval = l_xmlReader.ReadString();

                            int iClientOutTimeInterval = 0;
                            int.TryParse( l_strClientOutTimeInterval, out iClientOutTimeInterval );

                            s_ConfigInfo.ClientOutTimeInterval = iClientOutTimeInterval;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "Service" ) == true )
                        {
                            string l_strService = l_xmlReader.ReadString();

                            bool bService = false;
                            bool.TryParse( l_strService, out bService );

                            s_ConfigInfo.Service = bService;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "LogFile" ) == true )
                        {
                            string l_strLogFile = l_xmlReader.ReadString();

                            s_ConfigInfo.LogFile = l_strLogFile;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "Cache" ) == true )
                        {
                            string l_strCache = l_xmlReader.ReadString();

                            bool bCache = false;
                            bool.TryParse( l_strCache, out bCache );

                            s_ConfigInfo.Cache = bCache;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "Debug" ) == true )
                        {
                            string l_strDebug = l_xmlReader.ReadString();

                            bool bDebug = false;
                            bool.TryParse( l_strDebug, out bDebug );

                            s_ConfigInfo.Debug = bDebug;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "HaltOnWarning" ) == true )
                        {
                            string l_strHaltOnWarning = l_xmlReader.ReadString();

                            bool bHaltOnWarning = false;
                            bool.TryParse( l_strHaltOnWarning, out bHaltOnWarning );

                            s_ConfigInfo.HaltOnWarning = bHaltOnWarning;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "Profiling" ) == true )
                        {
                            string l_strProfiling = l_xmlReader.ReadString();

                            bool bProfiling = false;
                            bool.TryParse( l_strProfiling, out bProfiling );

                            s_ConfigInfo.Profiling = bProfiling;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "WorldThreadCount" ) == true )
                        {
                            string l_strWorldThreadCount = l_xmlReader.ReadString();

                            byte iWorldThreadCount = 0;
                            byte.TryParse( l_strWorldThreadCount, out iWorldThreadCount );

                            s_ConfigInfo.WorldThreadCount = iWorldThreadCount;
                        }

                        break;
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                }
            }

            l_xmlReader.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void InitSQL()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码

            Type l_Type = ScriptCompiler.FindTypeByFullName( "Demo_R.O.S.E.Scripts.Globals.GlobalConfig" );
            if ( l_Type != null )
            {
                FieldInfo l_FieldInfo = l_Type.GetField( "SQLPassword" );
                if ( l_FieldInfo != null )
                {
                    string l_strSQLPassword = l_FieldInfo.GetValue( string.Empty ) as string;

                    if ( l_strSQLPassword != null && l_strSQLPassword != string.Empty )
                        s_ConfigInfo.SQLPassword = l_strSQLPassword;
                }

                l_FieldInfo = l_Type.GetField( "LoginServerPassword" );
                if ( l_FieldInfo != null )
                {
                    string l_strLoginPassword = l_FieldInfo.GetValue( string.Empty ) as string;

                    if ( l_strLoginPassword != null && l_strLoginPassword != string.Empty )
                        s_ConfigInfo.LoginPassword = l_strLoginPassword;
                }

                l_FieldInfo = l_Type.GetField( "CharServerPassword" );
                if ( l_FieldInfo != null )
                {
                    string l_strCharPassword = l_FieldInfo.GetValue( string.Empty ) as string;

                    if ( l_strCharPassword != null && l_strCharPassword != string.Empty )
                        s_ConfigInfo.CharPassword = l_strCharPassword;
                }

                l_FieldInfo = l_Type.GetField( "WorldServerPassword" );
                if ( l_FieldInfo != null )
                {
                    string l_strWorldPassword = l_FieldInfo.GetValue( string.Empty ) as string;

                    if ( l_strWorldPassword != null && l_strWorldPassword != string.Empty )
                        s_ConfigInfo.WorldPassword = l_strWorldPassword;
                }
            }

            //////////////////////////////////////////////////////////////////////////
            // 设置SQL的连接信息

            if ( s_ConfigInfo.SQLConnection == string.Empty ||
                s_ConfigInfo.SQLUser == string.Empty ||
                s_ConfigInfo.SQLHost == string.Empty ||
                s_ConfigInfo.SQLDatabase == string.Empty )
            {
                s_ConfigInfo.SQLConnectionUrl = BaseDatabase.ConnectionURL;
            }
            else
            {
                BaseDatabase.ConnectionURL = s_ConfigInfo.SQLConnectionUrl = s_ConfigInfo.SQLConnection
                    + "://"
                    + s_ConfigInfo.SQLUser
                    + ":"
                    + s_ConfigInfo.SQLPassword
                    + "@"
                    + s_ConfigInfo.SQLHost
                    //+ ( s_ConfigInfo.m_strSQLPort == 0 ? string.Empty : ":" + s_ConfigInfo.m_strSQLPort ) // 数据库引擎暂时不支持
                    + "/"
                    + s_ConfigInfo.SQLDatabase;
            }

            //////////////////////////////////////////////////////////////////////////
            // 开始连接数据库

            BaseDatabase.BuildDefault();
        }
        #endregion
    }
}
#endregion
