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
    /// 游戏人物的界面按钮的信息
    /// </summary>
    public class CharacterActionBar : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterActionBar() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharacterActionBar( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物的界面按钮拥有者的Guid
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
        private long m_Slot;
        #endregion
        /// <summary>
        /// 快捷按钮编号
        /// </summary>
        public long Slot
        {
            get { return m_Slot; }
            set { SetPropertyValue<long>( "Slot", ref m_Slot, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ActionId;
        #endregion
        /// <summary>
        /// 法术编号或物品编号或宏定义编号
        /// </summary>
        public long ActionId
        {
            get { return m_ActionId; }
            set { SetPropertyValue<long>( "ActionId", ref m_ActionId, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ActionType;
        #endregion
        /// <summary>
        /// 技能类型 0 = 法术 64 = 宏定义 128 = 物品
        /// </summary>
        public long ActionType
        {
            get { return m_ActionType; }
            set { SetPropertyValue<long>( "ActionType", ref m_ActionType, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();
            Slot = 0;
            ActionId = 0;
            ActionType = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion