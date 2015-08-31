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
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.EventSkin;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Map;
using Demo.Mmose.Core.Timer;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.World;
#endregion

namespace Demo.Mmose.Core.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class WorldEntity : ISerial, ILocation, IPoint4D, IComparable, IComparable<WorldEntity>
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int LIST_CAPACITY_SIZE = 1024;
        /// <summary>
        /// 
        /// </summary>
        private readonly static int DICTIONARY_CAPACITY_SIZE = 1024;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public WorldEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serial">唯一序号</param>
        public WorldEntity( Serial serial )
        {
            m_Serial = serial;
        }

        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Serial属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_Serial = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
            set
            {
                Serial oldValueSerial = m_Serial;

                if ( m_GameEntityState != null )
                {
                    if ( m_GameEntityState.OnUpdatingSerial( value, this ) == true )
                        return;
                }

                m_Serial = value;
                m_GameEntityState.IsUpdateSerial = true;

                 if ( m_GameEntityState != null )
                     m_GameEntityState.OnUpdatedSerial( oldValueSerial, this );
            }
        }

        #endregion

        #region zh-CHS X属性 | en Public Properties

        /// <summary>
        /// 
        /// </summary>
        public float X
        {
            get { return m_Location.X; }
            set
            {
                float oldX = m_Location.X;

                if ( m_GameEntityState != null )
                {
                    if ( m_GameEntityState.OnUpdatingX( value, this ) == true )
                        return;
                }

                m_Location.X = value;
                m_GameEntityState.IsUpdateX = true;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatedX( oldX, this );
            }
        }

        #endregion

        #region zh-CHS Y属性 | en Public Properties

        /// <summary>
        /// 
        /// </summary>
        public float Y
        {
            get { return m_Location.Y; }
            set
            {
                float oldY = m_Location.Y;

                if ( m_GameEntityState != null )
                {
                    if ( m_GameEntityState.OnUpdatingY( value, this ) == true )
                        return;
                }

                m_Location.Y = value;
                m_GameEntityState.IsUpdateY = true;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatedY( oldY, this );
            }
        }

        #endregion

        #region zh-CHS Z属性 | en Public Properties

        /// <summary>
        /// 
        /// </summary>
        public float Z
        {
            get { return m_Location.Z; }
            set
            {
                float oldZ = m_Location.Z;

                if ( m_GameEntityState != null )
                {
                    if ( m_GameEntityState.OnUpdatingZ( value, this ) == true )
                        return;
                }

                m_Location.Z = value;
                m_GameEntityState.IsUpdateZ = true;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatedZ( oldZ, this );
            }
        }

        #endregion

        #region zh-CHS Orientation属性 | en Public Properties

        /// <summary>
        /// 
        /// </summary>
        public float O
        {
            get { return m_Location.O; }
            set
            {
                float oldOrientation = m_Location.O;

                if ( m_GameEntityState != null )
                {
                    if ( m_GameEntityState.OnUpdatingOrientation( value, this ) == true )
                        return;
                }

                m_Location.O = value;
                m_GameEntityState.IsUpdateOrientation = true;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatedOrientation( oldOrientation, this );
            }
        }

        #endregion

        #region zh-CHS Location属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point4D m_Location = Point4D.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D Location
        {
            get { return (Point3D)m_Location; }
            set
            {
                Point3D oldLocation = (Point3D)m_Location;

                if ( m_GameEntityState != null )
                {
                    if ( m_GameEntityState.OnUpdatingLocation( value, this ) == true )
                        return;
                }

                m_Location.X = value.X;
                m_Location.Y = value.Y;
                m_Location.Z = value.Z;
                m_GameEntityState.IsUpdateLocation = true;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatedLocation( oldLocation, this );
            }
        }

        #endregion

        #region zh-CHS Map属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物所在的地图
        /// </summary>
        private BaseMap m_Map = null;
        #endregion
        /// <summary>
        /// 人物所在的地图
        /// </summary>
        public BaseMap Map
        {
            get { return m_Map; }
            internal set
            {
                BaseMap oldMap = m_Map;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatingMap( value, this );

                m_Map = value;
                m_GameEntityState.IsUpdateMap = true;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatedMap( oldMap, this );
            }
        }

        #region zh-CHS 地图点激活方法 | en Protected Internal Methods

        /// <summary>
        /// 
        /// </summary>
        private TimeSlice m_SpaceNodeActivateTimeSlice = null;
        /// <summary>
        /// 
        /// </summary>
        public void SetSpaceNodeActivateCallbackTime( TimeSpan timeSlice )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void SpaceNodeActivateCallback()
        {
        }

        /// <summary>
        /// 地图点激活
        /// </summary>
        public virtual void OnSpaceNodeActivate()
        {
            m_SpaceNodeActivateTimeSlice = TimeSlice.StartTimeSlice( TimeSpan.FromMilliseconds( 1000 ), SpaceNodeActivateCallback );
        }

        /// <summary>
        /// 地图点不激活
        /// </summary>
        public virtual void OnSpaceNodeDeactivate()
        {
            m_SpaceNodeActivateTimeSlice.Stop();
        }
        #endregion

        #region zh-CHS 人物的移动 | en
        /// <summary>
        /// 人物的移动方向
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool MoveTo( Point3D newLocation )
        {
            BaseMap tempMap = m_Map; // 副本防止多线程置空
            if ( m_Deleted == true || tempMap == null )
                return false;

            MoveToEventArgs eventArgs = GlobalEvent.BaseCharacter.InvokeMoveTo( newLocation, this );
            if ( eventArgs != null )
            {
                if ( eventArgs.Blocked == true )
                    return false;
            }

            Point3D oldLocation = (Point3D)m_Location;

            if ( m_GameEntityState != null )
            {
                if ( m_GameEntityState.OnMovingTo( newLocation, this ) == true )
                    return false;
            }

            this.Location = newLocation; // 间接设置
            tempMap.OnMove( oldLocation, this );
            m_GameEntityState.IsMoveToCall = true;

            if ( m_GameEntityState != null )
                m_GameEntityState.OnMovedTo( oldLocation, this );

            return true;
        }

        /// <summary>
        /// 移动到世界的某地图的某个点
        /// </summary>
        /// <param name="newLocation"></param>
        /// <param name="map"></param>
        public bool MoveToWorld( Point3D newLocation, BaseMap newMap )
        {
            BaseMap tempMap = m_Map; // 副本防止多线程置空
            if ( m_Deleted == true || tempMap == null || newMap == null )
                return false;

            MoveToWorldEventArgs eventArgs = GlobalEvent.BaseCharacter.InvokeMoveToWorld( newLocation, newMap, this );
            if ( eventArgs != null )
            {
                if ( eventArgs.Blocked == true )
                    return false;
            }

            if ( tempMap == newMap )
                return MoveTo( newLocation );
            else
            {
                BaseMap oldMap = tempMap;
                Point3D oldLocation = (Point3D)m_Location;

                if ( m_GameEntityState != null )
                {
                    if ( m_GameEntityState.OnMovingToWorld( newLocation, newMap, this ) == true )
                        return false;
                }

                this.Map = newMap; // 间接设置
                this.Location = newLocation; // 间接设置

                oldMap.OnLeave( this );
                tempMap.OnEnter( this );
                m_GameEntityState.IsMoveToWorldCall = true;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnMovedToWorld( oldLocation, oldMap, this );

                return true;
            }
        }
        #endregion

        #endregion

        #region zh-CHS MapSpaceNode属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MapSpaceNode m_MapSpaceNode = null;
        #endregion
        /// <summary>
        /// 用于内部使用的地图点
        /// </summary>
        public MapSpaceNode MapSpaceNode
        {
            get { return m_MapSpaceNode; }
            internal set
            {
                MapSpaceNode oldMapSpaceNode = m_MapSpaceNode;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatingMapSpaceNode( value, this );

                m_MapSpaceNode = value;
                m_GameEntityState.IsUpdateMapSpaceNode = true;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatedMapSpaceNode( oldMapSpaceNode, this );
            }
        }

        #endregion

        #region zh-CHS AI属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private IArtificialIntelligence m_ArtificialIntelligence = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public IArtificialIntelligence AI
        {
            get { return m_ArtificialIntelligence; }
            set
            {
                IArtificialIntelligence oldArtificialIntelligence = m_ArtificialIntelligence;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatingAI( value, this );

                m_ArtificialIntelligence = value;
                m_GameEntityState.IsUpdateAI = true;

                if ( m_GameEntityState != null )
                    m_GameEntityState.OnUpdatedAI( oldArtificialIntelligence, this );
            }
        }


        #endregion

        #region zh-CHS Deleted属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物是否删除
        /// </summary>
        private bool m_Deleted = false;
        #endregion
        /// <summary>
        /// BaseMobile是否已无效删除
        /// </summary>
        public bool Deleted
        {
            get { return m_Deleted; }
        }

        #region zh-CHS 人物的删除 | en
        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            if ( m_GameEntityState != null )
                m_GameEntityState.OnDeletingCall( this );

            m_Deleted = true;

            if ( m_GameEntityState != null )
                m_GameEntityState.OnDeletedCall( this );
        }
        #endregion

        #endregion

        #region zh-CHS Saving属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_Saving = false;
        #endregion
        /// <summary>
        /// 是否正在存储数据中
        /// </summary>
        public bool Saving
        {
            get { return m_Saving; }
        }

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockSave = new SpinLock();
        #endregion
        /// <summary>
        /// 保存人物的数据
        /// </summary>
        public void Save()
        {
            // 移动物体的数据必须要成功才返回
            m_LockSave.Enter();
            {
                // 保存数据中......
                m_Saving = true;

                EventHandler<WorldEntityEventArgs> tempEventArgs = m_EventSaveWorldEntity;
                // 保存数据
                if ( tempEventArgs != null )
                {
                    WorldEntityEventArgs eventArgs = new WorldEntityEventArgs( this );
                    tempEventArgs( this, eventArgs );
                }

                // 保存数据结束......
                m_Saving = false;
            }
            m_LockSave.Exit();
        }
        #endregion

        #endregion

        #region zh-CHS World属性 | en World Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 管理当前的世界服务
        /// </summary>
        private BaseWorld m_World = null;
        #endregion
        /// <summary>
        /// 管理当前的世界服务
        /// </summary>
        public BaseWorld World
        {
            get { return m_World; }
            internal set { m_World = value; }
        }

        #endregion

        #region zh-CHS GameEntityState属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的状态机
        /// </summary>
        private WorldEntityState m_GameEntityState = null;
        #endregion
        /// <summary>
        /// BaseCreatureState人物的状态器(默认为空，可以在需要的时候设置)
        /// </summary>
        public WorldEntityState GameEntityState
        {
            get { return m_GameEntityState; }
            protected set { m_GameEntityState = value; }
        }

        #endregion

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 物体可见的范围 | en

        #region zh-CHS 给出目标的距离 | en
        /// <summary>
        /// 给出目标的距离
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double GetDistanceToSqrt( WorldEntity entity )
        {
            if ( entity == null )
                throw new Exception( "GameEntity.GetDistanceToSqrt(...) - entity == null error!" );

            return GetDistanceToSqrt( entity as IPoint2D );
        }

        /// <summary>
        /// 给出目标的距离
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double GetDistanceToSqrt( Point3D point3D )
        {
            // (防止装箱操作)
            float xDelta = this.Location.X - point3D.X;
            float yDelta = this.Location.Y - point3D.Y;

            return Math.Sqrt( ( xDelta * xDelta ) + ( yDelta * yDelta ) );
        }

        /// <summary>
        /// 给出目标的距离
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double GetDistanceToSqrt( IPoint3D point3D )
        {
            return GetDistanceToSqrt( point3D as IPoint2D );
        }

        /// <summary>
        /// 给出目标的距离
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double GetDistanceToSqrt( Point2D point2D )
        {
            // (防止装箱操作)
            float xDelta = this.Location.X - point2D.X;
            float yDelta = this.Location.Y - point2D.Y;

            return Math.Sqrt( ( xDelta * xDelta ) + ( yDelta * yDelta ) );
        }

        /// <summary>
        /// 给出目标的距离
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double GetDistanceToSqrt( IPoint2D point2D )
        {
            float xDelta = this.Location.X - point2D.X;
            float yDelta = this.Location.Y - point2D.Y;

            return Math.Sqrt( ( xDelta * xDelta ) + ( yDelta * yDelta ) );
        }
        #endregion

        #region zh-CHS 给出物体范围内的道具或人物或对象 | en

        #region zh-CHS 给出 GameEntitys 的数据 | en
        /// <summary>
        /// 给出人物范围内的道具
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public IEnumerable<GameEntityT> GetEntitysInRange<GameEntityT>( int iRange ) where GameEntityT : WorldEntity
        {
            BaseMap tempMap = this.Map;
            if ( tempMap == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "GameEntity.GetEntitysInRange(...) - tempMap == null error!" );

                return NullEnumerable<GameEntityT>.SingletonInstance;
            }

            return tempMap.GetEntitysInRange<GameEntityT>( this.Location, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<GameEntityT> GetEntitysInRange<GameEntityT>( int iRange, IEnumerable<GameEntityT> originalInRange, out GameEntityT[] newInRange, out GameEntityT[] outOfRange ) where GameEntityT : WorldEntity
        {
            List<GameEntityT> newInRangeList = new List<GameEntityT>( LIST_CAPACITY_SIZE );
            List<GameEntityT> outOfRangeList = new List<GameEntityT>( LIST_CAPACITY_SIZE );
            IEnumerable<GameEntityT> returnEnumerable = this.GetEntitysInRange<GameEntityT>( iRange );

            // 获取返回的数据
            Dictionary<GameEntityT, GameEntityT> returnInRangeDictionary = new Dictionary<GameEntityT, GameEntityT>( DICTIONARY_CAPACITY_SIZE );
            foreach ( GameEntityT itemEntity in returnEnumerable )
                returnInRangeDictionary.Add( itemEntity, itemEntity );

            GameEntityT getValue = default( GameEntityT );

            // 获取已经不再范围内的数据
            Dictionary<GameEntityT, GameEntityT> originalInRangeDictionary = new Dictionary<GameEntityT, GameEntityT>( DICTIONARY_CAPACITY_SIZE );
            foreach ( GameEntityT itemEntity in originalInRange )
            {
                // 没有找到数据，表示已经不再范围内了
                if ( returnInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    outOfRangeList.Add( itemEntity );
                
                originalInRangeDictionary.Add( itemEntity, itemEntity );
            }

            // 获取新的在范围内的数据
            foreach ( GameEntityT itemEntity in returnEnumerable )
            {
                // 没有找到数据，表示有新的数据在范围内
                if ( originalInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    newInRangeList.Add( itemEntity );
            }

            newInRange = newInRangeList.ToArray();
            outOfRange = outOfRangeList.ToArray();

            return returnEnumerable;
        }
        #endregion
        
        #region zh-CHS 给出 Items 的数据 | en
        /// <summary>
        /// 给出人物范围内的道具
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public IEnumerable<ItemT> GetItemsInRange<ItemT>( int iRange ) where ItemT : BaseItem
        {
            BaseMap tempMap = this.Map;
            if ( tempMap == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "GameEntity.GetItemsInRange(...) - tempMap == null error!" );

                return NullEnumerable<ItemT>.SingletonInstance;
            }

            return tempMap.GetItemsInRange<ItemT>( this.Location, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<ItemT> GetItemsInRange<ItemT>( int iRange, IEnumerable<ItemT> originalInRange, out ItemT[] newInRange, out ItemT[] outOfRange ) where ItemT : BaseItem
        {
            List<ItemT> newInRangeList = new List<ItemT>( LIST_CAPACITY_SIZE );
            List<ItemT> outOfRangeList = new List<ItemT>( LIST_CAPACITY_SIZE );
            IEnumerable<ItemT> returnEnumerable = this.GetItemsInRange<ItemT>( iRange );

            // 获取返回的数据
            Dictionary<ItemT, ItemT> returnInRangeDictionary = new Dictionary<ItemT, ItemT>( DICTIONARY_CAPACITY_SIZE );
            foreach ( ItemT itemEntity in returnEnumerable )
                returnInRangeDictionary.Add( itemEntity, itemEntity );

            ItemT getValue = default( ItemT );

            // 获取已经不再范围内的数据
            Dictionary<ItemT, ItemT> originalInRangeDictionary = new Dictionary<ItemT, ItemT>( DICTIONARY_CAPACITY_SIZE );
            foreach ( ItemT itemEntity in originalInRange )
            {
                // 没有找到数据，表示已经不再范围内了
                if ( returnInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    outOfRangeList.Add( itemEntity );

                originalInRangeDictionary.Add( itemEntity, itemEntity );
            }

            // 获取新的在范围内的数据
            foreach ( ItemT itemEntity in returnEnumerable )
            {
                // 没有找到数据，表示有新的数据在范围内
                if ( originalInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    newInRangeList.Add( itemEntity );
            }

            newInRange = newInRangeList.ToArray();
            outOfRange = outOfRangeList.ToArray();

            return returnEnumerable;
        }
        #endregion

        #region zh-CHS 给出 Creatures 的数据 | en
        /// <summary>
        /// 给出人物范围内的人物
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public IEnumerable<CreatureT> GetCreaturesInRange<CreatureT>( int iRange ) where CreatureT : BaseCreature
        {
            BaseMap tempMap = this.Map;
            if ( tempMap == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "GameEntity.GetItemsInRange(...) - tempMap == null error!" );

                return NullEnumerable<CreatureT>.SingletonInstance;
            }

            return tempMap.GetCreaturesInRange<CreatureT>( this.Location, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<CreatureT> GetCreaturesInRange<CreatureT>( int iRange, IEnumerable<CreatureT> originalInRange, out CreatureT[] newInRange, out CreatureT[] outOfRange ) where CreatureT : BaseCreature
        {
            List<CreatureT> newInRangeList = new List<CreatureT>( LIST_CAPACITY_SIZE );
            List<CreatureT> outOfRangeList = new List<CreatureT>( LIST_CAPACITY_SIZE );
            IEnumerable<CreatureT> returnEnumerable = this.GetCreaturesInRange<CreatureT>( iRange );

            // 获取返回的数据
            Dictionary<CreatureT, CreatureT> returnInRangeDictionary = new Dictionary<CreatureT, CreatureT>( DICTIONARY_CAPACITY_SIZE );
            foreach ( CreatureT itemEntity in returnEnumerable )
                returnInRangeDictionary.Add( itemEntity, itemEntity );

            CreatureT getValue = default( CreatureT );

            // 获取已经不再范围内的数据
            Dictionary<CreatureT, CreatureT> originalInRangeDictionary = new Dictionary<CreatureT, CreatureT>( DICTIONARY_CAPACITY_SIZE );
            foreach ( CreatureT itemEntity in originalInRange )
            {
                // 没有找到数据，表示已经不再范围内了
                if ( returnInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    outOfRangeList.Add( itemEntity );

                originalInRangeDictionary.Add( itemEntity, itemEntity );
            }

            // 获取新的在范围内的数据
            foreach ( CreatureT itemEntity in returnEnumerable )
            {
                // 没有找到数据，表示有新的数据在范围内
                if ( originalInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    newInRangeList.Add( itemEntity );
            }

            newInRange = newInRangeList.ToArray();
            outOfRange = outOfRangeList.ToArray();

            return returnEnumerable;
        }
        #endregion

        #region zh-CHS 给出 Players 的数据 | en
        /// <summary>
        /// 给出人物范围内的客户端
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public IEnumerable<CharacterT> GetPlayersInRange<CharacterT>( int iRange ) where CharacterT : BaseCharacter
        {
            BaseMap tempMap = this.Map;
            if ( tempMap == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "GameEntity.GetItemsInRange(...) - tempMap == null error!" );

                return NullEnumerable<CharacterT>.SingletonInstance;
            }

            return tempMap.GetCreaturesInRange<CharacterT>( this.Location, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<CharacterT> GetPlayersInRange<CharacterT>( int iRange, IEnumerable<CharacterT> originalInRange, out CharacterT[] newInRange, out CharacterT[] outOfRange ) where CharacterT : BaseCharacter
        {
            List<CharacterT> newInRangeList = new List<CharacterT>( LIST_CAPACITY_SIZE );
            List<CharacterT> outOfRangeList = new List<CharacterT>( LIST_CAPACITY_SIZE );
            IEnumerable<CharacterT> returnEnumerable = this.GetCreaturesInRange<CharacterT>( iRange );

            // 获取返回的数据
            Dictionary<CharacterT, CharacterT> returnInRangeDictionary = new Dictionary<CharacterT, CharacterT>( DICTIONARY_CAPACITY_SIZE );
            foreach ( CharacterT itemEntity in returnEnumerable )
                returnInRangeDictionary.Add( itemEntity, itemEntity );

            CharacterT getValue = default( CharacterT );

            // 获取已经不再范围内的数据
            Dictionary<CharacterT, CharacterT> originalInRangeDictionary = new Dictionary<CharacterT, CharacterT>( DICTIONARY_CAPACITY_SIZE );
            foreach ( CharacterT itemEntity in originalInRange )
            {
                // 没有找到数据，表示已经不再范围内了
                if ( returnInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    outOfRangeList.Add( itemEntity );

                originalInRangeDictionary.Add( itemEntity, itemEntity );
            }

            // 获取新的在范围内的数据
            foreach ( CharacterT itemEntity in returnEnumerable )
            {
                // 没有找到数据，表示有新的数据在范围内
                if ( originalInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    newInRangeList.Add( itemEntity );
            }

            newInRange = newInRangeList.ToArray();
            outOfRange = outOfRangeList.ToArray();

            return returnEnumerable;
        }
        #endregion

        #region zh-CHS 给出 GetAllEntitys 的数据 | en
        /// <summary>
        /// 给出人物范围内的客户端
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public IEnumerable<WorldEntity> GetAllEntitysInRange( int iRange )
        {
            BaseMap tempMap = this.Map;
            if ( tempMap == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "GameEntity.GetItemsInRange(...) - tempMap == null error!" );

                return NullEnumerable<WorldEntity>.SingletonInstance;
            }

            return tempMap.GetAllEntitysInRange( this.Location, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<WorldEntity> GetAllEntitysInRange( int iRange, IEnumerable<WorldEntity> originalInRange, out WorldEntity[] newInRange, out WorldEntity[] outOfRange )
        {
            List<WorldEntity> newInRangeList = new List<WorldEntity>( LIST_CAPACITY_SIZE );
            List<WorldEntity> outOfRangeList = new List<WorldEntity>( LIST_CAPACITY_SIZE );
            IEnumerable<WorldEntity> returnEnumerable = this.GetAllEntitysInRange( iRange );

            // 获取返回的数据
            Dictionary<WorldEntity, WorldEntity> returnInRangeDictionary = new Dictionary<WorldEntity, WorldEntity>( DICTIONARY_CAPACITY_SIZE );
            foreach ( WorldEntity itemEntity in returnEnumerable )
                returnInRangeDictionary.Add( itemEntity, itemEntity );

            WorldEntity getValue = default( WorldEntity );

            // 获取已经不再范围内的数据
            Dictionary<WorldEntity, WorldEntity> originalInRangeDictionary = new Dictionary<WorldEntity, WorldEntity>( DICTIONARY_CAPACITY_SIZE );
            foreach ( WorldEntity itemEntity in originalInRange )
            {
                // 没有找到数据，表示已经不再范围内了
                if ( returnInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    outOfRangeList.Add( itemEntity );

                originalInRangeDictionary.Add( itemEntity, itemEntity );
            }

            // 获取新的在范围内的数据
            foreach ( WorldEntity itemEntity in returnEnumerable )
            {
                // 没有找到数据，表示有新的数据在范围内
                if ( originalInRangeDictionary.TryGetValue( itemEntity, out getValue ) == false )
                    newInRangeList.Add( itemEntity );
            }

            newInRange = newInRangeList.ToArray();
            outOfRange = outOfRangeList.ToArray();

            return returnEnumerable;
        }
        #endregion

        #endregion

        #region zh-CHS 给出人物或道具或位置是否在此物体的范围内 | en
        /// <summary>
        /// 人物是否在范围内
        /// </summary>
        /// <param name="p"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool InRange( WorldEntity checkEntity, int iInRange )
        {
            if ( checkEntity == null )
                throw new Exception( "GameEntity.InRange(...) - checkEntity == null error!" );

            return InRange( checkEntity as IPoint2D, iInRange );
        }

        /// <summary>
        /// 位置是否在范围内
        /// </summary>
        /// <param name="p"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool InRange( Point3D point3D, int iInRange )
        {
            // (防止装箱操作)
            return ( point3D.X >= ( this.Location.X - iInRange ) )
                && ( point3D.X <= ( this.Location.X + iInRange ) )
                && ( point3D.Y >= ( this.Location.Y - iInRange ) )
                && ( point3D.Y <= ( this.Location.Y + iInRange ) );
        }

        /// <summary>
        /// 位置是否在范围内
        /// </summary>
        /// <param name="p"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool InRange( IPoint3D point3D, int iInRange )
        {
            return InRange( point3D as IPoint2D, iInRange );
        }

        /// <summary>
        /// 位置是否在范围内
        /// </summary>
        /// <param name="p"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool InRange( Point2D point2D, int iInRange )
        {
            // (防止装箱操作)
            return ( point2D.X >= ( this.Location.X - iInRange ) )
                && ( point2D.X <= ( this.Location.X + iInRange ) )
                && ( point2D.Y >= ( this.Location.Y - iInRange ) )
                && ( point2D.Y <= ( this.Location.Y + iInRange ) );
        }

        /// <summary>
        /// 位置是否在范围内
        /// </summary>
        /// <param name="p"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool InRange( IPoint2D point2D, int iInRange )
        {
            return ( point2D.X >= ( this.Location.X - iInRange ) )
                && ( point2D.X <= ( this.Location.X + iInRange ) )
                && ( point2D.Y >= ( this.Location.Y - iInRange ) )
                && ( point2D.Y <= ( this.Location.Y + iInRange ) );
        }
        #endregion

        #endregion

        #region zh-CHS 创建一个新的自身人物 | en Method
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private FastCreateInstanceHandler m_ConstructorInstance = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GameEntityT CreateNewInstance<GameEntityT>() where GameEntityT : WorldEntity
        {
            if ( m_ConstructorInstance != null )
            {
                object returnObject = m_ConstructorInstance.Invoke();

                GameEntityT creature = returnObject as GameEntityT;
                if ( creature == null )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "GameEntity.CreateNewInstance(...) - creature == null error!" );
                    return null;
                }

                return creature;
            }
            else
            {
                m_ConstructorInstance = DynamicCalls.GetInstanceCreator( GetType() );
                if ( m_ConstructorInstance == null )
                    throw new Exception( "GameEntity.CreateNewInstance(...) - m_ConstructorInstance == null error!" );

                GameEntityT creature = m_ConstructorInstance.Invoke() as GameEntityT;
                if ( creature == null )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "GameEntity.CreateNewInstance(...) - creature == null error!" );
                    return null;
                }

                return creature;
            }
        }
        #endregion

        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( WorldEntity other )
        {
            if ( other == null )
                return 1;

            return m_Serial.CompareTo( other.Serial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( object xObject )
        {
            return CompareTo( xObject as WorldEntity );
        }

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS Save事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<WorldEntityEventArgs> m_EventSaveWorldEntity;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventSaveWorldEntity = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<WorldEntityEventArgs> SaveWorldEntity
        {
            add
            {
                m_LockEventSaveWorldEntity.Enter();
                {
                    m_EventSaveWorldEntity += value;
                }
                m_LockEventSaveWorldEntity.Exit();
            }
            remove
            {
                m_LockEventSaveWorldEntity.Enter();
                {
                    m_EventSaveWorldEntity -= value;
                }
                m_LockEventSaveWorldEntity.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion
