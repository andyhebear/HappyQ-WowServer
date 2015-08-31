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

#endregion

namespace Demo.Mmose.Core.World.Zone
{
    #region zh-CHS 枚举 | en Enum
    /// <summary>
    /// Zone OpCode Client To Zone Cluster
    /// </summary>
    internal enum ZoneOpCodeToZoneCluster
    {
        //////////////////////////////////////////////////////////////////////////
        // 连接至ZoneCluster - OpCode( 1 << 12 + ? )
        // 从Zone返回的结果信息给ZoneCluster - OpCode( 1 << 12 + 0x80 + ? )
        /// <summary>
        /// 登陆ZoneCluster
        /// </summary>
        CMSG_LOGIN_ZONE_CLUSTER = ( 1 << 12 ) + 0x0,
        /// <summary>
        /// 登陆Zone后,返回的结果信息
        /// </summary>
        SMSG_LOGIN_ZONE_CLUSTER_RESULT = ( 1 << 12 ) + 0x80,

        /// <summary>
        /// 添加个新的Zone至当前的ZoneCluster
        /// </summary>
        CMSG_ADD_CURRENT_ZONE = ( 1 << 12 ) + 0x1,
        /// <summary>
        /// 通知当前的Zone已有个新的Zone添加至当前连接的ZoneCluster
        /// </summary>
        SMSG_ADD_CURRENT_ZONE_RESULT = ( 1 << 12 ) + 0x81,

        /// <summary>
        /// 移去个Zone在当前的ZoneCluster中
        /// </summary>
        CMSG_REMOVE_CURRENT_ZONE = ( 1 << 12 ) + 0x2,
        /// <summary>
        /// 通知当前的Zone有个Zone已在当前连接的ZoneCluster中移去
        /// </summary>
        SMSG_REMOVE_CURRENT_ZONE_RESULT = ( 1 << 12 ) + 0x82,

        /// <summary>
        /// 通知当前的ZoneCluster连接是在线的
        /// </summary>
        CMSG_PING_ZONE_CLUSTER = ( 1 << 12 ) + 0x3,
        /// <summary>
        /// 返回通知当前的ZoneCluster连接是在线的
        /// </summary>
        SMSG_PONG_ZONE_CLUSTER = ( 1 << 12 ) + 0x83,
    }

    /// <summary>
    /// Zone OpCode Server From Zone Cluster
    /// </summary>
    internal enum ZoneOpCodeFromZoneCluster
    {
        //////////////////////////////////////////////////////////////////////////
        // 从ZoneCluster来的信息 - OpCode( 2 << 12 + ? )
        // 从ZoneCluster返回的结果信息 - OpCode( 2 << 12 + 0x80 + ? )
        /// <summary>
        /// 登陆Zone
        /// </summary>
        SMSG_LOGIN_ZONE = ( 2 << 12 ) + 0x0,
        /// <summary>
        /// 登陆ZoneCluster后,返回的结果信息
        /// </summary>
        CMSG_LOGIN_ZONE_CLUSTER_RESULT = ( 2 << 12 ) + 0x80,

        /// <summary>
        /// 通知当前的Zone已有个新的Zone添加至当前连接的ZoneCluster
        /// </summary>
        SMSG_NOTIFY_ADD_ZONE = ( 2 << 12 ) + 0x1,
        /// <summary>
        /// 添加当前的Zone至当前连接的ZoneCluster后,返回的结果信息
        /// </summary>
        CMSG_NOTIFY_ADD_ZONE_RESULT = ( 2 << 12 ) + 0x81,

        /// <summary>
        /// 通知当前的Zone有个Zone已在当前连接的ZoneCluster中移去
        /// </summary>
        SMSG_NOTIFY_REMOVE_ZONE = ( 2 << 12 ) + 0x2,
        /// <summary>
        /// 移去当前的Zone至当前连接的ZoneCluster后,返回的结果信息
        /// </summary>
        CMSG_NOTIFY_REMOVE_ZONE_RESULT = ( 2 << 12 ) + 0x82,

        /// <summary>
        /// 通知当前的Zone连接是在线的
        /// </summary>
        SMSG_PING_ZONE = ( 2 << 12 ) + 0x3,
        /// <summary>
        /// 返回通知当前的Zone连接是在线的
        /// </summary>
        CMSG_PONG_ZONE = ( 2 << 12 ) + 0x83,
    }
    #endregion
}
#endregion