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
using System.Threading;
#endregion

namespace Demo.Mmose.Core.Common.Atom
{
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都是静态,支持多线程操作" )]
    public struct LockCheck
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private const int LOCK_FALSE = 0;
        /// <summary>
        /// 
        /// </summary>
        private const int LOCK_TRUE = 1;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_LockValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public LockCheck( bool isValid )
        {
            m_LockValue = isValid == true ? LOCK_TRUE : LOCK_FALSE;
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid() { return Interlocked.CompareExchange( ref m_LockValue, LOCK_TRUE, LOCK_TRUE ) == LOCK_TRUE; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SetValid() { return Interlocked.CompareExchange( ref m_LockValue, LOCK_TRUE, LOCK_FALSE ) == LOCK_FALSE; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SetInvalid() { return Interlocked.CompareExchange( ref m_LockValue, LOCK_FALSE, LOCK_TRUE ) == LOCK_TRUE; }
        #endregion
    }
}
#endregion
