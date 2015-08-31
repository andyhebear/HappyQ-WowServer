using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.Server;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Realm_LoginRealmServer ¿‡ | en Realm_LoginRealmServer Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Realm_LoginRealmServer : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Realm_LoginRealmServer()
            : base( (long)RealmOpCode.SMSG_REGISTER_REALM, 0 )
        {
            WriterStream.Write( (byte)RealmOpCode.SMSG_REGISTER_REALM );
            WriterStream.Write( (ushort)0 );
            //////////////////////////////////////////////////////////////////////////

            WriterStream.WriteUTF8Null( ProcessServer.ConfigInfo.WowConfig.WorldName );
            WriterStream.WriteUTF8Null( ProcessServer.ConfigInfo.WowConfig.WorldServerHost + ":" + ProcessServer.ConfigInfo.WowConfig.WorldServerPort.ToString() );
            WriterStream.WriteUTF8Null( ProcessServer.ConfigInfo.WowConfig.Icon );
            WriterStream.Write( (uint)ProcessServer.ConfigInfo.WowConfig.Colour );
            WriterStream.Write( (uint)ProcessServer.ConfigInfo.WowConfig.TimeZone );
            WriterStream.Write( (float)ProcessServer.ConfigInfo.WowConfig.Population );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 1, SeekOrigin.Begin );
            WriterStream.Write( (ushort)( WriterStream.Length - ProcessNet.REALM_HEAD_SIZE ) );
        }
    }
    #endregion
}
