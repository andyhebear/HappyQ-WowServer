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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Entity;
#endregion

namespace Demo.Mmose.Core.AIEngine.FiniteStateMachine
{
    /// <summary>
    /// The controlling Machine class for the Finite State Machine
    /// </summary>
    [MultiThreadedNoSupport( "zh-CHS", "当前的类所有成员没有锁定,不支持多线程操作" )]
    public class Machine<EntityT> : IArtificialIntelligence where EntityT : WorldEntity
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// Constructs a new Machine object with no start state.
        /// </summary>
        public Machine( EntityT owner )
        {
            m_Owner = owner;
        }

        /// <summary>
        /// Constructs a new Machine object.
        /// </summary>
        /// <param name="startState">The State object to begin on.  This must be non-null</param>
        public Machine( EntityT owner, State<EntityT> startState )
            : this( owner )
        {
            m_StartState = startState;
            m_PreviousState = m_StartState;
            m_CurrentState = m_StartState;
            m_CurrentState.EnterState( this, m_Owner );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EntityT m_Owner = default( EntityT );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public EntityT Owner
        {
            get { return m_Owner; }
            internal set { m_Owner = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// A handle to the start state.  This will be the first state added to the machine.
        /// </summary>
        private State<EntityT> m_StartState = null;
        #endregion
        /// <summary>
        /// Sets the start state for this machine.
        /// Returns a handle to the starting state for this machine.
        /// </summary>
        public State<EntityT> StartState
        {
            get { return m_StartState; }
            set
            {
                if ( value == null )
                    return;

                m_StartState = value;
                if ( m_CurrentState == null )
                {
                    if ( m_PreviousState == null )
                        m_PreviousState = m_StartState;

                    m_CurrentState = m_StartState;
                    m_CurrentState.EnterState( this, default( EntityT ) );
                }
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// A handle to the previous state of the machine.
        /// </summary>
        private State<EntityT> m_PreviousState = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public State<EntityT> PreviousState
        {
            get { return m_PreviousState; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// A handle to the current state of the machine.
        /// </summary>
        private State<EntityT> m_CurrentState = null;
        #endregion
        /// <summary>
        /// Forcibly sets the current state of this machine.
        /// NOTE: This is NOT recommended for use in general, but it is provided
        ///       in case there is a need for it.  No checking is done as to
        ///       whether or not the state can be reached though valid transitions
        ///       and any state listeners, and state IO is not performed.
        /// Returns the current state of this machine.
        /// </summary>
        protected State<EntityT> CurrentState
        {
            get { return m_CurrentState; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// Takes input and passes it to the current State.
        /// If the condition is met by one of the Conditions of the State, then the new current State will be that returned by the input method of the present State.
        /// </summary>
        /// <param name="condition">The input to pass to the current State</param>
        public void SliceAI()
        {
            if ( m_CurrentState == null )
                throw new Exception( "Machine.Execute(...) - m_CurrentState == null error!" );

            // same for the current state
            m_CurrentState.ExecuteState( this, m_Owner );
        }

        /// <summary>
        /// Change to a new state
        /// </summary>
        /// <param name="pNewState"></param>
        public void ChangeState( State<EntityT> newState )
        {
            if ( newState == null )
                throw new Exception( "Machine.Execute(...) - newState == null error!" );

            // keep a record of the previous state
            m_PreviousState = m_CurrentState;

            // call the exit method of the existing state
            m_CurrentState.ExitState( this, m_Owner );

            // change state to the new state
            m_CurrentState = newState;

            // call the entry method of the new state
            m_CurrentState.EnterState( this, m_Owner );
        }

        /// <summary>
        /// Change state back to the previous state
        /// </summary>
        public void RevertToPreviousState()
        {
            if ( m_PreviousState != null )
                ChangeState( m_PreviousState );
        }

        /// <summary>
        /// Resets this machine so that its current State is the start state.
        /// No state transitions will be fired.
        /// </summary>
        public void ResetToStartState()
        {
            if ( m_StartState != null )
                ChangeState( m_StartState );
        }
        #endregion
    }
}
#endregion