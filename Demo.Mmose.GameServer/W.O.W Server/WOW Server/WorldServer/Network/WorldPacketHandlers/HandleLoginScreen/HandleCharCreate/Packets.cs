using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Word_CharCreateResponse 类 | en Word_CharCreateResponse Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_CharCreateResponse : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_CharCreateResponse(  )
            : base( (long)WordOpCode.SMSG_CHAR_CREATE, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );              // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_CHAR_CREATE );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)ResponseCodes.CHAR_CREATE_SUCCESS );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_CharCreateResponseError 类 | en Word_CharCreateResponseError Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_CharCreateResponseError : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_CharCreateResponseError( byte errorInfo )
            : base( (long)WordOpCode.SMSG_CHAR_CREATE, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );              // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_CHAR_CREATE );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)errorInfo );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion
}
