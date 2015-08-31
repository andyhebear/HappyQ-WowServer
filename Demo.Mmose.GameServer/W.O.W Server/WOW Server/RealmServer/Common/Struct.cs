using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.RealmServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    internal struct UpdateAccountLastIPSQL
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worldExtendData"></param>
        public UpdateAccountLastIPSQL( string strAccountsName, string strLastIP )
        {
            m_AccountsName = strAccountsName;
            m_LastIP = strLastIP;
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_AccountsName;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string AccountsName
        {
            get { return m_AccountsName; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_LastIP;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string LastIP
        {
            get { return m_LastIP; }
        }
    }
}