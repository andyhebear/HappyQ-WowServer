using System;
using System.Text;
using System.Collections.Generic;

namespace Demo_R.O.S.E.RespawnZone
{
    public class ROSERespawnZone
    {
        #region zh-CHS ���� | en Properties
        #region zh-CHS ��Ա���� | en Member Variables
        /// <summary>
        /// RespawnZone��GUID
        /// </summary>
        private long m_RespawnZoneGuid;
        #endregion
        public long RespawnZoneGuid
        {
            get { return m_RespawnZoneGuid; }
            set { m_RespawnZoneGuid = value; }
        }

        #region zh-CHS ��Ա���� | en Member Variables
        /// <summary>
        /// ���ˢ�ֵ��ͼ��λ��
        /// </summary>
        private int m_RespawnZoneMapID;
        #endregion
        public int RespawnZoneMapID
        {
            get { return m_RespawnZoneMapID; }
            set { m_RespawnZoneMapID = value; }
        }

        #region zh-CHS ��Ա���� | en Member Variables
        /// <summary>
        /// ˢ�ֵ��ͼ�� X ����
        /// </summary>
        private int m_PositionX;
        #endregion
        public int PositionX
        {
            get { return m_PositionX; }
            set { m_PositionX = value; }
        }

        #region zh-CHS ��Ա���� | en Member Variables
        /// <summary>
        /// ˢ�ֵ��ͼ�� Y ����
        /// </summary>
        private int m_PositionY;
        #endregion
        public int PositionY
        {
            get { return m_PositionY; }
            set { m_PositionY = value; }
        }

        #region zh-CHS ��Ա���� | en Member Variables
        /// <summary>
        /// ˢ�ֵ�����λ�õ� ˢ�ַ�Χ
        /// </summary>
        private int m_Radius;
        #endregion
        public int Radius
        {
            get { return m_Radius; }
            set { m_Radius = value; }
        }

        #region zh-CHS ��Ա���� | en Member Variables
        /// <summary>
        /// �Ƿ����������
        /// </summary>
        private bool m_Master;
        #endregion
        public bool Master
        {
            get { return m_Master; }
            set { m_Master = value; }
        }
        #endregion
    }
}
