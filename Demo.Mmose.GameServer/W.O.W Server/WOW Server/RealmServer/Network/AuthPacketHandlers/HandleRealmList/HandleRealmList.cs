using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class Auth_PacketHandlers : BasePacketHandlers
    {
        /// <summary>
        /// 列表服务
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void Auth_HandleRealmList( NetState netState, PacketReader packetReader )
        {
            AuthExtendData extendData = netState.GetComponent<AuthExtendData>( AuthExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "Auth_PacketHandlers.Auth_HandleRealmList(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "Auth_PacketHandlers.Auth_HandleRealmList(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            if ( extendData.IsAuthenticated == false )
            {
                Debug.WriteLine( "Auth_PacketHandlers.Auth_HandleRealmList(...) - extendData.IsAuthenticated == false error!" );
                return;
            }

            byte iCommandID = packetReader.ReadByte();
            uint iUnk = packetReader.ReadUInt32();

            netState.Send( new Auth_RealmListResult() );
        }
    }
}
