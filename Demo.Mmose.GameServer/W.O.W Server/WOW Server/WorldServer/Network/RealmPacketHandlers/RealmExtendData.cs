using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Component;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS RealmExtendData �� | en RealmExtendData Class
    /// <summary>
    /// Realm Server �ͻ������ӹ����洢������
    /// </summary>
    internal sealed partial class RealmExtendData : Component
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static ComponentId COMPONENT_ID = "RealmExtendData";

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsLoggedIn = false;
        #endregion
        /// <summary>
        /// ��ֹû��½��Hack
        /// </summary>
        public bool IsLoggedIn
        {
            get { return m_bIsLoggedIn; }
            set { m_bIsLoggedIn = value; }
        }
    }
    #endregion
}
