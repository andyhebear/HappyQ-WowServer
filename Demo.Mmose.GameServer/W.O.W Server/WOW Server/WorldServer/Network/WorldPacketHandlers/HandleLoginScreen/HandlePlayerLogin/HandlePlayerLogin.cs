using System;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.World;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Wow.Database;
using Demo.Wow.Database.Ver1a;
using Demo.Wow.WorldServer.Item;
using Demo.Wow.WorldServer.Server;
using Demo.Wow.WorldServer.Creature;
using Demo.Wow.WorldServer.Character;
using Demo.Wow.WorldServer.Reputation;
using Demo.Wow.WorldServer.Ability.Skill;
using Demo.Wow.WorldServer.Ability.Spell;
using Demo.Wow.WorldServer.Ability.Talent;
using DevExpress.Xpo;

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
        internal static void World_HandlePlayerLogin( NetState netState, PacketReader packetReader )
        {
            WorldExtendData extendData = netState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleCharDelete(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleCharDelete(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            ulong iGuid = packetReader.ReadULong64();

            CharLoginSQL charLoginSQL = new CharLoginSQL( extendData, netState, (long)iGuid );
            WaitExecuteInfo<CharLoginSQL> waitExecuteInfo = new WaitExecuteInfo<CharLoginSQL>( charLoginSQL, WorldPacketHandlers.SQL_HandleCharLogin );

            ProcessServer.WowZoneCluster.World.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SQL_HandleCharLogin( CharLoginSQL sqlInfo )
        {
            //////////////////////////////////////////////////////////////////////////
            // ��ȡ���������Ϣ(CharacterBase)
            // ��ȡ����״̬��Ϣ(CharacterBase)
            // ��ȡ������Ϣ(CharacterItem)
            // ��ȡ������Ϣ(CharacterSkill)
            // ��ȡ������Ϣ(CharacterSpell)
            // ��ȡ�츳��Ϣ(CharactersGift)
            // ��ȡ������Ϣ(CharacterPet)
            // ��ȡ̽����Ϣ(CharacterExplore)
            // ��ȡ������Ϣ(CharacterReputation)
            // ��ȡ�ʼ���Ϣ(Mail)
            // ��ȡ���е���Ϣ(CharactersTaxi)
            // ��ȡ��ݰ�ť��Ϣ(CharacterActionBar)
            // ��ȡ������Ϣ(CharacterSocial)
            // ��ȡ�л���Ϣ(Guild)/
            // ��ȡ�Ŷ���Ϣ(Group)
            // ��ȡ�����Ϣ ?
            // ���㹥����Ϣ
            // ��ȡ��������/������Ϣ(CharacterAura)
            // ��ȡ����/������ȴ��Ϣ(CharacterSpellCooldown)


            //////////////////////////////////////////////////////////////////////////
            // ��ȡ���������Ϣ(CharacterBase)
            XPQuery<CharacterBase> characters = new XPQuery<CharacterBase>( OneDatabase.Session );

            var characterList = from character in characters
                               where character.Oid == sqlInfo.LoginCharGuid
                               select character;

            bool bIsFinde = false;
            WowCharacter wowCharacter = new WowCharacter();
            foreach ( CharacterBase character in characterList )
            {
                //////////////////////////////////////////////////////////////////////////
                // ��ȡ����״̬��Ϣ(CharacterBase)
                wowCharacter.GuildGuid = character.Oid;
                wowCharacter.Name = character.CharacterName;
                wowCharacter.Level = (uint)character.Level;
                wowCharacter.Race = (uint)character.Race;
                wowCharacter.Class = (uint)character.Class;
                wowCharacter.ZoneId = (uint)character.ZoneId;
                wowCharacter.MapId = (uint)character.MapId;
                wowCharacter.X = character.PositionX;
                wowCharacter.Y = character.PositionY;
                wowCharacter.Z = character.PositionZ;
                wowCharacter.Gender = (uint)character.Gender;
                wowCharacter.Face = (uint)character.Face;
                wowCharacter.HairStyle = (uint)character.HairStyle;
                wowCharacter.HairColor = (uint)character.HairColor;
                wowCharacter.FacialHair = (uint)character.FacialHair;



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ������Ϣ(CharacterItem)
                XPQuery<CharacterItem> characterItems = new XPQuery<CharacterItem>( OneDatabase.Session );


                var characterItemList = from characterItem in characterItems
                                        where characterItem.Owner == character && characterItem.BagId > InventorySlotBag.InventorySlotEquipmentBag && characterItem.BagId < InventorySlotBag.InventorySlotMainBag
                                        select characterItem;

                foreach ( CharacterItem characterItem in characterItemList )
                {
                    if ( characterItem.SlotId != BaseItem.SlotNotSet )
                        continue;

                    WowItemContainer wowItemContainer = wowCharacter.BagManager.FindContainerAtSlot( characterItem.BagId ) as WowItemContainer;
                    if ( wowItemContainer != null )
                        continue;
                    else
                    {
                        WowItemTemplate wowItemTemplate = ProcessServer.WowZoneCluster.World.ItemTemplateManager.GetItemTemplate( (Serial)characterItem.ItemTemplateGuid ) as WowItemTemplate;
                        if ( wowItemTemplate == null )
                            continue;

                        wowItemContainer = new WowItemContainer();
                        wowItemContainer.InitContainerSlot( 0, wowItemTemplate.ContainerSlots );
                        wowItemContainer.Item = new WowItem();
                        wowItemContainer.Item.Serial = characterItem.Oid;
                        wowItemContainer.Item.ItemTemplate = wowItemTemplate;

                        wowCharacter.BagManager.AddContainer( characterItem.BagId, wowItemContainer );
                    }
                }


                characterItemList = from characterItem in characterItems
                                        select characterItem;

                foreach ( CharacterItem characterItem in characterItemList )
                {
                    if ( characterItem.SlotId != BaseItem.SlotNotSet )
                        continue;

                    WowItem wowItem = new WowItem();
                    wowItem.Serial = characterItem.Oid;

                    if ( characterItem.BagId == InventorySlotBag.InventorySlotEquipmentBag )
                    {
                        if ( characterItem.SlotId == BaseItem.SlotNotSet ||
                            characterItem.SlotId < EquipmentSlot.EquipmentSlotStart ||
                            characterItem.SlotId >= EquipmentSlot.EquipmentSlotEnd )
                            continue;

                        if ( wowCharacter.BagManager.EquipmentBag.FindSubItemAtSlot( characterItem.SlotId ) != null )
                            continue;

                        wowCharacter.BagManager.EquipmentBag.AddSubItem( characterItem.SlotId, wowItem );
                    }
                    else if ( characterItem.BagId == InventorySlotBag.InventorySlotMainBag )
                    {
                        if ( characterItem.SlotId == BaseItem.SlotNotSet ||
                            characterItem.SlotId < BagSlotItem.BagSlotItemStart ||
                            characterItem.SlotId >= BagSlotItem.BagSlotItemEnd )
                            continue;

                        if ( wowCharacter.BagManager.EquipmentBag.FindSubItemAtSlot( characterItem.SlotId ) != null )
                            continue;

                        wowCharacter.BagManager.MainBag.AddSubItem( characterItem.SlotId, wowItem );
                    }
                    else
                    {
                        WowItemContainer wowItemContainer = wowCharacter.BagManager.FindContainerAtSlot( characterItem.BagId ) as WowItemContainer;
                        if ( wowItemContainer == null )
                            continue;
                        else
                        {
                            if ( wowItemContainer.FindSubItemAtSlot( characterItem.SlotId ) != null )
                                continue;

                            wowItemContainer.AddSubItem( characterItem.SlotId, wowItem );
                        }
                    }
                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ������Ϣ(CharacterSkill)
                XPQuery<CharacterSkill> characterSkills = new XPQuery<CharacterSkill>( OneDatabase.Session );


                var characterSkillList = from characterSkill in characterSkills
                                        where characterSkill.Owner == character
                                         select characterSkill;

                foreach ( CharacterSkill characterSkill in characterSkillList )
                {
                    WowSkill wowSkill = new WowSkill();
                    wowSkill.Serial = characterSkill.SkillId;

                    wowCharacter.SkillManager.AddSkill( wowSkill.Serial, wowSkill );
                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ������Ϣ(CharacterSpell)
                XPQuery<CharacterSpell> characterSpells = new XPQuery<CharacterSpell>( OneDatabase.Session );


                var characterSpellList = from characterSpell in characterSpells
                                         where characterSpell.Owner == character
                                         select characterSpell;

                foreach ( CharacterSpell characterSpell in characterSpellList )
                {
                    WowSpell wowSpell = new WowSpell();
                    wowSpell.Serial = characterSpell.SpellId;

                    wowCharacter.SpellManager.AddSpell( wowSpell.Serial, wowSpell );
                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ�츳��Ϣ(CharactersGift)
                XPQuery<CharactersGift> charactersGifts = new XPQuery<CharactersGift>( OneDatabase.Session );


                var charactersGiftList = from charactersGift in charactersGifts
                                         where charactersGift.Owner == character
                                         select charactersGift;

                foreach ( CharactersGift charactersGift in charactersGiftList )
                {
                    WowTalent wowTalent = new WowTalent();
                    wowTalent.Serial = charactersGift.Oid;

                    wowCharacter.TalentManager.AddTalent( wowTalent.Serial, wowTalent );
                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ������Ϣ(CharacterPet)
                XPQuery<CharacterPet> characterPets = new XPQuery<CharacterPet>( OneDatabase.Session );


                var characterPetList = from characterPet in characterPets
                                         where characterPet.Owner == character
                                         select characterPet;

                foreach ( CharacterPet characterPet in characterPetList )
                {
                    WowPet wowPet = new WowPet();

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ̽����Ϣ(CharacterExplore)
                XPQuery<CharacterExplore> characterExplores = new XPQuery<CharacterExplore>( OneDatabase.Session );


                var characterExploreList = from characterExplore in characterExplores
                                       where characterExplore.Owner == character
                                       select characterExplore;

                foreach ( CharacterExplore characterExplore in characterExploreList )
                {

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ������Ϣ(CharacterReputation)
                XPQuery<CharacterReputation> characterReputations = new XPQuery<CharacterReputation>( OneDatabase.Session );


                var characterReputationList = from characterReputation in characterReputations
                                           where characterReputation.Owner == character
                                           select characterReputation;

                foreach ( CharacterReputation characterReputation in characterReputationList )
                {

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ�ʼ���Ϣ(Mail)
                XPQuery<Mail> mails = new XPQuery<Mail>( OneDatabase.Session );


                var mailList = from mail in mails
                               where mail.Receiver == character
                               select mail;

                foreach ( Mail mail in mailList )
                {

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ���е���Ϣ(CharactersTaxi)
                XPQuery<CharactersTaxi> charactersTaxis = new XPQuery<CharactersTaxi>( OneDatabase.Session );


                var charactersTaxiList = from charactersTaxi in charactersTaxis
                                         where charactersTaxi.Owner == character
                                         select charactersTaxi;

                foreach ( CharactersTaxi charactersTaxi in charactersTaxiList )
                {

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ��ݰ�ť��Ϣ(CharacterActionBar)
                XPQuery<CharacterActionBar> characterActionBars = new XPQuery<CharacterActionBar>( OneDatabase.Session );


                var characterActionBarList = from characterActionBar in characterActionBars
                                         where characterActionBar.Owner == character
                                         select characterActionBar;

                foreach ( CharacterActionBar characterActionBar in characterActionBarList )
                {

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ������Ϣ(CharacterSocial)
                XPQuery<CharacterSocial> characterSocials = new XPQuery<CharacterSocial>( OneDatabase.Session );


                var characterSocialList = from characterSocial in characterSocials
                                          where characterSocial.Owner == character
                                          select characterSocial;

                foreach ( CharacterSocial characterSocial in characterSocialList )
                {

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ�л���Ϣ(Guild)
                XPQuery<Guild> guilds = new XPQuery<Guild>( OneDatabase.Session );


                var guildList = from guild in guilds
                                where guild.Leader == character
                                select guild;

                foreach ( Guild guild in guildList )
                {

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ�Ŷ���Ϣ(Group)
                XPQuery<Group> groups = new XPQuery<Group>( OneDatabase.Session );


                var groupList = from groupItem in groups
                                where groupItem.Leader == character
                                select groupItem;

                foreach ( Group group in groupList )
                {

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ�����Ϣ ?

                //////////////////////////////////////////////////////////////////////////
                // ���㹥����Ϣ

                //////////////////////////////////////////////////////////////////////////
                // ��ȡ��������/������Ϣ(CharacterAura)
                XPQuery<CharacterAura> characterAuras = new XPQuery<CharacterAura>( OneDatabase.Session );


                var characterAuraList = from characterAura in characterAuras
                                        where characterAura.Owner == character
                                        select characterAura;

                foreach ( CharacterAura characterAura in characterAuraList )
                {

                }



                //////////////////////////////////////////////////////////////////////////
                // ��ȡ����/������ȴ��Ϣ(CharacterSpellCooldown)
                XPQuery<CharacterSpellCooldown> characterSpellCooldowns = new XPQuery<CharacterSpellCooldown>( OneDatabase.Session );


                var characterSpellCooldownList = from characterSpellCooldown in characterSpellCooldowns
                                                 where characterSpellCooldown.Owner == character
                                                 select characterSpellCooldown;

                foreach ( CharacterSpellCooldown characterSpellCooldown in characterSpellCooldownList )
                {

                }

                bIsFinde = true;
                break;
            }

            if ( bIsFinde == false )
            {
                Debug.WriteLine( "CHAR_LOGIN_FAILED error!" );

                sqlInfo.NetState.Send( new Word_PlayerLoginFailedResponse( ResponseCodes.CHAR_LOGIN_FAILED ) );
                return;
            }

            sqlInfo.NetState.Send( new Word_PlayerDungeonDifficulty( InstanceMode.MODE_NORMAL ) );

            sqlInfo.NetState.Send( new Word_PlayerLoginVerifyWorld( wowCharacter.MapId, wowCharacter.X, wowCharacter.Y, wowCharacter.Z, wowCharacter.O ) );

            AccountData[] accountDataArray = new AccountData[8];
            for ( int iIndex = 0; iIndex < accountDataArray.Length; iIndex++ )
                accountDataArray[iIndex] = new AccountData();

            sqlInfo.NetState.Send( new Word_PlayerAccountDataMd5( accountDataArray ) );

            sqlInfo.NetState.Send( new Word_PlayerVoiceSystemStatus( 0 ) );// ��Ҫ�����׽���

            sqlInfo.NetState.Send( new Word_PlayerTriggerCinematic( 0 ) );

            sqlInfo.NetState.Send( new Word_PlayerBroadcastMsg( "ookk1234567" ) );

            sqlInfo.NetState.Send( new Word_PlayerSetRestStart() );

            sqlInfo.NetState.Send( new Word_PlayerBindPointUpdate( wowCharacter.X, wowCharacter.Y, wowCharacter.Z, wowCharacter.MapId, wowCharacter.ZoneId ) );

            uint[] uiTutorialArray = new uint[8];
            for ( int iIndex = 0; iIndex < uiTutorialArray.Length; iIndex++ )
                uiTutorialArray[iIndex] = 0;

            sqlInfo.NetState.Send( new Word_PlayerTutorialFlags( uiTutorialArray ) );

            sqlInfo.NetState.Send( new Word_PlayerInitialSpells( wowCharacter.SpellManager.ToArray(), wowCharacter.SpellCooldownManager.ToArray() ) );

            sqlInfo.NetState.Send( new Word_PlayerActionButtons( wowCharacter.ActionBarManager.ToArray() ) );

            sqlInfo.NetState.Send( new Word_PlayerInitializeFactions( wowCharacter.ReputationManager.ToArray() ) );

            sqlInfo.NetState.Send( new Word_PlayerInitWorldStates( wowCharacter.MapId, wowCharacter.ZoneId, 0 ) );

            sqlInfo.NetState.Send( new Word_PlayerLoginSetTimeSpeed( DateTime.Now ) );
        }
    }
}