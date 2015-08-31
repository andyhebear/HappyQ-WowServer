using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Collections;

namespace Demo.Wow.WorldServer.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class GlobalCharacterManager
    {
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, WowCharacter> m_WowPlayerInfoFromGuid = new SafeDictionary<long, WowCharacter>();
        
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, string> m_WowPlayerNameFromGuid = new SafeDictionary<long, string>();

        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<string, long> m_WowPlayerGuidFromName = new SafeDictionary<string, long>();

        /// <summary>
        /// 
        /// </summary>
        public void AddPlayerInfo( string playerName, long iGuid, WowCharacter wowPlayerInfo )
        {
            m_WowPlayerNameFromGuid.Add( iGuid, playerName );
            m_WowPlayerGuidFromName.Add( playerName, iGuid );

            m_WowPlayerInfoFromGuid.Add( iGuid, wowPlayerInfo );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WowCharacter GetPlayerInfo( string playerName )
        {
            return m_WowPlayerInfoFromGuid.GetValue( GetGuidFromName( playerName ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WowCharacter GetPlayerInfo( long iGuid )
        {
            return m_WowPlayerInfoFromGuid.GetValue( iGuid );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetNameFromGuid( long iGuid )
        {
            return m_WowPlayerNameFromGuid.GetValue( iGuid );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long GetGuidFromName( string playerName )
        {
            return m_WowPlayerGuidFromName.GetValue( playerName );
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemovePlayerInfo( string playerName )
        {
            m_WowPlayerInfoFromGuid.Remove( GetGuidFromName( playerName ) );
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemovePlayerInfo( long iGuid )
        {
            m_WowPlayerInfoFromGuid.Remove( iGuid );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WowCharacter[] ToArray()
        {
            return m_WowPlayerInfoFromGuid.ToArrayValues();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_WowPlayerInfoFromGuid.Count; }
        }
    }
}
