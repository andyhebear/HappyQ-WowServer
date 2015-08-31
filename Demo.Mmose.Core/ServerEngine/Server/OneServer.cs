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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Demo.Mmose.Core.AIEngine;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.EventSkin;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Scripts;
using Demo.Mmose.Core.Server.Language;
using Demo.Mmose.Core.Timer;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.World;
#endregion

namespace Demo.Mmose.Core.Server
{
    /// <summary>
    /// 主服务程序(全局唯一)
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都是静态,支持多线程操作")]
    public static class OneServer
    {
        #region zh-CHS 共有常量 | en Public Constants
        /// <summary>
        /// 是否是64位系统
        /// </summary>
        public static readonly bool Is64Bit     = (IntPtr.Size == 8);

        /// <summary>
        /// 
        /// </summary>
        public static IntPtr ConsoleHwnd       = GetConsoleWindow();
        #endregion

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 服务端的配置是否需要改变的类
        /// </summary>
        private static ConfigServer s_ConfigServer = new ConfigServer();
        #endregion

        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 给出整个服务的世界
        /// </summary>
        private static BaseWorld[] s_WorldArray = new BaseWorld[0];
        #endregion
        /// <summary>
        /// 给出整个服务的世界
        /// </summary>
        public static BaseWorld[] World
        {
            get { return s_WorldArray; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Version s_Version = new Version();
        #endregion
        /// <summary>
        /// 服务程序的版本号
        /// </summary>
        public static Version Version
        {
            get { return s_Version; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static bool s_MultiProcessor = false;
        #endregion
        /// <summary>
        /// 硬件是否是多处理器
        /// </summary>
        public static bool MultiProcessor
        {
            get { return s_MultiProcessor; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static int s_ProcessorCount = 1;
        #endregion
        /// <summary>
        /// 硬件处理器的数量
        /// </summary>
        public static int ProcessorCount
        {
            get { return s_ProcessorCount; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Assembly s_Assembly  = null;
        #endregion
        /// <summary>
        /// 主服务程序集
        /// </summary>
        public static Assembly Assembly
        {
            get { return s_Assembly; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static string s_ExePath = string.Empty;
        #endregion
        /// <summary>
        /// 主服务程序的全部路径
        /// </summary>
        public static string ExePath
        {
            get { return s_ExePath; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static string s_BaseDirectory = string.Empty;
        #endregion
        /// <summary>
        /// 主服务程序的路径
        /// </summary>
        public static string BaseDirectory
        {
            get { return s_BaseDirectory; }
        }

        /// <summary>
        /// 主服务程序的参数的字符串信息
        /// </summary>
        public static string Arguments
        {
            get
            {
                StringBuilder strBuilder = new StringBuilder();

                if ( Debug == true )
                    ConvertString.Concat( ref strBuilder, "-Debug", " " );

                if ( Service == true )
                    ConvertString.Concat( ref strBuilder, "-Service", " " );

                if ( Profiling == true )
                    ConvertString.Concat( ref strBuilder, "-Profile", " " );

                if ( s_Cache == false )
                    ConvertString.Concat( ref strBuilder, "-NoCache", " " );

                if ( HaltOnWarning == true )
                    ConvertString.Concat( ref strBuilder, "-HaltOnWarning", " " );

                return strBuilder.ToString();
            }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 主服务程序是否正在程序关闭中...
        /// </summary>
        private static bool s_Closing = false;
        #endregion
        /// <summary>
        /// 主服务程序是否正在程序关闭中...
        /// </summary>
        public static bool Closing
        {
            get { return s_Closing; }
            set
            {
                if ( s_Closing == value )
                    return;
                else
                    s_Closing = value;

                if ( s_Closing == true )
                    ExitProgram();
            }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static bool s_Debug = false;
        #endregion
        /// <summary>
        /// 主服务程序是否正在调试状态
        /// </summary>
        public static bool Debug
        {
            get { return s_Debug; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 程序是否使用缓存的程序集
        /// </summary>
        private static bool s_Cache = true;
        #endregion
        /// <summary>
        /// 程序是否使用缓存的程序集
        /// </summary>
        public static bool Cache
        {
            get { return s_Cache; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static bool s_HaltOnWarning = false;
        #endregion
        /// <summary>
        /// 主服务程序的编译出现警告时是否中断编译
        /// </summary>
        public static bool HaltOnWarning
        {
            get { return s_HaltOnWarning; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static MultiTextWriter s_MultiConOut = new MultiTextWriter( Console.Out );
        #endregion
        /// <summary>
        /// 主服务程序的控制台调试输出服务信息
        /// </summary>
        public static MultiTextWriter MultiConsoleOut
        {
            get { return s_MultiConOut; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Process s_Process = Process.GetCurrentProcess();
        #endregion
        /// <summary>
        /// 主服务程序的本地系统进程
        /// </summary>
        public static Process Process
        {
            get { return s_Process; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static bool s_Service   = false;
        #endregion
        /// <summary>
        /// 主服务程序是否具有服务日志
        /// </summary>
        public static bool Service
        { 
            get { return s_Service; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static System.Threading.Thread s_Thread = System.Threading.Thread.CurrentThread;
        #endregion
        /// <summary>
        /// 主服务程序的主核心线程
        /// </summary>
        public static System.Threading.Thread Thread
        {
            get { return s_Thread; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 是否开始对软件进行性能测试和统计
        /// </summary>
        private static bool s_Profiling = false;
        /// <summary>
        /// 性能测试和统计开始的时间
        /// </summary>
        private static DateTime s_ProfileStart = DateTime.MinValue;
        #endregion
        /// <summary>
        /// 是否用来对软件进行性能测试和统计的过程
        /// </summary>
        public static bool Profiling
        {
            get { return s_Profiling; }
            set
            {
                if ( s_Profiling == value )
                    return;
                else
                    s_Profiling = value;

                // 计算已经统计了的时间长度(如果 s_Profiling == true 的话)
                if ( s_ProfileStart > DateTime.MinValue )
                    s_ProfileTime += DateTime.Now - s_ProfileStart;

                // 统计开始的时间
                s_ProfileStart = ( s_Profiling == true ? DateTime.Now : DateTime.MinValue );
            }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 性能测试和统计经过的总时间
        /// </summary>
        private static TimeSpan s_ProfileTime = TimeSpan.Zero;
        #endregion
        /// <summary>
        /// 性能测试和统计经过的总时间
        /// </summary>
        public static TimeSpan ProfileTime
        {
            get { return s_ProfileTime; }
        }
        #endregion

        #region zh-CHS 私有静态方法 | en Private Static Method
        /// <summary>
        /// 0) 初始化语言
        /// 1) 初始化程序的主要信息(核心(主)线程,进程,程序域,程序目录)
        /// 2) 检测程序实例是否在运行
        /// 3) 初始化程序域的异常错误处理
        /// 4) 获取运行程序的参数处理
        /// 5) 程序详细内容的信息显示
        /// 6) 初始化脚本的编译
        /// 7) 创建世界 运行世界(多线程处理)
        /// 8) 开始命令行(额外的线程处理)
        /// </summary>
        private static bool InsideRunServer( string[] args )
        {
            InitLanguage( args );

            InitServerMainInfo();

            InitServerIsRun();

            InitServerExceptionDisposal();

            InitServerArgumentsDisposal( args );

            DisplayServerMainInfo();

            if ( InitServerScriptCompiler() == false )
                return false;

            InitServerWorld();

            StartServerCommandlinesDisposal();

            return true;
        }

        /// <summary>
        /// 0) 初始化语言
        /// </summary>
        private static void InitLanguage( string[] args )
        {
            const string LANGUAGE = "-Language:";

            string strLanguage = string.Empty;
            for ( int iIndex = 0; iIndex < args.Length; iIndex++ )
            {
                string itemLanguage = args[iIndex];

                if ( Insensitive.StartsWith( itemLanguage, LANGUAGE ) == true )
                {
                    string strLanguageFile = itemLanguage.Substring( LANGUAGE.Length );

                    if ( File.Exists( strLanguageFile ) == true )
                        strLanguage = strLanguageFile;

                    break;
                }
            }

            LanguageString.LoadLanguageFromAssembly( strLanguage );
        }
        
        /// <summary>
        /// 1) 初始化程序的主要信息(核心(主)线程,进程,程序域,程序目录)
        /// </summary>
        private static void InitServerMainInfo()
        {
            s_Process = Process.GetCurrentProcess();
            s_Assembly = Assembly.GetEntryAssembly();
            s_Version = s_Assembly.GetName().Version;

            s_ExePath = s_Assembly.Location;
            s_BaseDirectory = s_ExePath;
            if ( s_BaseDirectory.Length > 0 )
            {
                s_BaseDirectory = Path.GetDirectoryName( s_BaseDirectory );
                Directory.SetCurrentDirectory( BaseDirectory );
            }

            s_Thread = Thread.CurrentThread;
            if ( s_Thread != null )
                s_Thread.Name = LanguageString.SingletonInstance.OneServerString001;

            s_ProcessorCount = Environment.ProcessorCount;
            if ( s_ProcessorCount > 1 )
                s_MultiProcessor = true;
        }

        /// <summary>
        /// 2) 检测程序实例是否在运行
        /// </summary>
        private static void InitServerIsRun()
        {
            Process[] processArray = Process.GetProcessesByName( Path.GetFileNameWithoutExtension( s_ExePath ) );
            while ( processArray.Length > 1 )
            {
                LOGs.WriteLine( LogMessageType.MSG_WARNING, LanguageString.SingletonInstance.OneServerString002 );

                if ( processArray[0].Id == Process.GetCurrentProcess().Id )
                    processArray[1].WaitForExit();
                else
                    processArray[0].WaitForExit();

                processArray = Process.GetProcessesByName( Path.GetFileNameWithoutExtension( s_ExePath ) );
                if ( processArray.Length == 1 )
                    break;
            }
        }

        #region zh-CHS 私有静态方法 | en Private Static Methods
        /// <summary>
        /// 去除关闭按扭
        /// </summary>
        private static void RemoveSystemCloseMenu()
        {
            const int SC_CLOSE = 0xF060;

            IntPtr closeMenu = GetSystemMenu( ConsoleHwnd, IntPtr.Zero );
            RemoveMenu( closeMenu, SC_CLOSE, 0x0 );
            DrawMenuBar( OneServer.ConsoleHwnd );
        }
        #endregion
        /// <summary>
        /// 3) 初始化程序域的异常错误处理
        /// </summary>
        private static void InitServerExceptionDisposal()
        {
            // 未知的异常处理
            AppDomain.CurrentDomain.UnhandledException  += new UnhandledExceptionEventHandler( CurrentDomain_UnhandledException );
            // 程序终止退出处理
            AppDomain.CurrentDomain.ProcessExit         += new EventHandler( CurrentDomain_ProcessExit );
            // 控制台按(Ctrl+C)处理
            Console.CancelKeyPress += new ConsoleCancelEventHandler( Console_CancelKeyPress );
            // 去除关闭按扭
            RemoveSystemCloseMenu();
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static FileLogger s_FileLogger = null;
        #endregion
        /// <summary>
        /// 4) 获取运行程序的参数处理
        /// </summary>
        private static void InitServerArgumentsDisposal(string[] args)
        {
            // 完成服务端的基本初始设置后,配置OneServer一次
            if ( EventConfigServer != null )
                EventConfigServer( ref s_ConfigServer );

            if ( s_ConfigServer.IsChangeDebug == true )
                s_Debug = s_ConfigServer.Debug;

            if ( s_ConfigServer.IsChangeService == true )
                s_Service = s_ConfigServer.Service;

            if ( s_ConfigServer.IsChangeProfiling == true )
                s_Profiling = s_ConfigServer.Profiling;

            if ( s_ConfigServer.IsChangeCache == true )
                s_Cache = s_ConfigServer.Cache;

            if ( s_ConfigServer.IsChangeHaltOnWarning == true )
                s_HaltOnWarning = s_ConfigServer.HaltOnWarning;

            // 初始化
            if ( s_ConfigServer.IsChangeServerNetConfig == true )
                Mmose.Net.Server.Init( s_ConfigServer.m_iServerCachedSize, s_ConfigServer.m_iServerBufferSize, s_ConfigServer.m_iServerManageThreadPoolSize, s_ConfigServer.m_iServerSendThreadPoolSize, s_ConfigServer.m_iServerReceiveThreadPoolSize, s_ConfigServer.m_iServerProcessThreadPoolSize, s_ConfigServer.m_iServerMaxClients, s_ConfigServer.m_iServerOutTimeInterval );
            else
                Mmose.Net.Server.InitDefault();

            // 初始化
            if ( s_ConfigServer.IsChangeClientNetConfig == true )
                Mmose.Net.Client.Init( s_ConfigServer.m_iClientCachedSize, s_ConfigServer.m_iClientBufferSize, s_ConfigServer.m_iClientManageThreadPoolSize, s_ConfigServer.m_iClientSendThreadPoolSize, s_ConfigServer.m_iClientReceiveThreadPoolSize, s_ConfigServer.m_iClientProcessThreadPoolSize, s_ConfigServer.m_iClientOutTimeInterval );
            else
                Mmose.Net.Client.InitDefault();

            for ( int iIndex = 0; iIndex < args.Length; iIndex++ )
            {
                string strArg = args[iIndex];

                if ( Insensitive.Equals( strArg, "-Debug" ) )
                    s_Debug = true;
                else if ( Insensitive.Equals( strArg, "-Service" ) )
                    s_Service = true;
                else if ( Insensitive.Equals( strArg, "-Profile" ) )
                    s_Profiling = true;
                else if ( Insensitive.Equals( strArg, "-NoCache" ) )
                    s_Cache = false;
                else if ( Insensitive.Equals( strArg, "-HaltOnWarning" ) )
                    s_HaltOnWarning = true;
            }

            if ( s_Service == true )
            {
                if ( Directory.Exists( "../Logs" ) == false )
                    Directory.CreateDirectory( "../Logs" );

                if ( s_ConfigServer.IsChangeLogFile )
                    s_FileLogger = new FileLogger( "../Logs/" + s_ConfigServer.LogFile );
                else
                    s_FileLogger = new FileLogger( "../Logs/Console.log" );

                Console.SetOut( s_MultiConOut = new MultiTextWriter( Console.Out, s_FileLogger ) );
            }
            else
                Console.SetOut( s_MultiConOut = new MultiTextWriter( Console.Out ) );
        }

        #region zh-CHS 显示Ascii字符串 | en Display Ascii
        /// <summary>
        /// 
        /// </summary>
        private static void DisplayAscii0()
        {
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                         " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                         " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @" _______     _______     _______     _______     _______ " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"(       )   (       )   (  ___  )   (  ____ \   (  ____ \" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"| () () |   | () () |   | (   ) |   | (    \/   | (    \/" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"| || || |   | || || |   | |   | |   | (_____    | (__    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"| |(_)| |   | |(_)| |   | |   | |   (_____  )   |  __)   " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"| |   | |   | |   | |   | |   | |         ) |   | (      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"| )   ( | _ | )   ( | _ | (___) | _ /\____) | _ | (____/\" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"|/     \|(_)|/     \|(_)(_______)(_)\_______)(_)(_______/" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                         " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                         " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                 http://www.MMO8848.com                  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                         " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                         " );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayAscii1()
        {
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"      ___           ___           ___           ___           ___     " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     /  /\         /  /\         /  /\         /  /\         /  /\    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"    /  /::|       /  /::|       /  /::\       /  /::\       /  /::\   " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"   /  /:|:|      /  /:|:|      /  /:/\:\     /__/:/\:\     /  /:/\:\  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"  /  /:/|:|__   /  /:/|:|__   /  /:/  \:\   _\_ \:\ \:\   /  /::\ \:\ " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @" /__/:/_|::::\ /__/:/_|::::\ /__/:/ \__\:\ /__/\ \:\ \:\ /__/:/\:\ \:\" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @" \__\/  /~~/:/ \__\/  /~~/:/ \  \:\ /  /:/ \  \:\ \:\_\/ \  \:\ \:\_\/" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"       /  /:/        /  /:/   \  \:\  /:/   \  \:\_\:\    \  \:\ \:\  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"      /  /:/        /  /:/     \  \:\/:/     \  \:\/:/     \  \:\_\/  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     /__/:/        /__/:/       \  \::/       \  \::/       \  \:\    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     \__\/         \__\/         \__\/         \__\/         \__\/    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                        http://www.MMO8848.com                        " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayAscii2()
        {
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"      ___           ___           ___           ___           ___     " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     /\__\         /\__\         /\  \         /\  \         /\  \    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"    /::|  |       /::|  |       /::\  \       /::\  \       /::\  \   " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"   /:|:|  |      /:|:|  |      /:/\:\  \     /:/\ \  \     /:/\:\  \  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"  /:/|:|__|__   /:/|:|__|__   /:/  \:\  \   _\:\~\ \  \   /::\~\:\  \ " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @" /:/ |::::\__\ /:/ |::::\__\ /:/__/ \:\__\ /\ \:\ \ \__\ /:/\:\ \:\__\" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @" \/__/~~/:/  / \/__/~~/:/  / \:\  \ /:/  / \:\ \:\ \/__/ \:\~\:\ \/__/" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"       /:/  /        /:/  /   \:\  /:/  /   \:\ \:\__\    \:\ \:\__\  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"      /:/  /        /:/  /     \:\/:/  /     \:\/:/  /     \:\ \/__/  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     /:/  /        /:/  /       \::/  /       \::/  /       \:\__\    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     \/__/         \/__/         \/__/         \/__/         \/__/    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                        http://www.MMO8848.com                        " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayAscii3()
        {
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"      ___           ___           ___           ___           ___     " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     /__/\         /__/\         /  /\         /  /\         /  /\    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"    |  |::\       |  |::\       /  /::\       /  /:/_       /  /:/_   " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"    |  |:|:\      |  |:|:\     /  /:/\:\     /  /:/ /\     /  /:/ /\  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"  __|__|:|\:\   __|__|:|\:\   /  /:/  \:\   /  /:/ /::\   /  /:/ /:/_ " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @" /__/::::| \:\ /__/::::| \:\ /__/:/ \__\:\ /__/:/ /:/\:\ /__/:/ /:/ /\" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @" \  \:\~~\__\/ \  \:\~~\__\/ \  \:\ /  /:/ \  \:\/:/~/:/ \  \:\/:/ /:/" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"  \  \:\        \  \:\        \  \:\  /:/   \  \::/ /:/   \  \::/ /:/ " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"   \  \:\        \  \:\        \  \:\/:/     \__\/ /:/     \  \:\/:/  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"    \  \:\        \  \:\        \  \::/        /__/:/       \  \::/   " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     \__\/         \__\/         \__\/         \__\/         \__\/    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                        http://www.MMO8848.com                        " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayAscii4()
        {
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"      ___           ___           ___           ___           ___     " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     /\  \         /\  \         /\  \         /\__\         /\__\    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"    |::\  \       |::\  \       /::\  \       /:/ _/_       /:/ _/_   " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"    |:|:\  \      |:|:\  \     /:/\:\  \     /:/ /\  \     /:/ /\__\  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"  __|:|\:\  \   __|:|\:\  \   /:/  \:\  \   /:/ /::\  \   /:/ /:/ _/_ " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @" /::::|_\:\__\ /::::|_\:\__\ /:/__/ \:\__\ /:/_/:/\:\__\ /:/_/:/ /\__\" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @" \:\~~\  \/__/ \:\~~\  \/__/ \:\  \ /:/  / \:\/:/ /:/  / \:\/:/ /:/  /" );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"  \:\  \        \:\  \        \:\  /:/  /   \::/ /:/  /   \::/_/:/  / " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"   \:\  \        \:\  \        \:\/:/  /     \/_/:/  /     \:\/:/  /  " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"    \:\__\        \:\__\        \::/  /        /:/  /       \::/  /   " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"     \/__/         \/__/         \/__/         \/__/         \/__/    " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                        http://www.MMO8848.com                        " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
            LOGs.WriteLine( LogMessageType.MSG_INFO, @"                                                                      " );
        }
        #endregion
        /// <summary>
        /// 5) 程序详细内容的信息显示
        /// </summary>
        private static void DisplayServerMainInfo()
        {
            switch ( RandomEx.Random( 5 ) )
            {
                case 1:
                    DisplayAscii1();
                    break;
                case 2:
                    DisplayAscii2();
                    break;
                case 3:
                    DisplayAscii3();
                    break;
                case 4:
                    DisplayAscii4();
                    break;
                default:
                    DisplayAscii0();
                    break;
            }

            LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.OneServerString003, Version.Major, Version.Minor, Version.Build, Version.Revision );

            LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.OneServerString004, Environment.Version.Major, Environment.Version.Minor, Environment.Version.Build );

            string strArguments = Arguments;
            if ( strArguments.Length > 0 )
                LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.OneServerString005, strArguments );

            if ( s_MultiProcessor || Is64Bit )
                LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.OneServerString006, s_ProcessorCount, Is64Bit ? "64-系统" : "32-系统" );
        }

        /// <summary>
        /// 6) 初始化脚本的编译
        /// </summary>
        private static bool InitServerScriptCompiler()
        {
            while ( ScriptCompiler.Compile( s_Debug, s_Cache, s_ConfigServer.AssemblyDirectory, s_ConfigServer.ScriptDirectory ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.OneServerString007 );
                LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.OneServerString008 );

                if ( Console.ReadKey( true ).Key != ConsoleKey.R )
                    return false;
            }

            return true;
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static volatile bool s_bIsInitWorld = false;
        #endregion
        /// <summary>
        /// 7) 创建世界 运行世界(多线程处理)
        /// </summary>
        private static void InitServerWorld()
        {
            // 完成服务端的设置以后,在开始时初始化一次OneServer
            if ( EventInitOnceServer != null )
                EventInitOnceServer();

            // 启动处理时间片的主线程
            TimerThread.StartTimerThread();

            // 启动处理AI系统的主线程
            CreatureAIThread.StartCreatureAIThread();

            foreach ( BaseWorld world in s_WorldArray )
            {
                // 创建World运行世界的线程
                if ( s_ConfigServer.IsChangeWorldThreadCount == true )
                    world.StartThreadPool( s_ConfigServer.WorldThreadCount );
                else
                    world.StartThreadPool( OneServer.ProcessorCount * 2 + 2 );

                // 在开始运行世界之前,初始化一次BaseWorld
                world.OnInitOnce();

                // 启动BaseWorld保存数据的时间片
                world.StartSaveTimeSlice();

                // 初始化网络客户端在线状态的检查
                world.StartCheckAllAliveTime();
            }

            s_bIsInitWorld = true;
        }

        /// <summary>
        /// 8) 开始命令行(在主线程处理)
        /// </summary>
        private static void StartServerCommandlinesDisposal()
        {
            const string DOS_PROMPT = "MMOSE:>";

            while ( s_Closing == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_DOS_PROMPT, DOS_PROMPT );

                ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                StringBuilder strStringBuilder = new StringBuilder();
                string strReadLine = string.Empty;
                do
                {
                    keyInfo = Console.ReadKey( false );

                    // 再次检测程序已经运行
                    if ( s_Closing == true )
                        break;

                    // 回车
                    if ( keyInfo.Key == ConsoleKey.Enter )
                    {
                        strReadLine = strStringBuilder.ToString();
                        strStringBuilder.Remove( 0, strStringBuilder.Length );

                        // 如果输入的键值不为空
                        if ( strReadLine != string.Empty )
                        {
                            LOGs.WriteLine( LogMessageType.MSG_INPUT, string.Empty );
                            break;
                        } else continue;
                    }

                    // 退格
                    if ( keyInfo.Key == ConsoleKey.Backspace )
                    {
                        if ( strStringBuilder.Length > 0 )
                            strStringBuilder.Remove( strStringBuilder.Length - 1, 1 );
                        else continue;
                    }
                    else
                    {
                        // 跳过无效的健值
                        if ( ( (int)keyInfo.Key > 19 && (int)keyInfo.Key < 47 ) == false )
                        {
                            // 最多 255 个有效的字符
                            if ( strStringBuilder.Length < 255 )
                                strStringBuilder.Append( keyInfo.KeyChar );
                            else continue;
                        }
                    }

                    strReadLine = strStringBuilder.ToString();
                    LOGs.WriteLine( LogMessageType.MSG_INPUT, strReadLine );

                } while ( true );

                if ( strReadLine == string.Empty )
                    continue;

                switch ( strReadLine.ToLower() )
                {
                    case "restart":
                    case "-restart":
                        LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString009, strReadLine );
                        {
                            s_Closing = true;
                            RestartProgram();
                        }
                        break;
                    case "closelog":
                    case "-closelog":
                        if ( s_FileLogger == null )
                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString010, strReadLine );
                        else
                        {
                            if ( s_FileLogger.IsLogFile == true )
                            {
                                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString011, strReadLine );
                                s_FileLogger.IsLogFile = false;
                            }
                            else
                                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString012, strReadLine );
                        }
                        break;
                    case "openlog":
                    case "-openlog":
                        if ( s_FileLogger == null )
                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString013, strReadLine );
                        else
                        {
                            if ( s_FileLogger.IsLogFile == false )
                            {
                                s_FileLogger.IsLogFile = true;
                                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString014, strReadLine );
                            }
                            else
                                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString015, strReadLine );
                        }
                        break;
                    case "timeinfo":
                    case "-timeinfo":
                        LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString016, strReadLine );
                        {
                            TimerThread.DumpInfo();
                        }
                        break;
                    case "saveworld":
                    case "-saveworld":
                        LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString017, strReadLine );
                        {
                            foreach ( BaseWorld baseWorld in s_WorldArray )
                                baseWorld.OnSave();
                        }
                        break;
                    case "?":
                    case "h":
                    case "-?":
                    case "-h":
                    case "help":
                    case "-help":
                        LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString018, strReadLine );
                        {
                            if ( EventCommandLineInfo != null )
                                EventCommandLineInfo();

                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString019 );
                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString020 );
                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString021 );
                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString022 );
                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString023 );
                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString024 );
                            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString025 );
                        }
                        break;
                    case "quit":
                    case "-quit":
                        LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString026, strReadLine );
                        {
                            s_Closing = true;
                        }
                        break;
                    case "exit":
                    case "-exit":
                        LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString027, strReadLine );
                        {
                            s_Closing = true;
                        }
                        break;
                    default:
                        {
                            // EventCommandLineDisposal是否已经处理过了
                            bool bIsDisposal = false;
                            if ( EventCommandLineDisposal != null )
                                bIsDisposal = EventCommandLineDisposal( strReadLine );

                            if ( strReadLine != string.Empty && bIsDisposal == false )
                                LOGs.WriteLine( LogMessageType.MSG_WARNING, LanguageString.SingletonInstance.OneServerString028, strReadLine );
                        }
                        break;
                }
            }

            ExitProgram();
        }

        /// <summary>
        /// 重起系统,打开新的执行程序,关闭当前进程
        /// </summary>
        private static void ExitProgram()
        {
            // 停止全部的世界线程
            foreach ( BaseWorld world in s_WorldArray )
                world.StopThreadPool();    // 停止世界线程

            // 等待内部全部的线程结束
            WaitAllRegisterThreadExit();

            // 在结束世界之前,调用一次
            foreach ( BaseWorld world in s_WorldArray )
            {
                // 在结束世界之前,保存一次数据
                world.OnSave();
                world.OnExit();
            }

            // 在结束服务端之前,调用一次
            if ( EventExitServer != null )
                EventExitServer();

            // 释放
            Mmose.Net.Client.Fini();
            Mmose.Net.Server.Fini();
        }

        /// <summary>
        /// 重起系统,打开新的执行程序,关闭当前进程
        /// </summary>
        private static void RestartProgram()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Process.Start( Path.GetFileName( s_ExePath ) );
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 当某个线程结束时调用
        /// </summary>
        private static AutoResetEvent s_ExitSignal = new AutoResetEvent( true );
        #endregion
        /// <summary>
        /// 等待全部的线程关闭
        /// </summary>
        private static void WaitAllRegisterThreadExit()
        {
            while ( s_RegisteredThreadCount > 0 )
            {
                // 调用事件告诉一些线程程序将要关闭
                BaseWorld[] tempWorldArray = s_WorldArray;
                for ( int iIndex = 0; iIndex < tempWorldArray.Length; iIndex++ )
                    tempWorldArray[iIndex].SetWorldSignal();

                // 等待线程关闭的事件
                s_ExitSignal.WaitOne( 10, false );
            }

            LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.OneServerString029 );
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 表示程序是否是异常退出的
        /// </summary>
        private volatile static bool s_IsTerminating   = false;
        #endregion
        /// <summary>
        /// 未知的异常处理
        /// </summary>
        private static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs eventArgs )
        {
            LOGs.WriteLine( LogMessageType.MSG_FATALERROR, eventArgs.IsTerminating ? LanguageString.SingletonInstance.OneServerString030 : LanguageString.SingletonInstance.OneServerString031 );
            LOGs.WriteLine( LogMessageType.MSG_FATALERROR, eventArgs.ExceptionObject.ToString() );

            if ( eventArgs.IsTerminating )
            {
                s_IsTerminating = true;

                try
                {
                    GlobalEvent.OneServer.InvokeCrashed( eventArgs.ExceptionObject as Exception );

                    // foreach数组操作,在多线程中不怕被替换掉(s_BaseWorld),它不同于列表的操作
                    foreach ( BaseWorld baseWorld in s_WorldArray )
                    {
                        foreach ( MessagePump messagePump in baseWorld.MessagePump )
                        {
                            foreach ( Listener listener in messagePump.Listeners )
                                listener.Dispose();

                            foreach ( Connecter connecter in messagePump.Connecters )
                                connecter.Dispose();
                        }
                    }
                }
                catch { }

                s_Closing = true;

                LOGs.WriteLine( LogMessageType.MSG_FATALERROR, LanguageString.SingletonInstance.OneServerString032 );
                Console.ReadKey( false );
            }
        }

        /// <summary>
        /// 程序终止退出处理
        /// </summary>
        private static void CurrentDomain_ProcessExit( object sender, EventArgs eventArgs )
        {
            LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.OneServerString033 );

            // 如果不是异常的关闭
            if ( s_IsTerminating == false )
            {
                try
                {
                    GlobalEvent.OneServer.InvokeShutdown();
                } catch { }
            }

            LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.OneServerString034 );
        }

        /// <summary>
        /// 控制台按(Ctrl+C)处理
        /// </summary>
        private static void Console_CancelKeyPress( object sender, ConsoleCancelEventArgs eventArgs )
        {

            // 阻止 控制台键 (Ctrl+C) 。
            // 无法阻止 控制台键 (Ctrl+Break 无效)
            if ( eventArgs.SpecialKey == ConsoleSpecialKey.ControlC /* ||
                e.SpecialKey == ConsoleSpecialKey.ControlBreak */
                                                                  )
                eventArgs.Cancel = true;
        }
        #endregion

        #region zh-CHS 内部静态方法 | en Internal Private Static Method
        /// <summary>
        /// 给全部的游戏世界发出信号
        /// </summary>
        internal static void SetAllWorldSignal()
        {
            BaseWorld[] tempWorldArray = s_WorldArray;
            for ( int iIndex = 0; iIndex < tempWorldArray.Length; iIndex++ )
                tempWorldArray[iIndex].SetWorldSignal();
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 共在OneServer中注册的线程数
        /// </summary>
        private static int s_RegisteredThreadCount = 0;
        #endregion
        /// <summary>
        /// 当启动某个新的线程时候需要注册入OneServer(告诉OneServer有新的线程已启动)
        /// </summary>
        internal static void BeginRegisterThread()
        {
            Interlocked.Increment( ref s_RegisteredThreadCount );
        }

        /// <summary>
        /// 当关闭某个新的线程时候需要反注册OneServer(告诉OneServer有个的线程已停止)
        /// </summary>
        internal static void EndRegisterThread()
        {
            Interlocked.Decrement( ref s_RegisteredThreadCount );

            // 发生注销线程的事件
            s_ExitSignal.Set();
        }

        /// <summary>
        /// 发生未知的异常(触发)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        internal static void UnhandledException( object sender, UnhandledExceptionEventArgs eventArgs )
        {
            CurrentDomain_UnhandledException( sender, eventArgs );
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Method
        /// <summary>
        /// 开始运行主服务架构程序
        /// </summary>
        /// <param name="args"></param>
        /// <param name="baseWorld"></param>
        /// <returns></returns>
        public static bool RunServer( string[] args, BaseWorld world )
        {
            if ( world == null )
                throw new Exception( "OneServer.RunServer(...) - world == null error!" );

            AddWorld( world );
            return InsideRunServer( args == null ? new string[0] : args );
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 只锁定添加操作(因为是数组,不会有添加和删除的操作,其它的地方就可以不用锁定)
        /// </summary>
        private static SpinLock s_OnlyLockAddRemove = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseWorld"></param>
        public static void AddWorld( BaseWorld world )
        {
            if ( world == null )
                throw new Exception( "OneServer.AddWorld(...) - world == null error!" );

            s_OnlyLockAddRemove.Enter();
            {
                // 创建新的MessagePump数组,添加数据,交换数组数据,不需要锁定,没有引用时自动会回收数据
                BaseWorld[] tempWorld = new BaseWorld[s_WorldArray.Length + 1];

                for ( int iIndex = 0; iIndex < s_WorldArray.Length; ++iIndex )
                    tempWorld[iIndex] = s_WorldArray[iIndex];
                tempWorld[s_WorldArray.Length] = world;

                s_WorldArray = tempWorld;
            }
            s_OnlyLockAddRemove.Exit();

            // 是否已经初始化过World了
            if ( s_bIsInitWorld == true )
            {
                // 创建World运行世界的线程
                if ( s_ConfigServer.IsChangeWorldThreadCount == true )
                    world.StartThreadPool( s_ConfigServer.WorldThreadCount );
                else
                    world.StartThreadPool( OneServer.ProcessorCount * 2 + 2 );

                // 在开始运行世界之前,初始化一次BaseWorld
                world.OnInitOnce();

                // 启动BaseWorld保存数据的时间片
                world.StartSaveTimeSlice();

                // 初始化网络客户端在线状态的检查
                world.StartCheckAllAliveTime();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseWorld"></param>
        public static void RemoveWorld( BaseWorld world )
        {
            if ( world == null )
                throw new Exception( "OneServer.RemoveWorld(...) - world == null error!" );

            BaseWorld matchWorld = null;

            s_OnlyLockAddRemove.Enter();
            {
                List<BaseWorld> worldList = new List<BaseWorld>();

                foreach ( BaseWorld itemWorld in worldList )
                {
                    if ( itemWorld != world )
                        worldList.Add( itemWorld );
                    else
                        matchWorld = world;
                }

                s_WorldArray = worldList.ToArray();
            }
            s_OnlyLockAddRemove.Exit();

            if ( matchWorld != null && s_bIsInitWorld == true )
            {
                // 停止世界线程
                matchWorld.StopThreadPool();

                // 停止保存数据的时间片
                world.StopSaveTimeSlice();

                // 停止网络客户端在线状态的检查
                world.StopCheckAllAliveTime();

                // 在结束世界之前,保存一次数据
                matchWorld.OnSave();
                matchWorld.OnExit();
            }
        }
        #endregion

        #region zh-CHS 共有静态事件 | en Public Static Event
        /// <summary>
        /// 主服务初始化时调用
        /// </summary>
        public static event InitOnceServerEventHandler EventInitOnceServer;
        /// <summary>
        /// 主服务退出时调用
        /// </summary>
        public static event ExitServerEventHandler EventExitServer;
        /// <summary>
        /// 主服务命令执行时调用
        /// </summary>
        public static event CommandLineDisposalEventHandler EventCommandLineDisposal;
        /// <summary>
        /// 主服务显示命令信息时调用
        /// </summary>
        public static event CommandLineInfoEventHandler EventCommandLineInfo;
        /// <summary>
        /// 配置主服务的内容时调用
        /// </summary>
        public static event ConfigServerEventHandler EventConfigServer;
        #endregion

        #region zh-CHS 引入DLL接口 | en DLL Import
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport( "kernel32.dll" )]
        private extern static IntPtr GetConsoleWindow();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="bRevert"></param>
        /// <returns></returns>
        [DllImport( "user32.dll" )]
        private extern static IntPtr GetSystemMenu( IntPtr hWnd, IntPtr bRevert );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMenu"></param>
        /// <param name="nPos"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport( "user32.dll" )]
        private extern static int RemoveMenu( IntPtr hMenu, int iPos, int iFlags );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport( "user32.dll" )]
        private extern static bool DrawMenuBar( IntPtr hWnd );
        #endregion
    }
}
#endregion