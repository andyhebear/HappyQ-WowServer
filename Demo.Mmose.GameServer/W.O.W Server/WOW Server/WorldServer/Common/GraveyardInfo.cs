using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class GraveyardInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private uint m_GraveyardId = 0;
        /// <summary>
        /// 
        /// </summary>
        public uint GraveyardId
        {
            get { return m_GraveyardId; }
            set { m_GraveyardId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_GhostMap = 0;
        /// <summary>
        /// 
        /// </summary>
        public uint GhostMap
        {
            get { return m_GhostMap; }
            set { m_GhostMap = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_GhostZone = 0;
        /// <summary>
        /// 
        /// </summary>
        public uint GhostZone
        {
            get { return m_GhostZone; }
            set { m_GhostZone = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_Faction = 0;
        /// <summary>
        /// 
        /// </summary>
        public uint Faction
        {
            get { return m_Faction; }
            set { m_Faction = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_GraveyardMap = 0;
        /// <summary>
        /// 
        /// </summary>
        internal uint GraveyardMap
        {
            get { return m_GraveyardMap; }
            set { m_GraveyardMap = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string m_GraveyardName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        internal string GraveyardName
        {
            get { return m_GraveyardName; }
            set { m_GraveyardName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private float m_GraveyardX = 0;
        /// <summary>
        /// 
        /// </summary>
        internal float GraveyardX
        {
            get { return m_GraveyardX; }
            set { m_GraveyardX = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private float m_GraveyardY = 0;
        /// <summary>
        /// 
        /// </summary>
        internal float GraveyardY
        {
            get { return m_GraveyardY; }
            set { m_GraveyardY = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private float m_GraveyardZ = 0;
        /// <summary>
        /// 
        /// </summary>
        internal float GraveyardZ
        {
            get { return m_GraveyardZ; }
            set { m_GraveyardZ = value; }
        }
    }
}
