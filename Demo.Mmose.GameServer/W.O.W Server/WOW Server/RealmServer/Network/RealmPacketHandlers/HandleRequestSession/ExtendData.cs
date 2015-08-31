using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestSession
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_Serial = Serial.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
            set { m_Serial = value; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed partial class RealmExtendData
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private RequestSession m_RequestSession = new RequestSession();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public RequestSession RequestSession
        {
            get { return m_RequestSession; }
        }
    }
}
