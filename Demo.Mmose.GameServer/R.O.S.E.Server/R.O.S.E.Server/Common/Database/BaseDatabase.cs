#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2006 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Text;
using Demo_G.O.S.E.Data;
using System.Globalization;
using System.Collections.Generic;
using Demo_G.O.S.E.ServerEngine.Util;
using Demo_R.O.S.E.Database.Model;
using Demo_G.O.S.E.ServerEngine.Common;
#endregion

namespace Demo_R.O.S.E.Database
{
    /// <summary>
    /// 建造数据库
    /// </summary>
    public class BaseDatabase
    {
        #region zh-CHS 静态属性 | en Static Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Domain s_Domain = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static Domain Domain
        {
            get { return BaseDatabase.s_Domain; }
            set { BaseDatabase.s_Domain = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static string s_ConnectionUrl = "mssql://localhost/DemoSoft";
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static string ConnectionURL
        {
            get { return BaseDatabase.s_ConnectionUrl; }
            set { BaseDatabase.s_ConnectionUrl = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static string s_RegisterTypes = "Demo_R.O.S.E.Database.Model";
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static string RegisterNameSpace
        {
            get { return BaseDatabase.s_RegisterTypes; }
            set { BaseDatabase.s_RegisterTypes = value; }
        }
        #endregion

        #region zh-CHS 静态方法 | en Static Method
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool BuildDefault()
        {
            try
            {
                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 开始建构SQL领域..." );
                s_Domain = new Domain( s_ConnectionUrl, "" );

                //LOGs.WriteLine( LogMessageType.MSG_INFO, "SQL: 连接 {0}", s_Domain.ConnectionUrl );
                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 信息 {0}", s_Domain.Driver.Info.Description );

                s_Domain.RegisterCulture( new Culture( "US", "U.S. English", new CultureInfo( "en-US", false ) ) );
                s_Domain.RegisterCulture( new Culture( "CN", "China. Chinese", new CultureInfo( "zh-CN", false ) ) );
                s_Domain.RegisterCulture( new Culture( "TW", "Taiwan. Chinese", new CultureInfo( "zh-TW", false ) ) );
                s_Domain.Cultures["CN"].Default = true;

                s_Domain.RegisterTypes( s_RegisterTypes );

                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 注册 (NameSpace){0}", s_RegisterTypes );

                s_Domain.Build( DomainUpdateMode.Block );
            }
            catch ( Exception exception )
            {
                LOGs.WriteLine( LogMessageType.MSG_FATALERROR, "SQL: 无法建构SQL领域 {0}", exception );
                return false;
            }

            LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 完成建构SQL领域" );

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool BuildRecreate()
        {
            try
            {
                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 开始建构SQL领域..." );
                s_Domain = new Domain( s_ConnectionUrl, "" );

                //LOGs.WriteLine( LogMessageType.MSG_INFO, "SQL: 连接 {0}", s_Domain.ConnectionUrl );
                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 信息 {0}", s_Domain.Driver.Info.Description );

                s_Domain.RegisterCulture( new Culture( "US", "U.S. English", new CultureInfo( "en-US", false ) ) );
                s_Domain.RegisterCulture( new Culture( "CN", "China. Chinese", new CultureInfo( "zh-CN", false ) ) );
                s_Domain.RegisterCulture( new Culture( "TW", "Taiwan. Chinese", new CultureInfo( "zh-TW", false ) ) );
                s_Domain.Cultures["CN"].Default = true;

                s_Domain.RegisterTypes( s_RegisterTypes );

                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 注册 (NameSpace){0}", s_RegisterTypes );

                s_Domain.Build( DomainUpdateMode.Recreate );
            }
            catch ( Exception exception )
            {
                LOGs.WriteLine( LogMessageType.MSG_FATALERROR, "SQL: 无法建构SQL领域 {0}", exception );
                return false;
            }

            using ( Session session = new Session( s_Domain ) )
            {
                session.BeginTransaction();

                Accounts accountsGM = (Accounts)session.CreateObject( typeof( Accounts ) );
                accountsGM.AccountsGuid = accountsGM.ID;
                accountsGM.AccountsName = "DemoSoft";
                accountsGM.Password = "faf2ca38c02c5f2ba1c49d200a03f9fb";
                accountsGM.GMLevel = 300; // GM
                accountsGM.Locked = false;
                accountsGM.Banned = true;
                accountsGM.CreateDate = DateTime.Now;

                Accounts accountsTest = (Accounts)session.CreateObject( typeof( Accounts ) );
                accountsTest.AccountsGuid = accountsTest.ID;
                accountsTest.AccountsName = "Test";
                accountsTest.Password = "faf2ca38c02c5f2ba1c49d200a03f9fb";
                accountsTest.GMLevel = 100; // Player
                accountsTest.Locked = false;
                accountsTest.Banned = false;
                accountsTest.CreateDate = DateTime.Now;

                Channels channelsCharacter1 = (Channels)session.CreateObject( typeof( Channels ) );
                channelsCharacter1.ServerGuid = channelsCharacter1.ID;
                channelsCharacter1.ServerName = "Angel";
                //channelsCharacter1.Host = "218.3.85.107";
                channelsCharacter1.Host = "127.0.0.1";
                channelsCharacter1.Port = 29100;
                channelsCharacter1.Status = 0;
                channelsCharacter1.OwnerGuid = Channels.CHARACTER_SERVER_ID;
                channelsCharacter1.Connected = 0;
                channelsCharacter1.MaxConnected = 0;

                Channels channelsCharacter2 = (Channels)session.CreateObject( typeof( Channels ) );
                channelsCharacter2.ServerGuid = channelsCharacter2.ID;
                channelsCharacter2.ServerName = "Hell";
                //channelsCharacter2.Host = "218.3.85.107";
                channelsCharacter2.Host = "127.0.0.1";
                channelsCharacter2.Port = 29100;
                channelsCharacter2.Status = 0;
                channelsCharacter2.OwnerGuid = Channels.CHARACTER_SERVER_ID;
                channelsCharacter2.Connected = 0;
                channelsCharacter2.MaxConnected = 0;

                Channels channelsWorld1 = (Channels)session.CreateObject( typeof( Channels ) );
                channelsWorld1.ServerGuid = channelsWorld1.ID;
                channelsWorld1.ServerName = "Angel-1";
                //channelsWorld1.Host = "218.3.85.107";
                channelsWorld1.Host = "127.0.0.1";
                channelsWorld1.Port = 29200;
                channelsWorld1.Status = 0;
                channelsWorld1.OwnerGuid = channelsCharacter1.ServerGuid;
                channelsWorld1.Connected = 0;
                channelsWorld1.MaxConnected = 300;

                Channels channelsWorld2 = (Channels)session.CreateObject( typeof( Channels ) );
                channelsWorld2.ServerGuid = channelsWorld2.ID;
                channelsWorld2.ServerName = "Angel-2";
                //channelsWorld2.Host = "218.3.85.107";
                channelsWorld2.Host = "127.0.0.1";
                channelsWorld2.Port = 29200;
                channelsWorld2.Status = 0;
                channelsWorld2.OwnerGuid = channelsCharacter1.ServerGuid;
                channelsWorld2.Connected = 0;
                channelsWorld2.MaxConnected = 300;

                Channels channelsWorld3 = (Channels)session.CreateObject( typeof( Channels ) );
                channelsWorld3.ServerGuid = channelsWorld3.ID;
                channelsWorld3.ServerName = "Hell-1";
                //channelsWorld3.Host = "218.3.85.107";
                channelsWorld3.Host = "127.0.0.1";
                channelsWorld3.Port = 29200;
                channelsWorld3.Status = 0;
                channelsWorld3.OwnerGuid = channelsCharacter2.ServerGuid;
                channelsWorld3.Connected = 0;
                channelsWorld3.MaxConnected = 300;

                Channels channelsWorld4 = (Channels)session.CreateObject( typeof( Channels ) );
                channelsWorld4.ServerGuid = channelsWorld4.ID;
                channelsWorld4.ServerName = "Hell-2";
                //channelsWorld4.Host = "218.3.85.107";
                channelsWorld4.Host = "127.0.0.1";
                channelsWorld4.Port = 29200;
                channelsWorld4.Status = 0;
                channelsWorld4.OwnerGuid = channelsCharacter2.ServerGuid;
                channelsWorld4.Connected = 0;
                channelsWorld4.MaxConnected = 300;

                session.Commit();
            }

            LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 完成建构SQL领域" );

            return true;
        }

        /// <summary>
        /// And this method can dump the result of a query
        /// </summary>
        /// <param name="queryResult"></param>
        internal static void Dump( QueryResult queryResult )
        {
            LOGs.WriteLine( LogMessageType.MSG_SQL, "QueryResult: 查询结果开始:" );

            foreach ( DataObject dataObject in queryResult )
            {
                IDumpable dumpable = dataObject as IDumpable;
                if ( dumpable != null )
                    dumpable.Dump( Console.Out );
                else
                    LOGs.WriteLine( LogMessageType.MSG_SQL, "{0}, ID = {1}", dataObject.GetType().BaseType.Name, dataObject.ID );
            }

            LOGs.WriteLine( LogMessageType.MSG_SQL, "QueryResult: 查询结果结束." );
        }
        #endregion
    }
}
#endregion