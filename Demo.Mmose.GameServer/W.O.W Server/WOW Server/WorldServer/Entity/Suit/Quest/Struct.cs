using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Quest
{
    /// <summary>
    /// Array for correct use Discovery quests
    /// </summary>
    public class WowQuestDiscoveryArea
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaTriggerId"></param>
        public void Add( uint areaTriggerId )
        {
            if ( m_Areas.Contains( areaTriggerId ) == false )
                m_Areas.Add( areaTriggerId );
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_Areas.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ulong[] Areas
        {
            get { return m_Areas.ToArray(); }
        }

        /// <summary>
        /// 
        /// </summary>
        private List<ulong> m_Areas = new List<ulong>();
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowQuestSkill
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skillID"></param>
        /// <param name="skillValue"></param>
        public WowQuestSkill( uint skillID, uint skillValue )
        {
            m_SkillID = skillID;
            m_SkillValue = skillValue;
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_SkillID;
        /// <summary>
        /// 
        /// </summary>
        public uint SkillID
        {
            get { return m_SkillID; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_SkillValue;
        /// <summary>
        /// 
        /// </summary>
        public uint SkillValue
        {
            get { return m_SkillValue; }
        }
    }

    /// <summary>
    /// Array for correct use Skills restriction
    /// </summary>
    public class WowQuestSkills
    {
        /// <summary>
        /// 
        /// </summary>
        private List<WowQuestSkill> m_Skills = new List<WowQuestSkill>();

        /// <summary>
        /// 技能添加
        /// </summary>
        /// <param name="iSkillID"></param>
        public void Add( uint iSkillID, uint skillValue )
        {
            m_Skills.Add( new WowQuestSkill( iSkillID, skillValue ) );
        }

        /// <summary>
        /// 技能数量
        /// </summary>
        public int Count
        {
            get { return m_Skills.Count; }
        }

        /// <summary>
        /// 技能编号
        /// </summary>
        public WowQuestSkill[] Skills
        {
            get { return m_Skills.ToArray(); }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowQuestItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="itemValue"></param>
        public WowQuestItem( uint itemID, uint itemValue )
        {
            m_ItemID = itemID;
            m_ItemValue = itemValue;
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemID;
        /// <summary>
        /// 
        /// </summary>
        public uint ItemID
        {
            get { return m_ItemID; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemValue;
        /// <summary>
        /// 
        /// </summary>
        public uint ItemValue
        {
            get { return m_ItemValue; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowQuestFaction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="factionID"></param>
        /// <param name="factionValue"></param>
        public WowQuestFaction( uint factionID, uint factionValue )
        {
            m_FactionID = factionID;
            m_FactionValue = factionValue;
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_FactionID;
        /// <summary>
        /// 
        /// </summary>
        public uint FactionID
        {
            get { return m_FactionID; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_FactionValue;
        /// <summary>
        /// 
        /// </summary>
        public uint FactionValue
        {
            get { return m_FactionValue; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowQuestEmote
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emoteID"></param>
        /// <param name="emoteDelay"></param>
        public WowQuestEmote( uint emoteID, uint emoteDelay )
        {
            m_EmoteID = emoteID;
            m_EmoteValue = emoteDelay;
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_EmoteID;
        /// <summary>
        /// 
        /// </summary>
        public uint EmoteID
        {
            get { return m_EmoteID; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_EmoteValue;
        /// <summary>
        /// 
        /// </summary>
        public uint EmoteValue
        {
            get { return m_EmoteValue; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowQuestCreature
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="creatureID"></param>
        /// <param name="creatureValue"></param>
        public WowQuestCreature( uint creatureID, uint creatureValue )
        {
            m_CreatureID = creatureID;
            m_CreatureValue = creatureValue;
            m_SpellID = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creatureID"></param>
        /// <param name="creatureValue"></param>
        /// <param name="spellID"></param>
        public WowQuestCreature( uint creatureID, uint creatureValue, uint spellID )
        {
            m_CreatureID = creatureID;
            m_CreatureValue = creatureValue;
            m_SpellID = spellID;
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureID;
        /// <summary>
        /// 
        /// </summary>
        public uint CreatureID
        {
            get { return m_CreatureID; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_CreatureValue;
        /// <summary>
        /// 
        /// </summary>
        public uint CreatureValue
        {
            get { return m_CreatureValue; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_SpellID;
        /// <summary>
        /// 
        /// </summary>
        public uint SpellID
        {
            get { return m_SpellID; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct WowQuestGameObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObjectID"></param>
        /// <param name="ameObjectValue"></param>
        public WowQuestGameObject( uint gameObjectID, uint ameObjectValue )
        {
            m_GameObjectID = gameObjectID;
            m_GameObjectValue = ameObjectValue;
            m_SpellID = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObjectID"></param>
        /// <param name="ameObjectValue"></param>
        /// <param name="spellID"></param>
        public WowQuestGameObject( uint gameObjectID, uint ameObjectValue, uint spellID )
        {
            m_GameObjectID = gameObjectID;
            m_GameObjectValue = ameObjectValue;
            m_SpellID = spellID;
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_GameObjectID;
        /// <summary>
        /// 
        /// </summary>
        public uint GameObjectID
        {
            get { return m_GameObjectID; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_GameObjectValue;
        /// <summary>
        /// 
        /// </summary>
        public uint GameObjectValue
        {
            get { return m_GameObjectValue; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_SpellID;
        /// <summary>
        /// 
        /// </summary>
        public uint SpellID
        {
            get { return m_SpellID; }
        }
    }
}
