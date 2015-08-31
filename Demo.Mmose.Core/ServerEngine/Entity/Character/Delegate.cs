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


#region zh-CHS 包含名字空间 | en Include AccessLevelspace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
#endregion

namespace Demo.Mmose.Core.Entity.Character
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseCharacter的事件数据类
    /// </summary>
    public class BaseCharacterEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param AccessLevel="baseCharacter"></param>
        public BaseCharacterEventArgs( BaseCharacter character )
        {
            m_Character = character;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseCharacter m_Character = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseCharacter Character
        {
            get { return m_Character; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCharacter的事件数据类
    /// </summary>
    public class UpdatingAccessLevelEventArgs : BaseCharacterEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param AccessLevel="baseCharacter"></param>
        public UpdatingAccessLevelEventArgs( AccessLevel newAccessLevel, BaseCharacter character ) :
            base( character )
        {
            m_NewAccessLevel = newAccessLevel;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private AccessLevel m_NewAccessLevel = AccessLevel.Player;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public AccessLevel NewAccessLevel
        {
            get { return m_NewAccessLevel; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCharacter的事件数据类
    /// </summary>
    public class UpdatedAccessLevelEventArgs : BaseCharacterEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param AccessLevel="baseCharacter"></param>
        public UpdatedAccessLevelEventArgs( AccessLevel oldAccessLevel, BaseCharacter character ) :
            base( character )
        {
            m_OldAccessLevel = oldAccessLevel;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private AccessLevel m_OldAccessLevel = AccessLevel.Player;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public AccessLevel OldAccessLevel
        {
            get { return m_OldAccessLevel; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCharacter的事件数据类
    /// </summary>
    public class UpdatingNetStateEventArgs : BaseCharacterEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param AccessLevel="baseCharacter"></param>
        public UpdatingNetStateEventArgs( NetState newNetState, BaseCharacter character ) :
            base( character )
        {
            m_NewNetState = newNetState;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NetState m_NewNetState = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public NetState NewNetState
        {
            get { return m_NewNetState; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsCancel = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsCancel
        {
            get { return m_IsCancel; }
            set { m_IsCancel = value; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCharacter的事件数据类
    /// </summary>
    public class UpdatedNetStateEventArgs : BaseCharacterEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param AccessLevel="baseCharacter"></param>
        public UpdatedNetStateEventArgs( NetState oldNetState, BaseCharacter character ) :
            base( character )
        {
            m_OldNetState = oldNetState;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NetState m_OldNetState = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public NetState OldNetState
        {
            get { return m_OldNetState; }
        }
        #endregion
    }
    #endregion
}
#endregion