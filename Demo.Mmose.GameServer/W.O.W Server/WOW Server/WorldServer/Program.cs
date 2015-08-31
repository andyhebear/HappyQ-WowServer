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
using System.Linq;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Server;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.World;
using Demo.Wow.WorldServer.Network;
using Demo.Wow.WorldServer.Server;
using Demo.Wow.Database.Ver1a;
#endregion

namespace Demo.Wow.WorldServer
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    { 
        #region zh-CHS 内部静态属性 | en Internal Static Properties

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Connecter s_RealmServerConnecter = new Connecter();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static Connecter RealmServerConnecter
        {
            get { return s_RealmServerConnecter; }
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
        private static Listener s_WorldServerListener = new Listener();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static Listener WorldServerListener
        {
            get { return s_WorldServerListener; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static MessagePump s_WorldServerMessagePump = new MessagePump();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static MessagePump WorldServerMessagePump
        {
            get { return s_WorldServerMessagePump; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static bool s_IsOnlyBuildScript = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal static bool IsOnlyBuildScript
        {
            get { return s_IsOnlyBuildScript; }
        }

        #endregion

        #region zh-CHS 预编译脚本 方法 | en
        /// <summary>
        /// 重新建造SQL
        /// </summary>
        /// <param name="strArgs"></param>
        private static void InitServerArguments( string[] strArgs )
        {
            for ( int iIndex = 0; iIndex < strArgs.Length; ++iIndex )
            {
                if ( Insensitive.Equals( strArgs[iIndex], "-OnlyBuildScript" ) )
                {
                    s_IsOnlyBuildScript = true;
                    break;
                }
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strArgs"></param>
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

            Program.WorldServerMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( ProcessNet.WorldInitializeNetState );
            Program.WorldServerMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( ProcessNet.WorldProcessReceive );
            Program.WorldServerMessagePump.AddListener( Program.WorldServerListener );

            Program.RealmServerMessagePump.EventNetStateCreate += new EventHandler<NetStateInitEventArgs>( ProcessNet.RealmInitializeNetState );
            Program.RealmServerMessagePump.EventProcessReceive += new EventHandler<NetStateEventArgs>( ProcessNet.RealmProcessReceive );
            Program.RealmServerMessagePump.AddConnecter( Program.RealmServerConnecter );

            ProcessServer.WowZoneCluster.World.AddMessagePump( Program.WorldServerMessagePump );
            ProcessServer.WowZoneCluster.World.AddMessagePump( Program.RealmServerMessagePump );

            ProcessServer.WowZoneCluster.World.EventInitOnceWorld += new EventHandler<BaseWorldEventArgs>( ProcessServer.WowZoneCluster.World.InitOnceWorld );
            ProcessServer.WowZoneCluster.World.EventEndSlice += new EventHandler<BaseWorldEventArgs>( ProcessServer.WowZoneCluster.World.WorldSlice );

            //////////////////////////////////////////////////////////////////////////
            // 开始运行服务

            OneServer.RunServer( strArgs, ProcessServer.WowZoneCluster.World );
        }
    }
}
#endregion