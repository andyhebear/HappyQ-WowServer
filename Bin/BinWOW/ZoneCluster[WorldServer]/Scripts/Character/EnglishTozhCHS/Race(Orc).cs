using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Character;

namespace Demo.Wow.Script.Character
{
    /// <summary>
    /// English Interface
    /// </summary>
    public class RaceOrc
    {
        /// <summary>
        /// English Interface
        /// </summary>
        public static void StartBirth( WowCharacterCreateInfo playerCreateInfo )
        {
            // English To zhCHS Interface
            种族_兽人.出生设置( new 魔兽世界人物创建信息( playerCreateInfo ) );
        }

        /// <summary>
        /// English Interface
        /// </summary>
        public static void LevelUp( WowCharacterLevelInfo[] playerLevelStats )
        {
            // English To zhCHS Interface
            魔兽世界等级上升信息[] playerLevelInfoArray = new 魔兽世界等级上升信息[playerLevelStats.Length];
            for ( int iIndex = 0; iIndex < playerLevelStats.Length; iIndex++ )
                playerLevelInfoArray[iIndex] = new 魔兽世界等级上升信息( playerLevelStats[iIndex] );

            种族_矮人.等级上升设置( playerLevelInfoArray );
        }
    }
}
