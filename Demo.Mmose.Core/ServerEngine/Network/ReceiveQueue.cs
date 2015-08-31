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
using System.Runtime.InteropServices;
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common.Atom;
#endregion

namespace Demo.Mmose.Core.Network
{
    /// <summary>
    /// 接受到的数据,使用环绕缓冲区来解决粘包和半包的处理
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
    public class ReceiveQueue
    {
        #region zh-CHS 类常量 | en Class Constants
        /// <summary>
        /// 字节默认的大小
        /// </summary>
        private const long BUFFER_SIZE = 2048;
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 字节的头位置
        /// </summary>
        private long m_Head = 0;
        /// <summary>
        /// 字节的尾位置
        /// </summary>
        private long m_Tail = 0;
        /// <summary>
        /// 字节的数组
        /// </summary>
        private byte[] m_Buffer = new byte[BUFFER_SIZE];
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockBuffer = new SpinLock();
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 字节的大小
        /// </summary>
        private long m_Size = 0;
        #endregion
        /// <summary>
        /// 环绕缓冲区内的数据大小
        /// </summary>
        public long Length
        {
            get { return m_Size; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 给出使用环绕缓冲区内的数据
        /// </summary>
        /// <param name="byteBuffer"></param>
        /// <param name="iOffset"></param>
        /// <param name="iSize"></param>
        /// <returns>返回实际读取到的字节数</returns>
        public long Dequeue( ref byte[] byteBuffer, long iOffset, long iSize )
        {
            if ( iSize == 0 )
                return 0;

            if ( iSize > m_Size )
                iSize = m_Size;

            m_LockBuffer.Enter();
            {
                if ( m_Head < m_Tail )
                    Buffer.BlockCopy( m_Buffer, (int)m_Head, byteBuffer, (int)iOffset, (int)iSize );
                else
                {
                    long rightLength = m_Buffer.Length - m_Head;

                    if ( rightLength >= iSize )
                        Buffer.BlockCopy( m_Buffer, (int)m_Head, byteBuffer, (int)iOffset, (int)iSize );
                    else
                    {
                        Buffer.BlockCopy( m_Buffer, (int)m_Head, byteBuffer, (int)iOffset, (int)rightLength );
                        Buffer.BlockCopy( m_Buffer, 0, byteBuffer, (int)( iOffset + rightLength ), (int)( iSize - rightLength ) );
                    }
                }

                m_Head = ( m_Head + iSize ) % m_Buffer.Length;
                m_Size -= iSize;

                if ( m_Size == 0 )
                {
                    m_Head = 0;
                    m_Tail = 0;
                }
            }
            m_LockBuffer.Exit();

            return iSize;
        }

        /// <summary>
        /// 压入数据至环绕缓冲区内
        /// </summary>
        /// <param name="byteBuffer"></param>
        /// <param name="iOffset"></param>
        /// <param name="iSize"></param>
        public void Enqueue( byte[] byteBuffer, long iOffset, long iSize )
        {
            m_LockBuffer.Enter();
            {
                if ( ( m_Size + iSize ) > m_Buffer.Length )
                    SetCapacity( ( m_Size + iSize + 2047 ) & ~2047 ); // 总是以2048的倍数来增大字节数, :( 弄得我老半天才明白原理呢!

                if ( m_Head < m_Tail )
                {
                    long rightLength = m_Buffer.Length - m_Tail;

                    if ( rightLength >= iSize )
                        Buffer.BlockCopy( byteBuffer, (int)iOffset, m_Buffer, (int)m_Tail, (int)iSize );
                    else
                    {
                        Buffer.BlockCopy( byteBuffer, (int)iOffset, m_Buffer, (int)m_Tail, (int)rightLength );
                        Buffer.BlockCopy( byteBuffer, (int)( iOffset + rightLength ), m_Buffer, 0, (int)( iSize - rightLength ) );
                    }
                }
                else
                    Buffer.BlockCopy( byteBuffer, (int)iOffset, m_Buffer, (int)m_Tail, (int)iSize );

                m_Tail = ( m_Tail + iSize ) % m_Buffer.Length;
                m_Size += iSize;
            }
            m_LockBuffer.Exit();
        }

        /// <summary>
        /// 压入数据至环绕缓冲区内
        /// </summary>
        /// <param name="byteBuffer"></param>
        /// <param name="iOffset"></param>
        /// <param name="iSize"></param>
        public void Enqueue( IntPtr byteBuffer, long iOffset, long iSize )
        {
            m_LockBuffer.Enter();
            {
                if ( ( m_Size + iSize ) > m_Buffer.Length )
                    SetCapacity( ( m_Size + iSize + 2047 ) & ~2047 ); // 总是以2048的倍数来增大字节数, :( 弄得我我半天才明白原理呢!

                IntPtr byteBufferOffset;
                if ( m_Head < m_Tail )
                {
                    long rightLength = m_Buffer.Length - m_Tail;

                    if ( rightLength >= iSize )
                    {
                        byteBufferOffset = new IntPtr( byteBuffer.ToInt64() + iOffset );
                        Marshal.Copy( byteBufferOffset, m_Buffer, (int)m_Tail, (int)iSize );
                    }
                    else
                    {
                        byteBufferOffset = new IntPtr( byteBuffer.ToInt64() + iOffset );
                        Marshal.Copy( byteBuffer, m_Buffer, (int)m_Tail, (int)rightLength );

                        byteBufferOffset = new IntPtr( byteBuffer.ToInt64() + iOffset + rightLength );
                        Marshal.Copy( byteBuffer, m_Buffer, 0, (int)( iSize - rightLength ) );
                    }
                }
                else
                {
                    byteBufferOffset = new IntPtr( byteBuffer.ToInt64() + iOffset );
                    Marshal.Copy( byteBuffer, m_Buffer, (int)m_Tail, (int)iSize );
                }

                m_Tail = ( m_Tail + iSize ) % m_Buffer.Length; // 返回环绕的数据的位置
                m_Size += iSize;
            }
            m_LockBuffer.Exit();
        }

        /// <summary>
        /// 清除数据的信息,不清除数据缓冲,用于下次使用
        /// </summary>
        public void Clear()
        {
            m_LockBuffer.Enter();
            {
                m_Head = 0;
                m_Tail = 0;
                m_Size = 0;
            }
            m_LockBuffer.Exit();
        }

        /// <summary>
        /// 给出数据包的长度
        /// </summary>
        /// <returns></returns>
        public long GetPacketLength()
        {
            long iReturn = 0;

            m_LockBuffer.Enter();
            {
                EventHandler<PacketLengthInfoEventArgs> tempEvent = s_ThreadEventPacketLength;
                if ( tempEvent != null )
                {
                    PacketLengthInfoEventArgs packetLengthInfoEventArgs = new PacketLengthInfoEventArgs( m_Buffer, m_Size, m_Head );
                    tempEvent( this, packetLengthInfoEventArgs );
                    iReturn = packetLengthInfoEventArgs.PacketLength;
                }
            }
            m_LockBuffer.Exit();

            return iReturn;
        }

        /// <summary>
        /// 给出数据包的ID
        /// </summary>
        /// <returns></returns>
        public long GetPacketID()
        {
            long iReturn = 0;

            m_LockBuffer.Enter();
            {
                EventHandler<PacketIdInfoEventArgs> tempEvent = s_ThreadEventPacketID;
                if ( tempEvent != null )
                {
                    PacketIdInfoEventArgs packetIdInfoEventArgs = new PacketIdInfoEventArgs( m_Buffer, m_Size, m_Head );
                    tempEvent( this, packetIdInfoEventArgs );
                    iReturn = packetIdInfoEventArgs.PacketId;
                }
            }
            m_LockBuffer.Exit();

            return iReturn;
        }

        /// <summary>
        /// 给出数据包的ID
        /// </summary>
        /// <returns></returns>
        public PacketHeadT GetPacketHead<PacketHeadT>( EventHandler<PacketHeadInfoEventArgs<PacketHeadT>> eventHandler )
        {
            if ( eventHandler == null )
                throw new Exception( "ReceiveQueue.GetPacketHead<.>(...) - eventHandler == null error!" );

            PacketHeadT returnT = default( PacketHeadT );

            m_LockBuffer.Enter();
            {
                PacketHeadInfoEventArgs<PacketHeadT> eventArgs = new PacketHeadInfoEventArgs<PacketHeadT>( m_Buffer, m_Size, m_Head );
                eventHandler( this, eventArgs );
                returnT = eventArgs.PacketHead;
            }
            m_LockBuffer.Exit();

            return returnT;
        }
        #endregion

        #region zh-CHS 内部方法 | en Internal Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 当前的类是否已锁
        /// </summary>
        private LockInOut m_bIsLockThis = new LockInOut( false );
        #endregion
        /// <summary>
        /// 锁定当前的类(表示当前类正在调用中)
        /// </summary>
        /// <returns>返回是否已经锁定成功</returns>
        internal bool InProcessReceive()
        {
            return m_bIsLockThis.InLock();
        }

        /// <summary>
        /// 释放当前已经锁定的类(表示当前类的调用已结束)
        /// </summary>
        internal void OutProcessReceive()
        {
            m_bIsLockThis.OutLock();
        }
        #endregion

        #region zh-CHS 私有方法 | en Private Method
        /// <summary>
        /// 扩大缓冲数据的大小(当前都在锁中操作，因此不需要锁定的)
        /// </summary>
        /// <param name="iCapacity"></param>
        private void SetCapacity( long iCapacity )
        {
            byte[] newBuffer = new byte[iCapacity];

            if ( m_Size > 0 )
            {
                if ( m_Head < m_Tail )
                    Buffer.BlockCopy( m_Buffer, (int)m_Head, newBuffer, 0, (int)m_Size );
                else
                {
                    Buffer.BlockCopy( m_Buffer, (int)m_Head, newBuffer, 0, (int)( m_Buffer.Length - m_Head ) );
                    Buffer.BlockCopy( m_Buffer, 0, newBuffer, (int)( m_Buffer.Length - m_Head ), (int)m_Tail );
                }
            }

            m_Head = 0;
            m_Tail = m_Size;
            m_Buffer = newBuffer;
        }
        #endregion

        #region zh-CHS 共有事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<PacketLengthInfoEventArgs> s_ThreadEventPacketLength;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock s_LockThreadEventPacketLength = new SpinLock();
        #endregion
        /// <summary>
        /// 获取接收到的数据包长度
        /// </summary>
        public event EventHandler<PacketLengthInfoEventArgs> ThreadEventPacketLength
        {
            add
            {
                s_LockThreadEventPacketLength.Enter();
                {
                    s_ThreadEventPacketLength += value;
                }
                s_LockThreadEventPacketLength.Exit();
            }
            remove
            {
                s_LockThreadEventPacketLength.Enter();
                {
                    s_ThreadEventPacketLength -= value;
                }
                s_LockThreadEventPacketLength.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<PacketIdInfoEventArgs> s_ThreadEventPacketID;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock s_LockThreadEventPacketID = new SpinLock();
        #endregion
        /// <summary>
        /// 获取接收到的数据包长度
        /// </summary>
        public event EventHandler<PacketIdInfoEventArgs> ThreadEventPacketID
        {
            add
            {
                s_LockThreadEventPacketID.Enter();
                {
                    s_ThreadEventPacketID += value;
                }
                s_LockThreadEventPacketID.Exit();
            }
            remove
            {
                s_LockThreadEventPacketID.Enter();
                {
                    s_ThreadEventPacketID -= value;
                }
                s_LockThreadEventPacketID.Exit();
            }
        }
        #endregion
    }
}
#endregion
