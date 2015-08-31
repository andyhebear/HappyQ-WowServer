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
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Guild
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseGuildHandler<T, V>
        where T : BaseGuild<V>
        where V : BaseGuildMember
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Count 属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_Guilds.Count; }
        }
        #endregion

        #region zh-CHS Guild列表 属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_Guilds = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(行会)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_Guilds.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public bool AddGuild( long iGuildSerial, T guildT )
        {
            if ( guildT == null )
            {
                Debug.WriteLine( "BaseGuildHandler.AddGuildMember(...) - guildT == null error!" );

                return false;
            }

            EventHandler<BeforeAddGuildCallEventArgs<T, V>> tempBeforeEventArgs = m_ThreadEventBeforeAddGuildCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddGuildCallEventArgs<T, V> eventArgs = new BeforeAddGuildCallEventArgs<T, V>( guildT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Guilds.Add( iGuildSerial, guildT );

            EventHandler<AfterAddGuildCallEventArgs<T, V>> tempAfterEventArgs = m_ThreadEventAfterAddGuildCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddGuildCallEventArgs<T, V> eventArgs = new AfterAddGuildCallEventArgs<T, V>( guildT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public bool RemoveGuild( long iGuildSerial )
        {
            T guildT = FindGuildOnSerial( iGuildSerial );
            if ( guildT == null )
                return false;

            EventHandler<BeforeRemoveGuildCallEventArgs<T, V>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveGuildCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveGuildCallEventArgs<T, V> eventArgs = new BeforeRemoveGuildCallEventArgs<T, V>( guildT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Guilds.Remove( iGuildSerial );

            EventHandler<AfterRemoveGuildCallEventArgs<T, V>> tempAfterEventArgs = m_ThreadEventAfterRemoveGuildCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveGuildCallEventArgs<T, V> eventArgs = new AfterRemoveGuildCallEventArgs<T, V>( guildT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public T FindGuildOnSerial( long iGuildSerial )
        {
            return m_Guilds.GetValue( iGuildSerial );
        }

        #endregion

        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddGuildCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddGuildCallEventArgs<T, V>> m_ThreadEventBeforeAddGuildCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddGuildCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddGuildCallEventArgs<T, V>> ThreadBeforeAddGuildCall
        {
            add
            {
                m_LockThreadEventBeforeAddGuildCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddGuildCall += value;
                }
                m_LockThreadEventBeforeAddGuildCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddGuildCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddGuildCall -= value;
                }
                m_LockThreadEventBeforeAddGuildCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddGuildCallEventArgs<T, V>> m_ThreadEventAfterAddGuildCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterAddGuildCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddGuildCallEventArgs<T, V>> ThreadAfterAddGuildCall
        {
            add
            {
                m_LockThreadEventAfterAddGuildCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddGuildCall += value;
                }
                m_LockThreadEventAfterAddGuildCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterAddGuildCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddGuildCall -= value;
                }
                m_LockThreadEventAfterAddGuildCall.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS RemoveGuildCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveGuildCallEventArgs<T, V>> m_ThreadEventBeforeRemoveGuildCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeRemoveGuildCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveGuildCallEventArgs<T, V>> ThreadBeforeRemoveGuildCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveGuildCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveGuildCall += value;
                }
                m_LockThreadEventBeforeRemoveGuildCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveGuildCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveGuildCall -= value;
                }
                m_LockThreadEventBeforeRemoveGuildCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveGuildCallEventArgs<T, V>> m_ThreadEventAfterRemoveGuildCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterRemoveGuildCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveGuildCallEventArgs<T, V>> ThreadAfterRemoveGuildCall
        {
            add
            {
                m_LockThreadEventAfterRemoveGuildCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveGuildCall += value;
                }
                m_LockThreadEventAfterRemoveGuildCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterRemoveGuildCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveGuildCall -= value;
                }
                m_LockThreadEventAfterRemoveGuildCall.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion