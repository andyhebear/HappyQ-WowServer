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
#endregion

namespace Demo.Mmose.Core.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="KeyT"></typeparam>
    /// <typeparam name="ValueT"></typeparam>
    public class MultiDictionary<KeyT, ValueT> : IEnumerable<KeyValuePair<KeyT, ICollection<ValueT>>>
    {
        #region zh-CHS 私有常量 | en Private Constants
        private const int DEFAULT_CAPACITY_SIZE = 32;
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_AllowDuplicateValues = false;
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<KeyT, List<ValueT>> m_AllowDuplicateKeyValues = null;
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<KeyT, HashSet<ValueT>> m_UnallowDuplicateKeyValues = null;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="allowDuplicateValues"></param>
        public MultiDictionary( bool allowDuplicateValues )
            : this( allowDuplicateValues, DEFAULT_CAPACITY_SIZE, DEFAULT_CAPACITY_SIZE, EqualityComparer<KeyT>.Default, EqualityComparer<ValueT>.Default )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allowDuplicateValues"></param>
        public MultiDictionary( bool allowDuplicateValues, int iKeyCapacity, int iValueCapacity )
            : this( allowDuplicateValues, DEFAULT_CAPACITY_SIZE, DEFAULT_CAPACITY_SIZE, EqualityComparer<KeyT>.Default, EqualityComparer<ValueT>.Default )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allowDuplicateValues"></param>
        /// <param name="keyEqualityComparer"></param>
        public MultiDictionary( bool allowDuplicateValues, int iKeyCapacity, int iValueCapacity, IEqualityComparer<KeyT> keyEqualityComparer )
            : this( allowDuplicateValues, DEFAULT_CAPACITY_SIZE, DEFAULT_CAPACITY_SIZE, keyEqualityComparer, EqualityComparer<ValueT>.Default )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allowDuplicateValues"></param>
        /// <param name="keyEqualityComparer"></param>
        /// <param name="valueEqualityComparer"></param>
        public MultiDictionary( bool allowDuplicateValues, int iKeyCapacity, int iValueCapacity, IEqualityComparer<KeyT> keyEqualityComparer, IEqualityComparer<ValueT> valueEqualityComparer )
        {
            m_AllowDuplicateValues = allowDuplicateValues;

            m_KeyCapacity = iKeyCapacity;
            m_ValueCapacity = iValueCapacity;

            m_KeyEqualityComparer = keyEqualityComparer;
            m_ValueEqualityComparer = valueEqualityComparer;

            if (m_AllowDuplicateValues ==  true)
                m_AllowDuplicateKeyValues = new Dictionary<KeyT, List<ValueT>>( m_KeyCapacity, m_KeyEqualityComparer );
            else
                m_UnallowDuplicateKeyValues = new Dictionary<KeyT, HashSet<ValueT>>( m_KeyCapacity, m_KeyEqualityComparer );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                if ( m_AllowDuplicateValues == true )
                    return m_AllowDuplicateKeyValues.Keys.Count;
                else
                    return m_UnallowDuplicateKeyValues.Keys.Count;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private IEqualityComparer<KeyT> m_KeyEqualityComparer = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public IEqualityComparer<KeyT> KeyComparer
        {
            get { return m_KeyEqualityComparer; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private IEqualityComparer<ValueT> m_ValueEqualityComparer = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public IEqualityComparer<ValueT> ValueComparer
        {
            get { return m_ValueEqualityComparer; }
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_KeyCapacity = DEFAULT_CAPACITY_SIZE;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int KeyCapacity
        {
            get { return m_KeyCapacity; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_ValueCapacity = DEFAULT_CAPACITY_SIZE;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int ValueCapacity
        {
            get { return m_ValueCapacity; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ICollection<ValueT> this[KeyT key]
        {
            get
            {
                if ( m_AllowDuplicateValues == true )
                    return m_AllowDuplicateKeyValues[key];
                else
                    return m_UnallowDuplicateKeyValues[key];
            }
            set
            {
                if ( m_AllowDuplicateValues == true )
                {
                    List<ValueT> values = new List<ValueT>( value );

                    m_AllowDuplicateKeyValues[key] = values;
                }
                else
                {
                    HashSet<ValueT> values = new HashSet<ValueT>( value );

                    m_UnallowDuplicateKeyValues[key] = values;
                }
            }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add( KeyT key, ValueT value )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                    listValue.Add( value );
                else
                {
                    listValue = new List<ValueT>( this.ValueCapacity );
                    listValue.Add( value );

                    m_AllowDuplicateKeyValues.Add( key, listValue );
                }
                
                m_AllowDuplicateKeyValues[key].Add( value );
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                    hashSetValue.Add( value );
                else
                {
                    hashSetValue = new HashSet<ValueT>();
                    hashSetValue.Add( value );

                    m_UnallowDuplicateKeyValues.Add( key, hashSetValue );
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add( KeyValuePair<KeyT, ICollection<ValueT>> pair )
        {
            this.AddMany( pair.Key, pair.Value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void AddMany( KeyT key, IEnumerable<ValueT> values )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                    listValue.AddRange( values );
                else
                {
                    listValue = new List<ValueT>( values );
                    m_AllowDuplicateKeyValues.Add( key, listValue );
                }
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                {
                    foreach ( var value in values )
                        hashSetValue.Add( value );
                }
                else
                {
                    hashSetValue = new HashSet<ValueT>( values );
                    m_UnallowDuplicateKeyValues.Add( key, hashSetValue );
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove( KeyT key )
        {
            if ( m_AllowDuplicateValues == true )
                return m_AllowDuplicateKeyValues.Remove( key );
            else
                return m_AllowDuplicateKeyValues.Remove( key );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove( KeyT key, ValueT value )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                    return listValue.Remove( value );
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                    return hashSetValue.Remove( value );
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public bool Remove( KeyValuePair<KeyT, ICollection<ValueT>> pair )
        {
            return this.RemoveMany( pair.Key, pair.Value ) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyCollection"></param>
        /// <returns></returns>
        public int RemoveMany( IEnumerable<KeyT> keyCollection )
        {
            if ( m_AllowDuplicateValues == true )
            {
                int iRemovecCount = 0;

                foreach ( KeyT key in keyCollection )
                {
                    if ( m_AllowDuplicateKeyValues.Remove( key ) == true )
                        iRemovecCount++;
                }

                return iRemovecCount;
            }
            else
            {
                int iRemovecCount = 0;

                foreach ( KeyT key in keyCollection )
                {
                    if ( m_UnallowDuplicateKeyValues.Remove( key ) == true )
                        iRemovecCount++;
                }

                return iRemovecCount;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int RemoveMany( KeyT key, IEnumerable<ValueT> values )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                {
                    int iRemovecCount = 0;

                    foreach ( var value in values )
                    {
                        if ( listValue.Remove( value ) == true )
                            iRemovecCount++;
                    }

                    return iRemovecCount;
                }
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                {
                    int iRemovecCount = 0;
                    
                    foreach ( var value in values )
                    {
                        if ( hashSetValue.Remove( value ) == true )
                            iRemovecCount++;
                    }

                    return iRemovecCount;
                }
            }

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Replace( KeyT key, ValueT value )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                {
                    listValue.Clear();
                    listValue.Add( value );

                    return true;
                }
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                {
                    hashSetValue.Clear();
                    hashSetValue.Add( value );

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public bool Replace( KeyValuePair<KeyT, ICollection<ValueT>> pair )
        {
            return this.ReplaceMany( pair.Key, pair.Value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool ReplaceMany( KeyT key, IEnumerable<ValueT> values )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                {
                    listValue.Clear();
                    listValue.AddRange( values );
                }

                return true;
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                {
                    hashSetValue.Clear();

                    foreach ( ValueT value in values )
                        hashSetValue.Add( value );

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool TryEnumerateValuesForKey( KeyT key, out IEnumerable<ValueT> values )
        {
            values = null;

            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                {
                    values = listValue;

                    return true;
                }
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                {
                    values = hashSetValue;

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
            if ( m_AllowDuplicateValues == true )
                m_AllowDuplicateKeyValues.Clear();
            else
                m_UnallowDuplicateKeyValues.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void ClearValues( KeyT key )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                    listValue.Clear();
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                    hashSetValue.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains( KeyT key, ValueT value )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                    return listValue.Contains( value );
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                    return hashSetValue.Contains( value );
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public bool Contains( KeyValuePair<KeyT, ICollection<ValueT>> pair )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( pair.Key, out listValue ) == true )
                {
                    foreach ( var value in pair.Value )
                    {
                        if ( listValue.Contains( value ) == false )
                            return false;
                    }

                    return true;
                }
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( pair.Key, out hashSetValue ) == true )
                {
                    foreach ( var value in pair.Value )
                    {
                        if ( hashSetValue.Contains( value ) == false )
                            return false;
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey( KeyT key )
        {
            if ( m_AllowDuplicateValues == true )
                return m_AllowDuplicateKeyValues.ContainsKey( key );
            else
                return m_UnallowDuplicateKeyValues.ContainsKey( key );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int CountValues( KeyT key )
        {
            if ( m_AllowDuplicateValues == true )
            {
                List<ValueT> listValue = null;
                if ( m_AllowDuplicateKeyValues.TryGetValue( key, out listValue ) == true )
                    return listValue.Count;
            }
            else
            {
                HashSet<ValueT> hashSetValue = null;
                if ( m_UnallowDuplicateKeyValues.TryGetValue( key, out hashSetValue ) == true )
                    return hashSetValue.Count;
            }

            return 0;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<KeyT, ICollection<ValueT>>> GetEnumerator()
        {
            if ( m_AllowDuplicateValues == true )
            {
                foreach ( var keyValue in m_AllowDuplicateKeyValues )
                    yield return new KeyValuePair<KeyT, ICollection<ValueT>>( keyValue.Key, keyValue.Value );
            }
            else
            {
                foreach ( var keyValue in m_UnallowDuplicateKeyValues )
                    yield return new KeyValuePair<KeyT, ICollection<ValueT>>( keyValue.Key, keyValue.Value );
            }

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