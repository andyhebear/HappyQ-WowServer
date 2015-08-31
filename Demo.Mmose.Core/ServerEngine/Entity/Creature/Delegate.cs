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
using Demo.Mmose.Core.Entity.Suit.Treasure;
#endregion

namespace Demo.Mmose.Core.Entity.Creature
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class BaseCreatureEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BaseCreatureEventArgs( BaseCreature creature )
        {
            m_Creature = creature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseCreature m_Creature = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseCreature Creature
        {
            get { return m_Creature; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatingNameEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatingNameEventArgs( string strName, BaseCreature creature ) :
            base( creature )
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatedNameEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatedNameEventArgs( string strName, BaseCreature creature ) :
            base( creature )
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatingCreatureTemplateEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatingCreatureTemplateEventArgs( BaseCreatureTemplate creatureTemplate, BaseCreature creature ) :
            base( creature )
        {
            m_NewCreatureTemplate = creatureTemplate;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreatureTemplate m_NewCreatureTemplate = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreatureTemplate NewCreatureTemplate
        {
            get { return m_NewCreatureTemplate; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatedCreatureTemplateEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatedCreatureTemplateEventArgs( BaseCreatureTemplate creatureTemplate, BaseCreature creature ) :
            base( creature )
        {
            m_OldCreatureTemplate = creatureTemplate;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreatureTemplate m_OldCreatureTemplate = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreatureTemplate OldCreatureTemplate
        {
            get { return m_OldCreatureTemplate; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatingLootsEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatingLootsEventArgs( OneTreasure[] treasure, BaseCreature creature ) :
            base( creature )
        {
            m_NewTreasure = treasure;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_NewTreasure = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] NewTreasure
        {
            get { return m_NewTreasure; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatedLootsEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatedLootsEventArgs( OneTreasure[] treasure, BaseCreature creature ) :
            base( creature )
        {
            m_OldTreasure = treasure;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_OldTreasure = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] OldLoots
        {
            get { return m_OldTreasure; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatingGoldLootsEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatingGoldLootsEventArgs( OneTreasure[] treasure, BaseCreature creature ) :
            base( creature )
        {
            m_NewTreasure = treasure;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_NewTreasure = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] NewTreasure
        {
            get { return m_NewTreasure; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatedGoldLootsEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatedGoldLootsEventArgs( OneTreasure[] treasure, BaseCreature creature ) :
            base( creature )
        {
            m_OldTreasure = treasure;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_OldTreasure = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] OldLoots
        {
            get { return m_OldTreasure; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class DieingCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public DieingCallEventArgs( BaseCreature creatureKiller, BaseCreature creature ) :
            base( creature )
        {
            m_CreatureKiller = creatureKiller;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseCreature m_CreatureKiller = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseCreature Killer
        {
            get { return m_CreatureKiller; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class DiedCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public DiedCallEventArgs( BaseCreature creatureKiller, BaseCreature creature ) :
            base( creature )
        {
            m_CreatureKiller = creatureKiller;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseCreature m_CreatureKiller = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseCreature Killer
        {
            get { return m_CreatureKiller; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class LivingCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public LivingCallEventArgs( BaseCreature creatureRevival, BaseCreature creature ) :
            base( creature )
        {
            m_CreatureRevival = creatureRevival;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseCreature m_CreatureRevival = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseCreature Revival
        {
            get { return m_CreatureRevival; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class LivedCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public LivedCallEventArgs( BaseCreature creatureRevival, BaseCreature creature ) :
            base( creature )
        {
            m_CreatureRevival = creatureRevival;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseCreature m_CreatureRevival = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseCreature Revival
        {
            get { return m_CreatureRevival; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class AddingItemCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddingItemCallEventArgs( BaseItem addItem, BaseCreature creature ) :
            base( creature )
        {
            m_AddIteme = addItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_AddIteme = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem AddItem
        {
            get { return m_AddIteme; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class AddedItemCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddedItemCallEventArgs( BaseItem addItem, BaseCreature creature ) :
            base( creature )
        {
            m_AddItem = addItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_AddItem = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem AddItem
        {
            get { return m_AddItem; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class RemovingItemCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovingItemCallEventArgs( BaseItem removeItem, BaseCreature creature ) :
            base( creature )
        {
            m_RemoveItem = removeItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_RemoveItem = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem RemoveItem
        {
            get { return m_RemoveItem; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class RemovedItemCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovedItemCallEventArgs( BaseItem removeItem, BaseCreature creature ) :
            base( creature )
        {
            m_RemoveItem = removeItem;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseItem m_RemoveItem = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseItem RemoveItem
        {
            get { return m_RemoveItem; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class AddingFriendCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddingFriendCallEventArgs( BaseCreature creatureFriend, BaseCreature creature ) :
            base( creature )
        {
            m_AddFriend = creatureFriend;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_AddFriend = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature AddFriend
        {
            get { return m_AddFriend; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class AddedFriendCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddedFriendCallEventArgs( BaseCreature creatureFriend, BaseCreature creature ) :
            base( creature )
        {
            m_AddFriend = creatureFriend;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_AddFriend = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature AddFriend
        {
            get { return m_AddFriend; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class RemovingFriendCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovingFriendCallEventArgs( BaseCreature creatureFriend, BaseCreature creature ) :
            base( creature )
        {
            m_RemoveFriend = creatureFriend;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_RemoveFriend = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature RemoveFriend
        {
            get { return m_RemoveFriend; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class RemovedFriendCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovedFriendCallEventArgs( BaseCreature creatureFriend, BaseCreature creature ) :
            base( creature )
        {
            m_RemoveFriend = creatureFriend;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_RemoveFriend = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature RemoveFriend
        {
            get { return m_RemoveFriend; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class AddingGroupCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddingGroupCallEventArgs( BaseCreature creatureGroup, BaseCreature creature ) :
            base( creature )
        {
            m_AddGroup = creatureGroup;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_AddGroup = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature AddGroup
        {
            get { return m_AddGroup; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class AddedGroupCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddedGroupCallEventArgs( BaseCreature creatureGroup, BaseCreature baseCreature ) :
            base( baseCreature )
        {
            m_AddGroup = creatureGroup;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_AddGroup = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature AddGroup
        {
            get { return m_AddGroup; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class RemovingGroupCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovingGroupCallEventArgs( BaseCreature creatureGroup, BaseCreature creature ) :
            base( creature )
        {
            m_AddGroup = creatureGroup;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_AddGroup = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature AddGroup
        {
            get { return m_AddGroup; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class RemovedGroupCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovedGroupCallEventArgs( BaseCreature creatureGroup, BaseCreature creature ) :
            base( creature )
        {
            m_RemoveGroup = creatureGroup;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_RemoveGroup = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature RemoveGroup
        {
            get { return m_RemoveGroup; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class AddingPartyCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddingPartyCallEventArgs( BaseCreature creatureParty, BaseCreature creature ) :
            base( creature )
        {
            m_AddParty = creatureParty;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_AddParty = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature AddParty
        {
            get { return m_AddParty; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class AddedPartyCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AddedPartyCallEventArgs( BaseCreature creatureParty, BaseCreature creature ) :
            base( creature )
        {
            m_AddParty = creatureParty;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_AddParty = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature AddParty
        {
            get { return m_AddParty; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class RemovingPartyCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovingPartyCallEventArgs( BaseCreature creatureParty, BaseCreature creature ) :
            base( creature )
        {
            m_RemoveParty = creatureParty;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_RemoveParty = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature RemoveParty
        {
            get { return m_RemoveParty; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class RemovedPartyCallEventArgs : BaseCreatureEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public RemovedPartyCallEventArgs( BaseCreature creatureParty, BaseCreature creature ) :
            base( creature )
        {
            m_RemoveParty = creatureParty;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_RemoveParty = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature RemoveParty
        {
            get { return m_RemoveParty; }
        }
        #endregion
    }
    #endregion
}
#endregion

