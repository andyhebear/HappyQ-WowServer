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
using System.Threading;
using Demo.Mmose.Core.Util;
using System.Diagnostics;
#endregion

namespace Demo.Mmose.Core.Common.SupportSlice
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SliceUpdate<T> : IUpdateSlice<T> where T : ISupportSlice
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bMultiThreadedCall"></param>
        public SliceUpdate( bool bMultiThreadedCall )
        {
            m_MultiThreadedCall = bMultiThreadedCall;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_MultiThreadedCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool MultiThreadedCall
        {
            get { return m_MultiThreadedCall; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int UPDATE_SLICE_QUEUE_CAPACITY = 1024;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private Queue<T> m_SliceQueue = new Queue<T>( UPDATE_SLICE_QUEUE_CAPACITY );
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockSliceQueue = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        public void Slice()
        {
            if ( m_SliceQueue.Count <= 0 )
                return;

            // 使用数组减少锁定时间
            T[] arrayT = null;

            if ( SpinLockEx.QuickTryEnter( ref m_LockSliceQueue ) == false ) return;
            {
                if ( m_SliceQueue.Count > 0 )
                {
                    arrayT = m_SliceQueue.ToArray();
                    m_SliceQueue.Clear();
                }
            }
            m_LockSliceQueue.Exit();

            // 如果没有需要处理的数据则返回
            if ( arrayT == null )
                return;

            // 现在的时间
            DateTime nowTime = DateTime.Now;

            // 用于计算经过的时间（因为Stopwatch的计算速度比DateTime.Now快近3倍）
            Stopwatch updateTime = Stopwatch.StartNew();

            for ( int iIndex = 0; iIndex < arrayT.Length; iIndex++ )
            {
                T itemT = arrayT[iIndex];
                itemT.OnProcessSlice( nowTime + updateTime.Elapsed );

                if ( m_MultiThreadedCall == false )
                    itemT.OutLockProcessSlice();
            }

            // 计算结束
            updateTime.Stop();
        }
        #endregion

        #region zh-CHS IUpdateSlice接口实现 | en IUpdateSlice Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        public void UpdateSlice( T dataT )
        {
            if ( m_MultiThreadedCall == false && dataT.InLockProcessSlice() == false )
                return;

            m_LockSliceQueue.Enter();
            {
                m_SliceQueue.Enqueue( dataT );
            }
            m_LockSliceQueue.Exit();
        }
        #endregion
    }
}
#endregion