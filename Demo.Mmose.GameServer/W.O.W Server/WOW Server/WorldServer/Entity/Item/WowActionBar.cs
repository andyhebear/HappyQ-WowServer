using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Creature.Suit;

namespace Demo.Wow.WorldServer.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class WowActionBar : BaseActionBar
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ActionId;
        #endregion
        /// <summary>
        /// 法术编号或物品编号或宏定义编号
        /// </summary>
        public uint Action
        {
            get { return m_ActionId; }
            set { m_ActionId = value; }
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_TypeId;
        #endregion
        /// <summary>
        /// 技能类型 0 = 法术 64 = 宏定义 128 = 物品
        /// </summary>
        public uint Type
        {
            get { return m_TypeId; }
            set { m_TypeId = value; }
        }

        #endregion
    }
}
