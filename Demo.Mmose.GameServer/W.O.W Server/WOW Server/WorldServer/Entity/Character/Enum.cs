using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class WowGender
    {
        public const byte Male = 0;
        public const byte Female = 1;
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowClasse
    {
        public const byte Warrior = 1;
        public const byte Paladin = 2;
        public const byte Hunter = 3;
        public const byte Rogue = 4;
        public const byte Priest = 5;
        public const byte Shaman = 7;
        public const byte Mage = 8;
        public const byte Warlock = 9;
        public const byte Druid = 11;
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowRace
    {
        public const byte Human = 1;
        public const byte Orc = 2;
        public const byte Dwarf = 3;
        public const byte Nightelf = 4;
        public const byte Undead = 5;
        public const byte Tauren = 6;
        public const byte Gnome = 7;
        public const byte Troll = 8;
        public const byte BloodElf = 10;
        public const byte Draenei = 11;
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowTeam
    {
        public const byte ALLIANCE = 1;
        public const byte HORDE = 2;
        public const byte ALLIANCE_FORCES = 3;
        public const byte HORDE_FORCES = 4;
        public const byte STEAMWHEEDLE_CARTEL = 5;
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowFactionRating
    {
        Hated = 1,
        Hostile = 2,
        Unfriendly = 3,
        Neutral = 4,
        Friendly = 5,
        Honored = 6,
        Revered = 7,
        Exalted = 8,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum WowFactionFlag
    {
        FactionFlagVisible = 0x01,
        FactionFlagAtWar = 0x02,
        FactionFlagUnknown = 0x04,
        FactionFlagInvisible = 0x08,
        FactionFlagOwnTeam = 0x10,
        FactionFlagInactive = 0x20,
    }
}