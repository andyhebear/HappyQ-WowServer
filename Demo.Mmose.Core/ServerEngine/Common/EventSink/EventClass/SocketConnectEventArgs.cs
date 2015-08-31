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
using Demo.Mmose.Net;
#endregion

namespace Demo.Mmose.Core.Common.EventSkin
{
    /// <summary>
    /// 
    /// </summary>
    public class SocketConnectEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientHandler"></param>
        public SocketConnectEventArgs( ServiceHandle clientHandler )
        {
            m_ClientHandler = clientHandler;
        }

        /// <summary>
        /// 
        /// </summary>
        private ServiceHandle m_ClientHandler;
        /// <summary>
        /// 
        /// </summary>
        public ServiceHandle Socket
        {
            get { return m_ClientHandler; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool m_AllowConnection = true;
        /// <summary>
        /// 
        /// </summary>
        public bool AllowConnection
        {
            get { return m_AllowConnection; }
            set { m_AllowConnection = value; }
        }
    }
}
#endregion