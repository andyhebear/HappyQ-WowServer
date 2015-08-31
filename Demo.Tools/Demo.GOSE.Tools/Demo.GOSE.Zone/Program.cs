#region zh-CHS 版权所有 (C) 2006 - 2007 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2007 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2007 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using Demo.GOSE.ServerEngine.World;
using Demo.GOSE.ServerEngine.Server;
using Demo.GOSE.ServerEngine.Network;
using Demo.GOSE.ServerEngine.Common;
using Demo.GOSE.ServerEngine.BuildScripts;
using Demo.GOSE.ServerEngine.World.ZoneWorld;
using Demo.WOW.Zone.Common;
using Demo.WOW.Zone.Server;
using Demo.WOW.Zone.Network;
#endregion

namespace Demo.WOW.Zone
{
    /// <summary>
    /// 应用程序
    /// </summary>
    class Program
    {
        #region zh-CHS 内部保护静态成员变量 | en Protected Internal Static Member Variables

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Listener s_ZoneListener = new Listener();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static Listener ZoneListener
        {
            get { return s_ZoneListener; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static MessagePump s_ZoneMessagePump = new MessagePump();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static MessagePump ZoneMessagePump
        {
            get { return s_ZoneMessagePump; }
        }

        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// <param name="args"></param>
        static void Main( string[] strArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 初始化一些工作

            BaseServer.EventConfigServer += new ConfigServerEventHandler( ProcessServer.ConfigServer );
            BaseServer.EventInitOnceServer += new InitOnceServerEventHandler( ProcessServer.InitOnceServer );
            BaseServer.EventExitServer += new ExitServerEventHandler( ProcessServer.ExitServer );

            BaseServer.EventCommandLineInfo += new CommandLineInfoEventHandler( ProcessServer.CommandLineInfo );
            BaseServer.EventCommandLineDisposal += new CommandLineDisposalEventHandler( ProcessServer.CommandLineDisposal );

            Program.ZoneMessagePump.ThreadEventNetStateCreate += new EventHandler<NetStateInitEventArgs>( ProcessNet.Zone_InitializeNetState );
            Program.ZoneMessagePump.ThreadEventProcessReceive += new EventHandler<NetStateEventArgs>( ProcessNet.Zone_ProcessReceive );
            Program.ZoneMessagePump.AddListener( Program.ZoneListener );

            ProcessServer.WoWWorld.AddMessagePump( Program.ZoneMessagePump );

            //////////////////////////////////////////////////////////////////////////
            // 开始运行服务

            BaseServer.RunServer( strArgs, ProcessServer.WoWWorld );
        }
    }
}
#endregion