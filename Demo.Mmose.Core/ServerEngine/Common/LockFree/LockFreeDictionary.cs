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
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Util;
using System.Collections;
#endregion

namespace Demo.Mmose.Core.Common.LockFree
{
    /// <summary>
    /// 不是什么情况都可以使用LockFreeDictionary的，不然你会得到相反的效果（性能很差）
    /// 这里假设读非常多，写非常非常少。 
    /// 这种方法的好处是在获取数值的时候没有任何lock，从而极大的提高了性能
    /// </summary>
    public class LockFreeDictionary<KeyT, ValueT> : IEnumerable<KeyValuePair<KeyT, ValueT>>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public LockFreeDictionary()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public LockFreeDictionary( IDictionary<KeyT, ValueT> dictionary )
        {
            m_Dictionary = new Dictionary<KeyT, ValueT>( dictionary );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public LockFreeDictionary( int iCapacity )
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
            get { return m_Dictionary[key]; }
            set { this.Add( key, value ); }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<KeyT, ValueT> m_Dictionary = new Dictionary<KeyT, ValueT>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add( KeyT key, ValueT value )
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                oldDict = m_Dictionary;

                newDict = new Dictionary<KeyT, ValueT>( oldDict );
                newDict[key] = value;

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_Dictionary, newDict, oldDict ) != oldDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void AddRange( IDictionary<KeyT, ValueT> dictionary )
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                oldDict = m_Dictionary;

                newDict = new Dictionary<KeyT, ValueT>( oldDict );

                foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in dictionary )
                    newDict[keyValuePair.Key] = keyValuePair.Value;

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_Dictionary, newDict, oldDict ) != oldDict );
        }

        /// <summary>
        /// 请尽可能的使用AddRange(...) 比 Add(...) 添加单个快得多
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void AddRange( IEnumerable<KeyValuePair<KeyT, ValueT>> collection )
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                oldDict = m_Dictionary;

                newDict = new Dictionary<KeyT, ValueT>( oldDict );

                foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in collection )
                    newDict[keyValuePair.Key] = keyValuePair.Value;

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_Dictionary, newDict, oldDict ) != oldDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void Remove( KeyT key )
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                oldDict = m_Dictionary;

                newDict = new Dictionary<KeyT, ValueT>( oldDict );

                newDict.Remove( key );

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_Dictionary, newDict, oldDict ) != oldDict );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int RemoveAll( Predicate<KeyT, ValueT> match )
        {
            Dictionary<KeyT, ValueT> tempDictionary = m_Dictionary;
            if ( tempDictionary.Count <= 0 )
                return 0;

            List<KeyT> removeList = new List<KeyT>( tempDictionary.Count );

            foreach ( KeyValuePair<KeyT, ValueT> itemT in tempDictionary )
            {
                if ( match( itemT.Key, itemT.Value ) == true )
                    removeList.Add( itemT.Key );
            }

            if ( removeList.Count <= 0 )
                return 0;

            int iRemoveCount = 0;

            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                iRemoveCount = 0;

                oldDict = m_Dictionary;

                newDict = new Dictionary<KeyT, ValueT>( oldDict );

                foreach ( KeyT itemKey in removeList )
                {
                    if ( newDict.Remove( itemKey ) == true )
                        iRemoveCount++;
                }

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_Dictionary, newDict, oldDict ) != oldDict );

            return iRemoveCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public ValueT GetValue( KeyT key )
        {
            return m_Dictionary[key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public bool TryGetValue( KeyT key, out ValueT value )
        {
            return m_Dictionary.TryGetValue( key, out value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey( KeyT key )
        {
            return m_Dictionary.ContainsKey( key );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue( ValueT value )
        {
            return m_Dictionary.ContainsValue( value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Find( Predicate<KeyT, ValueT> match, out KeyValuePair<KeyT, ValueT> findKeyValuePair )
        {
            findKeyValuePair = new KeyValuePair<KeyT, ValueT>( default( KeyT ), default( ValueT ) );

            Dictionary<KeyT, ValueT> tempDictionary = m_Dictionary;
            if ( tempDictionary.Count <= 0 )
                return false;

            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in tempDictionary )
            {
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

            Dictionary<KeyT, ValueT> tempDictionary = m_Dictionary;
            if ( tempDictionary.Count <= 0 )
                return keyValuePairList.ToArray();
            else
                keyValuePairList.Capacity = tempDictionary.Count;

            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in tempDictionary )
            {
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
            Dictionary<KeyT, ValueT> tempDictionary = m_Dictionary;
            if ( tempDictionary.Count <= 0 )
                return;

            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in tempDictionary )
                action( keyValuePair.Key, keyValuePair.Value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Exists( Predicate<KeyT, ValueT> match )
        {
            Dictionary<KeyT, ValueT> tempDictionary = m_Dictionary;
            if ( tempDictionary.Count <= 0 )
                return false;

            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in tempDictionary )
            {
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
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                oldDict = m_Dictionary;

                newDict = new Dictionary<KeyT, ValueT>();

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_Dictionary, newDict, oldDict ) != oldDict );
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
        private Dictionary<KeyT, ValueT> m_CachedDictionary = null;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockCachedDictionary = new SpinLock();
        #endregion

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        private KeyValuePair<KeyT, ValueT>[] InternalToArray()
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                if ( m_CachedDictionary == m_Dictionary )
                    return m_KeyValuePairArray;

                oldDict = m_CachedDictionary;
                newDict = m_Dictionary;

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_CachedDictionary, newDict, oldDict ) != oldDict );


            KeyT[] keyArray = new KeyT[newDict.Count];
            ValueT[] valueArray = new ValueT[newDict.Count];
            KeyValuePair<KeyT, ValueT>[] keyValuePairArray = new KeyValuePair<KeyT, ValueT>[newDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in newDict )
            {
                keyArray[iIndex] = keyValuePair.Key;
                valueArray[iIndex] = keyValuePair.Value;
                keyValuePairArray[iIndex] = keyValuePair;

                ++iIndex;
            }

            // 不能总是获取最新的数据
            m_LockCachedDictionary.Enter();
            {
                if ( m_CachedDictionary == newDict )
                {
                    m_KeyArray = keyArray;
                    m_ValueArray = valueArray;
                    m_KeyValuePairArray = keyValuePairArray;
                }
            }
            m_LockCachedDictionary.Exit();

            return keyValuePairArray;
        }

        /// <summary>
        /// 
        /// </summary>
        private ValueT[] InternalToArrayValues()
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                if ( m_CachedDictionary == m_Dictionary )
                    return m_ValueArray;

                oldDict = m_CachedDictionary;
                newDict = m_Dictionary;

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_CachedDictionary, newDict, oldDict ) != oldDict );


            KeyT[] keyArray = new KeyT[newDict.Count];
            ValueT[] valueArray = new ValueT[newDict.Count];
            KeyValuePair<KeyT, ValueT>[] keyValuePairArray = new KeyValuePair<KeyT, ValueT>[newDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in newDict )
            {
                keyArray[iIndex] = keyValuePair.Key;
                valueArray[iIndex] = keyValuePair.Value;
                keyValuePairArray[iIndex] = keyValuePair;

                ++iIndex;
            }

            // 不能总是获取最新的数据
            m_LockCachedDictionary.Enter();
            {
                if ( m_CachedDictionary == newDict )
                {
                    m_KeyArray = keyArray;
                    m_ValueArray = valueArray;
                    m_KeyValuePairArray = keyValuePairArray;
                }
            }
            m_LockCachedDictionary.Exit();

            return valueArray;
        }

        /// <summary>
        /// 
        /// </summary>
        private KeyT[] InternalToArrayKeys()
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                if ( m_CachedDictionary == m_Dictionary )
                    return m_KeyArray;

                oldDict = m_CachedDictionary;
                newDict = m_Dictionary;

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_CachedDictionary, newDict, oldDict ) != oldDict );


            KeyT[] keyArray = new KeyT[newDict.Count];
            ValueT[] valueArray = new ValueT[newDict.Count];
            KeyValuePair<KeyT, ValueT>[] keyValuePairArray = new KeyValuePair<KeyT, ValueT>[newDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in newDict )
            {
                keyArray[iIndex] = keyValuePair.Key;
                valueArray[iIndex] = keyValuePair.Value;
                keyValuePairArray[iIndex] = keyValuePair;

                ++iIndex;
            }

            // 不能总是获取最新的数据
            m_LockCachedDictionary.Enter();
            {
                if ( m_CachedDictionary == newDict )
                {
                    m_KeyArray = keyArray;
                    m_ValueArray = valueArray;
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
        public KeyValuePair<KeyT, ValueT>[] ToArray()
        {
            return InternalToArray();
        }

        /// <summary>
        /// 速度比GetEnumerator(...)慢
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public ValueT[] ToArrayValues()
        {
            return InternalToArrayValues();
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
        public KeyValuePair<KeyT, ValueT>[] ToArrayAndClear()
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                oldDict = m_Dictionary;

                newDict = new Dictionary<KeyT, ValueT>();

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_Dictionary, newDict, oldDict ) != oldDict );

            // 开始获取数据
            KeyValuePair<KeyT, ValueT>[] tempKeyValuePairArray = new KeyValuePair<KeyT, ValueT>[newDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in oldDict )
            {
                tempKeyValuePairArray[iIndex] = keyValuePair;

                ++iIndex;
            }

            return tempKeyValuePairArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT[] ToArrayValuesAndClear()
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                oldDict = m_Dictionary;

                newDict = new Dictionary<KeyT, ValueT>();

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_Dictionary, newDict, oldDict ) != oldDict );

            // 开始获取数据
            ValueT[] tempValueArray = new ValueT[newDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in oldDict )
            {
                tempValueArray[iIndex] = keyValuePair.Value;

                ++iIndex;
            }

            return tempValueArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyT[] ToArrayKeysAndClear()
        {
            Dictionary<KeyT, ValueT> newDict = null;
            Dictionary<KeyT, ValueT> oldDict = null;

            do
            {
                oldDict = m_Dictionary;

                newDict = new Dictionary<KeyT, ValueT>();

            } while ( Interlocked.CompareExchange<Dictionary<KeyT, ValueT>>( ref m_Dictionary, newDict, oldDict ) != oldDict );

            // 开始获取数据
            KeyT[] tempKeyArray = new KeyT[newDict.Count];

            int iIndex = 0;
            foreach ( KeyValuePair<KeyT, ValueT> keyValuePair in oldDict )
            {
                tempKeyArray[iIndex] = keyValuePair.Key;

                ++iIndex;
            }

            return tempKeyArray;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 速度比ToArray(...)快的多
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<KeyT, ValueT>> GetEnumerator()
        {
            return m_Dictionary.GetEnumerator();
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