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
using System.Diagnostics;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Treasure
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    public class Loot
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private FastCreateInstanceHandler m_ConstructorInstance = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="fProbability"></param>
        public Loot( Type type, float fProbability )
        {
            m_ConstructorInstance = DynamicCalls.GetInstanceCreator( type );
            if ( m_ConstructorInstance == null )
                throw new Exception( "Loot.Loot(...) - m_ConstructorInstance == null error!" );

            m_fProbability = fProbability;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_fProbability = 0.0f;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Probability
        {
            get { return m_fProbability; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDrop()
        {
            if ( RandomEx.RandomDouble() * 100 < m_fProbability * OneTreasure.DropMultiplier )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ItemT Instance<ItemT>() where ItemT : BaseItem
        {
            if ( m_ConstructorInstance == null )
                throw new Exception( "Loot.Instance(...) - m_ConstructorInstance == null error!" );

            return m_ConstructorInstance.Invoke() as ItemT;
        }
        #endregion
    }
}
#endregion