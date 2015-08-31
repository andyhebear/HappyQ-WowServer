using System;
using System.Text;
using System.Collections.Generic;
using Demo_G.O.S.E.ServerEngine.Item;
using Demo_G.O.S.E.ServerEngine.Util;
using Demo_G.O.S.E.ServerEngine.Treasure;

namespace Demo_R.O.S.E.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class MoneyItem : GeneralItem
    {
        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_iMinAmount = 1;
        /// <summary>
        /// 
        /// </summary>
        private int m_iMaxAmount = 2;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="minamount"></param>
        /// <param name="maxamount"></param>
        public MoneyItem( int iMinamount, int iMaxamount )
        {
            m_iMinAmount = iMinamount;
            m_iMaxAmount = iMaxamount;
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int RandomMoney()
        {
            return ( Utility.Random( m_iMinAmount, m_iMaxAmount ) ) * (int)BaseTreasure.DropGoldMultiplier;
        }
        #endregion
    }
}
