using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Wow.RealmServer.Common;
using Demo.Mmose.Core.Common.Srp;

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
        public static void Realm_HandleRequestSession( NetState netState, PacketReader packetReader )
        {
            RealmExtendData extendData = netState.GetComponent<RealmExtendData>( RealmExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandleRequestSession(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandleRequestSession(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            uint iSerial = packetReader.ReadUInt32();
            string strAccountName = packetReader.ReadUTF8StringSafe();

            WowAccount wowAccount = WowAccountHandler.GetAccount( strAccountName );
            if ( wowAccount == null )
            {
                netState.Send( new Realm_RequestSessionResultError( iSerial ) );
                return;
            }

            SecureRemotePassword srp = SrpHandler.GetSRP( strAccountName );
            if ( srp == null )
            {
                netState.Send( new Realm_RequestSessionResultError( iSerial ) );
                return;
            }

            netState.Send( new Realm_RequestSessionResult( iSerial, wowAccount, srp ) );
        }
    }
}
