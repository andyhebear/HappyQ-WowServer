using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Word_TradeStatus 类 | en Word_TradeStatus Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_TradeStatus : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_TradeStatus( uint uiTradeStatus )
            : base( (long)WordOpCode.SMSG_TRADE_STATUS, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );              // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_TRADE_STATUS );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)uiTradeStatus );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion
}
