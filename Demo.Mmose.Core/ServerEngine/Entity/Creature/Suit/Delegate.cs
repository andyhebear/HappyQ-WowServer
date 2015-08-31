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
using Demo.Mmose.Core.Entity.Item;
#endregion

namespace Demo.Mmose.Core.Entity.Creature.Suit
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseActionBarManager的事件数据类
    /// </summary>
    public class BaseActionBarHandlerEventArgs<T> : EventArgs where T : BaseActionBar
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BaseActionBarHandlerEventArgs( BaseActionBarManager<T> baseActionBarHandlerT )
        {
            m_BaseActionBarHandler = baseActionBarHandlerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseActionBarManager<T> m_BaseActionBarHandler = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseActionBarManager<T> ActionBarHandler
        {
            get { return m_BaseActionBarHandler; }
        }
        #endregion
    }

    /// <summary>
    /// BaseActionBarManager的事件数据类
    /// </summary>
    public class BeforeAddActionBarCallEventArgs<T> : BaseActionBarHandlerEventArgs<T> where T : BaseActionBar
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddActionBarCallEventArgs( T actionBarT, BaseActionBarManager<T> baseActionBarHandlerT ) :
            base( baseActionBarHandlerT )
        {
            m_AddActionBar = actionBarT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddActionBar = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddActionBar
        {
            get { return m_AddActionBar; }
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
    /// BaseActionBarManager的事件数据类
    /// </summary>
    public class AfterAddActionBarCallEventArgs<T> : BaseActionBarHandlerEventArgs<T> where T : BaseActionBar
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddActionBarCallEventArgs( T actionBarT, BaseActionBarManager<T> baseActionBarHandlerT ) :
            base( baseActionBarHandlerT )
        {
            m_AddActionBar = actionBarT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddActionBar = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddActionBar
        {
            get { return m_AddActionBar; }
        }
        #endregion
    }

    /// <summary>
    /// BaseActionBarManager的事件数据类
    /// </summary>
    public class BeforeRemoveActionBarCallEventArgs<T> : BaseActionBarHandlerEventArgs<T> where T : BaseActionBar
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveActionBarCallEventArgs( T actionBarT, BaseActionBarManager<T> baseActionBarHandlerT ) :
            base( baseActionBarHandlerT )
        {
            m_RemoveActionBar = actionBarT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveActionBar = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveActionBar
        {
            get { return m_RemoveActionBar; }
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
    /// BaseActionBarManager的事件数据类
    /// </summary>
    public class AfterRemoveActionBarCallEventArgs<T> : BaseActionBarHandlerEventArgs<T> where T : BaseActionBar
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveActionBarCallEventArgs( T actionBarT, BaseActionBarManager<T> baseActionBarHandlerT ) :
            base( baseActionBarHandlerT )
        {
            m_RemoveActionBar = actionBarT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveActionBar = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveActionBar
        {
            get { return m_RemoveActionBar; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class BaseBagHandlerEventArgs<T, V> : EventArgs
        where T : BaseItemContainer<V>
        where V : BaseItem

    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BaseBagHandlerEventArgs( BaseBagManager<T, V> baseBagHandlerT )
        {
            m_BaseBagHandler = baseBagHandlerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseBagManager<T, V> m_BaseBagHandler = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseBagManager<T, V> BagHandler
        {
            get { return m_BaseBagHandler; }
        }
        #endregion
    }

    /// <summary>
    /// BaseBagManager的事件数据类
    /// </summary>
    public class BeforeAddItemContainerCallEventArgs<T, V> : BaseBagHandlerEventArgs<T, V>
        where T : BaseItemContainer<V>
        where V : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddItemContainerCallEventArgs( T itemContainerT, BaseBagManager<T, V> baseBagHandlerT ) :
            base( baseBagHandlerT )
        {
            m_AddItemContainer = itemContainerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddItemContainer = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddItemContainer
        {
            get { return m_AddItemContainer; }
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
    /// BaseBagManager的事件数据类
    /// </summary>
    public class AfterAddItemContainerCallEventArgs<T, V> : BaseBagHandlerEventArgs<T, V>
        where T : BaseItemContainer<V>
        where V : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddItemContainerCallEventArgs( T itemContainerT, BaseBagManager<T, V> baseBagHandlerT ) :
            base( baseBagHandlerT )
        {
            m_AddItemContainer = itemContainerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddItemContainer = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddItemContainer
        {
            get { return m_AddItemContainer; }
        }
        #endregion
    }

    /// <summary>
    /// BaseBagManager的事件数据类
    /// </summary>
    public class BeforeRemoveItemContainerCallEventArgs<T, V> : BaseBagHandlerEventArgs<T, V>
        where T : BaseItemContainer<V>
        where V : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveItemContainerCallEventArgs( T itemContainerT, BaseBagManager<T, V> baseBagHandlerT ) :
            base( baseBagHandlerT )
        {
            m_RemoveItemContainer = itemContainerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveItemContainer = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveItemContainer
        {
            get { return m_RemoveItemContainer; }
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
    /// BaseBagManager的事件数据类
    /// </summary>
    public class AfterRemoveItemContainerCallEventArgs<T, V> : BaseBagHandlerEventArgs<T, V>
        where T : BaseItemContainer<V>
        where V : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveItemContainerCallEventArgs( T itemContainerT, BaseBagManager<T, V> baseBagHandlerT ) :
            base( baseBagHandlerT )
        {
            m_RemoveItemContainer = itemContainerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveItemContainer = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveItemContainer
        {
            get { return m_RemoveItemContainer; }
        }
        #endregion
    }
    #endregion
}
#endregion