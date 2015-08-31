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
using System.Threading;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseItemContainerState<T> where T : BaseItem
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 单体
        /// </summary>
        private static BaseItemContainerState<T> s_BaseItemContainerState = new BaseItemContainerState<T>();
        #endregion
        /// <summary>
        /// 单体
        /// </summary>
        public static BaseItemContainerState<T> SingletonInstance
        {
            get { return s_BaseItemContainerState; }
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateAddSubItemCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateAddSubItemCall
        {
            get { return m_UpdateAddSubItemCall; }
            internal set { m_UpdateAddSubItemCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateRemoveSubItemCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateRemoveSubItemCall
        {
            get { return m_UpdateRemoveSubItemCall; }
            internal set { m_UpdateRemoveSubItemCall = value; }
        }

        #endregion

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        internal void RestoreAll()
        {
            m_UpdateAddSubItemCall = false;
            m_UpdateAddSubItemCall = false;
        }
        #endregion

        #region zh-CHS 内部的事件处理函数 | en Internal Event Handlers

        #region zh-CHS AddChildItemCall事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnAddingSubItem( T addSubItemT, BaseItemContainer<T> itemContainer )
        {
            EventHandler<AddingSubItemCallEventArgs<T>> tempBeforeEventArgs = m_EventAddingSubItem;
            if ( tempBeforeEventArgs != null )
            {
                AddingSubItemCallEventArgs<T> eventArgs = new AddingSubItemCallEventArgs<T>( addSubItemT, itemContainer );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnAddedSubItem( T addSubItemT, BaseItemContainer<T> itemContainer )
        {
            EventHandler<AddedSubItemCallEventArgs<T>> tempAfterEventArgs = m_EventAddedSubItem;
            if ( tempAfterEventArgs != null )
            {
                AddedSubItemCallEventArgs<T> eventArgs = new AddedSubItemCallEventArgs<T>( addSubItemT, itemContainer );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS RemoveChildItemCall事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnRemovingSubItem( T removeSubItem, BaseItemContainer<T> itemContainer )
        {
            EventHandler<RemovingSubItemCallEventArgs<T>> tempBeforeEventArgs = m_EventRemovingSubItem;
            if ( tempBeforeEventArgs != null )
            {
                RemovingSubItemCallEventArgs<T> eventArgs = new RemovingSubItemCallEventArgs<T>( removeSubItem, itemContainer );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnRemovedSubItem( T removeSubItem, BaseItemContainer<T> itemContainer )
        {
            EventHandler<RemovedSubItemCallEventArgs<T>> tempAfterEventArgs = m_EventRemovedSubItem;
            if ( tempAfterEventArgs != null )
            {
                RemovedSubItemCallEventArgs<T> eventArgs = new RemovedSubItemCallEventArgs<T>( removeSubItem, itemContainer );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddChildItem事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddingSubItemCallEventArgs<T>> m_EventAddingSubItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddingSubItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddingSubItemCallEventArgs<T>> AddingSubItem
        {
            add
            {
                m_LockEventAddingSubItem.Enter();
                {
                    m_EventAddingSubItem += value;
                }
                m_LockEventAddingSubItem.Exit();
            }
            remove
            {
                m_LockEventAddingSubItem.Enter();
                {
                    m_EventAddingSubItem -= value;
                }
                m_LockEventAddingSubItem.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddedSubItemCallEventArgs<T>> m_EventAddedSubItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddedSubItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddedSubItemCallEventArgs<T>> AddedSubItem
        {
            add
            {
                m_LockEventAddedSubItem.Enter();
                {
                    m_EventAddedSubItem += value;
                }
                m_LockEventAddedSubItem.Exit();
            }
            remove
            {
                m_LockEventAddedSubItem.Enter();
                {
                    m_EventAddedSubItem -= value;
                }
                m_LockEventAddedSubItem.Exit();
            }
        }
        #endregion

        #region zh-CHS RemoveChildItem事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovingSubItemCallEventArgs<T>> m_EventRemovingSubItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovingSubItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovingSubItemCallEventArgs<T>> RemovingSubItem
        {
            add
            {
                m_LockEventRemovingSubItem.Enter();
                {
                    m_EventRemovingSubItem += value;
                }
                m_LockEventRemovingSubItem.Exit();
            }
            remove
            {
                m_LockEventRemovingSubItem.Enter();
                {
                    m_EventRemovingSubItem -= value;
                }
                m_LockEventRemovingSubItem.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovedSubItemCallEventArgs<T>> m_EventRemovedSubItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovedSubItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovedSubItemCallEventArgs<T>> RemovedSubItem
        {
            add
            {
                m_LockEventRemovedSubItem.Enter();
                {
                    m_EventRemovedSubItem += value;
                }
                m_LockEventRemovedSubItem.Exit();
            }
            remove
            {
                m_LockEventRemovedSubItem.Enter();
                {
                    m_EventRemovedSubItem -= value;
                }
                m_LockEventRemovedSubItem.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion