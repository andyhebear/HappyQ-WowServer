using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal class AuthProof
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private AuthLogonProof m_AuthLogonProof = new AuthLogonProof();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public AuthLogonProof AuthLogonProof
        {
            get { return m_AuthLogonProof; }
            set { m_AuthLogonProof = value; }
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
        private AuthProof m_AuthProof = new AuthProof();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public AuthProof AuthProof
        {
            get { return m_AuthProof; }
        }
    }
}
