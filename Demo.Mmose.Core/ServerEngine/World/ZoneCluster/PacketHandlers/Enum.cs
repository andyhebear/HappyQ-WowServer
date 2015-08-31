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

namespace Demo.Mmose.Core.World.ZoneClusterWorld
{
    /// <summary>
    /// ZoneCluster OpCode Client
    /// </summary>
    internal enum ZoneClusterOpCodeToZone
    {
        //////////////////////////////////////////////////////////////////////////
        // 连接至Zone - OpCode(2 << 12)
        // 从ZoneCluster返回的结果信息给Zone - OpCode(2 << 12)
        /// <summary>
        /// 登陆Zone
        /// </summary>
        CMSG_LOGIN_ZONE = ( 2 << 12 ) + 0x0,
        /// <summary>
        /// 登陆ZoneCluster后,返回的结果信息
        /// </summary>
        SMSG_LOGIN_ZONE_RESULT = ( 2 << 12 ) + 0x80,

        /// <summary>
        /// 通知当前的Zone已有个新的Zone添加至当前连接的ZoneCluster
        /// </summary>
        CMSG_NOTIFY_ADD_ZONE = ( 2 << 12 ) + 0x1,
        /// <summary>
        /// 添加当前的Zone至当前连接的ZoneCluster后,返回的结果信息
        /// </summary>
        SMSG_NOTIFY_ADD_ZONE_RESULT = ( 2 << 12 ) + 0x81,

        /// <summary>
        /// 通知当前的Zone有个Zone已在当前连接的ZoneCluster中移去
        /// </summary>
        CMSG_NOTIFY_REMOVE_ZONE = ( 2 << 12 ) + 0x2,
        /// <summary>
        /// 移去当前的Zone至当前连接的ZoneCluster后,返回的结果信息
        /// </summary>
        SMSG_NOTIFY_REMOVE_ZONE_RESULT = ( 2 << 12 ) + 0x82,

        /// <summary>
        /// 通知当前的Zone连接是在线的
        /// </summary>
        CMSG_PING_ZONE = ( 2 << 12 ) + 0x3,
        /// <summary>
        /// 返回通知当前的Zone连接是在线的
        /// </summary>
        SMSG_PONG_ZONE = ( 2 << 12 ) + 0x83,
    }

    /// <summary>
    /// 
    /// </summary>
    internal enum ZoneClusterOpCodeToDomain
    {
        //////////////////////////////////////////////////////////////////////////
        // 从ZoneCluster的信息 - OpCode( 4 << 12 + ? )
        // 从ZoneCluster返回的结果信息 - OpCode( 4 << 120x80 + ? )
        /// <summary>
        /// 登陆Domain
        /// </summary>
        CMSG_LOGIN_DOMAIN = ( 4 << 12 ) + 0x0,
        /// <summary>
        /// 登陆Domain后,返回的结果信息
        /// </summary>
        SMSG_LOGIN_DOMAIN_RESULT = ( 4 << 12 ) + 0x80,

        /// <summary>
        /// 添加个新的ZoneCluster至当前的Domain中
        /// </summary>
        CMSG_ADD_CURRENT_ZONE_CLUSTER = ( 4 << 12 ) + 0x1,
        /// <summary>
        /// 通知当前的ZoneCluster已有个新的ZoneCluster添加至当前连接的Domain
        /// </summary>
        SMSG_ADD_CURRENT_ZONE_CLUSTER_RESULT = ( 4 << 12 ) + 0x81,

        /// <summary>
        /// 移去个ZoneCluster在当前的Domain中
        /// </summary>
        CMSG_REMOVE_CURRENT_ZONE_CLUSTER = ( 4 << 12 ) + 0x2,
        /// <summary>
        /// 通知当前的ZoneCluster有个ZoneCluster已在当前连接的Domain中移去
        /// </summary>  
        SMSG_REMOVE_CURRENT_ZONE_CLUSTER_RESULT = ( 4 << 12 ) + 0x82,

        /// <summary>
        /// 通知当前的Domain连接是在线的
        /// </summary>
        CMSG_PING_DOMAIN = ( 4 << 12 ) + 0x3,
        /// <summary>
        /// 通知当前的Domain连接是在线的
        /// </summary>
        SMSG_PONG_DOMAIN = ( 4 << 12 ) + 0x83,
    }

    /// <summary>
    /// ZoneCluster OpCode Server
    /// </summary>
    internal enum ZoneClusterOpCodeFromZone
    {
        //////////////////////////////////////////////////////////////////////////
        // 从Zone来的信息 - OpCode( 1 << 12 + ? )
        // 从Zone返回的结果信息 - OpCode( 1 << 12 + 0x80 + ? )
        /// <summary>
        /// 登陆ZoneCluster
        /// </summary>
        SMSG_LOGIN_ZONE_CLUSTER = ( 1 << 12 ) + 0x0,
        /// <summary>
        /// 登陆Zone后,返回的结果信息
        /// </summary>
        CMSG_LOGIN_ZONE_CLUSTER_RESULT = ( 1 << 12 ) + 0x80,

        /// <summary>
        /// 添加个新的Zone至当前的ZoneCluster
        /// </summary>
        SMSG_ADD_CURRENT_ZONE = ( 1 << 12 ) + 0x1,
        /// <summary>
        /// 通知当前的Zone已有个新的Zone添加至当前连接的ZoneCluster
        /// </summary>
        CMSG_ADD_CURRENT_ZONE_RESULT = ( 1 << 12 ) + 0x81,

        /// <summary>
        /// 移去个Zone在当前的ZoneCluster中
        /// </summary>
        SMSG_REMOVE_CURRENT_ZONE = ( 1 << 12 ) + 0x2,
        /// <summary>
        /// 通知当前的Zone有个Zone已在当前连接的ZoneCluster中移去
        /// </summary>
        CMSG_REMOVE_CURRENT_ZONE_RESULT = ( 1 << 12 ) + 0x82,

        /// <summary>
        /// 通知当前的ZoneCluster连接是在线的
        /// </summary>
        SMSG_ZONE_PING_ZONE_CLUSTER = ( 1 << 12 ) + 0x3,
        /// <summary>
        /// 返回通知当前的ZoneCluster连接是在线的
        /// </summary>
        CMSG_PONG_ZONE_CLUSTER = ( 1 << 12 ) + 0x83,
    }

    /// <summary>
    /// 
    /// </summary>
    internal enum ZoneClusterOpCodeFromDomain
    {
        //////////////////////////////////////////////////////////////////////////
        // 连接至ZoneCluster - OpCode( 3 << 12 + ? )
        // 从Domain返回的结果信息给ZoneCluster - OpCode( 3 << 12 + 0x80 + ? )
        /// <summary>
        /// 登陆ZoneCluster
        /// </summary>
        SMSG_LOGIN_ZONE_CLUSTER = ( 3 << 12 ) + 0x0,
        /// <summary>
        /// 登陆Domain后,返回的结果信息
        /// </summary>
        CMSG_LOGIN_ZONE_CLUSTER_RESULT = ( 3 << 12 ) + 0x80,

        /// <summary>
        /// 通知当前的ZoneCluster有个新的ZoneCluster添加至当前连接的Domain
        /// </summary>
        SMSG_NOTIFY_ADD_ZONE_CLUSTER = ( 3 << 12 ) + 0x1,
        /// <summary>
        ///  添加ZoneCluster后,返回的结果信息
        /// </summary>
        CMSG_NOTIFY_ADD_ZONE_CLUSTER_RESULT = ( 3 << 12 ) + 0x81,

        /// <summary>
        /// 通知当前的ZoneCluster有个ZoneCluster已在当前连接的Domain中移去
        /// </summary>
        SMSG_NOTIFY_REMOVE_ZONE_CLUSTER = ( 3 << 12 ) + 0x2,
        /// <summary>
        /// 移去ZoneCluster后,返回的结果信息
        /// </summary>
        CMSG_NOTIFY_REMOVE_ZONE_CLUSTER_RESULT = ( 3 << 12 ) + 0x82,

        /// <summary>
        /// 通知当前的ZoneCluster连接是在线的
        /// </summary>
        SMSG_DOMAIN_PING_ZONE_CLUSTER = ( 3 << 12 ) + 0x3,
        /// <summary>
        /// 返回通知当前的ZoneCluster连接是在线的
        /// </summary>
        CMSG_PONG_ZONE_CLUSTER = ( 3 << 12 ) + 0x83,
    }
}
#endregion