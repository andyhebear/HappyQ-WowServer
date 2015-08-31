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

namespace Demo_R.O.S.E.Database.Model
{
    /// <summary>
    /// 游戏的账号信息
    /// </summary>
    public abstract class Accounts : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 游戏账号的名称
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
        /// 游戏账号是否已登陆锁定不允许再次登陆
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
        /// 存储箱中的金币数
        /// </summary>
        [Nullable]
        public abstract uint StorageZuly { get; set; }

        /// <summary>
        /// 是否是白金会员
        /// </summary>
        [Nullable]
        public abstract uint Platinum { get; set; }
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
            StorageZuly = 0;
            Platinum = 0;

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

            output.WriteLine( "  AccountsGuid:      {0}", GetProperty( "AccountsGuid" ) == null ? "未知" : AccountsGuid.ToString() );
            output.WriteLine( "  AccountsName:      {0}", GetProperty( "AccountsName" ) == null ? "未知" : AccountsName.ToString() );
            output.WriteLine( "  Password:          {0}", GetProperty( "Password" ) == null ? "未知" : Password.ToString() );
            output.WriteLine( "  GMLevel:           {0}", GetProperty( "GMLevel" ) == null ? "未知" : GMLevel.ToString() );
            output.WriteLine( "  Locked:            {0}", GetProperty( "Locked" ) == null ? "未知" : Locked.ToString() );
            output.WriteLine( "  Banned:            {0}", GetProperty( "Banned" ) == null ? "未知" : Banned.ToString() );
            output.WriteLine( "  CreateDate:        {0}", GetProperty( "CreateDate" ) == null ? "未知" : CreateDate.ToString() );
            output.WriteLine( "  Email:             {0}", GetProperty( "Email" ) == null ? "未知" : Email.ToString() );
            output.WriteLine( "  ActiveEmail:       {0}", GetProperty( "ActiveEmail" ) == null ? "未知" : ActiveEmail.ToString() );
            output.WriteLine( "  ActiveEmailKey:    {0}", GetProperty( "ActiveEmailKey" ) == null ? "未知" : ActiveEmailKey.ToString() );
            output.WriteLine( "  SessionKey:        {0}", GetProperty( "SessionKey" ) == null ? "未知" : SessionKey.ToString() );
            output.WriteLine( "  DonationGuid:      {0}", GetProperty( "DonationGuid" ) == null ? "未知" : DonationGuid.ToString() );
            output.WriteLine( "  Donation:          {0}", GetProperty( "Donation" ) == null ? "未知" : Donation.ToString() );
            output.WriteLine( "  FailedLogins:      {0}", GetProperty( "FailedLogins" ) == null ? "未知" : FailedLogins.ToString() );
            output.WriteLine( "  LastIP:            {0}", GetProperty( "LastIP" ) == null ? "未知" : LastIP.ToString() );
            output.WriteLine( "  LastLoginDate:     {0}", GetProperty( "LastLoginDate" ) == null ? "未知" : LastLoginDate.ToString() );
            output.WriteLine( "  LastServerGuid:    {0}", GetProperty( "LastServerGuid" ) == null ? "未知" : LastServerGuid.ToString() );
            output.WriteLine( "  LastCharacter:     {0}", GetProperty( "LastCharacter" ) == null ? "未知" : LastCharacter.ToString() );
            output.WriteLine( "  StorageZuly:       {0}", GetProperty( "StorageZuly" ) == null ? "未知" : StorageZuly.ToString() );
            output.WriteLine( "  Platinum:          {0}", GetProperty( "Platinum" ) == null ? "未知" : Platinum.ToString() );
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

            output.WriteLine( "  IPAddress:         {0}", GetProperty( "IPAddress" ) == null ? "未知" : IPAddress.ToString() );
        }
        #endregion
    }

    /// <summary>
    /// 定义服务器的频道列表(游戏服务器或人物服务器)的内容
    /// </summary>
    public abstract class Channels : DataObject, IDumpable
    {
        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 服务器(游戏或人物)的ID
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
        /// 服务器的状态
        /// </summary>
        public abstract int Status { get; set; }

        /// <summary>
        /// 人物服务器(服务器的类型)
        /// </summary>
        public const int CHARACTER_SERVER_ID = 0;

        /// <summary>
        /// 一个人物服务器拥有多个游戏服务器OwnerID的数值里面的是人物服务器的ID号
        /// 0 代表 当前是人物服务器
        /// 其它-代表的是(游戏服务器的拥有者)OwnerID存储的是人物服务器的ID号
        /// </summary>
        [Indexed]
        public abstract long OwnerGuid { get; set; }

        /// <summary>
        /// 当前服务器连接的人数
        /// </summary>
        public abstract long Connected { get; set; }

        /// <summary>
        /// 当前服务器连接的最大人数
        /// </summary>
        public abstract long MaxConnected { get; set; }
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
            Status = 0;
            OwnerGuid = 0;

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

            output.WriteLine( "  ServerName:        {0}", GetProperty( "ServerName" ) == null ? "未知" : ServerName.ToString() );
            output.WriteLine( "  Host:              {0}", GetProperty( "Host" ) == null ? "未知" : Host.ToString() );
            output.WriteLine( "  Port:              {0}", GetProperty( "Port" ) == null ? "未知" : Port.ToString() );
            output.WriteLine( "  Status:            {0}", GetProperty( "Status" ) == null ? "未知" : Status.ToString() );
            output.WriteLine( "  OwnerGuid:         {0}", GetProperty( "OwnerGuid" ) == null ? "未知" : OwnerGuid.ToString() );
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
        /// 游戏人物是否在线
        /// </summary>
        public abstract bool IsOnline { get; set; }

        /// <summary>
        /// 游戏人物金币(Zuly)数量
        /// </summary>
        public abstract int Zuly { get; set; }

        /// <summary>
        /// 人物的等级
        /// </summary>
        public abstract int Level { get; set; }

        /// <summary>
        /// 人物当前的HP
        /// </summary>
        public abstract int CurrentHP { get; set; }

        /// <summary>
        /// 人物当前的MP
        /// </summary>
        public abstract int CurrentMP { get; set; }

        /// <summary>
        /// 人物的力量
        /// </summary>
        public abstract int Strength { get; set; }

        /// <summary>
        /// 人物的集中
        /// </summary>
        public abstract int Convergence { get; set; }

        /// <summary>
        /// 人物的敏捷
        /// </summary>
        public abstract int Dexterity { get; set; }

        /// <summary>
        /// 人物的智力
        /// </summary>
        public abstract int Intellect { get; set; }

        /// <summary>
        /// 人物的魅力
        /// </summary>
        public abstract int Charm { get; set; }

        /// <summary>
        /// 人物的感觉
        /// </summary>
        public abstract int Sense { get; set; }

        /// <summary>
        /// 人物的脸
        /// </summary>
        public abstract int Face { get; set; }

        /// <summary>
        /// 人物的头发
        /// </summary>
        public abstract int HairStyle { get; set; }

        /// <summary>
        /// 人物的性别
        /// </summary>
        public abstract int Sex { get; set; }

        /// <summary>
        /// 人物 所在的 X坐标
        /// </summary>
        public abstract int PositionX { get; set; }

        /// <summary>
        /// 人物 所在的 Y坐标
        /// </summary>
        public abstract int PositionY { get; set; }

        /// <summary>
        /// 人物的经验值
        /// </summary>
        public abstract int Experience { get; set; }

        /// <summary>
        /// 人物的技能点
        /// </summary>
        public abstract int SkillPoint { get; set; }

        /// <summary>
        /// 人物的能力点
        /// </summary>
        public abstract int StatusPoint { get; set; }

        /// <summary>
        /// 人物的职业
        /// </summary>
        public abstract int ClassID { get; set; }

        /// <summary>
        /// 人物所在部落的GUID
        /// </summary>
        [Indexed]
        public abstract int ClanGuid { get; set; }

        /// <summary> 
        /// 人物所在的部落的等级
        /// </summary>
        public abstract int ClanRank { get; set; }

        /// <summary>
        /// 人物当前所在的地图
        /// </summary>
        public abstract int CurrentMap { get; set; }

        /// <summary>
        /// 人物的精力
        /// </summary>
        public abstract int Stamina { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Length( 255 )]
        public abstract string QuickBar { get; set; }

        /// <summary>
        /// 人物的基础技能
        /// </summary>
        [Length( 255 )]
        public abstract string BasicSkills { get; set; }

        /// <summary>
        /// 人物的职业技能
        /// </summary>
        [Length( 255 )]
        public abstract string ClassSkills { get; set; }

        /// <summary>
        /// 人物的职业技能的等级
        /// </summary>
        [Length( 255 )]
        public abstract string ClassSkillsLevel { get; set; }

        /// <summary>
        /// 人物所在的游戏区
        /// </summary>
        public abstract int Realm { get; set; }

        /// <summary>
        /// 人物复活点的GUID
        /// </summary>
        public abstract long RespawnZoneGuid { get; set; }

        /// <summary>
        /// 人物所玩的总游戏时间
        /// </summary>
        public abstract int TotalTime { get; set; }

        /// <summary>
        /// 人物升级时的游戏时间(用于计算升级所需的游戏时间)
        /// </summary>
        public abstract int LevelTime { get; set; }

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
            IsOnline  = false;
            Zuly = 1000;
            Level = 1;
            CurrentHP = 50;
            CurrentMP = 18;
            Strength = 15;
            Convergence = 15;
            Dexterity = 15;
            Intellect = 15;
            Charm = 10;
            Sense = 10;
            Face = 1;
            HairStyle = 1;
            Sex = 0;
            PositionX = 5098;
            PositionY = 5321;
            Experience = 0;
            SkillPoint = 0;
            StatusPoint = 0;
            ClassID = 0;
            ClanGuid = 0;
            ClanRank = 0;
            CurrentMap = 0;
            Stamina = 5000;
            QuickBar = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            BasicSkills = "11,12,13,14,15,16,17,18,19,20,21,22,25,5000,0,0,0,0,0,0,0,0,0,0";
            ClassSkills = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            ClassSkillsLevel = "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";
            Realm = 0;
            RespawnZoneGuid = 0;
            TotalTime = 0;
            LevelTime = 0;
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
            // GetType().Name will print the name of the proxy class, so we'll use GetType().BaseType.Name :)
            output.WriteLine( "{0}, ID = {1}", GetType().BaseType.Name, ID );

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "未知" : CharacterGuid.ToString() );
            output.WriteLine( "  CharacterName:     {0}", GetProperty( "CharacterName" ) == null ? "未知" : CharacterName.ToString() );
            output.WriteLine( "  AccountGuid:       {0}", GetProperty( "AccountGuid" ) == null ? "未知" : AccountGuid.ToString() );
            output.WriteLine( "  IsOnline:          {0}", GetProperty( "IsOnline" ) == null ? "未知" : IsOnline.ToString() );
            output.WriteLine( "  Zuly:              {0}", GetProperty( "Zuly" ) == null ? "未知" : Zuly.ToString() );
            output.WriteLine( "  Level:             {0}", GetProperty( "Level" ) == null ? "未知" : Level.ToString() );
            output.WriteLine( "  CurrentHP:         {0}", GetProperty( "CurrentHP" ) == null ? "未知" : CurrentHP.ToString() );
            output.WriteLine( "  CurrentMP:         {0}", GetProperty( "CurrentMP" ) == null ? "未知" : CurrentMP.ToString() );
            output.WriteLine( "  Strength:          {0}", GetProperty( "Strength" ) == null ? "未知" : Strength.ToString() );
            output.WriteLine( "  Convergence:       {0}", GetProperty( "Convergence" ) == null ? "未知" : Convergence.ToString() );
            output.WriteLine( "  Dexterity:         {0}", GetProperty( "Dexterity" ) == null ? "未知" : Dexterity.ToString() );
            output.WriteLine( "  Intellect:         {0}", GetProperty( "Intellect" ) == null ? "未知" : Intellect.ToString() );
            output.WriteLine( "  Charm:             {0}", GetProperty( "Charm" ) == null ? "未知" : Charm.ToString() );
            output.WriteLine( "  Sense:             {0}", GetProperty( "Sense" ) == null ? "未知" : Sense.ToString() );
            output.WriteLine( "  Face:              {0}", GetProperty( "Face" ) == null ? "未知" : Face.ToString() );
            output.WriteLine( "  HairStyle:         {0}", GetProperty( "HairStyle" ) == null ? "未知" : HairStyle.ToString() );
            output.WriteLine( "  Sex:               {0}", GetProperty( "Sex" ) == null ? "未知" : Sex.ToString() );
            output.WriteLine( "  PositionX:         {0}", GetProperty( "PositionX" ) == null ? "未知" : PositionX.ToString() );
            output.WriteLine( "  PositionY:         {0}", GetProperty( "PositionY" ) == null ? "未知" : PositionY.ToString() );
            output.WriteLine( "  Experience:        {0}", GetProperty( "Experience" ) == null ? "未知" : Experience.ToString() );
            output.WriteLine( "  SkillPoint:        {0}", GetProperty( "SkillPoint" ) == null ? "未知" : SkillPoint.ToString() );
            output.WriteLine( "  StatusPoint:       {0}", GetProperty( "StatusPoint" ) == null ? "未知" : StatusPoint.ToString() );
            output.WriteLine( "  ClassID:           {0}", GetProperty( "ClassID" ) == null ? "未知" : ClassID.ToString() );
            output.WriteLine( "  ClanGuid:          {0}", GetProperty( "ClanGuid" ) == null ? "未知" : ClanGuid.ToString() );
            output.WriteLine( "  ClanRank:          {0}", GetProperty( "ClanRank" ) == null ? "未知" : ClanRank.ToString() );
            output.WriteLine( "  CurrentMap:        {0}", GetProperty( "CurrentMap" ) == null ? "未知" : CurrentMap.ToString() );
            output.WriteLine( "  Stamina:           {0}", GetProperty( "Stamina" ) == null ? "未知" : Stamina.ToString() );
            output.WriteLine( "  QuickBar:          {0}", GetProperty( "QuickBar" ) == null ? "未知" : QuickBar.ToString() );
            output.WriteLine( "  BasicSkills:       {0}", GetProperty( "BasicSkills" ) == null ? "未知" : BasicSkills.ToString() );
            output.WriteLine( "  ClassSkills:       {0}", GetProperty( "ClassSkills" ) == null ? "未知" : ClassSkills.ToString() );
            output.WriteLine( "  ClassSkillsLevel:  {0}", GetProperty( "ClassSkillsLevel" ) == null ? "未知" : ClassSkillsLevel.ToString() );
            output.WriteLine( "  Realm:             {0}", GetProperty( "Realm" ) == null ? "未知" : Realm.ToString() );
            output.WriteLine( "  RespawnZoneGuid:   {0}", GetProperty( "RespawnZoneGuid" ) == null ? "未知" : RespawnZoneGuid.ToString() );
            output.WriteLine( "  TotalTime:         {0}", GetProperty( "TotalTime" ) == null ? "未知" : TotalTime.ToString() );
            output.WriteLine( "  LevelTime:         {0}", GetProperty( "LevelTime" ) == null ? "未知" : LevelTime.ToString() );
            output.WriteLine( "  IsDelete:          {0}", GetProperty( "IsDelete" ) == null ? "未知" : IsDelete.ToString() );
            output.WriteLine( "  DeleteTime:        {0}", GetProperty( "DeleteTime" ) == null ? "未知" : DeleteTime.ToString() );
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

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "未知" : CharacterGuid.ToString() );
            output.WriteLine( "  ItemID:            {0}", GetProperty( "ItemID" ) == null ? "未知" : ItemID.ToString() );
            output.WriteLine( "  ItemType:          {0}", GetProperty( "ItemType" ) == null ? "未知" : ItemType.ToString() );
            output.WriteLine( "  Refine:            {0}", GetProperty( "Refine" ) == null ? "未知" : Refine.ToString() );
            output.WriteLine( "  Durability:        {0}", GetProperty( "Durability" ) == null ? "未知" : Durability.ToString() );
            output.WriteLine( "  Lifespan:          {0}", GetProperty( "Lifespan" ) == null ? "未知" : Lifespan.ToString() );
            output.WriteLine( "  SlotNumber:        {0}", GetProperty( "SlotNumber" ) == null ? "未知" : SlotNumber.ToString() );
            output.WriteLine( "  Count:             {0}", GetProperty( "Count" ) == null ? "未知" : Count.ToString() );
            output.WriteLine( "  Stats:             {0}", GetProperty( "Stats" ) == null ? "未知" : Stats.ToString() );
            output.WriteLine( "  Socketed:          {0}", GetProperty( "Socketed" ) == null ? "未知" : Socketed.ToString() );
            output.WriteLine( "  Appraised:         {0}", GetProperty( "Appraised" ) == null ? "未知" : Appraised.ToString() );
            output.WriteLine( "  GemID:             {0}", GetProperty( "GemID" ) == null ? "未知" : GemID.ToString() );
            output.WriteLine( "  IsDelete:          {0}", GetProperty( "IsDelete" ) == null ? "未知" : IsDelete.ToString() );
            output.WriteLine( "  DeleteTime:        {0}", GetProperty( "DeleteTime" ) == null ? "未知" : DeleteTime.ToString() );
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

            output.WriteLine( "  PreOwnerGuid:      {0}", GetProperty( "PreOwnerGuid" ) == null ? "未知" : PreOwnerGuid.ToString() );
            output.WriteLine( "  ItemID:            {0}", GetProperty( "ItemID" ) == null ? "未知" : ItemID.ToString() );
            output.WriteLine( "  ItemType:          {0}", GetProperty( "ItemType" ) == null ? "未知" : ItemType.ToString() );
            output.WriteLine( "  Refine:            {0}", GetProperty( "Refine" ) == null ? "未知" : Refine.ToString() );
            output.WriteLine( "  Durability:        {0}", GetProperty( "Durability" ) == null ? "未知" : Durability.ToString() );
            output.WriteLine( "  Lifespan:          {0}", GetProperty( "Lifespan" ) == null ? "未知" : Lifespan.ToString() );
            output.WriteLine( "  SlotNumber:        {0}", GetProperty( "SlotNumber" ) == null ? "未知" : SlotNumber.ToString() );
            output.WriteLine( "  Count:             {0}", GetProperty( "Count" ) == null ? "未知" : Count.ToString() );
            output.WriteLine( "  Stats:             {0}", GetProperty( "Stats" ) == null ? "未知" : Stats.ToString() );
            output.WriteLine( "  Socketed:          {0}", GetProperty( "Socketed" ) == null ? "未知" : Socketed.ToString() );
            output.WriteLine( "  Appraised:         {0}", GetProperty( "Appraised" ) == null ? "未知" : Appraised.ToString() );
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

            output.WriteLine( "  ClanGuid:          {0}", GetProperty( "ClanGuid" ) == null ? "未知" : ClanGuid.ToString() );
            output.WriteLine( "  ClanName:          {0}", GetProperty( "ClanName" ) == null ? "未知" : ClanName.ToString() );
            output.WriteLine( "  Logo:              {0}", GetProperty( "Logo" ) == null ? "未知" : Logo.ToString() );
            output.WriteLine( "  Back:              {0}", GetProperty( "Back" ) == null ? "未知" : Back.ToString() );
            output.WriteLine( "  CP:                {0}", GetProperty( "CP" ) == null ? "未知" : CP.ToString() );
            output.WriteLine( "  Grade:             {0}", GetProperty( "Grade" ) == null ? "未知" : Grade.ToString() );
            output.WriteLine( "  Slogan:            {0}", GetProperty( "Slogan" ) == null ? "未知" : Slogan.ToString() );
            output.WriteLine( "  News:              {0}", GetProperty( "News" ) == null ? "未知" : News.ToString() );
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

            output.WriteLine( "  CharacterGuid:     {0}", GetProperty( "CharacterGuid" ) == null ? "未知" : CharacterGuid.ToString() );
            output.WriteLine( "  FriendGuid:        {0}", GetProperty( "FriendGuid" ) == null ? "未知" : FriendGuid.ToString() );
            output.WriteLine( "  FriendName:        {0}", GetProperty( "FriendName" ) == null ? "未知" : FriendName.ToString() );
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

            output.WriteLine( "  CharacterGuid:        {0}", GetProperty( "CharacterGuid" ) == null ? "未知" : CharacterGuid.ToString() );
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

            output.WriteLine( "  CharacterGuid:        {0}", GetProperty( "CharacterGuid" ) == null ? "未知" : CharacterGuid.ToString() );
            output.WriteLine( "  ChatInfo:        {0}", GetProperty( "ChatInfo" ) == null ? "未知" : ChatInfo.ToString() );
            output.WriteLine( "  ChatTime:        {0}", GetProperty( "ChatTime" ) == null ? "未知" : ChatTime.ToString() );
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

            output.WriteLine( "  CharacterGuidOne:        {0}", GetProperty( "CharacterGuidOne" ) == null ? "未知" : CharacterGuidOne.ToString() );
            output.WriteLine( "  CharacterGuidTwo:        {0}", GetProperty( "CharacterGuidTwo" ) == null ? "未知" : CharacterGuidTwo.ToString() );
            output.WriteLine( "  TradeInfoOne:        {0}", GetProperty( "TradeInfoOne" ) == null ? "未知" : TradeInfoOne.ToString() );
            output.WriteLine( "  TradeInfoTwo:        {0}", GetProperty( "TradeInfoTwo" ) == null ? "未知" : TradeInfoTwo.ToString() );
            output.WriteLine( "  TradeTime:        {0}", GetProperty( "TradeTime" ) == null ? "未知" : TradeTime.ToString() );
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

            output.WriteLine( "  CharacterGuid:        {0}", GetProperty( "CharacterGuid" ) == null ? "未知" : CharacterGuid.ToString() );
            output.WriteLine( "  ItemGuid:        {0}", GetProperty( "ItemGuid" ) == null ? "未知" : ItemGuid.ToString() );
            output.WriteLine( "  ItemInfo:        {0}", GetProperty( "ItemInfo" ) == null ? "未知" : ItemInfo.ToString() );
            output.WriteLine( "  ItemTime:        {0}", GetProperty( "ItemTime" ) == null ? "未知" : ItemTime.ToString() );
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

            output.WriteLine( "  CharacterGuid:        {0}", GetProperty( "CharacterGuid" ) == null ? "未知" : CharacterGuid.ToString() );
            output.WriteLine( "  GMCommandInfo:        {0}", GetProperty( "GMCommandInfo" ) == null ? "未知" : GMCommandInfo.ToString() );
            output.WriteLine( "  GMCommandTime:        {0}", GetProperty( "GMCommandTime" ) == null ? "未知" : GMCommandTime.ToString() );
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

            output.WriteLine( "  SpawnGuid:     {0}", GetProperty( "SpawnGuid" ) == null ? "未知" : SpawnGuid.ToString() );
            output.WriteLine( "  NPCGuid:       {0}", GetProperty( "NPCGuid" ) == null ? "未知" : NPCGuid.ToString() );
            output.WriteLine( "  MapID:         {0}", GetProperty( "MapID" ) == null ? "未知" : MapID.ToString() );
            output.WriteLine( "  PositionX:     {0}", GetProperty( "PositionX" ) == null ? "未知" : PositionX.ToString() );
            output.WriteLine( "  PositionY:     {0}", GetProperty( "PositionY" ) == null ? "未知" : PositionY.ToString() );
            output.WriteLine( "  Direction:     {0}", GetProperty( "Direction" ) == null ? "未知" : Direction.ToString() );
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

            output.WriteLine( "  SpawnGuid:     {0}", GetProperty( "SpawnGuid" ) == null ? "未知" : SpawnGuid.ToString() );
            output.WriteLine( "  MobileGUID:    {0}", GetProperty( "MobileGUID" ) == null ? "未知" : MobileGUID.ToString() );
            output.WriteLine( "  MapID:         {0}", GetProperty( "MapID" ) == null ? "未知" : MapID.ToString() );
            output.WriteLine( "  Count:         {0}", GetProperty( "Count" ) == null ? "未知" : Count.ToString() );
            output.WriteLine( "  Points:        {0}", GetProperty( "Points" ) == null ? "未知" : Points.ToString() );
            output.WriteLine( "  RespawnTime:   {0}", GetProperty( "RespawnTime" ) == null ? "未知" : RespawnTime.ToString() );
        }
        #endregion
    }
}
#endregion