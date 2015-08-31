
using System;
using Demo.Wow.WorldServer.Entity.Common;
namespace Demo.Wow.WorldServer.Entity
{
    // UpdateFields Generated For Build 2.3.0.7561

    #region zh-CHS ObjectFields枚举 | en ObjectFields Enum
    /// <summary>
    /// 
    /// </summary>
    public enum ObjectFields
    {
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        GUID = 0,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        GUID_2 = 1,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        TYPE = 2,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        ENTRY = 3,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        SCALE_X = 4,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: None
        /// </summary>
        PADDING = 5,
    }
    #endregion

    #region zh-CHS ItemFields枚举 | en ItemFields Enum
    /// <summary>
    /// 
    /// </summary>
    public enum ItemFields : uint
    {
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        OWNER = 6,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        OWNER_2 = 7,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CONTAINED = 8,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CONTAINED_2 = 9,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CREATOR = 10,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CREATOR_2 = 11,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        GIFTCREATOR = 12,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        GIFTCREATOR_2 = 13,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: OnlyForOwner, Flag_0x10
        /// </summary>
        STACK_COUNT = 14,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: OnlyForOwner, Flag_0x10
        /// </summary>
        DURATION = 15,
        /// <summary>
        /// Size: 5 - Type: Int32 - Flags: OnlyForOwner, Flag_0x10
        /// </summary>
        SPELL_CHARGES = 16,
        /// <summary>
        /// Size: 5 - Type: Int32 - Flags: OnlyForOwner, Flag_0x10
        /// </summary>
        SPELL_CHARGES_2 = 17,
        /// <summary>
        /// Size: 5 - Type: Int32 - Flags: OnlyForOwner, Flag_0x10
        /// </summary>
        SPELL_CHARGES_3 = 18,
        /// <summary>
        /// Size: 5 - Type: Int32 - Flags: OnlyForOwner, Flag_0x10
        /// </summary>
        SPELL_CHARGES_4 = 19,
        /// <summary>
        /// Size: 5 - Type: Int32 - Flags: OnlyForOwner, Flag_0x10
        /// </summary>
        SPELL_CHARGES_5 = 20,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        FLAGS = 21,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT = 22,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_2 = 23,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_3 = 24,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_4 = 25,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_5 = 26,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_6 = 27,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_7 = 28,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_8 = 29,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_9 = 30,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_10 = 31,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_11 = 32,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_12 = 33,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_13 = 34,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_14 = 35,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_15 = 36,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_16 = 37,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_17 = 38,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_18 = 39,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_19 = 40,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_20 = 41,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_21 = 42,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_22 = 43,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_23 = 44,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_24 = 45,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_25 = 46,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_26 = 47,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_27 = 48,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_28 = 49,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_29 = 50,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_30 = 51,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_31 = 52,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_32 = 53,
        /// <summary>
        /// Size: 33 - Type: Int32 - Flags: Public
        /// </summary>
        ENCHANTMENT_33 = 54,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        PROPERTY_SEED = 55,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        RANDOM_PROPERTIES_ID = 56,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: OnlyForOwner
        /// </summary>
        TEXT_ID = 57,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: OnlyForOwner, Flag_0x10
        /// </summary>
        DURABILITY = 58,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: OnlyForOwner, Flag_0x10
        /// </summary>
        MAXDURABILITY = 59,
    }
    #endregion

    #region zh-CHS ContainerFields枚举 | en ContainerFields Enum
    /// <summary>
    /// 
    /// </summary>
    public enum ContainerFields
    {
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        NUM_SLOTS = 60,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: None
        /// </summary>
        CONTAINER_ALIGN_PAD,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_2,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_3,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_4,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_5,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_6,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_7,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_8,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_9,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_10,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_11,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_12,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_13,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_14,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_15,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_16,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_17,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_18,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_19,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_20,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_21,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_22,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_23,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_24,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_25,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_26,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_27,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_28,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_29,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_30,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_31,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_32,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_33,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_34,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_35,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_36,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_37,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_38,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_39,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_40,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_41,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_42,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_43,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_44,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_45,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_46,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_47,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_48,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_49,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_50,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_51,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_52,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_53,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_54,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_55,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_56,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_57,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_58,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_59,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_60,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_61,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_62,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_63,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_64,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_65,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_66,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_67,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_68,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_69,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_70,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_71,
        /// <summary>
        /// Size: 72 - Type: GUID - Flags: Public
        /// </summary>
        SLOT_1_72,
    }
    #endregion

    #region zh-CHS UnitFields枚举 | en UnitFields Enum
    /// <summary>
    /// 
    /// </summary>
    public enum UnitFields
    {
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CHARM = 6,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CHARM_2 = 7,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        SUMMON = 8,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        SUMMON_2 = 9,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CHARMEDBY = 10,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CHARMEDBY_2 = 11,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        SUMMONEDBY = 12,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        SUMMONEDBY_2 = 13,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CREATEDBY = 14,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CREATEDBY_2 = 15,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        TARGET = 16,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        TARGET_2 = 17,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        PERSUADED = 18,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        PERSUADED_2 = 19,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CHANNEL_OBJECT = 20,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CHANNEL_OBJECT_2 = 21,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Dynamic
        /// </summary>
        HEALTH = 22,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        POWER1 = 23,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        POWER2 = 24,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        POWER3 = 25,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        POWER4 = 26,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        POWER5 = 27,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Dynamic
        /// </summary>
        MAXHEALTH = 28,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        MAXPOWER1 = 29,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        MAXPOWER2 = 30,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        MAXPOWER3 = 31,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        MAXPOWER4 = 32,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        MAXPOWER5 = 33,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        LEVEL = 34,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        FACTIONTEMPLATE = 35,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        BYTES_0 = 36,
        /// <summary>
        /// Size: 3 - Type: Int32 - Flags: Public
        /// </summary>
        UNIT_VIRTUAL_ITEM_SLOT_DISPLAY = 37,
        /// <summary>
        /// Size: 3 - Type: Int32 - Flags: Public
        /// </summary>
        UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_2 = 38,
        /// <summary>
        /// Size: 3 - Type: Int32 - Flags: Public
        /// </summary>
        UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_3 = 39,
        /// <summary>
        /// Size: 6 - Type: Bytes - Flags: Public
        /// </summary>
        UNIT_VIRTUAL_ITEM_INFO = 40,
        /// <summary>
        /// Size: 6 - Type: Bytes - Flags: Public
        /// </summary>
        UNIT_VIRTUAL_ITEM_INFO_2 = 41,
        /// <summary>
        /// Size: 6 - Type: Bytes - Flags: Public
        /// </summary>
        UNIT_VIRTUAL_ITEM_INFO_3 = 42,
        /// <summary>
        /// Size: 6 - Type: Bytes - Flags: Public
        /// </summary>
        UNIT_VIRTUAL_ITEM_INFO_4 = 43,
        /// <summary>
        /// Size: 6 - Type: Bytes - Flags: Public
        /// </summary>
        UNIT_VIRTUAL_ITEM_INFO_5 = 44,
        /// <summary>
        /// Size: 6 - Type: Bytes - Flags: Public
        /// </summary>
        UNIT_VIRTUAL_ITEM_INFO_6 = 45,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        FLAGS = 46,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        FLAGS_2 = 47,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA = 48,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_2 = 49,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_3 = 50,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_4 = 51,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_5 = 52,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_6 = 53,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_7 = 54,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_8 = 55,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_9 = 56,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_10 = 57,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_11 = 58,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_12 = 59,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_13 = 60,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_14 = 61,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_15 = 62,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_16 = 63,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_17 = 64,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_18 = 65,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_19 = 66,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_20 = 67,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_21 = 68,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_22 = 69,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_23 = 70,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_24 = 71,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_25 = 72,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_26 = 73,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_27 = 74,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_28 = 75,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_29 = 76,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_30 = 77,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_31 = 78,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_32 = 79,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_33 = 80,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_34 = 81,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_35 = 82,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_36 = 83,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_37 = 84,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_38 = 85,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_39 = 86,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_40 = 87,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_41 = 88,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_42 = 89,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_43 = 90,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_44 = 91,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_45 = 92,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_46 = 93,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_47 = 94,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_48 = 95,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_49 = 96,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_50 = 97,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_51 = 98,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_52 = 99,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_53 = 100,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_54 = 101,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_55 = 102,
        /// <summary>
        /// Size: 56 - Type: Int32 - Flags: Public
        /// </summary>
        AURA_56 = 103,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS = 104,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_2 = 105,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_3 = 106,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_4 = 107,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_5 = 108,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_6 = 109,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_7 = 110,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_8 = 111,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_9 = 112,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_10 = 113,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_11 = 114,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_12 = 115,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_13 = 116,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAFLAGS_14 = 117,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS = 118,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_2 = 119,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_3 = 120,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_4 = 121,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_5 = 122,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_6 = 123,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_7 = 124,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_8 = 125,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_9 = 126,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_10 = 127,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_11 = 128,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_12 = 129,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_13 = 130,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURALEVELS_14 = 131,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS = 132,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_2 = 133,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_3 = 134,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_4 = 135,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_5 = 136,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_6 = 137,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_7 = 138,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_8 = 139,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_9 = 140,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_10 = 141,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_11 = 142,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_12 = 143,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_13 = 144,
        /// <summary>
        /// Size: 14 - Type: Bytes - Flags: Public
        /// </summary>
        AURAAPPLICATIONS_14 = 145,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        AURASTATE = 146,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Public
        /// </summary>
        BASEATTACKTIME = 147,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Public
        /// </summary>
        BASEATTACKTIME_2 = 148,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        RANGEDATTACKTIME = 149,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        BOUNDINGRADIUS = 150,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        COMBATREACH = 151,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        DISPLAYID = 152,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        NATIVEDISPLAYID = 153,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        MOUNTDISPLAYID = 154,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        MINDAMAGE = 155,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        MAXDAMAGE = 156,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        MINOFFHANDDAMAGE = 157,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        MAXOFFHANDDAMAGE = 158,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        BYTES_1 = 159,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        PETNUMBER = 160,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        PET_NAME_TIMESTAMP = 161,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: OnlyForOwner
        /// </summary>
        PETEXPERIENCE = 162,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: OnlyForOwner
        /// </summary>
        PETNEXTLEVELEXP = 163,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Dynamic
        /// </summary>
        UNIT_DYNAMIC_FLAGS = 164,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        UNIT_CHANNEL_SPELL = 165,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        UNIT_MOD_CAST_SPEED = 166,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        UNIT_CREATED_BY_SPELL = 167,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Dynamic
        /// </summary>
        UNIT_NPC_FLAGS = 168,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        UNIT_NPC_EMOTESTATE = 169,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: OnlyForOwner
        /// </summary>
        UNIT_TRAINING_POINTS = 170,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        STAT0 = 171,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        STAT1 = 172,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        STAT2 = 173,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        STAT3 = 174,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        STAT4 = 175,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POSSTAT0 = 176,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POSSTAT1 = 177,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POSSTAT2 = 178,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POSSTAT3 = 179,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POSSTAT4 = 180,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        NEGSTAT0 = 181,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        NEGSTAT1 = 182,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        NEGSTAT2 = 183,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        NEGSTAT3 = 184,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        NEGSTAT4 = 185,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        RESISTANCES = 186,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        RESISTANCES_2 = 187,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        RESISTANCES_3 = 188,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        RESISTANCES_4 = 189,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        RESISTANCES_5 = 190,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        RESISTANCES_6 = 191,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner, Flag_0x20
        /// </summary>
        RESISTANCES_7 = 192,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSPOSITIVE = 193,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSPOSITIVE_2 = 194,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSPOSITIVE_3 = 195,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSPOSITIVE_4 = 196,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSPOSITIVE_5 = 197,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSPOSITIVE_6 = 198,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSPOSITIVE_7 = 199,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSNEGATIVE = 200,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSNEGATIVE_2 = 201,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSNEGATIVE_3 = 202,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSNEGATIVE_4 = 203,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSNEGATIVE_5 = 204,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSNEGATIVE_6 = 205,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RESISTANCEBUFFMODSNEGATIVE_7 = 206,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        BASE_MANA = 207,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        BASE_HEALTH = 208,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        BYTES_2 = 209,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        ATTACK_POWER = 210,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Private, OnlyForOwner
        /// </summary>
        ATTACK_POWER_MODS = 211,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        ATTACK_POWER_MULTIPLIER = 212,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        RANGED_ATTACK_POWER = 213,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Private, OnlyForOwner
        /// </summary>
        RANGED_ATTACK_POWER_MODS = 214,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        RANGED_ATTACK_POWER_MULTIPLIER = 215,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        MINRANGEDDAMAGE = 216,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        MAXRANGEDDAMAGE = 217,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MODIFIER = 218,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MODIFIER_2 = 219,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MODIFIER_3 = 220,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MODIFIER_4 = 221,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MODIFIER_5 = 222,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MODIFIER_6 = 223,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MODIFIER_7 = 224,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MULTIPLIER = 225,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MULTIPLIER_2 = 226,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MULTIPLIER_3 = 227,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MULTIPLIER_4 = 228,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MULTIPLIER_5 = 229,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MULTIPLIER_6 = 230,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private, OnlyForOwner
        /// </summary>
        POWER_COST_MULTIPLIER_7 = 231,
    }
    #endregion

    #region zh-CHS PlayerFields枚举 | en PlayerFields Enum
    /// <summary>
    /// 
    /// </summary>
    public enum PlayerFields
    {
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        DUEL_ARBITER = 232,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        DUEL_ARBITER_2 = 233,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        FLAGS = 234,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        GUILDID = 235,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        GUILDRANK = 236,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        BYTES = 237,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        BYTES_2 = 238,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        BYTES_3 = 239,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        DUEL_TEAM = 240,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        GUILD_TIMESTAMP = 241,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_1_1 = 242,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_1_2 = 243,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_1_2_2 = 244,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_2_1 = 245,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_2_2 = 246,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_2_2_2 = 247,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_3_1 = 248,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_3_2 = 249,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_3_2_2 = 250,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_4_1 = 251,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_4_2 = 252,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_4_2_2 = 253,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_5_1 = 254,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_5_2 = 255,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_5_2_2 = 256,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_6_1 = 257,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_6_2 = 258,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_6_2_2 = 259,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_7_1 = 260,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_7_2 = 261,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_7_2_2 = 262,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_8_1 = 263,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_8_2 = 264,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_8_2_2 = 265,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_9_1 = 266,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_9_2 = 267,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_9_2_2 = 268,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_10_1 = 269,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_10_2 = 270,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_10_2_2 = 271,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_11_1 = 272,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_11_2 = 273,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_11_2_2 = 274,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_12_1 = 275,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_12_2 = 276,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_12_2_2 = 277,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_13_1 = 278,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_13_2 = 279,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_13_2_2 = 280,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_14_1 = 281,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_14_2 = 282,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_14_2_2 = 283,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_15_1 = 284,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_15_2 = 285,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_15_2_2 = 286,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_16_1 = 287,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_16_2 = 288,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_16_2_2 = 289,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_17_1 = 290,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_17_2 = 291,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_17_2_2 = 292,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_18_1 = 293,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_18_2 = 294,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_18_2_2 = 295,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_19_1 = 296,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_19_2 = 297,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_19_2_2 = 298,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_20_1 = 299,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_20_2 = 300,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_20_2_2 = 301,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_21_1 = 302,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_21_2 = 303,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_21_2_2 = 304,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_22_1 = 305,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_22_2 = 306,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_22_2_2 = 307,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_23_1 = 308,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_23_2 = 309,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_23_2_2 = 310,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_24_1 = 311,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_24_2 = 312,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_24_2_2 = 313,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: GroupOnly
        /// </summary>
        QUEST_LOG_25_1 = 314,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_25_2 = 315,
        /// <summary>
        /// Size: 2 - Type: Int32 - Flags: Private
        /// </summary>
        QUEST_LOG_25_2_2 = 316,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_CREATOR = 317,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_CREATOR_2 = 318,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0 = 319,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_2 = 320,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_3 = 321,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_4 = 322,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_5 = 323,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_6 = 324,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_7 = 325,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_8 = 326,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_9 = 327,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_10 = 328,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_11 = 329,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_0_12 = 330,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_PROPERTIES = 331,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_1_PAD = 332,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_CREATOR = 333,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_CREATOR_2 = 334,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0 = 335,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_2 = 336,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_3 = 337,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_4 = 338,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_5 = 339,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_6 = 340,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_7 = 341,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_8 = 342,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_9 = 343,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_10 = 344,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_11 = 345,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_0_12 = 346,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_PROPERTIES = 347,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_2_PAD = 348,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_CREATOR = 349,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_CREATOR_2 = 350,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0 = 351,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_2 = 352,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_3 = 353,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_4 = 354,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_5 = 355,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_6 = 356,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_7 = 357,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_8 = 358,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_9 = 359,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_10 = 360,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_11 = 361,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_0_12 = 362,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_PROPERTIES = 363,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_3_PAD = 364,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_CREATOR = 365,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_CREATOR_2 = 366,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0 = 367,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_2 = 368,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_3 = 369,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_4 = 370,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_5 = 371,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_6 = 372,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_7 = 373,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_8 = 374,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_9 = 375,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_10 = 376,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_11 = 377,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_0_12 = 378,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_PROPERTIES = 379,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_4_PAD = 380,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_CREATOR = 381,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_CREATOR_2 = 382,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0 = 383,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_2 = 384,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_3 = 385,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_4 = 386,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_5 = 387,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_6 = 388,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_7 = 389,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_8 = 390,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_9 = 391,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_10 = 392,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_11 = 393,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_0_12 = 394,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_PROPERTIES = 395,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_5_PAD = 396,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_CREATOR = 397,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_CREATOR_2 = 398,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0 = 399,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_2 = 400,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_3 = 401,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_4 = 402,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_5 = 403,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_6 = 404,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_7 = 405,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_8 = 406,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_9 = 407,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_10 = 408,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_11 = 409,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_0_12 = 410,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_PROPERTIES = 411,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_6_PAD = 412,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_CREATOR = 413,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_CREATOR_2 = 414,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0 = 415,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_2 = 416,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_3 = 417,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_4 = 418,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_5 = 419,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_6 = 420,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_7 = 421,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_8 = 422,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_9 = 423,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_10 = 424,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_11 = 425,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_0_12 = 426,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_PROPERTIES = 427,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_7_PAD = 428,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_CREATOR = 429,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_CREATOR_2 = 430,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0 = 431,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_2 = 432,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_3 = 433,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_4 = 434,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_5 = 435,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_6 = 436,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_7 = 437,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_8 = 438,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_9 = 439,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_10 = 440,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_11 = 441,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_0_12 = 442,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_PROPERTIES = 443,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_8_PAD = 444,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_CREATOR = 445,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_CREATOR_2 = 446,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0 = 447,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_2 = 448,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_3 = 449,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_4 = 450,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_5 = 451,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_6 = 452,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_7 = 453,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_8 = 454,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_9 = 455,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_10 = 456,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_11 = 457,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_0_12 = 458,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_PROPERTIES = 459,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_9_PAD = 460,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_CREATOR = 461,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_CREATOR_2 = 462,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0 = 463,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_2 = 464,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_3 = 465,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_4 = 466,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_5 = 467,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_6 = 468,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_7 = 469,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_8 = 470,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_9 = 471,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_10 = 472,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_11 = 473,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_0_12 = 474,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_PROPERTIES = 475,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_10_PAD = 476,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_CREATOR = 477,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_CREATOR_2 = 478,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0 = 479,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_2 = 480,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_3 = 481,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_4 = 482,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_5 = 483,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_6 = 484,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_7 = 485,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_8 = 486,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_9 = 487,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_10 = 488,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_11 = 489,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_0_12 = 490,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_PROPERTIES = 491,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_11_PAD = 492,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_CREATOR = 493,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_CREATOR_2 = 494,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0 = 495,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_2 = 496,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_3 = 497,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_4 = 498,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_5 = 499,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_6 = 500,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_7 = 501,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_8 = 502,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_9 = 503,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_10 = 504,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_11 = 505,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_0_12 = 506,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_PROPERTIES = 507,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_12_PAD = 508,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_CREATOR = 509,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_CREATOR_2 = 510,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0 = 511,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_2 = 512,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_3 = 513,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_4 = 514,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_5 = 515,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_6 = 516,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_7 = 517,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_8 = 518,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_9 = 519,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_10 = 520,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_11 = 521,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_0_12 = 522,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_PROPERTIES = 523,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_13_PAD = 524,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_CREATOR = 525,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_CREATOR_2 = 526,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0 = 527,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_2 = 528,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_3 = 529,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_4 = 530,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_5 = 531,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_6 = 532,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_7 = 533,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_8 = 534,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_9 = 535,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_10 = 536,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_11 = 537,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_0_12 = 538,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_PROPERTIES = 539,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_14_PAD = 540,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_CREATOR = 541,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_CREATOR_2 = 542,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0 = 543,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_2 = 544,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_3 = 545,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_4 = 546,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_5 = 547,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_6 = 548,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_7 = 549,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_8 = 550,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_9 = 551,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_10 = 552,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_11 = 553,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_0_12 = 554,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_PROPERTIES = 555,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_15_PAD = 556,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_CREATOR = 557,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_CREATOR_2 = 558,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0 = 559,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_2 = 560,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_3 = 561,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_4 = 562,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_5 = 563,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_6 = 564,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_7 = 565,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_8 = 566,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_9 = 567,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_10 = 568,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_11 = 569,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_0_12 = 570,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_PROPERTIES = 571,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_16_PAD = 572,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_CREATOR = 573,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_CREATOR_2 = 574,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0 = 575,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_2 = 576,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_3 = 577,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_4 = 578,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_5 = 579,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_6 = 580,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_7 = 581,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_8 = 582,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_9 = 583,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_10 = 584,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_11 = 585,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_0_12 = 586,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_PROPERTIES = 587,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_17_PAD = 588,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_CREATOR = 589,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_CREATOR_2 = 590,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0 = 591,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_2 = 592,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_3 = 593,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_4 = 594,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_5 = 595,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_6 = 596,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_7 = 597,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_8 = 598,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_9 = 599,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_10 = 600,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_11 = 601,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_0_12 = 602,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_PROPERTIES = 603,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_18_PAD = 604,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_CREATOR = 605,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_CREATOR_2 = 606,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0 = 607,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_2 = 608,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_3 = 609,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_4 = 610,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_5 = 611,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_6 = 612,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_7 = 613,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_8 = 614,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_9 = 615,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_10 = 616,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_11 = 617,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_0_12 = 618,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_PROPERTIES = 619,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        VISIBLE_ITEM_19_PAD = 620,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        CHOSEN_TITLE = 621,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD = 622,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_2 = 623,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_3 = 624,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_4 = 625,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_5 = 626,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_6 = 627,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_7 = 628,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_8 = 629,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_9 = 630,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_10 = 631,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_11 = 632,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_12 = 633,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_13 = 634,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_14 = 635,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_15 = 636,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_16 = 637,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_17 = 638,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_18 = 639,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_19 = 640,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_20 = 641,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_21 = 642,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_22 = 643,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_23 = 644,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_24 = 645,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_25 = 646,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_26 = 647,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_27 = 648,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_28 = 649,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_29 = 650,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_30 = 651,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_31 = 652,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_32 = 653,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_33 = 654,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_34 = 655,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_35 = 656,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_36 = 657,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_37 = 658,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_38 = 659,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_39 = 660,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_40 = 661,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_41 = 662,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_42 = 663,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_43 = 664,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_44 = 665,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_45 = 666,
        /// <summary>
        /// Size: 46 - Type: GUID - Flags: Private
        /// </summary>
        INV_SLOT_HEAD_46 = 667,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1 = 668,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_2 = 669,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_3 = 670,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_4 = 671,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_5 = 672,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_6 = 673,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_7 = 674,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_8 = 675,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_9 = 676,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_10 = 677,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_11 = 678,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_12 = 679,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_13 = 680,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_14 = 681,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_15 = 682,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_16 = 683,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_17 = 684,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_18 = 685,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_19 = 686,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_20 = 687,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_21 = 688,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_22 = 689,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_23 = 690,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_24 = 691,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_25 = 692,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_26 = 693,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_27 = 694,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_28 = 695,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_29 = 696,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_30 = 697,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_31 = 698,
        /// <summary>
        /// Size: 32 - Type: GUID - Flags: Private
        /// </summary>
        PACK_SLOT_1_32 = 699,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1 = 700,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_2 = 701,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_3 = 702,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_4 = 703,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_5 = 704,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_6 = 705,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_7 = 706,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_8 = 707,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_9 = 708,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_10 = 709,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_11 = 710,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_12 = 711,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_13 = 712,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_14 = 713,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_15 = 714,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_16 = 715,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_17 = 716,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_18 = 717,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_19 = 718,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_20 = 719,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_21 = 720,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_22 = 721,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_23 = 722,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_24 = 723,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_25 = 724,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_26 = 725,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_27 = 726,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_28 = 727,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_29 = 728,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_30 = 729,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_31 = 730,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_32 = 731,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_33 = 732,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_34 = 733,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_35 = 734,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_36 = 735,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_37 = 736,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_38 = 737,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_39 = 738,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_40 = 739,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_41 = 740,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_42 = 741,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_43 = 742,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_44 = 743,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_45 = 744,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_46 = 745,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_47 = 746,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_48 = 747,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_49 = 748,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_50 = 749,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_51 = 750,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_52 = 751,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_53 = 752,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_54 = 753,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_55 = 754,
        /// <summary>
        /// Size: 56 - Type: GUID - Flags: Private
        /// </summary>
        BANK_SLOT_1_56 = 755,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1 = 756,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_2 = 757,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_3 = 758,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_4 = 759,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_5 = 760,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_6 = 761,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_7 = 762,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_8 = 763,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_9 = 764,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_10 = 765,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_11 = 766,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_12 = 767,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_13 = 768,
        /// <summary>
        /// Size: 14 - Type: GUID - Flags: Private
        /// </summary>
        BANKBAG_SLOT_1_14 = 769,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1 = 770,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_2 = 771,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_3 = 772,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_4 = 773,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_5 = 774,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_6 = 775,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_7 = 776,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_8 = 777,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_9 = 778,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_10 = 779,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_11 = 780,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_12 = 781,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_13 = 782,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_14 = 783,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_15 = 784,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_16 = 785,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_17 = 786,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_18 = 787,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_19 = 788,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_20 = 789,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_21 = 790,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_22 = 791,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_23 = 792,
        /// <summary>
        /// Size: 24 - Type: GUID - Flags: Private
        /// </summary>
        VENDORBUYBACK_SLOT_1_24 = 793,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1 = 794,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_2 = 795,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_3 = 796,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_4 = 797,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_5 = 798,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_6 = 799,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_7 = 800,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_8 = 801,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_9 = 802,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_10 = 803,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_11 = 804,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_12 = 805,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_13 = 806,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_14 = 807,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_15 = 808,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_16 = 809,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_17 = 810,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_18 = 811,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_19 = 812,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_20 = 813,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_21 = 814,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_22 = 815,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_23 = 816,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_24 = 817,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_25 = 818,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_26 = 819,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_27 = 820,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_28 = 821,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_29 = 822,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_30 = 823,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_31 = 824,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_32 = 825,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_33 = 826,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_34 = 827,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_35 = 828,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_36 = 829,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_37 = 830,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_38 = 831,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_39 = 832,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_40 = 833,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_41 = 834,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_42 = 835,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_43 = 836,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_44 = 837,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_45 = 838,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_46 = 839,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_47 = 840,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_48 = 841,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_49 = 842,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_50 = 843,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_51 = 844,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_52 = 845,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_53 = 846,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_54 = 847,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_55 = 848,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_56 = 849,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_57 = 850,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_58 = 851,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_59 = 852,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_60 = 853,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_61 = 854,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_62 = 855,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_63 = 856,
        /// <summary>
        /// Size: 64 - Type: GUID - Flags: Private
        /// </summary>
        KEYRING_SLOT_1_64 = 857,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Private
        /// </summary>
        FARSIGHT = 858,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Private
        /// </summary>
        FARSIGHT_2 = 859,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Private
        /// </summary>
        KNOWN_TITLES = 860,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Private
        /// </summary>
        KNOWN_TITLES_2 = 861,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private				   t
        /// </summary>
        XP = 862,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        NEXT_LEVEL_XP = 863,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField1 = 864,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField2 = 865,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField3 = 866,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField4 = 867,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField5 = 868,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField6 = 869,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField7 = 870,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField8 = 871,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField9 = 872,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField10 = 873,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField11 = 874,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField12 = 875,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField13 = 876,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField14 = 877,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField15 = 878,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField16 = 879,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField17 = 880,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField18 = 881,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField19 = 882,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField20 = 883,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField21 = 884,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField22 = 885,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField23 = 886,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField24 = 887,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField25 = 888,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField26 = 889,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField27 = 890,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField28 = 891,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField29 = 892,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField30 = 893,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField31 = 894,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField32 = 895,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField33 = 896,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField34 = 897,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField35 = 898,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField36 = 899,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField37 = 900,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField38 = 901,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField39 = 902,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField40 = 903,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField41 = 904,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField42 = 905,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField43 = 906,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField44 = 907,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField45 = 908,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField46 = 909,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField47 = 910,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField48 = 911,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField49 = 912,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField50 = 913,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField51 = 914,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField52 = 915,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField53 = 916,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField54 = 917,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField55 = 918,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField56 = 919,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField57 = 920,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField58 = 921,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField59 = 922,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField60 = 923,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField61 = 924,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField62 = 925,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField63 = 926,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField64 = 927,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField65 = 928,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField66 = 929,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField67 = 930,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField68 = 931,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField69 = 932,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField70 = 933,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField71 = 934,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField72 = 935,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField73 = 936,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField74 = 937,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField75 = 938,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField76 = 939,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField77 = 940,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField78 = 941,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField79 = 942,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField80 = 943,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField81 = 944,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField82 = 945,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField83 = 946,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField84 = 947,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField85 = 948,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField86 = 949,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField87 = 950,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField88 = 951,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField89 = 952,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField90 = 953,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField91 = 954,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField92 = 955,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField93 = 956,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField94 = 957,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField95 = 958,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField96 = 959,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField97 = 960,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField98 = 961,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField99 = 962,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField100 = 963,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField101 = 964,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField102 = 965,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField103 = 966,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField104 = 967,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField105 = 968,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField106 = 969,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField107 = 970,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField108 = 971,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField109 = 972,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField110 = 973,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField111 = 974,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField112 = 975,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField113 = 976,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField114 = 977,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField115 = 978,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField116 = 979,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField117 = 980,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField118 = 981,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField119 = 982,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField120 = 983,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField121 = 984,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField122 = 985,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField123 = 986,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField124 = 987,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField125 = 988,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField126 = 989,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField127 = 990,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField128 = 991,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField129 = 992,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField130 = 993,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField131 = 994,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField132 = 995,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField133 = 996,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField134 = 997,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField135 = 998,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField136 = 999,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField137 = 1000,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField138 = 1001,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField139 = 1002,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField140 = 1003,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField141 = 1004,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField142 = 1005,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField143 = 1006,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField144 = 1007,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField145 = 1008,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField146 = 1009,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField147 = 1010,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField148 = 1011,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField149 = 1012,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField150 = 1013,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField151 = 1014,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField152 = 1015,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField153 = 1016,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField154 = 1017,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField155 = 1018,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField156 = 1019,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField157 = 1020,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField158 = 1021,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField159 = 1022,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField160 = 1023,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField161 = 1024,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField162 = 1025,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField163 = 1026,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField164 = 1027,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField165 = 1028,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField166 = 1029,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField167 = 1030,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField168 = 1031,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField169 = 1032,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField170 = 1033,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField171 = 1034,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField172 = 1035,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField173 = 1036,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField174 = 1037,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField175 = 1038,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField176 = 1039,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField177 = 1040,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField178 = 1041,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField179 = 1042,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField180 = 1043,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField181 = 1044,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField182 = 1045,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField183 = 1046,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField184 = 1047,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField185 = 1048,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField186 = 1049,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField187 = 1050,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField188 = 1051,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField189 = 1052,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField190 = 1053,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField191 = 1054,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField192 = 1055,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField193 = 1056,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField194 = 1057,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField195 = 1058,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField196 = 1059,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField197 = 1060,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField198 = 1061,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField199 = 1062,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField200 = 1063,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField201 = 1064,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField202 = 1065,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField203 = 1066,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField204 = 1067,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField205 = 1068,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField206 = 1069,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField207 = 1070,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField208 = 1071,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField209 = 1072,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField210 = 1073,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField211 = 1074,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField212 = 1075,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField213 = 1076,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField214 = 1077,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField215 = 1078,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField216 = 1079,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField217 = 1080,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField218 = 1081,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField219 = 1082,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField220 = 1083,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField221 = 1084,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField222 = 1085,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField223 = 1086,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField224 = 1087,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField225 = 1088,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField226 = 1089,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField227 = 1090,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField228 = 1091,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField229 = 1092,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField230 = 1093,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField231 = 1094,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField232 = 1095,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField233 = 1096,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField234 = 1097,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField235 = 1098,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField236 = 1099,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField237 = 1100,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField238 = 1101,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField239 = 1102,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField240 = 1103,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField241 = 1104,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField242 = 1105,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField243 = 1106,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField244 = 1107,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField245 = 1108,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField246 = 1109,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField247 = 1110,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField248 = 1111,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField249 = 1112,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField250 = 1113,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField251 = 1114,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField252 = 1115,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField253 = 1116,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField254 = 1117,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField255 = 1118,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField256 = 1119,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField257 = 1120,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField258 = 1121,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField259 = 1122,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField260 = 1123,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField261 = 1124,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField262 = 1125,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField263 = 1126,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField264 = 1127,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField265 = 1128,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField266 = 1129,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField267 = 1130,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField268 = 1131,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField269 = 1132,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField270 = 1133,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField271 = 1134,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField272 = 1135,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField273 = 1136,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField274 = 1137,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField275 = 1138,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField276 = 1139,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField277 = 1140,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField278 = 1141,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField279 = 1142,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField280 = 1143,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField281 = 1144,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField282 = 1145,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField283 = 1146,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField284 = 1147,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField285 = 1148,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField286 = 1149,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField287 = 1150,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField288 = 1151,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField289 = 1152,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField290 = 1153,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField291 = 1154,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField292 = 1155,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField293 = 1156,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField294 = 1157,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField295 = 1158,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField296 = 1159,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField297 = 1160,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField298 = 1161,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField299 = 1162,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField300 = 1163,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField301 = 1164,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField302 = 1165,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField303 = 1166,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField304 = 1167,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField305 = 1168,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField306 = 1169,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField307 = 1170,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField308 = 1171,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField309 = 1172,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField310 = 1173,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField311 = 1174,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField312 = 1175,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField313 = 1176,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField314 = 1177,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField315 = 1178,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField316 = 1179,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField317 = 1180,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField318 = 1181,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField319 = 1182,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField320 = 1183,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField321 = 1184,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField322 = 1185,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField323 = 1186,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField324 = 1187,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField325 = 1188,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField326 = 1189,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField327 = 1190,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField328 = 1191,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField329 = 1192,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField330 = 1193,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField331 = 1194,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField332 = 1195,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField333 = 1196,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField334 = 1197,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField335 = 1198,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField336 = 1199,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField337 = 1200,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField338 = 1201,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField339 = 1202,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField340 = 1203,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField341 = 1204,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField342 = 1205,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField343 = 1206,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField344 = 1207,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField345 = 1208,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField346 = 1209,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField347 = 1210,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField348 = 1211,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField349 = 1212,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField350 = 1213,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField351 = 1214,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField352 = 1215,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField353 = 1216,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField354 = 1217,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField355 = 1218,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField356 = 1219,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField357 = 1220,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField358 = 1221,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField359 = 1222,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField360 = 1223,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField361 = 1224,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField362 = 1225,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField363 = 1226,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField364 = 1227,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField365 = 1228,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField366 = 1229,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField367 = 1230,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField368 = 1231,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField369 = 1232,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField370 = 1233,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField371 = 1234,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField372 = 1235,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField373 = 1236,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField374 = 1237,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField375 = 1238,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField376 = 1239,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField377 = 1240,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField378 = 1241,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField379 = 1242,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField380 = 1243,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField381 = 1244,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField382 = 1245,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField383 = 1246,
        /// <summary>
        /// Size: 384 - Type: TwoInt16 - Flags: Private
        /// </summary>
        SkillField384 = 1247,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        TalentCount = 1248,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        RemainingProfessions = 1249,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        TRACK_CREATURES = 1250,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        TRACK_RESOURCES = 1251,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private
        /// </summary>
        BLOCK_PERCENTAGE = 1252,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private
        /// </summary>
        DODGE_PERCENTAGE = 1253,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private
        /// </summary>
        PARRY_PERCENTAGE = 1254,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        EXPERTISE = 1255,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private
        /// </summary>
        CRIT_PERCENTAGE = 1256,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private
        /// </summary>
        RANGED_CRIT_PERCENTAGE = 1257,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private
        /// </summary>
        OFFHAND_CRIT_PERCENTAGE = 1258,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private
        /// </summary>
        SPELL_CRIT_PERCENTAGE1 = 1259,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private
        /// </summary>
        SPELL_CRIT_PERCENTAGE1_2 = 1260,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private
        /// </summary>
        SPELL_CRIT_PERCENTAGE1_3 = 1261,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private
        /// </summary>
        SPELL_CRIT_PERCENTAGE1_4 = 1262,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private
        /// </summary>
        SPELL_CRIT_PERCENTAGE1_5 = 1263,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private
        /// </summary>
        SPELL_CRIT_PERCENTAGE1_6 = 1264,
        /// <summary>
        /// Size: 7 - Type: Float - Flags: Private
        /// </summary>
        SPELL_CRIT_PERCENTAGE1_7 = 1265,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        SHIELD_BLOCK = 1266,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1 = 1267,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_2 = 1268,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_3 = 1269,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_4 = 1270,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_5 = 1271,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_6 = 1272,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_7 = 1273,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_8 = 1274,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_9 = 1275,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_10 = 1276,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_11 = 1277,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_12 = 1278,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_13 = 1279,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_14 = 1280,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_15 = 1281,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_16 = 1282,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_17 = 1283,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_18 = 1284,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_19 = 1285,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_20 = 1286,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_21 = 1287,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_22 = 1288,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_23 = 1289,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_24 = 1290,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_25 = 1291,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_26 = 1292,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_27 = 1293,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_28 = 1294,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_29 = 1295,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_30 = 1296,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_31 = 1297,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_32 = 1298,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_33 = 1299,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_34 = 1300,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_35 = 1301,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_36 = 1302,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_37 = 1303,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_38 = 1304,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_39 = 1305,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_40 = 1306,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_41 = 1307,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_42 = 1308,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_43 = 1309,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_44 = 1310,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_45 = 1311,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_46 = 1312,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_47 = 1313,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_48 = 1314,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_49 = 1315,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_50 = 1316,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_51 = 1317,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_52 = 1318,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_53 = 1319,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_54 = 1320,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_55 = 1321,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_56 = 1322,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_57 = 1323,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_58 = 1324,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_59 = 1325,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_60 = 1326,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_61 = 1327,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_62 = 1328,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_63 = 1329,
        /// <summary>
        /// Size: 64 - Type: Bytes - Flags: Private
        /// </summary>
        EXPLORED_ZONES_1_64 = 1330,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        REST_STATE_EXPERIENCE = 1331,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        COINAGE = 1332,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_POS = 1333,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_POS_2 = 1334,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_POS_3 = 1335,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_POS_4 = 1336,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_POS_5 = 1337,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_POS_6 = 1338,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_POS_7 = 1339,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_NEG = 1340,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_NEG_2 = 1341,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_NEG_3 = 1342,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_NEG_4 = 1343,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_NEG_5 = 1344,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_NEG_6 = 1345,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_NEG_7 = 1346,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_PCT = 1347,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_PCT_2 = 1348,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_PCT_3 = 1349,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_PCT_4 = 1350,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_PCT_5 = 1351,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_PCT_6 = 1352,
        /// <summary>
        /// Size: 7 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_DAMAGE_DONE_PCT_7 = 1353,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_HEALING_DONE_POS = 1354,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        MOD_TARGET_RESISTANCE = 1355,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Private
        /// </summary>
        BYTES_ = 1356,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        AMMO_ID = 1357,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        SELF_RES_SPELL = 1358,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        PVP_MEDALS = 1359,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1 = 1360,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_2 = 1361,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_3 = 1362,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_4 = 1363,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_5 = 1364,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_6 = 1365,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_7 = 1366,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_8 = 1367,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_9 = 1368,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_10 = 1369,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_11 = 1370,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_PRICE_1_12 = 1371,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1 = 1372,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_2 = 1373,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_3 = 1374,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_4 = 1375,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_5 = 1376,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_6 = 1377,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_7 = 1378,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_8 = 1379,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_9 = 1380,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_10 = 1381,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_11 = 1382,
        /// <summary>
        /// Size: 12 - Type: Int32 - Flags: Private
        /// </summary>
        BUYBACK_TIMESTAMP_1_12 = 1383,
        /// <summary>
        /// Size: 1 - Type: TwoInt16 - Flags: Private
        /// </summary>
        KILLS = 1384,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        TODAY_CONTRIBUTION = 1385,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        YESTERDAY_CONTRIBUTION = 1386,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        LIFETIME_HONORBALE_KILLS = 1387,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Private
        /// </summary>
        BYTES2 = 1388,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        WATCHED_FACTION_INDEX = 1389,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1 = 1390,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_2 = 1391,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_3 = 1392,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_4 = 1393,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_5 = 1394,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_6 = 1395,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_7 = 1396,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_8 = 1397,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_9 = 1398,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_10 = 1399,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_11 = 1400,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_12 = 1401,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_13 = 1402,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_14 = 1403,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_15 = 1404,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_16 = 1405,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_17 = 1406,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_18 = 1407,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_19 = 1408,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_20 = 1409,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_21 = 1410,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_22 = 1411,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_23 = 1412,
        /// <summary>
        /// Size: 24 - Type: Int32 - Flags: Private
        /// </summary>
        COMBAT_RATING_1_24 = 1413,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1 = 1414,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_2 = 1415,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_3 = 1416,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_4 = 1417,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_5 = 1418,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_6 = 1419,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_7 = 1420,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_8 = 1421,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_9 = 1422,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_10 = 1423,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_11 = 1424,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_12 = 1425,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_13 = 1426,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_14 = 1427,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_15 = 1428,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_16 = 1429,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_17 = 1430,
        /// <summary>
        /// Size: 18 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_TEAM_INFO_1_1_18 = 1431,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        HONOR_CURRENCY = 1432,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        ARENA_CURRENCY = 1433,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private
        /// </summary>
        MOD_MANA_REGEN = 1434,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Private
        /// </summary>
        MOD_MANA_REGEN_INTERRUPT = 1435,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Private
        /// </summary>
        MAX_LEVEL = 1436,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1 = 1437,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1_2 = 1438,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1_3 = 1439,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1_4 = 1440,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1_5 = 1441,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1_6 = 1442,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1_7 = 1443,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1_8 = 1444,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1_9 = 1445,
        /// <summary>
        /// Size: 10 - Type: Int32 - Flags: Private
        /// </summary>
        DAILY_QUESTS_1_10 = 1446,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: None
        /// </summary>
        PADDING = 1447,
    }
    #endregion

    #region zh-CHS GameObjectFields枚举 | en GameObjectFields Enum
    /// <summary>
    /// 
    /// </summary>
    public enum GameObjectFields
    {
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CREATED_BY = 6,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CREATED_BY_2 = 7,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        DISPLAYID = 8,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        FLAGS = 9,
        /// <summary>
        /// Size: 4 - Type: Float - Flags: Public
        /// </summary>
        ROTATION = 10,
        /// <summary>
        /// Size: 4 - Type: Float - Flags: Public
        /// </summary>
        ROTATION_2 = 11,
        /// <summary>
        /// Size: 4 - Type: Float - Flags: Public
        /// </summary>
        ROTATION_3 = 12,
        /// <summary>
        /// Size: 4 - Type: Float - Flags: Public
        /// </summary>
        ROTATION_4 = 13,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        STATE = 14,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        POS_X = 15,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        POS_Y = 16,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        POS_Z = 17,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        FACING = 18,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Dynamic
        /// </summary>
        DYN_FLAGS = 19,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        FACTION = 20,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        TYPE_ID = 21,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        LEVEL = 22,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        ARTKIT = 23,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Dynamic
        /// </summary>
        ANIMPROGRESS = 24,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: None
        /// </summary>
        PADDING = 25,
    }
    #endregion

    #region zh-CHS DynamicObjectFields 枚举 | en DynamicObjectFields Enum
    /// <summary>
    /// 
    /// </summary>
    public enum DynamicObjectFields
    {
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CASTER = 6,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        CASTER_2 = 7,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        BYTES = 8,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        SPELLID = 9,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        RADIUS = 10,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        POS_X = 11,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        POS_Y = 12,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        POS_Z = 13,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        FACING = 14,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        PAD = 15,
    }
    #endregion

    #region zh-CHS CorpseFields枚举 | en CorpseFields Enum
    /// <summary>
    /// 
    /// </summary>
    public enum CorpseFields
    {
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        OWNER = 6,
        /// <summary>
        /// Size: 2 - Type: GUID - Flags: Public
        /// </summary>
        OWNER_2 = 7,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        FACING = 8,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        POS_X = 9,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        POS_Y = 10,
        /// <summary>
        /// Size: 1 - Type: Float - Flags: Public
        /// </summary>
        POS_Z = 11,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        DISPLAY_ID = 12,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM = 13,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_2 = 14,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_3 = 15,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_4 = 16,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_5 = 17,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_6 = 18,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_7 = 19,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_8 = 20,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_9 = 21,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_10 = 22,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_11 = 23,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_12 = 24,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_13 = 25,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_14 = 26,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_15 = 27,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_16 = 28,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_17 = 29,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_18 = 30,
        /// <summary>
        /// Size: 19 - Type: Int32 - Flags: Public
        /// </summary>
        ITEM_19 = 31,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        BYTES_1 = 32,
        /// <summary>
        /// Size: 1 - Type: Bytes - Flags: Public
        /// </summary>
        BYTES_2 = 33,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        GUILD = 34,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Public
        /// </summary>
        FLAGS = 35,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: Dynamic
        /// </summary>
        DYNAMIC_FLAGS = 36,
        /// <summary>
        /// Size: 1 - Type: Int32 - Flags: None
        /// </summary>
        PAD = 37,
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum FieldFlag
    {
        None = 0,
        /// <summary>
        /// Fields with this flag are to be known by all surrounding players
        /// </summary>
        Public = 0x1,
        /// <summary>
        /// Fields with this flag are only meant to be known by the player itself
        /// </summary>
        Private = 0x2,
        /// <summary>
        /// Fields with this flag are to be known by the owner, in the case of pets and a few item fields
        /// </summary>
        OnlyForOwner = 0x4,
        /// <summary>
        /// Unused
        /// </summary>
        Flag_0x8_Unused = 0x8,
        /// <summary>
        /// ITEMSTACK_COUNT
        /// ITEMDURATION
        /// ITEMSPELL_CHARGES
        /// ITEMDURABILITY
        /// ITEMMAXDURABILITY
        /// </summary>
        Flag_0x10 = 0x10,
        /// <summary>
        /// _MINDAMAGE
        /// _MAXDAMAGE
        /// _MINOFFHANDDAMAGE
        /// _MAXOFFHANDDAMAGE
        /// _RESISTANCES
        /// </summary>
        Flag_0x20 = 0x20,
        /// <summary>
        /// Fields with this flag are only to be known by party members
        /// </summary>
        GroupOnly = 0x40,
        /// <summary>
        /// Unused
        /// </summary>
        Flag_0x80_Unused = 0x80,
        /// <summary>
        /// _HEALTH - Flag0x0100
        /// _MAXHEALTH - Flag0x0100
        /// UNIT_DYNAMIC_FLAGS - Flag0x0100
        /// DYN_FLAGS - Flag0x0100
        /// ANIMPROGRESS - Flag0x0100
        /// DYNAMIC_FLAGS - Flag0x0100
        /// Differs from player to player
        /// In the case of health, it sends percents to everyone not in your party instead of the acutal value
        /// </summary>
        Dynamic = 0x100,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum UpdateFieldType
    {
        None = 0,
        UInt32 = 1,
        TwoInt16 = 2,
        Float = 3,
        GUID = 4,
        ByteArray = 5,
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateField
	{
        #region zh-CHS 共有常量 | en Public Constants
        /// <summary>
        /// 
        /// </summary>
		public readonly static int ObjectTypeCount = (int)ObjectTypeId.AIGroup;
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ObjectTypeId m_Group;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ObjectTypeId Group
        {
            get { return m_Group; }
            set { m_Group = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Offset;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Offset
        {
            get { return m_Offset; }
            set { m_Offset = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Size;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Size
        {
            get { return m_Size; }
            set { m_Size = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UpdateFieldType m_Type;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UpdateFieldType Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private FieldFlag m_Flags;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public FieldFlag Flags
        {
            get { return m_Flags; }
            set { m_Flags = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Name;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsPublic;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsPublic
        {
            get { return m_IsPublic; }
            set { m_IsPublic = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public string FullName
		{
			get { return m_Group + "Fields." + m_Name; }
		}

        /// <summary>
        /// 
        /// </summary>
		public string FullTypeName
		{
			get { return "UpdateFieldType." + m_Type; }
        }

        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public override string ToString()
		{
			return this.FullName + string.Format(" (Offset: {0}, Size: {1}, Type: {2}, Flags: {3})", m_Offset, m_Size, m_Type, m_Flags);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
		public override bool Equals(object xObject)
		{
            UpdateField updateField = xObject as UpdateField;
            if ( updateField == null )
                return false;

            return updateField.m_Group == m_Group && updateField.m_Offset == m_Offset;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public override int GetHashCode()
		{
			return (int)m_Group | ((int)m_Offset << 3);	// guaranteed to be unique
		}

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public static class UpdateFields
    {
        /// <summary>
        /// 
        /// </summary>
        internal static readonly UpdateField[][] AllFields = new UpdateField[][]
        {
            #region Object Field
			// Object
			new UpdateField[]{

				// ObjectFields.GUID
				new UpdateField {
					Offset = 0,
					Size = 2,
					Name = "GUID",
					Flags = FieldFlag.Public,
					Type = UpdateFieldType.GUID,
					Group = ObjectTypeId.Object,
				},

 				// ObjectFields.GUID_2
               null,

				// ObjectFields.TYPE
				new UpdateField {
					Offset = 2,
					Size = 1,
					Name = "TYPE",
					Flags = FieldFlag.Public,
					Type = UpdateFieldType.UInt32,
					Group = ObjectTypeId.Object,
				},

				// ObjectFields.ENTRY
				new UpdateField {
					Offset = 3,
					Size = 1,
					Name = "ENTRY",
					Flags = FieldFlag.Public,
					Type = UpdateFieldType.UInt32,
					Group = ObjectTypeId.Object,
				},

				// ObjectFields.SCALE_X
				new UpdateField {
					Offset = 4,
					Size = 1,
					Name = "SCALE_X",
					Flags = FieldFlag.Public,
					Type = UpdateFieldType.Float,
					Group = ObjectTypeId.Object,
				},

				// ObjectFields.PADDING
				new UpdateField {
					Offset = 5,
					Size = 1,
					Name = "PADDING",
					Flags = FieldFlag.None,
					Type = UpdateFieldType.UInt32,
					Group = ObjectTypeId.Object,
				},
			},
	        #endregion

            #region Item Field
            // Item
			new UpdateField[]{
				null,
				null,
				null,
				null,
				null,
				null,
				// ItemFields.OWNER
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Item,
					Name = "OWNER",
					Offset = 6,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// ItemFields.CONTAINED
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Item,
					Name = "CONTAINED",
					Offset = 8,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// ItemFields.CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Item,
					Name = "CREATOR",
					Offset = 10,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// ItemFields.GIFTCREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Item,
					Name = "GIFTCREATOR",
					Offset = 12,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// ItemFields.STACK_COUNT
				new UpdateField {
					Flags = FieldFlag.OnlyForOwner | FieldFlag.Flag_0x10,
					Group = ObjectTypeId.Item,
					Name = "STACK_COUNT",
					Offset = 14,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// ItemFields.DURATION
				new UpdateField {
					Flags = FieldFlag.OnlyForOwner | FieldFlag.Flag_0x10,
					Group = ObjectTypeId.Item,
					Name = "DURATION",
					Offset = 15,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// ItemFields.SPELL_CHARGES
				new UpdateField {
					Flags = FieldFlag.OnlyForOwner | FieldFlag.Flag_0x10,
					Group = ObjectTypeId.Item,
					Name = "SPELL_CHARGES",
					Offset = 16,
					Size = 5,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				// ItemFields.FLAGS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Item,
					Name = "FLAGS",
					Offset = 21,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// ItemFields.ENCHANTMENT
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Item,
					Name = "ENCHANTMENT",
					Offset = 22,
					Size = 33,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// ItemFields.PROPERTY_SEED
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Item,
					Name = "PROPERTY_SEED",
					Offset = 55,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// ItemFields.RANDOM_PROPERTIES_ID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Item,
					Name = "RANDOM_PROPERTIES_ID",
					Offset = 56,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// ItemFields.ITEM_TEXT_ID
				new UpdateField {
					Flags = FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Item,
					Name = "ITEM_TEXT_ID",
					Offset = 57,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// ItemFields.DURABILITY
				new UpdateField {
					Flags = FieldFlag.OnlyForOwner | FieldFlag.Flag_0x10,
					Group = ObjectTypeId.Item,
					Name = "DURABILITY",
					Offset = 58,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// ItemFields.MAXDURABILITY
				new UpdateField {
					Flags = FieldFlag.OnlyForOwner | FieldFlag.Flag_0x10,
					Group = ObjectTypeId.Item,
					Name = "MAXDURABILITY",
					Offset = 59,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
			},
            #endregion

            #region Container Field
            // Container
			new UpdateField[]{
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// ContainerFields.NUM_SLOTS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Container,
					Name = "NUM_SLOTS",
					Offset = 60,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// ContainerFields.ALIGN_PAD
				new UpdateField {
					Flags = FieldFlag.None,
					Group = ObjectTypeId.Container,
					Name = "ALIGN_PAD",
					Offset = 61,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// ContainerFields.SLOT_1
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Container,
					Name = "SLOT_1",
					Offset = 62,
					Size = 72,
					Type = UpdateFieldType.GUID
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
			},
	        #endregion

            #region Unit Field
            // Unit
			new UpdateField[]{
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.CHARM
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "CHARM",
					Offset = 6,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// UnitFields.SUMMON
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "SUMMON",
					Offset = 8,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// UnitFields.CHARMEDBY
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "CHARMEDBY",
					Offset = 10,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// UnitFields.SUMMONEDBY
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "SUMMONEDBY",
					Offset = 12,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// UnitFields.CREATEDBY
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "CREATEDBY",
					Offset = 14,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// UnitFields.TARGET
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "TARGET",
					Offset = 16,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// UnitFields.PERSUADED
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "PERSUADED",
					Offset = 18,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// UnitFields.CHANNEL_OBJECT
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "CHANNEL_OBJECT",
					Offset = 20,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// UnitFields.HEALTH
				new UpdateField {
					Flags = FieldFlag.Dynamic,
					Group = ObjectTypeId.Unit,
					Name = "HEALTH",
					Offset = 22,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POWER1
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "POWER1",
					Offset = 23,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POWER2
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "POWER2",
					Offset = 24,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POWER3
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "POWER3",
					Offset = 25,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POWER4
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "POWER4",
					Offset = 26,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POWER5
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "POWER5",
					Offset = 27,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.MAXHEALTH
				new UpdateField {
					Flags = FieldFlag.Dynamic,
					Group = ObjectTypeId.Unit,
					Name = "MAXHEALTH",
					Offset = 28,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.MAXPOWER1
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "MAXPOWER1",
					Offset = 29,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.MAXPOWER2
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "MAXPOWER2",
					Offset = 30,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.MAXPOWER3
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "MAXPOWER3",
					Offset = 31,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.MAXPOWER4
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "MAXPOWER4",
					Offset = 32,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.MAXPOWER5
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "MAXPOWER5",
					Offset = 33,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.LEVEL
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "LEVEL",
					Offset = 34,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.FACTIONTEMPLATE
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "FACTIONTEMPLATE",
					Offset = 35,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.BYTES_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "BYTES_0",
					Offset = 36,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// UnitFields.VIRTUAL_ITEM_SLOT_DISPLAY
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "VIRTUAL_ITEM_SLOT_DISPLAY",
					Offset = 37,
					Size = 3,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				// UnitFields.VIRTUAL_ITEM_INFO
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "VIRTUAL_ITEM_INFO",
					Offset = 40,
					Size = 6,
					Type = UpdateFieldType.ByteArray
				},
				null,
				null,
				null,
				null,
				null,
				// UnitFields.FLAGS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "FLAGS",
					Offset = 46,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.FLAGS_2
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "FLAGS_2",
					Offset = 47,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.AURA
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "AURA",
					Offset = 48,
					Size = 56,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.AURAFLAGS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "AURAFLAGS",
					Offset = 104,
					Size = 14,
					Type = UpdateFieldType.ByteArray
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.AURALEVELS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "AURALEVELS",
					Offset = 118,
					Size = 14,
					Type = UpdateFieldType.ByteArray
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.AURAAPPLICATIONS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "AURAAPPLICATIONS",
					Offset = 132,
					Size = 14,
					Type = UpdateFieldType.ByteArray
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.AURASTATE
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "AURASTATE",
					Offset = 146,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.BASEATTACKTIME
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "BASEATTACKTIME",
					Offset = 147,
					Size = 2,
					Type = UpdateFieldType.UInt32
				},
				null,
				// UnitFields.RANGEDATTACKTIME
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Unit,
					Name = "RANGEDATTACKTIME",
					Offset = 149,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.BOUNDINGRADIUS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "BOUNDINGRADIUS",
					Offset = 150,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.COMBATREACH
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "COMBATREACH",
					Offset = 151,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.DISPLAYID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "DISPLAYID",
					Offset = 152,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.NATIVEDISPLAYID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "NATIVEDISPLAYID",
					Offset = 153,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.MOUNTDISPLAYID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "MOUNTDISPLAYID",
					Offset = 154,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.MINDAMAGE
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner | FieldFlag.Flag_0x20,
					Group = ObjectTypeId.Unit,
					Name = "MINDAMAGE",
					Offset = 155,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.MAXDAMAGE
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner | FieldFlag.Flag_0x20,
					Group = ObjectTypeId.Unit,
					Name = "MAXDAMAGE",
					Offset = 156,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.MINOFFHANDDAMAGE
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner | FieldFlag.Flag_0x20,
					Group = ObjectTypeId.Unit,
					Name = "MINOFFHANDDAMAGE",
					Offset = 157,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.MAXOFFHANDDAMAGE
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner | FieldFlag.Flag_0x20,
					Group = ObjectTypeId.Unit,
					Name = "MAXOFFHANDDAMAGE",
					Offset = 158,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.BYTES_1
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "BYTES_1",
					Offset = 159,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// UnitFields.PETNUMBER
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "PETNUMBER",
					Offset = 160,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.PET_NAME_TIMESTAMP
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "PET_NAME_TIMESTAMP",
					Offset = 161,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.PETEXPERIENCE
				new UpdateField {
					Flags = FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "PETEXPERIENCE",
					Offset = 162,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.PETNEXTLEVELEXP
				new UpdateField {
					Flags = FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "PETNEXTLEVELEXP",
					Offset = 163,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.DYNAMIC_FLAGS
				new UpdateField {
					Flags = FieldFlag.Dynamic,
					Group = ObjectTypeId.Unit,
					Name = "DYNAMIC_FLAGS",
					Offset = 164,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.CHANNEL_SPELL
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "CHANNEL_SPELL",
					Offset = 165,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.MOD_CAST_SPEED
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "MOD_CAST_SPEED",
					Offset = 166,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.CREATED_BY_SPELL
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "CREATED_BY_SPELL",
					Offset = 167,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.NPC_FLAGS
				new UpdateField {
					Flags = FieldFlag.Dynamic,
					Group = ObjectTypeId.Unit,
					Name = "NPC_FLAGS",
					Offset = 168,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.NPC_EMOTESTATE
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "NPC_EMOTESTATE",
					Offset = 169,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.TRAINING_POINTS
				new UpdateField {
					Flags = FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "TRAINING_POINTS",
					Offset = 170,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// UnitFields.STAT0
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "STAT0",
					Offset = 171,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.STAT1
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "STAT1",
					Offset = 172,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.STAT2
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "STAT2",
					Offset = 173,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.STAT3
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "STAT3",
					Offset = 174,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.STAT4
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "STAT4",
					Offset = 175,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POSSTAT0
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "POSSTAT0",
					Offset = 176,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POSSTAT1
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "POSSTAT1",
					Offset = 177,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POSSTAT2
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "POSSTAT2",
					Offset = 178,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POSSTAT3
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "POSSTAT3",
					Offset = 179,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.POSSTAT4
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "POSSTAT4",
					Offset = 180,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.NEGSTAT0
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "NEGSTAT0",
					Offset = 181,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.NEGSTAT1
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "NEGSTAT1",
					Offset = 182,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.NEGSTAT2
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "NEGSTAT2",
					Offset = 183,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.NEGSTAT3
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "NEGSTAT3",
					Offset = 184,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.NEGSTAT4
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "NEGSTAT4",
					Offset = 185,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.RESISTANCES
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner | FieldFlag.Flag_0x20,
					Group = ObjectTypeId.Unit,
					Name = "RESISTANCES",
					Offset = 186,
					Size = 7,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.RESISTANCEBUFFMODSPOSITIVE
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "RESISTANCEBUFFMODSPOSITIVE",
					Offset = 193,
					Size = 7,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.RESISTANCEBUFFMODSNEGATIVE
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "RESISTANCEBUFFMODSNEGATIVE",
					Offset = 200,
					Size = 7,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.BASE_MANA
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "BASE_MANA",
					Offset = 207,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.BASE_HEALTH
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "BASE_HEALTH",
					Offset = 208,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.BYTES_2
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Unit,
					Name = "BYTES_2",
					Offset = 209,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// UnitFields.ATTACK_POWER
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "ATTACK_POWER",
					Offset = 210,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.ATTACK_POWER_MODS
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "ATTACK_POWER_MODS",
					Offset = 211,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// UnitFields.ATTACK_POWER_MULTIPLIER
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "ATTACK_POWER_MULTIPLIER",
					Offset = 212,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.RANGED_ATTACK_POWER
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "RANGED_ATTACK_POWER",
					Offset = 213,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// UnitFields.RANGED_ATTACK_POWER_MODS
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "RANGED_ATTACK_POWER_MODS",
					Offset = 214,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// UnitFields.RANGED_ATTACK_POWER_MULTIPLIER
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "RANGED_ATTACK_POWER_MULTIPLIER",
					Offset = 215,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.MINRANGEDDAMAGE
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "MINRANGEDDAMAGE",
					Offset = 216,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.MAXRANGEDDAMAGE
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "MAXRANGEDDAMAGE",
					Offset = 217,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.POWER_COST_MODIFIER
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "POWER_COST_MODIFIER",
					Offset = 218,
					Size = 7,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.POWER_COST_MULTIPLIER
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "POWER_COST_MULTIPLIER",
					Offset = 225,
					Size = 7,
					Type = UpdateFieldType.Float
				},
				null,
				null,
				null,
				null,
				null,
				null,
				// UnitFields.MAXHEALTHMODIFIER
				new UpdateField {
					Flags = FieldFlag.Private | FieldFlag.OnlyForOwner,
					Group = ObjectTypeId.Unit,
					Name = "MAXHEALTHMODIFIER",
					Offset = 232,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// UnitFields.PADDING
				new UpdateField {
					Flags = FieldFlag.None,
					Group = ObjectTypeId.Unit,
					Name = "PADDING",
					Offset = 233,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
			},
            #endregion

            #region Player Field
            // Player
			new UpdateField[]{
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.DUEL_ARBITER
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "DUEL_ARBITER",
					Offset = 234,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.FLAGS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "FLAGS",
					Offset = 236,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.GUILDID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "GUILDID",
					Offset = 237,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.GUILDRANK
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "GUILDRANK",
					Offset = 238,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.BYTES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "BYTES",
					Offset = 239,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.BYTES_2
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "BYTES_2",
					Offset = 240,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.BYTES_3
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "BYTES_3",
					Offset = 241,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.DUEL_TEAM
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "DUEL_TEAM",
					Offset = 242,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.GUILD_TIMESTAMP
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "GUILD_TIMESTAMP",
					Offset = 243,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_1_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_1_1",
					Offset = 244,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_1_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_1_2",
					Offset = 245,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_1_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_1_3",
					Offset = 246,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_1_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_1_4",
					Offset = 247,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_2_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_2_1",
					Offset = 248,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_2_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_2_2",
					Offset = 249,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_2_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_2_3",
					Offset = 250,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_2_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_2_4",
					Offset = 251,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_3_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_3_1",
					Offset = 252,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_3_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_3_2",
					Offset = 253,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_3_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_3_3",
					Offset = 254,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_3_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_3_4",
					Offset = 255,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_4_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_4_1",
					Offset = 256,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_4_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_4_2",
					Offset = 257,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_4_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_4_3",
					Offset = 258,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_4_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_4_4",
					Offset = 259,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_5_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_5_1",
					Offset = 260,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_5_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_5_2",
					Offset = 261,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_5_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_5_3",
					Offset = 262,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_5_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_5_4",
					Offset = 263,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_6_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_6_1",
					Offset = 264,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_6_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_6_2",
					Offset = 265,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_6_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_6_3",
					Offset = 266,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_6_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_6_4",
					Offset = 267,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_7_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_7_1",
					Offset = 268,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_7_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_7_2",
					Offset = 269,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_7_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_7_3",
					Offset = 270,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_7_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_7_4",
					Offset = 271,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_8_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_8_1",
					Offset = 272,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_8_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_8_2",
					Offset = 273,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_8_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_8_3",
					Offset = 274,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_8_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_8_4",
					Offset = 275,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_9_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_9_1",
					Offset = 276,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_9_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_9_2",
					Offset = 277,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_9_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_9_3",
					Offset = 278,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_9_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_9_4",
					Offset = 279,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_10_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_10_1",
					Offset = 280,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_10_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_10_2",
					Offset = 281,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_10_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_10_3",
					Offset = 282,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_10_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_10_4",
					Offset = 283,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_11_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_11_1",
					Offset = 284,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_11_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_11_2",
					Offset = 285,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_11_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_11_3",
					Offset = 286,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_11_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_11_4",
					Offset = 287,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_12_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_12_1",
					Offset = 288,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_12_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_12_2",
					Offset = 289,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_12_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_12_3",
					Offset = 290,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_12_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_12_4",
					Offset = 291,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_13_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_13_1",
					Offset = 292,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_13_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_13_2",
					Offset = 293,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_13_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_13_3",
					Offset = 294,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_13_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_13_4",
					Offset = 295,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_14_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_14_1",
					Offset = 296,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_14_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_14_2",
					Offset = 297,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_14_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_14_3",
					Offset = 298,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_14_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_14_4",
					Offset = 299,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_15_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_15_1",
					Offset = 300,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_15_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_15_2",
					Offset = 301,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_15_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_15_3",
					Offset = 302,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_15_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_15_4",
					Offset = 303,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_16_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_16_1",
					Offset = 304,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_16_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_16_2",
					Offset = 305,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_16_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_16_3",
					Offset = 306,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_16_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_16_4",
					Offset = 307,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_17_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_17_1",
					Offset = 308,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_17_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_17_2",
					Offset = 309,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_17_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_17_3",
					Offset = 310,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_17_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_17_4",
					Offset = 311,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_18_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_18_1",
					Offset = 312,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_18_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_18_2",
					Offset = 313,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_18_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_18_3",
					Offset = 314,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_18_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_18_4",
					Offset = 315,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_19_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_19_1",
					Offset = 316,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_19_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_19_2",
					Offset = 317,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_19_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_19_3",
					Offset = 318,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_19_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_19_4",
					Offset = 319,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_20_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_20_1",
					Offset = 320,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_20_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_20_2",
					Offset = 321,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_20_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_20_3",
					Offset = 322,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_20_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_20_4",
					Offset = 323,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_21_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_21_1",
					Offset = 324,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_21_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_21_2",
					Offset = 325,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_21_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_21_3",
					Offset = 326,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_21_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_21_4",
					Offset = 327,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_22_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_22_1",
					Offset = 328,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_22_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_22_2",
					Offset = 329,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_22_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_22_3",
					Offset = 330,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_22_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_22_4",
					Offset = 331,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_23_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_23_1",
					Offset = 332,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_23_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_23_2",
					Offset = 333,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_23_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_23_3",
					Offset = 334,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_23_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_23_4",
					Offset = 335,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_24_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_24_1",
					Offset = 336,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_24_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_24_2",
					Offset = 337,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_24_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_24_3",
					Offset = 338,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_24_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_24_4",
					Offset = 339,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_25_1
				new UpdateField {
					Flags = FieldFlag.GroupOnly,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_25_1",
					Offset = 340,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_25_2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_25_2",
					Offset = 341,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.QUEST_LOG_25_3
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_25_3",
					Offset = 342,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.QUEST_LOG_25_4
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "QUEST_LOG_25_4",
					Offset = 343,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_1_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_1_CREATOR",
					Offset = 344,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_1_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_1_0",
					Offset = 346,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_1_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_1_PROPERTIES",
					Offset = 358,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_1_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_1_PAD",
					Offset = 359,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_2_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_2_CREATOR",
					Offset = 360,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_2_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_2_0",
					Offset = 362,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_2_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_2_PROPERTIES",
					Offset = 374,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_2_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_2_PAD",
					Offset = 375,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_3_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_3_CREATOR",
					Offset = 376,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_3_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_3_0",
					Offset = 378,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_3_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_3_PROPERTIES",
					Offset = 390,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_3_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_3_PAD",
					Offset = 391,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_4_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_4_CREATOR",
					Offset = 392,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_4_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_4_0",
					Offset = 394,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_4_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_4_PROPERTIES",
					Offset = 406,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_4_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_4_PAD",
					Offset = 407,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_5_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_5_CREATOR",
					Offset = 408,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_5_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_5_0",
					Offset = 410,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_5_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_5_PROPERTIES",
					Offset = 422,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_5_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_5_PAD",
					Offset = 423,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_6_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_6_CREATOR",
					Offset = 424,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_6_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_6_0",
					Offset = 426,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_6_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_6_PROPERTIES",
					Offset = 438,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_6_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_6_PAD",
					Offset = 439,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_7_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_7_CREATOR",
					Offset = 440,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_7_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_7_0",
					Offset = 442,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_7_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_7_PROPERTIES",
					Offset = 454,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_7_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_7_PAD",
					Offset = 455,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_8_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_8_CREATOR",
					Offset = 456,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_8_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_8_0",
					Offset = 458,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_8_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_8_PROPERTIES",
					Offset = 470,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_8_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_8_PAD",
					Offset = 471,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_9_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_9_CREATOR",
					Offset = 472,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_9_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_9_0",
					Offset = 474,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_9_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_9_PROPERTIES",
					Offset = 486,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_9_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_9_PAD",
					Offset = 487,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_10_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_10_CREATOR",
					Offset = 488,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_10_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_10_0",
					Offset = 490,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_10_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_10_PROPERTIES",
					Offset = 502,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_10_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_10_PAD",
					Offset = 503,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_11_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_11_CREATOR",
					Offset = 504,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_11_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_11_0",
					Offset = 506,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_11_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_11_PROPERTIES",
					Offset = 518,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_11_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_11_PAD",
					Offset = 519,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_12_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_12_CREATOR",
					Offset = 520,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_12_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_12_0",
					Offset = 522,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_12_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_12_PROPERTIES",
					Offset = 534,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_12_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_12_PAD",
					Offset = 535,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_13_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_13_CREATOR",
					Offset = 536,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_13_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_13_0",
					Offset = 538,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_13_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_13_PROPERTIES",
					Offset = 550,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_13_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_13_PAD",
					Offset = 551,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_14_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_14_CREATOR",
					Offset = 552,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_14_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_14_0",
					Offset = 554,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_14_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_14_PROPERTIES",
					Offset = 566,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_14_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_14_PAD",
					Offset = 567,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_15_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_15_CREATOR",
					Offset = 568,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_15_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_15_0",
					Offset = 570,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_15_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_15_PROPERTIES",
					Offset = 582,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_15_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_15_PAD",
					Offset = 583,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_16_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_16_CREATOR",
					Offset = 584,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_16_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_16_0",
					Offset = 586,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_16_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_16_PROPERTIES",
					Offset = 598,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_16_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_16_PAD",
					Offset = 599,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_17_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_17_CREATOR",
					Offset = 600,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_17_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_17_0",
					Offset = 602,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_17_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_17_PROPERTIES",
					Offset = 614,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_17_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_17_PAD",
					Offset = 615,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_18_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_18_CREATOR",
					Offset = 616,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_18_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_18_0",
					Offset = 618,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_18_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_18_PROPERTIES",
					Offset = 630,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_18_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_18_PAD",
					Offset = 631,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.VISIBLE_ITEM_19_CREATOR
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_19_CREATOR",
					Offset = 632,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.VISIBLE_ITEM_19_0
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_19_0",
					Offset = 634,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VISIBLE_ITEM_19_PROPERTIES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_19_PROPERTIES",
					Offset = 646,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.VISIBLE_ITEM_19_PAD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "VISIBLE_ITEM_19_PAD",
					Offset = 647,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.CHOSEN_TITLE
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Player,
					Name = "CHOSEN_TITLE",
					Offset = 648,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.PAD_0
				new UpdateField {
					Flags = FieldFlag.None,
					Group = ObjectTypeId.Player,
					Name = "PAD_0",
					Offset = 649,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.INV_SLOT_HEAD
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "INV_SLOT_HEAD",
					Offset = 650,
					Size = 46,
					Type = UpdateFieldType.GUID
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.PACK_SLOT_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "PACK_SLOT_1",
					Offset = 696,
					Size = 32,
					Type = UpdateFieldType.GUID
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.BANK_SLOT_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "BANK_SLOT_1",
					Offset = 728,
					Size = 56,
					Type = UpdateFieldType.GUID
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.BANKBAG_SLOT_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "BANKBAG_SLOT_1",
					Offset = 784,
					Size = 14,
					Type = UpdateFieldType.GUID
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VENDORBUYBACK_SLOT_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "VENDORBUYBACK_SLOT_1",
					Offset = 798,
					Size = 24,
					Type = UpdateFieldType.GUID
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.KEYRING_SLOT_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "KEYRING_SLOT_1",
					Offset = 822,
					Size = 64,
					Type = UpdateFieldType.GUID
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.VANITYPET_SLOT_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "VANITYPET_SLOT_1",
					Offset = 886,
					Size = 36,
					Type = UpdateFieldType.GUID
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.FARSIGHT
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "FARSIGHT",
					Offset = 922,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields._FIELD_KNOWN_TITLES
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "_FIELD_KNOWN_TITLES",
					Offset = 924,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// PlayerFields.XP
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "XP",
					Offset = 926,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.NEXT_LEVEL_XP
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "NEXT_LEVEL_XP",
					Offset = 927,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.SKILL_INFO_1_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "SKILL_INFO_1_1",
					Offset = 928,
					Size = 384,
					Type = UpdateFieldType.TwoInt16
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.CHARACTER_POINTS1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "CHARACTER_POINTS1",
					Offset = 1312,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.CHARACTER_POINTS2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "CHARACTER_POINTS2",
					Offset = 1313,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.TRACK_CREATURES
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "TRACK_CREATURES",
					Offset = 1314,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.TRACK_RESOURCES
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "TRACK_RESOURCES",
					Offset = 1315,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.BLOCK_PERCENTAGE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "BLOCK_PERCENTAGE",
					Offset = 1316,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// PlayerFields.DODGE_PERCENTAGE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "DODGE_PERCENTAGE",
					Offset = 1317,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// PlayerFields.PARRY_PERCENTAGE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "PARRY_PERCENTAGE",
					Offset = 1318,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// PlayerFields.EXPERTISE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "EXPERTISE",
					Offset = 1319,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.OFFHAND_EXPERTISE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "OFFHAND_EXPERTISE",
					Offset = 1320,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.CRIT_PERCENTAGE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "CRIT_PERCENTAGE",
					Offset = 1321,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// PlayerFields.RANGED_CRIT_PERCENTAGE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "RANGED_CRIT_PERCENTAGE",
					Offset = 1322,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// PlayerFields.OFFHAND_CRIT_PERCENTAGE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "OFFHAND_CRIT_PERCENTAGE",
					Offset = 1323,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// PlayerFields.SPELL_CRIT_PERCENTAGE1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "SPELL_CRIT_PERCENTAGE1",
					Offset = 1324,
					Size = 7,
					Type = UpdateFieldType.Float
				},
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.SHIELD_BLOCK
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "SHIELD_BLOCK",
					Offset = 1331,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.EXPLORED_ZONES_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "EXPLORED_ZONES_1",
					Offset = 1332,
					Size = 64,
					Type = UpdateFieldType.ByteArray
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.REST_STATE_EXPERIENCE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "REST_STATE_EXPERIENCE",
					Offset = 1396,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.COINAGE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "COINAGE",
					Offset = 1397,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.MOD_DAMAGE_DONE_POS
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "MOD_DAMAGE_DONE_POS",
					Offset = 1398,
					Size = 7,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.MOD_DAMAGE_DONE_NEG
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "MOD_DAMAGE_DONE_NEG",
					Offset = 1405,
					Size = 7,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.MOD_DAMAGE_DONE_PCT
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "MOD_DAMAGE_DONE_PCT",
					Offset = 1412,
					Size = 7,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.MOD_HEALING_DONE_POS
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "MOD_HEALING_DONE_POS",
					Offset = 1419,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.MOD_TARGET_RESISTANCE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "MOD_TARGET_RESISTANCE",
					Offset = 1420,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.MOD_TARGET_PHYSICAL_RESISTANCE
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "MOD_TARGET_PHYSICAL_RESISTANCE",
					Offset = 1421,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.BYTES
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "BYTES",
					Offset = 1422,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.AMMO_ID
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "AMMO_ID",
					Offset = 1423,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.SELF_RES_SPELL
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "SELF_RES_SPELL",
					Offset = 1424,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.PVP_MEDALS
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "PVP_MEDALS",
					Offset = 1425,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.BUYBACK_PRICE_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "BUYBACK_PRICE_1",
					Offset = 1426,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.BUYBACK_TIMESTAMP_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "BUYBACK_TIMESTAMP_1",
					Offset = 1438,
					Size = 12,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.KILLS
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "KILLS",
					Offset = 1450,
					Size = 1,
					Type = UpdateFieldType.TwoInt16
				},
				// PlayerFields.TODAY_CONTRIBUTION
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "TODAY_CONTRIBUTION",
					Offset = 1451,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.YESTERDAY_CONTRIBUTION
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "YESTERDAY_CONTRIBUTION",
					Offset = 1452,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.LIFETIME_HONORBALE_KILLS
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "LIFETIME_HONORBALE_KILLS",
					Offset = 1453,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.BYTES2
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "BYTES2",
					Offset = 1454,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// PlayerFields.WATCHED_FACTION_INDEX
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "WATCHED_FACTION_INDEX",
					Offset = 1455,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.COMBAT_RATING_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "COMBAT_RATING_1",
					Offset = 1456,
					Size = 24,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.ARENA_TEAM_INFO_1_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "ARENA_TEAM_INFO_1_1",
					Offset = 1480,
					Size = 18,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// PlayerFields.HONOR_CURRENCY
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "HONOR_CURRENCY",
					Offset = 1498,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.ARENA_CURRENCY
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "ARENA_CURRENCY",
					Offset = 1499,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.MOD_MANA_REGEN
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "MOD_MANA_REGEN",
					Offset = 1500,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// PlayerFields.MOD_MANA_REGEN_INTERRUPT
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "MOD_MANA_REGEN_INTERRUPT",
					Offset = 1501,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// PlayerFields.MAX_LEVEL
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "MAX_LEVEL",
					Offset = 1502,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// PlayerFields.DAILY_QUESTS_1
				new UpdateField {
					Flags = FieldFlag.Private,
					Group = ObjectTypeId.Player,
					Name = "DAILY_QUESTS_1",
					Offset = 1503,
					Size = 25,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
			},
            #endregion

            #region GameObject Field
			// GameObject
			new UpdateField[]{
				null,
				null,
				null,
				null,
				null,
				null,
				// GameObjectFields.OBJECT_FIELD_CREATED_BY
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "OBJECT_FIELD_CREATED_BY",
					Offset = 6,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// GameObjectFields.DISPLAYID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "DISPLAYID",
					Offset = 8,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// GameObjectFields.FLAGS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "FLAGS",
					Offset = 9,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// GameObjectFields.ROTATION
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "ROTATION",
					Offset = 10,
					Size = 4,
					Type = UpdateFieldType.Float
				},
				null,
				null,
				null,
				// GameObjectFields.STATE
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "STATE",
					Offset = 14,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// GameObjectFields.POS_X
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "POS_X",
					Offset = 15,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// GameObjectFields.POS_Y
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "POS_Y",
					Offset = 16,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// GameObjectFields.POS_Z
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "POS_Z",
					Offset = 17,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// GameObjectFields.FACING
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "FACING",
					Offset = 18,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// GameObjectFields.DYN_FLAGS
				new UpdateField {
					Flags = FieldFlag.Dynamic,
					Group = ObjectTypeId.GameObject,
					Name = "DYN_FLAGS",
					Offset = 19,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// GameObjectFields.FACTION
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "FACTION",
					Offset = 20,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// GameObjectFields.TYPE_ID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "TYPE_ID",
					Offset = 21,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// GameObjectFields.LEVEL
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "LEVEL",
					Offset = 22,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// GameObjectFields.ARTKIT
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.GameObject,
					Name = "ARTKIT",
					Offset = 23,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// GameObjectFields.ANIMPROGRESS
				new UpdateField {
					Flags = FieldFlag.Dynamic,
					Group = ObjectTypeId.GameObject,
					Name = "ANIMPROGRESS",
					Offset = 24,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// GameObjectFields.PADDING
				new UpdateField {
					Flags = FieldFlag.None,
					Group = ObjectTypeId.GameObject,
					Name = "PADDING",
					Offset = 25,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
			},
			// DynamicObject
			new UpdateField[]{
				null,
				null,
				null,
				null,
				null,
				null,
				// DynamicObjectFields.CASTER
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "CASTER",
					Offset = 6,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// DynamicObjectFields.BYTES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "BYTES",
					Offset = 8,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// DynamicObjectFields.SPELLID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "SPELLID",
					Offset = 9,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// DynamicObjectFields.RADIUS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "RADIUS",
					Offset = 10,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.POS_X
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "POS_X",
					Offset = 11,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.POS_Y
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "POS_Y",
					Offset = 12,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.POS_Z
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "POS_Z",
					Offset = 13,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.FACING
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "FACING",
					Offset = 14,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.CASTTIME
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "CASTTIME",
					Offset = 15,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
			},
			// Corpse
			new UpdateField[]{
				null,
				null,
				null,
				null,
				null,
				null,
				// CorpseFields.OWNER
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "OWNER",
					Offset = 6,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// CorpseFields.FACING
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "FACING",
					Offset = 8,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// CorpseFields.POS_X
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "POS_X",
					Offset = 9,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// CorpseFields.POS_Y
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "POS_Y",
					Offset = 10,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// CorpseFields.POS_Z
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "POS_Z",
					Offset = 11,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// CorpseFields.DISPLAY_ID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "DISPLAY_ID",
					Offset = 12,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// CorpseFields.ITEM
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "ITEM",
					Offset = 13,
					Size = 19,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// CorpseFields.BYTES_1
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "BYTES_1",
					Offset = 32,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// CorpseFields.BYTES_2
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "BYTES_2",
					Offset = 33,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// CorpseFields.GUILD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "GUILD",
					Offset = 34,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// CorpseFields.FLAGS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "FLAGS",
					Offset = 35,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// CorpseFields.DYNAMIC_FLAGS
				new UpdateField {
					Flags = FieldFlag.Dynamic,
					Group = ObjectTypeId.Corpse,
					Name = "DYNAMIC_FLAGS",
					Offset = 36,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// CorpseFields.PAD
				new UpdateField {
					Flags = FieldFlag.None,
					Group = ObjectTypeId.Corpse,
					Name = "PAD",
					Offset = 37,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
			},
            #endregion

            #region DynamicObject Field
			// DynamicObject
			new UpdateField[]{
				null,
				null,
				null,
				null,
				null,
				null,
				// DynamicObjectFields.CASTER
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "CASTER",
					Offset = 6,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// DynamicObjectFields.BYTES
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "BYTES",
					Offset = 8,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// DynamicObjectFields.SPELLID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "SPELLID",
					Offset = 9,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// DynamicObjectFields.RADIUS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "RADIUS",
					Offset = 10,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.POS_X
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "POS_X",
					Offset = 11,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.POS_Y
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "POS_Y",
					Offset = 12,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.POS_Z
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "POS_Z",
					Offset = 13,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.FACING
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "FACING",
					Offset = 14,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// DynamicObjectFields.CASTTIME
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.DynamicObject,
					Name = "CASTTIME",
					Offset = 15,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
			},
            #endregion

            #region Corpse Field
            // Corpse
			new UpdateField[]{
				null,
				null,
				null,
				null,
				null,
				null,
				// CorpseFields.OWNER
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "OWNER",
					Offset = 6,
					Size = 2,
					Type = UpdateFieldType.GUID
				},
				null,
				// CorpseFields.FACING
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "FACING",
					Offset = 8,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// CorpseFields.POS_X
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "POS_X",
					Offset = 9,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// CorpseFields.POS_Y
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "POS_Y",
					Offset = 10,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// CorpseFields.POS_Z
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "POS_Z",
					Offset = 11,
					Size = 1,
					Type = UpdateFieldType.Float
				},
				// CorpseFields.DISPLAY_ID
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "DISPLAY_ID",
					Offset = 12,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// CorpseFields.ITEM
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "ITEM",
					Offset = 13,
					Size = 19,
					Type = UpdateFieldType.UInt32
				},
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				// CorpseFields.BYTES_1
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "BYTES_1",
					Offset = 32,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// CorpseFields.BYTES_2
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "BYTES_2",
					Offset = 33,
					Size = 1,
					Type = UpdateFieldType.ByteArray
				},
				// CorpseFields.GUILD
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "GUILD",
					Offset = 34,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// CorpseFields.FLAGS
				new UpdateField {
					Flags = FieldFlag.Public,
					Group = ObjectTypeId.Corpse,
					Name = "FLAGS",
					Offset = 35,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// CorpseFields.DYNAMIC_FLAGS
				new UpdateField {
					Flags = FieldFlag.Dynamic,
					Group = ObjectTypeId.Corpse,
					Name = "DYNAMIC_FLAGS",
					Offset = 36,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
				// CorpseFields.PAD
				new UpdateField {
					Flags = FieldFlag.None,
					Group = ObjectTypeId.Corpse,
					Name = "PAD",
					Offset = 37,
					Size = 1,
					Type = UpdateFieldType.UInt32
				},
			},
            #endregion
		};
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateFieldCollection
    {
        #region zh-CHS 共有常量 | en Public Constants
        /// <summary>
        /// 
        /// </summary>
        public readonly uint Offset;
        /// <summary>
        /// 
        /// </summary>
        public readonly bool HasPrivateFields;
        /// <summary>
        /// 
        /// </summary>
        public readonly ObjectTypeId TypeId;
        /// <summary>
        /// 
        /// </summary>
        public readonly UpdateField[] Fields;
        /// <summary>
        /// 
        /// </summary>
        public readonly UpdateFieldCollection BaseCollection;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <param name="baseCollection"></param>
        /// <param name="offset"></param>
        /// <param name="hasPrivateFields"></param>
        internal UpdateFieldCollection( ObjectTypeId typeId, UpdateField[] updateFields,
            UpdateFieldCollection baseCollection, uint iOffset, bool hasPrivateFields )
        {
            TypeId = typeId;
            Fields = updateFields;
            BaseCollection = baseCollection;
            Offset = iOffset;
            HasPrivateFields = hasPrivateFields;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public uint Count
        {
            get { return (uint)Fields.Length - Offset; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public static class UpdateFieldManager
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private static readonly UpdateFieldCollection[] Collections = new UpdateFieldCollection[UpdateField.ObjectTypeCount];
        /// <summary>
        /// 
        /// </summary>
        private static readonly ObjectTypeId[] Inheritance = new ObjectTypeId[UpdateField.ObjectTypeCount];
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods

        #region zh-CHS 私有静态方法 | en Private Static Methods
        #region zh-CHS 私有静态方法 | en Private Static Methods
        /// <summary>
        /// 
        /// </summary>
        private static void InitInheritance()
        {
            Inheritance[(int)ObjectTypeId.Object] = ObjectTypeId.None;
            Inheritance[(int)ObjectTypeId.Item] = ObjectTypeId.Object;
            Inheritance[(int)ObjectTypeId.Container] = ObjectTypeId.Item;
            Inheritance[(int)ObjectTypeId.Unit] = ObjectTypeId.Object;
            Inheritance[(int)ObjectTypeId.Player] = ObjectTypeId.Unit;
            Inheritance[(int)ObjectTypeId.GameObject] = ObjectTypeId.Object;
            Inheritance[(int)ObjectTypeId.DynamicObject] = ObjectTypeId.Object;
            Inheritance[(int)ObjectTypeId.Corpse] = ObjectTypeId.Object;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private static void Init()
        {
            InitInheritance();

            for ( var iIndex = ObjectTypeId.Object; iIndex < (ObjectTypeId)UpdateField.ObjectTypeCount; iIndex++ )
            {
                UpdateField[] updateFields = UpdateFields.AllFields[(int)iIndex];

                uint iOffset = uint.MaxValue;
                bool hasPrivateFields = false;
                UpdateField lastUpdateField = null;

                for ( int iIndex2 = 0; iIndex2 < updateFields.Length; iIndex2++ )
                {
                    var updateField = updateFields[iIndex2];
                    if ( updateField != null )
                    {
                        if ( iOffset == uint.MaxValue )
                            iOffset = updateField.Offset;

                        lastUpdateField = updateField;

                        updateField.IsPublic =
                            ( updateField.Flags & FieldFlag.Private ) == FieldFlag.None &&
                            ( updateField.Flags & FieldFlag.OnlyForOwner ) == FieldFlag.None;

                        if ( updateField.IsPublic == false )
                            hasPrivateFields = true;
                    }
                    else
                    {
                        if ( lastUpdateField != null )
                            updateFields[iIndex2] = lastUpdateField;
                    }
                }


                UpdateFieldCollection baseCollection = null;
                var baseType = UpdateFieldManager.Inheritance[(int)iIndex];

                if ( baseType != ObjectTypeId.None )
                {
                    baseCollection = UpdateFieldManager.Collections[(int)baseType];

                    // copy all inherited fields into this Collection's array
                    for ( var iIndex2 = 0; iIndex2 < baseCollection.Fields.Length; iIndex2++ )
                        updateFields[iIndex2] = baseCollection.Fields[iIndex2];
                }

                UpdateFieldManager.Collections[(int)iIndex] = new UpdateFieldCollection( iIndex, updateFields, baseCollection, iOffset, hasPrivateFields );
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static UpdateFieldCollection GetCollection( ObjectTypeId typeId )
        {
            //////////////////////////////////////////////////////////////////////////
            // 初始化物体全部的基础字段信息

            if ( UpdateFieldManager.Collections[0] == null )
                UpdateFieldManager.Init();

            return UpdateFieldManager.Collections[(int)typeId];
        }

        #endregion
    }
}