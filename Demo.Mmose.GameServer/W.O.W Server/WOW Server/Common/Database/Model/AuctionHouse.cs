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
    /// 拍卖系统
    /// </summary>
    public class AuctionHouse : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public AuctionHouse() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public AuctionHouse( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ItemGuid;
        #endregion
        /// <summary>
        ///  拍卖道具的唯一序号
        /// </summary>
        [Indexed]
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
        /// 拍卖道具模板的唯一序号
        /// </summary>
        [Indexed]
        public long ItemTemplateGuid
        {
            get { return m_ItemTemplateGuid; }
            set { SetPropertyValue<long>( "ItemTemplateGuid", ref m_ItemTemplateGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 拍卖的道具拥有者的唯一序号
        /// </summary>
        public CharacterBase Owner
        {
            get { return m_Owner; }
            set { SetPropertyValue<CharacterBase>( "Owner", ref m_Owner, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_BuyoutPrice;
        #endregion
        /// <summary>
        /// 拍卖道具的直购价格
        /// </summary>
        public uint BuyoutPrice
        {
            get { return m_BuyoutPrice; }
            set { SetPropertyValue<uint>( "BuyoutPrice", ref m_BuyoutPrice, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_EndTime;
        #endregion
        /// <summary>
        /// 拍卖道具的结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return m_EndTime; }
            set { SetPropertyValue<DateTime>( "DateTime", ref m_EndTime, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Buyer;
        #endregion
        /// <summary>
        /// 拍卖道具出价最高的人的唯一序号
        /// </summary>
        public CharacterBase Buyer
        {
            get { return m_Buyer; }
            set { SetPropertyValue<CharacterBase>( "Buyer", ref m_Buyer, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_LastBid;
        #endregion
        /// <summary>
        /// 拍卖道具最后出价人的金币数目
        /// </summary>
        public uint LastBid
        {
            get { return m_LastBid; }
            set { SetPropertyValue<uint>( "LastBid", ref m_LastBid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_StartBid;
        #endregion
        /// <summary>
        /// 拍卖道具开始出价人的金币数目
        /// </summary>
        public uint StartBid
        {
            get { return m_StartBid; }
            set { SetPropertyValue<uint>( "StartBid", ref m_StartBid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Deposit;
        #endregion
        /// <summary>
        /// 拍卖道具保证金
        /// </summary>
        public uint Deposit
        {
            get { return m_Deposit; }
            set { SetPropertyValue<uint>( "Deposit", ref m_Deposit, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Location;
        #endregion
        /// <summary>
        /// 拍卖房的位置
        /// </summary>
        public uint Location
        {
            get { return m_Location; }
            set { SetPropertyValue<uint>( "Location", ref m_Location, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            ItemGuid = 0;
            ItemTemplateGuid = 0;
            Owner = null;
            BuyoutPrice = 0;
            EndTime = DateTime.MinValue;
            Buyer = null;
            LastBid = 0;
            StartBid = 0;
            Deposit = 0;
            Location = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion