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

namespace Demo.Mmose.Core.Entity.Suit.Ability.TreeBuild
{
    #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
    /// <summary>
    /// TreeNode的事件数据类
    /// </summary>
    public class TreeNodeEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public TreeNodeEventArgs( BaseTreeNode treeNode )
        {
            m_TreeNode = treeNode;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNode的数据
        /// </summary>
        private BaseTreeNode m_TreeNode = null;
        #endregion
        /// <summary>
        /// TreeNode实例
        /// </summary>
        public BaseTreeNode TreeNode
        {
            get { return m_TreeNode; }
        }
        #endregion
    }

    /// <summary>
    /// TreeNode的事件数据类
    /// </summary>
    public class TreeNodeInfoEventArgs : TreeNodeEventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseCreature"></param>
        public TreeNodeInfoEventArgs( BaseTreeNodeInfo treeNodeInfo, BaseTreeNode treeNode )
            : base( treeNode )
        {
            m_TreeNodeInfo = treeNodeInfo;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TreeNodeInfo的数据
        /// </summary>
        private BaseTreeNodeInfo m_TreeNodeInfo = null;
        #endregion
        /// <summary>
        /// TreeNodeInfo实例
        /// </summary>
        public BaseTreeNodeInfo TreeNodeInfo
        {
            get { return m_TreeNodeInfo; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_CheckResult = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool CheckResult
        {
            get { return m_CheckResult; }
            set { m_CheckResult = value; }
        }        
        #endregion
    }
    #endregion
}
#endregion