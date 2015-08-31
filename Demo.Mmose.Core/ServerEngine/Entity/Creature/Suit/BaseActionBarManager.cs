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

namespace Demo.Mmose.Core.Entity.Creature.Suit
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseActionBarManager<T> where T : BaseActionBar
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Owner 属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_Owner = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        #endregion

        #region zh-CHS MinSlot属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MinSlot = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MinSlot
        {
            get { return m_MinSlot; }
        }

        #region zh-CHS 保护方法 | en Protected Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMinSlot"></param>
        public void SetMinSlot( long iMinSlot )
        {
            m_MinSlot = iMinSlot;
        }

        #endregion

        #endregion

        #region zh-CHS MaxSlot属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MaxSlot = long.MaxValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MaxSlot
        {
            get { return m_MaxSlot; }
        }

        #region zh-CHS 保护方法 | en Protected Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMaxButtonSlot"></param>
        public void SetMaxSlot( long iMaxSlot )
        {
            m_MaxSlot = iMaxSlot;
        }

        #endregion

        #endregion

        #region zh-CHS IsContainerFull属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsContainerFull
        {
            get
            {
                if ( m_ToteActionBars.Count < ( ( this.MaxSlot - this.MinSlot ) + 1 ) )
                    return false;
                else
                    return true;
            }
        }
        #endregion

        #region zh-CHS ActionBar 属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的道具列表
        /// </summary>
        private SafeDictionary<long, T> m_ToteActionBars = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 人物的道具列表(包裹与身上)
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(ActionBar)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_ToteActionBars.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public bool AddActionBar( long lActionBarSlot, T actionBarT )
        {
            if ( actionBarT == null )
            {
                Debug.WriteLine( "BaseActionBarHandler.AddContainer(...) - actionBarT == null error!" );

                return false;
            }

            if ( lActionBarSlot > this.MaxSlot || lActionBarSlot < this.MinSlot )
                return false;

            T findActionBarT = FindActionBarOnSlot( lActionBarSlot );
            if ( findActionBarT != null )
            {
                Debug.WriteLine( "BaseActionBarHandler.AddContainer(...) - findActionBarT != null error!" );

                return false;
            }

            EventHandler<BeforeAddActionBarCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeAddActionBarCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddActionBarCallEventArgs<T> eventArgs = new BeforeAddActionBarCallEventArgs<T>( actionBarT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_ToteActionBars.Add( lActionBarSlot, actionBarT );
            actionBarT.ActionBarSlotId = lActionBarSlot;

            EventHandler<AfterAddActionBarCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterAddActionBarCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddActionBarCallEventArgs<T> eventArgs = new AfterAddActionBarCallEventArgs<T>( actionBarT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public bool RemoveActionBar( long lActionBarSlot )
        {
            if ( lActionBarSlot > this.MaxSlot || lActionBarSlot < this.MinSlot )
                return false;

            T baseActionBar = FindActionBarOnSlot( lActionBarSlot );
            if ( baseActionBar == null )
                return false;

            EventHandler<BeforeRemoveActionBarCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveActionBarCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveActionBarCallEventArgs<T> eventArgs = new BeforeRemoveActionBarCallEventArgs<T>( baseActionBar, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_ToteActionBars.Remove( lActionBarSlot );
            baseActionBar.ActionBarSlotId = -1;

            EventHandler<AfterRemoveActionBarCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterRemoveActionBarCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveActionBarCallEventArgs<T> eventArgs = new AfterRemoveActionBarCallEventArgs<T>( baseActionBar, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public T FindActionBarOnSlot( long lActionBarSlot )
        {
            return m_ToteActionBars.GetValue( lActionBarSlot );
        }

        /// <summary>
        /// 
        /// </summary>
        public void EmptyActionBars()
        {
            m_ToteActionBars.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public bool AddToFreeActionBarSlot( T actionBarT )
        {
            long iRetrunButtonSlot = -1;
            if ( this.FindFreeActionBarSlot( ref iRetrunButtonSlot ) == false )
                return false;

            if ( this.AddActionBar( iRetrunButtonSlot, actionBarT ) == false )
                return false;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public bool FindFreeActionBarSlot( ref long lRetrunButtonSlot )
        {
            lRetrunButtonSlot = -1;

            if ( this.IsContainerFull == true )
                return false;

            for ( long iIndexSlot = this.MinSlot; iIndexSlot <= this.MaxSlot; iIndexSlot++ )
            {
                T baseActionBar = FindActionBarOnSlot( iIndexSlot );

                if ( baseActionBar == null )
                {
                    lRetrunButtonSlot = iIndexSlot;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iContainerSlotForm"></param>
        /// <param name="iItemSlotForm"></param>
        /// <param name="iContainerSlotTo"></param>
        /// <returns></returns>
        public bool ReplaceActionBar( long lActionBarSlot, T newActionBarT )
        {
            T findBaseActionBarT = this.FindActionBarOnSlot( lActionBarSlot );
            if ( findBaseActionBarT != null )
            {
                if ( this.RemoveActionBar( lActionBarSlot ) == false )
                    return false;
            }

            if ( this.AddActionBar( lActionBarSlot, newActionBarT ) == false )
            {
                if ( findBaseActionBarT != null )
                {
                    if ( this.AddActionBar( lActionBarSlot, findBaseActionBarT ) == false )
                        Debug.WriteLine( "BaseActionBarHandler.ReplaceActionBar(...) - AddActionBar(...) error(No Complete, Lost findBaseActionBarT)!" );
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iActionBarSlotForm"></param>
        /// <param name="iActionBarSlotTo"></param>
        /// <returns></returns>
        public bool SwapActionBar( long lActionBarSlotForm, long lActionBarSlotTo )
        {
            T actionBarFormT = FindActionBarOnSlot( lActionBarSlotForm );
            if ( actionBarFormT == null )
                return false;

            T actionBarToT = FindActionBarOnSlot( lActionBarSlotTo );
            if ( actionBarToT == null )
                return false;

            if ( this.RemoveActionBar( lActionBarSlotForm ) == false )
                return false;

            if ( this.RemoveActionBar( lActionBarSlotTo ) == false )
            {
                if ( this.AddActionBar( lActionBarSlotForm, actionBarFormT ) == false )
                    Debug.WriteLine( "BaseActionBarHandler.SwapActionBar(...) - AddActionBar(.1.) error(No Complete, Lost actionBarFormT)!" );

                return false;
            }

            if ( this.AddActionBar( lActionBarSlotForm, actionBarToT ) == false )
            {
                if ( this.AddActionBar( lActionBarSlotForm, actionBarFormT ) == false )
                    Debug.WriteLine( "BaseActionBarHandler.SwapActionBar(...) - AddActionBar(.2.) error(No Complete, Lost actionBarFormT)!" );

                if ( this.AddActionBar( lActionBarSlotTo, actionBarToT ) == false )
                    Debug.WriteLine( "BaseActionBarHandler.SwapActionBar(...) - AddActionBar(.3.) error(No Complete, Lost actionBarToT)!" );

                return false;
            }

            if ( this.AddActionBar( lActionBarSlotTo, actionBarFormT ) == false )
            {
                if ( this.RemoveActionBar( lActionBarSlotForm ) == false )
                    Debug.WriteLine( "BaseActionBarHandler.SwapActionBar(...) - RemoveActionBar(...) error!" );
                else
                {
                    // 恢复到原来
                    if ( this.AddActionBar( lActionBarSlotForm, actionBarFormT ) == false )
                        Debug.WriteLine( "BaseActionBarHandler.SwapActionBar(...) - AddActionBar(.4.) error(No Complete, Lost actionBarFormT)!" );
                }

                if ( this.AddActionBar( lActionBarSlotTo, actionBarToT ) == false )
                    Debug.WriteLine( "BaseActionBarHandler.SwapActionBar(...) - AddActionBar(.5.) error(No Complete, Lost actionBarToT)!" );

                return false;
            }

            return true;
        }

        #endregion
        
        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddActionBarCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddActionBarCallEventArgs<T>> m_ThreadEventBeforeAddActionBarCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockThreadEventBeforeAddActionBarCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddActionBarCallEventArgs<T>> ThreadBeforeAddActionBarCall
        {
            add
            {
                m_LockThreadEventBeforeAddActionBarCall.Enter();
                {
                    m_ThreadEventBeforeAddActionBarCall += value;
                }
                m_LockThreadEventBeforeAddActionBarCall.Exit();
            }
            remove
            {
                m_LockThreadEventBeforeAddActionBarCall.Enter();
                {
                    m_ThreadEventBeforeAddActionBarCall -= value;
                }
                m_LockThreadEventBeforeAddActionBarCall.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddActionBarCallEventArgs<T>> m_ThreadEventAfterAddActionBarCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockThreadEventAfterAddActionBarCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddActionBarCallEventArgs<T>> ThreadAfterAddActionBarCall
        {
            add
            {
                m_LockThreadEventAfterAddActionBarCall.Enter();
                {
                    m_ThreadEventAfterAddActionBarCall += value;
                }
                m_LockThreadEventAfterAddActionBarCall.Exit();
            }
            remove
            {
                m_LockThreadEventAfterAddActionBarCall.Enter();
                {
                    m_ThreadEventAfterAddActionBarCall -= value;
                }
                m_LockThreadEventAfterAddActionBarCall.Exit();
            }
        }
        #endregion

        #region zh-CHS RemoveActionBarCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveActionBarCallEventArgs<T>> m_ThreadEventBeforeRemoveActionBarCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockThreadEventBeforeRemoveActionBarCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveActionBarCallEventArgs<T>> ThreadBeforeRemoveActionBarCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveActionBarCall.Enter();
                {
                    m_ThreadEventBeforeRemoveActionBarCall += value;
                }
                m_LockThreadEventBeforeRemoveActionBarCall.Exit();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveActionBarCall.Enter();
                {
                    m_ThreadEventBeforeRemoveActionBarCall -= value;
                }
                m_LockThreadEventBeforeRemoveActionBarCall.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveActionBarCallEventArgs<T>> m_ThreadEventAfterRemoveActionBarCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockThreadEventAfterRemoveActionBarCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveActionBarCallEventArgs<T>> ThreadAfterRemoveActionBarCall
        {
            add
            {
                m_LockThreadEventAfterRemoveActionBarCall.Enter();
                {
                    m_ThreadEventAfterRemoveActionBarCall += value;
                }
                m_LockThreadEventAfterRemoveActionBarCall.Exit();
            }
            remove
            {
                m_LockThreadEventAfterRemoveActionBarCall.Enter();
                {
                    m_ThreadEventAfterRemoveActionBarCall -= value;
                }
                m_LockThreadEventAfterRemoveActionBarCall.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion