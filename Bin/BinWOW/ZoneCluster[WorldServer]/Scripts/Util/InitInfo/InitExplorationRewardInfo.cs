using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Common;

namespace Demo.Wow.Script.Util
{
    public class InitExplorationRewardInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public const int PLAYER_MAX_LEVEL = 80;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlayerCreateInfoManager"></param>
        public static void InitWowExplorationReward( WowExplorationRewardHandler explorationRewardHandler )
        {
            ExplorationReward[] explorationRewardArray = new ExplorationReward[PLAYER_MAX_LEVEL];

            // Init
            for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
            {
                explorationRewardArray[iIndex] = new ExplorationReward();

                explorationRewardArray[iIndex].Level = (uint)iIndex + 1;
            }

            ExplorationRewardSetting.ExplorationRewardUpdate( explorationRewardArray );

            // Prevent Modify
            for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
            {
                explorationRewardArray[iIndex].Level = (uint)iIndex + 1;
            }
        }
    }
}
