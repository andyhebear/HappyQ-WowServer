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
    /// 服务正常运行的时间(防止服务程序启动时检测小于服务程序曾经正常运行的时间)
    /// </summary>
    public class ServerUptime : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public ServerUptime() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public ServerUptime( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_StartTime;
        #endregion
        /// <summary>
        /// 服务开始运行的时间
        /// </summary>
        public DateTime StartTime
        {
            get { return m_StartTime; }
            set { SetPropertyValue<DateTime>( "StartTime", ref m_StartTime, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_UpdateTime;
        #endregion
        /// <summary>
        /// 服务正常运行的时间(一般用于SQL数据存储时的运行时间)
        /// </summary>
        public DateTime UpdateTime
        {
            get { return m_UpdateTime; }
            set { SetPropertyValue<DateTime>( "UpdateTime", ref m_UpdateTime, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            StartTime = DateTime.Now;
            UpdateTime = DateTime.Now;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion