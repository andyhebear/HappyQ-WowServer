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
    /// 
    /// </summary>
    public class ConfigZoneCluster
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strZoneClusterID = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ZoneClusterID
        {
            get { return m_strZoneClusterID; }
            set { m_strZoneClusterID = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strZoneClusterHost = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ZoneClusterHost
        {
            get { return m_strZoneClusterHost; }
            set { m_strZoneClusterHost = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iZoneClusterPort = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ZoneClusterPort
        {
            get { return m_iZoneClusterPort; }
            set { m_iZoneClusterPort = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strZoneClusterPassword = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ZoneClusterPassword
        {
            get { return m_strZoneClusterPassword; }
            set { m_strZoneClusterPassword = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strDomainID = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string DomainID
        {
            get { return m_strDomainID; }
            set { m_strDomainID = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strDomainHost = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string DomainHost
        {
            get { return m_strDomainHost; }
            set { m_strDomainHost = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_iDomainPort = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int DomainPort
        {
            get { return m_iDomainPort; }
            set { m_iDomainPort = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strDomainPassword = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string DomainPassword
        {
            get { return m_strDomainPassword; }
            set { m_strDomainPassword = value; }
        }
        #endregion
    }
}
#endregion