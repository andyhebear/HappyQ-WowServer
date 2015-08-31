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
using System.Collections;
#endregion

namespace Demo.Mmose.Core.Common.SafeCollections
{
    /// <summary>
    /// 
    /// </summary>
    public class SafeList<ValueT> : IEnumerable<ValueT>
    {
        #region zh-CHS 私有的类 | en Private Class
        /// <summary>
        /// 
        /// </summary>
        private class ListPredicate<InternalT>
        {
            #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
            /// <summary>
            /// 
            /// </summary>
            public ListPredicate( int iCapacity )
            {
                m_Data = new Dictionary<InternalT, InternalT>( iCapacity );
            }
            #endregion

            #region zh-CHS 共有属性 | en Public Properties
            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private Dictionary<InternalT, InternalT> m_Data = null;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public Dictionary<InternalT, InternalT> Data
            {
                get { return m_Data; }
            }
            #endregion

            #region zh-CHS 共有方法 | en Public Methods
            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public bool PredicateCallback( InternalT value )
            {
                InternalT outValue = default( InternalT );

                if ( m_Data.TryGetValue( value, out outValue ) == true )
                    return true;
                else
                    return false;
            }
            #endregion
        }
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public SafeList()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public SafeList( IEnumerable<ValueT> collection )
        {
            m_List.AddRange( collection );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public SafeList( int iCapacity )
        {
            m_List = new List<ValueT>( iCapacity );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_List.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Capacity
        {
            get { return m_List.Capacity; }
            set
            {
                m_LockList.EnterWriteLock();
                {
                    if ( m_List.Capacity < value )
                    {
                        m_List.Capacity = value;

                        m_bIsValueChange = true;
                    }
                }
                m_LockList.ExitWriteLock();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ValueT this[int iIndex]
        {
            get
            {
                ValueT returnValue = default( ValueT );

                m_LockList.EnterReadLock();
                {
                    returnValue = m_List[iIndex];
                }
                m_LockList.ExitReadLock();

                return returnValue;
            }
            set
            {
                m_LockList.EnterWriteLock();
                {
                    m_List[iIndex] = value;

                    m_bIsValueChange = true;
                }
                m_LockList.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private List<ValueT> m_List = new List<ValueT>();
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockList = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public void Add( ValueT value )
        {
            m_LockList.EnterWriteLock();
            {
                m_List.Add( value );

                m_bIsValueChange = true;
            }
            m_LockList.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange( IEnumerable<ValueT> collection )
        {
            m_LockList.EnterWriteLock();
            {
                m_List.AddRange( collection );

                m_bIsValueChange = true;
            }
            m_LockList.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void Remove( ValueT value )
        {
            m_LockList.EnterWriteLock();
            {
                if ( m_List.Remove( value ) == true )
                    m_bIsValueChange = true;
            }
            m_LockList.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt( int iIndex )
        {
            m_LockList.EnterWriteLock();
            {
                int iBeforeCount = m_List.Count;

                m_List.RemoveAt( iIndex );

                int iAfterCount = m_List.Count;

                if ( iBeforeCount != iAfterCount )
                    m_bIsValueChange = true;
            }
            m_LockList.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int RemoveAll( Predicate<ValueT> match )
        {
            ValueT[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return 0;

            ListPredicate<ValueT> listPredicate = new ListPredicate<ValueT>( valueArray.Length );

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                ValueT itemT = valueArray[iIndex];
                if ( match( itemT ) == true )
                    listPredicate.Data.Add( itemT, itemT );
            }

            if ( listPredicate.Data.Count <= 0 )
                return 0;

            int iRemoveCount = 0;

            m_LockList.EnterWriteLock();
            {
                // 内部处理速度比较快
                iRemoveCount = m_List.RemoveAll( listPredicate.PredicateCallback );

                if ( iRemoveCount > 0 )
                    m_bIsValueChange = true;
            }
            m_LockList.ExitWriteLock();

            return iRemoveCount;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public void RemoveRange( int iIndex, int iCount )
        {
            m_LockList.EnterWriteLock();
            {
                int iBeforeCount = m_List.Count;

                m_List.RemoveRange( iIndex, iCount );

                int iAfterCount = m_List.Count;

                if ( iBeforeCount != iAfterCount )
                    m_bIsValueChange = true;
            }
            m_LockList.ExitWriteLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains( ValueT value )
        {
            bool bIsContains = false;

            m_LockList.EnterReadLock();
            {
                bIsContains = m_List.Contains( value );
            }
            m_LockList.ExitReadLock();

            return bIsContains;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrayT"></param>
        /// <param name="iArrayIndex"></param>
        public void CopyTo( ValueT[] arrayT, int iArrayIndex )
        {
            m_LockList.EnterReadLock();
            {
                m_List.CopyTo( arrayT, iArrayIndex );
            }
            m_LockList.ExitReadLock();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="converter"></param>
        /// <returns></returns>
        public SafeList<TOutput> ConvertAll<TOutput>( Converter<ValueT, TOutput> converter )
        {
            SafeList<TOutput> safeList = new SafeList<TOutput>( m_List.Count );

            ValueT[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return safeList;

            List<TOutput> converterList = new List<TOutput>( valueArray.Length );

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                ValueT itemT = valueArray[iIndex];
                converterList.Add( converter( itemT ) );
            }

            if ( converterList.Count <= 0 )
                return safeList;
            else
                safeList.AddRange( converterList );

            return safeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public ValueT Find( Predicate<ValueT> match )
        {
            ValueT[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return default( ValueT );

            ValueT returnT = default( ValueT );

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                ValueT itemT = valueArray[iIndex];
                if ( match( itemT ) == true )
                {
                    returnT = itemT;
                    break;
                }
            }

            return returnT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public SafeList<ValueT> FindAll( Predicate<ValueT> match )
        {
            SafeList<ValueT> safeList = new SafeList<ValueT>();

            ValueT[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return safeList;

            List<ValueT> list = new List<ValueT>( valueArray.Length );

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                ValueT itemT = valueArray[iIndex];
                if ( match( itemT ) == true )
                    list.Add( itemT );
            }

            if ( list.Count <= 0 )
                return safeList;
            else
                safeList.AddRange( list );

            return safeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public ValueT FindLast( Predicate<ValueT> match )
        {
            ValueT[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return default( ValueT );

            ValueT returnT = default( ValueT );

            for ( int iIndex = valueArray.Length - 1; iIndex >= 0; iIndex-- )
            {
                if ( match( valueArray[iIndex] ) == true )
                {
                    returnT = valueArray[iIndex];
                    break;
                }
            }

            return returnT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void ForEach( Action<ValueT> action )
        {
            ValueT[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return;

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                ValueT itemT = valueArray[iIndex];
                action( itemT );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Exists( Predicate<ValueT> match )
        {
            ValueT[] valueArray = this.ToArray();
            if ( valueArray.Length <= 0 )
                return false;

            for ( int iIndex = 0; iIndex < valueArray.Length; iIndex++ )
            {
                ValueT itemT = valueArray[iIndex];
                if ( match( itemT ) == true )
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            m_LockList.EnterWriteLock();
            {
                m_List.Clear();

                // 清空
                m_ValueArray = s_ZeroArray;
                m_bIsValueChange = false;
            }
            m_LockList.ExitWriteLock();
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

            m_LockList.EnterReadLock();
            {
                if ( m_bIsValueChange == true )
                {
                    m_ValueArray = m_List.ToArray();

                    m_bIsValueChange = false;
                }
            }
            m_LockList.ExitReadLock();

            return m_ValueArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT[] ToArrayAndClear()
        {
            ValueT[] valueArray = s_ZeroArray;

            m_LockList.EnterWriteLock();
            {
                if ( m_bIsValueChange == true )
                {
                    valueArray = m_List.ToArray();

                    m_bIsValueChange = false;
                }
                else
                    valueArray = m_ValueArray;

                // 清空
                m_List.Clear();
                m_ValueArray = s_ZeroArray;
            }
            m_LockList.ExitWriteLock();

            return valueArray;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
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
