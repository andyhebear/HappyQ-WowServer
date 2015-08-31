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
    /// 团队系统
    /// </summary>
    public class Group : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public Group() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public Group( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Leader;
        #endregion
        /// <summary>
        /// 团队的领导者的唯一序号
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
        private long m_MainTankGuid;
        #endregion
        /// <summary>
        /// 团队的主攻者的唯一序号
        /// </summary>
        public long MainTankGuid
        {
            get { return m_MainTankGuid; }
            set { SetPropertyValue<long>( "MainTankGuid", ref m_MainTankGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MainAssistantGuid;
        #endregion
        /// <summary>
        /// 团队的助攻者的唯一序号
        /// </summary>
        public long MainAssistantGuid
        {
            get { return m_MainAssistantGuid; }
            set { SetPropertyValue<long>( "MainAssistantGuid", ref m_MainAssistantGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_LootMethod;
        #endregion
        /// <summary>
        /// 团队掉落物品的方式
        /// </summary>
        public uint LootMethod
        {
            get { return m_LootMethod; }
            set { SetPropertyValue<uint>( "LootMethod", ref m_LootMethod, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_LooterGuid;
        #endregion
        /// <summary>
        /// 团队掉落者的唯一序号
        /// </summary>
        public long LooterGuid
        {
            get { return m_LooterGuid; }
            set { SetPropertyValue<long>( "LooterGuid", ref m_LooterGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_LootThreshold;
        #endregion
        /// <summary>
        /// 团队
        /// </summary>
        public long LootThreshold
        {
            get { return m_LootThreshold; }
            set { SetPropertyValue<long>( "LootThreshold", ref m_LootThreshold, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Icon1;
        #endregion
        /// <summary>
        /// 团队的图标1
        /// </summary>
        public uint Icon1
        {
            get { return m_Icon1; }
            set { SetPropertyValue<uint>( "Icon1", ref m_Icon1, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Icon2;
        #endregion
        /// <summary>
        /// 团队的图标2
        /// </summary>
        public uint Icon2
        {
            get { return m_Icon2; }
            set { SetPropertyValue<uint>( "Icon2", ref m_Icon2, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Icon3;
        #endregion
        /// <summary>
        /// 团队的图标3
        /// </summary>
        public uint Icon3
        {
            get { return m_Icon3; }
            set { SetPropertyValue<uint>( "Icon3", ref m_Icon3, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Icon4;
        #endregion
        /// <summary>
        /// 团队的图标4
        /// </summary>
        public uint Icon4
        {
            get { return m_Icon4; }
            set { SetPropertyValue<uint>( "Icon4", ref m_Icon4, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Icon5;
        #endregion
        /// <summary>
        /// 团队的图标5
        /// </summary>
        public uint Icon5
        {
            get { return m_Icon5; }
            set { SetPropertyValue<uint>( "Icon5", ref m_Icon5, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Icon6;
        #endregion
        /// <summary>
        /// 团队的图标6
        /// </summary>
        public uint Icon6
        {
            get { return m_Icon6; }
            set { SetPropertyValue<uint>( "Icon6", ref m_Icon6, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Icon7;
        #endregion
        /// <summary>
        /// 团队的图标7
        /// </summary>
        public uint Icon7
        {
            get { return m_Icon7; }
            set { SetPropertyValue<uint>( "Icon7", ref m_Icon7, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Icon8;
        #endregion
        /// <summary>
        /// 团队的图标8
        /// </summary>
        public uint Icon8
        {
            get { return m_Icon8; }
            set { SetPropertyValue<uint>( "Icon8", ref m_Icon8, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsRaid;
        #endregion
        /// <summary>
        /// 团队是否是副本中的
        /// </summary>
        public bool IsRaid
        {
            get { return m_IsRaid; }
            set { SetPropertyValue<bool>( "IsRaid", ref m_IsRaid, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Leader = new CharacterBase();
            MainTankGuid = 0;
            MainAssistantGuid = 0;
            LootMethod = 0;
            LooterGuid = 0;
            LootThreshold = 0;
            Icon1 = 0;
            Icon2 = 0;
            Icon3 = 0;
            Icon4 = 0;
            Icon5 = 0;
            Icon6 = 0;
            Icon7 = 0;
            Icon8 = 0;
            IsRaid = false;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion