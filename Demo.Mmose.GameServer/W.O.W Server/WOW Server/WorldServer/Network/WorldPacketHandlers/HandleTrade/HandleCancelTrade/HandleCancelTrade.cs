using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class WorldPacketHandlers : BasePacketHandlers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void World_HandleCancelTrade( NetState netState, PacketReader packetReader )
        {
            WorldExtendData extendData = netState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleCancelTrade(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleCancelTrade(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            netState.Send( new Word_TradeStatus( TRADE_STATUS.TRADE_STATUS_CANCELLED ) );
        }
    }
}
