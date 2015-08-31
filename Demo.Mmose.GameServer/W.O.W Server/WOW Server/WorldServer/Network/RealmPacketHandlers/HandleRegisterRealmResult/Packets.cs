using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Realm_Ping ¿‡ | en Realm_Ping Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Realm_Ping : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Realm_Ping()
            : base( (long)RealmOpCode.SMSG_PING, 0 /* 3 + 0 */)
        {
            WriterStream.Write( (byte)RealmOpCode.SMSG_PING );
            WriterStream.Write( (ushort)0 );
            //////////////////////////////////////////////////////////////////////////
        }
    }
    #endregion
}
