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
using System.Data.SqlClient;
using System.Linq;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Collections;
using Demo.Mmose.Core.Timer;
using Demo.Mmose.Core.World;
using Demo.Wow.Database;
using Demo.Wow.Database.Ver1a;
using Demo.Wow.RealmServer.Server;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
#endregion

namespace Demo.Wow.RealmServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    internal static class WowAccountHandler
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static TimeSpan s_RefreshAccountTimeSpan = TimeSpan.FromMinutes( 10.0 );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static TimeSpan AccountRefresh
        {
            get { return s_RefreshAccountTimeSpan; }
            set { s_RefreshAccountTimeSpan = value; }
        }

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
        #endregion

        #region zh-CHS 私有静态方法 | en Private Static Methods
        /// <summary>
        /// 
        /// </summary>
        internal static void ReloadAccount()
        {
            WaitExecuteInfo<ExecuteInfoNull> waitExecuteInfo = new WaitExecuteInfo<ExecuteInfoNull>( ExecuteInfoNull.NULL, WowAccountHandler.SQL_ReloadAccount );

            ProcessServer.WowZoneCluster.World.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strAccountName"></param>
        /// <param name="strLastIP"></param>
        internal static void UpdateAccountLastIP( string strAccountName, string strLastIP )
        {
            UpdateAccountLastIPSQL updateAccountLastIPSQL = new UpdateAccountLastIPSQL( strAccountName, strLastIP );
            WaitExecuteInfo<UpdateAccountLastIPSQL> waitExecuteInfo = new WaitExecuteInfo<UpdateAccountLastIPSQL>( updateAccountLastIPSQL, WowAccountHandler.SQL_UpdateAccountLastIP );

            ProcessServer.WowZoneCluster.World.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods

        /// <summary>
        /// 
        /// </summary>
        public static void StartLoadAccountTimeSlice()
        {
            s_UnitOfWork.Connection = new SqlConnection( OneDatabase.ConnectionURL );
            s_UnitOfWork.AutoCreateOption = AutoCreateOption.SchemaOnly;

            ReloadAccount();

            TimeSlice.StartTimeSlice( TimerPriority.Lowest, s_RefreshAccountTimeSpan, s_RefreshAccountTimeSpan, new TimeSliceCallback( WowAccountHandler.ReloadAccount ) );
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static SafeDictionary<string, WowAccount> s_WowAccountManager = new SafeDictionary<string, WowAccount>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strAccountName"></param>
        /// <returns></returns>
        public static WowAccount GetAccount( string strAccountName )
        {
            return s_WowAccountManager.GetValue( strAccountName );
        }

        #endregion

        #region zh-CHS SQL静态方法 | en SQL Static Methods

        /// <summary>
        /// 
        /// </summary>
        private static void SQL_ReloadAccount( ExecuteInfoNull sqlInfo )
        {
            s_UnitOfWork.ReloadChangedObjects();

            XPQuery<Account> accounts = new XPQuery<Account>( s_UnitOfWork );

            var accountList = from account in accounts
                              select account;

            // 账号是不会删除的，人物会删除，所以只需要添加即可。
            foreach ( Account account in accountList )
            {
                WowAccount wowAccount = new WowAccount();
                wowAccount.AccountGuid = account.Oid;
                wowAccount.AccountName = account.AccountName.ToUpper();
                wowAccount.Password = account.Password;
                wowAccount.Locked = account.IsLocked;
                wowAccount.Banned = account.IsBanned;

                wowAccount.AccessLevel = (AccessLevel)account.GMLevel;
                wowAccount.IsTBC = account.IsTBC;

                s_WowAccountManager.Add( wowAccount.AccountName, wowAccount );
            }
            
            LOGs.WriteLine( LogMessageType.MSG_INFO, "Wow帐号：读取数据库内的 Wow 帐号完成" );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SQL_UpdateAccountLastIP( UpdateAccountLastIPSQL sqlInfo )
        {
            XPQuery<Account> accounts = new XPQuery<Account>( OneDatabase.Session );

            var accountList = from account in accounts
                              where account.AccountName == sqlInfo.AccountsName
                              select account;

            // 可能数据已添加，但没有刷新。
            if ( accountList.Count() == 0 )
            {
                s_UnitOfWork.ReloadChangedObjects();

                accounts = new XPQuery<Account>( OneDatabase.Session );

                accountList = from account in accounts
                              where account.AccountName == sqlInfo.AccountsName
                              select account;
            }

            foreach ( Account account in accountList )
            {
                account.LastIP = sqlInfo.LastIP;
                account.Save();

                OneDatabase.Session.CommitChanges();

                break;
            }
        }
        #endregion
    }
}
#endregion