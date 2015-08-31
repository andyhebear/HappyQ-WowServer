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
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Util;
using System.Threading.Collections;
using System;
#endregion

namespace Demo.Mmose.Core.Network
{
    /// <summary>
    /// Byte的内存池
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
    public class BufferPool
    {
        #region zh-CHS 共有的结构 | en Public Struct
        /// <summary>
        /// 
        /// </summary>
        public struct PoolInfo
        {
            #region zh-CHS 共有属性 | en Public Properties
            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private string m_strName;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public string Name
            {
                get { return m_strName; }
                internal set { m_strName = value; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private long m_iBufferSize;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public long BufferSize
            {
                get { return m_iBufferSize; }
                internal set { m_iBufferSize = value; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private long m_iFreeCount;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public long FreeCount
            {
                get { return m_iFreeCount; }
                internal set { m_iFreeCount = value; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private long m_iInitialCapacity;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public long InitialCapacity
            {
                get { return m_iInitialCapacity; }
                internal set { m_iInitialCapacity = value; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private long m_iCurrentCapacity;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public long CurrentCapacity
            {
                get { return m_iCurrentCapacity; }
                internal set { m_iCurrentCapacity = value; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private long m_iMisses;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public long Misses
            {
                get { return m_iMisses; }
                internal set { m_iMisses = value; }
            }
            #endregion
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 内存池的名字
        /// </summary>
        private string m_BufferName;
        /// <summary>
        /// 数据获取的失败次数
        /// </summary>
        private long m_Misses;
        /// <summary>
        /// 数据的大小
        /// </summary>
        private long m_BufferSize;
        /// <summary>
        /// 初始的空间大小
        /// </summary>
        private long m_InitialCapacity;
        /// <summary>
        /// 内存池
        /// </summary>
        private ConcurrentQueue<byte[]> m_FreeBuffers = new ConcurrentQueue<byte[]>();
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="iInitialCapacity"></param>
        /// <param name="iBufferSize"></param>
        public BufferPool( string strBufferName, long iInitialCapacity, long iBufferSize )
        {
            m_BufferName = strBufferName;
            m_BufferSize = iBufferSize;
            m_InitialCapacity = iInitialCapacity;

            for ( int iIndex = 0; iIndex < iInitialCapacity; ++iIndex )
                m_FreeBuffers.Enqueue( new byte[iBufferSize] );

            s_Pools.Add( this );
        }
        #endregion

        #region zh-CHS 静态属性 | en Static Properties

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 存放全局Byte的内存列表
        /// </summary>
        private static SafeHashSet<BufferPool> s_Pools = new SafeHashSet<BufferPool>();
        #endregion
        /// <summary>
        /// 存放全局Byte的内存列表
        /// </summary>
        public static SafeHashSet<BufferPool> GlobalPools
        {
            get { return s_Pools; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 内存池请求数据
        /// </summary>
        /// <returns></returns>
        public byte[] AcquireBuffer()
        {
            byte[] returnByteArray = null;

            do
            {
                if ( m_FreeBuffers.Count > 0 )
                {
                    if ( m_FreeBuffers.TryDequeue( out returnByteArray ) == true )
                        break;
                }

                ++m_Misses;

                for ( int iIndex = 0; iIndex < m_InitialCapacity; ++iIndex )
                    m_FreeBuffers.Enqueue( new byte[m_BufferSize] );

                if ( m_FreeBuffers.TryDequeue( out returnByteArray ) == true )
                    break;
            } while ( true );

            return returnByteArray;
        }

        /// <summary>
        /// 内存池请释放
        /// </summary>
        /// <param name="byteBuffer"></param>
        public void ReleaseBuffer( byte[] byteBuffer )
        {
            if ( byteBuffer == null )
                throw new ArgumentNullException( "byteBuffer", "BufferPool.ReleaseBuffer(...) - byteBuffer == null error!" );

            m_FreeBuffers.Enqueue( byteBuffer );
        }

        /// <summary>
        /// 从存放全局Byte的内存列表中删除自己,被回收内存
        /// </summary>
        public void Free()
        {
            s_Pools.Remove( this );
        }

        /// <summary>
        /// 获取内存池的详细信息
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="iFreeCount"></param>
        /// <param name="iInitialCapacity"></param>
        /// <param name="iCurrentCapacity"></param>
        /// <param name="iBufferSize"></param>
        /// <param name="iMisses"></param>
        public BufferPool.PoolInfo GetPoolInfo()
        {
            BufferPool.PoolInfo poolInfo = new BufferPool.PoolInfo();

            // 该可以不锁定的,因只是读取数据而已
            poolInfo.Name = m_BufferName;
            poolInfo.Misses = m_Misses;
            poolInfo.BufferSize = m_BufferSize;
            poolInfo.FreeCount = m_FreeBuffers.Count;
            poolInfo.InitialCapacity = m_InitialCapacity;
            poolInfo.CurrentCapacity = m_InitialCapacity * ( m_Misses + 1 );

            return poolInfo;
        }
        #endregion
    }
}
#endregion

