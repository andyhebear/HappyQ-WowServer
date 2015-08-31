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

namespace Demo.Mmose.Core.Entity.Suit.Ability.Skill
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseSkillManager的事件数据类
    /// </summary>
    public class SkillHandlerEventArgs<T> : EventArgs where T : BaseSkill
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public SkillHandlerEventArgs( BaseSkillHandler<T> skillHandlerT )
        {
            m_SkillHandler = skillHandlerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseSkillHandler<T> m_SkillHandler = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseSkillHandler<T> SkillHandler
        {
            get { return m_SkillHandler; }
        }
        #endregion
    }

    /// <summary>
    /// BaseSkillManager的事件数据类
    /// </summary>
    public class BeforeAddSkillCallEventArgs<T> : SkillHandlerEventArgs<T> where T : BaseSkill
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddSkillCallEventArgs( T skillT, BaseSkillHandler<T> skillHandlerT ) :
            base( skillHandlerT )
        {
            m_AddSkill = skillT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddSkill = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddSkill
        {
            get { return m_AddSkill; }
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
    /// BaseSkillManager的事件数据类
    /// </summary>
    public class AfterAddSkillCallEventArgs<T> : SkillHandlerEventArgs<T> where T : BaseSkill
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddSkillCallEventArgs( T skillT, BaseSkillHandler<T> skillHandlerT ) :
            base( skillHandlerT )
        {
            m_AddSkill = skillT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddSkill = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddSkill
        {
            get { return m_AddSkill; }
        }
        #endregion
    }

    /// <summary>
    /// BaseSkillManager的事件数据类
    /// </summary>
    public class BeforeRemoveSkillCallEventArgs<T> : SkillHandlerEventArgs<T> where T : BaseSkill
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveSkillCallEventArgs( T skillT, BaseSkillHandler<T> skillHandlerT ) :
            base( skillHandlerT )
        {
            m_RemoveSkill = skillT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveSkill = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveSkill
        {
            get { return m_RemoveSkill; }
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
    /// BaseSkillManager的事件数据类
    /// </summary>
    public class AfterRemoveSkillCallEventArgs<T> : SkillHandlerEventArgs<T> where T : BaseSkill
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveSkillCallEventArgs( T skillT, BaseSkillHandler<T> skillHandlerT ) :
            base( skillHandlerT )
        {
            m_RemoveSkill = skillT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveSkill = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveSkill
        {
            get { return m_RemoveSkill; }
        }
        #endregion
    }
    #endregion
}
#endregion