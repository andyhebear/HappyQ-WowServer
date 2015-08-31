using System.Linq;
using System.Diagnostics;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.World;
using Demo.Wow.WorldServer.Server;
using Demo.Wow.Database.Ver1a;
using DevExpress.Xpo;
using Demo.Wow.Database;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Character;
using Demo.Wow.WorldServer.Creature;
using Demo.Mmose.Core.Common;
using Demo.Wow.WorldServer.Item;

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
        internal static void World_HandleCharEnum( NetState netState, PacketReader packetReader )
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

            CharEnumSQL charEnumSQL = new CharEnumSQL( extendData, netState );
            WaitExecuteInfo<CharEnumSQL> waitExecuteInfo = new WaitExecuteInfo<CharEnumSQL>( charEnumSQL, WorldPacketHandlers.SQL_HandleCharEnum );

            ProcessServer.WowZoneCluster.World.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SQL_HandleCharEnum( CharEnumSQL sqlInfo )
        {
            XPQuery<Account> accounts = new XPQuery<Account>( OneDatabase.Session );

            var accountList = from account in accounts
                              where account.Oid == sqlInfo.WorldExtendData.CommonData.AccountsGuid
                              select account;


            XPCollection<CharacterBase> characterCollection = null;
            foreach ( Account character in accountList )
            {
                characterCollection = character.Characters;
                break;
            }

            if ( characterCollection == null )
            {
                Debug.WriteLine( "World_PacketHandlers.SQL_HandleCharEnum(...) - characterCollection == null error!" );
                return;
            }

            List<WowCharEnumCharacterInfo> characterInfoList = new List<WowCharEnumCharacterInfo>( (int)WowCharacter.WOW_MAX_CHARACTER_COUNT );

            foreach ( CharacterBase character in characterCollection )
            {
                WowCharEnumCharacterInfo characterInfo = new WowCharEnumCharacterInfo();

                characterInfo.CharacterGuid = (ulong)character.Oid;
                characterInfo.GuildGuid = (uint)character.Account.Oid;
                characterInfo.Name = character.CharacterName;
                characterInfo.Level = (uint)character.Level;
                characterInfo.Race = (uint)character.Race;
                characterInfo.Class = (uint)character.Class;
                characterInfo.ZoneId = (uint)character.ZoneId;
                characterInfo.MapId = (uint)character.MapId;
                characterInfo.PositionX = (uint)character.PositionX;
                characterInfo.PositionY = (uint)character.PositionY;
                characterInfo.PositionZ = (uint)character.PositionZ;
                characterInfo.Gender = (uint)character.Gender;
                characterInfo.Face = (uint)character.Face;
                characterInfo.HairStyle = (uint)character.HairStyle;
                characterInfo.HairColor = (uint)character.HairColor;
                characterInfo.FacialHair = (uint)character.FacialHair;
                characterInfo.IsHideHelm = false;
                characterInfo.IsHideCloak = false;
                characterInfo.IsGhost = character.IsGhost;
                characterInfo.IsNeedRename = character.IsNeedRename;



                XPQuery<CharacterPet> creaturePets = new XPQuery<CharacterPet>( OneDatabase.Session );

                var creaturePetList = from creaturePet in creaturePets
                                      where creaturePet.Owner == character
                                      select creaturePet;

                foreach ( CharacterPet creaturePet in creaturePetList )
                {
                    WowCreatureTemplate creatureTemplate = ProcessServer.WowZoneCluster.World.CreatureTemplateManager.GetCreatureTemplate( (Serial)creaturePet.CreatureTemplateGuid ) as WowCreatureTemplate;
                    if ( creatureTemplate != null )
                    {
                        characterInfo.PetInfo.PetLevel = (uint)creaturePet.Level;
                        characterInfo.PetInfo.PetModelId = creatureTemplate.ModelId;
                        characterInfo.PetInfo.PetFamily = creatureTemplate.Family;
                    }

                    break;
                }



                XPQuery<CharacterItem> characterItems = new XPQuery<CharacterItem>( OneDatabase.Session );

                var characterItemList = from characterItem in characterItems
                                        where characterItem.Owner == character && characterItem.SlotId > EquipmentSlot.EquipmentSlotEnd && characterItem.BagId == InventorySlotBag.InventorySlotEquipmentBag
                                        select characterItem;

                foreach ( CharacterItem characterItem in characterItemList )
                {
                    WowItemTemplate itemTemplate = ProcessServer.WowZoneCluster.World.ItemTemplateManager.GetItemTemplate( (Serial)characterItem.ItemTemplateGuid ) as WowItemTemplate;
                    if ( itemTemplate == null )
                        continue;

                    characterInfo.Equipment[characterItem.SlotId] = itemTemplate;
                }


                characterInfoList.Add( characterInfo );
            }

            sqlInfo.NetState.Send( new Word_CharEnumResponse( characterInfoList.ToArray() ) );
        }
    }
}
