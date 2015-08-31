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

namespace Demo.Mmose.Core.Common.SafeCollections
{
    /// <summary>
    /// 
    /// </summary>
    public class SafeHashSet<KeyT> : IEnumerable<KeyT>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public SafeHashSet()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public SafeHashSet( IEnumerable<KeyT> collection )
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
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockHashSet = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void Add( KeyT key )
        {
            m_LockHashSet.EnterWriteLock();
            {
                m_HashSet.Add( key );

                m_bIsValueChange = true;
            }
            m_LockHashSet.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void AddRange( IEnumerable<KeyT> collection )
        {
            m_LockHashSet.EnterWriteLock();
            {
                foreach ( KeyT key in collection )
                    m_HashSet.Add( key );

                m_bIsValueChange = true;
            }
            m_LockHashSet.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void Remove( KeyT key )
        {
            m_LockHashSet.EnterWriteLock();
            {
                if ( m_HashSet.Remove( key ) == true )
                    m_bIsValueChange = true;
            }
            m_LockHashSet.ExitWriteLock();
        }

        /// <summary>
        /// 从当前 LockFreeHashSet 对象中移除指定集合中的所有元素。
        /// </summary>
        /// <param name="other"></param>
        public void ExceptWith( IEnumerable<KeyT> other )
        {
            m_LockHashSet.EnterWriteLock();
            {
                m_HashSet.ExceptWith( other );
                m_bIsValueChange = true;
            }
            m_LockHashSet.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int RemoveAll( Predicate<KeyT> match )
        {
            KeyT[] keyArray = this.ToArray();
            if ( keyArray.Length <= 0 )
                return 0;

            List<KeyT> removeList = new List<KeyT>( keyArray.Length );

            for ( int iIndex = 0; iIndex < keyArray.Length; iIndex++ )
            {
                KeyT key = keyArray[iIndex];
                if ( match( key ) == true )
                    removeList.Add( key );
            }

            if ( removeList.Count <= 0 )
                return 0;

            int iRemoveCount = 0;

            m_LockHashSet.EnterWriteLock();
            {
                foreach ( KeyT itemKey in removeList )
                {
                    if ( m_HashSet.Remove( itemKey ) == true )
                        iRemoveCount++;
                }

                if ( iRemoveCount > 0 )
                    m_bIsValueChange = true;
            }
            m_LockHashSet.ExitWriteLock();

            return iRemoveCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains( KeyT key )
        {
            bool bIsContains = false;

            m_LockHashSet.EnterReadLock();
            {
                bIsContains = m_HashSet.Contains( key );
            }
            m_LockHashSet.ExitReadLock();

            return bIsContains;
        }

        /// <summary>
        /// 修改当前的 LockFreeHashSet 对象，以仅包含该对象和指定集合中存在的元素。
        /// </summary>
        /// <param name="other"></param>
        public void IntersectWith( IEnumerable<KeyT> other )
        {
            m_LockHashSet.EnterWriteLock();
            {
                m_HashSet.IntersectWith( other );
                m_bIsValueChange = true;
            }
            m_LockHashSet.ExitWriteLock();
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象是否为指定集合的真子集。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsProperSubsetOf( IEnumerable<KeyT> other )
        {
            bool bIsOK = false;

            m_LockHashSet.EnterReadLock();
            {
                bIsOK = m_HashSet.IsProperSubsetOf( other );
            }
            m_LockHashSet.ExitReadLock();

            return bIsOK;
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象是否为指定集合的真超集。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsProperSupersetOf( IEnumerable<KeyT> other )
        {
            bool bIsOK = false;

            m_LockHashSet.EnterReadLock();
            {
                bIsOK = m_HashSet.IsProperSupersetOf( other );
            }
            m_LockHashSet.ExitReadLock();

            return bIsOK;
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象是否为指定集合的子集。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsSubsetOf( IEnumerable<KeyT> other )
        {
            bool bIsOK = false;

            m_LockHashSet.EnterReadLock();
            {
                bIsOK = m_HashSet.IsSubsetOf( other );
            }
            m_LockHashSet.ExitReadLock();

            return bIsOK;
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象是否为指定集合的超集。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsSupersetOf( IEnumerable<KeyT> other )
        {
            bool bIsOK = false;

            m_LockHashSet.EnterReadLock();
            {
                bIsOK = m_HashSet.IsSupersetOf( other );
            }
            m_LockHashSet.ExitReadLock();

            return bIsOK;
        }

        /// <summary>
        /// 确定当前的 LockFreeHashSet 对象是否与指定的集合重叠。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Overlaps( IEnumerable<KeyT> other )
        {
            bool bIsOK = false;

            m_LockHashSet.EnterReadLock();
            {
                bIsOK = m_HashSet.Overlaps( other );
            }
            m_LockHashSet.ExitReadLock();

            return bIsOK;
        }

        /// <summary>
        /// 确定 LockFreeHashSet 对象与指定的集合中是否包含相同的元素。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool SetEquals( IEnumerable<KeyT> other )
        {
            bool bIsOK = false;

            m_LockHashSet.EnterReadLock();
            {
                bIsOK = m_HashSet.SetEquals( other );
            }
            m_LockHashSet.ExitReadLock();

            return bIsOK;
        }

        /// <summary>
        /// 修改当前的 LockFreeHashSet 对象，以仅包含该对象或指定集合中存在的元素（但不可同时包含两者中的元素）。
        /// </summary>
        /// <param name="other"></param>
        public void SymmetricExceptWith( IEnumerable<KeyT> other )
        {
            m_LockHashSet.EnterWriteLock();
            {
                m_HashSet.SymmetricExceptWith( other );
                m_bIsValueChange = true;
            }
            m_LockHashSet.ExitWriteLock();
        }

        /// <summary>
        /// 修改当前的 LockFreeHashSet 对象，以包含该对象本身和指定集合中存在的所有元素。
        /// </summary>
        /// <param name="other"></param>
        public void UnionWith( IEnumerable<KeyT> other )
        {
            m_LockHashSet.EnterWriteLock();
            {
                m_HashSet.UnionWith( other );
                m_bIsValueChange = true;
            }
            m_LockHashSet.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            m_LockHashSet.EnterWriteLock();
            {
                m_HashSet.Clear();

                // 清空
                m_KeyArray = s_ZeroArray;
                m_bIsValueChange = false;
            }
            m_LockHashSet.ExitWriteLock();
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static KeyT[] s_ZeroArray = new KeyT[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private volatile KeyT[] m_KeyArray = s_ZeroArray;
        /// <summary>
        /// 
        /// </summary>
        private volatile bool m_bIsValueChange = true;
        #endregion

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        private void InternalToCached()
        {
            if ( m_bIsValueChange == false )
                return;

            m_LockHashSet.EnterReadLock();
            {
                if ( m_bIsValueChange == true )
                {
                    m_KeyArray = new KeyT[m_HashSet.Count];

                    int iIndex = 0;
                    foreach ( KeyT keyValuePair in m_HashSet )
                    {
                        m_KeyArray[iIndex] = keyValuePair;
                        ++iIndex;
                    }

                    // 最后设置
                    m_bIsValueChange = false;
                }
            }
            m_LockHashSet.ExitReadLock();
        }
        #endregion
        /// <summary>
        /// 这里假设读非常多，写比较少。 
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public KeyT[] ToArray()
        {
            InternalToCached();

            return m_KeyArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyT[] ToArrayAndClear()
        {
            KeyT[] keyArray = s_ZeroArray;

            m_LockHashSet.EnterWriteLock();
            {
                if ( m_bIsValueChange == true )
                {
                    keyArray = new KeyT[m_HashSet.Count];

                    int iIndex = 0;
                    foreach ( KeyT keyValuePair in m_HashSet )
                    {
                        keyArray[iIndex] = keyValuePair;
                        ++iIndex;
                    }

                    // 最后设置
                    m_bIsValueChange = false;
                }
                else
                    keyArray = m_KeyArray;

                // 清空
                m_HashSet.Clear();
                m_KeyArray = s_ZeroArray;
            }
            m_LockHashSet.ExitWriteLock();

            return keyArray;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 等同于ToArray()
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyT> GetEnumerator()
        {
            KeyT[] tempKeyArray = this.ToArray();
            if ( tempKeyArray == null )
                yield break;

            for ( int iIndex = 0; iIndex < tempKeyArray.Length; iIndex++ )
                yield return tempKeyArray[iIndex];
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