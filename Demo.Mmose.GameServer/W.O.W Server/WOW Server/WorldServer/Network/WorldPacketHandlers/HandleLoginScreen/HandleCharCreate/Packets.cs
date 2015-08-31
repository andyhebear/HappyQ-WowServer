using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Word_CharCreateResponse �� | en Word_CharCreateResponse Class
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
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size����Ĵ�С*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_CharCreateResponseError �� | en Word_CharCreateResponseError Class
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
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size����Ĵ�С*/ ) ) );
        }
    }
    #endregion
}
