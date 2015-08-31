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

#region zh-CHS 包含名字空间 | en Include AccessLevelspace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Mmose.Core.Network;
using System.Threading;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Entity.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseCharacterState
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 单体
        /// </summary>
        private static BaseCharacterState s_BaseCharacterState = new BaseCharacterState();
        #endregion
        /// <summary>
        /// 单体
        /// </summary>
        public static BaseCharacterState SingletonInstance
        {
            get { return s_BaseCharacterState; }
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateAccessLevel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateAccessLevel
        {
            get { return m_UpdateAccessLevel; }
            internal set { m_UpdateAccessLevel = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateNetState = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateNetState
        {
            get { return m_UpdateNetState; }
            internal set { m_UpdateNetState = value; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        internal void RestoreAll()
        {
            m_UpdateAccessLevel = false;
            m_UpdateNetState = false;
        }
        #endregion

        #region zh-CHS 内部的事件处理函数 | en Internal Event Handlers

        #region zh-CHS AccessLevel事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingAccessLevel( AccessLevel accessLevel, BaseCharacter creature )
        {
            EventHandler<UpdatingAccessLevelEventArgs> tempBeforeEventArgs = m_EventUpdatingAccessLevel;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingAccessLevelEventArgs eventArgs = new UpdatingAccessLevelEventArgs( accessLevel, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedAccessLevel( AccessLevel accessLevel, BaseCharacter creature )
        {
            EventHandler<UpdatedAccessLevelEventArgs> tempAfterEventArgs = m_EventUpdatedAccessLevel;
            if ( tempAfterEventArgs != null )
            {
                UpdatedAccessLevelEventArgs eventArgs = new UpdatedAccessLevelEventArgs( accessLevel, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS NetState事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingNetState( NetState netState, BaseCharacter creature )
        {
            EventHandler<UpdatingNetStateEventArgs> tempBeforeEventArgs = m_EventUpdatingNetState;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingNetStateEventArgs eventArgs = new UpdatingNetStateEventArgs( netState, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedNetState( NetState netState, BaseCharacter creature )
        {
            EventHandler<UpdatedNetStateEventArgs> tempAfterEventArgs = m_EventUpdatedNetState;
            if ( tempAfterEventArgs != null )
            {
                UpdatedNetStateEventArgs eventArgs = new UpdatedNetStateEventArgs( netState, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AccessLevel事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingAccessLevelEventArgs> m_EventUpdatingAccessLevel;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingAccessLevel = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingAccessLevelEventArgs> UpdatingAccessLevel
        {
            add
            {
                m_LockEventUpdatingAccessLevel.Enter();
                {
                    m_EventUpdatingAccessLevel += value;
                }
                m_LockEventUpdatingAccessLevel.Exit();
            }
            remove
            {
                m_LockEventUpdatingAccessLevel.Enter();
                {
                    m_EventUpdatingAccessLevel -= value;
                }
                m_LockEventUpdatingAccessLevel.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedAccessLevelEventArgs> m_EventUpdatedAccessLevel;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedAccessLevel = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedAccessLevelEventArgs> UpdatedAccessLevel
        {
            add
            {
                m_LockEventUpdatedAccessLevel.Enter();
                {
                    m_EventUpdatedAccessLevel += value;
                }
                m_LockEventUpdatedAccessLevel.Exit();
            }
            remove
            {
                m_LockEventUpdatedAccessLevel.Enter();
                {
                    m_EventUpdatedAccessLevel -= value;
                }
                m_LockEventUpdatedAccessLevel.Exit();
            }
        }
        #endregion

        #region zh-CHS NetState事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingNetStateEventArgs> m_EventUpdatingNetState;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingNetState = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingNetStateEventArgs> UpdatingNetState
        {
            add
            {
                m_LockEventUpdatingNetState.Enter();
                {
                    m_EventUpdatingNetState += value;
                }
                m_LockEventUpdatingNetState.Exit();
            }
            remove
            {
                m_LockEventUpdatingNetState.Enter();
                {
                    m_EventUpdatingNetState -= value;
                }
                m_LockEventUpdatingNetState.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedNetStateEventArgs> m_EventUpdatedNetState;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedNetState = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedNetStateEventArgs> UpdatedNetState
        {
            add
            {
                m_LockEventUpdatedNetState.Enter();
                {
                    m_EventUpdatedNetState += value;
                }
                m_LockEventUpdatedNetState.Exit();
            }
            remove
            {
                m_LockEventUpdatedNetState.Enter();
                {
                    m_EventUpdatedNetState -= value;
                }
                m_LockEventUpdatedNetState.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion