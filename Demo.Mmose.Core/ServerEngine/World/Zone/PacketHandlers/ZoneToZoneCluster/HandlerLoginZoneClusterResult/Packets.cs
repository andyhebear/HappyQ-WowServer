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

namespace Demo.Mmose.Core.World.Zone
{
    #region zh-CHS Zone_LoginZoneCluster 类 | en Zone_LoginZoneCluster Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Zone_LoginZoneCluster : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Zone_LoginZoneCluster( string strZoneClusterPassword, string strZonePassword )
            : base( (long)ZoneOpCodeToZoneCluster.CMSG_LOGIN_ZONE_CLUSTER, 0/*4 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*4 + ?*/ );      // 字段大小
            WriterStream.Write( (ushort)base.PacketID );    // 字段编号

            WriterStream.WriteUTF8Null( strZoneClusterPassword );
            WriterStream.WriteUTF8Null( strZonePassword );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion

    #region zh-CHS Zone_LoginZoneCluster 类 | en Zone_LoginZoneCluster Class
    /// <summary>
    /// 
    /// </summary>
    internal struct LoginZoneCluster
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strZoneClusterPassword;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ZoneClusterPassword
        {
            get { return m_strZoneClusterPassword; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strZonePassword;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ZonePassword
        {
            get { return m_strZonePassword; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetReader"></param>
        /// <returns></returns>
        public LoginZoneCluster GetLoginZoneCluster( PacketReader packetReader )
        {
            LoginZoneCluster returnLoginZoneCluster = new LoginZoneCluster();

            returnLoginZoneCluster.m_strZonePassword = string.Empty;
            returnLoginZoneCluster.m_strZoneClusterPassword = string.Empty;

            return returnLoginZoneCluster;
        }
    }
    #endregion

    #region zh-CHS Zone_LoginZoneCluster 类 | en Zone_LoginZoneCluster Class
    /// <summary>
    /// 
    /// </summary>
    internal struct LoginZoneClusterResult
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCheckPass;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCheckPass
        {
            get { return m_IsCheckPass; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetReader"></param>
        /// <returns></returns>
        public static LoginZoneClusterResult GetLoginZoneClusterResult( PacketReader packetReader )
        {
            LoginZoneClusterResult returnLoginZoneClusterResult = new LoginZoneClusterResult();

            returnLoginZoneClusterResult.m_IsCheckPass = packetReader.ReadBoolean();

            return returnLoginZoneClusterResult;
        }
    }
    #endregion

    #region zh-CHS Zone_LoginZoneClusterResult 类 | en Zone_LoginZoneClusterResult Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Zone_LoginZoneClusterResult : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Zone_LoginZoneClusterResult( bool isCheckPass )
            : base( (long)ZoneOpCodeToZoneCluster.SMSG_LOGIN_ZONE_CLUSTER_RESULT, 0/*4 + 1*/ )
        {
            WriterStream.Write( (ushort)5 /*4 + 1*/ );      // 字段大小
            WriterStream.Write( (ushort)base.PacketID );    // 字段编号

            WriterStream.Write( isCheckPass );
        }
    }
    #endregion
}
#endregion