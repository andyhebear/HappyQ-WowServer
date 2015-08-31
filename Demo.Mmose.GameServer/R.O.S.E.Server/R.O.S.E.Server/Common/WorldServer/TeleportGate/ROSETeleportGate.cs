using System;
using System.Text;
using System.Collections.Generic;

namespace Demo_R.O.S.E.TeleportGate
{
    /// <summary>
    /// Զ���봫��֮��
    /// </summary>
    public class ROSETeleportGate
    {
        #region zh-CHS ���� | en Properties
        #region zh-CHS ��Ա���� | en Member Variables
        /// <summary>
        /// Զ���봫��֮�ŵ�GUID
        /// </summary>
        private long m_TeleGateGuid;
        #endregion
        public long TeleGateGuid
        {
            get { return m_TeleGateGuid; }
            set { m_TeleGateGuid = value; }
        }

        #region zh-CHS ��Ա���� | en Member Variables
        // ��ͼ�ı�Ƿ���(ID)
        private int m_TeleGateMapID;
        #endregion
        public int TeleGateMapID
        {
            get { return m_TeleGateMapID; }
            set { m_TeleGateMapID = value; }
        }

        #region zh-CHS ��Ա���� | en Member Variables
        // ��ͼ�� X ����
        private int m_PositionX;
        #endregion
        public int PositionX
        {
            get { return m_PositionX; }
            set { m_PositionX = value; }
        }

        #region zh-CHS ��Ա���� | en Member Variables
        // ��ͼ�� Y ����
        private int m_PositionY;
        #endregion
        public int PositionY
        {
            get { return m_PositionY; }
            set { m_PositionY = value; }
        }
        #endregion
    }
}
