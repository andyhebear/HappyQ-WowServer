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
    public class CharacterBase : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterBase() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharacterBase( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_CharacterName;
        #endregion
        /// <summary>
        /// 游戏人物的名称
        /// </summary>
        [Indexed( Unique = true )]
        [Size( 64 )]
        public string CharacterName
        {
            get { return m_CharacterName; }
            set { SetPropertyValue<string>( "CharacterName", ref m_CharacterName, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Account m_Account;
        #endregion
        /// <summary>
        /// 游戏人物所处的帐号的ID
        /// </summary>
        [Indexed]
        [Association( "Account-CharacterBase" )]
        public Account Account;

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_Gender;
        #endregion
        /// <summary>
        /// 人物的性别
        /// </summary>
        public byte Gender
        {
            get { return m_Gender; }
            set { SetPropertyValue<byte>( "Gender", ref m_Gender, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_Skin;
        #endregion
        /// <summary>
        /// 人物的外观
        /// </summary>
        public byte Skin
        {
            get { return m_Skin; }
            set { SetPropertyValue<byte>( "Skin", ref m_Skin, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_Face;
        #endregion
        /// <summary>
        /// 人物的脸型
        /// </summary>
        public byte Face
        {
            get { return m_Face; }
            set { SetPropertyValue<byte>( "Face", ref m_Face, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_HairStyle;
        #endregion
        /// <summary>
        /// 人物的发型
        /// </summary>
        public byte HairStyle
        {
            get { return m_HairStyle; }
            set { SetPropertyValue<byte>( "HairStyle", ref m_HairStyle, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_HairColor;
        #endregion
        /// <summary>
        /// 人物的发型颜色
        /// </summary>
        public byte HairColor
        {
            get { return m_HairColor; }
            set { SetPropertyValue<byte>( "HairColor", ref m_HairColor, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_FacialHair;
        #endregion
        /// <summary>
        /// 人物脸部的毛发或耳坠
        /// </summary>
        public byte FacialHair
        {
            get { return m_FacialHair; }
            set { SetPropertyValue<byte>( "FacialHair", ref m_FacialHair, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_Race;
        #endregion
        /// <summary>
        /// 人物的种族
        /// </summary>
        public byte Race
        {
            get { return m_Race; }
            set { SetPropertyValue<byte>( "Race", ref m_Race, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Class;
        #endregion
        /// <summary>
        /// 人物的职业
        /// </summary>
        public long Class
        {
            get { return m_Class; }
            set { SetPropertyValue<long>( "Class", ref m_Class, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Level;
        #endregion
        /// <summary>
        /// 人物的等级
        /// </summary>
        public long Level
        {
            get { return m_Level; }
            set { SetPropertyValue<long>( "Level", ref m_Level, value ); }
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

        /// <summary>
        /// 人物所在行会的GUID
        /// </summary>
        [Indexed]
        [Association( "Guild-CharacterBase" )]
        public Guild Guild
        {
            get { return GetPropertyValue<Guild>( "Guild" ); }
            set { SetPropertyValue<Guild>( "Guild", value ); }
        }

        ///// <summary>
        ///// 人物当前的HP
        ///// </summary>
        //public abstract float CurrentHP { get; set; }

        ///// <summary>
        ///// 人物当前的MP
        ///// </summary>
        //public abstract int CurrentMP { get; set; }

        ///// <summary>
        ///// 人物的力量
        ///// </summary>
        //public abstract int Strength { get; set; }

        ///// <summary>
        ///// 人物的集中
        ///// </summary>
        //public abstract int Convergence { get; set; }

        ///// <summary>
        ///// 人物的敏捷
        ///// </summary>
        //public abstract int Dexterity { get; set; }

        ///// <summary>
        ///// 人物的智力
        ///// </summary>
        //public abstract int Intellect { get; set; }

        ///// <summary>
        ///// 人物的魅力
        ///// </summary>
        //public abstract int Charm { get; set; }

        ///// <summary>
        ///// 人物的感觉
        ///// </summary>
        //public abstract int Sense { get; set; }

        ///// <summary>
        ///// 人物的经验值
        ///// </summary>
        //public abstract int Experience { get; set; }

        ///// <summary>
        ///// 人物的技能点
        ///// </summary>
        //public abstract int SkillPoint { get; set; }

        ///// <summary>
        ///// 人物的能力点
        ///// </summary>
        //public abstract int StatusPoint { get; set; }

        ///// <summary>
        ///// 人物的职业
        ///// </summary>
        //public abstract int ClassID { get; set; }

        ///// <summary>
        ///// 人物所在部落的GUID
        ///// </summary>
        //[Indexed]
        //public abstract int ClanGuid { get; set; }

        ///// <summary> 
        ///// 人物所在的部落的等级
        ///// </summary>
        //public abstract int ClanRank { get; set; }

        ///// <summary>
        ///// 人物当前所在的地图
        ///// </summary>
        //public abstract int CurrentMap { get; set; }

        ///// <summary>
        ///// 人物的精力
        ///// </summary>
        //public abstract int Stamina { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[Length( 255 )]
        //public abstract string QuickBar { get; set; }

        ///// <summary>
        ///// 人物的基础技能
        ///// </summary>
        //[Length( 255 )]
        //public abstract string BasicSkills { get; set; }

        ///// <summary>
        ///// 人物的职业技能
        ///// </summary>
        //[Length( 255 )]
        //public abstract string ClassSkills { get; set; }

        ///// <summary>
        ///// 人物的职业技能的等级
        ///// </summary>
        //[Length( 255 )]
        //public abstract string ClassSkillsLevel { get; set; }

        ///// <summary>
        ///// 人物所在的游戏区
        ///// </summary>
        //public abstract int Realm { get; set; }

        ///// <summary>
        ///// 人物复活点的GUID
        ///// </summary>
        //public abstract long RespawnZoneGuid { get; set; }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint[] m_TaxiMask;
        #endregion
        /// <summary>
        /// 人物的坐骑航线标记点 32位值|32位值|32位值|32位值
        /// 00000000000000000000000000000000|...|...|...
        /// 以位域标示 1~TaxiId~32| 32~TaxiId~64|65~TaxiId~96|96~TaxiId~128
        /// </summary>
        public uint[] TaxiMask
        {
            get { return m_TaxiMask; }
            set { SetPropertyValue<uint[]>( "TaxiMask", ref m_TaxiMask, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint[] m_TutorialFlag;
        #endregion
        /// <summary>
        /// 学习的标记 大小8
        /// </summary>
        public uint[] TutorialFlag
        {
            get { return m_TutorialFlag; }
            set { SetPropertyValue<uint[]>( "TutorialFlag", ref m_TutorialFlag, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsGhost;
        #endregion
        /// <summary>
        /// 人物是否已经成为鬼魂
        /// </summary>
        public bool IsGhost
        {
            get { return m_IsGhost; }
            set { SetPropertyValue<bool>( "IsGhost", ref m_IsGhost, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCinematic;
        #endregion
        /// <summary>
        /// 人物开始时是否需要显示电影或已经显示过了不需要再此的显示
        /// </summary>
        public bool IsCinematic
        {
            get { return m_IsCinematic; }
            set { SetPropertyValue<bool>( "IsCinematic", ref m_IsCinematic, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsNeedRename;
        #endregion
        /// <summary>
        /// 人物是否需要重命名
        /// </summary>
        public bool IsNeedRename
        {
            get { return m_IsNeedRename; }
            set { SetPropertyValue<bool>( "IsNeedRename", ref m_IsNeedRename, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_TotalTime;
        #endregion
        /// <summary>
        /// 人物所玩的总游戏时间
        /// </summary>
        public long TotalTime
        {
            get { return m_TotalTime; }
            set { SetPropertyValue<long>( "TotalTime", ref m_TotalTime, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_LevelTime;
        #endregion
        /// <summary>
        /// 人物最后升级时的时间(或创建时的时间)
        /// </summary>
        public long LevelTime
        {
            get { return m_LevelTime; }
            set { SetPropertyValue<long>( "LevelTime", ref m_LevelTime, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_LogoutTime;
        #endregion
        /// <summary>
        /// 人物登出的时间
        /// </summary>
        public DateTime LogoutTime
        {
            get { return m_LogoutTime; }
            set { SetPropertyValue<DateTime>( "LogoutTime", ref m_LogoutTime, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_CreatingTime;
        #endregion
        /// <summary>
        /// 人物创建时的时间
        /// </summary>
        public DateTime CreatingTime
        {
            get { return m_CreatingTime; }
            set { SetPropertyValue<DateTime>( "CreatingTime", ref m_CreatingTime, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsBanned;
        #endregion
        /// <summary>
        /// 人物是否已经封停
        /// </summary>
        public bool IsBanned
        {
            get { return m_IsBanned; }
            set { SetPropertyValue<bool>( "IsBanned", ref m_IsBanned, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsDelete;
        #endregion
        /// <summary>
        /// 人物的是否已删除
        /// </summary>
        public bool IsDelete
        {
            get { return m_IsDelete; }
            set { SetPropertyValue<bool>( "IsDelete", ref m_IsDelete, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_DeleteTime;
        #endregion
        /// <summary>
        /// 人物删除的时间
        /// </summary>
        [NullValue( null )]
        public DateTime DeleteTime
        {
            get { return m_DeleteTime; }
            set { SetPropertyValue<DateTime>( "DeleteTime", ref m_DeleteTime, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            CharacterName = Guid.NewGuid().ToString();

            Gender = 0;
            Skin = 0;
            Face = 0;
            Race = 0;
            Class = 0;
            HairStyle = 0;
            FacialHair = 0;
            Level = 0;
            MapId = 0;
            ZoneId = 0;
            PositionX = 0;
            PositionY = 0;
            PositionZ = 0;
            Orientation = 0;
            TaxiMask = new uint[0];
            TutorialFlag = new uint[0];
            IsGhost = false;
            IsCinematic = true;
            IsNeedRename = false;
            TotalTime = 0;
            LevelTime = 0;
            LogoutTime = DateTime.MinValue;
            CreatingTime = DateTime.Now;
            IsBanned = false;
            IsDelete = false;
            DeleteTime = DateTime.MaxValue;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion