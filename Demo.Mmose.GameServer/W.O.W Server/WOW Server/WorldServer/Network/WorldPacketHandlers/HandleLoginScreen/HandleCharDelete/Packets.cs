using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Word_CharDeleteResponse 类 | en Word_CharDeleteResponse Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_CharDeleteResponse : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_CharDeleteResponse ()
            : base( (long)WordOpCode.SMSG_CHAR_DELETE, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_CHAR_DELETE );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)ResponseCodes.CHAR_DELETE_SUCCESS );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_CharDeleteResponseError 类 | en Word_CharDeleteResponseError Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_CharDeleteResponseError : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_CharDeleteResponseError ( byte errorInfo )
            : base( (long)WordOpCode.SMSG_CHAR_DELETE, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_CHAR_DELETE );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)errorInfo );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion
}
