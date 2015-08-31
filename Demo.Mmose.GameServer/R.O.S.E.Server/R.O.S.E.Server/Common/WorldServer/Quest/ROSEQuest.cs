
namespace Demo_R.O.S.E.Quest
{
    /// <summary>
    /// Quest structure
    /// </summary>
    public class ROSEQuest
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID;
        /// <summary>
        /// 
        /// </summary>
        public uint FinalID;
        /// <summary>
        /// 
        /// </summary>
        public uint[] ItemID = new uint[10];
        /// <summary>
        /// 任务的ID
        /// </summary>
        public uint QuestID;
        /// <summary>
        /// 任务的怪物
        /// </summary>
        public int[] Mobs = new int[10];
        /// <summary>
        /// 任务的道具
        /// </summary>
        public int[] Items = new int[10];
        /// <summary>
        /// 
        /// </summary>
        public int[] NumItems = new int[10];
        /// <summary>
        /// 任务完成奖励的道具
        /// </summary>
        public int[] ItemReward = new int[10];
        /// <summary>
        /// 
        /// </summary>
        public int[] ItemType = new int[10];
        /// <summary>
        /// 
        /// </summary>
        public int[] CountItem = new int[10];
        /// <summary>
        /// 
        /// </summary>
        public int[] Item = new int[5];
        /// <summary>
        /// 任务完成奖励的金币
        /// </summary>
        public int ZulieReward;
        /// <summary>
        /// 任务完成奖励的经验
        /// </summary>
        public int ExperienceReward;
        /// <summary>
        /// 
        /// </summary>
        public int Script;
        public uint value1;
        public uint value2;
        public uint value3;
    }
}
