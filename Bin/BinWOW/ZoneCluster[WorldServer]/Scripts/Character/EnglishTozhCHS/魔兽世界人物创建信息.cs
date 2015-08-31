using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Character;

namespace Demo.Wow.Script.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class 魔兽世界人物创建信息
    {
        /// <summary>
        /// 
        /// </summary>
        private WowCharacterCreateInfo m_PlayerCreateInfo = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerCreateInfo"></param>
        public 魔兽世界人物创建信息( WowCharacterCreateInfo playerCreateInfo )
        {
            m_PlayerCreateInfo = playerCreateInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 种族
        {
            get { return m_PlayerCreateInfo.Race; }
            set { m_PlayerCreateInfo.Race = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 职业
        {
            get { return m_PlayerCreateInfo.Class; }
            set { m_PlayerCreateInfo.Class = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 男性模型
        {
            get { return m_PlayerCreateInfo.MaleDisplayId; }
            set { m_PlayerCreateInfo.MaleDisplayId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 女性模型
        {
            get { return m_PlayerCreateInfo.FemaleDisplayId; }
            set { m_PlayerCreateInfo.FemaleDisplayId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 地图
        {
            get { return m_PlayerCreateInfo.Map; }
            set { m_PlayerCreateInfo.Map = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint 地域
        {
            get { return m_PlayerCreateInfo.Zone; }
            set { m_PlayerCreateInfo.Zone = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float 坐标点X
        {
            get { return m_PlayerCreateInfo.PositionX; }
            set { m_PlayerCreateInfo.PositionX = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float 坐标点Y
        {
            get { return m_PlayerCreateInfo.PositionY; }
            set { m_PlayerCreateInfo.PositionY = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float 坐标点Z
        {
            get { return m_PlayerCreateInfo.PositionZ; }
            set { m_PlayerCreateInfo.PositionZ = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowPlayerInfoSpells 人物携带法术
        {
            get { return m_PlayerCreateInfo.WowPlayerSpells; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowPlayerInfoSkills 人物携带技能
        {
            get { return m_PlayerCreateInfo.WowPlayerSkills; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowPlayerInfoItems 人物携带物品
        {
            get { return m_PlayerCreateInfo.WowPlayerItems; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WowPlayerInfoActions 人物快捷按钮
        {
            get { return m_PlayerCreateInfo.WowPlayerActions; }
        }
    }
}
