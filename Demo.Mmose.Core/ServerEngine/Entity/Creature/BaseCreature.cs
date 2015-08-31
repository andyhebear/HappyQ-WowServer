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
using System.Diagnostics;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Suit.Treasure;
#endregion

namespace Demo.Mmose.Core.Entity.Creature
{
    // 人物的信息
    //////////////////////////////////////////////////////////////////////////
    // 人物的种族
    // 人物的状态
    // 人物的抗性
    // 人物的信息
    // 人物的道具(包裹&身上)

    // 人物的动作
    //////////////////////////////////////////////////////////////////////////
    // 人物的移动
    // 人物的说话
    // 人物用道具
    // 人物的死亡
    // 人物的复活(NPC/怪物-刷出)

    // 人物的AI
    //////////////////////////////////////////////////////////////////////////
    // 人物的AI(移动/说话/攻击/防御/做任务)
    // 人物的普通(攻击/防御)
    // 人物的技能(攻击/增益/诅咒)
    // 人物的魔法(攻击/增益/诅咒)

    // 人物掉落的道具(玩家/NPC-可不掉落)
    // 人物可用的道具
    // 人物可见的范围
    // 
    // 
    // 

    /// <summary>
    /// Base class representing players, npcs, and creatures.
    /// </summary>
    public abstract class BaseCreature : WorldEntity, IComparable, IComparable<BaseCreature>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BaseCreature()
        {
            DefaultCreatureInit();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serial">唯一序号</param>
        public BaseCreature( Serial serial )
            : base( serial )
        {
            DefaultCreatureInit();
        }

        #region zh-CHS 人物的初始化 | en
        /// <summary>
        /// 缺省的初始化人物
        /// </summary>
        protected virtual void DefaultCreatureInit()
        {
        }
        #endregion

        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Name属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的名字
        /// </summary>
        private string m_Name = string.Empty;
        #endregion
        /// <summary>
        /// 人物的名字
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set
            {
                string oldName = m_Name;

                if ( m_BaseCreatureState != null )
                {
                    if ( m_BaseCreatureState.OnUpdatingName( value, this ) == true )
                        return;
                }

                m_Name = value;
                m_BaseCreatureState.IsUpdateName = true;

                if ( m_BaseCreatureState != null )
                    m_BaseCreatureState.OnUpdatedName( oldName, this );
            }
        }

        #endregion

        #region zh-CHS CreatureTemplate属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的帐号等级
        /// </summary>
        private BaseCreatureTemplate m_CreatureTemplate = null;
        #endregion
        /// <summary>
        /// 人物的帐号等级
        /// </summary>
        public BaseCreatureTemplate CreatureTemplate
        {
            get { return m_CreatureTemplate; }
            set
            {
                BaseCreatureTemplate oldCreatureTemplate = m_CreatureTemplate;

                if ( m_BaseCreatureState != null )
                {
                    if ( m_BaseCreatureState.OnUpdatingCreatureTemplate( value, this ) == true )
                        return;
                }

                m_CreatureTemplate = value;
                m_BaseCreatureState.IsUpdateCreatureTemplate = true;

                if ( m_BaseCreatureState != null )
                    m_BaseCreatureState.OnUpdatedCreatureTemplate( oldCreatureTemplate, this );
            }
        }

        #endregion

        #region zh-CHS Alive属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物是否在活着(true)或死亡(false)
        /// </summary>
        private bool m_Alive = true;
        #endregion
        /// <summary>
        /// 人物是否在活着(true)或死亡(false)
        /// </summary>
        public virtual bool Alive
        {
            get { return m_Alive; }
        }

        #region zh-CHS 人物的死亡(Player/NPC/Monster) | en
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Death()
        {
            return Die( null );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobileKiller"></param>
        /// <returns></returns>
        public bool Die( BaseCreature creatureKiller )
        {
            if ( base.Deleted == true || m_Alive == false )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnDieingCall( creatureKiller, this ) == true )
                    return false;
            }

            m_Alive = false;
            m_BaseCreatureState.IsDeathCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnDiedCall( creatureKiller, this );

            return true;
        }
        #endregion

        #region zh-CHS 人物的复活(Player/NPC/Monster-刷出) | en

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Live()
        {
            return Live( null );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobileResurrect"></param>
        /// <returns></returns>
        public bool Live( BaseCreature creatureLive )
        {
            if ( base.Deleted == true || m_Alive == true )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnLivingCall( creatureLive, this ) == true )
                    return false;
            }

            m_Alive = true;
            m_BaseCreatureState.IsRevivalCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnLivedCall( creatureLive, this );

            return true;
        }

        #endregion

        #endregion

        #region zh-CHS CreationTime 属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物实例产生的时间
        /// </summary>
        private DateTime m_CreationTime = DateTime.Now;
        #endregion
        /// <summary>
        /// 实例人物时产生的时间
        /// </summary>
        public DateTime CreationTime
        {
            get { return m_CreationTime; }
        }

        #endregion

        #region zh-CHS Loots属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        OneTreasure[] m_Loots = null;
        #endregion
        /// <summary>
        /// 随机掉落的道具
        /// </summary>
        public OneTreasure[] Loots
        {
            get { return m_Loots; }
            set
            {
                OneTreasure[] oldLoots = m_Loots;

                if ( m_BaseCreatureState != null )
                {
                    if ( m_BaseCreatureState.OnUpdatingLoots( value, this ) == true )
                        return;
                }

                m_Loots = value;
                m_BaseCreatureState.IsUpdateLoots = true;

                if ( m_BaseCreatureState != null )
                    m_BaseCreatureState.OnUpdatedLoots( oldLoots, this );
            }
        }

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 开始掉落随机的道具
        /// </summary>
        /// <returns></returns>
        public ItemT[] GenerateLoot<ItemT>() where ItemT : BaseItem
        {
            if ( m_Loots == null )
                return null;

            List<ItemT> treasureList = new List<ItemT>( OneTreasure.DROP_CACHED_SIZE );

            for ( int iIndex = 0; iIndex < m_Loots.Length; iIndex++ )
            {
                OneTreasure oneTreasure = m_Loots[iIndex];
                if ( oneTreasure.IsDrop() == true )
                {
                    ItemT[] itemArray = oneTreasure.RandomDrop<ItemT>();
                    if ( itemArray != null )
                        treasureList.AddRange( itemArray );
                }
            }

            return treasureList.ToArray();
        }

        #endregion

        #endregion

        #region zh-CHS GoldLoots属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        OneTreasure[] m_GoldLoots = null;
        #endregion
        /// <summary>
        /// 随机掉落的道具
        /// </summary>
        public OneTreasure[] GoldLoots
        {
            get { return m_GoldLoots; }
            set
            {
                OneTreasure[] oldGoldLoots = m_GoldLoots;

                if ( m_BaseCreatureState != null )
                {
                    if ( m_BaseCreatureState.OnUpdatingLoots( value, this ) == true )
                        return;
                }

                m_GoldLoots = value;
                m_BaseCreatureState.IsUpdateGoldLoots = true;

                if ( m_BaseCreatureState != null )
                    m_BaseCreatureState.OnUpdatedLoots( oldGoldLoots, this );
            }
        }

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 开始掉落随机的道具
        /// </summary>
        /// <returns></returns>
        public GoldItem[] GenerateGoldLoot()
        {
            if ( m_GoldLoots == null )
                return null;

            List<GoldItem> treasureList = new List<GoldItem>( OneTreasure.DROP_CACHED_SIZE );

            for ( int iIndex = 0; iIndex < m_Loots.Length; iIndex++ )
            {
                OneTreasure oneTreasure = m_Loots[iIndex];
                if ( oneTreasure.IsDrop() )
                {
                    GoldItem[] goldItemArray = oneTreasure.RandomGoldDrop();
                    if ( goldItemArray != null )
                        treasureList.AddRange( goldItemArray );
                }
            }

            return treasureList.ToArray();
        }

        #endregion

        #endregion

        #region zh-CHS 道具列表 属性 | en Items Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的道具列表
        /// </summary>
        private SafeDictionary<long, BaseItem> m_ToteItems = new SafeDictionary<long, BaseItem>();
        #endregion
        /// <summary>
        /// 人物的道具列表(包裹与身上)
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(道具)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public BaseItem[] ToArrayInItems()
        {
            return m_ToteItems.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 添加道具
        /// </summary>
        /// <param name="item"></param>
        public bool AddItem( Serial itemSerial, BaseItem addItem )
        {
            if ( addItem == null )
                throw new Exception( "BaseCreature.AddItem(...) - addItem == null error!" );

            if ( base.Deleted == true )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnAddingItem( addItem, this ) == true )
                    return false;
            }

            m_ToteItems.Add( itemSerial, addItem );
            m_BaseCreatureState.IsAddItemCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnAddedItem( addItem, this );

            return true;
        }

        /// <summary>
        /// 移出道具
        /// </summary>
        /// <param name="item"></param>
        public bool RemoveItem( Serial itemSerial )
        {
            if ( base.Deleted == true )
                return false;

            BaseItem item = FindItemOnSerial( itemSerial );
            if ( item == null )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnRemovingItem( item, this ) == true )
                    return false;
            }

            m_ToteItems.Remove( itemSerial );
            m_BaseCreatureState.IsRemoveItemCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnRemovedItem( item, this );

            return true;
        }

        /// <summary>
        /// 在身上找道具
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public BaseItem FindItemOnSerial( Serial itemSerial )
        {
            return m_ToteItems.GetValue( itemSerial );
        }

        #endregion

        #endregion

        #region zh-CHS 好友列表 方法 | en Friend Method

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 好友的集合
        /// </summary>
        private SafeDictionary<long, BaseCreature> m_BaseCreaturesFriend = new SafeDictionary<long, BaseCreature>();
        #endregion
        /// <summary>
        /// 全部好友的数组
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(好友)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public BaseCreature[] ToArrayInFriend()
        {
            return m_BaseCreaturesFriend.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 添加好友到集合
        /// </summary>
        public bool AddFriend( Serial creatureSerial, BaseCreature addCreature )
        {
            if ( addCreature == null )
                throw new Exception( "BaseCreature.AddItem(...) - addCreature == null error!" );

            if ( base.Deleted == true )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnAddingFriend( addCreature, this ) == true )
                    return false;
            }

            m_BaseCreaturesFriend.Add( creatureSerial, addCreature );
            m_BaseCreatureState.IsAddFriendCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnAddedFriend( addCreature, this );

            return true;
        }

        /// <summary>
        /// 在好友的集合内删除某好友
        /// </summary>
        /// <param name="iCreatureSerial"></param>
        public bool RemoveFriend( Serial creatureSerial )
        {
            if ( base.Deleted == true )
                return false;

            BaseCreature baseCreature = FindFriendOnSerial( creatureSerial );
            if ( baseCreature == null )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnRemovingFriend( baseCreature, this ) == true )
                    return false;
            }

            m_BaseCreaturesFriend.Remove( creatureSerial );
            m_BaseCreatureState.IsRemoveFriendCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnRemovedFriend( baseCreature, this );

            return true;
        }

        /// <summary>
        /// 在好友的集合内给出某好友
        /// </summary>
        /// <param name="iCreatureSerial"></param>
        /// <returns></returns>
        public BaseCreature FindFriendOnSerial( Serial creatureSerial )
        {
            return m_BaseCreaturesFriend.GetValue( creatureSerial );
        }
        #endregion

        #endregion

        #region zh-CHS 组队列表 方法 | en Group Method

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 好友的集合
        /// </summary>
        private SafeDictionary<long, BaseCreature> m_BaseCreaturesGroup = new SafeDictionary<long, BaseCreature>();
        #endregion
        /// <summary>
        /// 全部好友的数组
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(组队)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public BaseCreature[] ToArrayInGroup()
        {
            return m_BaseCreaturesGroup.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 添加好友到集合
        /// </summary>
        public bool AddGroup( Serial creatureSerial, BaseCreature addCreature )
        {
            if ( addCreature == null )
                throw new Exception( "BaseCreature.AddGroup(...) - addCreature == null error!" );

            if ( base.Deleted == true )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnAddingGroup( addCreature, this ) == true )
                    return false;
            }

            m_BaseCreaturesGroup.Add( creatureSerial, addCreature );
            m_BaseCreatureState.IsAddGroupCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnAddedGroup( addCreature, this );

            return true;
        }

        /// <summary>
        /// 在好友的集合内删除某好友
        /// </summary>
        /// <param name="iMapID"></param>
        public bool RemoveGroup( Serial creatureSerial )
        {
            if ( base.Deleted == true )
                return false;

            BaseCreature baseCreature = FindGroupOnSerial( creatureSerial );
            if ( baseCreature == null )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnRemovingGroup( baseCreature, this ) == true )
                    return false;
            }

            m_BaseCreaturesGroup.Remove( creatureSerial );
            m_BaseCreatureState.IsRemoveGroupCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnRemovedGroup( baseCreature, this );

            return true;
        }

        /// <summary>
        /// 在好友的集合内给出某好友
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public BaseCreature FindGroupOnSerial( Serial creatureSerial )
        {
            return m_BaseCreaturesGroup.GetValue( creatureSerial );
        }
        #endregion

        #endregion

        #region zh-CHS 团体列表 方法 | en Party Method

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 好友的集合
        /// </summary>
        private SafeDictionary<long, BaseCreature> m_BaseCreaturesParty = new SafeDictionary<long, BaseCreature>();
        #endregion
        /// <summary>
        /// 全部好友的数组
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(团队)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public BaseCreature[] ToArrayInParty()
        {
            return m_BaseCreaturesParty.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 添加好友到集合
        /// </summary>
        public bool AddParty( Serial creatureSerial, BaseCreature addCreature )
        {
            if ( addCreature == null )
                throw new Exception( "BaseCreature.AddParty(...) - addCreature == null error!" );

            if ( base.Deleted == true )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnAddingParty( addCreature, this ) == true )
                    return false;
            }

            m_BaseCreaturesParty.Add( addCreature.Serial, addCreature );
            m_BaseCreatureState.IsAddPartyCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnAddedParty( addCreature, this );

            return true;
        }

        /// <summary>
        /// 在好友的集合内删除某好友
        /// </summary>
        /// <param name="iMapID"></param>
        public bool RemoveParty( Serial creatureSerial )
        {
            if ( base.Deleted == true )
                return false;

            BaseCreature baseCreature = FindPartyOnSerial( creatureSerial );
            if ( baseCreature == null )
                return false;

            if ( m_BaseCreatureState != null )
            {
                if ( m_BaseCreatureState.OnRemovingParty( baseCreature, this ) == true )
                    return false;
            }

            m_BaseCreaturesParty.Remove( creatureSerial );
            m_BaseCreatureState.IsRemovePartyCall = true;

            if ( m_BaseCreatureState != null )
                m_BaseCreatureState.OnRemovedParty( baseCreature, this );

            return true;
        }

        /// <summary>
        /// 在好友的集合内给出某好友
        /// </summary>
        /// <param name="iCreatureSerial"></param>
        /// <returns></returns>
        public BaseCreature FindPartyOnSerial( Serial creatureSerial )
        {
            return m_BaseCreaturesParty.GetValue( creatureSerial );
        }

        #endregion

        #endregion

        #region zh-CHS CreatureState属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的状态机
        /// </summary>
        private BaseCreatureState m_BaseCreatureState = null;
        #endregion
        /// <summary>
        /// BaseCreatureState人物的状态器
        /// </summary>
        public BaseCreatureState BaseCreatureState
        {
            get { return m_BaseCreatureState; }
            protected set { m_BaseCreatureState = value; }
        }

        #endregion

        #endregion

        #region zh-CHS 创建一个新的自身人物 | en Public Method
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseCreature CreateNewCreatureInstance()
        {
            return CreateNewInstance<BaseCreature>();
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( BaseCreature other )
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