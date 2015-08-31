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
    /// 具有线程锁定的Dictionary类
    /// </summary>
    /// <typeparam name="KEY"></typeparam>
    /// <typeparam name="VALUE"></typeparam>
    public class SafeDictionary<KeyT, ValueT> : IEnumerable<KeyValuePair<KeyT, ValueT>>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public SafeDictionary()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public SafeDictionary( IDictionary<KeyT, ValueT> dictionary )
        {
            m_Dictionary = new Dictionary<KeyT, ValueT>( dictionary );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public SafeDictionary( int iCapacity )
        {
            m_Dictionary = new Dictionary<KeyT, ValueT>( iCapacity );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_Dictionary.Count; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ValueT this[KeyT key]
        {
            get
            {
                ValueT tempVALUE = default( ValueT );

                m_LockDictionary.EnterReadLock();
                {
                    tempVALUE = m_Dictionary[key];
                }
                m_LockDictionary.ExitReadLock();

                return tempVALUE;
            }
            set
            {
                m_LockDictionary.EnterWriteLock();
                {
                    m_Dictionary[key] = value;

                    m_bIsValueChange = true;
                }
                m_LockDictionary.ExitWriteLock();
            }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<KeyT, ValueT> m_Dictionary = new Dictionary<KeyT, ValueT>();
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockDictionary = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void Add( KeyT key, ValueT value )
        {
            m_LockDictionary.EnterWriteLock();
            {
                m_Dictionary[key] = value;

                m_bIsValueChange = true;
            }
            m_LockDictionary.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void AddRange( IEnumerable<KeyValuePair<KeyT, ValueT>> dictionary )
        {
            m_LockDictionary.EnterWriteLock();
            {
                foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in dictionary )
                    m_Dictionary[keyValuePair.Key] = keyValuePair.Value;

                m_bIsValueChange = true;
            }
            m_LockDictionary.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void Remove( KeyT key )
        {
            m_LockDictionary.EnterWriteLock();
            {
                if ( m_Dictionary.Remove( key ) == true )
                    m_bIsValueChange = true;
            }
            m_LockDictionary.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int RemoveAll( Predicate<KeyT, ValueT> match )
        {
            KeyValuePair<KeyT, ValueT>[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return 0;

            List<KeyT> removeList = new List<KeyT>( valueArray.Length );

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT> itemT = valueArray[iIndex];
                if ( match( itemT.Key, itemT.Value ) == true )
                    removeList.Add( itemT.Key );
            }

            if ( removeList.Count <= 0 )
                return 0;

            int iRemoveCount = 0;

            m_LockDictionary.EnterWriteLock();
            {
                foreach ( KeyT itemKey in removeList )
                {
                    if ( m_Dictionary.Remove( itemKey ) == true )
                        iRemoveCount++;
                }

                if ( iRemoveCount > 0 )
                    m_bIsValueChange = true;
            }
            m_LockDictionary.ExitWriteLock();

            return iRemoveCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public ValueT GetValue( KeyT key )
        {
            ValueT returnVALUE = default( ValueT );

            m_LockDictionary.EnterReadLock();
            {
                m_Dictionary.TryGetValue( key, out returnVALUE );
            }
            m_LockDictionary.ExitReadLock();

            return returnVALUE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public bool TryGetValue( KeyT key, out ValueT value )
        {
            value = default( ValueT );

            bool returnValue = false;

            m_LockDictionary.EnterReadLock();
            {
                returnValue = m_Dictionary.TryGetValue( key, out value );
            }
            m_LockDictionary.ExitReadLock();

            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey( KeyT key )
        {
            bool bIsContains = false;

            m_LockDictionary.EnterReadLock();
            {
                bIsContains = m_Dictionary.ContainsKey( key );
            }
            m_LockDictionary.ExitReadLock();

            return bIsContains;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue( ValueT value )
        {
            bool bIsContains = false;

            m_LockDictionary.EnterReadLock();
            {
                bIsContains = m_Dictionary.ContainsValue( value );
            }
            m_LockDictionary.ExitReadLock();

            return bIsContains;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Find( Predicate<KeyT, ValueT> match, out KeyValuePair<KeyT, ValueT> findKeyValuePair )
        {
            findKeyValuePair = new KeyValuePair<KeyT, ValueT>( default( KeyT ), default( ValueT ) );

            KeyValuePair<KeyT, ValueT>[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return false;

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT> keyValuePair = valueArray[iIndex];
                if ( match( keyValuePair.Key, keyValuePair.Value ) == true )
                {
                    findKeyValuePair = keyValuePair;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public KeyValuePair<KeyT, ValueT>[] FindAll( Predicate<KeyT, ValueT> match )
        {
            List<KeyValuePair<KeyT, ValueT>> keyValuePairList = new List<KeyValuePair<KeyT, ValueT>>();

            KeyValuePair<KeyT, ValueT>[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return keyValuePairList.ToArray();
            else
                keyValuePairList.Capacity = valueArray.Length;

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT> keyValuePair = valueArray[iIndex];
                if ( match( keyValuePair.Key, keyValuePair.Value ) == true )
                    keyValuePairList.Add( keyValuePair );
            }

            return keyValuePairList.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void ForEach( Action<KeyT, ValueT> action )
        {
            KeyValuePair<KeyT, ValueT>[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return;

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT> keyValuePair = valueArray[iIndex];
                action( keyValuePair.Key, keyValuePair.Value );
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Exists( Predicate<KeyT, ValueT> match )
        {
            KeyValuePair<KeyT, ValueT>[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return false;

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT> keyValuePair = valueArray[iIndex];
                if ( match( keyValuePair.Key, keyValuePair.Value ) == true )
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            m_LockDictionary.EnterWriteLock();
            {
                m_Dictionary.Clear();

                // 清空
                m_KeyArray = s_ZeroKeyArray;
                m_ValueArray = s_ZeroValueArray;
                m_KeyValuePairArray = s_ZeroKeyValuePairArray;
                m_bIsValueChange = false;
            }
            m_LockDictionary.ExitWriteLock();
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static KeyT[] s_ZeroKeyArray = new KeyT[0];
        /// <summary>
        /// 
        /// </summary>
        private readonly static ValueT[] s_ZeroValueArray = new ValueT[0];
        /// <summary>
        /// 
        /// </summary>
        private readonly static KeyValuePair<KeyT, ValueT>[] s_ZeroKeyValuePairArray = new KeyValuePair<KeyT, ValueT>[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private volatile KeyT[] m_KeyArray = s_ZeroKeyArray;
        /// <summary>
        /// 
        /// </summary>
        private volatile ValueT[] m_ValueArray = s_ZeroValueArray;
        /// <summary>
        /// 
        /// </summary>
        private volatile KeyValuePair<KeyT, ValueT>[] m_KeyValuePairArray = s_ZeroKeyValuePairArray;
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

            m_LockDictionary.EnterReadLock();
            {
                if ( m_bIsValueChange == true )
                {
                    m_KeyArray = new KeyT[m_Dictionary.Count];
                    m_ValueArray = new ValueT[m_Dictionary.Count];
                    m_KeyValuePairArray = new KeyValuePair<KeyT, ValueT>[m_Dictionary.Count];

                    int iIndex = 0;
                    foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in m_Dictionary )
                    {
                        m_KeyArray[iIndex] = keyValuePair.Key;
                        m_ValueArray[iIndex] = keyValuePair.Value;
                        m_KeyValuePairArray[iIndex] = keyValuePair;
                        ++iIndex;
                    }

                    // 最后设置
                    m_bIsValueChange = false;
                }
            }
            m_LockDictionary.ExitReadLock();
        }
        #endregion
        /// <summary>
        /// 这里假设读非常多，写比较少。 
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public KeyValuePair<KeyT, ValueT>[] ToArray()
        {
            InternalToCached();

            return m_KeyValuePairArray;
        }

        /// <summary>
        /// 这里假设读非常多，写比较少。 
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public ValueT[] ToArrayValues()
        {
            InternalToCached();

            return m_ValueArray;
        }

        /// <summary>
        /// 这里假设读非常多，写比较少。 
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public KeyT[] ToArrayKeys()
        {
            InternalToCached();

            return m_KeyArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<KeyT, ValueT>[] ToArrayAndClear()
        {
            KeyValuePair<KeyT, ValueT>[] keyValuePairArray = s_ZeroKeyValuePairArray;

            m_LockDictionary.EnterWriteLock();
            {
                if ( m_bIsValueChange == true )
                {
                    keyValuePairArray = new KeyValuePair<KeyT, ValueT>[m_Dictionary.Count];

                    int iIndex = 0;
                    foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in m_Dictionary )
                    {
                        keyValuePairArray[iIndex] = keyValuePair;
                        ++iIndex;
                    }

                    // 最后设置
                    m_bIsValueChange = false;
                }
                else
                    keyValuePairArray = m_KeyValuePairArray;

                // 清空
                m_Dictionary.Clear();
                m_KeyArray = s_ZeroKeyArray;
                m_ValueArray = s_ZeroValueArray;
                m_KeyValuePairArray = s_ZeroKeyValuePairArray;
            }
            m_LockDictionary.ExitWriteLock();

            return keyValuePairArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT[] ToArrayValuesAndClear()
        {
            ValueT[] valueArray = s_ZeroValueArray;

            m_LockDictionary.EnterWriteLock();
            {
                if ( m_bIsValueChange == true )
                {
                    valueArray = new ValueT[m_Dictionary.Count];

                    int iIndex = 0;
                    foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in m_Dictionary )
                    {
                        valueArray[iIndex] = keyValuePair.Value;
                        ++iIndex;
                    }

                    // 最后设置
                    m_bIsValueChange = false;
                }
                else
                    valueArray = m_ValueArray;

                // 清空
                m_Dictionary.Clear();
                m_KeyArray = s_ZeroKeyArray;
                m_ValueArray = s_ZeroValueArray;
                m_KeyValuePairArray = s_ZeroKeyValuePairArray;
            }
            m_LockDictionary.ExitWriteLock();

            return valueArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyT[] ToArrayKeysAndClear()
        {
            KeyT[] keyArray = s_ZeroKeyArray;

            m_LockDictionary.EnterWriteLock();
            {
                if ( m_bIsValueChange == true )
                {
                    keyArray = new KeyT[m_Dictionary.Count];

                    int iIndex = 0;
                    foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in m_Dictionary )
                    {
                        keyArray[iIndex] = keyValuePair.Key;
                        ++iIndex;
                    }

                    // 最后设置
                    m_bIsValueChange = false;
                }
                else
                    keyArray = m_KeyArray;

                // 清空
                m_Dictionary.Clear();
                m_KeyArray = s_ZeroKeyArray;
                m_ValueArray = s_ZeroValueArray;
                m_KeyValuePairArray = s_ZeroKeyValuePairArray;
            }
            m_LockDictionary.ExitWriteLock();

            return keyArray;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 等同于ToArray()
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<KeyT, ValueT>> GetEnumerator()
        {
            KeyValuePair<KeyT, ValueT>[] tempKeyValuePairArray = this.ToArray();
            if ( tempKeyValuePairArray == null )
                yield break;

            for ( int iIndex = 0; iIndex < tempKeyValuePairArray.Length; iIndex++ )
                yield return tempKeyValuePairArray[iIndex];
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