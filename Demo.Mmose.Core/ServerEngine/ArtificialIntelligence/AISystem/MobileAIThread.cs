#region zh-CHS 2006 - 2008 DemoSoft �Ŷ� | en 2006 - 2008 DemoSoft Team

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

#region zh-CHS �������ֿռ� | en Include namespace
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
        #region zh-CHS ˽�о�̬��Ա���� | en Private Static Member Variables
        ///// <summary>
        ///// ��һ�ε��õ�ʱ��Ƭ
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
        ///// �ӳٵ��õ�ʱ��Ƭ
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
        ///// 8��ʱ��Ƭ���б�
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

        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        #region zh-CHS ˽�о�̬��Ա���� | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static System.Threading.Thread s_MobileAIThread = new System.Threading.Thread( new ThreadStart( CreatureAIThread.RunMobileAIThread ) );
        #endregion
        /// <summary>
        /// �����ʵ��TimeSlice��ʱ��Ϳ�ʼ��ʼ���߳�
        /// </summary>
        public static void StartCreatureAIThread()
        {
            s_MobileAIThread.Name = "��AIϵͳ �߳�";
            s_MobileAIThread.Priority = ThreadPriority.AboveNormal;
            s_MobileAIThread.IsBackground = true;
            s_MobileAIThread.Start();
        }
        #endregion

        #region zh-CHS ��̬���� | en Static Method
        /// <summary>
        /// ��ӻ��޸Ļ���ȥʱ��Ƭ
        /// </summary>
        /// <param name="tTimer"></param>
        public static void AddAIEventInfo( BaseAIEvent aiEventInfo )
        {
            Change( aiEventInfo, true );
        }

        /// <summary>
        /// ��ȥʱ��Ƭ
        /// </summary>
        /// <param name="tTimer"></param>
        public static void RemoveAIEventInfo( BaseAIEvent aiEventInfo )
        {
            Change( aiEventInfo, false );
        }

        #region zh-CHS ˽�о�̬��Ա���� | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static volatile bool s_IsDumpInfo = false;
        #endregion
        /// <summary>
        /// ����TimeSlice���͵������Ͱٷֱ������ʾ,��ʾ��Ϣ��ʱ��Ƭ���߳��ڲ���ʾ
        /// ����������Ϊ�˷�ֹ���߳���ʾ��Ϣʱ��Ҫ����s_Timers,����Ӱ�����ܵ�,���Խ������߳��ڲ�����
        /// </summary>
        /// <param name="textWriter"></param>
        public static void DumpInfo()
        {
            s_IsDumpInfo = true;
        }

        /// <summary>
        /// ����Timer�����͵������Ͱٷֱ������ʾ
        /// </summary>
        /// <param name="textWriter"></param>
        private static void InternalDumpInfo()
        {
            //for ( long iIndex = 0; iIndex < 8; ++iIndex )
            //{
            //    LOGs.WriteLine( LogMessageType.MSG_INFO, "ʱ��Ƭ���ȼ�: {0}", (TimerPriority)iIndex );
            //    LOGs.WriteLine( LogMessageType.MSG_INFO, ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" );

            //    // ����Timer����������ȡ���е�ʱ��Ƭ
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

            //    // ����Timer������ö�����е�ʱ��Ƭ
            //    foreach ( KeyValuePair<string, List<TimeSlice>> keyValuePair in l_TimerHash )
            //    {
            //        string l_strKey = keyValuePair.Key;
            //        List<TimeSlice> l_TimeSliceList = keyValuePair.Value;

            //        LOGs.WriteLine( LogMessageType.MSG_INFO, "����: {0}; ����: {1}; �ٷֱ�: {2}%", l_strKey, l_TimeSliceList.Count, (long)( 100 * ( l_TimeSliceList.Count / (double)s_Timers[iIndex].Count ) ) );
            //        LOGs.WriteLine( LogMessageType.MSG_INFO, "-------------------------------" );
            //    }

            //    LOGs.WriteLine( LogMessageType.MSG_INFO, ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" );
            //    LOGs.WriteLine( LogMessageType.MSG_INFO, string.Empty );
            //}
        }
        #endregion

        #region zh-CHS ˽�о�̬���� | en Private Static Method
        #region zh-CHS ˽�о�̬��Ա���� | en Private Static Member Variables
        /// <summary>
        /// �����µ�ʱ��Ƭ�Ķ�����ӻ���ȥ��ʱ���¼�����
        /// </summary>
        private static AutoResetEvent s_Signal = new AutoResetEvent( true );
        #endregion
        /// <summary>
        /// Timer����Ҫ������,���������Ƿ���Ҫ�����ʱ����
        /// </summary>
        private static void RunMobileAIThread()
        {
            // ��������ע�����µ��߳����ڲ�����
            OneServer.BeginRegisterThread();

            LOGs.WriteLine( LogMessageType.MSG_INFO, "AIϵͳ: ����AIϵͳ�����߳�������!" );

            //long l_iIndex = 0;
            bool l_bLoaded = false;
            DateTime l_nowDateTime = DateTime.Now;

            while ( OneServer.Closing == false )
            {
                s_Signal.WaitOne( 10, false );

                // �����Ѿ��ر����˳�
                if ( OneServer.Closing )
                    break;

                // �ٷֱ������ʾ
                if ( s_IsDumpInfo )
                {
                    s_IsDumpInfo = false;
                    InternalDumpInfo();
                }

                // �ȴ���ı������ȼ���ʱ��Ƭ����
                ProcessChangeQueue();

                l_bLoaded = false;

                //// 8��ʱ��Ƭ
                //for ( l_iIndex = 0; l_iIndex < 8; l_iIndex++ )
                //{
                //    l_nowDateTime = DateTime.Now;

                //    // ���С����һ�δ����ʱ��Ƭ������
                //    if ( l_nowDateTime < s_NextPriorities[l_iIndex] )
                //        break;

                //    // ������һ�δ����ʱ��Ƭ
                //    s_NextPriorities[l_iIndex] = l_nowDateTime + s_PriorityDelays[l_iIndex];

                //    foreach ( TimeSlice timeSlice in s_Timers[l_iIndex] )
                //    {
                //        // �����ǰʱ��Ƭ�Ѿ������,�Ѳ��������ȳ��ļ�����,���ҵ�ǰ��ʱ�������һ�ε��õ�ʱ��
                //        if ( timeSlice.InQueued == false && l_nowDateTime > timeSlice.NextTime )
                //        {
                //            // ��ʾ����ǰ��ʱ��Ƭ�Ѿ����������ȳ�������
                //            TimeSlice.JoinProcessQueue( timeSlice );

                //            l_bLoaded = true;

                //            // ������д������ڵ��ڵ�ǰ��ʱ��Ƭ��������������ֹͣ(���ֻ����һ�εĻ������ϵ���ֹͣ,�´����н����б�����ȥ,��Ϊ�Ѿ�������TimeSlice.s_TimeSliceQueue�������Ի����һ�ε�)
                //            if ( timeSlice.Count != 0 && ( timeSlice.SetAdding( timeSlice.Adding + 1 ) >= timeSlice.Count ) )
                //                timeSlice.Stop();
                //            else
                //                timeSlice.SetNextTime( l_nowDateTime + timeSlice.IntervalTime ); // �����´ε��õ�ʱ��
                //        }
                //    }
                //}

                if ( l_bLoaded )
                    OneServer.SetAllWorldSignal();
            }

            // ��������ע�ᴴ�������߳��ѽ���
            OneServer.EndRegisterThread();
        }

        #region zh-CHS ˽�о�̬��Ա���� | en Private Static Member Variables
        /// <summary>
        /// �ı����ӻ���ȥ��ʱ��Ƭ
        /// </summary>
        private static Queue<AIChangeEntry> s_AIChangeEntryChangeQueue = new Queue<AIChangeEntry>();
        /// <summary>
        /// 
        /// </summary>
        private static object s_LockAIChangeEntryChangeQueue = new object();
        #endregion
        /// <summary>
        /// ��ӻ��޸Ļ���ȥ��ʱ��Ƭ
        /// </summary>
        /// <param name="tTimer"></param>
        /// <param name="newIndex"></param>
        /// <param name="isAdd"></param>
        private static void Change( BaseAIEvent aiEventInfo, bool isAdd )
        {
            Monitor.Enter( s_LockAIChangeEntryChangeQueue );
            {
                // ��ProcessChangeQueue(...)���ͷ��벻ʹ�õ��б���
                s_AIChangeEntryChangeQueue.Enqueue( AIChangeEntry.Instance( aiEventInfo, isAdd ) );
            }
            Monitor.Exit( s_LockAIChangeEntryChangeQueue );

            // �����¼�
            s_Signal.Set();
        }

        /// <summary>
        /// ������ӻ��޸Ļ���ȥ��ʱ��Ƭ
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

                //// �ȴӵ�ǰ�����ȼ�ʱ��Ƭ�б�����ȥ
                //if ( l_nonceTimer.TimeSliceList != null )
                //    l_nonceTimer.TimeSliceList.Remove( l_nonceTimer );

                //// �������ӵĻ�,��ʼ��ʱ��Ƭ����
                //if ( timerChangeEntry.AddTimerSlice )
                //{
                //    l_nonceTimer.SetNextTime( DateTime.Now + l_nonceTimer.DelayTime ); // �����´ε��õ��ӳٵ�ʱ��(m_Delayֻ����ʹ��һ��)
                //    l_nonceTimer.SetAdding( 0 );
                //}

                //// ������ȼ����ڻ����������ӵ��µ�ʱ��Ƭ�б���ȥ,�����ÿ�
                //if ( l_newIndex >= 0 && l_newIndex < 8 ) // 8��ʱ��Ƭ, -1 ������ӽ��б�,ɾ����
                //{
                //    l_nonceTimer.TimeSliceList = s_Timers[l_newIndex];
                //    l_nonceTimer.TimeSliceList.Add( l_nonceTimer );
                //}
                //else
                //    l_nonceTimer.TimeSliceList = null;

                // �ͷ��Լ����ڴ��
                aiChangeEntry.Release();
            }
        }
        #endregion
    }
}
#endregion