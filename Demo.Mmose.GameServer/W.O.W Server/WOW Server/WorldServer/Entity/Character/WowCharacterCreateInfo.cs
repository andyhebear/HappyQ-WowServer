using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class WowCharacterCreateInfo
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
        private uint m_PlayerMaleDisplayId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MaleDisplayId
        {
            get { return m_PlayerMaleDisplayId; }
            set { m_PlayerMaleDisplayId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerFemaleDisplayId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FemaleDisplayId
        {
            get { return m_PlayerFemaleDisplayId; }
            set { m_PlayerFemaleDisplayId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerMap = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Map
        {
            get { return m_PlayerMap; }
            set { m_PlayerMap = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PlayerZone = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Zone
        {
            get { return m_PlayerZone; }
            set { m_PlayerZone = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PlayerPositionX = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float PositionX
        {
            get { return m_PlayerPositionX; }
            set { m_PlayerPositionX = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PlayerPositionY = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float PositionY
        {
            get { return m_PlayerPositionY; }
            set { m_PlayerPositionY = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PlayerPositionZ = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float PositionZ
        {
            get { return m_PlayerPositionZ; }
            set { m_PlayerPositionZ = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowPlayerInfoSpells m_WowPlayerSpells = new WowPlayerInfoSpells();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowPlayerInfoSpells WowPlayerSpells
        {
            get { return m_WowPlayerSpells; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowPlayerInfoSkills m_WowPlayerSkills = new WowPlayerInfoSkills();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowPlayerInfoSkills WowPlayerSkills
        {
            get { return m_WowPlayerSkills; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowPlayerInfoItems m_WowPlayerItems = new WowPlayerInfoItems();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowPlayerInfoItems WowPlayerItems
        {
            get { return m_WowPlayerItems; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowPlayerInfoActions m_WowPlayerActions = new WowPlayerInfoActions();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowPlayerInfoActions WowPlayerActions
        {
            get { return m_WowPlayerActions; }
        }
        #endregion
    }
}
