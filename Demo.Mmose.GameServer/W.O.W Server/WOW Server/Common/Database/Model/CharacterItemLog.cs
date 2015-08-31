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
    /// 人物道具使用状况的详细记录
    /// </summary>
    public class CharacterItemLog : XPObject
    {
        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 记录使用道具的人物的唯一序号
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
        /// 记录使用的道具的唯一序号
        /// </summary>
        [Indexed]
        public long ItemGuid
        {
            get { return m_ItemGuid; }
            set { SetPropertyValue<long>( "ItemGuid", ref m_ItemGuid, value ); }
        }

        #region zh-CHS Type 枚举 | en Enum
        /// <summary>
        /// 道具使用的信息
        /// </summary>
        public enum UseType
        {
            /// <summary>
            /// 没有使用
            /// </summary>
            None = 0x00,
            /// <summary>
            /// 获得道具
            /// </summary>
            Obtain = 0x01,
            /// <summary>
            /// 消耗道具
            /// </summary>
            Use = 0x02,
            /// <summary>
            /// 交易道具
            /// </summary>
            Trade = 0x04,
            /// <summary>
            /// 丢弃道具
            /// </summary>
            Discard = 0x08
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_UseTypeFlag;
        #endregion
        /// <summary>
        /// 记录道具使用状况的信息
        /// </summary>
        public uint UseTypeFlag
        {
            get { return m_UseTypeFlag; }
            set { SetPropertyValue<uint>( "UseTypeFlag", ref m_UseTypeFlag, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_UseTime;
        #endregion
        /// <summary>
        /// 记录道具使用时的时间
        /// </summary>
        [NullValue( null )]
        public DateTime UseTime
        {
            get { return m_UseTime; }
            set { SetPropertyValue<DateTime>( "UseTime", ref m_UseTime, value ); }
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
            UseTypeFlag = 0;
            UseTime = DateTime.MinValue;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion