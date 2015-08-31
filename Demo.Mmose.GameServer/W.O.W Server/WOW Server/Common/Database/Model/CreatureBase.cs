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
using DevExpress.Xpo;
#endregion

namespace Demo.Wow.Database.Ver1a
{
    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public class CreatureBase : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CreatureBase() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CreatureBase( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CreatureTemplateGuid;
        #endregion
        /// <summary>
        /// 游戏人物所处的帐号的ID
        /// </summary>
        [Indexed]
        public long CreatureTemplateGuid
        {
            get { return m_CreatureTemplateGuid; }
            set { SetPropertyValue<long>( "CreatureTemplateGuid", ref m_CreatureTemplateGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MapId;
        #endregion
        /// <summary>
        /// 人物的地图
        /// </summary>
        [Indexed]
        public long MapId
        {
            get { return m_MapId; }
            set { SetPropertyValue<long>( "MapId", ref m_MapId, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ZoneId;
        #endregion
        /// <summary>
        /// 人物的地域
        /// </summary>
        [Indexed]
        public long ZoneId
        {
            get { return m_ZoneId; }
            set { SetPropertyValue<long>( "ZoneId", ref m_ZoneId, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PositionX;
        #endregion
        /// <summary>
        /// 人物 所在的 X坐标
        /// </summary>
        public float PositionX
        {
            get { return m_PositionX; }
            set { SetPropertyValue<float>( "PositionX", ref m_PositionX, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PositionY;
        #endregion
        /// <summary>
        /// 人物 所在的 Y坐标
        /// </summary>
        public float PositionY
        {
            get { return m_PositionY; }
            set { SetPropertyValue<float>( "PositionY", ref m_PositionY, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PositionZ;
        #endregion
        /// <summary>
        /// 人物 所在的 Z坐标
        /// </summary>
        public float PositionZ
        {
            get { return m_PositionZ; }
            set { SetPropertyValue<float>( "PositionZ", ref m_PositionZ, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Orientation;
        #endregion
        /// <summary>
        /// 人物 所在的 方向
        /// North(北方) is 0*Pi => 0.00000
        /// East(东方) is Pi/2 => 1.57079
        /// South(南方) is Pi => 3.14159
        /// West(西方) is 3*Pi/2 => 4.71238
        /// </summary>
        public float Orientation
        {
            get { return m_Orientation; }
            set { SetPropertyValue<float>( "Orientation", ref m_Orientation, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_SpawnTimeSecs;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public DateTime SpawnTimeSecs
        {
            get { return m_SpawnTimeSecs; }
            set { SetPropertyValue<DateTime>( "SpawnTimeSecs", ref m_SpawnTimeSecs, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_SpawnDistance;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float SpawnDistance
        {
            get { return m_SpawnDistance; }
            set { SetPropertyValue<float>( "SpawnDistance", ref m_SpawnDistance, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_SpawnPositionX;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float SpawnPositionX
        {
            get { return m_SpawnPositionX; }
            set { SetPropertyValue<float>( "SpawnPositionX", ref m_SpawnPositionX, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_SpawnPositionY;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float SpawnPositionY
        {
            get { return m_SpawnPositionY; }
            set { SetPropertyValue<float>( "SpawnPositionY", ref m_SpawnPositionY, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_SpawnPositionZ;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float SpawnPositionZ
        {
            get { return m_SpawnPositionZ; }
            set { SetPropertyValue<float>( "SpawnPositionZ", ref m_SpawnPositionZ, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_SpawnPositionOrientation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float SpawnPositionOrientation
        {
            get { return m_SpawnPositionOrientation; }
            set { SetPropertyValue<float>( "SpawnPositionOrientation", ref m_SpawnPositionOrientation, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CurrentHealth;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long CurrentHealth
        {
            get { return m_CurrentHealth; }
            set { SetPropertyValue<long>( "CurrentHealth", ref m_CurrentHealth, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CurrentMana;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long CurrentMana
        {
            get { return m_CurrentMana; }
            set { SetPropertyValue<long>( "CurrentMana", ref m_CurrentMana, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_DeathState;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long DeathState
        {
            get { return m_DeathState; }
            set { SetPropertyValue<long>( "DeathState", ref m_DeathState, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MovementType;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MovementType
        {
            get { return m_MovementType; }
            set { SetPropertyValue<long>( "MovementType", ref m_MovementType, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            CreatureTemplateGuid = 0;
            MapId = 0;
            ZoneId = 0;
            PositionX = 0;
            PositionY = 0;
            PositionZ = 0;
            Orientation = 0;
            SpawnTimeSecs = DateTime.MaxValue;
            SpawnDistance = 0;
            SpawnPositionX = 0;
            SpawnPositionY = 0;
            SpawnPositionZ = 0;
            SpawnPositionOrientation = 0;
            CurrentHealth = 0;
            CurrentMana = 0;
            DeathState = 0;
            MovementType = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion