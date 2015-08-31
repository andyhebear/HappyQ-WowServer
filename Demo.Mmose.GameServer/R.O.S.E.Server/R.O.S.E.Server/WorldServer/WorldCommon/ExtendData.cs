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
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Demo_G.O.S.E.Data;
using Demo_R.O.S.E.Database;
using Demo_R.O.S.E.Database.Model;
using Demo_G.O.S.E.ServerEngine.Network;
using System.Text.RegularExpressions;
using Demo_R.O.S.E.WorldServer.Common;
using Demo_R.O.S.E.Quest;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_R.O.S.E.Mobile;
#endregion

namespace Demo_R.O.S.E.WorldServer.Network
{
    internal class WorldServerExtendData
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ROSEMobile m_ROSEMobile = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal ROSEMobile ROSEMobile
        {
            get { return m_ROSEMobile; }
            set { m_ROSEMobile = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool LoadData()
        {
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    // 读取人物的详细信息
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharacters.Parameters.Add( "@CharacterName", m_ROSEMobile.CharacterName );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    m_ROSEMobile.m_strCharacter = l_Characters.CharacterName;
                    m_ROSEMobile.m_iLevel = l_Characters.Level;
                    m_ROSEMobile.m_iFace = l_Characters.Face;
                    m_ROSEMobile.m_iHairStyle = l_Characters.HairStyle;
                    m_ROSEMobile.m_iSex = l_Characters.Sex;
                    m_ROSEMobile.m_iClassID = l_Characters.ClassID;
                    m_ROSEMobile.m_iZuly = l_Characters.Zuly;
                    m_ROSEMobile.m_iStrength = l_Characters.Strength;
                    m_ROSEMobile.m_iDexterity = l_Characters.Dexterity;
                    m_ROSEMobile.m_iIntellect = l_Characters.Intellect;
                    m_ROSEMobile.m_iConvergence = l_Characters.Convergence;
                    m_ROSEMobile.m_iCharm = l_Characters.Charm;
                    m_ROSEMobile.m_iSense = l_Characters.Sense;
                    m_ROSEMobile.m_iCurrentHP = l_Characters.CurrentHP;
                    m_ROSEMobile.m_iCurrentMP = l_Characters.CurrentMP;
                    m_ROSEMobile.m_iCharacterGuid = l_Characters.CharacterGuid;
                    m_ROSEMobile.m_iStatusPoint = l_Characters.StatusPoint;
                    m_ROSEMobile.m_iSkillPoint = l_Characters.SkillPoint;
                    m_ROSEMobile.m_iExperience = l_Characters.Experience;
                    m_ROSEMobile.m_iStamina = l_Characters.Stamina;
                    m_ROSEMobile.m_iClanGuid = l_Characters.ClanGuid;
                    m_ROSEMobile.m_iClanRank = l_Characters.ClanRank;

                    m_ROSEMobile.X = 5300;
                    m_ROSEMobile.Y = 5200;
                    m_ROSEMobile.m_posMapID = 2;
                    m_ROSEMobile.m_iRespawnGuid = l_Characters.RespawnZoneGuid;

                    Regex l_Regex = new Regex( @"(\d+)+", RegexOptions.Compiled );

                    // 分析 QuickBar "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
                    MatchCollection l_MatchCollectionQuickBar = l_Regex.Matches( l_Characters.QuickBar );
                    if ( l_MatchCollectionQuickBar == null )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_MatchCollectionQuickBar == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_MatchCollectionQuickBar.Count != m_ROSEMobile.m_iQuickBar.Length )
                    {
                        Debug.WriteLine( string.Format( "WorldServerExtendData.LoadData(...) - l_MatchCollectionQuickBar.Count != m_CharacterInfo.m_iQuickBar.Length error{0}-{1}!", l_MatchCollectionQuickBar.Count, m_ROSEMobile.m_iQuickBar.Length ) );

                        l_bIsReturn = true;
                        break;
                    }

                    for ( int iIndex = 0; iIndex < l_MatchCollectionQuickBar.Count; iIndex++ )
                    {
                        Match l_Match = l_MatchCollectionQuickBar[iIndex];
                        Group l_Group = l_Match.Groups[1];

                        int l_iResult = 0;
                        Int32.TryParse( l_Group.ToString(), out l_iResult );

                        m_ROSEMobile.m_iQuickBar[iIndex] = l_iResult;
                    }

                    // 分析 BasicSkills "11,12,13,14,15,16,17,18,19,20,21,22,25,5000,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
                    MatchCollection l_MatchCollectionBasicSkills = l_Regex.Matches( l_Characters.BasicSkills );
                    if ( l_MatchCollectionBasicSkills == null )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_MatchCollectionBasicSkills == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_MatchCollectionBasicSkills.Count != m_ROSEMobile.m_iBasicSkills.Length )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_MatchCollectionBasicSkills.Count != 42 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    for ( int iIndex = 0; iIndex < l_MatchCollectionBasicSkills.Count; iIndex++ )
                    {
                        Match l_Match = l_MatchCollectionBasicSkills[iIndex];
                        Group l_Group = l_Match.Groups[1];

                        int l_iResult = 0;
                        Int32.TryParse( l_Group.ToString(), out l_iResult );

                        m_ROSEMobile.m_iBasicSkills[iIndex] = l_iResult;
                    }

                    // 分析 ClassSkills "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
                    MatchCollection l_MatchCollectionClassSkills = l_Regex.Matches( l_Characters.ClassSkills );
                    if ( l_MatchCollectionClassSkills == null )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_MatchCollectionClassSkills == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_MatchCollectionClassSkills.Count != m_ROSEMobile.m_iClassSkills.Length )
                    {
                        Debug.WriteLine( string.Format( "WorldServerExtendData.LoadData(...) - l_MatchCollectionClassSkills.Count != m_CharacterInfo.m_iClassSkills.Length error{0}-{1}!", l_MatchCollectionClassSkills.Count, m_ROSEMobile.m_iClassSkills.Length ) );

                        l_bIsReturn = true;
                        break;
                    }

                    // 初始化人物的技能
                    for ( int iIndex = 0; iIndex < m_ROSEMobile.m_iClassSkills.Length; iIndex++ )
                        m_ROSEMobile.m_iClassSkills[iIndex] = new CSkill();

                    for ( int iIndex = 0; iIndex < l_MatchCollectionClassSkills.Count; iIndex++ )
                    {
                        Match l_Match = l_MatchCollectionClassSkills[iIndex];
                        Group l_Group = l_Match.Groups[1];

                        int l_iResult = 0;
                        Int32.TryParse( l_Group.ToString(), out l_iResult );

                        m_ROSEMobile.m_iClassSkills[iIndex].m_iClassSkillID = l_iResult;
                    }

                    // 分析 ClassSkillsLevel "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1"
                    MatchCollection l_MatchCollectionClassSkillsLevel = l_Regex.Matches( l_Characters.ClassSkillsLevel );
                    if ( l_MatchCollectionClassSkillsLevel == null )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_MatchCollectionClassSkillsLevel == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_MatchCollectionClassSkillsLevel.Count != m_ROSEMobile.m_iClassSkills.Length )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_MatchCollectionClassSkillsLevel.Count != 40 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    for ( int iIndex = 0; iIndex < l_MatchCollectionClassSkillsLevel.Count; iIndex++ )
                    {
                        Match l_Match = l_MatchCollectionClassSkillsLevel[iIndex];
                        Group l_Group = l_Match.Groups[1];

                        int l_iResult = 0;
                        Int32.TryParse( l_Group.ToString(), out l_iResult );

                        m_ROSEMobile.m_iClassSkills[iIndex].m_iLevel = l_iResult;
                    }

                    do
                    {
                        // 初始化人物身上道具
                        for ( int iIndex = 0; iIndex < m_ROSEMobile.m_Items.Length; iIndex++ )
                            m_ROSEMobile.m_Items[iIndex] = new CItem();

                        // 读取人物身上的道具
                        Query l_QueryItems = new Query( l_Session, "Select Items instances where {CharacterGuid}=@CharacterGuid" );
                        l_QueryItems.Parameters.Add( "@CharacterGuid", l_Characters.CharacterGuid );
                        QueryResult l_ItemResult = l_QueryItems.Execute();

                        if ( l_ItemResult == null )
                        {
                            Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_ItemResult == null error!" );

                            break;
                        }

                        // 人物身上道具不存在
                        if ( l_ItemResult.Count <= 0 )
                            break;

                        for ( int iIndex = 0; iIndex < l_ItemResult.Count; iIndex++ )
                        {
                            Items l_Items = l_ItemResult[0] as Items;
                            if ( l_Items == null )
                            {
                                Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_Items == null error!" );

                                l_bIsReturn = true;
                                break;
                            }

                            if ( l_Items.SlotNumber >= m_ROSEMobile.m_Items.Length )
                                continue;

                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_iItemID = l_Items.ItemID;
                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_iItemtype = l_Items.ItemType;
                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_iRefine = l_Items.Refine;
                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_iDurability = l_Items.Durability;
                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_iLifespan = l_Items.Lifespan;
                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_iCount = l_Items.Count;
                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_iStats = l_Items.Stats;
                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_bSocketed = l_Items.Socketed;
                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_bAppraised = l_Items.Appraised;
                            m_ROSEMobile.m_Items[l_Items.SlotNumber].m_iGemID = l_Items.GemID;
                        }
                    } while ( false );

                    // 如果错误则返回
                    if ( l_bIsReturn == true )
                        break;

                    do
                    {
                        //初始化贮藏库道具
                        for ( int iIndex = 0; iIndex < m_ROSEMobile.m_Storage.m_Items.Length; iIndex++ )
                            m_ROSEMobile.m_Storage.m_Items[iIndex] = new CItem();

                        // 读取贮藏库的内容
                        Query l_QueryStorage = new Query( l_Session, "Select ListStorage instances where {AccountGuid}=@AccountGuid" );
                        l_QueryStorage.Parameters.Add( "@AccountGuid", m_ROSEMobile.AccountGuid );
                        QueryResult l_StorageResult = l_QueryStorage.Execute();

                        if ( l_StorageResult == null )
                        {
                            Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_StorageResult == null error!" );

                            break;
                        }


                        // 贮藏库道具不存在
                        if ( l_StorageResult.Count <= 0 )
                            break;

                        for ( int iIndex = 0; iIndex < l_StorageResult.Count; iIndex++ )
                        {
                            ListStorage l_Storage = l_StorageResult[0] as ListStorage;
                            if ( l_Storage == null )
                            {
                                Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_Storage == null error!" );

                                l_bIsReturn = true;
                                break;
                            }

                            if ( l_Storage.SlotNumber >= m_ROSEMobile.m_Storage.m_Items.Length )
                                continue;

                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_iItemID = l_Storage.ItemID;
                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_iItemtype = l_Storage.ItemType;
                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_iRefine = l_Storage.Refine;
                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_iDurability = l_Storage.Durability;
                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_iLifespan = l_Storage.Lifespan;
                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_iCount = l_Storage.Count;
                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_iStats = l_Storage.Stats;
                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_bSocketed = l_Storage.Socketed;
                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_bAppraised = l_Storage.Appraised;
                            m_ROSEMobile.m_Storage.m_Items[l_Storage.SlotNumber].m_iGemID = l_Storage.GemID;
                        }
                    } while ( false );

                    // 如果错误则返回
                    if ( l_bIsReturn == true )
                        break;

                    // 读取部落信息
                    if ( m_ROSEMobile.m_iClanGuid > 0 )
                    {
                        do
                        {
                            Query l_QueryListClan = new Query( l_Session, "Select ListClan instances where {ClanGuid}=@ClanGuid" );
                            l_QueryListClan.Parameters.Add( "@ClanGuid", l_Characters.ClanGuid );
                            QueryResult l_ListClanResult = l_QueryListClan.Execute();

                            if ( l_ListClanResult == null )
                            {
                                Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_ListClanResult == null error!" );

                                break;
                            }

                            // 部落信息不存在
                            if ( l_ListClanResult.Count <= 0 )
                                break;

                            if ( l_ListClanResult.Count != 1 )
                            {
                                Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_ListClanResult == null error!" );

                                l_bIsReturn = true;
                                break;
                            }

                            ListClan l_ListClan = l_ListClanResult[0] as ListClan;
                            if ( l_ListClan == null )
                            {
                                Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_ListClan == null error!" );

                                l_bIsReturn = true;
                                break;
                            }

                            m_ROSEMobile.m_iGrade = l_ListClan.Grade;
                            m_ROSEMobile.m_iBack = l_ListClan.Back;
                            m_ROSEMobile.m_iLogo = l_ListClan.Logo;
                            m_ROSEMobile.m_strClanName = l_ListClan.ClanName;
                        } while ( false );

                        // 如果错误则返回
                        if ( l_bIsReturn == true )
                            break;
                    }

                    // 读取人物的任务列表
                    Query l_QueryListQuest = new Query( l_Session, "Select ListQuest instances where {CharacterGuid}=@CharacterGuid" );
                    l_QueryListQuest.Parameters.Add( "@CharacterGuid", l_Characters.CharacterGuid );
                    QueryResult l_ListQuestResult = l_QueryListQuest.Execute();

                    // 人物的任务信息不存在
                    if ( l_ListQuestResult == null )
                    {
                        Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_ListQuestResult == null error!" );

                        break;
                    }

                    // 人物的任务信息不存在
                    if ( l_ListQuestResult.Count <= 0 )
                        break;

                    for ( int iIndex = 0; iIndex < l_ListQuestResult.Count; iIndex++ )
                    {
                        ListQuest l_ListQuest = l_ListQuestResult[iIndex] as ListQuest;
                        if ( l_ListQuest == null )
                        {
                            Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_ListQuest == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        CMyQuest l_thisQuest = new CMyQuest();
                        l_thisQuest.m_iQuestGuid = l_ListQuest.QuestGuid;
                        //l_CMyQuest.thisquest = ;
                        l_thisQuest.m_bActive = l_ListQuest.Active;

                        // 分析 QuestItems
                        MatchCollection l_MatchCollectionQuestItems = l_Regex.Matches( l_ListQuest.QuestItems );
                        if ( l_MatchCollectionQuestItems == null )
                        {
                            Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_MatchCollectionQuestItems == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        if ( l_MatchCollectionQuestItems.Count != l_thisQuest.m_iItems.Length )
                        {
                            Debug.WriteLine( "WorldServerExtendData.LoadData(...) - l_MatchCollectionQuestItems.Count != 5 error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        for ( int iIndex2 = 0; iIndex2 < l_MatchCollectionQuestItems.Count; iIndex2++ )
                        {
                            Match l_Match = l_MatchCollectionQuestItems[iIndex2];
                            Group l_Group = l_Match.Groups[1];

                            int l_iResult = 0;
                            Int32.TryParse( l_Group.ToString(), out l_iResult );

                            l_thisQuest.m_iItems[iIndex2] = l_iResult;
                        }

                        m_ROSEMobile.MyQuestList.Add( l_thisQuest );
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return false;
            else
                return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetStats()
        {
            return true;
        }

        public bool AddQuest( long QuestId )
        {
            return true;
        }

        public bool RemoveQuest( long QuestId )
        {
            return true;
        }

        public bool CleanPlayerVector()
        {
            return true;            
        }

        public void RestartPlayerVal()
        {
            
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class CharServerExtendData
    {
        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
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
        #endregion
    }





















    // -----------------------------------------------------------------------------------------
    // A 2d point, for positions
    // -----------------------------------------------------------------------------------------
    public class fPoint
    {
        public float x;
        public float y;
    }

    // -----------------------------------------------------------------------------------------
    // An item or zuly dropped on the ground
    // -----------------------------------------------------------------------------------------
    class CDrop
    {
        ushort clientid;
        sbyte posMap;
        fPoint pos;
        sbyte type;
        uint amount;
        CItem item;
        DateTime droptime;
        ushort owner;
    }

    // -----------------------------------------------------------------------------------------
    // A teleport gate object
    // -----------------------------------------------------------------------------------------
    class CTeleGate
    {
        ushort id;
        fPoint dest;
        sbyte destMap;
    }

    // -----------------------------------------------------------------------------------------
    // A respawn point object
    // -----------------------------------------------------------------------------------------
    class CRespawnPoint
    {
        ushort id;
        fPoint dest;
        sbyte destMap;
        sbyte radius;
        bool masterdest;
    }

    // -----------------------------------------------------------------------------
    // A monster spawn zone
    // -----------------------------------------------------------------------------
    class CSpawnArea
    {
        uint id;
        sbyte map;
        int count;
        int respawntime;
        ushort montype;
        int pcount;
        int aggrocount;
        fPoint points;
    }

    // -----------------------------------------------------------------------------------------
    // A typical NPC
    // -----------------------------------------------------------------------------------------
    class CNPC
    {
        ushort clientid;
        fPoint pos;
        float dir;
        sbyte posMap;
        uint npctype;
    }

    // -----------------------------------------------------------------------------------------
    // A typical monster
    // -----------------------------------------------------------------------------------------
    class CMonster
    {
        bool isAttacking;
        bool isAggro;

        ushort clientid;
        ushort targetid;
        fPoint nPos;
        fPoint pos;
        sbyte posMap;
        uint montype;
        int spawnarea;
        int currenthp;
        int level;
        uint defense;
        uint atkpower;
        DateTime lastMoveTime;
        DateTime lastAttackTime;
    }

    public class CharacterState
    {
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

        public ushort targettype; // 1 = mob | 2 = player | 3 = npc	
        public ushort targetid;
        public int atktype;
        public ushort mspeed = 425;    


        // Position Information
        public sbyte m_posMapID;
        public MapData m_posMapData = new MapData();
        public fPoint m_nPos;
        public fPoint m_pos;

        public int[] m_iQuickBar = new int[48];
        public int[] m_iBasicSkills = new int[42];
        public CSkill[] m_iClassSkills = new CSkill[60];

        public CItem[] m_Items = new CItem[140];

        public CStorage m_Storage = new CStorage();

        // OnServerReady
        List<CTeleGate> TeleGateList = new List<CTeleGate>();
        List<CRespawnPoint> RespawnPointList = new List<CRespawnPoint>();
        List<CSpawnArea> MonsterSpawnList = new List<CSpawnArea>();
        List<CNPC> NPCList = new List<CNPC>();
        List<CMonster> MonsterList = new List<CMonster>();


        //
        List<NetState> VisibleClients = new List<NetState>();
        List<CDrop> VisibleDrops = new List<CDrop>();
        List<CMonster> VisibleMonsters = new List<CMonster>();
        List<CNPC> VisibleNPCs = new List<CNPC>();

        //
        //List<NetState> VisibleClients;			// A list of visible clients
        //List<CDrop> VisibleDrops;			// A list of visible dropped objects
        //List<CMonster> VisibleMonsters;		// A list of visible spawned monsters
        //List<CNPC> VisibleNPCs;			// A list of visible NPCs

        List<CDrop> DropsList = new List<CDrop>();

        public List<CMyQuest> MyQuestList = new List<CMyQuest>();

        //***********Clan Info***********
        //int clan_rank;
        //int clanID;
        public int m_iGrade;
        public int m_iBack;
        public int m_iLogo;
        public string m_strClanName;
    }
}
#endregion