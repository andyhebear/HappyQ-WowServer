using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Realm_RequestSession 类 | en Realm_RequestSession Class
    /// <summary>
    /// 在World_PacketHandlers.World_HandleAuthSession(...)中处理
    /// </summary>
    internal sealed class Realm_RequestSession : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Realm_RequestSession( long iLoginId, string strAccountName )
            : base( (long)RealmOpCode.SMSG_REQUEST_SESSION, 0 )
        {
            WriterStream.Write( (byte)RealmOpCode.SMSG_REQUEST_SESSION );
            WriterStream.Write( (ushort)0 );
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)iLoginId );
            WriterStream.WriteUTF8Null( strAccountName );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 1, SeekOrigin.Begin );
            WriterStream.Write( (ushort)( WriterStream.Length - ProcessNet.REALM_HEAD_SIZE ) );
        }
    }
    #endregion
}
