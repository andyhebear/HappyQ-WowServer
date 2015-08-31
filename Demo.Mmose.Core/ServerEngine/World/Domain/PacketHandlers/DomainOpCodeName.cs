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

namespace Demo.Mmose.Core.World.DomainWorld
{
    /// <summary>
    /// 
    /// </summary>
    public static class DomainOpCodeName
    {
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<long, string> s_DomainOpCodeName = new Dictionary<long, string>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iOpCode"></param>
        public static string GetDomainOpCodeName( long iOpCode )
        {
            string strWordOpCodeName = string.Empty;

            if ( s_DomainOpCodeName.TryGetValue( iOpCode, out strWordOpCodeName ) == true )
                return strWordOpCodeName;
            else
                return "Unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitDomainOpCodeName()
        {
            s_DomainOpCodeName.Add( (long)DomainOpCodeToZoneCluster.CMSG_LOGIN_ZONE_CLUSTER, "CMSG_LOGIN_ZONE_CLUSTER" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeToZoneCluster.SMSG_LOGIN_ZONE_CLUSTER_RESULT, "SMSG_LOGIN_ZONE_CLUSTER_RESULT" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeToZoneCluster.CMSG_NOTIFY_ADD_ZONE_CLUSTER, "CMSG_NOTIFY_ADD_ZONE_CLUSTER" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeToZoneCluster.SMSG_NOTIFY_ADD_ZONE_CLUSTER_RESULT, "SMSG_NOTIFY_ADD_ZONE_CLUSTER_RESULT" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeToZoneCluster.CMSG_NOTIFY_REMOVE_ZONE_CLUSTER, "CMSG_NOTIFY_REMOVE_ZONE_CLUSTER" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeToZoneCluster.SMSG_NOTIFY_REMOVE_ZONE_CLUSTER_RESULT, "SMSG_NOTIFY_REMOVE_ZONE_CLUSTER_RESULT" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeToZoneCluster.CMSG_PING_ZONE_CLUSTER, "CMSG_PING_ZONE_CLUSTER" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeToZoneCluster.SMSG_PONG_ZONE_CLUSTER, "SMSG_PONG_ZONE_CLUSTER" );

            s_DomainOpCodeName.Add( (long)DomainOpCodeFromZoneCluster.SMSG_LOGIN_DOMAIN, "SMSG_LOGIN_DOMAIN" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeFromZoneCluster.CMSG_LOGIN_DOMAIN_RESULT, "CMSG_LOGIN_DOMAIN_RESULT" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeFromZoneCluster.SMSG_ADD_CURRENT_ZONE_CLUSTER, "SMSG_ADD_CURRENT_ZONE_CLUSTER" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeFromZoneCluster.CMSG_ADD_CURRENT_ZONE_CLUSTER_RESULT, "CMSG_ADD_CURRENT_ZONE_CLUSTER_RESULT" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeFromZoneCluster.SMSG_REMOVE_CURRENT_ZONE_CLUSTER, "SMSG_REMOVE_CURRENT_ZONE_CLUSTER" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeFromZoneCluster.CMSG_REMOVE_CURRENT_ZONE_CLUSTER_RESULT, "CMSG_REMOVE_CURRENT_ZONE_CLUSTER_RESULT" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeFromZoneCluster.SMSG_PING_DOMAIN, "SMSG_PING_DOMAIN" );
            s_DomainOpCodeName.Add( (long)DomainOpCodeFromZoneCluster.CMSG_PONG_DOMAIN, "CMSG_PONG_DOMAIN" );
        }
    }
}
#endregion
