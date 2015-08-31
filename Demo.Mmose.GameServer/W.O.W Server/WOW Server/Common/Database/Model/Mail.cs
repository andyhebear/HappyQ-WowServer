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
    /// 邮件系统
    /// </summary>
    public class Mail : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public Mail() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public Mail( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MessageType;
        #endregion
        /// <summary>
        /// 邮件的消息类型
        /// </summary>
        public uint MessageType
        {
            get { return m_MessageType; }
            set { SetPropertyValue<uint>( "MessageType", ref m_MessageType, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Sender;
        #endregion
        /// <summary>
        /// 邮件发送者的唯一序号
        /// </summary>
        public CharacterBase Sender
        {
            get { return m_Sender; }
            set { SetPropertyValue<CharacterBase>( "Sender", ref m_Sender, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Receiver;
        #endregion
        /// <summary>
        /// 邮件接收者的唯一序号
        /// </summary>
        [Indexed]
        public CharacterBase Receiver
        {
            get { return m_Receiver; }
            set { SetPropertyValue<CharacterBase>( "Receiver", ref m_Receiver, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Subject;
        #endregion
        /// <summary>
        /// 邮件的标题
        /// </summary>
        public string Subject
        {
            get { return m_Subject; }
            set { SetPropertyValue<string>( "Subject", ref m_Subject, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemTextId;
        #endregion
        /// <summary>
        /// 邮件的
        /// </summary>
        public uint ItemTextId
        {
            get { return m_ItemTextId; }
            set { SetPropertyValue<uint>( "ItemTextId", ref m_ItemTextId, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ItemGuid;
        #endregion
        /// <summary>
        /// 邮件内包含的道具的唯一序号
        /// </summary>
        public long ItemGuid
        {
            get { return m_ItemGuid; }
            set { SetPropertyValue<long>( "ItemGuid", ref m_ItemGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ItemTemplateGuid;
        #endregion
        /// <summary>
        ///  邮件内包含的道具模板的唯一序号
        /// </summary>
        public long ItemTemplateGuid
        {
            get { return m_ItemTemplateGuid; }
            set { SetPropertyValue<long>( "ItemTemplateGuid", ref m_ItemTemplateGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_ExpireTime;
        #endregion
        /// <summary>
        /// 邮件的结束日期
        /// </summary>
        public DateTime ExpireTime
        {
            get { return m_ExpireTime; }
            set { SetPropertyValue<DateTime>( "ExpireTime", ref m_ExpireTime, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_DeliverTime;
        #endregion
        /// <summary>
        /// 邮件的交付日期
        /// </summary>
        public DateTime DeliverTime
        {
            get { return m_DeliverTime; }
            set { SetPropertyValue<DateTime>( "DeliverTime", ref m_DeliverTime, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Money;
        #endregion
        /// <summary>
        /// 邮件的包含的金钱数
        /// </summary>
        public uint Money
        {
            get { return m_Money; }
            set { SetPropertyValue<uint>( "Money", ref m_Money, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Cod;
        #endregion
        /// <summary>
        /// 邮件的
        /// </summary>
        public uint Cod
        {
            get { return m_Cod; }
            set { SetPropertyValue<uint>( "Cod", ref m_Cod, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Checked;
        #endregion
        /// <summary>
        /// 邮件是否已经看过
        /// </summary>
        public uint Checked
        {
            get { return m_Checked; }
            set { SetPropertyValue<uint>( "Checked", ref m_Checked, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            MessageType = 0;
            Sender = null;
            Receiver = null;
            Subject = string.Empty;
            ItemTextId = 0;
            ItemGuid = 0;
            ItemTemplateGuid = 0;
            ExpireTime = DateTime.MinValue;
            DeliverTime = DateTime.MinValue;
            Money = 0;
            Cod = 0;
            Checked = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion