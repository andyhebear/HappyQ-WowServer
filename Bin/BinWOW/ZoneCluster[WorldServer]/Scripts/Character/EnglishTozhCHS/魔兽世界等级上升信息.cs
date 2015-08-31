using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Character;

namespace Demo.Wow.Script.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class 魔兽世界等级上升信息
    {
        /// <summary>
        /// 
        /// </summary>
        private WowCharacterLevelInfo m_PlayerLevelStats = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fff"></param>
        public 魔兽世界等级上升信息( WowCharacterLevelInfo playerLevelStats )
        {
            m_PlayerLevelStats = playerLevelStats;
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 种族
        {
            get { return m_PlayerLevelStats.Race; }
            set { m_PlayerLevelStats.Race = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 职业
        {
            get { return m_PlayerLevelStats.Class; }
            set { m_PlayerLevelStats.Class = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 等级
        {
            get { return m_PlayerLevelStats.Level; }
            set { m_PlayerLevelStats.Level = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 生命值
        {
            get { return m_PlayerLevelStats.Health; }
            set { m_PlayerLevelStats.Health = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 法力值
        {
            get { return m_PlayerLevelStats.Mana; }
            set { m_PlayerLevelStats.Mana = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 力量
        {
            get { return m_PlayerLevelStats.Strength; }
            set { m_PlayerLevelStats.Strength = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public uint 敏捷
        {
            get { return m_PlayerLevelStats.Agility; }
            set { m_PlayerLevelStats.Agility = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public uint 耐力
        {
            get { return m_PlayerLevelStats.Stamina; }
            set { m_PlayerLevelStats.Stamina = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 智力
        {
            get { return m_PlayerLevelStats.Intellect; }
            set { m_PlayerLevelStats.Intellect = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 精神
        {
            get { return m_PlayerLevelStats.Spirit; }
            set { m_PlayerLevelStats.Spirit = value; }
        }


        public 魔兽世界等级上升信息 this[int iIndex]
        {
            get { return null; }
        }
    }
}
