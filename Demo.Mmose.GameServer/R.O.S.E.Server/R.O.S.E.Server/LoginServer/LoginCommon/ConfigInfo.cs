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
#endregion

namespace Demo_R.O.S.E.LoginServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    internal class ConfigInfo
    {
        #region zh-CHS 内部属性 | en Internal Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strLoginHost = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string LoginHost
        {
            get { return m_strLoginHost; }
            set { m_strLoginHost = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iLoginPort = Program.LoginServerPort;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long LoginPort
        {
            get { return m_iLoginPort; }
            set { m_iLoginPort = value; }
        }



        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strCharHost = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string CharHost
        {
            get { return m_strCharHost; }
            set { m_strCharHost = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iCharPort = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long CharPort
        {
            get { return m_iCharPort; }
            set { m_iCharPort = value; }
        }



        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strCharPassword = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string CharPassword
        {
            get { return m_strCharPassword; }
            set { m_strCharPassword = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strLoginPassword = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string LoginPassword
        {
            get { return m_strLoginPassword; }
            set { m_strLoginPassword = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strWorldPassword = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string WorldPassword
        {
            get { return m_strWorldPassword; }
            set { m_strWorldPassword = value; }
        }



        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strSQLUser = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string SQLUser
        {
            get { return m_strSQLUser; }
            set { m_strSQLUser = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strSQLHost = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string SQLHost
        {
            get { return m_strSQLHost; }
            set { m_strSQLHost = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iSQLPort = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long SQLPort
        {
            get { return m_iSQLPort; }
            set { m_iSQLPort = value; }
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strSQLDatabase = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string SQLDatabase
        {
            get { return m_strSQLDatabase; }
            set { m_strSQLDatabase = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strSQLConnection = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string SQLConnection
        {
            get { return m_strSQLConnection; }
            set { m_strSQLConnection = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strSQLPassword = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string SQLPassword
        {
            get { return m_strSQLPassword; }
            set { m_strSQLPassword = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strSQLConnectionUrl = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string SQLConnectionUrl
        {
            get { return m_strSQLConnectionUrl; }
            set { m_strSQLConnectionUrl = value; }
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iServerCachedSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ServerCachedSize
        {
            get { return m_iServerCachedSize; }
            set { m_iServerCachedSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iServerBufferSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ServerBufferSize
        {
            get { return m_iServerBufferSize; }
            set { m_iServerBufferSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iServerManageThreadPoolSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ServerManageThreadPoolSize
        {
            get { return m_iServerManageThreadPoolSize; }
            set { m_iServerManageThreadPoolSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iServerSendThreadPoolSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ServerSendThreadPoolSize
        {
            get { return m_iServerSendThreadPoolSize; }
            set { m_iServerSendThreadPoolSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iServerReceiveThreadPoolSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ServerReceiveThreadPoolSize
        {
            get { return m_iServerReceiveThreadPoolSize; }
            set { m_iServerReceiveThreadPoolSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iServerProcessThreadPoolSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ServerProcessThreadPoolSize
        {
            get { return m_iServerProcessThreadPoolSize; }
            set { m_iServerProcessThreadPoolSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iServerMaxClients = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ServerMaxClients
        {
            get { return m_iServerMaxClients; }
            set { m_iServerMaxClients = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iServerOutTimeInterval = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ServerOutTimeInterval
        {
            get { return m_iServerOutTimeInterval; }
            set { m_iServerOutTimeInterval = value; }
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iClientCachedSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClientCachedSize
        {
            get { return m_iClientCachedSize; }
            set { m_iClientCachedSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iClientBufferSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClientBufferSize
        {
            get { return m_iClientBufferSize; }
            set { m_iClientBufferSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iClientManageThreadPoolSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClientManageThreadPoolSize
        {
            get { return m_iClientManageThreadPoolSize; }
            set { m_iClientManageThreadPoolSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iClientSendThreadPoolSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClientSendThreadPoolSize
        {
            get { return m_iClientSendThreadPoolSize; }
            set { m_iClientSendThreadPoolSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iClientReceiveThreadPoolSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClientReceiveThreadPoolSize
        {
            get { return m_iClientReceiveThreadPoolSize; }
            set { m_iClientReceiveThreadPoolSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iClientProcessThreadPoolSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClientProcessThreadPoolSize
        {
            get { return m_iClientProcessThreadPoolSize; }
            set { m_iClientProcessThreadPoolSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iClientOutTimeInterval = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClientOutTimeInterval
        {
            get { return m_iClientOutTimeInterval; }
            set { m_iClientOutTimeInterval = value; }
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bCache = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool Cache
        {
            get { return m_bCache; }
            set { m_bCache = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bDebug = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool Debug
        {
            get { return m_bDebug; }
            set { m_bDebug = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bHaltOnWarning = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool HaltOnWarning
        {
            get { return m_bHaltOnWarning; }
            set { m_bHaltOnWarning = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bProfiling = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool Profiling
        {
            get { return m_bProfiling; }
            set { m_bProfiling = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bService = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool Service
        {
            get { return m_bService; }
            set { m_bService = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strLogFile = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string LogFile
        {
            get { return m_strLogFile; }
            set { m_strLogFile = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iWorldThreadCount = 5;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal byte WorldThreadCount
        {
            get { return m_iWorldThreadCount; }
            set { m_iWorldThreadCount = value; }
        }

        #endregion
    }
}
#endregion