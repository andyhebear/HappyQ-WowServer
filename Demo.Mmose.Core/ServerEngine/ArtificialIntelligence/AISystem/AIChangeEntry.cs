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
using System.Collections.Generic;
using System.Threading;
#endregion

namespace Demo.Mmose.Core.AIEngine
{
    /// <summary>
    /// 
    /// </summary>
    internal class AIChangeEntry
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tTimer"></param>
        /// <param name="newIndex"></param>
        /// <param name="isAdd"></param>
        private AIChangeEntry( BaseAIEvent aiEventInfo, bool isAdd )
        {
            m_AIEventInfo = aiEventInfo;
            m_IsAddAIEventInfo = isAdd;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 添加或修改或移去的时间片
        /// </summary>
        private BaseAIEvent m_AIEventInfo;
        #endregion
        /// <summary>
        /// AI事件信息
        /// </summary>
        public BaseAIEvent AIEventInfo
        {
            get { return m_AIEventInfo; }
            set { m_AIEventInfo = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否是添加还是移去AI触发器
        /// </summary>
        private bool m_IsAddAIEventInfo = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool AddAIEventInfo
        {
            get { return m_IsAddAIEventInfo; }
            set { m_IsAddAIEventInfo = value; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        public void Release()
        {
            Monitor.Enter( s_LockAIChangeEntryPool );
            {
                s_AIChangeEntryPool.Enqueue( this );
            }
            Monitor.Exit( s_LockAIChangeEntryPool );
        }
        #endregion

        #region zh-CHS 静态方法 | en Static Method
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Queue<AIChangeEntry> s_AIChangeEntryPool = new Queue<AIChangeEntry>();
        /// <summary>
        /// 
        /// </summary>
        private static object s_LockAIChangeEntryPool = new object();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tTimer"></param>
        /// <param name="newIndex"></param>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        public static AIChangeEntry Instance( BaseAIEvent aiEventInfo, bool isAdd )
        {
            AIChangeEntry l_AIChangeEntry = null;

            Monitor.Enter( s_LockAIChangeEntryPool );
            {
                if ( s_AIChangeEntryPool.Count > 0 )
                    l_AIChangeEntry = s_AIChangeEntryPool.Dequeue();
            }
            Monitor.Exit( s_LockAIChangeEntryPool );

            if ( l_AIChangeEntry == null )
                l_AIChangeEntry = new AIChangeEntry( aiEventInfo, isAdd );
            else
            {
                l_AIChangeEntry.m_AIEventInfo = aiEventInfo;
                l_AIChangeEntry.m_IsAddAIEventInfo = isAdd;
            }

            return l_AIChangeEntry;
        }
        #endregion
    }
}
#endregion