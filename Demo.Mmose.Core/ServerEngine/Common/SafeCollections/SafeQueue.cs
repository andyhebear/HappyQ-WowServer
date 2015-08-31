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
using System.Threading;
using Demo.Mmose.Core.Util;
using System.Collections;
#endregion

namespace Demo.Mmose.Core.Common.SafeCollections
{
    /// <summary>
    /// 表示对象的先进先出集合。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SafeQueue<ValueT> : IEnumerable<ValueT>
    {
        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_Queue.Count; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Queue<ValueT> m_Queue = new Queue<ValueT>();
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockQueue = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void Enqueue( ValueT value )
        {
            m_LockQueue.EnterWriteLock();
            {
                m_Queue.Enqueue( value );

                m_bIsValueChange = true;
            }
            m_LockQueue.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public ValueT Dequeue()
        {
            ValueT tempVALUE = default( ValueT );

            m_LockQueue.EnterWriteLock();
            {
                tempVALUE = m_Queue.Dequeue();

                m_bIsValueChange = true;
            }
            m_LockQueue.ExitWriteLock();

            return tempVALUE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT Peek()
        {
            ValueT tempVALUE = default( ValueT );

            m_LockQueue.EnterReadLock();
            {
                tempVALUE = m_Queue.Peek();
            }
            m_LockQueue.ExitReadLock();

            return tempVALUE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains( ValueT value )
        {
            bool bIsContains = false;

            m_LockQueue.EnterReadLock();
            {
                bIsContains = m_Queue.Contains( value );
            }
            m_LockQueue.ExitReadLock();

            return bIsContains;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrayT"></param>
        /// <param name="iArrayIndex"></param>
        public void CopyTo( ValueT[] arrayT, int iArrayIndex )
        {
            m_LockQueue.EnterReadLock();
            {
                m_Queue.CopyTo( arrayT, iArrayIndex );
            }
            m_LockQueue.ExitReadLock();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            m_LockQueue.EnterWriteLock();
            {
                m_Queue.Clear();

                m_ValueArray = s_ZeroArray;
                m_bIsValueChange = false;
            }
            m_LockQueue.ExitWriteLock();
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static ValueT[] s_ZeroArray = new ValueT[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private volatile ValueT[] m_ValueArray = s_ZeroArray;
        /// <summary>
        /// 
        /// </summary>
        private volatile bool m_bIsValueChange = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public ValueT[] ToArray()
        {
            if ( m_bIsValueChange == false )
                return m_ValueArray;

            m_LockQueue.EnterReadLock();
            {
                if ( m_bIsValueChange == true )
                {
                    m_ValueArray = m_Queue.ToArray();

                    m_bIsValueChange = false;
                }
            }
            m_LockQueue.ExitReadLock();

            return m_ValueArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT[] ToArrayAndClear()
        {
            ValueT[] valueArray = s_ZeroArray;

            m_LockQueue.EnterWriteLock();
            {
                if ( m_bIsValueChange == true )
                {
                    valueArray = m_Queue.ToArray();

                    m_bIsValueChange = false;
                }
                else
                    valueArray = m_ValueArray;

                // 清空
                m_Queue.Clear();
                m_ValueArray = s_ZeroArray;
            }
            m_LockQueue.ExitWriteLock();

            return valueArray;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 等同于ToArray()
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ValueT> GetEnumerator()
        {
            ValueT[] tempValueArray = this.ToArray();
            if ( tempValueArray == null )
                yield break;

            for ( int iIndex = 0; iIndex < tempValueArray.Length; iIndex++ )
                    yield return tempValueArray[iIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
#endregion
