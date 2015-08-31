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
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.World.ZoneClusterWorld
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ZoneClusterPacketHandlers : BasePacketHandlers
    {
        #region zh-CHS ZoneCluster_HandlerLoginZoneCluster - 数据处理 | en ZoneCluster_HandlerLoginZoneCluster - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void ZoneCluster_HandlerLoginZoneCluster( NetState netState, PacketReader packetReader )
        {
            ZoneCluster_ListenerExtendData extendData = netState.GetComponent<ZoneCluster_ListenerExtendData>( ZoneCluster_ListenerExtendData.COMPONENT_ID );
            if ( extendData == null )
                throw new Exception( "ZoneCluster_PacketHandlers.ZoneCluster_HandlerLoginZoneCluster(...) - extendData == null error!" );

            if ( extendData.IsLoggedIn == true )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "ZoneCluster_PacketHandlers.ZoneCluster_HandlerLoginZoneCluster(...) - extendData.IsLoggedIn == true error!" );
                return;
            }

            string strZoneClusterPassword = packetReader.ReadUTF8String();
            string strZoneOrDomainPassword = packetReader.ReadUTF8String();

            if ( extendData.ConfigZoneCluster.ZoneClusterPassword == strZoneClusterPassword )
            {
                extendData.IsLoggedIn = true;

                // 检查是 Domain 服务端登陆 还是 Zone客户端登陆
                if ( extendData.ConfigZoneCluster.DomainPassword == strZoneOrDomainPassword )
                    extendData.IsDomainServer = true;
                else
                    extendData.IsZoneServer = true;

                extendData.ServerPassword = strZoneOrDomainPassword;
            }

            netState.Send( new ZoneCluster_LoginZoneClusterResult( extendData.IsLoggedIn ) );
        }
        #endregion
    }
}
#endregion