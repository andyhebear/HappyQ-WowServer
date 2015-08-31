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
    /// 人物聊天的记录
    /// </summary>
    public class CharacterChatLog : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterChatLog() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharacterChatLog( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 记录聊天人物的唯一序号
        /// </summary>
        [Indexed]
        public CharacterBase Owner
        {
            get { return m_Owner; }
            set { SetPropertyValue<CharacterBase>( "Owner", ref m_Owner, value ); }
        }

        #region zh-CHS 枚举 | en Enum
        /// <summary>
        /// 聊天频道
        /// </summary>
        public enum ChatType
        {
            Normal = 0x00,
            /// <summary>
            /// 耳语频道
            /// </summary>
            Whisper = 0x01,
            /// <summary>
            /// 交易频道
            /// </summary>
            Trader = 0x02,
            /// <summary>
            /// 团队频道
            /// </summary>
            Party = 0x04,
            /// <summary>
            /// 部落频道
            /// </summary>
            Guild = 0x08,
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ChatTypeFlag;
        #endregion
        /// <summary>
        /// 记录人物在那个频道聊天
        /// </summary>
        public uint ChatTypeFlag
        {
            get { return m_ChatTypeFlag; }
            set { SetPropertyValue<uint>( "ChatTypeFlag", ref m_ChatTypeFlag, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_ChatMessage;
        #endregion
        /// <summary>
        /// 记录人物聊天时的文字信息
        /// </summary>
        [Size( 1000 )]
        public string ChatMessage
        {
            get { return m_ChatMessage; }
            set { SetPropertyValue<string>( "ChatMessage", ref m_ChatMessage, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_ChatTime;
        #endregion
        /// <summary>
        /// 记录人物聊天时的时间
        /// </summary>
        [NullValue( null )]
        public DateTime ChatTime
        {
            get { return m_ChatTime; }
            set { SetPropertyValue<DateTime>( "ChatTime", ref m_ChatTime, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();
            ChatTypeFlag = 0;
            ChatMessage = string.Empty;
            ChatTime = DateTime.MinValue;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion