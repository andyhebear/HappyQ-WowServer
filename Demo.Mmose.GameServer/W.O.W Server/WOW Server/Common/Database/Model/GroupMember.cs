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
    /// 团队的成员
    /// </summary>
    public class GroupMember : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public GroupMember() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public GroupMember( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Leader;
        #endregion
        /// <summary>
        /// 团队的领导者
        /// </summary>
        [Indexed]
        public CharacterBase Leader
        {
            get { return m_Leader; }
            set { SetPropertyValue<CharacterBase>( "Leader", ref m_Leader, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MemberGuid;
        #endregion
        /// <summary>
        /// 团队的成员唯一序号
        /// </summary>
        [Indexed]
        public long MemberGuid
        {
            get { return m_MemberGuid; }
            set { SetPropertyValue<long>( "MemberGuid", ref m_MemberGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_AssistantGuid;
        #endregion
        /// <summary>
        /// 团队的助攻成员唯一序号
        /// </summary>
        public long AssistantGuid
        {
            get { return m_AssistantGuid; }
            set { SetPropertyValue<long>( "AssistantGuid", ref m_AssistantGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_SubGroupGuid;
        #endregion
        /// <summary>
        /// 团队的子团队的唯一序号
        /// </summary>
        public long SubGroupGuid
        {
            get { return m_SubGroupGuid; }
            set { SetPropertyValue<long>( "SubGroupGuid", ref m_SubGroupGuid, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Leader = new CharacterBase();
            MemberGuid = 0;
            AssistantGuid = 0;
            SubGroupGuid = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion