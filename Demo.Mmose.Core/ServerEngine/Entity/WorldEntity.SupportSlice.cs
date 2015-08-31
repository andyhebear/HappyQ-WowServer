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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SupportSlice;
using Demo.Mmose.Core.World;
using System.Threading;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WorldEntity : ISupportSlice
    {
        #region zh-CHS 物体的主处理行为 | en
        /// <summary>
        /// 
        /// </summary>
        public void UpdateSlice()
        {
            if ( m_Deleted == true )
                return;

            BaseWorld tempWorld = m_World;
            if ( tempWorld != null )
            {
                tempWorld.SliceUpdate.UpdateSlice( this );
                tempWorld.SetWorldSignal();
            }
            else
                throw new Exception( "GameEntity.UpdateSlice(...) - m_World == null error!" );
        }
        #endregion

        #region zh-CHS ISupportSlice接口实现 | en ISupportSlice Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        public virtual void OnProcessSlice( DateTime updateDelta )
        {
            IArtificialIntelligence tempAI = m_ArtificialIntelligence;
            if ( tempAI != null )
                tempAI.SliceAI();

            EventHandler<ProcessSliceEventArgs> tempEventArgs = m_EventSlice;
            if ( tempEventArgs != null )
            {
                ProcessSliceEventArgs eventArgs = new ProcessSliceEventArgs( updateDelta, this );
                tempEventArgs( this, eventArgs );
            }
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SliceSupport m_SliceSupport = new SliceSupport();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool InLockProcessSlice()
        {
            return m_SliceSupport.InLockProcessSlice();
        }

        /// <summary>
        /// 
        /// </summary>
        public void OutLockProcessSlice()
        {
            m_SliceSupport.OutLockProcessSlice();
        }
        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS Slice事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<ProcessSliceEventArgs> m_EventSlice;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventSlice = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ProcessSliceEventArgs> Slice
        {
            add
            {
                m_LockEventSlice.Enter();
                {
                    m_EventSlice += value;
                }
                m_LockEventSlice.Exit();
            }
            remove
            {
                m_LockEventSlice.Enter();
                {
                    m_EventSlice -= value;
                }
                m_LockEventSlice.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion