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
    /// 表示同一任意类型的实例的大小可变的后进先出 (LIFO) 集合。
    /// </summary>
    /// <typeparam name="ValueT"></typeparam>
    public class LockFreeStack<ValueT> : IEnumerable<ValueT>
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

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Node<ValueT> m_Head = new Node<ValueT>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemT"></param>
        public void Push( ValueT itemT )
        {
            Node<ValueT> newNode = new Node<ValueT>( itemT );

            do
            {
                newNode.Next = m_Head.Next;

            } while ( Interlocked.CompareExchange<Node<ValueT>>( ref m_Head.Next, newNode, newNode.Next ) != newNode.Next );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryPop( out ValueT itemT )
        {
            itemT = default( ValueT );

            Node<ValueT> nextNode = null;

            do
            {
                nextNode = m_Head.Next;

                if ( nextNode == null )
                    return false;

            } while ( Interlocked.CompareExchange<Node<ValueT>>( ref m_Head.Next, nextNode.Next, nextNode ) != nextNode );

            itemT = nextNode.Item;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueT Pop()
        {
            ValueT returnValue = default( ValueT );

            this.TryPop( out returnValue );

            return returnValue;
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
        /// <param name="item"></param>
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
                throw new Exception( "LockFreeStack.CopyTo(...) - arrayT == null error!" );

            if ( iArrayIndex < 0 || iArrayIndex >= arrayT.Length )
                throw new Exception( "LockFreeStack.CopyTo(...) - iArrayIndex < 0 || iArrayIndex >= arrayT.Length error!" );

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
            Node<ValueT> oldHead = null;

            do
            {
                oldHead = m_Head;

            } while ( Interlocked.CompareExchange<Node<ValueT>>( ref m_Head, nullNode, oldHead ) != nullNode );
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

            // 致空头，防止出入栈
            do
            {
                oldHeadNode = oldHead = m_Head;

            } while ( Interlocked.CompareExchange<Node<ValueT>>( ref m_Head, nullNode, oldHead ) != nullNode );

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