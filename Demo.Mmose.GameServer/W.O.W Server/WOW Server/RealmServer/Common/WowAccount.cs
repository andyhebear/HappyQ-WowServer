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
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Wow.RealmServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    internal class WowAccount
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iAccountGuid;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long AccountGuid
        {
            get { return m_iAccountGuid; }
            set { m_iAccountGuid = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strAccountName;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string AccountName
        {
            get { return m_strAccountName; }
            set { m_strAccountName = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strPassword;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return m_strPassword; }
            set { m_strPassword = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private AccessLevel m_AccessLevel = AccessLevel.Player;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public AccessLevel AccessLevel
        {
            get { return m_AccessLevel; }
            set { m_AccessLevel = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_isTBC = true;
        #endregion
        /// <summary>
        /// 是否支持TBC
        /// </summary>
        public bool IsTBC
        {
            get { return m_isTBC; }
            set { m_isTBC = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bLocked;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool Locked
        {
            get { return m_bLocked; }
            set { m_bLocked = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bBanned;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool Banned
        {
            get { return m_bBanned; }
            set { m_bBanned = value; }
        }
        #endregion
    }
}
#endregion