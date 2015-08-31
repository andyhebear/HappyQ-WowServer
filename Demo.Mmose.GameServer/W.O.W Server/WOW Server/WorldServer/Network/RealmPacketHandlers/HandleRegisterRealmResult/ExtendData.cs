using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterRealmResult
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
        private RegisterRealmResult m_RegisterRealmResult = new RegisterRealmResult();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public RegisterRealmResult RegisterRealmResult
        {
            get { return m_RegisterRealmResult; }
        }
    }
}
