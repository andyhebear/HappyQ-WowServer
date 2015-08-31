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
using System.Linq;
using System.Text;
#endregion

namespace Demo.Mmose.Core.Common.Component
{
    /// <summary>
    /// 
    /// </summary>
    public class ComponentEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public ComponentEventArgs( IComponent component )
        {
            m_Component = component;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private IComponent m_Component = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public IComponent Component
        {
            get { return m_Component; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ComponentMessageEventArgs : ComponentEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public ComponentMessageEventArgs( IComponent component, ComponentMessage componentMessage )
            : base( component )
        {
            m_ComponentMessage = componentMessage;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ComponentMessage m_ComponentMessage = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ComponentMessage ComponentMessage
        {
            get { return m_ComponentMessage; }
        }

        #endregion
    }
}
#endregion