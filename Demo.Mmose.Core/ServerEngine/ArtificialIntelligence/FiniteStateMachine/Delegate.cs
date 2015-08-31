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
using Demo.Mmose.Core.Entity;
#endregion

namespace Demo.Mmose.Core.AIEngine.FiniteStateMachine
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// StateEventArgs的事件数据类
    /// </summary>
    public class StateEventArgs<EntityT> : EventArgs where EntityT : WorldEntity
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseServer"></param>
        public StateEventArgs( State<EntityT> state, StateType stateType )
        {
            m_State = state;
            m_StateType = stateType;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// The type of event that this StateEvent is.
        /// </summary>
        private State<EntityT> m_State = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public State<EntityT> State
        {
            get { return m_State; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// The type of event that this StateEvent is.
        /// </summary>
        private StateType m_StateType = StateType.NONE;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public StateType StateType
        {
            get { return m_StateType; }
        }
        #endregion
    }
    #endregion
}
#endregion