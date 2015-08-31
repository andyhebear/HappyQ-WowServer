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
using System.Diagnostics;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.AIEngine.Trigger
{
    /// <summary>
    /// 触发器系统
    /// </summary>
    public class TriggerSystem
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private const int LIST_CACHED_SIZE = 1024;
        /// <summary>
        /// 
        /// </summary>
        private const int DICTIONARY_CACHED_SIZE = 1024;
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<TriggerAgents, TriggerAgents> m_TriggerAgents = new SafeDictionary<TriggerAgents, TriggerAgents>( DICTIONARY_CACHED_SIZE );
        #endregion
        /// <summary>
        /// 触发器类型
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        [MultiThreadedWarning( "en", "...:Warning!" )]
        public TriggerAgents[] Agents
        {
            get { return m_TriggerAgents.ToArrayKeys(); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器事件
        /// </summary>
        private SafeDictionary<long, TriggerEvent> m_TriggerEvents = new SafeDictionary<long, TriggerEvent>();
        #endregion
        /// <summary>
        /// 触发器事件
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public TriggerEvent[] Events
        {
            get { return m_TriggerEvents.ToArrayValues(); }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS TriggerEvent方法 | en TriggerEvent Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 获取触发器事件的唯一序号
        /// </summary>
        private ExclusiveSerial m_ExclusiveSerial = new ExclusiveSerial();
        #endregion
        /// <summary>
        /// 添加触发器事件
        /// </summary>
        /// <param name="triggerEvent"></param>
        /// <returns>触发器的唯一序号</returns>
        public bool RegisterTriggerEvent( TriggerEvent triggerEvent )
        {
            if ( triggerEvent.Serial > 0 || triggerEvent.TriggerSystem != null )
            {
                Debug.WriteLine( "TriggerSystem.AddTriggerEvent(...) - triggerEvent.Serial > 0 || triggerEvent.TriggerSystem != null error!" );
                return false;
            }

            triggerEvent.TriggerSystem = this;
            triggerEvent.Serial = m_ExclusiveSerial.GetExclusiveSerial();

            m_TriggerEvents.Add( triggerEvent.Serial, triggerEvent );

            return true;
        }

        /// <summary>
        /// 给出触发器事件
        /// </summary>
        public TriggerEvent GetTriggerEvent( long lTriggerEventSerial )
        {
            return m_TriggerEvents.GetValue( lTriggerEventSerial );
        }


        /// <summary>
        /// 移除触发器事件
        /// </summary>
        public void RemoveTriggerEvent( long lTriggerEventSerial )
        {
            TriggerEvent triggerEvent = m_TriggerEvents.GetValue( lTriggerEventSerial );
            if ( triggerEvent == null )
                return;

            triggerEvent.Serial = Serial.MinusOne;
            triggerEvent.TriggerSystem = null;

            m_ExclusiveSerial.ReleaseSerial( lTriggerEventSerial );

            m_TriggerEvents.Remove( lTriggerEventSerial );
        }
        #endregion

        #region zh-CHS TriggerAgents方法 | en TriggerAgents Methods
        /// <summary>
        /// 添加响应触发器的智能体组
        /// </summary>
        public bool AddTriggerAgents( TriggerAgents triggerAgents )
        {
            if ( triggerAgents.TriggerSystem != null )
            {
                if ( triggerAgents.TriggerSystem != this )
                {
                    Debug.WriteLine( "TriggerSystem.AddTriggerAgents(...) - triggerAgents.TriggerSystem != null && triggerAgents.TriggerSystem != this error!" );
                    return false;
                }
            }

            triggerAgents.TriggerSystem = this;
            m_TriggerAgents.Add( triggerAgents, triggerAgents );

            return true;
        }

        /// <summary>
        /// 移除响应触发器的智能体组
        /// </summary>
        public void RemoveTriggerAgents( TriggerAgents triggerAgents )
        {
            if ( triggerAgents.TriggerSystem != this )
            {
                Debug.WriteLine( "TriggerSystem.AddTriggerAgents(...) - triggerAgents.TriggerSystem != this error!" );
                return;
            }

            triggerAgents.TriggerSystem = null;
            m_TriggerAgents.Remove( triggerAgents );
        }
        #endregion

        /// <summary>
        /// 更新触发器系统
        /// </summary>
        public void UpdateTrigger()
        {
            foreach ( TriggerEvent triggerEvent in m_TriggerEvents.ToArrayValues() )
            {
                if ( triggerEvent.TriggerTime + triggerEvent.Duration > DateTime.Now )
                {
                    m_TriggerEvents.Remove( triggerEvent.Serial );
                }
                //else if ( triggerEvent.ThreadIsRemove() == true )
                //{
                //    m_TriggerEvents.Remove( triggerEvent.Serial );
                //}
                else
                {
                    if ( triggerEvent.IsDynamicPoint )
                    {
                        //triggerEvent.ThreadUpdatePoint
                        triggerEvent.TimeStamp = DateTime.Now;
                    }
                }
            }

            foreach ( TriggerAgents triggerAgents in m_TriggerAgents.ToArrayKeys() )
            {
                foreach ( TriggerEvent triggerEvent in m_TriggerEvents.ToArrayValues() )
                {
                    //if ( triggerAgents.EventTypes in triggerEvent.EventType == false )
                    //    continue;
                    //else if ( triggerAgents.ThreadCheck == false )
                    //    continue;
                    //else
                    {
                        foreach ( TriggerAgent triggerAgent in triggerAgents.Agents )
                        {
                            //if ( triggerAgent.ThreadTriggerCondition != triggerEvent )
                            //    continue;
                            //else
                            //{
                            //    triggerAgent.ThreadTriggerAction( triggerEvent );
                            //}

                        }
                    }
                    
                }
            }

            //foreach ( TriggerAgent triggerEvent in new TriggerAgent[4] )
            //{

            //}

        }

        #endregion
    }
}
#endregion