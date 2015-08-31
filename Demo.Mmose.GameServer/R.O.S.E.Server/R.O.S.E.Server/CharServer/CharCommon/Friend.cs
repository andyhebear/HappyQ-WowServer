

namespace Demo_R.O.S.E.CharServer.Common
{
    /// <summary>
    /// List of friends
    /// </summary>
    internal class Friend
    {
        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 私有成员变量 | en Private Member Variables
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

        #region zh-CHS 临时计算的内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
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
