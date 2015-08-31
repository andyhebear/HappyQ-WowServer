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

namespace Demo.Mmose.Core.Entity.Suit.Mail
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseMailHandler<T, V>
        where T : BaseMailBox<V>
        where V : BaseMailMessage
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS MailBox列表 属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_MailBoxs = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(邮件信息)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_MailBoxs.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 添加道具
        /// </summary>
        /// <param name="item"></param>
        public bool AddMailBox( long iMailBoxSerial, T mailBoxT )
        {
            if ( mailBoxT == null )
            {
                Debug.WriteLine( "BaseMailHandler.AddMailBox(...) - mailBoxT == null error!" );

                return false;
            }

            EventHandler<BeforeAddMailBoxCallEventArgs<T, V>> tempBeforeEventArgs = m_ThreadEventBeforeAddMailBoxCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddMailBoxCallEventArgs<T, V> eventArgs = new BeforeAddMailBoxCallEventArgs<T, V>( mailBoxT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_MailBoxs.Add( iMailBoxSerial, mailBoxT );

            EventHandler<AfterAddMailBoxCallEventArgs<T, V>> tempAfterEventArgs = m_ThreadEventAfterAddMailBoxCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddMailBoxCallEventArgs<T, V> eventArgs = new AfterAddMailBoxCallEventArgs<T, V>( mailBoxT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 移出道具
        /// </summary>
        /// <param name="item"></param>
        public bool RemoveMailBox( long iMailBoxSerial )
        {
            T mailBoxT = FindMailBoxOnSerial( iMailBoxSerial );
            if ( mailBoxT == null )
                return false;

            EventHandler<BeforeRemoveMailBoxCallEventArgs<T, V>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveMailBoxCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveMailBoxCallEventArgs<T, V> eventArgs = new BeforeRemoveMailBoxCallEventArgs<T, V>( mailBoxT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_MailBoxs.Remove( iMailBoxSerial );

            EventHandler<AfterRemoveMailBoxCallEventArgs<T, V>> tempAfterEventArgs = m_ThreadEventAfterRemoveMailBoxCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveMailBoxCallEventArgs<T, V> eventArgs = new AfterRemoveMailBoxCallEventArgs<T, V>( mailBoxT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 在身上找道具
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public T FindMailBoxOnSerial( long iMailBoxSerial )
        {
            return m_MailBoxs.GetValue( iMailBoxSerial );
        }

        #endregion

        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddMailBoxCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddMailBoxCallEventArgs<T, V>> m_ThreadEventBeforeAddMailBoxCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddMailBoxCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddMailBoxCallEventArgs<T, V>> ThreadBeforeAddMailBoxCall
        {
            add
            {
                m_LockThreadEventBeforeAddMailBoxCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddMailBoxCall += value;
                }
                m_LockThreadEventBeforeAddMailBoxCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddMailBoxCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddMailBoxCall -= value;
                }
                m_LockThreadEventBeforeAddMailBoxCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddMailBoxCallEventArgs<T, V>> m_ThreadEventAfterAddMailBoxCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterAddMailBoxCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddMailBoxCallEventArgs<T, V>> ThreadAfterAddMailBoxCall
        {
            add
            {
                m_LockThreadEventAfterAddMailBoxCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddMailBoxCall += value;
                }
                m_LockThreadEventAfterAddMailBoxCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterAddMailBoxCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddMailBoxCall -= value;
                }
                m_LockThreadEventAfterAddMailBoxCall.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS RemoveMailBoxCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveMailBoxCallEventArgs<T, V>> m_ThreadEventBeforeRemoveMailBoxCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeRemoveMailBoxCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveMailBoxCallEventArgs<T, V>> ThreadBeforeRemoveMailBoxCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveMailBoxCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveMailBoxCall += value;
                }
                m_LockThreadEventBeforeRemoveMailBoxCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveMailBoxCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveMailBoxCall -= value;
                }
                m_LockThreadEventBeforeRemoveMailBoxCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveMailBoxCallEventArgs<T, V>> m_ThreadEventAfterRemoveMailBoxCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterRemoveMailBoxCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveMailBoxCallEventArgs<T, V>> ThreadAfterRemoveMailBoxCall
        {
            add
            {
                m_LockThreadEventAfterRemoveMailBoxCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveMailBoxCall += value;
                }
                m_LockThreadEventAfterRemoveMailBoxCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterRemoveMailBoxCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveMailBoxCall -= value;
                }
                m_LockThreadEventAfterRemoveMailBoxCall.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion