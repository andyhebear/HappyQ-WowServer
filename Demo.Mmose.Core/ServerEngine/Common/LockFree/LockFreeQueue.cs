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
using System.Threading;
using System.Collections;
#endregion

namespace Demo.Mmose.Core.Common.LockFree
{
    /// <summary>
    /// 现在还没解决ABA的问题，使用的时候需注意
    /// 还没找到用.net框架可以解决ABA的问题方法，不过出现的几率非常非常的小
    /// 表示对象的先进先出集合。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LockFreeQueue<ValueT> : IEnumerable<ValueT>
    {
        /// <summary>
        /// 
        /// </summary>
        private class Node<T>
        {
            #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            public Node()
            {
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            public Node( T item )
            {
                m_Item = item;
            }
            #endregion

            #region zh-CHS 共有属性 | en Public Properties
            /// <summary>
            /// 
            /// </summary>
            public Node<T> Next = null;

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private T m_Item = default( T );
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public T Item
            {
                get { return m_Item; }
            }
            #endregion
        }

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
		private Node<ValueT> m_Head = null;
        /// <summary>
        /// 
        /// </summary>
		private Node<ValueT> m_Tail = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public LockFreeQueue()
		{
			m_Tail = m_Head = new Node<ValueT>();
		}
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemT"></param>
        public void Enqueue( ValueT itemT )
        {
            Node<ValueT> oldTail = null;
            Node<ValueT> oldTailNext = null;

            Node<ValueT> newNode = new Node<ValueT>( itemT );

            bool bNewNodeWasAdded = false;

            while ( bNewNodeWasAdded == false )
            {
                oldTail = m_Tail;
                oldTailNext = oldTail.Next;

                if ( m_Tail == oldTail )
                {
                    if ( oldTailNext == null )
                        bNewNodeWasAdded = ( Interlocked.CompareExchange<Node<ValueT>>( ref m_Tail.Next, newNode, null ) == null );
                    else // 如果上次没有成功则添加至尾部
                        Interlocked.CompareExchange<Node<ValueT>>( ref m_Tail, oldTailNext, oldTail );
                }
            }

            // 如果没有成功，则会在下次添加，或已经添加完成
            Interlocked.CompareExchange<Node<ValueT>>( ref m_Tail, newNode, oldTail );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryDequeue( out ValueT outItemT )
        {
            outItemT = default( ValueT );

            bool bHaveAdvancedHead = false;

            while ( bHaveAdvancedHead == false )
            {
                Node<ValueT> oldHead = m_Head;
                Node<ValueT> oldTail = m_Tail;
                Node<ValueT> oldHeadNext = oldHead.Next;

                if ( oldHead == m_Head )
                {
                    if ( oldHead == oldTail )
                    {
                        if ( oldHeadNext == null )
                            return false;

                        Interlocked.CompareExchange<Node<ValueT>>( ref m_Tail, oldHeadNext, oldTail );
                    }
                    else
                    {
                        outItemT = oldHeadNext.Item;
                        bHaveAdvancedHead = ( Interlocked.CompareExchange<Node<ValueT>>( ref m_Head, oldHeadNext, oldHead ) == oldHead );
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT Dequeue()
        {
            ValueT result;

            this.TryDequeue( out result );

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT Peek()
        {
            ValueT returnValue = default( ValueT );

            Node<ValueT> nextNode = m_Head.Next;

            if ( nextNode == null )
                return returnValue;
            else
                return nextNode.Item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains( ValueT value )
        {
            EqualityComparer<ValueT> equalityComparer = EqualityComparer<ValueT>.Default;

            foreach ( var itemValue in this )
            {
                if ( equalityComparer.Equals( itemValue, value ) == true )
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrayT"></param>
        /// <param name="iArrayIndex"></param>
        public void CopyTo( ValueT[] arrayT, int iArrayIndex )
        {
            if ( arrayT == null )
                throw new Exception( "LockFreeQueue.CopyTo(...) - arrayT == null error!" );

            if ( iArrayIndex < 0 || iArrayIndex >= arrayT.Length )
                throw new Exception( "LockFreeQueue.CopyTo(...) - iArrayIndex < 0 || iArrayIndex >= arrayT.Length error!" );

            foreach ( var itemValue in this )
            {
                arrayT[iArrayIndex] = itemValue;
                ++iArrayIndex;

                if ( iArrayIndex >= arrayT.Length )
                    return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            Node<ValueT> nullNode = new Node<ValueT>();

            // 应为清除数据，所以数据漏掉无所谓。
            do
            {
                m_Tail = m_Head = nullNode;

            } while ( Interlocked.CompareExchange<Node<ValueT>>( ref m_Head, nullNode, m_Tail ) != nullNode );
        }

        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int LIST_CAPACITY_SIZE = 1024;
        #endregion
        /// <summary>
        /// 速度比GetEnumerator(...)慢,没有缓存数据
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public ValueT[] ToArray()
        {
            List<ValueT> valueList = new List<ValueT>( LIST_CAPACITY_SIZE );

            EqualityComparer<ValueT> equalityComparer = EqualityComparer<ValueT>.Default;

            foreach ( var value in this )
            {
                if ( equalityComparer.Equals( value, default( ValueT ) ) == true )
                    continue;

                valueList.Add( value );
            }

            return valueList.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT[] ToArrayAndClear()
        {
            Node<ValueT> nullNode = new Node<ValueT>();
            Node<ValueT> oldHeadNode = null;

            Node<ValueT> oldHead = null;
            Node<ValueT> oldTail = null;

            // 致空头，防止出栈
            do
            {
                oldHeadNode = oldHead = m_Head;

            } while ( Interlocked.CompareExchange<Node<ValueT>>( ref m_Head, nullNode, oldHead ) != nullNode );

            // 致空尾，防止入栈
            do
            {
                oldTail = m_Tail;

            } while ( Interlocked.CompareExchange<Node<ValueT>>( ref m_Tail, nullNode, oldTail ) != nullNode );

            List<ValueT> valueList = new List<ValueT>( LIST_CAPACITY_SIZE );

            EqualityComparer<ValueT> equalityComparer = EqualityComparer<ValueT>.Default;

            while ( ( oldHeadNode = oldHeadNode.Next ) != null )
            {
                if ( equalityComparer.Equals( oldHeadNode.Item, default( ValueT ) ) == true )
                    continue;

                valueList.Add( oldHeadNode.Item );
            }

            return valueList.ToArray();
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 速度比ToArray(...)快
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ValueT> GetEnumerator()
        {
            Node<ValueT> tempNode = m_Head;
            if ( tempNode == null )
                yield break;

            EqualityComparer<ValueT> equalityComparer = EqualityComparer<ValueT>.Default;

            while ( ( tempNode = tempNode.Next ) != null )
            {
                if ( equalityComparer.Equals( tempNode.Item, default( ValueT ) ) == true )
                    continue;

                yield return tempNode.Item;
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