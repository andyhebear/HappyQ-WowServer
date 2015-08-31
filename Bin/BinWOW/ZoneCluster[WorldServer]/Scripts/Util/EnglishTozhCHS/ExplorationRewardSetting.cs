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
    public static class ExplorationRewardSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public static void ExplorationRewardUpdate( ExplorationReward[] explorationReward )
        {
            // English To zhCHS Interface
            探索酬劳[] explorationRewardArray = new 探索酬劳[explorationReward.Length];
            for ( int iIndex = 0; iIndex < explorationReward.Length; iIndex++ )
                explorationRewardArray[iIndex] = new 探索酬劳( explorationReward[iIndex] );

            探索酬劳设置.设置探索酬劳信息( explorationRewardArray );
        }
    }
}
