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

namespace Demo.Mmose.Core.Entity.Suit.Mail
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseMailBox的事件数据类
    /// </summary>
    public class BaseMailBoxEventArgs<T> : EventArgs where T : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BaseMailBoxEventArgs( BaseMailBox<T> mailBoxT )
        {
            m_MailBox = mailBoxT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseMailBox的数据
        /// </summary>
        private BaseMailBox<T> m_MailBox = null;
        #endregion
        /// <summary>
        /// BaseGuild实例
        /// </summary>
        public BaseMailBox<T> MailBox
        {
            get { return m_MailBox; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMailBox的事件数据类
    /// </summary>
    public class BeforeAddMailMessageCallEventArgs<T> : BaseMailBoxEventArgs<T> where T : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddMailMessageCallEventArgs( T addMailMessage, BaseMailBox<T> mailBoxT ) :
            base( mailBoxT )
        {
            m_AddMailMessage = addMailMessage;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddMailMessage = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddMailMessage
        {
            get { return m_AddMailMessage; }
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
    /// BaseMailBox的事件数据类
    /// </summary>
    public class AfterAddMailMessageCallEventArgs<T> : BaseMailBoxEventArgs<T> where T : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddMailMessageCallEventArgs( T addMailMessage, BaseMailBox<T> mailBoxT ) :
            base( mailBoxT )
        {
            m_AddMailMessage = addMailMessage;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddMailMessage = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddMailMessage
        {
            get { return m_AddMailMessage; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMailBox的事件数据类
    /// </summary>
    public class BeforeRemoveMailMessageCallEventArgs<T> : BaseMailBoxEventArgs<T> where T : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveMailMessageCallEventArgs( T removeMailMessage, BaseMailBox<T> mailBoxT ) :
            base( mailBoxT )
        {
            m_RemoveMailMessage = removeMailMessage;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveMailMessage = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveMailMessage
        {
            get { return m_RemoveMailMessage; }
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
    /// BaseMailBox的事件数据类
    /// </summary>
    public class AfterRemoveMailMessageCallEventArgs<T> : BaseMailBoxEventArgs<T> where T : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveMailMessageCallEventArgs( T removeMailMessage, BaseMailBox<T> mailBoxT ) :
            base( mailBoxT )
        {
            m_RemoveMailMessage = removeMailMessage;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveMailMessage = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveMailMessage
        {
            get { return m_RemoveMailMessage; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMailManager的事件数据类
    /// </summary>
    public class BaseMailHandlerEventArgs<T, V> : EventArgs
        where T : BaseMailBox<V>
        where V : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BaseMailHandlerEventArgs( BaseMailHandler<T, V> mailHandlerT )
        {
            m_MailHandler = mailHandlerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseMailHandler<T, V> m_MailHandler = null;
        #endregion
        /// <summary>
        /// BaseGuild实例
        /// </summary>
        public BaseMailHandler<T, V> MailHandler
        {
            get { return m_MailHandler; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMailManager的事件数据类
    /// </summary>
    public class BeforeAddMailBoxCallEventArgs<T, V> : BaseMailHandlerEventArgs<T, V>
        where T : BaseMailBox<V>
        where V : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddMailBoxCallEventArgs( T addMailBox, BaseMailHandler<T, V> mailHandlerT ) :
            base( mailHandlerT )
        {
            m_AddMailBox = addMailBox;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddMailBox = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddMailBox
        {
            get { return m_AddMailBox; }
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
    public class AfterAddMailBoxCallEventArgs<T, V> : BaseMailHandlerEventArgs<T, V>
        where T : BaseMailBox<V>
        where V : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddMailBoxCallEventArgs( T addMailBox, BaseMailHandler<T, V> mailHandlerT ) :
            base( mailHandlerT )
        {
            m_AddMailBox = addMailBox;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddMailBox = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddMailBox
        {
            get { return m_AddMailBox; }
        }
        #endregion
    }

    /// <summary>
    /// BaseMailManager的事件数据类
    /// </summary>
    public class BeforeRemoveMailBoxCallEventArgs<T, V> : BaseMailHandlerEventArgs<T, V>
        where T : BaseMailBox<V>
        where V : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveMailBoxCallEventArgs( T removeMailBox, BaseMailHandler<T, V> mailHandlerT ) :
            base( mailHandlerT )
        {
            m_RemoveMailBox = removeMailBox;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveMailBox = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveMailBox
        {
            get { return m_RemoveMailBox; }
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
    public class AfterRemoveMailBoxCallEventArgs<T, V> : BaseMailHandlerEventArgs<T, V>
        where T : BaseMailBox<V>
        where V : BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveMailBoxCallEventArgs( T removeMailBox, BaseMailHandler<T, V> mailHandlerT ) :
            base( mailHandlerT )
        {
            m_RemoveMailBox = removeMailBox;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveMailBox = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveMailBox
        {
            get { return m_RemoveMailBox; }
        }
        #endregion
    }
    #endregion
}
#endregion