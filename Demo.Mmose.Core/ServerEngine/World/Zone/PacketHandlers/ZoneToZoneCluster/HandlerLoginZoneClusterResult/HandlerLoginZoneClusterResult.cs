#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Diagnostics;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
#endregion

namespace Demo.Mmose.Core.World.Zone
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ZonePacketHandlers : BasePacketHandlers
    {
        #region zh-CHS Zone_LoginZoneClusterResult - 数据处理 | en Zone_LoginZoneClusterResult - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void Zone_HandlerLoginZoneClusterResult( NetState netState, PacketReader packetReader )
        {
            Zone_ConnecterExtendData extendData = netState.GetComponent<Zone_ConnecterExtendData>( Zone_ConnecterExtendData.COMPONENT_ID );
            if ( extendData == null )
                throw new Exception( "Zone_PacketHandlers.Zone_HandlerLoginZoneClusterResult(...) - extendData == null error!" );

            if ( extendData.IsLoggedIn == true )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "Zone_PacketHandlers.Zone_HandlerLoginZoneClusterResult(...) - extendData.IsLoggedIn == true error!" );
                return;
            }

            LoginZoneClusterResult loginZoneClusterResult = LoginZoneClusterResult.GetLoginZoneClusterResult( packetReader );
            if ( loginZoneClusterResult.IsCheckPass )
            {
                LOGs.WriteLine( LogMessageType.MSG_INFO, "ZoneWorld：登陆ZoneCluster服务器 成功！" );

                extendData.IsLoggedIn = true;
            }
        }
        #endregion
    }
}
#endregion