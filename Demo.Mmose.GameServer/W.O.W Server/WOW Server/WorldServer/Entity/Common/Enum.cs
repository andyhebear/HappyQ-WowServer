using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Wow.WorldServer.Entity.Common
{

    /// <summary>
    /// Per player
    /// </summary>
    [Flags]
    public enum ChannelFlags
    {
        None = 0,
        Owner = 0x1,
        Moderator = 0x2,
        Muted = 0x8
    }

    [Flags]
    public enum GroupMemberFlags : byte
    {
        Normal = 0x0,
        Assistant = 0x1,
        MainTank = 0x2,
        MainAssistant = 0x4
    }

    /// <summary>
    /// Priviledge levels
    /// </summary>
    public enum GroupPrivs
    {
        Normal = 0,
        Assistant,
        MainAsisstant,
        Leader
    }

    public enum AIType
    {
        Loner,
        Agro,
        Social,
        Pet,
        Totem,
        Guardian
    }

    public enum AIMovementType
    {
        None = 0,
        DesiredWaypoint = 1,
        StayWaypoint = 1 << 1,
        ForwardThenStop = 1 << 2,
        AnyWaypoint = DesiredWaypoint | StayWaypoint
    }

    public enum AIMovementState
    {
        Move,
        Follow,
        Stop,
        FollowOwner
    }

    public enum AICreatureState
    {
        Stopped,
        Moving,
        Attacking
    }

    public enum AIMoveType
    {
        Walk,
        Run,
        Sprint,
        Fly
    }

    public enum MonsterMoveFlags
    {
        None = 0,
        Sprint = 0x100,
        Fly = 0x300,
    }

    [Flags]
    public enum CreatureFlags
    {
        Skinnable = 0x1,
        SpiritHealer = 0x2,
        FLAG_0x4 = 0x4,
        FLAG_0x8 = 0x8,

        FLAG_0x10 = 0x10,
        FLAG_0x20 = 0x20,
        FLAG_0x40 = 0x40,
        FLAG_0x80 = 0x80,

        SkinningTypeHerbalism = 0x100,
        FLAG_0x200 = 0x200,
        FLAG_0x400 = 0x400,
        FLAG_0x800 = 0x800,

        FLAG_0x1000 = 0x1000,
        FLAG_0x2000 = 0x2000,
        FLAG_0x4000 = 0x4000,
        FLAG_0x8000 = 0x8000,

        FLAG_0x10000 = 0x10000,
        FLAG_0x20000 = 0x20000,
        FLAG_0x40000 = 0x40000,
        FLAG_0x80000 = 0x80000,
    }

    public enum NPCType
    {
        Beast = 1,
        Dragonkin = 2,
        Demon = 3,
        Elemental = 4,
        Giant = 5,
        Undead = 6,
        Humanoid = 7,
        Critter = 8,
        Mechanical = 9,
        NotSpecified = 10,
        Totem = 11,
        NonCombatPet = 12,
        GasCloud = 13
    }

    public enum CreatureRank
    {
        Normal = 0,
        Elite = 1,
        RareElite = 2,
        WorldBoss = 3,
        Rare = 4,
    }

    public enum SkillCategory
    {
        /// <summary>
        /// Only "Pet - Raveger" and "Pet Event - Remote Control"
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// Strength, Agility, etc.
        /// </summary>
        Attribute = 5,
        /// <summary>
        /// Bow, Gun, Sword, etc.
        /// </summary>
        WeaponSkill = 6,
        /// <summary>
        /// Lockpicking, Pickpocketing and Poisoning
        /// </summary>
        ClassSkill = 7,
        /// <summary>
        /// Cloth, Leather, Mail, Plate
        /// </summary>
        ArmorProficiency = 8,
        /// <summary>
        /// Cooking, First Aid, Fishing, Riding
        /// </summary>
        SecondarySkill = 9,
        /// <summary>
        /// Common, Orcish, Darnassian, Gutterspeak, etc.
        /// </summary>
        Language = 10,
        /// <summary>
        /// Alchemy, Blacksmithing, Engineering, Leatherworking, Tailoring, Jewelcrafting,
        /// Herbalism, Mining, Skinning, Enchanting, Inscription
        /// </summary>
        Profession = 11,
        NotDisplayed = 12
    }

    /// <summary>
    /// Commom guild events
    /// </summary>
    public enum GuildEvents : byte
    {
        DEMOTION = 1,
        DISBANDED = 8,
        JOINED = 3,
        LEADER_CHANGED = 7,
        LEADER_IS = 6,
        LEFT = 4,
        MOTD = 2,
        OFFLINE = 13,
        ONLINE = 12,
        PROMOTION = 0,
        REMOVED = 5,
        TABARDCHANGE = 9
    }

    /// <summary>
    /// Results of a guild command request
    /// </summary>
    public enum GuildCommandResults
    {
        NO_MORE_IN_GUILD = 0,
        INTERNAL = 1,
        ALREADY_IN_GUILD = 2,
        ALREADY_IN_GUILD_S = 3,
        INVITED_TO_GUILD = 4,
        ALREADY_INVITED_TO_GUILD = 5,
        NAME_INVALID = 6,
        NAME_EXISTS = 7,
        PERMISSIONS = 8,
        LEADER_LEAVE = 8,
        NOT_IN_GUILD = 9,
        NOT_IN_GUILD_S = 10,
        NOT_FOUND = 11,
        NOT_ALLIED = 12,
        RANK_TO_HIGH = 13,
        ALREADY_NOOB = 14,
        TEMPORARY_ERROR = 17,
        GUILD_RANK_IN_USE = 18,
        IGNORING_YOU = 19,
    }

    /// <summary>
    /// Commom guild commands
    /// </summary>
    public enum GuildCommands
    {
        CREATE = 0,
        INVITE = 1,
        QUIT = 2,
        FOUNDER = 12,
        MEMBER = 13
    }

    /// <summary>
    /// Rights of a Guild Member
    /// </summary>
    [Flags]
    public enum GuildRankRights : int
    {
        EMPTY = 0x0040,
        GCHATLISTEN = 0x0041,
        GCHATSPEAK = 0x0042,
        OFFCHATLISTEN = 0x0044,
        OFFCHATSPEAK = 0x0048,
        PROMOTE = 0x00C0,
        DEMOTE = 0x0140,
        INVITE = 0x0050,
        REMOVE = 0x0060,
        SETMOTD = 0x1040,
        EPNOTE = 0x2040,
        VIEWOFFNOTE = 0x4040,
        EOFFNOTE = 0x8040,
        ALL = 0xF1FF,
    }

    public enum LoadStrategy
    {
        File = 0,
        Directory = 1,
        DirectoryRecursive = 2
    }

    public enum ChatTag : byte
    {
        None = 0,
        AFK = 1,
        //QA = 2,
        DND = 3,
        GM = 4
    }

    // May be only used in client
    public enum UnitNameType
    {
        UNITNAME_TITLE_PET = 1,
        UNITNAME_TITLE_MINION,
        UNITNAME_TITLE_GUARDIAN,
        UNITNAME_TITLE_CREATION,
        UNITNAME_TITLE_COMPANION,
    }

    public enum SkinningType
    {
        UNIT_SKINNABLE_LEATHER,
        UNIT_SKINNABLE_HERB,
        UNIT_SKINNABLE_ROCK,
    }

    public enum CombatRating
    {
        WeaponSkill = 1,
        DefenseSkill = 2,
        Dodge = 3,
        Parry = 4,
        Block = 5,
        MeleeHitChance = 6,
        RangedHitChance = 7,
        SpellHitChance = 8,
        MeleeCritChance = 9,
        RangedCritChance = 10,
        SpellCritChance = 11,
        /// <summary>
        /// Chance of an attacker to hit the char with a melee attack
        /// </summary>
        MeleeAttackerHit = 12,
        /// <summary>
        /// Chance of an attacker to hit the char with a ranged attack
        /// </summary>
        RangedAttackerHit = 13,
        /// <summary>
        /// Chance of an attacker to hit the char with spells
        /// </summary>
        SpellAttackerHit = 14,
        /// <summary>
        /// Reduction of chance of an attacker to make a melee crit
        /// </summary>
        MeleeResilience = 15,
        /// <summary>
        /// Reduction of chance of an attacker to make a ranged crit
        /// </summary>
        RangedResilience = 16,
        /// <summary>
        /// Reduction of chance of an attacker to make a spell crit
        /// </summary>
        SpellResilience = 17,
        MeleeHaste = 18,
        RangedHaste = 19,
        SpellHaste = 20,

        WeaponSkillMainhand = 21,
        WeaponSkillOffhand = 22,
        WeaponSkillRanged = 23,
        Expertise = 24
    }

    public enum GameObjectAnimState
    {
        Closed,
        Opening,
        Open,
        Closing,
        Custom1,
        Custom2,
        Custom3,
        Custom4,
        Despawn,
    }

    public enum InstanceResetFailed
    {
        PlayersInside,
        PlayersOffline,
        PlayersZoning
    }

    public enum InstanceTransferFailed
    {
        InstanceFull = 1,
        InstanceNotFound,
        ToManyInstancesRecently
    }

    public enum ChannelNotification
    {
        PlayerJoined = 0x00,
        PlayerLeft = 0x01,
        YouJoined = 0x02,
        YouLeft = 0x03,
        WrongPassword = 0x04,
        NotOnChannel = 0x05,
        NotModerator = 0x06,
        PasswordChanged = 0x07,
        OwnerChanged = 0x08,
        PlayerNotOnChannel = 0x09,
        NotOwner = 0x0A,
        CurrentOwner = 0x0B,
        Mute = 0x0C,
        Moderator = 0x0C,
        Announcing = 0x0D,
        NotAnnouncing = 0x0E,
        Moderated = 0x0F,
        NotModerated = 0x10,
        YouAreMuted = 0x11,
        Kicked = 0x12,
        YouAreBanned = 0x13,
        Banned = 0x14,
        Unbanned = 0x15,
        AlreadyOnChannel = 0x17,
        BeenInvitedToChannel = 0x18,
        HaveInvitedToChannel = 0x1D
    }

    public enum TradeStatus
    {
        PlayerBusy = 0x00,
        Proposed = 0x01,
        Initiated = 0x02,
        Cancelled = 0x03,
        Accepted = 0x04,
        AlreadyTrading = 0x05,
        PlayerNotFound = 0x06,
        StateChanged = 0x07,
        Complete = 0x08,
        Unaccepted = 0x09,
        TooFarAway = 0x0A,
        WrongFaction = 0x0B,
        Failed = 0x0C,
        TargetDead = 0x0D,
        Petition = 0x0E,
        PlayerIgnored = 0x0F,
    }

    public enum TradeData
    {
        Give = 0x00,
        Receive = 0x01,
    }

    public enum InitializationPass : int
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Fifth = 4,
        Sixth = 5,
        Seventh = 6,
        Eighth = 7,
        Nineth = 8,
        Tenth = 9
    }

    #region Realm Login
    public enum VersionComparison
    {
        LessThan = -1,
        LessThanOrExact = 0,
        Exact = 1
    }

    [Flags]
    public enum CharEnumFlags
    {
        None = 0,
        Alive = 0x1,
        //Flag_0x2 = 0x2,
        LockedForTransfer = 0x4,
        //Flag_0x8 = 0x8,
        //Flag_0x10 = 0x10, // No Visible Change
        HideHelm = 0x400,
        HideCloak = 0x800,
        Ghost = 0x2000, // Correct
        NeedsRename = 0x4000, // Correct
        Unknown = 0xA00000,
        LockedForBilling = 0x1000000 // Correct
    }

    public enum RealmColor
    {
        Green = 0x0,
        Red = 0x1,
        Offline = 0x2,
    }

    public enum RealmTimeZone
    {
        USA = 0x01,
        Oceanic = 0x05
    }

    public enum RealmStatus
    {
        Good = 0x00,
        Locked = 0x01,
    }

    public enum RealmType
    {
        Normal = 0x00,
        PVP = 0x01,
        RP = 0x06,
        RPPVP = 0x08,
    }

    public enum RealmPopulation
    {
        Low = 0,
        Medium = 1,
        High = 2,
        New = 200,
        Full = 400,
        Recommended = 600
    }
    #endregion

    #region Movement and Sitting
    public enum MovementState
    {
        Root = 1,
        Unroot = 2,
        WalkOnWater = 3,
        WalkOnLand = 4,
    }

    public enum MovementType
    {
        Walk,
        WalkBack,
        Run,
        Swim,
        SwimBack,
        Fly,
        FlyBack,
        Turn
    }

    /// <summary>
    /// Used in _BYTES_1, 1st byte
    /// </summary>
    public enum StandState : byte
    {
        Stand = 0,
        Sit = 1,
        SittingInChair = 2,
        Sleeping = 3,
        SittingInLowChair = 4,
        SittingInMediumChair = 5,
        SittingInHighChair = 6,
        Dead = 7,
        Kneeling = 8
    }

    public enum ChairHeight
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
    #endregion

    #region Mail
    public enum MailResult
    {
        MailSent = 0,
        MoneyTaken = 1,
        ItemTaken = 2,
        ReturnedToSender = 3,
        Deleted = 4,
        MadePermanent = 5
    }

    public enum MailType : byte
    {
        Normal = 0,
        CashOnDelivery = 1,
        Auction = 2,
        Creature = 3,
        GameObject = 4,
        Item = 5
    }

    public enum MailStationary
    {
        Unknown = 0x01,
        Normal = 0x29,
        GM = 0x3D,
        Auction = 0x3E,
        Val = 0x40,
        Chr = 0x41
    }

    public enum MailError : uint
    {
        MAIL_OK = 0,
        MAIL_ERR_BAG_FULL = 1,
        MAIL_ERR_CANNOT_SEND_TO_SELF = 2,
        MAIL_ERR_NOT_ENOUGH_MONEY = 3,
        MAIL_ERR_RECIPIENT_NOT_FOUND = 4,
        MAIL_ERR_NOT_YOUR_ALLIANCE = 5,
        MAIL_ERR_INTERNAL_ERROR = 6,
        MAIL_ERR_DISABLED_FOR_TRIAL_ACCOUNT = 14,
        MAIL_ERR_RECIPIENT_CAP_REACHED = 15,
        MAIL_ERR_CANT_SEND_WRAPPED_COD = 16,
        MAIL_ERR_MAIL_AND_CHAT_SUSPENDED = 17
    }

    public enum MailCheckedFlag
    {
        NotRead = 0,
        Read = 1,
        AuctionChecked = 4,
        CODPaymentChecked = 8,
        ReturnedChecked = 16
    }

    public enum MailAuctionAnswers
    {
        Outbid = 0,
        Won = 1,
        Successful = 2,
        Expired = 3,
        CancelledToBidder = 4,
        Cancelled = 5
    }
    #endregion

    /// <summary>
    /// Results of char relation related commands
    /// </summary>
    public enum RelationResult
    {
        FRIEND_DB_ERROR = 0x00,
        FRIEND_LIST_FULL = 0x01,
        FRIEND_ONLINE = 0x02,
        FRIEND_OFFLINE = 0x03,
        FRIEND_NOT_FOUND = 0x04,
        FRIEND_REMOVED = 0x05,
        FRIEND_ADDED_ONLINE = 0x06,
        FRIEND_ADDED_OFFLINE = 0x07,
        FRIEND_ALREADY = 0x08,
        FRIEND_SELF = 0x09,
        FRIEND_ENEMY = 0x0A,
        IGNORE_LIST_FULL = 0x0B,
        IGNORE_SELF = 0x0C,
        IGNORE_NOT_FOUND = 0x0D,
        IGNORE_ALREADY = 0x0E,
        IGNORE_ADDED = 0x0F,
        IGNORE_REMOVED = 0x10,

        MUTED_LIST_FULL = 17, // guess value
        MUTED_SELF = 18, // guess value
        MUTED_ENEMY = 19, // guess value
        MUTED_NOT_FOUND = 20, // guess value
        MUTED_ALREADY = 21, // guess value
        PlayerMuted = 22, // ulong guid
        PlayerUnMuted = 23, // ulong guid
    }

    /// <summary>
    /// Same a NPCFlags, but as a simple (not flag-)field
    /// </summary>
    public enum NPCEntryType
    {
        SpiritGuide = 6,	// pre 2.3.0

        Gossip = 1,
        QuestGiver = 2,
        Trainer = 4,
        Vendor = 7,
        Armorer = 12,
        TaxiVendor = 13,
        ProfessionTrainer = 14,
        SpiritHealer = 15,
        InnKeeper = 16,
        Banker = 17,
        ArenaPetitioner = 18,
        TabardVendor = 19,
        BattleMaster = 20,
        Auctioneer = 21,
        Stable = 22,
        GuildBanker = 23
    }

    /// <summary>
    /// NPC Type Flags
    /// </summary>
    [Flags]
    public enum NPCEntryMask
    {
        SpiritGuide = 0x00000040,	// pre 2.3.0
        GuildPetitioner = 0x00000600,	// pre 2.3.0
        None = 0x00000000,
        Gossip = 0x00000001,
        QuestGiver = 0x00000002,
        Trainer = 0x00000010,
        Vendor = 0x00000080,
        Armorer = 0x00001000,
        TaxiVendor = 0x00002000,
        ProfessionTrainer = 0x00004000,
        SpiritHealer = 0x00008000,
        InnKeeper = 0x00010000,
        Banker = 0x00020000,
        ArenaPetitioner = 0x00040000,
        TabardVendor = 0x00080000,
        BattleMaster = 0x00100000,
        Auctioneer = 0x00200000,
        Stable = 0x00400000,
        GuildBanker = 0x00800000
    }

    /// <summary>
    /// Update Types used in SMSG_UPDATE_OBJECT inside realm server
    /// </summary>
    public enum UpdateTypes : byte
    {
        Values = 0,
        Movement = 1,
        Create = 2,
        CreateSelf = 3,
        OutOfRange = 4,
        Near = 5
    }

    /// <summary>
    /// Object Type Ids are used in SMSG_UPDATE_OBJECT inside realm server
    /// </summary>
    public enum ObjectTypeId
    {
        Object = 0,
        Item = 1,
        Container = 2,
        Unit = 3,
        Player = 4,
        GameObject = 5,
        DynamicObject = 6,
        Corpse = 7,
        AIGroup = 8,
        AreaTrigger = 9,
  		Count,
		None = 0xFF
  }

    [Flags]
    public enum ObjectTypes : uint
    {
        None = 0,
        Object = 0x1,
        Item = 0x2,
        Container = 0x4,
        /// <summary>
        /// Any unit
        /// </summary>
        Unit = 0x8,
        Player = 0x10,
        GameObject = 0x20,
        /// <summary>
        /// Any Unit or GameObject
        /// </summary>
        Attackable = 0x28,
        DynamicObject = 0x40,
        Corpse = 0x80,
        AIGroup = 0x100,
        AreaTrigger = 0x200,
        All = 0xFFFF,
    }

    /// <summary>
    /// Custom enum to enable further distinction between Units
    /// </summary>
    public enum ObjectTypeCustom
    {
        None = 0,
        Object = 0x1,
        Item = 0x2,
        Container = 0x6,
        /// <summary>
        /// Any unit
        /// </summary>
        Unit = 0x8,
        Player = 0x10,
        GameObject = 0x20,
        /// <summary>
        /// Any Unit or GameObject
        /// </summary>
        Attackable = 0x28,
        DynamicObject = 0x40,
        Corpse = 0x80,
        AIGroup = 0x100,
        AreaTrigger = 0x200,
        NPC = 0x1000,
        Pet = 0x2000,
        All = 0xFFFF
    }

    /// <summary>
    /// The Ids for the different races
    /// </summary>
    /// <remarks>Values come from column 1 of ChrClasses.dbc</remarks>
    public enum ClassType
    {
        Warrior = 1,
        Paladin = 2,
        Hunter = 3,
        Rogue = 4,
        Priest = 5,
        //??	= 6
        Shaman = 7,
        Mage = 8,
        Warlock = 9,
        //??	= 10
        Druid = 11
    }

    /// <summary>
    /// The mask is the corrosponding ClassTypes-value ^2 - 1
    /// </summary>
    [Flags]
    public enum ClassMask : uint
    {
        Warrior = 0x0001,
        Paladin = 0x0002,
        Hunter = 0x0004,
        Rogue = 0x0008,
        Priest = 0x0010,

        Shaman = 0x0040,
        Mage = 0x0080,
        Warlock = 0x0100,

        Druid = 0x0400
    }

    /// <summary>
    /// The Ids for the different races
    /// </summary>
    /// <remarks>Values come from column 1 of ChrRaces.dbc</remarks>
    public enum RaceType : byte
    {
        Human = 1,
        Orc = 2,
        Dwarf = 3,
        NightElf = 4,
        Undead = 5,
        Tauren = 6,
        Gnome = 7,
        Troll = 8,
        Goblin = 9,
        BloodElf = 10,
        Draenei = 11,
        FelOrc = 12,
        Naga = 13,
        Broken = 14,
        Skeleton = 15
    }

    /// <summary>
    /// The mask is the corrosponding RaceTypes-value ^2 - 1
    /// </summary>
    [Flags]
    public enum RaceMask
    {
        Human = 0x00001,
        Orc = 0x00002,
        Dwarf = 0x00004,
        Nightelf = 0x00008,
        Undead = 0x00010,
        Tauren = 0x00020,
        Gnomoe = 0x00040,
        Troll = 0x00080,
        Goblin = 0x00100,
        Bloodelf = 0x00200,
        Draenei = 0x00400,
        FelOrc = 0x00800,
        Naga = 0x01000,
        Broken = 0x02000,
        Skeleton = 0x04000
    }


    /// <summary>
    /// The gender types
    /// </summary>
    public enum GenderType
    {
        Male = 0,
        Female = 1,
        Neutral = 2
    }

    /// <summary>
    /// The power types (Mana, Rage, Energy, Focus, Happiness)
    /// </summary>
    public enum PowerType
    {
        Health = -2,
        Mana = 0,
        Rage = 1,
        Focus = 2,
        Energy = 3,
        Happiness = 4
    }

    #region Chatting
    /// <summary>
    /// Message Types
    /// </summary>
    public enum ChatMsgType : byte
    {
        Say = 0x00,
        Party = 0x01,
        Raid = 0x02,
        Guild = 0x03,
        Officer = 0x04,
        Yell = 0x05,
        Whisper = 0x06,
        WhisperInform = 0x07,
        Emote = 0x08,
        TextEmote = 0x09,
        System = 0x0A,
        MonsterSay = 0x0B,
        MonsterYell = 0x0C,
        MonsterEmote = 0x0D,
        Channel = 0x0E,
        ChannelJoin = 0x0F,
        ChannelLeave = 0x10,
        ChannelList = 0x11,
        ChannelNotice = 0x12,
        ChannelNoticeUser = 0x13,
        AFK = 0x14,
        DND = 0x15,
        Ignored = 0x16,
        Skill = 0x17,
        Loot = 0x18,
        RaidLeader = 0x57,
        RaidWarn = 0x58,
        End
    }

    /// <summary>
    /// Chat Language Ids
    /// <remarks>Values from the first column of Languages.dbc</remarks>
    /// </summary>
    public enum ChatLanguage
    {
        Universal = 0,
        Orcish = 1,
        Darnassian = 2,
        Taurahe = 3,
        Dwarven = 6,
        Common = 7,
        DemonTongue = 8,
        Titan = 9,
        Thalassian = 10,
        Draconic = 11,
        OldTongue = 12,
        Gnomish = 13,
        Troll = 14,
        Gutterspeak = 33,
        Draenei = 35,
    }

    /// <summary>
    /// A list of all HTML colors. Use: <c>ChatUtil.Colors[(int)ChatColor]</c>.
    /// See http://www.w3schools.com/html/html_colornames.asp
    /// </summary>
    public enum ChatColor
    {
        AliceBlue,
        AntiqueWhite,
        Aqua,
        Aquamarine,
        Azure,
        Beige,
        Bisque,
        Black,
        BlanchedAlmond,
        Blue,
        BlueViolet,
        Brown,
        BurlyWood,
        CadetBlue,
        Chartreuse,
        Chocolate,
        Coral,
        CornflowerBlue,
        Cornsilk,
        Crimson,
        Cyan,
        DarkBlue,
        DarkCyan,
        DarkGoldenRod,
        DarkGray,
        DarkGrey,
        DarkGreen,
        DarkKhaki,
        DarkMagenta,
        DarkOliveGreen,
        Darkorange,
        DarkOrchid,
        DarkRed,
        DarkSalmon,
        DarkSeaGreen,
        DarkSlateBlue,
        DarkSlateGray,
        DarkSlateGrey,
        DarkTurquoise,
        DarkViolet,
        DeepPink,
        DeepSkyBlue,
        DimGray,
        DimGrey,
        DodgerBlue,
        FireBrick,
        FloralWhite,
        ForestGreen,
        Fuchsia,
        Gainsboro,
        GhostWhite,
        Gold,
        GoldenRod,
        Gray,
        Grey,
        Green,
        GreenYellow,
        HoneyDew,
        HotPink,
        IndianRed,
        Indigo,
        Ivory,
        Khaki,
        Lavender,
        LavenderBlush,
        LawnGreen,
        LemonChiffon,
        LightBlue,
        LightCoral,
        LightCyan,
        LightGoldenRodYellow,
        LightGray,
        LightGrey,
        LightGreen,
        LightPink,
        LightSalmon,
        LightSeaGreen,
        LightSkyBlue,
        LightSlateGray,
        LightSlateGrey,
        LightSteelBlue,
        LightYellow,
        Lime,
        LimeGreen,
        Linen,
        Magenta,
        Maroon,
        MediumAquaMarine,
        MediumBlue,
        MediumOrchid,
        MediumPurple,
        MediumSeaGreen,
        MediumSlateBlue,
        MediumSpringGreen,
        MediumTurquoise,
        MediumVioletRed,
        MidnightBlue,
        MintCream,
        MistyRose,
        Moccasin,
        NavajoWhite,
        Navy,
        OldLace,
        Olive,
        OliveDrab,
        Orange,
        OrangeRed,
        Orchid,
        PaleGoldenRod,
        PaleGreen,
        PaleTurquoise,
        PaleVioletRed,
        PapayaWhip,
        PeachPuff,
        Peru,
        Pink,
        Plum,
        PowderBlue,
        Purple,
        Red,
        RosyBrown,
        RoyalBlue,
        SaddleBrown,
        Salmon,
        SandyBrown,
        SeaGreen,
        SeaShell,
        Sienna,
        Silver,
        SkyBlue,
        SlateBlue,
        SlateGray,
        SlateGrey,
        Snow,
        SpringGreen,
        SteelBlue,
        Tan,
        Teal,
        Thistle,
        Tomato,
        Turquoise,
        Violet,
        Wheat,
        White,
        WhiteSmoke,
        Yellow,
        YellowGreen,

    }

    /// <summary>
    /// Shows a Character performing an action
    /// </summary>
    public enum EmoteType
    {
        None = 0,
        SimpleTalk = 1,
        SimpleBow = 2,
        SimpleWave = 3,
        SimpleCheer = 4,
        SimpleExclamation = 5,
        SimpleQuestion = 6,
        SimpleEat = 7,
        StateDance = 10,
        SimpleLaugh = 11,
        StateSleep = 12,
        StateSit = 13,
        SimpleRude = 14,
        SimpleRoar = 15,
        SimpleKneel = 16,
        SimpleKiss = 17,
        SimpleCry = 18,
        SimpleChicken = 19,
        SimpleBeg = 20,
        SimpleApplaud = 21,
        SimpleShout = 22,
        SimpleFlex = 23,
        SimpleShy = 24,
        SimplePoint = 25,
        StateStand = 26,
        StateReadyunarmed = 27,
        StateWork = 28,
        StatePoint = 29,
        StateNone = 30,
        SimpleWound = 33,
        SimpleWoundcritical = 34,
        SimpleAttackunarmed = 35,
        SimpleAttack1h = 36,
        SimpleAttack2htight = 37,
        SimpleAttack2hloose = 38,
        SimpleParryunarmed = 39,
        SimpleParryshield = 43,
        SimpleReadyunarmed = 44,
        SimpleReady1h = 45,
        SimpleReadybow = 48,
        SimpleSpellprecast = 50,
        SimpleSpellcast = 51,
        SimpleBattleroar = 53,
        SimpleSpecialattack1h = 54,
        SimpleKick = 60,
        SimpleAttackthrown = 61,
        StateStun = 64,
        StateDead = 65,
        SimpleSalute = 66,
        StateKneel = 68,
        StateUsestanding = 69,
        SimpleWaveNosheathe = 70,
        SimpleCheerNosheathe = 71,
        SimpleEatNosheathe = 92,
        StateStunNosheathe = 93,
        SimpleDance = 94,
        SimpleSaluteNosheath = 113,
        StateUsestandingNosheathe = 133,
        SimpleLaughNosheathe = 153,
        StateWorkNosheathe = 173,
        StateSpellprecast = 193,
        SimpleReadyrifle = 213,
        StateReadyrifle = 214,
        StateWorkNosheatheMining = 233,
        StateWorkNosheatheChopwood = 234,
        Old_SimpleLiftoff = 253,
        SimpleLiftoff = 254,
        SimpleYes = 273,
        SimpleNo = 274,
        SimpleTrain = 275,
        SimpleLand = 293,
        StateAtEase = 313,
        StateReady1h = 333,
        StateSpellkneelstart = 353,
        StateSubmerged = 373,
        SimpleSubmerge = 374,
        StateReady2h = 375,
        StateReadybow = 376,
        SimpleMountspecial = 377,
        StateTalk = 378,
        StateFishing = 379,
        SimpleFishing = 380,
        SimpleLoot = 381,
        StateWhirlwind = 382,
        StateDrowned = 383,
        StateHoldBow = 384,
        StateHoldRifle = 385,
        StateHoldThrown = 386,
        SimpleDrown = 387,
        SimpleStomp = 388,
        SimpleAttackoff = 389,
        SimpleAttackoffpierce = 390,
        StateRoar = 391,
        StateLaugh = 392,
        SimpleCreatureSpecial = 393,
        SimpleJumpandrun = 394,
        SimpleJumpend = 395,
        SimpleTalkNosheathe = 396,
        SimplePointNosheathe = 397,
        StateCannibalize = 398,
        SimpleJumpstart = 399,
        StateDancespecial = 400,
        SimpleDancespecial = 401,
        SimpleCustomspell01 = 402,
        SimpleCustomspell02 = 403,
        SimpleCustomspell03 = 404,
        SimpleCustomspell04 = 405,
        SimpleCustomspell05 = 406,
        SimpleCustomspell06 = 407,
        SimpleCustomspell07 = 408,
        SimpleCustomspell08 = 409,
        SimpleCustomspell09 = 410,
        SimpleCustomspell10 = 411,
        StateExclaim = 412
    }

    public enum TextEmote
    {
        Agree = 1,
        Amaze = 2,
        Angry = 3,
        Apologize = 4,
        Applaud = 5,
        Bashful = 6,
        Beckon = 7,
        Beg = 8,
        Bite = 9,
        Bleed = 10,
        Blink = 11,
        Blush = 12,
        Bonk = 13,
        Bored = 14,
        Bounce = 15,
        Brb = 16,
        Bow = 17,
        Burp = 18,
        Bye = 19,
        Cackle = 20,
        Cheer = 21,
        Chicken = 22,
        Chuckle = 23,
        Clap = 24,
        Confused = 25,
        Congratulate = 26,
        Cough = 27,
        Cower = 28,
        Crack = 29,
        Cringe = 30,
        Cry = 31,
        Curious = 32,
        Curtsey = 33,
        Dance = 34,
        Drink = 35,
        Drool = 36,
        Eat = 37,
        Eye = 38,
        Fart = 39,
        Fidget = 40,
        Flex = 41,
        Frown = 42,
        Gasp = 43,
        Gaze = 44,
        Giggle = 45,
        Glare = 46,
        Gloat = 47,
        Greet = 48,
        Grin = 49,
        Groan = 50,
        Grovel = 51,
        Guffaw = 52,
        Hail = 53,
        Happy = 54,
        Hello = 55,
        Hug = 56,
        Hungry = 57,
        Kiss = 58,
        Kneel = 59,
        Laugh = 60,
        Laydown = 61,
        Massage = 62,
        Moan = 63,
        Moon = 64,
        Mourn = 65,
        No = 66,
        Nod = 67,
        Nosepick = 68,
        Panic = 69,
        Peer = 70,
        Plead = 71,
        Point = 72,
        Poke = 73,
        Pray = 74,
        Roar = 75,
        Rofl = 76,
        Rude = 77,
        Salute = 78,
        Scratch = 79,
        Sexy = 80,
        Shake = 81,
        Shout = 82,
        Shrug = 83,
        Shy = 84,
        Sigh = 85,
        Sit = 86,
        Sleep = 87,
        Snarl = 88,
        Spit = 89,
        Stare = 90,
        Surprised = 91,
        Surrender = 92,
        Talk = 93,
        Talkex = 94,
        Talkq = 95,
        Tap = 96,
        Thank = 97,
        Threaten = 98,
        Tired = 99,
        Victory = 100,
        Wave = 101,
        Welcome = 102,
        Whine = 103,
        Whistle = 104,
        Work = 105,
        Yawn = 106,
        Boggle = 107,
        Calm = 108,
        Cold = 109,
        Comfort = 110,
        Cuddle = 111,
        Duck = 112,
        Insult = 113,
        Introduce = 114,
        Jk = 115,
        Lick = 116,
        Listen = 117,
        Lost = 118,
        Mock = 119,
        Ponder = 120,
        Pounce = 121,
        Praise = 122,
        Purr = 123,
        Puzzle = 124,
        Raise = 125,
        Ready = 126,
        Shimmy = 127,
        Shiver = 128,
        Shoo = 129,
        Slap = 130,
        Smirk = 131,
        Sniff = 132,
        Snub = 133,
        Soothe = 134,
        Stink = 135,
        Taunt = 136,
        Tease = 137,
        Thirsty = 138,
        Veto = 139,
        Snicker = 140,
        Stand = 141,
        Tickle = 142,
        Violin = 143,
        Smile = 163,
        Rasp = 183,
        Pity = 203,
        Growl = 204,
        Bark = 205,
        Scared = 223,
        Flop = 224,
        Love = 225,
        Moo = 226,
        Commend = 243,
        Joke = 329
    }

    #endregion

    /// <summary>
    /// Race model offset IDs
    /// </summary>
    public enum RaceModelOffset
    {
        Human = 49,
        Orc = 51,
        Dwarf = 53,
        NightElf = 55,
        Undead = 57,
        Tauren = 59,
        Troll = 1478,
        Gnome = 1563,
        BloodElf = 15476,
        Draenei = 16125
    }

    [Flags]
    public enum UnitFlags
    {
        None = 0,
        //Unknown1 = 0x00000001,

        /// <summary>
        /// Cannot be attacked
        /// </summary>
        Invulnerable = 0x2,

        /// <summary>
        /// Applied in SPELL_AURA_MOD_CONFUSE (5)
        /// Applied in SPELL_AURA_MOD_FEAR (7)
        /// </summary>
        Influenced = 0x4, // Stops movement packets

        /// <summary>
        /// Enables Detailed Collision, Allows swimming
        /// When set for pets allows the popup menu to be shown (dismiss, rename, etc)
        /// </summary>
        PlayerControlled = 0x8,

        /// <summary>
        /// Rename?
        /// </summary>
        Flag_0x10 = 0x10,

        /// <summary>
        /// Resting?
        /// </summary>
        Flag_0x20 = 0x20,

        /// <summary>
        /// Probably Elite
        /// </summary>
        Flag_0x40 = 0x40,

        Flag_0x80 = 0x80,

        Flag_0x100 = 0x100,

        Flag_0x200 = 0x200,

        /// <summary>
        /// Looting animation is shown
        /// </summary>
        Looting = 0x400,

        // Check
        PetInCombat = 0x800,

        //Totem = 0x808,

        PVP = 0x1000,

        Silenced = 0x2000,

        /// <summary>
        /// Applied in SPELL_AURA_MOD_FEAR (7)
        /// </summary>
        LockRotation = 0x40000,

        /// <summary>
        /// Unit is in Combat
        /// </summary>
        Combat = 0x80000,

        /// <summary>
        /// Unit is currently on a taxi
        /// </summary>
        TaxiFlight = 0x00100000,


        Confused = 0x400000,
        Feared = 0x800000,

        /* Some flags to find
         * ImmuneNPC
         * ImmunePC
         * NoXP - maybe just make this up
         * NoLoot
         * Unkillable
         * Uninteractable 
         * */

        /*UNIT_UNTACKABLE_SELECT = 0x100,
        // ImmuneNPC?
        UNIT_UNTACKABLE_SELECT_2 = 0x100000, //AI, UNIT can attack non players.
        // Uninteractable?
        UNIT_UNTACKABLE_NO_SELECT = 0x2000000, //AI, UNIT cant attack any unit, no name is displayed
        // ImmunePC?
        MAKE_CHAR_UNTOUCHABLE = 0x8000000,*/

        /// <summary>
        /// Applied in SPELL_AURA_MOD_POSSESS_PET (128)
        /// </summary>
        ControlledCreature = 0x1000000,

        UnInteractable = 0x2000000,
        Skinnable = 0x4000000,
        Mounted = 0x8000000,

        /// <summary>
        /// Applied in SPELL_AURA_MOD_DISARM (67)
        /// </summary>
        Disarmed = 0x40000000
    }

    [Flags]
    public enum UnitFlag2
    {
        FeignDeath = 0x00000001
    }

    [Flags]
    public enum UpdateFlag : uint
    {
        Self = 0x1,
        Transport = 0x2,
        HasGuid = 0x4,
        HasLowGuid = 0x8,
        HasHighGuid = 0x10,
        Living = 0x20,
        HasPosition = 0x40,
    }

    [Flags]
    public enum UnitDynamicFlags
    {
        None = 0,
        Lootable = 0x1,
        TrackUnit = 0x2,
        TaggedByOther = 0x4,
        TaggedByMe = 0x8,
        SpecialInfo = 0x10,
        Dead = 0x20,
    }

    [Flags]
    public enum PlayerFlag : uint
    {
        None = 0,
        GroupLeader = 0x1,
        AFK = 0x2,
        DND = 0x4,
        GM = 0x8,
        Ghost = 0x10,
        Resting = 0x20,
        Flag_0x40 = 0x40,
        FreeForAllPVP = 0x80,
        Flag_0x100 = 0x100,
        PVP = 0x200,
        HideHelm = 0x400,
        HideCloak = 0x800,
        Flag_0x1000 = 0x1000, //played long time
        Flag_0x2000 = 0x2000, //played too long time
        Flag_0x4000 = 0x4000,
        Flag_0x8000 = 0x8000,
        Flag_0x10000 = 0x10000,
        Flag_0x20000 = 0x20000, // Taxi Time Test
        Flag_0x40000 = 0x40000,
    }

    /// <summary>
    /// Used in _BYTES_1, 4th byte
    /// </summary>
    [Flags]
    public enum StateFlag
    {
        None = 0,
        AlwaysStand = 0x1,
        Sneaking = 0x2,
        UnTrackable = 0x4,
    }

    public enum MapTransferError
    {
        TRANSFER_ABORT_ERROR = 0,
        TRANSFER_ABORT_MAX_PLAYERS = 1,
        TRANSFER_ABORT_NOT_FOUND = 2,
        TRANSFER_ABORT_TOO_MANY_INSTANCES = 3,
        TRANSFER_ABORT_ZONE_IN_COMBAT = 5,
        TRANSFER_ABORT_INSUF_EXPAN_LVL = 6,
    }

    /// <summary>
    /// Used in _BYTES_1, 2nd byte
    /// </summary>
    public enum LoyaltyLevel
    {
        REBELIOUS = 1,
        UNRULY = 2,
        SUBMISIVE = 3,
        DEPENDABLE = 4,
        FAITHFUL = 5,
        BEST_FRIEND = 6
    }

    public enum FoodType
    {
    }

    /// <summary>
    /// Used in UNIT_FIELD_BYTES_2, 1st byte
    /// </summary>
    public enum SheathType : byte
    {
        None = 0,
        Melee = 1,
        Ranged = 2,

        Shield = 4,
        Rod = 5,
        Light = 7
    }

    /// <summary>
    /// Used in UNIT_FIELD_BYTES_2, 2nd byte
    /// </summary>
    [Flags]
    public enum UFB2Flags2 : byte
    {
        Flag_0x1 = 0x1,
        Flag_0x2 = 0x2,
        Flag_0x4 = 0x4,
        Flag_0x8 = 0x8,
        Flag_0x10 = 0x10,
        Flag_0x20 = 0x20,
        Flag_0x40 = 0x40,
        Flag_0x80 = 0x80
    }

    public enum Material : uint
    {
        Metal = 1,
        Wood = 2,
        Gem = 3,
        Cloth = 7
    }

    public enum PageMaterial
    {
        Parchment = 1,
        Stone = 2,
        Marble = 3,
        Silver = 4,
        Bronze = 5,
        Valentine = 6
    }

    public enum EntityIdType : byte
    {
        Player = 0x00000000,
        Corpse = 0x00000001,
        Unit = 0x00000002,
        GameObject = 0x00000003,
        DynamicObject = 0x00000004,
        Item = 0x00000005,
        Container = 0x00000006,
        Transport = 0x00000007,
    }

    /// <summary>
    /// Used in BYTES_2, 4th Byte
    /// </summary>
    public enum RestState
    {
        Normal = 0x01,
        Rested = 0x02,
    }

    /// <summary>
    /// Group Type
    /// </summary>
    public enum GroupType : byte
    {
        Party = 0,
        Raid = 1
    }

    /// <summary>
    /// Loot method
    /// </summary>
    public enum LootMethod : uint
    {
        FreeForAll = 0,
        RoundRobin = 1,
        MasterLoot = 2,
        GroupLoot = 3,
        NeedBeforeGreed = 4,
        End
    }

    #region GOs
    public enum GameObjectType : uint
    {
        Door = 0,
        Button = 1,
        Questgiver = 2,
        Chest = 3,
        Binder = 4,
        Generic = 5,
        Trap = 6,
        Chair = 7,
        SpellFocus = 8,
        Text = 9,
        Goober = 10,
        Transport = 11,
        AreaDamage = 12,
        Camera = 13,
        MapObject = 14,
        MOTransport = 15,
        DuelFlag = 16,
        FishingNode = 17,
        SummoningRitual = 18,
        Mailbox = 19,
        AuctionHouse = 20,
        GuardPost = 21,
        SpellCaster = 22,
        MeetingStone = 23,
        FlagStand = 24,
        FishingHole = 25,
        Flagdrop = 26,
        MiniGame = 27,
        LotteryKiosk = 28,
        CapturePoint = 29,
        AuraGenerator = 30,
        DungeonDifficulty = 31,
        DoNotUseYet = 32,
        DestructibleBuilding = 33,
        GuildBank = 34,

        None = 0xFFFFFFFF
    }

    public enum GameObjectState
    {
        Diabled = 0x00,
        Enabled = 0x01,
    }

    [Flags]
    public enum GameObjectFlags : uint
    {
        #region Generic
        None = 0x0,

        //GOFlag0x1 = 0x1,
        GOFlag0x00000002 = 0x2,
        GOFlag0x00000004 = 0x4,
        GOFlag0x00000008 = 0x8,

        GOFlag0x00000010 = 0x10,
        Usable = 0x20,
        //GOFlag0x40 = 0x40,
        GOFlag0x00000080 = 0x80,

        GOFlag0x00000100 = 0x100,
        GOFlag0x00000200 = 0x200,
        GOFlag0x00000400 = 0x400,
        GOFlag0x00000800 = 0x800,

        GOFlag0x00001000 = 0x1000,
        GOFlag0x00002000 = 0x2000,
        GOFlag0x00004000 = 0x4000,
        GOFlag0x00008000 = 0x8000,

        GOFlag0x00010000 = 0x10000,
        GOFlag0x00020000 = 0x20000,
        GOFlag0x00040000 = 0x40000,
        GOFlag0x00080000 = 0x80000,

        GOFlag0x00100000 = 0x100000,
        GOFlag0x00200000 = 0x200000,
        GOFlag0x00400000 = 0x400000,
        GOFlag0x00800000 = 0x800000,

        GOFlag0x01000000 = 0x1000000,
        GOFlag0x02000000 = 0x2000000,
        GOFlag0x04000000 = 0x4000000,
        GOFlag0x08000000 = 0x8000000,

        GOFlag0x10000000 = 0x10000000,
        GOFlag0x20000000 = 0x20000000,
        GOFlag0x40000000 = 0x40000000,
        GOFlag0x80000000 = 0x80000000,
        #endregion

        Activate = 0x01,

        Transport = 0x28,

        WarsongGulchOpenGate = 0x40
    }

    [Flags]
    public enum GameObjectDynamicFlags
    {
        Deactivated = 0x00,
        Activated = 0x01,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum LockInteractionGroup
    {
        None = 0,
        Key,
        /// <summary>
        /// See LockType.DBC
        /// </summary>
        Profession
    }

    public enum CreatureTrackingMask : uint
    {
        None = 0,
    }

    /// <summary>
    /// Mask of LockType
    /// </summary>
    [Flags]
    public enum LockMask : uint
    {
        None = 0,
    }

    /// <summary>
    /// See LockType.dbc
    /// </summary>
    public enum LockInteractionType
    {
        None = 0,
        PickLock = 1,
        Herbalism = 2,
        Mining = 3,
        DisarmTrap = 4,
        Open = 5,
        Treasure = 6,
        ElvenGems = 7,
        Close = 8,
        ArmTrap = 9,
        QuickOpen = 10,
        QuickClose = 11,
        OpenTinkering = 12,
        OpenKneeling = 13,
        OpenAttacking = 14,

        /// <summary>
        /// For tracking Gahz'ridian and in GO:
        /// 
        /// Name: Gahz'ridian
        /// Id: 140971
        /// </summary>
        GahzRidian = 15,
        Blasting = 16,
        SlowOpen = 17,
        SlowClose = 18,
        Fishing = 19
    }
    #endregion

    [Flags]
    public enum CharacterStatus : byte
    {
        AFK = 2,
        DND = 4,
        ONLINE = 1,
        OFFLINE = 0
    }

    [Flags]
    public enum MovementFlags
    {
        None = 0,
        Forward = 0x1,
        Backward = 0x2,
        StrafeLeft = 0x4,
        StrafeRight = 0x8,
        Left = 0x10,
        Right = 0x20,
        PitchUp = 0x40,
        PitchDown = 0x80,
        Walk = 0x100,
        OnTransport = 0x200,

        /// <summary>
        /// Used in Movement block
        /// </summary>
        UnitFlying = 0x800,//FlyUnk1 = 0x00000800,

        LockedAxis = 0x1000, // cant move, only rotate

        Falling = 0x2000,
        FallingFar = 0x4000,

        Swimming = 0x200000,
        //FlyUp = 0x00400000,
        //CanFly = 0x00800000,
        //Flying = 0x01000000,
        AirSwimming = 0x2000000,

        Spline = 0x4000000, // ?
        SplineTaxi = 0x8000000,

        Waterwalking = 0x10000000,
        SafeFall = 0x20000000,
        Leviate = 0x40000000
    }

    [Flags]
    public enum SplineFlags
    {
        None = 0,

        SplineFlags0x00000300 = 0x300,

        XYZ = 0x10000,
        GUID = 0x20000,
        Orientation = 0x40000
    }

    /// <summary>
    /// Used in _BYTES_1, 3rd byte
    /// <remarks>Values from the first column of SpellShapeshiftForm.dbc</remarks>
    /// </summary>
    public enum ShapeShiftForm
    {
        Normal = 0,
        Cat = 1,
        TreeOfLife = 2,
        Travel = 3,
        Aqua = 4,
        Bear = 5,
        Ambient = 6,
        Ghoul = 7,
        DireBear = 8,
        CreatureBear = 14,
        CreatureCat = 15,
        GhostWolf = 16,
        BattleStance = 17,
        DefensiveStance = 18,
        BerserkerStance = 19,
        EpicFlightForm = 27,
        Shadow = 28,
        Stealth = 30,
        Moonkin = 31,
        SpiritOfRedemption = 32
    }

    [Flags]
    public enum ShapeShiftMask : uint
    {
        Cat = 1,
        TreeOfLife = 2,
        Travel = 4,
        Aqua = 8,
        Bear = 0x000000010,
        Ambient = 0x000000020,
        Ghoul = 0x000000040,
        DireBear = 0x00000080,
        CreatureBear = 0x00004000,
        CreatureCat = 0x00008000,
        GhostWolf = 0x00010000,
        BattleStance = 0x00020000,
        DefensiveStance = 0x00040000,
        BerserkerStance = 0x00080000,
        EpicFlightForm = 0x08000000,
        Shadow = 0x10000000,
        Stealth = 0x20000000,
        Moonkin = 0x40000000,
        SpiritOfRedemption = 0x80000000
    }

    public enum VictimState
    {
        None = 0,
        Normal = 1,
        Dodge = 2,
        Parry = 3,
        Interrupt = 4,
        Block = 5,
        Evade = 6,
        Immune = 7,
        Deflect = 8
    }

    [Flags]
    public enum ZoneFlag
    {
        None = 0,
        Flag_0x40 = 0x40,

        /// <summary>
        /// Let's fight!
        /// </summary>
        Arena = 0x80,

        /// <summary>
        /// Wooooooow!!
        /// </summary>
        CapitalCity = 0x100,
        Flag_0x200 = 0x200,

        /// <summary>
        /// No harm in this zone
        /// </summary>
        Sanctuary = 0x800,

        /// <summary>
        /// Areas with this flag are up on in the air. when you die you respawn alive at the graveyard
        /// </summary>
        RespawnNoCorpse = 0x1000,

        /// <summary>
        /// More fight!
        /// </summary>
        PVPObjectiveArea = 0x8000,
    }

    [Flags]
    public enum ChatChannelDBCFlags
    {
        None = 0,
        AutoJoinAtCharacterCreation = 0x1, // General, Trade, LocalDefense, LookingForGroup.
        ZoneSpecific = 0x2,
        Global = 0x4,
        Trade = 0x8,
        CityOnly = 0x30,
        Defense = 0x10000,
        RequiresUnguilded = 0x20000,
        LookingForGroup = 0x40000,
    }

    [Flags]
    public enum HitInfo
    {
        NormalSwing = 0x00,
        NormalSwingAnim = 0x02,
        LeftSwing = 0x04,			// actually DualWield?
        Miss = 0x10,
        Absorb = 0x20, // plays absorb sound
        Resist = 0x40, // resisted at least some damage
        CriticalHit = 0x80,
        Block = 0x800,
        Glancing = 0x4000,
        Crushing = 0x8000,
        NoAction = 0x10000,
        SwingNoHitSound = 0x80000
    }

    public enum WeaponAttackType
    {
        BaseAttack = 0,
        OffhandAttack = 1,
        RangedAttack = 2
    }

    public enum DamageEffectType
    {
        DirectDamage = 0,
        SpellDirectDamage = 1,
        DamageOverTime = 2,
        Heal = 3,
        NoDamage = 4,
        SelfDamage = 5
    }

    [Flags]
    public enum DamageTypeMasks : uint
    {
        None = 0,
        Physical = 1,
        Holy = 2,
        Fire = 4,
        Nature = 8,
        Frost = 0x10,
        Shadow = 0x20,
        Arcane = 0x40
    }

    public enum DamageSchool
    {
        Physical = 0,
        Holy = 1,
        Fire = 2,
        Nature = 3,
        Frost = 4,
        Shadow = 5,
        Arcane = 6,
    }

    public enum EnviromentalDamageType
    {
        Exhausted = 0,
        Drowning = 1,
        Fall = 2,
        Lava = 3,
        Slime = 4,
        Fire = 5
    };

    public enum MapType
    {
        Normal = 0,
        Dungeon = 1,
        Raid = 2,
        PVPZone = 3,
        Arena = 4
    }

    /// <summary>
    /// Mask for <see cref="PlayerFields.KNOWN_TITLES"/>
    /// <remarks>Values are from column 20 of CharTitles.dbc. (1 lsh value) </remarks>
    /// </summary>
    public enum PvPTitles : ulong
    {
        Disabled = 0x00000000,
        None = 0x00000001,
        Private = 0x00000002,
        Corporal = 0x00000004,
        SergeantAlliance = 0x00000008,
        MasterSergeant = 0x00000010,
        SegeantMajor = 0x00000020,
        Knight = 0x00000040,
        KnightLieutenant = 0x00000080,
        KnightCaptain = 0x00000100,
        KnightChampion = 0x00000200,
        LieutenantCommander = 0x00000400,
        Commander = 0x00000800,
        Marshal = 0x00001000,
        FieldMarshal = 0x00002000,
        GrandMarshal = 0x00004000,
        Scout = 0x00008000,
        Grunt = 0x00010000,
        Sergeant = 0x00020000,
        SeniorSergeant = 0x00040000,
        FirstSergeant = 0x00080000,
        StoneGuard = 0x00100000,
        BloodGuard = 0x00200000,
        Legionnaire = 0x00400000,
        Centurion = 0x00800000,
        Champion = 0x01000000,
        LieutenantGeneral = 0x02000000,
        General = 0x04000000,
        Warlord = 0x08000000,
        HighWarlord = 0x10000000,

        Gladiator = 0x20000000,
        Duelist = 0x40000000,
        Rival = 0x80000000,
        Challenger = 0x100000000,
        ScarabLord = 0x200000000,
        Conqueror = 0x400000000,
        Justicar = 0x800000000,

        ChampionOfTheNaaru = 0x1000000000,
        MercilessGladiator = 0x2000000000,
    }

    /// <summary>
    /// Values sent in the SMSG_PARTY_COMMAND_RESULT packet
    /// </summary>
    public enum GroupResult
    {
        /// <summary>
        /// Either means everything is OK or the member left?
        /// </summary>
        NoError = 0,
        OfflineOrDoesntExist = 1,
        NotInYourParty = 2,
        NotInYourInstance = 3,
        GroupIsFull = 4,
        AlreadyInGroup = 5,
        PlayerNotInParty = 6,
        DontHavePermission = 7,
        TargetIsUnfriendly = 8,
        TargetIsIgnoringYou = 9,
        PendingMatch = 12,
        TrialCantInviteHighLevel = 13
    }

    public enum DungeonMode : byte
    {
        Normal = 0,
        Heroic = 1,
        End
    }

    [Flags]
    public enum ProcTriggers : uint
    {
        #region Generic
        Flag0x1000000 = 0x1000000,
        Flag0x2000000 = 0x2000000,
        Flag0x4000000 = 0x4000000,
        Flag0x8000000 = 0x8000000,

        Flag0x10000000 = 0x10000000,
        Flag0x20000000 = 0x20000000,
        Flag0x40000000 = 0x40000000,
        Flag0x80000000 = 0x80000000,
        #endregion

        None = 0x0,
        AnyHostileAction = 0x1,
        GainExperience = 0x2,
        /// <summary>
        /// We get attacked
        /// </summary>
        MeleeAttackSelf = 0x4,
        /// <summary>
        /// We land a critical hit
        /// </summary>
        CriticalHit = 0x8,

        /// <summary>
        /// We cast a spell
        /// </summary>
        SpellCast = 0x10,
        /// <summary>
        /// We attack physically
        /// </summary>
        PhysicalAttack = 0x20,
        /// <summary>
        /// We get attacked physically
        /// </summary>
        RangedAttackSelf = 0x40,
        /// <summary>
        /// Someone lands a critical ranged hit on us
        /// </summary>
        RangeCriticalHitSelf = 0x80,

        /// <summary>
        /// Someone attacks us physically
        /// </summary>
        PhysicalAttackSelf = 0x100,
        /// <summary>
        /// We land a melee attack
        /// </summary>
        MeleeAttack = 0x200,
        /// <summary>
        /// 
        /// </summary>
        ActionSelf = 0x400,
        RangedCriticalHit = 0x800,

        CriticalHitSelf = 0x1000,
        RangedAttack = 0x2000,
        Always = 0x4000,
        Flag0x8000 = 0x8000,

        SpellCastSpecific = 0x10000,
        SpellHit = 0x20000,
        SpellCriticalHit = 0x40000,
        ProcFlag0x80000 = 0x80000,

        AnyDamage = 0x100000,
        TrapTriggered = 0x200000,
        AutoShotHit = 0x400000,
        Absorb = 0x800000
    }


    [Flags]
    public enum CorpseFlags
    {
        None = 0,
        Bones = 0x5,
    }

    [Flags]
    public enum CorpseDynamicFlags
    {
        None = 0,
        /// <summary>
        /// "Sparks" emerging from the Corpse
        /// </summary>
        PlayerLootable = 0x1
    }

    public enum StatType
    {
        Strength = 0,
        Agility = 1,
        Stamina = 2,
        Intellect = 3,
        Spirit = 4,
        None = 0xFFFFFFF
    }

    /// <summary>
    /// Item modifiers
    /// </summary>
    public enum ItemModType
    {
        None = -1,
        Power = 0,
        Health = 1,
        /// <summary>
        /// Unused
        /// </summary>
        Unused = 2,
        Agility = 3,
        Strength = 4,
        Intellect = 5,
        Spirit = 6,
        Stamina = 7,

        WeaponSkillRating = 11,
        DefenseRating = 12,
        DodgeRating = 13,
        ParryRating = 14,
        BlockRating = 15,
        /// <summary>
        /// Unused
        /// </summary>
        MeleeHitRating = 16,
        /// <summary>
        /// Unused
        /// </summary>
        RangedHitRating = 17,
        SpellHitRating = 18,
        MeleeCriticalStrikeRating = 19,
        RangedCriticalStrikeRating = 20,
        SpellCriticalStrikeRating = 21,
        /// <summary>
        /// Unused
        /// </summary>
        MeleeHitAvoidanceRating = 22,
        /// <summary>
        /// Unused
        /// </summary>
        RangedHitAvoidanceRating = 23,
        /// <summary>
        /// Unused
        /// </summary>
        SpellHitAvoidanceRating = 24,
        /// <summary>
        /// Unused (see Resilience)
        /// </summary>
        MeleeCriticalAvoidanceRating = 25,
        /// <summary>
        /// Unused (see Resilience)
        /// </summary>
        RangedCriticalAvoidanceRating = 26,
        /// <summary>
        /// Unused (see Resilience)
        /// </summary>
        SpellCriticalAvoidanceRating = 27,
        MeleeHasteRating = 28,
        RangedHasteRating = 29,
        SpellHasteRating = 30,
        /// <summary>
        /// Melee and Ranged HitRating (no SpellHitRating)
        /// </summary>
        HitRating = 31,

        CriticalStrikeRating = 32,
        /// <summary>
        /// Unused
        /// </summary>
        HitAvoidanceRating = 33,
        /// <summary>
        /// Unused (see Resilience)
        /// </summary>
        CriticalAvoidanceRating = 34,
        ResilienceRating = 35,
        HasteRating = 36,
        ExpertiseRating = 37,
        End
    }

    [Flags]
    public enum PetState
    {
        /*CannotRename = 0x2,
        CanRename = 0x3,*/
        CanBeRenamed = 0x1,
        CanBeAbandoned = 0x2,
    }

    public enum ModifierMulti
    {
        Health = 0,
        Power,
        CritChance,
        RangedCritChance,
        AttackerCritChance,
        BlockChance,
        AttackTime,
        PowerRegen,
        HealthRegen,

        Strength,
        Agility,
        Stamina,
        Intellect,
        Spirit
    }

    public enum ModifierFlatInt
    {
        Health = 0,
        Power,

        /// <summary>
        /// Overall HealthRegen
        /// </summary>
        HealthRegen,
        /// <summary>
        /// HealthRegen during Combat
        /// </summary>
        HealthRegenInCombat,
        /// <summary>
        /// HealthRegen while not in Combat
        /// </summary>
        HealthRegenNoCombat,

        PowerRegen,

        RangedAttackPowerByPercentOfIntellect,

        DodgeRating
    }

    public enum GossipMenuItemType : byte
    {
        Talk = 0,
        Trade = 1,
        Taxi = 2,
        Train = 2,
        Ressurect = 3,
        Bind = 4,
        Bank = 5,
        Guild = 6,
        Tabard = 7,
        Battlefield = 8
    }




























    #region zh-CHS Item枚举 | en Item Enum
    /// <summary>
    /// Loot threshold
    /// </summary>
    public enum ItemQuality : byte
    {
        Poor = 0,
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5,
        Artifact = 6,
        End
    }

    /// <summary>
    /// Used in the ITEMFLAGS updatefield
    /// </summary>
    [Flags]
    public enum ItemFlags : uint
    {
        None = 0,

        Soulbound = 0x1, // PER ITEM, NOT PROTO

        /// <summary>
        /// Warlock/Mage stones, water etc
        /// </summary>
        Conjured = 0x2,

        /// <summary>
        /// Lockboxes, clams etc
        /// </summary>
        Openable = 0x4,

        GiftWrapped = 0x8, // PER ITEM, NOT PROTO

        /// <summary>
        /// Shaman totem tools
        /// </summary>
        Totem = 0x20,

        /// <summary>
        /// Items bearing a spell (Equip/Use/Proc etc) 
        /// </summary>
        TriggersSpell = 0x40,

        /// <summary>
        /// CHECK THIS
        /// </summary>
        NoEquipCooldown = 0x80,

        /// <summary>
        /// These items would appear to do ranged magical damage
        /// ITEM_FLAG_INTBONUSINSTEAD = 0x100
        /// </summary>
        Wand = 0x100,

        /// <summary>
        /// These items can wrap other items (wrapping paper)
        /// </summary>
        WrappingPaper = 0x200,

        /// <summary>
        /// These items produce other items when right clicked (motes, enchanting essences, darkmoon cards...)
        /// </summary>
        Producer = 0x400,

        /// <summary>
        /// Everyone in the group/raid can loot a copy of the item.
        /// </summary>
        MultiLoot = 0x800,

        /// <summary>
        /// ITEM_FLAG_BRIEFSPELLEFFECTS = 0x1000
        /// </summary>
        BriefSpellEffect = 0x1000,

        /// <summary>
        /// Guild charters
        /// </summary>
        Charter = 0x2000,

        /// <summary>
        /// "Right Click to Read"
        /// </summary>
        Readable = 0x4000,

        /// <summary>
        /// 
        /// </summary>
        PVPItem = 0x8000,

        /// <summary>
        /// Item expires after a certain amount of time
        /// </summary>
        Expires = 0x10000,

        /// <summary>
        /// Items a jewel crafter can prospect
        /// </summary>
        Prospectable = 0x40000,

        /// <summary>
        /// Items you can only have one of equipped, but multiple in your inventory
        /// </summary>
        UniqueEquipped = 0x80000,

        /// <summary>
        /// Lowers durability on cast (also contains deprecated throwing weapons)
        /// </summary>
        ThrownWeapon = 0x400000,
    }

    public enum ItemClass
    {
        None = -1,
        Consumable = 0,
        Container = 1,
        Weapon = 2,
        Jewelry = 3,
        Armor = 4,
        Reagent = 5,
        Projectile = 6,
        TradeGoods = 7,
        Generic = 8,
        Recipe = 9,
        Money = 10,
        Quiver = 11,
        Quest = 12,
        Key = 13,
        Permanent = 14,
        Miscellaneous = 15
    }

    public enum ItemSubClass
    {
        None = -1,
        // Weapon
        WeaponAxe = 0,
        WeaponTwoHandAxe = 1,
        WeaponBow = 2,
        WeaponGun = 3,
        WeaponMace = 4,
        WeaponTwoHandMace = 5,
        WeaponPolearm = 6,
        WeaponSword = 7,
        WeaponTwoHandSword = 8,
        WeaponFist = 13,
        WeaponDagger = 15,
        WeaponStaff = 10,
        WeaponMisc = 14,
        WeaponThrown = 16,
        WeaponCrossbow = 18,
        WeaponWand = 19,
        WeaponFishingPole = 20,

        // Armor
        ArmorMisc = 0,
        ArmorCloth = 1,
        ArmorLeather = 2,
        AmorMail = 3,
        ArmorPlate = 4,
        ArmorShield = 6,

        // Projectile
        ProjectileArrow = 2,
        ProjectileBullet = 3,

        // Trade goods
        ITEM_SUBCLASS_PROJECTILE_TRADE_GOODS = 0,
        ITEM_SUBCLASS_PROJECTILE_PARTS = 1,
        ITEM_SUBCLASS_PROJECTILE_EXPLOSIVES = 2,
        ITEM_SUBCLASS_PROJECTILE_DEVICES = 3,

        // Recipe
        ITEM_SUBCLASS_RECIPE_BOOK = 0,
        ITEM_SUBCLASS_RECIPE_LEATHERWORKING = 1,
        ITEM_SUBCLASS_RECIPE_TAILORING = 2,
        ITEM_SUBCLASS_RECIPE_ENGINEERING = 3,
        ITEM_SUBCLASS_RECIPE_BLACKSMITHING = 4,
        ITEM_SUBCLASS_RECIPE_COOKING = 5,
        ITEM_SUBCLASS_RECIPE_ALCHEMY = 6,
        ITEM_SUBCLASS_RECIPE_FIRST_AID = 7,
        ITEM_SUBCLASS_RECIPE_ENCHANTING = 8,
        ITEM_SUBCLASS_RECIPE_FISHING = 9,

        // Quiver
        AmmoPouch = 3,
        Quiver = 2,

        // Misc
        Junk = 0,
    }

    [Flags]
    public enum ItemSubClassMask : uint
    {
        None = 0,

        AnyMeleeWeapon = 0x2A5F3,
        AnyRangedWeapon = 0x4000C,

        WeaponAxe = 1,
        WeaponTwoHandAxe = 0x000000002,
        WeaponBow = 0x000000004,
        WeaponGun = 0x000000008,
        //WeaponMace = 0x000000008,
        WeaponPolearm = 0x000000010,
        WeaponTwoHandMace = 0x000000020,
        Shield = 0x000000040,
        WeaponOneHandSword = 0x00000080,
        WeaponTwoHandSword = 0x00000100,
        /// <summary>
        /// Only in: NotDisplayed Totem (Id: 27763)
        /// </summary>
        UnknownSubClass1 = 0x00000200,
        WeaponStaff = 0x00000400,
        WeaponFist = 0x00002000,
        WeaponDagger = 0x00008000,
        WeaponThrown = 0x00010000,
        UnknownSubClass2 = 0x00020000,
        WeaponCrossbow = 0x00040000,
    }

    public enum InventorySlotType
    {
        None = 0,
        Head = 1,
        Neck = 2,
        Shoulder = 3,
        Body = 4,
        Chest = 5,
        Waist = 6,
        Legs = 7,
        Feet = 8,
        Wrist = 9,
        Hand = 10,
        Finger = 11,
        Trinket = 12,
        Weapon = 13,
        Shield = 14,
        Ranged = 15,
        Cloak = 16,
        TwoHandWeapon = 17,
        Bag = 18,
        Tabard = 19,
        Robe = 20,
        WeaponMainHand = 21,
        WeaponOffHand = 22,
        Holdable = 23,
        Ammo = 24,
        Thrown = 25,
        RangedRight = 26,
        /// <summary>
        /// Ammo pouch
        /// </summary>
        Quiver = 27,
        Relic = 28,
    }

    [Flags]
    public enum InventorySlotMask
    {
        None = 0,
        Head = 0x002,
        Neck = 0x000004,
        Shoulder = 0x000008,
        Body = 0x000010,
        Chest = 0x000020,
        Waist = 0x00040,
        Legs = 0x00080,
        Feet = 0x000100,
        Wrist = 0x00200,
        Hand = 0x00400,
        Finger = 0x00800,
        Trinket = 0x01000,
        Weapon = 0x02000,
        Shield = 0x04000,
        Ranged = 0x08000,
        Cloak = 0x10000,
        TwoHandWeapon = 0x20000,
        Bag = 0x040000,
        Tabard = 0x080000,
        Robe = 0x00100000,
        WeaponMainHand = 0x00200000,
        WeaponOffHand = 0x00400000,
        Holdable = 0x00800000,
        Ammo = 0x01000000,
        Thrown = 0x02000000,
        RangedRight = 0x04000000,
        /// <summary>
        /// Ammo pouch
        /// </summary>
        Quiver = 0x08000000,
        Relic = 0x10000000
    }


    public enum EquipmentSlot : int
    {
        Invalid = -1,
        Head = 0,
        Neck = 1,
        Shoulders = 2,
        Shirt = 3,
        Chest = 4,
        Belt = 5,
        Pants = 6,
        Boots = 7,
        Wrist = 8,
        Gloves = 9,
        Finger1 = 10,
        Finger2 = 11,
        Trinket1 = 12,
        Trinket2 = 13,
        Back = 14,
        MainHand = 15,
        OffHand = 16,
        ExtraWeapon = 17,
        Tabard = 18,
        Bag1,
        Bag2,
        Bag3,
        BagLast,
        End
    }

    /// <summary>
    /// 
    /// </summary>
    public enum InventorySlot
    {
        /// <summary>
        /// Usually used for default container (Player Inventory) or Ammo
        /// </summary>
        Invalid = -1,
        Head = 0,
        Neck = 1,
        Shoulders = 2,
        Shirt = 3,
        Chest = 4,
        Belt = 5,
        Pants = 6,
        Boots = 7,
        Wrist = 8,
        Gloves = 9,
        Finger1 = 10,
        Finger2 = 11,
        Trinket1 = 12,
        Trinket2 = 13,
        Back = 14,
        MainHand = 15,
        OffHand = 16,
        ExtraWeapon = 17,
        Tabard = 18,

        Bag1 = 19,
        Bag2,
        Bag3,
        BagLast,

        BackPack1 = 23,
        BackPack2,
        BackPack3,
        BackPack4,
        BackPack5,
        BackPack6,
        BackPack7,
        BackPack8,
        BackPack9,
        BackPack10,
        BackPack11,
        BackPack12,
        BackPack13,
        BackPack14,
        BackPack15,
        /// <summary>
        /// BackPack16 (amount might change in the future)
        /// </summary>
        BackPackLast,

        Bank1 = 39,
        Bank2,
        Bank3,
        Bank4,
        Bank5,
        Bank6,
        Bank7,
        Bank8,
        Bank9,
        Bank10,
        Bank11,
        Bank12,
        Bank13,
        Bank14,
        Bank15,
        Bank16,
        Bank17,
        Bank18,
        Bank19,
        Bank20,
        Bank21,
        Bank22,
        Bank23,
        Bank24,
        Bank25,
        Bank26,
        Bank27,
        /// <summary>
        /// Bank28 (amount might change in the future)
        /// </summary>
        BankLast,

        BankBag1 = 67,
        BankBag2,
        BankBag3,
        BankBag4,
        BankBag5,
        BankBag6,
        /// <summary>
        /// BankBag7 (amount might change in the future)
        /// </summary>
        BankBagLast = 73,

        BuyBack1 = 74,
        BuyBack2,
        BuyBack3,
        BuyBack4,
        BuyBack5,
        BuyBack6,
        BuyBack7,
        BuyBack8,
        BuyBack9,
        BuyBack10,
        BuyBack11,
        /// <summary>
        /// BuyBack12 (amount might change in the future)
        /// </summary>
        BuyBackLast,

        // keyring keys
        Key1 = 86,
        Key2,
        Key3,
        Key4,
        Key5,
        Key6,
        Key7,
        Key8,
        Key9,
        Key10,
        Key11,
        Key12,
        Key13,
        Key14,
        Key15,
        Key16,
        Key17,
        Key18,
        Key19,
        Key20,
        Key21,
        Key22,
        Key23,
        Key24,
        Key25,
        Key26,
        Key27,
        Key28,
        Key29,
        Key30,
        Key31,
        /// <summary>
        /// Key32 (amount might change in the future)
        /// </summary>
        KeyLast,

        Count
    }

    public enum BagSlot : sbyte
    {
        Invalid = -1,
        Bag1 = 19,
        Bag2,
        Bag3,
        LastBag
    }

    public enum ItemBondType
    {
        None = 0,
        OnPickup = 1,
        OnEquip = 2,
        OnUse = 3,
        Quest = 4,
    }

    public enum ItemSpellTrigger
    {
        Use = 0,
        Equip = 1,
        ChanceOnHit = 2,

        /// <summary>
        /// Only used by: Glowing Sanctified Crystal (ID: 23442)
        /// To cast: Unsummon Sanctified Crystal (Id: 29343)
        /// </summary>
        Unsummon = 3,

        Soulstone = 4,

        /// <summary>
        /// Only used by 3 Quest Items; 
        /// each triggering a Dummy spell which seems to check for another requirement and -if given- allow something to happen
        /// </summary>
        Combo = 5,

        /// <summary>
        /// Casted once and then consumes the Item (usually teaching formulars, patterns, designs etc)
        /// </summary>
        Consume = 6
    }

    public enum ItemProjectileType
    {
        None = 0,
        /// <summary>
        /// Obsolete
        /// </summary>
        Bolts = 1,
        Arrows = 2,
        Bullets = 3,
        Thrown = 4
    }

    public enum ItemBagFamily
    {
        None = 0,
        Arrows = 1,
        Bullets = 2,
        SoulShards = 3,
        Leatherworking = 4,
        Unused = 5,
        Herbs = 6,
        Enchanting = 7,
        Engineering = 8,
        Keys = 9,
        Gems = 10,
        Mining = 11,
    }

    public enum InventoryError
    {
        /// <summary>
        /// If nothing else helps
        /// </summary>
        Invalid = -1,
        OK,
        /// <summary>
        /// Done
        /// </summary>
        YOU_MUST_REACH_LEVEL_N,
        /// <summary>
        /// Done
        /// </summary>
        SKILL_ISNT_HIGH_ENOUGH,
        /// <summary>
        /// Done
        /// </summary>
        ITEM_DOESNT_GO_TO_SLOT,
        /// <summary>
        /// Done
        /// </summary>
        BAG_FULL,
        /// <summary>
        /// Done
        /// </summary>
        NONEMPTY_BAG_OVER_OTHER_BAG,
        /// <summary>
        /// TODO: Missing
        /// </summary>
        CANT_TRADE_EQUIP_BAGS,
        /// <summary>
        /// Done
        /// </summary>
        ONLY_AMMO_CAN_GO_HERE,
        /// <summary>
        /// Done
        /// </summary>
        NO_REQUIRED_PROFICIENCY,
        /// <summary>
        /// Done
        /// </summary>
        NO_EQUIPMENT_SLOT_AVAILABLE,
        /// <summary>
        /// Done
        /// </summary>
        YOU_CAN_NEVER_USE_THAT_ITEM,
        /// <summary>
        /// Uncertain
        /// </summary>
        YOU_CAN_NEVER_USE_THAT_ITEM2,
        /// <summary>
        /// Uncertain
        /// </summary>
        NO_EQUIPMENT_SLOT_AVAILABLE2,
        /// <summary>
        /// Done
        /// </summary>
        CANT_EQUIP_WITH_TWOHANDED,
        /// <summary>
        /// Done
        /// </summary>
        CANT_DUAL_WIELD,
        /// <summary>
        /// TODO: Missing
        /// </summary>
        ITEM_DOESNT_GO_INTO_BAG,
        /// <summary>
        /// Uncertain
        /// </summary>
        ITEM_DOESNT_GO_INTO_BAG2,
        /// <summary>
        /// Consider Unique count
        /// 
        /// TODO: Missing
        /// </summary>
        CANT_CARRY_MORE_OF_THIS,
        /// <summary>
        /// Uncertain
        /// </summary>
        NO_EQUIPMENT_SLOT_AVAILABLE3,
        /// <summary>
        /// Uncertain
        /// </summary>
        ITEM_CANT_STACK,
        /// <summary>
        /// Done
        /// </summary>
        ITEM_CANT_BE_EQUIPPED,
        /// <summary>
        /// Done
        /// </summary>
        ITEMS_CANT_BE_SWAPPED,
        /// <summary>
        /// Uncertain
        /// </summary>
        SLOT_IS_EMPTY,
        /// <summary>
        /// Done
        /// </summary>
        ITEM_NOT_FOUND,
        /// <summary>
        /// Some Quest items cannot be dropped during the Quest itself
        /// 
        /// Done
        /// </summary>
        CANT_DROP_SOULBOUND,
        /// <summary>
        /// Uncertain
        /// </summary>
        OUT_OF_RANGE,
        /// <summary>
        /// Done
        /// </summary>
        TRIED_TO_SPLIT_MORE_THAN_COUNT,
        /// <summary>
        /// Done
        /// </summary>
        COULDNT_SPLIT_ITEMS,
        /// <summary>
        /// Uncertain
        /// </summary>
        MISSING_REAGENT,
        /// <summary>
        /// Done (Vendors)
        /// </summary>
        NOT_ENOUGH_MONEY,
        /// <summary>
        /// Done
        /// </summary>
        NOT_A_BAG,
        /// <summary>
        /// Done
        /// </summary>
        CAN_ONLY_DO_WITH_EMPTY_BAGS,
        /// <summary>
        /// Probably cannot take/use Items of Trade partners etc
        /// 
        /// TODO: Missing
        /// </summary>
        DONT_OWN_THAT_ITEM,
        /// <summary>
        /// TODO: Missing
        /// </summary>
        CAN_EQUIP_ONLY1_QUIVER,
        /// <summary>
        /// Done
        /// </summary>
        MUST_PURCHASE_THAT_BAG_SLOT,
        /// <summary>
        /// Done
        /// </summary>
        TOO_FAR_AWAY_FROM_BANK,
        /// <summary>
        /// Probably when trying to move an item while being disarmed
        /// 
        /// TODO: Missing
        /// </summary>
        ITEM_LOCKED,
        /// <summary>
        /// Done
        /// </summary>
        YOU_ARE_STUNNED,
        /// <summary>
        /// Done
        /// </summary>
        YOU_ARE_DEAD,
        /// <summary>
        /// Uncertain
        /// </summary>
        CANT_DO_RIGHT_NOW,
        /// <summary>
        /// Uncertain
        /// </summary>
        BAG_FULL2,
        /// <summary>
        /// Uncertain
        /// </summary>
        CAN_EQUIP_ONLY1_QUIVER2,
        /// <summary>
        /// TODO: Missing
        /// </summary>
        CAN_EQUIP_ONLY1_AMMOPOUCH,

        // wrappings are all missing
        STACKABLE_CANT_BE_WRAPPED,
        EQUIPPED_CANT_BE_WRAPPED,
        WRAPPED_CANT_BE_WRAPPED,
        BOUND_CANT_BE_WRAPPED,
        UNIQUE_CANT_BE_WRAPPED,
        BAGS_CANT_BE_WRAPPED,

        /// <summary>
        /// Done
        /// </summary>
        ALREADY_LOOTED,
        /// <summary>
        /// Done
        /// </summary>
        INVENTORY_FULL,
        /// <summary>
        /// Done
        /// </summary>
        BANK_FULL,
        /// <summary>
        /// See Vendors
        /// 
        /// TODO: Missing
        /// </summary>
        ITEM_IS_CURRENTLY_SOLD_OUT,
        /// <summary>
        /// Uncertain
        /// </summary>
        BAG_FULL3,
        /// <summary>
        /// Uncertain
        /// </summary>
        ITEM_NOT_FOUND2,
        /// <summary>
        /// Uncertain
        /// </summary>
        ITEM_CANT_STACK2,
        /// <summary>
        /// Uncertain
        /// </summary>
        BAG_FULL4,
        /// <summary>
        /// See Vendors
        /// 
        /// TODO: Missing
        /// </summary>
        ITEM_SOLD_OUT,
        /// <summary>
        /// Uncertain
        /// </summary>
        OBJECT_IS_BUSY,
        DontReport,
        /// <summary>
        /// Done
        /// </summary>
        CANT_DO_IN_COMBAT,
        /// <summary>
        /// Done
        /// </summary>
        CANT_DO_WHILE_DISARMED,
        /// <summary>
        /// Uncertain
        /// </summary>
        BAG_FULL6,
        /// <summary>
        /// Uncertain
        /// </summary>
        ITEM_RANK_NOT_ENOUGH,
        /// <summary>
        /// Probably Vendor-related
        /// 
        /// TODO: Missing
        /// </summary>
        ITEM_REPUTATION_NOT_ENOUGH,
        /// <summary>
        /// TODO: Missing
        /// </summary>
        MORE_THAN1_SPECIAL_BAG,
    }

    public enum EnchantmentSlot
    {
        Permanent = 0,
        Temporary = 1,
        Socket1 = 2,
        Socket2 = 3,
        Socket3 = 4,
        Bonus = 5,
        MaxInspected = 6, // ?

        PROP_ENCHANTMENT_SLOT_0 = 6,                        // used with RandomSuffix   (or have HELD enchantments)
        PROP_ENCHANTMENT_SLOT_1 = 7,                        // used with RandomSuffix   (or have HELD enchantments)
        PROP_ENCHANTMENT_SLOT_2 = 8,                        // used with RandomSuffix and RandomProperty
        PROP_ENCHANTMENT_SLOT_3 = 9,                        // used with RandomProperty (or have HELD enchantments)
        PROP_ENCHANTMENT_SLOT_4 = 10,                       // used with RandomProperty (or have HELD enchantments)
    }

    public enum PartialInventoryType
    {
        Equipment = 0,
        BackPack,
        EquippedContainers,
        Bank,
        BankBags,
        BuyBack,
        KeyRing,

        /// <summary>
        /// The amount of different PartialInventories
        /// </summary>
        Count
    }

    public enum SellItemError : byte
    {
        Unknown1 = 0x00,
        CantFindItem = 0x01,
        CantSellItem = 0x02,
        CantFindVendor = 0x03,
        PlayerDoesntOwnItem = 0x04,
        Unknown = 0x05,
        OnlyEmptyBag = 0x06
    }

    public enum BuyItemError : byte
    {
        CantFindItem = 0x00,
        ItemAlreadySold = 0x01,
        NotEnoughMoney = 0x02,
        Unknown1 = 0x03,
        SellerDoesntLikeYou = 0x04,
        DistanceTooFar = 0x05,
        Unknown2 = 0x06,
        ItemSoldOut = 0x07,
        CantCarryAnymore = 0x08,
        Unknown3 = 0x09,
        Unknown4 = 0x10,
        RankRequirementNotMet = 0x11,
        ReputationRequirementNotMet = 0x12
    }

    [Flags]
    public enum SocketColor : uint
    {
        None = 0,
        Meta = 1,
        Red = 2,

        Yellow = 4,

        Blue = 8,

    }
    #endregion



    /// <summary>
    /// Enum-definition automatically created by WCell's DBCEnumBuilder
    /// </summary>
    public enum SpellMechanic
    {
        None = 0,
        Charmed = 1,
        /// <summary>
        /// Makes you wander in circles, can't do anything
        /// </summary>
        Disoriented = 2,
        Disarmed = 3,
        Distracted = 4,
        Fleeing = 5,
        Clumsy = 6,
        Rooted = 7,
        Pacified = 8,
        Silenced = 9,
        Asleep = 10,
        Ensnared = 11,
        Stunned = 12,
        Frozen = 13,
        Incapacitated = 14,
        Bleeding = 15,
        Healing = 16,
        Polymorphed = 17,
        Banished = 18,
        Shielded = 19,
        Shackled = 20,
        Mounted = 21,
        Seduced = 22,
        Turned = 23,
        Horrified = 24,
        Invulnerable = 25,
        Interrupted = 26,
        Dazed = 27
    }

    public enum DispelType
    {
        Trinkets = -1,
        None = 0,
        Magic = 1,
        Curse = 2,
        Disease = 3,
        Poison = 4,
        Stealth = 5,
        Invisibility = 6,
        All = 7,

        Frenzy = 9
    };
}
