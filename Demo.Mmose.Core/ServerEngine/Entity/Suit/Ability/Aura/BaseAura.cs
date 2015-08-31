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

#endregion

namespace Demo.Mmose.Core.Entity.Suit.Ability.Aura
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseAura : BaseAbility
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS AuraTemplate属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseAuraTemplate m_BaseAuraTemplate = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseAuraTemplate AuraTemplate
        {
            get { return m_BaseAuraTemplate; }
            set { m_BaseAuraTemplate = value; }
        }

        #endregion

        #endregion
    }
}
#endregion