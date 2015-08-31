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

namespace Demo.Mmose.Core.Entity.Suit.Ability.Spell
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseSpellManager的事件数据类
    /// </summary>
    public class SpellHandlerEventArgs<T> : EventArgs where T : BaseSpell
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public SpellHandlerEventArgs( BaseSpellHandler<T> spellHandlerT )
        {
            m_SpellHandler = spellHandlerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseSpellHandler<T> m_SpellHandler = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseSpellHandler<T> SpellHandler
        {
            get { return m_SpellHandler; }
        }
        #endregion
    }

    /// <summary>
    /// BaseSpellManager的事件数据类
    /// </summary>
    public class BeforeAddSpellCallEventArgs<T> : SpellHandlerEventArgs<T> where T : BaseSpell
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddSpellCallEventArgs( T spellT, BaseSpellHandler<T> spellHandlerT ) :
            base( spellHandlerT )
        {
            m_AddSpell = spellT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddSpell = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddSpell
        {
            get { return m_AddSpell; }
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
    /// BaseSpellManager的事件数据类
    /// </summary>
    public class AfterAddSpellCallEventArgs<T> : SpellHandlerEventArgs<T> where T : BaseSpell
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddSpellCallEventArgs( T spellT, BaseSpellHandler<T> spellHandlerT ) :
            base( spellHandlerT )
        {
            m_AddSpell = spellT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddSpell = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddSpell
        {
            get { return m_AddSpell; }
        }
        #endregion
    }

    /// <summary>
    /// BaseSpellManager的事件数据类
    /// </summary>
    public class BeforeRemoveSpellCallEventArgs<T> : SpellHandlerEventArgs<T> where T : BaseSpell
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveSpellCallEventArgs( T spellT, BaseSpellHandler<T> spellHandlerT ) :
            base( spellHandlerT )
        {
            m_RemoveSpell = spellT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveSpell = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveSpell
        {
            get { return m_RemoveSpell; }
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
    /// BaseSpellManager的事件数据类
    /// </summary>
    public class AfterRemoveSpellCallEventArgs<T> : SpellHandlerEventArgs<T> where T : BaseSpell
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveSpellCallEventArgs( T spellT, BaseSpellHandler<T> spellHandlerT ) :
            base( spellHandlerT )
        {
            m_RemoveSpell = spellT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveSpell = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveSpell
        {
            get { return m_RemoveSpell; }
        }
        #endregion
    }
    #endregion
}
#endregion