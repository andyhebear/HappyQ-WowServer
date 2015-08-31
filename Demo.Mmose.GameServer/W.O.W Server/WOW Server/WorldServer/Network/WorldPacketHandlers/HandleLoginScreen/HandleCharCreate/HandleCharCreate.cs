using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.DBC;
using Demo.Wow.WorldServer.Item;
using Demo.Wow.WorldServer.World;
using Demo.Wow.WorldServer.Server;
using Demo.Wow.WorldServer.Common;
using Demo.Wow.WorldServer.Character;
using Demo.Wow.WorldServer.Reputation;
using Demo.Wow.WorldServer.Ability.Skill;
using Demo.Wow.WorldServer.Ability.Spell;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class WorldPacketHandlers : BasePacketHandlers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void World_HandleCharCreate( NetState netState, PacketReader packetReader )
        {
            WorldExtendData extendData = netState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleCharEnum(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleCharEnum(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            string strName = packetReader.ReadUTF8StringSafe();
            byte iRace = packetReader.ReadByte();
            byte iClass = packetReader.ReadByte();
            byte iGender = packetReader.ReadByte();
            byte iSkin = packetReader.ReadByte();
            byte iFace = packetReader.ReadByte();
            byte iHairStyle = packetReader.ReadByte();
            byte iHairColor = packetReader.ReadByte();
            byte iFacialHair = packetReader.ReadByte();
            byte iOutFitId = packetReader.ReadByte();

            if ( WorldPacketHandlers.VerifyName( strName ) == false )
            {
                netState.Send( new Word_CharCreateResponseError( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
                return;
            }

            if ( ProcessServer.WowZoneCluster.World.GlobalPlayerInfo.GetPlayerInfo( strName ) != null )
            {
                netState.Send( new Word_CharCreateResponseError( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
                return;
            }

            WowCharacterCreateInfo wowCharacterCreateInfo = ProcessServer.WowZoneCluster.World.GlobalCreateInfo.GetCreateInfo( iRace, iClass );
            if ( wowCharacterCreateInfo == null )
            {
                netState.Send( new Word_CharCreateResponseError( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
                return;
            }

            if ( ( iRace == WowRace.BloodElf || iRace == WowRace.Draenei ) &&
                extendData.CommonData.IsTBC == false )
            {
                netState.Send ( new Word_CharCreateResponseError ( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
                return;
            }

            WowCharacterLevelInfo[] wowCharacterLevelInfo = ProcessServer.WowZoneCluster.World.GlobalLevelInfo.GetLevelInfo( iRace, iClass );
            if ( wowCharacterLevelInfo == null )
            {
                netState.Send( new Word_CharCreateResponseError( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
                return;
            }

            WowCharacter wowPlayerInfo = new WowCharacter();

            wowPlayerInfo.Serial = 0;
            wowPlayerInfo.IsTBC = extendData.CommonData.IsTBC;
            wowPlayerInfo.AccountGuid = extendData.CommonData.AccountsGuid;

            wowPlayerInfo.Name = strName;
            wowPlayerInfo.Race = iRace;
            wowPlayerInfo.Class = iClass;
            wowPlayerInfo.Gender = iGender;
            wowPlayerInfo.Skin = iSkin;
            wowPlayerInfo.Face = iFace;
            wowPlayerInfo.HairStyle = iHairStyle;
            wowPlayerInfo.HairColor = iHairColor;
            wowPlayerInfo.FacialHair = iFacialHair;

            wowPlayerInfo.X = wowCharacterCreateInfo.PositionX;
            wowPlayerInfo.Y = wowCharacterCreateInfo.PositionY;
            wowPlayerInfo.Z = wowCharacterCreateInfo.PositionZ;
            wowPlayerInfo.MapId = wowCharacterCreateInfo.Map;
            wowPlayerInfo.ZoneId = wowCharacterCreateInfo.Zone;

            wowPlayerInfo.BindX = 0;
            wowPlayerInfo.BindY = 0;
            wowPlayerInfo.BindZ = 0;
            wowPlayerInfo.BindMapId = 0;
            wowPlayerInfo.BindZoneId = 0;

            ChrRacesEntry chrRacesEntry = DBCInstances.ChrRacesEntry.LookupIDEntry( iRace );
            if ( chrRacesEntry == null )
            {
                netState.Send( new Word_CharCreateResponseError( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
                return;
            }

            if ( chrRacesEntry.m_TeamId == 7 )
                wowPlayerInfo.TeamId = WowTeam.ALLIANCE;
            else
                wowPlayerInfo.TeamId = WowTeam.HORDE;

            ChrClassesEntry chrClassesEntry = DBCInstances.ChrClassesEntry.LookupIDEntry( iClass );
            if ( chrClassesEntry == null )
            {
                netState.Send( new Word_CharCreateResponseError( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
                return;
            }

            wowPlayerInfo.PowerType = chrClassesEntry.m_PowerType;

            switch ( iRace )
            {
                case (byte)WowRace.Tauren:
                    wowPlayerInfo.TaxiMask[0] = 1 << ( 22 - 1 );

                    break;
                case (byte)WowRace.Human:
                    wowPlayerInfo.TaxiMask[0] = 1 << ( 2 - 1 );
                    
                    break;
                case (byte)WowRace.Dwarf:
                    wowPlayerInfo.TaxiMask[0] = 1 << ( 6 - 1 );

                    break;
                case (byte)WowRace.Gnome:
                    wowPlayerInfo.TaxiMask[0] = 1 << ( 6 - 1 );

                    break;
                case (byte)WowRace.Orc:
                    wowPlayerInfo.TaxiMask[0] = 1 << ( 23 - 1 );

                    break;
                case (byte)WowRace.Troll:
                    wowPlayerInfo.TaxiMask[0] = 1 << ( 23 - 1 );

                    break;
                case (byte)WowRace.Undead:
                    wowPlayerInfo.TaxiMask[0] = 1 << ( 11 - 1 );

                    break;
                case (byte)WowRace.Nightelf:
                    wowPlayerInfo.TaxiMask[0] = 1 << ( 27 - 1 );

                    break;
                case (byte)WowRace.BloodElf:
                    wowPlayerInfo.TaxiMask[2] = 1 << ( 18 - 1 );

                    break;
                case (byte)WowRace.Draenei:
                    wowPlayerInfo.TaxiMask[2] = 1 << ( 30 - 1 );

                    break;
            }

            wowPlayerInfo.Size = ( iRace == WowRace.Tauren ) ? 1.3f : 1.0f;

            wowPlayerInfo.Health = wowCharacterLevelInfo[0].Health;
            wowPlayerInfo.Mana = wowCharacterLevelInfo[0].Mana;
            wowPlayerInfo.Rage = 0;
            wowPlayerInfo.Focus = 0;
            wowPlayerInfo.Energy = 0;

            wowPlayerInfo.MaxHealth = wowCharacterLevelInfo[0].Health;
            wowPlayerInfo.MaxMana = wowCharacterLevelInfo[0].Mana;
            wowPlayerInfo.MaxRage = 0;
            wowPlayerInfo.MaxFocus = 0;
            wowPlayerInfo.MaxEnergy = 0;

            wowPlayerInfo.BaseHealth = wowCharacterLevelInfo[0].Health;
            wowPlayerInfo.BaseMana = wowCharacterLevelInfo[0].Mana;

            wowPlayerInfo.FactionTemplate = 0;
            wowPlayerInfo.Level = 1;

            wowPlayerInfo.Strength = wowCharacterLevelInfo[0].Strength;
            wowPlayerInfo.Agility = wowCharacterLevelInfo[0].Agility;
            wowPlayerInfo.Stamina = wowCharacterLevelInfo[0].Stamina;
            wowPlayerInfo.Intellect = wowCharacterLevelInfo[0].Intellect;
            wowPlayerInfo.Spirit = wowCharacterLevelInfo[0].Spirit;

            wowPlayerInfo.BoundingRadius = 0.388999998569489f;
            wowPlayerInfo.CombatReach = 1.5f;

            if ( iGender == 0 )
            {
                wowPlayerInfo.DisplayId = wowCharacterCreateInfo.MaleDisplayId;
                wowPlayerInfo.NativeDisplayId = wowCharacterCreateInfo.MaleDisplayId;
            }
            else
            {
                wowPlayerInfo.DisplayId = wowCharacterCreateInfo.FemaleDisplayId;
                wowPlayerInfo.NativeDisplayId = wowCharacterCreateInfo.FemaleDisplayId;
            }


            wowPlayerInfo.AttackPower = 0;
            wowPlayerInfo.NextLevelXP = 400;
            wowPlayerInfo.MaxLevel = 10;

            for ( uint iIndex = 0; iIndex < DBCInstances.FactionEntry.Count; iIndex++ )
            {
                FactionEntry factionEntry = DBCInstances.FactionEntry.LookupRowEntry( iIndex );
                if ( factionEntry == null )
                    continue;

                if ( factionEntry.m_RepListId < 0 )
                    continue;

                int iReputation = 0;
                if ( ( factionEntry.m_BaseRepMask1 & ( 1 << ( iRace - 1 ) ) ) != 0 )
                {
                    iReputation = (int)factionEntry.m_BaseRepValue1;
                }
                else if ( ( factionEntry.m_BaseRepMask2 & ( 1 << ( iRace - 1 ) ) ) != 0 )
                {
                    iReputation = (int)factionEntry.m_BaseRepValue2;
                }
                else if ( ( factionEntry.m_BaseRepMask3 & ( 1 << ( iRace - 1 ) ) ) != 0 )
                {
                    iReputation = (int)factionEntry.m_BaseRepValue3;
                }
                else if ( ( factionEntry.m_BaseRepMask4 & ( 1 << ( iRace - 1 ) ) ) != 0 )
                {
                    iReputation = (int)factionEntry.m_BaseRepValue4;
                }
                else continue;

                WowReputation wowReputation = new WowReputation()
                {
                    FactionId = factionEntry.ID,
                    Reputation = iReputation,
                };

                if ( (int)wowReputation.CalcRating() <= (int)WowFactionRating.Hostile )
                    wowReputation.Flag |= (byte)WowFactionFlag.FactionFlagAtWar;

                if ( ( factionEntry.m_Team == 469 && wowPlayerInfo.TeamId == WowTeam.ALLIANCE ) ||
                    ( factionEntry.m_Team == 67 && wowPlayerInfo.TeamId == WowTeam.HORDE ) )
                    wowReputation.Flag |= (byte)WowFactionFlag.FactionFlagVisible;

                wowPlayerInfo.ReputationManager.AddReputation( wowReputation.FactionId, wowReputation );
            }

            foreach ( WowPlayerInfoSkill wowPlayerInfoSkill in wowCharacterCreateInfo.WowPlayerSkills.Skills )
            {
                WowSkillTemplate wowSkillTemplate = ProcessServer.WowZoneCluster.World.GlobalSkillTemplates.GetSkillTemplate( (long)wowPlayerInfoSkill.Skill ) as WowSkillTemplate;
                if ( wowSkillTemplate == null )
                    continue;

                WowSkill wowSkill = new WowSkill()
                {
                    Serial = wowSkillTemplate.SkillId,
                    SkillTemplate = wowSkillTemplate
                };

                wowPlayerInfo.SkillManager.AddSkill( wowSkill.Serial, wowSkill );
            }

            foreach ( WowPlayerInfoSpell wowPlayerInfoSpell in wowCharacterCreateInfo.WowPlayerSpells.Spells )
            {
                WowSpellTemplate wowSpellTemplate = ProcessServer.WowZoneCluster.World.GlobalSpellTemplates.GetSpellTemplate( (long)wowPlayerInfoSpell.Spell ) as WowSpellTemplate;
                if ( wowSpellTemplate == null )
                    continue;

                WowSpell wowSpell = new WowSpell()
                {
                    Serial = wowSpellTemplate.SpellId,
                    SpellTemplate = wowSpellTemplate
                };

                wowPlayerInfo.SpellManager.AddSpell( wowSpell.Serial, wowSpell );
            }

            foreach ( WowPlayerInfoItem wowPlayerInfoItem in wowCharacterCreateInfo.WowPlayerItems.Items )
            {
                WowItemTemplate wowItemTemplate = ProcessServer.WowZoneCluster.World.ItemTemplateManager.GetItemTemplate( (long)wowPlayerInfoItem.ItemId ) as WowItemTemplate;
                if ( wowItemTemplate == null )
                    continue;

                WowItemContainer equipmentBag = wowPlayerInfo.BagManager.EquipmentBag;
                if ( equipmentBag == null )
                    break;

                WowItem wowItem = equipmentBag.FindSubItemAtSlot( wowItemTemplate.InventoryType ) as WowItem;
                if ( wowItem == null )
                {
                    wowItem = new WowItem()
                    {
                        ItemTemplate = wowItemTemplate
                    };

                    equipmentBag.AddSubItem( wowItemTemplate.InventoryType, wowItem );
                }
                else
                {
                    WowItemContainer mainBag = wowPlayerInfo.BagManager.MainBag;
                    if ( mainBag == null )
                        break;

                    wowItem = new WowItem()
                    {
                        ItemTemplate = wowItemTemplate
                    };

                    mainBag.AddToFreeSlot( wowItem );
                }
            }


            foreach ( WowPlayerInfoAction wowPlayerInfoAction in wowCharacterCreateInfo.WowPlayerActions.Actions )
            {
                WowActionBar wowActionBar = new WowActionBar()
                {
                    Serial = wowPlayerInfoAction.Button, 
                    Action = wowPlayerInfoAction.Action, 
                    Type = wowPlayerInfoAction.Type
                };

                wowPlayerInfo.ActionBarManager.AddActionBar( wowActionBar.Serial, wowActionBar );
            }

            if ( wowPlayerInfo.SaveNewCreature() == false )
            {
                netState.Send( new Word_CharCreateResponseError( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
                return;
            }

            ProcessServer.WowZoneCluster.World.GlobalPlayerInfo.AddPlayerInfo( wowPlayerInfo.Name, wowPlayerInfo.Serial, wowPlayerInfo );

            netState.Send( new Word_CharCreateResponse() );
        }

        /// <summary>
        /// 
        /// </summary>
        private static string s_BannedCharacters = "\t\v\b\f\a\n\r\\\"\'? <>[](){}_=+-|/!@#$%^&*~`.,0123456789\0";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        internal static bool VerifyName( string strName )
        {
            if ( strName.Length < 3 || strName.Length > 12 )
                return false;

            foreach ( char charName in strName )
            {
                foreach ( char charBanned in s_BannedCharacters )
                {
                    if ( charName == charBanned )
                        return false;
                }
            }

            return true;
        }

        public void Create()
        {
        }
    }
}
