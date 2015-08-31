

namespace Demo_R.O.S.E.CharServer.Common
{
    /// <summary>
    /// List of clan members
    /// </summary>
    internal class ClanMember
    {
        #region zh-CHS �ڲ����� | en Internal Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ClanGuid = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClanGuid
        {
            get { return m_ClanGuid; }
            set { m_ClanGuid = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_CharacterName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal string CharacterName
        {
            get { return m_CharacterName; }
            set { m_CharacterName = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ClanRank = 1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal long ClanRank
        {
            get { return m_ClanRank; }
            set { m_ClanRank = value; }
        }
        #endregion

        #region zh-CHS ��ʱ������ڲ����� | en Internal Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ServerGuid = 0xFF;
        #endregion
        /// <summary>
        /// ��������Id
        /// </summary>
        internal long ServerGuid
        {
            get { return m_ServerGuid; }
            set { m_ServerGuid = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Level = 1;
        #endregion
        /// <summary>
        /// �ȼ�
        /// </summary>
        internal long Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ClassId = 0;
        #endregion
        /// <summary>
        /// ְҵ
        /// </summary>
        internal long ClassId
        {
            get { return m_ClassId; }
            set { m_ClassId = value; }
        }
        #endregion
    }
}