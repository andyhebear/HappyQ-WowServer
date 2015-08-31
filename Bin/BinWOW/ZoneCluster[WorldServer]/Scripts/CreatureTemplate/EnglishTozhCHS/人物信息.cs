using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Suit.Treasure;
using Demo.Wow.WorldServer.Creature;

namespace Demo.Wow.Script.CreatureTemplate
{
    /// <summary>
    /// English To zhCHS Interface
    /// </summary>
    public class 魔兽世界人物信息 : WowCreatureTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultMobileInit()
        {
            初始化人物信息();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void 初始化人物信息()
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
        public uint 模型编号
        {
            get { return ModelId; }
            set { ModelId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string 名字
        {
            get { return Name; }
            set { Name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string 名称
        {
            get { return SubName; }
            set { SubName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 最小等级
        {
            get { return MinLevel; }
            set { MinLevel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 最大等级
        {
            get { return MaxLevel; }
            set { MaxLevel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 最小生命值
        {
            get { return MinHealth; }
            set { MinHealth = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 最大生命值
        {
            get { return MaxHealth; }
            set { MaxHealth = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 最小魔法值
        {
            get { return MinMana; }
            set { MinMana = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 最大魔法值
        {
            get { return MaxMana; }
            set { MaxMana = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 攻击力
        {
            get { return AttackPower; }
            set { AttackPower = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float 最小伤害
        {
            get { return MinDamage; }
            set { MinDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float 最大伤害
        {
            get { return MaxDamage; }
            set { MaxDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 攻击间隔
        {
            get { return BaseAttackTime; }
            set { BaseAttackTime = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 远程攻击力
        {
            get { return RangedAttackPower; }
            set { RangedAttackPower = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float 远程最小伤害
        {
            get { return MinRangeDamage; }
            set { MinRangeDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float 远程最大伤害
        {
            get { return MaxRangeDamage; }
            set { MaxRangeDamage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 远程攻击间隔
        {
            get { return RangeAttackTime; }
            set { RangeAttackTime = value; }
        }

        /// <summary>
        /// 可以攻击玩家的战斗范围
        /// </summary>
        public float 战斗范围
        {
            get { return CombatReach; }
            set { CombatReach = value; }
        }

        /// <summary>
        /// 可以攻击玩家的范围
        /// </summary>
        public float 攻击范围
        {
            get { return BoundingRadius; }
            set { BoundingRadius = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 防御力
        {
            get { return Armor; }
            set { Armor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float 速度
        {
            get { return Speed; }
            set { Speed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float 大小
        {
            get { return Size; }
            set { Size = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 职业
        {
            get { return Class; }
            set { Class = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 种族
        {
            get { return Race; }
            set { Race = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阵营
        {
            get { return Faction; }
            set { Faction = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 阶层
        {
            get { return Rank; }
            set { Rank = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 坐骑模型编号
        {
            get { return Mount; }
            set { Mount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 家族
        {
            get { return Family; }
            set { Family = value; }
        }

        /// <summary>
        /// 当"家族"为0时"类型"有效
        /// </summary>
        public uint 类型
        {
            get { return Type; }
            set { Type = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool 是否平民
        {
            get { return Civilian; }
            set { Civilian = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 移动方式
        {
            get { return MovementType; }
            set { MovementType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 栖息方式
        {
            get { return InhabitType; }
            set { InhabitType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint NPC标记
        {
            get { return NPCFlag; }
            set { NPCFlag = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 训练师类型
        {
            get { return TrainerType; }
            set { TrainerType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 训练法术编号
        {
            get { return TrainerSpell; }
            set { TrainerSpell = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowCreatureEquip[] 装备信息
        {
            get { return EquipInfo; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowCreatureSpell[] 法术信息
        {
            get { return SpellInfo; }
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
        public OneTreasure[] 皮毛掉落
        {
            get { return SkinTreasure; }
            set { SkinTreasure = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] 物品掉落
        {
            get { return ItemTreasure; }
            set { ItemTreasure = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] 任务物品掉落
        {
            get { return QuestTreasure; }
            set { QuestTreasure = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] 金币掉落
        {
            get { return GoldTreasure; }
            set { GoldTreasure = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowObjectQuests 任务
        {
            get { return Quests; }
        }
    }
}
