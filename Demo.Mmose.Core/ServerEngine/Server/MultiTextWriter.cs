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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server.Language;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Server
{
    /// <summary>
    /// 多个控制台调试输出信息的数据输出流的集合类
    /// </summary>
    [MultiThreadedNoSupport( "zh-CHS", "当前的类所有成员没有锁定(为了快速的输出日志信息),部分支持多线程操作(但是在LOGs中支持了多线程)" )]
    public class MultiTextWriter : TextWriter
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 存储多个数据输出流的列表
        /// </summary>
        private TextWriter[] m_TextWriterArray = new TextWriter[0];
        #endregion
        /// <summary>
        /// 添加多个数据输出流至列表中
        /// </summary>
        public MultiTextWriter( params TextWriter[] streamsArray )
        {
            if ( streamsArray == null )
                throw new Exception( "MultiTextWriter.MultiTextWriter(...) - streamsArray == null error!" );

            m_TextWriterArray = new TextWriter[streamsArray.Length];
            for ( int iIndex = 0; iIndex < m_TextWriterArray.Length; ++iIndex )
                m_TextWriterArray[iIndex] = streamsArray[iIndex];

            if ( m_TextWriterArray.Length <= 0 )
                throw new ArgumentException( LanguageString.SingletonInstance.MultiTextWriterString001 );
        }
        #endregion

        #region zh-CHS 属性覆盖 | en Override Property
        /// <summary>
        /// 返回系统的缺省代码页的编码
        /// </summary>
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 只锁定添加和删除操作(因为是数组，其它的地方可以不用锁定的)
        /// </summary>
        private SpinLock m_OnlyLockAddRemove = new SpinLock();
        #endregion
        /// <summary>
        /// 添加一个数据输出流
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "当前的类有添加操作,但支持多线程操作:声明!" )]
        public void Add( TextWriter textWriter )
        {
            if ( textWriter == null )
                throw new Exception( "MultiTextWriter.Add(...) - textWriter == null error!" );

            m_OnlyLockAddRemove.Enter();
            {
                // 创建新的TextWriter数组,添加数据,交换数组数据,不需要锁定,没有引用时自动会回收数据
                TextWriter[] tempTextWriter = new TextWriter[m_TextWriterArray.Length + 1];

                for ( int iIndex = 0; iIndex < m_TextWriterArray.Length; ++iIndex )
                    tempTextWriter[iIndex] = m_TextWriterArray[iIndex];

                tempTextWriter[m_TextWriterArray.Length] = textWriter;

                m_TextWriterArray = tempTextWriter;
            }
            m_OnlyLockAddRemove.Exit();
        }

        /// <summary>
        /// 移去一个数据输出流
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "当前的类有删除操作,但支持多线程操作:声明!" )]
        public void Remove( TextWriter textWriter )
        {
            if ( textWriter == null )
                throw new Exception( "MultiTextWriter.Remove(...) - textWriter == null error!" );

            m_OnlyLockAddRemove.Enter();
            {
                List<TextWriter> textWriterList = new List<TextWriter>();

                for ( int iIndex = 0; iIndex < m_TextWriterArray.Length; ++iIndex )
                {
                    TextWriter itemTextWriter = m_TextWriterArray[iIndex];

                    if ( itemTextWriter != textWriter )
                        textWriterList.Add( itemTextWriter );
                }

                m_TextWriterArray = textWriterList.ToArray();
            }
            m_OnlyLockAddRemove.Exit();
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        /// <summary>
        /// 在数据输出流中写入一个字符信息
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "当前的类有枚举列表操作(无锁),不支持多线程操作:警告!" )]
        public override void Write( char charWrite )
        {
            for ( int iIndex = 0; iIndex < m_TextWriterArray.Length; ++iIndex )
                m_TextWriterArray[iIndex].Write( charWrite );
        }

        /// <summary>
        /// 在数据输出流中写入一行文本信息
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "当前的类有枚举列表操作(无锁),不支持多线程操作:警告!" )]
        public override void WriteLine( string strLine )
        {
            for ( int iIndex = 0; iIndex < m_TextWriterArray.Length; ++iIndex )
                m_TextWriterArray[iIndex].WriteLine( strLine );
        }

        /// <summary>
        /// 在数据输出流中写入一行具有参数的文本信息
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "当前的类有枚举列表操作(无锁),不支持多线程操作:警告!" )]
        public override void WriteLine( string strLine, params object[] args )
        {
            WriteLine( string.Format( strLine, args ) );
        }
        #endregion
    }
}
#endregion