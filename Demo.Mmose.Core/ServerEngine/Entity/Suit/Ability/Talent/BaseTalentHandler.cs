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

namespace Demo.Mmose.Core.Entity.Suit.Ability.Talent
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseTalentHandler<T> where T : BaseTalent
    {
        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_Talents.Count; }
        }
        #endregion

        #region zh-CHS TalentHandler方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_Talents = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseTaxiNode"></param>
        public bool AddTalent( long lTalentSerial, T talentT )
        {
            if ( talentT == null )
            {
                Debug.WriteLine( "BaseTalentHandler.AddTalent(...) - talentT == null error!" );
                return false;
            }

            EventHandler<BeforeAddTalentCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeAddTalentCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddTalentCallEventArgs<T> eventArgs = new BeforeAddTalentCallEventArgs<T>( talentT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Talents.Add( lTalentSerial, talentT );

            EventHandler<AfterAddTalentCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterAddTalentCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddTalentCallEventArgs<T> eventArgs = new AfterAddTalentCallEventArgs<T>( talentT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RemoveTalent( long lTalentSerial )
        {
            T talentT = FindTalentOnSerial( lTalentSerial );
            if ( talentT == null )
                return false;

            EventHandler<BeforeRemoveTalentCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveTalentCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveTalentCallEventArgs<T> eventArgs = new BeforeRemoveTalentCallEventArgs<T>( talentT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Talents.Remove( lTalentSerial );

            EventHandler<AfterRemoveTalentCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterRemoveTalentCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveTalentCallEventArgs<T> eventArgs = new AfterRemoveTalentCallEventArgs<T>( talentT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T FindTalentOnSerial( long lTalentSerial )
        {
            return m_Talents.GetValue( lTalentSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(Talent)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_Talents.ToArrayValues();
        }

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddTalentCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddTalentCallEventArgs<T>> m_ThreadEventBeforeAddTalentCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddTalentCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddTalentCallEventArgs<T>> ThreadBeforeAddTalentCall
        {
            add
            {
                m_LockThreadEventBeforeAddTalentCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddTalentCall += value;
                }
                m_LockThreadEventBeforeAddTalentCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddTalentCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddTalentCall -= value;
                }
                m_LockThreadEventBeforeAddTalentCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddTalentCallEventArgs<T>> m_ThreadEventAfterAddTalentCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterAddTalentCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddTalentCallEventArgs<T>> ThreadAfterAddTalentCall
        {
            add
            {
                m_LockThreadEventAfterAddTalentCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddTalentCall += value;
                }
                m_LockThreadEventBeforeAddTalentCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddTalentCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddTalentCall -= value;
                }
                m_LockThreadEventBeforeAddTalentCall.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS RemoveTalentCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveTalentCallEventArgs<T>> m_ThreadEventBeforeRemoveTalentCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeRemoveTalentCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveTalentCallEventArgs<T>> ThreadBeforeRemoveTalentCall
        {
            add
            {
                m_LockThreadEventBeforeAddTalentCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveTalentCall += value;
                }
                m_LockThreadEventBeforeAddTalentCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddTalentCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveTalentCall -= value;
                }
                m_LockThreadEventBeforeAddTalentCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveTalentCallEventArgs<T>> m_ThreadEventAfterRemoveTalentCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterRemoveTalentCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveTalentCallEventArgs<T>> ThreadAfterRemoveTalentCall
        {
            add
            {
                m_LockThreadEventBeforeAddTalentCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveTalentCall += value;
                }
                m_LockThreadEventBeforeAddTalentCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddTalentCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveTalentCall -= value;
                }
                m_LockThreadEventBeforeAddTalentCall.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion
