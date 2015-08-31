using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Wow.Common;
using Demo.Wow.RealmServer.Common;

namespace Demo.Wow.RealmServer.Network
{
    #region zh-CHS Auth_RealmListResult 类 | en Auth_RealmListResult Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Auth_RealmListResult : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Auth_RealmListResult()
            : base( (long)AuthOpCode.CMSG_REALM_LIST_RESULT, 0 )
        {
            WriterStream.Write( (byte)AuthOpCode.CMSG_REALM_LIST_RESULT );
            WriterStream.Write( (ushort)0 );
            //////////////////////////////////////////////////////////////////////////

            // dunno what this is..
            WriterStream.Write( (uint)0 );

            Realm[] realmArrray = RealmHandler.RealmsToArray();

            WriterStream.Write( (ushort)realmArrray.Length );

            foreach ( Realm itemRealm in realmArrray )
            {
                WriterStream.Write( (byte)itemRealm.Colour );
                WriterStream.Write( (byte)0 );                       // Locked Flag. if 1, then realm locked. if 2, then realm is offline
                WriterStream.Write( (byte)itemRealm.Icon );

                WriterStream.WriteUTF8Null( itemRealm.Name );
                WriterStream.WriteUTF8Null( itemRealm.Address );

                WriterStream.Write( (float)itemRealm.Population );   //this is population 0.5 = low 1.0 = medium 2.0 high     (float)(maxplayers / players)*2
                WriterStream.Write( (byte)0 );                       // Character Count 在这个服务器内创建的人物数量
                WriterStream.Write( (byte)itemRealm.TimeZone );      // time zone
                WriterStream.Write( (byte)0 );                       // unk, may be realm number/id?
            }

            WriterStream.Write( (byte)0x15 );
            WriterStream.Write( (byte)0 );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 1, SeekOrigin.Begin );
            WriterStream.Write( (ushort)( WriterStream.Length - 3 ) );
        }
    }
    #endregion
}
