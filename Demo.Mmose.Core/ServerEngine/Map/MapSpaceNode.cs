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
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Map
{
    /// <summary>
    /// 地图内某个部分的内容及信息(Clients,Mobiles,Items)
    /// </summary>
    public partial class MapSpaceNode
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        internal const int DICTIONARY_CAPACITY_SIZE = 1024;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public MapSpaceNode( BaseMap owner )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="owner"></param>
        public MapSpaceNode( Rectangle3D partitionSpaceRectangle )
        {
            m_SpaceNodeRectangle = partitionSpaceRectangle;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Rectangle3D m_SpaceNodeRectangle = new Rectangle3D();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Rectangle3D SpaceNodeRectangle
        {
            get { return m_SpaceNodeRectangle; }
            set { m_SpaceNodeRectangle = value; }
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private RankIndex m_RankIndex = new RankIndex( -1, -1, -1 );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public RankIndex RankIndex
        {
            get { return m_RankIndex; }
            internal set { m_RankIndex = value; }
       }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_LayerIndex = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint LayerIndex
        {
            get { return m_LayerIndex; }
        }
        
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private volatile SpaceNodeState m_SpaceNodeState = SpaceNodeState.Deactivate;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockSpaceNodeState = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public SpaceNodeState SpaceNodeState
        {
            get { return m_SpaceNodeState; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsLeaf = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsLeaf
        {
            get { return m_IsLeaf; }
            internal set { m_IsLeaf = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MapSpaceNode m_ParentSpaceNode = null;
        #endregion
        /// <summary>
        /// 当前的区域点如果有玩家的话就激活该区域点(true)
        /// 如果没有玩家的话，无效此区域点(false)
        /// </summary>
        public MapSpaceNode Parent
        {
            get { return m_ParentSpaceNode; }
            internal set { m_ParentSpaceNode = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 拥有者的地图
        /// </summary>
        private BaseMap m_Owner = null;
        #endregion
        /// <summary>
        /// 地图点的拥有者(地图)
        /// </summary>
        public BaseMap Owner
        {
            get { return m_Owner; }
            internal set { m_Owner = value; }
        }

        #region zh-CHS Entitys 属性 | en Items Properties
        /// <summary>
        /// 地图点内的所有道具数量
        /// </summary>
        public long EntitysCount
        {
            get { return m_Entitys.Count; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 道具的列表
        /// </summary>
        private SafeDictionary<WorldEntity, WorldEntity> m_Entitys = new SafeDictionary<WorldEntity, WorldEntity>( DICTIONARY_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 地图点内的所有道具数组
        /// </summary>
        /// <returns></returns>
        public WorldEntity[] ToArrayInEntitys()
        {
            return m_Entitys.ToArrayValues();
        }
        #endregion

        #region zh-CHS Items 属性 | en Items Properties
        /// <summary>
        /// 地图点内的所有道具数量
        /// </summary>
        public long ItemsCount
        {
            get { return m_Items.Count; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 道具的列表
        /// </summary>
        private SafeDictionary<BaseItem, BaseItem> m_Items = new SafeDictionary<BaseItem, BaseItem>( DICTIONARY_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 地图点内的所有道具数组
        /// </summary>
        /// <returns></returns>
        public BaseItem[] ToArrayInItems()
        {
            return m_Items.ToArrayValues();
        }
        #endregion

        #region zh-CHS Creature 属性 | en Creature Properties
        /// <summary>
        /// 地图点内的所有人物(npc/playes/monster)数量
        /// </summary>
        public long CreaturesCount
        {
            get { return m_Creatures.Count; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 怪物/NPC的列表
        /// </summary>
        private SafeDictionary<BaseCreature, BaseCreature> m_Creatures = new SafeDictionary<BaseCreature, BaseCreature>( DICTIONARY_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 地图点内的所有人物(npc/monster)数组
        /// </summary>
        /// <returns></returns>
        public BaseCreature[] ToArrayInCreatures()
        {
            return m_Creatures.ToArrayValues();
        }
        #endregion

        #region zh-CHS Players 属性 | en Players Properties
        /// <summary>
        /// 地图点内的所有玩家数量(playes)
        /// </summary>
        public long PlayersCount
        {
            get { return m_Players.Count; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 地图点内的所有玩家
        /// </summary>
        private SafeDictionary<BaseCharacter, BaseCharacter> m_Players = new SafeDictionary<BaseCharacter, BaseCharacter>( DICTIONARY_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 地图点内所有的玩家数组
        /// </summary>
        /// <returns></returns>
        public BaseCharacter[] ToArrayInPlayers()
        {
            return m_Players.ToArrayValues();
        }
        #endregion

        #region zh-CHS MapSpaceNodeState属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的状态机
        /// </summary>
        private MapSpaceNodeState m_MapSpaceNodeState = null;
        #endregion
        /// <summary>
        /// MapSpaceNodeState的状态器(默认为空，可以在需要的时候设置)
        /// </summary>
        public MapSpaceNodeState MapSpaceNodeState
        {
            get { return m_MapSpaceNodeState; }
            protected set { m_MapSpaceNodeState = value; }
        }

        #endregion

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 分割区域点 | en
        /// <summary>
        /// 
        /// </summary>
        public virtual void ProcessPartitionSpace( IPartitionSpaceNode partitionSpaceInterface )
        {
            if ( partitionSpaceInterface == null )
                throw new Exception( "MapSpaceNode.ProcessPartitionSpace(...) - partitionSpaceInterface == null error!" );

            if ( this.EventPartitionSpaceNode != null )
                throw new Exception( "MapSpaceNode.ProcessPartitionSpace(...) - this.EventPartitionSpaceNode != null error!" );

            this.EventInitSpaceNode += new EventHandler<SpaceNodeEventArgs>( partitionSpaceInterface.InitSpaceNode );
            this.EventPartitionSpaceNode += new EventHandler<PartitionSpaceNodeEventArgs>( partitionSpaceInterface.ProcessPartitionSpaceNode );
            this.EventActivateSpaceNode += new EventHandler<ActivateSpaceNodeEventArgs>( partitionSpaceInterface.ActivateSpaceNode );
            this.EventDeactivateSpaceNode += new EventHandler<DeactivateSpaceNodeEventArgs>( partitionSpaceInterface.DeactivateSpaceNode );

            // EventInitSpaceNode
            SpaceNodeEventArgs spaceNodeEventArgs = new SpaceNodeEventArgs( this );
            this.EventInitSpaceNode( this, spaceNodeEventArgs );

            // EventPartitionSpaceNode
            PartitionSpaceNodeEventArgs partitionSpaceNodeEventArgs = new PartitionSpaceNodeEventArgs( this, this.m_Owner );
            this.EventPartitionSpaceNode( this, partitionSpaceNodeEventArgs );

            if ( partitionSpaceNodeEventArgs.PartitionSpace != null )
            {
                m_SpaceNodes = partitionSpaceNodeEventArgs.PartitionSpace;

                for ( int iIndex0 = 0; iIndex0 < m_SpaceNodes.GetLength( 0 ); iIndex0++ )
                {
                    for ( int iIndex1 = 0; iIndex1 < m_SpaceNodes.GetLength( 1 ); iIndex1++ )
                    {
                        for ( int iIndex2 = 0; iIndex2 < m_SpaceNodes.GetLength( 2 ); iIndex2++ )
                        {
                            if ( m_SpaceNodes[iIndex0, iIndex1, iIndex2] != null )
                            {
                                m_SpaceNodes[iIndex0, iIndex1, iIndex2].RankIndex = new RankIndex( iIndex0, iIndex1, iIndex2 );
                                m_SpaceNodes[iIndex0, iIndex1, iIndex2].Parent = this;
                                m_SpaceNodes[iIndex0, iIndex1, iIndex2].Owner = this.Owner;
                                m_SpaceNodes[iIndex0, iIndex1, iIndex2].m_LayerIndex = this.m_LayerIndex + 1;

                                m_SpaceNodes[iIndex0, iIndex1, iIndex2].ProcessPartitionSpace( partitionSpaceInterface );
                            }
                        }
                    }
                }

                m_IsLeaf = false;
            }
        }
        #endregion

        #region zh-CHS 进入或离开区域点 | en
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseItem"></param>
        public void OnEnter( WorldEntity entity )
        {
            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnEnteringMapSpaceNode( entity, this );

            m_Entitys.Add( entity, entity );

            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnEnteredMapSpaceNode( entity, this );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseItem"></param>
        public void OnLeave( WorldEntity entity )
        {
            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnLeavingMapSpaceNode( entity, this );

            m_Entitys.Remove( entity );

            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnLeavedMapSpaceNode( entity, this );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseItem"></param>
        public void OnEnter( BaseItem item )
        {
            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnEnteringMapSpaceNode( item, this );

            m_Items.Add( item, item );

            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnEnteredMapSpaceNode( item, this );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseItem"></param>
        public void OnLeave( BaseItem item )
        {
            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnLeavingMapSpaceNode( item, this );

            m_Items.Remove( item );

            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnLeavedMapSpaceNode( item, this );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseMobile"></param>
        public void OnEnter( BaseCreature creature )
        {
            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnEnteringMapSpaceNode( creature, this );

            m_Creatures.Add( creature, creature );

            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnEnteredMapSpaceNode( creature, this );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseMobile"></param>
        public void OnLeave( BaseCreature creature )
        {
            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnLeavingMapSpaceNode( creature, this );

            m_Creatures.Remove( creature );

            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnLeavedMapSpaceNode( creature, this );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseMobile"></param>
        public void OnEnter( BaseCharacter character )
        {
            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnEnteringMapSpaceNode( character, this );

            m_Players.Add( character, character );

            if ( m_SpaceNodeState != SpaceNodeState.Activate )
            {
                // 如果游戏玩家的列表是空的话,则激活区域点,说明此区域点有玩家存在
                m_LockSpaceNodeState.Enter();
                {
                    if ( this.PlayersCount > 0 && m_SpaceNodeState != SpaceNodeState.Activate )
                    {
                        m_SpaceNodeState = SpaceNodeState.Activate;
                        this.OnActivate();
                    }
                }
                m_LockSpaceNodeState.Exit();
            }

            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnEnteredMapSpaceNode( character, this );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseMobile"></param>
        public void OnLeave( BaseCharacter character )
        {
            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnLeavingMapSpaceNode( character, this );

            m_Players.Remove( character );

            if ( this.PlayersCount == 0 && m_SpaceNodeState != SpaceNodeState.Deactivate)
            {
                // 如果游戏玩家的列表是空的话,则无效区域点,说明此区域点玩家不存在
                m_LockSpaceNodeState.Enter();
                {
                    if ( this.PlayersCount == 0 && m_SpaceNodeState != SpaceNodeState.Deactivate )
                    {
                        m_SpaceNodeState = SpaceNodeState.Deactivate;
                        this.OnDeactivate();
                    }
                }
                m_LockSpaceNodeState.Exit();
            }

            if ( m_MapSpaceNodeState != null )
                m_MapSpaceNodeState.OnLeavedMapSpaceNode( character, this );
        }
        #endregion
        
        #region zh-CHS 激活/无效区域点 | en
        /// <summary>
        /// 激活地图区域点内的BaseItem或BaseMobile,当有新的玩家加入的时候会激活,表示怪物可以攻击了,没有玩家的时候可以不用动了.
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "OnActivate调用与OnDeactivate调用总是同步(按顺序)进行回调的:警告!" )]
        protected virtual void OnActivate()
        {
            if ( this.EventActivateSpaceNode != null )
            {
                ActivateSpaceNodeEventArgs eventArgs = new ActivateSpaceNodeEventArgs( this );
                this.EventActivateSpaceNode( this, eventArgs );
            }
        }

        /// <summary>
        /// 无效地图区域点内的BaseItem或BaseMobile
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "OnDeactivate调用与OnActivate调用总是同步(按顺序)进行回调的:警告!" )]
        protected virtual void OnDeactivate()
        {
            if ( this.EventDeactivateSpaceNode != null )
            {
                DeactivateSpaceNodeEventArgs eventArgs = new DeactivateSpaceNodeEventArgs( this );
                this.EventDeactivateSpaceNode( this, eventArgs );
            }
        }
        #endregion

        #endregion

        #region zh-CHS 私有事件 | en Private Event

        #region zh-CHS PartitionSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<SpaceNodeEventArgs> EventInitSpaceNode;
        #endregion

        #region zh-CHS PartitionSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<PartitionSpaceNodeEventArgs> EventPartitionSpaceNode;
        #endregion

        #region zh-CHS ActivateMapSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ActivateSpaceNodeEventArgs> EventActivateSpaceNode;
        #endregion

        #region zh-CHS DeactivateMapSpaceNode事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<DeactivateSpaceNodeEventArgs> EventDeactivateSpaceNode;
        #endregion

        #endregion
    }
}
#endregion

