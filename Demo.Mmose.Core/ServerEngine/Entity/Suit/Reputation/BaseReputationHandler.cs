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

namespace Demo.Mmose.Core.Entity.Suit.Reputation
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseReputationHandler<T> where T : BaseReputation
    {
        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 给出脚本里面的可运动物体的数量(NPCs、Monster)
        /// </summary>
        public int Count
        {
            get { return m_Reputations.Count; }
        }
        #endregion

        #region zh-CHS ReputationManager方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_Reputations = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(Reputation)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_Reputations.ToArrayValues();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseTaxiNode"></param>
        public bool AddReputation( long lReputationSerial, T reputationT )
        {
            if ( reputationT == null )
            {
                Debug.WriteLine( "BaseReputationManager.AddReputation(...) - reputationT == null error!" );
                return false;
            }

            EventHandler<BeforeAddReputationCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeAddReputationCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddReputationCallEventArgs<T> eventArgs = new BeforeAddReputationCallEventArgs<T>( reputationT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Reputations.Add( lReputationSerial, reputationT );

            EventHandler<AfterAddReputationCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterAddReputationCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddReputationCallEventArgs<T> eventArgs = new AfterAddReputationCallEventArgs<T>( reputationT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RemoveReputation( long lReputationSerial )
        {
            T reputationT = FindReputationOnSerial( lReputationSerial );
            if ( reputationT == null )
                return false;

            EventHandler<BeforeRemoveReputationCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveReputationCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveReputationCallEventArgs<T> eventArgs = new BeforeRemoveReputationCallEventArgs<T>( reputationT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Reputations.Remove( lReputationSerial );

            EventHandler<AfterRemoveReputationCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterRemoveReputationCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveReputationCallEventArgs<T> eventArgs = new AfterRemoveReputationCallEventArgs<T>( reputationT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T FindReputationOnSerial( long lReputationSerial )
        {
            return m_Reputations.GetValue( lReputationSerial );
        }

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddReputationCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddReputationCallEventArgs<T>> m_ThreadEventBeforeAddReputationCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddReputationCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddReputationCallEventArgs<T>> ThreadBeforeAddReputationCall
        {
            add
            {
                m_LockThreadEventBeforeAddReputationCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddReputationCall += value;
                }
                m_LockThreadEventBeforeAddReputationCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddReputationCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddReputationCall -= value;
                }
                m_LockThreadEventBeforeAddReputationCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddReputationCallEventArgs<T>> m_ThreadEventAfterAddReputationCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterAddReputationCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddReputationCallEventArgs<T>> ThreadAfterAddReputationCall
        {
            add
            {
                m_LockThreadEventAfterAddReputationCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddReputationCall += value;
                }
                m_LockThreadEventAfterAddReputationCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterAddReputationCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddReputationCall -= value;
                }
                m_LockThreadEventAfterAddReputationCall.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS RemoveReputationCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveReputationCallEventArgs<T>> m_ThreadEventBeforeRemoveReputationCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeRemoveReputationCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveReputationCallEventArgs<T>> ThreadBeforeRemoveReputationCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveReputationCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveReputationCall += value;
                }
                m_LockThreadEventBeforeRemoveReputationCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveReputationCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveReputationCall -= value;
                }
                m_LockThreadEventBeforeRemoveReputationCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveReputationCallEventArgs<T>> m_ThreadEventAfterRemoveReputationCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterRemoveReputationCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveReputationCallEventArgs<T>> ThreadAfterRemoveReputationCall
        {
            add
            {
                m_LockThreadEventAfterRemoveReputationCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveReputationCall += value;
                }
                m_LockThreadEventAfterRemoveReputationCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterRemoveReputationCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveReputationCall -= value;
                }
                m_LockThreadEventAfterRemoveReputationCall.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion