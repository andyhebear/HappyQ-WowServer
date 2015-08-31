using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Wow.WorldServer.Character;
using Demo.Mmose.Core.Entity.Suit.Reputation;

namespace Demo.Wow.WorldServer.Reputation
{
    /// <summary>
    /// 
    /// </summary>
    public class WowReputation : BaseReputation
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_FactionId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FactionId
        {
            get { return m_FactionId; }
            set { m_FactionId = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Reputation = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Reputation
        {
            get { return m_Reputation; }
            set { m_Reputation = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_Flag = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte Flag
        {
            get { return m_Flag; }
            set { m_Flag = value; } 
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Positive()
        {
            return m_Reputation >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WowFactionRating CalcRating()
        {
            if ( m_Reputation >= 42000 )
                return WowFactionRating.Exalted;
            if ( m_Reputation >= 21000 )
                return WowFactionRating.Revered;
            if ( m_Reputation >= 9000 )
                return WowFactionRating.Honored;
            if ( m_Reputation >= 3000 )
                return WowFactionRating.Friendly;
            if ( m_Reputation >= 0 )
                return WowFactionRating.Neutral;
            if ( m_Reputation > -3000 )
                return WowFactionRating.Unfriendly;
            if ( m_Reputation > -6000 )
                return WowFactionRating.Hostile;

            return WowFactionRating.Hated;
        }
        #endregion
    }
}
