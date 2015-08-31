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
using System.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Collections.Generic;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common;
using Demo.Wow.Database.Ver1a;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
#endregion

namespace Demo.Wow.Database
{
    /// <summary>
    /// 建造数据库
    /// </summary>
    public class OneDatabase
    {
        #region zh-CHS 静态属性 | en Static Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static UnitOfWork s_UnitOfWork = new UnitOfWork();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static UnitOfWork Session
        {
            get { return s_UnitOfWork; }
            set { s_UnitOfWork = value; }
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
            get { return s_ConnectionUrl; }
            set { s_ConnectionUrl = value; }
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
                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 开始建构连接SQL..." );

                s_UnitOfWork.Connection = new SqlConnection( s_ConnectionUrl );
                s_UnitOfWork.AutoCreateOption = AutoCreateOption.SchemaOnly;

                s_UnitOfWork.Connect();
            }
            catch ( Exception exception )
            {
                LOGs.WriteLine( LogMessageType.MSG_FATALERROR, "SQL: 无法建构SQL领域 {0}", exception );
                return false;
            }

            LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 完成连接SQL" );

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
                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 开始连接SQL..." );

                s_UnitOfWork.Connection = new SqlConnection( s_ConnectionUrl );
                s_UnitOfWork.AutoCreateOption = AutoCreateOption.SchemaOnly;

                s_UnitOfWork.Connect();

                LOGs.WriteLine( LogMessageType.MSG_INFO, "SQL: 连接 {0}", s_ConnectionUrl );
            }
            catch ( Exception exception )
            {
                LOGs.WriteLine( LogMessageType.MSG_FATALERROR, "SQL: 无法连接SQL {0}", exception );
                return false;
            }

            const string AccountNameGM = "DemoSoft";
            const string AccountPasswordGM = "123456";
            const string AccountNameTest = "wowwow1978";
            const string AccountPasswordTest = "TrueHacke0";

            XPQuery<Account> accounts = new XPQuery<Account>( s_UnitOfWork );

            var accountList = from account in accounts
                              where account.AccountName == AccountNameGM || account.AccountName == AccountNameTest
                              select account;

            foreach ( Account account in accountList )
                account.Delete();

            s_UnitOfWork.CommitChanges();
            s_UnitOfWork.PurgeDeletedObjects();

            Account accountsGM = new Account( s_UnitOfWork );
            accountsGM.AccountName = AccountNameGM;
            accountsGM.Password = AccountPasswordGM;
            accountsGM.GMLevel = 1; // GM
            accountsGM.IsLocked = false;
            accountsGM.IsBanned = true;
            accountsGM.CreateDate = DateTime.Now;
            accountsGM.Save();

            Account accountsTest = new Account( s_UnitOfWork );
            accountsTest.AccountName = AccountNameTest;
            accountsTest.Password = AccountPasswordTest;
            accountsTest.GMLevel = 100; // Player
            accountsTest.IsLocked = false;
            accountsTest.IsBanned = false;
            accountsTest.CreateDate = DateTime.Now;
            accountsTest.Save();

            s_UnitOfWork.CommitChanges();

            LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: 完成构建SQL" );

            return true;
        }
        #endregion
    }
}
#endregion