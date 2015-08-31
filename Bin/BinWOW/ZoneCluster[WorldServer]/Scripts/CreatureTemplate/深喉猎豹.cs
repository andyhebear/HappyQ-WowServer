using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Suit.Treasure;
using Demo.Wow.Script.ItemTemplate;
using Demo.Wow.Script.GlobalConfig;
using Demo.Wow.WorldServer.Creature;


namespace Demo.Wow.Script.CreatureTemplate
{
    /// <summary>
    /// 中文格式
    /// </summary>
    public class 深喉猎豹: 魔兽世界人物信息
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void 初始化人物信息()
        {
            // 唯一序号
            // (0x1代表怪物标记,00大类,00子类,00001怪物顺序号)
            // (11 = 图腾 , 10 = 未指定 , 09 = 机械 , 08 = 小动物 , 07 = 人型生物 , 06 = 亡灵 , 05 = 巨人 , 04 = 元素生物 , 03 = 恶魔 , 02 = 龙类 , 01 = 野兽) 
            // 无子类
            唯一序号 = 0x1010000684;


            // creature_template - modelid (mangos数据库的字段名称)
            模型编号 = 633;


            // creature_template - name (mangos数据库的字段名称)
            名字 = "深喉猎豹";


            // creature_template - subname (mangos数据库的字段名称)
            名称 = "深喉猎豹";


            // creature_template - minlevel (mangos数据库的字段名称)
            最小等级 = 37;


            // creature_template - maxlevel (mangos数据库的字段名称)
            最大等级 = 38;


            // creature_template - minhealth (mangos数据库的字段名称)
            最小生命值 = 1586;


            // creature_template - maxhealth (mangos数据库的字段名称)
            最大生命值 = 1651;


            // creature_template - minmana (mangos数据库的字段名称)
            最小魔法值 = 0;


            // creature_template - maxmana  (mangos数据库的字段名称)
            最大魔法值 = 0;


            // creature_template - armor (mangos数据库的字段名称)
            防御力 = 0;


            // creature_template - Faction (mangos数据库的字段名称)
            阵营 = 16;


            // creature_template - Npcflag (mangos数据库的字段名称)
            // 取值范围见mangos数据库npc_option表
            NPC标记 = 0;


            // creature_template - speed (mangos数据库的字段名称)
            速度 = 1.3F;


            // creature_template - rank (mangos数据库的字段名称)
            // 级别 0 = 普通 , 1 = 精英 , 2 = 稀有精英 , 3 = 世界BOSS , 4 = 非常稀有
            阶层 = 0;


            // creature_template - mindmg (mangos数据库的字段名称)
            最小伤害 = 55;


            // creature_template - maxdmg (mangos数据库的字段名称)
            最大伤害 = 80;


            // creature_template - attackpower (mangos数据库的字段名称)
            攻击力 = 100;


            // creature_template - baseattacktime (mangos数据库的字段名称)
            攻击间隔 = 1620;


            // creature_template - rangeattacktime (mangos数据库的字段名称)
            远程攻击间隔 = 1782;


            //flags           (未采用的mangos数据库,未知字段)       
            //dynamicflags    (未采用的mangos数据库,未知字段)


            // creature_template - size (mangos数据库的字段名称)
            // 模型的大小尺寸
            大小 = 1.15F;


            // creature_template - family (mangos数据库的字段名称)
            // (0=无,1=狼,2=豹,3=蜘蛛,4=熊,5=野猪,6=鳄鱼,7=食腐鸟,8=螃蟹,9=猩猩,11=迅猛龙,12=平原陆行鸟,15=地狱猎犬)             
            // (16=虚空行者,17=魅魔,19=末日守卫,20=蝎子,21=海龟,23=小鬼,24=蝙蝠,25=土狼,26=猫头鹰,27=风蛇,28=远程控制)
            家族 = 2;


            // creature_template - bounding_radius (mangos数据库的字段名称)
            攻击范围 = 2;


            // creature_template - trainer_type (mangos数据库的字段名称)
            // (0 = 普通 , 1 = 天赋 , 2 = 商业技能 , 3 = 宠物 )
            训练师类型 = 0;


            // creature_template - trainer_spell (mangos数据库的字段名称)
            训练法术编号 = 0;


            // creature_template - class (mangos数据库的字段名称)
            // (0 = 无限制 , 1 = 战士 , 2 = 圣骑士 , 3 = 猎人 , 4 = 盗贼 , 5 = 牧师 , 6 = 保留 , 7 = 萨满 , 8 = 法师 , 9 = 术士 , 10 = 保留 , 11 = 德鲁伊)
            职业 = 0;


            // creature_template - race  (mangos数据库的字段名称)
            // (1 = 人类 , 2 = 兽人 , 3 = 矮人 , 4 = 暗夜精灵 , 5 = 亡灵 , 6 = 牛头人 , 7 = 侏儒 , 8 = 巨魔)
            种族 = 0;


            // creature_template - minrangedmg (mangos数据库的字段名称)
            远程最小伤害 = 52.7472F;


            // creature_template - maxrangedmg (mangos数据库的字段名称)
            远程最大伤害 = 72.5274F;


            // creature_template - rangedattackpower (mangos数据库的字段名称)
            远程攻击力 = 100;


            // creature_template - combat_reach (mangos数据库的字段名称)
            战斗范围 = 2.43F;


            // creature_template - type (mangos数据库的字段名称)
            // (11 = 图腾 , 10 = 未指定 , 09 = 机械 , 08 = 小动物 , 07 = 人型生物 , 06 = 亡灵 , 05 = 巨人 , 04 = 元素生物 , 03 = 恶魔 , 02 = 龙类 , 01 = 野兽) 
            类型 = 1;


            // creature_template - civilian (mangos数据库的字段名称
            // (1-是 0-不是)
            是否平民 = false;


            // equipmodel1,equipmodel2,equipmodel3,info1,info2,info3,slot1,slot2,slot3 (mangos数据库的字段名称)
            装备信息[0] = new WowCreatureEquip( 0/*装备模型*/, 0/*装备信息*/, 0/*装备位置*/ );
            装备信息[1] = new WowCreatureEquip( 0, 0, 0 );
            装备信息[2] = new WowCreatureEquip( 0, 0, 0 );



            // creature_template - resistance1 (mangos数据库的字段名称)
            神圣抗性 = 0;

            // creature_template - resistance2 (mangos数据库的字段名称)
            火焰抗性 = 0;

            // creature_template - resistance3 (mangos数据库的字段名称)
            自然抗性 = 0;

            // creature_template - resistance4 (mangos数据库的字段名称)
            冰霜抗性 = 0;

            // creature_template - resistance5 (mangos数据库的字段名称)
            阴影抗性 = 0;

            // creature_template - resistance6 (mangos数据库的字段名称)
            奥术抗性 = 0;



            //spell1 ... spell4  (mangos数据库的字段名称)
            法术信息[0] = new WowCreatureSpell( 0 ); ;
            法术信息[1] = new WowCreatureSpell( 0 );
            法术信息[2] = new WowCreatureSpell( 0 );
            法术信息[3] = new WowCreatureSpell( 0 );



            // creature_template - MovementType (mangos数据库的字段名称 0=原地不动 1=任意走动 2=根据creature_movement里的路径点移动)
            移动方式 = 1;


            // creature_template - InhabitType (mangos数据库的字段名称)
            栖息方式 = 1;


            // creature_template - ??? (mangos数据库的字段名称)
            坐骑模型编号 = 0;




            // 怪物暴率部分
            // 如果怪没有皮毛,物品,任务,金币掉落 = new OneTreasure[0]
            // 参考怪物暴率文字说明
            // 支持物品自定义分组爆率

            皮毛掉落 = new OneTreasure[] 
            {


                new OneTreasure(
                new Loot[]{
                    new Loot( typeof(物品模板名字/*皮毛名字*/), 44.4f ) 
                    } , 100f ),
            };


            物品掉落 = new OneTreasure[] 
            {
              //掉落物品组1
               new OneTreasure(
                new Loot[]{
                    new Loot( typeof(物品模板名字/*物品1名字*/), 44.4f ),
                    new Loot( typeof(物品模板名字/*物品2名字*/), 44.4f ),
                    new Loot( typeof(物品模板名字/*物品N名字*/), 44.4f ),
                } , 100f ),

              //掉落物品组2
               new OneTreasure(
                new Loot[]{
                    new Loot( typeof(物品模板名字/*物品1名字*/), 44.4f ),
                    new Loot( typeof(物品模板名字/*物品2名字*/), 44.4f ), 
                    new Loot( typeof(物品模板名字/*物品N名字*/), 44.4f ),
                } , 100f ),
            };


            任务物品掉落 = new OneTreasure[]
            {
               new OneTreasure(
                new Loot[] {
                    new Loot( typeof(物品模板名字/*任务物品名*/), 44.4f )
                } , 100f ),
            };


            金币掉落 = new OneTreasure[] 
            {
               new OneTreasure(
                new Loot[] {
                    new GoldLoot( 100, 250, 99.9f )
                } , 100f ),
            };



            //----------怪物包含的任务信息----------

            // 任务编号
            任务.Add( 0x1234 );
            任务.Add( 0x1235 );

            //----------怪物包含的任务信息----------



            //mangos数据库未采用的未知字段
            //flags
            //dynamicflags
            //flag1



            //mangos数据库未采用的已知字段
            //lootid
            //pickpocketloot
            //skinloot
            //mingold
            //maxgold
            //AIName
            //ScriptName
        }
    }
}