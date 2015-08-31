using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Quest;

namespace Demo.Wow.Script.QuestTemplate
{
    /// <summary>
    /// English To zhCHS Interface
    /// </summary>
    public class 魔兽世界任务信息 : WowQuestTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultQuestInit()
        {
            初始化任务信息();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void 初始化任务信息()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public ulong 唯一序号
        {
            get { return (ulong)Serial; }
            set { Serial = (long)value; }
        }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string 任务标题
        {
            get { return Title; }
            set { Title = value; }
        }

        /// <summary>
        /// 任务描述
        /// </summary>
        public string 任务目标
        {
            get { return Description; }
            set { Description = value; }
        }

        /// <summary>
        /// 任务详细资料
        /// </summary>
        public string 任务介绍
        {
            get { return Details; }
            set { Details = value; }
        }

        /// <summary>
        /// 任务详细资料2
        /// </summary>
        public string 任务完成信息
        {
            get { return OfferReward; }
            set { OfferReward = value; }
        }

        /// <summary>
        /// 任务详细资料2
        /// </summary>
        public string 任务未完成信息
        {
            get { return RequestItems; }
            set { RequestItems = value; }
        }

        /// <summary>
        /// 任务详细资料2
        /// </summary>
        public string 任务结束信息
        {
            get { return EndText; }
            set { EndText = value; }
        }

        /// <summary>
        /// 任务描述
        /// </summary>
        public string[] 任务目标标题
        {
            get { return ObjectiveText; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 地域编号
        {
            get { return ZoneId; }
            set { ZoneId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 分类
        {
            get { return Sort; }
            set { Sort = value; }
        }

        /// <summary>
        /// Wow类型
        /// </summary>
        public uint 类型
        {
            get { return Type; }
            set { Type = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 标记
        {
            get { return Flags; }
            set { Flags = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ulong 后个任务编号
        {
            get { return NextQuest; }
            set { NextQuest = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int 相同任务集编号
        {
            get { return ExclusiveGroup; }
            set { ExclusiveGroup = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int 任务链后个编号
        {
            get { return NextQuestInChain; }
            set { NextQuestInChain = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int 任务提示点地图编号
        {
            get { return POIMapId; }
            set { POIMapId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int 任务提示点坐标X
        {
            get { return POIPointX; }
            set { POIPointX = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int 任务提示点坐标Y
        {
            get { return POIPointY; }
            set { POIPointY = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool 是否重复任务
        {
            get { return IsRepeatable; }
            set { IsRepeatable = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestEmote[] 开始动作
        {
            get { return StartQuestEmote; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestEmote 处理动作
        {
            get { return ProgressQuestEmote; }
            set { ProgressQuestEmote = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestEmote 结束动作
        {
            get { return EndQuestEmote; }
            set { EndQuestEmote = value; }
        }

        /// <summary>
        /// 获取任务的最小等级
        /// </summary>
        public int 最小等级
        {
            get { return MinLevel; }
            set { MinLevel = value; }
        }

        /// <summary>
        /// 获取任务的理想等级
        /// </summary>
        public int 任务等级
        {
            get { return IdealLevel; }
            set { IdealLevel = value; }
        }

        /// <summary>
        /// [Flags]
        /// public enum Wow种族
        /// {
        ///     人类 = 1,
        ///     兽人 = 2,
        ///     矮人 = 4,
        ///     暗夜精灵 = 8,
        ///     亡灵 = 16,
        ///     牛头 = 32,
        ///     侏儒 = 64,
        ///     巨魔 = 128,
        ///     血精灵 = 256,
        ///     德莱尼 = 512,
        ///     全部种族 = 人类 + 兽人 + 矮人 + 暗夜精灵 + 亡灵 + 牛头 + 侏儒 + 巨魔 + 血精灵 + 德莱尼,
        /// }
        /// </summary>
        public uint 种族
        {
            get { return RaceAllowed; }
            set { RaceAllowed = value; }
        }

        /// <summary>
        /// [Flags]
        /// public enum Wow职业
        /// {
        ///     战士 = 1,
        ///     圣骑士 = 2,
        ///     猎人 = 4,
        ///     盗贼 = 8,
        ///     牧师 = 16,
        ///     萨满祭司 = 64,
        ///     法师 = 128,
        ///     术士 = 256,
        ///     德鲁伊 = 1024,
        ///     全部职业 = 战士 + 圣骑士 + 猎人 + 盗贼 + 牧师 + 萨满祭司 + 法师 + 术士 + 德鲁伊,
        /// }
        /// </summary>
        public uint 职业
        {
            get { return ClassAllowed; }
            set { ClassAllowed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestSkills 技能
        {
            get { return SkillsAllowed; }
            set { SkillsAllowed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阵营编号
        {
            get { return Faction; }
            set { Faction = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阵营声望
        {
            get { return Reputation; }
            set { Reputation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ulong 前个任务编号
        {
            get { return PreviousQuest; }
            set { PreviousQuest = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int 任务物品
        {
            get { return QuestSrcItem; }
            set { QuestSrcItem = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int 任务物品数量
        {
            get { return QuestSrcItemCount; }
            set { QuestSrcItemCount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int 任务法术
        {
            get { return QuestSrcSpell; }
            set { QuestSrcSpell = value; }
        }

        /// <summary>
        /// 完成时间
        /// </summary>
        public TimeSpan 完成时间
        {
            get { return CompletionTime; }
            set { CompletionTime = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public WowQuestItem[] 所需物品
        {
            get { return RequiredItem; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestCreature[] 所需怪物
        {
            get { return RequiredCreature; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestGameObject[] 所需物体
        {
            get { return RequiredGameObject; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestDiscoveryArea 所需探索区域
        {
            get { return DiscoverigArea; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestItem[] 选择奖励物品
        {
            get { return ChoiceRewardedItem; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestItem[] 奖励物品
        {
            get { return RewardedItem; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowQuestFaction[] 奖励声望
        {
            get { return RewardedFaction; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int 奖励金钱
        {
            get { return RewardedMoney; }
            set { RewardedMoney = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int 奖励经验
        {
            get { return RewardedExperience; }
            set { RewardedExperience = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int 奖励法术
        {
            get { return RewardedSpell; }
            set { RewardedSpell = value; }
        }
    }
}
