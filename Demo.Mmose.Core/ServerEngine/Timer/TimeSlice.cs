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
using System.Diagnostics;
using System.Threading;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Server;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.World;
#endregion

namespace Demo.Mmose.Core.Timer
{
    /// <summary>
    /// 时间片的处理(具有均衡负载的时间片处理)
    /// </summary>
    public class TimeSlice
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        public TimeSlice( TimeSpan delayTimeSpan )
            : this( TimerPriority.Normal, delayTimeSpan, TimeSpan.Zero, 1 )
        {
        }

        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        public TimeSlice( TimerPriority processPriority, TimeSpan delayTimeSpan )
            : this( processPriority, delayTimeSpan, TimeSpan.Zero, 1 )
        {
        }

        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        /// <param name="intervalTimeSpan">间隔的时间</param>
        public TimeSlice( TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan )
            : this( TimerPriority.Normal, delayTimeSpan, intervalTimeSpan, 0/*循环调用*/ )
        {
        }

        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        /// <param name="intervalTimeSpan">间隔的时间</param>
        public TimeSlice( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan )
            : this( processPriority, delayTimeSpan, intervalTimeSpan, 0/*循环调用*/ )
        {
        }

        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        /// <param name="intervalTimeSpan">间隔的时间</param>
        /// <param name="iCount">调用的次数</param>
        public TimeSlice( TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, long iCount )
            : this( TimerPriority.Normal, delayTimeSpan, intervalTimeSpan, iCount )
        {
        }

        /// <summary>
        /// 初始化时间片
        /// </summary>
        /// <param name="delayTimeSpan">延迟的时间</param>
        /// <param name="intervalTimeSpan">间隔的时间</param>
        /// <param name="iCount">调用的次数</param>
        public TimeSlice( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, long iCount )
        {
            m_Count = iCount;
            m_DelayTime = delayTimeSpan;
            m_IntervalTime = intervalTimeSpan;
            m_ProcessPriority = processPriority;

            if ( iCount == 1 )
                m_RunFrequency = ComputePriority( delayTimeSpan );
            else
                m_RunFrequency = ComputePriority( intervalTimeSpan );

            RegCreation();
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 调用次数的累计数
        /// </summary>
        private long m_Adding = 0;
        #endregion
        /// <summary>
        /// 调用次数的累计数
        /// </summary>
        public long Adding
        {
            get { return m_Adding; }
            internal set { m_Adding = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 调用的总次数
        /// </summary>
        private long m_Count = 0;
        #endregion
        /// <summary>
        /// 调用的总次数
        /// </summary>
        public long Count
        {
            get { return m_Count; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 表示当前的时间片已否已经加入了TimeSlice.s_TimeSliceQueue的先入先出集合中
        /// </summary>
        private volatile bool m_InQueued = false;
        #endregion
        /// <summary>
        /// 表示当前的时间片已否已经加入了TimeSlice.s_TimeSliceQueue的先入先出集合中
        /// </summary>
        public bool InQueued
        {
            get { return m_InQueued; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 时间片的优先级
        /// </summary>
        private TimerFrequency m_RunFrequency = TimerFrequency.EveryTick;
        #endregion
        /// <summary>
        /// 时间片的优先级
        /// </summary>
        public TimerFrequency Frequency
        {
            get { return m_RunFrequency; }
            set
            {
                if ( m_RunFrequency != value )
                {
                    m_RunFrequency = value;

                    // 如果是在运行则调用改变当前时间片的优先级, 如果没有运行则在Start()调用TimerThread.AddTimer(...)
                    if ( m_Running )
                        TimerThread.PriorityChange( this, m_RunFrequency );
                }
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 时间片的优先级
        /// </summary>
        private TimerPriority m_ProcessPriority = TimerPriority.Normal;
        #endregion
        /// <summary>
        /// 时间片的调度优先级
        /// </summary>
        public TimerPriority Priority
        {
            get { return m_ProcessPriority; }
            set { m_ProcessPriority = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 下一次调用的时间
        /// </summary>
        private DateTime m_NextTime = DateTime.Now;
        #endregion
        /// <summary>
        /// 下一次的调用时间
        /// </summary>
        public DateTime NextTime
        {
            get { return m_NextTime; }
            internal set { m_NextTime = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 延迟调用的时间(只在加入集合时计算一次)
        /// </summary>
        private TimeSpan m_DelayTime = TimeSpan.Zero;
        #endregion
        /// <summary>
        /// 延迟调用的时间间隔(只在加入集合时计算一次)
        /// </summary>
        public TimeSpan DelayTime
        {
            get { return m_DelayTime; }
            set { m_DelayTime = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 间隔调用的时间
        /// </summary>
        private TimeSpan m_IntervalTime = TimeSpan.Zero;
        #endregion
        /// <summary>
        /// 间隔调用的时间间隔
        /// </summary>
        public TimeSpan IntervalTime
        {
            get { return m_IntervalTime; }
            set { m_IntervalTime = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 调用是否在运行(volatile 用于多线程)
        /// </summary>
        private volatile bool m_Running = false;
        #endregion
        /// <summary>
        /// 调用是否运行
        /// </summary>
        public bool IsRunning
        {
            get { return m_Running; }
            set
            {
                if ( value == true )
                    Start();
                else
                    Stop();
            }
        }

        #region zh-CHS BaseWorld属性 | en BaseWorld Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 管理当前的世界服务
        /// </summary>
        private BaseWorld m_BaseWorld = null;
        #endregion
        /// <summary>
        /// 管理当前的世界服务
        /// </summary>
        public BaseWorld BaseWorld
        {
            get { return m_BaseWorld; }
            internal set { m_BaseWorld = value; }
        }

        #endregion

        #endregion

        #region zh-CHS 内部属性 | en Internal Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TimerThread.m_Timers当前某种时间片的引用
        /// </summary>
        private Dictionary<TimeSlice, TimeSlice> m_TimeSliceDictionary = null;
        #endregion
        /// <summary>
        /// TimerThread.m_Timers当前某种时间片的引用
        /// </summary>
        internal Dictionary<TimeSlice, TimeSlice> TimeSliceDictionary
        {
            get { return m_TimeSliceDictionary; }
            set { m_TimeSliceDictionary = value; }
        }
        #endregion

        #region zh-CHS 共有静态成员变量 | en Public Static Member Variables
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 当时间片的累计数量到该数量时将中断后面的调用
        /// </summary>
        private static long s_BreakSliceAtNumber = 200; // 默认值(在多线程中不因该太多)
        #endregion
        /// <summary>
        /// 当时间片的累计数量到该数量时将中断后面的调用
        /// </summary>
        public static long BreakSliceAtNumber
        {
            get { return s_BreakSliceAtNumber; }
            set { s_BreakSliceAtNumber = value; }
        }
        #endregion

        #region zh-CHS 内部静态属性 | en Internal Static Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// TimerProfile处理信息定义,以类型名为关键字共有8种
        /// </summary>
        private static SafeDictionary<string, TimerProfile> s_Profiles = new SafeDictionary<string, TimerProfile>();
        #endregion
        /// <summary>
        /// 时间片的处理信息定义,以类型名为关键字共有8种
        /// </summary>
        internal static SafeDictionary<string, TimerProfile> Profiles
        {
            get { return s_Profiles; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 开始时间片的处理
        /// </summary>
        public void Start()
        {
            if ( m_Running == false )
            {
                m_Running = true;

                TimerThread.AddTimer( this );

                TimerProfile timerProfile = GetProfile();
                if ( timerProfile != null )
                    timerProfile.RegStart();
            }
        }

        /// <summary>
        /// 停止时间片的处理
        /// </summary>
        public void Stop()
        {
            if ( m_Running == true )
            {
                m_Running = false;

                TimerThread.RemoveTimer( this );

                TimerProfile timerProfile = GetProfile();
                if ( timerProfile != null )
                    timerProfile.RegStopped();
            }
        }


        /// <summary>
        /// 给出某种时间片的处理信息
        /// </summary>
        /// <returns></returns>
        public TimerProfile GetProfile()
        {
            if ( OneServer.Profiling == false )
                return null;

            string strName = ToString();
            if ( strName == null || strName == string.Empty )
                strName = "null";

            TimerProfile timerProfile = s_Profiles.GetValue( strName );
            if ( timerProfile == null )
            {
                timerProfile = new TimerProfile();
                s_Profiles.Add( strName, timerProfile ); 
            }

            return timerProfile;
        }

        /// <summary>
        /// 给出时间片的定义字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetType().FullName;
        }
        #endregion

        #region zh-CHS 保护方法 | en Protected Methods
        /// <summary>
        /// 时间片的处理函数
        /// </summary>
        protected virtual void OnTick()
        {
        }
        #endregion

        #region zh-CHS 私有方法 | en Private Method
        /// <summary>
        /// 添加某种时间片类型创建的数量
        /// </summary>
        private void RegCreation()
        {
            TimerProfile timerProfile = GetProfile();
            if ( timerProfile != null )
                timerProfile.RegCreation(); // 添加某种时间片类型的创建的数量
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 获取时间片的优先级
        /// </summary>
        /// <param name="tsTimeSpan"></param>
        /// <returns></returns>
        public static TimerFrequency ComputePriority( TimeSpan timeSpan )
        {
            if ( timeSpan >= TimeSpan.FromMinutes( 1.0 ) )
                return TimerFrequency.FiveSeconds;

            if ( timeSpan >= TimeSpan.FromSeconds( 10.0 ) )
                return TimerFrequency.OneSecond;

            if ( timeSpan >= TimeSpan.FromSeconds( 5.0 ) )
                return TimerFrequency.TwoFiftyMS;

            if ( timeSpan >= TimeSpan.FromSeconds( 2.5 ) )
                return TimerFrequency.FiftyMS;

            if ( timeSpan >= TimeSpan.FromSeconds( 1.0 ) )
                return TimerFrequency.TwentyFiveMS;

            if ( timeSpan >= TimeSpan.FromSeconds( 0.5 ) )
                return TimerFrequency.TenMS;

            return TimerFrequency.EveryTick;
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="timerCallback"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimeSpan delayTimeSpan, TimeSliceCallback timerCallback )
        {
            return StartTimeSlice( TimerPriority.Normal, delayTimeSpan, TimeSpan.Zero, 1, timerCallback );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="timerCallback"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSliceCallback timerCallback )
        {
            return StartTimeSlice( processPriority, delayTimeSpan, TimeSpan.Zero, 1, timerCallback );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="timerCallback"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, TimeSliceCallback timerCallback )
        {
            return StartTimeSlice( TimerPriority.Normal, delayTimeSpan, intervalTimeSpan, 0, timerCallback );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="timerCallback"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, TimeSliceCallback timerCallback )
        {
            return StartTimeSlice( processPriority, delayTimeSpan, intervalTimeSpan, 0, timerCallback );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="iCount"></param>
        /// <param name="timerCallback"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, long iCount, TimeSliceCallback timerCallback )
        {
            return StartTimeSlice( TimerPriority.Normal, delayTimeSpan, intervalTimeSpan, iCount, timerCallback );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="iCount"></param>
        /// <param name="timerCallback"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, long iCount, TimeSliceCallback timerCallback )
        {
            TimeSlice tTimer = new DelayCallTimer( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerCallback );

            tTimer.Start();

            return tTimer;
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimeSpan delayTimeSpan, TimeSliceStateCallback timerStateCallback, object tState )
        {
            return StartTimeSlice( TimerPriority.Normal, delayTimeSpan, TimeSpan.Zero, 1, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSliceStateCallback timerStateCallback, object tState )
        {
            return StartTimeSlice( processPriority, delayTimeSpan, TimeSpan.Zero, 1, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, TimeSliceStateCallback timerStateCallback, object tState )
        {
            return StartTimeSlice( TimerPriority.Normal, delayTimeSpan, intervalTimeSpan, 0, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, TimeSliceStateCallback timerStateCallback, object tState )
        {
            return StartTimeSlice( processPriority, delayTimeSpan, intervalTimeSpan, 0, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="iCount"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, long iCount, TimeSliceStateCallback timerStateCallback, object tState )
        {
            return StartTimeSlice( TimerPriority.Normal, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="iCount"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, long iCount, TimeSliceStateCallback timerStateCallback, object tState )
        {
            TimeSlice tTimer = new DelayStateCallTimer( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState );

            tTimer.Start();

            return tTimer;
        }


        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delayTimeSpan"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice<T>( TimeSpan delayTimeSpan, TimeSliceStateCallback<T> timerStateCallback, T tState )
        {
            return StartTimeSlice( TimerPriority.Normal, delayTimeSpan, TimeSpan.Zero, 1, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delayTimeSpan"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice<T>( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSliceStateCallback<T> timerStateCallback, T tState )
        {
            return StartTimeSlice( processPriority, delayTimeSpan, TimeSpan.Zero, 1, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice<T>( TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, TimeSliceStateCallback<T> timerStateCallback, T tState )
        {
            return StartTimeSlice( TimerPriority.Normal, delayTimeSpan, intervalTimeSpan, 0, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice<T>( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, TimeSliceStateCallback<T> timerStateCallback, T tState )
        {
            return StartTimeSlice( processPriority, delayTimeSpan, intervalTimeSpan, 0, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="count"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice<T>( TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, long iCount, TimeSliceStateCallback<T> timerStateCallback, T tState )
        {
            return StartTimeSlice( TimerPriority.Normal, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState );
        }

        /// <summary>
        /// 创建一个新的时间片
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delayTimeSpan"></param>
        /// <param name="intervalTimeSpan"></param>
        /// <param name="count"></param>
        /// <param name="timerStateCallback"></param>
        /// <param name="tState"></param>
        /// <returns></returns>
        public static TimeSlice StartTimeSlice<T>( TimerPriority processPriority, TimeSpan delayTimeSpan, TimeSpan intervalTimeSpan, long iCount, TimeSliceStateCallback<T> timerStateCallback, T tState )
        {
            TimeSlice tTimer = new DelayStateCallTimer<T>( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState );

            tTimer.Start();

            return tTimer;
        }
        #endregion

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 需要处理的时间片的先进先出列队集合(线程安全)(Highest 调度优先级)
        /// </summary>
        private static Queue<TimeSlice> s_HighestTimeSliceQueue = new Queue<TimeSlice>();
        /// <summary>
        /// (Highest 调度优先级)集合锁
        /// </summary>
        private static SpinLock s_LockHighestTimeSliceQueue = new SpinLock();

        /// <summary>
        /// 需要处理的时间片的先进先出列队集合(线程安全)(AboveNormal 调度优先级)
        /// </summary>
        private static Queue<TimeSlice> s_AboveNormalTimeSliceQueue = new Queue<TimeSlice>();
        /// <summary>
        /// (AboveNormal 调度优先级)集合锁
        /// </summary>
        private static SpinLock s_LockAboveNormalTimeSliceQueue = new SpinLock();

        /// <summary>
        /// 需要处理的时间片的先进先出列队集合(线程安全)(Normal 调度优先级)
        /// </summary>
        private static Queue<TimeSlice> s_NormalTimeSliceQueue = new Queue<TimeSlice>();
        /// <summary>
        /// (Normal 调度优先级)集合锁
        /// </summary>
        private static SpinLock s_LockNormalTimeSliceQueue = new SpinLock();

        /// <summary>
        /// 需要处理的时间片的先进先出列队集合(线程安全)(BelowNormal 调度优先级)
        /// </summary>
        private static Queue<TimeSlice> s_BelowNormalTimeSliceQueue = new Queue<TimeSlice>();
        /// <summary>
        /// (BelowNormal 调度优先级)集合锁
        /// </summary>
        private static SpinLock s_LockBelowNormalTimeSliceQueue = new SpinLock();

        /// <summary>
        /// 需要处理的时间片的先进先出列队集合(线程安全)(Lowest 调度优先级)
        /// </summary>
        private static Queue<TimeSlice> s_LowestTimeSliceQueue = new Queue<TimeSlice>();
        /// <summary>
        /// (Lowest 调度优先级)集合锁
        /// </summary>
        private static SpinLock s_LockLowestTimeSliceQueue = new SpinLock();
        #endregion
        /// <summary>
        /// 放入处理列表中
        /// </summary>
        internal static void JoinProcessQueue( TimeSlice timeSlice )
        {
            // 现修改 防止多线程(还没改成true就已经调用完成被设置成false了)
            timeSlice.m_InQueued = true;

            switch ( timeSlice.Priority )
            {
                case TimerPriority.Highest:

                    s_LockHighestTimeSliceQueue.Enter();
                    {
                        // 线程安全, 放入处理列表中
                        s_HighestTimeSliceQueue.Enqueue( timeSlice );
                    }
                    s_LockHighestTimeSliceQueue.Exit();

                    break;
                case TimerPriority.AboveNormal:

                    s_LockAboveNormalTimeSliceQueue.Enter();
                    {
                        // 线程安全, 放入处理列表中
                        s_AboveNormalTimeSliceQueue.Enqueue( timeSlice );
                    }
                    s_LockAboveNormalTimeSliceQueue.Exit();

                    break;
                case TimerPriority.Normal:

                    s_LockNormalTimeSliceQueue.Enter();
                    {
                        // 线程安全, 放入处理列表中
                        s_NormalTimeSliceQueue.Enqueue( timeSlice );
                    }
                    s_LockNormalTimeSliceQueue.Exit();

                    break;
                case TimerPriority.BelowNormal:

                    s_LockBelowNormalTimeSliceQueue.Enter();
                    {
                        // 线程安全, 放入处理列表中
                        s_BelowNormalTimeSliceQueue.Enqueue( timeSlice );
                    }
                    s_LockBelowNormalTimeSliceQueue.Exit();

                    break;
                case TimerPriority.Lowest:

                    s_LockLowestTimeSliceQueue.Enter();
                    {
                        // 线程安全, 放入处理列表中
                        s_LowestTimeSliceQueue.Enqueue( timeSlice );
                    }
                    s_LockLowestTimeSliceQueue.Exit();

                    break;
                default:

                    s_LockNormalTimeSliceQueue.Enter();
                    {
                        // 线程安全, 放入处理列表中
                        s_NormalTimeSliceQueue.Enqueue( timeSlice );
                    }
                    s_LockNormalTimeSliceQueue.Exit();

                    break;
            }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private volatile static int s_CallHighestCount = 0;
        /// <summary>
        /// 
        /// </summary>
        private volatile static int s_CallAboveNormalCount = 0;
        /// <summary>
        /// 
        /// </summary>
        private volatile static int s_CallNormalCount = 0;
        /// <summary>
        /// 
        /// </summary>
        private volatile static int s_CallBelowNormalCount = 0;
        /// <summary>
        /// 
        /// </summary>
        private volatile static int s_CallLowestCount = 0;
        /// <summary>
        /// 
        /// </summary>
        private readonly static int CALL_SLICE_MAX_COUNT = 3;
        #endregion
        /// <summary>
        /// 运行时间片(具有均衡负载的时间片处理)
        /// </summary>
        internal static void Slice()
        {
            bool bIsSliceOK = false;

            do
            {
                // 总是先处理完高优先级
                if ( s_CallHighestCount < CALL_SLICE_MAX_COUNT )
                {
                    bIsSliceOK = Slice_Highest();
                    if ( bIsSliceOK == true )
                    {
                        s_CallHighestCount++;
                        break;
                    }
                }

                if ( s_CallAboveNormalCount < CALL_SLICE_MAX_COUNT )
                {
                    bIsSliceOK = Slice_AboveNormal();
                    if ( bIsSliceOK == true )
                    {
                        s_CallAboveNormalCount++;
                        break;
                    }
                }

                if ( s_CallNormalCount < CALL_SLICE_MAX_COUNT )
                {
                    bIsSliceOK = Slice_Normal();
                    if ( bIsSliceOK == true )
                    {
                        s_CallNormalCount++;
                        break;
                    }
                }

                if ( s_CallBelowNormalCount < CALL_SLICE_MAX_COUNT )
                {
                    bIsSliceOK = Slice_BelowNormal();
                    if ( bIsSliceOK == true )
                    {
                        s_CallBelowNormalCount++;
                        break;
                    }
                }

                if ( s_CallLowestCount < CALL_SLICE_MAX_COUNT )
                {
                    bIsSliceOK = Slice_Lowest();
                    if ( bIsSliceOK == true )
                    {
                        s_CallLowestCount++;
                        break;
                    }
                }

                // 如果没有需要处理的则再检测调用的次数是否已满
                if ( s_CallHighestCount >= CALL_SLICE_MAX_COUNT )
                {
                    s_CallHighestCount = 0;

                    bIsSliceOK = Slice_Highest();
                    if ( bIsSliceOK == true )
                        break;
                }

                if ( s_CallAboveNormalCount >= CALL_SLICE_MAX_COUNT )
                {
                    s_CallAboveNormalCount = 0;

                    bIsSliceOK = Slice_AboveNormal();
                    if ( bIsSliceOK == true )
                        break;
                }

                if ( s_CallNormalCount >= CALL_SLICE_MAX_COUNT )
                {
                    s_CallNormalCount = 0;

                    bIsSliceOK = Slice_Normal();
                    if ( bIsSliceOK == true )
                        break;
                }

                if ( s_CallBelowNormalCount >= CALL_SLICE_MAX_COUNT )
                {
                    s_CallBelowNormalCount = 0;

                    bIsSliceOK = Slice_BelowNormal();
                    if ( bIsSliceOK == true )
                        break;
                }

                if ( s_CallLowestCount >= CALL_SLICE_MAX_COUNT )
                {
                    s_CallLowestCount = 0;

                    bIsSliceOK = Slice_Lowest();
                    if ( bIsSliceOK == true )
                        break;
                }
            } while ( false );

            if ( bIsSliceOK == true )
            {
                // 如果已经处理完,再发一次事件消息,让下一个线程来处理下一个时间片优先级的调用
                OneServer.SetAllWorldSignal();
            }
        }

        /// <summary>
        /// 运行时间片(Highest 调度优先级)
        /// </summary>
        private static bool Slice_Highest()
        {
            if ( s_HighestTimeSliceQueue.Count <= 0 )
                return false;

            TimeSlice[] timeSliceArray = null;

            // 使用数组减少锁定时间
            s_LockHighestTimeSliceQueue.Enter();
            {
                if ( s_HighestTimeSliceQueue.Count > 0 )
                {
                    // 时间片先进先出列队集合的数量(和中断处理比较)
                    long iQueueCountAtSlice = s_HighestTimeSliceQueue.Count;
                    if ( iQueueCountAtSlice <= s_BreakSliceAtNumber )
                    {
                        timeSliceArray = s_HighestTimeSliceQueue.ToArray();
                        s_HighestTimeSliceQueue.Clear();
                    }
                    else
                    {
                        timeSliceArray = new TimeSlice[s_BreakSliceAtNumber];
                        for ( long iIndex = 0; iIndex < s_BreakSliceAtNumber; iIndex++ )
                            timeSliceArray[iIndex] = s_HighestTimeSliceQueue.Dequeue();

                        // 如果没有全部处理完,再发一次事件消息,让下一个线程来处理
                    }
                }
            }
            s_LockHighestTimeSliceQueue.Exit();

            if ( timeSliceArray == null )
                return false;

            Stopwatch stopWatch = null;
            for ( int iIndex = 0; iIndex < timeSliceArray.Length; iIndex++ )
            {
                TimeSlice timeSlice = timeSliceArray[iIndex];

                // 线程安全的
                TimerProfile timerProfile = timeSlice.GetProfile();
                if ( timerProfile != null )
                {
                    if ( stopWatch == null )
                        stopWatch = Stopwatch.StartNew();
                    else
                        stopWatch.Start();
                }

                timeSlice.OnTick();
                timeSlice.m_InQueued = false;  // 表示当前已不在列表中,用于在TimerThread线程中检测,如果已在列表中则不许要再次加入了

                if ( timerProfile != null )
                {
                    timerProfile.RegTicked( stopWatch.Elapsed );
                    stopWatch.Reset();
                }
            }

            return true;
        }

        /// <summary>
        /// 运行时间片(AboveNormal 调度优先级)
        /// </summary>
        private static bool Slice_AboveNormal()
        {
            if ( s_AboveNormalTimeSliceQueue.Count <= 0 )
                return false;

            TimeSlice[] timeSliceArray = null;

            // 使用数组减少锁定时间
            s_LockAboveNormalTimeSliceQueue.Enter();
            {
                if ( s_AboveNormalTimeSliceQueue.Count > 0 )
                {
                    // 时间片先进先出列队集合的数量(和中断处理比较)
                    long iQueueCountAtSlice = s_AboveNormalTimeSliceQueue.Count;
                    if ( iQueueCountAtSlice <= s_BreakSliceAtNumber )
                    {
                        timeSliceArray = s_AboveNormalTimeSliceQueue.ToArray();
                        s_AboveNormalTimeSliceQueue.Clear();
                    }
                    else
                    {
                        timeSliceArray = new TimeSlice[s_BreakSliceAtNumber];
                        for ( long iIndex = 0; iIndex < s_BreakSliceAtNumber; iIndex++ )
                            timeSliceArray[iIndex] = s_AboveNormalTimeSliceQueue.Dequeue();

                        // 如果没有全部处理完,再发一次事件消息,让下一个线程来处理
                    }
                }
            }
            s_LockAboveNormalTimeSliceQueue.Exit();

            if ( timeSliceArray == null )
                return false;

            Stopwatch stopWatch = null;
            for ( int iIndex = 0; iIndex < timeSliceArray.Length; iIndex++ )
            {
                TimeSlice timeSlice = timeSliceArray[iIndex];

                // 线程安全的
                TimerProfile timerProfile = timeSlice.GetProfile();
                if ( timerProfile != null )
                {
                    if ( stopWatch == null )
                        stopWatch = Stopwatch.StartNew();
                    else
                        stopWatch.Start();
                }

                timeSlice.OnTick();
                timeSlice.m_InQueued = false;  // 表示当前已不在列表中,用于在TimerThread线程中检测,如果已在列表中则不许要再次加入了

                if ( timerProfile != null )
                {
                    timerProfile.RegTicked( stopWatch.Elapsed );
                    stopWatch.Reset();
                }
            }

            return true;
        }

        /// <summary>
        /// 运行时间片(Normal 调度优先级)
        /// </summary>
        internal static bool Slice_Normal()
        {
            if ( s_NormalTimeSliceQueue.Count <= 0 )
                return false;

            TimeSlice[] timeSliceArray = null;

            // 使用数组减少锁定时间
            s_LockNormalTimeSliceQueue.Enter();
            {
                if ( s_NormalTimeSliceQueue.Count > 0 )
                {
                    // 时间片先进先出列队集合的数量(和中断处理比较)
                    long iQueueCountAtSlice = s_NormalTimeSliceQueue.Count;
                    if ( iQueueCountAtSlice <= s_BreakSliceAtNumber )
                    {
                        timeSliceArray = s_NormalTimeSliceQueue.ToArray();
                        s_NormalTimeSliceQueue.Clear();
                    }
                    else
                    {
                        timeSliceArray = new TimeSlice[s_BreakSliceAtNumber];
                        for ( long iIndex = 0; iIndex < s_BreakSliceAtNumber; iIndex++ )
                            timeSliceArray[iIndex] = s_NormalTimeSliceQueue.Dequeue();

                        // 如果没有全部处理完,再发一次事件消息,让下一个线程来处理
                    }
                }
            }
            s_LockNormalTimeSliceQueue.Exit();

            if ( timeSliceArray == null )
                return false;

            Stopwatch stopWatch = null;
            for ( int iIndex = 0; iIndex < timeSliceArray.Length; iIndex++ )
            {
                TimeSlice timeSlice = timeSliceArray[iIndex];

                // 线程安全的
                TimerProfile timerProfile = timeSlice.GetProfile();
                if ( timerProfile != null )
                {
                    if ( stopWatch == null )
                        stopWatch = Stopwatch.StartNew();
                    else
                        stopWatch.Start();
                }

                timeSlice.OnTick();
                timeSlice.m_InQueued = false;  // 表示当前已不在列表中,用于在TimerThread线程中检测,如果已在列表中则不许要再次加入了

                if ( timerProfile != null )
                {
                    timerProfile.RegTicked( stopWatch.Elapsed );
                    stopWatch.Reset();
                }
            }

            return true;
        }

        /// <summary>
        /// 运行时间片(BelowNormal 调度优先级)
        /// </summary>
        private static bool Slice_BelowNormal()
        {
            if ( s_BelowNormalTimeSliceQueue.Count <= 0 )
                return false;

            TimeSlice[] timeSliceArray = null;

            // 使用数组减少锁定时间
            s_LockBelowNormalTimeSliceQueue.Enter();
            {
                if ( s_BelowNormalTimeSliceQueue.Count > 0 )
                {
                    // 时间片先进先出列队集合的数量(和中断处理比较)
                    long iQueueCountAtSlice = s_BelowNormalTimeSliceQueue.Count;
                    if ( iQueueCountAtSlice <= s_BreakSliceAtNumber )
                    {
                        timeSliceArray = s_BelowNormalTimeSliceQueue.ToArray();
                        s_BelowNormalTimeSliceQueue.Clear();
                    }
                    else
                    {
                        timeSliceArray = new TimeSlice[s_BreakSliceAtNumber];
                        for ( long iIndex = 0; iIndex < s_BreakSliceAtNumber; iIndex++ )
                            timeSliceArray[iIndex] = s_BelowNormalTimeSliceQueue.Dequeue();

                        // 如果没有全部处理完,再发一次事件消息,让下一个线程来处理
                    }
                }
            }
            s_LockBelowNormalTimeSliceQueue.Exit();

            if ( timeSliceArray == null )
                return false;

            Stopwatch stopWatch = null;
            for ( int iIndex = 0; iIndex < timeSliceArray.Length; iIndex++ )
            {
                TimeSlice timeSlice = timeSliceArray[iIndex];

                // 线程安全的
                TimerProfile timerProfile = timeSlice.GetProfile();
                if ( timerProfile != null )
                {
                    if ( stopWatch == null )
                        stopWatch = Stopwatch.StartNew();
                    else
                        stopWatch.Start();
                }

                timeSlice.OnTick();
                timeSlice.m_InQueued = false;  // 表示当前已不在列表中,用于在TimerThread线程中检测,如果已在列表中则不许要再次加入了

                if ( timerProfile != null )
                {
                    timerProfile.RegTicked( stopWatch.Elapsed );
                    stopWatch.Reset();
                }
            }

            return true;
        }

        /// <summary>
        /// 运行时间片(Lowest 调度优先级)
        /// </summary>
        private static bool Slice_Lowest()
        {
            if ( s_LowestTimeSliceQueue.Count <= 0 )
                return false;

            TimeSlice[] timeSliceArray = null;

            // 使用数组减少锁定时间
            s_LockLowestTimeSliceQueue.Enter();
            {
                if ( s_LowestTimeSliceQueue.Count > 0 )
                {
                    // 时间片先进先出列队集合的数量(和中断处理比较)
                    long iQueueCountAtSlice = s_LowestTimeSliceQueue.Count;
                    if ( iQueueCountAtSlice <= s_BreakSliceAtNumber )
                    {
                        timeSliceArray = s_LowestTimeSliceQueue.ToArray();
                        s_LowestTimeSliceQueue.Clear();
                    }
                    else
                    {
                        timeSliceArray = new TimeSlice[s_BreakSliceAtNumber];
                        for ( long iIndex = 0; iIndex < s_BreakSliceAtNumber; iIndex++ )
                            timeSliceArray[iIndex] = s_LowestTimeSliceQueue.Dequeue();

                        // 如果没有全部处理完,再发一次事件消息,让下一个线程来处理
                    }
                }
            }
            s_LockLowestTimeSliceQueue.Exit();

            if ( timeSliceArray == null )
                return false;

            Stopwatch stopWatch = null;
            for ( int iIndex = 0; iIndex < timeSliceArray.Length; iIndex++ )
            {
                TimeSlice timeSlice = timeSliceArray[iIndex];

                // 线程安全的
                TimerProfile timerProfile = timeSlice.GetProfile();
                if ( timerProfile != null )
                {
                    if ( stopWatch == null )
                        stopWatch = Stopwatch.StartNew();
                    else
                        stopWatch.Start();
                }

                timeSlice.OnTick();
                timeSlice.m_InQueued = false;  // 表示当前已不在列表中,用于在TimerThread线程中检测,如果已在列表中则不许要再次加入了

                if ( timerProfile != null )
                {
                    timerProfile.RegTicked( stopWatch.Elapsed );
                    stopWatch.Reset();
                }
            }

            return true;
        }

        /// <summary>
        /// 获取时间片定义的字符串信息
        /// </summary>
        /// <param name="delegateCallback"></param>
        /// <returns></returns>
        internal static string FormatDelegate( Delegate delegateCallback )
        {
            if ( delegateCallback == null )
                return "null";

            return String.Format( "{0}.{1}", delegateCallback.Method.DeclaringType.FullName, delegateCallback.Method.Name );
        }
        #endregion
    }
}
#endregion

