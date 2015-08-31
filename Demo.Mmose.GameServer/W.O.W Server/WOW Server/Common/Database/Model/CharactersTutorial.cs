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
    /// 游戏人物游戏操作指南信息
    /// </summary>
    public class CharactersTutorial : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharactersTutorial() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public CharactersTutorial( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterBase m_Owner;
        #endregion
        /// <summary>
        /// 游戏人物指南信息的GuidID
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
        private uint m_Tutorial0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Tutorial0
        {
            get { return m_Tutorial0; }
            set { SetPropertyValue<uint>( "Tutorial0", ref m_Tutorial0, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Tutorial1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Tutorial1
        {
            get { return m_Tutorial1; }
            set { SetPropertyValue<uint>( "Tutorial1", ref m_Tutorial1, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Tutorial2;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Tutorial2
        {
            get { return m_Tutorial2; }
            set { SetPropertyValue<uint>( "Tutorial2", ref m_Tutorial2, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Tutorial3;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Tutorial3
        {
            get { return m_Tutorial3; }
            set { SetPropertyValue<uint>( "Tutorial3", ref m_Tutorial3, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Tutorial4;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Tutorial4
        {
            get { return m_Tutorial4; }
            set { SetPropertyValue<uint>( "Tutorial4", ref m_Tutorial4, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Tutorial5;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Tutorial5
        {
            get { return m_Tutorial5; }
            set { SetPropertyValue<uint>( "Tutorial5", ref m_Tutorial5, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Tutorial6;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Tutorial6
        {
            get { return m_Tutorial6; }
            set { SetPropertyValue<uint>( "Tutorial6", ref m_Tutorial6, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Tutorial7;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Tutorial7
        {
            get { return m_Tutorial7; }
            set { SetPropertyValue<uint>( "Tutorial7", ref m_Tutorial7, value ); }
        }

        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        public override void AfterConstruction()
        {
            Owner = new CharacterBase();
            Tutorial0 = 0;
            Tutorial1 = 0;
            Tutorial2 = 0;
            Tutorial3 = 0;
            Tutorial4 = 0;
            Tutorial5 = 0;
            Tutorial6 = 0;
            Tutorial7 = 0;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion