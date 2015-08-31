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
using DevExpress.Xpo;
#endregion

namespace Demo.Wow.Database.Ver1a
{
    /// <summary>
    /// 游戏的账号信息
    /// </summary>
    public class Account : XPObject
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public Account() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public Account( Session session ) : base( session ) { }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏账号的名称
        /// </summary>
        private string m_AccountName;
        #endregion
        /// <summary>
        /// 游戏账号的名称
        /// </summary>
        [Size( 64 )]
        [Indexed( Unique = true )]
        public string AccountName
        {
            get { return m_AccountName; }
            set { SetPropertyValue<string>( "AccountName", ref m_AccountName, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏账号的密码
        /// </summary>
        private string m_Password;
        #endregion
        /// <summary>
        /// 游戏账号的密码
        /// </summary>
        [Indexed]
        [Size( 32 )]
        public string Password
        {
            get { return m_Password; }
            set { SetPropertyValue<string>( "Password", ref m_Password, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏账号中的权限等级
        /// </summary>
        private byte m_GMLevel;
        #endregion
        /// <summary>
        /// 游戏账号中的权限等级
        /// </summary>
        public byte GMLevel
        {
            get { return m_GMLevel; }
            set { SetPropertyValue<byte>( "GMLevel", ref m_GMLevel, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏账号是否已登陆锁定不允许再次登陆或冻结
        /// </summary>
        private bool m_IsLocked;
        #endregion
        /// <summary>
        /// 游戏账号是否已登陆锁定不允许再次登陆或冻结
        /// </summary>
        public bool IsLocked
        {
            get { return m_IsLocked; }
            set { SetPropertyValue<bool>( "IsLocked", ref m_IsLocked, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏账号是否已封停
        /// </summary>
        private bool m_IsBanned;
        #endregion
        /// <summary>
        /// 游戏账号是否已封停
        /// </summary>
        public bool IsBanned
        {
            get { return m_IsBanned; }
            set { SetPropertyValue<bool>( "IsBanned", ref m_IsBanned, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏账号创建的日期
        /// </summary>
        private DateTime m_CreateDate;
        #endregion
        /// <summary>
        /// 游戏账号创建的日期
        /// </summary>
        public DateTime CreateDate
        {
            get { return m_CreateDate; }
            set { SetPropertyValue<DateTime>( "CreateDate", ref m_CreateDate, value ); }
        }

        /// <summary>
        /// 游戏账号创建者的电子邮件
        /// </summary>
        [Delayed]
        [Size( 50 )]
        [NullValue( "" )]
        public string Email
        {
            get { return GetDelayedPropertyValue<string>( "Email" ); }
            set { SetDelayedPropertyValue<string>( "Email", value ); }
        }

        /// <summary>
        /// 游戏账号创建者的电子邮件是否已激活
        /// </summary>
        [Delayed]
        [NullValue( false )]
        public bool ActiveEmail
        {
            get { return GetDelayedPropertyValue<bool>( "ActiveEmail" ); }
            set { SetDelayedPropertyValue<bool>( "ActiveEmail", value ); }
        }

        /// <summary>
        /// 用于游戏账号创建者的电子邮件激活检验的(KEY)
        /// </summary>
        [Size( 32 )]
        [NullValue( "" )]
        [Delayed]
        public string ActiveEmailKey
        {
            get { return GetDelayedPropertyValue<string>( "ActiveEmailKey" ); }
            set { SetPropertyValue<string>( "ActiveEmailKey", value ); }
        }

        /// <summary>
        /// 游戏账号检验的正式(CD-KEY)
        /// </summary>
        [Delayed]
        [Size( 32 )]
        [NullValue( "" )]
        public string SessionKey
        {
            get { return GetDelayedPropertyValue<string>( "SessionKey" ); }
            set { SetDelayedPropertyValue<string>( "SessionKey", value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏账号登陆失败的次数
        /// </summary>
        private int m_FailedLogins;
        #endregion
        /// <summary>
        /// 游戏账号登陆失败的次数
        /// </summary>
        [NullValue( 0 )]
        public int FailedLogins
        {
            get { return m_FailedLogins; }
            set { SetPropertyValue<int>( "FailedLogins", ref m_FailedLogins, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏者最后登陆的(IP)地址(IPv4/IPv6)
        /// </summary>
        private string m_LastIP;
        #endregion
        /// <summary>
        /// 游戏者最后登陆的(IP)地址(IPv4/IPv6)
        /// </summary>
        [Size( 24 )]
        [NullValue( "" )]
        public string LastIP
        {
            get { return m_LastIP; }
            set { SetPropertyValue<string>( "LastIP", ref m_LastIP, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏者最后登陆的时间
        /// </summary>
        private DateTime m_LastLoginDate;
        #endregion
        /// <summary>
        /// 游戏者最后登陆的时间
        /// </summary>
        [NullValue( null )]
        public DateTime LastLoginDate
        {
            get { return m_LastLoginDate; }
            set { SetPropertyValue<DateTime>( "LastLoginDate", ref m_LastLoginDate, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏最后登陆的游戏服务所在的区
        /// </summary>
        private long m_LastServerGuid;
        #endregion
        /// <summary>
        /// 游戏最后登陆的游戏服务所在的区
        /// </summary>
        [NullValue( 0 )]
        public long LastServerGuid
        {
            get { return m_LastServerGuid; }
            set { SetPropertyValue<long>( "LastServerGuid", ref m_LastServerGuid, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏最后使用的游戏人物
        /// </summary>
        private CharacterBase m_LastCharacter;
        #endregion
        /// <summary>
        /// 游戏最后使用的游戏人物
        /// </summary>
        [NullValue( null )]
        public CharacterBase LastCharacter
        {
            get { return m_LastCharacter; }
            set { SetPropertyValue<CharacterBase>( "LastCharacter", ref m_LastCharacter, value ); }
        }

        /// <summary>
        /// 全部的游戏人物
        /// </summary>
        [Association( "Account-CharacterBase" )]
        public XPCollection<CharacterBase> Characters
        {
            get { return GetCollection<CharacterBase>( "Characters" ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否是资料片(TBC)的拥有者
        /// </summary>
        private bool m_IsTBC;
        #endregion
        /// <summary>
        /// 是否是资料片(TBC)的拥有者
        /// </summary>
        public bool IsTBC
        {
            get { return m_IsTBC; }
            set { SetPropertyValue<bool>( "IsTBC", ref m_IsTBC, value ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否是资料片(WLK)的拥有者
        /// </summary>
        private bool m_IsWLK;
        #endregion
        /// <summary>
        /// 是否是资料片(WLK)的拥有者
        /// </summary>
        public bool IsWLK
        {
            get { return m_IsWLK; }
            set { SetPropertyValue<bool>( "IsWLK", ref m_IsWLK, value ); }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 初始化
        /// </summary>
        public override void AfterConstruction()
        {
            // 防止违反索引唯一的规者
            AccountName = Guid.NewGuid().ToString();

            Password = string.Empty;
            GMLevel = 100;
            IsLocked = false;
            IsBanned = false;
            CreateDate = DateTime.Now;
            Email = "null@null.com";
            ActiveEmail = false;
            ActiveEmailKey = string.Empty;
            SessionKey = string.Empty;
            FailedLogins = 0;
            LastIP = "127.0.0.1";
            LastLoginDate = DateTime.Now;
            LastServerGuid = 0;
            LastCharacter = null;
            IsTBC = true;   // 默认支持资料片
            IsWLK = true;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion