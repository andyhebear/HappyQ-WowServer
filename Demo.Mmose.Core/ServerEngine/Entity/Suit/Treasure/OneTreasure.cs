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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Treasure
{
    /// <summary>
    /// 
    /// </summary>
    public class OneTreasure
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loot"></param>
        /// <param name="probability"></param>
        public OneTreasure()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loot"></param>
        /// <param name="probability"></param>
        public OneTreasure( Loot[] baseLoot, float probability )
        {
            m_Loots = baseLoot;
            m_fProbability = probability;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Loot[] m_Loots;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Loot[] Loots
        {
            get { return m_Loots; }
            set { m_Loots = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_fProbability;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Probability
        {
            get { return m_fProbability; }
            set { m_fProbability = value; }
        }
        #endregion

        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static float s_DropMultiplier = 1.0f;
        #endregion
        /// <summary>
        /// 道具掉落的几率比率
        /// </summary>
        public static float DropMultiplier
        {
            get { return s_DropMultiplier; }
            set { s_DropMultiplier = value; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static float s_DropGoldMultiplier = 1.0f;
        #endregion
        /// <summary>
        /// 金币掉落的几率比率
        /// </summary>
        public static float DropGoldMultiplier
        {
            get { return s_DropGoldMultiplier; }
            set { s_DropGoldMultiplier = value; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsDrop()
        {
            if ( RandomEx.RandomDouble() * 100 < m_fProbability * OneTreasure.s_DropMultiplier )
                return true;
            else
                return false;
        }

        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        internal readonly static int DROP_CACHED_SIZE = 20;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lootMoney"></param>
        /// <returns></returns>
        public ItemT[] RandomDrop<ItemT>() where ItemT : BaseItem
        {
            if ( m_Loots == null )
                throw new Exception( "BaseTreasure.RandomDrop(...) - m_Loots == null error!" );

            List<ItemT> treasureList = new List<ItemT>( DROP_CACHED_SIZE );

            for ( int iIndex = 0; iIndex < m_Loots.Length; iIndex++ )
            {
                Loot loot = m_Loots[iIndex];
                if ( loot.IsDrop() == true )
                {
                    ItemT item = loot.Instance<ItemT>();
                    if ( item != null )
                        treasureList.Add( item );
                }
            }

            return treasureList.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lootMoney"></param>
        /// <returns></returns>
        public GoldItem[] RandomGoldDrop()
        {
            if ( m_Loots == null )
                throw new Exception( "BaseTreasure.RandomGoldDrop(...) - m_Loots == null error!" );

            List<GoldItem> treasureList = new List<GoldItem>( DROP_CACHED_SIZE );

            for ( int iIndex = 0; iIndex < m_Loots.Length; iIndex++ )
            {
                GoldLoot lootGold = m_Loots[iIndex] as GoldLoot;
                if ( lootGold == null )
                    continue;

                if ( lootGold.IsDrop() == true )
                {
                    GoldItem goldItem = lootGold.Instance();
                    if ( goldItem != null )
                        treasureList.Add( goldItem );
                }
            }

            return treasureList.ToArray();
        }
        #endregion
    }
}
#endregion