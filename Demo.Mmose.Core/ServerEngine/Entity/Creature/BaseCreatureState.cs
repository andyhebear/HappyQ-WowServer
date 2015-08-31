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
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Suit.Treasure;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Creature
{
    /// <summary>
    /// BaseMobile Delta
    /// </summary>
    public class BaseCreatureState
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 单体
        /// </summary>
        private static BaseCreatureState s_BaseCreatureState = new BaseCreatureState();
        #endregion
        /// <summary>
        /// 单体
        /// </summary>
        public static BaseCreatureState SingletonInstance
        {
            get { return s_BaseCreatureState; }
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
        private bool m_UpdateCreatureTemplate = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateCreatureTemplate
        {
            get { return m_UpdateCreatureTemplate; }
            internal set { m_UpdateCreatureTemplate = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateLoots = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateLoots
        {
            get { return m_UpdateLoots; }
            internal set { m_UpdateLoots = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateGoldLoots = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateGoldLoots
        {
            get { return m_UpdateGoldLoots; }
            internal set { m_UpdateGoldLoots = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_DeathCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeathCall
        {
            get { return m_DeathCall; }
            internal set { m_DeathCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_RevivalCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsRevivalCall
        {
            get { return m_RevivalCall; }
            internal set { m_RevivalCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_AddItemCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsAddItemCall
        {
            get { return m_AddItemCall; }
            internal set { m_AddItemCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_RemoveItemCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsRemoveItemCall
        {
            get { return m_RemoveItemCall; }
            internal set { m_RemoveItemCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_AddFriendCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsAddFriendCall
        {
            get { return m_AddFriendCall; }
            internal set { m_AddFriendCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_RemoveFriendCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsRemoveFriendCall
        {
            get { return m_RemoveFriendCall; }
            internal set { m_RemoveFriendCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_AddGroupCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsAddGroupCall
        {
            get { return m_AddGroupCall; }
            internal set { m_AddGroupCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_RemoveGroupCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsRemoveGroupCall
        {
            get { return m_RemoveGroupCall; }
            internal set { m_RemoveGroupCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_AddPartyCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsAddPartyCall
        {
            get { return m_AddPartyCall; }
            internal set { m_AddPartyCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_RemovePartyCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsRemovePartyCall
        {
            get { return m_RemovePartyCall; }
            internal set { m_RemovePartyCall = value; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        internal void RestoreAll()
        {
            m_UpdateName = false;
            m_UpdateCreatureTemplate = false;
            m_UpdateLoots = false;
            m_UpdateGoldLoots = false;
            m_DeathCall = false;
            m_RevivalCall = false;
            m_AddItemCall = false;
            m_RemoveItemCall = false;
            m_AddFriendCall = false;
            m_RemoveFriendCall = false;
            m_AddGroupCall = false;
            m_RemoveGroupCall = false;
            m_AddPartyCall = false;
            m_RemovePartyCall = false;
        }
        #endregion

        #region zh-CHS 内部的事件处理函数 | en Internal Event Handlers

        #region zh-CHS Name事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingName( string strName, BaseCreature creature )
        {
            EventHandler<UpdatingNameEventArgs> tempBeforeEventArgs = m_EventUpdatingName;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingNameEventArgs eventArgs = new UpdatingNameEventArgs( strName, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedName( string strName, BaseCreature creature )
        {
            EventHandler<UpdatedNameEventArgs> tempAfterEventArgs = m_EventUpdatedName;
            if ( tempAfterEventArgs != null )
            {
                UpdatedNameEventArgs eventArgs = new UpdatedNameEventArgs( strName, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CreatureTemplate事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingCreatureTemplate( BaseCreatureTemplate creatureTemplate, BaseCreature creature )
        {
            EventHandler<UpdatingCreatureTemplateEventArgs> tempBeforeEventArgs = m_EventUpdatingCreatureTemplate;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingCreatureTemplateEventArgs eventArgs = new UpdatingCreatureTemplateEventArgs( creatureTemplate, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedCreatureTemplate( BaseCreatureTemplate creatureTemplate, BaseCreature creature )
        {
            EventHandler<UpdatedCreatureTemplateEventArgs> tempAfterEventArgs = m_EventUpdatedCreatureTemplate;
            if ( tempAfterEventArgs != null )
            {
                UpdatedCreatureTemplateEventArgs eventArgs = new UpdatedCreatureTemplateEventArgs( creatureTemplate, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS Loots事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingLoots( OneTreasure[] loots, BaseCreature creature )
        {
            EventHandler<UpdatingLootsEventArgs> tempBeforeEventArgs = m_EventUpdatingLoots;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingLootsEventArgs eventArgs = new UpdatingLootsEventArgs( loots, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedLoots( OneTreasure[] loots, BaseCreature creature )
        {
            EventHandler<UpdatedLootsEventArgs> tempAfterEventArgs = m_EventUpdatedLoots;
            if ( tempAfterEventArgs != null )
            {
                UpdatedLootsEventArgs eventArgs = new UpdatedLootsEventArgs( loots, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS GoldLoots事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingGoldLoots( OneTreasure[] goldLoots, BaseCreature creature )
        {
            EventHandler<UpdatingGoldLootsEventArgs> tempBeforeEventArgs = m_EventUpdatingGoldLoots;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingGoldLootsEventArgs eventArgs = new UpdatingGoldLootsEventArgs( goldLoots, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedGoldLoots( OneTreasure[] goldLoots, BaseCreature creature )
        {
            EventHandler<UpdatedGoldLootsEventArgs> tempAfterEventArgs = m_EventUpdatedGoldLoots;
            if ( tempAfterEventArgs != null )
            {
                UpdatedGoldLootsEventArgs eventArgs = new UpdatedGoldLootsEventArgs( goldLoots, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS DeathCall事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnDieingCall( BaseCreature creatureKiller, BaseCreature creature )
        {
            EventHandler<DieingCallEventArgs> tempBeforeEventArgs = m_EventDieingCall;
            if ( tempBeforeEventArgs != null )
            {
                DieingCallEventArgs eventArgs = new DieingCallEventArgs( creatureKiller, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnDiedCall( BaseCreature creatureKiller, BaseCreature creature )
        {
            EventHandler<DiedCallEventArgs> tempAfterEventArgs = m_EventDiedCall;
            if ( tempAfterEventArgs != null )
            {
                DiedCallEventArgs eventArgs = new DiedCallEventArgs( creatureKiller, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS LiveCall事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnLivingCall( BaseCreature creatureRevival, BaseCreature creature )
        {
            EventHandler<LivingCallEventArgs> tempBeforeEventArgs = m_EventLivingCall;
            if ( tempBeforeEventArgs != null )
            {
                LivingCallEventArgs eventArgs = new LivingCallEventArgs( creatureRevival, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnLivedCall( BaseCreature creatureRevival, BaseCreature creature )
        {
            EventHandler<LivedCallEventArgs> tempAfterEventArgs = m_EventLivedCall;
            if ( tempAfterEventArgs != null )
            {
                LivedCallEventArgs eventArgs = new LivedCallEventArgs( creatureRevival, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS AddItem事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnAddingItem( BaseItem addItem, BaseCreature creature )
        {
            EventHandler<AddingItemCallEventArgs> tempBeforeEventArgs = m_EventAddingItem;
            if ( tempBeforeEventArgs != null )
            {
                AddingItemCallEventArgs eventArgs = new AddingItemCallEventArgs( addItem, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnAddedItem( BaseItem addItem, BaseCreature creature )
        {
            EventHandler<AddedItemCallEventArgs> tempAfterEventArgs = m_EventAddedItem;
            if ( tempAfterEventArgs != null )
            {
                AddedItemCallEventArgs eventArgs = new AddedItemCallEventArgs( addItem, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS RemoveItem事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnRemovingItem( BaseItem removeItem, BaseCreature creature )
        {
            EventHandler<RemovingItemCallEventArgs> tempBeforeEventArgs = m_EventRemovingItem;
            if ( tempBeforeEventArgs != null )
            {
                RemovingItemCallEventArgs eventArgs = new RemovingItemCallEventArgs( removeItem, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnRemovedItem( BaseItem removeItem, BaseCreature creature )
        {
            EventHandler<RemovedItemCallEventArgs> tempAfterEventArgs = m_EventRemovedItem;
            if ( tempAfterEventArgs != null )
            {
                RemovedItemCallEventArgs eventArgs = new RemovedItemCallEventArgs( removeItem, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS AddFriend事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnAddingFriend( BaseCreature creatureFriend, BaseCreature creature )
        {
            EventHandler<AddingFriendCallEventArgs> tempBeforeEventArgs = m_EventAddingFriend;
            if ( tempBeforeEventArgs != null )
            {
                AddingFriendCallEventArgs eventArgs = new AddingFriendCallEventArgs( creatureFriend, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnAddedFriend( BaseCreature creatureFriend, BaseCreature creature )
        {
            EventHandler<AddedFriendCallEventArgs> tempAfterEventArgs = m_EventAddedFriend;
            if ( tempAfterEventArgs != null )
            {
                AddedFriendCallEventArgs eventArgs = new AddedFriendCallEventArgs( creatureFriend, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS RemoveFriend事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnRemovingFriend( BaseCreature creatureFriend, BaseCreature creature )
        {
            EventHandler<RemovingFriendCallEventArgs> tempBeforeEventArgs = m_EventRemovingFriend;
            if ( tempBeforeEventArgs != null )
            {
                RemovingFriendCallEventArgs eventArgs = new RemovingFriendCallEventArgs( creatureFriend, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnRemovedFriend( BaseCreature creatureFriend, BaseCreature creature )
        {
            EventHandler<RemovedFriendCallEventArgs> tempAfterEventArgs = m_EventRemovedFriend;
            if ( tempAfterEventArgs != null )
            {
                RemovedFriendCallEventArgs eventArgs = new RemovedFriendCallEventArgs( creatureFriend, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS AddGroup事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnAddingGroup( BaseCreature creatureGroup, BaseCreature creature )
        {
            EventHandler<AddingGroupCallEventArgs> tempBeforeEventArgs = m_EventAddingGroup;
            if ( tempBeforeEventArgs != null )
            {
                AddingGroupCallEventArgs eventArgs = new AddingGroupCallEventArgs( creatureGroup, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnAddedGroup( BaseCreature creatureGroup, BaseCreature creature )
        {
            EventHandler<AddedGroupCallEventArgs> tempAfterEventArgs = m_EventAddedGroup;
            if ( tempAfterEventArgs != null )
            {
                AddedGroupCallEventArgs eventArgs = new AddedGroupCallEventArgs( creatureGroup, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS RemoveGroup事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnRemovingGroup( BaseCreature creatureGroup, BaseCreature creature )
        {
            EventHandler<RemovingGroupCallEventArgs> tempBeforeEventArgs = m_EventRemovingGroup;
            if ( tempBeforeEventArgs != null )
            {
                RemovingGroupCallEventArgs eventArgs = new RemovingGroupCallEventArgs( creatureGroup, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnRemovedGroup( BaseCreature creatureGroup, BaseCreature creature )
        {
            EventHandler<RemovedGroupCallEventArgs> tempAfterEventArgs = m_EventRemovedGroup;
            if ( tempAfterEventArgs != null )
            {
                RemovedGroupCallEventArgs eventArgs = new RemovedGroupCallEventArgs( creatureGroup, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS AddParty事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnAddingParty( BaseCreature creatureParty, BaseCreature creature )
        {
            EventHandler<AddingPartyCallEventArgs> tempBeforeEventArgs = m_EventAddingParty;
            if ( tempBeforeEventArgs != null )
            {
                AddingPartyCallEventArgs eventArgs = new AddingPartyCallEventArgs( creatureParty, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnAddedParty( BaseCreature creatureParty, BaseCreature creature )
        {
            EventHandler<AddedPartyCallEventArgs> tempAfterEventArgs = m_EventAddedParty;
            if ( tempAfterEventArgs != null )
            {
                AddedPartyCallEventArgs eventArgs = new AddedPartyCallEventArgs( creatureParty, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS RemoveParty事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnRemovingParty( BaseCreature creatureParty, BaseCreature creature )
        {
            EventHandler<RemovingPartyCallEventArgs> tempBeforeEventArgs = m_EventRemovingParty;
            if ( tempBeforeEventArgs != null )
            {
                RemovingPartyCallEventArgs eventArgs = new RemovingPartyCallEventArgs( creatureParty, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnRemovedParty( BaseCreature creatureParty, BaseCreature creature )
        {
            EventHandler<RemovedPartyCallEventArgs> tempAfterEventArgs = m_EventRemovedParty;
            if ( tempAfterEventArgs != null )
            {
                RemovedPartyCallEventArgs eventArgs = new RemovedPartyCallEventArgs( creatureParty, creature );
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
        private EventHandler<UpdatedNameEventArgs> m_EventUpdatedName;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedName = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedNameEventArgs> UpdatedName
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

        #region zh-CHS CreatureTemplate事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingCreatureTemplateEventArgs> m_EventUpdatingCreatureTemplate;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingCreatureTemplate = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingCreatureTemplateEventArgs> UpdatingCreatureTemplate
        {
            add
            {
                m_LockEventUpdatingCreatureTemplate.Enter();
                {
                    m_EventUpdatingCreatureTemplate += value;
                }
                m_LockEventUpdatingCreatureTemplate.Exit();
            }
            remove
            {
                m_LockEventUpdatingCreatureTemplate.Enter();
                {
                    m_EventUpdatingCreatureTemplate -= value;
                }
                m_LockEventUpdatingCreatureTemplate.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedCreatureTemplateEventArgs> m_EventUpdatedCreatureTemplate;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedCreatureTemplate = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedCreatureTemplateEventArgs> UpdatedCreatureTemplate
        {
            add
            {
                m_LockEventUpdatedCreatureTemplate.Enter();
                {
                    m_EventUpdatedCreatureTemplate += value;
                }
                m_LockEventUpdatedCreatureTemplate.Exit();
            }
            remove
            {
                m_LockEventUpdatedCreatureTemplate.Enter();
                {
                    m_EventUpdatedCreatureTemplate -= value;
                }
                m_LockEventUpdatedCreatureTemplate.Exit();
            }
        }
        #endregion

        #region zh-CHS Loots事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingLootsEventArgs> m_EventUpdatingLoots;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingLoots = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingLootsEventArgs> UpdatingLoots
        {
            add
            {
                m_LockEventUpdatingLoots.Enter();
                {
                    m_EventUpdatingLoots += value;
                }
                m_LockEventUpdatingLoots.Exit();
            }
            remove
            {
                m_LockEventUpdatingLoots.Enter();
                {
                    m_EventUpdatingLoots -= value;
                }
                m_LockEventUpdatingLoots.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedLootsEventArgs> m_EventUpdatedLoots;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedLoots = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedLootsEventArgs> UpdatedLoots
        {
            add
            {
                m_LockEventUpdatedLoots.Enter();
                {
                    m_EventUpdatedLoots += value;
                }
                m_LockEventUpdatedLoots.Exit();
            }
            remove
            {
                m_LockEventUpdatedLoots.Enter();
                {
                    m_EventUpdatedLoots -= value;
                }
                m_LockEventUpdatedLoots.Exit();
            }
        }
        #endregion

        #region zh-CHS GoldLoots事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingGoldLootsEventArgs> m_EventUpdatingGoldLoots;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingGoldLoots = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingGoldLootsEventArgs> UpdatingGoldLoots
        {
            add
            {
                m_LockEventUpdatingGoldLoots.Enter();
                {
                    m_EventUpdatingGoldLoots += value;
                }
                m_LockEventUpdatingGoldLoots.Exit();
            }
            remove
            {
                m_LockEventUpdatingGoldLoots.Enter();
                {
                    m_EventUpdatingGoldLoots -= value;
                }
                m_LockEventUpdatingGoldLoots.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedGoldLootsEventArgs> m_EventUpdatedGoldLoots;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedGoldLoots = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedGoldLootsEventArgs> UpdatedGoldLoots
        {
            add
            {
                m_LockEventUpdatedGoldLoots.Enter();
                {
                    m_EventUpdatedGoldLoots += value;
                }
                m_LockEventUpdatedGoldLoots.Exit();
            }
            remove
            {
                m_LockEventUpdatedGoldLoots.Enter();
                {
                    m_EventUpdatedGoldLoots -= value;
                }
                m_LockEventUpdatedGoldLoots.Exit();
            }
        }
        #endregion

        #region zh-CHS DeathCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<DieingCallEventArgs> m_EventDieingCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventDieingCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<DieingCallEventArgs> DieingCall
        {
            add
            {
                m_LockEventDieingCall.Enter();
                {
                    m_EventDieingCall += value;
                }
                m_LockEventDieingCall.Exit();
            }
            remove
            {
                m_LockEventDieingCall.Enter();
                {
                    m_EventDieingCall -= value;
                }
                m_LockEventDieingCall.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<DiedCallEventArgs> m_EventDiedCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventDiedCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<DiedCallEventArgs> DiedCall
        {
            add
            {
                m_LockEventDiedCall.Enter();
                {
                    m_EventDiedCall += value;
                }
                m_LockEventDiedCall.Exit();
            }
            remove
            {
                m_LockEventDiedCall.Enter();
                {
                    m_EventDiedCall -= value;
                }
                m_LockEventDiedCall.Exit();
            }
        }
        #endregion

        #region zh-CHS LiveCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<LivingCallEventArgs> m_EventLivingCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventLivingCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<LivingCallEventArgs> LivingCall
        {
            add
            {
                m_LockEventLivingCall.Enter();
                {
                    m_EventLivingCall += value;
                }
                m_LockEventLivingCall.Exit();
            }
            remove
            {
                m_LockEventLivingCall.Enter();
                {
                    m_EventLivingCall -= value;
                }
                m_LockEventLivingCall.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<LivedCallEventArgs> m_EventLivedCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventLivedCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<LivedCallEventArgs> LivedCall
        {
            add
            {
                m_LockEventLivedCall.Enter();
                {
                    m_EventLivedCall += value;
                }
                m_LockEventLivedCall.Exit();
            }
            remove
            {
                m_LockEventLivedCall.Enter();
                {
                    m_EventLivedCall -= value;
                }
                m_LockEventLivedCall.Exit();
            }
        }
        #endregion

        #region zh-CHS AddItem事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddingItemCallEventArgs> m_EventAddingItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddingItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddingItemCallEventArgs> AddingItem
        {
            add
            {
                m_LockEventAddingItem.Enter();
                {
                    m_EventAddingItem += value;
                }
                m_LockEventAddingItem.Exit();
            }
            remove
            {
                m_LockEventAddingItem.Enter();
                {
                    m_EventAddingItem -= value;
                }
                m_LockEventAddingItem.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddedItemCallEventArgs> m_EventAddedItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddedItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddedItemCallEventArgs> AddedItem
        {
            add
            {
                m_LockEventAddedItem.Enter();
                {
                    m_EventAddedItem += value;
                }
                m_LockEventAddedItem.Exit();
            }
            remove
            {
                m_LockEventAddedItem.Enter();
                {
                    m_EventAddedItem -= value;
                }
                m_LockEventAddedItem.Exit();
            }
        }
        #endregion

        #region zh-CHS RemoveItem事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovingItemCallEventArgs> m_EventRemovingItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovingItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovingItemCallEventArgs> RemovingItem
        {
            add
            {
                m_LockEventRemovingItem.Enter();
                {
                    m_EventRemovingItem += value;
                }
                m_LockEventRemovingItem.Exit();
            }
            remove
            {
                m_LockEventRemovingItem.Enter();
                {
                    m_EventRemovingItem -= value;
                }
                m_LockEventRemovingItem.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovedItemCallEventArgs> m_EventRemovedItem;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovedItem = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovedItemCallEventArgs> RemovedItem
        {
            add
            {
                m_LockEventRemovedItem.Enter();
                {
                    m_EventRemovedItem += value;
                }
                m_LockEventRemovedItem.Exit();
            }
            remove
            {
                m_LockEventRemovedItem.Enter();
                {
                    m_EventRemovedItem -= value;
                }
                m_LockEventRemovedItem.Exit();
            }
        }
        #endregion

        #region zh-CHS AddFriend事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddingFriendCallEventArgs> m_EventAddingFriend;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddingFriend = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddingFriendCallEventArgs> AddingFriend
        {
            add
            {
                m_LockEventAddingFriend.Enter();
                {
                    m_EventAddingFriend += value;
                }
                m_LockEventAddingFriend.Exit();
            }
            remove
            {
                m_LockEventAddingFriend.Enter();
                {
                    m_EventAddingFriend -= value;
                }
                m_LockEventAddingFriend.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddedFriendCallEventArgs> m_EventAddedFriend;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddedFriend = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddedFriendCallEventArgs> AddedFriend
        {
            add
            {
                m_LockEventAddedFriend.Enter();
                {
                    m_EventAddedFriend += value;
                }
                m_LockEventAddedFriend.Exit();
            }
            remove
            {
                m_LockEventAddedFriend.Enter();
                {
                    m_EventAddedFriend -= value;
                }
                m_LockEventAddedFriend.Exit();
            }
        }
        #endregion

        #region zh-CHS RemoveFriend事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovingFriendCallEventArgs> m_EventRemovingFriend;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovingFriend = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovingFriendCallEventArgs> RemovingFriend
        {
            add
            {
                m_LockEventRemovingFriend.Enter();
                {
                    m_EventRemovingFriend += value;
                }
                m_LockEventRemovingFriend.Exit();
            }
            remove
            {
                m_LockEventRemovingFriend.Enter();
                {
                    m_EventRemovingFriend -= value;
                }
                m_LockEventRemovingFriend.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovedFriendCallEventArgs> m_EventRemovedFriend;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovedFriend = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovedFriendCallEventArgs> RemovedFriend
        {
            add
            {
                m_LockEventRemovedFriend.Enter();
                {
                    m_EventRemovedFriend += value;
                }
                m_LockEventRemovedFriend.Exit();
            }
            remove
            {
                m_LockEventRemovedFriend.Enter();
                {
                    m_EventRemovedFriend -= value;
                }
                m_LockEventRemovedFriend.Exit();
            }
        }
        #endregion

        #region zh-CHS AddGroup事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddingGroupCallEventArgs> m_EventAddingGroup;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddingGroup = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddingGroupCallEventArgs> AddingGroup
        {
            add
            {
                m_LockEventAddingGroup.Enter();
                {
                    m_EventAddingGroup += value;
                }
                m_LockEventAddingGroup.Exit();
            }
            remove
            {
                m_LockEventAddingGroup.Enter();
                {
                    m_EventAddingGroup -= value;
                }
                m_LockEventAddingGroup.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddedGroupCallEventArgs> m_EventAddedGroup;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddedGroup = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddedGroupCallEventArgs> AddedGroup
        {
            add
            {
                m_LockEventAddedGroup.Enter();
                {
                    m_EventAddedGroup += value;
                }
                m_LockEventAddedGroup.Exit();
            }
            remove
            {
                m_LockEventAddedGroup.Enter();
                {
                    m_EventAddedGroup -= value;
                }
                m_LockEventAddedGroup.Exit();
            }
        }
        #endregion

        #region zh-CHS RemoveGroup事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovingGroupCallEventArgs> m_EventRemovingGroup;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovingGroup = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovingGroupCallEventArgs> RemovingGroup
        {
            add
            {
                m_LockEventRemovingGroup.Enter();
                {
                    m_EventRemovingGroup += value;
                }
                m_LockEventRemovingGroup.Exit();
            }
            remove
            {
                m_LockEventRemovingGroup.Enter();
                {
                    m_EventRemovingGroup -= value;
                }
                m_LockEventRemovingGroup.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovedGroupCallEventArgs> m_EventRemovedGroup;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovedGroup = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovedGroupCallEventArgs> RemovedGroup
        {
            add
            {
                m_LockEventRemovedGroup.Enter();
                {
                    m_EventRemovedGroup += value;
                }
                m_LockEventRemovedGroup.Exit();
            }
            remove
            {
                m_LockEventRemovedGroup.Enter();
                {
                    m_EventRemovedGroup -= value;
                }
                m_LockEventRemovedGroup.Exit();
            }
        }
        #endregion

        #region zh-CHS AddParty事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddingPartyCallEventArgs> m_EventAddingParty;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddingParty = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddingPartyCallEventArgs> AddingParty
        {
            add
            {
                m_LockEventAddingParty.Enter();
                {
                    m_EventAddingParty += value;
                }
                m_LockEventAddingParty.Exit();
            }
            remove
            {
                m_LockEventAddingParty.Enter();
                {
                    m_EventAddingParty -= value;
                }
                m_LockEventAddingParty.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AddedPartyCallEventArgs> m_EventAddedParty;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventAddedParty = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AddedPartyCallEventArgs> AddedParty
        {
            add
            {
                m_LockEventAddedParty.Enter();
                {
                    m_EventAddedParty += value;
                }
                m_LockEventAddedParty.Exit();
            }
            remove
            {
                m_LockEventAddedParty.Enter();
                {
                    m_EventAddedParty -= value;
                }
                m_LockEventAddedParty.Exit();
            }
        }
        #endregion

        #region zh-CHS RemoveParty事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovingPartyCallEventArgs> m_EventRemovingParty;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovingParty = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovingPartyCallEventArgs> RemovingParty
        {
            add
            {
                m_LockEventRemovingParty.Enter();
                {
                    m_EventRemovingParty += value;
                }
                m_LockEventRemovingParty.Exit();
            }
            remove
            {
                m_LockEventRemovingParty.Enter();
                {
                    m_EventRemovingParty -= value;
                }
                m_LockEventRemovingParty.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<RemovedPartyCallEventArgs> m_EventRemovedParty;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventRemovedParty = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<RemovedPartyCallEventArgs> RemovedParty
        {
            add
            {
                m_LockEventRemovedParty.Enter();
                {
                    m_EventRemovedParty += value;
                }
                m_LockEventRemovedParty.Exit();
            }
            remove
            {
                m_LockEventRemovedParty.Enter();
                {
                    m_EventRemovedParty -= value;
                }
                m_LockEventRemovedParty.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion

