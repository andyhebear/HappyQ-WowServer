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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
#endregion

namespace Demo.Mmose.Core.Map
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class MapEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public MapEventArgs( BaseMap map )
        {
            m_Map = map;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseMap m_Map = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseMap Map
        {
            get { return m_Map; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class PartitionSpaceEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public PartitionSpaceEventArgs( BaseMap map )
            : base( map )
        {
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MapSpaceNode[, ,] m_PartitionSpace = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public MapSpaceNode[, ,] PartitionSpace
        {
            get { return m_PartitionSpace; }
            set { m_PartitionSpace = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class PartitionSpaceNodeEventArgs : PartitionSpaceEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public PartitionSpaceNodeEventArgs( MapSpaceNode partitionSpaceNode, BaseMap map )
            : base( map )
        {
            m_PartitionSpaceNode = partitionSpaceNode;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MapSpaceNode m_PartitionSpaceNode = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public MapSpaceNode PartitionSpaceNode
        {
            get { return m_PartitionSpaceNode; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class GetSpaceNodeEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public GetSpaceNodeEventArgs( float x, float y, float z, BaseMap map )
            : base( map )
        {
            m_X = x;
            m_Y = y;
            m_Z = z;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_X;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float X
        {
            get { return m_X; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Y;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Y
        {
            get { return m_Y; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Z;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Z
        {
            get { return m_Z; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MapSpaceNode m_SpaceNode = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public MapSpaceNode SpaceNode
        {
            get { return m_SpaceNode; }
            set { m_SpaceNode = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class GetGetSpaceNodesInRangeEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public GetGetSpaceNodesInRangeEventArgs( float x, float y, float z, float fRange, BaseMap map )
            : base( map )
        {
            m_X = x;
            m_Y = y;
            m_Z = z;
            m_Range = fRange;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_X;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float X
        {
            get { return m_X; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Y;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Y
        {
            get { return m_Y; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Z;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Z
        {
            get { return m_Z; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Range;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Range
        {
            get { return m_Range; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MapSpaceNode[] m_SpaceNodesInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public MapSpaceNode[] SpaceNodes
        {
            get { return m_SpaceNodesInRange; }
            set { m_SpaceNodesInRange = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CanSpawnEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CanSpawnEventArgs( float x, float y, float z, BaseMap map )
            : base( map )
        {
            m_X = x;
            m_Y = y;
            m_Z = z;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_X;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float X
        {
            get { return m_X; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Y;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Y
        {
            get { return m_Y; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Z;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Z
        {
            get { return m_Z; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCanSpawn = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCanSpawn
        {
            get { return m_IsCanSpawn; }
            set { m_IsCanSpawn = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class PlayersInRangeEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public PlayersInRangeEventArgs( float x, float y, float z, float fRange, BaseMap map )
            : base( map )
        {
            m_X = x;
            m_Y = y;
            m_Z = z;
            m_Range = fRange;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_X;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float X
        {
            get { return m_X; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Y;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Y
        {
            get { return m_Y; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Z;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Z
        {
            get { return m_Z; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Range;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Range
        {
            get { return m_Range; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsPlayersInRange = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsPlayersInRange
        {
            get { return m_IsPlayersInRange; }
            set { m_IsPlayersInRange = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CreaturesInRangeEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CreaturesInRangeEventArgs( float x, float y, float z, float fRange, BaseMap map )
            : base( map )
        {
            m_X = x;
            m_Y = y;
            m_Z = z;
            m_Range = fRange;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_X;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float X
        {
            get { return m_X; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Y;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Y
        {
            get { return m_Y; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Z;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Z
        {
            get { return m_Z; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Range;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Range
        {
            get { return m_Range; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCreaturesInRange = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCreaturesInRange
        {
            get { return m_IsCreaturesInRange; }
            set { m_IsCreaturesInRange = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class WorldEntityEnteringMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public WorldEntityEnteringMapEventArgs( WorldEntity entity, BaseMap map )
            : base( map )
        {
            m_Entity = entity;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private WorldEntity m_Entity = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_Entity; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class WorldEntityEnteredMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public WorldEntityEnteredMapEventArgs( WorldEntity entity, BaseMap map )
            : base( map )
        {
            m_Entity = entity;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private WorldEntity m_Entity = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_Entity; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class WorldEntityLeavingMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public WorldEntityLeavingMapEventArgs( WorldEntity entity, BaseMap map )
            : base( map )
        {
            m_Entity = entity;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private WorldEntity m_Entity = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_Entity; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class WorldEntityLeavedMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public WorldEntityLeavedMapEventArgs( WorldEntity entity, BaseMap map )
            : base( map )
        {
            m_Entity = entity;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private WorldEntity m_Entity = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_Entity; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class WorldEntityMovingInMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public WorldEntityMovingInMapEventArgs( Point3D oldLocation, WorldEntity entity, BaseMap map )
            : base( map )
        {
            m_OldLocation = oldLocation;
            m_Entity = entity;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private WorldEntity m_Entity = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_Entity; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class WorldEntityMovedInMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public WorldEntityMovedInMapEventArgs( Point3D oldLocation, WorldEntity entity, BaseMap map )
            : base( map )
        {
            m_OldLocation = oldLocation;
            m_GameEntity = entity;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private WorldEntity m_GameEntity = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_GameEntity; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class ItemEnteringMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ItemEnteringMapEventArgs( BaseItem item, BaseMap map )
            : base( map )
        {
            m_Item = item;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseItem m_Item = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseItem Item
        {
            get { return m_Item; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class ItemEnteredMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ItemEnteredMapEventArgs( BaseItem item, BaseMap map )
            : base( map )
        {
            m_Item = item;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseItem m_Item = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseItem Item
        {
            get { return m_Item; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class ItemLeavingMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ItemLeavingMapEventArgs( BaseItem item, BaseMap map )
            : base( map )
        {
            m_Item = item;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseItem m_Item = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseItem Item
        {
            get { return m_Item; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class ItemLeavedMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ItemLeavedMapEventArgs( BaseItem item, BaseMap map )
            : base( map )
        {
            m_Item = item;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseItem m_Item = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseItem Item
        {
            get { return m_Item; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class ItemMovingInMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ItemMovingInMapEventArgs( Point3D oldLocation, BaseItem item, BaseMap map )
            : base( map )
        {
            m_OldLocation = oldLocation;
            m_Item = item;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseItem m_Item = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseItem Item
        {
            get { return m_Item; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class ItemMovedInMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ItemMovedInMapEventArgs( Point3D oldLocation, BaseItem item, BaseMap map )
            : base( map )
        {
            m_OldLocation = oldLocation;
            m_Item = item;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseItem m_Item = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseItem Item
        {
            get { return m_Item; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CreatureEnteringMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CreatureEnteringMapEventArgs( BaseCreature creature, BaseMap map )
            : base( map )
        {
            m_Creature = creature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCreature m_Creature = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCreature Creature
        {
            get { return m_Creature; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class CreatureEnteredMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CreatureEnteredMapEventArgs( BaseCreature creature, BaseMap map )
            : base( map )
        {
            m_Creature = creature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCreature m_Creature = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCreature Creature
        {
            get { return m_Creature; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CreatureLeavingMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CreatureLeavingMapEventArgs( BaseCreature creature, BaseMap map )
            : base( map )
        {
            m_Creature = creature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCreature m_Creature = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCreature Creature
        {
            get { return m_Creature; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class CreatureLeavedMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CreatureLeavedMapEventArgs( BaseCreature creature, BaseMap map )
            : base( map )
        {
            m_Creature = creature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCreature m_Creature = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCreature Creature
        {
            get { return m_Creature; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CreatureMovingInMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CreatureMovingInMapEventArgs( Point3D oldLocation, BaseCreature creature, BaseMap map )
            : base( map )
        {
            m_OldLocation = oldLocation;
            m_Creature = creature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCreature m_Creature = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCreature Creature
        {
            get { return m_Creature; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class CreaturedMoveInMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CreaturedMoveInMapEventArgs( Point3D oldLocation, BaseCreature creature, BaseMap map )
            : base( map )
        {
            m_OldLocation = oldLocation;
            m_Creature = creature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCreature m_Creature = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCreature Creature
        {
            get { return m_Creature; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CharacterEnteringMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CharacterEnteringMapEventArgs( BaseCharacter character, BaseMap map )
            : base( map )
        {
            m_Character = character;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCharacter m_Character = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCharacter Character
        {
            get { return m_Character; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class CharacterEnteredMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CharacterEnteredMapEventArgs( BaseCharacter character, BaseMap map )
            : base( map )
        {
            m_Character = character;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCharacter m_Character = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCharacter Character
        {
            get { return m_Character; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CharacterLeavingMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CharacterLeavingMapEventArgs( BaseCharacter character, BaseMap map )
            : base( map )
        {
            m_Character = character;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCharacter m_Character = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCharacter Character
        {
            get { return m_Character; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class CharacterLeavedMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CharacterLeavedMapEventArgs( BaseCharacter character, BaseMap map )
            : base( map )
        {
            m_Character = character;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCharacter m_Character = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCharacter Character
        {
            get { return m_Character; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CharacterMovingInMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="character"></param>
        public CharacterMovingInMapEventArgs( Point3D oldLocation, BaseCharacter character, BaseMap map )
            : base( map )
        {
            m_OldLocation = oldLocation;
            m_Character = character;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCharacter m_Character = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCharacter Character
        {
            get { return m_Character; }
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
    /// BaseMap的事件数据类
    /// </summary>
    public class CharacterMovedInMapEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="character"></param>
        public CharacterMovedInMapEventArgs( Point3D oldLocation, BaseCharacter character, BaseMap map )
            : base( map )
        {
            m_OldLocation = oldLocation;
            m_Character = character;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCharacter m_Character = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCharacter Character
        {
            get { return m_Character; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class SpaceNodeEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public SpaceNodeEventArgs( MapSpaceNode mapSpaceNode )
        {
            m_SpaceNode = mapSpaceNode;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private MapSpaceNode m_SpaceNode = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public MapSpaceNode SpaceNode
        {
            get { return m_SpaceNode; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class ActivateSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ActivateSpaceNodeEventArgs( MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class DeactivateSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public DeactivateSpaceNodeEventArgs( MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class WorldEntityEnterSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public WorldEntityEnterSpaceNodeEventArgs( WorldEntity entity, MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
            m_Entity = entity;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private WorldEntity m_Entity = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_Entity; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class WorldEntityLeaveSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public WorldEntityLeaveSpaceNodeEventArgs( WorldEntity entity, MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
            m_Entity = entity;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private WorldEntity m_Entity = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_Entity; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class ItemEnterSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ItemEnterSpaceNodeEventArgs( BaseItem item, MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
            m_Item = item;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseItem m_Item = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseItem Item
        {
            get { return m_Item; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class ItemLeaveSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ItemLeaveSpaceNodeEventArgs( BaseItem item, MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
            m_Item = item;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseItem m_Item = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseItem Item
        {
            get { return m_Item; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CreatureEnterSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CreatureEnterSpaceNodeEventArgs( BaseCreature creature, MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
            m_Creature = creature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCreature m_Creature = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCreature Creature
        {
            get { return m_Creature; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CreatureLeaveSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CreatureLeaveSpaceNodeEventArgs( BaseCreature creature, MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
            m_Creature = creature;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCreature m_Creature = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCreature Creature
        {
            get { return m_Creature; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CharacterEnterSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CharacterEnterSpaceNodeEventArgs( BaseCharacter character, MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
            m_Character = character;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCharacter m_Character = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCharacter Character
        {
            get { return m_Character; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class CharacterLeaveSpaceNodeEventArgs : SpaceNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public CharacterLeaveSpaceNodeEventArgs( BaseCharacter character, MapSpaceNode mapSpaceNode )
            : base( mapSpaceNode )
        {
            m_Character = character;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseCharacter m_Character = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseCharacter Character
        {
            get { return m_Character; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMap的事件数据类
    /// </summary>
    public class ProcessSliceEventArgs : MapEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="creature"></param>
        public ProcessSliceEventArgs( DateTime updateTime, BaseMap map )
            : base( map )
        {
            m_DateTime = updateTime;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private DateTime m_DateTime = DateTime.MinValue;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public DateTime UpdateTime
        {
            get { return m_DateTime; }
        }
        #endregion
    }
    #endregion
}
#endregion
