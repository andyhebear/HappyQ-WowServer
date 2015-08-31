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
    /// 游戏账号里面的游戏人物
    /// </summary>
    public class CreatureMovement : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CreatureMovement() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CreatureMovement( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CreatureTemplateGuid;
        #endregion
        /// <summary>
        /// 游戏人物所处的帐号的ID
        /// </summary>
        [Indexed]
        public long CreatureTemplateGuid
        {
            get { return m_CreatureTemplateGuid; }
            set { SetPropertyValue<long>( "CreatureTemplateGuid", ref m_CreatureTemplateGuid, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            CreatureTemplateGuid = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion