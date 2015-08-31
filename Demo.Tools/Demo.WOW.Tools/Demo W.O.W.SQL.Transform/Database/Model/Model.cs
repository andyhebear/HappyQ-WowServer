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
using System.IO;
using System.Text;
using System.Globalization;
using Demo_G.O.S.E.Data;
using Demo_G.O.S.E.Data.FullText;
using System.Collections.Generic;
using Demo_G.O.S.E.Data.Attributes;
using Demo_G.O.S.E.ServerEngine.Util;
#endregion

namespace Demo_W.O.W.Database.Model_Ver1a
{
    /// <summary>
    /// 游戏的账号信息
    /// </summary>
    public abstract class Accounts : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏账号的唯一序号
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long AccountsGuid { get; set; }

        /// <summary>
        /// 游戏账号的名称
        /// </summary>
        [Indexed( Unique = true )]
        [Length(64)]
        public abstract string AccountsName { get; set; }

        /// <summary>
        /// 游戏账号的密码
        /// </summary>
        [Indexed]
        [Length( 32 )]
        public abstract string Password { get; set; }

        /// <summary>
        /// 游戏账号中的权限等级
        /// </summary>
        public abstract int GMLevel { get; set; }

        /// <summary>
        /// 游戏账号是否已登陆锁定不允许再次登陆或冻结
        /// </summary>
        public abstract bool Locked { get; set; }

        /// <summary>
        /// 游戏账号是否已封停
        /// </summary>
        public abstract bool Banned { get; set; }

        /// <summary>
        /// 游戏账号创建的日期
        /// </summary>
        public abstract DateTime CreateDate { get; set; }

        /// <summary>
        /// 游戏账号创建者的电子邮件
        /// </summary>
        [Length(50)]
        [Nullable]
        [LoadOnDemand]
        public abstract string Email { get; set; }

        /// <summary>
        /// 游戏账号创建者的电子邮件是否已激活
        /// </summary>
        [Nullable]
        [LoadOnDemand]
        public abstract bool ActiveEmail { get; set; }

        /// <summary>
        /// 用于游戏账号创建者的电子邮件激活检验的(KEY)
        /// </summary>
        [Length(32)]
        [Nullable]
        [LoadOnDemand]
        public abstract string ActiveEmailKey { get; set; }

        /// <summary>
        /// 游戏账号检验的正式(CD-KEY)
        /// </summary>
        [Length(32)]
        [Nullable]
        [LoadOnDemand]
        public abstract string SessionKey { get; set; }

        /// <summary>
        /// 游戏推荐人的标示(ID)
        /// </summary>
        [Nullable]
        [LoadOnDemand]
        public abstract int DonationGuid { get; set; }

        /// <summary>
        /// 游戏推荐人的帐号名称
        /// </summary>
        [Length(64)]
        [Nullable]
        [LoadOnDemand]
        public abstract string Donation { get; set; }

        /// <summary>
        /// 游戏账号登陆失败的次数
        /// </summary>
        [Nullable]
        public abstract int FailedLogins { get; set; }

        /// <summary>
        /// 游戏者最后登陆的(IP)地址(IPv4/IPv6)
        /// </summary>
        [Length(24)]
        [Nullable]
        public abstract string LastIP { get; set; }

        /// <summary>
        /// 游戏者最后登陆的时间
        /// </summary>
        [Nullable]
        public abstract DateTime LastLoginDate { get; set; }

        /// <summary>
        /// 游戏最后登陆的游戏服务所在的区
        /// </summary>
        [Nullable]
        public abstract long LastServerGuid { get; set; }

        /// <summary>
        /// 游戏最后使用的游戏人物
        /// </summary>
        [Length(64)]
        [Nullable]
        public abstract string LastCharacter { get; set; }

        /// <summary>
        /// 是否是资料片(TBC)的拥有者
        /// </summary>
        [Nullable]
        public abstract bool IsTBC { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            AccountsGuid = Guid.NewGuid().GetHashCode();
            AccountsName = Guid.NewGuid().ToString();
            
            Password = string.Empty;
            GMLevel = 100;
            Locked = false;
            Banned = false;
            CreateDate = DateTime.Now;
            Email = "null@null.com";
            ActiveEmail = false;
            ActiveEmailKey = string.Empty;
            SessionKey = string.Empty;
            DonationGuid = 0;
            Donation = string.Empty;
            FailedLogins = 0;
            LastIP = "127.0.0.1";
            LastLoginDate = DateTime.Now;
            LastServerGuid = 0;
            LastCharacter = string.Empty;
            IsTBC = true; // 支持资料片

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  AccountsGuid:      {0}", GetProperty( "AccountsGuid" ) == null ? "null" : AccountsGuid.ToString() );
            output.WriteLine( "  AccountsName:      {0}", GetProperty( "AccountsName" ) == null ? "null" : AccountsName.ToString() );
            output.WriteLine( "  Password:          {0}", GetProperty( "Password" ) == null ? "null" : Password.ToString() );
            output.WriteLine( "  GMLevel:           {0}", GetProperty( "GMLevel" ) == null ? "null" : GMLevel.ToString() );
            output.WriteLine( "  Locked:            {0}", GetProperty( "Locked" ) == null ? "null" : Locked.ToString() );
            output.WriteLine( "  Banned:            {0}", GetProperty( "Banned" ) == null ? "null" : Banned.ToString() );
            output.WriteLine( "  CreateDate:        {0}", GetProperty( "CreateDate" ) == null ? "null" : CreateDate.ToString() );
            output.WriteLine( "  Email:             {0}", GetProperty( "Email" ) == null ? "null" : Email.ToString() );
            output.WriteLine( "  ActiveEmail:       {0}", GetProperty( "ActiveEmail" ) == null ? "null" : ActiveEmail.ToString() );
            output.WriteLine( "  ActiveEmailKey:    {0}", GetProperty( "ActiveEmailKey" ) == null ? "null" : ActiveEmailKey.ToString() );
            output.WriteLine( "  SessionKey:        {0}", GetProperty( "SessionKey" ) == null ? "null" : SessionKey.ToString() );
            output.WriteLine( "  DonationGuid:      {0}", GetProperty( "DonationGuid" ) == null ? "null" : DonationGuid.ToString() );
            output.WriteLine( "  Donation:          {0}", GetProperty( "Donation" ) == null ? "null" : Donation.ToString() );
            output.WriteLine( "  FailedLogins:      {0}", GetProperty( "FailedLogins" ) == null ? "null" : FailedLogins.ToString() );
            output.WriteLine( "  LastIP:            {0}", GetProperty( "LastIP" ) == null ? "null" : LastIP.ToString() );
            output.WriteLine( "  LastLoginDate:     {0}", GetProperty( "LastLoginDate" ) == null ? "null" : LastLoginDate.ToString() );
            output.WriteLine( "  LastServerGuid:    {0}", GetProperty( "LastServerGuid" ) == null ? "null" : LastServerGuid.ToString() );
            output.WriteLine( "  LastCharacter:     {0}", GetProperty( "LastCharacter" ) == null ? "null" : LastCharacter.ToString() );
            output.WriteLine( "  IsTBC:             {0}", GetProperty( "IsTBC" ) == null ? "null" : IsTBC.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 需要禁掉的(IP)地址
    /// </summary>
    public abstract class IPBanned : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 需要过滤的(IP)地址(IPv4/IPv6)
        /// </summary>
        [Length(24)]
        public abstract string IPAddress { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            IPAddress = string.Empty;

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  IPAddress:         {0}", GetProperty( "IPAddress" ) == null ? "null" : IPAddress.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 某帐号在某服务器内创建的人物数
    /// </summary>
    public abstract class RealmCharacters : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 服务器唯一序号
        /// </summary>
        public abstract long RealmGuid { get; set; }

        /// <summary>
        /// 服务器的名称
        /// </summary>
        [Length( 64 )]
        public abstract string RealmName { get; set; }

        /// <summary>
        /// 游戏账号的唯一序号
        /// </summary>
        public abstract long AccountsGuid { get; set; }

        /// <summary>
        /// 服务器内创建的人物数
        /// </summary>
        public abstract byte NumberCharacters { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            RealmGuid = 0;
            RealmName = string.Empty;
            AccountsGuid = 0;
            NumberCharacters = 0;

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  RealmGuid:         {0}", GetProperty( "RealmGuid" ) == null ? "null" : RealmGuid.ToString() );
            output.WriteLine( "  RealmName:         {0}", GetProperty( "RealmName" ) == null ? "null" : RealmName.ToString() );
            output.WriteLine( "  AccountsGuid:      {0}", GetProperty( "AccountsGuid" ) == null ? "null" : AccountsGuid.ToString() );
            output.WriteLine( "  NumberCharacters:  {0}", GetProperty( "NumberCharacters" ) == null ? "null" : NumberCharacters.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 定义服务器的频道列表(游戏服务器或人物服务器)的内容
    /// </summary>
    public abstract class RealmList : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 服务器的唯一序号
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long ServerGuid { get; set; }

        /// <summary>
        /// 服务器的名字
        /// </summary>
        [Indexed( Unique = true )]
        [Length( 64 )]
        public abstract string ServerName { get; set; }

        /// <summary>
        /// 服务器的(IP)地址(IPv4/IPv6)
        /// </summary>
        [Length(24)]
        public abstract string Host { get; set; }

        /// <summary>
        /// 服务器的端口
        /// </summary>
        public abstract int Port { get; set; }

        /// <summary>
        /// 服务器的游戏类型 PVP/RP/RPPVP/NORMAL
        /// </summary>
        public abstract int Icon { get; set; }

        /// <summary>
        /// 服务器的名称颜色(暂时不要改)
        /// </summary>
        public abstract long Color { get; set; }

        /// <summary>
        /// 服务器的区域(中国,台湾...)位置(暂时不要改)
        /// </summary>
        public abstract long Timezone { get; set; }

        /// <summary>
        /// 当前服务器连接的最大人数
        /// </summary>
        public abstract long Population { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            ServerGuid = Guid.NewGuid().GetHashCode();
            ServerName = Guid.NewGuid().ToString();

            Host = "127.0.0.1";
            Port  = 0;
            Icon = 0;
            Color = 1;
            Timezone = 1;
            Population = 1000;

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  ServerName:        {0}", GetProperty( "ServerName" ) == null ? "null" : ServerName.ToString() );
            output.WriteLine( "  Host:              {0}", GetProperty( "Host" ) == null ? "null" : Host.ToString() );
            output.WriteLine( "  Port:              {0}", GetProperty( "Port" ) == null ? "null" : Port.ToString() );
            output.WriteLine( "  Icon:              {0}", GetProperty( "Icon" ) == null ? "null" : Icon.ToString() );
            output.WriteLine( "  Color:             {0}", GetProperty( "Color" ) == null ? "null" : Color.ToString() );
            output.WriteLine( "  Timezone:          {0}", GetProperty( "Timezone" ) == null ? "null" : Timezone.ToString() );
            output.WriteLine( "  Population:        {0}", GetProperty( "Population" ) == null ? "null" : Population.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// 游戏人物的名称
        /// </summary>
        [Indexed( Unique = true )]
        [Length( 64 )]
        public abstract string CharacterName { get; set; }

        /// <summary>
        /// 游戏人物所处的帐号的ID
        /// </summary>
        [Indexed]
        public abstract long AccountGuid { get; set; }

        /// <summary>
        /// 人物的种族
        /// </summary>
        public abstract int Race { get; set; }

        /// <summary>
        /// 人物的职业
        /// </summary>
        public abstract int Class { get; set; }

        /// <summary>
        /// 人物的性别
        /// </summary>
        public abstract int Gender { get; set; }

        /// <summary>
        /// 人物的？
        /// </summary>
        public abstract uint Bytes { get; set; }

        /// <summary>
        /// 人物的？
        /// </summary>
        public abstract uint Bytes2 { get; set; }
        
        /// <summary>
        /// 人物的等级
        /// </summary>
        public abstract int Level { get; set; }

        /// <summary>
        /// 人物的等级
        /// </summary>
        [Indexed]
        public abstract int MapGuid { get; set; }

        /// <summary>
        /// 人物 所在的 X坐标
        /// </summary>
        public abstract int PositionX { get; set; }

        /// <summary>
        /// 人物 所在的 Y坐标
        /// </summary>
        public abstract float PositionY { get; set; }

        /// <summary>
        /// 人物 所在的 Z坐标
        /// </summary>
        public abstract float PositionZ { get; set; }

        /// <summary>
        /// 人物 所在的 方向
        /// </summary>
        public abstract float Orientation { get; set; }

        ///// <summary>
        ///// 人物当前的HP
        ///// </summary>
        //public abstract float CurrentHP { get; set; }

        ///// <summary>
        ///// 人物当前的MP
        ///// </summary>
        //public abstract int CurrentMP { get; set; }

        ///// <summary>
        ///// 人物的力量
        ///// </summary>
        //public abstract int Strength { get; set; }

        ///// <summary>
        ///// 人物的集中
        ///// </summary>
        //public abstract int Convergence { get; set; }

        ///// <summary>
        ///// 人物的敏捷
        ///// </summary>
        //public abstract int Dexterity { get; set; }

        ///// <summary>
        ///// 人物的智力
        ///// </summary>
        //public abstract int Intellect { get; set; }

        ///// <summary>
        ///// 人物的魅力
        ///// </summary>
        //public abstract int Charm { get; set; }

        ///// <summary>
        ///// 人物的感觉
        ///// </summary>
        //public abstract int Sense { get; set; }

        ///// <summary>
        ///// 人物的脸
        ///// </summary>
        //public abstract int Face { get; set; }

        ///// <summary>
        ///// 人物的头发
        ///// </summary>
        //public abstract int HairStyle { get; set; }

        ///// <summary>
        ///// 人物的性别
        ///// </summary>
        //public abstract int Sex { get; set; }


        ///// <summary>
        ///// 人物的经验值
        ///// </summary>
        //public abstract int Experience { get; set; }

        ///// <summary>
        ///// 人物的技能点
        ///// </summary>
        //public abstract int SkillPoint { get; set; }

        ///// <summary>
        ///// 人物的能力点
        ///// </summary>
        //public abstract int StatusPoint { get; set; }

        ///// <summary>
        ///// 人物的职业
        ///// </summary>
        //public abstract int ClassID { get; set; }

        ///// <summary>
        ///// 人物所在部落的GUID
        ///// </summary>
        //[Indexed]
        //public abstract int ClanGuid { get; set; }

        ///// <summary> 
        ///// 人物所在的部落的等级
        ///// </summary>
        //public abstract int ClanRank { get; set; }

        ///// <summary>
        ///// 人物当前所在的地图
        ///// </summary>
        //public abstract int CurrentMap { get; set; }

        ///// <summary>
        ///// 人物的精力
        ///// </summary>
        //public abstract int Stamina { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[Length( 255 )]
        //public abstract string QuickBar { get; set; }

        ///// <summary>
        ///// 人物的基础技能
        ///// </summary>
        //[Length( 255 )]
        //public abstract string BasicSkills { get; set; }

        ///// <summary>
        ///// 人物的职业技能
        ///// </summary>
        //[Length( 255 )]
        //public abstract string ClassSkills { get; set; }

        ///// <summary>
        ///// 人物的职业技能的等级
        ///// </summary>
        //[Length( 255 )]
        //public abstract string ClassSkillsLevel { get; set; }

        ///// <summary>
        ///// 人物所在的游戏区
        ///// </summary>
        //public abstract int Realm { get; set; }

        ///// <summary>
        ///// 人物复活点的GUID
        ///// </summary>
        //public abstract long RespawnZoneGuid { get; set; }

        /// <summary>
        /// 人物所玩的总游戏时间
        /// </summary>
        public abstract long TotalTime { get; set; }

        /// <summary>
        /// 人物升级时的游戏时间(用于计算升级所需的游戏时间)
        /// </summary>
        public abstract long LevelTime { get; set; }

        /// <summary>
        /// 人物登出的时间
        /// </summary>
        public abstract DateTime LogoutTime { get; set; }

        /// <summary>
        /// 人物的是否已删除
        /// </summary>
        public abstract bool IsDelete { get; set; }

        /// <summary>
        /// 人物将删除的时间
        /// </summary>
        [Nullable]
        public abstract DateTime DeleteTime { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();
            CharacterName = Guid.NewGuid().ToString();
            
            AccountGuid  = 0;
            Race = 0;
            Class = 0;
            Level = 0;
            PositionX = 5098;
            PositionY = 5321;
            PositionZ = 5321;
            Orientation = 0;
            TotalTime = 0;
            LevelTime = 0;
            LogoutTime = DateTime.MinValue;
            IsDelete = false;
            DeleteTime = DateTime.MaxValue;

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
            output.WriteLine( "  CharacterName:     {0}", GetProperty( "CharacterName" ) == null ? "null" : CharacterName.ToString() );
            output.WriteLine( "  AccountGuid:       {0}", GetProperty( "AccountGuid" ) == null ? "null" : AccountGuid.ToString() );
            output.WriteLine( "  Race:              {0}", GetProperty( "Race" ) == null ? "null" : Race.ToString() );
            output.WriteLine( "  Class:             {0}", GetProperty( "Class" ) == null ? "null" : Class.ToString() );
            output.WriteLine( "  Level:             {0}", GetProperty( "Level" ) == null ? "null" : Level.ToString() );
            output.WriteLine( "  PositionX:         {0}", GetProperty( "PositionX" ) == null ? "null" : PositionX.ToString() );
            output.WriteLine( "  PositionY:         {0}", GetProperty( "PositionY" ) == null ? "null" : PositionY.ToString() );
            output.WriteLine( "  PositionZ:         {0}", GetProperty( "PositionZ" ) == null ? "null" : PositionZ.ToString() );
            output.WriteLine( "  Orientation:       {0}", GetProperty( "Orientation" ) == null ? "null" : Orientation.ToString() );
            output.WriteLine( "  TotalTime:         {0}", GetProperty( "TotalTime" ) == null ? "null" : TotalTime.ToString() );
            output.WriteLine( "  LevelTime:         {0}", GetProperty( "LevelTime" ) == null ? "null" : LevelTime.ToString() );
            output.WriteLine( "  LogoutTime:        {0}", GetProperty( "LogoutTime" ) == null ? "null" : LogoutTime.ToString() );
            output.WriteLine( "  IsDelete:          {0}", GetProperty( "IsDelete" ) == null ? "null" : IsDelete.ToString() );
            output.WriteLine( "  DeleteTime:        {0}", GetProperty( "DeleteTime" ) == null ? "null" : DeleteTime.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Action : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Aura : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Gifts : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Homebind : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Instance : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Inventory : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Kill : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Pet : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Queststatus : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Reputation : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Social : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Spell : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_SpellCooldown : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Ticket : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 游戏账号里面的游戏人物
    /// </summary>
    public abstract class Characters_Tutorial : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏人物的名称的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 人物所拥有的道具
    /// </summary>
    public abstract class Items : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 道具的的唯一Guid信息
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long ItemGuid { get; set; }

        /// <summary>
        /// 道具的拥有者
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// 道具的编号(模型的ID号)
        /// </summary>
        public abstract int ItemID { get; set; }

        /// <summary>
        /// 道具的类型(1 假面  2 帽子 3衣服 4手套 5鞋子  6背部披风  7耳环 指环 项链  8武器 9盾牌)
        /// </summary>
        public abstract int ItemType { get; set; }

        /// <summary>
        /// 道具的精炼度(等级1-9)
        /// </summary>
        public abstract int Refine { get; set; }

        /// <summary>
        /// 道具的耐久度
        /// </summary>
        public abstract int Durability { get; set; }

        /// <summary>
        /// 道具的使用期限
        /// </summary>
        public abstract int Lifespan { get; set; }

        /// <summary>
        /// 道具的所在的位置的编号(小于10是在人物的身上)
        /// </summary>
        public abstract int SlotNumber { get; set; }

        /// <summary>
        /// 道具的数量
        /// </summary>
        public abstract int Count { get; set; }

        /// <summary>
        /// 道具的状态(鉴定是否)
        /// </summary>
        public abstract int Stats { get; set; }

        /// <summary>
        /// 道具的插槽
        /// </summary>
        public abstract bool Socketed { get; set; }

        /// <summary>
        /// 道具的估价
        /// </summary>
        public abstract bool Appraised { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract int GemID{ get; set; }

        /// <summary>
        /// 道具的是否已消失
        /// </summary>
        public abstract bool IsDelete { get; set; }

        /// <summary>
        /// 道具消失的时间
        /// </summary>
        [Nullable]
        public abstract DateTime DeleteTime { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            ItemGuid = Guid.NewGuid().GetHashCode();

            CharacterGuid = 0;
            ItemID = 0;
            ItemType = 0;
            Refine = 0;
            Durability = 0;
            Lifespan = 0;
            SlotNumber = 0;
            Count = 0;
            Stats = 0;
            Socketed = false;
            Appraised  = false;
            GemID = 0;
            IsDelete = false;
            DeleteTime = DateTime.Now;

            base.OnCreate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
            output.WriteLine( "  ItemID:            {0}", GetProperty( "ItemID" ) == null ? "null" : ItemID.ToString() );
            output.WriteLine( "  ItemType:          {0}", GetProperty( "ItemType" ) == null ? "null" : ItemType.ToString() );
            output.WriteLine( "  Refine:            {0}", GetProperty( "Refine" ) == null ? "null" : Refine.ToString() );
            output.WriteLine( "  Durability:        {0}", GetProperty( "Durability" ) == null ? "null" : Durability.ToString() );
            output.WriteLine( "  Lifespan:          {0}", GetProperty( "Lifespan" ) == null ? "null" : Lifespan.ToString() );
            output.WriteLine( "  SlotNumber:        {0}", GetProperty( "SlotNumber" ) == null ? "null" : SlotNumber.ToString() );
            output.WriteLine( "  Count:             {0}", GetProperty( "Count" ) == null ? "null" : Count.ToString() );
            output.WriteLine( "  Stats:             {0}", GetProperty( "Stats" ) == null ? "null" : Stats.ToString() );
            output.WriteLine( "  Socketed:          {0}", GetProperty( "Socketed" ) == null ? "null" : Socketed.ToString() );
            output.WriteLine( "  Appraised:         {0}", GetProperty( "Appraised" ) == null ? "null" : Appraised.ToString() );
            output.WriteLine( "  GemID:             {0}", GetProperty( "GemID" ) == null ? "null" : GemID.ToString() );
            output.WriteLine( "  IsDelete:          {0}", GetProperty( "IsDelete" ) == null ? "null" : IsDelete.ToString() );
            output.WriteLine( "  DeleteTime:        {0}", GetProperty( "DeleteTime" ) == null ? "null" : DeleteTime.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 人物所拥共有的存储箱
    /// </summary>
    public abstract class ListStorage : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 存储箱的拥有者帐号
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long AccountGuid { get; set; }

        /// <summary>
        /// 存放在存储箱里道具的前拥有者
        /// </summary>
        [Indexed]
        public abstract long PreOwnerGuid { get; set; }

        /// <summary>
        /// 道具的的唯一Guid信息
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long ItemGuid { get; set; }

        /// <summary>
        /// 道具的编号(模型的ID号)
        /// </summary>
        public abstract int ItemID { get; set; }

        /// <summary>
        /// 道具的类型(1 假面  2 帽子 3衣服 4手套 5鞋子  6背部披风  7耳环 指环 项链  8武器 9盾牌)
        /// </summary>
        public abstract int ItemType { get; set; }

        /// <summary>
        /// 道具的精炼度(等级1-9)
        /// </summary>
        public abstract int Refine { get; set; }

        /// <summary>
        /// 道具的耐久度
        /// </summary>
        public abstract int Durability { get; set; }

        /// <summary>
        /// 道具的使用期限
        /// </summary>
        public abstract int Lifespan { get; set; }

        /// <summary>
        /// 道具的所在的位置的编号(小于10是在人物的身上)
        /// </summary>
        public abstract int SlotNumber { get; set; }

        /// <summary>
        /// 道具的数量
        /// </summary>
        public abstract int Count { get; set; }

        /// <summary>
        /// 道具的状态(鉴定是否)
        /// </summary>
        public abstract int Stats { get; set; }

        /// <summary>
        /// 道具的插槽
        /// </summary>
        public abstract bool Socketed { get; set; }

        /// <summary>
        /// 道具的估价
        /// </summary>
        public abstract bool Appraised { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract int GemID{ get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            AccountGuid = Guid.NewGuid().GetHashCode();

            base.OnCreate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  PreOwnerGuid:      {0}", GetProperty( "PreOwnerGuid" ) == null ? "null" : PreOwnerGuid.ToString() );
            output.WriteLine( "  ItemID:            {0}", GetProperty( "ItemID" ) == null ? "null" : ItemID.ToString() );
            output.WriteLine( "  ItemType:          {0}", GetProperty( "ItemType" ) == null ? "null" : ItemType.ToString() );
            output.WriteLine( "  Refine:            {0}", GetProperty( "Refine" ) == null ? "null" : Refine.ToString() );
            output.WriteLine( "  Durability:        {0}", GetProperty( "Durability" ) == null ? "null" : Durability.ToString() );
            output.WriteLine( "  Lifespan:          {0}", GetProperty( "Lifespan" ) == null ? "null" : Lifespan.ToString() );
            output.WriteLine( "  SlotNumber:        {0}", GetProperty( "SlotNumber" ) == null ? "null" : SlotNumber.ToString() );
            output.WriteLine( "  Count:             {0}", GetProperty( "Count" ) == null ? "null" : Count.ToString() );
            output.WriteLine( "  Stats:             {0}", GetProperty( "Stats" ) == null ? "null" : Stats.ToString() );
            output.WriteLine( "  Socketed:          {0}", GetProperty( "Socketed" ) == null ? "null" : Socketed.ToString() );
            output.WriteLine( "  Appraised:         {0}", GetProperty( "Appraised" ) == null ? "null" : Appraised.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 定义部落的名字
    /// </summary>
    public abstract class ListClan : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 部落的ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long ClanGuid { get; set; }

        /// <summary>
        /// 部落的名字
        /// </summary>
        [Indexed( Unique = true )]
        [Length( 64 )]
        public abstract string ClanName { get; set; }

        /// <summary>
        /// 部落的标志
        /// </summary>
        public abstract int Logo { get; set; }

        /// <summary>
        /// 部落的？
        /// </summary>
        public abstract int Back { get; set; }

        /// <summary>
        /// 部落的？
        /// </summary>
        public abstract int CP { get; set; }

        /// <summary>
        /// 部落的等级
        /// </summary>
        public abstract int Grade { get; set; }

        /// <summary>
        /// 部落的口号
        /// </summary>
        [Length( 255 )]
        public abstract string Slogan { get; set; }

        /// <summary>
        /// 部落的新闻
        /// </summary>
        [SqlType( SqlType.Text )]
        public abstract string News { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            ClanGuid = Guid.NewGuid().GetHashCode();
            ClanName = Guid.NewGuid().ToString();

            Logo  = 0;
            Back  = 0;
            CP = 0;
            Grade = 0;
            Slogan = string.Empty;
            News = string.Empty;

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  ClanGuid:          {0}", GetProperty( "ClanGuid" ) == null ? "null" : ClanGuid.ToString() );
            output.WriteLine( "  ClanName:          {0}", GetProperty( "ClanName" ) == null ? "null" : ClanName.ToString() );
            output.WriteLine( "  Logo:              {0}", GetProperty( "Logo" ) == null ? "null" : Logo.ToString() );
            output.WriteLine( "  Back:              {0}", GetProperty( "Back" ) == null ? "null" : Back.ToString() );
            output.WriteLine( "  CP:                {0}", GetProperty( "CP" ) == null ? "null" : CP.ToString() );
            output.WriteLine( "  Grade:             {0}", GetProperty( "Grade" ) == null ? "null" : Grade.ToString() );
            output.WriteLine( "  Slogan:            {0}", GetProperty( "Slogan" ) == null ? "null" : Slogan.ToString() );
            output.WriteLine( "  News:              {0}", GetProperty( "News" ) == null ? "null" : News.ToString() );
       }
        #endregion
    }

    /// <summary>
    /// 好友的列表
    /// </summary>
    public abstract class ListFriend : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Indexed]
        public abstract long FriendGuid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Indexed]
        [Length( 64 )]
        public abstract string FriendName { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            CharacterGuid = 0;
            FriendGuid = 0;
            FriendName = string.Empty;

            base.OnCreate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
            output.WriteLine( "  FriendGuid:        {0}", GetProperty( "FriendGuid" ) == null ? "null" : FriendGuid.ToString() );
            output.WriteLine( "  FriendName:        {0}", GetProperty( "FriendName" ) == null ? "null" : FriendName.ToString() );
       }
        #endregion
    }

    /// <summary>
    /// 任务的列表
    /// </summary>
    public abstract class ListQuest : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Indexed]
        public abstract long QuestGuid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Length( 1000 )]
        public abstract string QuestItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract bool Active { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:        {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 人物聊天的记录
    /// </summary>
    public abstract class CharacterChatLog : FtObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 记录游戏聊天的人物
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        #region zh-CHS 枚举 | en Enum
        /// <summary>
        /// 聊天频道
        /// </summary>
        public enum ChatChannel
        {
            /// <summary>
            /// 耳语频道
            /// </summary>
            Whisper = 0x01,
            /// <summary>
            /// 交易频道
            /// </summary>
            Trader = 0x02,
            /// <summary>
            /// 团队频道
            /// </summary>
            Party = 0x04,
            /// <summary>
            /// 部落频道
            /// </summary>
            Clan = 0x08
        }
        #endregion

        /// <summary>
        /// 记录聊天在那个频道
        /// </summary>
        public abstract uint ChatChannelInfo { get; set; }

        /// <summary>
        /// 聊天记录的文字信息
        /// </summary>
        [Length( 1000 )]
        public abstract string ChatInfo { get; set; }

        /// <summary>
        /// 聊天记录的时间
        /// </summary>
        public abstract DateTime ChatTime { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:        {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
            output.WriteLine( "  ChatInfo:        {0}", GetProperty( "ChatInfo" ) == null ? "null" : ChatInfo.ToString() );
            output.WriteLine( "  ChatTime:        {0}", GetProperty( "ChatTime" ) == null ? "null" : ChatTime.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 人物交易的记录
    /// </summary>
    public abstract class CharacterTradeLog : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 记录交易的游戏人物1
        /// </summary>
        [Indexed]
        public abstract long CharacterGuidOne { get; set; }

        /// <summary>
        /// 记录交易的游戏人物2
        /// </summary>
        [Indexed]
        public abstract long CharacterGuidTwo { get; set; }

        /// <summary>
        /// 交易记录的文字信息人物1
        /// "ItemGuid:OnlyItemGuid;ItemGuid:OnlyItemGuid;...ItemGuid:OnlyItemGuid"
        /// </summary>
        [Length( 1000 )]
        public abstract string TradeInfoOne { get; set; }

        /// <summary>
        /// 交易记录的文字信息人物2
        /// "ItemGuid:OnlyItemGuid;ItemGuid:OnlyItemGuid;...ItemGuid:OnlyItemGuid"
        /// </summary>
        [Length( 1000 )]
        public abstract string TradeInfoTwo { get; set; }

        /// <summary>
        /// 交易记录的时间
        /// </summary>
        public abstract DateTime TradeTime { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuidOne:        {0}", GetProperty( "CharacterGuidOne" ) == null ? "null" : CharacterGuidOne.ToString() );
            output.WriteLine( "  CharacterGuidTwo:        {0}", GetProperty( "CharacterGuidTwo" ) == null ? "null" : CharacterGuidTwo.ToString() );
            output.WriteLine( "  TradeInfoOne:        {0}", GetProperty( "TradeInfoOne" ) == null ? "null" : TradeInfoOne.ToString() );
            output.WriteLine( "  TradeInfoTwo:        {0}", GetProperty( "TradeInfoTwo" ) == null ? "null" : TradeInfoTwo.ToString() );
            output.WriteLine( "  TradeTime:        {0}", GetProperty( "TradeTime" ) == null ? "null" : TradeTime.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 人物道具的详细记录
    /// </summary>
    public abstract class CharacterItemLog : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 记录道具使用的游戏人物
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// 记录的道具Guid信息
        /// </summary>
        [Indexed]
        public abstract long ItemGuid { get; set; }

        #region zh-CHS 枚举 | en Enum
        /// <summary>
        /// 道具使用的信息
        /// </summary>
        public enum Item
        {
            /// <summary>
            /// 获得道具
            /// </summary>
            Obtain = 0x01,
            /// <summary>
            /// 使用道具
            /// </summary>
            Use = 0x02,
            /// <summary>
            /// 交易道具
            /// </summary>
            Trade = 0x04,
            /// <summary>
            /// 丢弃道具
            /// </summary>
            Discard = 0x08
        }
        #endregion

        /// <summary>
        /// 道具的使用信息
        /// </summary>
        public abstract uint ItemInfo { get; set; }

        /// <summary>
        /// 记录道具使用的时间
        /// </summary>
        public abstract DateTime ItemTime { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:        {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
            output.WriteLine( "  ItemGuid:        {0}", GetProperty( "ItemGuid" ) == null ? "null" : ItemGuid.ToString() );
            output.WriteLine( "  ItemInfo:        {0}", GetProperty( "ItemInfo" ) == null ? "null" : ItemInfo.ToString() );
            output.WriteLine( "  ItemTime:        {0}", GetProperty( "ItemTime" ) == null ? "null" : ItemTime.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// GM使用命令的详细记录
    /// </summary>
    public abstract class GMCommandLog : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 记录使用GM命令的游戏人物
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// 记录GM使用的命令信息
        /// </summary>
        [Length( 1000 )]
        public abstract string GMCommandInfo { get; set; }

        /// <summary>
        /// 记录GM使用使用命令的时间
        /// </summary>
        public abstract DateTime GMCommandTime { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:        {0}", GetProperty( "CharacterGuid" ) == null ? "null" : CharacterGuid.ToString() );
            output.WriteLine( "  GMCommandInfo:        {0}", GetProperty( "GMCommandInfo" ) == null ? "null" : GMCommandInfo.ToString() );
            output.WriteLine( "  GMCommandTime:        {0}", GetProperty( "GMCommandTime" ) == null ? "null" : GMCommandTime.ToString() );
        }
        #endregion
    }

    /// <summary>
    ///  刷NPC的所标记的刷NPC的内容
    /// </summary>
    public abstract class SpawnNPCs : DataObject
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 刷NPC的GUID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long SpawnGuid { get; set; }
        
        /// <summary>
        /// NPC的GUID
        /// </summary>
        [Indexed]
        public abstract long NPCGuid { get; set; }

        /// <summary>
        /// NPC所在地图的ID
        /// </summary>
        public abstract int MapID { get; set; }

        /// <summary>
        /// NPC的 X 坐标
        /// </summary>
        public abstract int PositionX { get; set; }

        /// <summary>
        /// NPC的 Y 坐标
        /// </summary>
        public abstract int PositionY { get; set; }

        /// <summary>
        /// NPC的方向
        /// </summary>
        public abstract int Direction { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            SpawnGuid = Guid.NewGuid().GetHashCode();

            NPCGuid = 0;
            MapID = 0;
            PositionX = 0;
            PositionY = 0;
            Direction = 0;

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  SpawnGuid:     {0}", GetProperty( "SpawnGuid" ) == null ? "null" : SpawnGuid.ToString() );
            output.WriteLine( "  NPCGuid:       {0}", GetProperty( "NPCGuid" ) == null ? "null" : NPCGuid.ToString() );
            output.WriteLine( "  MapID:         {0}", GetProperty( "MapID" ) == null ? "null" : MapID.ToString() );
            output.WriteLine( "  PositionX:     {0}", GetProperty( "PositionX" ) == null ? "null" : PositionX.ToString() );
            output.WriteLine( "  PositionY:     {0}", GetProperty( "PositionY" ) == null ? "null" : PositionY.ToString() );
            output.WriteLine( "  Direction:     {0}", GetProperty( "Direction" ) == null ? "null" : Direction.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 刷怪点的所标记的刷怪内容
    /// </summary>
    public abstract class SpawnMonsters : DataObject
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 刷怪的GUID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long SpawnGuid { get; set; }

        /// <summary>
        /// 怪物的GUID
        /// </summary>
        [Indexed]
        public abstract long MobileGUID { get; set; }

        /// <summary>
        /// 刷怪点地图的ID
        /// </summary>
        public abstract int MapID { get; set; }

        /// <summary>
        /// 所需刷怪的数量(在下面的范围内随机刷的刷怪点)
        /// </summary>
        public abstract int Count { get; set; }

        /// <summary>
        /// 刷怪的数据数量和位置x和位置y(count|x,y|x,y|...|...)至少3个坐标点以上,是个一或多个三角的范围,怪物在此三角范围内刷怪
        /// </summary>
        [SqlType( SqlType.Text )]
        public abstract string Points { get; set; }

        /// <summary>
        /// 刷怪所需的最小数量(范围内少于此怪物数量将马上刷怪,忽略刷怪的时间间隔)
        /// </summary>
        public abstract int MinRespawn { get; set; }

        /// <summary>
        /// 刷怪的时间间隔(据刷怪的类型: 可能是怪物死亡后刷怪的时间间隔,或按时间间隔来持续的刷怪直到所需刷怪的数量位置......等)
        /// </summary>
        public abstract int RespawnTime { get; set; }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 防止违反索引唯一的规者
        /// </summary>
        protected override void OnCreate()
        {
            SpawnGuid = Guid.NewGuid().GetHashCode();

            MobileGUID = 0;
            MapID = 0;
            Count = 0;
            Points = "3|5000,5000|5100,5000|5000,5100";
            RespawnTime = 30;

            base.OnCreate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public virtual void Dump( TextWriter output )
        {
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  SpawnGuid:     {0}", GetProperty( "SpawnGuid" ) == null ? "null" : SpawnGuid.ToString() );
            output.WriteLine( "  MobileGUID:    {0}", GetProperty( "MobileGUID" ) == null ? "null" : MobileGUID.ToString() );
            output.WriteLine( "  MapID:         {0}", GetProperty( "MapID" ) == null ? "null" : MapID.ToString() );
            output.WriteLine( "  Count:         {0}", GetProperty( "Count" ) == null ? "null" : Count.ToString() );
            output.WriteLine( "  Points:        {0}", GetProperty( "Points" ) == null ? "null" : Points.ToString() );
            output.WriteLine( "  RespawnTime:   {0}", GetProperty( "RespawnTime" ) == null ? "null" : RespawnTime.ToString() );
        }
        #endregion
    }
}
#endregion