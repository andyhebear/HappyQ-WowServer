using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Character;

namespace Demo.Wow.Script.Character
{
    /// <summary>
    /// English Interface
    /// </summary>
    public class ClasseShaman
    {
        /// <summary>
        /// English Interface
        /// </summary>
        public static void StartBirth( WowCharacterCreateInfo playerCreateInfo )
        {
            // English To zhCHS Interface
            ְҵ_������˾.��������( new ħ���������ﴴ����Ϣ( playerCreateInfo ) );
        }

        /// <summary>
        /// English Interface
        /// </summary>
        public static void LevelUp( WowCharacterLevelInfo[] playerLevelStats )
        {
            // English To zhCHS Interface
            ħ������ȼ�������Ϣ[] playerLevelInfoArray = new ħ������ȼ�������Ϣ[playerLevelStats.Length];
            for ( int iIndex = 0; iIndex < playerLevelStats.Length; iIndex++ )
                playerLevelInfoArray[iIndex] = new ħ������ȼ�������Ϣ( playerLevelStats[iIndex] );

            ְҵ_������˾.�ȼ���������( playerLevelInfoArray );
        }
    }
}
