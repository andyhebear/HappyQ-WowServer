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
    public class WowCharacterCreateInfoHandler
    {
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<uint, SafeDictionary<uint, WowCharacterCreateInfo>> m_PlayerCreateInfo = new SafeDictionary<uint, SafeDictionary<uint, WowCharacterCreateInfo>>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRace"></param>
        /// <param name="iClass"></param>
        /// <param name="playerLevelStats"></param>
        public void AddCreateInfo( uint iRace, uint iClass, WowCharacterCreateInfo playerCreateInfo )
        {
            SafeDictionary<uint, WowCharacterCreateInfo> safeWowPlayerCreateInfo = m_PlayerCreateInfo.GetValue( iRace );
            if ( safeWowPlayerCreateInfo == null )
                safeWowPlayerCreateInfo = new SafeDictionary<uint, WowCharacterCreateInfo>();

            safeWowPlayerCreateInfo.Add( iClass, playerCreateInfo );

            m_PlayerCreateInfo.Add( iRace, safeWowPlayerCreateInfo );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRace"></param>
        /// <param name="iClass"></param>
        /// <returns></returns>
        public WowCharacterCreateInfo GetCreateInfo( uint iRace, uint iClass )
        {
            SafeDictionary<uint, WowCharacterCreateInfo> safeWowPlayerCreateInfo = m_PlayerCreateInfo.GetValue( iRace );
            if ( safeWowPlayerCreateInfo == null )
                return null;

            WowCharacterCreateInfo playerCreateInfo = safeWowPlayerCreateInfo.GetValue( iClass );
            if ( playerCreateInfo == null )
                return null;
            else
                return playerCreateInfo;
        }
    }
}
