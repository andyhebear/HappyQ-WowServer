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
// 
// optimize BaseMap : Thank DanielChen

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
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.World;
using Demo.Mmose.Core.Server.Language;
#endregion

// 可移动的物体
// 可视
// 更新血
// 移动
// 攻击
// 给出经验和道具
// 给出是否升级
// 检测是否上面已经更新则发送相应的数据包

// 道具的物体
// 清除已无效的掉落道具
// 可视
// 装备上
// 道具状态改变

// 地图
// 所有的道具
// 所有的人物

// 地图 -> 人物&道具

namespace Demo.Mmose.Core.Map
{
    // 地图的信息
    //////////////////////////////////////////////////////////////////////////
    // 给出某个坐标点范围内的数据(Mobile/Item/Client)
    // 
    // 
    // 
    // 
    // 
    // 
    // 

    /// <summary>
    /// 
    /// </summary>
    public partial class BaseMap : IComparable, IComparable<BaseMap>
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int LIST_CAPACITY_SMALL_SIZE = 20;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public BaseMap()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapID"></param>
        /// <param name="mapIndex"></param>
        /// <param name="fileIndex"></param>
        /// <param name="iWidth"></param>
        /// <param name="iHeight"></param>
        /// <param name="iSeason"></param>
        /// <param name="strName"></param>
        /// <param name="mapRules"></param>
        public BaseMap( Serial mapId, Rectangle3D mapRectangle, string strMapName )
        {
            m_MapId = mapId;
            m_MapRectangle = mapRectangle;
            m_MapName = strMapName;
        }

        #region zh-CHS 分割地图内的区域点 | en
        /// <summary>
        /// 
        /// </summary>
        public void InitPartitionSpace( IPartitionSpace partitionSpace )
        {
            if ( partitionSpace == null )
                throw new ArgumentNullException( "partitionSpace" );

            if ( this.EventInitMap != null )
                throw new InvalidOperationException( LanguageString.SingletonInstance.ExceptionString.BaseMapString001 );

            // InitMap
            MapEventArgs mapEventArgs = new MapEventArgs( this );
            partitionSpace.InitMap( this, mapEventArgs );

            // PartitionSpace
            PartitionSpaceEventArgs partitionSpaceEventArgs = new PartitionSpaceEventArgs( this );
            partitionSpace.ProcessPartitionSpace( this, partitionSpaceEventArgs );

            if ( partitionSpaceEventArgs.PartitionSpace == null )
                throw new NullReferenceException( "PartitionSpaceEventArgs.PartitionSpac没有初始化和设置！" );
            else
            {
                this.EventInitMap += new EventHandler<MapEventArgs>( partitionSpace.InitMap );
                this.EventPartitionSpace += new EventHandler<PartitionSpaceEventArgs>( partitionSpace.ProcessPartitionSpace );
                this.EventGetSpaceNode += new EventHandler<GetSpaceNodeEventArgs>( partitionSpace.GetSpaceNod );
                this.EventGetSpaceNodesInRange += new EventHandler<GetGetSpaceNodesInRangeEventArgs>( partitionSpace.GetSpaceNodesInRange );

                m_SpaceNodes = partitionSpaceEventArgs.PartitionSpace;
            }

            for ( int iIndex0 = 0; iIndex0 < m_SpaceNodes.GetLength( 0 ); iIndex0++ )
            {
                for ( int iIndex1 = 0; iIndex1 < m_SpaceNodes.GetLength( 1 ); iIndex1++ )
                {
                    for ( int iIndex2 = 0; iIndex2 < m_SpaceNodes.GetLength( 2 ); iIndex2++ )
                    {
                        if ( m_SpaceNodes[iIndex0, iIndex1, iIndex2] != null )
                        {
                            m_SpaceNodes[iIndex0, iIndex1, iIndex2].RankIndex = new RankIndex( iIndex0, iIndex1, iIndex2 );
                            m_SpaceNodes[iIndex0, iIndex1, iIndex2].Owner = this;

                            m_SpaceNodes[iIndex0, iIndex1, iIndex2].ProcessPartitionSpace( partitionSpace );
                        }
                    }
                }
            }
        }
        #endregion

        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        Rectangle3D m_MapRectangle = new Rectangle3D();
        #endregion
        /// <summary>
        /// 地图的大小
        /// </summary>
        public Rectangle3D MapRectangle
        {
            get { return m_MapRectangle; }
            set { m_MapRectangle = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_MapId;
        #endregion
        /// <summary>
        /// 地图的ID
        /// </summary>
        public Serial MapId
        {
            get { return m_MapId; }
            set { m_MapId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 地图名
        /// </summary>
        private string m_MapName;
        #endregion
        /// <summary>
        /// 地图名
        /// </summary>
        public string MapName
        {
            get { return m_MapName; }
            set { m_MapName = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 地图的全部地图点的数据
        /// </summary>
        private MapSpaceNode[, ,] m_SpaceNodes = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public MapSpaceNode[, ,] SpaceNodes
        {
            get { return m_SpaceNodes; }
        }

        #region zh-CHS BaseMapState属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的状态机
        /// </summary>
        private BaseMapState m_BaseMapState = null;
        #endregion
        /// <summary>
        /// BaseMapState的状态器(默认为空，可以在需要的时候设置)
        /// </summary>
        public BaseMapState BaseMapState
        {
            get { return m_BaseMapState; }
            protected set { m_BaseMapState = value; }
        }

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

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 给出坐标获取地图内的某个区域点 | en
        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public MapSpaceNode GetSpaceNode( Point2D point2D )
        {
            return GetSpaceNode( point2D.X, point2D.Y, 0 );
        }

        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public MapSpaceNode GetSpaceNode( IPoint2D point2D )
        {
            return GetSpaceNode( point2D.X, point2D.Y, 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public MapSpaceNode GetSpaceNode( float x, float y )
        {
            return GetSpaceNode( x, y, 0 );
        }

        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="point3D"></param>
        /// <returns></returns>
        public MapSpaceNode GetSpaceNode( Point3D point3D )
        {
            return GetSpaceNode( point3D.X, point3D.Y, point3D.Z );
        }

        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public MapSpaceNode GetSpaceNode( IPoint3D point3D )
        {
            return GetSpaceNode( point3D.X, point3D.Y, point3D.Z );
        }

        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public MapSpaceNode GetSpaceNode( float x, float y, float z )
        {
            if ( this.EventGetSpaceNode != null )
            {
                GetSpaceNodeEventArgs eventArgs = new GetSpaceNodeEventArgs( x, y, z, this );
                this.EventGetSpaceNode( this, eventArgs );

                return eventArgs.SpaceNode;
            }

            return null;
        }
        #endregion

        #region zh-CHS 给出坐标范围获取地图内的多个区域点 | en
        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public MapSpaceNode[] GetSpaceNodesInRange( Point2D point2D, float fRange )
        {
            return GetSpaceNodesInRange( point2D.X, point2D.Y, 0, fRange );
        }

        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public MapSpaceNode[] GetSpaceNodesInRange( IPoint2D point2D, float fRange )
        {
            return GetSpaceNodesInRange( point2D.X, point2D.Y, 0, fRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public MapSpaceNode[] GetSpaceNodesInRange( float x, float y, float fRange )
        {
            return GetSpaceNodesInRange( x, y, 0, fRange );
        }

        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="point3D"></param>
        /// <returns></returns>
        public MapSpaceNode[] GetSpaceNodesInRange( Point3D point3D, float fRange )
        {
            return GetSpaceNodesInRange( point3D.X, point3D.Y, point3D.Z, fRange );
        }

        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public MapSpaceNode[] GetSpaceNodesInRange( IPoint3D point3D, float fRange )
        {
            return GetSpaceNodesInRange( point3D.X, point3D.Y, point3D.Z, fRange );
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private readonly static MapSpaceNode[] s_NullSpaceNodeArray = new MapSpaceNode[0];
        #endregion
        /// <summary>
        /// 给出x,y点的地图该点的数据
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public MapSpaceNode[] GetSpaceNodesInRange( float x, float y, float z, float fRange )
        {
            if ( this.EventGetSpaceNodesInRange != null )
            {
                GetGetSpaceNodesInRangeEventArgs eventArgs = new GetGetSpaceNodesInRangeEventArgs( x, y, z, Math.Abs( fRange ), this );
                this.EventGetSpaceNodesInRange( this, eventArgs );

                return eventArgs.SpaceNodes;
            }

            return s_NullSpaceNodeArray;
        }
        #endregion

        #region zh-CHS 进入或离开地图区域点 | en

        /// <summary>
        /// 道具进入新的地图区域点
        /// </summary>
        /// <param name="item"></param>
        public bool OnEnter( WorldEntity entity )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnEnteringMap( entity, this ) == true )
                    return false;
            }

            MapSpaceNode mapSpaceNode = this.GetSpaceNode( entity );
            if ( mapSpaceNode == null )
                return false;
            else
            {
                if ( mapSpaceNode != entity.MapSpaceNode )
                {
                    mapSpaceNode.OnEnter( entity );
                    entity.MapSpaceNode = mapSpaceNode;
                    entity.Map = this;
                }
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnEnteredMap( entity, this );

            return true;
        }

        /// <summary>
        /// 道具进入新的地图区域点
        /// </summary>
        /// <param name="item"></param>
        public bool OnEnter( BaseItem item )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnEnteringMap( item, this ) == true )
                    return false;
            }

            MapSpaceNode mapSpaceNode = this.GetSpaceNode( item );
            if ( mapSpaceNode == null )
                return false;
            else
            {
                if ( mapSpaceNode != item.MapSpaceNode )
                {
                    mapSpaceNode.OnEnter( item );
                    item.MapSpaceNode = mapSpaceNode;
                    item.Map = this;
                }
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnEnteredMap( item, this );

            return true;
        }

        /// <summary>
        /// 人物进入新的地图区域点
        /// </summary>
        /// <param name="m"></param>
        public bool OnEnter( BaseCreature creature )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnEnteringMap( creature, this ) == true )
                    return false;
            }

            MapSpaceNode mapSpaceNode = this.GetSpaceNode( creature );
            if ( mapSpaceNode == null )
                return false;
            else
            {
                if ( mapSpaceNode != creature.MapSpaceNode )
                {
                    mapSpaceNode.OnEnter( creature );
                    creature.MapSpaceNode = mapSpaceNode;
                    creature.Map = this;
                }
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnEnteredMap( creature, this );

            return true;
        }

        /// <summary>
        /// 人物进入新的地图区域点
        /// </summary>
        /// <param name="m"></param>
        public bool OnEnter( BaseCharacter character )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnEnteringMap( character, this ) == true )
                    return false;
            }

            MapSpaceNode mapSpaceNode = this.GetSpaceNode( character );
            if ( mapSpaceNode == null )
                return false;
            else
            {
                if ( mapSpaceNode != character.MapSpaceNode )
                {
                    mapSpaceNode.OnEnter( character );
                    character.MapSpaceNode = mapSpaceNode;
                    character.Map = this;
                }
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnEnteredMap( character, this );

            return true;
        }

        /// <summary>
        /// 道具离开新的地图区域点
        /// </summary>
        /// <param name="item"></param>
        public bool OnLeave( WorldEntity entity )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnLeavingMap( entity, this ) == true )
                    return false;
            }

            MapSpaceNode mapSpaceNode = this.GetSpaceNode( entity );
            if ( mapSpaceNode == null )
                return false;
            else
            {
                if ( mapSpaceNode != entity.MapSpaceNode )
                {
                    mapSpaceNode.OnLeave( entity );
                    entity.MapSpaceNode = null;
                    entity.Map = null;
                }
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnLeavedMap( entity, this );

            return true;
        }

        /// <summary>
        /// 道具离开新的地图区域点
        /// </summary>
        /// <param name="item"></param>
        public bool OnLeave( BaseItem item )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnLeavingMap( item, this ) == true )
                    return false;
            }

            MapSpaceNode mapSpaceNode = this.GetSpaceNode( item );
            if ( mapSpaceNode == null )
                return false;
            else
            {
                if ( mapSpaceNode != item.MapSpaceNode )
                {
                    mapSpaceNode.OnLeave( item );
                    item.MapSpaceNode = null;
                    item.Map = null;
                }
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnLeavedMap( item, this );

            return true;
        }

        /// <summary>
        /// 人物离开新的地图区域点
        /// </summary>
        /// <param name="m"></param>
        public bool OnLeave( BaseCreature creature )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnLeavingMap( creature, this ) == true )
                    return false;
            }

            MapSpaceNode mapSpaceNode = this.GetSpaceNode( creature );
            if ( mapSpaceNode == null )
                return false;
            else
            {
                if ( mapSpaceNode != creature.MapSpaceNode )
                {
                    mapSpaceNode.OnLeave( creature );
                    creature.MapSpaceNode = null;
                    creature.Map = null;
                }
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnLeavedMap( creature, this );

            return true;
        }

        /// <summary>
        /// 人物离开新的地图区域点
        /// </summary>
        /// <param name="m"></param>
        public bool OnLeave( BaseCharacter character )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnLeavingMap( character, this ) == true )
                    return false;
            }

            MapSpaceNode mapSpaceNode = this.GetSpaceNode( character );
            if ( mapSpaceNode == null )
                return false;
            else
            {
                if ( mapSpaceNode != character.MapSpaceNode )
                {
                    mapSpaceNode.OnLeave( character );
                    character.MapSpaceNode = null;
                    character.Map = null;
                }
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnLeavedMap( character, this );

            return true;
        }

        /// <summary>
        /// 道具移动到旧的地图区域点, 并离开新的地图区域点
        /// </summary>
        /// <param name="oldLocation"></param>
        /// <param name="item"></param>
        public bool OnMove( Point3D oldLocation, WorldEntity entity )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnMoving( oldLocation, entity, this ) == true )
                    return false;
            }

            MapSpaceNode oldMapSpaceNode = this.GetSpaceNode( oldLocation );
            if ( oldMapSpaceNode == null )
                return false;

            MapSpaceNode newMapSpaceNode = this.GetSpaceNode( entity.Location );
            if ( newMapSpaceNode == null )
                return false;

            if ( oldMapSpaceNode != newMapSpaceNode )
            {
                oldMapSpaceNode.OnLeave( entity );

                newMapSpaceNode.OnEnter( entity );
                entity.MapSpaceNode = newMapSpaceNode;
                entity.Map = this;
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnMoved( oldLocation, entity, this );

            return true;
        }

        /// <summary>
        /// 道具移动到旧的地图区域点, 并离开新的地图区域点
        /// </summary>
        /// <param name="oldLocation"></param>
        /// <param name="item"></param>
        public bool OnMove( Point3D oldLocation, BaseItem item )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnMoving( oldLocation, item, this ) == true )
                    return false;
            }

            MapSpaceNode oldMapSpaceNode = this.GetSpaceNode( oldLocation );
            if ( oldMapSpaceNode == null )
                return false;

            MapSpaceNode newMapSpaceNode = this.GetSpaceNode( item.Location );
            if ( newMapSpaceNode == null )
                return false;

            if ( oldMapSpaceNode != newMapSpaceNode )
            {
                oldMapSpaceNode.OnLeave( item );

                newMapSpaceNode.OnEnter( item );
                item.MapSpaceNode = newMapSpaceNode;
                item.Map = this;
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnMoved( oldLocation, item, this );

            return true;
        }

        /// <summary>
        /// 人物移动到新的地图区域点, 并离开旧的地图区域点
        /// </summary>
        /// <param name="oldLocation"></param>
        /// <param name="m"></param>
        public bool OnMove( Point3D oldLocation, BaseCreature creature )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnMoving( oldLocation, creature, this ) == true )
                    return false;
            }

            MapSpaceNode oldMapSpaceNode = this.GetSpaceNode( oldLocation );
            if ( oldMapSpaceNode == null )
                return false;

            MapSpaceNode newMapSpaceNode = this.GetSpaceNode( creature.Location );
            if ( newMapSpaceNode == null )
                return false;

            if ( oldMapSpaceNode != newMapSpaceNode )
            {
                oldMapSpaceNode.OnLeave( creature );

                newMapSpaceNode.OnEnter( creature );
                creature.MapSpaceNode = newMapSpaceNode;
                creature.Map = this;
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnMoved( oldLocation, creature, this );

            return true;
        }

        /// <summary>
        /// 人物移动到新的地图区域点, 并离开旧的地图区域点
        /// </summary>
        /// <param name="oldLocation"></param>
        /// <param name="m"></param>
        public bool OnMove( Point3D oldLocation, BaseCharacter character )
        {
            if ( m_BaseMapState != null )
            {
                if ( m_BaseMapState.OnMoving( oldLocation, character, this ) == true )
                    return false;
            }

            MapSpaceNode oldMapSpaceNode = this.GetSpaceNode( oldLocation );
            if ( oldMapSpaceNode == null )
                return false;

            MapSpaceNode newMapSpaceNode = this.GetSpaceNode( character.Location );
            if ( newMapSpaceNode == null )
                return false;

            if ( oldMapSpaceNode != newMapSpaceNode )
            {
                oldMapSpaceNode.OnLeave( character );

                newMapSpaceNode.OnEnter( character );
                character.MapSpaceNode = newMapSpaceNode;
                character.Map = this;
            }

            if ( m_BaseMapState != null )
                m_BaseMapState.OnMoved( oldLocation, character, this );

            return true;
        }
        #endregion

        #region zh-CHS 给出某个坐标点范围内的数据(GameEntity/BaseCreature/BaseItem/BaseCharacter/AllGameEntity) | en

        #region zh-CHS 给出 GameEntitys 的数据 | en
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<GameEntityT> GetEntitysInRange<GameEntityT>( Point3D point3D, int iRange ) where GameEntityT : WorldEntity
        {
            return GetEntitysInRange<GameEntityT>( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<GameEntityT> GetEntitysInRange<GameEntityT>( IPoint3D point3D, int iRange ) where GameEntityT : WorldEntity
        {
            return GetEntitysInRange<GameEntityT>( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<GameEntityT> GetEntitysInRange<GameEntityT>( float x, float y, float z, int iRange ) where GameEntityT : WorldEntity
        {
            MapSpaceNode[] mapSpaceNodeArray = this.GetSpaceNodesInRange( x, y, z, iRange );
            if ( mapSpaceNodeArray == null )
                yield break;

            List<WorldEntity[]> entityArrayList = new List<WorldEntity[]>( LIST_CAPACITY_SMALL_SIZE );

            for ( int iIndex = 0; iIndex < mapSpaceNodeArray.Length; iIndex++ )
                entityArrayList.Add( mapSpaceNodeArray[iIndex].ToArrayInEntitys() );

            Rectangle3D rectangle3D = new Rectangle3D( new Point3D( x - iRange, y - iRange, z - iRange ), new Point3D( x + iRange, y + iRange, z + iRange ) );

            foreach ( WorldEntity[] gameEntityArray in entityArrayList )
            {
                for ( int iIndex = 0; iIndex < gameEntityArray.Length; iIndex++ )
                {
                    GameEntityT gameEntityT = gameEntityArray[iIndex] as GameEntityT;
                    if ( gameEntityT == default( GameEntityT ) )
                        continue;

                    if ( rectangle3D.Contains( gameEntityT.Location ) == false )
                        continue;

                    yield return gameEntityT;
                }
            }
        }
        #endregion

        #region zh-CHS 给出 Items 的数据 | en
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<ItemT> GetItemsInRange<ItemT>( Point3D point3D, int iRange ) where ItemT : BaseItem
        {
            return GetItemsInRange<ItemT>( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<ItemT> GetItemsInRange<ItemT>( IPoint3D point3D, int iRange ) where ItemT : BaseItem
        {
            return GetItemsInRange<ItemT>( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<ItemT> GetItemsInRange<ItemT>( float x, float y, float z, int iRange ) where ItemT : BaseItem
        {
            MapSpaceNode[] mapSpaceNodeArray = this.GetSpaceNodesInRange( x, y, z, iRange );
            if ( mapSpaceNodeArray == null )
                yield break;

            List<BaseItem[]> itemArrayList = new List<BaseItem[]>( LIST_CAPACITY_SMALL_SIZE );

            for ( int iIndex = 0; iIndex < mapSpaceNodeArray.Length; iIndex++ )
                itemArrayList.Add( mapSpaceNodeArray[iIndex].ToArrayInItems() );

            Rectangle3D rectangle3D = new Rectangle3D( new Point3D( x - iRange, y - iRange, z - iRange ), new Point3D( x + iRange, y + iRange, z + iRange ) );

            foreach ( BaseItem[] itemArray in itemArrayList )
            {
                for ( int iIndex = 0; iIndex < itemArray.Length; iIndex++ )
                {
                    ItemT itemT = itemArray[iIndex] as ItemT;
                    if ( itemT == default( ItemT ) )
                        continue;

                    if ( rectangle3D.Contains( itemT.Location ) == false )
                        continue;

                    yield return itemT;
                }
            }
        }
        #endregion

        #region zh-CHS 给出 Creatures 的数据 | en
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<CreatureT> GetCreaturesInRange<CreatureT>( Point3D point3D, int iRange ) where CreatureT : BaseCreature
        {
            return GetCreaturesInRange<CreatureT>( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<CreatureT> GetCreaturesInRange<CreatureT>( IPoint3D point3D, int iRange ) where CreatureT : BaseCreature
        {
            return GetCreaturesInRange<CreatureT>( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<CreatureT> GetCreaturesInRange<CreatureT>( float x, float y, float z, int iRange ) where CreatureT : BaseCreature
        {
            MapSpaceNode[] mapSpaceNodeArray = this.GetSpaceNodesInRange( x, y, z, iRange );
            if ( mapSpaceNodeArray == null )
                yield break;

            List<BaseCreature[]> creatureArrayList = new List<BaseCreature[]>( LIST_CAPACITY_SMALL_SIZE );

            for ( int iIndex = 0; iIndex < mapSpaceNodeArray.Length; iIndex++ )
                creatureArrayList.Add( mapSpaceNodeArray[iIndex].ToArrayInCreatures() );

            Rectangle3D rectangle3D = new Rectangle3D( new Point3D( x - iRange, y - iRange, z - iRange ), new Point3D( x + iRange, y + iRange, z + iRange ) );

            foreach ( BaseCreature[] creatureArray in creatureArrayList )
            {
                for ( int iIndex = 0; iIndex < creatureArray.Length; iIndex++ )
                {
                    CreatureT creatureT = creatureArray[iIndex] as CreatureT;
                    if ( creatureT == default( CreatureT ) )
                        continue;

                    if ( rectangle3D.Contains( creatureT.Location ) == false )
                        continue;

                    yield return creatureT;
                }
            }
        }
        #endregion

        #region zh-CHS 给出 Players 的数据 | en
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<CharacterT> GetPlayersInRange<CharacterT>( Point3D point3D, int iRange ) where CharacterT : BaseCharacter
        {
            return GetPlayersInRange<CharacterT>( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<CharacterT> GetPlayersInRange<CharacterT>( IPoint3D point3D, int iRange ) where CharacterT : BaseCharacter
        {
            return GetPlayersInRange<CharacterT>( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<CharacterT> GetPlayersInRange<CharacterT>( float x, float y, float z, int iRange ) where CharacterT : BaseCharacter
        {
            MapSpaceNode[] mapSpaceNodeArray = this.GetSpaceNodesInRange( x, y, z, iRange );
            if ( mapSpaceNodeArray == null )
                yield break;

            List<BaseCharacter[]> characterArrayList = new List<BaseCharacter[]>( LIST_CAPACITY_SMALL_SIZE );

            for ( int iIndex = 0; iIndex < mapSpaceNodeArray.Length; iIndex++ )
                characterArrayList.Add( mapSpaceNodeArray[iIndex].ToArrayInPlayers() );

            Rectangle3D rectangle3D = new Rectangle3D( new Point3D( x - iRange, y - iRange, z - iRange ), new Point3D( x + iRange, y + iRange, z + iRange ) );
            
            foreach ( BaseCharacter[] characterArray in characterArrayList )
            {
                for ( int iIndex = 0; iIndex < characterArray.Length; iIndex++ )
                {
                    CharacterT characterT = characterArray[iIndex] as CharacterT;
                    if ( characterT == default( CharacterT ) )
                        continue;

                    if ( rectangle3D.Contains( characterT.Location ) == false )
                        continue;

                    yield return characterT;
                }
            }
        }
        #endregion

        #region zh-CHS 给出 GetAllEntitys 的数据 | en
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<WorldEntity> GetAllEntitysInRange( Point3D point3D, int iRange )
        {
            return GetAllEntitysInRange( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<WorldEntity> GetAllEntitysInRange( IPoint3D point3D, int iRange )
        {
            return GetAllEntitysInRange( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public IEnumerable<WorldEntity> GetAllEntitysInRange( float x, float y, float z, int iRange )
        {
            MapSpaceNode[] mapSpaceNodeArray = this.GetSpaceNodesInRange( x, y, z, iRange );
            if ( mapSpaceNodeArray == null )
                yield break;

            List<WorldEntity[]> entityArrayList = new List<WorldEntity[]>( LIST_CAPACITY_SMALL_SIZE );

            for ( int iIndex = 0; iIndex < mapSpaceNodeArray.Length; iIndex++ )
            {
                MapSpaceNode MapSpaceNode = mapSpaceNodeArray[iIndex];

                entityArrayList.Add( MapSpaceNode.ToArrayInEntitys() );
                entityArrayList.Add( MapSpaceNode.ToArrayInItems() );
                entityArrayList.Add( MapSpaceNode.ToArrayInCreatures() );
                entityArrayList.Add( MapSpaceNode.ToArrayInPlayers() );
            }

            Rectangle3D rectangle3D = new Rectangle3D( new Point3D( x - iRange, y - iRange, z - iRange ), new Point3D( x + iRange, y + iRange, z + iRange ) );
            
            foreach ( WorldEntity[] gameEntityArray in entityArrayList )
            {
                for ( int iIndex = 0; iIndex < gameEntityArray.Length; iIndex++ )
                {
                    WorldEntity gameEntity = gameEntityArray[iIndex];
                    if ( gameEntity == null )
                        continue;

                    if ( rectangle3D.Contains( gameEntity.Location ) == false )
                        continue;

                    yield return gameEntity;
                }
            }
        }
        #endregion

        #endregion

        #region zh-CHS 在区域内的某个坐标点是否可刷怪 | en
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <returns></returns>
        public bool CanSpawn( Point3D point3D )
        {
            return CanSpawn( point3D.X, point3D.Y, point3D.Z );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <returns></returns>
        public bool CanSpawn( IPoint3D point3D )
        {
            return CanSpawn( point3D.X, point3D.Y, point3D.Z );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point2D"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public bool CanSpawn( Point2D point2D, float z )
        {
            return CanSpawn( point2D.X, point2D.Y, z );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point2D"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public bool CanSpawn( IPoint2D point2D, float z )
        {
            return CanSpawn( point2D.X, point2D.Y, z );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public bool CanSpawn( float x, float y, float z )
        {
            EventHandler<CanSpawnEventArgs> tempEventArgs = m_EventCanSpawn;
            if ( tempEventArgs != null )
            {
                CanSpawnEventArgs eventArgs = new CanSpawnEventArgs( x, y, z, this );
                tempEventArgs( this, eventArgs );

                return eventArgs.IsCanSpawn;
            }

            return true;
        }
        #endregion

        #region zh-CHS 地图区域点是否有玩家存在 | en
        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool PlayersInRange( Point2D point2D, int iRange )
        {
            return PlayersInRange( point2D.X, point2D.Y, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool PlayersInRange( IPoint2D point2D, int iRange )
        {
            return PlayersInRange( point2D.X, point2D.Y, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool PlayersInRange( float x, float y, int iRange )
        {
            return PlayersInRange( x, y, 0, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool PlayersInRange( Point3D point3D, int iRange )
        {
            return PlayersInRange( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool PlayersInRange( IPoint3D point3D, int iRange )
        {
            return PlayersInRange( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool PlayersInRange( float x, float y, float z, int iRange )
        {
            IEnumerable<BaseCharacter> enumerable = this.GetPlayersInRange<BaseCharacter>( x, y, z, iRange );
            if ( enumerable == null )
                return false;

            bool bIsPlayersInRange = false;

            foreach ( BaseCharacter character in enumerable )
            {
                bIsPlayersInRange = true; // > 1
                break;
            }

            return bIsPlayersInRange;
        }
        #endregion

        #region zh-CHS 地图区域点是否有人物存在 | en
        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool CreaturesInRange( Point2D point2D, int iRange )
        {
            return CreaturesInRange( point2D.X, point2D.Y, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool CreaturesInRange( IPoint2D point2D, int iRange )
        {
            return CreaturesInRange( point2D.X, point2D.Y, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool CreaturesInRange( float x, float y, int iRange )
        {
            return CreaturesInRange( x, y, 0, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool CreaturesInRange( Point3D point3D, int iRange )
        {
            return CreaturesInRange( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool CreaturesInRange( IPoint3D point3D, int iRange )
        {
            return CreaturesInRange( point3D.X, point3D.Y, point3D.Z, iRange );
        }

        /// <summary>
        /// 检查某个区域内是否有玩家存在
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="iRange"></param>
        /// <returns></returns>
        public bool CreaturesInRange( float x, float y, float z, int iRange )
        {
            IEnumerable<BaseCreature> enumerable = this.GetCreaturesInRange<BaseCreature>( x, y, z, iRange );
            if ( enumerable == null )
                return false;

            bool bIsCreaturesInRange = false;

            foreach ( BaseCharacter character in enumerable )
            {
                bIsCreaturesInRange = true; // > 1
                break;
            }

            return bIsCreaturesInRange;
        }
        #endregion

        #region zh-CHS 确保坐标点在地图的边界内 | en
        /// <summary>
        /// 确保Point2D坐标点在地图的边界内
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public Point2D Bound( Point2D point2D )
        {
            return Bound( point2D.X, point2D.Y );
        }

        /// <summary>
        /// 确保Point2D坐标点在地图的边界内
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public Point2D Bound( IPoint2D point2D )
        {
            return Bound( point2D.X, point2D.Y );
        }

        /// <summary>
        /// 确保x,y在地图的边界内
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        public Point2D Bound( float x, float y )
        {
            float newX = 0;
            float newY = 0;

            if ( x < m_MapRectangle.Start.X )
                newX = m_MapRectangle.Start.X;
            else if ( x > m_MapRectangle.End.X )
                newX = m_MapRectangle.End.X;
            else
                newX = x;

            if ( y < m_MapRectangle.Start.Y )
                newY = m_MapRectangle.Start.Y;
            else if ( y > m_MapRectangle.End.Y )
                newY = m_MapRectangle.End.Y;
            else
                newY = y;

            return new Point2D( newX, newY );
        }

        /// <summary>
        /// 确保Point3D坐标点在地图的边界内
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public Point3D Bound( Point3D point3D )
        {
            return Bound( point3D.X, point3D.Y, point3D.Z );
        }

        /// <summary>
        /// 确保Point3D坐标点在地图的边界内
        /// </summary>
        /// <param name="point2D"></param>
        /// <returns></returns>
        public Point3D Bound( IPoint3D point3D )
        {
            return Bound( point3D.X, point3D.Y, point3D.Z );
        }

        /// <summary>
        /// 确保x,y,z在地图的边界内
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        public Point3D Bound( float x, float y, float z )
        {
            float newX = 0;
            float newY = 0;
            float newZ = 0;

            if ( x < m_MapRectangle.Start.X )
                newX = m_MapRectangle.Start.X;
            else if ( x > m_MapRectangle.End.X )
                newX = m_MapRectangle.End.X;
            else
                newX = x;

            if ( y < m_MapRectangle.Start.Y )
                newY = m_MapRectangle.Start.Y;
            else if ( y > m_MapRectangle.End.Y )
                newY = m_MapRectangle.End.Y;
            else
                newY = y;

            if ( z < m_MapRectangle.Start.Z )
                newZ = m_MapRectangle.Start.Z;
            else if ( z > m_MapRectangle.End.Z )
                newZ = m_MapRectangle.End.Z;
            else
                newZ = z;

            return new Point3D( newX, newY, newZ );
        }
        #endregion

        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_MapName;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherBaseMap"></param>
        /// <returns></returns>
        public int CompareTo( BaseMap otherMap )
        {
            if ( otherMap == null )
                return 1;

            return m_MapId.CompareTo( otherMap.m_MapId );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public int CompareTo( object xObject )
        {
            return CompareTo( xObject as BaseMap );
        }

        #endregion

        #region zh-CHS 私有事件 | en Private Event

        #region zh-CHS InitMap事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<MapEventArgs> EventInitMap;
        #endregion

        #region zh-CHS PartitionSpace事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<PartitionSpaceEventArgs> EventPartitionSpace;
        #endregion

        #region zh-CHS GetSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<GetSpaceNodeEventArgs> EventGetSpaceNode;
        #endregion

        #region zh-CHS GetGetSpaceNodesInRange事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<GetGetSpaceNodesInRangeEventArgs> EventGetSpaceNodesInRange;
        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS CanSpawn事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<CanSpawnEventArgs> m_EventCanSpawn;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventCanSpawn = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CanSpawnEventArgs> CanSpawnCall
        {
            add
            {
                m_LockEventCanSpawn.Enter();
                {
                    m_EventCanSpawn += value;
                }
                m_LockEventCanSpawn.Exit();
            }
            remove
            {
                m_LockEventCanSpawn.Enter();
                {
                    m_EventCanSpawn -= value;
                }
                m_LockEventCanSpawn.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion

