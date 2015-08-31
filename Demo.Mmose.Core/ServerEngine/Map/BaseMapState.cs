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
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseMapState
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 单体
        /// </summary>
        private static BaseMapState s_BaseMapState = new BaseMapState();
        #endregion
        /// <summary>
        /// 单体
        /// </summary>
        public static BaseMapState SingletonInstance
        {
            get { return s_BaseMapState; }
        }
        #endregion

        #region zh-CHS 内部的事件处理函数 | en Internal Event Handlers

        #region zh-CHS WorldEntityEnterMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnEnteringMap( WorldEntity worldEntity, BaseMap map )
        {
            EventHandler<WorldEntityEnteringMapEventArgs> tempBeforeEventArgs = m_EventWorldEntityEnteringMap;
            if ( tempBeforeEventArgs != null )
            {
                WorldEntityEnteringMapEventArgs eventArgs = new WorldEntityEnteringMapEventArgs( worldEntity, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteredMap( WorldEntity worldEntity, BaseMap map )
        {
            EventHandler<WorldEntityEnteredMapEventArgs> tempAfterEventArgs = m_EventWorldEntityEnteredMap;
            if ( tempAfterEventArgs != null )
            {
                WorldEntityEnteredMapEventArgs eventArgs = new WorldEntityEnteredMapEventArgs( worldEntity, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS ItemEnterMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnEnteringMap( BaseItem item, BaseMap map )
        {
            EventHandler<ItemEnteringMapEventArgs> tempBeforeEventArgs = m_EventItemEnteringMap;
            if ( tempBeforeEventArgs != null )
            {
                ItemEnteringMapEventArgs eventArgs = new ItemEnteringMapEventArgs( item, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteredMap( BaseItem item, BaseMap map )
        {
            EventHandler<ItemEnteredMapEventArgs> tempAfterEventArgs = m_EventItemEnteredMap;
            if ( tempAfterEventArgs != null )
            {
                ItemEnteredMapEventArgs eventArgs = new ItemEnteredMapEventArgs( item, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CreatureEnterMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnEnteringMap( BaseCreature creature, BaseMap map )
        {
            EventHandler<CreatureEnteringMapEventArgs> tempBeforeEventArgs = m_EventCreatureEnteringMap;
            if ( tempBeforeEventArgs != null )
            {
                CreatureEnteringMapEventArgs eventArgs = new CreatureEnteringMapEventArgs( creature, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteredMap( BaseCreature creature, BaseMap map )
        {
            EventHandler<CreatureEnteredMapEventArgs> tempAfterEventArgs = m_EventCreatureEnteredMap;
            if ( tempAfterEventArgs != null )
            {
                CreatureEnteredMapEventArgs eventArgs = new CreatureEnteredMapEventArgs( creature, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CharacterEnterMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnEnteringMap( BaseCharacter character, BaseMap map )
        {
            EventHandler<CharacterEnteringMapEventArgs> tempBeforeEventArgs = m_EventCharacterEnteringMap;
            if ( tempBeforeEventArgs != null )
            {
                CharacterEnteringMapEventArgs eventArgs = new CharacterEnteringMapEventArgs( character, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnEnteredMap( BaseCharacter character, BaseMap map )
        {
            EventHandler<CharacterEnteredMapEventArgs> tempAfterEventArgs = m_EventCharacterEnteredMap;
            if ( tempAfterEventArgs != null )
            {
                CharacterEnteredMapEventArgs eventArgs = new CharacterEnteredMapEventArgs( character, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS EntityLeaveMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnLeavingMap( WorldEntity worldEntity, BaseMap map )
        {
            EventHandler<WorldEntityLeavingMapEventArgs> tempBeforeEventArgs = m_EventWorldEntityLeavingMap;
            if ( tempBeforeEventArgs != null )
            {
                WorldEntityLeavingMapEventArgs eventArgs = new WorldEntityLeavingMapEventArgs( worldEntity, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavedMap( WorldEntity worldEntity, BaseMap map )
        {
            EventHandler<WorldEntityLeavedMapEventArgs> tempAfterEventArgs = m_EventWorldEntityLeavedMap;
            if ( tempAfterEventArgs != null )
            {
                WorldEntityLeavedMapEventArgs eventArgs = new WorldEntityLeavedMapEventArgs( worldEntity, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS ItemLeaveMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnLeavingMap( BaseItem item, BaseMap map )
        {
            EventHandler<ItemLeavingMapEventArgs> tempBeforeEventArgs = m_EventItemLeavingMap;
            if ( tempBeforeEventArgs != null )
            {
                ItemLeavingMapEventArgs eventArgs = new ItemLeavingMapEventArgs( item, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavedMap( BaseItem item, BaseMap map )
        {
            EventHandler<ItemLeavedMapEventArgs> tempAfterEventArgs = m_EventItemLeavedMap;
            if ( tempAfterEventArgs != null )
            {
                ItemLeavedMapEventArgs eventArgs = new ItemLeavedMapEventArgs( item, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CreatureLeaveMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnLeavingMap( BaseCreature creature, BaseMap map )
        {
            EventHandler<CreatureLeavingMapEventArgs> tempBeforeEventArgs = m_EventCreatureLeavingMap;
            if ( tempBeforeEventArgs != null )
            {
                CreatureLeavingMapEventArgs eventArgs = new CreatureLeavingMapEventArgs( creature, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavedMap( BaseCreature creature, BaseMap map )
        {
            EventHandler<CreatureLeavedMapEventArgs> tempAfterEventArgs = m_EventCreatureLeavedMap;
            if ( tempAfterEventArgs != null )
            {
                CreatureLeavedMapEventArgs eventArgs = new CreatureLeavedMapEventArgs( creature, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CreatureLeaveMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnLeavingMap( BaseCharacter character, BaseMap map )
        {
            EventHandler<CharacterLeavingMapEventArgs> tempBeforeEventArgs = m_EventCharacterLeavingMap;
            if ( tempBeforeEventArgs != null )
            {
                CharacterLeavingMapEventArgs eventArgs = new CharacterLeavingMapEventArgs( character, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnLeavedMap( BaseCharacter character, BaseMap map )
        {
            EventHandler<CharacterLeavedMapEventArgs> tempAfterEventArgs = m_EventCharacterLeavedMap;
            if ( tempAfterEventArgs != null )
            {
                CharacterLeavedMapEventArgs eventArgs = new CharacterLeavedMapEventArgs( character, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS EntityMoveInMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnMoving( Point3D oldLocation, WorldEntity worldEntity, BaseMap map )
        {
            EventHandler<WorldEntityMovingInMapEventArgs> tempBeforeEventArgs = m_EventWorldEntityMovingInMap;
            if ( tempBeforeEventArgs != null )
            {
                WorldEntityMovingInMapEventArgs eventArgs = new WorldEntityMovingInMapEventArgs( oldLocation, worldEntity, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnMoved( Point3D oldLocation, WorldEntity worldEntity, BaseMap map )
        {
            EventHandler<WorldEntityMovedInMapEventArgs> tempAfterEventArgs = m_EventWorldEntityMovedInMap;
            if ( tempAfterEventArgs != null )
            {
                WorldEntityMovedInMapEventArgs eventArgs = new WorldEntityMovedInMapEventArgs( oldLocation, worldEntity, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS ItemMoveInMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnMoving( Point3D oldLocation, BaseItem item, BaseMap map )
        {
            EventHandler<ItemMovingInMapEventArgs> tempBeforeEventArgs = m_EventItemMovingInMap;
            if ( tempBeforeEventArgs != null )
            {
                ItemMovingInMapEventArgs eventArgs = new ItemMovingInMapEventArgs( oldLocation, item, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnMoved( Point3D oldLocation, BaseItem item, BaseMap map )
        {
            EventHandler<ItemMovedInMapEventArgs> tempAfterEventArgs = m_EventItemMovedInMap;
            if ( tempAfterEventArgs != null )
            {
                ItemMovedInMapEventArgs eventArgs = new ItemMovedInMapEventArgs( oldLocation, item, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CreatureMoveInMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnMoving( Point3D oldLocation, BaseCreature creature, BaseMap map )
        {
            EventHandler<CreatureMovingInMapEventArgs> tempBeforeEventArgs = m_EventCreatureMovingInMap;
            if ( tempBeforeEventArgs != null )
            {
                CreatureMovingInMapEventArgs eventArgs = new CreatureMovingInMapEventArgs( oldLocation, creature, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnMoved( Point3D oldLocation, BaseCreature creature, BaseMap map )
        {
            EventHandler<CreaturedMoveInMapEventArgs> tempAfterEventArgs = m_EventCreatureMovedInMap;
            if ( tempAfterEventArgs != null )
            {
                CreaturedMoveInMapEventArgs eventArgs = new CreaturedMoveInMapEventArgs( oldLocation, creature, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS CharacterMoveInMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnMoving( Point3D oldLocation, BaseCharacter character, BaseMap map )
        {
            EventHandler<CharacterMovingInMapEventArgs> tempBeforeEventArgs = m_EventCharacterMovingInMap;
            if ( tempBeforeEventArgs != null )
            {
                CharacterMovingInMapEventArgs eventArgs = new CharacterMovingInMapEventArgs( oldLocation, character, map );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnMoved( Point3D oldLocation, BaseCharacter character, BaseMap map )
        {
            EventHandler<CharacterMovedInMapEventArgs> tempAfterEventArgs = m_EventCharacterMovedInMap;
            if ( tempAfterEventArgs != null )
            {
                CharacterMovedInMapEventArgs eventArgs = new CharacterMovedInMapEventArgs( oldLocation, character, map );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS WorldEntityEnterMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityEnteringMapEventArgs> m_EventWorldEntityEnteringMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityEnteringMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityEnteringMapEventArgs> WorldEntityEnteringMap
        {
            add
            {
                m_LockEventWorldEntityEnteringMap.Enter();
                {
                    m_EventWorldEntityEnteringMap += value;
                }
                m_LockEventWorldEntityEnteringMap.Exit();
            }
            remove
            {
                m_LockEventWorldEntityEnteringMap.Enter();
                {
                    m_EventWorldEntityEnteringMap -= value;
                }
                m_LockEventWorldEntityEnteringMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityEnteredMapEventArgs> m_EventWorldEntityEnteredMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityEnteredMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityEnteredMapEventArgs> WorldEntityEnteredMap
        {
            add
            {
                m_LockEventWorldEntityEnteredMap.Enter();
                {
                    m_EventWorldEntityEnteredMap += value;
                }
                m_LockEventWorldEntityEnteredMap.Exit();
            }
            remove
            {
                m_LockEventWorldEntityEnteredMap.Enter();
                {
                    m_EventWorldEntityEnteredMap -= value;
                }
                m_LockEventWorldEntityEnteredMap.Exit();
            }
        }
        #endregion

        #region zh-CHS WorldEntityLeaveMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityLeavingMapEventArgs> m_EventWorldEntityLeavingMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityLeavingMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityLeavingMapEventArgs> WorldEntityLeavingMap
        {
            add
            {
                m_LockEventWorldEntityLeavingMap.Enter();
                {
                    m_EventWorldEntityLeavingMap += value;
                }
                m_LockEventWorldEntityLeavingMap.Exit();
            }
            remove
            {
                m_LockEventWorldEntityLeavingMap.Enter();
                {
                    m_EventWorldEntityLeavingMap -= value;
                }
                m_LockEventWorldEntityLeavingMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityLeavedMapEventArgs> m_EventWorldEntityLeavedMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityLeavedMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityLeavedMapEventArgs> WorldEntityLeavedMap
        {
            add
            {
                m_LockEventWorldEntityLeavedMap.Enter();
                {
                    m_EventWorldEntityLeavedMap += value;
                }
                m_LockEventWorldEntityLeavedMap.Exit();
            }
            remove
            {
                m_LockEventWorldEntityLeavedMap.Enter();
                {
                    m_EventWorldEntityLeavedMap -= value;
                }
                m_LockEventWorldEntityLeavedMap.Exit();
            }
        }
        #endregion

        #region zh-CHS WorldEntityMoveInMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityMovingInMapEventArgs> m_EventWorldEntityMovingInMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityMoveingInMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityMovingInMapEventArgs> WorldEntityMovingInMap
        {
            add
            {
                m_LockEventWorldEntityMoveingInMap.Enter();
                {
                    m_EventWorldEntityMovingInMap += value;
                }
                m_LockEventWorldEntityMoveingInMap.Exit();
            }
            remove
            {
                m_LockEventWorldEntityMoveingInMap.Enter();
                {
                    m_EventWorldEntityMovingInMap -= value;
                }
                m_LockEventWorldEntityMoveingInMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityMovedInMapEventArgs> m_EventWorldEntityMovedInMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventWorldEntityMovedInMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityMovedInMapEventArgs> WorldEntityMovedInMap
        {
            add
            {
                m_LockEventWorldEntityMovedInMap.Enter();
                {
                    m_EventWorldEntityMovedInMap += value;
                }
                m_LockEventWorldEntityMovedInMap.Exit();
            }
            remove
            {
                m_LockEventWorldEntityMovedInMap.Enter();
                {
                    m_EventWorldEntityMovedInMap -= value;
                }
                m_LockEventWorldEntityMovedInMap.Exit();
            }
        }
        #endregion

        #region zh-CHS ItemEnterMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemEnteringMapEventArgs> m_EventItemEnteringMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemEnteringMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemEnteringMapEventArgs> ItemEnteringMap
        {
            add
            {
                m_LockEventItemEnteringMap.Enter();
                {
                    m_EventItemEnteringMap += value;
                }
                m_LockEventItemEnteringMap.Exit();
            }
            remove
            {
                m_LockEventItemEnteringMap.Enter();
                {
                    m_EventItemEnteringMap -= value;
                }
                m_LockEventItemEnteringMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemEnteredMapEventArgs> m_EventItemEnteredMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemEnteredMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemEnteredMapEventArgs> ItemEnteredMap
        {
            add
            {
                m_LockEventItemEnteredMap.Enter();
                {
                    m_EventItemEnteredMap += value;
                }
                m_LockEventItemEnteredMap.Exit();
            }
            remove
            {
                m_LockEventItemEnteredMap.Enter();
                {
                    m_EventItemEnteredMap -= value;
                }
                m_LockEventItemEnteredMap.Exit();
            }
        }
        #endregion

        #region zh-CHS ItemLeaveMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemLeavingMapEventArgs> m_EventItemLeavingMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemLeavingMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemLeavingMapEventArgs> ItemLeavingMap
        {
            add
            {
                m_LockEventItemLeavingMap.Enter();
                {
                    m_EventItemLeavingMap += value;
                }
                m_LockEventItemLeavingMap.Exit();
            }
            remove
            {
                m_LockEventItemLeavingMap.Enter();
                {
                    m_EventItemLeavingMap -= value;
                }
                m_LockEventItemLeavingMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemLeavedMapEventArgs> m_EventItemLeavedMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemLeavedMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemLeavedMapEventArgs> ItemLeavedMap
        {
            add
            {
                m_LockEventItemLeavedMap.Enter();
                {
                    m_EventItemLeavedMap += value;
                }
                m_LockEventItemLeavedMap.Exit();
            }
            remove
            {
                m_LockEventItemLeavedMap.Enter();
                {
                    m_EventItemLeavedMap -= value;
                }
                m_LockEventItemLeavedMap.Exit();
            }
        }
        #endregion

        #region zh-CHS ItemMoveInMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemMovingInMapEventArgs> m_EventItemMovingInMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemMovingInMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemMovingInMapEventArgs> ItemMovingInMap
        {
            add
            {
                m_LockEventItemMovingInMap.Enter();
                {
                    m_EventItemMovingInMap += value;
                }
                m_LockEventItemMovingInMap.Exit();
            }
            remove
            {
                m_LockEventItemMovingInMap.Enter();
                {
                    m_EventItemMovingInMap -= value;
                }
                m_LockEventItemMovingInMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ItemMovedInMapEventArgs> m_EventItemMovedInMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventItemMovedInMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ItemMovedInMapEventArgs> ItemMovedInMap
        {
            add
            {
                m_LockEventItemMovedInMap.Enter();
                {
                    m_EventItemMovedInMap += value;
                }
                m_LockEventItemMovedInMap.Exit();
            }
            remove
            {
                m_LockEventItemMovedInMap.Enter();
                {
                    m_EventItemMovedInMap -= value;
                }
                m_LockEventItemMovedInMap.Exit();
            }
        }
        #endregion

        #region zh-CHS CreatureEnterMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreatureEnteringMapEventArgs> m_EventCreatureEnteringMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureEnteringMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreatureEnteringMapEventArgs> CreatureEnteringMap
        {
            add
            {
                m_LockEventCreatureEnteringMap.Enter();
                {
                    m_EventCreatureEnteringMap += value;
                }
                m_LockEventCreatureEnteringMap.Exit();
            }
            remove
            {
                m_LockEventCreatureEnteringMap.Enter();
                {
                    m_EventCreatureEnteringMap -= value;
                }
                m_LockEventCreatureEnteringMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreatureEnteredMapEventArgs> m_EventCreatureEnteredMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureEnteredMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreatureEnteredMapEventArgs> CreatureEnteredMap
        {
            add
            {
                m_LockEventCreatureEnteredMap.Enter();
                {
                    m_EventCreatureEnteredMap += value;
                }
                m_LockEventCreatureEnteredMap.Exit();
            }
            remove
            {
                m_LockEventCreatureEnteredMap.Enter();
                {
                    m_EventCreatureEnteredMap -= value;
                }
                m_LockEventCreatureEnteredMap.Exit();
            }
        }
        #endregion

        #region zh-CHS CreatureLeaveMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreatureLeavingMapEventArgs> m_EventCreatureLeavingMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureLeavingMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreatureLeavingMapEventArgs> CreatureLeavingMap
        {
            add
            {
                m_LockEventCreatureLeavingMap.Enter();
                {
                    m_EventCreatureLeavingMap += value;
                }
                m_LockEventCreatureLeavingMap.Exit();
            }
            remove
            {
                m_LockEventCreatureLeavingMap.Enter();
                {
                    m_EventCreatureLeavingMap -= value;
                }
                m_LockEventCreatureLeavingMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreatureLeavedMapEventArgs> m_EventCreatureLeavedMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureLeavedMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreatureLeavedMapEventArgs> CreatureLeavedMap
        {
            add
            {
                m_LockEventCreatureLeavedMap.Enter();
                {
                    m_EventCreatureLeavedMap += value;
                }
                m_LockEventCreatureLeavedMap.Exit();
            }
            remove
            {
                m_LockEventCreatureLeavedMap.Enter();
                {
                    m_EventCreatureLeavedMap -= value;
                }
                m_LockEventCreatureLeavedMap.Exit();
            }
        }
        #endregion

        #region zh-CHS CreatureMoveInMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreatureMovingInMapEventArgs> m_EventCreatureMovingInMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureMovingInMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreatureMovingInMapEventArgs> CreatureMovingInMap
        {
            add
            {
                m_LockEventCreatureMovingInMap.Enter();
                {
                    m_EventCreatureMovingInMap += value;
                }
                m_LockEventCreatureMovingInMap.Exit();
            }
            remove
            {
                m_LockEventCreatureMovingInMap.Enter();
                {
                    m_EventCreatureMovingInMap -= value;
                }
                m_LockEventCreatureMovingInMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CreaturedMoveInMapEventArgs> m_EventCreatureMovedInMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCreatureMovedInMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreaturedMoveInMapEventArgs> CreatureMovedInMap
        {
            add
            {
                m_LockEventCreatureMovedInMap.Enter();
                {
                    m_EventCreatureMovedInMap += value;
                }
                m_LockEventCreatureMovedInMap.Exit();
            }
            remove
            {
                m_LockEventCreatureMovedInMap.Enter();
                {
                    m_EventCreatureMovedInMap -= value;
                }
                m_LockEventCreatureMovedInMap.Exit();
            }
        }
        #endregion

        #region zh-CHS CharacterEnterMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterEnteringMapEventArgs> m_EventCharacterEnteringMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterEnteringMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterEnteringMapEventArgs> CharacterEnteringMap
        {
            add
            {
                m_LockEventCharacterEnteringMap.Enter();
                {
                    m_EventCharacterEnteringMap += value;
                }
                m_LockEventCharacterEnteringMap.Exit();
            }
            remove
            {
                m_LockEventCharacterEnteringMap.Enter();
                {
                    m_EventCharacterEnteringMap -= value;
                }
                m_LockEventCharacterEnteringMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterEnteredMapEventArgs> m_EventCharacterEnteredMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterEnteredMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterEnteredMapEventArgs> CharacterEnteredMap
        {
            add
            {
                m_LockEventCharacterEnteredMap.Enter();
                {
                    m_EventCharacterEnteredMap += value;
                }
                m_LockEventCharacterEnteredMap.Exit();
            }
            remove
            {
                m_LockEventCharacterEnteredMap.Enter();
                {
                    m_EventCharacterEnteredMap -= value;
                }
                m_LockEventCharacterEnteredMap.Exit();
            }
        }
        #endregion

        #region zh-CHS CharacterLeaveMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterLeavingMapEventArgs> m_EventCharacterLeavingMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterLeavingMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterLeavingMapEventArgs> CharacterLeavingMap
        {
            add
            {
                m_LockEventCharacterLeavingMap.Enter();
                {
                    m_EventCharacterLeavingMap += value;
                }
                m_LockEventCharacterLeavingMap.Exit();
            }
            remove
            {
                m_LockEventCharacterLeavingMap.Enter();
                {
                    m_EventCharacterLeavingMap -= value;
                }
                m_LockEventCharacterLeavingMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterLeavedMapEventArgs> m_EventCharacterLeavedMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterLeavedMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterLeavedMapEventArgs> CharacterLeavedMap
        {
            add
            {
                m_LockEventCharacterLeavedMap.Enter();
                {
                    m_EventCharacterLeavedMap += value;
                }
                m_LockEventCharacterLeavedMap.Exit();
            }
            remove
            {
                m_LockEventCharacterLeavedMap.Enter();
                {
                    m_EventCharacterLeavedMap -= value;
                }
                m_LockEventCharacterLeavedMap.Exit();
            }
        }
        #endregion

        #region zh-CHS CharacterMoveInMap事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterMovingInMapEventArgs> m_EventCharacterMovingInMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterMovingInMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterMovingInMapEventArgs> CharacterMovingInMap
        {
            add
            {
                m_LockEventCharacterMovingInMap.Enter();
                {
                    m_EventCharacterMovingInMap += value;
                }
                m_LockEventCharacterMovingInMap.Exit();
            }
            remove
            {
                m_LockEventCharacterMovingInMap.Enter();
                {
                    m_EventCharacterMovingInMap -= value;
                }
                m_LockEventCharacterMovingInMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CharacterMovedInMapEventArgs> m_EventCharacterMovedInMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCharacterMovedInMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CharacterMovedInMapEventArgs> CharacterMovedInMap
        {
            add
            {
                m_LockEventCharacterMovedInMap.Enter();
                {
                    m_EventCharacterMovedInMap += value;
                }
                m_LockEventCharacterMovedInMap.Exit();
            }
            remove
            {
                m_LockEventCharacterMovedInMap.Enter();
                {
                    m_EventCharacterMovedInMap -= value;
                }
                m_LockEventCharacterMovedInMap.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion