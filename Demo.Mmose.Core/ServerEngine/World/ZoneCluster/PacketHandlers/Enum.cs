#region zh-CHS 2006 - 2008 DemoSoft �Ŷ� | en 2006 - 2008 DemoSoft Team

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

#region zh-CHS �������ֿռ� | en Include namespace

#endregion

namespace Demo.Mmose.Core.World.ZoneClusterWorld
{
    /// <summary>
    /// ZoneCluster OpCode Client
    /// </summary>
    internal enum ZoneClusterOpCodeToZone
    {
        //////////////////////////////////////////////////////////////////////////
        // ������Zone - OpCode(2 << 12)
        // ��ZoneCluster���صĽ����Ϣ��Zone - OpCode(2 << 12)
        /// <summary>
        /// ��½Zone
        /// </summary>
        CMSG_LOGIN_ZONE = ( 2 << 12 ) + 0x0,
        /// <summary>
        /// ��½ZoneCluster��,���صĽ����Ϣ
        /// </summary>
        SMSG_LOGIN_ZONE_RESULT = ( 2 << 12 ) + 0x80,

        /// <summary>
        /// ֪ͨ��ǰ��Zone���и��µ�Zone�������ǰ���ӵ�ZoneCluster
        /// </summary>
        CMSG_NOTIFY_ADD_ZONE = ( 2 << 12 ) + 0x1,
        /// <summary>
        /// ��ӵ�ǰ��Zone����ǰ���ӵ�ZoneCluster��,���صĽ����Ϣ
        /// </summary>
        SMSG_NOTIFY_ADD_ZONE_RESULT = ( 2 << 12 ) + 0x81,

        /// <summary>
        /// ֪ͨ��ǰ��Zone�и�Zone���ڵ�ǰ���ӵ�ZoneCluster����ȥ
        /// </summary>
        CMSG_NOTIFY_REMOVE_ZONE = ( 2 << 12 ) + 0x2,
        /// <summary>
        /// ��ȥ��ǰ��Zone����ǰ���ӵ�ZoneCluster��,���صĽ����Ϣ
        /// </summary>
        SMSG_NOTIFY_REMOVE_ZONE_RESULT = ( 2 << 12 ) + 0x82,

        /// <summary>
        /// ֪ͨ��ǰ��Zone���������ߵ�
        /// </summary>
        CMSG_PING_ZONE = ( 2 << 12 ) + 0x3,
        /// <summary>
        /// ����֪ͨ��ǰ��Zone���������ߵ�
        /// </summary>
        SMSG_PONG_ZONE = ( 2 << 12 ) + 0x83,
    }

    /// <summary>
    /// 
    /// </summary>
    internal enum ZoneClusterOpCodeToDomain
    {
        //////////////////////////////////////////////////////////////////////////
        // ��ZoneCluster����Ϣ - OpCode( 4 << 12 + ? )
        // ��ZoneCluster���صĽ����Ϣ - OpCode( 4 << 120x80 + ? )
        /// <summary>
        /// ��½Domain
        /// </summary>
        CMSG_LOGIN_DOMAIN = ( 4 << 12 ) + 0x0,
        /// <summary>
        /// ��½Domain��,���صĽ����Ϣ
        /// </summary>
        SMSG_LOGIN_DOMAIN_RESULT = ( 4 << 12 ) + 0x80,

        /// <summary>
        /// ��Ӹ��µ�ZoneCluster����ǰ��Domain��
        /// </summary>
        CMSG_ADD_CURRENT_ZONE_CLUSTER = ( 4 << 12 ) + 0x1,
        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster���и��µ�ZoneCluster�������ǰ���ӵ�Domain
        /// </summary>
        SMSG_ADD_CURRENT_ZONE_CLUSTER_RESULT = ( 4 << 12 ) + 0x81,

        /// <summary>
        /// ��ȥ��ZoneCluster�ڵ�ǰ��Domain��
        /// </summary>
        CMSG_REMOVE_CURRENT_ZONE_CLUSTER = ( 4 << 12 ) + 0x2,
        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster�и�ZoneCluster���ڵ�ǰ���ӵ�Domain����ȥ
        /// </summary>  
        SMSG_REMOVE_CURRENT_ZONE_CLUSTER_RESULT = ( 4 << 12 ) + 0x82,

        /// <summary>
        /// ֪ͨ��ǰ��Domain���������ߵ�
        /// </summary>
        CMSG_PING_DOMAIN = ( 4 << 12 ) + 0x3,
        /// <summary>
        /// ֪ͨ��ǰ��Domain���������ߵ�
        /// </summary>
        SMSG_PONG_DOMAIN = ( 4 << 12 ) + 0x83,
    }

    /// <summary>
    /// ZoneCluster OpCode Server
    /// </summary>
    internal enum ZoneClusterOpCodeFromZone
    {
        //////////////////////////////////////////////////////////////////////////
        // ��Zone������Ϣ - OpCode( 1 << 12 + ? )
        // ��Zone���صĽ����Ϣ - OpCode( 1 << 12 + 0x80 + ? )
        /// <summary>
        /// ��½ZoneCluster
        /// </summary>
        SMSG_LOGIN_ZONE_CLUSTER = ( 1 << 12 ) + 0x0,
        /// <summary>
        /// ��½Zone��,���صĽ����Ϣ
        /// </summary>
        CMSG_LOGIN_ZONE_CLUSTER_RESULT = ( 1 << 12 ) + 0x80,

        /// <summary>
        /// ��Ӹ��µ�Zone����ǰ��ZoneCluster
        /// </summary>
        SMSG_ADD_CURRENT_ZONE = ( 1 << 12 ) + 0x1,
        /// <summary>
        /// ֪ͨ��ǰ��Zone���и��µ�Zone�������ǰ���ӵ�ZoneCluster
        /// </summary>
        CMSG_ADD_CURRENT_ZONE_RESULT = ( 1 << 12 ) + 0x81,

        /// <summary>
        /// ��ȥ��Zone�ڵ�ǰ��ZoneCluster��
        /// </summary>
        SMSG_REMOVE_CURRENT_ZONE = ( 1 << 12 ) + 0x2,
        /// <summary>
        /// ֪ͨ��ǰ��Zone�и�Zone���ڵ�ǰ���ӵ�ZoneCluster����ȥ
        /// </summary>
        CMSG_REMOVE_CURRENT_ZONE_RESULT = ( 1 << 12 ) + 0x82,

        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster���������ߵ�
        /// </summary>
        SMSG_ZONE_PING_ZONE_CLUSTER = ( 1 << 12 ) + 0x3,
        /// <summary>
        /// ����֪ͨ��ǰ��ZoneCluster���������ߵ�
        /// </summary>
        CMSG_PONG_ZONE_CLUSTER = ( 1 << 12 ) + 0x83,
    }

    /// <summary>
    /// 
    /// </summary>
    internal enum ZoneClusterOpCodeFromDomain
    {
        //////////////////////////////////////////////////////////////////////////
        // ������ZoneCluster - OpCode( 3 << 12 + ? )
        // ��Domain���صĽ����Ϣ��ZoneCluster - OpCode( 3 << 12 + 0x80 + ? )
        /// <summary>
        /// ��½ZoneCluster
        /// </summary>
        SMSG_LOGIN_ZONE_CLUSTER = ( 3 << 12 ) + 0x0,
        /// <summary>
        /// ��½Domain��,���صĽ����Ϣ
        /// </summary>
        CMSG_LOGIN_ZONE_CLUSTER_RESULT = ( 3 << 12 ) + 0x80,

        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster�и��µ�ZoneCluster�������ǰ���ӵ�Domain
        /// </summary>
        SMSG_NOTIFY_ADD_ZONE_CLUSTER = ( 3 << 12 ) + 0x1,
        /// <summary>
        ///  ���ZoneCluster��,���صĽ����Ϣ
        /// </summary>
        CMSG_NOTIFY_ADD_ZONE_CLUSTER_RESULT = ( 3 << 12 ) + 0x81,

        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster�и�ZoneCluster���ڵ�ǰ���ӵ�Domain����ȥ
        /// </summary>
        SMSG_NOTIFY_REMOVE_ZONE_CLUSTER = ( 3 << 12 ) + 0x2,
        /// <summary>
        /// ��ȥZoneCluster��,���صĽ����Ϣ
        /// </summary>
        CMSG_NOTIFY_REMOVE_ZONE_CLUSTER_RESULT = ( 3 << 12 ) + 0x82,

        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster���������ߵ�
        /// </summary>
        SMSG_DOMAIN_PING_ZONE_CLUSTER = ( 3 << 12 ) + 0x3,
        /// <summary>
        /// ����֪ͨ��ǰ��ZoneCluster���������ߵ�
        /// </summary>
        CMSG_PONG_ZONE_CLUSTER = ( 3 << 12 ) + 0x83,
    }
}
#endregion