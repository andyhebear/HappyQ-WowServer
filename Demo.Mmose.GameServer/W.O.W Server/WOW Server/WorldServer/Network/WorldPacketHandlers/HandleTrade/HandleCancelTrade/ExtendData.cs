using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal class TRADE_STATUS
    {
        public const uint TRADE_STATUS_PLAYER_BUSY = 0x00;
        public const uint TRADE_STATUS_PROPOSED = 0x01;
        public const uint TRADE_STATUS_INITIATED = 0x02;
        public const uint TRADE_STATUS_CANCELLED = 0x03;
        public const uint TRADE_STATUS_ACCEPTED = 0x04;
        public const uint TRADE_STATUS_ALREADY_TRADING = 0x05;
        public const uint TRADE_STATUS_PLAYER_NOT_FOUND = 0x06;
        public const uint TRADE_STATUS_STATE_CHANGED = 0x07;
        public const uint TRADE_STATUS_COMPLETE = 0x08;
        public const uint TRADE_STATUS_UNACCEPTED = 0x09;
        public const uint TRADE_STATUS_TOO_FAR_AWAY = 0x0A;
        public const uint TRADE_STATUS_WRONG_FACTION = 0x0B;
        public const uint TRADE_STATUS_FAILED = 0x0C;
        public const uint TRADE_STATUS_DEAD = 0x0D;
        public const uint TRADE_STATUS_PETITION = 0x0E;
        public const uint TRADE_STATUS_PLAYER_IGNORED = 0x0F;
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed partial class WorldExtendData : IPacketEncoder
    {

    }
}
