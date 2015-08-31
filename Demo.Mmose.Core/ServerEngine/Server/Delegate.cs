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

namespace Demo.Mmose.Core.Server
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    ///  命令行的事件数据类
    /// </summary>
    public class CommandLineDisposalEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseServer"></param>
        public CommandLineDisposalEventArgs( string strCommandLine )
        {
            m_strCommandLine = strCommandLine;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strCommandLine = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string CommandLine
        {
            get { return m_strCommandLine; }
        }
        #endregion
    }
    #endregion

    #region zh-CHS 共有委托 | en Public Delegate
    /// <summary>
    /// BaseServer初始化的委托
    /// </summary>
    /// <param name="newNetState"></param>
    public delegate void InitOnceServerEventHandler();
    /// <summary>
    /// BaseServer退出的委托
    /// </summary>
    /// <param name="newNetState"></param>
    public delegate void ExitServerEventHandler();
    /// <summary>
    /// BaseServer命令行处理的委托
    /// </summary>
    /// <param name="newNetState"></param>
    public delegate bool CommandLineDisposalEventHandler( string strCommandLine );
    /// <summary>
    /// BaseServer给出命令行详细信息的委托
    /// </summary>
    /// <param name="newNetState"></param>
    public delegate void CommandLineInfoEventHandler();
    /// <summary>
    /// BaseServer配置的委托
    /// </summary>
    public delegate void ConfigServerEventHandler( ref ConfigServer configServer );
    #endregion
}
#endregion

