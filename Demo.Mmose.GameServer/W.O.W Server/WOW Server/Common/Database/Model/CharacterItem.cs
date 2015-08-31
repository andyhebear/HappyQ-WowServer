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
    /// 游戏账号里面的游戏人物的物品
    /// </summary>
    public class CharacterItem : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterItem() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharacterItem( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物的物品的拥有者序号
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
        private ulong m_ItemTemplateGuid;
        #endregion
        /// <summary>
        /// 游戏人物的物品在模板内的唯一序号
        /// </summary>
        public ulong ItemTemplateGuid
        {
            get { return m_ItemTemplateGuid; }
            set { SetPropertyValue<ulong>( "ItemTemplateGuid", ref m_ItemTemplateGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Amount;
        #endregion
        /// <summary>
        /// 游戏人物的物品数量
        /// </summary>
        public int Amount
        {
            get { return m_Amount; }
            set { SetPropertyValue<int>( "Amount", ref m_Amount, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_BagId;
        #endregion
        /// <summary>
        /// 游戏人物的物品在那个包裹内的编号
        /// </summary>
        public int BagId
        {
            get { return m_BagId; }
            set { SetPropertyValue<int>( "BagId", ref m_BagId, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_SlotId;
        #endregion
        /// <summary>
        /// 游戏人物的物品在那个包裹内的位置编号
        /// </summary>
        public int SlotId
        {
            get { return m_SlotId; }
            set { SetPropertyValue<int>( "SlotId", ref m_SlotId, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();
            ItemTemplateGuid = 0;
            Amount = 0;
            BagId = 0;
            SlotId = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion