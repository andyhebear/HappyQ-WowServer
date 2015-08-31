using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Collections;

namespace Demo.Wow.WorldServer.Creature
{
    /// <summary>
    /// 
    /// </summary>
    public struct WowCreatureEquip
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowCreatureEquip( ulong iEquipModel, ulong iEquipInfo, ulong iEquipSlot )
        {
            m_EquipModel = iEquipModel;
            m_EquipInfo = iEquipInfo;
            m_EquipSlot = iEquipSlot;
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_EquipModel;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong EquipModel
        {
            get { return m_EquipModel; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_EquipInfo;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong EquipInfo
        {
            get { return m_EquipInfo; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_EquipSlot;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong EquipSlot
        {
            get { return m_EquipSlot; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iEquipModel"></param>
        /// <param name="iEquipInfo"></param>
        /// <param name="iEquipSlot"></param>
        /// <returns></returns>
        public WowCreatureEquip GetWowCreatureEquip( ulong iEquipModel, ulong iEquipInfo, ulong iEquipSlot )
        {
            return new WowCreatureEquip( iEquipModel, iEquipInfo, iEquipSlot );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowCreatureSpell
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowCreatureSpell( ulong iSpellID )
        {
            m_SpellID = iSpellID;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iEquipModel"></param>
        /// <param name="iEquipInfo"></param>
        /// <param name="iEquipSlot"></param>
        /// <returns></returns>
        public WowCreatureSpell GetWowCreatureSpell( ulong iSpellID )
        {
            return new WowCreatureSpell( iSpellID );
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public struct WowCreatureQuest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowCreatureQuest( ulong iQuestID )
        {
            m_QuestID = iQuestID;
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_QuestID;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong QuestID
        {
            get { return m_QuestID; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        /// <returns></returns>
        public WowCreatureQuest GetWowCreatureQuest( ulong iQuestID )
        {
            return new WowCreatureQuest( iQuestID );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowObjectQuests
    {
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<ulong, WowCreatureQuest> m_Quests = new SafeDictionary<ulong, WowCreatureQuest>();
        #endregion
        /// <summary>
        /// 任务添加
        /// </summary>
        /// <param name="iQuestID"></param>
        public void Add( ulong iQuestID )
        {
            m_Quests.Add( iQuestID, new WowCreatureQuest( iQuestID ) );
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowCreatureQuest[] m_QuestsArray = new WowCreatureQuest[0];
        #endregion
        /// <summary>
        /// 任务编号
        /// </summary>
        public WowCreatureQuest[] Quests
        {
            get { return m_Quests.ToArrayValues(); }
        }

        /// <summary>
        /// 任务数量
        /// </summary>
        public int Count
        {
            get { return m_Quests.Count; }
        }
    }
}
