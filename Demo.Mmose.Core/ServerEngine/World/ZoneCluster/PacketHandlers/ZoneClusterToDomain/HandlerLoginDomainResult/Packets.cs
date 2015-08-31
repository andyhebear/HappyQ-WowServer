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
using Demo.Mmose.Core.Network;
#endregion

namespace Demo.Mmose.Core.World.ZoneClusterWorld
{
    #region zh-CHS ZoneCluster_LoginDomain 类 | en ZoneCluster_LoginDomain Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class ZoneCluster_LoginDomain : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ZoneCluster_LoginDomain( string strDomainPassword, string strZoneClusterPassword )
            : base( (long)ZoneClusterOpCodeToDomain.CMSG_LOGIN_DOMAIN, 0/*4 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*4 + ?*/ );      // 字段大小
            WriterStream.Write( (ushort)base.PacketID );    // 字段编号

            WriterStream.WriteUTF8Null( strDomainPassword );
            WriterStream.WriteUTF8Null( strZoneClusterPassword );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion
}
#endregion