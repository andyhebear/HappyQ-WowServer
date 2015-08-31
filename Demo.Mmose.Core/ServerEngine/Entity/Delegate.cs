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
using Demo.Mmose.Core.Map;
#endregion

namespace Demo.Mmose.Core.Entity
{
    /// <summary>
    /// gameEntity的事件数据类
    /// </summary>
    public class WorldEntityEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public WorldEntityEventArgs( WorldEntity gameEntity )
        {
            m_GameEntity = gameEntity;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private WorldEntity m_GameEntity = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_GameEntity; }
        }
        #endregion
    }

    /// <summary>
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatingSerialEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatingSerialEventArgs( Serial serial, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewSerial = serial;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_NewSerial = Serial.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Serial NewSerial
        {
            get { return m_NewSerial; }
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
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatedSerialEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatedSerialEventArgs( Serial serial, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldSerial = serial;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_OldSerial = Serial.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Serial OldSerial
        {
            get { return m_OldSerial; }
        }
        #endregion
    }

    /// <summary>
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatingXEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatingXEventArgs( float x, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewX = x;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_NewX = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float NewX
        {
            get { return m_NewX; }
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
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatedXEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatedXEventArgs( float x, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldX = x;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_OldX = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float OldX
        {
            get { return m_OldX; }
        }
        #endregion
    }

    /// <summary>
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatingYEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatingYEventArgs( float y, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewY = y;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_NewY = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float NewY
        {
            get { return m_NewY; }
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
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatedYEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatedYEventArgs( float y, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldY = y;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_OldY = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float OldY
        {
            get { return m_OldY; }
        }
        #endregion
    }

    /// <summary>
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatingZEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatingZEventArgs( float z, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewZ = z;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_NewZ = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float NewZ
        {
            get { return m_NewZ; }
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
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatedZEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatedZEventArgs( float z, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldZ = z;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_OldZ = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float OldZ
        {
            get { return m_OldZ; }
        }
        #endregion
    }

    /// <summary>
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatingOrientationEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatingOrientationEventArgs( float orientation, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewOrientation = orientation;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_NewOrientation = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float NewOrientation
        {
            get { return m_NewOrientation; }
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
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatedOrientationEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatedOrientationEventArgs( float orientation, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldOrientation = orientation;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_OldOrientation = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float OldOrientation
        {
            get { return m_OldOrientation; }
        }
        #endregion
    }

    /// <summary>
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatingLocationEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatingLocationEventArgs( Point3D location, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewLocation = location;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_NewLocation = Point3D.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D NewLocation
        {
            get { return m_NewLocation; }
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
    /// gameEntity的事件数据类
    /// </summary>
    public class UpdatedLocationEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="gameEntity"></param>
        public UpdatedLocationEventArgs( Point3D location, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldLocation = location;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation = Point3D.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatingMapEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatingMapEventArgs( BaseMap baseMap, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewMap = baseMap;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseMap m_NewMap = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseMap NewMap
        {
            get { return m_NewMap; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatedMapEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatedMapEventArgs( BaseMap baseMap, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldMap = baseMap;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseMap m_OldMap = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseMap OldMap
        {
            get { return m_OldMap; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatingMapSpaceNodeEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatingMapSpaceNodeEventArgs( MapSpaceNode mapSpaceNode, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewMapSpaceNode = mapSpaceNode;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MapSpaceNode m_NewMapSpaceNode = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public MapSpaceNode NewMapSpaceNode
        {
            get { return m_NewMapSpaceNode; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatedMapSpaceNodeEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatedMapSpaceNodeEventArgs( MapSpaceNode mapSpaceNode, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldMapSpaceNode = mapSpaceNode;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MapSpaceNode m_OldMapSpaceNode = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public MapSpaceNode OldMapSpaceNode
        {
            get { return m_OldMapSpaceNode; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatingAIEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatingAIEventArgs( IArtificialIntelligence artificialIntelligence, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewArtificialIntelligence = artificialIntelligence;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private IArtificialIntelligence m_NewArtificialIntelligence = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public IArtificialIntelligence NewAI
        {
            get { return m_NewArtificialIntelligence; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatedAIEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatedAIEventArgs( IArtificialIntelligence artificialIntelligence, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldArtificialIntelligence = artificialIntelligence;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private IArtificialIntelligence m_OldArtificialIntelligence = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public IArtificialIntelligence OldAI
        {
            get { return m_OldArtificialIntelligence; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class MovingToCallEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public MovingToCallEventArgs( Point3D location, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewLocation = location;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_NewLocation = Point3D.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D NewLocation
        {
            get { return m_NewLocation; }
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
    public class MovedToCallEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public MovedToCallEventArgs( Point3D location, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldLocation = location;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation = Point3D.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D OldLocation
        {
            get { return m_OldLocation; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class MovingToWorldEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public MovingToWorldEventArgs( Point3D location, BaseMap newMap, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_NewLocation = location;
            m_NewMap = newMap;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_NewLocation = Point3D.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point3D NewLocation
        {
            get { return m_NewLocation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseMap m_NewMap = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseMap NewMap
        {
            get { return m_NewMap; }
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
    public class MovedToWorldEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public MovedToWorldEventArgs( Point3D oldLocation, BaseMap oldMap, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_OldLocation = oldLocation;
            m_OldMap = oldMap;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Point3D m_OldLocation = Point3D.Zero;
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
        /// 
        /// </summary>
        private BaseMap m_OldMap = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseMap OldMap
        {
            get { return m_OldMap; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class ProcessSliceEventArgs : WorldEntityEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public ProcessSliceEventArgs( DateTime updateTime, WorldEntity gameEntity ) :
            base( gameEntity )
        {
            m_DateTime = updateTime;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_DateTime = DateTime.MinValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            get { return m_DateTime; }
        }
        #endregion
    }
}
#endregion