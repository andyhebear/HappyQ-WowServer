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
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common.Atom;
#endregion

namespace Demo.Mmose.Core.Common.SupportSlice
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SliceSupport : ISupportSlice
    {
        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        public void OnProcessSlice( DateTime updateDelta )
        {
            EventHandler<EventArgs> tempEventArgs = m_ThreadEventSlice;
            if ( tempEventArgs != null )
            {
                EventArgs eventArgs = EventArgs.Empty;
                tempEventArgs( this, eventArgs );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private LockInOut m_LockProcessSlice = new LockInOut( false );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool InLockProcessSlice()
        {
            return m_LockProcessSlice.InLock();
        }

        /// <summary>
        /// 
        /// </summary>
        public void OutLockProcessSlice()
        {
            m_LockProcessSlice.OutLock();
        }
        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS Slice事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<EventArgs> m_ThreadEventSlice;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockThreadEventSlice = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> ThreadSlice
        {
            add
            {
                m_LockThreadEventSlice.Enter();
                {
                    m_ThreadEventSlice += value;
                }
                m_LockThreadEventSlice.Exit();
            }
            remove
            {
                m_LockThreadEventSlice.Enter();
                {
                    m_ThreadEventSlice -= value;
                }
                m_LockThreadEventSlice.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion
