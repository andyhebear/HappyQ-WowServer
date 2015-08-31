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
    /// 宠物法术
    /// </summary>
    public class PetSpell : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public PetSpell() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public PetSpell( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Owner;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        [Indexed]
        public long Owner
        {
            get { return m_Owner; }
            set { SetPropertyValue<long>( "Owner", ref m_Owner, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_SpellId;
        #endregion
        /// <summary>
        /// 
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
        private long m_SlotId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long SlotId
        {
            get { return m_SlotId; }
            set { SetPropertyValue<long>( "SlotId", ref m_SlotId, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Active;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Active
        {
            get { return m_Active; }
            set { SetPropertyValue<long>( "Active", ref m_Active, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion