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

namespace Demo.Mmose.Core.Entity.Suit.Guild
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseGuild的事件数据类
    /// </summary>
    public class GuildEventArgs<T> : EventArgs where T : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public GuildEventArgs( BaseGuild<T> guildT )
        {
            m_Guild = guildT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseGuild<T> m_Guild = null;
        #endregion
        /// <summary>
        /// BaseGuild实例
        /// </summary>
        public BaseGuild<T> Guild
        {
            get { return m_Guild; }
        }
        #endregion
    }

    /// <summary>
    /// BaseGuild的事件数据类
    /// </summary>
    public class BeforeAddGuildMemberCallEventArgs<T> : GuildEventArgs<T> where T : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddGuildMemberCallEventArgs( T addGuildMember, BaseGuild<T> guildT ) :
            base( guildT )
        {
            m_AddGuildMember = addGuildMember;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddGuildMember = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddGuildMember
        {
            get { return m_AddGuildMember; }
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
    /// BaseGuild的事件数据类
    /// </summary>
    public class AfterAddGuildMemberCallEventArgs<T> : GuildEventArgs<T> where T : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddGuildMemberCallEventArgs( T addGuildMember, BaseGuild<T> guildT ) :
            base( guildT )
        {
            m_AddGuildMember = addGuildMember;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddGuildMember = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddGuildMember
        {
            get { return m_AddGuildMember; }
        }
        #endregion
    }

    /// <summary>
    /// BaseGuild的事件数据类
    /// </summary>
    public class BeforeRemoveGuildMemberCallEventArgs<T> : GuildEventArgs<T> where T : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveGuildMemberCallEventArgs( T removeGuildMember, BaseGuild<T> guildT ) :
            base( guildT )
        {
            m_RemoveGuildMember = removeGuildMember;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveGuildMember = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveGuildMember
        {
            get { return m_RemoveGuildMember; }
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
    /// BaseGuild的事件数据类
    /// </summary>
    public class AfterRemoveGuildMemberCallEventArgs<T> : GuildEventArgs<T> where T : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveGuildMemberCallEventArgs( T removeGuildMember, BaseGuild<T> guildT ) :
            base( guildT )
        {
            m_RemoveGuildMember = removeGuildMember;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveGuildMember = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveGuildMember
        {
            get { return m_RemoveGuildMember; }
        }
        #endregion
    }

    /// <summary>
    /// BaseGuildManager的事件数据类
    /// </summary>
    public class GuildHandlerEventArgs<T, V> : EventArgs
        where T : BaseGuild<V>
        where V : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public GuildHandlerEventArgs( BaseGuildHandler<T, V> guildHandlerT )
        {
            m_GuildHandler = guildHandlerT;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseGuildHandler<T, V> m_GuildHandler = null;
        #endregion
        /// <summary>
        /// BaseGuild实例
        /// </summary>
        public BaseGuildHandler<T, V> GuildHandler
        {
            get { return m_GuildHandler; }
        }
        #endregion
    }

    /// <summary>
    /// BaseGuildManager的事件数据类
    /// </summary>
    public class BeforeAddGuildCallEventArgs<T, V> : GuildHandlerEventArgs<T, V>
        where T : BaseGuild<V>
        where V : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeAddGuildCallEventArgs( T addGuild, BaseGuildHandler<T, V> guildHandlerT ) :
            base( guildHandlerT )
        {
            m_AddGuild = addGuild;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddGuild = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddGuild
        {
            get { return m_AddGuild; }
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
    /// BaseGuildManager的事件数据类
    /// </summary>
    public class AfterAddGuildCallEventArgs<T, V> : GuildHandlerEventArgs<T, V>
        where T : BaseGuild<V>
        where V : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterAddGuildCallEventArgs( T addGuild, BaseGuildHandler<T, V> guildHandlerT ) :
            base( guildHandlerT )
        {
            m_AddGuild = addGuild;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_AddGuild = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T AddGuild
        {
            get { return m_AddGuild; }
        }
        #endregion
    }

    /// <summary>
    /// BaseGuildManager的事件数据类
    /// </summary>
    public class BeforeRemoveGuildCallEventArgs<T, V> : GuildHandlerEventArgs<T, V>
        where T : BaseGuild<V>
        where V : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BeforeRemoveGuildCallEventArgs( T removeGuild, BaseGuildHandler<T, V> guildHandlerT ) :
            base( guildHandlerT )
        {
            m_RemoveGuild = removeGuild;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveGuild = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveGuild
        {
            get { return m_RemoveGuild; }
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
    /// BaseGuildManager的事件数据类
    /// </summary>
    public class AfterRemoveGuildCallEventArgs<T, V> : GuildHandlerEventArgs<T, V>
        where T : BaseGuild<V>
        where V : BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AfterRemoveGuildCallEventArgs( T removeGuild, BaseGuildHandler<T, V> guildHandlerT ) :
            base( guildHandlerT )
        {
            m_RemoveGuild = removeGuild;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_RemoveGuild = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T RemoveGuild
        {
            get { return m_RemoveGuild; }
        }
        #endregion
    }
    #endregion
}
#endregion