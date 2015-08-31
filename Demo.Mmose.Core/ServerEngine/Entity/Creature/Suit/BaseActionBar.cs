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
#endregion

namespace Demo.Mmose.Core.Entity.Creature.Suit
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseActionBar
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Serial属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物所定义的唯一序号GUID
        /// </summary>
        private Serial m_Serial = Serial.Zero;
        #endregion
        /// <summary>
        /// 唯一序号GUID
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
            set { m_Serial = value; }
        }

        #endregion

        #region zh-CHS ActionBarSlotId属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ActionBarSlotId = -1;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long ActionBarSlotId
        {
            get { return m_ActionBarSlotId; }
            internal set { m_ActionBarSlotId = value; }
        }

        #endregion

        #endregion
    }
}
#endregion