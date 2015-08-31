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
using Demo.Mmose.Core.Collections;
using Demo.Mmose.Core.Util;
using System.Collections;
#endregion

namespace Demo.Mmose.Core.Common.SafeCollections
{
    /// <summary>
    /// 
    /// </summary>
    public class SafeMultiDictionary<KeyT, ValueT> : IEnumerable<KeyValuePair<KeyT, IEnumerable<ValueT>>>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// allowDuplicateValues == false
        /// </summary>
        public SafeMultiDictionary()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public SafeMultiDictionary( bool allowDuplicateValues )
        {
            m_MultiDictionary = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_MultiDictionary.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<ValueT> this[KeyT key]
        {
            get { return this.ToArrayValuesByKey( key ); }
            set { this.AddMany( key, value ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<KeyT> Keys
        {
            get { return this.ToArrayKeys(); }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MultiDictionary<KeyT, ValueT> m_MultiDictionary = new MultiDictionary<KeyT, ValueT>( false );
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockMultiDictionary = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add( KeyT key, ValueT value )
        {
            m_LockMultiDictionary.EnterWriteLock();
            {
                m_MultiDictionary.Add( key, value );

                m_bIsValueChange = true;
            }
            m_LockMultiDictionary.ExitWriteLock();
        }

        /// <summary>
        /// 请尽可能的使用AddMany(...) 比 Add(...) 添加单个快得多
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void AddMany( KeyT key, IEnumerable<ValueT> values )
        {
            m_LockMultiDictionary.EnterWriteLock();
            {
                m_MultiDictionary.AddMany( key, values );

                m_bIsValueChange = true;
            }
            m_LockMultiDictionary.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove( KeyT key )
        {
            bool bReturn = false;

            m_LockMultiDictionary.EnterWriteLock();
            {
                bReturn = m_MultiDictionary.Remove( key );

                m_bIsValueChange = true;
            }
            m_LockMultiDictionary.ExitWriteLock();

            return bReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove( KeyT key, ValueT value )
        {
            bool bReturn = false;

            m_LockMultiDictionary.EnterWriteLock();
            {
                bReturn = m_MultiDictionary.Remove( key, value );

                m_bIsValueChange = true;
            }
            m_LockMultiDictionary.ExitWriteLock();

            return bReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void RemoveMany( IEnumerable<KeyT> key )
        {
            m_LockMultiDictionary.EnterWriteLock();
            {
                m_MultiDictionary.RemoveMany( key );

                m_bIsValueChange = true;
            }
            m_LockMultiDictionary.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void RemoveMany( KeyT key, IEnumerable<ValueT> values )
        {
            m_LockMultiDictionary.EnterWriteLock();
            {
                m_MultiDictionary.RemoveMany( key, values );

                m_bIsValueChange = true;
            }
            m_LockMultiDictionary.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int RemoveAll( Predicate<KeyT, ValueT> match )
        {
            KeyValuePair<KeyT, ValueT[]>[] tempKeyValuePairArray = this.ToArray();
            if ( tempKeyValuePairArray.Length <= 0 )
                return 0;

            List<KeyValuePair<KeyT, ValueT>> removeList = new List<KeyValuePair<KeyT, ValueT>>( tempKeyValuePairArray.Length );

            for ( int iIndex = 0; iIndex < tempKeyValuePairArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT[]> keyValuePair = tempKeyValuePairArray[iIndex];

                for ( int iIndex2 = 0; iIndex2 < keyValuePair.Value.Length; iIndex2++ )
                {
                    ValueT value = keyValuePair.Value[iIndex2];
                    if ( match( keyValuePair.Key, value ) == true )
                        removeList.Add( new KeyValuePair<KeyT, ValueT>( keyValuePair.Key, value ) );
                }
            }

            if ( removeList.Count <= 0 )
                return 0;

            int iRemoveCount = 0;

            m_LockMultiDictionary.EnterWriteLock();
            {
                foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in removeList )
                {
                    if ( m_MultiDictionary.Remove( keyValuePair.Key, keyValuePair.Value ) == true )
                        iRemoveCount++;
                }

                m_bIsValueChange = true;
            }
            m_LockMultiDictionary.ExitWriteLock();

            return iRemoveCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public IEnumerable<ValueT> GetValues( KeyT key )
        {
            return this.ToArrayValuesByKey( key );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public bool TryGetValues( KeyT key, out IEnumerable<ValueT> values )
        {
            values = null;

            InternalToArray();

            Dictionary<KeyT, ValueT[]> tempValueArray = m_ValueDictionary;

            ValueT[] outValues = s_ZeroValueArray;

            bool returnResult = tempValueArray.TryGetValue( key, out outValues );
            if ( returnResult == true )
                values = outValues;

            return returnResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey( KeyT key )
        {
            bool bReturn = false;

            m_LockMultiDictionary.EnterReadLock();
            {
                bReturn = m_MultiDictionary.ContainsKey( key );
            }
            m_LockMultiDictionary.ExitReadLock();

            return bReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains( KeyT key, ValueT value )
        {
            bool bReturn = false;

            m_LockMultiDictionary.EnterReadLock();
            {
                bReturn = m_MultiDictionary.Contains( key, value );
            }
            m_LockMultiDictionary.ExitReadLock();

            return bReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Find( Predicate<KeyT, ValueT> match, out KeyValuePair<KeyT, ValueT> findKeyValuePair )
        {
            findKeyValuePair = new KeyValuePair<KeyT, ValueT>( default( KeyT ), default( ValueT ) );

            KeyValuePair<KeyT, ValueT[]>[] tempKeyValuePairArray = this.ToArray();
            if ( tempKeyValuePairArray.Length <= 0 )
                return false;

            for ( int iIndex = 0; iIndex < tempKeyValuePairArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT[]> keyValuePair = tempKeyValuePairArray[iIndex];

                for ( int iIndex2 = 0; iIndex2 < keyValuePair.Value.Length; iIndex2++ )
                {
                    ValueT value = keyValuePair.Value[iIndex2];
                    if ( match( keyValuePair.Key, value ) == true )
                    {
                        findKeyValuePair = new KeyValuePair<KeyT, ValueT>( keyValuePair.Key, value );
                        return true;
                    }
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

            KeyValuePair<KeyT, ValueT[]>[] tempKeyValuePairArray = this.ToArray();
            if ( tempKeyValuePairArray.Length <= 0 )
                return keyValuePairList.ToArray();
            else
                keyValuePairList.Capacity = tempKeyValuePairArray.Length;

            for ( int iIndex = 0; iIndex < tempKeyValuePairArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT[]> keyValuePair = tempKeyValuePairArray[iIndex];

                for ( int iIndex2 = 0; iIndex2 < keyValuePair.Value.Length; iIndex2++ )
                {
                    ValueT value = keyValuePair.Value[iIndex2];
                    if ( match( keyValuePair.Key, value ) == true )
                        keyValuePairList.Add( new KeyValuePair<KeyT, ValueT>( keyValuePair.Key, value ) );
                }
            }

            return keyValuePairList.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void ForEach( Action<KeyT, ValueT> action )
        {
            KeyValuePair<KeyT, ValueT[]>[] tempKeyValuePairArray = this.ToArray();
            if ( tempKeyValuePairArray.Length <= 0 )
                return;

            for ( int iIndex = 0; iIndex < tempKeyValuePairArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT[]> keyValuePair = tempKeyValuePairArray[iIndex];

                for ( int iIndex2 = 0; iIndex2 < keyValuePair.Value.Length; iIndex2++ )
                {
                    ValueT value = keyValuePair.Value[iIndex2];
                    action( keyValuePair.Key, value );
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Exists( Predicate<KeyT, ValueT> match )
        {
            KeyValuePair<KeyT, ValueT[]>[] tempKeyValuePairArray = this.ToArray();
            if ( tempKeyValuePairArray.Length <= 0 )
                return false;

            for ( int iIndex = 0; iIndex < tempKeyValuePairArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT[]> keyValuePair = tempKeyValuePairArray[iIndex];

                for ( int iIndex2 = 0; iIndex2 < keyValuePair.Value.Length; iIndex2++ )
                {
                    ValueT value = keyValuePair.Value[iIndex2];
                    if ( match( keyValuePair.Key, value ) == true )
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        void Clear()
        {
            m_LockMultiDictionary.EnterWriteLock();
            {
                m_MultiDictionary.Clear();

                m_KeyArray = s_ZeroKeyArray;
                m_KeyValuePairArray = s_ZeroKeyValuePairArray;
                m_ValueDictionary.Clear();
                m_bIsValueChange = false;
            }
            m_LockMultiDictionary.ExitWriteLock();
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
        private readonly static KeyValuePair<KeyT, ValueT[]>[] s_ZeroKeyValuePairArray = new KeyValuePair<KeyT, ValueT[]>[0];
        /// <summary>
        /// 
        /// </summary>
        private readonly static int DICTIONARY_VALUE_CAPACITY = 1024;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private volatile KeyT[] m_KeyArray = s_ZeroKeyArray;
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<KeyT, ValueT[]> m_ValueDictionary = new Dictionary<KeyT, ValueT[]>( DICTIONARY_VALUE_CAPACITY );
        /// <summary>
        /// 
        /// </summary>
        private volatile KeyValuePair<KeyT, ValueT[]>[] m_KeyValuePairArray = s_ZeroKeyValuePairArray;
        /// <summary>
        /// 
        /// </summary>
        private volatile bool m_bIsValueChange = true;
        #endregion

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        private void InternalToArray()
        {
            if ( m_bIsValueChange == false )
                return;

            m_LockMultiDictionary.EnterReadLock();
            {
                if ( m_bIsValueChange == true )
                {
                    m_KeyArray = new KeyT[m_MultiDictionary.Count];
                    m_KeyValuePairArray = new KeyValuePair<KeyT, ValueT[]>[m_MultiDictionary.Count];

                    m_ValueDictionary.Clear();

                    int iIndex = 0;
                    foreach ( KeyValuePair<KeyT,  ICollection<ValueT>> keyValuePair in m_MultiDictionary )
                    {
                        m_KeyArray[iIndex] = keyValuePair.Key;

                        ValueT[] valueArray = new ValueT[keyValuePair.Value.Count];

                        int iIndex2 = 0;
                        foreach ( ValueT value in keyValuePair.Value )
                        {
                            valueArray[iIndex2] = value;

                            ++iIndex2;
                        }

                        m_ValueDictionary.Add( keyValuePair.Key, valueArray );
                        m_KeyValuePairArray[iIndex] = new KeyValuePair<KeyT, ValueT[]>( keyValuePair.Key, valueArray );

                        ++iIndex;
                    }

                    m_bIsValueChange = false;
                }
            }
            m_LockMultiDictionary.ExitReadLock();
        }
        #endregion
        /// <summary>
        /// 这里假设读非常多，写比较少。 
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public KeyValuePair<KeyT, ValueT[]>[] ToArray()
        {
            InternalToArray();

            return m_KeyValuePairArray;
        }

        /// <summary>
        /// 这里假设读非常多，写比较少。 
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public ValueT[] ToArrayValuesByKey( KeyT key )
        {
            InternalToArray();

            ValueT[] returnValues = s_ZeroValueArray;

            m_ValueDictionary.TryGetValue( key, out returnValues );

            return returnValues;
        }

        /// <summary>
        /// 这里假设读非常多，写比较少。 
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public KeyT[] ToArrayKeys()
        {
            InternalToArray();

            return m_KeyArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<KeyT, ValueT[]>[] ToArrayAndClear()
        {
            KeyValuePair<KeyT, ValueT[]>[] keyValuePairArray = s_ZeroKeyValuePairArray;

            m_LockMultiDictionary.EnterWriteLock();
            {
                if ( m_bIsValueChange == true )
                {
                    keyValuePairArray = new KeyValuePair<KeyT, ValueT[]>[m_MultiDictionary.Count];

                    int iIndex = 0;
                    foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in m_MultiDictionary )
                    {
                        ValueT[] valueArray = new ValueT[keyValuePair.Value.Count];

                        int iIndex2 = 0;
                        foreach ( ValueT value in keyValuePair.Value )
                        {
                            valueArray[iIndex2] = value;

                            ++iIndex2;
                        }

                        keyValuePairArray[iIndex] = new KeyValuePair<KeyT, ValueT[]>( keyValuePair.Key, valueArray );

                        ++iIndex;
                    }

                    m_bIsValueChange = false;
                }
                else
                    keyValuePairArray = m_KeyValuePairArray;

                // 清空
                m_MultiDictionary.Clear();
                m_KeyArray = s_ZeroKeyArray;
                m_KeyValuePairArray = s_ZeroKeyValuePairArray;
                m_ValueDictionary.Clear();
            }
            m_LockMultiDictionary.ExitWriteLock();

            return keyValuePairArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT[] ToArrayValuesByKeyAndClear( KeyT key )
        {
            ValueT[] valueArray = s_ZeroValueArray;

            m_LockMultiDictionary.EnterWriteLock();
            {
                if ( m_bIsValueChange == true )
                {
                    EqualityComparer<KeyT> equalityComparer = EqualityComparer<KeyT>.Default;

                    foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in m_MultiDictionary )
                    {
                        if ( equalityComparer.Equals( keyValuePair.Key, key ) == true )
                        {
                            ValueT[] tempValueArray = new ValueT[keyValuePair.Value.Count];

                            int iIndex = 0;
                            foreach ( ValueT value in keyValuePair.Value )
                            {
                                tempValueArray[iIndex] = value;

                                ++iIndex;
                            }

                            valueArray = tempValueArray;
                            break;
                        }
                    }

                    m_bIsValueChange = false;
                }
                else
                    m_ValueDictionary.TryGetValue( key, out valueArray );

                // 清空
                m_MultiDictionary.Clear();
                m_KeyArray = s_ZeroKeyArray;
                m_KeyValuePairArray = s_ZeroKeyValuePairArray;
                m_ValueDictionary.Clear();
            }
            m_LockMultiDictionary.ExitWriteLock();

            return valueArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyT[] ToArrayKeysAndClear()
        {
            KeyT[] keyArray = s_ZeroKeyArray;

            m_LockMultiDictionary.EnterWriteLock();
            {
                if ( m_bIsValueChange == true )
                {
                    m_KeyArray = new KeyT[m_MultiDictionary.Count];

                    int iIndex = 0;
                    foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in m_MultiDictionary )
                    {
                        m_KeyArray[iIndex] = keyValuePair.Key;

                        ++iIndex;
                    }

                    m_bIsValueChange = false;
                }
                else
                    keyArray = m_KeyArray;

                // 清空
                m_MultiDictionary.Clear();
                m_KeyArray = s_ZeroKeyArray;
                m_KeyValuePairArray = s_ZeroKeyValuePairArray;
                m_ValueDictionary.Clear();
            }
            m_LockMultiDictionary.ExitWriteLock();

            return keyArray;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 等同于ToArray()
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<KeyT, IEnumerable<ValueT>>> GetEnumerator()
        {
            KeyValuePair<KeyT, ValueT[]>[] tempKeyValuePairArray = this.ToArray();
            if ( tempKeyValuePairArray == null )
                yield break;

            for ( int iIndex = 0; iIndex < tempKeyValuePairArray.Length; iIndex++ )
            {
                KeyValuePair<KeyT, ValueT[]> keyValuePair = tempKeyValuePairArray[iIndex];

                yield return new KeyValuePair<KeyT, IEnumerable<ValueT>>( keyValuePair.Key, keyValuePair.Value );
            }
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
