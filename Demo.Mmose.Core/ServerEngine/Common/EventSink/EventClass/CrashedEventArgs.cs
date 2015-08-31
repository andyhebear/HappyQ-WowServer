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
#endregion

namespace Demo.Mmose.Core.Common.EventSkin
{
    /// <summary>
    /// 
    /// </summary>
    public class CrashedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private Exception m_Exception = null;
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception
        {
            get { return m_Exception; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public CrashedEventArgs( Exception exception )
        {
            m_Exception = exception;
        }
    }
}
#endregion