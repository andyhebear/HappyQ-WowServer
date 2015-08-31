using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Wow.Common;
using Demo.Wow.RealmServer.Common;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class Realm_PacketHandlers : BasePacketHandlers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void Realm_HandleRegisterRealm( NetState netState, PacketReader packetReader )
        {
            RealmExtendData extendData = netState.GetComponent<RealmExtendData>( RealmExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandleRegisterRealm(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == true )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandleRegisterRealm(...) - extendData.IsLoggedIn == true error!" );
                return;
            }

            Realm realm = new Realm();

            realm.Name = packetReader.ReadUTF8String();
            realm.Address = packetReader.ReadUTF8String();

            string strIcon = packetReader.ReadUTF8String();
            if ( Insensitive.Equals( strIcon, "PVP" ) )
                realm.Icon = (uint)RealmIconType.REALMTYPE_PVP;
            else if ( Insensitive.Equals( strIcon, "RP" ) )
                realm.Icon = (uint)RealmIconType.REALMTYPE_RP;
            else if ( Insensitive.Equals( strIcon, "RPPVP" ) )
                realm.Icon = (uint)RealmIconType.REALMTYPE_RPPVP;
            else
                realm.Icon = (uint)RealmIconType.REALMTYPE_NORMAL;

            realm.Colour = packetReader.ReadUInt32();
            realm.TimeZone = packetReader.ReadUInt32();
            realm.Population = packetReader.ReadFloat();

            extendData.RequestSession.Serial = RealmHandler.RealmsExclusiveSerial.GetExclusiveSerial();

            // Add to the main realm list
            RealmHandler.AddRealm( extendData.RequestSession.Serial, realm );

            extendData.IsLoggedIn = true;

            // Send back response packet.
            netState.Send( new Realm_RegisterRealmResult( extendData.RequestSession.Serial ) );
        }
    }
}
