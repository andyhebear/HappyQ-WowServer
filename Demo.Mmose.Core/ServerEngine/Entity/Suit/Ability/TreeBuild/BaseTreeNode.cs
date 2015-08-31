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
using System.Threading;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Ability.TreeBuild
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseTreeNode
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseTreeNodeInfo m_TreeNodeInfo = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseTreeNodeInfo TreeNodeInfo
        {
            get { return m_TreeNodeInfo; }
            set { m_TreeNodeInfo = value; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<BaseTreeNode, BaseTreeNode> m_SubTreeNodes = new SafeDictionary<BaseTreeNode, BaseTreeNode>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public void AddSubTreeNode( BaseTreeNode treeNode )
        {
            m_SubTreeNodes.Add( treeNode, treeNode );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseTreeNode[] SubTreeNodeToArray()
        {
            return m_SubTreeNodes.ToArrayValues();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool CheckTreeNodeInfo()
        {
            BaseTreeNode[] treeNodeArray = SubTreeNodeToArray();
            if ( treeNodeArray == null )
                return false;

            for ( int iIndex = 0; iIndex < treeNodeArray.Length; iIndex++ )
            {
                BaseTreeNode treeNode = treeNodeArray[iIndex];
                if ( treeNode.CheckTreeNodeInfo() == false )
                    return false;
            }

            EventHandler<TreeNodeInfoEventArgs> tempBeforeEventArgs = m_ThreadEventCheckTreeNodeInfo;
            if ( tempBeforeEventArgs != null )
            {
                TreeNodeInfoEventArgs eventArgs = new TreeNodeInfoEventArgs( m_TreeNodeInfo, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.CheckResult == true )
                    return false;
            }

            return true;
        }

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS CheckTreeNodeInfo事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<TreeNodeInfoEventArgs> m_ThreadEventCheckTreeNodeInfo;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventCheckTreeNodeInfo = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<TreeNodeInfoEventArgs> ThreadCheckTreeNodeInfo
        {
            add
            {
                m_LockThreadEventCheckTreeNodeInfo.EnterWriteLock();
                {
                    m_ThreadEventCheckTreeNodeInfo += value;
                }
                m_LockThreadEventCheckTreeNodeInfo.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventCheckTreeNodeInfo.EnterWriteLock();
                {
                    m_ThreadEventCheckTreeNodeInfo -= value;
                }
                m_LockThreadEventCheckTreeNodeInfo.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion