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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.AIEngine.Trigger
{
    /// <summary>
    /// 响应触发器的智能体组
    /// </summary>
    public class TriggerAgents
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private const int DICTIONARY_CACHED_SIZE = 1024;
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器类型
        /// </summary>
        private SafeDictionary<long, TriggerType> m_TriggerTypes = new SafeDictionary<long, TriggerType>( DICTIONARY_CACHED_SIZE );
        #endregion
        /// <summary>
        /// 触发器类型
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public TriggerType[] EventTypes
        {
            get { return m_TriggerTypes.ToArrayValues(); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器类型
        /// </summary>
        private SafeDictionary<TriggerAgent, TriggerAgent> m_TriggerAgents = new SafeDictionary<TriggerAgent, TriggerAgent>( DICTIONARY_CACHED_SIZE );
        #endregion
        /// <summary>
        /// 触发器类型
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public TriggerAgent[] Agents
        {
            get { return m_TriggerAgents.ToArrayKeys(); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器的持续时间
        /// </summary>
        private TriggerSystem m_TriggerSystem = null;
        #endregion
        /// <summary>
        /// 触发器的持续时间
        /// </summary>
        public TriggerSystem TriggerSystem
        {
            get { return m_TriggerSystem; }
            internal set { m_TriggerSystem = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 可填充得扩展数据
        /// </summary>
        private object m_ExtendData = null;
        #endregion
        /// <summary>
        /// 可填充得扩展数据
        /// </summary>
        public object ExtendData
        {
            get { return m_ExtendData; }
            set { m_ExtendData = value; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS TriggerType方法 | en TriggerType Methods
        /// </summary>
        /// 添加触发器事件
        /// </summary>
        public void AddTriggerType( TriggerType triggerType )
        {
            m_TriggerTypes.Add( triggerType, triggerType );
        }

        /// <summary>
        /// 移除触发器事件
        /// </summary>
        public void RemoveTriggerEvent( TriggerType triggerType )
        {
            m_TriggerTypes.Remove( triggerType );
        }
        #endregion

        #region zh-CHS TriggerType方法 | en TriggerType Methods
        /// <summary>
        /// 添加响应触发器的智能体
        /// </summary>
        public void AddTriggerAgent( TriggerAgent triggerAgent )
        {
            m_TriggerAgents.Add( triggerAgent, triggerAgent );
        }

        /// <summary>
        /// 移除响应触发器的智能体
        /// </summary>
        public void RemoveTriggerAgent( TriggerAgent triggerAgent )
        {
            m_TriggerAgents.Remove( triggerAgent );
        }
        #endregion

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS TriggerCondition事件 | en Public Event

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<EventArgs> m_EventTriggerCondition;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockEventTriggerCondition = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 触发条件
        /// </summary>
        public event EventHandler<EventArgs> TriggerCondition
        {
            add
            {
                m_LockEventTriggerCondition.EnterWriteLock();
                {
                    m_EventTriggerCondition += value;
                }
                m_LockEventTriggerCondition.ExitWriteLock();
            }
            remove
            {
                m_LockEventTriggerCondition.EnterWriteLock();
                {
                    m_EventTriggerCondition -= value;
                }
                m_LockEventTriggerCondition.ExitWriteLock();
            }
        }

        #endregion

        #endregion
    }
}
#endregion