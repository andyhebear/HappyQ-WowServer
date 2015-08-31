using System;
using System.Text;
using System.Collections.Generic;

namespace Demo_R.O.S.E.TeleportGate
{
    /// <summary>
    /// 远距离传递之门
    /// </summary>
    public class ROSETeleportGate
    {
        #region zh-CHS 属性 | en Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 远距离传递之门的GUID
        /// </summary>
        private long m_TeleGateGuid;
        #endregion
        public long TeleGateGuid
        {
            get { return m_TeleGateGuid; }
            set { m_TeleGateGuid = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        // 地图的标记符号(ID)
        private int m_TeleGateMapID;
        #endregion
        public int TeleGateMapID
        {
            get { return m_TeleGateMapID; }
            set { m_TeleGateMapID = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        // 地图的 X 坐标
        private int m_PositionX;
        #endregion
        public int PositionX
        {
            get { return m_PositionX; }
            set { m_PositionX = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        // 地图的 Y 坐标
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
