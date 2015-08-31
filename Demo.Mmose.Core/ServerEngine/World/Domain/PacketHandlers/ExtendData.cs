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
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Common.Component;
#endregion

namespace Demo.Mmose.Core.World.DomainWorld
{
    /// <summary>
    /// ZoneCluster Server 客户端连接过来存储的数据
    /// </summary>
    public partial class Domain_ListenerExtendData : Component
    {
        #region zh-CHS 共有常量 | en Public Constants
        /// <summary>
        /// 
        /// </summary>
        public readonly static ComponentId COMPONENT_ID = "Domain_ListenerExtendData";
        #endregion

        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsLoggedIn = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsLoggedIn
        {
            get { return m_bIsLoggedIn; }
            set { m_bIsLoggedIn = value; }
        }
        #endregion
    }

    /// <summary>
    /// ZoneCluster Server 客户端连接过来存储的数据
    /// </summary>
    public partial class Domain_ConnecterExtendData : Component
    {
        #region zh-CHS 共有常量 | en Public Constants
        /// <summary>
        /// 
        /// </summary>
        public readonly static ComponentId COMPONENT_ID = "Domain_ConnecterExtendData";
        #endregion

        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NetState m_NetState = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public NetState NetState
        {
            get { return m_NetState; }
            set { m_NetState = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsLoggedIn = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsLoggedIn
        {
            get { return m_bIsLoggedIn; }
            set { m_bIsLoggedIn = value; }
        }
        #endregion
    }
}
#endregion