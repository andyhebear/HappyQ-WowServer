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
    public class BaseGuild<T> where T : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public BaseGuild()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public BaseGuild( Serial serial ) // serialization ctor
        {
            m_Serial = serial;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Serial属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_Serial = new Serial();
        #endregion
        /// <summary>
        /// 道具的唯一序列号GUID
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
            set
            {
                //Serial oldValueSerial = m_Serial;

                //EventHandler<BeforeUpdateSerialEventArgs> tempBeforeEventArgs = m_ThreadEventBeforeUpdateSerial;
                //if ( tempBeforeEventArgs != null )
                //{
                //    BeforeUpdateSerialEventArgs eventArgs = new BeforeUpdateSerialEventArgs( value, this );
                //    tempBeforeEventArgs( this, eventArgs );

                //    if ( eventArgs.IsCancel == true )
                //        return;
                //}

                m_Serial = value;
                //m_BaseItemState.UpdateSerial();

                //EventHandler<AfterUpdateSerialEventArgs> tempAfterEventArgs = m_ThreadEventAfterUpdateSerial;
                //if ( tempAfterEventArgs != null )
                //{
                //    AfterUpdateSerialEventArgs eventArgs = new AfterUpdateSerialEventArgs( oldValueSerial, this );
                //    tempAfterEventArgs( this, eventArgs );
                //}
            }
        }

        #endregion

        #region zh-CHS BaseGuildMember列表 属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_GuildMembers = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(行会成员)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_GuildMembers.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 添加道具
        /// </summary>
        /// <param name="item"></param>
        public bool AddGuildMember( long iGuildMemberSerial, T guildMemberT )
        {
            if ( guildMemberT == null )
            {
                Debug.WriteLine( "BaseGuild.AddGuildMember(...) - baseGuildMember == null error!" );

                return false;
            }

            EventHandler<BeforeAddGuildMemberCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeAddGuildMemberCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddGuildMemberCallEventArgs<T> eventArgs = new BeforeAddGuildMemberCallEventArgs<T>( guildMemberT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_GuildMembers.Add( iGuildMemberSerial, guildMemberT );

            EventHandler<AfterAddGuildMemberCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterAddGuildMemberCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddGuildMemberCallEventArgs<T> eventArgs = new AfterAddGuildMemberCallEventArgs<T>( guildMemberT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 移出道具
        /// </summary>
        /// <param name="item"></param>
        public bool RemoveGuildMember( long iGuildMemberSerial )
        {
            T guildMemberT = FindGuildMemberOnSerial( iGuildMemberSerial );
            if ( guildMemberT == null )
                return false;

            EventHandler<BeforeRemoveGuildMemberCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveGuildMemberCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveGuildMemberCallEventArgs<T> eventArgs = new BeforeRemoveGuildMemberCallEventArgs<T>( guildMemberT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_GuildMembers.Remove( iGuildMemberSerial );

            EventHandler<AfterRemoveGuildMemberCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterRemoveGuildMemberCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveGuildMemberCallEventArgs<T> eventArgs = new AfterRemoveGuildMemberCallEventArgs<T>( guildMemberT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 在身上找道具
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public T FindGuildMemberOnSerial( long iGuildMemberSerial )
        {
            return m_GuildMembers.GetValue( iGuildMemberSerial );
        }

        #endregion

        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddGuildMemberCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddGuildMemberCallEventArgs<T>> m_ThreadEventBeforeAddGuildMemberCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddGuildMemberCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddGuildMemberCallEventArgs<T>> ThreadBeforeAddGuildMemberCall
        {
            add
            {
                m_LockThreadEventBeforeAddGuildMemberCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddGuildMemberCall += value;
                }
                m_LockThreadEventBeforeAddGuildMemberCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddGuildMemberCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddGuildMemberCall -= value;
                }
                m_LockThreadEventBeforeAddGuildMemberCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddGuildMemberCallEventArgs<T>> m_ThreadEventAfterAddGuildMemberCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterAddGuildMemberCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddGuildMemberCallEventArgs<T>> ThreadAfterAddGuildMemberCall
        {
            add
            {
                m_LockThreadEventAfterAddGuildMemberCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddGuildMemberCall += value;
                }
                m_LockThreadEventAfterAddGuildMemberCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterAddGuildMemberCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddGuildMemberCall -= value;
                }
                m_LockThreadEventAfterAddGuildMemberCall.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS RemoveGuildMemberCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveGuildMemberCallEventArgs<T>> m_ThreadEventBeforeRemoveGuildMemberCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeRemoveGuildMemberCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveGuildMemberCallEventArgs<T>> ThreadBeforeRemoveGuildMemberCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveGuildMemberCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveGuildMemberCall += value;
                }
                m_LockThreadEventBeforeRemoveGuildMemberCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveGuildMemberCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveGuildMemberCall -= value;
                }
                m_LockThreadEventBeforeRemoveGuildMemberCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveGuildMemberCallEventArgs<T>> m_ThreadEventAfterRemoveGuildMemberCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterRemoveGuildMemberCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveGuildMemberCallEventArgs<T>> ThreadAfterRemoveGuildMemberCall
        {
            add
            {
                m_LockThreadEventAfterRemoveGuildMemberCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveGuildMemberCall += value;
                }
                m_LockThreadEventAfterRemoveGuildMemberCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterRemoveGuildMemberCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveGuildMemberCall -= value;
                }
                m_LockThreadEventAfterRemoveGuildMemberCall.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion

