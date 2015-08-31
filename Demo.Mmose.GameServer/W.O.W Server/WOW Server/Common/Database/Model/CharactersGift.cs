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
    /// 游戏人物天赋信息
    /// </summary>
    public class CharactersGift : XPObject
    {
        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物天赋信息的GuidID
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
        private long m_ItemGuid;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long ItemGuid
        {
            get { return m_ItemGuid; }
            set { SetPropertyValue<long>( "ItemGuid", ref m_ItemGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Entry;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Entry
        {
            get { return m_Entry; }
            set { SetPropertyValue<long>( "Entry", ref m_Entry, value ); }
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
            ItemGuid = 0;
            Entry = 0;
            Flags = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion