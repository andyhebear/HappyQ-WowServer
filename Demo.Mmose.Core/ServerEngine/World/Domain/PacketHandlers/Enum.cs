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
using System;
using System.Text;
using System.Collections.Generic;
#endregion

namespace Demo.Mmose.Core.World.DomainWorld
{
    /// <summary>
    /// Domain OpCode Client
    /// </summary>
    internal enum DomainOpCodeToZoneCluster
    {
        //////////////////////////////////////////////////////////////////////////
        // ������ZoneCluster - OpCode( 3 << 12 + ? )
        // ��Domain���صĽ����Ϣ��ZoneCluster - OpCode( 3 << 12 + 0x80 + ? )
        /// <summary>
        /// ��½ZoneCluster
        /// </summary>
        CMSG_LOGIN_ZONE_CLUSTER = ( 3 << 12 ) + 0x0,
        /// <summary>
        /// ��½Domain��,���صĽ����Ϣ
        /// </summary>
        SMSG_LOGIN_ZONE_CLUSTER_RESULT = ( 3 << 12 ) + 0x80,

        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster�и��µ�ZoneCluster�������ǰ���ӵ�Domain
        /// </summary>
        CMSG_NOTIFY_ADD_ZONE_CLUSTER = ( 3 << 12 ) + 0x1,
        /// <summary>
        ///  ���ZoneCluster��,���صĽ����Ϣ
        /// </summary>
        SMSG_NOTIFY_ADD_ZONE_CLUSTER_RESULT = ( 3 << 12 ) + 0x81,

        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster�и�ZoneCluster���ڵ�ǰ���ӵ�Domain����ȥ
        /// </summary>
        CMSG_NOTIFY_REMOVE_ZONE_CLUSTER = ( 3 << 12 ) + 0x2,
        /// <summary>
        /// ��ȥZoneCluster��,���صĽ����Ϣ
        /// </summary>
        SMSG_NOTIFY_REMOVE_ZONE_CLUSTER_RESULT = ( 3 << 12 ) + 0x82,

        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster���������ߵ�
        /// </summary>
        CMSG_PING_ZONE_CLUSTER = ( 3 << 12 ) + 0x3,
        /// <summary>
        /// ����֪ͨ��ǰ��ZoneCluster���������ߵ�
        /// </summary>
        SMSG_PONG_ZONE_CLUSTER = ( 3 << 12 ) + 0x83,
    }

    /// <summary>
    /// Domain OpCode Server
    /// </summary>
    internal enum DomainOpCodeFromZoneCluster
    {
        //////////////////////////////////////////////////////////////////////////
        // ��ZoneCluster����Ϣ - OpCode( 4 << 12 + ? )
        // ��ZoneCluster���صĽ����Ϣ - OpCode( 4 << 120x80 + ? )
        /// <summary>
        /// ��½Domain
        /// </summary>
        SMSG_LOGIN_DOMAIN = ( 4 << 12 ) + 0x0,
        /// <summary>
        /// ��½Domain��,���صĽ����Ϣ
        /// </summary>
        CMSG_LOGIN_DOMAIN_RESULT = ( 4 << 12 ) + 0x80,

        /// <summary>
        /// ��Ӹ��µ�ZoneCluster����ǰ��Domain��
        /// </summary>
        SMSG_ADD_CURRENT_ZONE_CLUSTER = ( 4 << 12 ) + 0x1,
        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster���и��µ�ZoneCluster�������ǰ���ӵ�Domain
        /// </summary>
        CMSG_ADD_CURRENT_ZONE_CLUSTER_RESULT = ( 4 << 12 ) + 0x81,

        /// <summary>
        /// ��ȥ��ZoneCluster�ڵ�ǰ��Domain��
        /// </summary>
        SMSG_REMOVE_CURRENT_ZONE_CLUSTER = ( 4 << 12 ) + 0x2,
        /// <summary>
        /// ֪ͨ��ǰ��ZoneCluster�и�ZoneCluster���ڵ�ǰ���ӵ�Domain����ȥ
        /// </summary>  
        CMSG_REMOVE_CURRENT_ZONE_CLUSTER_RESULT = ( 4 << 12 ) + 0x82,

        /// <summary>
        /// ֪ͨ��ǰ��Domain���������ߵ�
        /// </summary>
        SMSG_PING_DOMAIN = ( 4 << 12 ) + 0x3,
        /// <summary>
        /// ֪ͨ��ǰ��Domain���������ߵ�
        /// </summary>
        CMSG_PONG_DOMAIN = ( 4 << 12 ) + 0x83,
    }
}
#endregion