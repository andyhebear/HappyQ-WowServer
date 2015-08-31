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
    /// 人物交易的记录
    /// </summary>
    public class CharacterTradeLog : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterTradeLog() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharacterTradeLog( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_OwnerOne;
        #endregion
        /// <summary>
        /// 记录交易的人物1的唯一序号
        /// </summary>
        [Indexed]
        public CharacterBase OwnerOne
        {
            get { return m_OwnerOne; }
            set { SetPropertyValue<CharacterBase>( "OwnerOne", ref m_OwnerOne, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_OwnerTwo;
        #endregion
        /// <summary>
        /// 记录交易的人物2的唯一序号
        /// </summary>
        [Indexed]
        public CharacterBase OwnerTwo
        {
            get { return m_OwnerTwo; }
            set { SetPropertyValue<CharacterBase>( "OwnerTwo", ref m_OwnerTwo, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_TradeInfoOneToTwo;
        #endregion
        /// <summary>
        /// 记录交易人物1的文字编码信息
        /// "ItemGuid(OnlyItemGuid):Count;ItemGuid(OnlyItemGuid):Count;...ItemGuid(OnlyItemGuid):Count"
        /// </summary>
        [Size( 1000 )]
        public string TradeInfoOneToTwo
        {
            get { return m_TradeInfoOneToTwo; }
            set { SetPropertyValue<string>( "TradeInfoOneToTwo", ref m_TradeInfoOneToTwo, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_TradeInfoTwoToOne;
        #endregion
        /// <summary>
        /// 记录交易人物2的文字编码信息
        /// "ItemGuid(OnlyItemGuid):Count;ItemGuid(OnlyItemGuid):Count;...ItemGuid(OnlyItemGuid):Count"
        /// </summary>
        [Size( 1000 )]
        public string TradeInfoTwoToOne
        {
            get { return m_TradeInfoTwoToOne; }
            set { SetPropertyValue<string>( "TradeInfoTwoToOne", ref m_TradeInfoTwoToOne, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_TradeTime;
        #endregion
        /// <summary>
        /// 记录交易时的时间
        /// </summary>
        [NullValue( null )]
        public DateTime TradeTime
        {
            get { return m_TradeTime; }
            set { SetPropertyValue<DateTime>( "TradeTime", ref m_TradeTime, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            OwnerOne = new CharacterBase();
            OwnerTwo = new CharacterBase();
            TradeInfoOneToTwo = string.Empty;
            TradeInfoTwoToOne = string.Empty;
            TradeTime = DateTime.MinValue;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion