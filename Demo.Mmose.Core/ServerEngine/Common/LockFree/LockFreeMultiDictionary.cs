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
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Demo.Mmose.Core.Collections;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.Common.LockFree
{
    /// <summary>
    /// 不是什么情况都可以使用LockFreeMultiDictionary的，不然你会得到相反的效果（性能很差）
    /// 这里假设读非常多，写非常非常少。 
    /// 这种方法的好处是在获取数值的时候没有任何lock，从而极大的提高了性能
    /// </summary>
    /// <typeparam name="KeyT"></typeparam>
    /// <typeparam name="ValueT"></typeparam>
    public class LockFreeMultiDictionary<KeyT, ValueT> : IEnumerable<KeyValuePair<KeyT, IEnumerable<ValueT>>>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// allowDuplicateValues == false
        /// </summary>
        /// <param name="iCapacity"></param>
        public LockFreeMultiDictionary()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public LockFreeMultiDictionary( bool allowDuplicateValues )
        {
            m_AllowDuplicateValues = allowDuplicateValues;
            m_MultiDictionary = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
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
            get { return m_MultiDictionary[key]; }
            set { this.ReplaceMany( key, value ); }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_AllowDuplicateValues = false;
        /// <summary>
        /// 
        /// </summary>
        private MultiDictionary<KeyT, ValueT> m_MultiDictionary = new MultiDictionary<KeyT, ValueT>( false );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add( KeyT key, ValueT value )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
                foreach ( var item in oldMultiDict )
                    newMultiDict.AddMany( item.Key, item.Value );

                newMultiDict.Add( key, value );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );
        }

        /// <summary>
        /// 请尽可能的使用AddMany(...) 比 Add(...) 添加单个快得多
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void AddMany( KeyT key, IEnumerable<ValueT> values )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
                foreach ( var item in oldMultiDict )
                    newMultiDict.AddMany( item.Key, item.Value );

                newMultiDict.AddMany( key, values );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void Remove( KeyT key )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
                foreach ( var item in oldMultiDict )
                    newMultiDict.AddMany( item.Key, item.Value );

                newMultiDict.Remove( key );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void Remove( KeyT key, ValueT value )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
                foreach ( var item in oldMultiDict )
                    newMultiDict.AddMany( item.Key, item.Value );

                newMultiDict.Remove( key, value );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void RemoveMany( IEnumerable<KeyT> key )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
                foreach ( var item in oldMultiDict )
                    newMultiDict.AddMany( item.Key, item.Value );

                newMultiDict.RemoveMany( key );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void RemoveMany( KeyT key, IEnumerable<ValueT> values )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
                foreach ( var item in oldMultiDict )
                    newMultiDict.AddMany( item.Key, item.Value );

                newMultiDict.RemoveMany( key, values );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int RemoveAll( Predicate<KeyT, ValueT> match )
        {
            MultiDictionary<KeyT, ValueT> tempMultiDictionary = m_MultiDictionary;
            if ( tempMultiDictionary.Count <= 0 )
                return 0;

            List<KeyValuePair<KeyT, ValueT>> removeList = new List<KeyValuePair<KeyT, ValueT>>( tempMultiDictionary.Count );

            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in tempMultiDictionary )
            {
                foreach ( ValueT valueItem in keyValuePair.Value )
                {
                    if ( match( keyValuePair.Key, valueItem ) == true )
                        removeList.Add( new KeyValuePair<KeyT, ValueT>( keyValuePair.Key, valueItem ) );
                }
            }

            if ( removeList.Count <= 0 )
                return 0;

            int iRemoveCount = 0;

            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                iRemoveCount = 0;

                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
                foreach ( var item in oldMultiDict )
                    newMultiDict.AddMany( item.Key, item.Value );

                foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in removeList )
                {
                    if ( newMultiDict.Remove( keyValuePair.Key, keyValuePair.Value ) == true )
                        iRemoveCount++;
                }

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );

            return iRemoveCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void Replace( KeyT key, ValueT value )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
            newMultiDict.Add( key, value );

            do
            {
                oldMultiDict = m_MultiDictionary;

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void ReplaceMany( KeyT key, IEnumerable<ValueT> values )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );
            newMultiDict.AddMany( key, values );

            do
            {
                oldMultiDict = m_MultiDictionary;

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public IEnumerable<ValueT> GetValues( KeyT key )
        {
            return m_MultiDictionary[key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public bool TryGetValues( KeyT key, out IEnumerable<ValueT> values )
        {
            values = null;

            ICollection<ValueT> collection = m_MultiDictionary[key];
            if ( collection == null )
                return false;

            if ( collection.Count <= 0 )
                return false;

            values = collection;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey( KeyT key )
        {
            return m_MultiDictionary.ContainsKey( key );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue( KeyT key, ValueT value )
        {
            return m_MultiDictionary.Contains( key, value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Find( Predicate<KeyT, ValueT> match, out KeyValuePair<KeyT, ValueT> findKeyValuePair )
        {
            findKeyValuePair = new KeyValuePair<KeyT, ValueT>( default( KeyT ), default( ValueT ) );

            MultiDictionary<KeyT, ValueT> tempMultiDictionary = m_MultiDictionary;
            if ( tempMultiDictionary.Count <= 0 )
                return false;

            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in tempMultiDictionary )
            {
                foreach ( ValueT valueItem in keyValuePair.Value )
                {
                    if ( match( keyValuePair.Key, valueItem ) == true )
                    {
                        findKeyValuePair = new KeyValuePair<KeyT, ValueT>( keyValuePair.Key, valueItem );
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

            MultiDictionary<KeyT, ValueT> tempMultiDictionary = m_MultiDictionary;
            if ( tempMultiDictionary.Count <= 0 )
                return keyValuePairList.ToArray();
            else
                keyValuePairList.Capacity = tempMultiDictionary.Count;

            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in tempMultiDictionary )
            {
                foreach ( ValueT valueItem in keyValuePair.Value )
                {
                    if ( match( keyValuePair.Key, valueItem ) == true )
                        keyValuePairList.Add( new KeyValuePair<KeyT, ValueT>( keyValuePair.Key, valueItem ) );
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
            MultiDictionary<KeyT, ValueT> tempMultiDictionary = m_MultiDictionary;
            if ( tempMultiDictionary.Count <= 0 )
                return;

            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in tempMultiDictionary )
            {
                foreach ( ValueT valueItem in keyValuePair.Value )
                    action( keyValuePair.Key, valueItem );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Exists( Predicate<KeyT, ValueT> match )
        {
            MultiDictionary<KeyT, ValueT> tempMultiDictionary = m_MultiDictionary;
            if ( tempMultiDictionary.Count <= 0 )
                return false;

            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in tempMultiDictionary )
            {
                foreach ( ValueT valueItem in keyValuePair.Value )
                {
                    if ( match( keyValuePair.Key, valueItem ) == true )
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );
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
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private volatile KeyT[] m_KeyArray = s_ZeroKeyArray;
        /// <summary>
        /// 
        /// </summary>
        private volatile Dictionary<KeyT, ValueT[]> m_ValueDictionary = null;
        /// <summary>
        /// 
        /// </summary>
        private volatile KeyValuePair<KeyT, ValueT[]>[] m_KeyValuePairArray = s_ZeroKeyValuePairArray;
        /// <summary>
        /// 
        /// </summary>
        private MultiDictionary<KeyT, ValueT> m_CachedMultiDictionary = null;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockCachedDictionary = new SpinLock();
        #endregion

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        private KeyValuePair<KeyT, ValueT[]>[] InternalToArray()
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                if ( m_CachedMultiDictionary == m_MultiDictionary )
                    return m_KeyValuePairArray;

                oldMultiDict = m_CachedMultiDictionary;
                newMultiDict = m_MultiDictionary;

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_CachedMultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );


            KeyT[] keyArray = new KeyT[newMultiDict.Count];
            Dictionary<KeyT, ValueT[]> valueArray = new Dictionary<KeyT, ValueT[]>( newMultiDict.Count );
            KeyValuePair<KeyT, ValueT[]>[] keyValuePairArray = new KeyValuePair<KeyT, ValueT[]>[newMultiDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in newMultiDict )
            {
                keyArray[iIndex] = keyValuePair.Key;

                ValueT[] tempValueArray = new ValueT[keyValuePair.Value.Count];

                int iIndex2 = 0;
                foreach ( ValueT value in keyValuePair.Value )
                {
                    tempValueArray[iIndex2] = value;

                    ++iIndex2;
                }

                valueArray.Add( keyValuePair.Key, tempValueArray );
                keyValuePairArray[iIndex] = new KeyValuePair<KeyT, ValueT[]>( keyValuePair.Key, tempValueArray );

                ++iIndex;
            }

            // 不能总是获取最新的数据
            m_LockCachedDictionary.Enter();
            {
                if ( m_CachedMultiDictionary == newMultiDict )
                {
                    m_KeyArray = keyArray;
                    m_ValueDictionary = valueArray;
                    m_KeyValuePairArray = keyValuePairArray;
                }
            }
            m_LockCachedDictionary.Exit();

            return keyValuePairArray;
        }

        /// <summary>
        /// 
        /// </summary>
        private ValueT[] InternalToArrayValuesByKey( KeyT key )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                if ( m_CachedMultiDictionary == m_MultiDictionary )
                {
                    ValueT[] tempValues = s_ZeroValueArray;

                    Dictionary<KeyT, ValueT[]> tempValueDictionary = m_ValueDictionary;
                    if ( tempValueDictionary != null )
                        tempValueDictionary.TryGetValue( key, out tempValues );

                    return tempValues;
                }

                oldMultiDict = m_CachedMultiDictionary;
                newMultiDict = m_MultiDictionary;

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_CachedMultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );


            KeyT[] keyArray = new KeyT[newMultiDict.Count];
            Dictionary<KeyT, ValueT[]> valueDictionary = new Dictionary<KeyT, ValueT[]>( newMultiDict.Count );
            KeyValuePair<KeyT, ValueT[]>[] keyValuePairArray = new KeyValuePair<KeyT, ValueT[]>[newMultiDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in newMultiDict )
            {
                keyArray[iIndex] = keyValuePair.Key;

                ValueT[] tempValueArray = new ValueT[keyValuePair.Value.Count];

                int iIndex2 = 0;
                foreach ( ValueT value in keyValuePair.Value )
                {
                    tempValueArray[iIndex2] = value;

                    ++iIndex2;
                }

                valueDictionary.Add( keyValuePair.Key, tempValueArray );
                keyValuePairArray[iIndex] = new KeyValuePair<KeyT, ValueT[]>( keyValuePair.Key, tempValueArray );

                ++iIndex;
            }

            // 不能总是获取最新的数据
            m_LockCachedDictionary.Enter();
            {
                if ( m_CachedMultiDictionary == newMultiDict )
                {
                    m_KeyArray = keyArray;
                    m_ValueDictionary = valueDictionary;
                    m_KeyValuePairArray = keyValuePairArray;
                }
            }
            m_LockCachedDictionary.Exit();

            ValueT[] returnValues = s_ZeroValueArray;

            valueDictionary.TryGetValue( key, out returnValues );

            return returnValues;
        }

        /// <summary>
        /// 
        /// </summary>
        private KeyT[] InternalToArrayKeys()
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                if ( m_CachedMultiDictionary == m_MultiDictionary )
                    return m_KeyArray;

                oldMultiDict = m_CachedMultiDictionary;
                newMultiDict = m_MultiDictionary;

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_CachedMultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );


            KeyT[] keyArray = new KeyT[newMultiDict.Count];
            Dictionary<KeyT, ValueT[]> valueDictionary = new Dictionary<KeyT, ValueT[]>( newMultiDict.Count );
            KeyValuePair<KeyT, ValueT[]>[] keyValuePairArray = new KeyValuePair<KeyT, ValueT[]>[newMultiDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in newMultiDict )
            {
                keyArray[iIndex] = keyValuePair.Key;

                ValueT[] tempValueArray = new ValueT[keyValuePair.Value.Count];

                int iIndex2 = 0;
                foreach ( ValueT value in keyValuePair.Value )
                {
                    tempValueArray[iIndex2] = value;

                    ++iIndex2;
                }

                valueDictionary.Add( keyValuePair.Key, tempValueArray );
                keyValuePairArray[iIndex] = new KeyValuePair<KeyT, ValueT[]>( keyValuePair.Key, tempValueArray );

                ++iIndex;
            }

            // 不能总是获取最新的数据
            m_LockCachedDictionary.Enter();
            {
                if ( m_CachedMultiDictionary == newMultiDict )
                {
                    m_KeyArray = keyArray;
                    m_ValueDictionary = valueDictionary;
                    m_KeyValuePairArray = keyValuePairArray;
                }
            }
            m_LockCachedDictionary.Exit();

            return keyArray;
        }
        #endregion
        /// <summary>
        /// 速度比GetEnumerator(...)慢
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public KeyValuePair<KeyT, ValueT[]>[] ToArray()
        {
            return InternalToArray();
        }

        /// <summary>
        /// 速度比GetEnumerator(...)慢
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public ValueT[] ToArrayValuesByKey( KeyT key )
        {
            return InternalToArrayValuesByKey( key );
        }

        /// <summary>
        /// 速度比GetEnumerator(...)慢
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public KeyT[] ToArrayKeys()
        {
            return InternalToArrayKeys();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<KeyT, ValueT[]>[] ToArrayAndClear()
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );

            // 开始获取数据
            KeyValuePair<KeyT, ValueT[]>[] keyValuePairArray = new KeyValuePair<KeyT, ValueT[]>[newMultiDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in oldMultiDict )
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

            return keyValuePairArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ValueT[] ToArrayValuesByKeyAndClear( KeyT key )
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );

            // 开始获取数据
            ValueT[] valueArray = s_ZeroValueArray;

            EqualityComparer<KeyT> equalityComparer = EqualityComparer<KeyT>.Default;

            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in oldMultiDict )
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

            return valueArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyT[] ToArrayKeysAndClear()
        {
            MultiDictionary<KeyT, ValueT> newMultiDict = null;
            MultiDictionary<KeyT, ValueT> oldMultiDict = null;

            do
            {
                oldMultiDict = m_MultiDictionary;

                newMultiDict = new MultiDictionary<KeyT, ValueT>( m_AllowDuplicateValues );

            } while ( Interlocked.CompareExchange<MultiDictionary<KeyT, ValueT>>( ref m_MultiDictionary, newMultiDict, oldMultiDict ) != oldMultiDict );

            // 开始获取数据
            KeyT[] keyArray = new KeyT[newMultiDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ICollection<ValueT>> keyValuePair in oldMultiDict )
            {
                keyArray[iIndex] = keyValuePair.Key;

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
        public IEnumerator<KeyValuePair<KeyT, IEnumerable<ValueT>>> GetEnumerator()
        {
            MultiDictionary<KeyT, ValueT> tempMultiDict = m_MultiDictionary;
            foreach ( var item in tempMultiDict )
                yield return new KeyValuePair<KeyT, IEnumerable<ValueT>>( item.Key, item.Value );

            yield break;
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