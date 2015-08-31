using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Mmose.Core.Entity;

namespace Demo.Wow.WorldServer.Entity.Common
{
    /// <summary>
    /// Defines the different states/speeds and mechanics of a unit
    /// 
    /// TODO: Fix speed calculations
    /// TODO: Add visibility-states
    /// </summary>
    public class UnitMechanics
    {
        //public static readonly int MechanicCount = (int)Convert.ChangeType( Utility.GetMaxEnum<SpellMechanic>(), typeof( int ) ) + 1;
        public static readonly int MechanicCount = 100 + 1;
        // public static readonly int DamageTypeCount = (int)Convert.ChangeType(Utility.GetMaxEnum<DamageType>(), typeof(int)) + 1;
        //public static readonly int DamageSchoolCount = (int)Convert.ChangeType( Utility.GetMaxEnum<DamageSchool>(), typeof( int ) ) + 1;
        public static readonly int DamageSchoolCount = 100 + 1;
        //public static readonly int DispelTypeCount = (int)Convert.ChangeType( Utility.GetMaxEnum<DispelType>(), typeof( int ) ) + 1;
        public static readonly int DispelTypeCount = 100 + 1;
        /// <summary>
        /// A dictionary that maps each specific DamageTypeMask-flag to its corresponding DamageType counterpart
        /// </summary>
        // public static readonly Dictionary<DamageTypeMask, DamageType> DamageTypeLookup = new Dictionary<DamageTypeMask, DamageType>();
        /// <summary>
        /// All DamageTypeMasks
        /// </summary>
        // public static readonly DamageTypeMask[] DamageTypeMasks = Utility.GetEnumValues<DamageTypeMask>();
        /// <summary>
        /// All CombatRatings
        /// </summary>
        //public static readonly CombatRating[] CombatRatings = Utility.GetEnumValues<CombatRating>();
        public static readonly CombatRating[] CombatRatings = null;

        /// <summary>
        /// Creates an array for a set of SpellMechanics
        /// </summary>
        internal static int[] CreateMechanicsArr()
        {
            return new int[MechanicCount];
        }

        internal static int[] CreateDamageSchoolArr()
        {
            return new int[DamageSchoolCount];
        }

        internal static int[] CreateDispelTypeArr()
        {
            return new int[DispelTypeCount];
        }

        public static readonly UnitMechanics Default = new UnitMechanics(
            2.5f,
            1.25f,
            7.0f,
            4.72222f,
            4.5f,
            7.0f,
            4.5f,
            (float)Math.PI
            );

        #region Mechanic Influences
        /// <summary>
        /// Several Hashsets containing all SpellMechanics that can toggle 
        /// CanHarm, CanMove and CanCastSpells respectively
        /// </summary>
        public static readonly bool[]
            HarmMechanics = new bool[MechanicCount],
            MoveMechanics = new bool[MechanicCount],
            InteractMechanics = new bool[MechanicCount],
            SpellMechanics = new bool[MechanicCount];

        static UnitMechanics()
        {
            MoveMechanics[(int)SpellMechanic.Disoriented] = true;
            MoveMechanics[(int)SpellMechanic.Asleep] = true;
            MoveMechanics[(int)SpellMechanic.Dazed] = true;
            MoveMechanics[(int)SpellMechanic.Ensnared] = true;
            MoveMechanics[(int)SpellMechanic.Frozen] = true;
            MoveMechanics[(int)SpellMechanic.Incapacitated] = true;
            MoveMechanics[(int)SpellMechanic.Rooted] = true;
            MoveMechanics[(int)SpellMechanic.Stunned] = true;
            MoveMechanics[(int)SpellMechanic.Polymorphed] = true;
            MoveMechanics[(int)SpellMechanic.Horrified] = true;
            MoveMechanics[(int)SpellMechanic.Turned] = true;

            InteractMechanics[(int)SpellMechanic.Disoriented] = true;
            InteractMechanics[(int)SpellMechanic.Asleep] = true;
            InteractMechanics[(int)SpellMechanic.Charmed] = true;
            InteractMechanics[(int)SpellMechanic.Dazed] = true;
            InteractMechanics[(int)SpellMechanic.Ensnared] = true;
            InteractMechanics[(int)SpellMechanic.Frozen] = true;
            InteractMechanics[(int)SpellMechanic.Incapacitated] = true;
            InteractMechanics[(int)SpellMechanic.Rooted] = true;
            InteractMechanics[(int)SpellMechanic.Stunned] = true;
            InteractMechanics[(int)SpellMechanic.Fleeing] = true;
            InteractMechanics[(int)SpellMechanic.Horrified] = true;
            InteractMechanics[(int)SpellMechanic.Turned] = true;
            InteractMechanics[(int)SpellMechanic.Seduced] = true;
            InteractMechanics[(int)SpellMechanic.Shackled] = true;
            InteractMechanics[(int)SpellMechanic.Turned] = true;

            HarmMechanics[(int)SpellMechanic.Dazed] = true;
            HarmMechanics[(int)SpellMechanic.Fleeing] = true;
            HarmMechanics[(int)SpellMechanic.Frozen] = true;
            HarmMechanics[(int)SpellMechanic.Healing] = true;
            HarmMechanics[(int)SpellMechanic.Banished] = true;
            HarmMechanics[(int)SpellMechanic.Incapacitated] = true;

            SpellMechanics[(int)SpellMechanic.Silenced] = true;
            SpellMechanics[(int)SpellMechanic.Polymorphed] = true;
            SpellMechanics[(int)SpellMechanic.Disoriented] = true;
            SpellMechanics[(int)SpellMechanic.Fleeing] = true;
            SpellMechanics[(int)SpellMechanic.Incapacitated] = true;
            SpellMechanics[(int)SpellMechanic.Seduced] = true;
            SpellMechanics[(int)SpellMechanic.Asleep] = true;
            SpellMechanics[(int)SpellMechanic.Charmed] = true;
            SpellMechanics[(int)SpellMechanic.Banished] = true;
            SpellMechanics[(int)SpellMechanic.Horrified] = true;
            SpellMechanics[(int)SpellMechanic.Turned] = true;
            SpellMechanics[(int)SpellMechanic.Stunned] = true;
            SpellMechanics[(int)SpellMechanic.Frozen] = true;
        }
        #endregion

        #region Fields
        internal WorldEntity m_owner;

        // mod counters
        uint m_flying, m_waterWalk, m_hovering, m_featherFalling;
        int m_stealthed;
        int[] m_mechanics;
        int[] m_mechanicImmunities;
        int[] m_mechanicResistances;
        int[] m_mechanicDurationMods;
        int[] m_debuffResistances;
        int[] m_dispelImmunities;
        int[] m_targetResistances;
        int[] m_spellInterruptProt;

        /// <summary>
        /// Immunities against damage-schools
        /// </summary>
        int[] m_dmgImmunities;
        /// <summary>
        /// Damage absorption of specific DamageTypes
        /// </summary>
        int[] m_dmgAbsorb;

        bool m_canMove, m_canInteract, m_canHarm, m_canCastSpells;

        float m_factor, m_swimFactor, m_flightFactor, m_mountMod;
        float m_walkSpeed;
        float m_walkBackSpeed;
        float m_runSpeed;
        float m_swimSpeed;
        float m_swimBackSpeed;
        float m_flightSpeed;
        float m_flightBackSpeed;
        float m_turnSpeed;
        #endregion

        #region Ctors
        /// <summary>
        /// Default ctor
        /// </summary>
        public UnitMechanics( WorldEntity owner )
        {
            m_owner = owner;
            ResetDefaults();
        }

        /// <param name="m_walkSpeed">the unit's walking speed</param>
        /// <param name="m_walkBackSpeed">the unit's backwards walking speed</param>
        /// <param name="m_runSpeed">the unit's running speed</param>
        /// <param name="m_swimSpeed">the unit's swimming speed</param>
        /// <param name="m_swimBackSpeed">the unit's backwards swimming speed</param>
        /// <param name="m_flightSpeed">the unit's flying speed</param>
        /// <param name="m_flightBackSpeed">the unit's backwards flying speed</param>
        /// <param name="m_turnSpeed">the unit's turning speed</param>
        private UnitMechanics( float walkSpeed, float walkBackSpeed, float runSpeed, float swimSpeed,
            float swimBackSpeed, float flightSpeed, float flightBackSpeed, float turnSpeed )
        {
            m_flying = m_waterWalk = m_hovering = m_featherFalling = 0;
            m_canMove = m_canInteract = m_canHarm = m_canCastSpells = true;

            m_factor = 1f;
            m_mountMod = 0;

            m_walkSpeed = walkSpeed;
            m_walkBackSpeed = walkBackSpeed;
            m_runSpeed = runSpeed;
            m_swimSpeed = swimSpeed;
            m_swimBackSpeed = swimBackSpeed;
            m_flightSpeed = flightSpeed;
            m_flightBackSpeed = flightBackSpeed;
            m_turnSpeed = turnSpeed;
        }
        #endregion

        #region SpellMechanic Types
        /// <summary>
        /// Wether we are allowed to cast spells
        /// </summary>
        public bool CanCastSpells
        {
            get
            {
                return m_canCastSpells;
            }
        }

        /// <summary>
        /// Wether the owner can move at all.
        /// To stop a char from moving, use IncMechanicCount to increase Rooted or any other movement-effecting Mechanic-school.
        /// </summary>
        public bool CanMove
        {
            get
            {
                return m_canMove;
            }
        }

        /// <summary>
        /// Wether the Owner can be interacted with
        /// </summary>
        public bool CanInteract
        {
            get
            {
                return m_canInteract;
            }
        }

        /// <summary>
        /// Wether the Unit is pacified. To find out if a Unit can really Harm at all or a specific target, use
        /// Unit.CanDoHarm and Unit.CanHarm
        /// </summary>
        public bool IsPacified
        {
            get
            {
                return m_canHarm;
            }
        }

        /// <summary>
        /// Wether the owner is disarmed
        /// </summary>
        public bool IsDisarmed
        {
            get
            {
                return IsMechanic( SpellMechanic.Disarmed );
            }
        }

        /// <summary>
        /// Return wether the given Mechanic applies to the Owner
        /// </summary>
        public bool IsMechanic( SpellMechanic mechanic )
        {
            if ( m_mechanics == null )
            {
                return false;
            }
            return m_mechanics[(int)mechanic] > 0;
        }

        /// <summary>
        /// Checks wether any of the mechanics of the given set are influencing the owner
        /// </summary>
        bool IsAnySetNoCheck( bool[] set )
        {
            for ( int i = 1; i < set.Length; i++ )
            {
                if ( set[i] && m_mechanics[i] > 0 )
                {
                    return true;
                }
            }
            return false;
        }

        ///// <summary>
        ///// Increase the mechnanic modifier count for the given SpellMechanic
        ///// </summary>
        //public void IncMechanicCount( SpellMechanic mechanic )
        //{
        //    if ( m_mechanics == null )
        //    {
        //        m_mechanics = CreateMechanicsArr();
        //    }
        //    int val = m_mechanics[(int)mechanic];
        //    if ( val == 0 )
        //    {
        //        // movement
        //        if ( m_canMove && MoveMechanics[(int)mechanic] )
        //        {
        //            m_canMove = false;
        //            if ( m_owner is Character )
        //            {
        //                MovementHandler.SendRooted( (Character)m_owner );
        //            }
        //            m_owner.UnitFlags |= UnitFlags.Influenced;
        //            if ( m_owner.IsUsingSpell && ( m_owner.SpellCast.Spell.InterruptFlags & InterruptFlag.OnStunned ) != 0 )
        //            {
        //                m_owner.SpellCast.Cancel();
        //            }
        //        }

        //        // interaction
        //        if ( m_canInteract && InteractMechanics[(int)mechanic] )
        //        {
        //            m_canInteract = false;
        //            //m_owner.UnitFlags |= UnitFlags.UnInteractable;
        //        }

        //        // harmfulnes
        //        if ( m_canHarm && HarmMechanics[(int)mechanic] )
        //        {
        //            m_canHarm = false;
        //            if ( m_owner.IsUsingSpell && m_owner.SpellCast.Spell.HasHarmfulEffects )
        //            {
        //                m_owner.SpellCast.Cancel();
        //            }
        //        }

        //        // check if we can still cast spells
        //        if ( m_canCastSpells && SpellMechanics[(int)mechanic] )
        //        {
        //            // check if we can still cast spells
        //            m_canCastSpells = false;
        //            m_owner.UnitFlags |= UnitFlags.Silenced;
        //            if ( m_owner.IsUsingSpell && ( m_owner.SpellCast.Spell.InterruptFlags & InterruptFlag.OnSilence ) != 0 )
        //            {
        //                m_owner.SpellCast.Cancel();
        //            }
        //        }


        //        if ( mechanic == SpellMechanic.Mounted )
        //        {
        //            m_owner.UnitFlags |= UnitFlags.Mounted;
        //            SpeedFactor += MountSpeedMod;
        //        }
        //        else if ( mechanic == SpellMechanic.Disarmed )
        //        {
        //            m_owner.UnitFlags |= UnitFlags.Disarmed;
        //            m_owner.MainWeapon = null;
        //            m_owner.OffHandWeapon = null;
        //            m_owner.ExtraWeapon = null;
        //        }
        //        else if ( mechanic == SpellMechanic.Fleeing )
        //        {
        //            m_owner.UnitFlags |= UnitFlags.Feared;
        //        }
        //        else if ( mechanic == SpellMechanic.Disoriented )
        //        {
        //            m_owner.UnitFlags |= UnitFlags.Confused;
        //        }
        //        else if ( mechanic == SpellMechanic.Invulnerable )
        //        {
        //            m_owner.UnitFlags |= UnitFlags.Invulnerable;
        //        }
        //    }

        //    // change the value
        //    m_mechanics[(int)mechanic]++;
        //}

        ///// <summary>
        ///// Decrease the mechnanic modifier count for the given SpellMechanic
        ///// </summary>
        //public void DecMechanicCount( SpellMechanic mechanic )
        //{
        //    if ( m_mechanics == null )
        //    {
        //        return;
        //    }
        //    int val = m_mechanics[(int)mechanic];
        //    if ( val > 0 )
        //    {
        //        // change the value
        //        m_mechanics[(int)mechanic] = val - 1;

        //        if ( val == 1 )
        //        {
        //            // All of this Mechanic's influences have been removed

        //            if ( !m_canMove && MoveMechanics[(int)mechanic] && !IsAnySetNoCheck( MoveMechanics ) )
        //            {
        //                m_canMove = true;
        //                m_owner.m_lastMoveTime = Environment.TickCount;

        //                m_owner.UnitFlags &= ~UnitFlags.Influenced;
        //                if ( m_owner is Character )
        //                    MovementHandler.SendUnrooted( (Character)m_owner );
        //            }

        //            if ( !m_canInteract && InteractMechanics[(int)mechanic] && !IsAnySetNoCheck( InteractMechanics ) )
        //            {
        //                m_canInteract = true;
        //                //m_owner.UnitFlags &= ~UnitFlags.UnInteractable;
        //            }

        //            if ( !m_canHarm && HarmMechanics[(int)mechanic] && !IsAnySetNoCheck( HarmMechanics ) )
        //            {
        //                m_canHarm = true;
        //            }

        //            if ( !m_canCastSpells && SpellMechanics[(int)mechanic] && !IsAnySetNoCheck( SpellMechanics ) )
        //            {
        //                m_canCastSpells = true;
        //                m_owner.UnitFlags &= ~UnitFlags.Silenced;
        //            }

        //            if ( mechanic == SpellMechanic.Mounted )
        //            {
        //                m_owner.UnitFlags &= ~UnitFlags.Mounted;
        //                SpeedFactor -= MountSpeedMod;
        //            }
        //            else if ( mechanic == SpellMechanic.Disarmed && m_mechanics[(int)SpellMechanic.Disarmed] == 0 )
        //            {
        //                m_owner.UnitFlags &= ~UnitFlags.Disarmed;
        //                // TODO: Put weapons back in place
        //            }
        //            else if ( mechanic == SpellMechanic.Fleeing && m_mechanics[(int)SpellMechanic.Horrified] == 0 )
        //            {
        //                m_owner.UnitFlags &= ~UnitFlags.Feared;
        //            }
        //            else if ( mechanic == SpellMechanic.Disoriented && m_mechanics[(int)SpellMechanic.Disoriented] == 0 )
        //            {
        //                m_owner.UnitFlags &= ~UnitFlags.Confused;
        //            }
        //            else if ( mechanic == SpellMechanic.Invulnerable && m_mechanics[(int)SpellMechanic.Invulnerable] == 0 )
        //            {
        //                m_owner.UnitFlags &= ~UnitFlags.Invulnerable;
        //            }
        //        }
        //    }
        //}
        #endregion

        #region Immunities
        /// <summary>
        /// Wether the owner is completely invulnerable
        /// </summary>
        public bool IsInvulnerable
        {
            get
            {
                return m_mechanics != null && m_mechanics[(int)SpellMechanic.Invulnerable] > 0;
            }
        }

        /// <summary>
        /// Indicates wether the owner is immune against the given SpellMechanic
        /// </summary>
        public bool IsImmune( SpellMechanic mechanic )
        {
            if ( IsInvulnerable )
            {
                return true;
            }
            if ( mechanic == SpellMechanic.None )
            {
                return false;
            }

            return m_mechanicImmunities != null && m_mechanicImmunities[(int)mechanic] > 0;
        }

        /// <summary>
        /// Indicates wether the owner is immune against the given DamageSchool
        /// </summary>
        public bool IsImmune( DamageSchool school )
        {
            if ( IsInvulnerable )
            {
                return true;
            }

            return m_dmgImmunities != null && m_dmgImmunities[(int)school] > 0;
        }



        ///// <summary>
        ///// Adds immunity against given damage-school
        ///// </summary>
        //public void IncDmgImmunityCount( DamageSchool school )
        //{
        //    if ( m_dmgImmunities == null )
        //    {
        //        m_dmgImmunities = CreateDamageSchoolArr();
        //    }
        //    int val = m_dmgImmunities[(int)school];

        //    if ( val == 0 )
        //    {
        //        // new immunity: Gets rid of all Auras that use this school
        //        m_owner.Auras.RemoveWhere( ( aura ) =>
        //        {
        //            return aura.Spell.School == school;
        //        } );
        //    }

        //    m_dmgImmunities[(int)school]++;
        //}

        /// <summary>
        /// Adds immunity against given damage-schools
        /// </summary>
        public void IncDmgImmunityCount( uint[] schools )
        {
            //foreach ( var school in schools )
            //{
            //    IncDmgImmunityCount( (DamageSchool)school );
            //}
        }

        /// <summary>
        /// Decreases immunity-count against given damage-school
        /// </summary>
        public void DecDmgImmunityCount( DamageSchool school )
        {
            if ( m_dmgImmunities == null )
            {
                return;
            }
            int val = m_dmgImmunities[(int)school];
            if ( val > 0 )
            {
                m_dmgImmunities[(int)school]--;
            }
        }

        /// <summary>
        /// Decreases immunity-count against given damage-schools
        /// </summary>
        public void DecDmgImmunityCount( uint[] damageSchools )
        {
            foreach ( var school in damageSchools )
            {
                DecDmgImmunityCount( (DamageSchool)school );
            }
        }

        ///// <summary>
        ///// Adds immunity against given SpellMechanic-school
        ///// </summary>
        //public void IncMechImmunityCount( SpellMechanic mechanic )
        //{
        //    if ( m_mechanicImmunities == null )
        //    {
        //        m_mechanicImmunities = CreateMechanicsArr();
        //    }
        //    int val = m_mechanicImmunities[(int)mechanic];

        //    if ( val == 0 )
        //    {
        //        // new immunity: Gets rid of all Auras that use this Mechanic
        //        m_owner.Auras.RemoveWhere( ( aura ) =>
        //        {
        //            return aura.Spell.Mechanic == mechanic;
        //        } );
        //    }

        //    m_mechanicImmunities[(int)mechanic]++;
        //}

        /// <summary>
        /// Decreases immunity-count against given SpellMechanic-school
        /// </summary>
        public void DecMechImmunityCount( SpellMechanic mechanic )
        {
            if ( m_mechanicImmunities == null )
            {
                return;
            }
            int val = m_mechanicImmunities[(int)mechanic];
            if ( val > 0 )
            {
                m_mechanicImmunities[(int)mechanic]--;
            }
        }


        // TODO: ModDamageTaken and ModDamageTakenPercent
        //public int GetDmgResistance(DamageType school)
        //{
        //    if (m_dmgResist == null) {
        //        return 0;
        //    }

        //    m_dmgResist[(int)school] += value;
        //}

        ///// <summary>
        ///// Adds resistance against certain damage
        ///// </summary>
        //public void SetDmgnNullifier(DamageType school, int value)
        //{
        //    if (m_dmgResist == null) {
        //        m_dmgResist = CreateDamageSchoolArr();
        //    }

        //    m_dmgResist[(int)school] += value;
        //}
        #endregion

        #region Mechanic Resistance
        /// <summary>
        /// Returns the resistance chance for the given SpellMechanic
        /// </summary>
        public int GetMechanicResistance( SpellMechanic mechanic )
        {
            if ( m_mechanicResistances == null )
            {
                return 0;
            }
            return m_mechanicResistances[(int)mechanic];
        }

        /// <summary>
        /// Changes the amount of resistance against certain SpellMechanics
        /// </summary>
        public void ModMechanicResistance( SpellMechanic mechanic, int delta )
        {
            if ( m_mechanicResistances == null )
                m_mechanicResistances = CreateMechanicsArr();
            int val = m_mechanicResistances[(int)mechanic] + delta;
            if ( val < 0 )
            {
                val = 0;
            }
            m_mechanicResistances[(int)mechanic] = val;
        }
        #endregion

        #region Mechanic Durations
        /// <summary>
        /// Returns the duration modifier for a certain SpellMechanic
        /// </summary>
        public int GetMechanicDurationMod( SpellMechanic mechanic )
        {
            if ( m_mechanicDurationMods == null || mechanic == SpellMechanic.None )
            {
                return 0;
            }
            return m_mechanicDurationMods[(int)mechanic];
        }

        /// <summary>
        /// Changes the duration-modifier for a certain SpellMechanic in %
        /// </summary>
        public void ModMechanicDurationMod( SpellMechanic mechanic, int delta )
        {
            if ( m_mechanicDurationMods == null )
                m_mechanicDurationMods = CreateMechanicsArr();
            int val = m_mechanicDurationMods[(int)mechanic] + delta;
            if ( val < 0 )
            {
                val = 0;
            }
            m_mechanicDurationMods[(int)mechanic] = val;
        }
        #endregion

        #region Absorb
        /// <summary>
        /// Absorbs the given school and amount of damage
        /// </summary>
        /// <returns>The amount of damage absorbed</returns>
        public int Absorb( DamageSchool school, int amount )
        {
            if ( m_dmgAbsorb == null )
            {
                return 0;
            }

            int absorbMax = m_dmgAbsorb[(int)school];
            if ( amount > absorbMax )
            {
                amount = absorbMax;
            }
            m_dmgAbsorb[(int)school] -= amount;
            return amount;
        }

        /// <summary>
        /// Modifies absorption of the owner
        /// </summary>
        public void ModDmgAbsorption( uint[] damageSchools, int delta )
        {
            if ( m_dmgAbsorb == null )
            {
                m_dmgAbsorb = CreateDamageSchoolArr();
            }

            foreach ( var school in damageSchools )
            {
                ModDmgAbsorption( (DamageSchool)school, delta );
            }
        }

        private void ModDmgAbsorption( DamageSchool school, int delta )
        {
            int val = m_dmgAbsorb[(int)school] + delta;
            if ( val < 0 )
            {
                val = 0;
            }
            m_dmgAbsorb[(int)school] = val;
        }
        #endregion

        #region Debuff Resistance
        public int GetDebuffResistance( DamageSchool school )
        {
            if ( m_debuffResistances == null )
            {
                return 0;
            }
            return m_debuffResistances[(int)school];
        }

        public void SetDebuffResistance( DamageSchool school, int value )
        {
            if ( m_debuffResistances == null )
            {
                m_debuffResistances = CreateDamageSchoolArr();
            }
            m_debuffResistances[(uint)school] = value;
        }

        public void ModDebuffResistance( DamageSchool school, int delta )
        {
            if ( m_debuffResistances == null )
            {
                m_debuffResistances = CreateDamageSchoolArr();
            }
            m_debuffResistances[(int)school] += delta;
        }

        //public void ModDebuffResistance(DamageTypeMask schools, float delta)
        //{
        //    foreach (var school in UnitMechanics.DamageTypeMasks) {
        //        if ((schools & school) != 0) {
        //            ModDebuffResistance(UnitMechanics.DamageTypeLookup[school], delta);
        //        }
        //    }
        //}
        #endregion

        #region Dispel Immunities
        public bool IsImmune( DispelType school )
        {
            if ( m_dispelImmunities == null )
            {
                return false;
            }
            return m_dispelImmunities[(int)school] > 0;
        }

        //public void IncDispelImmunity( DispelType school )
        //{
        //    if ( m_dispelImmunities == null )
        //    {
        //        m_dispelImmunities = CreateDispelTypeArr();
        //    }
        //    int value = m_dispelImmunities[(uint)school];
        //    if ( value == 0 )
        //    {
        //        // new immunity: Gets rid of all Auras that use this DispelType
        //        m_owner.Auras.RemoveWhere( ( aura ) =>
        //        {
        //            return aura.Spell.DispelType == school;
        //        } );
        //    }
        //    m_dispelImmunities[(uint)school] = value + 1;
        //}

        public void DecDispelImmunity( DispelType school )
        {
            if ( m_dispelImmunities == null )
            {
                return;
            }
            int value = m_dispelImmunities[(uint)school];
            if ( value > 0 )
            {
                m_dispelImmunities[(int)school] = value - 1;
            }
        }

        //public void ModDebuffResistance(DamageTypeMask schools, float delta)
        //{
        //    foreach (var school in UnitMechanics.DamageTypeMasks) {
        //        if ((schools & school) != 0) {
        //            ModDebuffResistance(UnitMechanics.DamageTypeLookup[school], delta);
        //        }
        //    }
        //}
        #endregion

        #region Target Resistances
        public int GetTargetResistanceMod( DamageSchool school )
        {
            if ( m_targetResistances == null )
            {
                return 0;
            }
            return m_targetResistances[(int)school];
        }

        //public void SetTargetResistanceMod( DamageSchool school, int value )
        //{
        //    if ( m_targetResistances == null )
        //    {
        //        m_targetResistances = CreateDamageSchoolArr();
        //    }
        //    m_targetResistances[(uint)school] = value;
        //    if ( school == DamageSchool.Physical && m_owner is Character )
        //    {
        //        ( (Character)m_owner ).SetInt32( PlayerFields.MOD_TARGET_RESISTANCE, value );
        //    }
        //}

        //public void ModTargetResistanceMod( DamageSchool school, int delta )
        //{
        //    if ( m_targetResistances == null )
        //    {
        //        m_targetResistances = CreateDamageSchoolArr();
        //    }
        //    var val = m_targetResistances[(int)school] + delta;
        //    m_targetResistances[(int)school] = val;
        //    if ( school == DamageSchool.Physical && m_owner is Character )
        //    {
        //        ( (Character)m_owner ).SetInt32( PlayerFields.MOD_TARGET_RESISTANCE, val );
        //    }
        //}

        public void ModTargetResistanceMod( uint[] dmgTypes, int delta )
        {
            //foreach ( var school in dmgTypes )
            //{
            //    ModTargetResistanceMod( (DamageSchool)school, delta );
            //}
        }
        #endregion

        #region SpellInterruptionProt
        public void ModSpellInterruptProt( DamageSchool school, int delta )
        {
            if ( m_spellInterruptProt == null )
            {
                m_spellInterruptProt = CreateDamageSchoolArr();
            }
            var val = m_spellInterruptProt[(int)school] + delta;
            m_spellInterruptProt[(int)school] = val;
        }

        public void ModSpellInterruptProt( uint[] dmgTypes, int delta )
        {
            foreach ( var school in dmgTypes )
            {
                ModSpellInterruptProt( (DamageSchool)school, delta );
            }
        }

        public int GetSpellInterruptProt( DamageSchool school )
        {
            if ( m_spellInterruptProt == null )
            {
                return 0;
            }
            return m_spellInterruptProt[(int)school];
        }
        #endregion

        #region Misc Methods
        public void ResetDefaults()
        {
            m_factor = 1f;
            m_mountMod = 0;

            m_flying = m_waterWalk = m_hovering = m_featherFalling = 0;
            m_canMove = m_canHarm = m_canInteract = m_canCastSpells = true;

            m_walkSpeed = Default.m_walkSpeed;
            m_walkBackSpeed = Default.m_walkBackSpeed;
            m_runSpeed = Default.m_runSpeed;
            m_swimSpeed = Default.m_swimSpeed;
            m_swimBackSpeed = Default.m_swimBackSpeed;
            m_flightSpeed = Default.m_flightSpeed;
            m_flightBackSpeed = Default.m_flightBackSpeed;
            m_turnSpeed = Default.m_turnSpeed;
        }

        ///// <summary>
        ///// Teleports the owner to the given position in the given region.
        ///// </summary>
        ///// <param name="region">the target <see cref="Region" /></param>
        ///// <param name="pos">the target <see cref="Vector3">position</see></param>
        //public bool TeleportTo( ZoneLocation loc )
        //{
        //    var pos = new Vector3( loc.X, loc.Y, loc.Z );
        //    var region = WorldMgr.GetRegion( loc.Region );
        //    if ( region != null )
        //    {
        //        return TeleportTo( region, ref pos );
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Teleports the owner to the given position in the given region.
        ///// </summary>
        ///// <param name="region">the target <see cref="Region" /></param>
        ///// <param name="pos">the target <see cref="Vector3">position</see></param>
        //public bool TeleportTo( Region region, ref Vector3 pos )
        //{
        //    return ( TeleportTo( region, ref pos, null ) );
        //}

        ///// <summary>
        ///// Teleports the owner to the given position in the given region.
        ///// </summary>
        ///// <param name="region">the target <see cref="Region" /></param>
        ///// <param name="pos">the target <see cref="Vector3">position</see></param>
        ///// <param name="orientation">the target orientation</param>
        //public bool TeleportTo( Region region, ref Vector3 pos, float? orientation )
        //{
        //    bool success = false;

        //    if ( m_owner.Region == region )
        //    {
        //        if ( m_owner.Region.MoveObject( m_owner, ref pos ) )
        //        {
        //            if ( orientation.HasValue )
        //                m_owner.Orientation = orientation.Value;

        //            if ( m_owner is Character )
        //            {
        //                var chr = ( (Character)m_owner );
        //                chr.LastPosition = pos;

        //                MovementHandler.SendMoved( chr );
        //            }

        //            success = true;
        //        }
        //    }
        //    else
        //    {
        //        Vector3 originalPosition = m_owner.Position;
        //        Region originalRegion = m_owner.Region;

        //        // TODO: Fix in case that Worldport-Ack arrives before the messages have been processed
        //        // TODO: Could anything else happen in the time between now and 
        //        // the time where the owner gets actually transfered (next region tick) 
        //        // or during the time when he is in Limbo (after being removed and before being added)?
        //        if ( region.RemoveAndAddObjectLater( m_owner, pos ) )
        //        {
        //            if ( orientation.HasValue )
        //            {
        //                m_owner.Orientation = orientation.Value;
        //            }

        //            if ( m_owner is Character )
        //            {
        //                var chr = ( (Character)m_owner );
        //                chr.LastPosition = pos;

        //                MovementHandler.SendNewWorld( chr.Client, region.MapID, ref pos, m_owner.Orientation );
        //            }

        //            success = true;
        //        }
        //        else
        //        {
        //            // apparently, the target region has a colliding entity ID. this should NEVER 
        //            // happen for any kind of Unit

        //            log.Error( "ERROR: Tried to teleport player, but failed to add player to the new region." );
        //        }
        //    }

        //    //if (!success && m_container is Owner) {
        //    //    SendMoveAbort(((Owner)m_container).Client, region.MapID);
        //    //}

        //    return success;
        //}

        #endregion

        #region Stealth
        /// <summary>
        /// Count of stealth-modifiers
        /// </summary>
        public int Stealthed
        {
            get
            {
                return m_stealthed;
            }
            set
            {
                //if ( m_stealthed != value )
                //{
                //    if ( m_stealthed > 0 && value <= 0 )
                //    {
                //        // deactivated stealth
                //        m_owner.ShapeShiftForm = ShapeShiftForm.Normal;
                //        m_owner.StateFlags &= ~StateFlag.Sneaking;
                //    }
                //    else if ( m_stealthed <= 0 && value > 0 )
                //    {
                //        // activated stealth
                //        m_owner.ShapeShiftForm = ShapeShiftForm.Stealth;
                //        m_owner.StateFlags |= StateFlag.Sneaking;

                //        // some auras don't live through Stealth
                //        m_owner.Auras.RemoveByFlag( AuraInterruptFlag.OnStealth );
                //    }
                //    m_stealthed = value;
                //}
            }
        }
        #endregion

        #region Movement Modes
        /// <summary>
        /// Wether the Unit is currently flying
        /// </summary>
        public bool IsFlying
        {
            get
            {
                return m_flying > 0;
            }
        }

        /// <summary>
        /// Wether the character may walk over water
        /// </summary>
        public uint WaterWalk
        {
            get
            {
                return m_waterWalk;
            }
            set
            {
                //if ( ( m_waterWalk == 0 ) != ( value == 0 ) )
                //{
                //    if ( m_owner is Character )
                //    {
                //        if ( value == 0 )
                //        {
                //            MovementHandler.SendWalk( (Character)m_owner );
                //        }
                //        else
                //        {
                //            MovementHandler.SendWaterWalk( (Character)m_owner );
                //        }
                //    }
                //}
                //m_waterWalk = value;
            }
        }

        /// <summary>
        /// Wether a character can fly or not
        /// </summary>
        public uint Flying
        {
            get
            {
                return m_flying;
            }
            set
            {
                //if ( ( m_flying == 0 ) != ( value == 0 ) )
                //{
                //    if ( m_owner is Character )
                //    {
                //        if ( value == 0 )
                //        {
                //            MovementHandler.SendFlyModeStop( (Character)m_owner );
                //        }
                //        else
                //        {
                //            MovementHandler.SendFlyModeStart( (Character)m_owner );
                //        }
                //    }
                //}
                //m_flying = value;
            }
        }


        /// <summary>
        /// Wether a character can hover
        /// </summary>
        public uint Hovering
        {
            get
            {
                return m_hovering;
            }
            set
            {
                //if ( ( m_hovering == 0 ) != ( value == 0 ) )
                //{
                //    if ( m_owner is Character )
                //    {
                //        if ( value == 0 )
                //        {
                //            MovementHandler.SendHoverModeStop( (Character)m_owner );
                //        }
                //        else
                //        {
                //            MovementHandler.SendHoverModeStart( (Character)m_owner );
                //        }
                //    }
                //}
                //m_hovering = value;
            }
        }


        /// <summary>
        /// Wether a character would take falling damage or not
        /// </summary>
        public uint FeatherFalling
        {
            get
            {
                return m_featherFalling;
            }
            set
            {
                //if ( ( m_featherFalling == 0 ) != ( value == 0 ) )
                //{
                //    if ( m_owner is Character )
                //    {
                //        if ( value == 0 )
                //        {
                //            MovementHandler.SendFeatherModeStop( (Character)m_owner );
                //        }
                //        else
                //        {
                //            MovementHandler.SendFeatherModeStart( (Character)m_owner );
                //        }
                //    }
                //}
                //m_featherFalling = value;
            }
        }
        #endregion

        #region Speeds
        /// <summary>
        /// The overall-factor for all speeds. Set by the owner's ModifierCollection
        /// </summary>
        public float SpeedFactor
        {
            get
            {
                return m_factor;
            }
            internal set
            {
                if ( value != m_factor )
                {
                    m_factor = value;
                    WalkSpeed = Default.m_walkSpeed * m_factor;
                    WalkBackSpeed = Default.m_walkBackSpeed * m_factor;
                    RunSpeed = Default.m_runSpeed * m_factor;
                    SwimSpeed = Default.m_swimSpeed * ( m_factor + m_swimFactor );
                    SwimBackSpeed = Default.m_swimBackSpeed * ( m_factor + m_swimFactor );
                    FlightSpeed = Default.m_flightSpeed * ( m_factor + m_flightFactor );
                    FlightBackSpeed = Default.m_flightBackSpeed * ( m_factor + m_flightFactor );
                }
            }
        }

        /// <summary>
        /// The factor for all flying-related speeds. Set by the owner's ModifierCollection
        /// </summary>
        public float FlightSpeedFactor
        {
            get
            {
                return m_flightFactor;
            }
            internal set
            {
                if ( value != m_flightFactor )
                {
                    m_flightFactor = value;
                    FlightSpeed = Default.m_flightSpeed * ( m_factor + m_flightFactor );
                    FlightBackSpeed = Default.m_flightBackSpeed * ( m_factor + m_flightFactor );
                }
            }
        }

        /// <summary>
        /// The factor for mounted speed
        /// </summary>
        public float MountSpeedMod
        {
            get
            {
                return m_mountMod;
            }
            internal set
            {
                //if ( value != m_mountMod )
                //{
                //    if ( m_owner.IsMounted )
                //    {
                //        SpeedFactor += value - m_mountMod;
                //    }
                //    m_mountMod = value;
                //}
            }
        }

        /// <summary>
        /// The factor for all swimming-related speeds
        /// </summary>
        public float SwimSpeedFactor
        {
            get
            {
                return m_swimFactor;
            }
            internal set
            {
                if ( value != m_swimFactor )
                {
                    m_swimFactor = value;
                    SwimSpeed = Default.m_swimSpeed * ( m_factor + m_swimFactor );
                    SwimBackSpeed = Default.m_swimBackSpeed * ( m_factor + m_swimFactor );
                }
            }
        }


        /// <summary>
        /// Forward walking speed.
        /// </summary>
        public float WalkSpeed
        {
            get { return m_walkSpeed; }
            set
            {
                //if ( m_walkSpeed != value )
                //{
                //    m_walkSpeed = value;
                //    MovementHandler.SendWalkSpeed( m_owner );
                //}
            }
        }

        /// <summary>
        /// Backwards walking speed.
        /// </summary>
        public float WalkBackSpeed
        {
            get { return m_walkBackSpeed; }
            set
            {
                //if ( m_walkBackSpeed != value )
                //{
                //    m_walkBackSpeed = value;
                //    MovementHandler.SendWalkBackSpeed( m_owner );
                //}
            }
        }

        /// <summary>
        /// Forward running speed.
        /// </summary>
        public float RunSpeed
        {
            get { return m_runSpeed; }
            set
            {
                //if ( m_runSpeed != value )
                //{
                //    m_runSpeed = value;
                //    MovementHandler.SendRunSpeed( m_owner );
                //}
            }
        }

        /// <summary>
        /// Forward swimming speed.
        /// </summary>
        public float SwimSpeed
        {
            get { return m_swimSpeed; }
            set
            {
                //if ( m_swimSpeed != value )
                //{
                //    m_swimSpeed = value;
                //    MovementHandler.SendSwimSpeed( m_owner );
                //}
            }
        }

        /// <summary>
        /// Backwards swimming speed.
        /// </summary>
        public float SwimBackSpeed
        {
            get { return m_swimBackSpeed; }
            set
            {
                //if ( m_swimBackSpeed != value )
                //{
                //    m_swimBackSpeed = value;
                //    MovementHandler.SendSwimBackSpeed( m_owner );
                //}
            }
        }

        /// <summary>
        /// Forward flying speed.
        /// </summary>
        public float FlightSpeed
        {
            get { return m_flightSpeed; }
            set
            {
                //if ( m_flightSpeed != value )
                //{
                //    m_flightSpeed = value;
                //    MovementHandler.SendFlySpeed( m_owner );
                //}
            }
        }

        /// <summary>
        /// Backwards flying speed.
        /// </summary>
        public float FlightBackSpeed
        {
            get { return m_flightBackSpeed; }
            set
            {
                //if ( m_flightBackSpeed != value )
                //{
                //    m_flightBackSpeed = value;
                //    MovementHandler.SendFlyBackSpeed( m_owner );
                //}
            }
        }

        /// <summary>
        /// Turning speed.
        /// </summary>
        public float TurnSpeed
        {
            get { return m_turnSpeed; }
            set
            {
                //if ( m_turnSpeed != value )
                //{
                //    m_turnSpeed = value;
                //    MovementHandler.SendTurnSpeed( m_owner );
                //}
            }
        }
        #endregion
    }
}
