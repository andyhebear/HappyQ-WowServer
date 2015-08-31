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
using System.Threading;
#endregion

namespace Demo.Mmose.Core.Common.Atom
{
    /// <summary>
    /// 
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都是静态,支持多线程操作" )]
    public struct LockInOut
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private const int TRUE = 1;
        /// <summary>
        /// 
        /// </summary>
        private const int FALSE = 0;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 表示当前已加入在处理列表中 0 == FALSE 1 == TRUE 
        /// </summary>
        private int m_IsLock;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLock"></param>
        public LockInOut( bool isLock )
        {
            m_IsLock = isLock == true ? TRUE : FALSE;
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool InLock()
        {
            return Interlocked.CompareExchange( ref m_IsLock, TRUE, FALSE ) == FALSE;
        }

        /// <summary>
        /// 
        /// </summary>
        public void OutLock()
        {
            Interlocked.CompareExchange( ref m_IsLock, FALSE, TRUE );
        }
        #endregion
    }
}
#endregion