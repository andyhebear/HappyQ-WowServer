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
    /// <summary>
    /// 
    /// </summary>
    public class ConfigZone
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strZoneID = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ZoneID
        {
            get { return m_strZoneID; }
            set { m_strZoneID = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strZoneHost = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ZoneHost
        {
            get { return m_strZoneHost; }
            set { m_strZoneHost = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iZonePort = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ZonePort
        {
            get { return m_iZonePort; }
            set { m_iZonePort = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strZonePassword = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ZonePassword
        {
            get { return m_strZonePassword; }
            set { m_strZonePassword = value; }
        }

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
        private int m_iZoneClusterPort = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int ZoneClusterPort
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
        #endregion
    }
}
#endregion