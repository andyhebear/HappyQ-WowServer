using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Word_AuthResponse 类 | en Word_AuthResponse Class
    /// <summary>
    /// Realm_PacketHandlers.Realm_HandleRequestSessionResult(...)中处理
    /// </summary>
    internal sealed class Word_RealmSplitStateRequest : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_RealmSplitStateRequest( uint iUnknown )
            : base( (long)WordOpCode.SMSG_REALM_SPLIT_STATE_RESPONSE, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                   // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_REALM_SPLIT_STATE_RESPONSE );  // ID
            //////////////////////////////////////////////////////////////////////////

            //WriterStream.Write( (uint)iUnknown );
            //WriterStream.Write( (uint)0 );

            //WriterStream.WriteUTF8Null( "01/01/01" );

            byte[] nnn = new byte[] {
                0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x30, 0x31, 0x2F, 0x30, 0x31, 0x2F, 0x30, 0x31, 0x00,
            };

            WriterStream.Write( nnn, 0, nnn.Length );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

}
