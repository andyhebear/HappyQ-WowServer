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
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class NetStateManager
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int HANDLER_CAPACITY_SIZE = 1024;
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_NetStates.Count; }
        }
        #endregion

        #region zh-CHS NetState 方法 | en BaseItem Method

        #region zh-CHS 内部方法 | en Internal Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 网络客户端的集合
        /// </summary>
        private SafeDictionary<NetState, NetState> m_NetStates = new SafeDictionary<NetState, NetState>( HANDLER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// 添加客户端到集合
        /// </summary>
        internal void InternalAddNetState( NetState netState )
        {
            m_NetStates.Add( netState, netState );
        }

        /// <summary>
        /// 在客户端的集合内删除某客户端
        /// </summary>
        /// <param name="iMapID"></param>
        internal void InternalRemoveNetState( NetState netState )
        {
            m_NetStates.Remove( netState );
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 全部网络客户端的数组
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(NetState)当前的数组是列表临时产生的,不能保存数组用于以后操作(给出部分的实例已经可能无效,请用 Running == true 检查实例是否有效):警告!" )]
        public NetState[] ToArray()
        {
            return m_NetStates.ToArrayValues();
        }
        #endregion

        #endregion
    }
}
#endregion