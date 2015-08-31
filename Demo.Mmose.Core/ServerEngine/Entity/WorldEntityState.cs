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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Map;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class WorldEntityState
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 单体
        /// </summary>
        private static WorldEntityState s_WorldEntityState = new WorldEntityState();
        #endregion
        /// <summary>
        /// 单体
        /// </summary>
        public static WorldEntityState SingletonInstance
        {
            get { return s_WorldEntityState; }
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateSerial = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateSerial
        {
            get { return m_UpdateSerial; }
            internal set {m_UpdateSerial = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateX = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateX
        {
            get { return m_UpdateX; }
            internal set { m_UpdateX = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateY = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateY
        {
            get { return m_UpdateY; }
            internal set { m_UpdateY = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateZ = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateZ
        {
            get { return m_UpdateZ; }
            internal set { m_UpdateZ = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateOrientation = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateOrientation
        {
            get { return m_UpdateOrientation; }
            internal set { m_UpdateOrientation = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateLocation = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateLocation
        {
            get { return m_UpdateLocation; }
            internal set { m_UpdateLocation = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateMap = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateMap
        {
            get { return m_UpdateMap; }
            internal set { m_UpdateMap = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateMapSpaceNode = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateMapSpaceNode
        {
            get { return m_UpdateMapSpaceNode; }
            internal set { m_UpdateMapSpaceNode = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateAI = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateAI
        {
            get { return m_UpdateAI; }
            internal set { m_UpdateAI = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateMoveToCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsMoveToCall
        {
            get { return m_UpdateMoveToCall; }
            internal set { m_UpdateMoveToCall = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateMoveToWorldCall = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsMoveToWorldCall
        {
            get { return m_UpdateMoveToWorldCall; }
            internal set { m_UpdateMoveToWorldCall = value; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        internal void RestoreAll()
        {
            m_UpdateSerial = false;
            m_UpdateX = false;
            m_UpdateY = false;
            m_UpdateZ = false;
            m_UpdateLocation = false;
            m_UpdateOrientation = false;
            m_UpdateMap = false;
            m_UpdateMapSpaceNode = false;
            m_UpdateAI = false;
            m_UpdateMoveToCall = false;
            m_UpdateMoveToWorldCall = false;
        }

        #endregion

        #region zh-CHS 内部的事件处理函数 | en Internal Event Handlers

        #region zh-CHS Serial事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingSerial( Serial serial, WorldEntity gameEntity )
        {
            EventHandler<UpdatingSerialEventArgs> tempBeforeEventArgs = m_EventUpdatingSerial;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingSerialEventArgs eventArgs = new UpdatingSerialEventArgs( serial, gameEntity );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedSerial( Serial serial, WorldEntity gameEntity )
        {
            EventHandler<UpdatedSerialEventArgs> tempAfterEventArgs = m_EventUpdatedSerial;
            if ( tempAfterEventArgs != null )
            {
                UpdatedSerialEventArgs eventArgs = new UpdatedSerialEventArgs( serial, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS X事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingX( float x, WorldEntity gameEntity )
        {
            EventHandler<UpdatingXEventArgs> tempBeforeEventArgs = m_EventUpdatingX;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingXEventArgs eventArgs = new UpdatingXEventArgs( x, gameEntity );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedX( float x, WorldEntity gameEntity )
        {
            EventHandler<UpdatedXEventArgs> tempAfterEventArgs = m_EventUpdatedX;
            if ( tempAfterEventArgs != null )
            {
                UpdatedXEventArgs eventArgs = new UpdatedXEventArgs( x, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS Y事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingY( float y, WorldEntity gameEntity )
        {
            EventHandler<UpdatingYEventArgs> tempBeforeEventArgs = m_EventUpdatingY;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingYEventArgs eventArgs = new UpdatingYEventArgs( y, gameEntity );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedY( float y, WorldEntity gameEntity )
        {
            EventHandler<UpdatedYEventArgs> tempAfterEventArgs = m_EventUpdatedY;
            if ( tempAfterEventArgs != null )
            {
                UpdatedYEventArgs eventArgs = new UpdatedYEventArgs( y, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS Z事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingZ( float z, WorldEntity gameEntity )
        {
            EventHandler<UpdatingZEventArgs> tempBeforeEventArgs = m_EventUpdatingZ;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingZEventArgs eventArgs = new UpdatingZEventArgs( z, gameEntity );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedZ( float z, WorldEntity gameEntity )
        {
            EventHandler<UpdatedZEventArgs> tempAfterEventArgs = m_EventUpdatedZ;
            if ( tempAfterEventArgs != null )
            {
                UpdatedZEventArgs eventArgs = new UpdatedZEventArgs( z, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS Orientation事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingOrientation( float orientation, WorldEntity gameEntity )
        {
            EventHandler<UpdatingOrientationEventArgs> tempBeforeEventArgs = m_EventUpdatingOrientation;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingOrientationEventArgs eventArgs = new UpdatingOrientationEventArgs( orientation, gameEntity );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedOrientation( float orientation, WorldEntity gameEntity )
        {
            EventHandler<UpdatedOrientationEventArgs> tempAfterEventArgs = m_EventUpdatedOrientation;
            if ( tempAfterEventArgs != null )
            {
                UpdatedOrientationEventArgs eventArgs = new UpdatedOrientationEventArgs( orientation, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS Location事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingLocation( Point3D point3D, WorldEntity gameEntity )
        {
            EventHandler<UpdatingLocationEventArgs> tempBeforeEventArgs = m_EventUpdatingLocation;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingLocationEventArgs eventArgs = new UpdatingLocationEventArgs( point3D, gameEntity );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedLocation( Point3D point3D, WorldEntity gameEntity )
        {
            EventHandler<UpdatedLocationEventArgs> tempAfterEventArgs = m_EventUpdatedLocation;
            if ( tempAfterEventArgs != null )
            {
                UpdatedLocationEventArgs eventArgs = new UpdatedLocationEventArgs( point3D, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS Map事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatingMap( BaseMap map, WorldEntity gameEntity )
        {
            EventHandler<UpdatingMapEventArgs> tempBeforeEventArgs = m_EventUpdatingMap;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingMapEventArgs eventArgs = new UpdatingMapEventArgs( map, gameEntity );
                tempBeforeEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedMap( BaseMap map, WorldEntity gameEntity )
        {
            EventHandler<UpdatedMapEventArgs> tempAfterEventArgs = m_EventUpdatedMap;
            if ( tempAfterEventArgs != null )
            {
                UpdatedMapEventArgs eventArgs = new UpdatedMapEventArgs( map, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS MapSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatingMapSpaceNode( MapSpaceNode mapSpaceNode, WorldEntity gameEntity )
        {
            EventHandler<UpdatingMapSpaceNodeEventArgs> tempBeforeEventArgs = m_EventUpdatingMapSpaceNode;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingMapSpaceNodeEventArgs eventArgs = new UpdatingMapSpaceNodeEventArgs( mapSpaceNode, gameEntity );
                tempBeforeEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedMapSpaceNode( MapSpaceNode mapSpaceNode, WorldEntity gameEntity )
        {
            EventHandler<UpdatedMapSpaceNodeEventArgs> tempAfterEventArgs = m_EventUpdatedMapSpaceNode;
            if ( tempAfterEventArgs != null )
            {
                UpdatedMapSpaceNodeEventArgs eventArgs = new UpdatedMapSpaceNodeEventArgs( mapSpaceNode, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS AI事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatingAI( IArtificialIntelligence artificialIntelligence, WorldEntity gameEntity )
        {
            EventHandler<UpdatingAIEventArgs> tempBeforeEventArgs = m_EventUpdatingAI;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingAIEventArgs eventArgs = new UpdatingAIEventArgs( artificialIntelligence, gameEntity );
                tempBeforeEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedAI( IArtificialIntelligence artificialIntelligence, WorldEntity gameEntity )
        {
            EventHandler<UpdatedAIEventArgs> tempAfterEventArgs = m_EventUpdatedAI;
            if ( tempAfterEventArgs != null )
            {
                UpdatedAIEventArgs eventArgs = new UpdatedAIEventArgs( artificialIntelligence, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS DeleteCall事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal void OnDeletingCall( WorldEntity gameEntity )
        {
            EventHandler<WorldEntityEventArgs> tempBeforeEventArgs = m_EventDeletingCall;
            if ( tempBeforeEventArgs != null )
            {
                WorldEntityEventArgs eventArgs = new WorldEntityEventArgs( gameEntity );
                tempBeforeEventArgs( this, eventArgs );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnDeletedCall( WorldEntity gameEntity )
        {
            EventHandler<WorldEntityEventArgs> tempAfterEventArgs = m_EventDeletedCall;
            if ( tempAfterEventArgs != null )
            {
                WorldEntityEventArgs eventArgs = new WorldEntityEventArgs( gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS MoveTo事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnMovingTo( Point3D location, WorldEntity gameEntity )
        {
            EventHandler<MovingToCallEventArgs> tempBeforeEventArgs = m_EventMovingToCall;
            if ( tempBeforeEventArgs != null )
            {
                MovingToCallEventArgs eventArgs = new MovingToCallEventArgs( location, gameEntity );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnMovedTo( Point3D location, WorldEntity gameEntity )
        {
            EventHandler<MovedToCallEventArgs> tempAfterEventArgs = m_EventMovedToCall;
            if ( tempAfterEventArgs != null )
            {
                MovedToCallEventArgs eventArgs = new MovedToCallEventArgs( location, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS MoveToWorld事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnMovingToWorld( Point3D newLocation, BaseMap newMap, WorldEntity gameEntity )
        {
            EventHandler<MovingToWorldEventArgs> tempBeforeEventArgs = m_EventMovingToWorld;
            if ( tempBeforeEventArgs != null )
            {
                MovingToWorldEventArgs eventArgs = new MovingToWorldEventArgs( newLocation, newMap, gameEntity );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnMovedToWorld( Point3D oldLocation, BaseMap oldMap, WorldEntity gameEntity )
        {
            EventHandler<MovedToWorldEventArgs> tempAfterEventArgs = m_EventMovedToWorld;
            if ( tempAfterEventArgs != null )
            {
                MovedToWorldEventArgs eventArgs = new MovedToWorldEventArgs( oldLocation, oldMap, gameEntity );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS Serial事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingSerialEventArgs> m_EventUpdatingSerial;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingSerial = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingSerialEventArgs> UpdatingSerial
        {
            add
            {
                m_LockEventUpdatingSerial.Enter();
                {
                    m_EventUpdatingSerial += value;
                }
                m_LockEventUpdatingSerial.Exit();
            }
            remove
            {
                m_LockEventUpdatingSerial.Enter();
                {
                    m_EventUpdatingSerial -= value;
                }
                m_LockEventUpdatingSerial.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedSerialEventArgs> m_EventUpdatedSerial;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedSerial = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedSerialEventArgs> UpdatedSerial
        {
            add
            {
                m_LockEventUpdatedSerial.Enter();
                {
                    m_EventUpdatedSerial += value;
                }
                m_LockEventUpdatedSerial.Exit();
            }
            remove
            {
                m_LockEventUpdatedSerial.Enter();
                {
                    m_EventUpdatedSerial -= value;
                }
                m_LockEventUpdatedSerial.Exit();
            }
        }
        #endregion

        #region zh-CHS X事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingXEventArgs> m_EventUpdatingX;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingX = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingXEventArgs> UpdatingX
        {
            add
            {
                m_LockEventUpdatingX.Enter();
                {
                    m_EventUpdatingX += value;
                }
                m_LockEventUpdatingX.Exit();
            }
            remove
            {
                m_LockEventUpdatingX.Enter();
                {
                    m_EventUpdatingX -= value;
                }
                m_LockEventUpdatingX.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedXEventArgs> m_EventUpdatedX;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedX = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedXEventArgs> UpdatedX
        {
            add
            {
                m_LockEventUpdatedX.Enter();
                {
                    m_EventUpdatedX += value;
                }
                m_LockEventUpdatedX.Exit();
            }
            remove
            {
                m_LockEventUpdatedX.Enter();
                {
                    m_EventUpdatedX -= value;
                }
                m_LockEventUpdatedX.Exit();
            }
        }
        #endregion

        #region zh-CHS Y事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingYEventArgs> m_EventUpdatingY;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingY = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingYEventArgs> UpdatingY
        {
            add
            {
                m_LockEventUpdatingY.Enter();
                {
                    m_EventUpdatingY += value;
                }
                m_LockEventUpdatingY.Exit();
            }
            remove
            {
                m_LockEventUpdatingY.Enter();
                {
                    m_EventUpdatingY -= value;
                }
                m_LockEventUpdatingY.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedYEventArgs> m_EventUpdatedY;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedY = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedYEventArgs> UpdatedY
        {
            add
            {
                m_LockEventUpdatedY.Enter();
                {
                    m_EventUpdatedY += value;
                }
                m_LockEventUpdatedY.Exit();
            }
            remove
            {
                m_LockEventUpdatedY.Enter();
                {
                    m_EventUpdatedY -= value;
                }
                m_LockEventUpdatedY.Exit();
            }
        }
        #endregion

        #region zh-CHS Z事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingZEventArgs> m_EventUpdatingZ;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingZ = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingZEventArgs> UpdatingZ
        {
            add
            {
                m_LockEventUpdatingZ.Enter();
                {
                    m_EventUpdatingZ += value;
                }
                m_LockEventUpdatingZ.Exit();
            }
            remove
            {
                m_LockEventUpdatingZ.Enter();
                {
                    m_EventUpdatingZ -= value;
                }
                m_LockEventUpdatingZ.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedZEventArgs> m_EventUpdatedZ;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedZ = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedZEventArgs> UpdatedZ
        {
            add
            {
                m_LockEventUpdatedZ.Enter();
                {
                    m_EventUpdatedZ += value;
                }
                m_LockEventUpdatedZ.Exit();
            }
            remove
            {
                m_LockEventUpdatedZ.Enter();
                {
                    m_EventUpdatedZ -= value;
                }
                m_LockEventUpdatedZ.Exit();
            }
        }
        #endregion

        #region zh-CHS Orientation事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingOrientationEventArgs> m_EventUpdatingOrientation;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingOrientation = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingOrientationEventArgs> UpdatingOrientation
        {
            add
            {
                m_LockEventUpdatingOrientation.Enter();
                {
                    m_EventUpdatingOrientation += value;
                }
                m_LockEventUpdatingOrientation.Exit();
            }
            remove
            {
                m_LockEventUpdatingOrientation.Enter();
                {
                    m_EventUpdatingOrientation -= value;
                }
                m_LockEventUpdatingOrientation.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedOrientationEventArgs> m_EventUpdatedOrientation;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedOrientation = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedOrientationEventArgs> UpdatedOrientation
        {
            add
            {
                m_LockEventUpdatedOrientation.Enter();
                {
                    m_EventUpdatedOrientation += value;
                }
                m_LockEventUpdatedOrientation.Exit();
            }
            remove
            {
                m_LockEventUpdatedOrientation.Enter();
                {
                    m_EventUpdatedOrientation -= value;
                }
                m_LockEventUpdatedOrientation.Exit();
            }
        }
        #endregion

        #region zh-CHS Location事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingLocationEventArgs> m_EventUpdatingLocation;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingLocation = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingLocationEventArgs> UpdatingLocation
        {
            add
            {
                m_LockEventUpdatingLocation.Enter();
                {
                    m_EventUpdatingLocation += value;
                }
                m_LockEventUpdatingLocation.Exit();
            }
            remove
            {
                m_LockEventUpdatingLocation.Enter();
                {
                    m_EventUpdatingLocation -= value;
                }
                m_LockEventUpdatingLocation.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedLocationEventArgs> m_EventUpdatedLocation;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedLocation = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedLocationEventArgs> UpdatedLocation
        {
            add
            {
                m_LockEventUpdatedLocation.Enter();
                {
                    m_EventUpdatedLocation += value;
                }
                m_LockEventUpdatedLocation.Exit();
            }
            remove
            {
                m_LockEventUpdatedLocation.Enter();
                {
                    m_EventUpdatedLocation -= value;
                }
                m_LockEventUpdatedLocation.Exit();
            }
        }
        #endregion

        #region zh-CHS Map事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingMapEventArgs> m_EventUpdatingMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingMapEventArgs> UpdatingMap
        {
            add
            {
                m_LockEventUpdatingMap.Enter();
                {
                    m_EventUpdatingMap += value;
                }
                m_LockEventUpdatingMap.Exit();
            }
            remove
            {
                m_LockEventUpdatingMap.Enter();
                {
                    m_EventUpdatingMap -= value;
                }
                m_LockEventUpdatingMap.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedMapEventArgs> m_EventUpdatedMap;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedMap = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedMapEventArgs> UpdatedMap
        {
            add
            {
                m_LockEventUpdatedMap.Enter();
                {
                    m_EventUpdatedMap += value;
                }
                m_LockEventUpdatedMap.Exit();
            }
            remove
            {
                m_LockEventUpdatedMap.Enter();
                {
                    m_EventUpdatedMap -= value;
                }
                m_LockEventUpdatedMap.Exit();
            }
        }
        #endregion

        #region zh-CHS MapSpaceNode事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingMapSpaceNodeEventArgs> m_EventUpdatingMapSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingMapSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingMapSpaceNodeEventArgs> UpdatingMapSpaceNode
        {
            add
            {
                m_LockEventUpdatingMapSpaceNode.Enter();
                {
                    m_EventUpdatingMapSpaceNode += value;
                }
                m_LockEventUpdatingMapSpaceNode.Exit();
            }
            remove
            {
                m_LockEventUpdatingMapSpaceNode.Enter();
                {
                    m_EventUpdatingMapSpaceNode -= value;
                }
                m_LockEventUpdatingMapSpaceNode.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedMapSpaceNodeEventArgs> m_EventUpdatedMapSpaceNode;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedMapSpaceNode = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedMapSpaceNodeEventArgs> UpdatedMapSpaceNode
        {
            add
            {
                m_LockEventUpdatedMapSpaceNode.Enter();
                {
                    m_EventUpdatedMapSpaceNode += value;
                }
                m_LockEventUpdatedMapSpaceNode.Exit();
            }
            remove
            {
                m_LockEventUpdatedMapSpaceNode.Enter();
                {
                    m_EventUpdatedMapSpaceNode -= value;
                }
                m_LockEventUpdatedMapSpaceNode.Exit();
            }
        }
        #endregion

        #region zh-CHS AI事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingAIEventArgs> m_EventUpdatingAI;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingAI = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingAIEventArgs> UpdatingAI
        {
            add
            {
                m_LockEventUpdatingAI.Enter();
                {
                    m_EventUpdatingAI += value;
                }
                m_LockEventUpdatingAI.Exit();
            }
            remove
            {
                m_LockEventUpdatingAI.Enter();
                {
                    m_EventUpdatingAI -= value;
                }
                m_LockEventUpdatingAI.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedAIEventArgs> m_EventUpdatedAI;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedAI = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedAIEventArgs> UpdatedAI
        {
            add
            {
                m_LockEventUpdatedAI.Enter();
                {
                    m_EventUpdatedAI += value;
                }
                m_LockEventUpdatedAI.Exit();
            }
            remove
            {
                m_LockEventUpdatedAI.Enter();
                {
                    m_EventUpdatedAI -= value;
                }
                m_LockEventUpdatedAI.Exit();
            }
        }
        #endregion

        #region zh-CHS DeleteCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityEventArgs> m_EventDeletingCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventDeletingCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityEventArgs> DeletingCall
        {
            add
            {
                m_LockEventDeletingCall.Enter();
                {
                    m_EventDeletingCall += value;
                }
                m_LockEventDeletingCall.Exit();
            }
            remove
            {
                m_LockEventDeletingCall.Enter();
                {
                    m_EventDeletingCall -= value;
                }
                m_LockEventDeletingCall.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityEventArgs> m_EventDeletedCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventDeletedCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityEventArgs> DeletedCall
        {
            add
            {
                m_LockEventDeletedCall.Enter();
                {
                    m_EventDeletedCall += value;
                }
                m_LockEventDeletedCall.Exit();
            }
            remove
            {
                m_LockEventDeletedCall.Enter();
                {
                    m_EventDeletedCall -= value;
                }
                m_LockEventDeletedCall.Exit();
            }
        }
        #endregion

        #region zh-CHS MoveTo事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<MovingToCallEventArgs> m_EventMovingToCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventMovingToCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MovingToCallEventArgs> MovingToCall
        {
            add
            {
                m_LockEventMovingToCall.Enter();
                {
                    m_EventMovingToCall += value;
                }
                m_LockEventMovingToCall.Exit();
            }
            remove
            {
                m_LockEventMovingToCall.Enter();
                {
                    m_EventMovingToCall -= value;
                }
                m_LockEventMovingToCall.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<MovedToCallEventArgs> m_EventMovedToCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventMovedToCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MovedToCallEventArgs> MovedToCall
        {
            add
            {
                m_LockEventMovedToCall.Enter();
                {
                    m_EventMovedToCall += value;
                }
                m_LockEventMovedToCall.Exit();
            }
            remove
            {
                m_LockEventMovedToCall.Enter();
                {
                    m_EventMovedToCall -= value;
                }
                m_LockEventMovedToCall.Exit();
            }
        }
        #endregion

        #region zh-CHS MoveToWorld事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<MovingToWorldEventArgs> m_EventMovingToWorld;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventMovingToWorld = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MovingToWorldEventArgs> MovingToWorld
        {
            add
            {
                m_LockEventMovingToWorld.Enter();
                {
                    m_EventMovingToWorld += value;
                }
                m_LockEventMovingToWorld.Exit();
            }
            remove
            {
                m_LockEventMovingToWorld.Enter();
                {
                    m_EventMovingToWorld -= value;
                }
                m_LockEventMovingToWorld.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<MovedToWorldEventArgs> m_EventMovedToWorld;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventMovedToWorld = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MovedToWorldEventArgs> MovedToWorld
        {
            add
            {
                m_LockEventMovedToWorld.Enter();
                {
                    m_EventMovedToWorld += value;
                }
                m_LockEventMovedToWorld.Exit();
            }
            remove
            {
                m_LockEventMovedToWorld.Enter();
                {
                    m_EventMovedToWorld -= value;
                }
                m_LockEventMovedToWorld.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion