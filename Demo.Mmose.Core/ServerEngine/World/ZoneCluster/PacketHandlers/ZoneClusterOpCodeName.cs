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

namespace Demo.Mmose.Core.World.ZoneClusterWorld
{
    /// <summary>
    /// 
    /// </summary>
    public static class ZoneClusterOpCodeName
    {
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<long, string> s_ZoneClusterOpCodeName = new Dictionary<long, string>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iOpCode"></param>
        public static string GetZoneClusterOpCodeName( long iOpCode )
        {
            string strWordOpCodeName = string.Empty;

            if ( s_ZoneClusterOpCodeName.TryGetValue( iOpCode, out strWordOpCodeName ) == true )
                return strWordOpCodeName;
            else
                return "Unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitZoneClusterOpCodeName()
        {
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeToZone.SMSG_LOGIN_ZONE_RESULT, "SMSG_LOGIN_ZONE_RESULT" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeToZone.SMSG_NOTIFY_ADD_ZONE_RESULT, "SMSG_NOTIFY_ADD_ZONE_RESULT" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeToZone.SMSG_NOTIFY_REMOVE_ZONE_RESULT, "SMSG_NOTIFY_REMOVE_ZONE_RESULT" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeToZone.SMSG_PONG_ZONE, "SMSG_PONG_ZONE" );

            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeToDomain.SMSG_LOGIN_DOMAIN_RESULT, "SMSG_LOGIN_DOMAIN_RESULT" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeToDomain.SMSG_ADD_CURRENT_ZONE_CLUSTER_RESULT, "SMSG_ADD_CURRENT_ZONE_CLUSTER_RESULT" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeToDomain.SMSG_REMOVE_CURRENT_ZONE_CLUSTER_RESULT, "SMSG_REMOVE_CURRENT_ZONE_CLUSTER_RESULT" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeToDomain.SMSG_PONG_DOMAIN, "SMSG_PONG_DOMAIN" );



            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeFromZone.SMSG_LOGIN_ZONE_CLUSTER, "SMSG_LOGIN_ZONE_CLUSTER" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeFromZone.SMSG_ADD_CURRENT_ZONE, "SMSG_ADD_CURRENT_ZONE" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeFromZone.SMSG_REMOVE_CURRENT_ZONE, "SMSG_REMOVE_CURRENT_ZONE" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeFromZone.SMSG_ZONE_PING_ZONE_CLUSTER, "SMSG_ZONE_PING_ZONE_CLUSTER" );

            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeFromDomain.SMSG_LOGIN_ZONE_CLUSTER, "SMSG_LOGIN_ZONE_CLUSTER" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeFromDomain.SMSG_NOTIFY_ADD_ZONE_CLUSTER, "SMSG_NOTIFY_ADD_ZONE_CLUSTER" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeFromDomain.SMSG_NOTIFY_REMOVE_ZONE_CLUSTER, "SMSG_NOTIFY_REMOVE_ZONE_CLUSTER" );
            s_ZoneClusterOpCodeName.Add( (long)ZoneClusterOpCodeFromDomain.SMSG_DOMAIN_PING_ZONE_CLUSTER, "SMSG_DOMAIN_PING_ZONE_CLUSTER" );
        }
    }
}
#endregion
