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
    /// 
    /// </summary>
    internal class DelayCallTimer : TimeSlice
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 委托
        /// </summary>
        private TimeSliceCallback m_Callback;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 延迟调用的时间
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        /// <param name="intervalTimeSpan">间隔的时间</param>
        /// <param name="iCount">调用的次数</param>
        /// <param name="timerCallback">委托</param>
        public DelayCallTimer( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, long iCount, TimeSliceCallback timerCallback )
            : base( processPriority, delayTimeSpan, intervalTimeSpan, iCount )
        {
            m_Callback = timerCallback;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 委托
        /// </summary>
        public TimeSliceCallback Callback
        {
            get { return m_Callback; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 调用
        /// </summary>
        protected override void OnTick()
        {
            if ( m_Callback != null )
                m_Callback();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "DelayCallTimer[{0}]", FormatDelegate( m_Callback ) );
        }
        #endregion
    }
}
#endregion

