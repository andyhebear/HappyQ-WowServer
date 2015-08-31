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
using System.Xml;
using System.Text;
using System.Reflection;
using Demo_G.O.S.E.ServerEngine.World;
using Demo_G.O.S.E.ServerEngine.Server;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_R.O.S.E.Database;
using Demo_G.O.S.E.ServerEngine.Network.DLL;
using Demo_R.O.S.E.WorldServer.Common;
using Demo_R.O.S.E.WorldServer.Network;
using Demo_G.O.S.E.Data;
using System.Collections.Generic;
using Demo_R.O.S.E.STB.Editor;
using Demo_G.O.S.E.ServerEngine.Item;
using Demo_G.O.S.E.ServerEngine.Mobile;
using Demo_G.O.S.E.ServerEngine.Util;
using Demo_R.O.S.E.Map;
using Demo_R.O.S.E.RespawnZone;
using Demo_R.O.S.E.TeleportGate;
using Demo_R.O.S.E.Item;
using Demo_R.O.S.E.Mobile;
using Demo_R.O.S.E.Database.Model;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Demo_G.O.S.E.ServerEngine.Map;
using Demo_R.O.S.E.Skill;
using Demo_R.O.S.E.Quest;
using System.Threading;
using Demo_R.O.S.E.Common;
using Demo_G.O.S.E.ServerEngine.BuildScripts;
#endregion

namespace Demo_R.O.S.E.WorldServer
{
    /// <summary>
    /// zh-CHS Program 是主入口程序的类
    /// </summary>
    class Program
    {
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Listener s_Listener = new Listener();
        /// <summary>
        /// 
        /// </summary>
        private static MessagePump s_MessagePump = new MessagePump();
        #endregion

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static BaseWorld s_BaseWorld = new BaseWorld();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static BaseWorld BaseWorld
        {
            get { return Program.s_BaseWorld; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static int s_WorldServerPort = 29200;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static int WorldServerPort
        {
            get { return s_WorldServerPort; }
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

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<ROSESkill> s_SkillDataList = new List<ROSESkill>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static List<ROSESkill> SkillDataList
        {
            get { return s_SkillDataList; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<DropData> s_DropDataList = new List<DropData>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static List<DropData> DropDataList
        {
            get { return s_DropDataList; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<ROSEQuest> s_QuestDataList = new List<ROSEQuest>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static List<ROSEQuest> QuestDataList
        {
            get { return s_QuestDataList; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<NPCData> s_NPCDataList = new List<NPCData>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static List<NPCData> NPCDataList
        {
            get { return s_NPCDataList; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<MapData> s_MapDataList = new List<MapData>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static List<MapData> MapDataList
        {
            get { return s_MapDataList; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<TeleGateData> s_TeleGateDataList = new List<TeleGateData>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static List<TeleGateData> TeleGateDataList
        {
            get { return s_TeleGateDataList; }
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

        #endregion

        /// <summary>
        /// 应用程序的主入口点.
        /// </summary>
        static void Main( string[] strArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 初始化一些工作

            BaseServer.EventConfigServer        += new ConfigServerEventHandler( BaseServer_ConfigServer );
            BaseServer.EventInitOnceServer      += new InitOnceServerEventHandler( BaseServer_InitOnceServer );
            BaseServer.EventExitServer          += new ExitServerEventHandler( BaseServer_ExitServer );

            s_BaseWorld.ThreadEventLoadWorld    += new EventHandler<BaseWorldEventArgs>( BaseWorld_Load );

            NetState.EventCreatedCallback       += new CreatedNetStateEventHandler( ProcessNet.NetState_InitializeNetState );

            s_MessagePump.ThreadEventProcessReceive   += new EventHandler<NetStateEventArgs>( ProcessNet.MessagePump_ProcessReceive );

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

            //////////////////////////////////////////////////////////////////////////
            // 设置配置的信息

            configServer.Service = s_ConfigInfo.Service;
            configServer.LogFile = s_ConfigInfo.LogFile;
            configServer.Cache = s_ConfigInfo.Cache;
            configServer.Debug = s_ConfigInfo.Debug;
            configServer.HaltOnWarning = s_ConfigInfo.HaltOnWarning;
            configServer.Profiling = s_ConfigInfo.Profiling;
            configServer.WorldThreadCount = s_ConfigInfo.WorldThreadCount;

            if ( s_ConfigInfo.ServerCachedSize != 0
                 && s_ConfigInfo.ServerBufferSize != 0
                 && s_ConfigInfo.ServerManageThreadPoolSize != 0
                && s_ConfigInfo.ServerSendThreadPoolSize != 0
                && s_ConfigInfo.ServerReceiveThreadPoolSize != 0
                && s_ConfigInfo.ServerProcessThreadPoolSize != 0
                && s_ConfigInfo.ServerMaxClients != 0
                && s_ConfigInfo.ServerOutTimeInterval != 0 )
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

            if ( s_ConfigInfo.ClientCachedSize != 0
                && s_ConfigInfo.ClientBufferSize != 0
                && s_ConfigInfo.ClientManageThreadPoolSize != 0
                && s_ConfigInfo.ClientSendThreadPoolSize != 0
                && s_ConfigInfo.ClientReceiveThreadPoolSize != 0
                && s_ConfigInfo.ClientProcessThreadPoolSize != 0
                && s_ConfigInfo.ClientOutTimeInterval != 0 )
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
        public static void BaseServer_InitOnceServer()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码, 并初始化SQL

            InitSQL();

            //////////////////////////////////////////////////////////////////////////
            // 开始注册协议

            // 服务端之间的协议
            PacketHandlers.Register( 0x0500, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.CharServerConnected ) );
            PacketHandlers.Register( 0x0502, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.CharServerAction ) );
            PacketHandlers.Register( 0x0505, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.CharServerDisconnectUser ) );

            // 客户端的协议
            PacketHandlers.Register( 0x0700, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerPing ) );
            PacketHandlers.Register( 0x0707, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerExit ) );
            PacketHandlers.Register( 0x070B, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerDoIdentify ) );
            PacketHandlers.Register( 0x071C, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.CharServerDisconnectUser ) );
            PacketHandlers.Register( 0x0730, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerQuest ) );
            PacketHandlers.Register( 0x0753, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerDoID ) );
            PacketHandlers.Register( 0x0755, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerUserDied ) );
            PacketHandlers.Register( 0x0762, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerWeight ) );
            PacketHandlers.Register( 0x0771, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerStopChar ) );
            PacketHandlers.Register( 0x0781, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerDoEmote ) );
            PacketHandlers.Register( 0x0782, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerChangeStance ) );
            PacketHandlers.Register( 0x0783, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerNormalChat ) );
            PacketHandlers.Register( 0x0784, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerWhisper ) );
            PacketHandlers.Register( 0x0785, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerShout ) );
            PacketHandlers.Register( 0x0798, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerStartAttack ) );
            PacketHandlers.Register( 0x079A, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerMoveChar ) );
            PacketHandlers.Register( 0x079F, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerUnknown0x079F ) );
            PacketHandlers.Register( 0x07A1, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerNPCBuy ) );
            PacketHandlers.Register( 0x07A3, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerConsume ) );
            PacketHandlers.Register( 0x07A4, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerDoDrop ) );
            PacketHandlers.Register( 0x07A5, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerChangeEquip ) );
            PacketHandlers.Register( 0x07A7, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerPickDrop ) );
            PacketHandlers.Register( 0x07A8, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerGate ) );
            PacketHandlers.Register( 0x07A9, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerAddStats ) );
            PacketHandlers.Register( 0x07AA, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerMoveSkill ) );
            PacketHandlers.Register( 0x07AB, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerEquipArrows ) );
            PacketHandlers.Register( 0x07AD, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerOpenStorage ) );
            PacketHandlers.Register( 0x07AE, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerStorageItem ) );
            PacketHandlers.Register( 0x07AF, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerCraft ) );
            PacketHandlers.Register( 0x07B1, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerIncreaseSkillLvl ) ); // Increase a skill lvl/learn the skill
            PacketHandlers.Register( 0x07B2, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerBuff ) );
            PacketHandlers.Register( 0x07B3, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerStartSkill ) );
            PacketHandlers.Register( 0x07BC, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerDrill ) );
            PacketHandlers.Register( 0x07C0, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerTradeAction ) );
            PacketHandlers.Register( 0x07C1, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerTradeAdd ) );
            PacketHandlers.Register( 0x07C2, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerShop ) );
            PacketHandlers.Register( 0x07C3, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerCloseShop ) );
            PacketHandlers.Register( 0x07CA, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerChangeCart ) );
            PacketHandlers.Register( 0x07CB, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerRepair ) );
            PacketHandlers.Register( 0x07D0, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerParty ) );
            PacketHandlers.Register( 0x07D7, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerPartyOpt ) );
            PacketHandlers.Register( 0x07D8, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerAfterCraft ) );
            PacketHandlers.Register( 0x07DA, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerStorageZuly ) );
            PacketHandlers.Register( 0x0808, 6 + 0, true, new PacketReceiveCallback( WorldPacketHandlers.WorldServerGameGuard ) );

            //////////////////////////////////////////////////////////////////////////
            // 开始监听端口

            if ( s_ConfigInfo.WorldHost == string.Empty )
            {
                if ( s_Listener.StartServer( WorldServerPort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听端口:{0} 失败!", WorldServerPort );
                    return;
                }
            }
            else
            {
                string l_strHostNamePort = s_ConfigInfo.WorldHost + ":" + s_ConfigInfo.WorldPort;

                if ( s_Listener.StartServer( l_strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听IP地址与端口:{0} 失败!", l_strHostNamePort );
                    return;
                }
            }

            //////////////////////////////////////////////////////////////////////////
            // 连接人物服务端

            ConnectToCharServer();
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
        /// <param name="baseWorld"></param>
        private static void BaseWorld_Load( object sender, BaseWorldEventArgs eventArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 读取数据内容

            //LoadSTB();
            LoadUpgrade();
            LoadSkillData();
            LoadQuestData();
            LoadRespawnData();
            LoadTeleGateData();

            LoadMaps();
            LoadAssemblyData(); // Load ROSEItem, ROSEMobile

            LoadMonsterSpawn();
        }

        #region zh-CHS 连接人物服务端 | en ConnectToCharServer
        /// <summary>
        /// 
        /// </summary>
        private static void ConnectToCharServer()
        {
            // 初始化连接服务段的数据加密种子
            Buffer.BlockCopy( ROSECrypt.Instance().CryptTableBuffer, 0, s_Seed, 0, ROSECrypt.Instance().CryptTableBuffer.Length );

            // 连接登陆服务端
            string l_strHostNamePort = s_ConfigInfo.CharHost + ":" + s_ConfigInfo.CharPort;

            if ( s_SocketClient.StartConnectServer( l_strHostNamePort ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "连接人物服务端({0}) 错误!", l_strHostNamePort );

                throw new Exception( "连接人物服务端 错误!" );
            }

            // 获取需要发送的数据
            byte[] l_PacketBuffer = Encoding.ASCII.GetBytes( ConfigInfo.CharPassword );

            int l_SendBufferLength = l_PacketBuffer.Length + 14;
            byte[] l_SendBuffer = new byte[l_SendBufferLength];

            l_SendBuffer[0] = (byte)l_SendBufferLength;
            l_SendBuffer[1] = (byte)( l_SendBufferLength >> 8 );
            l_SendBuffer[2] = 0x00;
            l_SendBuffer[3] = 0x05;
            l_SendBuffer[4] = 0x00;
            l_SendBuffer[5] = 0x00;

            long iWorldServerGuid = 0;

            bool l_bIsReturn = false;
            bool l_bIsFind = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryChannels = new Query( l_Session, "Select Channels instances" );
                    QueryResult l_ChannelsResult = l_QueryChannels.Execute();

                    if ( l_ChannelsResult == null )
                    {
                        Debug.WriteLine( "Program.ConnectToCharServer(...) - l_ChannelsResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    foreach ( DataObject dataObject in l_ChannelsResult )
                    {
                        Channels l_Channels = dataObject as Channels;
                        if ( l_Channels == null )
                        {
                            Debug.WriteLine( "Program.ConnectToCharServer(...) - l_Channels == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        if ( l_Channels.Host == Program.ConfigInfo.WorldHost && l_Channels.Port == Program.ConfigInfo.WorldPort )
                        {
                            iWorldServerGuid = l_Channels.ServerGuid;

                            l_bIsFind = true;
                            break;
                        }
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                throw new Exception( "读取数据库字段Channels时产生错误！" );

            if ( l_bIsFind == false )
                throw new Exception( "数据库字段Channels中没有找到和当前监听匹配的地址和端口！" );

            // CharServer GUID
            l_SendBuffer[6] = (byte)iWorldServerGuid;
            l_SendBuffer[7] = (byte)( iWorldServerGuid >> 8 );
            l_SendBuffer[8] = (byte)( iWorldServerGuid >> 16 );
            l_SendBuffer[9] = (byte)( iWorldServerGuid >> 24 );

            l_SendBuffer[10] = (byte)Program.ConfigInfo.WorldPort;
            l_SendBuffer[11] = (byte)( Program.ConfigInfo.WorldPort >> 8 );
            l_SendBuffer[12] = (byte)( Program.ConfigInfo.WorldPort >> 16 );
            l_SendBuffer[13] = (byte)( Program.ConfigInfo.WorldPort >> 24 );

            Buffer.BlockCopy( l_PacketBuffer, 0, l_SendBuffer, 14, l_PacketBuffer.Length );

            // 加密数据包
            ROSECrypt.CryptPacket( ref l_SendBuffer, s_Seed );

            s_SocketClient.SendBuffer( l_SendBuffer, l_SendBuffer.Length );
        }
        #endregion

        #region zh-CHS 读取配置信息 | en LoadVariables
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
        #endregion

        #region zh-CHS 初始化SQL | en InitSQL
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

                l_FieldInfo = l_Type.GetField( "WelcomeMessage" );
                if ( l_FieldInfo != null )
                {
                    string l_strWelcomeMessage = l_FieldInfo.GetValue( string.Empty ) as string;

                    if ( l_strWelcomeMessage != null && l_strWelcomeMessage != string.Empty )
                        s_ConfigInfo.WelcomeMessage = l_strWelcomeMessage;
                }

                l_FieldInfo = l_Type.GetField( "ExperienceRate" );
                if ( l_FieldInfo != null )
                {
                    int l_iExperienceRate = (int)l_FieldInfo.GetValue( int.MaxValue );

                    if ( l_iExperienceRate != 0 && l_iExperienceRate != int.MaxValue )
                        s_ConfigInfo.ExperienceRate = l_iExperienceRate;
                }

                l_FieldInfo = l_Type.GetField( "DropRate" );
                if ( l_FieldInfo != null )
                {
                    int l_iDropRate = (int)l_FieldInfo.GetValue( int.MaxValue );

                    if ( l_iDropRate != 0 && l_iDropRate != int.MaxValue )
                        s_ConfigInfo.DropRate = l_iDropRate;
                }

                l_FieldInfo = l_Type.GetField( "DropType" );
                if ( l_FieldInfo != null )
                {
                    int l_iDropType = (int)l_FieldInfo.GetValue( int.MaxValue );

                    if ( l_iDropType != 0 && l_iDropType != int.MaxValue )
                        s_ConfigInfo.DropType = l_iDropType;
                }

                l_FieldInfo = l_Type.GetField( "ZulyRate" );
                if ( l_FieldInfo != null )
                {
                    int l_iZulyRate = (int)l_FieldInfo.GetValue( int.MaxValue );

                    if ( l_iZulyRate != 0 && l_iZulyRate != int.MaxValue )
                        s_ConfigInfo.ZulyRate = l_iZulyRate;
                }

                l_FieldInfo = l_Type.GetField( "AutoSave" );
                if ( l_FieldInfo != null )
                {
                    bool l_bAutoSave = (bool)l_FieldInfo.GetValue( false );

                    if ( l_bAutoSave != false )
                        s_ConfigInfo.AutoSave = l_bAutoSave;
                }

                l_FieldInfo = l_Type.GetField( "SaveTime" );
                if ( l_FieldInfo != null )
                {
                    int l_iSaveTime = (int)l_FieldInfo.GetValue( int.MaxValue );

                    if ( l_iSaveTime != 0 && l_iSaveTime != int.MaxValue )
                        s_ConfigInfo.SaveTime = l_iSaveTime;
                }

                l_FieldInfo = l_Type.GetField( "Delay" );
                if ( l_FieldInfo != null )
                {
                    int l_iDelay = (int)l_FieldInfo.GetValue( int.MaxValue );

                    if ( l_iDelay != 0 && l_iDelay != int.MaxValue )
                        s_ConfigInfo.Delay = l_iDelay;
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

        #region zh-CHS 读取精炼度信息 | en LoadUpgrade
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static float[] s_fUpgrade = new float[10];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private static void LoadUpgrade()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取Upgrade

            Type l_Type = ScriptCompiler.FindTypeByFullName( "Demo_R.O.S.E.Scripts.Upgrade.UpgradeConfig" );
            if ( l_Type != null )
            {
                MethodInfo l_MethodInfo = l_Type.GetMethod( "InitUpgrade" );
                if ( l_MethodInfo != null )
                {
                    object[] l_Parameters = new object[] { s_fUpgrade };
                    l_MethodInfo.Invoke( null, l_Parameters );
                }
            }
            else throw new Exception( "Demo_R.O.S.E.Scripts.Upgrade.UpgradeConfig 没找到" );
        }
        #endregion

        #region zh-CHS 读取技能信息 | en LoadSkillData
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<ROSESkill> s_RoseSkillDataList = new List<ROSESkill>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private static void LoadSkillData()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取ROSESkill

            Type l_Type = ScriptCompiler.FindTypeByFullName( "Demo_R.O.S.E.Scripts.Skill.SkillConfig" );
            if ( l_Type != null )
            {
                MethodInfo l_MethodInfo = l_Type.GetMethod( "InitSkills" );
                if ( l_MethodInfo != null )
                {
                    object[] l_Parameters = new object[] { s_RoseSkillDataList };
                    l_MethodInfo.Invoke( null, l_Parameters );
                }
            }
            else throw new Exception( "Demo_R.O.S.E.Scripts.Skill.SkillConfig 没找到" );
        }
        #endregion

        #region zh-CHS 读取任务信息 | en LoadQuestData
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<ROSEQuest> s_RoseQuestList = new List<ROSEQuest>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private static void LoadQuestData()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取ROSEQuest

            Type l_Type = ScriptCompiler.FindTypeByFullName( "Demo_R.O.S.E.Scripts.Quest.QuestConfig" );
            if ( l_Type != null )
            {
                MethodInfo l_MethodInfo = l_Type.GetMethod( "InitQuests" );
                if ( l_MethodInfo != null )
                {
                    object[] l_Parameters = new object[] { s_RoseQuestList };
                    l_MethodInfo.Invoke( null, l_Parameters );
                }
            }
            else throw new Exception( "Demo_R.O.S.E.Scripts.Quest.QuestConfig 没找到" );
        }
        #endregion

        #region zh-CHS 读取复活点 | en LoadRespawnData
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<ROSERespawnZone> s_RoseRespawnZoneList = new List<ROSERespawnZone>();
        #endregion
        /// <summary>
        /// 复活点的数据
        /// </summary>
        private static void LoadRespawnData()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取ROSERespawnZone

            Type l_Type = ScriptCompiler.FindTypeByFullName( "Demo_R.O.S.E.Scripts.RespawnZone.RespawnZoneConfig" );
            if ( l_Type != null )
            {
                MethodInfo l_MethodInfo = l_Type.GetMethod( "InitRespawnZone" );
                if ( l_MethodInfo != null )
                {
                    object[] l_Parameters = new object[] { s_RoseRespawnZoneList };
                    l_MethodInfo.Invoke( null, l_Parameters );
                }
            }
            else throw new Exception( "Demo_R.O.S.E.Scripts.RespawnZone.TeleportGateConfig 没找到" );
        }
        #endregion

        #region zh-CHS 读取传送点 | en LoadTeleGateData
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<ROSETeleportGate> s_RoseTeleportGateList = new List<ROSETeleportGate>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private static void LoadTeleGateData()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取ROSETeleportGate

            Type l_Type = ScriptCompiler.FindTypeByFullName( "Demo_R.O.S.E.Scripts.TeleportGate.TeleportGateConfig" );
            if ( l_Type != null )
            {
                MethodInfo l_MethodInfo = l_Type.GetMethod( "InitTeleportGate" );
                if ( l_MethodInfo != null )
                {
                    object[] l_Parameters = new object[] { s_RoseTeleportGateList };
                    l_MethodInfo.Invoke( null, l_Parameters );
                }
            }
            else throw new Exception( "Demo_R.O.S.E.Scripts.TeleportGate.TeleportGateConfig 没找到" );
        }
        #endregion

        #region zh-CHS 读取地图信息 | en LoadMaps
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static List<RoseMap> s_RoseMapList = new List<RoseMap>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private static void LoadMaps()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取RoseMap

            Type l_Type = ScriptCompiler.FindTypeByFullName( "Demo_R.O.S.E.Scripts.Map.MapConfig" );
            if ( l_Type != null )
            {
                MethodInfo l_MethodInfo = l_Type.GetMethod( "InitMaps" );
                if ( l_MethodInfo != null )
                {
                    object[] l_Parameters = new object[] { s_RoseMapList };
                    l_MethodInfo.Invoke( null, l_Parameters );
                }
            }

            foreach ( RoseMap roseMap in s_RoseMapList )
                s_BaseWorld.AddMap( roseMap.MapID, roseMap );
        }
        #endregion

        #region zh-CHS 读取集合内的全部的道具和怪物定义的信息 | en LoadAssemblyData
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<long, ConstructorInfo> s_ROSEItemPool = new Dictionary<long, ConstructorInfo>();
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<long, ConstructorInfo> s_ROSEMobilePool = new Dictionary<long, ConstructorInfo>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private static void LoadAssemblyData()
        {
            for ( int iIndex = 0; iIndex < ScriptCompiler.Assemblies.Length; ++iIndex )
                LoadAssemblyData( ScriptCompiler.Assemblies[iIndex] );

            LOGs.WriteLine( LogMessageType.MSG_INFO, "脚本: 校验完成 ({0} 道具, {1} 运动物体)", s_ROSEItemPool.Count, s_ROSEMobilePool.Count );
        }

        private static void LoadAssemblyData( Assembly assembly )
        {
            if ( assembly == null )
                return;

            foreach ( Type l_Type in assembly.GetTypes() )
            {
                if ( l_Type.IsSubclassOf( typeof( ROSEItem ) ) == true )
                {
                    ConstructorInfo[] l_ConstructorInfoArray = l_Type.GetConstructors();
                    for ( int iIndex = 0; iIndex < l_ConstructorInfoArray.Length; iIndex++ )
                    {
                        foreach ( ConstructorInfo l_ConstructorInfo in l_ConstructorInfoArray )
                        {
                            ParameterInfo[] l_ParameterInfoArray = l_ConstructorInfo.GetParameters();
                            if ( l_ParameterInfoArray.Length == 0 )
                            {
                                ROSEItem l_ROSEItem = l_ConstructorInfo.Invoke( null ) as ROSEItem;

                                s_ROSEItemPool.Add( l_ROSEItem.ItemGUID, l_ConstructorInfo );

                                s_BaseWorld.AddTypeItem( l_Type, l_ROSEItem );

                                break;
                            }
                        }
                    }
                }
                else if ( l_Type.IsSubclassOf( typeof( ROSEMobile ) ) == true )
                {
                    ConstructorInfo[] l_ConstructorInfoArray = l_Type.GetConstructors();
                    for ( int iIndex = 0; iIndex < l_ConstructorInfoArray.Length; iIndex++ )
                    {
                        foreach ( ConstructorInfo l_ConstructorInfo in l_ConstructorInfoArray )
                        {
                            ParameterInfo[] l_ParameterInfoArray = l_ConstructorInfo.GetParameters();
                            if ( l_ParameterInfoArray.Length == 0 )
                            {
                                ROSEMobile l_ROSEMobile = l_ConstructorInfo.Invoke( null ) as ROSEMobile;

                                s_ROSEMobilePool.Add( l_ROSEMobile.MobileGUID, l_ConstructorInfo );

                                s_BaseWorld.AddTypeMobile( l_Type, l_ROSEMobile );

                                break;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region zh-CHS 读取刷怪点 | en LoadMonsterSpawn
        /// <summary>
        /// LoadNPCSpawn
        /// </summary>
        private static void LoadMonsterSpawn()
        {
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    //////////////////////////////////////////////////////////////////////////
                    // 获取刷怪点(怪物)信息

                    Query l_QuerySpawnMonsters = new Query( l_Session, "Select SpawnMonsters instances" );
                    QueryResult l_SpawnMonstersResult = l_QuerySpawnMonsters.Execute();

                    if ( l_SpawnMonstersResult == null )
                    {
                        Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_SpawnMonstersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    for ( int iIndex = 0; iIndex < l_SpawnMonstersResult.Count; iIndex++ )
                    {
                        SpawnMonsters l_SpawnMonster = l_SpawnMonstersResult[iIndex] as SpawnMonsters;
                        if ( l_SpawnMonster == null )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_SpawnMonster == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        ConstructorInfo l_ConstructorInfo = s_ROSEMobilePool[l_SpawnMonster.MobileGUID];
                        if ( l_ConstructorInfo == null )
                        {
                            Debug.WriteLine( string.Format( "Program.LoadMonsterSpawn(...) - l_ConstructorInfo == null error(SpawnMonsters.SpawnGuid = {0})!", l_SpawnMonster.SpawnGuid ) );

                            l_bIsReturn = true;
                            break;
                        }

                        ROSEMobile l_ROSEMobile = l_ConstructorInfo.Invoke( null ) as ROSEMobile;
                        if ( l_ROSEMobile == null )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_ROSEMobile == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        Regex l_Regex = new Regex( @"(\d+)+", RegexOptions.Compiled );

                        // 分析 Points "3|5000,5000|5100,5000|5000,5100"
                        MatchCollection l_MatchCollectionPoints = l_Regex.Matches( l_SpawnMonster.Points );
                        if ( l_MatchCollectionPoints == null )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_MatchCollectionPoints == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        if ( l_MatchCollectionPoints.Count < 1 )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_MatchCollectionPoints.Count < 1 error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        Match l_MatchPointCount = l_MatchCollectionPoints[0];
                        Group l_GroupPointCount = l_MatchPointCount.Groups[1];

                        int l_iPointCount = -1;
                        Int32.TryParse( l_GroupPointCount.ToString(), out l_iPointCount );

                        if ( l_iPointCount < 0 )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_iPointCount < 0 error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        if ( l_MatchCollectionPoints.Count != ( l_iPointCount * 2 + 1 ) )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_MatchCollectionPoints.Count != ( l_iPointCount * 2 + 1 ) error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        List<fPoint> l_PointList = new List<fPoint>();
                        for ( int iIndex2 = 1; iIndex2 < l_MatchCollectionPoints.Count; ++iIndex2 )
                        {
                            Match l_MatchX = l_MatchCollectionPoints[iIndex2];
                            Group l_GroupX = l_MatchX.Groups[1];

                            int l_iResultX = 0;
                            Int32.TryParse( l_GroupX.ToString(), out l_iResultX );

                            Match l_MatchY = l_MatchCollectionPoints[++iIndex2];
                            Group l_GroupY = l_MatchY.Groups[1];

                            int l_iResultY = 0;
                            Int32.TryParse( l_GroupY.ToString(), out l_iResultY );

                            fPoint l_Point = new fPoint();
                            l_Point.x = l_iResultX;
                            l_Point.y = l_iResultY;

                            l_PointList.Add( l_Point );
                        }

                        fPoint l_RandPoint = RandInPoly( l_PointList.ToArray() );

                        l_ROSEMobile.X = (int)l_RandPoint.x;
                        l_ROSEMobile.Y = (int)l_RandPoint.y;

                        BaseMap l_BaseMap = s_BaseWorld.GetMap( l_SpawnMonster.MapID );
                        if ( l_BaseMap == null )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_BaseMap == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        //l_BaseMap.OnEnter( l_ROSEMobile );
                    }

                    if ( l_bIsReturn == true )
                        break;

                    //////////////////////////////////////////////////////////////////////////
                    // 获取刷怪点(NPC)信息

                    Query l_QuerySpawnNPCs = new Query( l_Session, "Select SpawnNPCs instances" );
                    QueryResult l_SpawnNPCsResult = l_QuerySpawnNPCs.Execute();

                    if ( l_SpawnNPCsResult == null )
                    {
                        Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_SpawnNPCsResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    for ( int iIndex = 0; iIndex < l_SpawnNPCsResult.Count; iIndex++ )
                    {
                        SpawnNPCs l_SpawnNPCs = l_SpawnNPCsResult[iIndex] as SpawnNPCs;
                        if ( l_SpawnNPCs == null )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_SpawnNPCs == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        ConstructorInfo l_ConstructorInfo = s_ROSEMobilePool[l_SpawnNPCs.NPCGuid];
                        if ( l_ConstructorInfo == null )
                        {
                            Debug.WriteLine( string.Format( "Program.LoadMonsterSpawn(...) - l_ConstructorInfo == null error(SpawnNPCs.SpawnGuid = {0})!", l_SpawnNPCs.SpawnGuid ) );

                            l_bIsReturn = true;
                            break;
                        }

                        ROSEMobile l_ROSEMobile = l_ConstructorInfo.Invoke( null ) as ROSEMobile;
                        if ( l_ROSEMobile == null )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_ROSEMobile == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        l_ROSEMobile.X = (int)l_SpawnNPCs.PositionX;
                        l_ROSEMobile.Y = (int)l_SpawnNPCs.PositionY;
                        //l_ROSEMobile.Direction = l_SpawnNPCs.Direction;

                        BaseMap l_BaseMap = s_BaseWorld.GetMap( l_SpawnNPCs.MapID );
                        if ( l_BaseMap == null )
                        {
                            Debug.WriteLine( "Program.LoadMonsterSpawn(...) - l_BaseMap == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        //l_BaseMap.OnEnter( l_ROSEMobile );
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                throw new Exception( "读取刷怪点数据 错误！" );

            LOGs.WriteLine( LogMessageType.MSG_INFO, "信息: 刷怪点数据读取完成！" );
        }
        #endregion

        #region zh-CHS 三角形计算 | en Triangle 
        /// <summary>
        /// 给出在多边形内的一个随机点
        /// </summary>
        /// <param name="point">多边形的各个点</param>
        /// <param name="pointCount">多边形点数</param>
        /// <returns>多边形内的一个随机点</returns>
        private static fPoint RandInPoly( fPoint[] point )
        {
            // 多边形内三角形数(以第一个点为公共点)
            int l_iTriangleCount = point.Length - 2;

            // 多边形内三角形的逐步累计的面积
            float[] l_Areas = new float[l_iTriangleCount];

            // 多边形的总共面积
            float l_fTotalArea = 0.0f;
            for ( int iIndex = 0; iIndex < l_iTriangleCount; iIndex++ )
            {
                l_fTotalArea += AreaOfTriangle( point[0], point[iIndex + 1], point[iIndex + 2] );
                l_Areas[iIndex] = l_fTotalArea;
            }

            float l_fRandArea = 0.0f;
            do
            {
                l_fRandArea = (float)Utility.RandomDouble() * l_fTotalArea;
            } while ( l_fRandArea == 0.0f );

            int l_iIndex = 0;
            for ( l_iIndex = 0; l_iIndex < l_iTriangleCount; l_iIndex++ )
            {
                if ( l_fRandArea <= l_Areas[l_iIndex] )
                    break;
            }

            return RandInTriangle( point[0], point[l_iIndex + 1], point[l_iIndex + 2] );
        }

        //先介绍一下三维中的两点之间距离之式,和二维的几乎一样:d = sqrt((x0-x1)^2 + (y0-y1)^2 + (z0-z1)^2)
        //
        //再介绍叉乘,中心内容！叉乘在定义上有:两个向量进行叉乘得到的是一个向量,方向垂直于这两个向量构成的平面,大小等于这两个向量组成的平行四边形的面积.
        //
        //在直角座标系[O;i,j,k]中,i、j、k分别为X轴、Y轴、Z轴上向量的单位向量.设P0(0,0,0),P1(x1,y1,z1),P2(x2,y2,z2).因为是从原点出发,所以向量P0P1可简记为P1,向量P0P2可简记为P2.依定义有:
        //
        //            |i  j  k |
        //P1×P2   =  |x1 y1 z1| 
        //            |x2 y2 z2|
        //
        //展开,得到:
        //上式     = iy1z2 + jz1x2 + kx1y2 - ky1x2 - jx1z2 - iz1y2 
        //         = (y1z2 - y2z1)i + (x2z1 - x1z2)j + (x1y2 - x2y1)k
        //
        //按规定,有:单位向量的模为1.可得叉积的模为:
        //|P1×P2| = y1z2 - y2z1 + x2z1 - x1z2 + x1y2 - x2y1
        //         = (y1z2 + x2z1 + x1y2) - (y2z1 + x1z2 + x2y1)
        //
        //开始正式内容.我们设三角形的三个顶点为A(x0,y0,z0),B(x1,y1,z1),C(x2,y2,z2).我们将三角形的两条边AB和AC看成是向量.然后,我们以A为原点,进行坐标平移,得到向量B(x1-x0,y1-y0,z1-z0),向量C(x2-x0,y2-y0,z2-z0).
        //
        //①在三维的情况下,直接代入公式,可得向量B和向量C叉乘结果的模为:
        //|B×C|   = ((y1-y0)*(z2-z0) + (z1-z0)*(x2-x0) + (x1-x0)*(y2-y0)) - ((y2-y0)*(z1-z0) + (z2-z0)*(x1-x0) + (x2-x0)*(y1-y0))
        //           |  1     1     1  |
        //         = |x1-x0 y1-y0 z1-z0|
        //           |x2-x0 y2-y0 z2-z0|
        //它的一半即为所要求的三角形面积S.
        //
        //还有一种比较简单的写法.将向量AB和AC平移至原点后,设向量B为(x1,y1,z1),向量C为(x2,y2,z2),则他们的叉乘所得向量P为(x,y,z),其中:
        //    |y1 z1|     |z1 x1|     |x1 y1|
        //x = |     | y = |     | z = |     |
        //    |y2 z2|     |z2 x2|     |x2 y2|
        //然后用三维中的两点之间距离公式,求出(x,y,z)与(0,0,0)的距离,即为向量P的模,它的一半就是所要求的面积了.
        //以上公式都很好记:x分量由y,z分量组成,y分量由z,x分量组成,z分量由x,y分量组成,恰好是循环的.坐标平移一下就好了.
        //
        //②在二维的情况下,我们可以取z = 0这个平面,即令z1 = z2 = 0,且
        //|P1×P2| = x1y2 - x2y1
        //           |x1 y1|  
        //         = |     |
        //           |x2 y2|
        //所以:
        //|B×C| = (x1-x0)*(y2-y0)-(x2-x0)*(y1-y0)
        //         |x1-x0 y1-y0|
        //       = |           |
        //         |x2-x0 y2-y0|
        //它的一半即为所要求的三角形的面积S.
        //
        //注意,用行列式求出来的面积是带符号的.如果A,B,C是按顺时针方向给出,则S为负；按逆时针方向给出,则S为正.
        //以二维的情况为例,三维亦同: 
        //
        //A(0,0) B(0,1) C(1,0) (A,B,C按顺时针方向给出)
        //S = ((x1-x0)*(y2-y0)-(x2-x0)*(y1-y0))/2;
        //  = ((0 - 0)*(0 - 0)-(1 - 0)*(1 - 0))/2
        //  = -0.5
        //
        //A(1,0) B(0,1) C(0,0) (A,B,C按逆时针方向给出)
        //S = ((x1-x0)*(y2-y0)-(x2-x0)*(y1-y0))/2;
        //  = ((0 - 1)*(0 - 0)-(0 - 1)*(1 - 0))/2
        //  = 0.5
        //
        //如果你不需要符号的话,再求一下绝对值就好了.这样也不用去管给出的点的顺序了.
        //以上是利用叉乘.其实还有一招,那就是海伦公式:
        //利用两点之间距离公式,求出三角形的三边长a,b,c后,令p = (a+b+c)/2.再套入以下公式就可以求出三角形的面积S :
        //S = sqrt(p*(p-a)*(p-b)*(p-c))
        //看起来好像比上面的都要简单…… -.-b 各位看客不要打我！
        //推荐:在二维的时候使用叉乘公式,三维的时候使用海伦公式～～～不过如果是需要符号的情况时,就只能使用行列式的计算公式了.
        /// <summary>
        /// 给出三角形的面积
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <returns></returns>
        private static float AreaOfTriangle( fPoint point0, fPoint point1, fPoint point2 )
        {
            return Math.Abs( ( ( point1.x - point0.x ) * ( point2.y - point0.y ) - ( point2.x - point0.x ) * ( point1.y - point0.y ) ) / 2 ) ;
        }

        /// <summary>
        /// 给出在三角形内的一个随机点
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <returns></returns>
        private static fPoint RandInTriangle( fPoint point0, fPoint point1, fPoint point2 )
        {
            float floatA = 0.0f;
            do
            {
                floatA = (float)Utility.RandomDouble();
            } while ( floatA == 0.0f );

            float floatB = 0.0f;
            do
            {
                floatB = (float)Utility.RandomDouble();
            } while ( floatB == 0.0f || floatB + floatA >= 1.0 );

            float floatC = 1 - floatA - floatB;

            fPoint l_ReturnPoint = new fPoint();
            l_ReturnPoint.x = ( point0.x * floatA ) + ( point1.x * floatB ) + ( point2.x * floatC );
            l_ReturnPoint.y = ( point0.y * floatA ) + ( point1.y * floatB ) + ( point2.y * floatC );

            return l_ReturnPoint;
        }

        //功能: 用户输入4个坐标(平面坐标系x轴正方向向左,y正方向向上),判断前3个坐标是否可以作为三角形的3个顶点；   
        //           如果能,同时判断第四个坐标是否在这个三角形内   （不包括在边上和顶点上） 
        //
        //说明: 程序中涉及到两个函数PoOnSameLine和PoRelative.   
        //      其中函数PoOnSameLine是用来判断三点是否共线,函数PoRelative返回点与直线的关系,   
        //           两个函数都要用到向量叉积公式:   
        //           向量A和向量B的叉积是一个向量,记作A×B,方向可以用右用定则得出,其模|A×B| = |A||B|sin& (&是A与B的夹角)   
        //                                       | i , j , k  |     
        //           向量叉积的坐标表示为:A*B =  | a1, a2, a3 | (其中i,j,k分别为单位向量; A = [a1,a2,a3], B = [b1,b2,b3])   
        //                                       | b1, b2, b3 |   
        //
        //           判断三点是否共线的算法如下:   
        //           设三角形的三个顶点为A(x1,y1),B(x2,y2),和C(x3,y3),   
        //           以A为共同点分别连接B和C,得出向量AB和AC,坐标表示为 AB = (x2-x1,y2-y1), AC = (x3-x1,y3-y1)   
        //                     | x2 - x1, y2 - y1 |     
        //           AB*AC   = | x3 - x1, y3 - y1 |
        //                   = (x2 - x1)(y3 - y1) - (y2 - y1)(x3 - x1)   
        //           由|A||B|sin&=0得,如果AB×AC＝0则点A,B,C在同一条直线上(共顶点A且夹角为零)   
        //
        //           判断第四个点与直线的关系算法:   
        //           设三角形按逆时针方向的三个顶点分别为A,B,C,第四个点为P,我们按逆时针方向连接ABC,得到三个向量分别为AB,BC,CA,
        //           再分别以A,B,C为顶点,连接P,得到向量AP,BP,CP,分别计算AB×AP,BC×BP,CA×CP的值,结果为三个新向量N1,N2和N3,
        //           根据N*的方向可得出点P与向量AB,BC,CA的位置关系,我们以左侧或右侧来描述   

        //           根据位置关系,对于点P,如果他同时位于向量的AB,BC和CA的同一侧（左侧或右侧）即向量N同号(不为零）,则点在三角形内,
        //           否则在三角形外(如果叉乘为零则点位于向量上),该判定还可上升到凸多边形的情况.  
 
        /// <summary>
        /// 返回向量叉乘，公共点为point0   
        /// </summary>
        /// <param name="point0"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        private static float VectorMultiply( fPoint point0, fPoint point1, fPoint point2 )
        {
            return ( ( point1.x - point0.x ) * ( point2.y - point0.y ) - ( point2.x - point0.x ) * ( point1.y - point0.y ) );
        }

        /// <summary>
        /// 判断三点是否共线函数
        /// </summary>
        /// <param name="point0"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        private static bool PointOnSameLine( fPoint point0, fPoint point1, fPoint point2 )
        {
            return ( VectorMultiply( point0, point1, point2 ) == 0 );
        }

        /// <summary>
        /// 判断点point是否是三角形内 point0,point1,point2为三角形的三个顶点
        /// </summary>
        /// <param name="point0"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private static bool PointInTriangle( fPoint point0, fPoint point1, fPoint point2, fPoint point )
        {
            float iReturn0 = VectorMultiply( point0, point, point1 );
            float iReturn1 = VectorMultiply( point1, point, point2 );
            float iReturn2 = VectorMultiply( point2, point, point0 );

            if ( iReturn0 * iReturn1 * iReturn2 == 0 )
                return false;

            if ( ( iReturn0 > 0 && iReturn1 > 0 && iReturn2 > 0 ) || ( iReturn0 < 0 && iReturn1 < 0 && iReturn2 < 0 ) )
                return true;

            return false;
        }   
        #endregion

        private static STBData[] STB_ITEM = new STBData[14];    // Items List
        private static STBData STB_PRODUCT = new STBData();     // Products List    
        private static STBData STB_SELL = new STBData();        // Sell Items List

        public enum STBItem
        {
            Face = 0x00,
            Cap = 0x01,
            Body = 0x02,
            Arms = 0x03,
            Foot = 0x04,
            Back = 0x05,
            Jewel = 0x06,
            Weapon = 0x07,
            Subwpn = 0x08,
            UseItem = 0x09,
            JemItem = 0x10,
            Natural = 0x11,
            QuestItem = 0x12,
            Pat = 0x13
        }

        private static void LoadSTB()
        {
            for (int iIndex = 0; iIndex < STB_ITEM.Length; iIndex++)
            	STB_ITEM[iIndex] = new STBData();

            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |=               |" );
            STBData.LoadSTBDataKorea( ref STB_SELL, "STB\\LIST_SELL.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |==              |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[0], "STB\\LIST_FACE.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |===             |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[1], "STB\\LIST_CAP.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |====            |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[2], "STB\\LIST_BODY.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |=====           |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[3], "STB\\LIST_ARMS.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |======          |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[4], "STB\\LIST_FOOT.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |=======         |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[5], "STB\\LIST_BACK.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |========        |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[6], "STB\\LIST_JEWEL.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |=========       |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[7], "STB\\LIST_WEAPON.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |=========       |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[8], "STB\\LIST_SUBWPN.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |==========      |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[9],"STB\\LIST_USEITEM.STB"  );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |===========     |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[10], "STB\\LIST_JEMITEM.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |============    |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[11], "STB\\LIST_NATURAL.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |=============   |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[12], "STB\\LIST_QUESTITEM.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |==============  |" );
            STBData.LoadSTBDataKorea( ref STB_ITEM[13], "STB\\LIST_PAT.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |=============== |" );
            STBData.LoadSTBDataKorea( ref STB_PRODUCT, "STB\\LIST_PRODUCT.STB" );
            LOGs.WriteLine( LogMessageType.MSG_LOAD, "读取 STBs: |================|\n" );
        }
        #endregion
    }
}
#endregion
