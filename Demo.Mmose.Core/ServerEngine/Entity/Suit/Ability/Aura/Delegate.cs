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

namespace Demo.Mmose.Core.Entity.Suit.Ability.Aura
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseAuraManager的事件数据类
    /// </summary>
    public class AuraHandlerEventArgs<T> : EventArgs where T : BaseAura
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AuraHandlerEventArgs( BaseAuraHandler<T> auraHandler )
        {
            m_AuraHandler = auraHandler;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// Aura的数据
        /// </summary>
        private BaseAuraHandler<T> m_AuraHandler = null;
        #endregion
        /// <summary>
        /// Aura实例
        /// </summary>
        public BaseAuraHandler<T> AuraHandler
        {
            get { return m_AuraHandler; }
        }
        #endregion
    }

    /// <summary>
    /// BaseAuraManager的事件数据类
    /// </summary>
    public class BeforeAddAuraCallEventArgs<T> : AuraHandlerEventArgs<T> where T : BaseAura
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddAuraCallEventArgs( T auraT, BaseAuraHandler<T> auraHandler ) :
            base( auraHandler )
        {
            m_AddAura = auraT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddAura = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddAura
        {
            get { return m_AddAura; }
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
    /// BaseAuraManager的事件数据类
    /// </summary>
    public class AfterAddAuraCallEventArgs<T> : AuraHandlerEventArgs<T> where T : BaseAura
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddAuraCallEventArgs( T auraT, BaseAuraHandler<T> auraHandler ) :
            base( auraHandler )
        {
            m_AddAura = auraT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddAura = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddAura
        {
            get { return m_AddAura; }
        }
        #endregion
    }

    /// <summary>
    /// BaseAuraManager的事件数据类
    /// </summary>
    public class BeforeRemoveAuraCallEventArgs<T> : AuraHandlerEventArgs<T> where T : BaseAura
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveAuraCallEventArgs( T auraT, BaseAuraHandler<T> auraHandler ) :
            base( auraHandler )
        {
            m_RemoveAura = auraT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveAura = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveAura
        {
            get { return m_RemoveAura; }
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
    /// BaseAuraManager的事件数据类
    /// </summary>
    public class AfterRemoveAuraCallEventArgs<T> : AuraHandlerEventArgs<T> where T : BaseAura
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveAuraCallEventArgs( T auraT, BaseAuraHandler<T> auraHandler ) :
            base( auraHandler )
        {
            m_RemoveAura = auraT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveAura = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveAura
        {
            get { return m_RemoveAura; }
        }
        #endregion
    }
    #endregion
}
#endregion