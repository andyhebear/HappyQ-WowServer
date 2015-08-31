using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ExplorationReward
    {
        /// <summary>
        /// 
        /// </summary>
        private uint m_Level = 0;
        /// <summary>
        /// 
        /// </summary>
        public uint Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_Experience = 0;
        /// <summary>
        /// 
        /// </summary>
        public uint Experience
        {
            get { return m_Experience; }
            set { m_Experience = value; }
        }
    }
}
