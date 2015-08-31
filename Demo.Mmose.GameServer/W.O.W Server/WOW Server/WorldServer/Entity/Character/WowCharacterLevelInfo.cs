using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class WowCharacterLevelInfo
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerRace = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Race
        {
            get { return m_PlayerRace; }
            set { m_PlayerRace = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerClass = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Class
        {
            get { return m_PlayerClass; }
            set { m_PlayerClass = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerLevel = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Level
        {
            get { return m_PlayerLevel; }
            set { m_PlayerLevel = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerHealth = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Health
        {
            get { return m_PlayerHealth; }
            set { m_PlayerHealth = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerMana = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Mana
        {
            get { return m_PlayerMana; }
            set { m_PlayerMana = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerStrength = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Strength
        {
            get { return m_PlayerStrength; }
            set { m_PlayerStrength = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerAgility = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Agility
        {
            get { return m_PlayerAgility; }
            set { m_PlayerAgility = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerStamina = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Stamina
        {
            get { return m_PlayerStamina; }
            set { m_PlayerStamina = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerIntellect = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Intellect
        {
            get { return m_PlayerIntellect; }
            set { m_PlayerIntellect = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerSpirit = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Spirit
        {
            get { return m_PlayerSpirit; }
            set { m_PlayerSpirit = value; }
        }
        #endregion
    }
}
