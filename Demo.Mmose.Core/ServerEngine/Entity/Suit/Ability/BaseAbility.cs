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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Entity.Creature;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Ability
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseAbility
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public BaseAbility()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public BaseAbility( Serial serial )
        {
            m_Serial = serial;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Serial属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_Serial = new Serial();
        #endregion
        /// <summary>
        /// 唯一序列号GUID
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
            set { m_Serial = value; }
        }

        #endregion

        #region zh-CHS Level属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Level = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        #endregion

        #region zh-CHS Owner属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_Owner;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        #endregion

        #endregion
    }
}
#endregion