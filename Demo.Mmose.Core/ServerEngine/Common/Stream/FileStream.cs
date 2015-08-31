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
using System.Threading;

#endregion

namespace Demo.Mmose.Core.Common.Stream
{
    /// <summary>
    /// 提供字节序列的Mmose视图。
    /// </summary>
    public class FileStream : System.IO.Stream
    {
        #region zh-CHS 内部的类 | en Internal Class
        /// <summary>
        /// 表示异步操作的状态。
        /// </summary>
        internal class MmoseAsyncResult : IAsyncResult
        {
            #region zh-CHS 共有属性 | en Public Properties
            /// <summary>
            /// 获取用户定义的对象，它限定或包含关于异步操作的信息。
            /// </summary>
            /// <returns>用户定义的对象，它限定或包含关于异步操作的信息。</returns>
            public object AsyncState
            {
                get { return new object(); }
            }

            /// <summary>
            /// 获取用于等待异步操作完成的 System.Threading.WaitHandle。
            /// </summary>
            /// <returns>用于等待异步操作完成的 System.Threading.WaitHandle。</returns>
            public WaitHandle AsyncWaitHandle
            {
                get { return null; }
            }

            /// <summary>
            /// 获取异步操作是否同步完成的指示。
            /// </summary>
            /// <returns>如果异步操作同步完成，则为 true；否则为 false。</returns>
            public bool CompletedSynchronously
            {
                get { return false; }
            }

            /// <summary>
            /// 获取异步操作是否已完成的指示。
            /// </summary>
            /// <returns>如果操作完成则为 true，否则为 false。</returns>
            public bool IsCompleted
            {
                get { return false; }
            }
            #endregion
        }
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化 MmoseStream 类的新实例。
        /// </summary>
        protected internal FileStream()
        {
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        /// <summary>
        /// 当在派生类中重写时，获取指示当前流是否支持读取的值。
        /// </summary>
        /// <returns>如果流支持读取，为 true；否则为 false。</returns>
        public override bool CanRead
        {
            get { return false; }
        }

        /// <summary>
        /// 当在派生类中重写时，获取指示当前流是否支持查找功能的值。
        /// </summary>
        /// <returns>如果流支持查找，为 true；否则为 false。</returns>
        public override bool CanSeek
        {
            get { return false; }
        }

        /// <summary>
        /// 获取一个值，该值确定当前流是否可以超时。
        /// </summary>
        /// <returns>一个确定当前流是否可以超时的值。</returns>
        public override bool CanTimeout
        {
            get { return false; }
        }

        /// <summary>
        /// 当在派生类中重写时，获取指示当前流是否支持写入功能的值。
        /// </summary>
        /// <returns>如果流支持写入，为 true；否则为 false。</returns>
        public override bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// 当在派生类中重写时，获取用字节表示的流长度。
        /// </summary>
        /// <returns>用字节表示流长度的长值。</returns>
        /// <exception cref="System.NotSupportedException">从 Stream 派生的类不支持查找。</exception>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
        public override long Length 
        {
            get { return 0; }
        }

        /// <summary>
        /// 当在派生类中重写时，获取或设置当前流中的位置。
        /// </summary>
        /// <returns>流中的当前位置。</returns>
        /// <exception cref="System.NotSupportedException">流不支持查找。</exception>
        /// <exception cref="System.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
        public override long Position
        {
            get { return 0; }
            set
            {
                 //= value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值确定流在超时前尝试读取多长时间。
        /// </summary>
        /// <returns>一个确定流在超时前尝试读取多长时间的值。</returns>
        /// <exception cref="System.InvalidOperationException">System.IO.Stream.ReadTimeout 方法总是引发 System.InvalidOperationException。</exception>
        public override int ReadTimeout
        {
            get { return 0; } 
            set
            {
                 //= value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值确定流在超时前尝试写入多长时间。
        /// </summary>
        /// <returns>一个确定流在超时前尝试写入多长时间的值。</returns>
        /// <exception cref="System.InvalidOperationException">System.IO.Stream.ReadTimeout 方法总是引发 System.InvalidOperationException。</exception>
        public override int WriteTimeout
        {
            get { return 0; }
            set
            {
            }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 开始异步读操作。
        /// </summary>
        /// <param name="buffer">数据读入的缓冲区。</param>
        /// <param name="offset">buffer 中的字节偏移量，从该偏移量开始写入从流中读取的数据。</param>
        /// <param name="count">最多读取的字节数。</param>
        /// <param name="callback">可选的异步回调，在完成读取时调用。</param>
        /// <param name="state">一个用户提供的对象，它将该特定的异步读取请求与其他请求区别开来。</param>
        /// <returns>表示异步读取的 System.IAsyncResult（可能仍处于挂起状态）。</returns>
        /// <exception cref="System.IO.IOException">尝试的异步读取超过了流的结尾，或者发生了磁盘错误。</exception>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
        /// <exception cref="System.ArgumentException">一个或多个参数无效。</exception>
        /// <exception cref="System.NotSupportedException">当前 Stream 实现不支持读取操作。</exception>
        public override IAsyncResult BeginRead( byte[] buffer, int offset, int count, AsyncCallback callback, object state )
        {
            return new MmoseAsyncResult();
        }

        /// <summary>
        /// 开始异步写操作。
        /// </summary>
        /// <param name="buffer">从中写入数据的缓冲区。</param>
        /// <param name="offset">buffer 中的字节偏移量，从此处开始写入。</param>
        /// <param name="count">最多写入的字节数。</param>
        /// <param name="callback">可选的异步回调，在完成写入时调用。</param>
        /// <param name="state">一个用户提供的对象，它将该特定的异步写入请求与其他请求区别开来。</param>
        /// <returns>表示异步写入的 IAsyncResult（可能仍处于挂起状态）。</returns>
        /// <exception cref="System.IO.IOException">尝试进行的异步写入超过了流的结尾，或者发生了磁盘错误。</exception>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
        /// <exception cref="System.ArgumentException">一个或多个参数无效。</exception>
        /// <exception cref="System.NotSupportedException">当前 Stream 实现不支持写入操作。</exception>
        public override IAsyncResult BeginWrite( byte[] buffer, int offset, int count, AsyncCallback callback, object state )
        {
            return new MmoseAsyncResult();
        }

        /// <summary>
        /// 关闭当前流并释放与之关联的所有资源（如套接字和文件句柄）。
        /// </summary>
        public override void Close()
        {
        }

        /// <summary>
        /// 释放由 System.IO.Stream 占用的非托管资源，还可以另外再释放托管资源。
        /// </summary>
        /// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
        protected override void Dispose( bool disposing )
        {
        }

        /// <summary>
        /// 等待挂起的异步读取完成。
        /// </summary>
        /// <param name="asyncResult">对要完成的挂起异步请求的引用。</param>
        /// <returns>从流中读取的字节数，介于零 (0) 和所请求的字节数之间。流仅在流的末尾返回零 (0)，否则应一直阻止到至少有 1 个字节可用为止。</returns>
        /// <exception cref="System.ArgumentNullException">asyncResult 为 null。</exception>
        /// <exception cref="System.ArgumentException">asyncResult 并非源自当前流上的 System.IO.Stream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)方法。</exception>
        public override int EndRead( IAsyncResult asyncResult )
        {
            return 0;
        }

        /// <summary>
        ///  结束异步写操作。
        /// </summary>
        /// <param name="asyncResult">对未完成的异步 I/O 请求的引用。</param>
        /// <exception cref="System.ArgumentNullException">asyncResult 为 null。</exception>
        public override void EndWrite( IAsyncResult asyncResult )
        {
        }

        /// <summary>
        /// 当在派生类中重写时，将清除该流的所有缓冲区，并使得所有缓冲数据被写入到基础设备。
        /// </summary>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        public override void Flush()
        {
        }

        /// <summary>
        /// 当在派生类中重写时，从当前流读取字节序列，并将此流中的位置提升读取的字节数。
        /// </summary>
        /// <param name="buffer">字节数组。此方法返回时，该缓冲区包含指定的字符数组，该数组的 offset 和 (offset + count -1) 之间的值由从当前源中读取的字节替换。</param>
        /// <param name="offset">buffer 中的从零开始的字节偏移量，从此处开始存储从当前流中读取的数据。</param>
        /// <param name="count">要从当前流中最多读取的字节数。</param>
        /// <returns>读入缓冲区中的总字节数。如果当前可用的字节数没有请求的字节数那么多，则总字节数可能小于请求的字节数，或者如果已到达流的末尾，则为零 (0)。</returns>
        /// <exception cref="System.ArgumentException">offset 与 count 的和大于缓冲区长度。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">offset 或 count 为负。</exception>
        /// <exception cref="System.ArgumentNullException">buffer 为 null。</exception>
        /// <exception cref="System.NotSupportedException">流不支持读取。</exception>
       public override int Read( byte[] buffer, int offset, int count )
        {
            return 0;
        }

        /// <summary>
        /// 从流中读取一个字节，并将流内的位置向前推进一个字节，或者如果已到达流的末尾，则返回 -1。
        /// </summary>
        /// <returns>转换为 Int32 的无符号字节，或者如果到达流的末尾，则为 -1。</returns>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
        /// <exception cref="System.NotSupportedException">流不支持读取。</exception>
        public override int ReadByte()
        {
            return 0;
        }

        /// <summary>
        /// 当在派生类中重写时，设置当前流中的位置。
        /// </summary>
        /// <param name="offset">相对于 origin 参数的字节偏移量。</param>
        /// <param name="origin">System.IO.SeekOrigin 类型的值，指示用于获取新位置的参考点。</param>
        /// <returns>当前流中的新位置。</returns>
        /// <exception cref="System.NotSupportedException">流不支持查找，例如在流通过管道或控制台输出构造的情况下即为如此。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
        public override long Seek( long offset, SeekOrigin origin )
        {
            return 0;
        }

        /// <summary>
        /// 当在派生类中重写时，设置当前流的长度。
        /// </summary>
        /// <param name="value">所需的当前流的长度（以字节表示）。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.NotSupportedException">流不支持写入和查找，例如在流通过管道或控制台输出构造的情况下即为如此。</exception>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
       public override void SetLength( long value )
        {
        }

        /// <summary>
        /// 当在派生类中重写时，向当前流中写入字节序列，并将此流中的当前位置提升写入的字节数。
        /// </summary>
        /// <param name="buffer">字节数组。此方法将 count 个字节从 buffer 复制到当前流。</param>
        /// <param name="offset">buffer 中的从零开始的字节偏移量，从此处开始将字节复制到当前流。</param>
        /// <param name="count">要写入当前流的字节数。</param>
        /// <exception cref="System.ArgumentException">offset 与 count 的和大于缓冲区长度。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">offset 或 count 为负。</exception>
        /// <exception cref="System.NotSupportedException">流不支持写入。</exception>
        /// <exception cref="System.ArgumentNullException">buffer 为 null。</exception>
        public override void Write( byte[] buffer, int offset, int count )
        {
        }

        /// <summary>
        /// 将一个字节写入流内的当前位置，并将流内的位置向前推进一个字节。
        /// </summary>
        /// <param name="value">要写入流的字节。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误。</exception>
        /// <exception cref="System.ObjectDisposedException">在流关闭后调用方法。</exception>
        public override void WriteByte( byte value )
        {
        }
        #endregion
    }
}
#endregion

