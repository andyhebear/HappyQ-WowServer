using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
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
        internal static void World_HandleRealmSplitStateRequest( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_HACK, "World_HandleRealmSplitStateRequest...... {0} ", packetReader.Size );

            WorldExtendData extendData = netState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleRealmSplitStateRequest(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleRealmSplitStateRequest(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 10 /*ProcessNet.WORLD_HEAD_SIZE + 0*/)
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleRealmSplitStateRequest(...) - extendData.Size < 10 error!" );
                return;
            }

            uint iUnknown = packetReader.ReadUInt32();

            netState.Send( new Word_RealmSplitStateRequest( iUnknown ) );
            //netState.Send( new Word_CharEnumResponse( new WowCharacterInfo[0] ) );
        }
    }
}
