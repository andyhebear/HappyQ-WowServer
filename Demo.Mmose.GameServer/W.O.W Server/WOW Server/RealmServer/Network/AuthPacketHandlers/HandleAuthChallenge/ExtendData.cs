using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common.Srp;
using Demo.Wow.RealmServer.Common;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal class AuthChallenge
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private AuthLogonChallenge m_AuthLogonChallenge = new AuthLogonChallenge();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public AuthLogonChallenge AuthLogonChallenge
        {
            get { return m_AuthLogonChallenge; }
            set { m_AuthLogonChallenge = value; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed partial class AuthExtendData
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private AuthChallenge m_AuthChallenge = new AuthChallenge();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public AuthChallenge AuthChallenge
        {
            get { return m_AuthChallenge; }
        }
    }
}
