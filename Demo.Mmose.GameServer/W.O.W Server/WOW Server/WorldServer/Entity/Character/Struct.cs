using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Collections;

namespace Demo.Wow.WorldServer.Character
{
    /// <summary>
    /// 
    /// </summary>
    public struct WowPlayerInfoSpell
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowPlayerInfoSpell( uint iSpellId )
        {
            m_SpellId = iSpellId;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_SpellId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Spell
        {
            get { return m_SpellId; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowPlayerInfoSpells
    {
        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<uint, WowPlayerInfoSpell> m_Spells = new SafeDictionary<uint, WowPlayerInfoSpell>();
        #endregion
        /// <summary>
        /// 法术添加
        /// </summary>
        /// <param name="iSpellId"></param>
        public void Add( uint iSpellId )
        {
            m_Spells.Add( iSpellId, new WowPlayerInfoSpell( iSpellId ) );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 法术编号
        /// </summary>
        public WowPlayerInfoSpell[] Spells
        {
            get { return m_Spells.ToArrayValues(); }
        }

        /// <summary>
        /// 法术数量
        /// </summary>
        public int Count
        {
            get { return m_Spells.Count; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowPlayerInfoSkill
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowPlayerInfoSkill( ulong iSkillId )
        {
            m_SkillId = iSkillId;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_SkillId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong Skill
        {
            get { return m_SkillId; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        /// <returns></returns>
        public WowPlayerInfoSkill GetWowPlayerSkill( ulong iSkillId )
        {
            return new WowPlayerInfoSkill( iSkillId );
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowPlayerInfoSkills
    {
        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<ulong, WowPlayerInfoSkill> m_Skills = new SafeDictionary<ulong, WowPlayerInfoSkill>();
        #endregion
        /// <summary>
        /// 技能添加
        /// </summary>
        /// <param name="iSpellId"></param>
        public void Add( ulong iSkillId )
        {
            m_Skills.Add( iSkillId, new WowPlayerInfoSkill( iSkillId ) );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 技能编号
        /// </summary>
        public WowPlayerInfoSkill[] Skills
        {
            get { return m_Skills.ToArrayValues(); }
        }

        /// <summary>
        /// 技能数量
        /// </summary>
        public int Count
        {
            get { return m_Skills.Count; }
        }
        #endregion
    }


    /// <summary>
    /// 
    /// </summary>
    public struct WowPlayerInfoItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowPlayerInfoItem( ulong iItemId, uint iAmount )
        {
            m_ItemId = iItemId;
            m_Amount = iAmount;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_ItemId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong ItemId
        {
            get { return m_ItemId; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Amount;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Amount
        {
            get { return m_Amount; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowPlayerInfoItems
    {
        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<ulong, WowPlayerInfoItem> m_Items = new SafeDictionary<ulong, WowPlayerInfoItem>();
        #endregion
        /// <summary>
        /// 技能添加
        /// </summary>
        /// <param name="iSpellId"></param>
        public void Add( ulong iItemId, uint iAmount )
        {
            m_Items.Add( iItemId, new WowPlayerInfoItem( iItemId, iAmount ) );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 技能编号
        /// </summary>
        public WowPlayerInfoItem[] Items
        {
            get { return m_Items.ToArrayValues(); }
        }

        /// <summary>
        /// 技能数量
        /// </summary>
        public int Count
        {
            get { return m_Items.Count; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowPlayerInfoAction
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowPlayerInfoAction( uint iButton, uint iActionId, uint iType, uint iMisc )
        {
            m_ButtonId = iButton;
            m_ActionId = iActionId;
            m_TypeId = iType;
            m_MiscId = iMisc;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ButtonId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Button
        {
            get { return m_ButtonId; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ActionId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Action
        {
            get { return m_ActionId; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_TypeId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Type
        {
            get { return m_TypeId; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MiscId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Misc
        {
            get { return m_MiscId; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowPlayerInfoActions
    {
        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<uint, WowPlayerInfoAction> m_Actions = new SafeDictionary<uint, WowPlayerInfoAction>();
        #endregion
        /// <summary>
        /// 技能添加
        /// </summary>
        /// <param name="iSpellId"></param>
        public void Add( uint iButton, uint iActionId, uint iType, uint iMisc )
        {
            m_Actions.Add( iButton, new WowPlayerInfoAction( iButton, iActionId, iType, iMisc ) );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 技能编号
        /// </summary>
        public WowPlayerInfoAction[] Actions
        {
            get { return m_Actions.ToArrayValues(); }
        }

        /// <summary>
        /// 技能数量
        /// </summary>
        public int Count
        {
            get { return m_Actions.Count; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowFactionReputation
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowFactionReputation( uint iFaction, int iStanding, byte iFlag )
        {
            m_Faction = iFaction;
            m_Standing = iStanding;
            m_Flag = iFlag;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Faction;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Faction
        {
            get { return m_Faction; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Standing;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Standing
        {
            get { return m_Standing; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_Flag;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte Flag
        {
            get { return m_Flag; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Positive()
        {
            return m_Standing >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WowFactionRating CalcRating()
        {
            if ( m_Standing >= 42000 )
                return WowFactionRating.Exalted;
            if ( m_Standing >= 21000 )
                return WowFactionRating.Revered;
            if ( m_Standing >= 9000 )
                return WowFactionRating.Honored;
            if ( m_Standing >= 3000 )
                return WowFactionRating.Friendly;
            if ( m_Standing >= 0 )
                return WowFactionRating.Neutral;
            if ( m_Standing > -3000 )
                return WowFactionRating.Unfriendly;
            if ( m_Standing > -6000 )
                return WowFactionRating.Hostile;

            return WowFactionRating.Hated;
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowFactionReputations
    {
        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<uint, WowFactionReputation> m_FactionReputations = new SafeDictionary<uint, WowFactionReputation>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSpellId"></param>
        public void Add( uint iFaction, int iStanding, byte iFlag )
        {
            m_FactionReputations.Add( iFaction, new WowFactionReputation( iFaction, iStanding, iFlag ) );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public WowFactionReputation[] FactionReputations
        {
            get { return m_FactionReputations.ToArrayValues(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_FactionReputations.Count; }
        }
        #endregion
    }
}
