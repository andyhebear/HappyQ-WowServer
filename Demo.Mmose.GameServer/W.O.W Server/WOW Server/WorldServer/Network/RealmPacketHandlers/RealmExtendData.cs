using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Component;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS RealmExtendData 类 | en RealmExtendData Class
    /// <summary>
    /// Realm Server 客户端连接过来存储的数据
    /// </summary>
    internal sealed partial class RealmExtendData : Component
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static ComponentId COMPONENT_ID = "RealmExtendData";

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsLoggedIn = false;
        #endregion
        /// <summary>
        /// 防止没登陆就Hack
        /// </summary>
        public bool IsLoggedIn
        {
            get { return m_bIsLoggedIn; }
            set { m_bIsLoggedIn = value; }
        }
    }
    #endregion
}
