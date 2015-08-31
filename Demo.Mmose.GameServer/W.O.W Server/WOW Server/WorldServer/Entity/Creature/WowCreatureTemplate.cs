using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Suit.Treasure;

namespace Demo.Wow.WorldServer.Creature
{
    /// <summary>
    /// 
    /// </summary>
    public class WowCreatureTemplate : BaseCreatureTemplate
    {
        #region zh-CHS 游戏人物的信息 | en

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureModelId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ModelId
        {
            get { return m_CreatureModelId; }
            set { m_CreatureModelId = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_CreatureName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_CreatureName; }
            set { m_CreatureName = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_CreatureSubName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string SubName
        {
            get { return m_CreatureSubName; }
            set { m_CreatureSubName = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMinLevel = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MinLevel
        {
            get { return m_CreatureMinLevel; }
            set { m_CreatureMinLevel = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMaxLevel = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxLevel
        {
            get { return m_CreatureMaxLevel; }
            set { m_CreatureMaxLevel = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMinHealth = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MinHealth
        {
            get { return m_CreatureMinHealth; }
            set { m_CreatureMinHealth = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMaxHealth = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxHealth
        {
            get { return m_CreatureMaxHealth; }
            set { m_CreatureMaxHealth = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMinMana = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MinMana
        {
            get { return m_CreatureMinMana; }
            set { m_CreatureMinMana = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMaxMana = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxMana
        {
            get { return m_CreatureMaxMana; }
            set { m_CreatureMaxMana = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureAttackPower = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint AttackPower
        {
            get { return m_CreatureAttackPower; }
            set { m_CreatureAttackPower = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CreatureMinDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float MinDamage
        {
            get { return m_CreatureMinDamage; }
            set { m_CreatureMinDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CreatureMaxDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float MaxDamage
        {
            get { return m_CreatureMaxDamage; }
            set { m_CreatureMaxDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureBaseAttackTime = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint BaseAttackTime
        {
            get { return m_CreatureBaseAttackTime; }
            set { m_CreatureBaseAttackTime = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureRangedAttackPower = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RangedAttackPower
        {
            get { return m_CreatureRangedAttackPower; }
            set { m_CreatureRangedAttackPower = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CreatureMinRangeDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float MinRangeDamage
        {
            get { return m_CreatureMinRangeDamage; }
            set { m_CreatureMinRangeDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CreatureMaxRangeDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float MaxRangeDamage
        {
            get { return m_CreatureMaxRangeDamage; }
            set { m_CreatureMaxRangeDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureRangeAttackTime = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RangeAttackTime
        {
            get { return m_CreatureRangeAttackTime; }
            set { m_CreatureRangeAttackTime = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CreatureCombatReach = 0;
        #endregion
        /// <summary>
        /// 可以攻击玩家的战斗范围
        /// </summary>
        public float CombatReach
        {
            get { return m_CreatureCombatReach; }
            set { m_CreatureCombatReach = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CreatureBoundingRadius = 0;
        #endregion
        /// <summary>
        /// 可以攻击玩家的范围
        /// </summary>
        public float BoundingRadius
        {
            get { return m_CreatureBoundingRadius; }
            set { m_CreatureBoundingRadius = value; }
        }


        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureArmor = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Armor
        {
            get { return m_CreatureArmor; }
            set { m_CreatureArmor = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CreatureSpeed = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Speed
        {
            get { return m_CreatureSpeed; }
            set { m_CreatureSpeed = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CreatureSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Size
        {
            get { return m_CreatureSize; }
            set { m_CreatureSize = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureClass = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Class
        {
            get { return m_CreatureClass; }
            set { m_CreatureClass = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureRace = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Race
        {
            get { return m_CreatureRace; }
            set { m_CreatureRace = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureFaction = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Faction
        {
            get { return m_CreatureFaction; }
            set { m_CreatureFaction = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureRank = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Rank
        {
            get { return m_CreatureRank; }
            set { m_CreatureRank = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMount = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Mount
        {
            get { return m_CreatureMount; }
            set { m_CreatureMount = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureFamily = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Family
        {
            get { return m_CreatureFamily; }
            set { m_CreatureFamily = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureType = 0;
        #endregion
        /// <summary>
        /// 当"家族"为0时"类型"有效
        /// </summary>
        public uint Type
        {
            get { return m_CreatureType; }
            set { m_CreatureType = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_CreatureCivilian = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool Civilian
        {
            get { return m_CreatureCivilian; }
            set { m_CreatureCivilian = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMovementType = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MovementType
        {
            get { return m_CreatureMovementType; }
            set { m_CreatureMovementType = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureInhabitType = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint InhabitType
        {
            get { return m_CreatureInhabitType; }
            set { m_CreatureInhabitType = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureNPCFlag = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint NPCFlag
        {
            get { return m_CreatureNPCFlag; }
            set { m_CreatureNPCFlag = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureTrainerType = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint TrainerType
        {
            get { return m_CreatureTrainerType; }
            set { m_CreatureTrainerType = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureTrainerSpell = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint TrainerSpell
        {
            get { return m_CreatureTrainerSpell; }
            set { m_CreatureTrainerSpell = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowCreatureEquip[] m_EquipInfo = new WowCreatureEquip[3];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowCreatureEquip[] EquipInfo
        {
            get { return m_EquipInfo; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowCreatureSpell[] m_SpellInfo = new WowCreatureSpell[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowCreatureSpell[] SpellInfo
        {
            get { return m_SpellInfo; }
        }

        #endregion

        #region zh-CHS 游戏人物抗性的信息 | en

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureHolyResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint HolyResistance
        {
            get { return m_CreatureHolyResistance; }
            set { m_CreatureHolyResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureFireResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FireResistance
        {
            get { return m_CreatureFireResistance; }
            set { m_CreatureFireResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureNatureResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint NatureResistance
        {
            get { return m_CreatureNatureResistance; }
            set { m_CreatureNatureResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureFrostResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FrostResistance
        {
            get { return m_CreatureFrostResistance; }
            set { m_CreatureFrostResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureShadowResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ShadowResistance
        {
            get { return m_CreatureShadowResistance; }
            set { m_CreatureShadowResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureArcaneResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ArcaneResistance
        {
            get { return m_CreatureArcaneResistance; }
            set { m_CreatureArcaneResistance = value; }
        }

        #endregion

        #region zh-CHS 游戏人物内物品掉落的信息 | en

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_SkinTreasure = new OneTreasure[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] SkinTreasure
        {
            get { return m_SkinTreasure; }
            set { m_SkinTreasure = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_ItemTreasure = new OneTreasure[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] ItemTreasure
        {
            get { return m_ItemTreasure; }
            set { m_ItemTreasure = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_ItemQuestTreasure = new OneTreasure[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] QuestTreasure
        {
            get { return m_ItemQuestTreasure; }
            set { m_ItemQuestTreasure = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_GoldTreasure = new OneTreasure[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] GoldTreasure
        {
            get { return m_GoldTreasure; }
            set { m_GoldTreasure = value; }
        }

        #endregion

        #region zh-CHS 游戏人物包含的任务的信息 | en
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowObjectQuests m_CreatureQuests = new WowObjectQuests();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowObjectQuests Quests
        {
            get { return m_CreatureQuests; }
        }
        #endregion
    }
}
