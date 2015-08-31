#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
//
// This file is a part of the G.O.S.E(Game Online Server Engine) for .NET.
//
//           2007-2008 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions outlined
// in the accompanying license agreement.
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using Demo.Mmose.Core.Util;
using DevExpress.Xpo;
#endregion

namespace Demo.Wow.Database.Ver1a
{
    #region zh-CHS 人物 定义 | en 
    #endregion

    #region zh-CHS 怪物/NPC 定义 | en
    #endregion

    #region zh-CHS 宠物 定义 | en 
    #endregion

    #region zh-CHS 尸体 定义 | en 
    #endregion

    #region zh-CHS 团队系统 定义 | en 
    #endregion

    #region zh-CHS 行会 定义 | en 
    #endregion

    #region zh-CHS 拍卖系统 定义 | en 
    #endregion

    #region zh-CHS 邮件系统 定义 | en 
    #endregion

    #region zh-CHS 服务程序的运行时间  定义 | en 
    #endregion

    #region zh-CHS 记录日志 定义 | en
    #endregion



    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Instance : XPObject
    {
        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CharacterGuid;
        #endregion
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public long CharacterGuid
        {
            get { return m_CharacterGuid; }
            set { SetPropertyValue<long>( "CharacterGuid", ref m_CharacterGuid, value ); }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.AfterConstruction();
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public class Characters_Ticket : XPObject
    {
        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CharacterGuid;
        #endregion
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public long CharacterGuid
        {
            get { return m_CharacterGuid; }
            set { SetPropertyValue<long>( "CharacterGuid", ref m_CharacterGuid, value ); }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.AfterConstruction();
        }
        #endregion
    }

    /// <summary>
    ///  刷NPC的所标记的刷NPC的内容
    /// </summary>
    public class SpawnNPCs : XPObject
    {
        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_NPCGuid;
        #endregion
        /// <summary>
        /// NPC的GUID
        /// </summary>
        [Indexed]
        public long NPCGuid
        {
            get { return m_NPCGuid; }
            set { SetPropertyValue<long>( "NPCGuid", ref m_NPCGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_MapID;
        #endregion
        /// <summary>
        /// NPC所在地图的ID
        /// </summary>
        public int MapID
        {
            get { return m_MapID; }
            set { SetPropertyValue<int>( "MapID", ref m_MapID, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PositionX;
        #endregion
        /// <summary>
        /// NPC的 X 坐标
        /// </summary>
        public int PositionX
        {
            get { return m_PositionX; }
            set { SetPropertyValue<int>( "PositionX", ref m_PositionX, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PositionY;
        #endregion
        /// <summary>
        /// NPC的 Y 坐标
        /// </summary>
        public int PositionY
        {
            get { return m_PositionY; }
            set { SetPropertyValue<int>( "PositionY", ref m_PositionY, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Direction;
        #endregion
        /// <summary>
        /// NPC的方向
        /// </summary>
        public int Direction
        {
            get { return m_Direction; }
            set { SetPropertyValue<int>( "Direction", ref m_Direction, value ); }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            NPCGuid = 0;
            MapID = 0;
            PositionX = 0;
            PositionY = 0;
            Direction = 0;

            base.AfterConstruction();
        }
        #endregion
    }

    /// <summary>
    /// 刷怪点的所标记的刷怪内容
    /// </summary>
    public class SpawnMonsters : XPObject
    {
        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MobileGUID;
        #endregion
        /// <summary>
        /// 怪物的GUID
        /// </summary>
        [Indexed]
        public long MobileGUID
        {
            get { return m_MobileGUID; }
            set { SetPropertyValue<long>( "MobileGUID", ref m_MobileGUID, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_MapID;
        #endregion
        /// <summary>
        /// 刷怪点地图的ID
        /// </summary>
        public int MapID
        {
            get { return m_MapID; }
            set { SetPropertyValue<int>( "MapID", ref m_MapID, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Count;
        #endregion
        /// <summary>
        /// 所需刷怪的数量(在下面的范围内随机刷的刷怪点)
        /// </summary>
        public int Count
        {
            get { return m_Count; }
            set { SetPropertyValue<int>( "Count", ref m_Count, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Points;
        #endregion
        /// <summary>
        /// 刷怪的数据数量和位置x和位置y(count|x,y|x,y|...|...)至少3个坐标点以上,是个一或多个三角的范围,怪物在此三角范围内刷怪
        /// </summary>
        //[SqlType( SqlType.Text )]
        public string Points
        {
            get { return m_Points; }
            set { SetPropertyValue<string>( "Points", ref m_Points, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_MinRespawn;
        #endregion
        /// <summary>
        /// 刷怪所需的最小数量(范围内少于此怪物数量将马上刷怪,忽略刷怪的时间间隔)
        /// </summary>
        public int MinRespawn
        {
            get { return m_MinRespawn; }
            set { SetPropertyValue<int>( "MinRespawn", ref m_MinRespawn, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_RespawnTime;
        #endregion
        /// <summary>
        /// 刷怪的时间间隔(据刷怪的类型: 可能是怪物死亡后刷怪的时间间隔,或按时间间隔来持续的刷怪直到所需刷怪的数量位置......等)
        /// </summary>
        public int RespawnTime
        {
            get { return m_RespawnTime; }
            set { SetPropertyValue<int>( "RespawnTime", ref m_RespawnTime, value ); }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            MobileGUID = 0;
            MapID = 0;
            Count = 0;
            Points = "3|5000,5000|5100,5000|5000,5100";
            RespawnTime = 30;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion