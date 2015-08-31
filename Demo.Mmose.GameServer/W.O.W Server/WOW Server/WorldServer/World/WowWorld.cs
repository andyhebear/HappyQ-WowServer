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
using System.Diagnostics;
using System.Reflection;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Scripts;
using Demo.Mmose.Core.World;
using Demo.Wow.Database;
using Demo.Wow.Database.Ver1a;
using Demo.Wow.WorldServer.Ability.Skill;
using Demo.Wow.WorldServer.Ability.Spell;
using Demo.Wow.WorldServer.Character;
using Demo.Wow.WorldServer.Common;
using Demo.Wow.WorldServer.Creature;
using Demo.Wow.WorldServer.DBC;
using Demo.Wow.WorldServer.Item;
using Demo.Wow.WorldServer.Server;
using Demo.Wow.WorldServer.WorldServer.Common;
using DevExpress.Xpo;
using Demo.Wow.WorldServer.Object;
using Demo.Mmose.Core.Timer;
using Demo.Mmose.Core.Common.LockFree;
using System.Collections.Generic;
using Demo.Mmose.Core.Common.SupportSlice;
using Demo.Mmose.Core.Common.Atom;
using Demo.Wow.WorldServer.Entity;
#endregion

namespace Demo.Wow.WorldServer.World
{
    /// <summary>
    /// 
    /// </summary>
    public class WowWorld : MmorpgWorld<WowMap, WowItem, WowItemTemplate, WowGameObject, WowGameObjectTemplate, WowCreature, WowCreatureTemplate, WowCharacter>
    {
        #region zh-CHS 内部保护属性 | en Protected Internal Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowCharacterLevelInfoHandler m_GlobalLevelInfo = new WowCharacterLevelInfoHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal WowCharacterLevelInfoHandler GlobalLevelInfo
        {
            get { return m_GlobalLevelInfo; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowCharacterCreateInfoHandler m_GlobalCreateInfo = new WowCharacterCreateInfoHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal WowCharacterCreateInfoHandler GlobalCreateInfo
        {
            get { return m_GlobalCreateInfo; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowSkillTemplateHandler m_GlobalSkillTemplates = new WowSkillTemplateHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal WowSkillTemplateHandler GlobalSkillTemplates
        {
            get { return m_GlobalSkillTemplates; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowSpellTemplateManager m_GlobalSpellTemplates = new WowSpellTemplateManager();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal WowSpellTemplateManager GlobalSpellTemplates
        {
            get { return m_GlobalSpellTemplates; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private GlobalCharacterManager m_GlobalPlayerInfo = new GlobalCharacterManager();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal GlobalCharacterManager GlobalPlayerInfo
        {
            get { return m_GlobalPlayerInfo; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowExplorationRewardHandler m_GlobalExplorationReward = new WowExplorationRewardHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal WowExplorationRewardHandler GlobalExplorationReward
        {
            get { return m_GlobalExplorationReward; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowGraveyardInfoHandler m_GlobalGraveyardInfo = new WowGraveyardInfoHandler();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        internal WowGraveyardInfoHandler GlobalGraveyardInfo
        {
            get { return m_GlobalGraveyardInfo; }
        }
        #endregion

        #region zh-CHS InitOnceWorld方法 | en Static Method

        #region zh-CHS 读取人物等级信息和创建信息 方法 | en
        /// <summary>
        /// 读取人物等级信息和创建信息
        /// </summary>
        private void LoadPlayerCreateInfoAndLevelInfo()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码
            Type createInfoType = ProcessServer.ScriptAssemblyInfo.FindTypeByFullName( "Demo.WOW.Script.Character.InitCreateInfo" );
            if ( createInfoType != null )
            {
                MethodInfo createInfoMethod = createInfoType.GetMethod( "InitWowCharacterCreateInfo", BindingFlags.Static | BindingFlags.Public );
                if ( createInfoMethod != null )
                {
                    object[] parameters = new object[1];
                    parameters[0] = this.m_GlobalCreateInfo;
                    createInfoMethod.Invoke( null, parameters );
                }
                else
                    Debug.WriteLine( "WowWorld.LoadPlayerCreateInfoAndLevelInfo(...) - createInfoMethod == null error!" );
            }
            else
                Debug.WriteLine( "WowWorld.LoadPlayerCreateInfoAndLevelInfo(...) - createInfoType == null error!" );
            
            // 速度太慢需要改进
            Type levelInfoType = ProcessServer.ScriptAssemblyInfo.FindTypeByFullName( "Demo.WOW.Script.Character.InitLevelInfo" );
            if ( levelInfoType != null )
            {
                MethodInfo levelInfoMethod = levelInfoType.GetMethod( "InitWowCharacterLevelInfo", BindingFlags.Static | BindingFlags.Public );
                if ( levelInfoMethod != null )
                {
                    object[] parameters = new object[1];
                    parameters[0] = this.m_GlobalLevelInfo;
                    levelInfoMethod.Invoke( null, parameters );
                }
                else
                    Debug.WriteLine( "WowWorld.LoadPlayerCreateInfoAndLevelInfo(...) - levelInfoMethod == null error!" );
            }
            else
                Debug.WriteLine( "WowWorld.LoadPlayerCreateInfoAndLevelInfo(...) - levelInfoType == null error!" );

            LOGs.WriteLine( LogMessageType.MSG_INFO, "Wow世界：读取脚本内全部的 人物等级信息和创建信息 完成" );
        }
        #endregion

        #region zh-CHS 人物模板信息和物品模板信息 方法 | en
        /// <summary>
        /// 人物模板信息和物品模板信息
        /// </summary>
        private void LoadItemTemplateAndCreatureTemplate()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取人物模板信息和物品模板信息

            foreach ( Assembly assembly in ProcessServer.ScriptAssemblyInfo.ScriptAssembly )
            {
                TypeCache typeCache = ProcessServer.ScriptAssemblyInfo.GetTypeCache( assembly );
                Type[] typeArray = typeCache.Types;

                foreach ( Type typeItem in typeArray )
                {
                    if ( typeItem.IsSubclassOf( typeof( WowCreatureTemplate ) ) )
                    {
                        try
                        {
                            ConstructorInfo[] infoArray = typeItem.GetConstructors();
                            WowCreatureTemplate creatureTemplate = (WowCreatureTemplate)infoArray[0].Invoke( null );
                            if ( creatureTemplate.Serial == 0 )
                                continue;

                            this.CreatureTemplateManager.AddCreatureTemplate( creatureTemplate.Serial, creatureTemplate );
                        }
                        catch ( Exception )
                        {
                            Debug.WriteLine( "Program.LoadItemTemplateAndCreatureTemplate(...) - WowCreatureTemplate constructor of {0} Exception error!", typeItem.ToString() );
                        }
                    }
                    else if ( typeItem.IsSubclassOf( typeof( WowItemTemplate ) ) )
                    {
                        try
                        {
                            ConstructorInfo[] infoArray = typeItem.GetConstructors();
                            WowItemTemplate itemTemplate = (WowItemTemplate)infoArray[0].Invoke( null );

                            if ( itemTemplate.Serial == 0 )
                                continue;

                            this.ItemTemplateManager.AddItemTemplate( itemTemplate.Serial, itemTemplate );
                        }
                        catch ( Exception )
                        {
                            Debug.WriteLine( "Program.LoadItemTemplateAndCreatureTemplate(...) - WowCreatureTemplate constructor of {0} Exception error!", typeItem.ToString() );
                        }
                    }
                }
            }

            LOGs.WriteLine( LogMessageType.MSG_INFO, "Wow世界：读取脚本内全部的 人物模板信息和物品模板信息 完成" );
        }
        #endregion

        #region zh-CHS 人物技能模板信息和魔法模板信息 方法 | en
        /// <summary>
        /// 人物技能模板信息和魔法模板信息
        /// </summary>
        private void LoadSkillTemplateAndSpellTemplate()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始人物技能模板信息和魔法模板信息

            for ( uint iIndex = 0; iIndex < DBCInstances.SkillLineEntry.Count; ++iIndex )
            {
                SkillLineEntry skillLineEntry = DBCInstances.SkillLineEntry.LookupRowEntry( iIndex );
                if ( skillLineEntry == null )
                    continue;

                WowSkillTemplate wowSkillTemplate = new WowSkillTemplate();
                wowSkillTemplate.Serial = skillLineEntry.ID;

                m_GlobalSkillTemplates.AddSkillTemplate( wowSkillTemplate.Serial, wowSkillTemplate );
            }

            for ( uint iIndex = 0; iIndex < DBCInstances.SpellEntry.Count; ++iIndex )
            {
                SpellEntry spellEntry = DBCInstances.SpellEntry.LookupRowEntry( iIndex );
                if ( spellEntry == null )
                    continue;

                WowSpellTemplate wowSpellTemplate = new WowSpellTemplate();
                wowSpellTemplate.Serial = spellEntry.ID;

                m_GlobalSpellTemplates.AddSpellTemplate( wowSpellTemplate.Serial, wowSpellTemplate );
            }

            LOGs.WriteLine( LogMessageType.MSG_INFO, "Wow世界：读取脚本内全部的 人物技能模板信息和魔法模板信息 完成" );
        }
        #endregion

        #region zh-CHS 读取墓地信息 方法 | en
        /// <summary>
        /// 
        /// </summary>
        private void LoadGraveyardInfo()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码

            Type createInfoType = ProcessServer.ScriptAssemblyInfo.FindTypeByFullName( "Demo.WOW.Script.Util.InitGraveyardInfo" );
            if ( createInfoType != null )
            {
                MethodInfo createInfoMethod = createInfoType.GetMethod( "InitWowGraveyardInfo", BindingFlags.Static | BindingFlags.Public );
                if ( createInfoMethod != null )
                {
                    object[] parameters = new object[1];
                    parameters[0] = this.m_GlobalGraveyardInfo;
                    createInfoMethod.Invoke( null, parameters );
                }
                else
                    Debug.WriteLine( "Program.LoadGraveyardInfo(...) - createInfoMethod == null error!" );
            }
            else
                Debug.WriteLine( "Program.LoadGraveyardInfo(...) - createInfoType == null error!" );

            // 获取墓地的位置信息
            foreach ( GraveyardInfo graveyardInfo in this.m_GlobalGraveyardInfo.ToArray() )
            {
                WorldSafeLocsEntry worldSafeLocsEntry = DBCInstances.WorldSafeLocsEntry.LookupIDEntry( graveyardInfo.GraveyardId );
                if ( worldSafeLocsEntry == null )
                    continue;
                else
                {
                    graveyardInfo.GraveyardX = worldSafeLocsEntry.m_X;
                    graveyardInfo.GraveyardY = worldSafeLocsEntry.m_Y;
                    graveyardInfo.GraveyardZ = worldSafeLocsEntry.m_Z;
                    graveyardInfo.GraveyardName = worldSafeLocsEntry.m_Name;
                    graveyardInfo.GraveyardMap = worldSafeLocsEntry.m_MapId;
                }
            }
        }
        #endregion

        #region zh-CHS 读取探索酬劳信息 方法 | en
        /// <summary>
        /// 探索酬劳
        /// </summary>
        private void LoadExplorationReward()
        {
            //////////////////////////////////////////////////////////////////////////
            // 开始在编译后的程序集合内获取密码

            Type createInfoType = ProcessServer.ScriptAssemblyInfo.FindTypeByFullName( "Demo.WOW.Script.Character.InitExplorationRewardInfo" );
            if ( createInfoType != null )
            {
                MethodInfo createInfoMethod = createInfoType.GetMethod( "InitWowExplorationReward", BindingFlags.Static | BindingFlags.Public );
                if ( createInfoMethod != null )
                {
                    object[] parameters = new object[1];
                    parameters[0] = this.m_GlobalExplorationReward;
                    createInfoMethod.Invoke( null, parameters );
                }
                else
                    Debug.WriteLine( "Program.LoadExplorationReward(...) - createInfoMethod == null error!" );
            }
            else
                Debug.WriteLine( "Program.LoadExplorationReward(...) - createInfoType == null error!" );
        }
        #endregion

        #region zh-CHS 读取全部人物信息 | en 

        /// </summary>
        /// 
        /// </summary>
        private void LoadGlobalPlayerInfo()
        {
            WaitExecuteInfo<ExecuteInfoNull> waitExecuteInfo = new WaitExecuteInfo<ExecuteInfoNull>( ExecuteInfoNull.NULL, this.SQL_LoadGlobalPlayerInfo );

            base.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        #endregion    /// <summary>

        #region zh-CHS 读取全部人物尸体信息 | en

        /// </summary>
        /// 
        /// </summary>
        private void LoadGlobalCorpseInfo()
        {
            WaitExecuteInfo<ExecuteInfoNull> waitExecuteInfo = new WaitExecuteInfo<ExecuteInfoNull>( ExecuteInfoNull.NULL, this.SQL_LoadGlobalCorpseInfo );

            base.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        #endregion    /// <summary>

        #region zh-CHS 读取全部拍卖系统信息 | en

        /// </summary>
        /// 
        /// </summary>
        private void LoadGlobalAuctionHouse()
        {
            WaitExecuteInfo<ExecuteInfoNull> waitExecuteInfo = new WaitExecuteInfo<ExecuteInfoNull>( ExecuteInfoNull.NULL, this.SQL_LoadGlobalAuctionHouse );

            base.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        #endregion    /// <summary>

        #region zh-CHS 读取全部邮件系统信息 | en

        /// </summary>
        /// 
        /// </summary>
        private void LoadGlobalMailInfo()
        {
            WaitExecuteInfo<ExecuteInfoNull> waitExecuteInfo = new WaitExecuteInfo<ExecuteInfoNull>( ExecuteInfoNull.NULL, this.SQL_LoadGlobalMailInfo );

            base.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        #endregion    /// <summary>

        #region zh-CHS 读取全部掉落物品信息 | en

        /// </summary>
        /// 
        /// </summary>
        private void LoadGlobalPickpocketing()
        {
            WaitExecuteInfo<ExecuteInfoNull> waitExecuteInfo = new WaitExecuteInfo<ExecuteInfoNull>( ExecuteInfoNull.NULL, this.SQL_LoadGlobalPickpocketing );

            base.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        #endregion    /// <summary>

        #region zh-CHS 读取全部怪物刷新系统 | en

        /// </summary>
        /// 
        /// </summary>
        private void LoadCreatureRespawn()
        {
            WaitExecuteInfo<ExecuteInfoNull> waitExecuteInfo = new WaitExecuteInfo<ExecuteInfoNull>( ExecuteInfoNull.NULL, this.SQL_LoadCreatureRespawn );

            base.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        #endregion
        /// <summary>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        internal void InitOnceWorld( object sender, BaseWorldEventArgs eventArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 仅仅是预编译脚本

            if ( Program.IsOnlyBuildScript == true )
                return;

            //////////////////////////////////////////////////////////////////////////
            // 开始读取DBC文件信息

            //DBCInstances.LoadDBCFiles( "..\\DBCFiles\\" );

            //////////////////////////////////////////////////////////////////////////
            // 开始读取人物等级上升时的信息和人物创建时的信息

            //LoadPlayerCreateInfoAndLevelInfo();

            //////////////////////////////////////////////////////////////////////////
            // 开始人物模板信息和物品模板信息

            LoadItemTemplateAndCreatureTemplate();

            //////////////////////////////////////////////////////////////////////////
            // 读取墓地信息

            LoadGraveyardInfo();

            //////////////////////////////////////////////////////////////////////////
            // 读取探索酬劳信息

            LoadExplorationReward();

            //////////////////////////////////////////////////////////////////////////
            // 开始读取全部人物信息

            LoadGlobalPlayerInfo();

            //////////////////////////////////////////////////////////////////////////
            // 读取怪物刷新系统信息

            LoadCreatureRespawn();

            //////////////////////////////////////////////////////////////////////////
            // 读取尸体信息(Corpse)

            LoadGlobalCorpseInfo();

            //////////////////////////////////////////////////////////////////////////
            // 读取掉落物品信息(Pickpocketing)

            LoadGlobalPickpocketing();

            //////////////////////////////////////////////////////////////////////////
            // 读取拍卖系统信息(AuctionHouse)

            LoadGlobalAuctionHouse();

            //////////////////////////////////////////////////////////////////////////
            // 读取邮件系统信息(Mail)

            LoadGlobalMailInfo();

            //////////////////////////////////////////////////////////////////////////
            // 读取船舶/飞艇运行信息(可能不需要了)

            // 。。。

            //////////////////////////////////////////////////////////////////////////
            // 开始连接Realm端口
            string strHostNamePort = ProcessServer.ConfigInfo.WowConfig.RealmServerHost + ":" + ProcessServer.ConfigInfo.WowConfig.RealmServerPort;

            if ( Program.RealmServerConnecter.StartConnectServer( strHostNamePort ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "连接(RealmServer)IP地址与端口：{0} 失败!", strHostNamePort );
                return;
            }

            //////////////////////////////////////////////////////////////////////////
            // 开始更新世界(每秒跟新一次)

            base.StartUpdateWorld( TimeSpan.FromSeconds( 1.0 ) );
        }

        #endregion

        #region zh-CHS WorldSlice方法 | en Static Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void WorldSlice( object sender, BaseWorldEventArgs e )
        {
            //////////////////////////////////////////////////////////////////////////
            // 怪物攻防计算运行信息

            // 。。。
        }

        #endregion

        #region zh-CHS SQL方法 | en SQL Methods

        /// <summary>
        /// 
        /// </summary>
        private void SQL_LoadGlobalPlayerInfo( ExecuteInfoNull sqlInfo )
        {
            XPQuery<CharacterBase> characters = new XPQuery<CharacterBase>( OneDatabase.Session );

            var characterList = from character in characters
                                select character;

            foreach ( CharacterBase character in characterList )
            {
                WowCharacter wowPlayerInfo = new WowCharacter();

                wowPlayerInfo.Serial = character.Oid;
                wowPlayerInfo.CharacterGuid = character.Oid;
                wowPlayerInfo.Name = character.CharacterName;
                wowPlayerInfo.AccountGuid = character.Account.Oid;
                wowPlayerInfo.IsBanned = character.IsBanned;

                m_GlobalPlayerInfo.AddPlayerInfo( wowPlayerInfo.Name, wowPlayerInfo.Serial, wowPlayerInfo );
            }

            LOGs.WriteLine( LogMessageType.MSG_INFO, "WOW帐号：读取数据库内全部的 玩家信息 完成" );
        }

        /// <summary>
        /// 
        /// </summary>
        private void SQL_LoadCreatureRespawn( ExecuteInfoNull sqlInfo )
        {
            XPQuery<CreatureBase> creatures = new XPQuery<CreatureBase>( OneDatabase.Session );

            var creatureList = from creature in creatures
                                select creature;

            foreach ( CreatureBase creature in creatureList )
            {
                WowCreature wowPlayerInfo = new WowCreature();

                //wowPlayerInfo.Name = creature.N;
                //wowPlayerInfo.Serial = creature.AccountGuid;
                //wowPlayerInfo.Password = creature.Password;
                //wowPlayerInfo.Locked = creature.IsLocked;
                //wowPlayerInfo.Banned = creature.IsBanned;

                //m_Glob.AddPlayerInfo( wowPlayerInfo.Name, wowPlayerInfo );
            }

            LOGs.WriteLine( LogMessageType.MSG_INFO, "WOW帐号：读取数据库内全部的 怪物刷新系统 完成" );
        }

        /// <summary>
        /// 
        /// </summary>
        private void SQL_LoadGlobalAuctionHouse( ExecuteInfoNull sqlInfo )
        {
            XPQuery<AuctionHouse> auctionHouses = new XPQuery<AuctionHouse>( OneDatabase.Session );

            var auctionHouseList = from auctionHouse in auctionHouses
                               select auctionHouse;

            foreach ( AuctionHouse auctionHouse in auctionHouseList )
            {
                //WowCreature wowPlayerInfo = new WowCreature();

                //wowPlayerInfo.Name = creature.N;
                //wowPlayerInfo.Serial = creature.AccountGuid;
                //wowPlayerInfo.Password = creature.Password;
                //wowPlayerInfo.Locked = creature.IsLocked;
                //wowPlayerInfo.Banned = creature.IsBanned;

                //m_Glob.AddPlayerInfo( wowPlayerInfo.Name, wowPlayerInfo );
            }

            LOGs.WriteLine( LogMessageType.MSG_INFO, "WOW帐号：读取数据库内全部的 拍卖系统 完成" );
        }

        /// <summary>
        /// 
        /// </summary>
        private void SQL_LoadGlobalMailInfo( ExecuteInfoNull sqlInfo )
        {
            XPQuery<Mail> mails = new XPQuery<Mail>( OneDatabase.Session );

            var mailList = from mail in mails
                                   select mail;

            foreach ( Mail mail in mailList )
            {
                //WowCreature wowPlayerInfo = new WowCreature();

                //wowPlayerInfo.Name = creature.N;
                //wowPlayerInfo.Serial = creature.AccountGuid;
                //wowPlayerInfo.Password = creature.Password;
                //wowPlayerInfo.Locked = creature.IsLocked;
                //wowPlayerInfo.Banned = creature.IsBanned;

                //m_Glob.AddPlayerInfo( wowPlayerInfo.Name, wowPlayerInfo );
            }

            LOGs.WriteLine( LogMessageType.MSG_INFO, "WOW帐号：读取数据库内全部的 邮件系统 完成" );
        }

        /// <summary>
        /// 
        /// </summary>
        private void SQL_LoadGlobalCorpseInfo( ExecuteInfoNull sqlInfo )
        {
            XPQuery<Corpse> corpses = new XPQuery<Corpse>( OneDatabase.Session );

            var corpseList = from corpse in corpses
                             select corpse;

            foreach ( Corpse corpse in corpseList )
            {
                //WowCreature wowPlayerInfo = new WowCreature();

                //wowPlayerInfo.Name = creature.N;
                //wowPlayerInfo.Serial = creature.AccountGuid;
                //wowPlayerInfo.Password = creature.Password;
                //wowPlayerInfo.Locked = creature.IsLocked;
                //wowPlayerInfo.Banned = creature.IsBanned;

                //m_Glob.AddPlayerInfo( wowPlayerInfo.Name, wowPlayerInfo );
            }

            LOGs.WriteLine( LogMessageType.MSG_INFO, "WOW帐号：读取数据库内全部的 玩家尸体 完成" );
        }

        /// <summary>
        /// 
        /// </summary>
        private void SQL_LoadGlobalPickpocketing( ExecuteInfoNull sqlInfo )
        {
            //XPQuery<> mails = new XPQuery<>( OneDatabase.Session );

            //var mailList = from mail in mails
            //               select mail;

            //foreach (   mail in mailList )
            //{
            //    //WowCreature wowPlayerInfo = new WowCreature();

            //    //wowPlayerInfo.Name = creature.N;
            //    //wowPlayerInfo.Serial = creature.AccountGuid;
            //    //wowPlayerInfo.Password = creature.Password;
            //    //wowPlayerInfo.Locked = creature.IsLocked;
            //    //wowPlayerInfo.Banned = creature.IsBanned;

            //    //m_Glob.AddPlayerInfo( wowPlayerInfo.Name, wowPlayerInfo );
            //}

            LOGs.WriteLine( LogMessageType.MSG_INFO, "WOW帐号：读取数据库内全部的 怪物掉落信息 完成" );
        }

        #endregion
    }
}
#endregion