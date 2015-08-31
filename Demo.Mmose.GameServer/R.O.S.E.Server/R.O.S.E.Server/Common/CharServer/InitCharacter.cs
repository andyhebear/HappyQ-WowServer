#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2006 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System.Collections.Generic;
#endregion

namespace Demo_R.O.S.E.Mobile
{
    /// <summary>
    /// 
    /// </summary>
    public class InitCharacter
    {
        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        internal string m_CharacterName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string CharacterName
        {
            get { return m_CharacterName; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        internal int m_Face = 1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Face
        {
            get { return m_Face; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        internal int m_HairStyle = 1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int HairStyle
        {
            get { return m_HairStyle; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        internal int m_Sex = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Sex
        {
            get { return m_Sex; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_BasicSkills;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string BasicSkills
        {
            get { return m_BasicSkills; }
            set { m_BasicSkills = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Charm;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Charm
        {
            get { return m_Charm; }
            set { m_Charm = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_ClassID;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int ClassID
        {
            get { return m_ClassID; }
            set { m_ClassID = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_ClassSkills;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ClassSkills
        {
            get { return m_ClassSkills; }
            set { m_ClassSkills = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_ClassSkillsLevel;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ClassSkillsLevel
        {
            get { return m_ClassSkillsLevel; }
            set { m_ClassSkillsLevel = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Convergence;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Convergence
        {
            get { return m_Convergence; }
            set { m_Convergence = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_CurrentHP;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int CurrentHP
        {
            get { return m_CurrentHP; }
            set { m_CurrentHP = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_CurrentMP;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int CurrentMP
        {
            get { return m_CurrentMP; }
            set { m_CurrentMP = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_CurrentMap;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int CurrentMap
        {
            get { return m_CurrentMap; }
            set { m_CurrentMap = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Dexterity;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Dexterity
        {
            get { return m_Dexterity; }
            set { m_Dexterity = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Experience;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Experience
        {
            get { return m_Experience; }
            set { m_Experience = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Intellect;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Intellect
        {
            get { return m_Intellect; }
            set { m_Intellect = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Level;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PositionX;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int PositionX
        {
            get { return m_PositionX; }
            set { m_PositionX = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PositionY;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int PositionY
        {
            get { return m_PositionY; }
            set { m_PositionY = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_QuickBar;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string QuickBar
        {
            get { return m_QuickBar; }
            set { m_QuickBar = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Realm;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Realm
        {
            get { return m_Realm; }
            set { m_Realm = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Sense;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Sense
        {
            get { return m_Sense; }
            set { m_Sense = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_SkillPoint;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int SkillPoint
        {
            get { return m_SkillPoint; }
            set { m_SkillPoint = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Stamina;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Stamina
        {
            get { return m_Stamina; }
            set { m_Stamina = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_StatusPoint;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int StatusPoint
        {
            get { return m_StatusPoint; }
            set { m_StatusPoint = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Strength;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Strength
        {
            get { return m_Strength; }
            set { m_Strength = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Zuly;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Zuly
        {
            get { return m_Zuly; }
            set { m_Zuly = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private List<InitCharacterItem> m_CharacterItemList = new List<InitCharacterItem>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public List<InitCharacterItem> ItemList
        {
            get { return m_CharacterItemList; }
        }
        #endregion
    }
}
#endregion