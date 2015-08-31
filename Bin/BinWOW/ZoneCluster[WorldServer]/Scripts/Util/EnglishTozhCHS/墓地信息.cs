using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Common;

namespace Demo.Wow.Script.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class 墓地信息
    {
        /// <summary>
        /// 
        /// </summary>
        private GraveyardInfo m_GraveyardInfo = new GraveyardInfo();
        /// <summary>
        /// 
        /// </summary>
        internal GraveyardInfo GraveyardInfo
        {
            get { return m_GraveyardInfo; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fff"></param>
        public 墓地信息()
        {
        }

        /// <summary>
        /// 对应于WorldSafeLocs.dbc的ID编号
        /// </summary>
        public uint 墓地编号
        {
            get { return m_GraveyardInfo.GraveyardId; }
            set { m_GraveyardInfo.GraveyardId = value; }
        }

        /// <summary>
        /// 对应于Maps.dbc的ID编号
        /// </summary>
        public uint 地图
        {
            get { return m_GraveyardInfo.GhostMap; }
            set { m_GraveyardInfo.GhostMap = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 地域
        {
            get { return m_GraveyardInfo.GhostZone; }
            set { m_GraveyardInfo.GhostZone = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阵营
        {
            get { return m_GraveyardInfo.Faction; }
            set { m_GraveyardInfo.Faction = value; }
        }

    }
}
