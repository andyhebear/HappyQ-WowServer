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
using System.Diagnostics;
#endregion

namespace Demo.Mmose.Core.World
{
    /// <summary>
    /// 
    /// </summary>
    public struct ExecuteInfoNull
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static ExecuteInfoNull NULL = new ExecuteInfoNull();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WaitExecuteInfo<T> : IWaitExecuteInfo
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="waitCallBack"></param>
        public WaitExecuteInfo( T executeInfo, WaitCallBack<T> waitCallBack )
        {
            if ( waitCallBack == null )
                throw new Exception( "WaitExecuteInfo.WaitExecuteInfo(...) - waitCallBack == null error!" );

            m_ExecuteInfo = executeInfo;
            m_WaitCallBack = waitCallBack;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_ExecuteInfo;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T Data
        {
            get { return m_ExecuteInfo; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WaitCallBack<T> m_WaitCallBack;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WaitCallBack<T> WaitCallBack
        {
            get { return m_WaitCallBack; }
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            if ( m_WaitCallBack == null )
                throw new Exception( "WaitExecuteInfo.Execute(...) - m_WaitCallBack == null error!" );

            m_WaitCallBack( m_ExecuteInfo );
        }
        #endregion
    }
}
#endregion