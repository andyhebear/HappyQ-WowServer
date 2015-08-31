using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Object;
using Demo.Mmose.Core.Entity.Suit.Treasure;

namespace Demo.Wow.Script.ObjectTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class 魔兽世界物体信息 : WowObjectTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultItemInit()
        {
            初始化物体信息();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void 初始化物体信息()
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
            get { return Type; }
            set { Type = value; }
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
        public string 名字
        {
            get { return Name; }
            set { Name = value; }
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
        public uint 标记
        {
            get { return Flags; }
            set { Flags = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 大小
        {
            get { return Size; }
            set { Size = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint[] 声音
        {
            get { return Sound; }
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
