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

namespace Demo.Mmose.Core.World
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// BaseWorld的事件数据类
    /// </summary>
    public class BaseWorldEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public BaseWorldEventArgs( BaseWorld baseWorld )
        {
            m_BaseWorld = baseWorld;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// BaseWorld的数据
        /// </summary>
        private BaseWorld m_BaseWorld = null;
        #endregion
        /// <summary>
        /// BaseWorld实例
        /// </summary>
        public BaseWorld BaseWorld
        {
            get { return m_BaseWorld; }
        }
        #endregion
    }

    /// <summary>
    /// BaseWorld的广播事件数据类
    /// </summary>
    public class BroadcastEventArgs : BaseWorldEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public BroadcastEventArgs( BaseWorld baseWorld, string strText, object state )
            : base( baseWorld )
        {
            m_strText = strText;
            m_State = state;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 广播的文本信息数据
        /// </summary>
        private string m_strText = string.Empty;
        #endregion
        /// <summary>
        /// 广播的文本信息
        /// </summary>
        public string Text
        {
            get { return m_strText; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 广播的上下文数据
        /// </summary>
        private object m_State = null;
        #endregion
        /// <summary>
        /// 广播的上下文
        /// </summary>
        public object State
        {
            get { return m_State; }
        }
        #endregion
    }
    #endregion

    #region zh-CHS 共有委托 | en Public Delegate
    /// <summary>
    /// 世界服务的时间片委托
    /// </summary>
    public delegate void SliceEventHandler( BaseWorldEventArgs eventArgs );
    /// <summary>
    /// 世界服务的广播委托
    /// </summary>
    public delegate void BroadcastEventHandler( BroadcastEventArgs eventArgs );
    /// <summary>
    /// 世界服务的初始化委托
    /// </summary>
    /// <param name="newNetState"></param>
    public delegate void InitOnceWorldEventHandler( BaseWorldEventArgs eventArgs );
    /// <summary>
    /// 世界服务的退出委托
    /// </summary>
    /// <param name="newNetState"></param>
    public delegate void ExitWorldEventHandler( BaseWorldEventArgs eventArgs );
    /// <summary>
    /// 世界服务的读取委托
    /// </summary>
    /// <param name="newNetState"></param>
    public delegate void LoadWorldEventHandler( BaseWorldEventArgs eventArgs );
    /// <summary>
    /// 世界服务的保存委托
    /// </summary>
    /// <param name="newNetState"></param>
    public delegate void SaveWorldEventHandler( BaseWorldEventArgs eventArgs );
    #endregion
}
#endregion