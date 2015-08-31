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
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server.Language;
using Demo.Mmose.Core.Server;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Timer
{
    /// <summary>
    /// 
    /// </summary>
    internal class TimerThread
    {
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 下一次调用的时间片
        /// </summary>
        private static DateTime[] s_NextPriorities = new DateTime[8]
            {
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now
            };

        /// <summary>
        /// 延迟调用的时间片
        /// </summary>
        private static TimeSpan[] s_PriorityDelays = new TimeSpan[8]
			{
				TimeSpan.Zero,
				TimeSpan.FromMilliseconds( 10.0 ),
				TimeSpan.FromMilliseconds( 25.0 ),
				TimeSpan.FromMilliseconds( 50.0 ),
				TimeSpan.FromMilliseconds( 250.0 ),
				TimeSpan.FromSeconds( 1.0 ),
				TimeSpan.FromSeconds( 5.0 ),
				TimeSpan.FromMinutes( 1.0 )
			};

        /// <summary>
        /// 8种时间片的列表
        /// </summary>
        private static Dictionary<TimeSlice, TimeSlice>[] s_Timers = new Dictionary<TimeSlice, TimeSlice>[8]
			{
				new Dictionary<TimeSlice, TimeSlice>( 100 ),
				new Dictionary<TimeSlice, TimeSlice>( 100 ),
				new Dictionary<TimeSlice, TimeSlice>( 100 ),
				new Dictionary<TimeSlice, TimeSlice>( 100 ),
				new Dictionary<TimeSlice, TimeSlice>( 100 ),
				new Dictionary<TimeSlice, TimeSlice>( 100 ),
				new Dictionary<TimeSlice, TimeSlice>( 100 ),
				new Dictionary<TimeSlice, TimeSlice>( 100 ),
			};
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static System.Threading.Thread s_TimerThread = new System.Threading.Thread( new ThreadStart( TimerThread.RunTimerThread ) );
        #endregion
        /// <summary>
        /// 如果有实例TimeSlice的时候就开始初始化线程
        /// </summary>
        public static void StartTimerThread()
        {
            s_TimerThread.Name = LanguageString.SingletonInstance.TimerThreadString001;
            s_TimerThread.Priority = ThreadPriority.AboveNormal;
            s_TimerThread.IsBackground = true;
            s_TimerThread.Start();
        }
        #endregion

        #region zh-CHS 静态方法 | en Static Method
        /// <summary>
        /// 添加或修改或移去时间片
        /// </summary>
        /// <param name="tTimer"></param>
        public static void AddTimer( TimeSlice tTimer )
        {
            Change( tTimer, (long)tTimer.Frequency, true );
        }

        /// <summary>
        /// 修改时间片优先级
        /// </summary>
        /// <param name="tTimer"></param>
        /// <param name="newPrio"></param>
        public static void PriorityChange( TimeSlice tTimer, TimerFrequency newPriority )
        {
            Change( tTimer, (long)newPriority, false );
        }

        /// <summary>
        /// 移去时间片
        /// </summary>
        /// <param name="tTimer"></param>
        public static void RemoveTimer( TimeSlice tTimer )
        {
            Change( tTimer, -1, false );
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static volatile bool s_IsDumpInfo = false;
        #endregion
        /// <summary>
        /// 根据TimeSlice类型的数量和百分比输出显示,显示信息在时间片主线程内部显示
        /// 所以这样是为了防止多线程显示信息时需要锁定s_Timers,将会影响性能的,所以将在主线程内部处理
        /// </summary>
        /// <param name="textWriter"></param>
        public static void DumpInfo()
        {
            s_IsDumpInfo = true;
        }

        /// <summary>
        /// 根据Timer的类型的数量和百分比输出显示
        /// </summary>
        /// <param name="textWriter"></param>
        private static void InternalDumpInfo()
        {
            for ( long iIndex = 0; iIndex < 8; ++iIndex )
            {
                LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.TimerThreadString002, (TimerFrequency)iIndex );
                LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.TimerThreadString003 );

                // 根据Timer的类型来获取所有的时间片
                Dictionary<string, List<TimeSlice>> timerHash = new Dictionary<string, List<TimeSlice>>();

                foreach ( KeyValuePair<TimeSlice, TimeSlice> timeSlice in s_Timers[iIndex] )
                {
                    string strKey = timeSlice.Value.ToString();

                    List<TimeSlice> timeSliceList = null;
                    timerHash.TryGetValue( strKey, out timeSliceList );

                    if ( timeSliceList == null )
                        timerHash[strKey] = timeSliceList = new List<TimeSlice>( 20 );

                    timeSliceList.Add( timeSlice.Value );
                }

                // 根据Timer的类型枚举所有的时间片
                foreach ( KeyValuePair<string, List<TimeSlice>> keyValuePair in timerHash )
                {
                    string strKey = keyValuePair.Key;
                    List<TimeSlice> timeSliceList = keyValuePair.Value;

                    LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.TimerThreadString004, strKey, timeSliceList.Count, (long)( 100 * ( timeSliceList.Count / (double)s_Timers[iIndex].Count ) ) );
                    LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.TimerThreadString005 );
                }

                LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.TimerThreadString006 );
                LOGs.WriteLine( LogMessageType.MSG_INFO, string.Empty );
            }
        }
        #endregion

        #region zh-CHS 私有静态方法 | en Private Static Method
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 当有新的时间片改动或添加或移去的时候事件发生
        /// </summary>
        private static AutoResetEvent s_Signal = new AutoResetEvent( true );
        #endregion
        /// <summary>
        /// Timer的主要处理函数,用来计算是否需要处理的时候了
        /// </summary>
        private static void RunTimerThread()
        {
            // 向服务程序注册有新的线程在内部运行
            OneServer.BeginRegisterThread();

            LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.TimerThreadString007 );

            long iIndex = 0;
            bool bLoaded = false;
            DateTime nowDateTime = DateTime.Now;

            while ( OneServer.Closing == false )
            {
                s_Signal.WaitOne( 10, false );

                // 服务已经关闭则退出
                if ( OneServer.Closing == true )
                    break;

                // 百分比输出显示
                if ( s_IsDumpInfo == true )
                {
                    s_IsDumpInfo = false;
                    InternalDumpInfo();
                }

                // 先处理改变了优先级的时间片集合
                ProcessChangeQueue();

                bLoaded = false;

                // 8种时间片
                for ( iIndex = 0; iIndex < 8; iIndex++ )
                {
                    nowDateTime = DateTime.Now;

                    // 如果小于下一次处理的时间片就跳出
                    if ( nowDateTime < s_NextPriorities[iIndex] )
                        break;

                    // 设置下一次处理的时间片
                    s_NextPriorities[iIndex] = nowDateTime + s_PriorityDelays[iIndex];

                    foreach ( KeyValuePair<TimeSlice, TimeSlice> timeSlice in s_Timers[iIndex] )
                    {
                        // 如果当前时间片已经处理过,已不在先入先出的集合中,并且当前的时间大于下一次调用的时间
                        if ( timeSlice.Value.InQueued == false && nowDateTime > timeSlice.Value.NextTime )
                        {
                            // 表示将当前的时间片已经加入先入先出集合中
                            TimeSlice.JoinProcessQueue( timeSlice.Value );

                            bLoaded = true;

                            // 如果运行次数大于等于当前的时间片的运行数量话就停止(如果只运行一次的话就马上调用停止,下次运行将从列表中移去,因为已经加入了TimeSlice.s_TimeSliceQueue集合所以会调用一次的)
                            if ( timeSlice.Value.Count != 0 && ++timeSlice.Value.Adding >= timeSlice.Value.Count )
                                timeSlice.Value.Stop();
                            else
                                timeSlice.Value.NextTime = nowDateTime + timeSlice.Value.IntervalTime; // 计算下次调用的时间
                        }
                    }
                }

                if ( bLoaded == true )
                    OneServer.SetAllWorldSignal();
            }

            // 向服务程序注册创建的新线程已结束
            OneServer.EndRegisterThread();
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 改变或添加或移去的时间片
        /// </summary>
        private static Queue<TimerChangeEntry> s_TimerChangeEntryChangeQueue = new Queue<TimerChangeEntry>();
        /// <summary>
        /// 
        /// </summary>
        private static SpinLock s_LockTimerChangeEntryChangeQueue = new SpinLock();
        #endregion
        /// <summary>
        /// 添加或修改或移去的时间片
        /// </summary>
        /// <param name="tTimer"></param>
        /// <param name="newIndex"></param>
        /// <param name="isAdd"></param>
        private static void Change( TimeSlice tTimer, long newIndex, bool isAdd )
        {
            s_LockTimerChangeEntryChangeQueue.Enter();
            {
                // 在ProcessChangeQueue(...)中释放入不使用的列表中
                s_TimerChangeEntryChangeQueue.Enqueue( new TimerChangeEntry( tTimer, newIndex, isAdd ) );
            }
            s_LockTimerChangeEntryChangeQueue.Exit();

            // 发生事件
            s_Signal.Set();
        }

        /// <summary>
        /// 处理添加或修改或移去的时间片
        /// </summary>
        private static void ProcessChangeQueue()
        {
            TimerChangeEntry[] timerChangeEntryArray = null;

            s_LockTimerChangeEntryChangeQueue.Enter();
            {
                if ( s_TimerChangeEntryChangeQueue.Count > 0 )
                {
                    timerChangeEntryArray = s_TimerChangeEntryChangeQueue.ToArray();
                    s_TimerChangeEntryChangeQueue.Clear();
                }
            }
            s_LockTimerChangeEntryChangeQueue.Exit();

            if ( timerChangeEntryArray == null )
                return;

            for ( int iIndex = 0; iIndex < timerChangeEntryArray.Length; iIndex++ )
            {
                TimerChangeEntry timerChangeEntry = timerChangeEntryArray[iIndex];

                TimeSlice nonceTimer = timerChangeEntry.TimerSlice;
                long newIndex = timerChangeEntry.TimerPriority;

                // 先从当前的优先级时间片列表中移去
                if ( nonceTimer.TimeSliceDictionary != null )
                    nonceTimer.TimeSliceDictionary.Remove( nonceTimer );

                // 如果是添加的话,初始化时间片数据
                if ( timerChangeEntry.AddTimerSlice == true )
                {
                    nonceTimer.NextTime = DateTime.Now + nonceTimer.DelayTime; // 计算下次调用的延迟的时间(m_Delay只计算使用一次)
                    nonceTimer.Adding = 0;
                }

                // 如果优先级大于或等于零则添加到新的时间片列表中去,否则置空
                if ( newIndex >= 0 && newIndex < 8 ) // 8种时间片, -1 将不添加进列表,删除掉
                {
                    nonceTimer.TimeSliceDictionary = s_Timers[newIndex];
                    nonceTimer.TimeSliceDictionary.Add( nonceTimer, nonceTimer );
                }
                else
                    nonceTimer.TimeSliceDictionary = null;
            }
        }
        #endregion
    }
}
#endregion