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
#endregion

namespace Demo.Mmose.Core.Common.Stream
{
    /// <summary>
    /// 表示可以编写一个有序字符系列的编写器。
    /// </summary>
    public class StreamWriter : TextWriter
    {
        #region zh-CHS 内部的类 | en Internal Class
        /// <summary>
        /// 提供用于检索控制格式化的对象的机制。
        /// </summary>
        internal class MmoseFormatProvider : IFormatProvider
        {
            #region zh-CHS 共有方法 | en Public Methods
            /// <summary>
            /// 获取一个对象，该对象为指定类型提供格式化服务。
            /// </summary>
            /// <param name="formatType">一个对象，它指定要获取的格式对象的类型。</param>
            /// <returns>如果 formatType 与当前实例类型相同，则为当前实例，否则为 null。</returns>
            public object GetFormat( Type formatType )
            {
                return new object();
            }
            #endregion
        }
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化 MmoseStreamWriter 类的新实例。
        /// </summary>
        protected internal StreamWriter()
        {
        }

        /// <summary>
        /// 使用指定的格式提供程序初始化 MmoseStreamWriter 类的新实例。
        /// </summary>
        /// <param name="formatProvider">控制格式设置的 System.IFormatProvider 对象。</param>
        protected internal StreamWriter( IFormatProvider formatProvider )
        {
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 当在派生类中重写时，返回用来写输出的 System.Text.Encoding。
        /// </summary>
        /// <returns>用来写入输出的 Encoding。</returns>
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }

        /// <summary>
        /// 获取控制格式设置的对象。
        /// </summary>
        /// <returns>特定区域性的 System.IFormatProvider 对象，或者如果未指定任何其他区域性，则为当前区域性的格式设置。</returns>
        public override IFormatProvider FormatProvider
        {
            get { return new MmoseFormatProvider(); }
        }

        /// <summary>
        /// 获取或设置由当前 TextWriter 使用的行结束符字符串。
        /// </summary>
        /// <returns>当前 TextWriter 的行结束符字符串。</returns>
        public override string NewLine 
        {
            get { return string.Empty; }
            set
            {
                 //= value;
            }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 关闭当前编写器并释放任何与该编写器关联的系统资源。
        /// </summary>
        public override void Close()
        {
        }

        /// <summary>
        /// 释放由 System.IO.TextWriter 占用的非托管资源，还可以另外再释放托管资源。
        /// </summary>
        /// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
        protected override void Dispose( bool disposing )
        {
        }

        /// <summary>
        /// 清理当前编写器的所有缓冲区，使所有缓冲数据写入基础设备。
        /// </summary>
        public override void Flush()
        {
        }

        /// <summary>
        /// 将 Boolean 值的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 Boolean。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( bool value )
        {
        }

        /// <summary>
        /// 将字符写入文本流。
        /// </summary>
        /// <param name="value">要写入文本流中的字符。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( char value )
        {
        }

        /// <summary>
        /// 将字符数组写入文本流。
        /// </summary>
        /// <param name="buffer">要写入文本流中的字符数组。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( char[] buffer )
        {
        }

        /// <summary>
        /// 将后面带有行结束符的十进制值的文本表示形式写入文本流
        /// </summary>
        /// <param name="value">要写入的十进制值</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( decimal value )
        {
        }

        /// <summary>
        /// 将 8 字节浮点值的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 8 字节浮点值。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( double value )
        {
        }

        /// <summary>
        /// 将 4 字节浮点值的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 4 字节浮点值。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( float value )
        {
        }

        /// <summary>
        /// 将 4 字节有符号整数的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 4 字节有符号整数。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( int value )
        {
        }

        /// <summary>
        /// 将 8 字节有符号整数的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 8 字节有符号整数。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( long value )
        {
        }

        /// <summary>
        /// 通过在对象上调用 ToString 将此对象的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的对象。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( object value )
        {
        }

        /// <summary>
        /// 将字符串写入文本流。
        /// </summary>
        /// <param name="value">要写入的字符串。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( string value )
        {
        }

        /// <summary>
        /// 将 4 字节无符号整数的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 4 字节无符号整数。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( uint value )
        {
        }

        /// <summary>
        /// 将 8 字节无符号整数的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 8 字节无符号整数。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( ulong value )
        {
        }

        /// <summary>
        /// 使用与 System.String.Format(System.String,System.Object) 相同的语义写出格式化的字符串。
        /// </summary>
        /// <param name="format">格式化字符串。</param>
        /// <param name="arg0">要写入格式化字符串的对象。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.FormatException">格式中的格式规范无效。- 或 - 用于指示要设置格式的参数的数字小于零，或者大于或等于所提供的要设置格式的对象的数目。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( string format, object arg0 )
        {
        }

        /// <summary>
        /// 使用与 System.String.Format(System.String,System.Object) 相同的语义写出格式化的字符串。
        /// </summary>
        /// <param name="format">格式化字符串。</param>
        /// <param name="arg">要写入格式化字符串的对象数组。</param>
        /// <exception cref="System.FormatException">格式中的格式规范无效。- 或 - 用于指示要设置格式的参数的数字小于零，或者大于或等于所提供的要设置格式的对象的数目。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( string format, params object[] arg )
        {
        }

        /// <summary>
        /// 将字符的子数组写入文本流。
        /// </summary>
        /// <param name="buffer">要从中写出数据的字符数组。</param>
        /// <param name="index">在缓冲区中开始索引。</param>
        /// <param name="count">要写入的字符数。</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index 或 count 为负。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentException">缓冲区长度减去 index 小于 count。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( char[] buffer, int index, int count )
        {
        }

        /// <summary>
        /// 使用与 System.String.Format(System.String,System.Object) 相同的语义写出格式化的字符串。
        /// </summary>
        /// <param name="format">格式化字符串。</param>
        /// <param name="arg0">要写入格式化字符串的对象。</param>
        /// <param name="arg1">要写入格式化字符串的对象。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.FormatException">格式中的格式规范无效。- 或 - 用于指示要设置格式的参数的数字小于零，或者大于或等于所提供的要设置格式的对象的数目。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( string format, object arg0, object arg1 )
        {
        }

        /// <summary>
        /// 使用与 System.String.Format(System.String,System.Object) 相同的语义写出格式化的字符串。
        /// </summary>
        /// <param name="format">格式化字符串。</param>
        /// <param name="arg0">要写入格式化字符串的对象。</param>
        /// <param name="arg1">要写入格式化字符串的对象。</param>
        /// <param name="arg2">要写入格式化字符串的对象。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.FormatException">格式中的格式规范无效。- 或 - 用于指示要设置格式的参数的数字小于零，或者大于或等于所提供的要设置格式的对象的数目。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void Write( string format, object arg0, object arg1, object arg2 )
        {
        }

        /// <summary>
        /// 将行结束符写入文本流。
        /// </summary>
        /// <returns>默认行结束符是后跟换行符的回车符（“\r\n”），但使用 System.IO.TextWriter.NewLine 属性可以更改此值。</returns>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine()
        {
        }

        /// <summary>
        /// 将后跟行结束符的 Boolean 的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 Boolean。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( bool value )
        {
        }

        /// <summary>
        /// 将后跟行结束符的字符写入文本流。
        /// </summary>
        /// <param name="value">要写入文本流中的字符。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( char value )
        {
        }

        /// <summary>
        /// 将后跟行结束符的字符数组写入文本流。
        /// </summary>
        /// <param name="buffer">从其读取数据的字符数组。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( char[] buffer )
        {
        }

        /// <summary>
        /// 将后面带有行结束符的十进制值的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的十进制值。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( decimal value )
        {
        }

        /// <summary>
        /// 将后跟行结束符的 8 字节浮点值的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 8 字节浮点值。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( double value )
        {
        }

        /// <summary>
        /// 将后跟行结束符的 4 字节浮点值的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 4 字节浮点值。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( float value )
        {
        }

        /// <summary>
        /// 将后跟行结束符的 4 字节有符号整数的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 4 字节有符号整数。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( int value )
        {
        }

        /// <summary>
        /// 将后跟行结束符的 8 字节有符号整数的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 8 字节有符号整数。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( long value )
        {
        }

        /// <summary>
        /// 通过在对象上调用 ToString 将后跟行结束符的此对象的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的对象。如果 value 为 null，则仅写入行结束字符。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( object value )
        {
        }

        /// <summary>
        /// 将后跟行结束符的字符串写入文本流。
        /// </summary>
        /// <param name="value">要写入的字符串。如果 value 为 null，则仅写入行结束字符。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( string value )
        {
        }

        /// <summary>
        /// 将后跟行结束符的 4 字节无符号整数的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 4 字节无符号整数。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( uint value )
        {
        }

        /// <summary>
        /// 将后跟行结束符的 8 字节无符号整数的文本表示形式写入文本流。
        /// </summary>
        /// <param name="value">要写入的 8 字节无符号整数。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( ulong value )
        {
        }

        /// <summary>
        /// 使用与 System.String.Format(System.String,System.Object) 相同的语义写出格式化的字符串和一个新行。
        /// </summary>
        /// <param name="format">格式化的字符串。</param>
        /// <param name="arg0">要写入已格式化字符串的对象。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.FormatException">格式中的格式规范无效。- 或 - 用于指示要设置格式的参数的数字小于零，或者大于或等于所提供的要设置格式的对象的数目。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( string format, object arg0 )
        {
        }

        /// <summary>
        /// 使用与 System.String.Format(System.String,System.Object) 相同的语义写出格式化的字符串和一个新行。
        /// </summary>
        /// <param name="format">格式化字符串。</param>
        /// <param name="arg">要写入格式化字符串的对象数组。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.FormatException">格式中的格式规范无效。- 或 - 用于指示要设置格式的参数的数字小于零，或者大于或等于所提供的要设置格式的对象的数目。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( string format, params object[] arg )
        {
        }

        /// <summary>
        /// 将后跟行结束符的字符子数组写入文本流。
        /// </summary>
        /// <param name="buffer">从其读取数据的字符数组。</param>
        /// <param name="index">开始读取的 buffer 中的索引。</param>
        /// <param name="count">要写入的最大字符数。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.ArgumentException">缓冲区长度减去 index 小于 count。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( char[] buffer, int index, int count )
        {
        }

        /// <summary>
        /// 使用与 System.String.Format(System.String,System.Object) 相同的语义写出格式化的字符串和一个新行。
        /// </summary>
        /// <param name="format">格式化字符串。</param>
        /// <param name="arg0">要写入格式字符串的对象。</param>
        /// <param name="arg1">要写入格式字符串的对象。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.FormatException">格式中的格式规范无效。- 或 - 用于指示要设置格式的参数的数字小于零，或者大于或等于所提供的要设置格式的对象的数目。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( string format, object arg0, object arg1 )
        {
        }

        /// <summary>
        /// 使用与 System.String.Format(System.String,System.Object) 相同的语义写出格式化的字符串和一个新行。
        /// </summary>
        /// <param name="format">格式化字符串。</param>
        /// <param name="arg0">要写入格式字符串的对象。</param>
        /// <param name="arg1">要写入格式字符串的对象。</param>
        /// <param name="arg2">要写入格式字符串的对象。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">format 为 null。</exception>
        /// <exception cref="System.FormatException">格式中的格式规范无效。- 或 - 用于指示要设置格式的参数的数字小于零，或者大于或等于所提供的要设置格式的对象的数目。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextWriter 是关闭的。</exception>
        public override void WriteLine( string format, object arg0, object arg1, object arg2 )
        {
        }
        #endregion
    }
}
#endregion

