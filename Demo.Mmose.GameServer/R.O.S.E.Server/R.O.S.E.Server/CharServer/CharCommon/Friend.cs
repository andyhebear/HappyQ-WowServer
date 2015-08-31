

namespace Demo_R.O.S.E.CharServer.Common
{
    /// <summary>
    /// List of friends
    /// </summary>
    internal class Friend
    {
        #region zh-CHS �ڲ����� | en Internal Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_FriendGuid = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long FriendGuid
        {
            get { return m_FriendGuid; }
            set { m_FriendGuid = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_FriendName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string FriendName
        {
            get { return m_FriendName; }
            set { m_FriendName = value; }
        }
        #endregion

        #region zh-CHS ��ʱ������ڲ����� | en Internal Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsOnline = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal bool IsOnline
        {
            get { return m_IsOnline; }
            set { m_IsOnline = value; }
        }
        #endregion
    }
}
