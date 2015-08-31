using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Creature.Suit;
using Demo.Wow.WorldServer.Item;
using Demo.Wow.WorldServer.Character;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class WowItemBagManager : BaseBagManager<WowItemContainer, WowItem>
    {
        /// <summary>
        /// 
        /// </summary>
        public WowItemBagManager( WowCharacter player )
        {
            base.Owner = player;

            base.InitBagSlot( InventorySlotBag.InventorySlotEquipmentBag, InventorySlotBag.InventorySlotMainBag );

            m_WowEquipmentBag = new WowItemContainer();
            m_WowEquipmentBag.Item = new WowItem();
            m_WowEquipmentBag.InitContainerSlot( EquipmentSlot.EquipmentSlotStart, (long)EquipmentSlot.EquipmentSlotEnd - 1 );
            base.AddContainer( InventorySlotBag.InventorySlotEquipmentBag, m_WowEquipmentBag );

            m_WowMainBag = new WowItemContainer();
            m_WowMainBag.Item = new WowItem();            
            m_WowMainBag.InitContainerSlot( BagSlotItem.BagSlotItemStart, (long)BagSlotItem.BagSlotItemEnd - 1 );
            base.AddContainer( InventorySlotBag.InventorySlotMainBag, m_WowMainBag );
        }

        /// <summary>
        /// 
        /// </summary>
        private WowItemContainer m_WowEquipmentBag = null;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WowItemContainer EquipmentBag
        {
            get { return m_WowEquipmentBag; }
        }

        /// <summary>
        /// 
        /// </summary>
        private WowItemContainer m_WowMainBag = null;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WowItemContainer MainBag
        {
            get { return m_WowMainBag; }
        }

    }
}
