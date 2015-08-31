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
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_W.O.W.Database;
using Demo_W.O.W.Database.Model_Ver1a;
#endregion

namespace Demo_W.O.W.DatabaseVer1a
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
        private static string s_ConnectionUrl = "mssql://localhost/WorldOfWarcraft";
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
        private static string s_RegisterTypes = "Demo_W.O.W.Database.Model_Ver1a";
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
                accountsGM.Password = "123456";
                accountsGM.GMLevel = 300; // GM
                accountsGM.Locked = false;
                accountsGM.Banned = true;
                accountsGM.CreateDate = DateTime.Now;

                Accounts accountsTest = (Accounts)session.CreateObject( typeof( Accounts ) );
                accountsTest.AccountsGuid = accountsTest.ID;
                accountsTest.AccountsName = "Test3009";
                accountsTest.Password = "e12345678";
                accountsTest.GMLevel = 100; // Player
                accountsTest.Locked = false;
                accountsTest.Banned = false;
                accountsTest.CreateDate = DateTime.Now;

                RealmList RealmList01 = (RealmList)session.CreateObject( typeof( RealmList ) );
                RealmList01.ServerGuid = RealmList01.ID;
                RealmList01.ServerName = "Angel";
                //channelsCharacter1.Host = "218.3.85.107";
                RealmList01.Host = "127.0.0.1";
                RealmList01.Port = 29100;
                RealmList01.Icon = 0;
                RealmList01.Color = 1;
                RealmList01.Timezone = 1;
                RealmList01.Population = 0;

                RealmList RealmList02 = (RealmList)session.CreateObject( typeof( RealmList ) );
                RealmList02.ServerGuid = RealmList02.ID;
                RealmList02.ServerName = "Hell";
                //channelsCharacter2.Host = "218.3.85.107";
                RealmList02.Host = "127.0.0.1";
                RealmList02.Port = 29100;
                RealmList02.Icon = 0;
                RealmList02.Color = 1;
                RealmList02.Timezone = 1;
                RealmList02.Population = 300;

                RealmList RealmList03 = (RealmList)session.CreateObject( typeof( RealmList ) );
                RealmList03.ServerGuid = RealmList03.ID;
                RealmList03.ServerName = "Angel-1";
                //channelsWorld1.Host = "218.3.85.107";
                RealmList03.Host = "127.0.0.1";
                RealmList03.Port = 29200;
                RealmList03.Icon = 0;
                RealmList03.Color = 1;
                RealmList03.Timezone = 1;
                RealmList03.Population = 300;

                RealmList RealmList04 = (RealmList)session.CreateObject( typeof( RealmList ) );
                RealmList04.ServerGuid = RealmList04.ID;
                RealmList04.ServerName = "Angel-2";
                //channelsWorld2.Host = "218.3.85.107";
                RealmList04.Host = "127.0.0.1";
                RealmList04.Port = 29200;
                RealmList04.Icon = 0;
                RealmList04.Color = 1;
                RealmList04.Timezone = 1;
                RealmList04.Population = 300;

                RealmList RealmList05 = (RealmList)session.CreateObject( typeof( RealmList ) );
                RealmList05.ServerGuid = RealmList05.ID;
                RealmList05.ServerName = "Hell-1";
                //channelsWorld3.Host = "218.3.85.107";
                RealmList05.Host = "127.0.0.1";
                RealmList05.Port = 29200;
                RealmList05.Icon = 0;
                RealmList05.Color = 1;
                RealmList05.Timezone = 1;
                RealmList05.Population = 300;

                RealmList RealmList06 = (RealmList)session.CreateObject( typeof( RealmList ) );
                RealmList06.ServerGuid = RealmList06.ID;
                RealmList06.ServerName = "Hell-2";
                //channelsWorld4.Host = "218.3.85.107";
                RealmList06.Host = "127.0.0.1";
                RealmList06.Port = 29200;
                RealmList06.Icon = 0;
                RealmList06.Color = 1;
                RealmList06.Timezone = 1;
                RealmList06.Population = 300;

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