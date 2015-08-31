using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.Database.Ver1a;
using DevExpress.Xpo;
using Demo.Wow.Database;
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Entity.Suit.Ability.Skill;
using Demo.Wow.WorldServer.Ability.Skill;
using Demo.Mmose.Core.Entity.Suit.Ability.Spell;
using Demo.Wow.WorldServer.Ability.Spell;
using Demo.Wow.WorldServer.Item;
using Demo.Mmose.Core.Entity.Item;
using Demo.Wow.WorldServer.Reputation;

namespace Demo.Wow.WorldServer.Character
{
    public partial class WowCharacter
    {
        #region zh-CHS Creature Save 方法 | en Creature Save Methods
        /// <summary>
        /// 
        /// </summary>
        internal bool SaveNewCreature()
        {
            XPQuery<CharacterBase> characters = new XPQuery<CharacterBase>( OneDatabase.Session );

            var characterList = from character in characters
                                where character.Oid == m_CharacterAccountGuid
                                select character;

            if ( characterList.Count() > WOW_MAX_CHARACTER_COUNT ) // 人物过多
                return false;

            CharacterBase newCharacter = new CharacterBase( OneDatabase.Session );
            this.Serial = newCharacter.Oid;
            newCharacter.CharacterName = this.Name;
            //newCharacter.Account = this.AccountGuid;
            newCharacter.Gender = (byte)this.Gender;
            newCharacter.Skin = (byte)this.Skin;
            newCharacter.Face = (byte)this.Face;
            newCharacter.HairStyle = (byte)this.HairColor;
            newCharacter.HairColor = (byte)this.HairColor;
            newCharacter.FacialHair = (byte)this.FacialHair;
            newCharacter.Race = (byte)this.Race;
            newCharacter.Class = (int)this.Class;
            newCharacter.Level = (int)this.Level;
            newCharacter.MapId = (int)this.MapId;
            newCharacter.ZoneId = (int)this.ZoneId;
            newCharacter.PositionX = this.X;
            newCharacter.PositionY = this.Y;
            newCharacter.PositionZ = this.Z;
            newCharacter.Orientation = this.O;
            newCharacter.Guild = null;
            // 人物的坐骑航线标记点 32位值|32位值|32位值|32位值
            // 00000000000000000000000000000000|...|...|...
            // 以位域标示 1~TaxiId~32| 32~TaxiId~64|65~TaxiId~96|96~TaxiId~128
            newCharacter.TaxiMask = this.TaxiMask;
            newCharacter.IsGhost = false;
            newCharacter.IsCinematic = false;
            newCharacter.IsNeedRename = false;
            newCharacter.TotalTime = 0;
            newCharacter.LevelTime = 0;
            newCharacter.LogoutTime = DateTime.Now;
            newCharacter.CreatingTime = DateTime.Now;
            newCharacter.IsBanned = false;
            newCharacter.IsDelete = false;
            newCharacter.DeleteTime = DateTime.Now;

            CharacterHomeBind newCharacterHomeBind = new CharacterHomeBind( OneDatabase.Session );
            //newCharacterHomeBind.Owner = newCharacter.Oid;
            newCharacterHomeBind.MapId = (int)this.BindMapId;
            newCharacterHomeBind.ZoneId = (int)this.BindZoneId;
            newCharacterHomeBind.PositionX = this.BindX;
            newCharacterHomeBind.PositionY = this.BindY;
            newCharacterHomeBind.PositionZ = this.BindZ;

            foreach ( BaseSkill baseSkill in SkillManager.ToArray() )
            {
                WowSkill wowSkill = baseSkill as WowSkill;
                if ( wowSkill == null )
                    continue;

                if ( wowSkill.Serial != 0 )
                    continue;

                WowSkillTemplate wowSkillTemplate = wowSkill.SkillTemplate as WowSkillTemplate;
                if ( wowSkillTemplate == null )
                    continue;

                CharacterSkill newCharactersSkill = new CharacterSkill( OneDatabase.Session );
                wowSkill.Serial = newCharactersSkill.Oid;

                //newCharactersSkill.Owner = newCharacter.Oid;
                newCharactersSkill.SkillId = wowSkillTemplate.Serial;
                newCharactersSkill.Value = wowSkill.Level;
            }

            foreach ( BaseSpell baseSpell in SpellManager.ToArray() )
            {
                WowSpell wowSpell = baseSpell as WowSpell;
                if ( wowSpell == null )
                    continue;

                if ( wowSpell.Serial != 0 )
                    continue;

                WowSpellTemplate wowSpellTemplate = baseSpell.SpellTemplate as WowSpellTemplate;
                if ( wowSpellTemplate == null )
                    continue;

                CharacterSpell newCharacterSpell = new CharacterSpell( OneDatabase.Session );
                wowSpell.Serial = newCharacterSpell.Oid;

                //newCharacterSpell.Owner = newCharacter.Oid;
                newCharacterSpell.SpellId = wowSpellTemplate.Serial;
                //newCharacterSpell.Slot = baseSpell.Slot;
            }

            foreach ( WowActionBar baseActionBar in ActionBarManager.ToArray() )
            {
                WowActionBar wowActionBar = baseActionBar as WowActionBar;
                if ( baseActionBar == null )
                    continue;

                if ( wowActionBar.Serial != 0 )
                    continue;

                CharacterActionBar newCharactersAction = new CharacterActionBar( OneDatabase.Session );
                wowActionBar.Serial = newCharactersAction.Oid;

                //newCharactersAction.Owner= newCharacter.Oid;
                newCharactersAction.Slot = wowActionBar.ActionBarSlotId;
                newCharactersAction.ActionId = wowActionBar.Action;
                newCharactersAction.ActionType = wowActionBar.Type;
            }

            foreach ( BaseItem baseItem in BagManager.EquipmentBag.SubItemsToArray() )
            {
                WowItem wowItem = baseItem as WowItem;
                if ( wowItem == null )
                    continue;

                if ( wowItem.Serial != 0 )
                    continue;

                WowItemTemplate wowItemTemplate = wowItem.ItemTemplate as WowItemTemplate;
                if ( wowItemTemplate == null )
                    continue;

                CharacterItem newCharactersItem = new CharacterItem( OneDatabase.Session );
                wowItem.Serial = newCharactersItem.Oid;

                //newCharactersItem.Owner = newCharacter.Oid;
                newCharactersItem.ItemTemplateGuid = (ulong)wowItemTemplate.Serial;
                newCharactersItem.Amount = (int)wowItem.Amount;
                newCharactersItem.BagId = (int)BagManager.EquipmentBag.Item.SlotId;
                newCharactersItem.SlotId = (int)wowItem.SlotId;
            }

            foreach ( WowReputation baseReputation in ReputationManager.ToArray() )
            {
                WowReputation wowReputation = baseReputation as WowReputation;
                if ( wowReputation == null )
                    continue;

                if ( wowReputation.Serial != 0 )
                    continue;

                CharacterReputation newCharacterReputation = new CharacterReputation( OneDatabase.Session );
                wowReputation.Serial = newCharacterReputation.Oid;

                //newCharacterReputation.Owner = newCharacter.Oid;
                newCharacterReputation.FactionId = wowReputation.FactionId;
                newCharacterReputation.Reputation = wowReputation.Reputation;
                newCharacterReputation.Flag = wowReputation.Flag;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void WowCharacterSave( object sender, WorldEntityEventArgs eventArgs )
        {
            XPQuery<CharacterBase> characters = new XPQuery<CharacterBase>( OneDatabase.Session );

            var characterList = from character in characters
                                where character.Oid == m_CharacterAccountGuid
                                select character;

            bool bIsFinde = false;
            foreach ( CharacterBase character in characterList )
            {
                CharacterBase newCharacter = new CharacterBase( OneDatabase.Session );
                this.Serial = newCharacter.Oid;
                newCharacter.CharacterName = this.Name;
                //newCharacter.Account = this.AccountGuid;
                newCharacter.Gender = (byte)this.Gender;
                newCharacter.Skin = (byte)this.Skin;
                newCharacter.Face = (byte)this.Face;
                newCharacter.HairStyle = (byte)this.HairColor;
                newCharacter.HairColor = (byte)this.HairColor;
                newCharacter.FacialHair = (byte)this.FacialHair;
                newCharacter.Race = (byte)this.Race;
                newCharacter.Class = (int)this.Class;
                newCharacter.Level = (int)this.Level;
                newCharacter.MapId = (int)this.MapId;
                newCharacter.ZoneId = (int)this.ZoneId;
                newCharacter.PositionX = this.X;
                newCharacter.PositionY = this.Y;
                newCharacter.PositionZ = this.Z;
                newCharacter.Orientation = this.O;
                newCharacter.Guild = null;
                // 人物的坐骑航线标记点 32位值|32位值|32位值|32位值
                // 00000000000000000000000000000000|...|...|...
                // 以位域标示 1~TaxiId~32| 32~TaxiId~64|65~TaxiId~96|96~TaxiId~128
                newCharacter.TaxiMask = this.TaxiMask;
                newCharacter.IsGhost = false;
                newCharacter.IsCinematic = false;
                newCharacter.IsNeedRename = false;
                newCharacter.TotalTime = 0;
                newCharacter.LevelTime = 0;
                newCharacter.LogoutTime = DateTime.Now;
                newCharacter.CreatingTime = DateTime.Now;
                newCharacter.IsBanned = false;
                newCharacter.IsDelete = false;
                newCharacter.DeleteTime = DateTime.Now;

                CharacterHomeBind newCharacterHomeBind = new CharacterHomeBind( OneDatabase.Session );
                //newCharacterHomeBind.Owner = newCharacter.ID;
                newCharacterHomeBind.MapId = (int)this.BindMapId;
                newCharacterHomeBind.ZoneId = (int)this.BindZoneId;
                newCharacterHomeBind.PositionX = this.BindX;
                newCharacterHomeBind.PositionY = this.BindY;
                newCharacterHomeBind.PositionZ = this.BindZ;

                foreach ( BaseSkill baseSkill in SkillManager.ToArray() )
                {
                    WowSkill wowSkill = baseSkill as WowSkill;
                    if ( wowSkill == null )
                        continue;

                    if ( wowSkill.Serial != 0 )
                        continue;

                    WowSkillTemplate wowSkillTemplate = wowSkill.SkillTemplate as WowSkillTemplate;
                    if ( wowSkillTemplate == null )
                        continue;

                    CharacterSkill newCharactersSkill = new CharacterSkill( OneDatabase.Session );
                    wowSkill.Serial = newCharactersSkill.Oid;

                    //newCharactersSkill.Owner = newCharacter.ID;
                    newCharactersSkill.SkillId = wowSkillTemplate.Serial;
                    newCharactersSkill.Value = wowSkill.Level;
                }

                foreach ( BaseSpell baseSpell in SpellManager.ToArray() )
                {
                    WowSpell wowSpell = baseSpell as WowSpell;
                    if ( wowSpell == null )
                        continue;

                    if ( wowSpell.Serial != 0 )
                        continue;

                    WowSpellTemplate wowSpellTemplate = baseSpell.SpellTemplate as WowSpellTemplate;
                    if ( wowSpellTemplate == null )
                        continue;

                    CharacterSpell newCharacterSpell = new CharacterSpell( OneDatabase.Session );
                    wowSpell.Serial = newCharacterSpell.Oid;

                    //newCharacterSpell.Owner = newCharacter.ID;
                    newCharacterSpell.SpellId = wowSpellTemplate.Serial;
                    //newCharacterSpell.Slot = baseSpell.Slot;
                }

                foreach ( WowActionBar baseActionBar in ActionBarManager.ToArray() )
                {
                    WowActionBar wowActionBar = baseActionBar as WowActionBar;
                    if ( baseActionBar == null )
                        continue;

                    if ( wowActionBar.Serial != 0 )
                        continue;

                    CharacterActionBar newCharactersAction = new CharacterActionBar( OneDatabase.Session );
                    wowActionBar.Serial = newCharactersAction.Oid;

                    //newCharactersAction.Owner = newCharacter.ID;
                    newCharactersAction.Slot = wowActionBar.ActionBarSlotId;
                    newCharactersAction.ActionId = wowActionBar.Action;
                    newCharactersAction.ActionType = wowActionBar.Type;
                }

                foreach ( BaseItem baseItem in BagManager.EquipmentBag.SubItemsToArray() )
                {
                    WowItem wowItem = baseItem as WowItem;
                    if ( wowItem == null )
                        continue;

                    if ( wowItem.Serial != 0 )
                        continue;

                    WowItemTemplate wowItemTemplate = wowItem.ItemTemplate as WowItemTemplate;
                    if ( wowItemTemplate == null )
                        continue;

                    CharacterItem newCharactersItem = new CharacterItem( OneDatabase.Session );
                    wowItem.Serial = newCharactersItem.Oid;

                    //newCharactersItem.Owner = newCharacter.ID;
                    newCharactersItem.ItemTemplateGuid = (ulong)wowItemTemplate.Serial;
                    newCharactersItem.Amount = (int)wowItem.Amount;
                    newCharactersItem.BagId = (int)BagManager.EquipmentBag.Item.SlotId;
                    newCharactersItem.SlotId = (int)wowItem.SlotId;
                }

                foreach ( WowReputation baseReputation in ReputationManager.ToArray() )
                {
                    WowReputation wowReputation = baseReputation as WowReputation;
                    if ( wowReputation == null )
                        continue;

                    if ( wowReputation.Serial != 0 )
                        continue;

                    CharacterReputation newCharacterReputation = new CharacterReputation( OneDatabase.Session );
                    wowReputation.Serial = newCharacterReputation.Oid;

                    //newCharacterReputation.Owner = newCharacter.ID;
                    newCharacterReputation.FactionId = wowReputation.FactionId;
                    newCharacterReputation.Reputation = wowReputation.Reputation;
                    newCharacterReputation.Flag = wowReputation.Flag;
                }

                break;
            }
        }
        #endregion
    }
}
