#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
//
// This file is a part of the G.O.S.E(Game Online Server Engine) for .NET.
//
//           2007-2008 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions outlined
// in the accompanying license agreement.
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Scripts;
using Demo.Mmose.Core.Server;
using Demo.Mmose.Core.World.ZoneClusterWorld;
using Demo.Wow.Database;
using Demo.Wow.WorldServer.Common;
using Demo.Wow.WorldServer.Network;
using Demo.Wow.WorldServer.Network.Common;
using Demo.Wow.WorldServer.World;
#endregion

namespace Demo.Wow.WorldServer.Server
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProcessServer
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private const int WORLD_SERVER_PORT = 8093;
        #endregion

        #region zh-CHS 内部静态属性 | en Internal Static Properties

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static WowZoneCluster s_WowWorld = new WowZoneCluster();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static WowZoneCluster WowZoneCluster
        {
            get { return s_WowWorld; }
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static ConfigZoneCluster s_ConfigZoneCluster = new ConfigZoneCluster();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static ConfigZoneCluster ConfigZoneCluster
        {
            get { return s_ConfigZoneCluster; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static RealmPacketHandlers s_RealmListPacketHandlers = new RealmPacketHandlers();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static RealmPacketHandlers RealmPacketHandlers
        {
            get { return s_RealmListPacketHandlers; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static WorldPacketHandlers s_LoginPacketHandlers = new WorldPacketHandlers();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static WorldPacketHandlers WorldPacketHandlers
        {
            get { return s_LoginPacketHandlers; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static NetState s_RealmNetState = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static NetState RealmNetState
        {
            get { return s_RealmNetState; }
            set { s_RealmNetState = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static ScriptAssemblyInfo s_ScriptAssemblyInfo = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static ScriptAssemblyInfo ScriptAssemblyInfo
        {
            get { return s_ScriptAssemblyInfo; }
        }

        #endregion

        #region zh-CHS ConfigServer方法 | en

        #region zh-CHS 读取Server配置的信息 方法 | en LoadServerConfig Method
        /// <summary>
        /// 读取参数
        /// </summary>
        private static void LoadServerConfig()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            if ( File.Exists( "..\\Config\\Mmose.Server.config" ) == false )
                throw new Exception( "配置文件(Mmose.Server.config)没找到！" );

            XDocument documentConfig = XDocument.Load( "..\\Config\\Mmose.Server.config" );
            if ( documentConfig == null )
                return;

            XElement elementRoot = documentConfig.Element( (XName)"Mmose.Server" );
            if ( elementRoot == null )
                return;

            //////////////////////////////////////////////////////////////////////////
            // <Settings>
            XElement elementSettings = elementRoot.Element( (XName)"Settings" );
            if ( elementSettings == null )
                return;

            //////////////////////////////////////////////////////////////////////////
            // <ServerSetting>
            XElement elementServerSetting = elementSettings.Element( (XName)"ServerSetting" );
            if ( elementServerSetting != null )
            {
                XElement elementService = elementServerSetting.Element( (XName)"Service" );
                if ( elementService != null )
                {
                    string strService = elementService.Value;

                    bool bService = false;
                    bool.TryParse( strService, out bService );

                    s_ConfigInfo.ServerConfig.Service = bService;
                }

                XElement elementLogFile = elementServerSetting.Element( (XName)"LogFile" );
                if ( elementLogFile != null )
                {
                    string strLogFile = elementLogFile.Value;

                    s_ConfigInfo.ServerConfig.LogFile = strLogFile;
                }

                XElement elementCache = elementServerSetting.Element( (XName)"Cache" );
                if ( elementCache != null )
                {
                    string strCache = elementCache.Value;

                    bool bCache = false;
                    bool.TryParse( strCache, out bCache );

                    s_ConfigInfo.ServerConfig.Cache = bCache;
                }

                XElement elementDebug = elementServerSetting.Element( (XName)"Debug" );
                if ( elementDebug != null )
                {
                    string strDebug = elementDebug.Value;

                    bool bDebug = false;
                    bool.TryParse( strDebug, out bDebug );

                    s_ConfigInfo.ServerConfig.Debug = bDebug;
                }

                XElement elementHaltOnWarning = elementServerSetting.Element( (XName)"HaltOnWarning" );
                if ( elementHaltOnWarning != null )
                {
                    string strHaltOnWarning = elementHaltOnWarning.Value;

                    bool bHaltOnWarning = false;
                    bool.TryParse( strHaltOnWarning, out bHaltOnWarning );

                    s_ConfigInfo.ServerConfig.HaltOnWarning = bHaltOnWarning;
                }

                XElement elementProfiling = elementServerSetting.Element( (XName)"Profiling" );
                if ( elementProfiling != null )
                {
                    string strProfiling = elementProfiling.Value;

                    bool bProfiling = false;
                    bool.TryParse( strProfiling, out bProfiling );

                    s_ConfigInfo.ServerConfig.Profiling = bProfiling;
                }

                XElement elementWorldThreadCount = elementServerSetting.Element( (XName)"WorldThreadCount" );
                if ( elementWorldThreadCount != null )
                {
                    string strWorldThreadCount = elementWorldThreadCount.Value;

                    byte iWorldThreadCount = 0;
                    byte.TryParse( strWorldThreadCount, out iWorldThreadCount );

                    s_ConfigInfo.ServerConfig.WorldThreadCount = iWorldThreadCount;
                }
            }

            //////////////////////////////////////////////////////////////////////////
            // <NetSetting>
            XElement elementNetSetting = elementSettings.Element( (XName)"NetSetting" );
            if ( elementNetSetting != null )
            {
                //////////////////////////////////////////////////////////////////////////
                // <NetSetting> Server
                XElement elementServerCachedSize = elementServerSetting.Element( (XName)"ServerCachedSize" );
                if ( elementServerCachedSize != null )
                {
                    string strServerCachedSize = elementServerCachedSize.Value;

                    int iServerCachedSize = 0;
                    int.TryParse( strServerCachedSize, out iServerCachedSize );

                    s_ConfigInfo.ServerConfig.ServerCachedSize = iServerCachedSize;
                }

                XElement elementServerBufferSize = elementServerSetting.Element( (XName)"ServerBufferSize" );
                if ( elementServerBufferSize != null )
                {
                    string strServerBufferSize = elementServerBufferSize.Value;

                    int iServerBufferSize = 0;
                    int.TryParse( strServerBufferSize, out iServerBufferSize );

                    s_ConfigInfo.ServerConfig.ServerBufferSize = iServerBufferSize;
                }

                XElement elementServerManageThreadPoolSize = elementServerSetting.Element( (XName)"ServerManageThreadPoolSize" );
                if ( elementServerManageThreadPoolSize != null )
                {
                    string strServerManageThreadPoolSize = elementServerManageThreadPoolSize.Value;

                    int iServerManageThreadPoolSize = 0;
                    int.TryParse( strServerManageThreadPoolSize, out iServerManageThreadPoolSize );

                    s_ConfigInfo.ServerConfig.ServerManageThreadPoolSize = iServerManageThreadPoolSize;
                }

                XElement elementWorldThreadCount = elementServerSetting.Element( (XName)"ServerSendThreadPoolSize" );
                if ( elementWorldThreadCount != null )
                {
                    string strServerSendThreadPoolSize = elementWorldThreadCount.Value;

                    int iServerSendThreadPoolSize = 0;
                    int.TryParse( strServerSendThreadPoolSize, out iServerSendThreadPoolSize );

                    s_ConfigInfo.ServerConfig.ServerSendThreadPoolSize = iServerSendThreadPoolSize;
                }

                XElement elementServerReceiveThreadPoolSize = elementServerSetting.Element( (XName)"ServerReceiveThreadPoolSize" );
                if ( elementServerReceiveThreadPoolSize != null )
                {
                    string strServerReceiveThreadPoolSize = elementServerReceiveThreadPoolSize.Value;

                    int iServerReceiveThreadPoolSize = 0;
                    int.TryParse( strServerReceiveThreadPoolSize, out iServerReceiveThreadPoolSize );

                    s_ConfigInfo.ServerConfig.ServerReceiveThreadPoolSize = iServerReceiveThreadPoolSize;
                }

                XElement elementServerProcessThreadPoolSize = elementServerSetting.Element( (XName)"ServerProcessThreadPoolSize" );
                if ( elementServerProcessThreadPoolSize != null )
                {
                    string strServerProcessThreadPoolSize = elementServerProcessThreadPoolSize.Value;

                    int iServerProcessThreadPoolSize = 0;
                    int.TryParse( strServerProcessThreadPoolSize, out iServerProcessThreadPoolSize );

                    s_ConfigInfo.ServerConfig.ServerProcessThreadPoolSize = iServerProcessThreadPoolSize;
                }

                XElement elementServerMaxClients = elementServerSetting.Element( (XName)"ServerMaxClients" );
                if ( elementServerMaxClients != null )
                {
                    string strServerMaxClients = elementServerMaxClients.Value;

                    int iServerMaxClients = 0;
                    int.TryParse( strServerMaxClients, out iServerMaxClients );

                    s_ConfigInfo.ServerConfig.ServerMaxClients = iServerMaxClients;
                }

                XElement elementServerOutTimeInterval = elementServerSetting.Element( (XName)"ServerOutTimeInterval" );
                if ( elementServerOutTimeInterval != null )
                {
                    string strServerOutTimeInterval = elementServerOutTimeInterval.Value;

                    int iServerOutTimeInterval = 0;
                    int.TryParse( strServerOutTimeInterval, out iServerOutTimeInterval );

                    s_ConfigInfo.ServerConfig.ServerOutTimeInterval = iServerOutTimeInterval;
                }

                //////////////////////////////////////////////////////////////////////////
                // <NetSetting> Client
                XElement elementClientCachedSize = elementServerSetting.Element( (XName)"ClientCachedSize" );
                if ( elementClientCachedSize != null )
                {
                    string strClientCachedSize = elementClientCachedSize.Value;

                    int iClientCachedSize = 0;
                    int.TryParse( strClientCachedSize, out iClientCachedSize );

                    s_ConfigInfo.ServerConfig.ClientCachedSize = iClientCachedSize;
                }

                XElement elementClientBufferSize = elementServerSetting.Element( (XName)"ClientBufferSize" );
                if ( elementClientBufferSize != null )
                {
                    string strClientBufferSize = elementClientBufferSize.Value;

                    int iClientBufferSize = 0;
                    int.TryParse( strClientBufferSize, out iClientBufferSize );

                    s_ConfigInfo.ServerConfig.ClientBufferSize = iClientBufferSize;
                }

                XElement elementClientManageThreadPoolSize = elementServerSetting.Element( (XName)"ClientManageThreadPoolSize" );
                if ( elementClientManageThreadPoolSize != null )
                {
                    string strClientManageThreadPoolSize = elementClientManageThreadPoolSize.Value;

                    int iClientManageThreadPoolSize = 0;
                    int.TryParse( strClientManageThreadPoolSize, out iClientManageThreadPoolSize );

                    s_ConfigInfo.ServerConfig.ClientManageThreadPoolSize = iClientManageThreadPoolSize;
                }

                XElement elementClientSendThreadPoolSize = elementServerSetting.Element( (XName)"ClientSendThreadPoolSize" );
                if ( elementClientSendThreadPoolSize != null )
                {
                    string strClientSendThreadPoolSize = elementClientSendThreadPoolSize.Value;

                    int iClientSendThreadPoolSize = 0;
                    int.TryParse( strClientSendThreadPoolSize, out iClientSendThreadPoolSize );

                    s_ConfigInfo.ServerConfig.ClientSendThreadPoolSize = iClientSendThreadPoolSize;
                }

                XElement elementClientReceiveThreadPoolSize = elementServerSetting.Element( (XName)"ClientReceiveThreadPoolSize" );
                if ( elementClientReceiveThreadPoolSize != null )
                {
                    string strClientReceiveThreadPoolSize = elementClientReceiveThreadPoolSize.Value;

                    int iClientReceiveThreadPoolSize = 0;
                    int.TryParse( strClientReceiveThreadPoolSize, out iClientReceiveThreadPoolSize );

                    s_ConfigInfo.ServerConfig.ClientReceiveThreadPoolSize = iClientReceiveThreadPoolSize;
                }

                XElement elementClientProcessThreadPoolSize = elementServerSetting.Element( (XName)"ClientProcessThreadPoolSize" );
                if ( elementClientProcessThreadPoolSize != null )
                {
                    string strClientProcessThreadPoolSize = elementClientProcessThreadPoolSize.Value;

                    int iClientProcessThreadPoolSize = 0;
                    int.TryParse( strClientProcessThreadPoolSize, out iClientProcessThreadPoolSize );

                    s_ConfigInfo.ServerConfig.ClientProcessThreadPoolSize = iClientProcessThreadPoolSize;
                }

                XElement elementClientOutTimeInterval = elementServerSetting.Element( (XName)"ClientOutTimeInterval" );
                if ( elementClientOutTimeInterval != null )
                {
                    string strClientOutTimeInterval = elementClientOutTimeInterval.Value;

                    int iClientOutTimeInterval = 0;
                    int.TryParse( strClientOutTimeInterval, out iClientOutTimeInterval );

                    s_ConfigInfo.ServerConfig.ClientOutTimeInterval = iClientOutTimeInterval;
                }
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configServer"></param>
        internal static void ConfigServer( ref ConfigServer configServer )
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            LoadServerConfig();

            //////////////////////////////////////////////////////////////////////////
            // 设置配置的信息

            configServer.Service = ProcessServer.ConfigInfo.ServerConfig.Service;
            configServer.LogFile = ProcessServer.ConfigInfo.ServerConfig.LogFile;
            configServer.Cache = ProcessServer.ConfigInfo.ServerConfig.Cache;
            configServer.Debug = ProcessServer.ConfigInfo.ServerConfig.Debug;
            configServer.HaltOnWarning = ProcessServer.ConfigInfo.ServerConfig.HaltOnWarning;
            configServer.Profiling = ProcessServer.ConfigInfo.ServerConfig.Profiling;
            configServer.WorldThreadCount = ProcessServer.ConfigInfo.ServerConfig.WorldThreadCount;

            if ( ProcessServer.ConfigInfo.ServerConfig.ServerCachedSize > 0
                 && ProcessServer.ConfigInfo.ServerConfig.ServerBufferSize > 0
                 && ProcessServer.ConfigInfo.ServerConfig.ServerManageThreadPoolSize > 0
                && ProcessServer.ConfigInfo.ServerConfig.ServerSendThreadPoolSize > 0
                && ProcessServer.ConfigInfo.ServerConfig.ServerReceiveThreadPoolSize > 0
                && ProcessServer.ConfigInfo.ServerConfig.ServerProcessThreadPoolSize > 0
                && ProcessServer.ConfigInfo.ServerConfig.ServerMaxClients > 0
                && ProcessServer.ConfigInfo.ServerConfig.ServerOutTimeInterval >= 0 )
            {
                configServer.SetServerNetConfig( (int)ProcessServer.ConfigInfo.ServerConfig.ServerCachedSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ServerBufferSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ServerManageThreadPoolSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ServerSendThreadPoolSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ServerReceiveThreadPoolSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ServerProcessThreadPoolSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ServerMaxClients
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ServerOutTimeInterval );
            }


            if ( ProcessServer.ConfigInfo.ServerConfig.ClientCachedSize > 0
                 && ProcessServer.ConfigInfo.ServerConfig.ClientBufferSize > 0
                 && ProcessServer.ConfigInfo.ServerConfig.ClientManageThreadPoolSize > 0
                && ProcessServer.ConfigInfo.ServerConfig.ClientSendThreadPoolSize > 0
                && ProcessServer.ConfigInfo.ServerConfig.ClientReceiveThreadPoolSize > 0
                && ProcessServer.ConfigInfo.ServerConfig.ClientProcessThreadPoolSize > 0
                && ProcessServer.ConfigInfo.ServerConfig.ClientOutTimeInterval >= 0 )
            {
                configServer.SetClientNetConfig( (int)ProcessServer.ConfigInfo.ServerConfig.ClientCachedSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ClientBufferSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ClientManageThreadPoolSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ClientSendThreadPoolSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ClientReceiveThreadPoolSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ClientProcessThreadPoolSize
                    , (int)ProcessServer.ConfigInfo.ServerConfig.ClientOutTimeInterval );
            }
        }

        #endregion

        #region zh-CHS InitOnceServer方法 | en

        #region zh-CHS 获取WOW配置的信息 方法 | en LoadWOWConfig Method
        /// <summary>
        /// 读取参数
        /// </summary>
        private static void LoadWOWConfig()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            if ( File.Exists( "..\\Config\\Mmose.WorldOfWarcraft.config" ) == false )
                throw new Exception( "配置文件(Mmose.WorldOfWarcraft.config)没找到！" );

            XDocument documentWOWConfig = XDocument.Load( "..\\Config\\Mmose.WorldOfWarcraft.config" );
            if ( documentWOWConfig == null )
                return;

            XElement elementRoot = documentWOWConfig.Element( (XName)"Mmose.WorldOfWarcraft" );
            if ( elementRoot == null )
                return;

            //////////////////////////////////////////////////////////////////////////
            // <Settings>
            XElement elementSettings = elementRoot.Element( (XName)"Settings" );
            if ( elementSettings == null )
                return;

            //////////////////////////////////////////////////////////////////////////
            // <ServerSetting>
            XElement elementServerSetting = elementSettings.Element( (XName)"ServerSetting" );
            if ( elementServerSetting != null )
            {
                XElement elementRealmServerHost = elementServerSetting.Element( (XName)"RealmServerHost" );
                if ( elementRealmServerHost != null )
                {
                    string strRealmServerHost = elementRealmServerHost.Value;

                    s_ConfigInfo.WowConfig.RealmServerHost = strRealmServerHost;
                }

                XElement elementRealmServerPort = elementServerSetting.Element( (XName)"RealmServerPort" );
                if ( elementRealmServerHost != null )
                {
                    string strRealmServerPort = elementRealmServerPort.Value;

                    int iRealmServerPort = 0;
                    int.TryParse( strRealmServerPort, out iRealmServerPort );

                    s_ConfigInfo.WowConfig.RealmServerPort = iRealmServerPort;
                }

                XElement elementWorldServerHost = elementServerSetting.Element( (XName)"WorldServerHost" );
                if ( elementWorldServerHost != null )
                {
                    string strWorldServerHost = elementWorldServerHost.Value;

                    s_ConfigInfo.WowConfig.WorldServerHost = strWorldServerHost;
                }

                XElement elementWorldServerPort = elementServerSetting.Element( (XName)"WorldServerPort" );
                if ( elementWorldServerPort != null )
                {
                    string strWorldServerPort = elementWorldServerPort.Value;

                    int iWorldServerPort = 0;
                    int.TryParse( strWorldServerPort, out iWorldServerPort );

                    s_ConfigInfo.WowConfig.WorldServerPort = iWorldServerPort;
                }
            }

            //////////////////////////////////////////////////////////////////////////
            // <WorldSetting>
            XElement elementWorldSetting = elementSettings.Element( (XName)"WorldSetting" );
            if ( elementWorldSetting != null )
            {
                XElement elementWorldName = elementWorldSetting.Element( (XName)"WorldName" );
                if ( elementWorldName != null )
                {
                    string strWorldName = elementWorldName.Value;

                    s_ConfigInfo.WowConfig.WorldName = strWorldName;
                }

                XElement elementColour = elementWorldSetting.Element( (XName)"Colour" );
                if ( elementColour != null )
                {
                    string strColour = elementColour.Value;

                    int iColour = 0;
                    int.TryParse( strColour, out iColour );

                    s_ConfigInfo.WowConfig.Colour = iColour;
                }

                XElement elementTimeZone = elementWorldSetting.Element( (XName)"TimeZone" );
                if ( elementTimeZone != null )
                {
                    string strTimeZone = elementTimeZone.Value;

                    int iTimeZone = 0;
                    int.TryParse( strTimeZone, out iTimeZone );

                    s_ConfigInfo.WowConfig.TimeZone = iTimeZone;
                }

                XElement elementPopulation = elementWorldSetting.Element( (XName)"Population" );
                if ( elementPopulation != null )
                {
                    string strPopulation = elementPopulation.Value;

                    float iPopulation = 0;
                    float.TryParse( strPopulation, out iPopulation );

                    s_ConfigInfo.WowConfig.Population = iPopulation;
                }

                XElement elementIcon = elementWorldSetting.Element( (XName)"Icon" );
                if ( elementIcon != null )
                {
                    string strIcon = elementIcon.Value;

                    s_ConfigInfo.WowConfig.Icon = strIcon;
                }
            }

            //////////////////////////////////////////////////////////////////////////
            // <SQLSetting>
            XElement elementSQLSetting = elementSettings.Element( (XName)"SQLSetting" );
            if ( elementSQLSetting != null )
            {
                XElement elementSQLUser = elementSQLSetting.Element( (XName)"SQLUser" );
                if ( elementSQLUser != null )
                {
                    string strSQLUser = elementSQLUser.Value;

                    s_ConfigInfo.WowConfig.SQLUser = strSQLUser;
                }

                XElement elementSQLHost = elementSQLSetting.Element( (XName)"SQLHost" );
                if ( elementSQLHost != null )
                {
                    string strSQLHost = elementSQLHost.Value;

                    s_ConfigInfo.WowConfig.SQLHost = strSQLHost;
                }

                XElement elementSQLPort = elementSQLSetting.Element( (XName)"SQLPort" );
                if ( elementSQLPort != null )
                {
                    string strSQLPort = elementSQLPort.Value;

                    int iSQLPort = 0;
                    int.TryParse( strSQLPort, out iSQLPort );

                    s_ConfigInfo.WowConfig.SQLPort = iSQLPort;
                }

                XElement elementSQLDatabase = elementSQLSetting.Element( (XName)"SQLDatabase" );
                if ( elementSQLDatabase != null )
                {
                    string strSQLDatabase = elementSQLDatabase.Value;

                    s_ConfigInfo.WowConfig.SQLDatabase = strSQLDatabase;
                }

                XElement elementSQLConnection = elementSQLSetting.Element( (XName)"SQLConnection" );
                if ( elementSQLConnection != null )
                {
                    string strSQLConnection = elementSQLConnection.Value;

                    s_ConfigInfo.WowConfig.SQLConnection = strSQLConnection;
                }
            }
        }
        #endregion

        #region zh-CHS 初始化SQL 方法 | en InitSQL Method
        /// <summary>
        /// 初始化SQL
        /// </summary>
        private static void InitSQL()
        {
            //////////////////////////////////////////////////////////////////////////
            // 设置SQL的连接信息

            if ( ProcessServer.ConfigInfo.WowConfig.SQLConnection == string.Empty ||
                ProcessServer.ConfigInfo.WowConfig.SQLUser == string.Empty ||
                ProcessServer.ConfigInfo.WowConfig.SQLHost == string.Empty ||
                ProcessServer.ConfigInfo.WowConfig.SQLDatabase == string.Empty )
            {
                ProcessServer.ConfigInfo.WowConfig.SQLConnectionUrl = OneDatabase.ConnectionURL;
            }
            else
            {
                OneDatabase.ConnectionURL = s_ConfigInfo.WowConfig.SQLConnectionUrl =
                    string.Format( "Persist Security Info=False;uid={0};pwd={1};Network Library=dbmssocn;Data Source={2},{3};database={4}",
                    //s_ConfigInfo.WowConfig.SQLConnection,
                    s_ConfigInfo.WowConfig.SQLUser,
                    s_ConfigInfo.WowConfig.SQLPassword,
                    s_ConfigInfo.WowConfig.SQLHost,
                    s_ConfigInfo.WowConfig.SQLPort == 0 ? "1433" : s_ConfigInfo.WowConfig.SQLPort.ToString(),
                    s_ConfigInfo.WowConfig.SQLDatabase );
            }

            //////////////////////////////////////////////////////////////////////////
            // 开始连接数据库

            OneDatabase.BuildDefault();
        }
        #endregion

        #region zh-CHS 读取密码 方法 | en LoadPassword Method
        /// <summary>
        /// 读取密码
        /// </summary>
        private static void LoadPassword()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码

            Type type = ProcessServer.ScriptAssemblyInfo.FindTypeByFullName( "Demo.WOW.Scripts.Globals.GlobalConfig" );
            if ( type != null )
            {
                FieldInfo fieldInfo = type.GetField( "SQLPassword" );
                if ( fieldInfo != null )
                {
                    string strSQLPassword = fieldInfo.GetValue( string.Empty ) as string;

                    if ( strSQLPassword != null && strSQLPassword != string.Empty )
                        ProcessServer.ConfigInfo.WowConfig.SQLPassword = strSQLPassword;
                }

                fieldInfo = type.GetField( "DomainPassword" );
                if ( fieldInfo != null )
                {
                    string strDomainPassword = fieldInfo.GetValue( string.Empty ) as string;

                    if ( strDomainPassword != null && strDomainPassword != string.Empty )
                        ProcessServer.ConfigZoneCluster.DomainPassword = strDomainPassword;
                }

                fieldInfo = type.GetField( "ZoneClusterPassword" );
                if ( fieldInfo != null )
                {
                    string strZoneClusterPassword = fieldInfo.GetValue( string.Empty ) as string;

                    if ( strZoneClusterPassword != null && strZoneClusterPassword != string.Empty )
                        ProcessServer.ConfigZoneCluster.ZoneClusterPassword = strZoneClusterPassword;
                }
            }
            else
                Debug.WriteLine( "Program.LoadPassword(...) - FindTypeByFullName(...) error!" );
        }
        #endregion

        #region zh-CHS 读取ZoneWorld配置 方法 | en ZoneWorldConfig Method
        /// <summary>
        /// 读取 ZoneWorld 参数
        /// </summary>
        private static void LoadZoneClusterWorldConfig()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取ZoneWorld配置的信息

            if ( File.Exists( "..\\Config\\Mmose.World.config" ) == false )
                throw new Exception( "配置文件(Mmose.World.config)没找到！" );

            XDocument documentWOWConfig = XDocument.Load( "..\\Config\\Mmose.World.config" );
            if ( documentWOWConfig == null )
                return;

            XElement elementRoot = documentWOWConfig.Element( (XName)"Mmose.World" );
            if ( elementRoot == null )
                return;

            //////////////////////////////////////////////////////////////////////////
            // <Settings>
            XElement elementSettings = elementRoot.Element( (XName)"Settings" );
            if ( elementSettings == null )
                return;

            //////////////////////////////////////////////////////////////////////////
            // <ZoneClusterWorld>
            XElement elementZoneClusterWorld = elementSettings.Element( (XName)"ZoneClusterWorld" );
            if ( elementZoneClusterWorld != null )
            {
                XElement elementZoneClusterID = elementZoneClusterWorld.Element( (XName)"ZoneClusterID" );
                if ( elementZoneClusterID != null )
                {
                    string strZoneClusterID = elementZoneClusterID.Value;

                    s_ConfigZoneCluster.ZoneClusterID = strZoneClusterID;
                }

                XElement elementZoneClusterHost = elementZoneClusterWorld.Element( (XName)"ZoneClusterHost" );
                if ( elementZoneClusterHost != null )
                {
                    string strZoneClusterHost = elementZoneClusterHost.Value;

                    s_ConfigZoneCluster.ZoneClusterHost = strZoneClusterHost;
                }

                XElement elementZoneClusterPort = elementZoneClusterWorld.Element( (XName)"ZoneClusterPort" );
                if ( elementZoneClusterPort != null )
                {
                    string strZoneClusterPort = elementZoneClusterPort.Value;

                    int iZoneClusterPort = 0;
                    int.TryParse( strZoneClusterPort, out iZoneClusterPort );

                    s_ConfigZoneCluster.ZoneClusterPort = iZoneClusterPort;
                }

                XElement elementZoneClusterName = elementZoneClusterWorld.Element( (XName)"ZoneClusterName" );
                if ( elementZoneClusterName != null )
                {
                    string strZoneClusterName = elementZoneClusterName.Value;

                    s_ConfigInfo.WorldConfig.ZoneClusterName = strZoneClusterName;
                }
            }

            //////////////////////////////////////////////////////////////////////////
            // <DomainWorld>
            XElement elementDomainWorld = elementSettings.Element( (XName)"DomainWorld" );
            if ( elementDomainWorld != null )
            {
                XElement elementDomainID = elementDomainWorld.Element( (XName)"DomainID" );
                if ( elementDomainID != null )
                {
                    string strDomainID = elementDomainID.Value;

                    s_ConfigZoneCluster.DomainID = strDomainID;
                }

                XElement elementDomainHost = elementDomainWorld.Element( (XName)"DomainHost" );
                if ( elementDomainHost != null )
                {
                    string strDomainHost = elementDomainHost.Value;

                    s_ConfigZoneCluster.DomainHost = strDomainHost;
                }

                XElement elementDomainPort = elementDomainWorld.Element( (XName)"DomainPort" );
                if ( elementDomainPort != null )
                {
                    string strDomainPort = elementDomainPort.Value;

                    int iDomainPort = 0;
                    int.TryParse( strDomainPort, out iDomainPort );

                    s_ConfigZoneCluster.DomainPort = iDomainPort;
                }
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static void InitOnceServer()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取最新的脚本编译集

            ProcessServer.s_ScriptAssemblyInfo = ScriptCompiler.GetLastNewScriptAssemblyInfo( "Wow.WorldScript" );
            if ( ProcessServer.ScriptAssemblyInfo == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "脚本文件内没有找到{0}版本信息!", "Wow.WorldScript" );

                return;
            }

            //////////////////////////////////////////////////////////////////////////
            // 仅仅是预编译脚本

            if ( Program.IsOnlyBuildScript == true )
                return;

            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            LoadWOWConfig();

            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码和ZoneClusterWorld配置信息

            LoadPassword();

            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码, 并初始化SQL

            InitSQL();

            //////////////////////////////////////////////////////////////////////////
            // 开始注册协议

            // 初始化OpCode的名称
            RealmOpCodeName.InitRealmOpCodeName();
            WordOpCodeName.InitWordOpCodeName();

            // Realm 客户服务端的协议
            ProcessServer.RealmPacketHandlers.Register( (ushort)RealmOpCode.CMSG_REGISTER_REALM_RESULT, ProcessNet.REALM_HEAD_SIZE + 4, false, new PacketReceiveCallback( RealmPacketHandlers.Realm_HandleRegisterRealmResult ) );
            ProcessServer.RealmPacketHandlers.Register( (ushort)RealmOpCode.CMSG_REQUEST_SESSION_RESULT, ProcessNet.REALM_HEAD_SIZE + 4, false, new PacketReceiveCallback( RealmPacketHandlers.Realm_HandleRequestSessionResult ) );
            ProcessServer.RealmPacketHandlers.Register( (ushort)RealmOpCode.CMSG_PONG, ProcessNet.REALM_HEAD_SIZE + 0, false, new PacketReceiveCallback( RealmPacketHandlers.Realm_HandlePong ) );

            // World 客户端的协议
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PING, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePing ) );

            // Login
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUTH_SESSION, ProcessNet.WORLD_HEAD_SIZE + 6, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAuthSession ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHAR_ENUM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharEnum ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHAR_CREATE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharCreate ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHAR_DELETE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharDelete ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHAR_RENAME, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharRename ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PLAYER_LOGIN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePlayerLogin ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_REALM_SPLIT_STATE_REQUEST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleRealmSplitStateRequest ) );

            // Queries
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_CORPSE_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCorpseQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_NAME_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleNameQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUERY_TIME, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQueryTime ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CREATURE_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCreatureQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GAMEOBJECT_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGameObjectQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PAGE_TEXT_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePageTextQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ITEM_NAME_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleItemNameQuery ) );

            //// Movement
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_HEARTBEAT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_WORLDPORT_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMoveWorldportAck ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_JUMP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FLY_PITCH_UP_Z, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FLY_PITCH_DOWN_AFTER_UP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_START_FORWARD, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_START_BACKWARD, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_SET_FACING, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_START_STRAFE_LEFT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_START_STRAFE_RIGHT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_STOP_STRAFE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_START_TURN_LEFT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_START_TURN_RIGHT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_STOP_TURN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_START_PITCH_UP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_START_PITCH_DOWN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_STOP_PITCH, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_SET_RUN_MODE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_SET_WALK_MODE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_SET_PITCH, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_START_SWIM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_STOP_SWIM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_FALL_LAND, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_STOP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMoveStop ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MOVE_FLY_START_AND_END, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FLY_PITCH_UP_Z, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FLY_PITCH_DOWN_AFTER_UP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBasicMovement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MOVE_TIME_SKIPPED, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMoveTimeSkipped ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MOVE_NOT_ACTIVE_MOVER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMoveNotActiveMover ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_ACTIVE_MOVER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetActiveMover ) );

            //// ACK
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MOVE_TELEPORT_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMoveTeleportAck ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FORCE_WALK_SPEED_CHANGE_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MOVE_FEATHER_FALL_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MOVE_WATER_WALK_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FORCE_TURN_RATE_CHANGE_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FORCE_RUN_SPEED_CHANGE_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FORCE_SWIM_SPEED_CHANGE_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FORCE_MOVE_ROOT_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FORCE_MOVE_UNROOT_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MOVE_KNOCK_BACK_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MOVE_HOVER_ACK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcknowledgement ) );

            //// Action Buttons
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_ACTION_BUTTON, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetActionButton ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_REPOP_REQUEST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleRepopRequest ) );

            //// Loot
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUTOSTORE_LOOT_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAutostoreLootItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LOOT_MONEY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLootMoney ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LOOT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLoot ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LOOT_RELEASE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLootRelease ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LOOT_ROLL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLootRoll ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LOOT_MASTER_GIVE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLootMasterGive ) );

            //// Player Interaction
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_WHO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleWho ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LOGOUT_REQUEST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLogoutRequest ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PLAYER_LOGOUT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePlayerLogout ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LOGOUT_CANCEL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLogoutCancel ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ZONEUPDATE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleZoneUpdate ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_TARGET_OBSOLETE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetTarget ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_SELECTION, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetSelection ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_STANDSTATECHANGE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleStandStateChange ) );

            //// Friends
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_FRIEND_LIST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleFriendList ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ADD_FRIEND, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAddFriend ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_DEL_FRIEND, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleDelFriend ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ADD_IGNORE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAddIgnore ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_DEL_IGNORE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleDelIgnore ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BUG, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBug ) );

            //// Areatrigger
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AREATRIGGER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAreaTrigger ) );

            // Account Data
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_UPDATE_ACCOUNT_DATA, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleUpdateAccountData ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_REQUEST_ACCOUNT_DATA, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleRequestAccountData ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_FACTION_ATWAR, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetAtWar ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_WATCHED_FACTION_INDEX, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetWatchedFactionIndex ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TOGGLE_PVP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTogglePVP ) );

            //// Player Interaction
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GAMEOBJ_USE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGameObjectUse ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PLAYED_TIME, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePlayedTime ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SETSHEATHED, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetSheathed ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MESSAGECHAT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMessagechat ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TEXT_EMOTE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTextEmote ) );

            //// Channels
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_JOIN_CHANNEL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelJoin ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LEAVE_CHANNEL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelLeave ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_LIST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelList ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_PASSWORD, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelPassword ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_SET_OWNER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelSetOwner ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_OWNER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelOwner ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_MODERATOR, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelModerator ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_UNMODERATOR, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelUnmoderator ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_MUTE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelMute ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_UNMUTE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelUnmute ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_INVITE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelInvite ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_KICK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelKick ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_BAN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelBan ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_UNBAN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelUnban ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_ANNOUNCEMENTS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelAnnounce ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_MODERATE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelModerate ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_NUM_MEMBERS_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelNumMembersQuery ) );

            //// Groups / Raids
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_INVITE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupInvite ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_CANCEL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupCancel ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_ACCEPT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupAccept ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_DECLINE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupDecline ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_UNINVITE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupUninvite ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_UNINVITE_GUID, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupUninviteGuild ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_SET_LEADER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupSetLeader ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_DISBAND, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupDisband ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LOOT_METHOD, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLootMethod ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_MINIMAP_PING, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMinimapPing ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_RAID_CONVERT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleConvertGroupToRaid ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_CHANGE_SUB_GROUP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupChangeSubGroup ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GROUP_ASSISTANT_LEADER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGroupAssistantLeader ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_REQUEST_RAID_INFO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleRequestRaidInf ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_RAID_READYCHECK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleReadyCheck ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_GROUP_SET_PLAYER_ICON, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetPlayerIcon ) );

            //// LFG System
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_LOOKING_FOR_GROUP_COMMENT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetLookingForGroupComment ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_LOOKING_FOR_GROUP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMsgLookingForGroup ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_LOOKING_FOR_GROUP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetLookingForGroup ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ENABLE_AUTOJOIN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleEnableAutoJoin ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_DISABLE_AUTOJOIN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleDisableAutoJoin ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ENABLE_AUTOADD_MEMBERS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleEnableAutoAddMembers ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_DISABLE_AUTOADD_MEMBERS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleDisableAutoAddMembers ) );

            //// Taxi / NPC Interaction
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TAXINODE_STATUS_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTaxiNodeStatusQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TAXIQUERYAVAILABLENODES, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTaxiQueryAvaibleNodes ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ACTIVATETAXI, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleActivateTaxi ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_TABARDVENDOR_ACTIVATE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTabardVendorActivate ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BANKER_ACTIVATE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBankerActivate ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BUY_BANK_SLOT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBuyBankSlot ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TRAINER_LIST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTrainerList ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TRAINER_BUY_SPELL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTrainerBuySpell ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PETITION_SHOWLIST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharterShowList ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_AUCTION_HELLO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAuctionHello ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GOSSIP_HELLO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGossipHello ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GOSSIP_SELECT_OPTION, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGossipSelectOption ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SPIRIT_HEALER_ACTIVATE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSpiritHealerActivate ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_NPC_TEXT_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleNpcTextQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BINDER_ACTIVATE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBinderActivate ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ACTIVATE_MULTIPLE_TAXI, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMultipleActivateTaxi ) );

            //// Item / Vendors
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SWAP_INV_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSwapInvItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SWAP_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSwapItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_DESTROYITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleDestroyItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUTOEQUIP_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAutoEquipItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ITEM_QUERY_SINGLE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleItemQuerySingle ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SELL_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSellItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BUY_ITEM_IN_SLOT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBuyItemInSlot ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BUY_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBuyItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LIST_INVENTORY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleListInventory ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUTOSTORE_BAG_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAutoStoreBagItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_AMMO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAmmoSet ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BUYBACK_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBuyBack ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SPLIT_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSplit ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_READ_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleReadItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_REPAIR_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleRepairItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUTOBANK_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAutoBankItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUTOSTORE_BANK_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAutoStoreBankItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CANCEL_TEMPORARY_ENCHANTMENT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCancelTemporaryEnchantment ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SOCKET_GEMS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleInsertGem ) );

            //// Spell System / Talent System
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_USE_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleUseItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CAST_SPELL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCastSpell ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CANCEL_CAST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCancelCast ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CANCEL_AURA, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCancelAura ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CANCEL_CHANNELLING, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCancelChannelling ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CANCEL_AUTO_REPEAT_SPELL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCancelAutoRepeatSpell ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LEARN_TALENT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLearnTalent ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_UNLEARN_TALENTS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleUnlearnTalents ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_TALENT_WIPE_CONFIRM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleUnlearnTalents ) );

            //// Combat / Duel
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ATTACKSWING, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAttackSwing ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ATTACKSTOP, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAttackStop ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_DUEL_ACCEPTED, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleDuelAccepted ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_DUEL_CANCELLED, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleDuelCancelled ) );

            //// Trade
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_INITIATE_TRADE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleInitiateTrade ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BEGIN_TRADE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBeginTrade ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BUSY_TRADE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBusyTrade ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_IGNORE_TRADE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleIgnoreTrade ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ACCEPT_TRADE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAcceptTrade ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_UNACCEPT_TRADE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleUnacceptTrade ) );
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CANCEL_TRADE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCancelTrade ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_TRADE_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetTradeItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CLEAR_TRADE_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleClearTradeItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_TRADE_GOLD, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetTradeGold ) );

            //// Quest System
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUESTGIVER_STATUS_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestgiverStatusQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUESTGIVER_HELLO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestgiverHello ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUESTGIVER_ACCEPT_QUEST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestgiverAcceptQuest ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUESTGIVER_CANCEL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestgiverCancel ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUESTGIVER_CHOOSE_REWARD, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestgiverChooseReward ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUESTGIVER_REQUEST_REWARD, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestgiverRequestReward ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUEST_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUESTGIVER_QUERY_QUEST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestGiverQueryQuest ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUESTGIVER_COMPLETE_QUEST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestgiverCompleteQuest ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_QUESTLOG_REMOVE_QUEST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestlogRemoveQuest ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_RECLAIM_CORPSE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCorpseReclaim ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_RESURRECT_RESPONSE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleResurrectResponse ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PUSHQUESTTOPARTY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePushQuestToParty ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_QUEST_PUSH_RESULT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleQuestPushResult ) );

            //// Auction System
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUCTION_LIST_ITEMS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAuctionListItems ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUCTION_LIST_BIDDER_ITEMS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAuctionListBidderItems ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUCTION_SELL_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAuctionSellItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUCTION_LIST_OWNER_ITEMS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAuctionListOwnerItems ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUCTION_PLACE_BID, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAuctionPlaceBid ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AUCTION_REMOVE_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCancelAuction ) );

            //// Mail System
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GET_MAIL_LIST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGetMail ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ITEM_TEXT_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleItemTextQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SEND_MAIL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSendMail ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MAIL_TAKE_MONEY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTakeMoney ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MAIL_TAKE_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTakeItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MAIL_MARK_AS_READ, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMarkAsRead ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MAIL_RETURN_TO_SENDER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleReturnToSender ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MAIL_DELETE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMailDelete ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_QUERY_NEXT_MAIL_TIME, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMailTime ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MAIL_CREATE_TEXT_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMailCreateTextItem ) );

            //// Guild Query (called when not logged in sometimes)
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildQuery ) );

            //// Guild System
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_CREATE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCreateGuild ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_INVITE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleInviteToGuild ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_ACCEPT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildAccept ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_DECLINE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildDecline ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_INFO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildInfo ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_ROSTER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildRoster ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_PROMOTE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildPromote ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_DEMOTE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildDemote ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_LEAVE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildLeave ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_REMOVE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildRemove ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_DISBAND, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildDisband ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_LEADER, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildLeader ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_MOTD, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildMotd ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_RANK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildRank ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_ADD_RANK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildAddRank ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_DEL_RANK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildDelRank ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_SET_PUBLIC_NOTE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildSetPublicNote ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GUILD_SET_OFFICER_NOTE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGuildSetOfficerNote ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PETITION_BUY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharterBuy ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PETITION_SHOW_SIGNATURES, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharterShowSignatures ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TURN_IN_PETITION, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharterTurnInCharter ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PETITION_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharterQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_OFFER_PETITION, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharterOffer ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PETITION_SIGN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharterSign ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_PETITION_RENAME, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCharterRename ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_SAVE_GUILD_EMBLEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSaveGuildEmblem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_GUILD_INFORMATION, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetGuildInformation ) );

            //// Tutorials
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TUTORIAL_FLAG, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTutorialFlag ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TUTORIAL_CLEAR, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTutorialClear ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TUTORIAL_RESET, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleTutorialReset ) );

            //// Pets
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PET_ACTION, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePetAction ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_REQUEST_PET_INFO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePetInfo ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PET_NAME_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePetNameQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BUY_STABLE_SLOT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBuyStableSlot ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_STABLE_PET, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleStablePet ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_UNSTABLE_PET, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleUnstablePet ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_LIST_STABLED_PETS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleStabledPetList ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PET_SET_ACTION, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePetSetAction ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PET_RENAME, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePetRename ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_PET_ABANDON, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePetAbandon ) );

            //// Battlegrounds
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BATTLEFIELD_PORT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBattlefieldPort ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BATTLEFIELD_STATUS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBattlefieldStatus ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BATTLEFIELD_LIST, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBattlefieldList ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BATTLEMASTER_HELLO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBattleMasterHello ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ARENA_JOIN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleArenaJoin ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_BATTLEMASTER_JOIN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBattleMasterJoin ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_LEAVE_BATTLEFIELD, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleLeaveBattlefield ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AREA_SPIRIT_HEALER_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAreaSpiritHealerQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_AREA_SPIRIT_HEALER_QUEUE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleAreaSpiritHealerQueue ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_BATTLEGROUND_PLAYER_POSITIONS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleBattlegroundPlayerPositions ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_PVP_LOG_DATA, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandlePVPLogData ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_INSPECT_HONOR_STATS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleInspectHonorStats ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SET_ACTIONBAR_TOGGLES, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSetActionBarToggles ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MOVE_SPLINE_DONE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMoveSplineComplete ) );

            //// GM Ticket System
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GMTICKET_CREATE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGMTicketCreate ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GMTICKET_UPDATETEXT, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGMTicketUpdate ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GMTICKET_DELETETICKET, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGMTicketDelete ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GMTICKET_GETTICKET, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGMTicketGetTicket ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GMTICKET_SYSTEMSTATUS, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGMTicketSystemStatus ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_GMTICKETSYSTEM_TOGGLE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleGMTicketToggleSystemStatus ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_UNLEARN_SKILL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleUnlearnSkill ) );

            //// Meeting Stone / Instances
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MEETINGSTONE_INFO, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMeetingStoneInfo ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MEETINGSTONE_JOIN, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMeetingStoneJoin ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MEETINGSTONE_LEAVE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMeetingStoneLeave ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_RESET_INSTANCE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleResetInstance ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_SELF_RES, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleSelfResurrect ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.MSG_RANDOM_ROLL, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleRandomRoll ) );

            //// Misc
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_OPEN_ITEM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleOpenItem ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_COMPLETE_CINEMATIC, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleCompleteCinematic ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_MOUNTSPECIAL_ANIM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleMountSpecialAnim ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TOGGLE_CLOAK, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleToggleCloak ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_TOGGLE_HELM, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleToggleHelm ) );

            // voicechat
            ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_ENABLE_MICROPHONE, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleEnableMicrophone ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_VOICE_CHAT_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleVoiceChatQuery ) );
            //ProcessServer.WorldPacketHandlers.Register( (ushort)WordOpCode.CMSG_CHANNEL_VOICE_QUERY, ProcessNet.WORLD_HEAD_SIZE + 0, false, new PacketReceiveCallback( WorldPacketHandlers.World_HandleChannelVoiceQuery ) );

            //////////////////////////////////////////////////////////////////////////
            // 获取ZoneWorld配置信息

            LoadZoneClusterWorldConfig();

            //////////////////////////////////////////////////////////////////////////
            // 开始初始化ZoneClusterServer

            ProcessServer.WowZoneCluster.InitZoneCluster( ProcessServer.ConfigZoneCluster );

            //////////////////////////////////////////////////////////////////////////
            // 开始World监听端口

            if ( ProcessServer.ConfigInfo.WowConfig.WorldServerHost == string.Empty )
            {
                if ( Program.WorldServerListener.StartServer( ProcessServer.WORLD_SERVER_PORT ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听(WorldServer)端口：{0} 失败!", ProcessServer.WORLD_SERVER_PORT );
                    return;
                }
            }
            else
            {
                string strHostNamePort = ProcessServer.ConfigInfo.WowConfig.WorldServerHost + ":" + ProcessServer.ConfigInfo.WowConfig.WorldServerPort;

                if ( Program.WorldServerListener.StartServer( strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听(WorldServer)IP地址与端口：{0} 失败!", strHostNamePort );
                    return;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void ExitServer()
        {
            Program.RealmServerConnecter.Dispose();
            Program.WorldServerListener.Dispose();
        }

        #endregion

        #region zh-CHS CommandLine方法 | en

        /// <summary>
        /// 
        /// </summary>
        internal static void CommandLineInfo()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        internal static bool CommandLineDisposal( string strCommandLine )
        {
            bool bReturn = false;

            return bReturn;
        }

        #endregion
    }
}
#endregion
