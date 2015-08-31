#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
//
// This file is a part of the G.O.S.E(Game Online Server Engine) for .NET.
//
//           2007-2008 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions outlined
// in the accompanying license agreement.
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Server;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.World;
using Demo.Wow.RealmServer.Network;
using Demo.Wow.RealmServer.Server;
#endregion

namespace Demo.Wow.RealmServer
{
    /// <summary>
    /// 应用程序
    /// </summary>
    internal class Program
    {
        #region zh-CHS 内部保护静态成员变量 | en Protected Internal Static Member Variables

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Listener s_AuthServerListener = new Listener();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static Listener AuthServerListener
        {
            get { return s_AuthServerListener; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static MessagePump s_AuthServerMessagePump = new MessagePump();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static MessagePump AuthServerMessagePump
        {
            get { return s_AuthServerMessagePump; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Listener s_RealmServerListener = new Listener();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static Listener RealmServerListener
        {
            get { return s_RealmServerListener; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static MessagePump s_RealmServerMessagePump = new MessagePump();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static MessagePump RealmServerMessagePump
        {
            get { return s_RealmServerMessagePump; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static bool s_IsSQLRecreate = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static bool IsSQLRecreate
        {
            get { return s_IsSQLRecreate; }
        }

        #endregion

        #region zh-CHS 重新建造数据库(SQL) 方法 | en RecreateSQL Method
        /// <summary>
        /// 重新建造SQL
        /// </summary>
        /// <param name="strArgs"></param>
        private static void InitServerArguments( string[] strArgs )
        {
            for ( int iIndex = 0; iIndex < strArgs.Length; ++iIndex )
            {
                if ( Insensitive.Equals( strArgs[iIndex], "-SQLReCreate" ) )
                {
                    s_IsSQLRecreate = true;
                    break;
                }
            }
        }
        #endregion
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// <param name="args"></param>
        private static void Main( string[] strArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 初始化参数

            InitServerArguments( strArgs );

            //////////////////////////////////////////////////////////////////////////
            // 初始化一些工作

            OneServer.EventConfigServer += new ConfigServerEventHandler( ProcessServer.ConfigServer );
            OneServer.EventInitOnceServer += new InitOnceServerEventHandler( ProcessServer.InitOnceServer );
            OneServer.EventExitServer += new ExitServerEventHandler( ProcessServer.ExitServer );

            OneServer.EventCommandLineInfo += new CommandLineInfoEventHandler( ProcessServer.CommandLineInfo );
            OneServer.EventCommandLineDisposal += new CommandLineDisposalEventHandler( ProcessServer.CommandLineDisposal );

            Program.RealmServerMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( ProcessNet.RealmInitializeNetState );
            Program.RealmServerMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( ProcessNet.RealmProcessReceive );
            Program.RealmServerMessagePump.AddListener( Program.RealmServerListener );

            Program.AuthServerMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( ProcessNet.AuthInitializeNetState );
            Program.AuthServerMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( ProcessNet.AuthProcessReceive );
            Program.AuthServerMessagePump.AddListener( Program.AuthServerListener );

            ProcessServer.WowZoneCluster.World.AddMessagePump( Program.RealmServerMessagePump );
            ProcessServer.WowZoneCluster.World.AddMessagePump( Program.AuthServerMessagePump );

            ProcessServer.WowZoneCluster.World.EventInitOnceWorld += new EventHandler<BaseWorldEventArgs>( ProcessServer.WowZoneCluster.World.InitOnceWorld );
            ProcessServer.WowZoneCluster.World.EventEndSlice += new EventHandler<BaseWorldEventArgs>( ProcessServer.WowZoneCluster.World.WorldSlice );

            //////////////////////////////////////////////////////////////////////////
            // 开始运行服务

            OneServer.RunServer( strArgs, ProcessServer.WowZoneCluster.World );
        }
    }
}
#endregion