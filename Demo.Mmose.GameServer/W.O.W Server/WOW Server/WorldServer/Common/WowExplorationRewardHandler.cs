using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Collections;

namespace Demo.Wow.WorldServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class WowExplorationRewardHandler
    {
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<uint, ExplorationReward> m_ExplorationReward = new SafeDictionary<uint, ExplorationReward>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRace"></param>
        /// <param name="iClass"></param>
        /// <param name="playerLevelStats"></param>
        public void AddExplorationReward( uint iLevel, ExplorationReward explorationReward )
        {
            m_ExplorationReward.Add( iLevel, explorationReward );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRace"></param>
        /// <param name="iClass"></param>
        /// <returns></returns>
        public ExplorationReward GetExplorationReward( uint iLevel )
        {
            ExplorationReward explorationReward = m_ExplorationReward.GetValue( iLevel );
            if ( explorationReward == null )
                return null;
            else
                return explorationReward;
        }
    }
}
