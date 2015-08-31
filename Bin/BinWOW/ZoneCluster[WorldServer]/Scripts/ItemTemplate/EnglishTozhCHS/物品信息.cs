using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Item;

namespace Demo.Wow.Script.ItemTemplate
{
    /// <summary>
    /// English To zhCHS Interface
    /// </summary>
    public class 魔兽世界物品信息 : WowItemTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultItemInit()
        {
            初始化物品信息();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void 初始化物品信息()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public ulong 唯一序号
        {
            get { return (ulong)(long)Serial; }
            set { Serial = (long)value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 类型
        {
            get { return ItemClass; }
            set { ItemClass = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 子类型
        {
            get { return ItemSubclass; }
            set { ItemSubclass = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string[] 名字
        {
            get { return Name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 模型编号
        {
            get { return ModelID; }
            set { ModelID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 品质
        {
            get { return Quality; }
            set { Quality = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 标记
        {
            get { return Flag; }
            set { Flag = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 购买数量
        {
            get { return BuyCount; }
            set { BuyCount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 买价
        {
            get { return BuyPrice; }
            set { BuyPrice = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 卖价
        {
            get { return SellPrice; }
            set { SellPrice = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 装备位置
        {
            get { return InventoryType; }
            set { InventoryType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 职业
        {
            get { return AllowableClass; }
            set { AllowableClass = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 种族
        {
            get { return AllowableRace; }
            set { AllowableRace = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 物品等级
        {
            get { return ItemLevel; }
            set { ItemLevel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 装备需求等级
        {
            get { return RequiredLevel; }
            set { RequiredLevel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 技能需求编号
        {
            get { return RequiredSkill; }
            set { RequiredSkill = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 技能需求等级
        {
            get { return RequiredSkillRank; }
            set { RequiredSkillRank = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 法术需求编号
        {
            get { return RequiredSpell; }
            set { RequiredSpell = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 荣誉需求等级
        {
            get { return RequiredHonorRank; }
            set { RequiredHonorRank = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 城市需求等级
        {
            get { return RequiredCityRank; }
            set { RequiredCityRank = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阵营需求编号
        {
            get { return RequiredReputationFaction; }
            set { RequiredReputationFaction = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阵营声望需求等级
        {
            get { return RequiredReputationRank; }
            set { RequiredReputationRank = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 可持有最大数量
        {
            get { return MaxCount; }
            set { MaxCount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 可堆叠数量
        {
            get { return ItemStackable; }
            set { ItemStackable = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 绑定类型
        {
            get { return Bonding; }
            set { Bonding = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string 描述信息
        {
            get { return Description; }
            set { Description = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 文字编号
        {
            get { return PageText; }
            set { PageText = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 页面材质
        {
            get { return PageMaterial; }
            set { PageMaterial = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 语言类型
        {
            get { return LanguageID; }
            set { LanguageID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 材料类型
        {
            get { return Material; }
            set { Material = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 配戴位置
        {
            get { return Sheath; }
            set { Sheath = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 附属物品
        {
            get { return Extra; }
            set { Extra = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 格挡
        {
            get { return Block; }
            set { Block = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 套装编号
        {
            get { return Itemset; }
            set { Itemset = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 最大耐久度
        {
            get { return MaxDurability; }
            set { MaxDurability = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 背包格数
        {
            get { return ContainerSlots; }
            set { ContainerSlots = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 背包类型
        {
            get { return BagFamily; }
            set { BagFamily = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 护甲值
        {
            get { return Armor; }
            set { Armor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 攻击间隔
        {
            get { return AttackDelay; }
            set { AttackDelay = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 弹药类型
        {
            get { return AmmoType; }
            set { AmmoType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 限定地点
        {
            get { return Area; }
            set { Area = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 锁的编号
        {
            get { return LockID; }
            set { LockID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 武器类型
        {
            get { return RangedModRange; }
            set { RangedModRange = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ulong 任务编号
        {
            get { return StartQuest; }
            set { StartQuest = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowItemSpell[] 法术
        {
            get { return Spell; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 神圣抗性
        {
            get { return HolyResistance; }
            set { HolyResistance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 火焰抗性
        {
            get { return FireResistance; }
            set { FireResistance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 自然抗性
        {
            get { return NatureResistance; }
            set { NatureResistance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 冰霜抗性
        {
            get { return FrostResistance; }
            set { FrostResistance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阴影抗性
        {
            get { return ShadowResistance; }
            set { ShadowResistance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 奥术抗性
        {
            get { return ArcaneResistance; }
            set { ArcaneResistance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 神圣最小伤害
        {
            get { return HolyMinDamage; }
            set { HolyMinDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 神圣最大伤害
        {
            get { return HolyMaxDamage; }
            set { HolyMaxDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 火焰最小伤害
        {
            get { return FireMinDamage; }
            set { FireMinDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 火焰最大伤害
        {
            get { return FireMaxDamage; }
            set { FireMaxDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 自然最小伤害
        {
            get { return NatureMinDamage; }
            set { NatureMinDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 自然最大伤害
        {
            get { return NatureMaxDamage; }
            set { NatureMaxDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 冰霜最小伤害
        {
            get { return FrostMinDamage; }
            set { FrostMinDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 冰霜最大伤害
        {
            get { return FrostMaxDamage; }
            set { FrostMaxDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阴影最小伤害
        {
            get { return ShadowMinDamage; }
            set { ShadowMinDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阴影最大伤害
        {
            get { return ShadowMaxDamage; }
            set { ShadowMaxDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 奥术最小伤害
        {
            get { return ArcaneMinDamage; }
            set { ArcaneMinDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 奥术最大伤害
        {
            get { return ArcaneMaxDamage; }
            set { ArcaneMaxDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowItemAddOnProperty[] 附加属性
        {
            get { return AddOnProperty; }
        }
    }
}
