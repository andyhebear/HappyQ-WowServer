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

namespace Demo.Mmose.Core.Entity.Suit.Ability.Talent
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseTalentManager的事件数据类
    /// </summary>
    public class TalentHandlerEventArgs<T> : EventArgs where T : BaseTalent
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public TalentHandlerEventArgs( BaseTalentHandler<T> talentHandlerT )
        {
            m_TalentHandler = talentHandlerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseTalentHandler<T> m_TalentHandler = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseTalentHandler<T> TalentHandler
        {
            get { return m_TalentHandler; }
        }
        #endregion
    }

    /// <summary>
    /// BaseTalentManager的事件数据类
    /// </summary>
    public class BeforeAddTalentCallEventArgs<T> : TalentHandlerEventArgs<T> where T : BaseTalent
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddTalentCallEventArgs( T talentT, BaseTalentHandler<T> talentHandlerT ) :
            base( talentHandlerT )
        {
            m_AddTalent = talentT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddTalent = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddTalent
        {
            get { return m_AddTalent; }
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
    /// BaseTalentManager的事件数据类
    /// </summary>
    public class AfterAddTalentCallEventArgs<T> : TalentHandlerEventArgs<T> where T : BaseTalent
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddTalentCallEventArgs( T talentT, BaseTalentHandler<T> talentHandlerT ) :
            base( talentHandlerT )
        {
            m_AddTalent = talentT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddTalent = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddTalent
        {
            get { return m_AddTalent; }
        }
        #endregion
    }

    /// <summary>
    /// BaseTalentManager的事件数据类
    /// </summary>
    public class BeforeRemoveTalentCallEventArgs<T> : TalentHandlerEventArgs<T> where T : BaseTalent
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveTalentCallEventArgs( T talentT, BaseTalentHandler<T> talentHandlerT ) :
            base( talentHandlerT )
        {
            m_RemoveTalent = talentT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveTalent = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveTalent
        {
            get { return m_RemoveTalent; }
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
    /// BaseTalentManager的事件数据类
    /// </summary>
    public class AfterRemoveTalentCallEventArgs<T> : TalentHandlerEventArgs<T> where T : BaseTalent
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveTalentCallEventArgs( T talentT, BaseTalentHandler<T> talentHandlerT ) :
            base( talentHandlerT )
        {
            m_RemoveTalent = talentT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveTalent = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveTalent
        {
            get { return m_RemoveTalent; }
        }
        #endregion
    }
    #endregion
}
#endregion