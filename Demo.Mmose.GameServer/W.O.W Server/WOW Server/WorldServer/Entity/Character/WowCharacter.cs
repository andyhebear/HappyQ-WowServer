using System;
using System.Linq;
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Entity.Character;
using Demo.Wow.Database;
using Demo.Wow.Database.Ver1a;
using Demo.Wow.WorldServer.Ability.Skill;
using Demo.Wow.WorldServer.Ability.Spell;
using Demo.Wow.WorldServer.Ability.Talent;
using Demo.Wow.WorldServer.Item;
using Demo.Wow.WorldServer.Reputation;
using DevExpress.Xpo;
using Demo.Mmose.Core.Entity.Suit.Ability.Spell;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Entity.Suit.Ability.Skill;
using Demo.Wow.WorldServer.Entity.Fields;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.Entity;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;
using Demo.Wow.WorldServer.Network;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common.Component;

namespace Demo.Wow.WorldServer.Character
{
    /// <summary>
    /// wow玩家的信息
    /// </summary>
    public partial class WowCharacter : BaseCharacter
    {
        #region zh-CHS 内部常量 | en Internal Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint WOW_MAX_CHARACTER_COUNT = 8;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultCreatureInit()
        {
            base.DefaultCreatureInit();

            m_WowItemBagManager = new WowItemBagManager( this );
            m_WowItemBankManager = new WowItemBankManager( this );

            base.Slice += new EventHandler<ProcessSliceEventArgs>( this.OnUpdate );

            // IWowUpdate
            this.RegisterComponent<IWowUpdate>( WowUpdate.WOW_UPDATE_COMPONENT_ID, this );

            // Save
            base.SaveWorldEntity += new EventHandler<WorldEntityEventArgs>( this.WowCharacterSave );

            // CharacterField
            this.PlayerField.EventRequestUpdate += new RequestUpdateEventHandler( this.OnFieldRequestUpdate );
        }
        #endregion

        #region zh-CHS 属性 | en Public Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CharacterAccountGuid = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long AccountGuid
        {
            get { return m_CharacterAccountGuid; }
            set { m_CharacterAccountGuid = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CharacterGuid = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long CharacterGuid
        {
            get { return m_CharacterGuid; }
            set { m_CharacterGuid = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CharacterGuildGuid = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long GuildGuid
        {
            get { return m_CharacterGuildGuid; }
            set { m_CharacterGuildGuid = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsTBC = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsTBC
        {
            get { return m_IsTBC; }
            set { m_IsTBC = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsBanned = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsBanned
        {
            get { return m_IsBanned; }
            set { m_IsBanned = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsOnline = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsOnline
        {
            get { return m_IsOnline; }
            set { m_IsOnline = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_LastPing = DateTime.MinValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastPing
        {
            get { return m_LastPing; }
            set { m_LastPing = value; }
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterLevel = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Level
        {
            get { return m_CharacterLevel; }
            set { m_CharacterLevel = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MaxLevel = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxLevel
        {
            get { return m_MaxLevel; }
            set { m_MaxLevel = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterHealth = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Health
        {
            get { return m_CharacterHealth; }
            set { m_CharacterHealth = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterMaxHealth = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxHealth
        {
            get { return m_CharacterMaxHealth; }
            set { m_CharacterMaxHealth = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterBaseHealth = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint BaseHealth
        {
            get { return m_CharacterBaseHealth; }
            set { m_CharacterBaseHealth = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterMana = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Mana
        {
            get { return m_CharacterMana; }
            set { m_CharacterMana = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterMaxMana = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxMana
        {
            get { return m_CharacterMaxMana; }
            set { m_CharacterMaxMana = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterBaseMana = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint BaseMana
        {
            get { return m_CharacterBaseMana; }
            set { m_CharacterBaseMana = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterStrength = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Strength
        {
            get { return m_CharacterStrength; }
            set { m_CharacterStrength = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterAgility = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Agility
        {
            get { return m_CharacterAgility; }
            set { m_CharacterAgility = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterStamina = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Stamina
        {
            get { return m_CharacterStamina; }
            set { m_CharacterStamina = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterIntellect = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Intellect
        {
            get { return m_CharacterIntellect; }
            set { m_CharacterIntellect = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CharacterSpirit = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Spirit
        {
            get { return m_CharacterSpirit; }
            set { m_CharacterSpirit = value; }
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
        private uint m_CreatureGender = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Gender
        {
            get { return m_CreatureGender; }
            set { m_CreatureGender = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureSkin = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Skin
        {
            get { return m_CreatureSkin; }
            set { m_CreatureSkin = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureFace = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Face
        {
            get { return m_CreatureFace; }
            set { m_CreatureFace = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureHairStyle = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint HairStyle
        {
            get { return m_CreatureHairStyle; }
            set { m_CreatureHairStyle = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureHairColor = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint HairColor
        {
            get { return m_CreatureHairColor; }
            set { m_CreatureHairColor = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureFacialHair = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FacialHair
        {
            get { return m_CreatureFacialHair; }
            set { m_CreatureFacialHair = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MapId = 0;
        #endregion
        /// <summary>
        /// 人物的地图
        /// </summary>
        public uint MapId
        {
            get { return m_MapId; }
            set { m_MapId = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_BindMapId = 0;
        #endregion
        /// <summary>
        /// 人物的地图
        /// </summary>
        public uint BindMapId
        {
            get { return m_BindMapId; }
            set { m_BindMapId = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ZoneId = 0;
        #endregion
        /// <summary>
        /// 人物的地域
        /// </summary>
        public uint ZoneId
        {
            get { return m_ZoneId; }
            set { m_ZoneId = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_BindZoneId = 0;
        #endregion
        /// <summary>
        /// 人物的地域
        /// </summary>
        public uint BindZoneId
        {
            get { return m_BindZoneId; }
            set { m_BindZoneId = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_BindPositionX = 0;
        #endregion
        /// <summary>
        /// 人物 所在的 X坐标
        /// </summary>
        public float BindX
        {
            get { return m_BindPositionX; }
            set { m_BindPositionX = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_BindPositionY = 0;
        #endregion
        /// <summary>
        /// 人物 所在的 Y坐标
        /// </summary>
        public float BindY
        {
            get { return m_BindPositionY; }
            set { m_BindPositionY = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_BindPositionZ = 0;
        #endregion
        /// <summary>
        /// 人物 所在的 Z坐标
        /// </summary>
        public float BindZ
        {
            get { return m_BindPositionZ; }
            set { m_BindPositionZ = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_TeamId = 0;
        #endregion
        /// <summary>
        /// 人物 联盟或部落 编号
        /// </summary>
        public byte TeamId
        {
            get { return m_TeamId; }
            set { m_TeamId = value; }
        }


        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint[] m_TaxiMask = new uint[8];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint[] TaxiMask
        {
            get { return m_TaxiMask; }
            set { m_TaxiMask = value; }
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
        private uint m_CreatureRage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Rage
        {
            get { return m_CreatureRage; }
            set { m_CreatureRage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMaxRage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxRage
        {
            get { return m_CreatureMaxRage; }
            set { m_CreatureMaxRage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureFocus = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Focus
        {
            get { return m_CreatureFocus; }
            set { m_CreatureFocus = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMaxFocus = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxFocus
        {
            get { return m_CreatureMaxFocus; }
            set { m_CreatureMaxFocus = value; }
        }


        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureEnergy = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Energy
        {
            get { return m_CreatureEnergy; }
            set { m_CreatureEnergy = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureMaxEnergy = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxEnergy
        {
            get { return m_CreatureMaxEnergy; }
            set { m_CreatureMaxEnergy = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureFactionTemplate = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FactionTemplate
        {
            get { return m_CreatureFactionTemplate; }
            set { m_CreatureFactionTemplate = value; }
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
        private uint m_CreatureDisplayId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint DisplayId
        {
            get { return m_CreatureDisplayId; }
            set { m_CreatureDisplayId = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureNativeDisplayId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint NativeDisplayId
        {
            get { return m_CreatureNativeDisplayId; }
            set { m_CreatureNativeDisplayId = value; }
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
        private uint m_PowerType = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PowerType
        {
            get { return m_PowerType; }
            set { m_PowerType = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_NextLevelXP = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint NextLevelXP
        {
            get { return m_NextLevelXP; }
            set { m_NextLevelXP = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowSkillHandler m_WowSkillManager = new WowSkillHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowSkillHandler SkillManager
        {
            get { return m_WowSkillManager; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowSpellHandler m_WowSpellManager = new WowSpellHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowSpellHandler SpellManager
        {
            get { return m_WowSpellManager; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowSpellCooldownHandler m_WowSpellCooldownManager = new WowSpellCooldownHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowSpellCooldownHandler SpellCooldownManager
        {
            get { return m_WowSpellCooldownManager; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowTalentHandler m_WowTalentManager = new WowTalentHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowTalentHandler TalentManager
        {
            get { return m_WowTalentManager; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowItemBagManager m_WowItemBagManager = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowItemBagManager BagManager
        {
            get { return m_WowItemBagManager; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowItemBankManager m_WowItemBankManager = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowItemBankManager BankManager
        {
            get { return m_WowItemBankManager; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowActionBarManager m_WowActionBarManager = new WowActionBarManager();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowActionBarManager ActionBarManager
        {
            get { return m_WowActionBarManager; }
        }
        
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowReputationHandler m_WowReputationManager = new WowReputationHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowReputationHandler ReputationManager
        {
            get { return m_WowReputationManager; }
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_QueuedForUpdate = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool QueuedForUpdate
        {
            get { return m_QueuedForUpdate; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_isInWorld = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsInWorld
        {
            get { return m_isInWorld; }
            internal set { m_isInWorld = value; }
        }

        UnitMechanics m_UnitMechanics = null;
        bool m_IsSpiritHealer = false;

    }
}
