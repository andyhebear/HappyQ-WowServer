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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server;
#endregion

namespace Demo.Mmose.Core.AIEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseAITrigger
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        public BaseAITrigger( long iAIEventType )
            : this( iAIEventType, AIProcessPriority.Normal, TimeSpan.Zero )
        {
        }

        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        public BaseAITrigger( long iAIEventType, AIProcessPriority processPriority )
            : this( iAIEventType, processPriority, TimeSpan.Zero )
        {
        }

        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        public BaseAITrigger( long iAIEventType, TimeSpan expirationTimeSpan )
            : this( iAIEventType, AIProcessPriority.Normal, expirationTimeSpan )
        {
        }

        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        /// <param name="intervalTimeSpan">间隔的时间</param>
        /// <param name="iCount">调用的次数</param>
        public BaseAITrigger( long iAIEventType, AIProcessPriority processPriority, TimeSpan expirationTimeSpan )
        {
            m_iAITriggerType = iAIEventType;
            m_ProcessPriority = processPriority;
            m_ExpirationTimeSpan = expirationTimeSpan;

            if ( m_ExpirationTimeSpan == TimeSpan.Zero )
                m_ExpirationDateTime = DateTime.MaxValue; // 如果是零,这表示为永久触发器信号
            else
                m_ExpirationDateTime = DateTime.Now + expirationTimeSpan;

            if ( DefRegCreation == true )
                RegCreation();
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发人工智能的事件类型
        /// </summary>
        private long m_iAITriggerType;
        #endregion
        /// <summary>
        /// 触发人工智能的事件类型
        /// </summary>
        public long AITriggerType
        {
            get { return m_iAITriggerType; }
            set { m_iAITriggerType = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器的优先级
        /// </summary>
        private AIProcessPriority m_ProcessPriority;
        #endregion
        /// <summary>
        /// 触发器的优先级
        /// </summary>
        public AIProcessPriority ProcessPriority
        {
            get { return m_ProcessPriority; }
            set { m_ProcessPriority = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 触发器持续的时间间隔
        /// </summary>
        private TimeSpan m_ExpirationTimeSpan;
        #endregion
        /// <summary>
        /// 触发器持续的时间间隔
        /// </summary>
        public TimeSpan ExpirationTimeSpan
        {
            get { return m_ExpirationTimeSpan; }
            set { m_ExpirationTimeSpan = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 结束触发器的时间
        /// </summary>
        private DateTime m_ExpirationDateTime;
        #endregion
        /// <summary>
        /// 结束触发器的时间
        /// </summary>
        public DateTime ExpirationDateTime
        {
            get { return m_ExpirationDateTime; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 唯一的序号
        /// </summary>
        private Serial m_Serial = Serial.Zero;
        #endregion
        /// <summary>
        /// 唯一的序号
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
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

        /// <summary>
        /// 定义是否需要计算创建调用的次数
        /// </summary>
        protected virtual bool DefRegCreation
        {
            get { return true; }
        }
        #endregion

        #region zh-CHS 内部属性 | en Internal Properties
        /// <summary>
        /// 内部使用的序号
        /// </summary>
        internal Serial InternalSerial
        {
            get { return m_Serial; }
            set { m_Serial = value; }
        }
        #endregion

        /// <summary>
        /// 添加某种时间片类型创建的数量
        /// </summary>
        protected void RegCreation()
        {
            AIProfile l_AIProfile = GetProfile();

            if ( l_AIProfile != null )
                l_AIProfile.RegCreation(); // 添加某种AI触发器类型的创建数量
        }

        /// <summary>
        /// 给出某种时间片的处理信息
        /// </summary>
        /// <returns></returns>
        public AIProfile GetProfile()
        {
            if ( OneServer.Profiling == false )
                return null;

            string l_strName = ToString();

            if ( l_strName == null )
                l_strName = "null";

            AIProfile l_AIProfile = null;
            //s_Profiles.TryGetValue( l_strName, out l_timerProfile );

            //if ( l_timerProfile == null )
            //    s_Profiles[l_strName] = l_timerProfile = new AIProfile();

            return l_AIProfile;
        }

        /// <summary>
        /// 给出时间片的定义字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetType().FullName;
        }

        #region zh-CHS 静态属性 | en Static Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TimerProfile处理信息定义,以类型名为关键字共有8种
        /// </summary>
        private static Dictionary<string, AIProfile> s_Profiles = new Dictionary<string, AIProfile>();
        #endregion
        /// <summary>
        /// 时间片的处理信息定义,以类型名为关键字共有8种
        /// </summary>
        internal static Dictionary<string, AIProfile> Profiles
        {
            get { return s_Profiles; }
        }
        #endregion
    }
}
#endregion