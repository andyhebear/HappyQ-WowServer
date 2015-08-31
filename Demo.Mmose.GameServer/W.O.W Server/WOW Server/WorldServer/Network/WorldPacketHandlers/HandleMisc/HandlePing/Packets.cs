using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Word_CharEnumResponse ¿‡ | en Word_CharEnumResponse Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_Pong : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_Pong( uint iPing )
            : base( (long)WordOpCode.SMSG_PONG, 0 )
        {
            WriterStream.Write( (ushort)ByteOrder.NetToHost( 6 ) /* 2 + 4 */ );         // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_PONG );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)iPing );
        }
    }
    #endregion
}
