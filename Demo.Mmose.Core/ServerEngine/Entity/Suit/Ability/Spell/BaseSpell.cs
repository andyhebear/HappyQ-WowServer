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

#endregion

namespace Demo.Mmose.Core.Entity.Suit.Ability.Spell
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseSpell : BaseAbility
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS CastingTime属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_CastingTime = DateTime.Now;
        #endregion
        /// <summary>
        /// 释放时间
        /// </summary>
        public DateTime CastingTime
        {
            get { return m_CastingTime; }
            set { m_CastingTime = value; }
        }

        #endregion

        #region zh-CHS CoolDownTime属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_CoolDownTime = DateTime.Now;
        #endregion
        /// <summary>
        /// 冷却时间
        /// </summary>
        public DateTime CoolDownTime
        {
            get { return m_CoolDownTime; }
            set { m_CoolDownTime = value; }
        }

        #endregion

        #region zh-CHS SpellTemplate属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseSpellTemplate m_BaseSpellTemplate = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseSpellTemplate SpellTemplate
        {
            get { return m_BaseSpellTemplate; }
            set { m_BaseSpellTemplate = value; }
        }

        #endregion

        #endregion
    }
}
#endregion