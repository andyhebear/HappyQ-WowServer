using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Network
{
    internal partial class RealmPacketHandlers : BasePacketHandlers
    {
        #region zh-CHS Realm_Pong - 数据处理 | en Realm_Pong - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void Realm_HandlePong( NetState netState, PacketReader packetReader )
        {
            RealmExtendData extendData = netState.GetComponent<RealmExtendData>( RealmExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandlePong(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandlePong(...) - extendData.IsLoggedIn == false error!" );
                return;
            }
        }
        #endregion
    }
}
