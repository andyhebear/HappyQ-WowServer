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
    /// 游戏人物的声望信息
    /// </summary>
    public class CharacterReputation : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterReputation() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharacterReputation( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物的声望拥有者的Guid
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
        private long m_FactionId;
        #endregion
        /// <summary>
        /// 游戏人物的声望的编号
        /// </summary>
        public long FactionId
        {
            get { return m_FactionId; }
            set { SetPropertyValue <long>( "FactionId", ref m_FactionId, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Reputation;
        #endregion
        /// <summary>
        /// 游戏人物的声望的值
        /// EXALTED >= 42000
        /// REVERED >= 21000
        /// HONORED >= 9000
        /// FRIENDLY >= 3000
        /// NEUTRAL >= 0
        /// UNFRIENDLY > -3000
        /// HOSTILE > -6000
        /// HATED  -6000;
        /// </summary>
        public long Reputation
        {
            get { return m_Reputation; }
            set { SetPropertyValue<long>( "Reputation", ref m_Reputation, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Flag;
        #endregion
        /// <summary>
        /// 游戏人物的声望的标记（敌对阵营是否可见）
        /// </summary>
        public long Flag
        {
            get { return m_Flag; }
            set { SetPropertyValue<long>( "Flag", ref m_Flag, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();
            FactionId = 0;
            Reputation = 0;
            Flag = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion