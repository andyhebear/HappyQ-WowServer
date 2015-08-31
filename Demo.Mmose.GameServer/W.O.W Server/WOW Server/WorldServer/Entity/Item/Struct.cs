using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.Item
{
    /// <summary>
    /// 
    /// </summary>
    public struct WowItemSpell
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowItemSpell( ulong iSpellID, ulong iSpellTrigger, ulong iSpellCharges, ulong iSpellCooldown, ulong iSpellCategory, ulong iSpellCategoryCooldown )
        {
            m_SpellID = iSpellID;
            m_SpellTrigger = iSpellTrigger;
            m_SpellCharges = iSpellCharges;
            m_SpellCooldown = iSpellCooldown;
            m_SpellCategory = iSpellCategory;
            m_SpellCategoryCooldown = iSpellCategoryCooldown;
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_SpellID;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong SpellID
        {
            get { return m_SpellID; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_SpellTrigger;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong SpellTrigger
        {
            get { return m_SpellTrigger; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_SpellCharges;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong SpellCharges
        {
            get { return m_SpellCharges; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_SpellCooldown;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong SpellCooldown
        {
            get { return m_SpellCooldown; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_SpellCategory;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong SpellCategory
        {
            get { return m_SpellCategory; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_SpellCategoryCooldown;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong SpellCategoryCooldown
        {
            get { return m_SpellCategoryCooldown; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iEquipModel"></param>
        /// <param name="iEquipInfo"></param>
        /// <param name="iEquipSlot"></param>
        /// <returns></returns>
        public WowItemSpell GetWowItemSpell( ulong iSpellID, ulong iSpellTrigger, ulong iSpellCharges, ulong iSpellCooldown, ulong iSpellCategory, ulong iSpellCategoryCooldown )
        {
            return new WowItemSpell( iSpellID, iSpellTrigger, iSpellCharges, iSpellCooldown, iSpellCategory, iSpellCategoryCooldown );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowItemAddOnProperty
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowItemAddOnProperty( ulong iAddOnType, ulong iAddOnNumber )
        {
            m_AddOnType = iAddOnType;
            m_AddOnNumber = iAddOnNumber;
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_AddOnType;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong AddOnType
        {
            get { return m_AddOnType; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_AddOnNumber;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong AddOnNumber
        {
            get { return m_AddOnNumber; }
        }
    }

    public struct SlotResult
    {
        /// <summary>
        /// 
        /// </summary>
        private int m_ContainerSlot;
        /// <summary>
        /// 
        /// </summary>
        public int ContainerSlot
        {
            get { return m_ContainerSlot; }
            set { m_ContainerSlot = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int m_Slot;
        /// <summary>
        /// 
        /// </summary>
        public int Slot
        {
            get { return m_Slot; }
            set { m_Slot = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool m_Result;
        /// <summary>
        /// 
        /// </summary>
        public bool Result
        {
            get { return m_Result; }
            set { m_Result = value; }
        }

        public static SlotResult GetDefaultSlotResult()
        {
            SlotResult returnSlotResult = new SlotResult();

            returnSlotResult.m_ContainerSlot = -1;
            returnSlotResult.m_Slot = -1;
            returnSlotResult.m_Result = false;

            return returnSlotResult;
        }
    }
}