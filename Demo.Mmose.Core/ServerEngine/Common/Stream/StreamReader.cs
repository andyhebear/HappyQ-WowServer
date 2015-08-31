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
using System.IO;

#endregion

namespace Demo.Mmose.Core.Common.Stream
{
    /// <summary>
    /// 表示可读取连续字符系列的读取器。
    /// </summary>
    public class StreamReader : TextReader
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化 System.IO.TextReader 类的新实例。
        /// </summary>
        protected internal StreamReader()
        {
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 关闭 System.IO.TextReader 并释放与该 TextReader 关联的所有系统资源。
        /// </summary>
        public override void Close()
        {
        }

        /// <summary>
        /// 释放由 System.IO.TextReader 占用的非托管资源，还可以另外再释放托管资源。
        /// </summary>
        /// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
        protected override void Dispose( bool disposing )
        {
        }

        /// <summary>
        /// 读取下一个字符，而不更改读取器状态或字符源。返回下一个可用字符，而实际上并不从输入流中读取此字符。
        /// </summary>
        /// <returns>下一个要读取的字符，或者如果没有更多的可用字符或此流不支持查找，则为 -1。</returns>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextReader 是关闭的。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        public override int Peek()
        {
            return 0;
        }

        /// <summary>
        /// 读取输入流中的下一个字符并使该字符的位置提升一个字符。
        /// </summary>
        /// <returns>输入流中的下一个字符，或者如果没有更多的可用字符，则为 -1。默认实现将返回 -1。</returns>
        /// <exception cref="System.ObjectDisposedException"> System.IO.TextReader 是关闭的。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        public override int Read()
        {
            return 0;
        }

        /// <summary>
        /// 从当前流中读取最大 count 的字符并从 index 开始将该数据写入 buffer。
        /// </summary>
        /// <param name="buffer">此方法返回时，包含指定的字符数组，该数组的 index 和 (index + count - 1) 之间的值由从当前源中读取的字符替换。</param>
        /// <param name="index">buffer 中开始写入的位置。</param>
        /// <param name="count">最多读取的字符数。如果在将 count 个字符读入 buffer 之前已到达流的末尾，则当前方法将返回。</param>
        /// <returns>已读取的字符数。该数小于或等于 count，具体取决于流中是否有可用的数据。如果调用此方法时没有更多的字符留下可供读取，则此方法返回 0。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">index 或 count 为负。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextReader 是关闭的。</exception>
        /// <exception cref="System.ArgumentException">缓冲区长度减去 index 小于 count。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">buffer 为 null。</exception>
        public override int Read( char[] buffer, int index, int count )
        {
            return 0;
        }

        /// <summary>
        /// 从当前流中读取最大 count 的字符并从 index 开始将该数据写入 buffer。
        /// </summary>
        /// <param name="buffer">此方法返回时，此参数包含指定的字符数组，该数组中从 index 到 (index + count -1) 之间的值由从当前源中读取的字符替换。</param>
        /// <param name="index">buffer 中开始写入的位置。</param>
        /// <param name="count">最多读取的字符数。</param>
        /// <returns>已读取的字符数。该数字将小于或等于 count，具体取决于是否所有的输入字符都已读取。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">index 或 count 为负。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextReader 是关闭的。</exception>
        /// <exception cref="System.ArgumentException">缓冲区长度减去 index 小于 count。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">buffer 为 null。</exception>
        public override int ReadBlock( char[] buffer, int index, int count )
        {
            return 0;
        }

        /// <summary>
        /// 从当前流中读取一行字符并将数据作为字符串返回。
        /// </summary>
        /// <returns>输入流的下一行，或者如果已读取了所有字符，则为 null。</returns>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.OutOfMemoryException">内存不足，无法为返回的字符串分配缓冲区。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextReader 是关闭的。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">下一行中的字符数大于 System.Int32.MaxValue</exception>
        public override string ReadLine()
        {
            return string.Empty;
        }

        /// <summary>
        /// 读取从当前位置到 TextReader 的结尾的所有字符并将它们作为一个字符串返回。
        /// </summary>
        /// <returns>包含从当前位置到 TextReader 的结尾的所有字符的字符串。</returns>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.OutOfMemoryException">内存不足，无法为返回的字符串分配缓冲区。</exception>
        /// <exception cref="System.ObjectDisposedException">System.IO.TextReader 是关闭的。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">下一行中的字符数大于 System.Int32.MaxValue</exception>
        public override string ReadToEnd()
        {
            return string.Empty;
        }
        #endregion
    }
}
#endregion

