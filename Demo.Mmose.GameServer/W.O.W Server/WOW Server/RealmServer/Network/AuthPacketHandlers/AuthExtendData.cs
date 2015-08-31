#region zh-CHS 版权所有 (C) 2006 - 2007 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2007 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2007 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.RealmServer.Common;
using Demo.Mmose.Core.Common.Srp;
using Demo.Mmose.Core.Common.Component;
#endregion

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// Auth Server 客户端连接过来存储的数据
    /// </summary>
    internal sealed partial class AuthExtendData : Component
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static ComponentId COMPONENT_ID = "AuthExtendData";

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SecureRemotePassword m_SecureRemotePassword = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public SecureRemotePassword SRP
        {
            get { return m_SecureRemotePassword; }
            set { m_SecureRemotePassword = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowAccount m_WowAccount = new WowAccount();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowAccount WowAccount
        {
            get { return m_WowAccount; }
            set { m_WowAccount = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_Authenticated = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsAuthenticated
        {
            get { return m_Authenticated; }
            set { m_Authenticated = value; }
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
    }
}
#endregion