using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Common;
using Demo.Wow.WorldServer.Character;

namespace Demo.Wow.Script.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class InitLevelInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public const int PLAYER_MAX_LEVEL = 80;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlayerCreateInfoManager"></param>
        public static void InitWowCharacterLevelInfo( WowCharacterLevelInfoHandler playerLevelStatsHandler )
        {
            #region zh-CHS 种族 血精灵 类 | en Race_BloodElf Class
            // Race_BloodElf
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_BloodElf_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_BloodElf_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_BloodElf_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceBloodElf.LevelUp( Race_BloodElf_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_BloodElf_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_BloodElf_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.BloodElf, (uint)WowClasse.Druid, Race_BloodElf_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_BloodElf_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_BloodElf_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_BloodElf_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceBloodElf.LevelUp( Race_BloodElf_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_BloodElf_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_BloodElf_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.BloodElf, (uint)WowClasse.Hunter, Race_BloodElf_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_BloodElf_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_BloodElf_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_BloodElf_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceBloodElf.LevelUp( Race_BloodElf_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_BloodElf_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_BloodElf_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.BloodElf, (uint)WowClasse.Mage, Race_BloodElf_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_BloodElf_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_BloodElf_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_BloodElf_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceBloodElf.LevelUp( Race_BloodElf_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_BloodElf_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_BloodElf_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.BloodElf, (uint)WowClasse.Paladin, Race_BloodElf_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_BloodElf_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_BloodElf_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_BloodElf_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceBloodElf.LevelUp( Race_BloodElf_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_BloodElf_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_BloodElf_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.BloodElf, (uint)WowClasse.Priest, Race_BloodElf_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_BloodElf_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_BloodElf_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_BloodElf_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceBloodElf.LevelUp( Race_BloodElf_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_BloodElf_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_BloodElf_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.BloodElf, (uint)WowClasse.Rogue, Race_BloodElf_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_BloodElf_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_BloodElf_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_BloodElf_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceBloodElf.LevelUp( Race_BloodElf_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_BloodElf_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_BloodElf_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.BloodElf, (uint)WowClasse.Shaman, Race_BloodElf_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_BloodElf_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_BloodElf_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_BloodElf_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceBloodElf.LevelUp( Race_BloodElf_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_BloodElf_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_BloodElf_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.BloodElf, (uint)WowClasse.Warlock, Race_BloodElf_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_BloodElf_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_BloodElf_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_BloodElf_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceBloodElf.LevelUp( Race_BloodElf_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_BloodElf_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_BloodElf_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.BloodElf;
                        Race_BloodElf_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_BloodElf_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.BloodElf, (uint)WowClasse.Warrior, Race_BloodElf_Classe_Warrior_LevelInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 德莱尼 类 | en Race_Draenei Class
            // Race_Draenei
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_Draenei_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Draenei_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Draenei_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDraenei.LevelUp( Race_Draenei_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_Draenei_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Draenei_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Draenei, (uint)WowClasse.Druid, Race_Draenei_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_Draenei_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Draenei_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Draenei_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDraenei.LevelUp( Race_Draenei_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_Draenei_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Draenei_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Draenei, (uint)WowClasse.Hunter, Race_Draenei_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_Draenei_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Draenei_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Draenei_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDraenei.LevelUp( Race_Draenei_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_Draenei_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Draenei_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Draenei, (uint)WowClasse.Mage, Race_Draenei_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_Draenei_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Draenei_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Draenei_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDraenei.LevelUp( Race_Draenei_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_Draenei_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Draenei_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Draenei, (uint)WowClasse.Paladin, Race_Draenei_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_Draenei_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Draenei_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Draenei_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDraenei.LevelUp( Race_Draenei_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_Draenei_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Draenei_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Draenei, (uint)WowClasse.Priest, Race_Draenei_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_Draenei_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Draenei_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Draenei_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDraenei.LevelUp( Race_Draenei_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_Draenei_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Draenei_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Draenei, (uint)WowClasse.Rogue, Race_Draenei_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_Draenei_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Draenei_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Draenei_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDraenei.LevelUp( Race_Draenei_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_Draenei_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Draenei_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Draenei, (uint)WowClasse.Shaman, Race_Draenei_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_Draenei_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Draenei_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Draenei_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDraenei.LevelUp( Race_Draenei_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_Draenei_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Draenei_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Draenei, (uint)WowClasse.Warlock, Race_Draenei_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_Draenei_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Draenei_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Draenei_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDraenei.LevelUp( Race_Draenei_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_Draenei_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Draenei_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Draenei;
                        Race_Draenei_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Draenei_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Draenei, (uint)WowClasse.Warrior, Race_Draenei_Classe_Warrior_LevelInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 矮人 类 | en Race_Dwarf Class
            // Race_Dwarf
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_Dwarf_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Dwarf_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Dwarf_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDwarf.LevelUp( Race_Dwarf_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_Dwarf_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Dwarf_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Dwarf, (uint)WowClasse.Druid, Race_Dwarf_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_Dwarf_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Dwarf_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Dwarf_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDwarf.LevelUp( Race_Dwarf_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_Dwarf_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Dwarf_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Dwarf, (uint)WowClasse.Hunter, Race_Dwarf_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_Dwarf_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Dwarf_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Dwarf_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDwarf.LevelUp( Race_Dwarf_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_Dwarf_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Dwarf_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Dwarf, (uint)WowClasse.Mage, Race_Dwarf_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_Dwarf_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Dwarf_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Dwarf_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDwarf.LevelUp( Race_Dwarf_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_Dwarf_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Dwarf_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Dwarf, (uint)WowClasse.Paladin, Race_Dwarf_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_Dwarf_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Dwarf_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Dwarf_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDwarf.LevelUp( Race_Dwarf_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_Dwarf_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Dwarf_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Dwarf, (uint)WowClasse.Priest, Race_Dwarf_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_Dwarf_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Dwarf_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Dwarf_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDwarf.LevelUp( Race_Dwarf_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_Dwarf_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Dwarf_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Dwarf, (uint)WowClasse.Rogue, Race_Dwarf_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_Dwarf_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Dwarf_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Dwarf_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDwarf.LevelUp( Race_Dwarf_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_Dwarf_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Dwarf_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Dwarf, (uint)WowClasse.Shaman, Race_Dwarf_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_Dwarf_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Dwarf_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Dwarf_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDwarf.LevelUp( Race_Dwarf_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_Dwarf_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Dwarf_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Dwarf, (uint)WowClasse.Warlock, Race_Dwarf_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_Dwarf_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Dwarf_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Dwarf_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceDwarf.LevelUp( Race_Dwarf_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_Dwarf_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Dwarf_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Dwarf;
                        Race_Dwarf_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Dwarf_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Dwarf, (uint)WowClasse.Warrior, Race_Dwarf_Classe_Warrior_LevelInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 矮人 类 | en Race_Gnome Class
            // Race_Gnome
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_Gnome_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Gnome_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Gnome_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceGnome.LevelUp( Race_Gnome_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_Gnome_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Gnome_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Gnome, (uint)WowClasse.Druid, Race_Gnome_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_Gnome_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Gnome_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Gnome_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceGnome.LevelUp( Race_Gnome_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_Gnome_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Gnome_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Gnome, (uint)WowClasse.Hunter, Race_Gnome_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_Gnome_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Gnome_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Gnome_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceGnome.LevelUp( Race_Gnome_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_Gnome_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Gnome_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Gnome, (uint)WowClasse.Mage, Race_Gnome_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_Gnome_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Gnome_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Gnome_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceGnome.LevelUp( Race_Gnome_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_Gnome_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Gnome_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Gnome, (uint)WowClasse.Paladin, Race_Gnome_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_Gnome_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Gnome_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Gnome_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceGnome.LevelUp( Race_Gnome_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_Gnome_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Gnome_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Gnome, (uint)WowClasse.Priest, Race_Gnome_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_Gnome_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Gnome_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Gnome_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceGnome.LevelUp( Race_Gnome_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_Gnome_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Gnome_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Gnome, (uint)WowClasse.Rogue, Race_Gnome_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_Gnome_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Gnome_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Gnome_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceGnome.LevelUp( Race_Gnome_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_Gnome_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Gnome_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Gnome, (uint)WowClasse.Shaman, Race_Gnome_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_Gnome_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Gnome_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Gnome_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceGnome.LevelUp( Race_Gnome_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_Gnome_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Gnome_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Gnome, (uint)WowClasse.Warlock, Race_Gnome_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_Gnome_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Gnome_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Gnome_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceGnome.LevelUp( Race_Gnome_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_Gnome_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Gnome_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Gnome;
                        Race_Gnome_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Gnome_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Gnome, (uint)WowClasse.Warrior, Race_Gnome_Classe_Warrior_LevelInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 人类 类 | en Race_Human Class
            // Race_Human
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_Human_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Human_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Human_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceHuman.LevelUp( Race_Human_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_Human_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Human_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Human, (uint)WowClasse.Druid, Race_Human_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_Human_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Human_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Human_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceHuman.LevelUp( Race_Human_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_Human_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Human_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Human, (uint)WowClasse.Hunter, Race_Human_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_Human_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Human_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Human_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceHuman.LevelUp( Race_Human_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_Human_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Human_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Human, (uint)WowClasse.Mage, Race_Human_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_Human_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Human_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Human_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceHuman.LevelUp( Race_Human_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_Human_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Human_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Human, (uint)WowClasse.Paladin, Race_Human_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_Human_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Human_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Human_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceHuman.LevelUp( Race_Human_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_Human_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Human_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Human, (uint)WowClasse.Priest, Race_Human_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_Human_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Human_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Human_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceHuman.LevelUp( Race_Human_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_Human_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Human_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Human, (uint)WowClasse.Rogue, Race_Human_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_Human_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Human_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Human_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceHuman.LevelUp( Race_Human_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_Human_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Human_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Human, (uint)WowClasse.Shaman, Race_Human_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_Human_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Human_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Human_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceHuman.LevelUp( Race_Human_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_Human_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Human_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Human, (uint)WowClasse.Warlock, Race_Human_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_Human_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Human_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Human_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceHuman.LevelUp( Race_Human_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_Human_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Human_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Human;
                        Race_Human_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Human_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Human, (uint)WowClasse.Warrior, Race_Human_Classe_Warrior_LevelInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 暗夜精灵 类 | en Race_Nightelf Class
            // Race_Nightelf
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_Nightelf_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Nightelf_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Nightelf_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceNightelf.LevelUp( Race_Nightelf_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_Nightelf_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Nightelf_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Nightelf, (uint)WowClasse.Druid, Race_Nightelf_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_Nightelf_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Nightelf_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Nightelf_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceNightelf.LevelUp( Race_Nightelf_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_Nightelf_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Nightelf_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Nightelf, (uint)WowClasse.Hunter, Race_Nightelf_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_Nightelf_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Nightelf_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Nightelf_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceNightelf.LevelUp( Race_Nightelf_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_Nightelf_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Nightelf_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Nightelf, (uint)WowClasse.Mage, Race_Nightelf_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_Nightelf_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Nightelf_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Nightelf_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceNightelf.LevelUp( Race_Nightelf_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_Nightelf_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Nightelf_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Nightelf, (uint)WowClasse.Paladin, Race_Nightelf_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_Nightelf_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Nightelf_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Nightelf_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceNightelf.LevelUp( Race_Nightelf_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_Nightelf_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Nightelf_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Nightelf, (uint)WowClasse.Priest, Race_Nightelf_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_Nightelf_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Nightelf_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Nightelf_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceNightelf.LevelUp( Race_Nightelf_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_Nightelf_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Nightelf_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Nightelf, (uint)WowClasse.Rogue, Race_Nightelf_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_Nightelf_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Nightelf_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Nightelf_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceNightelf.LevelUp( Race_Nightelf_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_Nightelf_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Nightelf_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Nightelf, (uint)WowClasse.Shaman, Race_Nightelf_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_Nightelf_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Nightelf_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Nightelf_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceNightelf.LevelUp( Race_Nightelf_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_Nightelf_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Nightelf_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Nightelf, (uint)WowClasse.Warlock, Race_Nightelf_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_Nightelf_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Nightelf_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Nightelf_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceNightelf.LevelUp( Race_Nightelf_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_Nightelf_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Nightelf_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Nightelf;
                        Race_Nightelf_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Nightelf_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Nightelf, (uint)WowClasse.Warrior, Race_Nightelf_Classe_Warrior_LevelInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 兽人 类 | en Race_Orc Class
            // Race_Orc
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_Orc_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Orc_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Orc_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceOrc.LevelUp( Race_Orc_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_Orc_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Orc_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Orc, (uint)WowClasse.Druid, Race_Orc_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_Orc_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Orc_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Orc_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceOrc.LevelUp( Race_Orc_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_Orc_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Orc_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Orc, (uint)WowClasse.Hunter, Race_Orc_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_Orc_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Orc_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Orc_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceOrc.LevelUp( Race_Orc_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_Orc_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Orc_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Orc, (uint)WowClasse.Mage, Race_Orc_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_Orc_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Orc_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Orc_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceOrc.LevelUp( Race_Orc_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_Orc_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Orc_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Orc, (uint)WowClasse.Paladin, Race_Orc_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_Orc_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Orc_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Orc_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceOrc.LevelUp( Race_Orc_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_Orc_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Orc_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Orc, (uint)WowClasse.Priest, Race_Orc_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_Orc_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Orc_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Orc_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceOrc.LevelUp( Race_Orc_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_Orc_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Orc_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Orc, (uint)WowClasse.Rogue, Race_Orc_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_Orc_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Orc_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Orc_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceOrc.LevelUp( Race_Orc_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_Orc_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Orc_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Orc, (uint)WowClasse.Shaman, Race_Orc_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_Orc_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Orc_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Orc_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceOrc.LevelUp( Race_Orc_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_Orc_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Orc_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Orc, (uint)WowClasse.Warlock, Race_Orc_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_Orc_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Orc_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Orc_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceOrc.LevelUp( Race_Orc_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_Orc_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Orc_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Orc;
                        Race_Orc_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Orc_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Orc, (uint)WowClasse.Warrior, Race_Orc_Classe_Warrior_LevelInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 牛头 类 | en Race_Tauren Class
            // Race_Tauren
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_Tauren_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Tauren_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Tauren_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTauren.LevelUp( Race_Tauren_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_Tauren_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Tauren_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Tauren, (uint)WowClasse.Druid, Race_Tauren_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_Tauren_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Tauren_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Tauren_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTauren.LevelUp( Race_Tauren_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_Tauren_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Tauren_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Tauren, (uint)WowClasse.Hunter, Race_Tauren_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_Tauren_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Tauren_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Tauren_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTauren.LevelUp( Race_Tauren_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_Tauren_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Tauren_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Tauren, (uint)WowClasse.Mage, Race_Tauren_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_Tauren_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Tauren_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Tauren_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTauren.LevelUp( Race_Tauren_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_Tauren_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Tauren_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Tauren, (uint)WowClasse.Paladin, Race_Tauren_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_Tauren_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Tauren_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Tauren_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTauren.LevelUp( Race_Tauren_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_Tauren_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Tauren_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Tauren, (uint)WowClasse.Priest, Race_Tauren_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_Tauren_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Tauren_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Tauren_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTauren.LevelUp( Race_Tauren_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_Tauren_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Tauren_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Tauren, (uint)WowClasse.Rogue, Race_Tauren_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_Tauren_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Tauren_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Tauren_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTauren.LevelUp( Race_Tauren_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_Tauren_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Tauren_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Tauren, (uint)WowClasse.Shaman, Race_Tauren_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_Tauren_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Tauren_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Tauren_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTauren.LevelUp( Race_Tauren_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_Tauren_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Tauren_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Tauren, (uint)WowClasse.Warlock, Race_Tauren_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_Tauren_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Tauren_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Tauren_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTauren.LevelUp( Race_Tauren_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_Tauren_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Tauren_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Tauren;
                        Race_Tauren_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Tauren_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Tauren, (uint)WowClasse.Warrior, Race_Tauren_Classe_Warrior_LevelInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 巨魔 类 | en Race_Troll Class
            // Race_Troll
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_Troll_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Troll_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Troll_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTroll.LevelUp( Race_Troll_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_Troll_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Troll_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Troll, (uint)WowClasse.Druid, Race_Troll_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_Troll_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Troll_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Troll_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTroll.LevelUp( Race_Troll_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_Troll_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Troll_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Troll, (uint)WowClasse.Hunter, Race_Troll_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_Troll_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Troll_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Troll_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTroll.LevelUp( Race_Troll_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_Troll_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Troll_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Troll, (uint)WowClasse.Mage, Race_Troll_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_Troll_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Troll_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Troll_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTroll.LevelUp( Race_Troll_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_Troll_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Troll_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Troll, (uint)WowClasse.Paladin, Race_Troll_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_Troll_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Troll_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Troll_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTroll.LevelUp( Race_Troll_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_Troll_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Troll_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Troll, (uint)WowClasse.Priest, Race_Troll_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_Troll_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Troll_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Troll_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTroll.LevelUp( Race_Troll_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_Troll_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Troll_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Troll, (uint)WowClasse.Rogue, Race_Troll_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_Troll_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Troll_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Troll_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTroll.LevelUp( Race_Troll_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_Troll_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Troll_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Troll, (uint)WowClasse.Shaman, Race_Troll_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_Troll_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Troll_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Troll_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTroll.LevelUp( Race_Troll_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_Troll_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Troll_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Troll, (uint)WowClasse.Warlock, Race_Troll_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_Troll_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Troll_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Troll_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceTroll.LevelUp( Race_Troll_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_Troll_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Troll_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Troll;
                        Race_Troll_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Troll_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Troll, (uint)WowClasse.Warrior, Race_Troll_Classe_Warrior_LevelInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 亡灵 类 | en Race_Undead Class
            // Race_Undead
            {
                // Classe_Druid
                {
                    WowCharacterLevelInfo[] Race_Undead_Classe_Druid_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Druid_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Undead_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Undead_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceUndead.LevelUp( Race_Undead_Classe_Druid_LevelInfo );
                    ClasseDruid.LevelUp( Race_Undead_Classe_Druid_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Druid_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Druid_LevelInfo[iIndex].Class = (uint)WowClasse.Druid;
                        Race_Undead_Classe_Druid_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Undead, (uint)WowClasse.Druid, Race_Undead_Classe_Druid_LevelInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterLevelInfo[] Race_Undead_Classe_Hunter_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Hunter_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Undead_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Undead_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceUndead.LevelUp( Race_Undead_Classe_Hunter_LevelInfo );
                    ClasseHunter.LevelUp( Race_Undead_Classe_Hunter_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Hunter_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Hunter_LevelInfo[iIndex].Class = (uint)WowClasse.Hunter;
                        Race_Undead_Classe_Hunter_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Undead, (uint)WowClasse.Hunter, Race_Undead_Classe_Hunter_LevelInfo );
                }

                // Classe_Mage
                {
                    WowCharacterLevelInfo[] Race_Undead_Classe_Mage_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Mage_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Undead_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Undead_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceUndead.LevelUp( Race_Undead_Classe_Mage_LevelInfo );
                    ClasseMage.LevelUp( Race_Undead_Classe_Mage_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Mage_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Mage_LevelInfo[iIndex].Class = (uint)WowClasse.Mage;
                        Race_Undead_Classe_Mage_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Undead, (uint)WowClasse.Mage, Race_Undead_Classe_Mage_LevelInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterLevelInfo[] Race_Undead_Classe_Paladin_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Paladin_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Undead_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Undead_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceUndead.LevelUp( Race_Undead_Classe_Paladin_LevelInfo );
                    ClassePaladin.LevelUp( Race_Undead_Classe_Paladin_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Paladin_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Paladin_LevelInfo[iIndex].Class = (uint)WowClasse.Paladin;
                        Race_Undead_Classe_Paladin_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Undead, (uint)WowClasse.Paladin, Race_Undead_Classe_Paladin_LevelInfo );
                }

                // Classe_Priest
                {
                    WowCharacterLevelInfo[] Race_Undead_Classe_Priest_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Priest_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Undead_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Undead_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceUndead.LevelUp( Race_Undead_Classe_Priest_LevelInfo );
                    ClassePriest.LevelUp( Race_Undead_Classe_Priest_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Priest_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Priest_LevelInfo[iIndex].Class = (uint)WowClasse.Priest;
                        Race_Undead_Classe_Priest_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Undead, (uint)WowClasse.Priest, Race_Undead_Classe_Priest_LevelInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterLevelInfo[] Race_Undead_Classe_Rogue_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Rogue_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Undead_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Undead_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceUndead.LevelUp( Race_Undead_Classe_Rogue_LevelInfo );
                    ClasseRogue.LevelUp( Race_Undead_Classe_Rogue_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Rogue_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Rogue_LevelInfo[iIndex].Class = (uint)WowClasse.Rogue;
                        Race_Undead_Classe_Rogue_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Undead, (uint)WowClasse.Rogue, Race_Undead_Classe_Rogue_LevelInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterLevelInfo[] Race_Undead_Classe_Shaman_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Shaman_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Undead_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Undead_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceUndead.LevelUp( Race_Undead_Classe_Shaman_LevelInfo );
                    ClasseShaman.LevelUp( Race_Undead_Classe_Shaman_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Shaman_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Shaman_LevelInfo[iIndex].Class = (uint)WowClasse.Shaman;
                        Race_Undead_Classe_Shaman_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Undead, (uint)WowClasse.Shaman, Race_Undead_Classe_Shaman_LevelInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterLevelInfo[] Race_Undead_Classe_Warlock_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Warlock_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Undead_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Undead_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceUndead.LevelUp( Race_Undead_Classe_Warlock_LevelInfo );
                    ClasseWarlock.LevelUp( Race_Undead_Classe_Warlock_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Warlock_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Warlock_LevelInfo[iIndex].Class = (uint)WowClasse.Warlock;
                        Race_Undead_Classe_Warlock_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Undead, (uint)WowClasse.Warlock, Race_Undead_Classe_Warlock_LevelInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterLevelInfo[] Race_Undead_Classe_Warrior_LevelInfo = new WowCharacterLevelInfo[PLAYER_MAX_LEVEL];

                    // Init
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Warrior_LevelInfo[iIndex] = new WowCharacterLevelInfo();

                        Race_Undead_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Undead_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    RaceUndead.LevelUp( Race_Undead_Classe_Warrior_LevelInfo );
                    ClasseWarrior.LevelUp( Race_Undead_Classe_Warrior_LevelInfo );

                    // Prevent Modify
                    for ( int iIndex = 0; iIndex < PLAYER_MAX_LEVEL; iIndex++ )
                    {
                        Race_Undead_Classe_Warrior_LevelInfo[iIndex].Race = (uint)WowRace.Undead;
                        Race_Undead_Classe_Warrior_LevelInfo[iIndex].Class = (uint)WowClasse.Warrior;
                        Race_Undead_Classe_Warrior_LevelInfo[iIndex].Level = (uint)iIndex + 1;
                    }

                    playerLevelStatsHandler.AddLevelInfo( (uint)WowRace.Undead, (uint)WowClasse.Warrior, Race_Undead_Classe_Warrior_LevelInfo );
                }
            }
            #endregion
        }
    }
}
