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
using DevExpress.Xpo;
#endregion

namespace Demo.Wow.Database.Ver1a
{
    /// <summary>
    /// 行会的成员
    /// </summary>
    public class GuildMember : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public GuildMember() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public GuildMember( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Guild m_Guild;
        #endregion
        /// <summary>
        /// 行会的唯一序号
        /// </summary>
        [Indexed]
        public Guild Guild
        {
            get { return m_Guild; }
            set { SetPropertyValue<Guild>( "Guild", ref m_Guild, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Character;
        #endregion
        /// <summary>
        /// 行会的成员的唯一序号
        /// </summary>
        [Indexed]
        public CharacterBase Character
        {
            get { return m_Character; }
            set { SetPropertyValue<CharacterBase>( "Character", ref m_Character, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_RankId;
        #endregion
        /// <summary>
        /// 行会的等级编号
        /// </summary>
        public uint RankId
        {
            get { return m_RankId; }
            set { SetPropertyValue<uint>( "RankId", ref m_RankId, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_EveryoneNote;
        #endregion
        /// <summary>
        /// 行会的任何人可以看的信息
        /// </summary>
        [Size( 255 )]
        public string EveryoneNote
        {
            get { return m_EveryoneNote; }
            set { SetPropertyValue<string>( "EveryoneNote", ref m_EveryoneNote, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_OfficerNote;
        #endregion
        /// <summary>
        /// 行会的官员可以看的信息
        /// </summary>
        [Size( 255 )]
        public string OfficerNote
        {
            get { return m_OfficerNote; }
            set { SetPropertyValue<string>( "OfficerNote", ref m_OfficerNote, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Guild = new Guild();
            Character = new CharacterBase();
            RankId = 0;
            EveryoneNote = string.Empty;
            OfficerNote = string.Empty;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion