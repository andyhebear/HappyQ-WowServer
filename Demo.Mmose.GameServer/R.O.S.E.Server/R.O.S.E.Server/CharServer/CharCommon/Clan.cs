#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2006 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System.Collections.Generic;
using System.Threading;
#endregion

namespace Demo_R.O.S.E.CharServer.Common
{
    /// <summary>
    /// List of clan
    /// </summary>
    internal class Clan
    {
        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ClanGuid;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClanGuid
        {
            get { return m_ClanGuid; }
            set { m_ClanGuid = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_ClanName;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string ClanName
        {
            get { return m_ClanName; }
            set { m_ClanName = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Logo;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal int Logo
        {
            get { return m_Logo; }
            set { m_Logo = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Back;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal int Back
        {
            get { return m_Back; }
            set { m_Back = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Grade;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal int Grade
        {
            get { return m_Grade; }
            set { m_Grade = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_CP;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal int CP
        {
            get { return m_CP; }
            set { m_CP = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Slogan;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string Slogan
        {
            get { return m_Slogan; }
            set { m_Slogan = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_News;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string News
        {
            get { return m_News; }
            set { m_News = value; }
        }

        #region zh-CHS ClanMemberList属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private List<ClanMember> m_ClanMemberList = new List<ClanMember>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal List<ClanMember> ClanMemberList
        {
            get { return m_ClanMemberList; }
            set { m_ClanMemberList = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private object m_LockClanMembers = new object();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal object SyncClanMemberList
        {
            get { return m_LockClanMembers; }
        }

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal void AddClanMemberList( ClanMember clanMember )
        {
            Monitor.Enter( m_LockClanMembers );
            {
                m_ClanMemberList.Add( clanMember );
            }
            Monitor.Exit( m_LockClanMembers );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendList"></param>
        internal void RemoveClanMemberList( ClanMember clanMember )
        {
            Monitor.Enter( m_LockClanMembers );
            {
                m_ClanMemberList.Remove( clanMember );
            }
            Monitor.Exit( m_LockClanMembers );
        }

        /// <summary>
        /// 
        /// </summary>
        internal ClanMember[] ClanMemberListToArray()
        {
            ClanMember[] ClanMemberArray = null;

            Monitor.Enter( m_LockClanMembers );
            {
                if ( m_ClanMemberList.Count > 0 )
                    ClanMemberArray = m_ClanMemberList.ToArray();
            }
            Monitor.Exit( m_LockClanMembers );

            return ClanMemberArray;
        }
        #endregion

        #endregion

        #endregion
    }
}
#endregion