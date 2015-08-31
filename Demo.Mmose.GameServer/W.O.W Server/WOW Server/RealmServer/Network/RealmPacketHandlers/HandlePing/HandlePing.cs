using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

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
        public static void Realm_HandlePing( NetState netState, PacketReader packetReader )
        {
            RealmExtendData extendData = netState.GetComponent<RealmExtendData>( RealmExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandlePing(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandlePing(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            netState.Send( new Realm_Pong() );
        }
    }
}
