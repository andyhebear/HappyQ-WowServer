﻿#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

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

namespace Demo.Mmose.Core.Timer
{
    /// <summary>
    /// 当前某种Timer(如: Timer, DelayCallTimer, DelayStateCallTimer, DelayStateCallTimer<T>)类型定义的时间片的处理信息
    /// </summary>
    public class TimerProfile
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 创建调用的次数
        /// </summary>
        private int m_Created = 0;
        /// <summary>
        /// 开始调用的次数
        /// </summary>
        private int m_Started = 0;
        /// <summary>
        /// 停止调用的次数
        /// </summary>
        private int m_Stopped = 0;
        /// <summary>
        /// 调用的次数
        /// </summary>
        private int m_Ticked = 0;
        /// <summary>
        /// 总共调用的处理时间
        /// </summary>
        private TimeSpan m_TotalProcTime = TimeSpan.Zero;
        /// <summary>
        /// 调用的最高处理时间
        /// </summary>
        private TimeSpan m_PeakProcTime = TimeSpan.Zero;
        #endregion

        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 创建调用的次数
        /// </summary>
        public int Created
        {
            get { return m_Created; }
        }

        /// <summary>
        /// 开始调用的次数
        /// </summary>
        public int Started
        {
            get { return m_Started; }
        }

        /// <summary>
        /// 停止调用的次数
        /// </summary>
        public int Stopped
        {
            get { return m_Stopped; }
        }

        /// <summary>
        /// 调用的次数
        /// </summary>
        public int Ticked
        {
            get { return m_Ticked; }
        }

        /// <summary>
        /// 总共调用的处理时间
        /// </summary>
        public TimeSpan TotalProcTime
        {
            get { return m_TotalProcTime; }
        }

        /// <summary>
        /// 调用的最高处理时间
        /// </summary>
        public TimeSpan PeakProcTime
        {
            get { return m_PeakProcTime; }
        }

        /// <summary>
        /// 平均调用的处理时间
        /// </summary>
        public TimeSpan AverageProcTime
        {
            get
            {
                if ( m_Ticked == 0 )
                    return TimeSpan.Zero;

                return TimeSpan.FromTicks( m_TotalProcTime.Ticks / m_Ticked );
            }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 计算创建调用的次数
        /// </summary>
        public void RegCreation()
        {
            ++m_Created;
        }

        /// <summary>
        /// 计算开始调用的次数
        /// </summary>
        public void RegStart()
        {
            ++m_Started;
        }

        /// <summary>
        /// 计算停止调用的次数
        /// </summary>
        public void RegStopped()
        {
            ++m_Stopped;
        }

        /// <summary>
        /// 计算运行的次数,最高的处理时间,总共调用的处理时间
        /// </summary>
        /// <param name="procTime">当前的处理时间</param>
        public void RegTicked( TimeSpan procTime )
        {
            ++m_Ticked;

            m_TotalProcTime += procTime;

            if ( procTime > m_PeakProcTime )
                m_PeakProcTime = procTime;
        }
        #endregion
    }
}
#endregion

