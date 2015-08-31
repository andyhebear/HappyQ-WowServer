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
    /// 游戏人物法术冷却时间
    /// </summary>
    public class CharacterSpellCooldown : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterSpellCooldown() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharacterSpellCooldown( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物法术冷却时间拥有者的GuidID
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
        private long m_SpellId;
        #endregion
        /// <summary>
        /// 游戏人物法术冷却时间的编号
        /// </summary>
        public long SpellId
        {
            get { return m_SpellId; }
            set { SetPropertyValue<long>( "SpellId", ref m_SpellId, value ); }
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterItem m_Item;
        #endregion
        /// <summary>
        /// 游戏人物道具冷却时间的编号
        /// </summary>
        public CharacterItem Item
        {
            get { return m_Item; }
            set { SetPropertyValue<CharacterItem>( "Item", ref m_Item, value ); }
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_Cooldown;
        #endregion
        /// <summary>
        /// 游戏人物道具冷却的时间段
        /// </summary>
        public DateTime Cooldown
        {
            get { return m_Cooldown; }
            set { SetPropertyValue<DateTime>( "Cooldown", ref m_Cooldown, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();
            Item = new CharacterItem();
            Cooldown = DateTime.MinValue;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion