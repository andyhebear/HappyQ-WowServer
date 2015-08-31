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
using System.Collections.Generic;
#endregion

namespace Demo.Mmose.Core.Entity.GameObject
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class BaseGameObjectEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public BaseGameObjectEventArgs( BaseGameObject gameObject )
        {
            m_GameObject = gameObject;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseGameObject m_GameObject = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseGameObject GameObject
        {
            get { return m_GameObject; }
        }
        #endregion
    }

    /// <summary>
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatingNameEventArgs : BaseGameObjectEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatingNameEventArgs( string strName, BaseGameObject creature ) :
            base( creature )
        {
            m_NewName = strName;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_NewName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string NewName
        {
            get { return m_NewName; }
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
    /// BaseCreature的事件数据类
    /// </summary>
    public class UpdatedNameEventArgs : BaseGameObjectEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public UpdatedNameEventArgs( string strName, BaseGameObject creature ) :
            base( creature )
        {
            m_OldName = strName;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_OldName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string OldName
        {
            get { return m_OldName; }
        }
        #endregion
    }
    #endregion
}
#endregion