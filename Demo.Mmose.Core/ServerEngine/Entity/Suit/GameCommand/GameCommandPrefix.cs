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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.GameCommand
{
    /// <summary>
    /// 
    /// </summary>
    public class GameCommandPrefix
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strPrefix = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Prefix
        {
            get { return m_strPrefix; }
            internal set { m_strPrefix = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIgnoreCase = true;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IgnoreCase
        {
            get { return m_bIgnoreCase; }
            internal set { m_bIgnoreCase = value; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<string, GameCommandHandler> m_GameCommandsIgnoreCase = new SafeDictionary<string, GameCommandHandler>();
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<string, GameCommandHandler> m_GameCommandsInvariant = new SafeDictionary<string, GameCommandHandler>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <param name="iAccessLevel"></param>
        /// <param name="eventGameCommand"></param>
        public GameCommandHandler Register( string strGameCommand, AccessLevel accessLevel, DelegateGameCommandCall delegateGameCommandCall )
        {
            return Register( strGameCommand, true, accessLevel, delegateGameCommandCall );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <param name="caseIgnore"></param>
        /// <param name="accessLevel"></param>
        /// <param name="delegateGameCommandCall"></param>
        /// <returns></returns>
        public GameCommandHandler Register( string strGameCommand, bool bIgnoreCase, AccessLevel accessLevel, DelegateGameCommandCall delegateGameCommandCall )
        {
            if ( strGameCommand == null || strGameCommand == string.Empty )
                throw new Exception( "GameCommandManager.Register(...) - strGameCommand == null || strGameCommand == string.Empty error!" );

            GameCommandHandler gameCommand = null;
            if ( bIgnoreCase == true )
            {
                string strIgnoreCase = strGameCommand.ToLower();

                gameCommand = m_GameCommandsIgnoreCase.GetValue( strIgnoreCase );
                if ( gameCommand == null )
                {
                    gameCommand = new GameCommandHandler();
                    gameCommand.GameCommand = strGameCommand;
                    gameCommand.IgnoreCase = bIgnoreCase;
                    gameCommand.AccessLevel = accessLevel;

                    m_GameCommandsIgnoreCase.Add( strIgnoreCase, gameCommand );
                }
            }
            else
            {
                gameCommand = m_GameCommandsInvariant.GetValue( strGameCommand );
                if ( gameCommand == null )
                {
                    gameCommand = new GameCommandHandler();
                    gameCommand.GameCommand = strGameCommand;
                    gameCommand.IgnoreCase = bIgnoreCase;
                    gameCommand.AccessLevel = accessLevel;

                    m_GameCommandsInvariant.Add( strGameCommand, gameCommand );
                }
            }

            if ( delegateGameCommandCall != null )
                gameCommand.ThreadGameCommandCall += new EventHandler<GameCommandEventArgs>( delegateGameCommandCall );

            return gameCommand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <returns></returns>
        public void Register( GameCommandHandler gameCommandHandler )
        {
            if ( gameCommandHandler.IgnoreCase == true )
                m_GameCommandsIgnoreCase.Add( gameCommandHandler.GameCommand.ToLower(), gameCommandHandler );
            else
                m_GameCommandsInvariant.Add( gameCommandHandler.GameCommand, gameCommandHandler );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <returns></returns>
        public GameCommandHandler GetGameCommand( string strGameCommandLine )
        {
            return this.GetGameCommand( strGameCommandLine, true );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommand"></param>
        /// <returns></returns>
        public GameCommandHandler GetGameCommand( string strGameCommandLine, bool bIgnoreCase )
        {
            if ( bIgnoreCase == true )
            {
                if ( Insensitive.StartsWith( strGameCommandLine, m_strPrefix ) == false )
                    return null;
            }
            else
            {
                if ( strGameCommandLine.StartsWith( m_strPrefix ) == false )
                    return null;
            }

            int iIndexOf = strGameCommandLine.IndexOf( " ", m_strPrefix.Length );
            if ( iIndexOf <= 0 )
                return null;

            string strGameCommand = strGameCommandLine.Substring( m_strPrefix.Length, iIndexOf - m_strPrefix.Length );

            if ( bIgnoreCase == true )
                return m_GameCommandsIgnoreCase.GetValue( strGameCommand.ToLower() );
            else
                return m_GameCommandsInvariant.GetValue( strGameCommand );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommandLine"></param>
        /// <param name="netState"></param>
        /// <returns></returns>
        public bool CallGameCommand( NetState netState, string strGameCommandLine )
        {
            return this.CallGameCommand( netState, strGameCommandLine, true );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGameCommandLine"></param>
        /// <param name="netState"></param>
        /// <returns></returns>
        public bool CallGameCommand( NetState netState, string strGameCommandLine, bool bIgnoreCaseGameCommand )
        {
            if ( bIgnoreCaseGameCommand == true )
            {
                if ( Insensitive.StartsWith( strGameCommandLine, m_strPrefix ) == false )
                    return false;
            }
            else
            {
                if ( strGameCommandLine.StartsWith( m_strPrefix ) == false )
                    return false;
            }

            int iIndexOf = strGameCommandLine.IndexOf( " ", m_strPrefix.Length );
            if ( iIndexOf <= 0 )
                return false;

            string strGameCommand = strGameCommandLine.Substring( m_strPrefix.Length, iIndexOf - m_strPrefix.Length );

            GameCommandHandler gameCommandHandler = null;
            if ( bIgnoreCaseGameCommand == true )
                gameCommandHandler = m_GameCommandsIgnoreCase.GetValue( strGameCommand.ToLower() );
            else
                gameCommandHandler = m_GameCommandsInvariant.GetValue( strGameCommand );

            if ( gameCommandHandler == null )
                return false;

            string strGameCommandInfo = strGameCommandLine.Substring( iIndexOf + 1 );

            gameCommandHandler.CallGameCommand( netState, strGameCommandInfo );

            return true;
        }
        #endregion
    }
}
#endregion
