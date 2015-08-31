using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.Script.ItemTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public enum Wow类型
    {
        消耗品 = 0,
        容器 = 1,
        武器 = 2,
        盔甲 = 4,
        材料 = 5,
        弹药 = 6,
        商业物品 = 7,
        配方 = 9,
        弹药袋 = 11,
        任务道具 = 12,
        钥匙 = 13,
        其它 = 15,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowConsumable
    {
        /// <summary>
        /// 
        /// </summary>
        Food = 1,
        /// <summary>
        /// 
        /// </summary>
        Liquid = 2,
        /// <summary>
        /// usable in combat
        /// </summary>
        Potion = 3,
        /// <summary>
        /// usable in combat
        /// </summary>
        Scroll = 4,
        /// <summary>
        /// (usable in combat) 
        /// </summary>
        Bandage = 5,
        /// <summary>
        /// (usable in combat) 
        /// </summary>
        Healthstone = 6,
        /// <summary>
        /// (usable in combat)
        /// </summary>
        CombatEffect = 7,
    }

    /// <summary>
    /// Wow类型等于消耗品时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型消耗品
    {
        缺省 = 0,
        食物 = 1,
        液体 = 2,
        药剂 = 3,
        卷轴 = 4,
        绷带 = 5,
        /// <summary>
        /// 可能有误译
        /// </summary>
        健康石 = 6,
        /// <summary>
        /// 可能有误译
        /// </summary>
        战斗效果 = 7,
    }

    /// <summary>
    /// Wow类型等于容器时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型容器
    {
        容器 = 0,
        灵魂袋 = 1,
        草药袋 = 2,
        附魔材料袋 = 3,
        工程学材料袋 = 4,
    }

    /// <summary>
    /// Wow类型等于武器时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型武器
    {
        单手斧 = 0,
        双手斧 = 1,
        弓 = 2,
        枪 = 3,
        单手锤 = 4,
        双手锤 = 5,
        长柄武器 = 6,
        单手剑 = 7,
        双手剑 = 8,
        法杖 = 10,
        单手武器 = 11,
        双手武器 = 12,
        拳套 = 13,
        锄头或铁锤等 = 14,
        匕首 = 15,
        投掷武器 = 16,
        矛 = 17,
        弩 = 18,
        魔杖 = 19,
        鱼杆 = 20,
    }

    /// <summary>
    /// Wow类型等于盔甲时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型盔甲
    {
        /// <summary>
        /// 戒指等
        /// </summary>
        其它 = 0,
        布甲 = 1,
        皮甲 = 2,
        锁甲 = 3,
        板甲 = 4,
        小圆盾 = 5,
        盾牌 = 6,
        圣契 = 7,
        神像 = 8,
        图腾 = 9,
    }

    /// <summary>
    /// Wow类型等于材料时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型材料
    {
        缺省 = 0,
    }

    /// <summary>
    /// Wow类型等于弹药时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型弹药
    {
        弩用 = 1,
        弓用 = 2,
        枪用 = 3,
        投掷武器 = 4,
    }

    /// <summary>
    /// Wow类型等于商业材料时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型商业物品
    {
        商业制造道具 = 0,
        零件 = 1,
        火药炸弹 = 2,
        工程道具 = 3,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowRecipe
    {
        Book = 0,
        /// <summary>
        /// Leatherworking
        /// </summary>
        Pattern = 1,
        /// <summary>
        /// Tailoring
        /// </summary>
        Pattern2 = 2,
        /// <summary>
        /// Engineering
        /// </summary>
        Schematic = 3,
        /// <summary>
        /// Blacksmithing
        /// </summary>
        Plans = 4,
        /// <summary>
        /// Cooking
        /// </summary>
        Recipe = 5,
        /// <summary>
        /// Alchemy
        /// </summary>
        Recipe2 = 6,
        /// <summary>
        /// First Aid
        /// </summary>
        Manual = 7,
        /// <summary>
        /// Enchanting
        /// </summary>
        Formula = 8,
        /// <summary>
        /// Fishing
        /// </summary>
        Manual2 = 9,
    }

    /// <summary>
    /// Wow类型等于配方时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型配方
    {
        书 = 0,
        制皮 = 1,
        裁缝 = 2,
        工程学 = 3,
        锻造 = 4,
        烹饪 = 5,
        炼金术 = 6,
        急救 = 7,
        付魔 = 8,
        钩鱼 = 9,
    }

    /// <summary>
    /// Wow类型等于弹药袋时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型弹药袋
    {
        /// <summary>
        /// 弓箭用
        /// </summary>
        箭袋 = 0,
        /// <summary>
        /// 弓箭用
        /// </summary>
        箭袋I = 1,
        /// <summary>
        /// 弓箭用
        /// </summary>
        箭袋II = 2,
        /// <summary>
        /// 枪用
        /// </summary>
        弹药袋 = 3,
    }


    /// <summary>
    /// Wow类型等于任务时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型任务道具
    {
        缺省 = 0,
    }

    /// <summary>
    /// Wow类型等于钥匙时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型钥匙
    {
        钥匙 = 0,
        锁具 = 1,
    }

    /// <summary>
    /// Wow类型等于垃圾时 Wow子类型的详细内容
    /// </summary>
    public enum Wow子类型其它
    {
        缺省 = 0,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow品质
    {
        灰白 = 0,
        白色 = 1,
        绿色 = 2,
        蓝色 = 3,
        紫色 = 4,
        橙色 = 5,
        黄色 = 6,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum Wow标记
    {
        缺省 = 0,
        魔法制造 = 2,
        字箱 = 4,
        图腾 = 32,
        马或设计图等 = 64,
        棒棍 = 512,
        公会登记表 = 8192,
        PvP酬劳物品 = 32768,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow佩戴位置
    {
        缺省 = 0,
        双手之背在后面尖向下 = 1,
        杖之背在后面尖向上 = 2,
        单手之在旁边 = 3,
        盾之在后边 = 4,
        附魔棒 = 5,
        拳套火把锄头等 = 7,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow装备位置
    {
        /// <summary>
        /// 食品、泉水、奶酪、牙齿、皮毛、草药、肉类、鱼、油、各种小石头、药水、卷轴、绷带等杂物和任务物品 
        /// </summary>
        杂物 = 0,
        头 = 1,
        脖 = 2,
        肩 = 3,
        衬衫 = 4,
        胸 = 5,
        腰 = 6,
        裤 = 7,
        脚 = 8,
        手腕 = 9,
        手套 = 10,
        手指 = 11,
        饰品 = 12,
        单手 = 13,
        副手之盾 = 14,
        弓 = 15,
        后背 = 16,
        双手 = 17,
        袋子 = 18,
        徽章 = 19,
        长袍 = 20,
        主手 = 21,
        副手 = 22,
        书 = 23,
        弹药 = 24,
        未知 = 25,
        枪 = 26,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow绑定类型
    {
        不绑定 = 0,
        拾取绑定 = 1,
        装备绑定 = 2,
        使用绑定 = 3,
        任务道具 = 4,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow材料类型
    {
        金属类 = 1,
        草木制品 = 2,
        药水毒液酒等液体 = 3,
        戒指眼球炸弹等没有模型的东西 = 4,
        外衣腰带等 = 5,
        银色物品 = 6,
        布质物品 = 7,
        皮质物品 = 8,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum Wow职业
    {
        战士 = 1,
        圣骑士 = 2,
        猎人 = 4,
        盗贼 = 8,
        牧师 = 16,
        萨满祭司 = 64,
        法师 = 128,
        术士 = 256,
        德鲁伊 = 1024,
        全部职业 = 战士 + 圣骑士 + 猎人 + 盗贼 + 牧师 + 萨满祭司 + 法师 + 术士 + 德鲁伊,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum Wow种族
    {
        人类 = 1,
        兽人 = 2,
        矮人 = 4,
        暗夜精灵 = 8,
        亡灵 = 16,
        牛头 = 32,
        侏儒 = 64,
        巨魔 = 128,
        血精灵 = 256,
        德莱尼 = 512,
        全部种族 = 人类 + 兽人 + 矮人 + 暗夜精灵 + 亡灵 + 牛头 + 侏儒 + 巨魔 + 血精灵 + 德莱尼,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowReputationRank
    {
        Hated = 0,
        Hostile = 1,
        Unfriendly = 2,
        Neutral = 3,
        Friendly = 4,
        Honored = 5,
        Reverted = 6,
        Exalted = 7,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow声望等级
    {
        缺省 = 0,
        仇恨 = 0,
        敌对 = 1,
        不友善 = 2,
        中立 = 3,
        友善 = 4,
        尊敬 = 5,
        崇敬 = 6,
        崇拜 = 7,
    }


    /// <summary>
    /// 
    /// </summary>
    public enum Wow弹药类型
    {
        缺省 = 0,
        箭 = 2,
        子弹 = 3,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowLanguageType
    {
        Orcish = 1,
        Darnassian = 2,
        Taurahe = 3,
        Dwarvish = 6,
        Common = 7,
        Demonic = 8,
        Titan = 9,
        Thelassian = 10,
        Draconic = 11,
        Kalimag = 12,
        Gnomish = 13,
        Troll = 14,
        Gutterspeak = 33,
    }

    public enum Wow语言类型
    {
        缺省 = 0,
        Orcish = 1,
        Darnassian = 2,
        Taurahe = 3,
        Dwarvish = 6,
        Common = 7,
        Demonic = 8,
        Titan = 9,
        Thelassian = 10,
        Draconic = 11,
        Kalimag = 12,
        Gnomish = 13,
        Troll = 14,
        Gutterspeak = 33,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow页面材质类型
    {
        缺省 = 0,
        羊皮 = 1,
        石头 = 2,
        大理石 = 3,
        镀银 = 4,
        青铜 = 5,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow背包类型
    {
        缺省 = 0,
        箭型背包 = 1,
        子弹背包 = 2,
        灵魂碎片背包 = 3,
        药草背包 = 6,
        /// <summary>
        /// 可能误译
        /// </summary>
        迷惑背包 = 7,
        工程背包 = 8,
        钥匙背包 = 9,
        宝石背包 = 10,
        矿石背包 = 12,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow状态类型
    {
        魔法 = 0,
        健康 = 1,
        敏捷 = 3,
        力量 = 4,
        智力 = 5,
        精神 = 6,
        精力 = 7,
    }
}
