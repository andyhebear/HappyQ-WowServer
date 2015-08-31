#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Diagnostics;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.GameCommand
{
    /// <summary>
    /// 
    /// </summary>
    public class GameCommandManager
    {
        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<string, GameCommandPrefix> m_GameCommandPrefixsIgnoreCase = new SafeDictionary<string, GameCommandPrefix>();
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<string, GameCommandPrefix> m_GameCommandPrefixsInvariant = new SafeDictionary<string, GameCommandPrefix>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <param name="iAccessLevel"></param>
        /// <param name="eventGameCommand"></param>
        public GameCommandPrefix Register( string strPrefix )
        {
            return Register( strPrefix, true );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strPrefix"></param>
        /// <param name="bIgnoreCase"></param>
        /// <returns></returns>
        public GameCommandPrefix Register( string strPrefix, bool bIgnoreCase )
        {
            if ( strPrefix == null || strPrefix == string.Empty )
                throw new Exception( "GameCommandManager.Register(...) - strPrefix == null || strPrefix == string.Empty error!" );

            GameCommandPrefix gameCommandPrefix = null;
            if ( bIgnoreCase == true )
            {
                string strIgnoreCase = strPrefix.ToLower();

                gameCommandPrefix = m_GameCommandPrefixsIgnoreCase.GetValue( strIgnoreCase );
                if ( gameCommandPrefix == null )
                {
                    gameCommandPrefix = new GameCommandPrefix();
                    gameCommandPrefix.Prefix = strPrefix;
                    gameCommandPrefix.IgnoreCase = bIgnoreCase;

                    m_GameCommandPrefixsIgnoreCase.Add( strIgnoreCase, gameCommandPrefix );
                }
            }
            else
            {
                gameCommandPrefix = m_GameCommandPrefixsInvariant.GetValue( strPrefix );
                if ( gameCommandPrefix == null )
                {
                    gameCommandPrefix = new GameCommandPrefix();
                    gameCommandPrefix.Prefix = strPrefix;
                    gameCommandPrefix.IgnoreCase = bIgnoreCase;

                    m_GameCommandPrefixsInvariant.Add( gameCommandPrefix.Prefix, gameCommandPrefix );
                }
            }

            return gameCommandPrefix;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <param name="iAccessLevel"></param>
        /// <param name="eventGameCommand"></param>
        public void Register( GameCommandPrefix gameCommandPrefix )
        {
            if ( gameCommandPrefix.IgnoreCase == true )
                m_GameCommandPrefixsIgnoreCase.Add( gameCommandPrefix.Prefix.ToLower(), gameCommandPrefix );
            else
                m_GameCommandPrefixsInvariant.Add( gameCommandPrefix.Prefix, gameCommandPrefix );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommandLine"></param>
        /// <param name="bIgnoreCase"></param>
        /// <returns></returns>
        public GameCommandPrefix GetGameCommandPrefix( string strGameCommandLine )
        {
            return GetGameCommandPrefix( strGameCommandLine, true );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <returns></returns>
        public GameCommandPrefix GetGameCommandPrefix( string strGameCommandLine, bool bIgnoreCase )
        {
            if ( strGameCommandLine == null || strGameCommandLine == string.Empty )
                return null;

            if ( bIgnoreCase == true )
            {
                GameCommandPrefix[] gameCommandPrefixArray = m_GameCommandPrefixsIgnoreCase.ToArrayValues();

                for ( int iIndex = 0; iIndex < gameCommandPrefixArray.Length; iIndex++ )
                {
                    GameCommandPrefix gameCommandPrefix = gameCommandPrefixArray[iIndex];
                    if ( Insensitive.StartsWith( strGameCommandLine, gameCommandPrefix.Prefix ) == false )
                        continue;

                    return gameCommandPrefix;
                }
            }
            else
            {
                GameCommandPrefix[] gameCommandPrefixArray = m_GameCommandPrefixsInvariant.ToArrayValues();
                for ( int iIndex = 0; iIndex < gameCommandPrefixArray.Length; iIndex++ )
                {
                    GameCommandPrefix gameCommandPrefix = gameCommandPrefixArray[iIndex];
                    if ( strGameCommandLine.StartsWith( gameCommandPrefix.Prefix ) == false )
                        continue;

                    return gameCommandPrefix;
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <returns></returns>
        public bool CallGameCommand( NetState netState, string strGameCommandLine )
        {
            return CallGameCommand( netState, strGameCommandLine, true, true );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <returns></returns>
        public bool CallGameCommand( NetState netState, string strGameCommandLine, bool bIgnoreCasePrefix, bool bIgnoreCaseGameCommand )
        {
            GameCommandPrefix gameCommandPrefix = this.GetGameCommandPrefix( strGameCommandLine, bIgnoreCasePrefix );
            if ( gameCommandPrefix == null )
                return false;

            return gameCommandPrefix.CallGameCommand( netState, strGameCommandLine, bIgnoreCaseGameCommand );
        }

        #endregion
    }
}
#endregion