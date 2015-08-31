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
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.GameCommand
{
    /// <summary>
    /// 游戏内的命令行
    /// </summary>
    public class GameCommandHandler
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strGameCommand = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string GameCommand
        {
            get { return m_strGameCommand; }
            internal set { m_strGameCommand = value; }
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

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private AccessLevel m_iAccessLevel = AccessLevel.GameMaster;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public AccessLevel AccessLevel
        {
            get { return m_iAccessLevel; }
            internal set { m_iAccessLevel = value; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        public void CallGameCommand( NetState netState, string strGameCommandInfo )
        {
            EventHandler<GameCommandEventArgs> tempEventArgs = m_ThreadEventGameCommandCall;
            if ( tempEventArgs != null )
            {
                GameCommandEventArgs eventArgs = new GameCommandEventArgs( netState, strGameCommandInfo );
                tempEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS 共有事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<GameCommandEventArgs> m_ThreadEventGameCommandCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddAuraCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<GameCommandEventArgs> ThreadGameCommandCall
        {
            add
            {
                m_LockThreadEventBeforeAddAuraCall.EnterWriteLock();
                {
                    m_ThreadEventGameCommandCall += value;
                }
                m_LockThreadEventBeforeAddAuraCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddAuraCall.EnterWriteLock();
                {
                    m_ThreadEventGameCommandCall -= value;
                }
                m_LockThreadEventBeforeAddAuraCall.ExitWriteLock();
            }
        }
        #endregion
    }
}
#endregion