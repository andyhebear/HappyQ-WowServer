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
using System.IO;
using System.Text;
using System.Threading;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Common
{
    #region zh-CHS 枚举 | en Enum
    /// <summary>
    /// 
    /// </summary>
    public enum LogMessageType
    {
        MSG_NONE,
        MSG_STATUS,
        MSG_SQL,
        MSG_INFO,
        MSG_NOTICE,
        MSG_WARNING,
        MSG_DEBUG,
        MSG_ERROR,
        MSG_FATALERROR,
        MSG_HACK,
        MSG_LOAD,
        MSG_INPUT,
        MSG_DOS_PROMPT
    }
    #endregion

    /// <summary>
    /// 线程安全的日志
    /// </summary>
    public class LOGs
    {
        #region zh-CHS 内部类 | en Internal Class
        /// <summary>
        /// 
        /// </summary>
        private struct LogInfo
        {
            #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
            /// <summary>
            /// 
            /// </summary>
            /// <param name="tTimer"></param>
            /// <param name="newIndex"></param>
            /// <param name="isAdd"></param>
            public LogInfo( LogMessageType messageFlag, string strFormat, object[] parameter )
            {
                m_MessageFlag = messageFlag;
                m_strFormat = strFormat;
                m_Parameter = parameter;
            }
            #endregion

            #region zh-CHS 属性 | en Properties
            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private LogMessageType m_MessageFlag;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public LogMessageType MessageFlag
            {
                get { return m_MessageFlag; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private string m_strFormat;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public string Format
            {
                get { return m_strFormat; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private object[] m_Parameter;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public object[] Parameter
            {
                get { return m_Parameter; }
            }
            #endregion
        }
        #endregion

        #region zh-CHS 公开的函数 | en Class Public Methods
        /// <summary>
        /// 防止多线程的问题
        /// </summary>
        /// <param name="messageFlag"></param>
        /// <param name="strFormat"></param>
        public static void WriteLine( LogMessageType messageFlag, string strFormat )
        {
            WriteLine( messageFlag, strFormat, null );
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 当前需要处理的集合
        /// </summary>
        private static Queue<LogInfo> s_LogInfoQueue = new Queue<LogInfo>();
        /// <summary>
        /// 
        /// </summary>
        private static SpinLock s_LockLogInfoQueue = new SpinLock();
        /// <summary>
        /// 
        /// </summary>
        private static volatile bool s_IsLock = false;
        #endregion
        /// <summary>
        /// 防止多线程的问题
        /// </summary>
        /// <param name="messageFlag"></param>
        /// <param name="strFormat"></param>
        /// <param name="arg"></param>
        public static void WriteLine( LogMessageType messageFlag, string strFormat, params object[] arg )
        {
            bool bIsLock = false;

            s_LockLogInfoQueue.Enter();
            {
                s_LogInfoQueue.Enqueue( new LogInfo( messageFlag, strFormat, arg ) );

                // 检测是否有其它的线程已在处理中，如在使用就退出,否则开始锁定
                if ( s_IsLock == false )
                    bIsLock = s_IsLock = true;
            }
            s_LockLogInfoQueue.Exit();

            // 如果有其它的线程在处理就退出
            if ( bIsLock == false )
                return;

            LogInfo[] logInfoArray = null;
            do
            {
                logInfoArray = null;

                s_LockLogInfoQueue.Enter();
                {
                    if ( s_LogInfoQueue.Count > 0 )
                    {
                        logInfoArray = s_LogInfoQueue.ToArray();
                        s_LogInfoQueue.Clear();
                    }
                    else
                        s_IsLock = false; // 没有数据需要处理,释放锁定让其它的程序来继续处理
                }
                s_LockLogInfoQueue.Exit();

                if ( logInfoArray == null )
                    break;

                for ( int iIndex = 0; iIndex < logInfoArray.Length; iIndex++ )
                {
                    LogInfo logInfo = logInfoArray[iIndex];

                    if ( logInfo.Parameter == null )
                        InternalWriteLine( logInfo.MessageFlag, logInfo.Format );
                    else
                        InternalWriteLine( logInfo.MessageFlag, logInfo.Format, logInfo.Parameter );
                }
            } while ( logInfoArray != null );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="strFormat"></param>
        public static void WriteLineLogFile( string strFileName, string strFormat )
        {
            string strFilter = StringFilter( strFormat );
            if ( strFilter != string.Empty )
            {
                using ( StreamWriter writer = File.AppendText( strFileName ) )
                    writer.WriteLine( strFilter );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="strFormat"></param>
        /// <param name="arg"></param>
        public static void WriteLineLogFile( string strFileName, string strFormat, params object[] arg )
        {
            WriteLineLogFile( strFileName, string.Format( strFormat, arg ) );
        }
        #endregion

        #region zh-CHS 内部的函数 | en Class Internal Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static string s_strInput = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string s_strDosPrompt = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageFlag"></param>
        /// <param name="strFormat"></param>
        internal static void InternalWriteLine( LogMessageType messageFlag, string strFormat )
        {
            Console.Write( "\r" );

            switch (messageFlag)
            {
                case LogMessageType.MSG_NONE: // direct printf replacement
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write( "[NONE]: " );

                    break;
                case LogMessageType.MSG_STATUS:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write( "[STATUS]: " );

                    break;
                case LogMessageType.MSG_SQL:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write( "[SQL]: " );

                    break;
                case LogMessageType.MSG_INFO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write( "[INFO]: " );

                    break;
                case LogMessageType.MSG_NOTICE:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write( "[NOTICE]: " );

                    break;
                case LogMessageType.MSG_WARNING:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write( "[WARNING]: " );

                    break;
                case LogMessageType.MSG_DEBUG:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write( "[DEBUG]: " );

                    break;
                case LogMessageType.MSG_ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write( "[ERROR]: " );

                    break;
                case LogMessageType.MSG_FATALERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write( "[FATAL ERROR]: " );

                    break;
                case LogMessageType.MSG_HACK:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write( "[HACK]: " );

                    break;
                case LogMessageType.MSG_LOAD:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write( "[LOAD]: " );

                    break;
                case LogMessageType.MSG_DOS_PROMPT:
                    Console.ForegroundColor = ConsoleColor.Green;
                    s_strDosPrompt = strFormat;

                    break;
                case LogMessageType.MSG_INPUT:
                    if ( s_strDosPrompt != string.Empty )
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write( s_strDosPrompt );
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    s_strInput = strFormat;
                    break;

                default:
                    break;
            }

            if ( messageFlag == LogMessageType.MSG_DOS_PROMPT )
                Console.ForegroundColor = ConsoleColor.Green;
            else if ( messageFlag == LogMessageType.MSG_INPUT )
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.ForegroundColor = ConsoleColor.Gray;

            StringBuilder strStringBuilder = new StringBuilder( "" );

            if ( messageFlag != LogMessageType.MSG_DOS_PROMPT )
            {
                int iBlankLength = ( s_strDosPrompt.Length + s_strInput.Length ) - strFormat.Length;
                for ( int iIndex = 0; iIndex < iBlankLength; iIndex++ )
                    strStringBuilder.Append( " " );
                for ( int iIndex = 0; iIndex < iBlankLength; iIndex++ )
                    strStringBuilder.Append( "\b" );
            }

            Console.Write( strFormat + strStringBuilder );

            if ( messageFlag == LogMessageType.MSG_LOAD )
            {
                // none
            }
            else if ( messageFlag == LogMessageType.MSG_INPUT )
            {
                // none
            }
            else if ( messageFlag == LogMessageType.MSG_DOS_PROMPT )
            {
                if ( s_strInput != string.Empty )
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write( s_strInput );
                }
            }
            else
            {
                Console.WriteLine( " " );

                if ( s_strDosPrompt != string.Empty )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write( s_strDosPrompt );
                }

                if ( s_strInput != string.Empty )
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write( s_strInput );
                }
           }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageFlag"></param>
        /// <param name="strFormat"></param>
        /// <param name="arg"></param>
        internal static void InternalWriteLine( LogMessageType messageFlag, string strFormat, params object[] arg )
        {
            InternalWriteLine( messageFlag, string.Format( strFormat, arg ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFormat"></param>
        /// <returns></returns>
        internal static string StringFilter( string strFormat )
        {
            if ( strFormat == null || strFormat == string.Empty )
                return strFormat;

            string strReturn = strFormat;
            int iIndexOf = strFormat.IndexOf( "[L" ); //寻找 [LOAD]
            if ( iIndexOf > 0 )
                return string.Empty;

            return strReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charFormat"></param>
        /// <returns></returns>
        internal static string StringFilter( char charFormat )
        {
            if ( charFormat == '\r' || charFormat == '\b' )
                return string.Empty;

            return charFormat.ToString();
        }
        #endregion
    }
}
#endregion

