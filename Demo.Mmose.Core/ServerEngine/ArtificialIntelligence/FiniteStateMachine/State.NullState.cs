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
using Demo.Mmose.Core.Entity;
#endregion

namespace Demo.Mmose.Core.AIEngine.FiniteStateMachine
{
    /// <summary>
    /// 
    /// </summary>
    public class NullState<EntityT> : State<EntityT> where EntityT : WorldEntity
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        internal NullState()
        {
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityT"></param>
        public override void Execute( Machine<EntityT> machine, EntityT entity )
        {
        }

        /// <summary>
        /// This method is called when the state is entered.
        /// </summary>
        /// <param name="input">Any output from a previous state will become the input for this state. If this is a start state, then input will be null</param>
        public override void Enter( Machine<EntityT> machine, EntityT entity )
        {
        }

        /// <summary>
        /// This method is called when the state is exited via a transition to another state.
        /// </summary>
        /// <returns>Any output object that is to be fed into the next state.</returns>
        public override void Exit( Machine<EntityT> machine, EntityT entity )
        {
        }

        #endregion

        #region zh-CHS 共有静态属性 | en Public Static Properties

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static NullState<EntityT> s_UniqueInstance = new NullState<EntityT>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static NullState<EntityT> SingletonInstance
        {
            get { return s_UniqueInstance; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class NullState : NullState<WorldEntity>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        internal NullState()
        {
        }
        #endregion
    }
}
#endregion