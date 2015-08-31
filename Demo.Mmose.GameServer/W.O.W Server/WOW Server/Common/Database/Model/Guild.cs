#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
//
// This file is a part of the G.O.S.E(Game Online Server Engine) for .NET.
//
//           2007-2008 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions outlined
// in the accompanying license agreement.
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using DevExpress.Xpo;
#endregion

namespace Demo.Wow.Database.Ver1a
{
    /// <summary>
    /// 行会系统
    /// </summary>
    public class Guild : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public Guild() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public Guild( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_GuildName;
        #endregion
        /// <summary>
        /// 行会的名称
        /// </summary>
        [Indexed]
        [Size( 255 )]
        public string GuildName
        {
            get { return m_GuildName; }
            set { SetPropertyValue<string>( "GuildName", ref m_GuildName, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Leader;
        #endregion
        /// <summary>
        /// 行会的领导者
        /// </summary>
        public CharacterBase Leader
        {
            get { return m_Leader; }
            set { SetPropertyValue<CharacterBase>( "Leader", ref m_Leader, value ); }
        }

        /// <summary>
        /// 全部的游戏人物
        /// </summary>
        [Association( "Guild-CharacterBase" )]
        public XPCollection<CharacterBase> Characters
        {
            get { return GetCollection<CharacterBase>( "Characters" ); ; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_EmblemStyle;
        #endregion
        /// <summary>
        /// 行会徽章的风格
        /// </summary>
        public uint EmblemStyle
        {
            get { return m_EmblemStyle; }
            set { SetPropertyValue<uint>( "EmblemStyle", ref m_EmblemStyle, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_EmblemColor;
        #endregion
        /// <summary>
        /// 行会徽章的颜色
        /// </summary>
        public uint EmblemColor
        {
            get { return m_EmblemColor; }
            set { SetPropertyValue<uint>( "EmblemColor", ref m_EmblemColor, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_BorderStyle;
        #endregion
        /// <summary>
        /// 行会边界的风格
        /// </summary>
        public uint BorderStyle
        {
            get { return m_BorderStyle; }
            set { SetPropertyValue<uint>( "BorderStyle", ref m_BorderStyle, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_BorderColor;
        #endregion
        /// <summary>
        /// 行会边界的颜色
        /// </summary>
        public uint BorderColor
        {
            get { return m_BorderColor; }
            set { SetPropertyValue<uint>( "BorderColor", ref m_BorderColor, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_BackgroundColor;
        #endregion
        /// <summary>
        /// 行会背景的颜色
        /// </summary>
        public uint BackgroundColor
        {
            get { return m_BackgroundColor; }
            set { SetPropertyValue<uint>( "BackgroundColor", ref m_BackgroundColor, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_GuildInfo;
        #endregion
        /// <summary>
        /// 行会的通告信息
        /// </summary>
        [Size( 500 )]
        public string GuildInfo
        {
            get { return m_GuildInfo; }
            set { SetPropertyValue<string>( "GuildInfo", ref m_GuildInfo, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_CreateDate;
        #endregion
        /// <summary>
        /// 行会的创建的日期
        /// </summary>
        public DateTime CreateDate
        {
            get { return m_CreateDate; }
            set { SetPropertyValue<DateTime>( "CreateDate", ref m_CreateDate, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            GuildName = string.Empty;

            Leader = new CharacterBase();
            EmblemStyle = 0;
            EmblemColor = 0;
            BorderStyle = 0;
            BorderColor = 0;
            BackgroundColor = 0;
            GuildInfo = string.Empty;
            CreateDate = DateTime.Now;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion