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
using System.Collections.Generic;
#endregion

namespace Demo.Mmose.Core.World.Zone
{
    /// <summary>
    /// 
    /// </summary>
    public static class ZoneOpCodeName
    {
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<long, string> s_ZoneOpCodeName = new Dictionary<long, string>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iOpCode"></param>
        public static string GetZoneOpCodeName( long iOpCode )
        {
            string strWordOpCodeName = string.Empty;

            if ( s_ZoneOpCodeName.TryGetValue( iOpCode, out strWordOpCodeName ) == true )
                return strWordOpCodeName;
            else
                return "Unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitZoneOpCodeName()
        {
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeToZoneCluster.CMSG_LOGIN_ZONE_CLUSTER, "CMSG_LOGIN_ZONE_CLUSTER" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeToZoneCluster.CMSG_ADD_CURRENT_ZONE, "CMSG_ADD_CURRENT_ZONE" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeToZoneCluster.CMSG_REMOVE_CURRENT_ZONE, "CMSG_REMOVE_CURRENT_ZONE_FROM_ZONE_CLUSTER" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeToZoneCluster.CMSG_PING_ZONE_CLUSTER, "CMSG_PING_ZONE_CLUSTER" );

            s_ZoneOpCodeName.Add( (long)ZoneOpCodeToZoneCluster.SMSG_LOGIN_ZONE_CLUSTER_RESULT, "SMSG_LOGIN_ZONE_RESULT" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeToZoneCluster.SMSG_ADD_CURRENT_ZONE_RESULT, "SMSG_NOTIFY_ADD_CURRENT_ZONE_RESULT" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeToZoneCluster.SMSG_REMOVE_CURRENT_ZONE_RESULT, "SMSG_NOTIFY_REMOVE_CURRENT_ZONE_RESULT" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeToZoneCluster.SMSG_PONG_ZONE_CLUSTER, "SMSG_PONG_ZONE_CLUSTER" );



            s_ZoneOpCodeName.Add( (long)ZoneOpCodeFromZoneCluster.SMSG_LOGIN_ZONE, "SMSG_LOGIN_ZONE" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeFromZoneCluster.SMSG_NOTIFY_ADD_ZONE, "SMSG_NOTIFY_ADD_ZONE" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeFromZoneCluster.SMSG_NOTIFY_REMOVE_ZONE, "SMSG_NOTIFY_REMOVE_ZONE" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeFromZoneCluster.SMSG_PING_ZONE, "SMSG_PING_ZONE" );

            s_ZoneOpCodeName.Add( (long)ZoneOpCodeFromZoneCluster.CMSG_LOGIN_ZONE_CLUSTER_RESULT, "CMSG_LOGIN_ZONE_CLUSTER_RESULT" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeFromZoneCluster.CMSG_NOTIFY_ADD_ZONE_RESULT, "CMSG_NOTIFY_ADD_ZONE_RESULT" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeFromZoneCluster.CMSG_NOTIFY_REMOVE_ZONE_RESULT, "CMSG_NOTIFY_REMOVE_ZONE_RESULT" );
            s_ZoneOpCodeName.Add( (long)ZoneOpCodeFromZoneCluster.CMSG_PONG_ZONE, "SMSG_PONG_ZONE" );
        }
    }
}
#endregion