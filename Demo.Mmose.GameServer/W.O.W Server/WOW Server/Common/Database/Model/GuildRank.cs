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
    /// 行会的等级信息
    /// </summary>
    public class GuildRank : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public GuildRank() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public GuildRank( Session session ) : base( session ) { }
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
        private long m_RankId;
        #endregion
        /// <summary>
        /// 行会的等级编号
        /// </summary>
        public long RankId
        {
            get { return m_RankId; }
            set { SetPropertyValue<long>( "RankId", ref m_RankId, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_RankName;
        #endregion
        /// <summary>
        /// 行会的等级名称
        /// </summary>
        [Size( 255 )]
        public string RankName
        {
            get { return m_RankName; }
            set { SetPropertyValue<string>( "RankName", ref m_RankName, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Rights;
        #endregion
        /// <summary>
        /// 行会的等级权限
        /// </summary>
        public long Rights
        {
            get { return m_Rights; }
            set { SetPropertyValue<long>( "Rights", ref m_Rights, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Guild = new Guild();
            RankId = 0;
            RankName = string.Empty;
            Rights = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion