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
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Common.LockFree
{
    /// <summary>
    /// 
    /// </summary>
    public class LockFreeHashSet<KeyT> : IEnumerable<KeyT>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public LockFreeHashSet()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public LockFreeHashSet( IEnumerable<KeyT> collection )
        {
            m_HashSet = new HashSet<KeyT>( collection );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_HashSet.Count; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private HashSet<KeyT> m_HashSet = new HashSet<KeyT>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add( KeyT key )
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>( oldHashSet );
                newHashSet.Add( key );

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void AddRange( IEnumerable<KeyT> collection )
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>( oldHashSet );

                foreach ( KeyT key in collection )
                    newHashSet.Add( key );

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void Remove( KeyT key )
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>( oldHashSet );

                newHashSet.Remove( key );

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );
        }

        /// <summary>
        /// 从当前 LockFreeHashSet 对象中移除指定集合中的所有元素。
        /// </summary>
        /// <param name="other"></param>
        public void ExceptWith( IEnumerable<KeyT> other )
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>( oldHashSet );

                newHashSet.ExceptWith( other );

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );
        }

        /// <summary>
        /// 从 LockFreeHashSet 集合中移除与指定的谓词所定义的条件相匹配的所有元素。
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int RemoveWhere( Predicate<KeyT> match )
        {
            HashSet<KeyT> tempHashSet = m_HashSet;
            if ( tempHashSet.Count <= 0 )
                return 0;

            List<KeyT> removeList = new List<KeyT>( tempHashSet.Count );

            foreach ( KeyT key in tempHashSet )
            {
                if ( match( key ) == true )
                    removeList.Add( key );
            }

            if ( removeList.Count <= 0 )
                return 0;

            int iRemoveCount = 0;

            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                iRemoveCount = 0;

                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>( oldHashSet );

                foreach ( KeyT itemKey in removeList )
                {
                    if ( newHashSet.Remove( itemKey ) == true )
                        iRemoveCount++;
                }

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );

            return iRemoveCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains( KeyT key )
        {
            return m_HashSet.Contains( key );
        }

        /// <summary>
        /// 修改当前的 LockFreeHashSet 对象，以仅包含该对象和指定集合中存在的元素。
        /// </summary>
        /// <param name="other"></param>
        public void IntersectWith( IEnumerable<KeyT> other )
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>( oldHashSet );

                newHashSet.IntersectWith( other );

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象是否为指定集合的真子集。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsProperSubsetOf( IEnumerable<KeyT> other )
        {
            return m_HashSet.IsProperSubsetOf( other );
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象是否为指定集合的真超集。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsProperSupersetOf( IEnumerable<KeyT> other )
        {
            return m_HashSet.IsProperSupersetOf( other );
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象是否为指定集合的子集。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsSubsetOf( IEnumerable<KeyT> other )
        {
            return m_HashSet.IsSubsetOf( other );
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象是否为指定集合的超集。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsSupersetOf( IEnumerable<KeyT> other )
        {
            return m_HashSet.IsSupersetOf( other );
        }

        /// <summary>
        /// 确定当前的 LockFreeHashSet 对象是否与指定的集合重叠。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Overlaps( IEnumerable<KeyT> other )
        {
            return m_HashSet.Overlaps( other );
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象与指定的集合中是否包含相同的元素。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool SetEquals( IEnumerable<KeyT> other )
        {
            return m_HashSet.SetEquals( other );
        }

        /// <summary>
        /// 修改当前的 LockFreeHashSet 对象，以仅包含该对象或指定集合中存在的元素（但不可同时包含两者中的元素）。
        /// </summary>
        /// <param name="other"></param>
        public void SymmetricExceptWith( IEnumerable<KeyT> other )
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>( oldHashSet );

                newHashSet.SymmetricExceptWith( other );

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );
        }

        /// <summary>
        /// 修改当前的 LockFreeHashSet 对象，以包含该对象本身和指定集合中存在的所有元素。
        /// </summary>
        /// <param name="other"></param>
        public void UnionWith( IEnumerable<KeyT> other )
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>( oldHashSet );

                newHashSet.UnionWith( other );

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>();

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static KeyT[] s_ZeroKeyArray = new KeyT[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private volatile KeyT[] m_KeyArray = s_ZeroKeyArray;
        /// <summary>
        /// 
        /// </summary>
        private HashSet<KeyT> m_CachedHashSet = null;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockCachedHashSet = new SpinLock();
        #endregion

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        private KeyT[] InternalToArray()
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                if ( m_CachedHashSet == m_HashSet )
                    return m_KeyArray;

                oldHashSet = m_CachedHashSet;
                newHashSet = m_HashSet;

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_CachedHashSet, newHashSet, oldHashSet ) != oldHashSet );


            KeyT[] keyArray = new KeyT[newHashSet.Count];

            int iIndex = 0;
            foreach ( KeyT key in newHashSet )
            {
                keyArray[iIndex] = key;
                ++iIndex;
            }

            // 不能总是获取最新的数据
            m_LockCachedHashSet.Enter();
            {
                if ( m_CachedHashSet == newHashSet )
                    m_KeyArray = keyArray;
            }
            m_LockCachedHashSet.Exit();

            return keyArray;
        }
        #endregion

        /// <summary>
        /// 速度比GetEnumerator(...)慢
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public KeyT[] ToArray()
        {
            return InternalToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyT[] ToArrayAndClear()
        {
            HashSet<KeyT> newHashSet = null;
            HashSet<KeyT> oldHashSet = null;

            do
            {
                oldHashSet = m_HashSet;

                newHashSet = new HashSet<KeyT>();

            } while ( Interlocked.CompareExchange<HashSet<KeyT>>( ref m_HashSet, newHashSet, oldHashSet ) != oldHashSet );

            // 开始获取数据
            KeyT[] keyArray = new KeyT[newHashSet.Count];

            int iIndex = 0;
            foreach ( KeyT key in oldHashSet )
            {
                keyArray[iIndex] = key;
                ++iIndex;
            }

            return keyArray;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 速度比ToArray(...)快
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyT> GetEnumerator()
        {
            return m_HashSet.GetEnumerator();
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