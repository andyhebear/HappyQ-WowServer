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

namespace Demo.Mmose.Core.Entity.Suit.Ability.Aura
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseAuraHandler<T> where T : BaseAura
    {
        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_Auras.Count; }
        }
        #endregion

        #region zh-CHS AuraHandler方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_Auras = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseTaxiNode"></param>
        public bool AddAura( long lAuraSerial, T auraT )
        {
            if ( auraT == null )
            {
                Debug.WriteLine( "BaseAuraHandler.AddAura(...) - auraT == null error!" );
                return false;
            }

            EventHandler<BeforeAddAuraCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeAddAuraCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddAuraCallEventArgs<T> eventArgs = new BeforeAddAuraCallEventArgs<T>( auraT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Auras.Add( lAuraSerial, auraT );

            EventHandler<AfterAddAuraCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterAddAuraCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddAuraCallEventArgs<T> eventArgs = new AfterAddAuraCallEventArgs<T>( auraT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RemoveAura( long lAuraSerial )
        {
            T auraT = FindAuraOnSerial( lAuraSerial );
            if ( auraT == null )
                return false;

            EventHandler<BeforeRemoveAuraCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveAuraCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveAuraCallEventArgs<T> eventArgs = new BeforeRemoveAuraCallEventArgs<T>( auraT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Auras.Remove( lAuraSerial );

            EventHandler<AfterRemoveAuraCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterRemoveAuraCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveAuraCallEventArgs<T> eventArgs = new AfterRemoveAuraCallEventArgs<T>( auraT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T FindAuraOnSerial( long lAuraSerial )
        {
            return m_Auras.GetValue( lAuraSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(Aura)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_Auras.ToArrayValues();
        }

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddAuraCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddAuraCallEventArgs<T>> m_ThreadEventBeforeAddAuraCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddAuraCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddAuraCallEventArgs<T>> ThreadBeforeAddAuraCall
        {
            add
            {
                m_LockThreadEventBeforeAddAuraCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddAuraCall += value;
                }
                m_LockThreadEventBeforeAddAuraCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddAuraCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddAuraCall -= value;
                }
                m_LockThreadEventBeforeAddAuraCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddAuraCallEventArgs<T>> m_ThreadEventAfterAddAuraCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterAddAuraCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddAuraCallEventArgs<T>> ThreadAfterAddAuraCall
        {
            add
            {
                m_LockThreadEventAfterAddAuraCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddAuraCall += value;
                }
                m_LockThreadEventAfterAddAuraCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterAddAuraCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddAuraCall -= value;
                }
                m_LockThreadEventAfterAddAuraCall.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS RemoveAuraCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveAuraCallEventArgs<T>> m_ThreadEventBeforeRemoveAuraCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeRemoveAuraCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveAuraCallEventArgs<T>> ThreadBeforeRemoveAuraCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveAuraCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveAuraCall += value;
                }
                m_LockThreadEventBeforeRemoveAuraCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveAuraCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveAuraCall -= value;
                }
                m_LockThreadEventBeforeRemoveAuraCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveAuraCallEventArgs<T>> m_ThreadEventAfterRemoveAuraCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterRemoveAuraCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveAuraCallEventArgs<T>> ThreadAfterRemoveAuraCall
        {
            add
            {
                m_LockThreadEventAfterRemoveAuraCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveAuraCall += value;
                }
                m_LockThreadEventAfterRemoveAuraCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterRemoveAuraCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveAuraCall -= value;
                }
                m_LockThreadEventAfterRemoveAuraCall.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion