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
    public class 探索酬劳
    {
        /// <summary>
        /// 
        /// </summary>
        private ExplorationReward m_ExplorationReward = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fff"></param>
        public 探索酬劳( ExplorationReward explorationReward )
        {
            m_ExplorationReward = explorationReward;
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 等级
        {
            get { return m_ExplorationReward.Level; }
            set { m_ExplorationReward.Level = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 经验
        {
            get { return m_ExplorationReward.Experience; }
            set { m_ExplorationReward.Experience = value; }
        }

    }
}
