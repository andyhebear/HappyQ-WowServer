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
using Demo.Mmose.Core.Entity.Character;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Guild
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseGuildMember
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseCharacter"></param>
        public BaseGuildMember( BaseCharacter baseCharacter )
        {
            m_Owner = baseCharacter;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Owner属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCharacter m_Owner = null;
        #endregion
        /// <summary>
        /// 拥有者的对象
        /// </summary>
        public virtual BaseCharacter Owner
        {
            get { return m_Owner; }
        }

        #endregion

        #endregion
    }
}
#endregion