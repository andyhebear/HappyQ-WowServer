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
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.World
{
    /// <summary>
    /// 一般用于SQL的回调
    /// </summary>
    public class WorldWaitExecute
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        internal WorldWaitExecute( BaseWorld world )
        {
            if ( world == null )
                throw new Exception( "WorldWaitExecute.WorldWaitExecute(...) - world == null error!" );

            m_World = world;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS World属性 | en World Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 管理当前的世界服务
        /// </summary>
        private BaseWorld m_World = null;
        #endregion
        /// <summary>
        /// 管理当前的世界服务
        /// </summary>
        public BaseWorld World
        {
            get { return m_World; }
        }

        #endregion

        #endregion

        #region zh-CHS 内部方法 | en Internal Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否在调用Slice(...)中...(防止多线程多次调用Slice(...)函数)
        /// </summary>
        private bool m_InSliceWaitExecute = false;
        /// <summary>
        /// 是否在调用Slice(...)中...的锁
        /// </summary>
        private ReaderWriterLockSlim m_LockInSliceWaitExecute = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal void Slice()
        {
            bool bIsChange = false;

            // 检查是否已经在处理Slice(...)的调用
            if ( ReaderWriterLockSlimEx.QuickTryEnterWriteLock( m_LockInSliceWaitExecute ) == false )
                return;
            {
                if ( m_InSliceWaitExecute == false ) // 没有锁定
                    bIsChange = m_InSliceWaitExecute = true;
            }
            m_LockInSliceWaitExecute.ExitWriteLock();

            // 已经在处理Slice(...)中
            if ( bIsChange == false && m_InSliceWaitExecute )
                return;

            IWaitExecuteInfo[] waitExecuteArray = null;
            do
            {
                waitExecuteArray = null;

                m_LocksWaitExecuteQueue.EnterWriteLock();
                {
                    if ( m_WaitExecuteQueue.Count > 0 )
                    {
                        waitExecuteArray = m_WaitExecuteQueue.ToArray();
                        m_WaitExecuteQueue.Clear();
                    }
                }
                m_LocksWaitExecuteQueue.ExitWriteLock();

                if ( waitExecuteArray == null )
                    break;

                for ( int iIndex = 0; iIndex < waitExecuteArray.Length; iIndex++ )
                    waitExecuteArray[iIndex].Execute(); 

            } while ( waitExecuteArray != null );// 可能执行的时间比较长 所以再检测一下是不是还有

            // 已经处理完Slice(...)的调用
            m_LockInSliceWaitExecute.EnterWriteLock();
            {
                m_InSliceWaitExecute = false;
            }
            m_LockInSliceWaitExecute.ExitWriteLock();
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 当前需要处理的集合
        /// </summary>
        private Queue<IWaitExecuteInfo> m_WaitExecuteQueue = new Queue<IWaitExecuteInfo>();
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LocksWaitExecuteQueue = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="waitCallBack"></param>
        [MultiThreadedWarning( "zh-CHS", "此处IWaitExecuteInfo的回调只会同步在一个线程中处理，即处理完成以后才会再次处理回调:警告!" )]
        public void JoinWaitExecuteQueue( IWaitExecuteInfo waitExecuteInfo )
        {
            if ( m_World == null )
                throw new Exception( "WorldWaitExecute.JoinWaitExecuteQueue(...) - m_World == null error!" );

            if ( waitExecuteInfo == null )
                throw new Exception( "WorldWaitExecute.JoinWaitExecuteQueue(...) - waitExecuteInfo == null error!" );

            m_LocksWaitExecuteQueue.EnterWriteLock();
            {
                m_WaitExecuteQueue.Enqueue( waitExecuteInfo );
            }
            m_LocksWaitExecuteQueue.ExitWriteLock();
            
            m_World.SetWorldSignal();
        }

        #endregion
    }
}
#endregion