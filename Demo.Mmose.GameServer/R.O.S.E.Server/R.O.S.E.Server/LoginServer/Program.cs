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
using System.Reflection;
using System.Collections.Generic;
using Demo_G.O.S.E.ServerEngine.World;
using Demo_G.O.S.E.ServerEngine.Server;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_R.O.S.E.Database;
using Demo_G.O.S.E.ServerEngine.Network.DLL;
using Demo_R.O.S.E.LoginServer.Common;
using Demo_R.O.S.E.LoginServer.Network;
using Demo_R.O.S.E.LoginServer.LoginServer.ConfigInfo;
using System.Windows.Forms;
using System.Threading;
using Demo_G.O.S.E.ServerEngine.BuildScripts;
#endregion


namespace Demo_R.O.S.E.LoginServer
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
        /// <summary>
        /// 
        /// </summary>
        private static bool s_SQLRecreate = false;
        #endregion

        #region zh-CHS 内部静态属性 | en Internal Static Properties
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
            set { Program.s_BaseWorld = value; }
        }


        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static int s_LoginServerPort = 29000;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static int LoginServerPort
        {
            get { return s_LoginServerPort; }
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
        private static List<CharServerExtendData> s_CharServerList = new List<CharServerExtendData>();
        #endregion
        /// <summary>
        /// 人物服务端的数据
        /// </summary>
        internal static List<CharServerExtendData> CharServerList
        {
            get { return s_CharServerList; }
        }
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        private static void Main( string[] strArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 初始化参数

            InitServerArguments( strArgs );

            //////////////////////////////////////////////////////////////////////////
            // 初始化一些工作

            BaseServer.EventConfigServer += new ConfigServerEventHandler( BaseServer_ConfigServer );
            BaseServer.EventInitOnceServer += new InitOnceServerEventHandler( BaseServer_InitOnceServer );
            BaseServer.EventExitServer += new ExitServerEventHandler( BaseServer_ExitServer );

            BaseServer.EventCommandLineInfo += new CommandLineInfoEventHandler( BaseServer_CommandLineInfo );
            BaseServer.EventCommandLineDisposal += new CommandLineDisposalEventHandler( BaseServer_CommandLineDisposal );

            NetState.EventCreatedCallback += new CreatedNetStateEventHandler( ProcessNet.NetState_InitializeNetState );

            s_MessagePump.ThreadEventProcessReceive += new EventHandler<NetStateEventArgs>( ProcessNet.MessagePump_ProcessReceive );

            ReceiveQueue.ThreadEventPacketLength += new EventHandler<PacketLengthInfoEventArgs>( ProcessNet.ReceiveQueue_PacketLength );
            
            PacketReader.EventPacketID += new EventHandler<PacketIdInfoEventArgs>( ProcessNet.PacketReader_PacketID );

            s_MessagePump.AddListener( s_Listener );
            s_BaseWorld.AddMessagePump( s_MessagePump );

            //////////////////////////////////////////////////////////////////////////
            // 开始运行服务

            BaseServer.RunServer( strArgs, s_BaseWorld );
        }

        #region zh-CHS 静态方法 | en Static Method
        /// <summary>
        /// 
        /// </summary>
        private static void BaseServer_CommandLineInfo()
        {
            LOGs.WriteLine( LogMessageType.MSG_NOTICE, "命令帮助 : InfoWindow - 开启信息窗口" );
        }


        /// <summary>
        /// 
        /// </summary>
        private static Thread s_Thread = null;
        /// <summary>
        /// 
        /// </summary>
        private static int s_ConfigInfoThreadRun = 0;
        /// <summary>
        /// 配置信息窗口线程
        /// </summary>
        private static void ConfigInfoThread()
        {
            Interlocked.Increment( ref s_ConfigInfoThreadRun ); // 防止再次被调用的可能

            do
            {
                Application.Run( new ConfigInfoForm() );
            } while (false);

            Interlocked.Decrement( ref s_ConfigInfoThreadRun );
        }

        /// <summary>
        /// 
        /// </summary>
        private static bool BaseServer_CommandLineDisposal( string strCommandLine )
        {
            bool bReturn = false;
            switch ( strCommandLine.ToLower() )
            {
                case "infowin":
                case "-infowin":
                case "infowindow":
                case "-infowindow":
                    if ( s_ConfigInfoThreadRun <= 0 ) // 等于零则没有启动,否则已启动
                    {
                        Interlocked.Increment( ref s_ConfigInfoThreadRun ); // 防止再次被调用的可能
                        {
                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, "命令({0}) : InfoWindow - 开启信息窗口", strCommandLine );
                            {
                                s_Thread = new Thread( new ThreadStart( ConfigInfoThread ) );
                                s_Thread.SetApartmentState( ApartmentState.STA );
                                s_Thread.Start();
                            }
                        }
                        Interlocked.Decrement( ref s_ConfigInfoThreadRun );
                    }
                    else
                        LOGs.WriteLine( LogMessageType.MSG_NOTICE, "命令({0}) : InfoWindow - 已开启信息窗口状态", strCommandLine );

                    bReturn = true;
                    break;
                default:
                    break;
            }

            return bReturn;
        }

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
            // 开始注册协议

            // 服务端之间的协议
            PacketHandlers.Register( (ushort)LoginServerOpCode.CMSG_CONNECT_FROM_CHAR_SERVER, 6 + 0, false, new PacketReceiveCallback( LoginPacketHandlers.LoginServerConnectFromCharServer ) );

            // 客户端的协议
            PacketHandlers.Register( (ushort)LoginServerOpCode.CMSG_ENCRYPTION_REQUEST, 6 + 0, false, new PacketReceiveCallback( LoginPacketHandlers.LoginServerEncryptionRequest ) );
            PacketHandlers.Register( (ushort)LoginServerOpCode.CMSG_GET_SERVER_NAME_LIST, 6 + 4, false, new PacketReceiveCallback( LoginPacketHandlers.LoginServerGetServerNameList ) );
            PacketHandlers.Register( (ushort)LoginServerOpCode.CMSG_ACCOUNT_LOGIN, 6 + 34, false, new PacketReceiveCallback( LoginPacketHandlers.LoginServerAccountLogin ) );
            PacketHandlers.Register( (ushort)LoginServerOpCode.CMSG_GET_SERVER_IP, 7 + 4, false, new PacketReceiveCallback( LoginPacketHandlers.LoginServerGetServerIP ) );

            //////////////////////////////////////////////////////////////////////////
            // 开始监听端口

            if ( s_ConfigInfo.LoginHost == string.Empty )
            {
                if ( s_Listener.StartServer( LoginServerPort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听端口：{0} 失败!", LoginServerPort );
                    return;
                }
            }
            else
            {
                string l_strHostNamePort = s_ConfigInfo.LoginHost + ":" + s_ConfigInfo.LoginPort;

                if ( s_Listener.StartServer( l_strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听IP地址与端口：{0} 失败!", l_strHostNamePort );
                    return;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void BaseServer_ExitServer()
        {
            s_Listener.Dispose();
        }

        /// <summary>
        /// 重新建造SQL
        /// </summary>
        /// <param name="strArgs"></param>
        private static void InitServerArguments( string[] strArgs )
        {
            for ( int iIndex = 0; iIndex < strArgs.Length; ++iIndex )
            {
                if ( Insensitive.Equals( strArgs[iIndex], "-SQLRecreate" ) )
                    s_SQLRecreate = true;
            }
        }

        /// <summary>
        /// 读取参数
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
                throw new Exception("配置文件(R.O.S.E.config)没找到！");

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

                            int iServerCachedSize  = 0;
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
        /// 初始化SQL
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

            if ( s_SQLRecreate == false )
                BaseDatabase.BuildDefault();
            else
                // 重建数据库
                BaseDatabase.BuildRecreate();
        }
        #endregion
    }
}
#endregion
