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
using System.IO;
using System.Text;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server.Language;
#endregion

namespace Demo.Mmose.Core.Server
{
    /// <summary>
    // 控制台调试输出信息的文件数据输出流的类
    /// </summary>
    [MultiThreadedNoSupport( "zh-CHS", "当前的类所有成员没有锁定(为了快速的输出日志信息),不支持多线程操作(但是在LOGs中支持了多线程)" )]
    internal class FileLogger : TextWriter, IDisposable
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 日志日期的格式
        /// </summary>
        private readonly static string DateFormat = "[MMMM dd hh:mm:ss.f tt]: ";
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 控制台调试输出信息的文件数据输出流的构造函数
        /// </summary>
        /// <param name="file">文件数据输出流的文件名称</param>
        public FileLogger( string strFile )
            : this( strFile, false )
        {
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_FileName = string.Empty;
        #endregion
        /// <summary>
        /// 控制台调试输出信息的文件数据输出流的构造函数
        /// </summary>
        /// <param name="file">文件数据输出流的文件名称</param>
        /// <param name="append">是添加至文件的尾部还是新建个文件</param>
        public FileLogger( string strFile, bool bAppend )
        {
            if ( strFile == null )
                throw new Exception( "FileLogger.FileLogger(...) - strFile == null error!" );

            m_FileName = strFile;
            m_bIsLogFile = true;
            using ( StreamWriter writer = new StreamWriter( new FileStream( m_FileName, bAppend ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.Read ) ) )
            {
                writer.WriteLine( LanguageString.SingletonInstance.FileLoggerString001, DateTime.Now.ToString( "f" ) ); //f = Tuesday, April 10, 2001 3:51 PM 
            }
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 文件数据输出流的文件名称
        /// </summary>
        public string LogFileName
        {
            get { return m_FileName; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsLogFile = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsLogFile
        {
            get { return m_bIsLogFile; }
            set { m_bIsLogFile = value; }
        }
        #endregion

        #region zh-CHS 属性覆盖 | en Override Properties
        /// <summary>
        /// 返回系统的缺省代码页的编码
        /// </summary>
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private StringBuilder m_StringBuilder = new StringBuilder();
        #endregion
        /// <summary>
        /// 在文件数据输出流中写入一个字符信息
        /// </summary>
        public override void Write( char charWrite )
        {
            m_StringBuilder.Append( LOGs.StringFilter( charWrite ) );
        }

        /// <summary>
        /// 在文件数据输出流中写入一行文本信息
        /// </summary>
        public override void Write( string strWrite )
        {
            m_StringBuilder.Append( strWrite );
        }

        /// <summary>
        /// 在文件数据输出流中写入一行具有参数的文本信息
        /// </summary>
        public override void WriteLine( string strWriteLine )
        {
            m_StringBuilder.Append( strWriteLine );

            m_StringBuilder.Insert( 0, DateTime.Now.ToString( DateFormat ) );

            if ( m_bIsLogFile == true )
                LOGs.WriteLineLogFile( m_FileName, m_StringBuilder.ToString() );

            m_StringBuilder.Length = 0;
        }
        #endregion
    }
}
#endregion

