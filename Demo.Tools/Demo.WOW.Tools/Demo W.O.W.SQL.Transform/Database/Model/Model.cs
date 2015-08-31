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
    /// ��Ϸ���˺���Ϣ
    /// </summary>
    public abstract class Accounts : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ�˺ŵ�Ψһ���
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long AccountsGuid { get; set; }

        /// <summary>
        /// ��Ϸ�˺ŵ�����
        /// </summary>
        [Indexed( Unique = true )]
        [Length(64)]
        public abstract string AccountsName { get; set; }

        /// <summary>
        /// ��Ϸ�˺ŵ�����
        /// </summary>
        [Indexed]
        [Length( 32 )]
        public abstract string Password { get; set; }

        /// <summary>
        /// ��Ϸ�˺��е�Ȩ�޵ȼ�
        /// </summary>
        public abstract int GMLevel { get; set; }

        /// <summary>
        /// ��Ϸ�˺��Ƿ��ѵ�½�����������ٴε�½�򶳽�
        /// </summary>
        public abstract bool Locked { get; set; }

        /// <summary>
        /// ��Ϸ�˺��Ƿ��ѷ�ͣ
        /// </summary>
        public abstract bool Banned { get; set; }

        /// <summary>
        /// ��Ϸ�˺Ŵ���������
        /// </summary>
        public abstract DateTime CreateDate { get; set; }

        /// <summary>
        /// ��Ϸ�˺Ŵ����ߵĵ����ʼ�
        /// </summary>
        [Length(50)]
        [Nullable]
        [LoadOnDemand]
        public abstract string Email { get; set; }

        /// <summary>
        /// ��Ϸ�˺Ŵ����ߵĵ����ʼ��Ƿ��Ѽ���
        /// </summary>
        [Nullable]
        [LoadOnDemand]
        public abstract bool ActiveEmail { get; set; }

        /// <summary>
        /// ������Ϸ�˺Ŵ����ߵĵ����ʼ���������(KEY)
        /// </summary>
        [Length(32)]
        [Nullable]
        [LoadOnDemand]
        public abstract string ActiveEmailKey { get; set; }

        /// <summary>
        /// ��Ϸ�˺ż������ʽ(CD-KEY)
        /// </summary>
        [Length(32)]
        [Nullable]
        [LoadOnDemand]
        public abstract string SessionKey { get; set; }

        /// <summary>
        /// ��Ϸ�Ƽ��˵ı�ʾ(ID)
        /// </summary>
        [Nullable]
        [LoadOnDemand]
        public abstract int DonationGuid { get; set; }

        /// <summary>
        /// ��Ϸ�Ƽ��˵��ʺ�����
        /// </summary>
        [Length(64)]
        [Nullable]
        [LoadOnDemand]
        public abstract string Donation { get; set; }

        /// <summary>
        /// ��Ϸ�˺ŵ�½ʧ�ܵĴ���
        /// </summary>
        [Nullable]
        public abstract int FailedLogins { get; set; }

        /// <summary>
        /// ��Ϸ������½��(IP)��ַ(IPv4/IPv6)
        /// </summary>
        [Length(24)]
        [Nullable]
        public abstract string LastIP { get; set; }

        /// <summary>
        /// ��Ϸ������½��ʱ��
        /// </summary>
        [Nullable]
        public abstract DateTime LastLoginDate { get; set; }

        /// <summary>
        /// ��Ϸ����½����Ϸ�������ڵ���
        /// </summary>
        [Nullable]
        public abstract long LastServerGuid { get; set; }

        /// <summary>
        /// ��Ϸ���ʹ�õ���Ϸ����
        /// </summary>
        [Length(64)]
        [Nullable]
        public abstract string LastCharacter { get; set; }

        /// <summary>
        /// �Ƿ�������Ƭ(TBC)��ӵ����
        /// </summary>
        [Nullable]
        public abstract bool IsTBC { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
            IsTBC = true; // ֧������Ƭ

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
    /// ��Ҫ������(IP)��ַ
    /// </summary>
    public abstract class IPBanned : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ҫ���˵�(IP)��ַ(IPv4/IPv6)
        /// </summary>
        [Length(24)]
        public abstract string IPAddress { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ĳ�ʺ���ĳ�������ڴ�����������
    /// </summary>
    public abstract class RealmCharacters : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ������Ψһ���
        /// </summary>
        public abstract long RealmGuid { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        [Length( 64 )]
        public abstract string RealmName { get; set; }

        /// <summary>
        /// ��Ϸ�˺ŵ�Ψһ���
        /// </summary>
        public abstract long AccountsGuid { get; set; }

        /// <summary>
        /// �������ڴ�����������
        /// </summary>
        public abstract byte NumberCharacters { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// �����������Ƶ���б�(��Ϸ�����������������)������
    /// </summary>
    public abstract class RealmList : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��������Ψһ���
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long ServerGuid { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        [Indexed( Unique = true )]
        [Length( 64 )]
        public abstract string ServerName { get; set; }

        /// <summary>
        /// ��������(IP)��ַ(IPv4/IPv6)
        /// </summary>
        [Length(24)]
        public abstract string Host { get; set; }

        /// <summary>
        /// �������Ķ˿�
        /// </summary>
        public abstract int Port { get; set; }

        /// <summary>
        /// ����������Ϸ���� PVP/RP/RPPVP/NORMAL
        /// </summary>
        public abstract int Icon { get; set; }

        /// <summary>
        /// ��������������ɫ(��ʱ��Ҫ��)
        /// </summary>
        public abstract long Color { get; set; }

        /// <summary>
        /// ������������(�й�,̨��...)λ��(��ʱ��Ҫ��)
        /// </summary>
        public abstract long Timezone { get; set; }

        /// <summary>
        /// ��ǰ���������ӵ��������
        /// </summary>
        public abstract long Population { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// ��Ϸ���������
        /// </summary>
        [Indexed( Unique = true )]
        [Length( 64 )]
        public abstract string CharacterName { get; set; }

        /// <summary>
        /// ��Ϸ�����������ʺŵ�ID
        /// </summary>
        [Indexed]
        public abstract long AccountGuid { get; set; }

        /// <summary>
        /// ���������
        /// </summary>
        public abstract int Race { get; set; }

        /// <summary>
        /// �����ְҵ
        /// </summary>
        public abstract int Class { get; set; }

        /// <summary>
        /// ������Ա�
        /// </summary>
        public abstract int Gender { get; set; }

        /// <summary>
        /// ����ģ�
        /// </summary>
        public abstract uint Bytes { get; set; }

        /// <summary>
        /// ����ģ�
        /// </summary>
        public abstract uint Bytes2 { get; set; }
        
        /// <summary>
        /// ����ĵȼ�
        /// </summary>
        public abstract int Level { get; set; }

        /// <summary>
        /// ����ĵȼ�
        /// </summary>
        [Indexed]
        public abstract int MapGuid { get; set; }

        /// <summary>
        /// ���� ���ڵ� X����
        /// </summary>
        public abstract int PositionX { get; set; }

        /// <summary>
        /// ���� ���ڵ� Y����
        /// </summary>
        public abstract float PositionY { get; set; }

        /// <summary>
        /// ���� ���ڵ� Z����
        /// </summary>
        public abstract float PositionZ { get; set; }

        /// <summary>
        /// ���� ���ڵ� ����
        /// </summary>
        public abstract float Orientation { get; set; }

        ///// <summary>
        ///// ���ﵱǰ��HP
        ///// </summary>
        //public abstract float CurrentHP { get; set; }

        ///// <summary>
        ///// ���ﵱǰ��MP
        ///// </summary>
        //public abstract int CurrentMP { get; set; }

        ///// <summary>
        ///// ���������
        ///// </summary>
        //public abstract int Strength { get; set; }

        ///// <summary>
        ///// ����ļ���
        ///// </summary>
        //public abstract int Convergence { get; set; }

        ///// <summary>
        ///// ���������
        ///// </summary>
        //public abstract int Dexterity { get; set; }

        ///// <summary>
        ///// ���������
        ///// </summary>
        //public abstract int Intellect { get; set; }

        ///// <summary>
        ///// ���������
        ///// </summary>
        //public abstract int Charm { get; set; }

        ///// <summary>
        ///// ����ĸо�
        ///// </summary>
        //public abstract int Sense { get; set; }

        ///// <summary>
        ///// �������
        ///// </summary>
        //public abstract int Face { get; set; }

        ///// <summary>
        ///// �����ͷ��
        ///// </summary>
        //public abstract int HairStyle { get; set; }

        ///// <summary>
        ///// ������Ա�
        ///// </summary>
        //public abstract int Sex { get; set; }


        ///// <summary>
        ///// ����ľ���ֵ
        ///// </summary>
        //public abstract int Experience { get; set; }

        ///// <summary>
        ///// ����ļ��ܵ�
        ///// </summary>
        //public abstract int SkillPoint { get; set; }

        ///// <summary>
        ///// �����������
        ///// </summary>
        //public abstract int StatusPoint { get; set; }

        ///// <summary>
        ///// �����ְҵ
        ///// </summary>
        //public abstract int ClassID { get; set; }

        ///// <summary>
        ///// �������ڲ����GUID
        ///// </summary>
        //[Indexed]
        //public abstract int ClanGuid { get; set; }

        ///// <summary> 
        ///// �������ڵĲ���ĵȼ�
        ///// </summary>
        //public abstract int ClanRank { get; set; }

        ///// <summary>
        ///// ���ﵱǰ���ڵĵ�ͼ
        ///// </summary>
        //public abstract int CurrentMap { get; set; }

        ///// <summary>
        ///// ����ľ���
        ///// </summary>
        //public abstract int Stamina { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[Length( 255 )]
        //public abstract string QuickBar { get; set; }

        ///// <summary>
        ///// ����Ļ�������
        ///// </summary>
        //[Length( 255 )]
        //public abstract string BasicSkills { get; set; }

        ///// <summary>
        ///// �����ְҵ����
        ///// </summary>
        //[Length( 255 )]
        //public abstract string ClassSkills { get; set; }

        ///// <summary>
        ///// �����ְҵ���ܵĵȼ�
        ///// </summary>
        //[Length( 255 )]
        //public abstract string ClassSkillsLevel { get; set; }

        ///// <summary>
        ///// �������ڵ���Ϸ��
        ///// </summary>
        //public abstract int Realm { get; set; }

        ///// <summary>
        ///// ���︴����GUID
        ///// </summary>
        //public abstract long RespawnZoneGuid { get; set; }

        /// <summary>
        /// �������������Ϸʱ��
        /// </summary>
        public abstract long TotalTime { get; set; }

        /// <summary>
        /// ��������ʱ����Ϸʱ��(���ڼ��������������Ϸʱ��)
        /// </summary>
        public abstract long LevelTime { get; set; }

        /// <summary>
        /// ����ǳ���ʱ��
        /// </summary>
        public abstract DateTime LogoutTime { get; set; }

        /// <summary>
        /// ������Ƿ���ɾ��
        /// </summary>
        public abstract bool IsDelete { get; set; }

        /// <summary>
        /// ���ｫɾ����ʱ��
        /// </summary>
        [Nullable]
        public abstract DateTime DeleteTime { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Action : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Aura : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Gifts : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Homebind : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Instance : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Inventory : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Kill : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Pet : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Queststatus : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Reputation : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Social : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Spell : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_SpellCooldown : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Ticket : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Tutorial : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long CharacterGuid { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ������ӵ�еĵ���
    /// </summary>
    public abstract class Items : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ���ߵĵ�ΨһGuid��Ϣ
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long ItemGuid { get; set; }

        /// <summary>
        /// ���ߵ�ӵ����
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// ���ߵı��(ģ�͵�ID��)
        /// </summary>
        public abstract int ItemID { get; set; }

        /// <summary>
        /// ���ߵ�����(1 ����  2 ñ�� 3�·� 4���� 5Ь��  6��������  7���� ָ�� ����  8���� 9����)
        /// </summary>
        public abstract int ItemType { get; set; }

        /// <summary>
        /// ���ߵľ�����(�ȼ�1-9)
        /// </summary>
        public abstract int Refine { get; set; }

        /// <summary>
        /// ���ߵ��;ö�
        /// </summary>
        public abstract int Durability { get; set; }

        /// <summary>
        /// ���ߵ�ʹ������
        /// </summary>
        public abstract int Lifespan { get; set; }

        /// <summary>
        /// ���ߵ����ڵ�λ�õı��(С��10�������������)
        /// </summary>
        public abstract int SlotNumber { get; set; }

        /// <summary>
        /// ���ߵ�����
        /// </summary>
        public abstract int Count { get; set; }

        /// <summary>
        /// ���ߵ�״̬(�����Ƿ�)
        /// </summary>
        public abstract int Stats { get; set; }

        /// <summary>
        /// ���ߵĲ��
        /// </summary>
        public abstract bool Socketed { get; set; }

        /// <summary>
        /// ���ߵĹ���
        /// </summary>
        public abstract bool Appraised { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract int GemID{ get; set; }

        /// <summary>
        /// ���ߵ��Ƿ�����ʧ
        /// </summary>
        public abstract bool IsDelete { get; set; }

        /// <summary>
        /// ������ʧ��ʱ��
        /// </summary>
        [Nullable]
        public abstract DateTime DeleteTime { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ������ӵ���еĴ洢��
    /// </summary>
    public abstract class ListStorage : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// �洢���ӵ�����ʺ�
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long AccountGuid { get; set; }

        /// <summary>
        /// ����ڴ洢������ߵ�ǰӵ����
        /// </summary>
        [Indexed]
        public abstract long PreOwnerGuid { get; set; }

        /// <summary>
        /// ���ߵĵ�ΨһGuid��Ϣ
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long ItemGuid { get; set; }

        /// <summary>
        /// ���ߵı��(ģ�͵�ID��)
        /// </summary>
        public abstract int ItemID { get; set; }

        /// <summary>
        /// ���ߵ�����(1 ����  2 ñ�� 3�·� 4���� 5Ь��  6��������  7���� ָ�� ����  8���� 9����)
        /// </summary>
        public abstract int ItemType { get; set; }

        /// <summary>
        /// ���ߵľ�����(�ȼ�1-9)
        /// </summary>
        public abstract int Refine { get; set; }

        /// <summary>
        /// ���ߵ��;ö�
        /// </summary>
        public abstract int Durability { get; set; }

        /// <summary>
        /// ���ߵ�ʹ������
        /// </summary>
        public abstract int Lifespan { get; set; }

        /// <summary>
        /// ���ߵ����ڵ�λ�õı��(С��10�������������)
        /// </summary>
        public abstract int SlotNumber { get; set; }

        /// <summary>
        /// ���ߵ�����
        /// </summary>
        public abstract int Count { get; set; }

        /// <summary>
        /// ���ߵ�״̬(�����Ƿ�)
        /// </summary>
        public abstract int Stats { get; set; }

        /// <summary>
        /// ���ߵĲ��
        /// </summary>
        public abstract bool Socketed { get; set; }

        /// <summary>
        /// ���ߵĹ���
        /// </summary>
        public abstract bool Appraised { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract int GemID{ get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ���岿�������
    /// </summary>
    public abstract class ListClan : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// �����ID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long ClanGuid { get; set; }

        /// <summary>
        /// ���������
        /// </summary>
        [Indexed( Unique = true )]
        [Length( 64 )]
        public abstract string ClanName { get; set; }

        /// <summary>
        /// ����ı�־
        /// </summary>
        public abstract int Logo { get; set; }

        /// <summary>
        /// ����ģ�
        /// </summary>
        public abstract int Back { get; set; }

        /// <summary>
        /// ����ģ�
        /// </summary>
        public abstract int CP { get; set; }

        /// <summary>
        /// ����ĵȼ�
        /// </summary>
        public abstract int Grade { get; set; }

        /// <summary>
        /// ����Ŀں�
        /// </summary>
        [Length( 255 )]
        public abstract string Slogan { get; set; }

        /// <summary>
        /// ���������
        /// </summary>
        [SqlType( SqlType.Text )]
        public abstract string News { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ���ѵ��б�
    /// </summary>
    public abstract class ListFriend : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
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

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ������б�
    /// </summary>
    public abstract class ListQuest : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
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

        #region zh-CHS ���� | en Method
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
    /// ��������ļ�¼
    /// </summary>
    public abstract class CharacterChatLog : FtObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��¼��Ϸ���������
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        #region zh-CHS ö�� | en Enum
        /// <summary>
        /// ����Ƶ��
        /// </summary>
        public enum ChatChannel
        {
            /// <summary>
            /// ����Ƶ��
            /// </summary>
            Whisper = 0x01,
            /// <summary>
            /// ����Ƶ��
            /// </summary>
            Trader = 0x02,
            /// <summary>
            /// �Ŷ�Ƶ��
            /// </summary>
            Party = 0x04,
            /// <summary>
            /// ����Ƶ��
            /// </summary>
            Clan = 0x08
        }
        #endregion

        /// <summary>
        /// ��¼�������Ǹ�Ƶ��
        /// </summary>
        public abstract uint ChatChannelInfo { get; set; }

        /// <summary>
        /// �����¼��������Ϣ
        /// </summary>
        [Length( 1000 )]
        public abstract string ChatInfo { get; set; }

        /// <summary>
        /// �����¼��ʱ��
        /// </summary>
        public abstract DateTime ChatTime { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
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
    /// ���ｻ�׵ļ�¼
    /// </summary>
    public abstract class CharacterTradeLog : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��¼���׵���Ϸ����1
        /// </summary>
        [Indexed]
        public abstract long CharacterGuidOne { get; set; }

        /// <summary>
        /// ��¼���׵���Ϸ����2
        /// </summary>
        [Indexed]
        public abstract long CharacterGuidTwo { get; set; }

        /// <summary>
        /// ���׼�¼��������Ϣ����1
        /// "ItemGuid:OnlyItemGuid;ItemGuid:OnlyItemGuid;...ItemGuid:OnlyItemGuid"
        /// </summary>
        [Length( 1000 )]
        public abstract string TradeInfoOne { get; set; }

        /// <summary>
        /// ���׼�¼��������Ϣ����2
        /// "ItemGuid:OnlyItemGuid;ItemGuid:OnlyItemGuid;...ItemGuid:OnlyItemGuid"
        /// </summary>
        [Length( 1000 )]
        public abstract string TradeInfoTwo { get; set; }

        /// <summary>
        /// ���׼�¼��ʱ��
        /// </summary>
        public abstract DateTime TradeTime { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
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
    /// ������ߵ���ϸ��¼
    /// </summary>
    public abstract class CharacterItemLog : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��¼����ʹ�õ���Ϸ����
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// ��¼�ĵ���Guid��Ϣ
        /// </summary>
        [Indexed]
        public abstract long ItemGuid { get; set; }

        #region zh-CHS ö�� | en Enum
        /// <summary>
        /// ����ʹ�õ���Ϣ
        /// </summary>
        public enum Item
        {
            /// <summary>
            /// ��õ���
            /// </summary>
            Obtain = 0x01,
            /// <summary>
            /// ʹ�õ���
            /// </summary>
            Use = 0x02,
            /// <summary>
            /// ���׵���
            /// </summary>
            Trade = 0x04,
            /// <summary>
            /// ��������
            /// </summary>
            Discard = 0x08
        }
        #endregion

        /// <summary>
        /// ���ߵ�ʹ����Ϣ
        /// </summary>
        public abstract uint ItemInfo { get; set; }

        /// <summary>
        /// ��¼����ʹ�õ�ʱ��
        /// </summary>
        public abstract DateTime ItemTime { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
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
    /// GMʹ���������ϸ��¼
    /// </summary>
    public abstract class GMCommandLog : DataObject, IDumpable
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ��¼ʹ��GM�������Ϸ����
        /// </summary>
        [Indexed]
        public abstract long CharacterGuid { get; set; }

        /// <summary>
        /// ��¼GMʹ�õ�������Ϣ
        /// </summary>
        [Length( 1000 )]
        public abstract string GMCommandInfo { get; set; }

        /// <summary>
        /// ��¼GMʹ��ʹ�������ʱ��
        /// </summary>
        public abstract DateTime GMCommandTime { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
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
    ///  ˢNPC������ǵ�ˢNPC������
    /// </summary>
    public abstract class SpawnNPCs : DataObject
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ˢNPC��GUID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long SpawnGuid { get; set; }
        
        /// <summary>
        /// NPC��GUID
        /// </summary>
        [Indexed]
        public abstract long NPCGuid { get; set; }

        /// <summary>
        /// NPC���ڵ�ͼ��ID
        /// </summary>
        public abstract int MapID { get; set; }

        /// <summary>
        /// NPC�� X ����
        /// </summary>
        public abstract int PositionX { get; set; }

        /// <summary>
        /// NPC�� Y ����
        /// </summary>
        public abstract int PositionY { get; set; }

        /// <summary>
        /// NPC�ķ���
        /// </summary>
        public abstract int Direction { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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
    /// ˢ�ֵ������ǵ�ˢ������
    /// </summary>
    public abstract class SpawnMonsters : DataObject
    {
        #region zh-CHS ���� | en Properties
        /// <summary>
        /// ˢ�ֵ�GUID
        /// </summary>
        [Indexed( Unique = true )]
        public abstract long SpawnGuid { get; set; }

        /// <summary>
        /// �����GUID
        /// </summary>
        [Indexed]
        public abstract long MobileGUID { get; set; }

        /// <summary>
        /// ˢ�ֵ��ͼ��ID
        /// </summary>
        public abstract int MapID { get; set; }

        /// <summary>
        /// ����ˢ�ֵ�����(������ķ�Χ�����ˢ��ˢ�ֵ�)
        /// </summary>
        public abstract int Count { get; set; }

        /// <summary>
        /// ˢ�ֵ�����������λ��x��λ��y(count|x,y|x,y|...|...)����3�����������,�Ǹ�һ�������ǵķ�Χ,�����ڴ����Ƿ�Χ��ˢ��
        /// </summary>
        [SqlType( SqlType.Text )]
        public abstract string Points { get; set; }

        /// <summary>
        /// ˢ���������С����(��Χ�����ڴ˹�������������ˢ��,����ˢ�ֵ�ʱ����)
        /// </summary>
        public abstract int MinRespawn { get; set; }

        /// <summary>
        /// ˢ�ֵ�ʱ����(��ˢ�ֵ�����: �����ǹ���������ˢ�ֵ�ʱ����,��ʱ������������ˢ��ֱ������ˢ�ֵ�����λ��......��)
        /// </summary>
        public abstract int RespawnTime { get; set; }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
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