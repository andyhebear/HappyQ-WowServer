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
using System.Collections.Generic;
using System.Threading;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.GameObject
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseGameObjectState
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 单体
        /// </summary>
        private static BaseGameObjectState s_BaseGameObjectState = new BaseGameObjectState();
        #endregion
        /// <summary>
        /// 单体
        /// </summary>
        public static BaseGameObjectState SingletonInstance
        {
            get { return s_BaseGameObjectState; }
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_UpdateName = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdateName
        {
            get { return m_UpdateName; }
            internal set { m_UpdateName = value; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        internal void RestoreAll()
        {
            m_UpdateName = false;
        }
        #endregion

        #region zh-CHS 内部的事件处理函数 | en Internal Event Handlers

        #region zh-CHS Name事件 | en Public Event
        /// <summary>
        /// 
        /// </summary>
        internal bool OnUpdatingName( string strName, BaseGameObject creature )
        {
            EventHandler<UpdatingNameEventArgs> tempBeforeEventArgs = m_EventUpdatingName;
            if ( tempBeforeEventArgs != null )
            {
                UpdatingNameEventArgs eventArgs = new UpdatingNameEventArgs( strName, creature );
                tempBeforeEventArgs( this, eventArgs );

                return eventArgs.IsCancel;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnUpdatedName( string strName, BaseGameObject creature )
        {
            EventHandler<UpdatedNameEventArgs> tempAfterEventArgs = m_EventUpdatedName;
            if ( tempAfterEventArgs != null )
            {
                UpdatedNameEventArgs eventArgs = new UpdatedNameEventArgs( strName, creature );
                tempAfterEventArgs( this, eventArgs );
            }
        }
        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS Name事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatingNameEventArgs> m_EventUpdatingName;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatingName = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatingNameEventArgs> UpdatingName
        {
            add
            {
                m_LockEventUpdatingName.Enter();
                {
                    m_EventUpdatingName += value;
                }
                m_LockEventUpdatingName.Exit();
            }
            remove
            {
                m_LockEventUpdatingName.Enter();
                {
                    m_EventUpdatingName -= value;
                }
                m_LockEventUpdatingName.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<UpdatedNameEventArgs> m_EventUpdatedName;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventUpdatedName = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UpdatedNameEventArgs> UpdatedName
        {
            add
            {
                m_LockEventUpdatedName.Enter();
                {
                    m_EventUpdatedName += value;
                }
                m_LockEventUpdatedName.Exit();
            }
            remove
            {
                m_LockEventUpdatedName.Enter();
                {
                    m_EventUpdatedName -= value;
                }
                m_LockEventUpdatedName.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion