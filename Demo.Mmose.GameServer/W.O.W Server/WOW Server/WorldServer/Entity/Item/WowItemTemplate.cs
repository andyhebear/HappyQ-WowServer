using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Item;

namespace Demo.Wow.WorldServer.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class WowItemTemplate : BaseItemTemplate
    {
        #region zh-CHS 物品的基本信息 | en

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemClass = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ItemClass
        {
            get { return m_ItemClass; }
            set { m_ItemClass = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemSubclass = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ItemSubclass
        {
            get { return m_ItemSubclass; }
            set { m_ItemSubclass = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string[] m_ItemName = new string[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string[] Name
        {
            get { return m_ItemName; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemModelID = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ModelID
        {
            get { return m_ItemModelID; }
            set { m_ItemModelID = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemQuality = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Quality
        {
            get { return m_ItemQuality; }
            set { m_ItemQuality = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemFlags = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Flag
        {
            get { return m_ItemFlags; }
            set { m_ItemFlags = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemBuyCount = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint BuyCount
        {
            get { return m_ItemBuyCount; }
            set { m_ItemBuyCount = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemBuyPrice = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint BuyPrice
        {
            get { return m_ItemBuyPrice; }
            set { m_ItemBuyPrice = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemSellPrice = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint SellPrice
        {
            get { return m_ItemSellPrice; }
            set { m_ItemSellPrice = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemInventoryType = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint InventoryType
        {
            get { return m_ItemInventoryType; }
            set { m_ItemInventoryType = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemAllowableClass = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint AllowableClass
        {
            get { return m_ItemAllowableClass; }
            set { m_ItemAllowableClass = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemAllowableRace = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint AllowableRace
        {
            get { return m_ItemAllowableRace; }
            set { m_ItemAllowableRace = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemLevel = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ItemLevel
        {
            get { return m_ItemLevel; }
            set { m_ItemLevel = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemRequiredLevel = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RequiredLevel
        {
            get { return m_ItemRequiredLevel; }
            set { m_ItemRequiredLevel = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemRequiredSkill = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RequiredSkill
        {
            get { return m_ItemRequiredSkill; }
            set { m_ItemRequiredSkill = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemRequiredSkillRank = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RequiredSkillRank
        {
            get { return m_ItemRequiredSkillRank; }
            set { m_ItemRequiredSkillRank = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemRequiredSpell = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RequiredSpell
        {
            get { return m_ItemRequiredSpell; }
            set { m_ItemRequiredSpell = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemRequiredHonorRank = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RequiredHonorRank
        {
            get { return m_ItemRequiredHonorRank; }
            set { m_ItemRequiredHonorRank = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemRequiredCityRank = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RequiredCityRank
        {
            get { return m_ItemRequiredCityRank; }
            set { m_ItemRequiredCityRank = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemRequiredReputationFaction = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RequiredReputationFaction
        {
            get { return m_ItemRequiredReputationFaction; }
            set { m_ItemRequiredReputationFaction = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemRequiredReputationRank = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RequiredReputationRank
        {
            get { return m_ItemRequiredReputationRank; }
            set { m_ItemRequiredReputationRank = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemMaxCount = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxCount
        {
            get { return m_ItemMaxCount; }
            set { m_ItemMaxCount = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemStackable;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ItemStackable
        {
            get { return m_ItemStackable; }
            set { m_ItemStackable = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemBonding = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Bonding
        {
            get { return m_ItemBonding; }
            set { m_ItemBonding = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_ItemDescription = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return m_ItemDescription; }
            set { m_ItemDescription = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemPageText = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PageText
        {
            get { return m_ItemPageText; }
            set { m_ItemPageText = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemPageMaterial = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PageMaterial
        {
            get { return m_ItemPageMaterial; }
            set { m_ItemPageMaterial = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemLanguageID = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint LanguageID
        {
            get { return m_ItemLanguageID; }
            set { m_ItemLanguageID = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemMaterial = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Material
        {
            get { return m_ItemMaterial; }
            set { m_ItemMaterial = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemSheath = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Sheath
        {
            get { return m_ItemSheath; }
            set { m_ItemSheath = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemExtra = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Extra
        {
            get { return m_ItemExtra; }
            set { m_ItemExtra = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemBlock = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Block
        {
            get { return m_ItemBlock; }
            set { m_ItemBlock = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemItemset = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Itemset
        {
            get { return m_ItemItemset; }
            set { m_ItemItemset = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemMaxDurability = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaxDurability
        {
            get { return m_ItemMaxDurability; }
            set { m_ItemMaxDurability = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemContainerSlots = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ContainerSlots
        {
            get { return m_ItemContainerSlots; }
            set { m_ItemContainerSlots = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemBagFamily = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint BagFamily
        {
            get { return m_ItemBagFamily; }
            set { m_ItemBagFamily = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemArmor = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Armor
        {
            get { return m_ItemArmor; }
            set { m_ItemArmor = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemAttackDelay = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint AttackDelay
        {
            get { return m_ItemAttackDelay; }
            set { m_ItemAttackDelay = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemAmmoType = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint AmmoType
        {
            get { return m_ItemAmmoType; }
            set { m_ItemAmmoType = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemArea = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Area
        {
            get { return m_ItemArea; }
            set { m_ItemArea = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemLockID = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint LockID
        {
            get { return m_ItemLockID; }
            set { m_ItemLockID = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemRangedModRange = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RangedModRange
        {
            get { return m_ItemRangedModRange; }
            set { m_ItemRangedModRange = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_ItemStartQuest = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong StartQuest
        {
            get { return m_ItemStartQuest; }
            set { m_ItemStartQuest = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowItemSpell[] m_ItemSpell = new WowItemSpell[5];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowItemSpell[] Spell
        {
            get { return m_ItemSpell; }
        }

        #endregion

        #region zh-CHS 护甲抗性 | en

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemHolyResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint HolyResistance
        {
            get { return m_ItemHolyResistance; }
            set { m_ItemHolyResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemFireResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FireResistance
        {
            get { return m_ItemFireResistance; }
            set { m_ItemFireResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemNatureResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint NatureResistance
        {
            get { return m_ItemNatureResistance; }
            set { m_ItemNatureResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemFrostResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FrostResistance
        {
            get { return m_ItemFrostResistance; }
            set { m_ItemFrostResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemShadowResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ShadowResistance
        {
            get { return m_ItemShadowResistance; }
            set { m_ItemShadowResistance = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemArcaneResistance = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ArcaneResistance
        {
            get { return m_ItemArcaneResistance; }
            set { m_ItemArcaneResistance = value; }
        }

        #endregion

        #region zh-CHS 伤害属性 | en

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemHolyMinDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint HolyMinDamage
        {
            get { return m_ItemHolyMinDamage; }
            set { m_ItemHolyMinDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemHolyMaxDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint HolyMaxDamage
        {
            get { return m_ItemHolyMaxDamage; }
            set { m_ItemHolyMaxDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemFireMinDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FireMinDamage
        {
            get { return m_ItemFireMinDamage; }
            set { m_ItemFireMinDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemFireMaxDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FireMaxDamage
        {
            get { return m_ItemFireMaxDamage; }
            set { m_ItemFireMaxDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemNatureMinDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint NatureMinDamage
        {
            get { return m_ItemNatureMinDamage; }
            set { m_ItemNatureMinDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemNatureMaxDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint NatureMaxDamage
        {
            get { return m_ItemNatureMaxDamage; }
            set { m_ItemNatureMaxDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemFrostMinDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FrostMinDamage
        {
            get { return m_ItemFrostMinDamage; }
            set { m_ItemFrostMinDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemFrostMaxDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FrostMaxDamage
        {
            get { return m_ItemFrostMaxDamage; }
            set { m_ItemFrostMaxDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemShadowMinDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ShadowMinDamage
        {
            get { return m_ItemShadowMinDamage; }
            set { m_ItemShadowMinDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemShadowMaxDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ShadowMaxDamage
        {
            get { return m_ItemShadowMaxDamage; }
            set { m_ItemShadowMaxDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemArcaneMinDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ArcaneMinDamage
        {
            get { return m_ItemArcaneMinDamage; }
            set { m_ItemArcaneMinDamage = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemArcaneMaxDamage = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ArcaneMaxDamage
        {
            get { return m_ItemArcaneMaxDamage; }
            set { m_ItemArcaneMaxDamage = value; }
        }

        #endregion

        #region zh-CHS 附加属性 | en

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowItemAddOnProperty[] m_ItemAddOnProperty = new WowItemAddOnProperty[10];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowItemAddOnProperty[] AddOnProperty
        {
            get { return m_ItemAddOnProperty; }
        }

        #endregion
    }
}
