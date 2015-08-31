using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.GOSE.ServerEngine.World.ZoneWorld;
using Demo.GOSE.ServerEngine.Server;
using Demo.GOSE.ServerEngine.Common;
using Demo.WOW.Zone.World;
using Demo.WOW.Zone.Common;

namespace Demo.WOW.Zone.Server
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProcessServer
    {
        #region zh-CHS 内部静态属性 | en Internal Static Properties

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static WoWWorld s_ZoneWorld = new WoWWorld();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static WoWWorld WoWWorld
        {
            get { return s_ZoneWorld; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static int s_ZoneServerPort = 19780;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static int ZoneServerPort
        {
            get { return s_ZoneServerPort; }
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
        private static ConfigZoneWorld s_ConfigZoneWorld = new ConfigZoneWorld();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static ConfigZoneWorld ConfigZoneWorld
        {
            get { return s_ConfigZoneWorld; }
        }

        #endregion

        #region zh-CHS ConfigServer方法 | en Static Method

        #region zh-CHS 读取参数 方法 | en LoadVariables Method
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

            if ( File.Exists( "G.O.S.E.Zone.config" ) == false )
                throw new Exception( "配置文件(G.O.S.E.Zone.config)没找到！" );

            XmlReader l_xmlReader = XmlReader.Create( "G.O.S.E.Zone.config", l_xmlSettings );

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

                        //////////////////////////////////////////////////////////////////////////
                        // <G.O.S.E.Zone>
                        if ( Insensitive.Equals( l_xmlReader.Name, "G.O.S.E.Zone" ) == true )
                        {
                            if ( l_xmlReader.HasAttributes == true )
                            {
                                while ( l_xmlReader.MoveToNextAttribute() == true )
                                {
                                    if ( Insensitive.Equals( l_xmlReader.Name, "Author" ) == true )
                                    {
                                        string l_strAuthor = l_xmlReader.Value;

                                        if ( Insensitive.Equals( l_strAuthor, "H.Q.Cai" ) == false )
                                            throw new Exception( "G.O.S.E.Zone.config File - XML - Author != H.Q.Cai" );
                                    }
                                    else if ( Insensitive.Equals( l_xmlReader.Name, "Version" ) == true )
                                    {
                                        string l_strVersion = l_xmlReader.Value;

                                        if ( Insensitive.Equals( l_strVersion, "0.1" ) == false )
                                            throw new Exception( "G.O.S.E.Zone.config File - XML - Version != 0.1" );
                                    }
                                }

                                l_xmlReader.MoveToElement();
                            }
                        }

                        //////////////////////////////////////////////////////////////////////////
                        // <Settings>
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZoneClusterHost" ) == true )
                        {
                            string l_strZoneClusterHost = l_xmlReader.ReadString();

                            s_ConfigInfo.ZoneClusterHost = l_strZoneClusterHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZoneClusterPort" ) == true )
                        {
                            string l_strZoneClusterPort = l_xmlReader.ReadString();

                            int iZoneClusterPort = 0;
                            int.TryParse( l_strZoneClusterPort, out iZoneClusterPort );

                            s_ConfigInfo.ZoneClusterPort = iZoneClusterPort;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZoneHost" ) == true )
                        {
                            string l_strZoneHost = l_xmlReader.ReadString();

                            s_ConfigInfo.ZoneHost = l_strZoneHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZonePort" ) == true )
                        {
                            string l_strZonePort = l_xmlReader.ReadString();

                            int iZonePort = 0;
                            int.TryParse( l_strZonePort, out iZonePort );

                            s_ConfigInfo.ZonePort = iZonePort;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZoneName" ) == true )
                        {
                            string l_strZoneName = l_xmlReader.ReadString();

                            s_ConfigInfo.ZoneName = l_strZoneName;
                        }

                        //////////////////////////////////////////////////////////////////////////
                        // <ServerSetting>
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

                        //////////////////////////////////////////////////////////////////////////
                        // <NetSetting>
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

                        //////////////////////////////////////////////////////////////////////////
                        // <NetSetting>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configServer"></param>
        internal static void ConfigServer( ref ConfigServer configServer )
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

        #endregion

        #region zh-CHS InitOnceServer方法 | en Static Method

        #region zh-CHS 读取密码 方法 | en LoadPassword Method
        /// <summary>
        /// 读取密码
        /// </summary>
        private static void LoadPassword()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码

            //Type l_Type = ScriptCompiler.FindTypeByFullName( "Demo.GOSE.Scripts.Globals.GlobalConfig" );
            //if ( l_Type != null )
            //{
            //    FieldInfo l_FieldInfo = l_Type.GetField( "ZoneClusterPassword" );
            //    if ( l_FieldInfo != null )
            //    {
            //        string l_strZoneClusterPassword = l_FieldInfo.GetValue( string.Empty ) as string;

            //        if ( l_strZoneClusterPassword != null && l_strZoneClusterPassword != string.Empty )
            //            s_ConfigZoneWorld.ZoneClusterPassword = l_strZoneClusterPassword;
            //    }


            //    l_FieldInfo = l_Type.GetField( "ZonePassword" );
            //    if ( l_FieldInfo != null )
            //    {
            //        string l_strZonePassword = l_FieldInfo.GetValue( string.Empty ) as string;

            //        if ( l_strZonePassword != null && l_strZonePassword != string.Empty )
            //            s_ConfigZoneWorld.ZonePassword = l_strZonePassword;
            //    }
            //}
        }
        #endregion

        #region zh-CHS 读取ZoneWorld配置 方法 | en ZoneWorldConfig Method
        /// <summary>
        /// 读取 ZoneWorld 参数
        /// </summary>
        private static void LoadZoneWorldConfig()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取ZoneWorld配置的信息

            XmlReaderSettings l_xmlSettings = new XmlReaderSettings();
            l_xmlSettings.ConformanceLevel = ConformanceLevel.Fragment;
            l_xmlSettings.IgnoreWhitespace = true;
            l_xmlSettings.IgnoreComments = true;

            if ( File.Exists( "G.O.S.E.World.config" ) == false )
                throw new Exception( "配置文件(G.O.S.E.World.config)没找到！" );

            XmlReader l_xmlReader = XmlReader.Create( "G.O.S.E.World.config", l_xmlSettings );

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

                        //////////////////////////////////////////////////////////////////////////
                        // <G.O.S.E.World>
                        if ( Insensitive.Equals( l_xmlReader.Name, "G.O.S.E.World" ) == true )
                        {
                            if ( l_xmlReader.HasAttributes == true )
                            {
                                while ( l_xmlReader.MoveToNextAttribute() == true )
                                {
                                    if ( Insensitive.Equals( l_xmlReader.Name, "Author" ) == true )
                                    {
                                        string l_strAuthor = l_xmlReader.Value;

                                        if ( Insensitive.Equals( l_strAuthor, "H.Q.Cai" ) == false )
                                            throw new Exception( "G.O.S.E.World.config File - XML - Author != H.Q.Cai" );
                                    }
                                    else if ( Insensitive.Equals( l_xmlReader.Name, "Version" ) == true )
                                    {
                                        string l_strVersion = l_xmlReader.Value;

                                        if ( Insensitive.Equals( l_strVersion, "0.1" ) == false )
                                            throw new Exception( "G.O.S.E.World.config File - XML - Version != 0.1" );
                                    }
                                }

                                l_xmlReader.MoveToElement();
                            }
                        }

                        //////////////////////////////////////////////////////////////////////////
                        // <Settings>
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZoneID" ) == true )
                        {
                            string l_strZoneID = l_xmlReader.ReadString();

                            s_ConfigZoneWorld.ZoneID = l_strZoneID;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZoneHost" ) == true )
                        {
                            string l_strZoneHost = l_xmlReader.ReadString();

                            s_ConfigZoneWorld.ZoneHost = l_strZoneHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZonePort" ) == true )
                        {
                            string l_strZonePort = l_xmlReader.ReadString();

                            int iZonePort = 0;
                            int.TryParse( l_strZonePort, out iZonePort );

                            s_ConfigZoneWorld.ZonePort = iZonePort;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZoneClusterID" ) == true )
                        {
                            string l_strZoneClusterID = l_xmlReader.ReadString();

                            s_ConfigZoneWorld.ZoneClusterID = l_strZoneClusterID;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZoneClusterHost" ) == true )
                        {
                            string l_strZoneClusterHost = l_xmlReader.ReadString();

                            s_ConfigZoneWorld.ZoneClusterHost = l_strZoneClusterHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "ZoneClusterPort" ) == true )
                        {
                            string l_strZoneClusterPort = l_xmlReader.ReadString();

                            int iZoneClusterPort = 0;
                            int.TryParse( l_strZoneClusterPort, out iZoneClusterPort );

                            s_ConfigZoneWorld.ZoneClusterPort = iZoneClusterPort;
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
        /// <summary>
        /// 
        /// </summary>
        internal static void InitOnceServer()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码和ZoneWorld配置信息

            LoadPassword();

            //////////////////////////////////////////////////////////////////////////
            // 获取ZoneWorld配置信息

            LoadZoneWorldConfig();

            //////////////////////////////////////////////////////////////////////////
            // 开始注册协议


            //////////////////////////////////////////////////////////////////////////
            // 开始连接至ZoneClusterServer

            s_ZoneWorld.InitZoneWorld( s_ConfigZoneWorld );


            //////////////////////////////////////////////////////////////////////////
            // 开始监听端口

            if ( s_ConfigInfo.ZoneHost == string.Empty )
            {
                if ( Program.ZoneListener.StartServer( ZoneServerPort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听端口：{0} 失败!", ZoneServerPort );
                    return;
                }
            }
            else
            {
                string l_strHostNamePort = s_ConfigInfo.ZoneHost + ":" + s_ConfigInfo.ZonePort;

                if ( Program.ZoneListener.StartServer( l_strHostNamePort ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "监听IP地址与端口：{0} 失败!", l_strHostNamePort );
                    return;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void ExitServer()
        {
            Program.ZoneListener.Dispose();
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
