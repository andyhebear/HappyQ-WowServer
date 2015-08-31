using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.RealmServer.Network
{
    #region zh-CHS Realm_RegisterRealmResult Àà | en Realm_RegisterRealmResult Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Realm_RegisterRealmResult : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Realm_RegisterRealmResult( long iRealmID )
            : base( (long)RealmOpCode.CMSG_REGISTER_REALM_RESULT, 7 /* ProcessNet.REALM_HEAD_SIZE + 4 */ )
        {
            WriterStream.Write( (byte)RealmOpCode.CMSG_REGISTER_REALM_RESULT );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)4 );                                       // ×Ö¶ÎÊ£Óà´óÐ¡

            WriterStream.Write( (uint)iRealmID );
        }
    }
    #endregion
}
