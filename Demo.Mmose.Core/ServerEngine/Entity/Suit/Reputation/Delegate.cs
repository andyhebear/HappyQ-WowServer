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

#endregion

namespace Demo.Mmose.Core.Entity.Suit.Reputation
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseMailManager的事件数据类
    /// </summary>
    public class BaseReputationManagerEventArgs<T> : EventArgs where T : BaseReputation
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BaseReputationManagerEventArgs( BaseReputationHandler<T> reputationHandlerT )
        {
            m_ReputationHandler = reputationHandlerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseReputationHandler<T> m_ReputationHandler = null;
        #endregion
        /// <summary>
        /// BaseGuild实例
        /// </summary>
        public BaseReputationHandler<T> ReputationHandler
        {
            get { return m_ReputationHandler; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMailManager的事件数据类
    /// </summary>
    public class BeforeAddReputationCallEventArgs<T> : BaseReputationManagerEventArgs<T> where T : BaseReputation
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddReputationCallEventArgs( T addReputation, BaseReputationHandler<T> reputationHandlerT ) :
            base( reputationHandlerT )
        {
            m_AddReputation = addReputation;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddReputation = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddReputation
        {
            get { return m_AddReputation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMailManager的事件数据类
    /// </summary>
    public class AfterAddReputationCallEventArgs<T> : BaseReputationManagerEventArgs<T> where T : BaseReputation
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddReputationCallEventArgs( T addReputation, BaseReputationHandler<T> reputationHandlerT ) :
            base( reputationHandlerT )
        {
            m_AddReputation = addReputation;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddReputation = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddReputation
        {
            get { return m_AddReputation; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMailManager的事件数据类
    /// </summary>
    public class BeforeRemoveReputationCallEventArgs<T> : BaseReputationManagerEventArgs<T> where T : BaseReputation
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveReputationCallEventArgs( T removeReputation, BaseReputationHandler<T> reputationHandlerT ) :
            base( reputationHandlerT )
        {
            m_RemoveReputation = removeReputation;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveReputation = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveReputation
        {
            get { return m_RemoveReputation; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMailManager的事件数据类
    /// </summary>
    public class AfterRemoveReputationCallEventArgs<T> : BaseReputationManagerEventArgs<T> where T : BaseReputation
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveReputationCallEventArgs( T removeReputation, BaseReputationHandler<T> reputationHandlerT ) :
            base( reputationHandlerT )
        {
            m_RemoveReputation = removeReputation;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveReputation = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveReputation
        {
            get { return m_RemoveReputation; }
        }
        #endregion
    }
    #endregion
}
#endregion