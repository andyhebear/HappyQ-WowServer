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
using System.Diagnostics;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Entity.Creature;
#endregion

namespace Demo.Mmose.Core.Entity.Item
{
    // 道具的信息
    //////////////////////////////////////////////////////////////////////////
    // 道具(单一)
    // 道具(容器)
    // 
    // 
    // 

    // 道具的行为
    //////////////////////////////////////////////////////////////////////////
    // 道具(交易-玩家)
    // 道具(装备-玩家)
    // 道具(容器-道具)
    // 道具(位置-地图)
    // 道具(存在/消失-地图)
    // 道具(其它)
    // 
    // 

    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseItem : WorldEntity, IComparable, IComparable<BaseItem>
    {
        #region zh-CHS 共有常量 | en Public Constants
        /// <summary>
        /// 
        /// </summary>
        public static readonly long SlotNotSet = Serial.MinusOne;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public BaseItem()
        {
            DefaultItemInit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public BaseItem( Serial serial )
            : base(serial)
        {
            DefaultItemInit();
        }

        #region zh-CHS 道具的初始化 | en
        /// <summary>
        /// 缺省的初始化人物
        /// </summary>
        protected virtual void DefaultItemInit()
        {
        }
        #endregion

        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Name属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Name = string.Empty;
        #endregion
        /// <summary>
        /// 道具的名字
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set
            {
                string oldName = m_Name;

                if ( m_BaseItemState != null )
                {
                    if ( m_BaseItemState.OnUpdatingName( value, this ) == true )
                        return;
                }

                m_Name = value;
                m_BaseItemState.IsUpdateName = true;

                if ( m_BaseItemState != null )
                    m_BaseItemState.OnUpdatedName( oldName, this );
            }
        }

        #endregion

        #region zh-CHS ItemTemplate属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的帐号等级
        /// </summary>
        private BaseItemTemplate m_ItemTemplate = null;
        #endregion
        /// <summary>
        /// 人物的帐号等级
        /// </summary>
        public BaseItemTemplate ItemTemplate
        {
            get { return m_ItemTemplate; }
            set
            {
                BaseItemTemplate oldItemTemplate = m_ItemTemplate;

                if ( m_BaseItemState != null )
                {
                    if ( m_BaseItemState.OnUpdatingItemTemplate( value, this ) == true )
                        return;
                }

                m_ItemTemplate = value;
                m_BaseItemState.IsUpdateItemTemplate = true;

                if ( m_BaseItemState != null )
                    m_BaseItemState.OnUpdatedItemTemplate( oldItemTemplate, this );
            }
        }

        #endregion

        #region zh-CHS Owner属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_Owner = null;
        #endregion
        /// <summary>
        /// 拥有者的对象
        /// </summary>
        public virtual BaseCreature Owner
        {
            get { return m_Owner; }
            set
            {
                BaseCreature oldOwner = m_Owner;

                if ( m_BaseItemState != null )
                {
                    if ( m_BaseItemState.OnUpdatingOwner( value, this ) == true )
                        return;
                }

                m_Owner = value;
                m_BaseItemState.IsUpdateOwner = true;

                if ( m_BaseItemState != null )
                    m_BaseItemState.OnUpdatedOwner( oldOwner, this );
            }
        }

        #endregion

        #region zh-CHS Parent属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_Parent = null;
        #endregion
        /// <summary>
        /// 拥有者的对象
        /// </summary>
        public virtual BaseItem Parent
        {
            get { return m_Parent; }
            set
            {
                BaseItem oldParent = m_Parent;

                if ( m_BaseItemState != null )
                {
                    if ( m_BaseItemState.OnUpdatingParent( value, this ) == true )
                        return;
                }

                m_Parent = value;
                m_BaseItemState.IsUpdateParent = true;

                if ( m_BaseItemState != null )
                    m_BaseItemState.OnUpdatedParent( oldParent, this );
            }
        }

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentItem"></param>
        protected virtual void OnParentDeleted( BaseItem parentItem )
        {
        }
        #endregion

        #endregion

        #region zh-CHS 子道具列表 属性 | en ChildItems Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的道具列表
        /// </summary>
        private SafeDictionary<long, BaseItem> m_ChildItems = new SafeDictionary<long, BaseItem>();
        #endregion
        /// <summary>
        /// 人物的道具列表(包裹与身上)
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(子道具)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public BaseItem[] ToArrayInChildItems()
        {
            return m_ChildItems.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 添加道具
        /// </summary>
        /// <param name="item"></param>
        public bool AddChildItem( long lItemSerial, BaseItem addChildItem )
        {
            if ( addChildItem == null )
                throw new Exception( "BaseCreature.AddItem(...) - addChildItem == null error!" );

            if ( base.Deleted == true )
                return false;

            if ( m_BaseItemState != null )
            {
                if ( m_BaseItemState.OnAddingChildItem( addChildItem, this ) == true )
                    return false;
            }

            m_ChildItems.Add( lItemSerial, addChildItem );
            m_BaseItemState.IsUpdateAddChildItemCall = true;

            if ( m_BaseItemState != null )
                m_BaseItemState.OnAddedChildItem( addChildItem, this );

            return true;
        }

        /// <summary>
        /// 移出道具
        /// </summary>
        /// <param name="item"></param>
        public bool RemoveChildItem( long lItemSerial )
        {
            if ( base.Deleted == true )
                return false;

            BaseItem removeChildItem = FindChildItemOnSerial( lItemSerial );
            if ( removeChildItem == null )
                return false;

            if ( m_BaseItemState != null )
            {
                if ( m_BaseItemState.OnRemovingChildItem( removeChildItem, this ) == true )
                    return false;
            }

            m_ChildItems.Remove( lItemSerial );
            m_BaseItemState.IsUpdateRemoveChildItemCall = true;

            if ( m_BaseItemState != null )
                m_BaseItemState.OnRemovedChildItem( removeChildItem, this );

            return true;
        }

        /// <summary>
        /// 在身上找道具
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public BaseItem FindChildItemOnSerial( long iItemSerial )
        {
            return m_ChildItems.GetValue( iItemSerial );
        }

        #endregion

        #endregion

        #region zh-CHS BaseItemState属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 道具的的状态
        /// </summary>
        private BaseItemState m_BaseItemState = null;
        #endregion
        /// <summary>
        /// 道具的的状态
        /// </summary>
        public BaseItemState BaseItemState
        {
            get { return m_BaseItemState; }
            protected set { m_BaseItemState = value; }
        }

        #endregion

        #region zh-CHS SlotId属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_SlotId = BaseItem.SlotNotSet;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long SlotId
        {
            get { return m_SlotId; }
            internal set { m_SlotId = value; }
        }

        #endregion

        #endregion

        #region zh-CHS 创建一个新的自身道具 | en Public Method
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseItem CreateNewItemInstance()
        {
            return CreateNewInstance<BaseItem>();
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( BaseItem other )
        {
            return CompareTo( other as WorldEntity );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_Name;
        }
        #endregion
    }
}
#endregion