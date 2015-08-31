using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    public partial class CharacterField
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly int s_DamageSchoolCount = (int)Utility.GetMaxEnumValue<DamageSchool>() + 1;

        #region BYTES

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_PlayerBytes = new byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] PlayerBytes
        {
            get { return m_PlayerBytes; }
            set
            {
                m_PlayerBytes = value;
                SetByteArray( (int)PlayerFields.BYTES, m_PlayerBytes );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte Skin
        {
            get { return m_PlayerBytes[0]; }
            set
            {
                m_PlayerBytes[0] = value;
                SetByte( (int)PlayerFields.BYTES, 0, m_PlayerBytes[0] );
            }
        }

        public byte Face
        {
            get { return m_PlayerBytes[1]; }
            set
            {
                m_PlayerBytes[1] = value;
                SetByte( (int)PlayerFields.BYTES, 1, m_PlayerBytes[1] );
            }
        }

        public byte HairStyle
        {
            get { return m_PlayerBytes[2]; }
            set
            {
                m_PlayerBytes[2] = value;
                SetByte( (int)PlayerFields.BYTES, 2, m_PlayerBytes[2] );
            }
        }

        public byte HairColor
        {
            get { return m_PlayerBytes[3]; }
            set
            {
                m_PlayerBytes[3] = value;
                SetByte( (int)PlayerFields.BYTES, 3, m_PlayerBytes[3] );
            }
        }

        #endregion

        #region BYTES_2

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_PlayerBytes2 = new byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] PlayerBytes2
        {
            get { return m_PlayerBytes2; }
            set
            {
                m_PlayerBytes2 = value;
                SetByteArray( (int)PlayerFields.BYTES_2, m_PlayerBytes2 );
            }
        }

        public byte FacialHair
        {
            get { return m_PlayerBytes2[0]; }
            set
            {
                m_PlayerBytes2[0] = value;
                SetByte( (int)PlayerFields.BYTES_2, 0, m_PlayerBytes2[0] );
            }
        }

        public byte PlayerBytes2_2
        {
            get { return m_PlayerBytes2[1]; }
            set
            {
                m_PlayerBytes2[1] = value;
                SetByte( (int)PlayerFields.BYTES_2, 1, m_PlayerBytes2[1] );
            }
        }

        /// <summary>
        /// Use player.Inventory.BankBags.Inc/DecBagSlots() to change the amount of cont slots in use
        /// </summary>
        public byte BankBagSlots
        {
            get { return m_PlayerBytes2[2]; }
            internal set
            {
                m_PlayerBytes2[2] = value;
                SetByte( (int)PlayerFields.BYTES_2, 2, m_PlayerBytes2[2] );
            }
        }

        /// <summary>
        /// 0x01 -> Rested State
        /// 0x02 -> Normal State
        /// </summary>
        public RestState RestState
        {
            get { return (RestState)m_PlayerBytes2[3]; }
            set
            {
                m_PlayerBytes2[3] = (byte)value;
                SetByte( (int)PlayerFields.BYTES_2, 3, m_PlayerBytes2[3] );
            }
        }

        #endregion

        #region BYTES_3

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_PlayerBytes3 = new byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] PlayerBytes3
        {
            get { return m_PlayerBytes3; }
            set
            {
                m_PlayerBytes3 = value;
                SetByteArray( (int)PlayerFields.BYTES_3, m_PlayerBytes3 );
            }
        }

        public override GenderType Gender
        {
            get { return (GenderType)m_PlayerBytes3[0]; }
            set
            {
                base.Gender = value;

                m_PlayerBytes3[0] = (byte)value;
                SetByte( (int)PlayerFields.BYTES_3, 0, m_PlayerBytes3[0] );
            }
        }

        /// <summary>
        /// Totally smashed
        /// 60 Drunk
        /// 30 Tipsy
        /// </summary>
        public byte DrunkState
        {
            get { return m_PlayerBytes3[1]; }
            set
            {
                if ( value > 100 )
                    value = 100;

                m_PlayerBytes3[1] = value;

                SetByte( (int)PlayerFields.BYTES_3, 1, m_PlayerBytes3[1] );
            }
        }

        public byte PlayerBytes3_3
        {
            get { return m_PlayerBytes3[2]; }
            set
            {
                m_PlayerBytes3[2] = value;
                SetByte( (int)PlayerFields.BYTES_3, 2, m_PlayerBytes3[2] );
            }
        }

        public byte PvPRank
        {
            get { return m_PlayerBytes3[3]; }
            set
            {
                m_PlayerBytes3[3] = value;
                SetByte( (int)PlayerFields.BYTES_3, 3, m_PlayerBytes3[3] );
            }
        }

        #endregion

        #region BYTES

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_Bytes = new byte[4];
        #endregion
        /// <summary>
        /// BYTES
        /// </summary>
        public byte[] Bytes
        {
            get { return m_Bytes; }
            set
            {
                m_Bytes = value;
                SetByteArray( (int)PlayerFields.BYTES, m_Bytes );
            }
        }

        /// <summary>
        /// Set to 0x02 when handling AuraType.TrackStealthed (151)
        /// </summary>
        public byte Bytes_1
        {
            get { return m_Bytes[0]; }
            set
            {
                m_Bytes[0] = value;
                SetByte( (int)PlayerFields.BYTES, 0, m_Bytes[0] );
            }
        }

        public byte Bytes_2
        {
            get { return m_Bytes[1]; }
            set
            {
                m_Bytes[1] = value;
                SetByte( (int)PlayerFields.BYTES, 1, m_Bytes[1] );
            }
        }

        public byte ActionBarMask
        {
            get { return m_Bytes[2]; }
            set
            {
                m_Bytes[2] = value;
                SetByte( (int)PlayerFields.BYTES, 2, m_Bytes[2] );
            }
        }

        public byte Bytes_4
        {
            get { return m_Bytes[3]; }
            set
            {
                m_Bytes[3] = value;
                SetByte( (int)PlayerFields.BYTES, 3, m_Bytes[3] );
            }
        }

        #endregion

        #region BYTES2

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_Bytes2 = new byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] Bytes2
        {
            get { return m_Bytes2; }
            set
            {
                m_Bytes2 = value;
                SetByteArray( (int)PlayerFields.BYTES2, m_Bytes2 );
            }
        }

        #endregion

        #region Misc

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private PlayerFlag m_PlayerFlags = PlayerFlag.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public PlayerFlag PlayerFlags
        {
            get { return m_PlayerFlags; }
            set
            {
                m_PlayerFlags = value;
                SetUInt32( (int)PlayerFields.FLAGS, (uint)m_PlayerFlags );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_XP = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint XP
        {
            get { return m_XP; }
            set
            {
                m_XP = value;
                SetUInt32( (int)PlayerFields.XP, m_XP );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
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
            set
            {
                m_NextLevelXP = value;
                SetUInt32( (int)PlayerFields.NEXT_LEVEL_XP, m_NextLevelXP );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Money = 0;
        #endregion
        /// <summary>
        /// Amount of money (total in Copper Coins).
        /// 1 silver = 100 copper,
        /// 1 gold = 10,000 copper
        /// 
        /// Use Set, Add and SubtractMoney methods to savely modify the amount of money
        /// </summary>
        public uint Money
        {
            get { return m_Money; }
            internal set
            {
                if (value < 0)
                    value = 0;

                m_Money = value;
                SetUInt32( (int)PlayerFields.COINAGE, m_Money );
            }
        }


        public void SetMoney( uint amount )
        {
            m_Money = amount;
            SetUInt32( (int)PlayerFields.COINAGE, m_Money );
        }

        /// <summary>
        /// Adds the given amount of money
        /// </summary>
        public void AddMoney( uint amount )
        {
            m_Money += amount;
            SetUInt32( (int)PlayerFields.COINAGE, m_Money );
        }

        /// <summary>
        /// Subtracts the given amount of Money. Returns false if its more than this Character has.
        /// </summary>
        public bool SubtractMoney( uint amount )
        {
            if ( amount > m_Money )
                return false;

            m_Money -= amount;
            SetUInt32( (int)PlayerFields.COINAGE, m_Money );

            return true;
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_WatchedFaction = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint WatchedFaction
        {
            get { return m_WatchedFaction; }
            set
            {
                m_WatchedFaction = value;
                SetUInt32( (int)PlayerFields.WATCHED_FACTION_INDEX, m_WatchedFaction ); 
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ChosenTitle = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ChosenTitle
        {
            get { return m_ChosenTitle; }
            set
            {
                m_ChosenTitle = value;
                SetUInt32( (int)PlayerFields.CHOSEN_TITLE, m_ChosenTitle );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private PvPTitles m_KnownPVPTitles = PvPTitles.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public PvPTitles KnownPVPTitles
        {
            get { return m_KnownPVPTitles; }
            set
            {
                m_KnownPVPTitles = value;
                SetULong64( (int)PlayerFields.KNOWN_TITLES, (ulong)m_KnownPVPTitles );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_KillCount = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint KillCount
        {
            get { return m_KillCount; }
            set
            {
                m_KillCount = value;
                SetUInt32( (int)PlayerFields.KILLS, m_KillCount );
            }
        }

        //public InstanceCollection InstanceCollection
        //{
        //    get { return m_instanceCollection; }
        //    set { m_instanceCollection = value; }
        //}
        #endregion

        #region CombatRatings
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int[] m_CombatRating = new int[24];
        #endregion
        /// <summary>
        /// Gets the total modifier of the corresponding CombatRating (in %)
        /// </summary>
        public int GetCombatRatingMod( CombatRating combatRating )
        {
            return m_CombatRating[(int)combatRating - 1];
        }

        public void SetCombatRatingMod( CombatRating combatRating, int value )
        {
            m_CombatRating[(int)combatRating - 1] = value;
            SetInt32( (int)PlayerFields.COMBAT_RATING_1 - 1 + (int)combatRating, value );
        }

        /// <summary>
        /// Modifies the given CombatRating modifier by the given delta
        /// </summary>
        public void ModCombatRatingMod( CombatRating combatRating, int iDelta )
        {
            m_CombatRating[(int)combatRating - 1] += iDelta;

            SetInt32( (int)PlayerFields.COMBAT_RATING_1 - 1 + (int)combatRating, m_CombatRating[(int)combatRating - 1] );

            // TODO: Update influence
        }


        //public void ModCombatRatingMod( CombatRatingMask mask, int delta )
        //{
        //    foreach ( var rating in UnitMechanics.CombatRatings )
        //    {
        //        if ( ( (CombatRatingMask)( 1 << (int)rating ) & mask ) != 0 )
        //        {
        //            ModCombatRatingMod( rating, delta );
        //        }
        //    }
        //}
        #endregion

        #region Tracking of Resources & Creatures
        ///// <summary>
        ///// The spell that activated a Resource- or CreatureTracker (or null if the player is not tracking anything)
        ///// </summary>
        //public Spell CurrentTracker
        //{
        //    get;
        //    internal set;
        //}

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CreatureTrackingMask m_CreatureTracking = CreatureTrackingMask.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CreatureTrackingMask CreatureTracking
        {
            get { return m_CreatureTracking; }
            internal set
            {
                m_CreatureTracking = value;
                SetUInt32( (int)PlayerFields.TRACK_CREATURES, (uint)m_CreatureTracking );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private LockMask m_ResourceTracking = LockMask.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public LockMask ResourceTracking
        {
            get { return m_ResourceTracking; }
            internal set
            {
                m_ResourceTracking = value;
                SetUInt32( (int)PlayerFields.TRACK_RESOURCES, (uint)m_ResourceTracking );
            }
        }
        #endregion

        #region Misc Combat effecting Fields
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_BlockChance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float BlockChance
        {
            get { return m_BlockChance; }
            internal set
            {
                m_BlockChance = value;
                SetFloat( (int)PlayerFields.BLOCK_PERCENTAGE, m_BlockChance );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_DodgeChance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float DodgeChance
        {
            get { return m_DodgeChance; }
            internal set
            {
                m_DodgeChance = value;
                SetFloat( (int)PlayerFields.DODGE_PERCENTAGE, m_DodgeChance );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_ParryChance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float ParryChance
        {
            get { return m_ParryChance; }
            internal set
            {
                m_ParryChance = value;
                SetFloat( (int)PlayerFields.PARRY_PERCENTAGE, m_ParryChance );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Expertise = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Expertise
        {
            get { return m_Expertise; }
            internal set
            {
                m_Expertise = value;
                SetUInt32( (int)PlayerFields.EXPERTISE, m_Expertise );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CritChanceMelee = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float CritChanceMelee
        {
            get { return m_CritChanceMelee; }
            internal set
            {
                m_CritChanceMelee = value;
                SetFloat( (int)PlayerFields.CRIT_PERCENTAGE, m_CritChanceMelee );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CritChanceRanged = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float CritChanceRanged
        {
            get { return m_CritChanceRanged; }
            internal set
            {
                m_CritChanceRanged = value;
                SetFloat( (int)PlayerFields.RANGED_CRIT_PERCENTAGE, m_CritChanceRanged );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CritChanceOffHand = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float CritChanceOffHand
        {
            get { return m_CritChanceOffHand; }
            internal set
            {
                m_CritChanceOffHand = value;
                SetFloat( (int)PlayerFields.OFFHAND_CRIT_PERCENTAGE, m_CritChanceOffHand );
            }
        }

        //internal protected override float SetSpellCritChance(DamageSchool school, float val)
        //{
        //    // TODO:
        //}

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float[] m_SpellCritChance = new float[s_DamageSchoolCount];
        #endregion
        /// <summary>
        /// Returns the SpellCritChance for the given DamageType
        /// </summary>
        public float GetSpellCritChance( DamageSchool damageSchool )
        {
            return m_SpellCritChance[(int)damageSchool];
        }

        /// <summary>
        /// Sets the SpellCritChance for the given DamageType
        /// </summary>
        public void SetSpellCritChance( DamageSchool damageSchool, float value )
        {
            m_SpellCritChance[(int)damageSchool] = value;
            SetFloat( (int)PlayerFields.SPELL_CRIT_PERCENTAGE1 + (int)damageSchool, value );
        }

        /// <summary>
        /// Sets the SpellCritChance for the given DamageType
        /// </summary>
        public void ModSpellCritChance( DamageSchool damageSchool, float iDelta )
        {
            m_SpellCritChance[(int)damageSchool] += iDelta;

            SetFloat( (int)PlayerFields.SPELL_CRIT_PERCENTAGE1 + (int)damageSchool, m_SpellCritChance[(int)damageSchool] );
        }

        /// <summary>
        /// Sets the SpellCritChance for the given DamageType
        /// </summary>
        public void ModSpellCritChance( uint[] damageSchools, float iDelta )
        {
            for ( int iIndex = 0; iIndex < damageSchools.Length; iIndex++ )
                ModSpellCritChance( (DamageSchool)damageSchools[iIndex], iDelta );
        }
        #endregion

        #region Damage Done
        /// <summary>
        /// Also adds all additional damage boni
        /// </summary>
        public int CalcTotalDamage( DamageSchool school, int damage )
        {
            damage += (int)( GetUInt32( (int)PlayerFields.MOD_DAMAGE_DONE_POS + (int)school ) - GetUInt32( (int)PlayerFields.MOD_DAMAGE_DONE_NEG + (int)school ) );

            //damage = UnitUpdates.GetMultiMod( GetFloat( (int)PlayerFields.MOD_DAMAGE_DONE_PCT + (int)school ) / 100f,
            //    damage );

            return damage;
        }

        private void ModDamageBonus( DamageSchool damageSchool, int iDelta )
        {
            if ( iDelta == 0 )
                return;

            PlayerFields playerFields;
            if ( iDelta > 0 )
                playerFields = PlayerFields.MOD_DAMAGE_DONE_POS;
            else
            {
                playerFields = PlayerFields.MOD_DAMAGE_DONE_NEG;
                iDelta = -iDelta;
            }

            //SetUInt32( playerFields + (int)damageSchool, GetUInt32( field + (int)school ) + (uint)iDelta );
        }

        /// <summary>
        /// Adds/Removes a flat modifier to all of the given damage schools
        /// </summary>
        public void ModDamageBonus( uint[] damageSchools, int iDelta )
        {
            for ( int iIndex = 0; iIndex < damageSchools.Length; iIndex++ )
                ModDamageBonus( (DamageSchool)damageSchools[iIndex], iDelta );

            //this.UpdateAllDamages();
        }

        private void ModDamageBonusPct( DamageSchool damageSchool, float iDelta )
        {
            if ( iDelta == 0 )
                return;

            //PlayerFields field = (int)PlayerFields.MOD_DAMAGE_DONE_PCT;
            //SetFloat( field + (int)school, GetFloat( field + (int)school ) + delta );
        }

        /// <summary>
        /// Adds/Removes a percent modifier to all of the given damage schools
        /// </summary>
        public void ModDamageBonusPct( uint[] damageSchools, float iDelta )
        {
            for ( int iIndex = 0; iIndex < damageSchools.Length; iIndex++ )
                ModDamageBonusPct( (DamageSchool)damageSchools[iIndex], iDelta );

            //this.UpdateAllDamages();
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_HealingDoneMod = 0;
        #endregion
        /// <summary>
        /// Healing modifier
        /// </summary>
        public int HealingDoneMod
        {
            get { return m_HealingDoneMod; }
            set
            {
                m_HealingDoneMod = value;
                SetInt32( (int)PlayerFields.MOD_HEALING_DONE_POS, m_HealingDoneMod );
            }
        }

        ///// <summary>
        ///// Make sure that the given slot is actually an equipment slot
        ///// </summary>
        //public void SetVisibleItem( InventorySlot slot, Item item )
        //{
        //    var visibleIndex = (int)PlayerFields.VISIBLE_ITEM_1_0 + ( (int)slot * 16 );
        //    if ( item != null )
        //    {
        //        SetUInt32( visibleIndex, item.Template.Id );
        //    }
        //    else
        //    {
        //        SetUInt32( visibleIndex, 0 );
        //    }
        //}

        /// <summary>
        /// Sets an ActionButton with the given information.
        /// </summary>
        public void SetActionButton( uint btnIndex, ushort action, byte type, byte info )
        {
            //var actions = m_record.ActionButtons;
            //if ( action == 0 )
            //{
            //    // unset it
            //    Array.Copy( ActionButton.Empty, 0, actions, btnIndex, ActionButton.Size );
            //}
            //else
            //{
            //    actions[btnIndex] = (byte)( action & 0x00FF );
            //    actions[btnIndex + 1] = (byte)( ( action & 0xFF00 ) << 8 );
            //    actions[btnIndex + 2] = type;
            //    actions[btnIndex + 3] = info;
            //}
        }

        public void SetActionButton( ActionButton btn )
        {
            //btn.Set( m_record.ActionButtons );
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public byte[] ActionButtons
        //{
        //    get
        //    {
        //        return m_record.ActionButtons;
        //    }
        //    internal set
        //    {
        //        m_record.ActionButtons = value;
        //    }
        //}

        public struct ActionButton
        {
            public const uint Size = 4;
            public const uint MaxAmount = 120;

            public static readonly byte[] Empty = new byte[Size];

            public uint Index;
            public ushort Action;
            public byte Type;
            public byte Info;

            public void Set( byte[] actions )
            {
                actions[Index] = (byte)( Action & 0x00FF );
                actions[Index + 1] = (byte)( ( Action & 0xFF00 ) << 8 );
                actions[Index + 2] = Type;
                actions[Index + 3] = Info;
            }
        }

        #region Custom Properties

        ///// <summary>
        ///// The currently selected GO of this Owner. Set to null to deselect.
        ///// </summary>
        //public GameObject SelectedGO
        //{
        //    get
        //    {
        //        if ( m_goSelection != null )
        //        {
        //            return m_goSelection.GO;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        GOSelectMgr.Instance[this] = value;
        //    }
        //}
        #endregion
    }
}
