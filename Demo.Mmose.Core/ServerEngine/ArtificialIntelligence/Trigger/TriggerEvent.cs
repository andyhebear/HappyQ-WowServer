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
using Demo.Mmose.Core.Util;

#endregion

namespace Demo.Mmose.Core.AIEngine.Trigger
{
    /// <summary>
    /// 触发器事件
    /// </summary>
    public class TriggerEvent
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public TriggerEvent()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public TriggerEvent( TriggerType triggerType )
        {
            m_TriggerType = triggerType;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器编号
        /// </summary>
        private TriggerType m_TriggerType = new TriggerType();
        #endregion
        /// <summary>
        /// 触发器类型
        /// </summary>
        public TriggerType TriggerType
        {
            get { return m_TriggerType; }
            set { m_TriggerType = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器编号
        /// </summary>
        private Serial m_Serial = Serial.MinusOne;
        #endregion
        /// <summary>
        /// 触发器序号
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
            internal set { m_Serial = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器优先级
        /// </summary>
        private TriggerPriority m_TriggerPriority = TriggerPriority.Normal;
        #endregion
        /// <summary>
        /// 触发器优先级
        /// </summary>
        public TriggerPriority Priority
        {
            get { return m_TriggerPriority; }
            set { m_TriggerPriority = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器智能体
        /// </summary>
        private TriggerAgent m_TriggerAgent = null;
        #endregion
        /// <summary>
        /// 触发器智能体
        /// </summary>
        public TriggerAgent TriggerAgent
        {
            get { return m_TriggerAgent; }
            set { m_TriggerAgent = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器频率
        /// </summary>
        private TriggerFrequency m_RunFrequency = TriggerFrequency.FiftyMS;
        #endregion
        /// <summary>
        /// 触发器频率
        /// </summary>
        public TriggerFrequency Frequency
        {
            get { return m_RunFrequency; }
            set { m_RunFrequency = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器的位置是否是动态
        /// </summary>
        private bool m_IsDynamicPoint = false;
        #endregion
        /// <summary>
        /// 触发器的位置是否是动态
        /// </summary>
        public bool IsDynamicPoint
        {
            get { return m_IsDynamicPoint; }
            set { m_IsDynamicPoint = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器的位置
        /// </summary>
        private Point3D m_Point3D;
        #endregion
        /// <summary>
        /// 触发器的位置
        /// </summary>
        public Point3D Point3D
        {
            get { return m_Point3D; }
            set { m_Point3D = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器的范围
        /// </summary>
        private float m_fRange = 0;
        #endregion
        /// <summary>
        /// 触发器的范围
        /// </summary>
        public float Range
        {
            get { return m_fRange; }
            set { m_fRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器触发时的时间
        /// </summary>
        private DateTime m_TriggerTime = DateTime.Now;
        #endregion
        /// <summary>
        /// 触发器触发时的时间
        /// </summary>
        public DateTime TriggerTime
        {
            get { return m_TriggerTime; }
            set { m_TriggerTime = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器的持续时间
        /// </summary>
        private TimeSpan m_Duration = TimeSpan.MinValue;
        #endregion
        /// <summary>
        /// 触发器的持续时间
        /// </summary>
        public TimeSpan Duration
        {
            get { return m_Duration; }
            set { m_Duration = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器的持续时间
        /// </summary>
        private DateTime m_TimeStamp = DateTime.Now;
        #endregion
        /// <summary>
        /// 触发器的持续时间
        /// </summary>
        public DateTime TimeStamp
        {
            get { return m_TimeStamp; }
            set { m_TimeStamp = value; }
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

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS IsRemove事件 | en Public Event

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<EventArgs> m_ThreadEventIsRemove;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventIsRemove = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 触发器是否有效
        /// </summary>
        public event EventHandler<EventArgs> ThreadIsRemove
        {
            add
            {
                m_LockThreadEventIsRemove.EnterWriteLock();
                {
                    m_ThreadEventIsRemove += value;
                }
                m_LockThreadEventIsRemove.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventIsRemove.EnterWriteLock();
                {
                    m_ThreadEventIsRemove -= value;
                }
                m_LockThreadEventIsRemove.ExitWriteLock();
            }
        }

        #endregion

        #region zh-CHS UpdatePoint事件 | en Public Event

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<EventArgs> m_ThreadEventUpdatePoint;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventUpdatePoint = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 触发器位置更新
        /// </summary>
        public event EventHandler<EventArgs> ThreadUpdatePoint
        {
            add
            {
                m_LockThreadEventUpdatePoint.EnterWriteLock();
                {
                    m_ThreadEventUpdatePoint += value;
                }
                m_LockThreadEventUpdatePoint.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventUpdatePoint.EnterWriteLock();
                {
                    m_ThreadEventUpdatePoint -= value;
                }
                m_LockThreadEventUpdatePoint.ExitWriteLock();
            }
        }

        #endregion

        #endregion
    }
}
#endregion