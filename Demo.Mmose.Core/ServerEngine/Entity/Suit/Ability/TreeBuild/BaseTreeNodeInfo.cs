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
using System.Linq;
using System.Text;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Ability.TreeBuild
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseTreeNodeInfo
    {
        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<BaseAbility, BaseAbility> m_Abilitys = new SafeDictionary<BaseAbility, BaseAbility>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public void AddAbility( BaseAbility baseAbility )
        {
            m_Abilitys.Add( baseAbility, baseAbility );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseAbility[] ToArray()
        {
            return m_Abilitys.ToArrayValues();
        }

        #endregion
    }
}
#endregion