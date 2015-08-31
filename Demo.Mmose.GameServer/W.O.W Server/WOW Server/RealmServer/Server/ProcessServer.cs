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
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Scripts;
using Demo.Mmose.Core.Server;
using Demo.Mmose.Core.World.ZoneClusterWorld;
using Demo.Wow.Database;
using Demo.Wow.RealmServer.Common;
using Demo.Wow.RealmServer.Network;
using Demo.Wow.RealmServer.Network.Common;
using Demo.Wow.RealmServer.World;
#endregion

namespace Demo.Wow.RealmServer.Server
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
        private const int REALM_SERVER_PORT = 8093;
        #endregion

        #region zh-CHS 内部静态属性 | en Internal Static Properties

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static WowZoneCluster s_WowZoneCluster = new WowZoneCluster();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static WowZoneCluster WowZoneCluster
        {
            get { return s_WowZoneCluster; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static int s_AuthServerPort = 3724;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static int AuthServerPort
        {
            get { return s_AuthServerPort; }
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
        private static ConfigZoneCluster s_ConfigZoneClusterWorld = new ConfigZoneCluster();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static ConfigZoneCluster ConfigZoneClusterWorld
        {
            get { return s_ConfigZoneClusterWorld; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Auth_PacketHandlers m_AuthPacketHandlers = new Auth_PacketHandlers();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static Auth_PacketHandlers AuthPacketHandlers
        {
            get { return m_AuthPacketHandlers; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Realm_PacketHandlers m_RealmPacketHandlers = new Realm_PacketHandlers();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static Realm_PacketHandlers RealmPacketHandlers
        {
            get { return m_RealmPacketHandlers; }
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

        #region zh-CHS ConfigServer方法 | en Static Method

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

            configServer.Service = s_ConfigInfo.ServerConfig.Service;
            configServer.LogFile = s_ConfigInfo.ServerConfig.LogFile;
            configServer.Cache = s_ConfigInfo.ServerConfig.Cache;
            configServer.Debug = s_ConfigInfo.ServerConfig.Debug;
            configServer.HaltOnWarning = s_ConfigInfo.ServerConfig.HaltOnWarning;
            configServer.Profiling = s_ConfigInfo.ServerConfig.Profiling;
            configServer.WorldThreadCount = s_ConfigInfo.ServerConfig.WorldThreadCount;

            if ( s_ConfigInfo.ServerConfig.ServerCachedSize > 0
                 && s_ConfigInfo.ServerConfig.ServerBufferSize > 0
                 && s_ConfigInfo.ServerConfig.ServerManageThreadPoolSize > 0
                && s_ConfigInfo.ServerConfig.ServerSendThreadPoolSize > 0
                && s_ConfigInfo.ServerConfig.ServerReceiveThreadPoolSize > 0
                && s_ConfigInfo.ServerConfig.ServerProcessThreadPoolSize > 0
                && s_ConfigInfo.ServerConfig.ServerMaxClients > 0
                && s_ConfigInfo.ServerConfig.ServerOutTimeInterval >= 0 )
            {
                configServer.SetServerNetConfig( (int)s_ConfigInfo.ServerConfig.ServerCachedSize
                    , (int)s_ConfigInfo.ServerConfig.ServerBufferSize
                    , (int)s_ConfigInfo.ServerConfig.ServerManageThreadPoolSize
                    , (int)s_ConfigInfo.ServerConfig.ServerSendThreadPoolSize
                    , (int)s_ConfigInfo.ServerConfig.ServerReceiveThreadPoolSize
                    , (int)s_ConfigInfo.ServerConfig.ServerProcessThreadPoolSize
                    , (int)s_ConfigInfo.ServerConfig.ServerMaxClients
                    , (int)s_ConfigInfo.ServerConfig.ServerOutTimeInterval );
            }


            if ( s_ConfigInfo.ServerConfig.ClientCachedSize > 0
                 && s_ConfigInfo.ServerConfig.ClientBufferSize > 0
                 && s_ConfigInfo.ServerConfig.ClientManageThreadPoolSize > 0
                && s_ConfigInfo.ServerConfig.ClientSendThreadPoolSize > 0
                && s_ConfigInfo.ServerConfig.ClientReceiveThreadPoolSize > 0
                && s_ConfigInfo.ServerConfig.ClientProcessThreadPoolSize > 0
                && s_ConfigInfo.ServerConfig.ClientOutTimeInterval >= 0 )
            {
                configServer.SetClientNetConfig( (int)s_ConfigInfo.ServerConfig.ClientCachedSize
                    , (int)s_ConfigInfo.ServerConfig.ClientBufferSize
                    , (int)s_ConfigInfo.ServerConfig.ClientManageThreadPoolSize
                    , (int)s_ConfigInfo.ServerConfig.ClientSendThreadPoolSize
                    , (int)s_ConfigInfo.ServerConfig.ClientReceiveThreadPoolSize
                    , (int)s_ConfigInfo.ServerConfig.ClientProcessThreadPoolSize
                    , (int)s_ConfigInfo.ServerConfig.ClientOutTimeInterval );
            }
        }

        #endregion

        #region zh-CHS InitOnceServer方法 | en Static Method

        #region zh-CHS 获取Wow配置的信息 方法 | en LoadWowConfig Method
        /// <summary>
        /// 读取参数
        /// </summary>
        private static void LoadWowConfig()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            if ( File.Exists( "..\\Config\\Mmose.WorldOfWarcraft.config" ) == false )
                throw new Exception( "配置文件(Mmose.WorldOfWarcraft.config)没找到！" );

            XDocument documentWowConfig = XDocument.Load( "..\\Config\\Mmose.WorldOfWarcraft.config" );
            if ( documentWowConfig == null )
                return;

            XElement elementRoot = documentWowConfig.Element( (XName)"Mmose.WorldOfWarcraft" );
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

                XElement elementAuthServerHost = elementServerSetting.Element( (XName)"AuthServerHost" );
                if ( elementRealmServerHost != null )
                {
                    string strAuthServerHost = elementAuthServerHost.Value;

                    s_ConfigInfo.WowConfig.AuthServerHost = strAuthServerHost;
                }

                XElement elementAuthServerPort = elementServerSetting.Element( (XName)"AuthServerPort" );
                if ( elementRealmServerHost != null )
                {
                    string strAuthServerPort = elementAuthServerPort.Value;

                    int iAuthServerPort = 0;
                    int.TryParse( strAuthServerPort, out iAuthServerPort );

                    s_ConfigInfo.WowConfig.AuthServerPort = iAuthServerPort;
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

        #region zh-CHS 读取密码 方法 | en LoadPassword Method
        /// <summary>
        /// 读取密码
        /// </summary>
        private static void LoadPassword()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码

            Type type = s_ScriptAssemblyInfo.FindTypeByFullName( "Demo.Wow.Scripts.Globals.GlobalConfig" );
            if ( type != null )
            {
                FieldInfo fieldInfo = type.GetField( "SQLPassword" );
                if ( fieldInfo != null )
                {
                    string strSQLPassword = fieldInfo.GetValue( string.Empty ) as string;

                    if ( strSQLPassword != null && strSQLPassword != string.Empty )
                        s_ConfigInfo.WowConfig.SQLPassword = strSQLPassword;
                }

                fieldInfo = type.GetField( "DomainPassword" );
                if ( fieldInfo != null )
                {
                    string strDomainPassword = fieldInfo.GetValue( string.Empty ) as string;

                    if ( strDomainPassword != null && strDomainPassword != string.Empty )
                        s_ConfigZoneClusterWorld.DomainPassword = strDomainPassword;
                }


                fieldInfo = type.GetField( "ZoneClusterPassword" );
                if ( fieldInfo != null )
                {
                    string strZoneClusterPassword = fieldInfo.GetValue( string.Empty ) as string;

                    if ( strZoneClusterPassword != null && strZoneClusterPassword != string.Empty )
                        s_ConfigZoneClusterWorld.ZoneClusterPassword = strZoneClusterPassword;
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

            if ( s_ConfigInfo.WowConfig.SQLConnection == string.Empty ||
                s_ConfigInfo.WowConfig.SQLUser == string.Empty ||
                s_ConfigInfo.WowConfig.SQLHost == string.Empty ||
                s_ConfigInfo.WowConfig.SQLDatabase == string.Empty )
            {
                s_ConfigInfo.WowConfig.SQLConnectionUrl = OneDatabase.ConnectionURL;
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

            if ( Program.IsSQLRecreate == false )
                OneDatabase.BuildDefault();
            else
                // 重建数据库
                OneDatabase.BuildRecreate();
        }
        #endregion

        #region zh-CHS 读取ZoneClusterWorld配置 方法 | en LoadZoneClusterWorldConfig Method
        /// <summary>
        /// 读取 ZoneClusterWorld 参数
        /// </summary>
        private static void LoadZoneClusterWorldConfig()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取ZoneWorld配置的信息

            if ( File.Exists( "..\\Config\\Mmose.World.config" ) == false )
                throw new Exception( "配置文件(Mmose.World.config)没找到！" );

            XDocument documentWowConfig = XDocument.Load( "..\\Config\\Mmose.World.config" );
            if ( documentWowConfig == null )
                return;

            XElement elementRoot = documentWowConfig.Element( (XName)"Mmose.World" );
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

                    s_ConfigZoneClusterWorld.ZoneClusterID = strZoneClusterID;
                }

                XElement elementZoneClusterHost = elementZoneClusterWorld.Element( (XName)"ZoneClusterHost" );
                if ( elementZoneClusterHost != null )
                {
                    string strZoneClusterHost = elementZoneClusterHost.Value;

                    s_ConfigZoneClusterWorld.ZoneClusterHost = strZoneClusterHost;
                }

                XElement elementZoneClusterPort = elementZoneClusterWorld.Element( (XName)"ZoneClusterPort" );
                if ( elementZoneClusterPort != null )
                {
                    string strZoneClusterPort = elementZoneClusterPort.Value;

                    int iZoneClusterPort = 0;
                    int.TryParse( strZoneClusterPort, out iZoneClusterPort );

                    s_ConfigZoneClusterWorld.ZoneClusterPort = iZoneClusterPort;
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

                    s_ConfigZoneClusterWorld.DomainID = strDomainID;
                }

                XElement elementDomainHost = elementDomainWorld.Element( (XName)"DomainHost" );
                if ( elementDomainHost != null )
                {
                    string strDomainHost = elementDomainHost.Value;

                    s_ConfigZoneClusterWorld.DomainHost = strDomainHost;
                }

                XElement elementDomainPort = elementDomainWorld.Element( (XName)"DomainPort" );
                if ( elementDomainPort != null )
                {
                    string strDomainPort = elementDomainPort.Value;

                    int iDomainPort = 0;
                    int.TryParse( strDomainPort, out iDomainPort );

                    s_ConfigZoneClusterWorld.DomainPort = iDomainPort;
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

            s_ScriptAssemblyInfo = ScriptCompiler.GetLastNewScriptAssemblyInfo( "Wow.RealmScript" );
            if ( s_ScriptAssemblyInfo == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "脚本文件内没有找到{0}版本信息!", "Wow.RealmScript" );

                return;
            }

            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            LoadWowConfig();

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
            AuthOpCodeName.InitAuthOpCodeName();

            // Auth 客户端的协议
            AuthPacketHandlers.Register( (ushort)AuthOpCode.SMSG_AUTH_CHALLENGE, ProcessNet.AUTH_ID_SIZE + 33, false, new PacketReceiveCallback( Auth_PacketHandlers.Auth_HandleAuthChallenge ) );
            AuthPacketHandlers.Register( (ushort)AuthOpCode.SMSG_AUTH_RECONNECT_CHALLENGE, ProcessNet.AUTH_ID_SIZE + 33, false, new PacketReceiveCallback( Auth_PacketHandlers.Auth_HandleAuthChallenge ) );
            AuthPacketHandlers.Register( (ushort)AuthOpCode.SMSG_AUTH_PROOF, ProcessNet.AUTH_ID_SIZE + 74, false, new PacketReceiveCallback( Auth_PacketHandlers.Auth_HandleAuthProof ) );
            AuthPacketHandlers.Register( (ushort)AuthOpCode.SMSG_AUTH_RECONNECT_PROOF, ProcessNet.AUTH_ID_SIZE + 74, false, new PacketReceiveCallback( Auth_PacketHandlers.Auth_HandleAuthProof ) );
            AuthPacketHandlers.Register( (ushort)AuthOpCode.SMSG_REALM_LIST, ProcessNet.AUTH_ID_SIZE + 4, false, new PacketReceiveCallback( Auth_PacketHandlers.Auth_HandleRealmList ) );

            // Realm 客户端的协议
            RealmPacketHandlers.Register( (ushort)RealmOpCode.SMSG_REGISTER_REALM, ProcessNet.REALM_HEAD_SIZE + 0, false, new PacketReceiveCallback( Realm_PacketHandlers.Realm_HandleRegisterRealm ) );
            RealmPacketHandlers.Register( (ushort)RealmOpCode.SMSG_REQUEST_SESSION, ProcessNet.REALM_HEAD_SIZE + 4, false, new PacketReceiveCallback( Realm_PacketHandlers.Realm_HandleRequestSession ) );
            RealmPacketHandlers.Register( (ushort)RealmOpCode.SMSG_PING, ProcessNet.REALM_HEAD_SIZE + 0, false, new PacketReceiveCallback( Realm_PacketHandlers.Realm_HandlePing ) );
            RealmPacketHandlers.Register( (ushort)RealmOpCode.SMSG_SQL_EXECUTE, ProcessNet.REALM_HEAD_SIZE + 0, false, new PacketReceiveCallback( Realm_PacketHandlers.Realm_HandleSQLExecute ) );
            
            //////////////////////////////////////////////////////////////////////////
            // 获取ZoneWorld配置信息

            LoadZoneClusterWorldConfig();

            //////////////////////////////////////////////////////////////////////////
            // 开始初始化ZoneClusterServer

            s_WowZoneCluster.InitZoneCluster( s_ConfigZoneClusterWorld );

            //////////////////////////////////////////////////////////////////////////
            // 开始AuthServer监听端口

            if ( s_ConfigInfo.WowConfig.AuthServerHost == string.Empty )
            {
                if ( Program.AuthServerListener.StartServer( AuthServerPort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听端口：{0} 失败!", AuthServerPort );
                    return;
                }
            }
            else
            {
                string strHostNamePort = s_ConfigInfo.WowConfig.AuthServerHost + ":" + s_ConfigInfo.WowConfig.AuthServerPort;

                if ( Program.AuthServerListener.StartServer( strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听IP地址与端口：{0} 失败!", strHostNamePort );
                    return;
                }
            }

            //////////////////////////////////////////////////////////////////////////
            // 开始RealmServer监听端口

            if ( s_ConfigInfo.WowConfig.RealmServerHost == string.Empty )
            {
                if ( Program.RealmServerListener.StartServer( REALM_SERVER_PORT ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听端口：{0} 失败!", REALM_SERVER_PORT );
                    return;
                }
            }
            else
            {
                string strHostNamePort = s_ConfigInfo.WowConfig.RealmServerHost + ":" + s_ConfigInfo.WowConfig.RealmServerPort;

                if ( Program.RealmServerListener.StartServer( strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听IP地址与端口：{0} 失败!", strHostNamePort );
                    return;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void ExitServer()
        {
            Program.AuthServerListener.Dispose();
            Program.RealmServerListener.Dispose();
        }

        #endregion

        #region zh-CHS CommandLine方法 | en Static Method

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