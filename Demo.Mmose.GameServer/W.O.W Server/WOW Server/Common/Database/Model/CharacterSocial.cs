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
    /// 游戏人物好友信息
    /// </summary>
    public class CharacterSocial : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterSocial() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharacterSocial( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物好友信息的GuidID
        /// </summary>
        [Indexed]
        public CharacterBase Owner
        {
            get { return m_Owner; }
            set { SetPropertyValue<CharacterBase>( "Owner", ref m_Owner, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Name;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { SetPropertyValue<string>( "Name", ref m_Name, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Friend;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        [Indexed]
        public CharacterBase Friend
        {
            get { return m_Friend; }
            set { SetPropertyValue<CharacterBase>( "Friend", ref m_Friend, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Flags;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Flags
        {
            get { return m_Flags; }
            set { SetPropertyValue<long>( "Flags", ref m_Flags, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();
            Name = string.Empty;
            Friend = new CharacterBase();
            Flags = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion