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
    internal sealed class Word_ChannelNumMembersQueryResponse : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_ChannelNumMembersQueryResponse( string strChannelName, byte bFlags, uint uiNumMembers )
            : base( (long)WordOpCode.SMSG_CHANNEL_NUM_MEMBERS_QUERY_RESPONSE, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );              // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_CHANNEL_NUM_MEMBERS_QUERY_RESPONSE );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.WriteUTF8Null( strChannelName );
            WriterStream.Write( (byte)bFlags );
            WriterStream.Write( (uint)uiNumMembers );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

}
