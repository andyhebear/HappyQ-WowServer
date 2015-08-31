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
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Item
{
    /// <summary>
    /// BaseItem Delta
    /// </summary>
    public class BaseItemState
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 单体
        /// </summary>
        private static BaseItemState s_BaseItemState = new BaseItemState();
        #endregion
        /// <summary>
        /// 单体
        /// </summary>
        public static BaseItemState SingletonInstance
        {
            get { return s_BaseItemState; }
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateName = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateName
        {
            get { return m_UpdateName; }
            internal set { m_UpdateName = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateItemTemplate = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateItemTemplate
        {
            get { return m_UpdateItemTemplate; }
            internal set { m_UpdateItemTemplate = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateOwner = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateOwner
        {
            get { return m_UpdateOwner; }
            internal set { m_UpdateOwner = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateParent = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateParent
        {
            get { return m_UpdateParent; }
            internal set { m_UpdateParent = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateAddChildItemCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateAddChildItemCall
        {
            get { return m_UpdateAddChildItemCall; }
            internal set { m_UpdateAddChildItemCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateRemoveChildItemCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateRemoveChildItemCall
        {
            get { return m_UpdateRemoveChildItemCall; }
            internal set { m_UpdateRemoveChildItemCall = value; }
        }

        #endregion

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        internal void RestoreAll()
        {
            m_UpdateName = false;
            m_UpdateItemTemplate = false;
            m_UpdateOwner = false;
            m_UpdateParent = false;
            m_UpdateAddChildItemCall = false;
            m_UpdateRemoveChildItemCall = false;
        }
        #endregion

        #region zh-CHS 内部的事件处理函数 | en Internal Event Handlers

        #region zh-CHS Name事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingName( string strName, BaseItem baseItem )
        {
            EventHandler<UpdatingNameEventArgs> tempBeforeEventArgs = m_EventUpdatingName;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingNameEventArgs eventArgs = new UpdatingNameEventArgs( strName, baseItem );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedName( string strName, BaseItem baseItem )
        {
            EventHandler<AfterUpdatedEventArgs> tempAfterEventArgs = m_EventUpdatedName;
            if ( tempAfterEventArgs != null )
            {
                AfterUpdatedEventArgs eventArgs = new AfterUpdatedEventArgs( strName, baseItem );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS ItemTemplate事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingItemTemplate( BaseItemTemplate itemTemplate, BaseItem item )
        {
            EventHandler<UpdatingItemTemplateEventArgs> tempBeforeEventArgs = m_EventUpdatingItemTemplate;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingItemTemplateEventArgs eventArgs = new UpdatingItemTemplateEventArgs( itemTemplate, item );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedItemTemplate( BaseItemTemplate itemTemplate, BaseItem item )
        {
            EventHandler<UpdatedItemTemplateEventArgs> tempAfterEventArgs = m_EventUpdatedItemTemplate;
            if ( tempAfterEventArgs != null )
            {
                UpdatedItemTemplateEventArgs eventArgs = new UpdatedItemTemplateEventArgs( itemTemplate, item );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS Owner事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingOwner( BaseCreature ownerCreature, BaseItem item )
        {
            EventHandler<UpdatingOwnerEventArgs> tempBeforeEventArgs = m_EventUpdatingOwner;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingOwnerEventArgs eventArgs = new UpdatingOwnerEventArgs( ownerCreature, item );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedOwner( BaseCreature ownerCreature, BaseItem item )
        {
            EventHandler<UpdatedOwnerEventArgs> tempAfterEventArgs = m_EventUpdatedOwner;
            if ( tempAfterEventArgs != null )
            {
                UpdatedOwnerEventArgs eventArgs = new UpdatedOwnerEventArgs( ownerCreature, item );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS Parent事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingParent( BaseItem parentItem, BaseItem item )
        {
            EventHandler<UpdatingParentEventArgs> tempBeforeEventArgs = m_EventUpdatingParent;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingParentEventArgs eventArgs = new UpdatingParentEventArgs( parentItem, item );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedParent( BaseItem parentItem, BaseItem item )
        {
            EventHandler<UpdatedParentEventArgs> tempAfterEventArgs = m_EventUpdatedParent;
            if ( tempAfterEventArgs != null )
            {
                UpdatedParentEventArgs eventArgs = new UpdatedParentEventArgs( parentItem, item );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS AddChildItemCall事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnAddingChildItem( BaseItem addChildItem, BaseItem item )
        {
            EventHandler<AddingChildItemCallEventArgs> tempBeforeEventArgs = m_EventAddingChildItem;
            if ( tempBeforeEventArgs != null )
            {
                AddingChildItemCallEventArgs eventArgs = new AddingChildItemCallEventArgs( addChildItem, item );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnAddedChildItem( BaseItem addChildItem, BaseItem item )
        {
            EventHandler<AddedChildItemCallEventArgs> tempAfterEventArgs = m_EventAddedChildItem;
            if ( tempAfterEventArgs != null )
            {
                AddedChildItemCallEventArgs eventArgs = new AddedChildItemCallEventArgs( addChildItem, item );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS RemoveChildItemCall事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnRemovingChildItem( BaseItem removeChildItem, BaseItem item )
        {
            EventHandler<RemovingChildItemCallEventArgs> tempBeforeEventArgs = m_EventRemovingChildItem;
            if ( tempBeforeEventArgs != null )
            {
                RemovingChildItemCallEventArgs eventArgs = new RemovingChildItemCallEventArgs( removeChildItem, item );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnRemovedChildItem( BaseItem removeChildItem, BaseItem item )
        {
            EventHandler<RemovedChildItemCallEventArgs> tempAfterEventArgs = m_EventRemovedChildItem;
            if ( tempAfterEventArgs != null )
            {
                RemovedChildItemCallEventArgs eventArgs = new RemovedChildItemCallEventArgs( removeChildItem, item );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS Name事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingNameEventArgs> m_EventUpdatingName;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingName = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingNameEventArgs> UpdatingName
        {
            add
            {
                m_LockEventUpdatingName.Enter();
                {
                    m_EventUpdatingName += value;
                }
                m_LockEventUpdatingName.Exit();
            }
            remove
            {
                m_LockEventUpdatingName.Enter();
                {
                    m_EventUpdatingName -= value;
                }
                m_LockEventUpdatingName.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterUpdatedEventArgs> m_EventUpdatedName;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedName = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterUpdatedEventArgs> UpdatedName
        {
            add
            {
                m_LockEventUpdatedName.Enter();
                {
                    m_EventUpdatedName += value;
                }
                m_LockEventUpdatedName.Exit();
            }
            remove
            {
                m_LockEventUpdatedName.Enter();
                {
                    m_EventUpdatedName -= value;
                }
                m_LockEventUpdatedName.Exit();
            }
        }
        #endregion

        #region zh-CHS ItemTemplate事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingItemTemplateEventArgs> m_EventUpdatingItemTemplate;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingItemTemplate = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingItemTemplateEventArgs> UpdatingItemTemplate
        {
            add
            {
                m_LockEventUpdatingItemTemplate.Enter();
                {
                    m_EventUpdatingItemTemplate += value;
                }
                m_LockEventUpdatingItemTemplate.Exit();
            }
            remove
            {
                m_LockEventUpdatingItemTemplate.Enter();
                {
                    m_EventUpdatingItemTemplate -= value;
                }
                m_LockEventUpdatingItemTemplate.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedItemTemplateEventArgs> m_EventUpdatedItemTemplate;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedItemTemplate = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedItemTemplateEventArgs> UpdatedItemTemplate
        {
            add
            {
                m_LockEventUpdatedItemTemplate.Enter();
                {
                    m_EventUpdatedItemTemplate += value;
                }
                m_LockEventUpdatedItemTemplate.Exit();
            }
            remove
            {
                m_LockEventUpdatedItemTemplate.Enter();
                {
                    m_EventUpdatedItemTemplate -= value;
                }
                m_LockEventUpdatedItemTemplate.Exit();
            }
        }
        #endregion

        #region zh-CHS Owner事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingOwnerEventArgs> m_EventUpdatingOwner;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingOwner = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingOwnerEventArgs> UpdatingOwner
        {
            add
            {
                m_LockEventUpdatingOwner.Enter();
                {
                    m_EventUpdatingOwner += value;
                }
                m_LockEventUpdatingOwner.Exit();
            }
            remove
            {
                m_LockEventUpdatingOwner.Enter();
                {
                    m_EventUpdatingOwner -= value;
                }
                m_LockEventUpdatingOwner.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedOwnerEventArgs> m_EventUpdatedOwner;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedOwner = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedOwnerEventArgs> UpdatedOwner
        {
            add
            {
                m_LockEventUpdatedOwner.Enter();
                {
                    m_EventUpdatedOwner += value;
                }
                m_LockEventUpdatedOwner.Exit();
            }
            remove
            {
                m_LockEventUpdatedOwner.Enter();
                {
                    m_EventUpdatedOwner -= value;
                }
                m_LockEventUpdatedOwner.Exit();
            }
        }
        #endregion

        #region zh-CHS Parent事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingParentEventArgs> m_EventUpdatingParent;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingParent = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingParentEventArgs> UpdatingParent
        {
            add
            {
                m_LockEventUpdatingParent.Enter();
                {
                    m_EventUpdatingParent += value;
                }
                m_LockEventUpdatingParent.Exit();
            }
            remove
            {
                m_LockEventUpdatingParent.Enter();
                {
                    m_EventUpdatingParent -= value;
                }
                m_LockEventUpdatingParent.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedParentEventArgs> m_EventUpdatedParent;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAfterUpdateParent = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedParentEventArgs> UpdatedParent
        {
            add
            {
                m_LockEventAfterUpdateParent.Enter();
                {
                    m_EventUpdatedParent += value;
                }
                m_LockEventAfterUpdateParent.Exit();
            }
            remove
            {
                m_LockEventAfterUpdateParent.Enter();
                {
                    m_EventUpdatedParent -= value;
                }
                m_LockEventAfterUpdateParent.Exit();
            }
        }
        #endregion

        #region zh-CHS AddChildItem事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddingChildItemCallEventArgs> m_EventAddingChildItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddingChildItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddingChildItemCallEventArgs> AddingChildItem
        {
            add
            {
                m_LockEventAddingChildItem.Enter();
                {
                    m_EventAddingChildItem += value;
                }
                m_LockEventAddingChildItem.Exit();
            }
            remove
            {
                m_LockEventAddingChildItem.Enter();
                {
                    m_EventAddingChildItem -= value;
                }
                m_LockEventAddingChildItem.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddedChildItemCallEventArgs> m_EventAddedChildItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddedChildItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddedChildItemCallEventArgs> AddedChildItem
        {
            add
            {
                m_LockEventAddedChildItem.Enter();
                {
                    m_EventAddedChildItem += value;
                }
                m_LockEventAddedChildItem.Exit();
            }
            remove
            {
                m_LockEventAddedChildItem.Enter();
                {
                    m_EventAddedChildItem -= value;
                }
                m_LockEventAddedChildItem.Exit();
            }
        }
        #endregion

        #region zh-CHS RemoveChildItem事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovingChildItemCallEventArgs> m_EventRemovingChildItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovingChildItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovingChildItemCallEventArgs> RemovingChildItem
        {
            add
            {
                m_LockEventRemovingChildItem.Enter();
                {
                    m_EventRemovingChildItem += value;
                }
                m_LockEventRemovingChildItem.Exit();
            }
            remove
            {
                m_LockEventRemovingChildItem.Enter();
                {
                    m_EventRemovingChildItem -= value;
                }
                m_LockEventRemovingChildItem.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovedChildItemCallEventArgs> m_EventRemovedChildItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovedChildItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovedChildItemCallEventArgs> RemovedChildItem
        {
            add
            {
                m_LockEventRemovedChildItem.Enter();
                {
                    m_EventRemovedChildItem += value;
                }
                m_LockEventRemovedChildItem.Exit();
            }
            remove
            {
                m_LockEventRemovedChildItem.Enter();
                {
                    m_EventRemovedChildItem -= value;
                }
                m_LockEventRemovedChildItem.Exit();
            }
        }
        #endregion

        #endregion

    }
}
#endregion

