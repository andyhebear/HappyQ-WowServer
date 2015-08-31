#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Mail
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseMailMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public BaseMailMessage()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public BaseMailMessage( long iMessageId )
        {
            m_MessageId = iMessageId;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS MessageId属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MessageId = -1;
        #endregion
        /// <summary>
        /// 道具的唯一序列号GUID
        /// </summary>
        public long MessageId
        {
            get { return m_MessageId; }
            set { m_MessageId = value; }
        }

        #endregion

        #region zh-CHS TargetSerial属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_TargetSerial = Serial.MinusOne;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Serial TargetSerial
        {
            get { return m_TargetSerial; }
            set { m_TargetSerial = value; }
        }

        #endregion

        #region zh-CHS SenderSerial属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_SenderSerial = Serial.MinusOne;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Serial SenderSerial
        {
            get { return m_TargetSerial; }
            set { m_TargetSerial = value; }
        }

        #endregion

        #region zh-CHS Subject属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Subject = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Subject
        {
            get { return m_Subject; }
            set { m_Subject = value; }
        }

        #endregion

        #region zh-CHS Body属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Body = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Body
        {
            get { return m_Body; }
            set { m_Body = value; }
        }

        #endregion

        #region zh-CHS SendTime属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_SendTime = DateTime.MinValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public DateTime SendTime
        {
            get { return m_SendTime; }
            set { m_SendTime = value; }
        }

        #endregion

        #region zh-CHS DeliveryTime属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_DeliveryTime = DateTime.MaxValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public DateTime DeliveryTime
        {
            get { return m_DeliveryTime; }
            set { m_DeliveryTime = value; }
        }

        /// <summary>
        /// 是否已经接受到消息
        /// </summary>
        public bool WasDelivered
        {
            get { return DateTime.Now >= m_DeliveryTime; }
        }
        #endregion

        #region zh-CHS ReadTime属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_ReadTime = DateTime.MinValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReadTime
        {
            get { return m_ReadTime; }
            set { m_ReadTime = value; }
        }

        /// <summary>
        /// 是否已经读取消息
        /// </summary>
        public bool WasRead
        {
            get { return m_ReadTime >= m_DeliveryTime; }
        }

        #endregion

        #region zh-CHS ExpireTime属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_ExpireTime = DateTime.MinValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpireTime
        {
            get { return m_ExpireTime; }
            set { m_ExpireTime = value; }
        }

        #endregion

        #endregion
    }
}
#endregion