﻿#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

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
    /// 游戏人物增益/减益信息
    /// </summary>
    public class CharacterAura : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterAura() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharacterAura( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物增益/减益信息拥有者的唯一序号
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
        private long m_SpellGuid;
        #endregion
        /// <summary>
        /// 游戏人物法术序号
        /// </summary>
        public long SpellGuid
        {
            get { return m_SpellGuid; }
            set { SetPropertyValue<long>( "SpellGuid", ref m_SpellGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_EffectIndex;
        #endregion
        /// <summary>
        /// 游戏人物效果索引
        /// </summary>
        public long EffectIndex
        {
            get { return m_EffectIndex; }
            set { SetPropertyValue<long>( "EffectIndex", ref m_EffectIndex, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private TimeSpan m_RemainTime;
        #endregion
        /// <summary>
        /// 游戏人物效果剩余时间
        /// </summary>
        public TimeSpan RemainTime
        {
            get { return m_RemainTime; }
            set { SetPropertyValue<TimeSpan>( "RemainTime", ref m_RemainTime, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();
            SpellGuid = 0;
            EffectIndex = 0;
            RemainTime = TimeSpan.Zero;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion