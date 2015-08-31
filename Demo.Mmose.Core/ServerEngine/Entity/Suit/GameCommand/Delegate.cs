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
using Demo.Mmose.Core.Network;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.GameCommand
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// 
    /// </summary>
    public class GameCommandEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        public GameCommandEventArgs( NetState netState, string strGameCommandInfo )
        {
            m_NetState = netState;
            m_strGameCommandInfo = strGameCommandInfo;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strGameCommandInfo = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string GameCommandInfo
        {
            get { return m_strGameCommandInfo; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NetState m_NetState = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public NetState NetState
        {
            get { return m_NetState; }
        }
        #endregion
    }
    #endregion

    #region zh-CHS 共有委托 | en Public Delegate
    /// <summary>
    /// 
    /// </summary>
    /// <param name="newNetState"></param>
    public delegate void DelegateGameCommandCall( object sender, GameCommandEventArgs eventArgs );
    #endregion
}
#endregion