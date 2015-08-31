using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Suit.Treasure;
using Demo.Mmose.Core.Entity.GameObject;

namespace Demo.Wow.WorldServer.Object
{
    /// <summary>
    /// 
    /// </summary>
    public class WowGameObjectTemplate : BaseGameObjectTemplate
    {
        #region zh-CHS 游戏物体的信息 | en

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ObjectType = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Type
        {
            get { return m_ObjectType; }
            set { m_ObjectType = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ObjectModelID = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ModelID
        {
            get { return m_ObjectModelID; }
            set { m_ObjectModelID = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_ObjectName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_ObjectName; }
            set { m_ObjectName = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ObjectFaction = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Faction
        {
            get { return m_ObjectFaction; }
            set { m_ObjectFaction = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ObjectFlags = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Flags
        {
            get { return m_ObjectFlags; }
            set { m_ObjectFlags = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ObjectSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Size
        {
            get { return m_ObjectSize; }
            set { m_ObjectSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint[] m_ObjectSound = new uint[24];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint[] Sound
        {
            get { return m_ObjectSound; }
        }

        #endregion

        #region zh-CHS 游戏物体内物品掉落的信息 | en

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_ObjectTreasure = new OneTreasure[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] ItemTreasure
        {
            get { return m_ObjectTreasure; }
            set { m_ObjectTreasure = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_ObjectQuestTreasure = new OneTreasure[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] QuestTreasure
        {
            get { return m_ObjectQuestTreasure; }
            set { m_ObjectQuestTreasure = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private OneTreasure[] m_GoldTreasure = new OneTreasure[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public OneTreasure[] GoldTreasure
        {
            get { return m_GoldTreasure; }
            set { m_GoldTreasure = value; }
        }

        #endregion

        #region zh-CHS 游戏物体包含的任务的信息 | en

        /// <summary>
        /// 
        /// </summary>
        private WowObjectQuests m_ObjectQuests = new WowObjectQuests();
        /// <summary>
        /// 
        /// </summary>
        public WowObjectQuests Quests
        {
            get { return m_ObjectQuests; }
        }

        #endregion
    }
}
