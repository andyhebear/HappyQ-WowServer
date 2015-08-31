#region zh-CHS ��Ȩ���� (C) 2006 - 2006 DemoSoft Corporation. ��������Ȩ�� | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

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

#region zh-CHS �������ֿռ� | en Include namespace
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
    /// �������ݿ�
    /// </summary>
    public class OneDatabase
    {
        #region zh-CHS ��̬���� | en Static Properties
        #region zh-CHS ��Ա���� | en Member Variables
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

        #region zh-CHS ��Ա���� | en Member Variables
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

        #region zh-CHS ��̬���� | en Static Method
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool BuildDefault()
        {
            try
            {
                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: ��ʼ��������SQL..." );

                s_UnitOfWork.Connection = new SqlConnection( s_ConnectionUrl );
                s_UnitOfWork.AutoCreateOption = AutoCreateOption.SchemaOnly;

                s_UnitOfWork.Connect();
            }
            catch ( Exception exception )
            {
                LOGs.WriteLine( LogMessageType.MSG_FATALERROR, "SQL: �޷�����SQL���� {0}", exception );
                return false;
            }

            LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: �������SQL" );

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
                LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: ��ʼ����SQL..." );

                s_UnitOfWork.Connection = new SqlConnection( s_ConnectionUrl );
                s_UnitOfWork.AutoCreateOption = AutoCreateOption.SchemaOnly;

                s_UnitOfWork.Connect();

                LOGs.WriteLine( LogMessageType.MSG_INFO, "SQL: ���� {0}", s_ConnectionUrl );
            }
            catch ( Exception exception )
            {
                LOGs.WriteLine( LogMessageType.MSG_FATALERROR, "SQL: �޷�����SQL {0}", exception );
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

            LOGs.WriteLine( LogMessageType.MSG_SQL, "SQL: ��ɹ���SQL" );

            return true;
        }
        #endregion
    }
}
#endregion