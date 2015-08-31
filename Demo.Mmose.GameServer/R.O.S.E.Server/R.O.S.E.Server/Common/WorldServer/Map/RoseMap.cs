using System;
using System.Collections.Generic;
using System.Text;
using Demo_G.O.S.E.ServerEngine.Map;

namespace Demo_R.O.S.E.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class RoseMap : GeneralMap
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapID"></param>
        /// <param name="iWidth"></param>
        /// <param name="iHeight"></param>
        /// <param name="strName"></param>
        /// <param name="bPVP"></param>
        public RoseMap( int mapID, int iWidth, int iHeight, string strMapName, bool bPVP )
            : base( mapID, iWidth, iHeight, strMapName )
        {
            m_bPVP = bPVP;
        }

        /// <summary>
        /// 
        /// </summary>
        private bool m_bPVP;
        /// <summary>
        /// 
        /// </summary>
        public bool PVP
        {
            get { return m_bPVP; }
            set { m_bPVP = value; }
        }
    }
}
