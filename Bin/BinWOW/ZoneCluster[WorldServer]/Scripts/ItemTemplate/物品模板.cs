using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Item;

namespace Demo.Wow.Script.ItemTemplate
{
    /// <summary>
    /// 中文格式
    /// </summary>
    public class 物品模板名字 : 魔兽世界物品信息
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void 初始化物品信息()
        {
            // 1.物品的基本信息:


            // 唯一序号:
            // (0x2代表物品标记,00大类,00子类,00001物品顺序号)
            // 大类(00 = 消耗品 , 01 = 容器 , 02 = 武器 , 04 = 盔甲 , 05 = 材料 , 06 = 弹药 , 07 = 商业物品(材料)
            //      09 = 配方 , 11 = 箭弹药袋 , 12 = 任务物品 , 13 = 钥匙 , 14 = 永久做废 , 15 = 其它)
            // 子类见附件
            唯一序号 = 0x2040100001;

            // creature_template - class (mangos数据库的字段名称)
            类型 = 4;

            // SubClass
            // creature_template - subclass (mangos数据库的字段名称)
            子类型 = 1;


            // unk0 = -1,(未采用的芒果数据库字段,未知字段)


            // creature_template - name,name2,name3,name4 (mangos数据库的字段名称)
            名字[0] = "物品模板名字";
            名字[1] = "物品模板名字";
            名字[2] = "物品模板名字";
            名字[3] = "Overseer's Cloak";


            // creature_template - displayid (mangos数据库的字段名称)
            模型编号 = 15120;


            // creature_template - Quality (mangos数据库的字段名称)
            // 品质即颜色((0 = 灰,1 = 白,2 = 绿,3 = 蓝,4 = 紫,5 = 橙,6 = 黄)
            品质 = 2;


            // creature_template - Flags (mangos数据库的字段名称)
            // (0 = 无 , 2 = 魔法制造 , 4 = 箱子,包等 , 32 = 图腾 , 64 = 马,设计图,配方等 , 128 = 惩戒火炬)
            // (512 = 包装纸,礼物 , 1024 = 信物,精华等 , 1088 =  魔杖,卷轴,操作手册等等 , 8192 = 公会登记表)资料不全)
            标记 = 0;


            // creature_template - BuyCount (mangos数据库的字段名称)
            购买数量 = 1;


            // creature_template - BuyPrice (mangos数据库的字段名称)
            买价 = 3150;


            // creature_template - SellPrice (mangos数据库的字段名称)
            卖价 = 630;


            // creature_template - InventoryType (mangos数据库的字段名称)
            // 1 = 头 , 2 = 颈,3 = 肩 , 4 = 衬衣 , 5 = 胸部 , 6 = 腰部 , 7 = 腿部 , 8 = 脚 , 9 = 手腕 , 10 = 手套 , 11 = 手指 , 12 = 饰品 , 13 = 主手 
            // 14 = 副手 , 15 = 远程 , 16 = 背部 , 17 = 双手 , 18 = 包裹 , 19 = 公会徽章 , 20 = 长袍 , 21 = 背负 , 22 = 弹药 , 23 = 投抛 , 24 = 右手远程
            装备位置 = 16;



            // 2.物品装备条件:


            // creature_template - AllowableClass (mangos数据库的字段名称)
            // (0 = 无限制 , 1 = 战士 , 2 = 圣骑士 , 3 = 猎人 , 4 = 盗贼 , 5 = 牧师 , 6 = 保留 , 7 = 萨满 , 8 = 法师 , 9 = 术士 , 10 = 保留 , 11 = 德鲁伊)
            职业 = 0;


            // creature_template - AllowableRace (mangos数据库的字段名称)
            // (1 = 人类 , 2 = 兽人 , 3 = 矮人 , 4 = 暗夜精灵 , 5 = 亡灵 , 6 = 牛头人 , 7 = 侏儒 , 8 = 巨魔)
            种族 = 0;


            // creature_template - ItemLevel (mangos数据库的字段名称)
            物品等级 = 20;


            // creature_template - RequiredLevel (mangos数据库的字段名称)
            装备需求等级 = 15;



            // creature_template - RequiredSkill (mangos数据库的字段名称)
            技能需求编号 = 0;


            // creature_template - RequiredSkillRank (mangos数据库的字段名称)
            技能需求等级 = 0;


            // creature_template - requiredspell (mangos数据库的字段名称)
            法术需求编号 = 0;


            // creature_template - requiredhonorrank (mangos数据库的字段名称)
            荣誉需求等级 = 0;


            // creature_template - RequiredCityRank (mangos数据库的字段名称)
            城市需求等级 = 0;


            // creature_template - RequiredReputationFaction (mangos数据库的字段名称)
            阵营需求编号 = 0;


            // creature_template - RequiredReputationRank (mangos数据库的字段名称)
            阵营声望需求等级 = 0;



            // 3.护甲以及抗性:


            // creature_template - armor (mangos数据库的字段名称)
            护甲值 = 0;


            // creature_template - holy_res (mangos数据库的字段名称)
            神圣抗性 = 0;


            // creature_template - fire_res (mangos数据库的字段名称)
            火焰抗性 = 0;


            // creature_template - nature_res (mangos数据库的字段名称)
            自然抗性 = 0;


            // creature_template - frost_res (mangos数据库的字段名称)
            冰霜抗性 = 0;


            // creature_template - shadow_res (mangos数据库的字段名称)
            阴影抗性 = 0;


            // creature_template - arcane_res (mangos数据库的字段名称)
            奥术抗性 = 0;



            // 4.附加属性:


            // creature_template - stat_type1 (mangos数据库的字段名称)
            // creature_template - stat_value1 (mangos数据库的字段名称)
            // 附加属性(0 = 法力 , 1 = 生命值 , 2 = 无 , 3 = 敏捷 , 4 = 力量 , 5 = 智力 , 6 = 精神 , 7 = 耐力)
            // 附加数值(0-255)
            附加属性[0] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );
            附加属性[1] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );
            附加属性[2] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );
            附加属性[3] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );
            附加属性[4] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );
            附加属性[5] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );
            附加属性[6] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );
            附加属性[7] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );
            附加属性[8] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );
            附加属性[9] = new WowItemAddOnProperty( 0/*附加属性类型*/, 0/*附加数值*/ );


            // 5.伤害属性:

            // creature_template - dmg_type1 (mangos数据库的字段名称)
            // creature_template - dmg_min1 (mangos数据库的字段名称)
            // creature_template - dmg_max1 (mangos数据库的字段名称) 
            // 伤害类型(0 = 普通伤害 , 1 = 神圣伤害 , 2 = 火焰伤害 , 3 = 自然伤害 , 4 = 冰霜伤害 , 5 = 阴影伤害 , 6 = 奥术伤害) 

            神圣最小伤害 = 0;
            神圣最大伤害 = 0;

            火焰最小伤害 = 0;
            火焰最大伤害 = 0;

            自然最小伤害 = 0;
            自然最大伤害 = 0;

            冰霜最小伤害 = 0;
            冰霜最大伤害 = 0;

            阴影最小伤害 = 0;
            阴影最大伤害 = 0;

            奥术最小伤害 = 0;
            奥术最大伤害 = 0;




            // 6.数量和包的设置:

            // creature_template - maxcount (mangos数据库的字段名称)
            可持有最大数量 = 1;

            // creature_template - stackable (mangos数据库的字段名称)
            可堆叠数量 = 0;

            // creature_template - ContainerSlots (mangos数据库的字段名称)
            背包格数 = 0;




            // 7.近战与远程属性:

            // creature_template - ammo_type (mangos数据库的字段名称)
            // (0 = 无 , 2 = 弓箭 , 3 = 子弹)
            弹药类型 = 0;


            // creature_template - delay (mangos数据库的字段名称)
            攻击间隔 = 0;


            // creature_template - RangedModRange (mangos数据库的字段名称)
            // (0 = 非远程武器 , 3 = 鱼竿类装备 , 100 = 远程武器)
            武器类型 = 0;




            // 8.杂项设置(很多未知):

            // creature_template - entry (mangos数据库的字段名称)
            // (0 = 无绑定 , 1 = 拾取后绑定 , 2 = 装备后绑定 , 3 = 使用后绑定 , 4 = 任务物品)
            绑定类型 = 0;


            // creature_template - description (mangos数据库的字段名称)
            描述信息 = "这个是一个披风";


            // creature_template - PageText (mangos数据库的字段名称)
            文字编号 = 0;


            // creature_template - LanguageID (mangos数据库的字段名称)
            语言类型 = 0;


            // creature_template - PageMaterial (mangos数据库的字段名称)
            页面材质 = 0;


            // creature_template - startquest (mangos数据库的字段名称)
            任务编号 = 0;


            // creature_template - Lockid (mangos数据库的字段名称)
            锁的编号 = 0;


            // creature_template - Material (mangos数据库的字段名称)
            // 
            材料类型 = 0;


            // creature_template - Sheath (mangos数据库的字段名称)
            // 
            配戴位置 = 0;


            // creature_template - Extra (mangos数据库的字段名称)
            附属物品 = 0;


            // creature_template - block (mangos数据库的字段名称)
            格挡 = 0;


            // creature_template - itemset (mangos数据库的字段名称)
            套装编号 = 0;


            // creature_template - MaxDurability (mangos数据库的字段名称)
            最大耐久度 = 0;


            // creature_template - Area (mangos数据库的字段名称)
            限定地点 = 0;


            // creature_template - BagFamily (mangos数据库的字段名称)
            背包类型 = 0;



            //ScriptName 脚本名字 (未采用的芒果数据库字段) 
            //DisenchantID 未知   (未采用的芒果数据库字段) 



            // 9.装备绿字效果魔法效果:

            //mangos数据库的字段名称,具体意义参考装备綠字效果魔法效果资料
            //spellid_1      (魔法效果编号)
            //spelltrigger_1 (触发类型, 0 = 使用效果 , 1 = 装备效果 , 2 = 击中效果)
            //spellcharges_1 (魔法消耗,不确定)
            //spellcooldown_1 (冷却时间)
            //spellcategory_1 (魔法种类,不确定)
            //spellcategorycooldown_1 (魔法冷却类型,不确定)

            法术[0] = new WowItemSpell( 0/*魔法效果*/, 0/*触发类型*/, 0/*魔法消耗*/, 0/*冷却时间*/, 0/*魔法种类*/, 0/*魔法冷却类型*/ );
            法术[1] = new WowItemSpell( 0, 0, 0, 0, 0, 0 );
            法术[2] = new WowItemSpell( 0, 0, 0, 0, 0, 0 );
            法术[3] = new WowItemSpell( 0, 0, 0, 0, 0, 0 );
            法术[4] = new WowItemSpell( 0, 0, 0, 0, 0, 0 );






            //mangos数据库未采用的未知字段

            // 10.TBC新增装备属性字段:

            // unk_203
            // Map
            // TotemCategory
            // socketColor_1                     // 取值范围已知
            // socketContent_1                   // 取值范围已知
            // socketColor_2                     // 取值范围已知
            // socketContent_2                   // 取值范围已知
            // socketColor_3                     // 取值范围已知
            // socketContent_3                   // 取值范围已知
            // socketBonus                       // 取值范围已知
            // GemProperties
            // RequiredDisenchantSkill
            // ExtendedCost


            //mangos数据库未采用的已知字段
        }
    }
}
