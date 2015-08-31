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
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Collections;
using Demo.Mmose.Core.Common;
using Demo.Wow.WorldServer.Common;
#endregion

namespace Demo.Wow.WorldServer.DBC
{
    /// <summary>
    /// 
    /// </summary>
    public static class DBCInstances
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<AreaTableEntry> s_AreaTableEntry = new DataStore<AreaTableEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<AreaTableEntry> AreaTableEntry
        {
            get { return s_AreaTableEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<AuctionHouseEntry> s_AuctionHouseEntry = new DataStore<AuctionHouseEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<AuctionHouseEntry> AuctionHouseEntry
        {
            get { return s_AuctionHouseEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<BankBagSlotPricesEntry> s_BankBagSlotPricesEntry = new DataStore<BankBagSlotPricesEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<BankBagSlotPricesEntry> BankBagSlotPricesEntry
        {
            get { return s_BankBagSlotPricesEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<BattlemasterListEntry> s_BattlemasterListEntry = new DataStore<BattlemasterListEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<BattlemasterListEntry> BattlemasterListEntry
        {
            get { return s_BattlemasterListEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<ChatChannelsEntry> s_ChatChannelsEntry = new DataStore<ChatChannelsEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<ChatChannelsEntry> ChatChannelsEntry
        {
            get { return s_ChatChannelsEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<ChrClassesEntry> s_ChrClassesEntry = new DataStore<ChrClassesEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<ChrClassesEntry> ChrClassesEntry
        {
            get { return s_ChrClassesEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<ChrRacesEntry> s_ChrRacesEntry = new DataStore<ChrRacesEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<ChrRacesEntry> ChrRacesEntry
        {
            get { return s_ChrRacesEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<CreatureFamilyEntry> s_CreatureFamilyEntry = new DataStore<CreatureFamilyEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<CreatureFamilyEntry> CreatureFamilyEntry
        {
            get { return s_CreatureFamilyEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<CreatureSpellDataEntry> s_CreatureSpellDataEntry = new DataStore<CreatureSpellDataEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<CreatureSpellDataEntry> CreatureSpellDataEntry
        {
            get { return s_CreatureSpellDataEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<DurabilityCostsEntry> s_DurabilityCostsEntry = new DataStore<DurabilityCostsEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<DurabilityCostsEntry> DurabilityCostsEntry
        {
            get { return s_DurabilityCostsEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<DurabilityQualityEntry> s_DurabilityQualityEntry = new DataStore<DurabilityQualityEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<DurabilityQualityEntry> DurabilityQualityEntry
        {
            get { return s_DurabilityQualityEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<EmotesTextEntry> s_EmotesTextEntry = new DataStore<EmotesTextEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<EmotesTextEntry> EmotesTextEntry
        {
            get { return s_EmotesTextEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<FactionEntry> s_FactionEntry = new DataStore<FactionEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<FactionEntry> FactionEntry
        {
            get { return s_FactionEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<FactionTemplateEntry> s_FactionTemplateEntry = new DataStore<FactionTemplateEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<FactionTemplateEntry> FactionTemplateEntry
        {
            get { return s_FactionTemplateEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<GemPropertiesEntry> s_GemPropertiesEntry = new DataStore<GemPropertiesEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<GemPropertiesEntry> GemPropertiesEntry
        {
            get { return s_GemPropertiesEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<ItemExtendedCostEntry> s_ItemExtendedCostEntry = new DataStore<ItemExtendedCostEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<ItemExtendedCostEntry> ItemExtendedCostEntry
        {
            get { return s_ItemExtendedCostEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<ItemRandomPropertiesEntry> s_ItemRandomPropertiesEntry = new DataStore<ItemRandomPropertiesEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<ItemRandomPropertiesEntry> ItemRandomPropertiesEntry
        {
            get { return s_ItemRandomPropertiesEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<ItemSetEntry> s_ItemSetEntry = new DataStore<ItemSetEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<ItemSetEntry> ItemSetEntry
        {
            get { return s_ItemSetEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<LockEntry> s_LockEntry = new DataStore<LockEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<LockEntry> LockEntry
        {
            get { return s_LockEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<MapEntry> s_MapEntry = new DataStore<MapEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<MapEntry> MapEntry
        {
            get { return s_MapEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<NameGenEntry> s_NameGenEntry = new DataStore<NameGenEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<NameGenEntry> NameGenEntry
        {
            get { return s_NameGenEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<SkillLineAbilityEntry> s_SkillLineAbilityEntry = new DataStore<SkillLineAbilityEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<SkillLineAbilityEntry> SkillLineAbilityEntry
        {
            get { return s_SkillLineAbilityEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<SkillLineEntry> s_SkillLineEntry = new DataStore<SkillLineEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<SkillLineEntry> SkillLineEntry
        {
            get { return s_SkillLineEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<SpellCastTimesEntry> s_SpellCastTimesEntry = new DataStore<SpellCastTimesEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<SpellCastTimesEntry> SpellCastTimesEntry
        {
            get { return s_SpellCastTimesEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<SpellDurationEntry> s_SpellDurationEntry = new DataStore<SpellDurationEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<SpellDurationEntry> SpellDurationEntry
        {
            get { return s_SpellDurationEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<SpellEntry> s_SpellEntry = new DataStore<SpellEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<SpellEntry> SpellEntry
        {
            get { return s_SpellEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<SpellItemEnchantmentConditionEntry> s_SpellItemEnchantmentConditionEntry = new DataStore<SpellItemEnchantmentConditionEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<SpellItemEnchantmentConditionEntry> SpellItemEnchantmentConditionEntry
        {
            get { return s_SpellItemEnchantmentConditionEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<SpellItemEnchantmentEntry> s_SpellItemEnchantmentEntry = new DataStore<SpellItemEnchantmentEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<SpellItemEnchantmentEntry> SpellItemEnchantmentEntry
        {
            get { return s_SpellItemEnchantmentEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<SpellRadiusEntry> s_SpellRadiusEntry = new DataStore<SpellRadiusEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<SpellRadiusEntry> SpellRadiusEntry
        {
            get { return s_SpellRadiusEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<SpellRangeEntry> s_SpellRangeEntry = new DataStore<SpellRangeEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<SpellRangeEntry> SpellRangeEntry
        {
            get { return s_SpellRangeEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<StableSlotPricesEntry> s_StableSlotPricesEntry = new DataStore<StableSlotPricesEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<StableSlotPricesEntry> StableSlotPricesEntry
        {
            get { return s_StableSlotPricesEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<TalentEntry> s_TalentEntry = new DataStore<TalentEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<TalentEntry> TalentEntry
        {
            get { return s_TalentEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<TalentTabEntry> s_TalentTabEntry = new DataStore<TalentTabEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<TalentTabEntry> TalentTabEntry
        {
            get { return s_TalentTabEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<TaxiNodesEntry> s_TaxiNodesEntry = new DataStore<TaxiNodesEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<TaxiNodesEntry> TaxiNodesEntry
        {
            get { return s_TaxiNodesEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<TaxiPathEntry> s_TaxiPathEntry = new DataStore<TaxiPathEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<TaxiPathEntry> TaxiPathEntry
        {
            get { return s_TaxiPathEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<TaxiPathNodeEntry> s_TaxiPathNodeEntry = new DataStore<TaxiPathNodeEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<TaxiPathNodeEntry> TaxiPathNodeEntry
        {
            get { return s_TaxiPathNodeEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<TransportAnimationEntry> s_TransportAnimationEntry = new DataStore<TransportAnimationEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<TransportAnimationEntry> TransportAnimationEntry
        {
            get { return s_TransportAnimationEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<WorldMapAreaEntry> s_WorldMapAreaEntry = new DataStore<WorldMapAreaEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<WorldMapAreaEntry> WorldMapAreaEntry
        {
            get { return s_WorldMapAreaEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<WorldMapOverlayEntry> s_WorldMapOverlayEntry = new DataStore<WorldMapOverlayEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<WorldMapOverlayEntry> WorldMapOverlayEntry
        {
            get { return s_WorldMapOverlayEntry; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static DataStore<WorldSafeLocsEntry> s_WorldSafeLocsEntry = new DataStore<WorldSafeLocsEntry>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static DataStore<WorldSafeLocsEntry> WorldSafeLocsEntry
        {
            get { return s_WorldSafeLocsEntry; }
        }
        #endregion

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<uint, uint> s_AreaFlagByAreaID = new Dictionary<uint, uint>();
        #endregion

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<uint, uint> s_AreaFlagByMapID = new Dictionary<uint, uint>();
        #endregion

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        public static MultiDictionary<uint, uint> s_SpellCategory = new MultiDictionary<uint, uint>( false );
        #endregion

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<uint, uint> s_TalentSpellCosts = new Dictionary<uint, uint>();
        #endregion

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        public static uint[] s_TaxiNodesMask = new uint[32];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public struct TaxiPathBySourceAndDestination
        {
            public uint m_ID;
            public uint m_Price;
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<uint, Dictionary<uint, TaxiPathBySourceAndDestination>> s_TaxiPathSetBySource = new Dictionary<uint, Dictionary<uint, TaxiPathBySourceAndDestination>>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public struct TaxiPathNode
        {
            public uint m_MapId;
            public float m_X;
            public float m_Y;
            public float m_Z;
            public uint m_ActionFlag;
            public uint m_WaitTime;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<uint, Dictionary<uint, TaxiPathNode>> s_TaxiPathNodesByPath = new Dictionary<uint, Dictionary<uint, TaxiPathNode>>();

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool LoadDBCFiles( string strDirectory )
        {
            ConsoleProgressBar consoleProgressBar = new ConsoleProgressBar( 40 );
            consoleProgressBar.BeginStep( string.Format( "开始读取文件 {0}\\*.dbc", strDirectory ) );

            string strFileName = strDirectory + "\\AreaTable.dbc";
            if ( s_AreaTableEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\AuctionHouse.dbc";
            if ( s_AuctionHouseEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\BankBagSlotPrices.dbc";
            if ( s_BankBagSlotPricesEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\BattlemasterList.dbc";
            if ( s_BattlemasterListEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\ChatChannels.dbc";
            if ( s_ChatChannelsEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\ChrClasses.dbc";
            if ( s_ChrClassesEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\ChrRaces.dbc";
            if ( s_ChrRacesEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\CreatureFamily.dbc";
            if ( s_CreatureFamilyEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\CreatureSpellData.dbc";
            if ( s_CreatureSpellDataEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\DurabilityCosts.dbc";
            if ( s_DurabilityCostsEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\DurabilityQuality.dbc";
            if ( s_DurabilityQualityEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\EmotesText.dbc";
            if ( s_EmotesTextEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\Faction.dbc";
            if ( s_FactionEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\FactionTemplate.dbc";
            if ( s_FactionTemplateEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\GemProperties.dbc";
            if ( s_GemPropertiesEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\ItemExtendedCost.dbc";
            if ( s_ItemExtendedCostEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\ItemRandomProperties.dbc";
            if ( s_ItemRandomPropertiesEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\ItemSet.dbc";
            if ( s_ItemSetEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\Lock.dbc";
            if ( s_LockEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\Map.dbc";
            if ( s_MapEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\NameGen.dbc";
            if ( s_NameGenEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\SkillLineAbility.dbc";
            if ( s_SkillLineAbilityEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\SkillLine.dbc";
            if ( s_SkillLineEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\SpellCastTimes.dbc";
            if ( s_SpellCastTimesEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\SpellDuration.dbc";
            if ( s_SpellDurationEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\Spell.dbc";
            if ( s_SpellEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\SpellItemEnchantmentCondition.dbc";
            if ( s_SpellItemEnchantmentConditionEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\SpellItemEnchantment.dbc";
            if ( s_SpellItemEnchantmentEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\SpellRadius.dbc";
            if ( s_SpellRadiusEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\SpellRange.dbc";
            if ( s_SpellRangeEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\StableSlotPrices.dbc";
            if ( s_StableSlotPricesEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\Talent.dbc";
            if ( s_TalentEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\TalentTab.dbc";
            if ( s_TalentTabEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\TaxiNodes.dbc";
            if ( s_TaxiNodesEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\TaxiPath.dbc";
            if ( s_TaxiPathEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\TaxiPathNode.dbc";
            if ( s_TaxiPathNodeEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\TransportAnimation.dbc";
            if ( s_TransportAnimationEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\WorldMapArea.dbc";
            if ( s_WorldMapAreaEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\WorldMapOverlay.dbc";
            if ( s_WorldMapOverlayEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            strFileName = strDirectory + "\\WorldSafeLocs.dbc";
            if ( s_WorldSafeLocsEntry.LoadFile( strFileName ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "读取文件 {0} 失败!", strFileName );

                return false;
            }
            consoleProgressBar.Step();

            consoleProgressBar.EndStep( string.Format( "完成读取文件 {0}\\*.dbc", strDirectory ) );

            // must be after sAreaStore and sMapStore loading
            for ( uint iIndex = 0; iIndex < s_AreaTableEntry.Count; ++iIndex )
            {
                AreaTableEntry areaTableEntry = s_AreaTableEntry.LookupRowEntry( iIndex );

                if ( areaTableEntry != null )
                {
                    // fill AreaId->DBC records
                    s_AreaFlagByAreaID.Add( areaTableEntry.ID, areaTableEntry.m_ExplorationFlag );

                    // fill MapId->DBC records
                    if ( areaTableEntry.m_ZoneId == 0 )   // not sub-zone
                    {
                        MapEntry mapEntry = s_MapEntry.LookupIDEntry( areaTableEntry.m_MapId );
                        if ( mapEntry == null )
                            continue;

                        if ( mapEntry.m_MapType != 0 /*MAP_COMMON*/) // 有不用的值？
                            s_AreaFlagByMapID[areaTableEntry.m_MapId] = areaTableEntry.m_ExplorationFlag;
                    }
                }
            }

            for ( uint iIndex = 0; iIndex < s_SpellEntry.Count; ++iIndex )
            {
                SpellEntry spellEntry = s_SpellEntry.LookupRowEntry( iIndex );
                if ( spellEntry == null )
                    continue;

                if ( spellEntry.m_Category != 0 )
                    s_SpellCategory.Add( spellEntry.m_Category, iIndex );
            }

            // create telent spells set
            for ( uint iIndex = 0; iIndex < s_TalentEntry.Count; ++iIndex )
            {
                TalentEntry talentEntry = s_TalentEntry.LookupRowEntry( iIndex );
                if ( talentEntry == null )
                    continue;

                if ( talentEntry.m_RankID1 != 0 )
                {
                    s_TalentSpellCosts.Add( talentEntry.m_RankID1, 1 );
                }

                if ( talentEntry.m_RankID2 != 0 )
                {
                    s_TalentSpellCosts.Add( talentEntry.m_RankID2, 2 );
                }

                if ( talentEntry.m_RankID3 != 0 )
                {
                    s_TalentSpellCosts.Add( talentEntry.m_RankID3, 3 );
                }

                if ( talentEntry.m_RankID4 != 0 )
                {
                    s_TalentSpellCosts.Add( talentEntry.m_RankID4, 4 );
                }

                if ( talentEntry.m_RankID5 != 0 )
                {
                    s_TalentSpellCosts.Add( talentEntry.m_RankID5, 5 );
                }
            }

            // Initialize global taxinodes mask
            for ( uint iIndex = 0; iIndex < s_TalentEntry.Count; ++iIndex )
            {
                TalentEntry talentEntry = s_TalentEntry.LookupRowEntry( iIndex );
                if ( talentEntry != null )
                {
                    uint field = ( iIndex / 32 );
                    uint submask = (uint)( 1 << (int)( iIndex % 32 ) );
                    s_TaxiNodesMask[field] |= submask;
                }
            }

            for ( uint iIndex = 0; iIndex < s_TaxiPathEntry.Count; ++iIndex )
            {
                TaxiPathEntry taxiPathEntry = s_TaxiPathEntry.LookupRowEntry( iIndex );
                if ( taxiPathEntry == null )
                    continue;

                Dictionary<uint, TaxiPathBySourceAndDestination> taxiPathSetForSource = null;
                s_TaxiPathSetBySource.TryGetValue( taxiPathEntry.m_From, out taxiPathSetForSource );

                if ( taxiPathSetForSource == null )
                {
                    taxiPathSetForSource = new Dictionary<uint, TaxiPathBySourceAndDestination>();
                    TaxiPathBySourceAndDestination taxiPathBySourceAndDestination = new TaxiPathBySourceAndDestination();
                    taxiPathBySourceAndDestination.m_ID = taxiPathEntry.ID;
                    taxiPathBySourceAndDestination.m_Price = taxiPathEntry.m_Price;

                    taxiPathSetForSource.Add( taxiPathEntry.m_To, taxiPathBySourceAndDestination );

                    s_TaxiPathSetBySource.Add( taxiPathEntry.m_From, taxiPathSetForSource );
                }
                else
                {
                    TaxiPathBySourceAndDestination taxiPathBySourceAndDestination = new TaxiPathBySourceAndDestination();
                    taxiPathBySourceAndDestination.m_ID = taxiPathEntry.ID;
                    taxiPathBySourceAndDestination.m_Price = taxiPathEntry.m_Price;

                    taxiPathSetForSource.Add( taxiPathEntry.m_To, taxiPathBySourceAndDestination );
                }
            }

            for ( uint iIndex = 0; iIndex < s_TaxiPathNodeEntry.Count; ++iIndex )
            {
                TaxiPathNodeEntry taxiPathNodeEntry = s_TaxiPathNodeEntry.LookupRowEntry( iIndex );
                if ( taxiPathNodeEntry == null )
                    continue;

                Dictionary<uint, TaxiPathNode> taxiPathNodeSeq = null;
                s_TaxiPathNodesByPath.TryGetValue( taxiPathNodeEntry.m_Path, out taxiPathNodeSeq );

                if ( taxiPathNodeSeq == null )
                {
                    taxiPathNodeSeq = new Dictionary<uint, TaxiPathNode>();
                    TaxiPathNode taxiPathNode = new TaxiPathNode();
                    taxiPathNode.m_MapId = taxiPathNodeEntry.m_MapId;
                    taxiPathNode.m_X = taxiPathNodeEntry.m_X;
                    taxiPathNode.m_Y = taxiPathNodeEntry.m_Y;
                    taxiPathNode.m_Z = taxiPathNodeEntry.m_Z;
                    taxiPathNode.m_ActionFlag = taxiPathNodeEntry.m_ActionFlag;
                    taxiPathNode.m_WaitTime = taxiPathNodeEntry.m_WaitTime;

                    taxiPathNodeSeq.Add( taxiPathNodeEntry.m_Seq, taxiPathNode );

                    s_TaxiPathNodesByPath.Add( taxiPathNodeEntry.m_Path, taxiPathNodeSeq );
                }
                else
                {
                    TaxiPathNode taxiPathNode = new TaxiPathNode();
                    taxiPathNode.m_MapId = taxiPathNodeEntry.m_MapId;
                    taxiPathNode.m_X = taxiPathNodeEntry.m_X;
                    taxiPathNode.m_Y = taxiPathNodeEntry.m_Y;
                    taxiPathNode.m_Z = taxiPathNodeEntry.m_Z;
                    taxiPathNode.m_ActionFlag = taxiPathNodeEntry.m_ActionFlag;
                    taxiPathNode.m_WaitTime = taxiPathNodeEntry.m_WaitTime;

                    taxiPathNodeSeq.Add( taxiPathNodeEntry.m_Seq, taxiPathNode );
                }
            }

            return false;
        }
        #endregion
    }
}
#endregion