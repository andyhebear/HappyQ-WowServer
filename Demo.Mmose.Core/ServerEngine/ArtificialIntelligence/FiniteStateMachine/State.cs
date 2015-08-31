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
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.AIEngine.FiniteStateMachine
{
    /// <summary>
    /// State abstract class
    /// </summary>
    [MultiThreadedNoSupport( "zh-CHS", "当前的类所有成员没有锁定,不支持多线程操作" )]
    public abstract class State<EntityT> where EntityT : WorldEntity
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Machine<EntityT> m_SubMachine = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Machine<EntityT> SubMachine
        {
            get { return m_SubMachine; }
            set { m_SubMachine = value; }
        }

        #endregion

        #region zh-CHS 内部方法 | en Internal Methods

        /// <summary>
        /// Iterates through the Condition list and finds the first Condition that meets condition and returns the associated State.
        /// If no conditions match, then null is returned.
        /// </summary>
        /// <param name="condition">The condition to check.  For example, if the set of Conditions check for a particular Integer, then the first Condition that matches the Integer passed into this method will be "met" and the associated State will be returned.</param>
        /// <returns>The State that maps to the matching Condition or null if no Conditions meet the criteria.</returns>
        internal void ExecuteState( Machine<EntityT> machine, EntityT entityT )
        {
            OnStateEvent( StateType.EXECUTE_START );
            {
                Enter( machine, entityT );
            }
            OnStateEvent( StateType.EXECUTE_END );
        }

        /// <summary>
        /// Called directly by the machine when this state is entered.
        /// </summary>
        /// <param name="input">The input to feed into this state.</param>
        internal void EnterState( Machine<EntityT> machine, EntityT entityT )
        {
            OnStateEvent( StateType.ENTER_START );
            {
                Enter( machine, entityT );
            }
            OnStateEvent( StateType.ENTER_END );
        }

        /// <summary>
        /// Called directly by the machine when this state is exited.
        /// </summary>
        /// <returns>Any output object that is to be fed into the next state.</returns>
        internal void ExitState( Machine<EntityT> machine, EntityT entityT )
        {
            OnStateEvent( StateType.EXIT_START );
            {
                Exit( machine, entityT );
            }
            OnStateEvent( StateType.EXIT_END );
        }

        #endregion

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateType"></param>
        private void OnStateEvent( StateType stateType )
        {
            EventHandler<StateEventArgs<EntityT>> tempEvent = m_StateListener;
            if ( tempEvent != null )
            {
                StateEventArgs<EntityT> eventArgs = new StateEventArgs<EntityT>( this, stateType );
                tempEvent( this, eventArgs );
            }
        }
        #endregion

        #region zh-CHS 抽象方法 | en Abstract Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityT"></param>
        public abstract void Execute( Machine<EntityT> machine, EntityT entityT );

        /// <summary>
        /// This method is called when the state is entered.
        /// </summary>
        /// <param name="input">Any output from a previous state will become the input for this state. If this is a start state, then input will be null</param>
        public abstract void Enter( Machine<EntityT> machine, EntityT entityT );

        /// <summary>
        /// This method is called when the state is exited via a transition to another state.
        /// </summary>
        /// <returns>Any output object that is to be fed into the next state.</returns>
        public abstract void Exit( Machine<EntityT> machine, EntityT entityT );
        #endregion

        #region zh-CHS 共有事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<StateEventArgs<EntityT>> m_StateListener;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockStateListener = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// Adds a StateListener to this State that we will deliver events to.
        /// Removes a StateListener from this State.
        /// </summary>
        public event EventHandler<StateEventArgs<EntityT>> StateListener
        {
            add
            {
                m_LockStateListener.EnterWriteLock();
                {
                    m_StateListener += value;
                }
                m_LockStateListener.ExitWriteLock();
            }
            remove
            {
                m_LockStateListener.EnterWriteLock();
                {
                    m_StateListener -= value;
                }
                m_LockStateListener.ExitWriteLock();
            }
        }
        #endregion
    }
}
#endregion