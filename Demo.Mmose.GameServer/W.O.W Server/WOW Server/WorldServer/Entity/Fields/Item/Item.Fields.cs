using System;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Entity.Common;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ItemField
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterField m_OwningCharacter;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CharacterField OwningCharacter
        {
            get { return m_OwningCharacter; }
            internal set
            {
                m_OwningCharacter = value;
                if ( m_OwningCharacter != null )
                {
                    SetEntityId( (int)ItemFields.OWNER, value.EntityId );
                    //m_record.OwnerId = (int)value.EntityId.Low;
                }
                else
                {
                    SetEntityId( (int)ItemFields.OWNER, EntityId.Zero );
                    //m_record.OwnerId = 0;
                }
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseInventory m_Container;
        #endregion
        /// <summary>
        /// The Inventory of the Container that contains this Item
        /// </summary>
        public BaseInventory Container
        {
            get { return m_Container; }
            internal set
            {
                if ( m_Container != value )
                {
                    if ( value != null )
                    {
                        //var cont = value.Container;
                        //SetEntityId( (int)ItemFields.CONTAINED, cont.EntityId );
                        //m_record.ContainerSlot = cont.EntityId.Low;
                    }
                    else
                    {
                        SetEntityId( (int)ItemFields.CONTAINED, EntityId.Zero );
                        //m_record.ContainerSlot = 0;
                    }
                    m_Container = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private UnitField m_Creator;
        /// <summary>
        /// 
        /// </summary>
        public UnitField Creator
        {
            get { return m_Creator; }
            set
            {
                if ( m_Creator != value )
                {
                    m_Creator = value;
                    if ( m_Creator != null )
                    {
                        SetEntityId( (int)ItemFields.CREATOR, value.EntityId );
                        //m_record.CreatorEntityId = (long)value.EntityId.FullUInt64;
                    }
                    else
                    {
                        SetEntityId( (int)ItemFields.CREATOR, EntityId.Zero );
                        //m_record.CreatorEntityId = 0L;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private UnitField m_GiftCreator;
        /// <summary>
        /// 
        /// </summary>
        public UnitField GiftCreator
        {
            get { return m_GiftCreator; }
            set
            {
                m_GiftCreator = value;
                if ( value != null )
                {
                    SetEntityId( (int)ItemFields.GIFTCREATOR, value.EntityId );
                    //m_record.GiftCreatorEntityId = (long)value.EntityId.FullUInt64;
                }
                else
                {
                    SetEntityId( (int)ItemFields.GIFTCREATOR, EntityId.Zero );
                    //m_record.GiftCreatorEntityId = 0L;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ItemRecord m_Record;
        ///// <summary>
        ///// The Slot of this Item within its <see cref="Container">Container</see>.
        ///// </summary>
        //public int Slot
        //{
        //    get { return m_record.Slot; }
        //    internal set
        //    {
        //        m_record.Slot = value;
        //    }
        //}

        /// <summary>
        /// Current amount of items in this stack.
        /// Setting the Amount to 0 will destroy the Item.
        /// Keep in mind that this is uint and thus can never become smaller than 0!
        /// </summary>
        public uint Amount
        {
            //get { return (uint)m_record.Amount; }
            set
            {
                //if ( value == 0 )
                //{
                //    Destroy();
                //}
                //else
                //{
                    SetUInt32( (int)ItemFields.STACK_COUNT, value );
                    //m_record.Amount = (int)value;
                //}
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint Duration
        {
            //get { return (uint)m_record.Duration; }
            set
            {
                SetUInt32( (int)ItemFields.DURATION, value );
                //m_record.Duration = (int)value;
            }
        }

        #region zh-CHS ItemFields.SPELL_CHARGES | en ItemFields.SPELL_CHARGES

        ///// <summary>
        ///// Charges of the <c>UseSpell</c> of this Item.
        ///// </summary>
        //public uint SpellCharges
        //{
        //    //get { return (uint)m_record.Charges; }
        //    set
        //    {
        //        //SetSpellCharges( m_template.UseSpell.Index, value );
        //        //m_record.Charges = (short)value;
        //    }
        //}

        //public uint GetSpellCharges( uint index )
        //{
        //    return GetUInt32( (int)ItemFields.SPELL_CHARGES + index );
        //}

        //public void ModSpellCharges( uint index, int delta )
        //{
        //    SetUInt32( (int)ItemFields.SPELL_CHARGES + index, (uint)( GetUInt32( (int)ItemFields.SPELL_CHARGES + index ) + delta ) );
        //}

        //public void SetSpellCharges( uint index, uint value )
        //{
        //    SetUInt32( (int)ItemFields.SPELL_CHARGES + index, (uint)value );
        //}

        #endregion

        #region zh-CHS ItemFields.FLAGS | en ItemFields.FLAGS

        /// <summary>
        /// 
        /// </summary>
        public ItemFlags Flags
        {
            //get { return (ItemFlags)m_record.Flags; }
            set
            {
                SetUInt32( (int)ItemFields.FLAGS, (uint)value );
                //m_record.Flags = (int)value;
            }
        }

        //public bool IsSoulbound
        //{
        //    get { return ( Flags & ItemFlags.Soulbound ) != ItemFlags.None; }
        //}

        //public bool IsGiftWrapped
        //{
        //    get { return ( Flags & ItemFlags.GiftWrapped ) != ItemFlags.None; }
        //}

        #endregion

        #region zh-CHS ItemFields.ENCHANTMENT | en ItemFields.ENCHANTMENT

        /// <summary>
        /// 
        /// </summary>
        public uint EnchantmentBase
        {
            get { return GetUInt32( (int)ItemFields.ENCHANTMENT ); }
            set { SetUInt32( (int)ItemFields.ENCHANTMENT, value ); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        private int GetEnchantmentBase( EnchantmentSlot slot )
        {
            return (int)(int)ItemFields.ENCHANTMENT + ( (int)slot * 3 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="value"></param>
        public void SetEnchantId( EnchantmentSlot slot, uint value )
        {
            int enchBase = GetEnchantmentBase( slot );

            SetUInt32( enchBase, value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="value"></param>
        public void SetEnchantDuration( EnchantmentSlot slot, uint value )
        {
            int enchBase = GetEnchantmentBase( slot );

            SetUInt32( enchBase + 1, value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="value"></param>
        public void SetEnchantCharges( EnchantmentSlot slot, uint value )
        {
            int enchBase = GetEnchantmentBase( slot );

            SetUInt32( enchBase + 2, value );
        }

        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PropertySeed;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PropertySeed
        {
            get { return m_PropertySeed; }
            set
            {
                m_PropertySeed = value;
                SetUInt32( (int)ItemFields.PROPERTY_SEED, m_PropertySeed );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint RandomPropertiesId
        {
            //get { return (uint)m_record.RandomProperty; }
            set
            {

                SetUInt32( (int)ItemFields.RANDOM_PROPERTIES_ID, value );
                //m_record.RandomProperty = (int)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint TextId
        {
            //get { return (uint)m_record.TextId; }
            set
            {
                SetUInt32( (int)ItemFields.TEXT_ID, value );
                //m_record.TextId = (int)value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public uint Durability
        {
            //get { return (uint)m_record.Durability; }
            set
            {
                SetUInt32( (int)ItemFields.DURABILITY, value );
                //m_record.Durability = (int)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint MaxDurability
        {
            get
            {
                return GetUInt32( (int)ItemFields.MAXDURABILITY );
                //return m_Template.MaxDurability;
            }
            protected set
            {
                SetUInt32( (int)ItemFields.MAXDURABILITY, value );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RepairDurability()
        {
            this.Durability = MaxDurability;
        }

        #region IWeapon
        //public DamageInfo[] Damages
        //{
        //    get
        //    {
        //        return m_template.Damages;
        //    }
        //}

        //public SkillId Skill
        //{
        //    get
        //    {
        //        return m_template.ItemProfession;
        //    }
        //}

        public bool IsRanged
        {
            get { return false; }
        }

        public bool IsMelee
        {
            get { return true; }
        }

        /// <summary>
        /// The minimum Range of this weapon
        /// </summary>
        public float MinRange
        {
            get { return 0f; }
        }

        /// <summary>
        /// The maximum Range of this Weapon
        /// </summary>
        public float MaxRange
        {
            get { return 2f; }
        }

        /// <summary>
        /// The time in milliseconds between 2 attacks
        /// </summary>
        public uint AttackTime
        {
            get { return (uint)2000; }
        }
        #endregion
    }
}
