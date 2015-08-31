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
    /// GM使用的详细命令记录
    /// </summary>
    public class GMCommandLog : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public GMCommandLog() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public GMCommandLog( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 记录使用GM命令人物的唯一序号
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
        private string m_CommandInfo;
        #endregion
        /// <summary>
        /// 记录使用GM命令的信息
        /// </summary>
        [Size( 1000 )]
        public string CommandInfo
        {
            get { return m_CommandInfo; }
            set { SetPropertyValue<string>( "CommandInfo", ref m_CommandInfo, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_CommandTime;
        #endregion
        /// <summary>
        /// 记录GM使用命令时的时间
        /// </summary>
        [NullValue( null )]
        public DateTime CommandTime
        {
            get { return m_CommandTime; }
            set { SetPropertyValue<DateTime>( "CommandTime", ref m_CommandTime, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();
            CommandInfo = string.Empty;
            CommandTime = DateTime.MinValue;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion