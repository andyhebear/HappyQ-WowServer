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

namespace Demo.Mmose.Core.World.Zone
{
    #region zh-CHS ö�� | en Enum
    /// <summary>
    /// Zone OpCode Client To Zone Cluster
    /// </summary>
    internal enum ZoneOpCodeToZoneCluster
    {
        //////////////////////////////////////////////////////////////////////////
        // ������ZoneCluster - OpCode( 1 << 12 + ? )
        // ��Zone���صĽ����Ϣ��ZoneCluster - OpCode( 1 << 12 + 0x80 + ? )
        /// <summary>
        /// ��½ZoneCluster
        /// </summary>
        CMSG_LOGIN_ZONE_CLUSTER = ( 1 << 12 ) + 0x0,
        /// <summary>
        /// ��½Zone��,���صĽ����Ϣ
        /// </summary>
        SMSG_LOGIN_ZONE_CLUSTER_RESULT = ( 1 << 12 ) + 0x80,

        /// <summary>
        /// ��Ӹ��µ�Zone����ǰ��ZoneCluster
        /// </summary>
        CMSG_ADD_CURRENT_ZONE = ( 1 << 12 ) + 0x1,
        /// <summary>
        /// ֪ͨ��ǰ��Zone���и��µ�Zone�������ǰ���ӵ�ZoneCluster
        /// </summary>
        SMSG_ADD_CURRENT_ZONE_RESULT = ( 1 << 12 ) + 0x81,

        /// <summary>
        /// ��ȥ��Zone�ڵ�ǰ��ZoneCluster��
        /// </summary>
        CMSG_REMOVE_CURRENT_ZONE = ( 1 << 12 ) + 0x2,
        /// <summary>
        /// ֪ͨ��ǰ��Zone�и�Zone���ڵ�ǰ���ӵ�ZoneCluster����ȥ
        /// </summary>
        SMSG_REMOVE_CURRENT_ZONE_RESULT = ( 1 << 12 ) + 0x82,

        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster���������ߵ�
        /// </summary>
        CMSG_PING_ZONE_CLUSTER = ( 1 << 12 ) + 0x3,
        /// <summary>
        /// ����֪ͨ��ǰ��ZoneCluster���������ߵ�
        /// </summary>
        SMSG_PONG_ZONE_CLUSTER = ( 1 << 12 ) + 0x83,
    }

    /// <summary>
    /// Zone OpCode Server From Zone Cluster
    /// </summary>
    internal enum ZoneOpCodeFromZoneCluster
    {
        //////////////////////////////////////////////////////////////////////////
        // ��ZoneCluster������Ϣ - OpCode( 2 << 12 + ? )
        // ��ZoneCluster���صĽ����Ϣ - OpCode( 2 << 12 + 0x80 + ? )
        /// <summary>
        /// ��½Zone
        /// </summary>
        SMSG_LOGIN_ZONE = ( 2 << 12 ) + 0x0,
        /// <summary>
        /// ��½ZoneCluster��,���صĽ����Ϣ
        /// </summary>
        CMSG_LOGIN_ZONE_CLUSTER_RESULT = ( 2 << 12 ) + 0x80,

        /// <summary>
        /// ֪ͨ��ǰ��Zone���и��µ�Zone�������ǰ���ӵ�ZoneCluster
        /// </summary>
        SMSG_NOTIFY_ADD_ZONE = ( 2 << 12 ) + 0x1,
        /// <summary>
        /// ��ӵ�ǰ��Zone����ǰ���ӵ�ZoneCluster��,���صĽ����Ϣ
        /// </summary>
        CMSG_NOTIFY_ADD_ZONE_RESULT = ( 2 << 12 ) + 0x81,

        /// <summary>
        /// ֪ͨ��ǰ��Zone�и�Zone���ڵ�ǰ���ӵ�ZoneCluster����ȥ
        /// </summary>
        SMSG_NOTIFY_REMOVE_ZONE = ( 2 << 12 ) + 0x2,
        /// <summary>
        /// ��ȥ��ǰ��Zone����ǰ���ӵ�ZoneCluster��,���صĽ����Ϣ
        /// </summary>
        CMSG_NOTIFY_REMOVE_ZONE_RESULT = ( 2 << 12 ) + 0x82,

        /// <summary>
        /// ֪ͨ��ǰ��Zone���������ߵ�
        /// </summary>
        SMSG_PING_ZONE = ( 2 << 12 ) + 0x3,
        /// <summary>
        /// ����֪ͨ��ǰ��Zone���������ߵ�
        /// </summary>
        CMSG_PONG_ZONE = ( 2 << 12 ) + 0x83,
    }
    #endregion
}
#endregion