using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography;
using Demo.Mmose.Collections;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.Common;

namespace Demo.Wow.WorldServer.Network
{
    internal partial class RealmPacketHandlers : BasePacketHandlers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void Realm_HandleRequestSessionResult( NetState netState, PacketReader packetReader )
        {
            RealmExtendData extendData = netState.GetComponent<RealmExtendData>( RealmExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandleRequestSessionResult(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandleRequestSessionResult(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            uint iSerial = packetReader.ReadUInt32();

            NetState worldNetState = PendingLogins.GetAuthenticate( iSerial );
            if ( worldNetState == null )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandleRequestSessionResult(...) - sendNetState == null error!" );
                return;
            }
            PendingLogins.RemoveAuthenticate( iSerial );

            WorldPacketHandlers.InternalCallbackAuthenticate( worldNetState, packetReader );
        }
    }
}
