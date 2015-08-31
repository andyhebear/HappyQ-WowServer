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
using Demo.Mmose.Core.Common.SupportSlice;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Map;
using Demo.Mmose.Core.Entity.GameObject;
using Demo.Mmose.Core.Timer;
using Demo.Mmose.Core.Common.LockFree;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace Demo.Mmose.Core.World
{
    /// <summary>
    /// 
    /// </summary>
    public class MmorpgWorld<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> : BaseWorld
        where MapT : BaseMap
        where ItemT : BaseItem
        where ItemTemplateT : BaseItemTemplate
        where GameObjectT : BaseGameObject
        where GameObjectTemplateT : BaseGameObjectTemplate
        where CreatureT : BaseCreature
        where CreatureTemplateT : BaseCreatureTemplate
        where CharacterT : BaseCharacter
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int MANAGER_CAPACITY_SIZE = 1024;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public MmorpgWorld()
        {
            base.EventStartSlice += new EventHandler<BaseWorldEventArgs>( this.StartSlice );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Map属性 | en Map Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private MapManager<MapT> m_MapManager = new MapManager<MapT>( MANAGER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public MapManager<MapT> MapManager
        {
            get { return m_MapManager; }
            protected set { m_MapManager = value; }
        }

        #endregion

        #region zh-CHS Item属性 | en Item Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ItemManager<ItemT> m_ItemManager = new ItemManager<ItemT>( MANAGER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ItemManager<ItemT> ItemManager
        {
            get { return m_ItemManager; }
            protected set { m_ItemManager = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ItemTemplateManager<ItemTemplateT> m_ItemTemplateManager = new ItemTemplateManager<ItemTemplateT>( MANAGER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ItemTemplateManager<ItemTemplateT> ItemTemplateManager
        {
            get { return m_ItemTemplateManager; }
            protected set { m_ItemTemplateManager = value; }
        }

        #endregion

        #region zh-CHS GameObject属性 | en GameObject Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private GameObjectManager<GameObjectT> m_GameObjectManager = new GameObjectManager<GameObjectT>( MANAGER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public GameObjectManager<GameObjectT> GameObjectManager
        {
            get { return m_GameObjectManager; }
            protected set { m_GameObjectManager = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private GameObjectTemplateManager<GameObjectTemplateT> m_GameObjectTemplateHandler = new GameObjectTemplateManager<GameObjectTemplateT>( MANAGER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public GameObjectTemplateManager<GameObjectTemplateT> GameObjectTemplateManager
        {
            get { return m_GameObjectTemplateHandler; }
            protected set { m_GameObjectTemplateHandler = value; }
        }

        #endregion

        #region zh-CHS Creature属性 | en Creature Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CreatureManager<CreatureT> m_CreatureManager = new CreatureManager<CreatureT>( MANAGER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CreatureManager<CreatureT> CreatureManager
        {
            get { return m_CreatureManager; }
            protected set { m_CreatureManager = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CreatureTemplateManager<CreatureTemplateT> m_CreatureTemplateManager = new CreatureTemplateManager<CreatureTemplateT>( MANAGER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CreatureTemplateManager<CreatureTemplateT> CreatureTemplateManager
        {
            get { return m_CreatureTemplateManager; }
            protected set { m_CreatureTemplateManager = value; }
        }

        #endregion

        #region zh-CHS Character属性 | en Character Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterManager<CharacterT> m_CharacterManager = new CharacterManager<CharacterT>( MANAGER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CharacterManager<CharacterT> CharacterManager
        {
            get { return m_CharacterManager; }
            protected set { m_CharacterManager = value; }
        }

        #endregion

        #region zh-CHS UpdateWorldSpeed属性 | en UpdateWorldSpeed Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 每秒跟新一次
        /// </summary>
        private TimeSpan m_UpdateWorldSpeed = TimeSpan.FromSeconds( 1.0 );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan UpdateWorldSpeed
        {
            get { return m_UpdateWorldSpeed; }
            set { this.StartUpdateWorld( value ); }
        }

        #endregion

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 更新世界系统 | en

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 更新世界的时间片
        /// </summary>
        private TimeSlice m_UpdateWorldTimeSlice = null;
        #endregion
        /// <summary>
        /// 开始更新世界
        /// </summary>
        public void StartUpdateWorld( TimeSpan updateWorldSpeed )
        {
            m_UpdateWorldSpeed = updateWorldSpeed;

            if ( m_UpdateWorldTimeSlice != null )
                m_UpdateWorldTimeSlice.IntervalTime = m_UpdateWorldSpeed; // 如果存在了就只改变间隔时间
            else
                // 启动更新世界的时间片
                m_UpdateWorldTimeSlice = TimeSlice.StartTimeSlice( m_UpdateWorldSpeed, new TimeSliceCallback( this.OnUpdateWorld ) );
        }

        #region zh-CHS 私有方法 | en Private Methods
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int UPDATE_BREAK_COUNT = 24;
        #endregion
        /// <summary>
        /// 更新世界服务
        /// </summary>
        private void OnUpdateWorld()
        {
            List<ISupportSlice> updateList = new List<ISupportSlice>( UPDATE_BREAK_COUNT );

            CharacterT[] characterArray = this.CharacterManager.ToArray();
            for ( int iIndex = 0; iIndex < characterArray.Length; iIndex++ )
            {
                updateList.Add( characterArray[iIndex] );

                if ( updateList.Count >= UPDATE_BREAK_COUNT )
                {
                    m_NeedUpdateQueue.Enqueue( updateList.ToArray() );

                    updateList.Clear();
                    // 如果有数据则马上处理
                    base.SetWorldSignal();
                }
            }

            CreatureT[] creatureArray = this.CreatureManager.ToArray();
            for ( int iIndex = 0; iIndex < creatureArray.Length; iIndex++ )
            {
                updateList.Add( creatureArray[iIndex] );

                if ( updateList.Count >= UPDATE_BREAK_COUNT )
                {
                    m_NeedUpdateQueue.Enqueue( updateList.ToArray() );

                    updateList.Clear();
                    // 如果有数据则马上处理
                    base.SetWorldSignal();
                }
            }

            GameObjectT[] gameObjectArray = this.GameObjectManager.ToArray();
            for ( int iIndex = 0; iIndex < gameObjectArray.Length; iIndex++ )
            {
                updateList.Add( gameObjectArray[iIndex] );

                if ( updateList.Count >= UPDATE_BREAK_COUNT )
                {
                    m_NeedUpdateQueue.Enqueue( updateList.ToArray() );

                    updateList.Clear();
                    // 如果有数据则马上处理
                    base.SetWorldSignal();
                }
            }

            if ( updateList.Count > 0 )
            {
                m_NeedUpdateQueue.Enqueue( updateList.ToArray() );

                // 如果有数据则马上处理
                base.SetWorldSignal();
            }
        }
        #endregion

        #endregion

        #endregion

        #region zh-CHS 私有的事件处理函数 | en Private Event Handlers
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private LockFreeQueue<ISupportSlice[]> m_NeedUpdateQueue = new LockFreeQueue<ISupportSlice[]>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSlice( object sender, BaseWorldEventArgs eventArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // WOW世界的全部物体开始更新

            // 现在的时间
            DateTime nowTime = DateTime.Now;

            // 用于计算经过的时间（因为Stopwatch的计算速度比DateTime.Now快近3倍）
            Stopwatch updateTime = Stopwatch.StartNew();

            ISupportSlice[] updateSliceArray = m_NeedUpdateQueue.Dequeue();
            if ( updateSliceArray != null )
            {
                for ( int iIndex = 0; iIndex < updateSliceArray.Length; iIndex++ )
                {
                    var updateSlice = updateSliceArray[iIndex];

                    // 进入锁定
                    if ( updateSlice.InLockProcessSlice() == false )
                        continue;

                    // 只允许单线程内处理调用
                    updateSlice.OnProcessSlice( nowTime + updateTime.Elapsed );

                    // 离开锁定
                    updateSlice.OutLockProcessSlice();
                }

                // 先处理部分，然后再次处理剩下的
                base.SetWorldSignal();
            }

            // 计算结束
            updateTime.Stop();
        }
        #endregion
    }

    /// <summary>
    /// 缺省
    /// </summary>
    public class MmorpgWorld : MmorpgWorld<BaseMap, BaseItem, BaseItemTemplate, BaseGameObject, BaseGameObjectTemplate, BaseCreature, BaseCreatureTemplate, BaseCharacter>
    {
        // default
    }
}
#endregion