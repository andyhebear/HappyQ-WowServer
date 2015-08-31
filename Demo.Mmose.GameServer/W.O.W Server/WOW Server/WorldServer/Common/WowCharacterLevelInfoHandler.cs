using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Wow.WorldServer.Character;
using Demo.Mmose.Core.Common.Collections;

namespace Demo.Wow.WorldServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class WowCharacterLevelInfoHandler
    {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<uint, Dictionary<uint, WowCharacterLevelInfo[]>> m_PlayerLevelStats = new Dictionary<uint, Dictionary<uint, WowCharacterLevelInfo[]>>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRace"></param>
        /// <param name="iClass"></param>
        /// <param name="playerLevelStats"></param>
        public void AddLevelInfo( uint iRace, uint iClass, WowCharacterLevelInfo[] playerLevelStats )
        {
            Dictionary<uint, WowCharacterLevelInfo[]> wowPlayerLevelStats = null;
            m_PlayerLevelStats.TryGetValue( iRace, out wowPlayerLevelStats );

            if ( wowPlayerLevelStats == null )
            {
                wowPlayerLevelStats = new Dictionary<uint, WowCharacterLevelInfo[]>();
                m_PlayerLevelStats.Add( iRace, wowPlayerLevelStats );
            }

            wowPlayerLevelStats[iClass] = playerLevelStats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRace"></param>
        /// <param name="iClass"></param>
        /// <returns></returns>
        public WowCharacterLevelInfo[] GetLevelInfo( uint iRace, uint iClass )
        {
            Dictionary<uint, WowCharacterLevelInfo[]> wowPlayerLevelStats = null;
            m_PlayerLevelStats.TryGetValue( iRace, out wowPlayerLevelStats );

            if ( wowPlayerLevelStats == null )
                return null;

            WowCharacterLevelInfo[] playerLevelStats = null;

            wowPlayerLevelStats.TryGetValue( iClass, out playerLevelStats );
            if ( playerLevelStats == null )
                return null;
            else
                return playerLevelStats;
        }
    }
}