using System;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UnitField
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly int s_DamageSchoolCount = (int)Utility.GetMaxEnumValue<DamageSchool>() + 1;

        //internal readonly int[] FlatModsInt = new int[UnitUpdates.FlatIntModCount + 1];
        //internal readonly float[] MultiplierMods = new float[UnitUpdates.MultiplierModCount + 1];
        //internal readonly int[] BaseMods = new int[UnitUpdates.BaseModCount];
        //internal readonly float[] FlatModsFloat = new float[UnitUpdates.FlatFloatModCount];

        //protected UnitField m_persuator;

        #region UpdateFields

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitField m_Charmed = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UnitField Charm
        {
            get { return m_Charmed; }
            internal set
            {
                m_Charmed = value;
                SetEntityId( (int)UnitFields.CHARM, m_Charmed != null ? m_Charmed.EntityId : EntityId.Zero );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitField m_Summon = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UnitField Summon
        {
            get { return m_Summon; }
            internal set
            {
                m_Summon = value;
                SetEntityId( (int)UnitFields.SUMMON, m_Summon != null ? m_Summon.EntityId : EntityId.Zero );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitField m_Charmer = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UnitField CharmedBy
        {
            get { return m_Charmer; }
            internal set
            {
                m_Charmer = value;
                SetEntityId( (int)UnitFields.CHARMEDBY, m_Charmer != null ? m_Charmer.EntityId : EntityId.Zero );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCharmed
        {
            get { return m_Charmer != null; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitField m_Summoner = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UnitField Summoner
        {
            get { return m_Summoner; }
            internal set
            {
                m_Summoner = value;
                SetEntityId( (int)UnitFields.SUMMONEDBY, m_Summoner != null ? m_Summoner.EntityId : EntityId.Zero );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOwned
        {
            get { return m_Summoner != null; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitField m_Creator = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UnitField Creator
        {
            get { return m_Creator; }
            internal set
            {
                m_Creator = value;
                SetEntityId( (int)UnitFields.CREATEDBY, m_Creator != null ? m_Creator.EntityId : EntityId.Zero );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitField m_Target = null;
        #endregion
        /// <summary>
        /// The Unit's currently selected target.
        /// If set to null, also forces this Unit to leave combat mode.
        /// </summary>
        public UnitField Target
        {
            get { return m_Target; }
            internal set
            {
                if ( m_Target != value )
                {
                    m_Target = value;
                    if ( m_Target != null )
                    {
                        //if ( !CanSee( value ) )
                        //{
                        //    // we cannot target something that we can't see
                        //    return;
                        //}

                        SetEntityId( (int)UnitFields.TARGET, m_Target.EntityId );
                    }
                    else
                    {
                        SetEntityId( (int)UnitFields.TARGET, EntityId.Zero );

                        //if ( m_isInCombat )
                        //{
                        //    SetCombatState( false, false );
                        //}
                    }

                }
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitField m_Persuaded = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UnitField Persuaded
        {
            get { return m_Persuaded; }
            internal set
            {
                SetEntityId( (int)UnitFields.PERSUADED, value != null ? value.EntityId : EntityId.Zero );
                m_Persuaded = value;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseField m_Channeled = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseField ChannelObject
        {
            get { return m_Channeled; }
            internal set
            {
                m_Channeled = value;
                //if (m_Channeled != null)
                //{
                SetEntityId( (int)UnitFields.CHANNEL_OBJECT, m_Channeled != null ? m_Channeled.EntityId : EntityId.Zero );
                //}
            }
        }

        #region Power Types UnitFields.POWER1

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Health = 0;
        #endregion
        /// <summary>
        /// This Unit's current Health. 
        /// Health cannot exceed MaxHealth.
        /// If Health reaches 0, the Unit dies.
        /// If Health is 0 and increases, the Unit gets resurrected.
        /// </summary>
        public int Health
        {
            get { return m_Health; }
            internal set
            {
                if ( m_Health != value )
                {
                //    if ( value < 1 )
                //    {
                //        if ( health > 0 )
                //        {
                //            // we just died
                //            Die();
                //        }
                //        value = 0;
                //    }
                //    else
                //    {
                //        if ( health == 0 )
                //        {
                //            // we are getting resurrected
                //            if ( m_auras.GhostAura != null )
                //            {
                //                m_auras.GhostAura.Remove( false );
                //            }
                //            else
                //            {
                //                DoResurrect();
                //            }
                //        }

                //        var maxHealth = (int)MaxHealth;
                //        if ( value >= maxHealth )
                //        {
                //            value = maxHealth;
                //        }
                //        else
                //        {
                //            Regenerating = true;
                //        }
                //    }

                    m_Health = value;
                    SetUInt32( (int)UnitFields.HEALTH, (uint)m_Health );
                }
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PowerMana = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int PowerMana
        {
            get { return m_PowerMana; }
            internal set
            {
                m_PowerMana = value;
                SetInt32( (int)UnitFields.POWER1, m_PowerMana );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PowerRage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int PowerRage
        {
            get { return m_PowerRage; }
            internal set
            {
                m_PowerRage = value;
                SetInt32( (int)UnitFields.POWER2, m_PowerRage );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PowerFocus = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int PowerFocus
        {
            get { return m_PowerFocus; }
            internal set
            {
                m_PowerFocus = value;
                SetInt32( (int)UnitFields.POWER3, m_PowerFocus );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PowerEnergy = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int PowerEnergy
        {
            get { return m_PowerEnergy; }
            internal set
            {
                m_PowerEnergy = value;
                SetInt32( (int)UnitFields.POWER4, m_PowerEnergy );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PowerHappiness = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int PowerHappiness
        {
            get { return m_PowerHappiness; }
            internal set
            {
                SetInt32( (int)UnitFields.POWER5, m_PowerHappiness );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MaxHealth = 0;
        #endregion
        /// <summary>
        /// Total maximum Health for this Owner. 
        /// In order to change this value, set BaseHealth.
        /// </summary>
        public uint MaxHealth
        {
            get { return m_MaxHealth; }
            internal set
            {
                m_MaxHealth = value;
                SetUInt32( (int)UnitFields.MAXHEALTH, m_MaxHealth );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MaxPowerMana = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxPowerMana
        {
            get { return m_MaxPowerMana; }
            internal set
            {
                m_MaxPowerMana = value;
                SetUInt32( (int)UnitFields.MAXPOWER1, m_MaxPowerMana );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MaxPowerRage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxPowerRage
        {
            get { return m_MaxPowerRage; }
            internal set
            {
                m_MaxPowerRage = value;
                SetUInt32( (int)UnitFields.MAXPOWER2, m_MaxPowerRage );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MaxPowerFocus = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxPowerFocus
        {
            get { return m_MaxPowerFocus; }
            internal set
            {
                m_MaxPowerFocus = value;
                SetUInt32( (int)UnitFields.MAXPOWER3, m_MaxPowerFocus );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MaxPowerEnergy = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxPowerEnergy
        {
            get { return m_MaxPowerEnergy; }
            internal set
            {
                m_MaxPowerEnergy = value;
                SetUInt32( (int)UnitFields.MAXPOWER4, m_MaxPowerEnergy );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MaxPowerHappiness = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxPowerHappiness
        {
            get { return m_MaxPowerHappiness; }
            internal set
            {
                m_MaxPowerHappiness = value;
                SetUInt32( (int)UnitFields.MAXPOWER5, m_MaxPowerHappiness );
            }
        }

        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Level = 0;
        #endregion
        /// <summary>
        /// The Level of this Unit.
        /// TODO: Update all Level-dependent values in the setter
        /// </summary>
        public uint Level
        {
            get { return m_Level; }
            internal set { SetUInt32( (int)UnitFields.LEVEL, m_Level ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual uint CasterLevel
        {
            get { return Level; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Faction m_Faction = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public virtual Faction Faction
        {
            get { return m_Faction; }
            internal set
            {
                m_Faction = value;
                //SetUInt32( (int)UnitFields.FACTIONTEMPLATE, (uint)m_Faction.Template.Id );
            }
        }

        //public virtual FactionId FactionId
        //{
        //    get { return m_Faction.Id; }
        //    set
        //    {
        //        Faction fac = FactionMgr.Get( value );
        //        if ( fac != null )
        //        {
        //            Faction = fac;
        //        }
        //        // what to do if faction doesn't exist?
        //    }
        //}

        //public uint FactionTemplateId
        //{
        //    get { return m_Faction.Template.Id; }
        //    protected set
        //    {
        //        Faction newFaction = FactionMgr.Get( (FactionRepListId)value );
        //        if ( newFaction != null )
        //        {
        //            Faction = newFaction;
        //        }
        //        // what should happen if we try to set an invalid id?
        //    }
        //}

        #region _BYTES_0

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_UnitBytes0 = new Byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] UnitBytes0
        {
            get { return m_UnitBytes0; }
            set
            {
                m_UnitBytes0 = value;
                SetByteArray( (int)UnitFields.BYTES_0, m_UnitBytes0 );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual RaceType Race
        {
            get { return (RaceType)m_UnitBytes0[0]; }
            set
            {
                m_UnitBytes0[0] = (byte)value;
                SetByte( (int)UnitFields.BYTES_0, 0, m_UnitBytes0[0] );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual ClassType Class
        {
            get { return (ClassType)m_UnitBytes0[1]; }
            set
            {
                m_UnitBytes0[1] = (byte)value;
                SetByte( (int)UnitFields.BYTES_0, 1, m_UnitBytes0[1] );
            }
        }

        /// <summary>
        /// Race of the character.
        /// </summary>
        public RaceMask RaceMask
        {
            get { return (RaceMask)( 1 << ( (int)this.Race - 1 ) ); }
        }

        /// <summary>
        /// Class of the character.
        /// </summary>
        public ClassMask ClassMask
        {
            get { return (ClassMask)( 1 << ( (int)this.Class - 1 ) ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual GenderType Gender
        {
            get { return (GenderType)m_UnitBytes0[2]; }
            set
            {
                m_UnitBytes0[2] = (byte)value;
                SetByte( (int)UnitFields.BYTES_0, 2, m_UnitBytes0[2] );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PowerType PowerType
        {
            get { return (PowerType)m_UnitBytes0[3]; }
            set
            {
                m_UnitBytes0[3] = (byte)value;
                SetByte( (int)UnitFields.BYTES_0, 3, m_UnitBytes0[3] );
            }
        }

        #endregion

        // UNIT_VIRTUAL_ITEM_SLOT_DISPLAY
        // UNIT_VIRTUAL_ITEM_SLOT_DISPLAY2
        // UNIT_VIRTUAL_ITEM_SLOT_DISPLAY3

        // UNIT_VIRTUAL_ITEM_INFO
        // UNIT_VIRTUAL_ITEM_INFO2
        // UNIT_VIRTUAL_ITEM_INFO3
        // UNIT_VIRTUAL_ITEM_INFO4
        // UNIT_VIRTUAL_ITEM_INFO5
        // UNIT_VIRTUAL_ITEM_INFO6

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitFlags m_UnitFlags = UnitFlags.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UnitFlags UnitFlags
        {
            get { return m_UnitFlags; }
            internal set
            {
                m_UnitFlags = value;
                SetUInt32( (int)UnitFields.FLAGS, (uint)m_UnitFlags );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitFlag2 m_UnitFlags2 = UnitFlag2.FeignDeath;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UnitFlag2 UnitFlags2
        {
            get { return m_UnitFlags2; }
            internal set
            {
                m_UnitFlags2 = value;
                SetUInt32( (int)UnitFields.FLAGS_2, (uint)m_UnitFlags2 );
            }
        }



        // AURA
        // ...
        // AURA_56

        // AURAFLAGS
        // ...
        // AURAFLAGS_14

        // AURALEVELS
        // ...
        // AURALEVELS_14

        // AURAAPPLICATIONS
        // ...
        // AURAAPPLICATIONS_14

        // AURASTATE
        // BASEATTACKTIME
        // BASEATTACKTIME2
        // RANGEDATTACKTIME



        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_BoundingRadius = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float BoundingRadius
        {
            get { return m_BoundingRadius; }
            internal set
            {
                m_BoundingRadius = value;
                SetFloat( (int)UnitFields.BOUNDINGRADIUS, m_BoundingRadius );
                //this.UpdateCombatReach();
            }
        }



        // COMBATREACH



        #region Display

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_DisplayId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint DisplayId
        {
            get { return m_DisplayId; }
            set
            {
                m_DisplayId = value;
                SetUInt32( (int)UnitFields.DISPLAYID, m_DisplayId );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_NativeDisplayId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint NativeDisplayId
        {
            get { return m_NativeDisplayId; }
            set
            {
                m_NativeDisplayId = value;
                SetUInt32( (int)UnitFields.NATIVEDISPLAYID, m_NativeDisplayId );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MountDisplayId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MountDisplayId
        {
            get { return m_MountDisplayId; }
            set
            {
                m_MountDisplayId = value;
                SetUInt32( (int)UnitFields.MOUNTDISPLAYID, m_MountDisplayId );
            }
        }

        #endregion



        // MINDAMAGE
        // MAXDAMAGE
        // MINOFFHANDDAMAGE
        // MAXOFFHANDDAMAGE



        #region _BYTES_1

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_UnitBytes1 = new Byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] UnitBytes1
        {
            get { return m_UnitBytes1; }
            set
            {
                m_UnitBytes1 = value;
                SetByteArray( (int)UnitFields.BYTES_1, m_UnitBytes1 );
            }
        }

        public virtual StandState StandState
        {
            get { return (StandState)m_UnitBytes1[0]; }
            set
            {
                m_UnitBytes1[0] = (byte)value;
                SetByte( (int)UnitFields.BYTES_1, 0, m_UnitBytes1[0] );
            }
        }

        public LoyaltyLevel Loyalty
        {
            get { return (LoyaltyLevel)m_UnitBytes1[1]; }
            set
            {
                m_UnitBytes1[1] = (byte)value;
                SetByte( (int)UnitFields.BYTES_1, 1, m_UnitBytes1[1] );
            }
        }

        public ShapeShiftForm ShapeShiftForm
        {
            get { return (ShapeShiftForm)m_UnitBytes1[2]; }
            set
            {
                ShapeShiftForm oldForm = this.ShapeShiftForm;

                m_UnitBytes1[2] = (byte)value;
                SetByte( (int)UnitFields.BYTES_1, 2, m_UnitBytes1[2] );

                //var changed = ShapeShiftChanged;
                //if ( changed != null )
                //    changed( this, oldForm );
            }
        }

        /// <summary>
        /// TODO: Int conversion is a nono here?
        /// </summary>
        public ShapeShiftMask ShapeShiftMask
        {
            get { return (ShapeShiftMask)( 1 << (int)( m_UnitBytes1[2] - 1 ) ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public StateFlag StateFlags
        {
            get { return (StateFlag)m_UnitBytes1[3]; }
            set
            {
                m_UnitBytes1[3] = (byte)value;
                SetByte( (int)UnitFields.BYTES_1, 3, m_UnitBytes1[3] );
            }
        }

        #endregion

        #region Pet Info

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PetNumber = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PetNumber
        {
            get { return m_PetNumber; }
            set
            {
                m_PetNumber = value;
                SetUInt32( (int)UnitFields.PETNUMBER, m_PetNumber );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PetNameTimestamp = 0;
        #endregion
        /// <summary>
        /// Changing this makes clients send a pet name query
        /// </summary>
        public uint PetNameTimestamp
        {
            get { return m_PetNameTimestamp; }
            set
            {
                m_PetNameTimestamp = value;
                SetUInt32( (int)UnitFields.PET_NAME_TIMESTAMP, m_PetNameTimestamp );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PetExperience = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PetExperience
        {
            get { return m_PetExperience; }
            set
            {
                m_PetExperience = value;
                SetUInt32( (int)UnitFields.PETEXPERIENCE, m_PetExperience );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PetNextLevelExp = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PetNextLevelExp
        {
            get { return m_PetNextLevelExp; }
            set
            {
                m_PetNextLevelExp = value;
                SetUInt32( (int)UnitFields.PETNEXTLEVELEXP, m_PetNextLevelExp );
            }
        }

        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UnitDynamicFlags m_DynamicFlags = UnitDynamicFlags.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UnitDynamicFlags DynamicFlags
        {
            get { return m_DynamicFlags; }
            set
            {
                m_DynamicFlags = value;
                SetUInt32( (int)UnitFields.UNIT_DYNAMIC_FLAGS, (uint)m_DynamicFlags );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ChannelSpell = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ChannelSpell
        {
            get { return m_ChannelSpell; }
            set
            {
                m_ChannelSpell = value;
                SetUInt32( (int)UnitFields.UNIT_CHANNEL_SPELL, m_ChannelSpell );
                //// instant push needed
                //if ( m_isInWorld )
                //    PushFieldUpdateToPlayers( GetNearbyCharacters(), UnitFields.UNIT_CHANNEL_SPELL, value );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_CastSpeedFactor = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float CastSpeedFactor
        {
            get { return GetFloat( (int)UnitFields.UNIT_MOD_CAST_SPEED ); }
            set
            {
                m_CastSpeedFactor = value;
                SetFloat( (int)UnitFields.UNIT_MOD_CAST_SPEED, m_CastSpeedFactor );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatedBySpell = 0;
        #endregion
        /// <summary>
        /// The spell that created this Unit
        /// </summary>
        public uint CreatedBySpell
        {
            get { return m_CreatedBySpell; }
            set
            {
                m_CreatedBySpell = value;
                SetUInt32( (int)UnitFields.UNIT_CREATED_BY_SPELL, m_CreatedBySpell );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NPCEntryMask m_NPCFlags = NPCEntryMask.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public NPCEntryMask NPCFlags
        {
            get { return m_NPCFlags; }
            set
            {
                m_NPCFlags = value;
                SetUInt32( (int)UnitFields.UNIT_NPC_FLAGS, (uint)m_NPCFlags );

                //if ( ( value & NPCEntryMask.SpiritHealer ) != 0 || ( value & NPCEntryMask.SpiritGuide ) != 0 )
                //{
                //    DynamicFlags |= UnitDynamicFlags.Dead;
                //}
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EmoteType m_NPCEmoteState = EmoteType.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public EmoteType NPCEmoteState
        {
            get { return m_NPCEmoteState; }
            set
            {
                m_NPCEmoteState = value;
                SetUInt32( (int)UnitFields.UNIT_NPC_EMOTESTATE, (uint)m_NPCEmoteState );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_TrainingPoints = 0;
        #endregion
        /// <summary>
        /// Pet's Training Points
        /// </summary>
        public uint TrainingPoints
        {
            get { return m_TrainingPoints; }
            set
            {
                m_TrainingPoints = value;
                SetUInt32( (int)UnitFields.UNIT_TRAINING_POINTS, m_TrainingPoints );
            }
        }

        #region Base Stats

        /// <summary>
        /// 
        /// </summary>
        public uint Strength
        {
            get { return m_Stats[(int)StatType.Strength]; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint Agility
        {
            get { return m_Stats[(int)StatType.Agility]; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint Stamina
        {
            get { return m_Stats[(int)StatType.Stamina]; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint Intellect
        {
            get { return m_Stats[(int)StatType.Intellect]; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint Spirit
        {
            get { return m_Stats[(int)StatType.Spirit]; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        protected uint[] m_Stats = new uint[5];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public uint GetStatValue( StatType statType )
        {
            return m_Stats[(int)statType];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public void SetStatValue( StatType statType, uint value  )
        {
            m_Stats[(int)statType] = value;
            SetUInt32( (int)UnitFields.STAT0 + (int)statType, value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statType"></param>
        /// <param name="iDelta"></param>
        public void AddStatBuff( StatType statType, int iDelta )
        {
            if ( iDelta == 0 )
                return;

            UnitFields unitFields;
            if ( iDelta > 0 )
            {
                unitFields = UnitFields.POSSTAT0;
                SetInt32( (int)unitFields + (int)statType, GetInt32( (int)unitFields + (int)statType ) + iDelta );
            }
            else
            {
                unitFields = UnitFields.NEGSTAT0;
                SetInt32( (int)unitFields + (int)statType, GetInt32( (int)unitFields + (int)statType ) - iDelta );
            }

            //this.UpdateStat( statType );
        }

        /// <summary>
        /// Removes the given delta from positive or negative stat buffs correspondingly
        /// </summary>
        public void RemoveStatBuff( StatType statType, int iDelta )
        {
            if ( iDelta == 0 )
                return;
            
            UnitFields unitFields;
            if ( iDelta > 0 )
            {
                unitFields = UnitFields.POSSTAT0;
                SetInt32( (int)unitFields + (int)statType, GetInt32( (int)unitFields + (int)statType ) - iDelta );
            }
            else
            {
                unitFields = UnitFields.NEGSTAT0;
                SetInt32( (int)unitFields + (int)statType, GetInt32( (int)unitFields + (int)statType ) + iDelta );
            }

            //this.UpdateStat( statType );
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint[] m_BaseStats = new uint[5];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public uint GetBaseStatValue( StatType statType )
        {
            return m_BaseStats[(int)statType];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="value"></param>
        public void SetBaseStat( StatType statType, uint value )
        {
            m_BaseStats[(int)statType] = value;

            //this.UpdateStat( statType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statType"></param>
        /// <param name="iDelta"></param>
        public void ModBaseStat( StatType statType, int iDelta )
        {
            SetBaseStat( statType, (uint)( m_BaseStats[(int)statType] + iDelta ) );
        }
        #endregion

        #region Base Stat Mods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_StrengthBuffPositive = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int StrengthBuffPositive
        {
            get { return m_StrengthBuffPositive; }
            set
            {
                m_StrengthBuffPositive = value;
                SetInt32( (int)UnitFields.POSSTAT0, m_StrengthBuffPositive );
                //this.UpdateStrength();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_AgilityBuffPositive = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int AgilityBuffPositive
        {
            get { return m_AgilityBuffPositive; }
            set
            {
                m_AgilityBuffPositive = value;
                SetInt32( (int)UnitFields.POSSTAT1, m_AgilityBuffPositive );
                //this.UpdateAgility();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_StaminaBuffPositive = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int StaminaBuffPositive
        {
            get { return m_StaminaBuffPositive; }
            set
            {
                m_StaminaBuffPositive = value;
                SetInt32( (int)UnitFields.POSSTAT2, m_StaminaBuffPositive );
                //this.UpdateStamina();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_IntellectBuffPositive = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int IntellectBuffPositive
        {
            get { return m_IntellectBuffPositive; }
            set
            {
                m_IntellectBuffPositive = value;
                SetInt32( (int)UnitFields.POSSTAT3, m_IntellectBuffPositive );
                //this.UpdateIntellect();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_SpiritBuffPositive = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int SpiritBuffPositive
        {
            get { return m_SpiritBuffPositive; }
            set
            {
                m_SpiritBuffPositive = value;
                SetInt32( (int)UnitFields.POSSTAT4, m_SpiritBuffPositive );
                //this.UpdateSpirit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_StrengthBuffNegative = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int StrengthBuffNegative
        {
            get { return m_StrengthBuffNegative; }
            set
            {
                m_StrengthBuffNegative = value;
                SetInt32( (int)UnitFields.NEGSTAT0, m_StrengthBuffNegative );
                //this.UpdateStrength();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_AgilityBuffNegative = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int AgilityBuffNegative
        {
            get { return m_AgilityBuffNegative; }
            set
            {
                m_AgilityBuffNegative = value;
                SetInt32( (int)UnitFields.NEGSTAT1, m_AgilityBuffNegative );
                //this.UpdateAgility();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_StaminaBuffNegative = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int StaminaBuffNegative
        {
            get { return m_StaminaBuffNegative; }
            set
            {
                m_StaminaBuffNegative = value;
                SetInt32( (int)UnitFields.NEGSTAT2, m_StaminaBuffNegative );
                //this.UpdateStamina();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_IntellectBuffNegative = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int IntellectBuffNegative
        {
            get { return m_IntellectBuffNegative; }
            set
            {
                m_IntellectBuffNegative = value;
                SetInt32( (int)UnitFields.NEGSTAT3, m_IntellectBuffNegative );
                //this.UpdateIntellect();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_SpiritBuffNegative = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int SpiritBuffNegative
        {
            get { return m_SpiritBuffNegative; }
            set
            {
                m_SpiritBuffNegative = value;
                SetInt32( (int)UnitFields.NEGSTAT4, m_SpiritBuffNegative );
                //this.UpdateSpirit();
            }
        }

        #endregion

        #region Resistances

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Armor = 0;
        #endregion
        /// <summary>
        /// Physical resist
        /// </summary>
        public uint Armor
        {
            get { return m_Armor; }
            internal set
            {
                m_Armor = value;
                SetUInt32( (int)UnitFields.RESISTANCES, m_Armor );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_HolyResist = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint HolyResist
        {
            get { return m_HolyResist; }
            internal set
            {
                m_HolyResist = value;
                SetUInt32( (int)UnitFields.RESISTANCES_2, m_HolyResist );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_FireResist = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FireResist
        {
            get { return m_FireResist; }
            internal set
            {
                m_FireResist = value;
                SetUInt32( (int)UnitFields.RESISTANCES_3, m_FireResist );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_NatureResist = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint NatureResist
        {
            get { return m_NatureResist; }
            internal set
            {
                m_NatureResist = value;
                SetUInt32( (int)UnitFields.RESISTANCES_4, m_NatureResist );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_FrostResist = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FrostResist
        {
            get { return m_FrostResist; }
            internal set
            {
                m_FrostResist = value;
                SetUInt32( (int)UnitFields.RESISTANCES_5, m_FrostResist );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ShadowResist = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ShadowResist
        {
            get { return m_ShadowResist; }
            internal set
            {
                m_ShadowResist = value;
                SetUInt32( (int)UnitFields.RESISTANCES_6, m_ShadowResist );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ArcaneResist = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ArcaneResist
        {
            get { return m_ArcaneResist; }
            internal set
            {
                m_ArcaneResist = value;
                SetUInt32( (int)UnitFields.RESISTANCES_7, m_ArcaneResist );
            }
        }

        /// <summary>
        /// Returns the total resistance-value of the given school
        /// </summary>
        public uint GetResistance( DamageSchool damageSchool )
        {
            return GetUInt32( (int)UnitFields.RESISTANCES + (int)damageSchool );
        }

        /// <summary>
        /// 
        /// </summary>
        private uint[] m_BaseResistances = new uint[s_DamageSchoolCount];
        /// <summary>
        /// Returns the base resistance-value of the given school
        /// </summary>
        public uint GetBaseResistance( DamageSchool damageSchool )
        {
            return m_BaseResistances[(int)damageSchool];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="school"></param>
        /// <param name="value"></param>
        public void SetBaseResistance( DamageSchool damageSchool, uint value )
        {
            if ( value < 0 )
                value = 0;

            m_BaseResistances[(uint)damageSchool] = value;
            //this.UpdateResistance( damageSchool );
        }

        /// <summary>
        /// Adds the given amount to the base of the given resistance-schools
        /// </summary>
        public void ModBaseResistance( DamageSchool damageSchool, int iDelta )
        {
            int val = (int)m_BaseResistances[(int)damageSchool] + iDelta;
            if ( val < 0 )
                val = 0;

            m_BaseResistances[(uint)damageSchool] = (uint)val;
            //this.UpdateResistance( damageSchool );
        }

        /// <summary>
        /// Adds the given amount to the base of all given resistance-schools
        /// </summary>
        /// <param name="flags">All effected DamageSchools, eg uint[] { (uint)DamageSchool.Physical, (uint)DamageSchool.Arcane }</param>
        public void ModBaseResistance( uint[] damageSchools, int iDelta )
        {
            for (int iIndex = 0; iIndex < damageSchools.Length; iIndex++)
                ModBaseResistance( (DamageSchool)damageSchools[iIndex], iDelta );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="school"></param>
        /// <param name="delta"></param>
        public void AddResistanceBuff( DamageSchool damageSchools, int iDelta )
        {
            if ( iDelta == 0 )
                return;

            UnitFields unitFields;
            if ( iDelta > 0 )
            {
                unitFields = UnitFields.RESISTANCEBUFFMODSPOSITIVE;
                SetInt32( (int)unitFields + (int)damageSchools, GetInt32( (int)unitFields + (int)damageSchools ) + iDelta );
            }
            else
            {
                unitFields = UnitFields.RESISTANCEBUFFMODSNEGATIVE;
                SetInt32( (int)unitFields + (int)damageSchools, GetInt32( (int)unitFields + (int)damageSchools ) - iDelta );
            }

            //this.UpdateResistance( damageSchools );
        }

        /// <summary>
        /// Removes the given delta from positive or negative stat buffs correspondingly
        /// </summary>
        public void RemoveResistanceBuff( DamageSchool damageSchools, int iDelta )
        {
            if ( iDelta == 0 )
                return;

            UnitFields unitFields;
            if ( iDelta > 0 )
            {
                unitFields = UnitFields.RESISTANCEBUFFMODSPOSITIVE;
                SetInt32( (int)unitFields + (int)damageSchools, GetInt32( (int)unitFields + (int)damageSchools ) - iDelta );
            }
            else
            {
                unitFields = UnitFields.RESISTANCEBUFFMODSNEGATIVE;
                SetInt32( (int)unitFields + (int)damageSchools, GetInt32( (int)unitFields + (int)damageSchools ) + iDelta );
            }

            //this.UpdateResistance( school );
        }

        #endregion

        #region Resistance Buffs

        /// <summary>
        /// 
        /// </summary>
        public int ArmorBuffPositive
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSPOSITIVE ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int HolyResistBuffPositive
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSPOSITIVE + 1 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int FireResistBuffPositive
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSPOSITIVE + 2 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NatureResistBuffPositive
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSPOSITIVE + 3 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int FrostResistBuffPositive
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSPOSITIVE + 4 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ShadowResistBuffPositive
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSPOSITIVE + 5 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ArcaneResistBuffPositive
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSPOSITIVE + 6 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ArmorBuffNegative
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSNEGATIVE ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int HolyResistBuffNegative
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSNEGATIVE + 1 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int FireResistBuffNegative
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSNEGATIVE + 2 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NatureResistBuffNegative
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSNEGATIVE + 3 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int FrostResistBuffNegative
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSNEGATIVE + 4 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ShadowResistBuffNegative
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSNEGATIVE + 5 ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ArcaneResistBuffNegative
        {
            get { return GetInt32( (int)UnitFields.RESISTANCEBUFFMODSNEGATIVE + 6 ); }
        }

        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_BasePower = 0;
        #endregion
        /// <summary>
        /// Base maximum power, before modifiers.
        /// </summary>
        public uint BasePower
        {
            get { return m_BasePower; }
            set
            {
                m_BasePower = value;
                if ( this.PowerType == PowerType.Mana )
                    SetUInt32( (int)UnitFields.BASE_MANA, m_BasePower );

                //this.UpdatePower();

                if ( ( PowerType != PowerType.Rage ) && ( PowerType != PowerType.Energy ) )
                    this.Power = (int)MaxPower;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_BaseHealth = 0;
        #endregion
        /// <summary>
        /// Base maximum health, before modifiers.
        /// </summary>
        public uint BaseHealth
        {
            get { return m_BaseHealth; }
            set
            {
                m_BaseHealth = value;
                SetUInt32( (int)UnitFields.BASE_HEALTH, m_BaseHealth );
                //this.UpdateHealth();
            }
        }

        #region _BYTES_2

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_UnitBytes2 = new Byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] UnitBytes2
        {
            get { return m_UnitBytes2; }
            set
            {
                m_UnitBytes2 = value;
                SetByteArray( (int)UnitFields.BYTES_2, m_UnitBytes2 );
            }
        }

        /// <summary>
        /// Set to 0x01 for Spirit Healers, Totems (?)
        /// </summary>
        public SheathType SheathType
        {
            get { return (SheathType)m_UnitBytes2[0]; }
            set
            {
                m_UnitBytes2[0] = (byte)value;
                SetByte( (int)UnitFields.BYTES_2, 0, m_UnitBytes2[0] );
            }
        }

        /// <summary>
        /// Set to 0x10 for Spirit Healers (also several NPCs have it, eg some Melee Orc Warrior)
        /// Set to 0x28 for Pets, Players, Totems
        /// </summary>
        public byte UnitBytes2_2
        {
            get { return m_UnitBytes2[1]; }
            set
            {
                m_UnitBytes2[1] = value;
                SetByte( (int)UnitFields.BYTES_2, 1, m_UnitBytes2[1] );
            }
        }

        /// <summary>
        /// 0x02 -> Disable Pet Rename
        /// 0x03 -> Enable Pet Rename
        /// </summary>
        public PetState PetState
        {
            get { return (PetState)m_UnitBytes2[2]; }
            set
            {
                m_UnitBytes2[2] = (byte)value;
                SetByte( (int)UnitFields.BYTES_2, 2, m_UnitBytes2[2] );
            }
        }

        /// <summary>
        /// Set to 0x02 for Pets
        /// </summary>
        public byte UnitBytes2_4
        {
            get { return m_UnitBytes2[3]; }
            set
            {
                m_UnitBytes2[3] = value;
                SetByte( (int)UnitFields.BYTES_2, 3, m_UnitBytes2[3] );
            }
        }

        #endregion

        #endregion



        // ATTACK_POWER
        // ATTACK_POWER_MODS
        // ATTACK_POWER_MULTIPLIER
        // RANGED_ATTACK_POWER
        // RANGED_ATTACK_POWER_MODS
        // RANGED_ATTACK_POWER_MULTIPLIER
        // MINRANGEDDAMAGE
        // MAXRANGEDDAMAGE



        #region Power Cost

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PowerCostModifier = 0;
        #endregion
        /// <summary>
        /// The flat PowerCostModifier for your default Power
        /// </summary>
        public int PowerCostModifier
        {
            get { return m_PowerCostModifier; }
            internal set
            {
                m_PowerCostModifier = value;
                SetInt32( (int)UnitFields.POWER_COST_MODIFIER + (int)this.PowerType, m_PowerCostModifier );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PowerCostMultiplier = 0;
        #endregion
        /// <summary>
        /// The PowerCostMultiplier for your default Power
        /// </summary>
        public float PowerCostMultiplier
        {
            get { return m_PowerCostMultiplier; }
            internal set
            {
                m_PowerCostMultiplier = value;
                SetFloat( (int)UnitFields.POWER_COST_MULTIPLIER + (int)this.PowerType, m_PowerCostMultiplier );
            }
        }
        #endregion


        // 杂项

        #region Custom Fields

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Power = 0;
        #endregion
        /// <summary>
        /// The amount of the Unit's default Power (Mana, Energy, Rage, Happiness etc)
        /// 
        /// TODO: Take negative regeneration into account
        /// </summary>
        public int Power
        {
            get { return m_Power; }
            set
            {
                if ( value < 0 )
                    value = 0;
                else
                {
                    int maxPower = (int)this.MaxPower;
                    bool isNegative = this.PowerRegenPerTick < 0;

                    //if ( value >= maxPower )
                    //{
                    //    value = maxPower;

                    //    if ( isNegative == true )
                    //        this.Regenerating = true;
                    //}
                    //else if ( isNegative == false )
                    //    this.Regenerating = true;
                }

                m_Power = value;
                SetInt32( (int)UnitFields.POWER1 + (int)PowerType, m_Power );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MaxPower = 0;
        #endregion
        /// <summary>
        /// The max amount of the Unit's default Power (Mana, Energy, Rage, Happiness etc)
        /// </summary>
        public uint MaxPower
        {
            get { return m_MaxPower; }
            internal set
            {
                m_MaxPower = value;
                SetUInt32( (int)UnitFields.MAXPOWER1 + (int)this.PowerType, m_MaxPower );
            }
        }

        /// <summary>
        /// The amount of Health to add per regen-tick while not in combat
        /// </summary>
        public int HealthRegenPerTickNoCombat
        {
            get;
            internal set;
        }

        /// <summary>
        /// The amount of Health to add per regen-tick during combat
        /// </summary>
        public int HealthRegenPerTickCombat
        {
            get;
            internal set;
        }

        /// <summary>
        /// The amount of Power to add per regen-tick (while not being "interrupted")
        /// </summary>
        public int PowerRegenPerTick
        {
            get;
            internal set;
        }

        /// <summary>
        /// The amount of Mana to add per regen-tick (while being "interrupted")
        /// </summary>
        public int ManaRegenPerTickInterrupted
        {
            get;
            internal set;
        }

        /// <summary>
        /// Amount of percent taken less from falling-damage and amount of yards to be allowed to jump without having any damage inflicted.
        /// </summary>
        public int SafeFall
        {
            get;
            internal set;
        }
        #endregion
    }
}
