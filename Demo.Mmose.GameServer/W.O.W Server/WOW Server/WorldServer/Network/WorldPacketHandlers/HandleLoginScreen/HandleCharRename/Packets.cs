using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Word_CharRenameResponse 类 | en Word_CharRenameResponse Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_CharRenameResponse : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_CharRenameResponse ()
            : base( (long)WordOpCode.SMSG_CHAR_RENAME, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_CHAR_RENAME );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)ResponseCodes.RESPONSE_SUCCESS );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_CharRenameResponseError 类 | en Word_CharRenameResponseError Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_CharRenameResponseError : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_CharRenameResponseError ( byte errorInfo )
            : base( (long)WordOpCode.SMSG_CHAR_RENAME, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_CHAR_RENAME );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)errorInfo );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion
}
