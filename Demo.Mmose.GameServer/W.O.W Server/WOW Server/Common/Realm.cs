using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.Common
{
    /// <summary>
    /// 
    /// </summary>
    internal class Realm
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strName;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strAddress;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            get { return m_strAddress; }
            set { m_strAddress = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iColour;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Colour
        {
            get { return m_iColour; }
            set { m_iColour = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iIcon;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Icon
        {
            get { return m_iIcon; }
            set { m_iIcon = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iTimeZone;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint TimeZone
        {
            get { return m_iTimeZone; }
            set { m_iTimeZone = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_fPopulation;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Population
        {
            get { return m_fPopulation; }
            set { m_fPopulation = value; }
        }
        #endregion
    }
}
