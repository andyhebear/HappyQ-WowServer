#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Server
{
    /// <summary>
    /// 主服务的配置内容
    /// </summary>
    [MultiThreadedNoSupport( "zh-CHS", "当前的类所有成员没有锁定(仅局部使用,配置主服务),不支持多线程操作" )]
    public class ConfigServer
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 日志输出的文件名
        /// </summary>
        private string m_strLogFile = "Console.log";
        #endregion
        /// <summary>
        /// 日志输出的文件名
        /// </summary>
        public string LogFile
        {
            get { return m_strLogFile; }
            set
            {
                if ( value == null )
                    return;

                m_strLogFile = value;
                m_bIsChangeLogFile = true;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主服务程序是否正在调试状态
        /// </summary>
        private bool m_bDebug = false;
        #endregion
        /// <summary>
        /// 主服务程序是否正在调试状态
        /// </summary>
        public bool Debug
        {
            get { return m_bDebug; }
            set
            {                
                m_bDebug = value;
                m_bIsChangeDebug = true;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主服务程序是否具有服务日志
        /// </summary>
        private bool m_bService = false;
        #endregion
        /// <summary>
        /// 主服务程序是否具有服务日志
        /// </summary>
        public bool Service
        {
            get { return m_bService; }
            set
            {                
                m_bService = value;
                m_bIsChangeService = true;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否开始对软件进行性能测试和统计
        /// </summary>
        private bool m_bProfiling = false;
        #endregion
        /// <summary>
        /// 是否开始对软件进行性能测试和统计
        /// </summary>
        public bool Profiling
        {
            get { return m_bProfiling; }
            set
            {                
                m_bProfiling = value;
                m_bIsChangeProfiling = true;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 程序是否使用缓存的程序集
        /// </summary>
        private bool m_bCache = true;
        #endregion
        /// <summary>
        /// 程序是否使用缓存的程序集
        /// </summary>
        public bool Cache
        {
            get { return m_bCache; }
            set
            {                
                m_bCache = value;
                m_bIsChangeCache = true;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主服务程序的编译出现警告时是否中断编译
        /// </summary>
        private bool m_bHaltOnWarning = false;
        #endregion
        /// <summary>
        /// 主服务程序的编译出现警告时是否中断编译
        /// </summary>
        public bool HaltOnWarning
        {
            get { return m_bHaltOnWarning; }
            set
            {                
                m_bHaltOnWarning = value;
                m_bIsChangeHaltOnWarning = true;
            }
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 开启游戏世界的服务的线程数
        /// </summary>
        private byte m_iWorldThreadCount = 0;
        #endregion
        /// <summary>
        /// 开启游戏世界的服务的线程数
        /// </summary>
        public byte WorldThreadCount
        {
            get { return m_iWorldThreadCount; }
            set
            {
                m_iWorldThreadCount = value;
                m_bIsChangeWorldThreadCount = true;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主服务程序的编译出现警告时是否中断编译
        /// </summary>
        private string m_strAssemblyDirectory = "Scripts/";
        #endregion
        /// <summary>
        /// 主服务程序的编译出现警告时是否中断编译
        /// </summary>
        public string AssemblyDirectory
        {
            get { return m_strAssemblyDirectory; }
            set
            {
                if ( value == null )
                    return;
                
                m_strAssemblyDirectory = value;
                m_bIsChangeAssemblyDirectory = true;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主服务程序的编译出现警告时是否中断编译
        /// </summary>
        private string m_strScriptDirectory = "../Scripts/";
        #endregion
        /// <summary>
        /// 主服务程序的编译出现警告时是否中断编译
        /// </summary>
        public string ScriptDirectory
        {
            get { return m_strScriptDirectory; }
            set
            {
                if ( value == null )
                    return;
                
                m_strScriptDirectory = value;
                m_bIsChangeScriptDirectory = true;
            }
        }
        #endregion

        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 日志输出的文件名的变量是否已经改变
        /// </summary>
        private bool m_bIsChangeLogFile = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeLogFile
        {
            get { return m_bIsChangeLogFile; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主服务程序是否正在调试状态的变量是否已经改变
        /// </summary>
        private bool m_bIsChangeDebug = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeDebug
        {
            get { return m_bIsChangeDebug; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主服务程序是否具有服务日志的变量是否已经改变
        /// </summary>
        private bool m_bIsChangeService = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeService
        {
            get { return m_bIsChangeService; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否开始对软件进行性能测试和统计的变量是否已经改变
        /// </summary>
        private bool m_bIsChangeProfiling = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeProfiling
        {
            get { return m_bIsChangeProfiling; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 程序是否使用缓存的程序集的变量是否已经改变
        /// </summary>
        private bool m_bIsChangeCache = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeCache
        {
            get { return m_bIsChangeCache; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 主服务程序的编译出现警告时是否中断编译的变量是否已经改变
        /// </summary>
        private bool m_bIsChangeHaltOnWarning = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeHaltOnWarning
        {
            get { return m_bIsChangeHaltOnWarning; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 开启游戏世界的服务的线程数的变量是否已经改变
        /// </summary>
        private bool m_bIsChangeWorldThreadCount = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeWorldThreadCount
        {
            get { return m_bIsChangeWorldThreadCount; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否已经初始化网络模块
        /// </summary>
        private bool m_bIsChangeServerNetConfig = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeServerNetConfig
        {
            get { return m_bIsChangeServerNetConfig; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否已经初始化网络模块
        /// </summary>
        private bool m_bIsChangeClientNetConfig = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeClientNetConfig
        {
            get { return m_bIsChangeClientNetConfig; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否已经初始化网络模块
        /// </summary>
        private bool m_bIsChangeAssemblyDirectory = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeAssemblyDirectory
        {
            get { return m_bIsChangeAssemblyDirectory; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否已经初始化网络模块
        /// </summary>
        private bool m_bIsChangeScriptDirectory = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsChangeScriptDirectory
        {
            get { return m_bIsChangeScriptDirectory; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 内部成员变量 | en Internal Member Variables
        /// <summary>
        /// 
        /// </summary>
        internal int m_iServerCachedSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iServerBufferSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iServerManageThreadPoolSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iServerSendThreadPoolSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iServerReceiveThreadPoolSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iServerProcessThreadPoolSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iServerMaxClients = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iServerOutTimeInterval = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ServerCachedSize"></param>
        /// <param name="ServerBufferSize"></param>
        /// <param name="ServerManageThreadPoolSize"></param>
        /// <param name="ServerSendThreadPoolSize"></param>
        /// <param name="ServerReceiveThreadPoolSize"></param>
        /// <param name="ServerProcessThreadPoolSize"></param>
        /// <param name="ServerMaxClients"></param>
        /// <param name="ServerOutTimeInterval"></param>
        public void SetServerNetConfig( int ServerCachedSize, int ServerBufferSize, int ServerManageThreadPoolSize, int ServerSendThreadPoolSize, int ServerReceiveThreadPoolSize, int ServerProcessThreadPoolSize, int ServerMaxClients, int ServerOutTimeInterval )
        {
            m_iServerCachedSize             = ServerCachedSize;
            m_iServerBufferSize             = ServerBufferSize;
            m_iServerManageThreadPoolSize   = ServerManageThreadPoolSize;
            m_iServerSendThreadPoolSize     = ServerSendThreadPoolSize;
            m_iServerReceiveThreadPoolSize  = ServerReceiveThreadPoolSize;
            m_iServerProcessThreadPoolSize  = ServerProcessThreadPoolSize;
            m_iServerMaxClients             = ServerMaxClients;
            m_iServerOutTimeInterval        = ServerOutTimeInterval;

            m_bIsChangeServerNetConfig   = true;
        }

        #region zh-CHS 内部成员变量 | en Internal Member Variables
        /// <summary>
        /// 
        /// </summary>
        internal int m_iClientCachedSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iClientBufferSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iClientManageThreadPoolSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iClientSendThreadPoolSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iClientReceiveThreadPoolSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iClientProcessThreadPoolSize = 0;
        /// <summary>
        /// 
        /// </summary>
        internal int m_iClientOutTimeInterval = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClientCachedSize"></param>
        /// <param name="ClientBufferSize"></param>
        /// <param name="ClientManageThreadPoolSize"></param>
        /// <param name="ClientSendThreadPoolSize"></param>
        /// <param name="ClientReceiveThreadPoolSize"></param>
        /// <param name="ClientProcessThreadPoolSize"></param>
        /// <param name="ClientOutTimeInterval"></param>
        public void SetClientNetConfig( int ClientCachedSize, int ClientBufferSize, int ClientManageThreadPoolSize, int ClientSendThreadPoolSize, int ClientReceiveThreadPoolSize, int ClientProcessThreadPoolSize, int ClientOutTimeInterval )
        {
            m_iClientCachedSize = ClientCachedSize;
            m_iClientBufferSize = ClientBufferSize;
            m_iClientManageThreadPoolSize = ClientManageThreadPoolSize;
            m_iClientSendThreadPoolSize = ClientSendThreadPoolSize;
            m_iClientReceiveThreadPoolSize = ClientReceiveThreadPoolSize;
            m_iClientProcessThreadPoolSize = ClientProcessThreadPoolSize;
            m_iClientOutTimeInterval = ClientOutTimeInterval;

            m_bIsChangeClientNetConfig = true;
        }
        #endregion
    }
}
#endregion