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
    /// 游戏人物任务信息
    /// </summary>
    public class CharactersQuestStatus : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharactersQuestStatus() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharactersQuestStatus( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物任务信息的GuidID
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
        private long m_Quest;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Quest
        {
            get { return m_Quest; }
            set { SetPropertyValue<long>( "Quest", ref m_Quest, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Status;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Status
        {
            get { return m_Status; }
            set { SetPropertyValue<long>( "Status", ref m_Status, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Rewarded;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Rewarded
        {
            get { return m_Rewarded; }
            set { SetPropertyValue<long>( "Rewarded", ref m_Rewarded, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Explored;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Explored
        {
            get { return m_Explored; }
            set { SetPropertyValue<long>( "Explored", ref m_Explored, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Timer;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Timer
        {
            get { return m_Timer; }
            set { SetPropertyValue<long>( "Timer", ref m_Timer, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MobCount0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MobCount0
        {
            get { return m_MobCount0; }
            set { SetPropertyValue<long>( "MobCount0", ref m_MobCount0, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MobCount1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MobCount1
        {
            get { return m_MobCount1; }
            set { SetPropertyValue<long>( "MobCount1", ref m_MobCount1, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MobCount2;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MobCount2
        {
            get { return m_MobCount2; }
            set { SetPropertyValue<long>( "MobCount2", ref m_MobCount2, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MobCount3;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MobCount3
        {
            get { return m_MobCount3; }
            set { SetPropertyValue<long>( "MobCount3", ref m_MobCount3, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ItemCount0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long ItemCount0
        {
            get { return m_ItemCount0; }
            set { SetPropertyValue<long>( "ItemCount0", ref m_ItemCount0, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ItemCount1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long ItemCount1
        {
            get { return m_ItemCount1; }
            set { SetPropertyValue<long>( "ItemCount1", ref m_ItemCount1, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ItemCount2;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long ItemCount2
        {
            get { return m_ItemCount2; }
            set { SetPropertyValue<long>( "ItemCount2", ref m_ItemCount2, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ItemCount3;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long ItemCount3
        {
            get { return m_ItemCount3; }
            set { SetPropertyValue<long>( "ItemCount3", ref m_ItemCount3, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion