
/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/


using System;
using System.Text;
using System.Collections.Generic;
using Demo_R.O.S.E.Quest;
using Demo_G.O.S.E.ServerEngine.Mobile;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_G.O.S.E.ServerEngine.Treasure;
using Demo_G.O.S.E.ServerEngine.Common;


public class MapData
{
    public uint map;
    public bool pvp;
}

/// <summary>
/// MyQuest structure
/// </summary>
public class CMyQuest
{
    public long m_iQuestGuid;
    public ROSEQuest thisquest = new ROSEQuest();
    public int[] m_iItems = new int[5];
    public bool m_bActive;
}

// -----------------------------------------------------------------------------------------
// An item that a client owns
// -----------------------------------------------------------------------------------------
public class CItem
{
    public int m_iItemID;
    public int m_iItemtype;
    public int m_iRefine;
    public int m_iLifespan;
    public int m_iDurability;
    public bool m_bSocketed;
    public bool m_bAppraised;
    public int m_iCount;
    public int m_iStats;
    public int m_iGemID;

    /// <summary>
    /// Build Item refine
    /// </summary>
    /// <returns></returns>
    public ushort BuildItemRefine()
    {
        if ( m_iGemID == 0 )
            return (ushort)( m_iRefine << 8 );
        else
            return (ushort)( ( 0xD00 + ( m_iGemID - 320 ) << 2 ) + ( m_iRefine << 8 ) );
    }

    /// <summary>
    /// Build Item Header
    /// </summary>
    /// <returns></returns>
    public uint BuildItemHead()
    {
        if ( m_iCount == 0 )
            return 0;
        return (uint)( ( ( m_iItemID & 0x7FFFFFF ) << 5 ) | ( m_iItemtype & 0x1F ) );
    }

    /// <summary>
    /// Build Item Data
    /// </summary>
    /// <returns></returns>
    public uint BuildItemData()
    {
        if ( m_iCount == 0 )
            return 0;
        if ( m_iItemtype >= 10 && m_iItemtype <= 13 )
        {
            return (uint)m_iCount;
        }
        else
        {
            uint part1 = (uint)( ( m_iRefine >> 4 ) << 28 );
            uint part2 = (uint)( ( m_bAppraised ? 1 : 0 ) << 27 );
            uint part3 = (uint)( ( m_bSocketed ? 1 : 0 ) << 26 );
            uint part4 = (uint)( ( m_iLifespan * 10 ) << 16 );
            uint part5 = (uint)( m_iDurability << 9 );
            uint part6 = 0;
            uint part7 = (uint)m_iGemID;
            if ( part7 == 0 )
                part6 = (uint)m_iStats;

            return (uint)( part1 | part2 | part3 | part4 | part5 | part6 | part7 );
        }
    }
}

// -----------------------------------------------------------------------------------------
// User skill info
// -----------------------------------------------------------------------------------------
public class CSkill
{
    public int m_iClassSkillID;
    public int m_iLevel;
}

// -----------------------------------------------------------------------------
// A player-storage (c)2006 by Caali
// -----------------------------------------------------------------------------
public class CStorage
{
    public ulong m_iZuly;
    public CItem[] m_Items = new CItem[160]; //40 per page
}
// -----------------------------------------------------------------------------------------


namespace Demo_R.O.S.E.Mobile
{
    public class ROSEMobile : GeneralMobile
    {
        /// <summary>
        /// 
        /// </summary>
        public ROSEMobile()
        {
            //// 初始化人物的技能
            //for ( int iIndex = 0; iIndex < m_iClassSkills.Length; iIndex++ )
            //    m_iClassSkills[iIndex] = new CSkill();

            //// 初始化人物身上道具
            //for ( int iIndex = 0; iIndex < m_Items.Length; iIndex++ )
            //    m_Items[iIndex] = new CItem();

            ////初始化贮藏库道具
            //for ( int iIndex = 0; iIndex < m_Storage.m_Items.Length; iIndex++ )
            //    m_Storage.m_Items[iIndex] = new CItem();
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iAccountGuid = -1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long AccountGuid
        {
            get { return m_iAccountGuid; }
            set { m_iAccountGuid = value; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_iGMLevel = -1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal int GMLevel
        {
            get { return m_iGMLevel; }
            set { m_iGMLevel = value; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iLastServerGuid = -1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long LastServerGuid
        {
            get { return m_iLastServerGuid; }
            set { m_iLastServerGuid = value; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsLoggedIn = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsLoggedIn
        {
            get { return m_bIsLoggedIn; }
            set { m_bIsLoggedIn = value; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_StorageZuly = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long StorageZuly
        {
            get { return m_StorageZuly; }
            set { m_StorageZuly = value; }
        }

        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_iInGame = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool InGame
        {
            get { return m_iInGame; }
            set { m_iInGame = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// Char info
        /// </summary>
        private long m_CharacterGuid;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long CharacterGuid
        {
            get { return m_CharacterGuid; }
            set { m_CharacterGuid = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_CharacterName;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string CharacterName
        {
            get { return m_CharacterName; }
            set { m_CharacterName = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ClanGuid;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClanGuid
        {
            get { return m_ClanGuid; }
            set { m_ClanGuid = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ClanRank;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClanRank
        {
            get { return m_ClanRank; }
            set { m_ClanRank = value; }
        }





        // loaddata
        /// <summary>
        /// 
        /// </summary>
        public string m_strCharacter = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public long m_iClientID;
        /// <summary>
        /// 
        /// </summary>
        public long m_iCharacterGuid;
        /// <summary>
        /// 
        /// </summary>
        public int m_iCurrentHP;
        /// <summary>
        /// 
        /// </summary>
        public int m_iMaxHP;
        /// <summary>
        /// 
        /// </summary>
        public int m_iCurrentMP;
        /// <summary>
        /// 
        /// </summary>
        public int m_iStrength;
        /// <summary>
        /// 
        /// </summary>
        public int m_iDexterity;
        /// <summary>
        /// 
        /// </summary>
        public int m_iIntellect;
        /// <summary>
        /// 
        /// </summary>
        public int m_iConvergence;
        /// <summary>
        /// 
        /// </summary>
        public int m_iCharm;
        /// <summary>
        /// 
        /// </summary>
        public int m_iSense;
        /// <summary>
        /// 
        /// </summary>
        public long m_iRespawnGuid;
        /// <summary>
        /// 
        /// </summary>
        public int m_iExperience;
        /// <summary>
        /// 
        /// </summary>
        public int m_iClassID;
        /// <summary>
        /// 
        /// </summary>
        public int m_iStatusPoint;
        /// <summary>
        /// 
        /// </summary>
        public int m_iSkillPoint;
        /// <summary>
        /// 
        /// </summary>
        public int m_iStamina;
        /// <summary>
        /// 
        /// </summary>
        public int m_iLevel;
        /// <summary>
        /// 
        /// </summary>
        public int m_iFace;
        /// <summary>
        /// 
        /// </summary>
        public int m_iHairStyle;
        /// <summary>
        /// 
        /// </summary>
        public int m_iSex;
        /// <summary>
        /// 
        /// </summary>
        public int m_stance;
        /// <summary>
        /// 
        /// </summary>
        public int m_iZuly;
        /// <summary>
        /// 
        /// </summary>
        public int m_iClanGuid;
        /// <summary>
        /// 
        /// </summary>
        public int m_iClanRank;
        /// <summary>
        /// 
        /// </summary>
        public uint m_iCurrentWorldTime;       // Store the Current World Time	

        public ushort montype;
        public uint dialogid;
        public uint npctype;
        public ushort targettype; // 1 = mob | 2 = player | 3 = npc	
        public ushort targetid;
        public int atktype;
        public ushort mspeed = 425;

        public int owner;
       public Point3D m_DestinePoint3D = new Point3D();

        public sbyte m_posMapID;
        public MapData m_posMapData = new MapData();

        public int[] m_iQuickBar = new int[48];
        public int[] m_iBasicSkills = new int[42];
        public CSkill[] m_iClassSkills = new CSkill[60];

        public CItem[] m_Items = new CItem[140];

        public CStorage m_Storage = new CStorage();

        public List<CMyQuest> MyQuestList = new List<CMyQuest>();

        //***********Clan Info***********
        //int clan_rank;
        //int clanID;
        public int m_iGrade;
        public int m_iBack;
        public int m_iLogo;
        public string m_strClanName;


        //*spawn values
        //BYTE1
        public byte UNK1 = 0x01;
        public byte MAX_HP_MP = 0x02;//revizar
        public byte POISED = 0x04;
        public byte UNK2 = 0x08;
        public byte MP_UP = 0x10;//revizar
        public byte HP_UP = 0x20;//revizar
        public byte DASH_UP = 0x40;
        public byte DASH_DOWN = 0x80;
        //BYTE2
        public byte HASTE_UP = 0x01;
        public byte HASTE_DOWN = 0x02;
        public byte ATTACK_UP = 0x04;
        public byte ATTACK_DOWN = 0x08;
        public byte DEFENSE_UP = 0x10;
        public byte DEFENSE_DOWN = 0x20;
        public byte MDEFENSE_UP = 0x40;
        public byte MDEFENSE_DOWN = 0x80;
        //BYTE3
        public byte HITRATE_UP = 0x01;
        public byte HITRATE_DOWN = 0x02;
        public byte CRITICAL_UP = 0x04;
        public byte CRITICAL_DOWN = 0x08;
        public byte DODGE_UP = 0x10;
        public byte SUMMON = 0x20;
        public byte MUTED = 0x40;
        public byte SLEEPING = 0x80;
        //BYTE4
        public byte STUN = 0x01;
        public byte INVISIBLE_1 = 0x02;
        public byte INVISIBLE_2 = 0x04;
        public byte UNK3 = 0x08;
        public byte DAMAGE_UP = 0x10;
        //public byte SUMMON = 0x20;
        public byte UNK4 = 0x40;
        public byte UNK5 = 0x80;

        //Up
        public byte Attack_up;
        public byte Defense_up;
        public byte Magic_Defense_up;
        public byte Accury_up;
        public byte Critical_up;
        public byte Dodge_up;
        public byte Haste_up;
        public byte Dash_up;
        public byte HP_up;
        public byte MP_up;

        // Down
        public byte Attack_down;
        public byte Defense_down;
        public byte Magic_Defense_down;
        public byte Accury_down;
        public byte Critical_down;
        public byte Dodge_down;
        public byte Haste_down;
        public byte Dash_down;
        public byte HP_down;
        public byte MP_down;     





        private uint m_MobileID;

        public uint MobileID
        {
            get { return m_MobileID; }
            set { m_MobileID = value; }
        }

        private uint m_Life;

        public uint Life
        {
            get { return m_Life; }
            set { m_Life = value; }
        }

        private uint m_WalkSpeed;

        public uint WalkSpeed
        {
            get { return m_WalkSpeed; }
            set { m_WalkSpeed = value; }
        }

        private uint m_RunSpeed;

        public uint RunSpeed
        {
            get { return m_RunSpeed; }
            set { m_RunSpeed = value; }
        }

        private uint m_DriveSpeed;

        public uint DriveSpeed
        {
            get { return m_DriveSpeed; }
            set { m_DriveSpeed = value; }
        }

        private uint m_Weapon;

        public uint Weapon
        {
            get { return m_Weapon; }
            set { m_Weapon = value; }
        }

        private uint m_SubWeapon;

        public uint SubWeapon
        {
            get { return m_SubWeapon; }
            set { m_SubWeapon = value; }
        }

        private uint m_Level;

        public uint Level1
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        private uint m_HP;

        public uint HP
        {
            get { return m_HP; }
            set { m_HP = value; }
        }

        private uint m_AttackPower;

        public uint AttackPower
        {
            get { return m_AttackPower; }
            set { m_AttackPower = value; }
        }

        private uint m_HitPower;

        public uint HitPower
        {
            get { return m_HitPower; }
            set { m_HitPower = value; }
        }

        private uint m_Defense;

        public uint Defense
        {
            get { return m_Defense; }
            set { m_Defense = value; }
        }

        //private uint m_Strength;

        //public uint Strength
        //{
        //    get { return m_Strength; }
        //    set { m_Strength = value; }
        //}

        private uint m_Evasion;

        public uint Evasion
        {
            get { return m_Evasion; }
            set { m_Evasion = value; }
        }

        private float m_AttackSpeed;

        public float AttackSpeed
        {
            get { return m_AttackSpeed; }
            set { m_AttackSpeed = value; }
        }

        private uint m_AI;

        public uint AI
        {
            get { return m_AI; }
            set { m_AI = value; }
        }

        private uint m_Experience;

        public uint Experience1
        {
            get { return m_Experience; }
            set { m_Experience = value; }
        }

        private uint m_DropID;

        public uint DropID
        {
            get { return m_DropID; }
            set { m_DropID = value; }
        }

        private uint m_Money;

        public uint Money
        {
            get { return m_Money; }
            set { m_Money = value; }
        }

        private uint m_Item;

        public uint Item
        {
            get { return m_Item; }
            set { m_Item = value; }
        }

        private uint m_Tab1;

        public uint Tab1
        {
            get { return m_Tab1; }
            set { m_Tab1 = value; }
        }

        private uint m_Tab2;

        public uint Tab2
        {
            get { return m_Tab2; }
            set { m_Tab2 = value; }
        }

        private uint m_Tab3;

        public uint Tab3
        {
            get { return m_Tab3; }
            set { m_Tab3 = value; }
        }

        private uint m_SpecialTab;

        public uint SpecialTab
        {
            get { return m_SpecialTab; }
            set { m_SpecialTab = value; }
        }

        private float m_AttackDistance;

        public float AttackDistance
        {
            get { return m_AttackDistance; }
            set { m_AttackDistance = value; }
        }

        private uint m_Aggresive;

        public uint Aggresive
        {
            get { return m_Aggresive; }
            set { m_Aggresive = value; }
        }

        private uint m_sHP;

        public uint SHP
        {
            get { return m_sHP; }
            set { m_sHP = value; }
        }

        private uint m_DialogID;

        public uint DialogID
        {
            get { return m_DialogID; }
            set { m_DialogID = value; }
        }

    }
}
