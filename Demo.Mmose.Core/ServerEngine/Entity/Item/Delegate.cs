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
using Demo.Mmose.Core.Entity.Creature;
#endregion

namespace Demo.Mmose.Core.Entity.Item
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class BaseItemEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BaseItemEventArgs( BaseItem item )
        {
            m_Item = item;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseItem m_Item = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseItem Item
        {
            get { return m_Item; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class UpdatingNameEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseItem"></param>
        public UpdatingNameEventArgs( string strName, BaseItem item ) :
            base( item )
        {
            m_NewName = strName;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_NewName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string NewName
        {
            get { return m_NewName; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class AfterUpdatedEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseItem"></param>
        public AfterUpdatedEventArgs( string strName, BaseItem item ) :
            base( item )
        {
            m_OldName = strName;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_OldName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string OldName
        {
            get { return m_OldName; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class UpdatingItemTemplateEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseItem"></param>
        public UpdatingItemTemplateEventArgs( BaseItemTemplate itemTemplate, BaseItem item ) :
            base( item )
        {
            m_NewItemTemplate = itemTemplate;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItemTemplate m_NewItemTemplate = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItemTemplate NewItemTemplate
        {
            get { return m_NewItemTemplate; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class UpdatedItemTemplateEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseItem"></param>
        public UpdatedItemTemplateEventArgs( BaseItemTemplate itemTemplate, BaseItem baseItem ) :
            base( baseItem )
        {
            m_OldItemTemplate = itemTemplate;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItemTemplate m_OldItemTemplate = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItemTemplate OldItemTemplate
        {
            get { return m_OldItemTemplate; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class UpdatingOwnerEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseItem"></param>
        public UpdatingOwnerEventArgs( BaseCreature ownerCreature, BaseItem item ) :
            base( item )
        {
            m_NewOwner = ownerCreature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_NewOwner = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature NewOwner
        {
            get { return m_NewOwner; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class UpdatedOwnerEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseItem"></param>
        public UpdatedOwnerEventArgs( BaseCreature ownerCreature, BaseItem item ) :
            base( item )
        {
            m_OldOwner = ownerCreature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_OldOwner = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature OldOwner
        {
            get { return m_OldOwner; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class UpdatingParentEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseItem"></param>
        public UpdatingParentEventArgs( BaseItem parentItem, BaseItem item ) :
            base( item )
        {
            m_NewParent = parentItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_NewParent = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem NewParent
        {
            get { return m_NewParent; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class UpdatedParentEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseItem"></param>
        public UpdatedParentEventArgs( BaseItem parentItem, BaseItem item ) :
            base( item )
        {
            m_OldParent = parentItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_OldParent = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem OldParent
        {
            get { return m_OldParent; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class AddingChildItemCallEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddingChildItemCallEventArgs( BaseItem addChildItem, BaseItem item ) :
            base( item )
        {
            m_AddChildIteme = addChildItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_AddChildIteme = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem AddChildItem
        {
            get { return m_AddChildIteme; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class AddedChildItemCallEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddedChildItemCallEventArgs( BaseItem addChildItem, BaseItem item ) :
            base( item )
        {
            m_AddChildItem = addChildItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_AddChildItem = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem AddChildItem
        {
            get { return m_AddChildItem; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class RemovingChildItemCallEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovingChildItemCallEventArgs( BaseItem removeChildItem, BaseItem item ) :
            base( item )
        {
            m_RemoveChildItem = removeChildItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_RemoveChildItem = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem RemoveChildItem
        {
            get { return m_RemoveChildItem; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItem的事件数据类
    /// </summary>
    public class RemovedChildItemCallEventArgs : BaseItemEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovedChildItemCallEventArgs( BaseItem removeChildItem, BaseItem item ) :
            base( item )
        {
            m_RemoveChildItem = removeChildItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_RemoveChildItem = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem RemoveChildItem
        {
            get { return m_RemoveChildItem; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItemContainer的事件数据类
    /// </summary>
    public class ItemContainerEventArgs<T> : EventArgs where T : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public ItemContainerEventArgs( BaseItemContainer<T> itemContainerT )
        {
            m_ItemContainer = itemContainerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseItemContainer<T> m_ItemContainer = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseItemContainer<T> ItemContainer
        {
            get { return m_ItemContainer; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItemContainer的事件数据类
    /// </summary>
    public class AddingSubItemCallEventArgs<T> : ItemContainerEventArgs<T> where T : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddingSubItemCallEventArgs( T addSubItem, BaseItemContainer<T> itemContainerT ) :
            base( itemContainerT )
        {
            m_AddSubIteme = addSubItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddSubIteme = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddSubItem
        {
            get { return m_AddSubIteme; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItemContainer的事件数据类
    /// </summary>
    public class AddedSubItemCallEventArgs<T> : ItemContainerEventArgs<T> where T : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddedSubItemCallEventArgs( T addSubItem, BaseItemContainer<T> itemContainerT ) :
            base( itemContainerT )
        {
            m_AddSubItem = addSubItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddSubItem = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddSubItem
        {
            get { return m_AddSubItem; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItemContainer的事件数据类
    /// </summary>
    public class RemovingSubItemCallEventArgs<T> : ItemContainerEventArgs<T> where T : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovingSubItemCallEventArgs( T removeSubItem, BaseItemContainer<T> itemContainerT ) :
            base( itemContainerT )
        {
            m_RemoveSubItem = removeSubItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveSubItem = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveSubItem
        {
            get { return m_RemoveSubItem; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseItemContainer的事件数据类
    /// </summary>
    public class RemovedSubItemCallEventArgs<T> : ItemContainerEventArgs<T> where T : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovedSubItemCallEventArgs( T removeSubItem, BaseItemContainer<T> itemContainerT ) :
            base( itemContainerT )
        {
            m_RemoveSubItem = removeSubItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveSubItem = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveSubItem
        {
            get { return m_RemoveSubItem; }
        }
        #endregion
    }

    #endregion
}
#endregion
