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
    public class InitCreateInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlayerCreateInfoManager"></param>
        public static void InitWowCharacterCreateInfo( WowCharacterCreateInfoHandler playerCreateInfoHandler )
        {
            #region zh-CHS 种族 血精灵 类 | en Race_BloodElf Class
            // Race_BloodElf
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_BloodElf_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_BloodElf_Classe_Druid_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceBloodElf.StartBirth( Race_BloodElf_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_BloodElf_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_BloodElf_Classe_Druid_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_BloodElf_Classe_Druid_CreateInfo.Race, Race_BloodElf_Classe_Druid_CreateInfo.Class, Race_BloodElf_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_BloodElf_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_BloodElf_Classe_Hunter_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceBloodElf.StartBirth( Race_BloodElf_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_BloodElf_Classe_Hunter_CreateInfo );

                    Race_BloodElf_Classe_Hunter_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_BloodElf_Classe_Hunter_CreateInfo.Race, Race_BloodElf_Classe_Hunter_CreateInfo.Class, Race_BloodElf_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_BloodElf_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_BloodElf_Classe_Mage_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceBloodElf.StartBirth( Race_BloodElf_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_BloodElf_Classe_Mage_CreateInfo );

                    Race_BloodElf_Classe_Mage_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_BloodElf_Classe_Mage_CreateInfo.Race, Race_BloodElf_Classe_Mage_CreateInfo.Class, Race_BloodElf_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_BloodElf_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_BloodElf_Classe_Paladin_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceBloodElf.StartBirth( Race_BloodElf_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_BloodElf_Classe_Paladin_CreateInfo );

                    Race_BloodElf_Classe_Paladin_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_BloodElf_Classe_Paladin_CreateInfo.Race, Race_BloodElf_Classe_Paladin_CreateInfo.Class, Race_BloodElf_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_BloodElf_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_BloodElf_Classe_Priest_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceBloodElf.StartBirth( Race_BloodElf_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_BloodElf_Classe_Priest_CreateInfo );

                    Race_BloodElf_Classe_Priest_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_BloodElf_Classe_Priest_CreateInfo.Race, Race_BloodElf_Classe_Priest_CreateInfo.Class, Race_BloodElf_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_BloodElf_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_BloodElf_Classe_Rogue_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceBloodElf.StartBirth( Race_BloodElf_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_BloodElf_Classe_Rogue_CreateInfo );

                    Race_BloodElf_Classe_Rogue_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_BloodElf_Classe_Rogue_CreateInfo.Race, Race_BloodElf_Classe_Rogue_CreateInfo.Class, Race_BloodElf_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_BloodElf_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_BloodElf_Classe_Shaman_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceBloodElf.StartBirth( Race_BloodElf_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_BloodElf_Classe_Shaman_CreateInfo );

                    Race_BloodElf_Classe_Shaman_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_BloodElf_Classe_Shaman_CreateInfo.Race, Race_BloodElf_Classe_Shaman_CreateInfo.Class, Race_BloodElf_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_BloodElf_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_BloodElf_Classe_Warlock_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceBloodElf.StartBirth( Race_BloodElf_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_BloodElf_Classe_Warlock_CreateInfo );

                    Race_BloodElf_Classe_Warlock_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_BloodElf_Classe_Warlock_CreateInfo.Race, Race_BloodElf_Classe_Warlock_CreateInfo.Class, Race_BloodElf_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_BloodElf_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_BloodElf_Classe_Warrior_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceBloodElf.StartBirth( Race_BloodElf_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_BloodElf_Classe_Warrior_CreateInfo );

                    Race_BloodElf_Classe_Warrior_CreateInfo.Race = (uint)WowRace.BloodElf;
                    Race_BloodElf_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_BloodElf_Classe_Warrior_CreateInfo.Race, Race_BloodElf_Classe_Warrior_CreateInfo.Class, Race_BloodElf_Classe_Warrior_CreateInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 德莱尼 类 | en Race_Draenei Class
            // Race_Draenei
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_Draenei_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_Draenei_Classe_Druid_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceDraenei.StartBirth( Race_Draenei_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_Draenei_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_Draenei_Classe_Druid_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_Draenei_Classe_Druid_CreateInfo.Race, Race_Draenei_Classe_Druid_CreateInfo.Class, Race_Draenei_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_Draenei_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_Draenei_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceDraenei.StartBirth( Race_Draenei_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_Draenei_Classe_Hunter_CreateInfo );

                    Race_Draenei_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_Draenei_Classe_Hunter_CreateInfo.Race, Race_Draenei_Classe_Hunter_CreateInfo.Class, Race_Draenei_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_Draenei_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_Draenei_Classe_Mage_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceDraenei.StartBirth( Race_Draenei_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_Draenei_Classe_Mage_CreateInfo );

                    Race_Draenei_Classe_Mage_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_Draenei_Classe_Mage_CreateInfo.Race, Race_Draenei_Classe_Mage_CreateInfo.Class, Race_Draenei_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_Draenei_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_Draenei_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceDraenei.StartBirth( Race_Draenei_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_Draenei_Classe_Paladin_CreateInfo );

                    Race_Draenei_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_Draenei_Classe_Paladin_CreateInfo.Race, Race_Draenei_Classe_Paladin_CreateInfo.Class, Race_Draenei_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_Draenei_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_Draenei_Classe_Priest_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceDraenei.StartBirth( Race_Draenei_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_Draenei_Classe_Priest_CreateInfo );

                    Race_Draenei_Classe_Priest_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_Draenei_Classe_Priest_CreateInfo.Race, Race_Draenei_Classe_Priest_CreateInfo.Class, Race_Draenei_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_Draenei_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_Draenei_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceDraenei.StartBirth( Race_Draenei_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_Draenei_Classe_Rogue_CreateInfo );

                    Race_Draenei_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_Draenei_Classe_Rogue_CreateInfo.Race, Race_Draenei_Classe_Rogue_CreateInfo.Class, Race_Draenei_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_Draenei_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_Draenei_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceDraenei.StartBirth( Race_Draenei_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_Draenei_Classe_Shaman_CreateInfo );

                    Race_Draenei_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_Draenei_Classe_Shaman_CreateInfo.Race, Race_Draenei_Classe_Shaman_CreateInfo.Class, Race_Draenei_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_Draenei_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_Draenei_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceDraenei.StartBirth( Race_Draenei_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_Draenei_Classe_Warlock_CreateInfo );

                    Race_Draenei_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_Draenei_Classe_Warlock_CreateInfo.Race, Race_Draenei_Classe_Warlock_CreateInfo.Class, Race_Draenei_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_Draenei_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_Draenei_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceDraenei.StartBirth( Race_Draenei_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_Draenei_Classe_Warrior_CreateInfo );

                    Race_Draenei_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Draenei;
                    Race_Draenei_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_Draenei_Classe_Warrior_CreateInfo.Race, Race_Draenei_Classe_Warrior_CreateInfo.Class, Race_Draenei_Classe_Warrior_CreateInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 矮人 类 | en Race_Dwarf Class
            // Race_Dwarf
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_Dwarf_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_Dwarf_Classe_Druid_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceDwarf.StartBirth( Race_Dwarf_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_Dwarf_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_Dwarf_Classe_Druid_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_Dwarf_Classe_Druid_CreateInfo.Race, Race_Dwarf_Classe_Druid_CreateInfo.Class, Race_Dwarf_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_Dwarf_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_Dwarf_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceDwarf.StartBirth( Race_Dwarf_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_Dwarf_Classe_Hunter_CreateInfo );

                    Race_Dwarf_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_Dwarf_Classe_Hunter_CreateInfo.Race, Race_Dwarf_Classe_Hunter_CreateInfo.Class, Race_Dwarf_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_Dwarf_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_Dwarf_Classe_Mage_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceDwarf.StartBirth( Race_Dwarf_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_Dwarf_Classe_Mage_CreateInfo );

                    Race_Dwarf_Classe_Mage_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_Dwarf_Classe_Mage_CreateInfo.Race, Race_Dwarf_Classe_Mage_CreateInfo.Class, Race_Dwarf_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_Dwarf_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_Dwarf_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceDwarf.StartBirth( Race_Dwarf_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_Dwarf_Classe_Paladin_CreateInfo );

                    Race_Dwarf_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_Dwarf_Classe_Paladin_CreateInfo.Race, Race_Dwarf_Classe_Paladin_CreateInfo.Class, Race_Dwarf_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_Dwarf_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_Dwarf_Classe_Priest_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceDwarf.StartBirth( Race_Dwarf_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_Dwarf_Classe_Priest_CreateInfo );

                    Race_Dwarf_Classe_Priest_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_Dwarf_Classe_Priest_CreateInfo.Race, Race_Dwarf_Classe_Priest_CreateInfo.Class, Race_Dwarf_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_Dwarf_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_Dwarf_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceDwarf.StartBirth( Race_Dwarf_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_Dwarf_Classe_Rogue_CreateInfo );

                    Race_Dwarf_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_Dwarf_Classe_Rogue_CreateInfo.Race, Race_Dwarf_Classe_Rogue_CreateInfo.Class, Race_Dwarf_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_Dwarf_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_Dwarf_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceDwarf.StartBirth( Race_Dwarf_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_Dwarf_Classe_Shaman_CreateInfo );

                    Race_Dwarf_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_Dwarf_Classe_Shaman_CreateInfo.Race, Race_Dwarf_Classe_Shaman_CreateInfo.Class, Race_Dwarf_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_Dwarf_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_Dwarf_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceDwarf.StartBirth( Race_Dwarf_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_Dwarf_Classe_Warlock_CreateInfo );

                    Race_Dwarf_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_Dwarf_Classe_Warlock_CreateInfo.Race, Race_Dwarf_Classe_Warlock_CreateInfo.Class, Race_Dwarf_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_Dwarf_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_Dwarf_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceDwarf.StartBirth( Race_Dwarf_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_Dwarf_Classe_Warrior_CreateInfo );

                    Race_Dwarf_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Dwarf;
                    Race_Dwarf_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_Dwarf_Classe_Warrior_CreateInfo.Race, Race_Dwarf_Classe_Warrior_CreateInfo.Class, Race_Dwarf_Classe_Warrior_CreateInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 侏儒 类 | en Race_Gnome Class
            // Race_Gnome
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_Gnome_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_Gnome_Classe_Druid_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceGnome.StartBirth( Race_Gnome_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_Gnome_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_Gnome_Classe_Druid_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_Gnome_Classe_Druid_CreateInfo.Race, Race_Gnome_Classe_Druid_CreateInfo.Class, Race_Gnome_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_Gnome_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_Gnome_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceGnome.StartBirth( Race_Gnome_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_Gnome_Classe_Hunter_CreateInfo );

                    Race_Gnome_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_Gnome_Classe_Hunter_CreateInfo.Race, Race_Gnome_Classe_Hunter_CreateInfo.Class, Race_Gnome_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_Gnome_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_Gnome_Classe_Mage_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceGnome.StartBirth( Race_Gnome_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_Gnome_Classe_Mage_CreateInfo );

                    Race_Gnome_Classe_Mage_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_Gnome_Classe_Mage_CreateInfo.Race, Race_Gnome_Classe_Mage_CreateInfo.Class, Race_Gnome_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_Gnome_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_Gnome_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceGnome.StartBirth( Race_Gnome_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_Gnome_Classe_Paladin_CreateInfo );

                    Race_Gnome_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_Gnome_Classe_Paladin_CreateInfo.Race, Race_Gnome_Classe_Paladin_CreateInfo.Class, Race_Gnome_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_Gnome_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_Gnome_Classe_Priest_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceGnome.StartBirth( Race_Gnome_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_Gnome_Classe_Priest_CreateInfo );

                    Race_Gnome_Classe_Priest_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_Gnome_Classe_Priest_CreateInfo.Race, Race_Gnome_Classe_Priest_CreateInfo.Class, Race_Gnome_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_Gnome_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_Gnome_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceGnome.StartBirth( Race_Gnome_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_Gnome_Classe_Rogue_CreateInfo );

                    Race_Gnome_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_Gnome_Classe_Rogue_CreateInfo.Race, Race_Gnome_Classe_Rogue_CreateInfo.Class, Race_Gnome_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_Gnome_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_Gnome_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceGnome.StartBirth( Race_Gnome_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_Gnome_Classe_Shaman_CreateInfo );

                    Race_Gnome_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_Gnome_Classe_Shaman_CreateInfo.Race, Race_Gnome_Classe_Shaman_CreateInfo.Class, Race_Gnome_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_Gnome_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_Gnome_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceGnome.StartBirth( Race_Gnome_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_Gnome_Classe_Warlock_CreateInfo );

                    Race_Gnome_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_Gnome_Classe_Warlock_CreateInfo.Race, Race_Gnome_Classe_Warlock_CreateInfo.Class, Race_Gnome_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_Gnome_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_Gnome_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceGnome.StartBirth( Race_Gnome_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_Gnome_Classe_Warrior_CreateInfo );

                    Race_Gnome_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Gnome;
                    Race_Gnome_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_Gnome_Classe_Warrior_CreateInfo.Race, Race_Gnome_Classe_Warrior_CreateInfo.Class, Race_Gnome_Classe_Warrior_CreateInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 人类 类 | en Race_Human Class
            // Race_Human
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_Human_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_Human_Classe_Druid_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceHuman.StartBirth( Race_Human_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_Human_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_Human_Classe_Druid_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_Human_Classe_Druid_CreateInfo.Race, Race_Human_Classe_Druid_CreateInfo.Class, Race_Human_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_Human_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_Human_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceHuman.StartBirth( Race_Human_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_Human_Classe_Hunter_CreateInfo );

                    Race_Human_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_Human_Classe_Hunter_CreateInfo.Race, Race_Human_Classe_Hunter_CreateInfo.Class, Race_Human_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_Human_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_Human_Classe_Mage_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceHuman.StartBirth( Race_Human_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_Human_Classe_Mage_CreateInfo );

                    Race_Human_Classe_Mage_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_Human_Classe_Mage_CreateInfo.Race, Race_Human_Classe_Mage_CreateInfo.Class, Race_Human_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_Human_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_Human_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceHuman.StartBirth( Race_Human_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_Human_Classe_Paladin_CreateInfo );

                    Race_Human_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_Human_Classe_Paladin_CreateInfo.Race, Race_Human_Classe_Paladin_CreateInfo.Class, Race_Human_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_Human_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_Human_Classe_Priest_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceHuman.StartBirth( Race_Human_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_Human_Classe_Priest_CreateInfo );

                    Race_Human_Classe_Priest_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_Human_Classe_Priest_CreateInfo.Race, Race_Human_Classe_Priest_CreateInfo.Class, Race_Human_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_Human_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_Human_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceHuman.StartBirth( Race_Human_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_Human_Classe_Rogue_CreateInfo );

                    Race_Human_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_Human_Classe_Rogue_CreateInfo.Race, Race_Human_Classe_Rogue_CreateInfo.Class, Race_Human_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_Human_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_Human_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceHuman.StartBirth( Race_Human_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_Human_Classe_Shaman_CreateInfo );

                    Race_Human_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_Human_Classe_Shaman_CreateInfo.Race, Race_Human_Classe_Shaman_CreateInfo.Class, Race_Human_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_Human_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_Human_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceHuman.StartBirth( Race_Human_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_Human_Classe_Warlock_CreateInfo );

                    Race_Human_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_Human_Classe_Warlock_CreateInfo.Race, Race_Human_Classe_Warlock_CreateInfo.Class, Race_Human_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_Human_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_Human_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceHuman.StartBirth( Race_Human_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_Human_Classe_Warrior_CreateInfo );

                    Race_Human_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Human;
                    Race_Human_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_Human_Classe_Warrior_CreateInfo.Race, Race_Human_Classe_Warrior_CreateInfo.Class, Race_Human_Classe_Warrior_CreateInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 暗夜精灵 类 | en Race_Nightelf Class
            // Race_Nightelf
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_Nightelf_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_Nightelf_Classe_Druid_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceNightelf.StartBirth( Race_Nightelf_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_Nightelf_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_Nightelf_Classe_Druid_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_Nightelf_Classe_Druid_CreateInfo.Race, Race_Nightelf_Classe_Druid_CreateInfo.Class, Race_Nightelf_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_Nightelf_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_Nightelf_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceNightelf.StartBirth( Race_Nightelf_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_Nightelf_Classe_Hunter_CreateInfo );

                    Race_Nightelf_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_Nightelf_Classe_Hunter_CreateInfo.Race, Race_Nightelf_Classe_Hunter_CreateInfo.Class, Race_Nightelf_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_Nightelf_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_Nightelf_Classe_Mage_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceNightelf.StartBirth( Race_Nightelf_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_Nightelf_Classe_Mage_CreateInfo );

                    Race_Nightelf_Classe_Mage_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_Nightelf_Classe_Mage_CreateInfo.Race, Race_Nightelf_Classe_Mage_CreateInfo.Class, Race_Nightelf_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_Nightelf_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_Nightelf_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceNightelf.StartBirth( Race_Nightelf_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_Nightelf_Classe_Paladin_CreateInfo );

                    Race_Nightelf_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_Nightelf_Classe_Paladin_CreateInfo.Race, Race_Nightelf_Classe_Paladin_CreateInfo.Class, Race_Nightelf_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_Nightelf_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_Nightelf_Classe_Priest_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceNightelf.StartBirth( Race_Nightelf_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_Nightelf_Classe_Priest_CreateInfo );

                    Race_Nightelf_Classe_Priest_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_Nightelf_Classe_Priest_CreateInfo.Race, Race_Nightelf_Classe_Priest_CreateInfo.Class, Race_Nightelf_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_Nightelf_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_Nightelf_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceNightelf.StartBirth( Race_Nightelf_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_Nightelf_Classe_Rogue_CreateInfo );

                    Race_Nightelf_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_Nightelf_Classe_Rogue_CreateInfo.Race, Race_Nightelf_Classe_Rogue_CreateInfo.Class, Race_Nightelf_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_Nightelf_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_Nightelf_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceNightelf.StartBirth( Race_Nightelf_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_Nightelf_Classe_Shaman_CreateInfo );

                    Race_Nightelf_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_Nightelf_Classe_Shaman_CreateInfo.Race, Race_Nightelf_Classe_Shaman_CreateInfo.Class, Race_Nightelf_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_Nightelf_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_Nightelf_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceNightelf.StartBirth( Race_Nightelf_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_Nightelf_Classe_Warlock_CreateInfo );

                    Race_Nightelf_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_Nightelf_Classe_Warlock_CreateInfo.Race, Race_Nightelf_Classe_Warlock_CreateInfo.Class, Race_Nightelf_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_Nightelf_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_Nightelf_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceNightelf.StartBirth( Race_Nightelf_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_Nightelf_Classe_Warrior_CreateInfo );

                    Race_Nightelf_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Nightelf;
                    Race_Nightelf_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_Nightelf_Classe_Warrior_CreateInfo.Race, Race_Nightelf_Classe_Warrior_CreateInfo.Class, Race_Nightelf_Classe_Warrior_CreateInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 兽人 类 | en Race_Orc Class
            // Race_Orc
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_Orc_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_Orc_Classe_Druid_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceOrc.StartBirth( Race_Orc_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_Orc_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_Orc_Classe_Druid_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_Orc_Classe_Druid_CreateInfo.Race, Race_Orc_Classe_Druid_CreateInfo.Class, Race_Orc_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_Orc_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_Orc_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceOrc.StartBirth( Race_Orc_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_Orc_Classe_Hunter_CreateInfo );

                    Race_Orc_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_Orc_Classe_Hunter_CreateInfo.Race, Race_Orc_Classe_Hunter_CreateInfo.Class, Race_Orc_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_Orc_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_Orc_Classe_Mage_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceOrc.StartBirth( Race_Orc_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_Orc_Classe_Mage_CreateInfo );

                    Race_Orc_Classe_Mage_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_Orc_Classe_Mage_CreateInfo.Race, Race_Orc_Classe_Mage_CreateInfo.Class, Race_Orc_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_Orc_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_Orc_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceOrc.StartBirth( Race_Orc_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_Orc_Classe_Paladin_CreateInfo );

                    Race_Orc_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_Orc_Classe_Paladin_CreateInfo.Race, Race_Orc_Classe_Paladin_CreateInfo.Class, Race_Orc_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_Orc_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_Orc_Classe_Priest_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceOrc.StartBirth( Race_Orc_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_Orc_Classe_Priest_CreateInfo );

                    Race_Orc_Classe_Priest_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_Orc_Classe_Priest_CreateInfo.Race, Race_Orc_Classe_Priest_CreateInfo.Class, Race_Orc_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_Orc_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_Orc_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceOrc.StartBirth( Race_Orc_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_Orc_Classe_Rogue_CreateInfo );

                    Race_Orc_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_Orc_Classe_Rogue_CreateInfo.Race, Race_Orc_Classe_Rogue_CreateInfo.Class, Race_Orc_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_Orc_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_Orc_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceOrc.StartBirth( Race_Orc_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_Orc_Classe_Shaman_CreateInfo );

                    Race_Orc_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_Orc_Classe_Shaman_CreateInfo.Race, Race_Orc_Classe_Shaman_CreateInfo.Class, Race_Orc_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_Orc_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_Orc_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceOrc.StartBirth( Race_Orc_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_Orc_Classe_Warlock_CreateInfo );

                    Race_Orc_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_Orc_Classe_Warlock_CreateInfo.Race, Race_Orc_Classe_Warlock_CreateInfo.Class, Race_Orc_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_Orc_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_Orc_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceOrc.StartBirth( Race_Orc_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_Orc_Classe_Warrior_CreateInfo );

                    Race_Orc_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Orc;
                    Race_Orc_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_Orc_Classe_Warrior_CreateInfo.Race, Race_Orc_Classe_Warrior_CreateInfo.Class, Race_Orc_Classe_Warrior_CreateInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 牛头 类 | en Race_Tauren Class
            // Race_Tauren
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_Tauren_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_Tauren_Classe_Druid_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceTauren.StartBirth( Race_Tauren_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_Tauren_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_Tauren_Classe_Druid_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_Tauren_Classe_Druid_CreateInfo.Race, Race_Tauren_Classe_Druid_CreateInfo.Class, Race_Tauren_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_Tauren_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_Tauren_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceTauren.StartBirth( Race_Tauren_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_Tauren_Classe_Hunter_CreateInfo );

                    Race_Tauren_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_Tauren_Classe_Hunter_CreateInfo.Race, Race_Tauren_Classe_Hunter_CreateInfo.Class, Race_Tauren_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_Tauren_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_Tauren_Classe_Mage_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceTauren.StartBirth( Race_Tauren_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_Tauren_Classe_Mage_CreateInfo );

                    Race_Tauren_Classe_Mage_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_Tauren_Classe_Mage_CreateInfo.Race, Race_Tauren_Classe_Mage_CreateInfo.Class, Race_Tauren_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_Tauren_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_Tauren_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceTauren.StartBirth( Race_Tauren_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_Tauren_Classe_Paladin_CreateInfo );

                    Race_Tauren_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_Tauren_Classe_Paladin_CreateInfo.Race, Race_Tauren_Classe_Paladin_CreateInfo.Class, Race_Tauren_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_Tauren_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_Tauren_Classe_Priest_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceTauren.StartBirth( Race_Tauren_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_Tauren_Classe_Priest_CreateInfo );

                    Race_Tauren_Classe_Priest_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_Tauren_Classe_Priest_CreateInfo.Race, Race_Tauren_Classe_Priest_CreateInfo.Class, Race_Tauren_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_Tauren_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_Tauren_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceTauren.StartBirth( Race_Tauren_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_Tauren_Classe_Rogue_CreateInfo );

                    Race_Tauren_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_Tauren_Classe_Rogue_CreateInfo.Race, Race_Tauren_Classe_Rogue_CreateInfo.Class, Race_Tauren_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_Tauren_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_Tauren_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceTauren.StartBirth( Race_Tauren_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_Tauren_Classe_Shaman_CreateInfo );

                    Race_Tauren_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_Tauren_Classe_Shaman_CreateInfo.Race, Race_Tauren_Classe_Shaman_CreateInfo.Class, Race_Tauren_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_Tauren_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_Tauren_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceTauren.StartBirth( Race_Tauren_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_Tauren_Classe_Warlock_CreateInfo );

                    Race_Tauren_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_Tauren_Classe_Warlock_CreateInfo.Race, Race_Tauren_Classe_Warlock_CreateInfo.Class, Race_Tauren_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_Tauren_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_Tauren_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceTauren.StartBirth( Race_Tauren_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_Tauren_Classe_Warrior_CreateInfo );

                    Race_Tauren_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Tauren;
                    Race_Tauren_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_Tauren_Classe_Warrior_CreateInfo.Race, Race_Tauren_Classe_Warrior_CreateInfo.Class, Race_Tauren_Classe_Warrior_CreateInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 巨魔 类 | en Race_Troll Class
            // Race_Troll
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_Troll_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_Troll_Classe_Druid_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceTroll.StartBirth( Race_Troll_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_Troll_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_Troll_Classe_Druid_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_Troll_Classe_Druid_CreateInfo.Race, Race_Troll_Classe_Druid_CreateInfo.Class, Race_Troll_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_Troll_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_Troll_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceTroll.StartBirth( Race_Troll_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_Troll_Classe_Hunter_CreateInfo );

                    Race_Troll_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_Troll_Classe_Hunter_CreateInfo.Race, Race_Troll_Classe_Hunter_CreateInfo.Class, Race_Troll_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_Troll_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_Troll_Classe_Mage_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceTroll.StartBirth( Race_Troll_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_Troll_Classe_Mage_CreateInfo );

                    Race_Troll_Classe_Mage_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_Troll_Classe_Mage_CreateInfo.Race, Race_Troll_Classe_Mage_CreateInfo.Class, Race_Troll_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_Troll_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_Troll_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceTroll.StartBirth( Race_Troll_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_Troll_Classe_Paladin_CreateInfo );

                    Race_Troll_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_Troll_Classe_Paladin_CreateInfo.Race, Race_Troll_Classe_Paladin_CreateInfo.Class, Race_Troll_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_Troll_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_Troll_Classe_Priest_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceTroll.StartBirth( Race_Troll_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_Troll_Classe_Priest_CreateInfo );

                    Race_Troll_Classe_Priest_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_Troll_Classe_Priest_CreateInfo.Race, Race_Troll_Classe_Priest_CreateInfo.Class, Race_Troll_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_Troll_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_Troll_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceTroll.StartBirth( Race_Troll_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_Troll_Classe_Rogue_CreateInfo );

                    Race_Troll_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_Troll_Classe_Rogue_CreateInfo.Race, Race_Troll_Classe_Rogue_CreateInfo.Class, Race_Troll_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_Troll_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_Troll_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceTroll.StartBirth( Race_Troll_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_Troll_Classe_Shaman_CreateInfo );

                    Race_Troll_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_Troll_Classe_Shaman_CreateInfo.Race, Race_Troll_Classe_Shaman_CreateInfo.Class, Race_Troll_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_Troll_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_Troll_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceTroll.StartBirth( Race_Troll_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_Troll_Classe_Warlock_CreateInfo );

                    Race_Troll_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_Troll_Classe_Warlock_CreateInfo.Race, Race_Troll_Classe_Warlock_CreateInfo.Class, Race_Troll_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_Troll_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_Troll_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceTroll.StartBirth( Race_Troll_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_Troll_Classe_Warrior_CreateInfo );

                    Race_Troll_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Troll;
                    Race_Troll_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_Troll_Classe_Warrior_CreateInfo.Race, Race_Troll_Classe_Warrior_CreateInfo.Class, Race_Troll_Classe_Warrior_CreateInfo );
                }
            }
            #endregion

            #region zh-CHS 种族 亡灵 类 | en Race_Undead Class
            // Race_Undead
            {
                // Classe_Druid
                {
                    WowCharacterCreateInfo Race_Undead_Classe_Druid_CreateInfo = new WowCharacterCreateInfo();

                    // Init
                    Race_Undead_Classe_Druid_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    RaceUndead.StartBirth( Race_Undead_Classe_Druid_CreateInfo );
                    ClasseDruid.StartBirth( Race_Undead_Classe_Druid_CreateInfo );

                    // Prevent Modify
                    Race_Undead_Classe_Druid_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Druid_CreateInfo.Class = (uint)WowClasse.Druid;

                    playerCreateInfoHandler.AddCreateInfo( Race_Undead_Classe_Druid_CreateInfo.Race, Race_Undead_Classe_Druid_CreateInfo.Class, Race_Undead_Classe_Druid_CreateInfo );
                }

                // Classe_Hunter
                {
                    WowCharacterCreateInfo Race_Undead_Classe_Hunter_CreateInfo = new WowCharacterCreateInfo();

                    Race_Undead_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    RaceUndead.StartBirth( Race_Undead_Classe_Hunter_CreateInfo );
                    ClasseHunter.StartBirth( Race_Undead_Classe_Hunter_CreateInfo );

                    Race_Undead_Classe_Hunter_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Hunter_CreateInfo.Class = (uint)WowClasse.Hunter;

                    playerCreateInfoHandler.AddCreateInfo( Race_Undead_Classe_Hunter_CreateInfo.Race, Race_Undead_Classe_Hunter_CreateInfo.Class, Race_Undead_Classe_Hunter_CreateInfo );
                }

                // Classe_Mage
                {
                    WowCharacterCreateInfo Race_Undead_Classe_Mage_CreateInfo = new WowCharacterCreateInfo();

                    Race_Undead_Classe_Mage_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    RaceUndead.StartBirth( Race_Undead_Classe_Mage_CreateInfo );
                    ClasseMage.StartBirth( Race_Undead_Classe_Mage_CreateInfo );

                    Race_Undead_Classe_Mage_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Mage_CreateInfo.Class = (uint)WowClasse.Mage;

                    playerCreateInfoHandler.AddCreateInfo( Race_Undead_Classe_Mage_CreateInfo.Race, Race_Undead_Classe_Mage_CreateInfo.Class, Race_Undead_Classe_Mage_CreateInfo );
                }

                // Classe_Paladin
                {
                    WowCharacterCreateInfo Race_Undead_Classe_Paladin_CreateInfo = new WowCharacterCreateInfo();

                    Race_Undead_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    RaceUndead.StartBirth( Race_Undead_Classe_Paladin_CreateInfo );
                    ClassePaladin.StartBirth( Race_Undead_Classe_Paladin_CreateInfo );

                    Race_Undead_Classe_Paladin_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Paladin_CreateInfo.Class = (uint)WowClasse.Paladin;

                    playerCreateInfoHandler.AddCreateInfo( Race_Undead_Classe_Paladin_CreateInfo.Race, Race_Undead_Classe_Paladin_CreateInfo.Class, Race_Undead_Classe_Paladin_CreateInfo );
                }

                // Classe_Priest
                {
                    WowCharacterCreateInfo Race_Undead_Classe_Priest_CreateInfo = new WowCharacterCreateInfo();

                    Race_Undead_Classe_Priest_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    RaceUndead.StartBirth( Race_Undead_Classe_Priest_CreateInfo );
                    ClassePriest.StartBirth( Race_Undead_Classe_Priest_CreateInfo );

                    Race_Undead_Classe_Priest_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Priest_CreateInfo.Class = (uint)WowClasse.Priest;

                    playerCreateInfoHandler.AddCreateInfo( Race_Undead_Classe_Priest_CreateInfo.Race, Race_Undead_Classe_Priest_CreateInfo.Class, Race_Undead_Classe_Priest_CreateInfo );
                }

                // Classe_Rogue
                {
                    WowCharacterCreateInfo Race_Undead_Classe_Rogue_CreateInfo = new WowCharacterCreateInfo();

                    Race_Undead_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    RaceUndead.StartBirth( Race_Undead_Classe_Rogue_CreateInfo );
                    ClasseRogue.StartBirth( Race_Undead_Classe_Rogue_CreateInfo );

                    Race_Undead_Classe_Rogue_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Rogue_CreateInfo.Class = (uint)WowClasse.Rogue;

                    playerCreateInfoHandler.AddCreateInfo( Race_Undead_Classe_Rogue_CreateInfo.Race, Race_Undead_Classe_Rogue_CreateInfo.Class, Race_Undead_Classe_Rogue_CreateInfo );
                }

                // Classe_Shaman
                {
                    WowCharacterCreateInfo Race_Undead_Classe_Shaman_CreateInfo = new WowCharacterCreateInfo();

                    Race_Undead_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    RaceUndead.StartBirth( Race_Undead_Classe_Shaman_CreateInfo );
                    ClasseShaman.StartBirth( Race_Undead_Classe_Shaman_CreateInfo );

                    Race_Undead_Classe_Shaman_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Shaman_CreateInfo.Class = (uint)WowClasse.Shaman;

                    playerCreateInfoHandler.AddCreateInfo( Race_Undead_Classe_Shaman_CreateInfo.Race, Race_Undead_Classe_Shaman_CreateInfo.Class, Race_Undead_Classe_Shaman_CreateInfo );
                }

                // Classe_Warlock
                {
                    WowCharacterCreateInfo Race_Undead_Classe_Warlock_CreateInfo = new WowCharacterCreateInfo();

                    Race_Undead_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    RaceUndead.StartBirth( Race_Undead_Classe_Warlock_CreateInfo );
                    ClasseWarlock.StartBirth( Race_Undead_Classe_Warlock_CreateInfo );

                    Race_Undead_Classe_Warlock_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Warlock_CreateInfo.Class = (uint)WowClasse.Warlock;

                    playerCreateInfoHandler.AddCreateInfo( Race_Undead_Classe_Warlock_CreateInfo.Race, Race_Undead_Classe_Warlock_CreateInfo.Class, Race_Undead_Classe_Warlock_CreateInfo );
                }

                // Classe_Warrior
                {
                    WowCharacterCreateInfo Race_Undead_Classe_Warrior_CreateInfo = new WowCharacterCreateInfo();

                    Race_Undead_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    RaceUndead.StartBirth( Race_Undead_Classe_Warrior_CreateInfo );
                    ClasseWarrior.StartBirth( Race_Undead_Classe_Warrior_CreateInfo );

                    Race_Undead_Classe_Warrior_CreateInfo.Race = (uint)WowRace.Undead;
                    Race_Undead_Classe_Warrior_CreateInfo.Class = (uint)WowClasse.Warrior;

                    playerCreateInfoHandler.AddCreateInfo( Race_Undead_Classe_Warrior_CreateInfo.Race, Race_Undead_Classe_Warrior_CreateInfo.Class, Race_Undead_Classe_Warrior_CreateInfo );
                }
            }
            #endregion
        }
    }
}
