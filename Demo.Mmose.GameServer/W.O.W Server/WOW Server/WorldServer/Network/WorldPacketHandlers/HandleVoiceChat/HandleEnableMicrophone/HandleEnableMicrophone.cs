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
        internal static void World_HandleEnableMicrophone( NetState netState, PacketReader packetReader )
        {
            WorldExtendData extendData = netState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleEnableMicrophone(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleEnableMicrophone(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            bool bVoiceEnabled = packetReader.ReadBoolean();
            bool bMicEnabled = packetReader.ReadBoolean();
        }
    }
}
