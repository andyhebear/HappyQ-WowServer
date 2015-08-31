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

#endregion

namespace Demo.Mmose.Core.AIEngine.Trigger
{
    #region zh-CHS 委托 | en Delegate
    /// <summary>
    /// BaseAuraManager的事件数据类
    /// </summary>
    public class AuraHandlerEventArgs<T> : EventArgs where T : TriggerAgent
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public AuraHandlerEventArgs( TriggerAgent auraHandler )
        {
            m_AuraHandler = auraHandler;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// Aura的数据
        /// </summary>
        private TriggerAgent m_AuraHandler = null;
        #endregion
        /// <summary>
        /// Aura实例
        /// </summary>
        public TriggerAgent AuraHandler
        {
            get { return m_AuraHandler; }
        }
        #endregion
    }

    #endregion
}
#endregion
