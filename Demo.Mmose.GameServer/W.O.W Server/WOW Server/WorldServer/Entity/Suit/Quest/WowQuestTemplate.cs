using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Suit.Quest;

namespace Demo.Wow.WorldServer.Quest
{
    /// <summary>
    /// 
    /// </summary>
    public class WowQuestTemplate : BaseQuestTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        protected virtual void DefaultQuestInit()
        {
        }

        #region zh-CHS 任务的信息 | en
        /// <summary>
        /// 
        /// </summary>
        private string m_QuestTitle;
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Title
        {
            get { return m_QuestTitle; }
            set { m_QuestTitle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string m_QuestDescription;
        /// <summary>
        /// 任务描述
        /// </summary>
        public string Description
        {
            get { return m_QuestDescription; }
            set { m_QuestDescription = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string m_QuestDetails;
        /// <summary>
        /// 任务详细资料
        /// </summary>
        public string Details
        {
            get { return m_QuestDetails; }
            set { m_QuestDetails = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string m_QuestOfferReward;
        /// <summary>
        /// 任务详细资料2
        /// </summary>
        public string OfferReward
        {
            get { return m_QuestOfferReward; }
            set { m_QuestOfferReward = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string m_QuestRequestItems;
        /// <summary>
        /// 任务详细资料2
        /// </summary>
        public string RequestItems
        {
            get { return m_QuestRequestItems; }
            set { m_QuestRequestItems = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string m_QuestEndText;
        /// <summary>
        /// 任务详细资料2
        /// </summary>
        public string EndText
        {
            get { return m_QuestEndText; }
            set { m_QuestEndText = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string[] m_QuestObjectiveText = new string[4];
        /// <summary>
        /// 任务描述
        /// </summary>
        public string[] ObjectiveText
        {
            get { return m_QuestObjectiveText; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_QuestZoneId;
        /// <summary>
        /// 
        /// </summary>
        public uint ZoneId
        {
            get { return m_QuestZoneId; }
            set { m_QuestZoneId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_QuestSort;
        /// <summary>
        /// 
        /// </summary>
        public uint Sort
        {
            get { return m_QuestSort; }
            set { m_QuestSort = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_QuestType;
        /// <summary>
        /// Wow类型
        /// </summary>
        public uint Type
        {
            get { return m_QuestType; }
            set { m_QuestType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_QuestFlags;
        /// <summary>
        /// 
        /// </summary>
        public uint Flags
        {
            get { return m_QuestFlags; }
            set { m_QuestFlags = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected ulong m_NextQuest;
        /// <summary>
        /// 
        /// </summary>
        public ulong NextQuest
        {
            get { return m_NextQuest; }
            set { m_NextQuest = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int m_QuestExclusiveGroup;
        /// <summary>
        /// 
        /// </summary>
        public int ExclusiveGroup
        {
            get { return m_QuestExclusiveGroup; }
            set { m_QuestExclusiveGroup = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int m_NextQuestInChain;
        /// <summary>
        /// 
        /// </summary>
        public int NextQuestInChain
        {
            get { return m_NextQuestInChain; }
            set { m_NextQuestInChain = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int m_POIMapId;
        /// <summary>
        /// 
        /// </summary>
        public int POIMapId
        {
            get { return m_POIMapId; }
            set { m_POIMapId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int m_POIPointX;
        /// <summary>
        /// 
        /// </summary>
        public int POIPointX
        {
            get { return m_POIPointX; }
            set { m_POIPointX = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int m_POIPointY;
        /// <summary>
        /// 
        /// </summary>
        public int POIPointY
        {
            get { return m_POIPointY; }
            set { m_POIPointY = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool m_IsRepeatable;
        /// <summary>
        /// 
        /// </summary>
        public bool IsRepeatable
        {
            get { return m_IsRepeatable; }
            set { m_IsRepeatable = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private WowQuestEmote[] m_StartQuestEmote = new WowQuestEmote[4];
        /// <summary>
        /// 
        /// </summary>
        public WowQuestEmote[] StartQuestEmote
        {
            get { return m_StartQuestEmote; }
        }

        /// <summary>
        /// 
        /// </summary>
        private WowQuestEmote m_ProgressQuestEmote;
        /// <summary>
        /// 
        /// </summary>
        public WowQuestEmote ProgressQuestEmote
        {
            get { return m_ProgressQuestEmote; }
            set { m_ProgressQuestEmote = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private WowQuestEmote m_EndQuestEmote;
        /// <summary>
        /// 
        /// </summary>
        public WowQuestEmote EndQuestEmote
        {
            get { return m_EndQuestEmote; }
            set { m_EndQuestEmote = value; }
        }

        #endregion

        #region zh-CHS 任务需要的条件 | en

        /// <summary>
        /// 
        /// </summary>
        private int m_QuestMinLevel;
        /// <summary>
        /// 获取任务的最小等级
        /// </summary>
        public int MinLevel
        {
            get { return m_QuestMinLevel; }
            set { m_QuestMinLevel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int m_QuestIdealLevel;
        /// <summary>
        /// 获取任务的理想等级
        /// </summary>
        public int IdealLevel
        {
            get { return m_QuestIdealLevel; }
            set { m_QuestIdealLevel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_QuestRaceAllowed;
        /// <summary>
        /// 
        /// </summary>
        public uint RaceAllowed
        {
            get { return m_QuestRaceAllowed; }
            set { m_QuestRaceAllowed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_QuestClassAllowed;
        /// <summary>
        /// 职业允许
        /// </summary>
        public uint ClassAllowed
        {
            get { return m_QuestClassAllowed; }
            set { m_QuestClassAllowed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private WowQuestSkills m_QuestSkillsAllowed;
        /// <summary>
        /// 
        /// </summary>
        public WowQuestSkills SkillsAllowed
        {
            get { return m_QuestSkillsAllowed; }
            set { m_QuestSkillsAllowed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_QuestFaction;
        /// <summary>
        /// 
        /// </summary>
        public uint Faction
        {
            get { return m_QuestFaction; }
            set { m_QuestFaction = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_QuestReputation;
        /// <summary>
        /// 
        /// </summary>
        public uint Reputation
        {
            get { return m_QuestReputation; }
            set { m_QuestReputation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected ulong m_PreviousQuest;
        /// <summary>
        /// 
        /// </summary>
        public ulong PreviousQuest
        {
            get { return m_PreviousQuest; }
            set { m_PreviousQuest = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int m_QuestSrcItem;
        /// <summary>
        /// 
        /// </summary>
        public int QuestSrcItem
        {
            get { return m_QuestSrcItem; }
            set { m_QuestSrcItem = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int m_QuestSrcItemCount;
        /// <summary>
        /// 
        /// </summary>
        public int QuestSrcItemCount
        {
            get { return m_QuestSrcItemCount; }
            set { m_QuestSrcItemCount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int m_QuestSrcSpell;
        /// <summary>
        /// 
        /// </summary>
        public int QuestSrcSpell
        {
            get { return m_QuestSrcSpell; }
            set { m_QuestSrcSpell = value; }
        }

        #endregion

        #region zh-CHS 任务完成所需的目标 | en

        /// <summary>
        /// 
        /// </summary>
        private TimeSpan m_QuestCompletionTime;
        /// <summary>
        /// 完成时间
        /// </summary>
        public TimeSpan CompletionTime
        {
            get { return m_QuestCompletionTime; }
            set { m_QuestCompletionTime = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        WowQuestItem[] m_QuestRequiredItem = new WowQuestItem[4];
        /// <summary>
        /// 
        /// </summary>
        public WowQuestItem[] RequiredItem
        {
            get { return m_QuestRequiredItem; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected WowQuestCreature[] m_QuestRequiredCreature = new WowQuestCreature[4];
        /// <summary>
        /// 
        /// </summary>
        public WowQuestCreature[] RequiredCreature
        {
            get { return m_QuestRequiredCreature; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected WowQuestGameObject[] m_QuestRequiredGameObject;
        /// <summary>
        /// 
        /// </summary>
        public WowQuestGameObject[] RequiredGameObject
        {
            get { return m_QuestRequiredGameObject; }
        }

        /// <summary>
        /// 
        /// </summary>
        WowQuestDiscoveryArea m_DiscoverigArea = new WowQuestDiscoveryArea();
        /// <summary>
        /// 
        /// </summary>
        public WowQuestDiscoveryArea DiscoverigArea
        {
            get { return m_DiscoverigArea; }
        }

        #endregion

        #region zh-CHS 任务完成所得到的奖励 | en

        /// <summary>
        /// 
        /// </summary>
        WowQuestItem[] m_QuestChoiceRewardedItem = new WowQuestItem[6];
        /// <summary>
        /// 
        /// </summary>
        public WowQuestItem[] ChoiceRewardedItem
        {
            get { return m_QuestChoiceRewardedItem; }
        }

        /// <summary>
        /// 
        /// </summary>
        WowQuestItem[] m_QuestRewardedItem = new WowQuestItem[4];
        /// <summary>
        /// 
        /// </summary>
        public WowQuestItem[] RewardedItem
        {
            get { return m_QuestRewardedItem; }
        }

        /// <summary>
        /// 
        /// </summary>
        private WowQuestFaction[] m_QuestRewardedFaction = new WowQuestFaction[5];
        /// <summary>
        /// 
        /// </summary>
        public WowQuestFaction[] RewardedFaction
        {
            get { return m_QuestRewardedFaction; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int m_QuestRewardedMoney = 0;
        /// <summary>
        /// 
        /// </summary>
        public int RewardedMoney
        {
            get { return m_QuestRewardedMoney; }
            set { m_QuestRewardedMoney = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int m_QuestRewardedExperience = 0;
        /// <summary>
        /// 
        /// </summary>
        public int RewardedExperience
        {
            get { return m_QuestRewardedExperience; }
            set { m_QuestRewardedExperience = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int m_QuestRewardedSpell = 0;
        /// <summary>
        /// 
        /// </summary>
        public int RewardedSpell
        {
            get { return m_QuestRewardedSpell; }
            set { m_QuestRewardedSpell = value; }
        }

        #endregion
    }
}
