using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Creature.Suit;
using Demo.Wow.WorldServer.Item;
using Demo.Wow.WorldServer.Character;

namespace Demo.Wow.WorldServer.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class WowItemBankManager : BaseBagManager<WowItemContainer, WowItem>
    {
        /// <summary>
        /// 
        /// </summary>
        public WowItemBankManager( WowCharacter player )
        {
            base.Owner = player;

            base.InitBagSlot( InventorySlotBank.InventorySlotDefaultBank, InventorySlotBank.InventorySlotBankEnd - 1 );

            WowItemContainer baseItemContainerDefaultBag = new WowItemContainer();
            baseItemContainerDefaultBag.Item = new WowItem();
            baseItemContainerDefaultBag.InitContainerSlot( BankSlotItem.BankSlotItemStart, (long)BankSlotItem.BankSlotItemEnd - 1 );
            base.AddContainer( InventorySlotBank.InventorySlotDefaultBank, baseItemContainerDefaultBag );
        }
    }
}
