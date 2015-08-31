#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System.Diagnostics;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Treasure
{
    public class GoldLoot : Loot
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="fProbability"></param>
        public GoldLoot( ulong minGold, ulong maxGold, float fProbability )
            : base( typeof( GoldItem ), fProbability )
        {
            m_MinGold = minGold;
            m_MaxGold = maxGold;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_MinGold = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong MinGold
        {
            get { return m_MinGold; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_MaxGold = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong MaxGold
        {
            get { return m_MaxGold; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsDrop()
        {
            if ( RandomEx.RandomDouble() * 100 < base.Probability * OneTreasure.DropGoldMultiplier )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GoldItem Instance()
        {
            GoldItem goldItem = base.Instance<GoldItem>();
            if ( goldItem == null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "GoldLoot.Instance(...) - goldItem == null error!" );

                return null;
            }
            else
            {
                goldItem.MinGold = m_MinGold;
                goldItem.MaxGold = m_MaxGold;

                return goldItem;
            }
        }
        #endregion
    }
}
#endregion