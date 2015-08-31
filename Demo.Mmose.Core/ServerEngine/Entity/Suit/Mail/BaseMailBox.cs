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
    public class BaseMailBox<T> where T : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public BaseMailBox()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public BaseMailBox( Serial serial ) // serialization ctor
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

        #region zh-CHS MailMessage列表 属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_MailMessages = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(邮件信息)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_MailMessages.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 添加道具
        /// </summary>
        /// <param name="item"></param>
        public bool AddMailMessage( long lMailMessageId, T mailMessageT )
        {
            if ( mailMessageT == null )
            {
                Debug.WriteLine( "BaseMailBox.AddMailMessage(...) - mailMessageT == null error!" );

                return false;
            }

            EventHandler<BeforeAddMailMessageCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeAddMailMessageCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddMailMessageCallEventArgs<T> eventArgs = new BeforeAddMailMessageCallEventArgs<T>( mailMessageT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_MailMessages.Add( lMailMessageId, mailMessageT );

            EventHandler<AfterAddMailMessageCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterAddMailMessageCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddMailMessageCallEventArgs<T> eventArgs = new AfterAddMailMessageCallEventArgs<T>( mailMessageT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 移出道具
        /// </summary>
        /// <param name="item"></param>
        public bool RemoveMailMessage( long lMailMessageId )
        {
            T mailMessageT = FindMailMessageOnId( lMailMessageId );
            if ( mailMessageT == null )
                return false;

            EventHandler<BeforeRemoveMailMessageCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveMailMessageCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveMailMessageCallEventArgs<T> eventArgs = new BeforeRemoveMailMessageCallEventArgs<T>( mailMessageT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_MailMessages.Remove( lMailMessageId );

            EventHandler<AfterRemoveMailMessageCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterRemoveMailMessageCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveMailMessageCallEventArgs<T> eventArgs = new AfterRemoveMailMessageCallEventArgs<T>( mailMessageT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 在身上找道具
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public T FindMailMessageOnId( long lMailMessageId )
        {
            return m_MailMessages.GetValue( lMailMessageId );
        }

        #endregion

        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddMailMessageCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddMailMessageCallEventArgs<T>> m_ThreadEventBeforeAddMailMessageCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddMailMessageCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddMailMessageCallEventArgs<T>> ThreadBeforeAddMailMessageCall
        {
            add
            {
                m_LockThreadEventBeforeAddMailMessageCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddMailMessageCall += value;
                }
                m_LockThreadEventBeforeAddMailMessageCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddMailMessageCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddMailMessageCall -= value;
                }
                m_LockThreadEventBeforeAddMailMessageCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddMailMessageCallEventArgs<T>> m_ThreadEventAfterAddMailMessageCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterAddMailMessageCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddMailMessageCallEventArgs<T>> ThreadAfterAddMailMessageCall
        {
            add
            {
                m_LockThreadEventAfterAddMailMessageCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddMailMessageCall += value;
                }
                m_LockThreadEventAfterAddMailMessageCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterAddMailMessageCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddMailMessageCall -= value;
                }
                m_LockThreadEventAfterAddMailMessageCall.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS RemoveMailMessageCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveMailMessageCallEventArgs<T>> m_ThreadEventBeforeRemoveMailMessageCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeRemoveMailMessageCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveMailMessageCallEventArgs<T>> ThreadBeforeRemoveMailMessageCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveMailMessageCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveMailMessageCall += value;
                }
                m_LockThreadEventBeforeRemoveMailMessageCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveMailMessageCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveMailMessageCall -= value;
                }
                m_LockThreadEventBeforeRemoveMailMessageCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveMailMessageCallEventArgs<T>> m_ThreadEventAfterRemoveMailMessageCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterRemoveMailMessageCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveMailMessageCallEventArgs<T>> ThreadAfterRemoveMailMessageCall
        {
            add
            {
                m_LockThreadEventAfterRemoveMailMessageCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveMailMessageCall += value;
                }
                m_LockThreadEventAfterRemoveMailMessageCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterRemoveMailMessageCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveMailMessageCall -= value;
                }
                m_LockThreadEventAfterRemoveMailMessageCall.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion