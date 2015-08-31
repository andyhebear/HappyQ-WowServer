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
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Ability.TreeBuild
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseTreeBuild
    {
        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<BaseAbility, BaseTreeNode> m_TreeNodes = new SafeDictionary<BaseAbility, BaseTreeNode>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public void RegisterAbility( BaseAbility baseAbility, BaseTreeNode baseTreeNode )
        {
            m_TreeNodes.Add( baseAbility, baseTreeNode );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseAbility"></param>
        /// <returns></returns>
        public bool CheckAbilityUpdateAllow( BaseAbility baseAbility )
        {
            BaseTreeNode baseTreeNode = m_TreeNodes.GetValue( baseAbility );
            if ( baseTreeNode == null )
                return false;

            return baseTreeNode.CheckTreeNodeInfo();
        }

        #endregion
    }
}
#endregion