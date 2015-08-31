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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server;
#endregion

namespace Demo.Mmose.Core.AIEngine
{

//    void main()
//{
//    Read();

//    CTriggerSystem myTriggerSystem;

//    // The player constantly emits the EnemyNear trigger, by setting the duration to zero,
//    // and setting the bDynamicSourcePos flag.
//    myTriggerSystem.RegisterTrigger(kTrig_EnemyNear, 20, 0, g_pAgentList[0]->GetPosition(), 150.f, 0.f, true);


//    bool bExplosion = false;
//    bool bGunfire = false;
//    bool bMovePlayer = false;

//    unsigned long nCurTime;
//    unsigned long nStartTime = timeGetTime();
//    while(1)
//    {
//        nCurTime = timeGetTime();

//        // After 4 seconds, end the program.
//        if( nCurTime >= (nStartTime + 4000) )
//        {
//            break;
//        }

//        // After 3 seconds, the player moves closer to enemy2.
//        else if( !bMovePlayer && (nCurTime >= (nStartTime + 3000)) )
//        {
//            bMovePlayer = true;
//            printf("\nPlayer moves at 0:03\n");
//            g_pAgentList[0]->SetPosition( Vector(300.f, 120.f, 100.f) );
//        }

//        // After 2 seconds, enemy2 fires his weapon.
//        else if( !bGunfire && (nCurTime >= (nStartTime + 2000)) )
//        {
//            bGunfire = true;
//            printf("\nGunfire by Enemy2 at 0:02\n");
//            myTriggerSystem.RegisterTrigger(kTrig_Gunfire, 6, 2, g_pAgentList[2]->GetPosition(), 250.f, 0.4f, false);
//        }

//        // After 1 second, enemy3 causes an explosion.
//        else if( !bExplosion && (nCurTime >= (nStartTime + 1000)) )
//        {
//            bExplosion = true;
//            printf("\nExplosion by Enemy3 at 0:01\n");
//            myTriggerSystem.RegisterTrigger(kTrig_Explosion, 10, 3, g_pAgentList[3]->GetPosition(), 300.f, 0.5f, false);
//        }

//        myTriggerSystem.Update();
//    


    /// <summary>
    /// 
    /// </summary>
    internal class CreatureAIThread
    {
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        ///// <summary>
        ///// 下一次调用的时间片
        ///// </summary>
        //private static DateTime[] s_NextPriorities = new DateTime[8]
        //    {
        //        DateTime.Now,
        //        DateTime.Now,
        //        DateTime.Now,
        //        DateTime.Now,
        //        DateTime.Now,
        //        DateTime.Now,
        //        DateTime.Now,
        //        DateTime.Now
        //    };

        ///// <summary>
        ///// 延迟调用的时间片
        ///// </summary>
        //private static TimeSpan[] s_PriorityDelays = new TimeSpan[8]
        //    {
        //        TimeSpan.Zero,
        //        TimeSpan.FromMilliseconds( 10.0 ),
        //        TimeSpan.FromMilliseconds( 25.0 ),
        //        TimeSpan.FromMilliseconds( 50.0 ),
        //        TimeSpan.FromMilliseconds( 250.0 ),
        //        TimeSpan.FromSeconds( 1.0 ),
        //        TimeSpan.FromSeconds( 5.0 ),
        //        TimeSpan.FromMinutes( 1.0 )
        //    };

        ///// <summary>
        ///// 8种时间片的列表
        ///// </summary>
        //private static List<TimeSlice>[] s_Timers = new List<TimeSlice>[8]
        //    {
        //        new List<TimeSlice>(),
        //        new List<TimeSlice>(),
        //        new List<TimeSlice>(),
        //        new List<TimeSlice>(),
        //        new List<TimeSlice>(),
        //        new List<TimeSlice>(),
        //        new List<TimeSlice>(),
        //        new List<TimeSlice>(),
        //    };
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static System.Threading.Thread s_MobileAIThread = new System.Threading.Thread( new ThreadStart( CreatureAIThread.RunMobileAIThread ) );
        #endregion
        /// <summary>
        /// 如果有实例TimeSlice的时候就开始初始化线程
        /// </summary>
        public static void StartCreatureAIThread()
        {
            s_MobileAIThread.Name = "主AI系统 线程";
            s_MobileAIThread.Priority = ThreadPriority.AboveNormal;
            s_MobileAIThread.IsBackground = true;
            s_MobileAIThread.Start();
        }
        #endregion

        #region zh-CHS 静态方法 | en Static Method
        /// <summary>
        /// 添加或修改或移去时间片
        /// </summary>
        /// <param name="tTimer"></param>
        public static void AddAIEventInfo( BaseAIEvent aiEventInfo )
        {
            Change( aiEventInfo, true );
        }

        /// <summary>
        /// 移去时间片
        /// </summary>
        /// <param name="tTimer"></param>
        public static void RemoveAIEventInfo( BaseAIEvent aiEventInfo )
        {
            Change( aiEventInfo, false );
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
            //for ( long iIndex = 0; iIndex < 8; ++iIndex )
            //{
            //    LOGs.WriteLine( LogMessageType.MSG_INFO, "时间片优先级: {0}", (TimerPriority)iIndex );
            //    LOGs.WriteLine( LogMessageType.MSG_INFO, ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" );

            //    // 根据Timer的类型来获取所有的时间片
            //    Dictionary<string, List<TimeSlice>> l_TimerHash = new Dictionary<string, List<TimeSlice>>();

            //    foreach ( TimeSlice timeSlice in s_Timers[iIndex] )
            //    {
            //        string l_strKey = timeSlice.ToString();

            //        List<TimeSlice> l_TimeSliceList;
            //        l_TimerHash.TryGetValue( l_strKey, out l_TimeSliceList );

            //        if ( l_TimeSliceList == null )
            //            l_TimerHash[l_strKey] = l_TimeSliceList = new List<TimeSlice>();

            //        l_TimeSliceList.Add( timeSlice );
            //    }

            //    // 根据Timer的类型枚举所有的时间片
            //    foreach ( KeyValuePair<string, List<TimeSlice>> keyValuePair in l_TimerHash )
            //    {
            //        string l_strKey = keyValuePair.Key;
            //        List<TimeSlice> l_TimeSliceList = keyValuePair.Value;

            //        LOGs.WriteLine( LogMessageType.MSG_INFO, "类型: {0}; 数量: {1}; 百分比: {2}%", l_strKey, l_TimeSliceList.Count, (long)( 100 * ( l_TimeSliceList.Count / (double)s_Timers[iIndex].Count ) ) );
            //        LOGs.WriteLine( LogMessageType.MSG_INFO, "-------------------------------" );
            //    }

            //    LOGs.WriteLine( LogMessageType.MSG_INFO, ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" );
            //    LOGs.WriteLine( LogMessageType.MSG_INFO, string.Empty );
            //}
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
        private static void RunMobileAIThread()
        {
            // 向服务程序注册有新的线程在内部运行
            OneServer.BeginRegisterThread();

            LOGs.WriteLine( LogMessageType.MSG_INFO, "AI系统: 处理AI系统的主线程已启动!" );

            //long l_iIndex = 0;
            bool l_bLoaded = false;
            DateTime l_nowDateTime = DateTime.Now;

            while ( OneServer.Closing == false )
            {
                s_Signal.WaitOne( 10, false );

                // 服务已经关闭则退出
                if ( OneServer.Closing )
                    break;

                // 百分比输出显示
                if ( s_IsDumpInfo )
                {
                    s_IsDumpInfo = false;
                    InternalDumpInfo();
                }

                // 先处理改变了优先级的时间片集合
                ProcessChangeQueue();

                l_bLoaded = false;

                //// 8种时间片
                //for ( l_iIndex = 0; l_iIndex < 8; l_iIndex++ )
                //{
                //    l_nowDateTime = DateTime.Now;

                //    // 如果小于下一次处理的时间片就跳出
                //    if ( l_nowDateTime < s_NextPriorities[l_iIndex] )
                //        break;

                //    // 设置下一次处理的时间片
                //    s_NextPriorities[l_iIndex] = l_nowDateTime + s_PriorityDelays[l_iIndex];

                //    foreach ( TimeSlice timeSlice in s_Timers[l_iIndex] )
                //    {
                //        // 如果当前时间片已经处理过,已不在先入先出的集合中,并且当前的时间大于下一次调用的时间
                //        if ( timeSlice.InQueued == false && l_nowDateTime > timeSlice.NextTime )
                //        {
                //            // 表示将当前的时间片已经加入先入先出集合中
                //            TimeSlice.JoinProcessQueue( timeSlice );

                //            l_bLoaded = true;

                //            // 如果运行次数大于等于当前的时间片的运行数量话就停止(如果只运行一次的话就马上调用停止,下次运行将从列表中移去,因为已经加入了TimeSlice.s_TimeSliceQueue集合所以会调用一次的)
                //            if ( timeSlice.Count != 0 && ( timeSlice.SetAdding( timeSlice.Adding + 1 ) >= timeSlice.Count ) )
                //                timeSlice.Stop();
                //            else
                //                timeSlice.SetNextTime( l_nowDateTime + timeSlice.IntervalTime ); // 计算下次调用的时间
                //        }
                //    }
                //}

                if ( l_bLoaded )
                    OneServer.SetAllWorldSignal();
            }

            // 向服务程序注册创建的新线程已结束
            OneServer.EndRegisterThread();
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 改变或添加或移去的时间片
        /// </summary>
        private static Queue<AIChangeEntry> s_AIChangeEntryChangeQueue = new Queue<AIChangeEntry>();
        /// <summary>
        /// 
        /// </summary>
        private static object s_LockAIChangeEntryChangeQueue = new object();
        #endregion
        /// <summary>
        /// 添加或修改或移去的时间片
        /// </summary>
        /// <param name="tTimer"></param>
        /// <param name="newIndex"></param>
        /// <param name="isAdd"></param>
        private static void Change( BaseAIEvent aiEventInfo, bool isAdd )
        {
            Monitor.Enter( s_LockAIChangeEntryChangeQueue );
            {
                // 在ProcessChangeQueue(...)中释放入不使用的列表中
                s_AIChangeEntryChangeQueue.Enqueue( AIChangeEntry.Instance( aiEventInfo, isAdd ) );
            }
            Monitor.Exit( s_LockAIChangeEntryChangeQueue );

            // 发生事件
            s_Signal.Set();
        }

        /// <summary>
        /// 处理添加或修改或移去的时间片
        /// </summary>
        private static void ProcessChangeQueue()
        {
            AIChangeEntry[] l_AIChangeEntryArray = null;

            Monitor.Enter( s_LockAIChangeEntryChangeQueue );
            {
                if ( s_AIChangeEntryChangeQueue.Count > 0 )
                {
                    l_AIChangeEntryArray = s_AIChangeEntryChangeQueue.ToArray();
                    s_AIChangeEntryChangeQueue.Clear();
                }
            }
            Monitor.Exit( s_LockAIChangeEntryChangeQueue );

            if ( l_AIChangeEntryArray == null )
                return;

            foreach ( AIChangeEntry aiChangeEntry in l_AIChangeEntryArray )
            {
                if ( aiChangeEntry == null )
                {
                    Debug.WriteLine( "MobileAIThread.ProcessChangeQueue(...) - aiChangeEntry == null error!" );

                    continue;
                }

                BaseAIEvent l_nonceAIEventInfo = aiChangeEntry.AIEventInfo;
                //long l_newIndex = aiChangeEntry.TimerPriority;

                //// 先从当前的优先级时间片列表中移去
                //if ( l_nonceTimer.TimeSliceList != null )
                //    l_nonceTimer.TimeSliceList.Remove( l_nonceTimer );

                //// 如果是添加的话,初始化时间片数据
                //if ( timerChangeEntry.AddTimerSlice )
                //{
                //    l_nonceTimer.SetNextTime( DateTime.Now + l_nonceTimer.DelayTime ); // 计算下次调用的延迟的时间(m_Delay只计算使用一次)
                //    l_nonceTimer.SetAdding( 0 );
                //}

                //// 如果优先级大于或等于零则添加到新的时间片列表中去,否则置空
                //if ( l_newIndex >= 0 && l_newIndex < 8 ) // 8种时间片, -1 将不添加进列表,删除掉
                //{
                //    l_nonceTimer.TimeSliceList = s_Timers[l_newIndex];
                //    l_nonceTimer.TimeSliceList.Add( l_nonceTimer );
                //}
                //else
                //    l_nonceTimer.TimeSliceList = null;

                // 释放自己进内存池
                aiChangeEntry.Release();
            }
        }
        #endregion
    }
}
#endregion