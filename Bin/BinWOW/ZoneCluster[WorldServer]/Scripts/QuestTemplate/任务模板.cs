using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Quest;

namespace Demo.Wow.Script.QuestTemplate
{
    /// <summary>
    /// 中文格式
    /// </summary>
    public class 任务模板名字 : 魔兽世界任务信息
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void 初始化任务信息()
        {
            // 唯一序号
            // (0x4代表任务标记,00大类,00子类,00001任务顺序号)
            // 暂未分类
            唯一序号 = 0x40001166;

            //quest_template - ZoneId (mangos数据库的字段名称)
            //任务区域在AreaTable.dbc中第一项ZoneId定义
            地域编号 = 123;

            //quest_template - Title (mangos数据库的字段名称)
            任务标题 = "qwqwqw";

            //quest_template - Objectives (mangos数据库的字段名称)
            任务目标 = "qwqw";

            //quest_template - Details (mangos数据库的字段名称)
            任务介绍 = "qwqqw";

            //quest_template - OfferRewardText (mangos数据库的字段名称)
            任务完成信息 = "qwqwqw";

            //quest_template - RequestItemsText (mangos数据库的字段名称)
            任务未完成信息 = "qwqwqw";

            //quest_template - EndText (mangos数据库的字段名称)
            任务结束信息 = "qwwq";

            //quest_template - ObjectiveText (mangos数据库的字段名称)
            任务目标标题[0] = " ";
            任务目标标题[1] = " ";
            任务目标标题[2] = " ";
            任务目标标题[3] = " ";


            //quest_template - QuestSort在QuestSort.dbc定义 (mangos数据库的字段名称)
            分类 = 364;

            //quest_template - Type在QuestInfo.dbc定义 (mangos数据库的字段名称)
            类型 = 1;

            //quest_template - SpecialFlags (mangos数据库的字段名称)
            //SpecialFlags 0 = 普通 , 1 = 传递 , 2 = 探险 , 4 = 交谈 , 8 = 杀怪 , 16 = 限时 , 32 = 重复 , 64 = 声望 
            标记 = 0;

            //quest_template - PrevQuestId (mangos数据库的字段名称)
            前个任务编号 = 1;

            //quest_template - NextQuestId (mangos数据库的字段名称)
            后个任务编号 = 1;

            //quest_template - ExclusiveGroup (mangos数据库的字段名称)
            相同任务集编号 = 1;

            //quest_template - NextQuestInChain (mangos数据库的字段名称)
            任务链后个编号 = 1;


            //quest_template - DetailsEmote 接任务时NPC表情 (mangos数据库的字段名称)
            开始动作[0] = new WowQuestEmote( 1212/*表情动作编号*/, 1000/*延迟时间*/);
            开始动作[1] = new WowQuestEmote( 1212/*表情动作编号*/, 1000/*延迟时间*/);
            开始动作[2] = new WowQuestEmote( 1212/*表情动作编号*/, 1000/*延迟时间*/);
            开始动作[3] = new WowQuestEmote( 1212/*表情动作编号*/, 1000/*延迟时间*/);

            //quest_template - IncompleteEmote 未完成任务NPC表情 (mangos数据库的字段名称)
            处理动作 = new WowQuestEmote( 1212, 1000 );

            //quest_template - CompleteEmote 完成任务NPC表情 (mangos数据库的字段名称)
            结束动作 = new WowQuestEmote( 1212, 1000 );

            //quest_template - MinLevel  (mangos数据库的字段名称)
            最小等级 = 10;

            //quest_template - QuestLevel  (mangos数据库的字段名称)
            任务等级 = 20;

            //quest_template - RequiredRaces  (mangos数据库的字段名称)
            种族 = (uint)Wow种族.全部种族;

            //quest_template - RequiredRepFaction (mangos数据库的字段名称)
            阵营编号 = 123;

            //quest_template - RequiredRepValue (mangos数据库的字段名称)
            阵营声望 = 123;

            //quest_template - LimitTime (秒) (mangos数据库的字段名称)
            完成时间 = TimeSpan.FromSeconds( 600 );

            //quest_template - srcItem (接任务给的物品)(mangos数据库的字段名称)
            任务物品 = 12;

            //quest_template - srcItemCount (接任务给的物品数量)(mangos数据库的字段名称)
            任务物品数量 = 1;


            //quest_template - SrcSpell (接任务给的魔法)(mangos数据库的字段名称)
            任务法术 = 1;


            技能.Add( (uint)Wow技能.奥术, 255/*技能值*/ );
            技能.Add( (uint)Wow技能.冰霜, 255 );

            //quest_template - ReqItemId,ReqItemCount(mangos数据库的字段名称)
            所需物品[0] = new WowQuestItem( 111/*物品编号*/, 1/*物品数量*/ );
            所需物品[1] = new WowQuestItem( 111, 1 );
            所需物品[2] = new WowQuestItem( 111, 1 );
            所需物品[3] = new WowQuestItem( 111, 1 );

            //quest_template - ReqSpellCast(完成任务需要施放的技能)(mangos数据库的字段名称)
            // 这里的字段是在 “所需怪物” 的字段的最后一个参数

            //quest_template - ReqCreatureOrGOId,ReqCreatureOrGOCount(mangos数据库的字段名称)
            所需怪物[0] = new WowQuestCreature( 112/*怪物编号*/, 2/*数量*/, 222/*魔法编号 空为表示是杀死怪物，否则使用魔法来用在怪物身上*/ );
            所需怪物[1] = new WowQuestCreature( 112, 1212 );
            所需怪物[2] = new WowQuestCreature( 112, 1212, 222 );
            所需怪物[3] = new WowQuestCreature( 112, 1212 );


            //quest_template - (mangos数据库的字段名称)
            所需物体[0] = new WowQuestGameObject( 1221/*游戏物体编号*/, 2/*数量*/ );
            所需物体[1] = new WowQuestGameObject( 1221, 22 );
            所需物体[2] = new WowQuestGameObject( 1221, 22 );
            所需物体[3] = new WowQuestGameObject( 1221, 22 );

            //quest_template - RewChoiceItemId,RewChoiceItemCount(mangos数据库的字段名称)
            选择奖励物品[0] = new WowQuestItem( 122112/*物品编号*/, 1212/*物品数量*/ );
            选择奖励物品[1] = new WowQuestItem( 122112, 1212 );
            选择奖励物品[2] = new WowQuestItem( 122112, 1212 );
            选择奖励物品[3] = new WowQuestItem( 122112, 1212 );
            选择奖励物品[4] = new WowQuestItem( 122112, 1212 );
            选择奖励物品[5] = new WowQuestItem( 122112, 1212 );
            选择奖励物品[6] = new WowQuestItem( 122112, 1212 );


            //quest_template - ReqSourceId,ReqSourceRef(mangos数据库的字段名称)
            奖励物品[0] = new WowQuestItem( 122112/*道具编号*/, 1/*道具数量*/ );
            奖励物品[1] = new WowQuestItem( 122112, 1212 );
            奖励物品[2] = new WowQuestItem( 122112, 1212 );
            奖励物品[3] = new WowQuestItem( 122112, 1212 );


            //quest_template - RewRepFaction,RewRepValue(mangos数据库的字段名称)
            奖励声望[0] = new WowQuestFaction( 1212/*阵营编号*/, 122/*阵营声望值*/ );
            奖励声望[1] = new WowQuestFaction( 1212, 122 );
            奖励声望[2] = new WowQuestFaction( 1212, 122 );
            奖励声望[3] = new WowQuestFaction( 1212, 122 );
            奖励声望[4] = new WowQuestFaction( 1212, 122 );

            //quest_template - RewOrReqMoney (值为正时为完成任务奖励金币.值为负时为完成任务需要金币.)(mangos数据库的字段名称)
            奖励金钱 = 0;

            //quest_template - RewXP (mangos数据库的字段名称)
            奖励经验 = 0;

            //quest_template - RewSpell (mangos数据库的字段名称)
            奖励法术 = 212;


            //quest_template - Repeatable (mangos数据库的字段名称)
            是否重复任务 = false;



            //未校对字段
            //PointMapId 
            //PointX 
            //PointY 
            //PointOpt 

            //任务提示点地图编号 = 1;
            //任务提示点坐标X = 1;
            //任务提示点坐标Y = 1;


            //所需探索区域.Add( 1221/*需要 探索的区域编号*/ );
            //所需探索区域.Add( 121 );



            //mangos数据库未知字段

            //SuggestedPlayers

            //ReqSourceId1
            //ReqSourceId2
            //ReqSourceId3
            //ReqSourceId4
            //ReqSourceCount1
            //ReqSourceCount2
            //ReqSourceCount3
            //ReqSourceCount4
            //ReqSourceRef1
            //ReqSourceRef2
            //ReqSourceRef3
            //ReqSourceRef4

            //OfferRewardEmote1
            //OfferRewardEmote2
            //OfferRewardEmote3
            //OfferRewardEmote4



            //mangos数据库已取消字段
            //quest_template - 无 (mangos数据库的字段名称)
            //职业 = (uint)Wow职业.全部职业;
        }
    }
}
