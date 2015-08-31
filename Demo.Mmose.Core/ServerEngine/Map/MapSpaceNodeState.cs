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
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Character;
#endregion

namespace Demo.Mmose.Core.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class MapSpaceNodeState
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 单体
        /// </summary>
        private static MapSpaceNodeState s_MapSpaceNodeState = new MapSpaceNodeState();
        #endregion
        /// <summary>
        /// 单体
        /// </summary>
        public static MapSpaceNodeState SingletonInstance
        {
            get { return s_MapSpaceNodeState; }
        }
        #endregion

        #region zh-CHS 内部的事件处理函数 | en Internal Event Handlers

        #region zh-CHS WorldEntityEnterMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteringMapSpaceNode( WorldEntity worldEntity, MapSpaceNode mapSpaceNode )
        {
            EventHandler<WorldEntityEnterSpaceNodeEventArgs> tempEventArgs = m_EventWorldEntityEnteringSpaceNode;
            if ( tempEventArgs != null )
            {
                WorldEntityEnterSpaceNodeEventArgs eventArgs = new WorldEntityEnterSpaceNodeEventArgs( worldEntity, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteredMapSpaceNode( WorldEntity worldEntity, MapSpaceNode mapSpaceNode )
        {
            EventHandler<WorldEntityEnterSpaceNodeEventArgs> tempEventArgs = m_EventWorldEntityEnteredSpaceNode;
            if ( tempEventArgs != null )
            {
                WorldEntityEnterSpaceNodeEventArgs eventArgs = new WorldEntityEnterSpaceNodeEventArgs( worldEntity, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS WorldEntityLeaveMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavingMapSpaceNode( WorldEntity worldEntity, MapSpaceNode mapSpaceNode )
        {
            EventHandler<WorldEntityLeaveSpaceNodeEventArgs> tempEventArgs = m_EventWorldEntityLeavingSpaceNode;
            if ( tempEventArgs != null )
            {
                WorldEntityLeaveSpaceNodeEventArgs eventArgs = new WorldEntityLeaveSpaceNodeEventArgs( worldEntity, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavedMapSpaceNode( WorldEntity worldEntity, MapSpaceNode mapSpaceNode )
        {
            EventHandler<WorldEntityLeaveSpaceNodeEventArgs> tempEventArgs = m_EventWorldEntityLeavedSpaceNode;
            if ( tempEventArgs != null )
            {
                WorldEntityLeaveSpaceNodeEventArgs eventArgs = new WorldEntityLeaveSpaceNodeEventArgs( worldEntity, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS ItemEnterSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteringMapSpaceNode( BaseItem item, MapSpaceNode mapSpaceNode )
        {
            EventHandler<ItemEnterSpaceNodeEventArgs> tempEventArgs = m_EventItemEnteringSpaceNode;
            if ( tempEventArgs != null )
            {
                ItemEnterSpaceNodeEventArgs eventArgs = new ItemEnterSpaceNodeEventArgs( item, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteredMapSpaceNode( BaseItem item, MapSpaceNode mapSpaceNode )
        {
            EventHandler<ItemEnterSpaceNodeEventArgs> tempEventArgs = m_EventItemEnteredSpaceNode;
            if ( tempEventArgs != null )
            {
                ItemEnterSpaceNodeEventArgs eventArgs = new ItemEnterSpaceNodeEventArgs( item, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS ItemLeaveSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavingMapSpaceNode( BaseItem item, MapSpaceNode mapSpaceNode )
        {
            EventHandler<ItemLeaveSpaceNodeEventArgs> tempEventArgs = m_EventItemLeavingSpaceNode;
            if ( tempEventArgs != null )
            {
                ItemLeaveSpaceNodeEventArgs eventArgs = new ItemLeaveSpaceNodeEventArgs( item, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavedMapSpaceNode( BaseItem item, MapSpaceNode mapSpaceNode )
        {
            EventHandler<ItemLeaveSpaceNodeEventArgs> tempEventArgs = m_EventItemLeavedSpaceNode;
            if ( tempEventArgs != null )
            {
                ItemLeaveSpaceNodeEventArgs eventArgs = new ItemLeaveSpaceNodeEventArgs( item, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CreatureEnterSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteringMapSpaceNode( BaseCreature creature, MapSpaceNode mapSpaceNode )
        {
            EventHandler<CreatureEnterSpaceNodeEventArgs> tempEventArgs = m_EventCreatureEnteringSpaceNode;
            if ( tempEventArgs != null )
            {
                CreatureEnterSpaceNodeEventArgs eventArgs = new CreatureEnterSpaceNodeEventArgs( creature, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteredMapSpaceNode( BaseCreature creature, MapSpaceNode mapSpaceNode )
        {
            EventHandler<CreatureEnterSpaceNodeEventArgs> tempEventArgs = m_EventCreatureEnteredSpaceNode;
            if ( tempEventArgs != null )
            {
                CreatureEnterSpaceNodeEventArgs eventArgs = new CreatureEnterSpaceNodeEventArgs( creature, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CreatureLeaveSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavingMapSpaceNode( BaseCreature creature, MapSpaceNode mapSpaceNode )
        {
            EventHandler<CreatureLeaveSpaceNodeEventArgs> tempEventArgs = m_EventCreatureLeavingSpaceNode;
            if ( tempEventArgs != null )
            {
                CreatureLeaveSpaceNodeEventArgs eventArgs = new CreatureLeaveSpaceNodeEventArgs( creature, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavedMapSpaceNode( BaseCreature creature, MapSpaceNode mapSpaceNode )
        {
            EventHandler<CreatureLeaveSpaceNodeEventArgs> tempEventArgs = m_EventCreatureLeavedSpaceNode;
            if ( tempEventArgs != null )
            {
                CreatureLeaveSpaceNodeEventArgs eventArgs = new CreatureLeaveSpaceNodeEventArgs( creature, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CharacterEnterSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteringMapSpaceNode( BaseCharacter character, MapSpaceNode mapSpaceNode )
        {
            EventHandler<CharacterEnterSpaceNodeEventArgs> tempEventArgs = m_EventCharacterEnteringSpaceNode;
            if ( tempEventArgs != null )
            {
                CharacterEnterSpaceNodeEventArgs eventArgs = new CharacterEnterSpaceNodeEventArgs( character, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteredMapSpaceNode( BaseCharacter character, MapSpaceNode mapSpaceNode )
        {
            EventHandler<CharacterEnterSpaceNodeEventArgs> tempEventArgs = m_EventCharacterEnteredSpaceNode;
            if ( tempEventArgs != null )
            {
                CharacterEnterSpaceNodeEventArgs eventArgs = new CharacterEnterSpaceNodeEventArgs( character, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CharacterLeaveSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavingMapSpaceNode( BaseCharacter character, MapSpaceNode mapSpaceNode )
        {
            EventHandler<CharacterLeaveSpaceNodeEventArgs> tempEventArgs = m_EventCharacterLeavingSpaceNode;
            if ( tempEventArgs != null )
            {
                CharacterLeaveSpaceNodeEventArgs eventArgs = new CharacterLeaveSpaceNodeEventArgs( character, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavedMapSpaceNode( BaseCharacter character, MapSpaceNode mapSpaceNode )
        {
            EventHandler<CharacterLeaveSpaceNodeEventArgs> tempEventArgs = m_EventCharacterLeavedSpaceNode;
            if ( tempEventArgs != null )
            {
                CharacterLeaveSpaceNodeEventArgs eventArgs = new CharacterLeaveSpaceNodeEventArgs( character, mapSpaceNode );
                tempEventArgs( this, eventArgs );
            }
        }
        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS WorldEntityEnterSpaceNode事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityEnterSpaceNodeEventArgs> m_EventWorldEntityEnteringSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityEnteringSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityEnterSpaceNodeEventArgs> WorldEntityEnteringSpaceNode
        {
            add
            {
                m_LockEventWorldEntityEnteringSpaceNode.Enter();
                {
                    m_EventWorldEntityEnteringSpaceNode += value;
                }
                m_LockEventWorldEntityEnteringSpaceNode.Exit();
            }
            remove
            {
                m_LockEventWorldEntityEnteringSpaceNode.Enter();
                {
                    m_EventWorldEntityEnteringSpaceNode -= value;
                }
                m_LockEventWorldEntityEnteringSpaceNode.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityEnterSpaceNodeEventArgs> m_EventWorldEntityEnteredSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityEnteredSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityEnterSpaceNodeEventArgs> WorldEntityEnteredSpaceNode
        {
            add
            {
                m_LockEventWorldEntityEnteredSpaceNode.Enter();
                {
                    m_EventWorldEntityEnteredSpaceNode += value;
                }
                m_LockEventWorldEntityEnteredSpaceNode.Exit();
            }
            remove
            {
                m_LockEventWorldEntityEnteredSpaceNode.Enter();
                {
                    m_EventWorldEntityEnteredSpaceNode -= value;
                }
                m_LockEventWorldEntityEnteredSpaceNode.Exit();
            }
        }
        #endregion

        #region zh-CHS WorldEntityLeaveSpaceNode事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityLeaveSpaceNodeEventArgs> m_EventWorldEntityLeavingSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityLeavingSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityLeaveSpaceNodeEventArgs> WorldEntityLeavingSpaceNode
        {
            add
            {
                m_LockEventWorldEntityLeavingSpaceNode.Enter();
                {
                    m_EventWorldEntityLeavingSpaceNode += value;
                }
                m_LockEventWorldEntityLeavingSpaceNode.Exit();
            }
            remove
            {
                m_LockEventWorldEntityLeavingSpaceNode.Enter();
                {
                    m_EventWorldEntityLeavingSpaceNode -= value;
                }
                m_LockEventWorldEntityLeavingSpaceNode.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityLeaveSpaceNodeEventArgs> m_EventWorldEntityLeavedSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityLeavedSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityLeaveSpaceNodeEventArgs> WorldEntityLeavedSpaceNode
        {
            add
            {
                m_LockEventWorldEntityLeavedSpaceNode.Enter();
                {
                    m_EventWorldEntityLeavedSpaceNode += value;
                }
                m_LockEventWorldEntityLeavedSpaceNode.Exit();
            }
            remove
            {
                m_LockEventWorldEntityLeavedSpaceNode.Enter();
                {
                    m_EventWorldEntityLeavedSpaceNode -= value;
                }
                m_LockEventWorldEntityLeavedSpaceNode.Exit();
            }
        }
        #endregion

        #region zh-CHS ItemEnterSpaceNode事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemEnterSpaceNodeEventArgs> m_EventItemEnteringSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemEnteringSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemEnterSpaceNodeEventArgs> ItemEnteringSpaceNode
        {
            add
            {
                m_LockEventItemEnteringSpaceNode.Enter();
                {
                    m_EventItemEnteringSpaceNode += value;
                }
                m_LockEventItemEnteringSpaceNode.Exit();
            }
            remove
            {
                m_LockEventItemEnteringSpaceNode.Enter();
                {
                    m_EventItemEnteringSpaceNode -= value;
                }
                m_LockEventItemEnteringSpaceNode.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemEnterSpaceNodeEventArgs> m_EventItemEnteredSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemEnteredSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemEnterSpaceNodeEventArgs> ItemEnteredSpaceNode
        {
            add
            {
                m_LockEventItemEnteredSpaceNode.Enter();
                {
                    m_EventItemEnteredSpaceNode += value;
                }
                m_LockEventItemEnteredSpaceNode.Exit();
            }
            remove
            {
                m_LockEventItemEnteredSpaceNode.Enter();
                {
                    m_EventItemEnteredSpaceNode -= value;
                }
                m_LockEventItemEnteredSpaceNode.Exit();
            }
        }
        #endregion

        #region zh-CHS ItemLeaveSpaceNode事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemLeaveSpaceNodeEventArgs> m_EventItemLeavingSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemLeavingSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemLeaveSpaceNodeEventArgs> ItemLeavingSpaceNode
        {
            add
            {
                m_LockEventItemLeavingSpaceNode.Enter();
                {
                    m_EventItemLeavingSpaceNode += value;
                }
                m_LockEventItemLeavingSpaceNode.Exit();
            }
            remove
            {
                m_LockEventItemLeavingSpaceNode.Enter();
                {
                    m_EventItemLeavingSpaceNode -= value;
                }
                m_LockEventItemLeavingSpaceNode.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemLeaveSpaceNodeEventArgs> m_EventItemLeavedSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemLeavedSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemLeaveSpaceNodeEventArgs> ItemLeavedSpaceNode
        {
            add
            {
                m_LockEventItemLeavedSpaceNode.Enter();
                {
                    m_EventItemLeavedSpaceNode += value;
                }
                m_LockEventItemLeavedSpaceNode.Exit();
            }
            remove
            {
                m_LockEventItemLeavedSpaceNode.Enter();
                {
                    m_EventItemLeavedSpaceNode -= value;
                }
                m_LockEventItemLeavedSpaceNode.Exit();
            }
        }
        #endregion

        #region zh-CHS CreatureEnterSpaceNode事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreatureEnterSpaceNodeEventArgs> m_EventCreatureEnteringSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureEnteringSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreatureEnterSpaceNodeEventArgs> CreatureEnteringSpaceNode
        {
            add
            {
                m_LockEventCreatureEnteringSpaceNode.Enter();
                {
                    m_EventCreatureEnteringSpaceNode += value;
                }
                m_LockEventCreatureEnteringSpaceNode.Exit();
            }
            remove
            {
                m_LockEventCreatureEnteringSpaceNode.Enter();
                {
                    m_EventCreatureEnteringSpaceNode -= value;
                }
                m_LockEventCreatureEnteringSpaceNode.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreatureEnterSpaceNodeEventArgs> m_EventCreatureEnteredSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureEnteredSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreatureEnterSpaceNodeEventArgs> CreatureEnteredSpaceNode
        {
            add
            {
                m_LockEventCreatureEnteredSpaceNode.Enter();
                {
                    m_EventCreatureEnteredSpaceNode += value;
                }
                m_LockEventCreatureEnteredSpaceNode.Exit();
            }
            remove
            {
                m_LockEventCreatureEnteredSpaceNode.Enter();
                {
                    m_EventCreatureEnteredSpaceNode -= value;
                }
                m_LockEventCreatureEnteredSpaceNode.Exit();
            }
        }
        #endregion

        #region zh-CHS CreatureLeaveSpaceNode事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreatureLeaveSpaceNodeEventArgs> m_EventCreatureLeavingSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureLeavingSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreatureLeaveSpaceNodeEventArgs> CreatureLeavingSpaceNode
        {
            add
            {
                m_LockEventCreatureLeavingSpaceNode.Enter();
                {
                    m_EventCreatureLeavingSpaceNode += value;
                }
                m_LockEventCreatureLeavingSpaceNode.Exit();
            }
            remove
            {
                m_LockEventCreatureLeavingSpaceNode.Enter();
                {
                    m_EventCreatureLeavingSpaceNode -= value;
                }
                m_LockEventCreatureLeavingSpaceNode.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreatureLeaveSpaceNodeEventArgs> m_EventCreatureLeavedSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureLeavedSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreatureLeaveSpaceNodeEventArgs> CreatureLeavedSpaceNode
        {
            add
            {
                m_LockEventCreatureLeavedSpaceNode.Enter();
                {
                    m_EventCreatureLeavedSpaceNode += value;
                }
                m_LockEventCreatureLeavedSpaceNode.Exit();
            }
            remove
            {
                m_LockEventCreatureLeavedSpaceNode.Enter();
                {
                    m_EventCreatureLeavedSpaceNode -= value;
                }
                m_LockEventCreatureLeavedSpaceNode.Exit();
            }
        }
        #endregion

        #region zh-CHS CharacterEnterSpaceNode事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterEnterSpaceNodeEventArgs> m_EventCharacterEnteringSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterEnteringSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterEnterSpaceNodeEventArgs> CharacterEnteringSpaceNode
        {
            add
            {
                m_LockEventCharacterEnteringSpaceNode.Enter();
                {
                    m_EventCharacterEnteringSpaceNode += value;
                }
                m_LockEventCharacterEnteringSpaceNode.Exit();
            }
            remove
            {
                m_LockEventCharacterEnteringSpaceNode.Enter();
                {
                    m_EventCharacterEnteringSpaceNode -= value;
                }
                m_LockEventCharacterEnteringSpaceNode.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterEnterSpaceNodeEventArgs> m_EventCharacterEnteredSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterEnteredSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterEnterSpaceNodeEventArgs> CharacterEnteredSpaceNode
        {
            add
            {
                m_LockEventCharacterEnteredSpaceNode.Enter();
                {
                    m_EventCharacterEnteredSpaceNode += value;
                }
                m_LockEventCharacterEnteredSpaceNode.Exit();
            }
            remove
            {
                m_LockEventCharacterEnteredSpaceNode.Enter();
                {
                    m_EventCharacterEnteredSpaceNode -= value;
                }
                m_LockEventCharacterEnteredSpaceNode.Exit();
            }
        }
        #endregion

        #region zh-CHS CharacterLeaveSpaceNode事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterLeaveSpaceNodeEventArgs> m_EventCharacterLeavingSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterLeavingSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterLeaveSpaceNodeEventArgs> CharacterLeavingSpaceNode
        {
            add
            {
                m_LockEventCharacterLeavingSpaceNode.Enter();
                {
                    m_EventCharacterLeavingSpaceNode += value;
                }
                m_LockEventCharacterLeavingSpaceNode.Exit();
            }
            remove
            {
                m_LockEventCharacterLeavingSpaceNode.Enter();
                {
                    m_EventCharacterLeavingSpaceNode -= value;
                }
                m_LockEventCharacterLeavingSpaceNode.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterLeaveSpaceNodeEventArgs> m_EventCharacterLeavedSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterLeavedSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterLeaveSpaceNodeEventArgs> CharacterLeavedSpaceNode
        {
            add
            {
                m_LockEventCharacterLeavedSpaceNode.Enter();
                {
                    m_EventCharacterLeavedSpaceNode += value;
                }
                m_LockEventCharacterLeavedSpaceNode.Exit();
            }
            remove
            {
                m_LockEventCharacterLeavedSpaceNode.Enter();
                {
                    m_EventCharacterLeavedSpaceNode -= value;
                }
                m_LockEventCharacterLeavedSpaceNode.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion