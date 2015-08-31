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
    /// 游戏账号里面的游戏人物的宠物
    /// </summary>
    public class CharacterPet : XPObject
    {
        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物的宠物的拥有者序号
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
        private ulong m_CreatureTemplateGuid;
        #endregion
        /// <summary>
        /// 游戏人物的宠物在模板内的唯一序号
        /// </summary>
        public ulong CreatureTemplateGuid
        {
            get { return m_CreatureTemplateGuid; }
            set { SetPropertyValue<ulong>( "CreatureTemplateGuid", ref m_CreatureTemplateGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Name;
        #endregion
        /// <summary>
        /// 游戏人物的宠物的名称
        /// </summary>
        [Size( 64 )]
        public string Name
        {
            get { return m_Name; }
            set { SetPropertyValue<string>( "Name", ref m_Name, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Level;
        #endregion
        /// <summary>
        /// 游戏人物的宠物的等级
        /// </summary>
        public int Level
        {
            get { return m_Level; }
            set { SetPropertyValue<int>( "Level", ref m_Level, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Experience;
        #endregion
        /// <summary>
        /// 游戏人物的宠物的经验
        /// </summary>
        public long Experience
        {
            get { return m_Experience; }
            set { SetPropertyValue<long>( "Experience", ref m_Experience, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Fealty;
        #endregion
        /// <summary>
        /// 游戏人物的宠物的忠诚度
        /// </summary>
        public long Fealty
        {
            get { return m_Fealty; }
            set { SetPropertyValue<long>( "Fealty", ref m_Fealty, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Action;
        #endregion
        /// <summary>
        /// 游戏人物的宠物当前保存的动作编号
        /// </summary>
        public long Action
        {
            get { return m_Action; }
            set { SetPropertyValue<long>( "Action", ref m_Action, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsInUse;
        #endregion
        /// <summary>
        /// 游戏人物的宠物的是否已使用
        /// </summary>
        public bool IsInUse
        {
            get { return m_IsInUse; }
            set { SetPropertyValue<bool>( "IsInUse", ref m_IsInUse, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsRename;
        #endregion
        /// <summary>
        /// 游戏人物的宠物的是否需要重命名
        /// </summary>
        public bool IsRename
        {
            get { return m_IsRename; }
            set { SetPropertyValue<bool>( "IsRename", ref m_IsRename, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = null;
            CreatureTemplateGuid = 0;
            Name = string.Empty;
            Level = 0;
            Experience = 0;
            Fealty = 0;
            Action = 0;
            IsInUse = false;
            IsRename = false;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion