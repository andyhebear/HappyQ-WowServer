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
using Demo.Mmose.Core.AIEngine;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SupportSlice;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Server;
using Demo.Mmose.Core.Server.Language;
using Demo.Mmose.Core.Timer;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Threading;
using Demo.Mmose.Core.Common.Atom;
using System.Diagnostics;
#endregion

namespace Demo.Mmose.Core.World
{
    /// <summary>
    /// BaseWorld 是管理整个游戏世界的入口
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
    public partial class BaseWorld
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseWorldEventArgs m_BaseWorldEventArgs = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseWorld()
        {
            m_BaseWorldEventArgs = new BaseWorldEventArgs( this ); // 在世界时间片中调用
            m_WaitExecute = new WorldWaitExecute( this ); // 初始化
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否正在存储数据中...
        /// </summary>
        private bool m_Saving = false;
        #endregion
        /// <summary>
        /// 是否正在存储数据中...
        /// </summary>
        public bool Saving
        {
            get { return m_Saving; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据存储的时间间隔
        /// </summary>
        private TimeSpan m_SaveTimeSpan = TimeSpan.FromMinutes( 5.0 );
        #endregion
        /// <summary>
        /// 存储数据的时间间隔
        /// </summary>
        public TimeSpan IntervalSave
        {
            get { return m_SaveTimeSpan; }
            set
            {
                if ( m_SaveTimeSpan.Ticks != value.Ticks )
                {
                    m_SaveTimeSpan = value;

                    TimeSlice tempTimeSlice = m_SaveTimeSlice;
                    if ( tempTimeSlice != null )
                        tempTimeSlice.IntervalTime = m_SaveTimeSpan; // 如果存在了就只改变间隔时间
                }
            }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 检查在线的时间
        /// </summary>
        private TimeSpan m_CheckAliveTime = TimeSpan.FromMinutes( 5.0 );
        #endregion
        /// <summary>
        /// 检查在线的时间
        /// </summary>
        public TimeSpan CheckAliveTime
        {
            get { return m_CheckAliveTime; }
            set
            {
                if ( m_CheckAliveTime.Ticks != value.Ticks )
                {
                    m_CheckAliveTime = value;

                    TimeSlice tempTimeSlice = m_CheckAliveTimeSlice;
                    if ( tempTimeSlice != null )
                        tempTimeSlice.IntervalTime = m_CheckAliveTime; // 如果存在了就只改变间隔时间
                }
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 游戏世界的名字
        /// </summary>
        private string m_strWorldName = string.Empty;
        #endregion
        /// <summary>
        /// 游戏世界的名字
        /// </summary>
        public string WorldName
        {
            get { return m_strWorldName; }
            set
            {
                if ( value == null )
                    return;

                m_strWorldName = value;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SliceUpdate<ISupportSlice> m_SliceUpdate = new SliceUpdate<ISupportSlice>( false );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "ISupportSlice接口的OnProcessSlice(...)只支持单线程回调:警告!" )]
        public SliceUpdate<ISupportSlice> SliceUpdate
        {
            get { return m_SliceUpdate; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WorldWaitExecute m_WaitExecute = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WorldWaitExecute WaitExecute
        {
            get { return m_WaitExecute; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NetStateManager m_NetStateManager = new NetStateManager();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public NetStateManager NetStateManager
        {
            get { return m_NetStateManager; }
        }

        #region zh-CHS MessagePump 属性 | en MessagePump Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 多个监听的端口
        /// </summary>
        private MessagePump[] m_MessagePump = new MessagePump[0];
        #endregion
        /// <summary>
        /// 监听的端口
        /// </summary>
        public MessagePump[] MessagePump
        {
            get { return m_MessagePump; }
        }

        #region zh-CHS MessagePump 方法 | en MessagePump Method
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 只锁定添加操作(因为是数组，其它的地方就可以不用锁定的)
        /// </summary>
        private SpinLock m_LockAddMessagePump = new SpinLock();
        #endregion
        /// <summary>
        /// 添加监听的端口
        /// </summary>
        /// <param name="messagePump"></param>
        public void AddMessagePump( MessagePump messagePump )
        {
            if ( messagePump == null )
                throw new Exception( "BaseWorld.AddMessagePump(...) - messagePump == null error!" );

            if ( messagePump.World != null )
                throw new ArgumentException( "BaseWorld.AddMessagePump(...) - messagePump.World != null error!", "messagePump.World" );

            m_LockAddMessagePump.Enter();
            {
                // 创建新的MessagePump数组,添加数据,交换数组数据,不需要锁定,没有引用时自动会回收数据
                MessagePump[] tempMessagePump = new MessagePump[m_MessagePump.Length + 1];

                for ( int iIndex = 0; iIndex < m_MessagePump.Length; ++iIndex )
                    tempMessagePump[iIndex] = m_MessagePump[iIndex];

                tempMessagePump[m_MessagePump.Length] = messagePump;
                messagePump.World = this;

                m_MessagePump = tempMessagePump;
            }
            m_LockAddMessagePump.Exit();
        }
        #endregion

        #endregion

        #endregion

        #region zh-CHS 内部方法 | en Internal Method

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private IOCPThreadPool m_ThreadPool = null;
        /// <summary>
        /// 
        /// </summary>
        private LockInOut m_LockThreadPool = new LockInOut( false );
        /// <summary>
        /// 可处理信号的数量
        /// </summary>
        private long m_MaxSignalCount = 0;
        #endregion
        /// <summary>
        /// 开始线程池
        /// </summary>
        internal void StartThreadPool( int maxThreadsAllowed )
        {
            if ( m_LockThreadPool.InLock() == false )
                return;

            // 最多的可处理信号的数量
            m_MaxSignalCount = maxThreadsAllowed * 2 + 2;
            m_ThreadPool = new IOCPThreadPool( IOCPThreadPool.TIMEOUT_INFINITE, (uint)maxThreadsAllowed );
        }

        /// <summary>
        /// 停止线程池
        /// </summary>
        internal void StopThreadPool()
        {
            if ( m_LockThreadPool.InLock() == true )
            {
                m_LockThreadPool.OutLock();
                return;
            }

            IOCPThreadPool tempThreadPool = m_ThreadPool;
            if ( tempThreadPool != null )
                tempThreadPool.Dispose();

            m_ThreadPool = null;
            m_LockThreadPool.OutLock();
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据保存的时间片
        /// </summary>
        private TimeSlice m_SaveTimeSlice = null;
        /// <summary>
        /// 
        /// </summary>
        private LockInOut m_LockSaveTimeSlice = new LockInOut( false );
        #endregion
        /// <summary>
        /// 开始运行数据保存的时间片
        /// </summary>
        internal void StartSaveTimeSlice()
        {
            if ( m_LockSaveTimeSlice.InLock() == false )
                return;

            // 启动BaseWorld保存数据的时间片
            m_SaveTimeSlice = TimeSlice.StartTimeSlice( m_SaveTimeSpan, m_SaveTimeSpan, new TimeSliceCallback( this.OnSave ) );
        }

        internal void StopSaveTimeSlice()
        {
            if ( m_LockSaveTimeSlice.InLock() == true )
            {
                m_LockSaveTimeSlice.OutLock();
                return;
            }

            TimeSlice tempTimeSlice = m_SaveTimeSlice;
            if ( tempTimeSlice != null )
                tempTimeSlice.Stop();

            m_SaveTimeSlice = null;
            m_LockSaveTimeSlice.OutLock();
        }

        /// <summary>
        /// 表示线程池线程要执行的回调方法。
        /// </summary>
        /// <param name="state"></param>
        private void SliceWorld( object state )
        {
            if ( OneServer.Closing == true )
            {
                Interlocked.Decrement( ref m_SignalCount );
                return;
            }

            // 运行库为每个可执行文件创建一个异常信息表。在异常信息表中，可执行文件的每个方法都有一个关联的异常处理信息数组（可以为空）。
            // 数组中的每一项描述一个受保护的代码块、任何与该代码关联的异常筛选器和任何异常处理程序（Catch 语句）。此异常表非常有效，
            // 在没有发生异常时，在处理器时间或内存使用上没有性能损失。仅在异常发生时使用资源。
            try
            {
                EventHandler<BaseWorldEventArgs> tempEventArgs = m_EventStartSlice;
                if ( tempEventArgs != null )
                    tempEventArgs( this, m_BaseWorldEventArgs );

                // 更新ISupportSlice的处理
                m_SliceUpdate.Slice();

                // AI处理
                AISystem.Slice();

                // 时间片
                TimeSlice.Slice();

                // 测试下来在数组方面for内只使用一个索引数值的时候比foreach速度快，当超过使用两个索引数值时就比foreach慢了。
                // 其他方面foreach比较快
                MessagePump[] tempArray = m_MessagePump;
                for ( int iIndex = 0; iIndex < tempArray.Length; iIndex++ )
                    tempArray[iIndex].Slice();

                // 发送缓存的数据
                this.FlushAll();

                // 处理已经断开的连接
                this.ProcessDisposed();

                tempEventArgs = m_EventEndSlice;
                if ( tempEventArgs != null )
                    tempEventArgs( this, m_BaseWorldEventArgs );

                // 最后需要等待的单处理执行
                m_WaitExecute.Slice();
            }
            catch ( Exception exception )
            {
                OneServer.UnhandledException( this, new UnhandledExceptionEventArgs( exception, true ) );
            }
            finally
            {
                Interlocked.Decrement( ref m_SignalCount );
            }
        }

        #region zh-CHS CheckAllAlive(检查客户端状态) 函数 | en CheckAllAlive(NetState) Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据保存的时间片
        /// </summary>
        private TimeSlice m_CheckAliveTimeSlice = null;
        /// <summary>
        /// 
        /// </summary>
        private LockInOut m_LockCheckAlive = new LockInOut( false );
        #endregion
        /// <summary>
        /// 初始化在线状态的检查
        /// </summary>
        internal void StartCheckAllAliveTime()
        {
            if ( m_LockCheckAlive.InLock() == false )
                return;

            // 检测用户是否超时
            // 创建检测用户是否超时的时间片(默认5分钟)
            m_CheckAliveTimeSlice = TimeSlice.StartTimeSlice( TimerPriority.Lowest, m_CheckAliveTime, m_CheckAliveTime, new TimeSliceCallback( this.CheckAllAlive ) );
        }

        internal void StopCheckAllAliveTime()
        {
            if ( m_LockCheckAlive.InLock() == true )
            {
                m_LockCheckAlive.OutLock();
                return;
            }

            TimeSlice tempTimeSlice = m_CheckAliveTimeSlice;
            if ( tempTimeSlice != null )
                tempTimeSlice.Stop();

            m_CheckAliveTimeSlice = null;
            m_LockCheckAlive.OutLock();
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否在调用CheckAllAlive(...)中...的锁
        /// </summary>
        private LockInOut m_LockInCheckAllAlive = new LockInOut( false );
        #endregion
        /// <summary>
        /// 检查全部的连接是否有效
        /// </summary>
        private void CheckAllAlive()
        {
            // 检查是否已经在处理CheckAllAlive(...)的调用
            if ( m_LockInCheckAllAlive.InLock() == false )
                return;

            // 已经在处理CheckAllAlive(...)中

            // 处理数据
            NetState[] netStateArray = m_NetStateManager.ToArray();
            for ( int iIndex = 0; iIndex < netStateArray.Length; iIndex++ )
                netStateArray[iIndex].CheckAlive();

            // 已经处理完CheckAllAlive(...)的调用
            m_LockInCheckAllAlive.OutLock();
        }
        #endregion

        #region zh-CHS FlushAll(发送全部数据) 函数 | en FlushAll(NetState) Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int QUEUE_CAPACITY_SIZE = 1024;
        #endregion
        /// <summary>
        /// 需要处理发送的客户端的集合
        /// </summary>
        private Queue<NetState> m_NetStateFlush = new Queue<NetState>( QUEUE_CAPACITY_SIZE );
        /// <summary>
        /// 处理发送的客户端的集合锁
        /// </summary>
        private SpinLock m_LockNetStateFlush = new SpinLock();
        #endregion
        /// <summary>
        /// 放入处理发送的客户端的集合内,等待处理
        /// </summary>
        /// <param name="netSatate"></param>
        internal void FlushNetStates( NetState netSatate )
        {
            if ( netSatate.InFlushQueue() == false )
                return;

            m_LockNetStateFlush.Enter();
            {
                m_NetStateFlush.Enqueue( netSatate );
            }
            m_LockNetStateFlush.Exit();
        }

        /// <summary>
        /// 发送全部的数据
        /// </summary>
        internal void FlushAll()
        {
            // 处理数据
            NetState[] netStateArray = null;

            m_LockNetStateFlush.Enter();
            {
                if ( m_NetStateFlush.Count > 0 )
                {
                    netStateArray = m_NetStateFlush.ToArray();
                    m_NetStateFlush.Clear();
                }
            }
            m_LockNetStateFlush.Exit();

            if ( netStateArray == null )
                return;

            for ( int iIndex = 0; iIndex < netStateArray.Length; iIndex++ )
            {
                NetState netState = netStateArray[iIndex];
                if ( netState.Running == true ) // 如果NetState有效
                {
                    netState.Flush();

                    netState.OutFlushQueue(); // 处理完毕

                    // 如果还有没有全部Flush的数据则添加(再次Flush数据),防止多线程漏处理的问题
                    if ( netState.SendQueue.IsEmpty == false )
                        this.FlushNetStates( netState );
                }
            }
        }
        #endregion

        #region zh-CHS ProcessDisposed(处理断开) 方法 | en ProcessDisposed(NetState) Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 需要处理的无效客户端的集合
        /// </summary>
        private Queue<NetState> m_NetStateDisposed = new Queue<NetState>( QUEUE_CAPACITY_SIZE );
        /// <summary>
        /// 无效客户端的集合锁
        /// </summary>
        private SpinLock m_LockNetStateDisposed = new SpinLock();
        #endregion
        /// <summary>
        /// 放入无效客户端的集合内,等待处理
        /// </summary>
        /// <param name="netSatate"></param>
        internal void DisposedNetStates( NetState netSatate )
        {
            m_LockNetStateDisposed.Enter();
            {
                m_NetStateDisposed.Enqueue( netSatate );
            }
            m_LockNetStateDisposed.Exit();
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 当断开处理的累计数量到该数量时将中断后面的调用
        /// </summary>
        private readonly static int BREAK_COUNT = 16; // 默认值(在多线程中不因该太多)
        #endregion
        /// <summary>
        /// 是否在调用ProcessDisposed(...)中...的锁
        /// </summary>
        private LockInOut m_LockInProcessDisposed = new LockInOut( false );
        #endregion
        /// <summary>
        /// 处理全部的已断开连接的客户,不要处理过多的断开,以影响时间片的处理
        /// 主要是处理NetStateManage内的NetState
        /// </summary>
        internal void ProcessDisposed()
        {
            // 检查是否已经在处理ProcessDisposed(...)的调用
            if ( m_LockInProcessDisposed.InLock() == false )
                return;

            // 已经在处理ProcessDisposed(...)中

            do
            {
                // 使用数组减少锁定时间
                NetState[] netStateArray = null;

                if ( SpinLockEx.QuickTryEnter( ref m_LockNetStateDisposed ) == false )
                    break;
                {
                    if ( m_NetStateDisposed.Count > 0 )
                    {
                        // 断开连接的客户先进先出列队集合的数量(和中断处理比较)
                        long iQueueCountAtNetState = m_NetStateDisposed.Count;
                        if ( iQueueCountAtNetState <= BREAK_COUNT )
                        {
                            netStateArray = m_NetStateDisposed.ToArray();
                            m_NetStateDisposed.Clear();
                        }
                        else
                        {
                            netStateArray = new NetState[BREAK_COUNT];
                            for ( long iIndex = 0; iIndex < BREAK_COUNT; iIndex++ )
                                netStateArray[iIndex] = m_NetStateDisposed.Dequeue();
                        }
                    }
                }
                m_LockNetStateDisposed.Exit();

                // 如果没有需要处理的数据则返回
                if ( netStateArray == null )
                    break;

                for ( int iIndex = 0; iIndex < netStateArray.Length; iIndex++ )
                    netStateArray[iIndex].ExitWorld();

            } while ( false );

            // 已经处理完ProcessDisposed(...)的调用
            m_LockInProcessDisposed.OutLock();
        }
        #endregion

        #endregion

        #region zh-CHS 共有方法 | en Public Method
        /// <summary>
        /// 广播数据信息
        /// </summary>
        /// <param name="state"></param>
        /// <param name="strText"></param>
        public void Broadcast( object state, string strText )
        {
            this.OnBroadcast( state, strText );
        }

        /// <summary>
        /// 广播数据信息
        /// </summary>
        /// <param name="state"></param>
        /// <param name="strFormat"></param>
        /// <param name="args"></param>
        public void Broadcast( object state, string strFormat, params object[] args )
        {
            this.Broadcast( state, string.Format( strFormat, args ) );
        }

        /// <summary>
        /// 保存世界的数据
        /// </summary>
        public void Save()
        {
            // 保存世界的数据必须要成功才返回
            m_LockSave.Enter();
            {
                // 保存数据中......
                m_Saving = true;

                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.BaseWorldString001 );

                // 保存数据
                EventHandler<BaseWorldEventArgs> tempEvent = m_EventSaveWorld;
                if ( tempEvent != null )
                {
                    BaseWorldEventArgs worldEventArgs = new BaseWorldEventArgs( this );
                    tempEvent( this, worldEventArgs );
                }

                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.BaseWorldString002 );

                // 保存数据结束......
                m_Saving = false;
            }
            m_LockSave.Exit();
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_strWorldName;
        }
        #endregion

        #region zh-CHS 共有通知信号方法 | en Public WorldSignal Method
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_SignalCount = 0;
        /// <summary>
        /// 
        /// </summary>
        private object m_LockSignalCount = new object();
        #endregion
        /// <summary>
        /// 游戏世界的通知信号
        /// </summary>
        public void SetWorldSignal()
        {
            if ( m_SignalCount > m_MaxSignalCount )
                return;
            else
                Interlocked.Increment( ref m_SignalCount );

            // 打开默认线程池的处理
            IOCPThreadPool tempThreadPool = m_ThreadPool;
            if ( tempThreadPool != null )
                tempThreadPool.QueueUserWorkItem( this.SliceWorld );
        }
        #endregion

        #region zh-CHS 内部的事件处理函数 | en Internal Event Handlers
        /// <summary>
        /// 初始化世界服务
        /// </summary>
        internal void OnInitOnce()
        {
            // 在开始运行世界之前,初始化一次BaseWorld
            // 需要一个副本是因为可能在需要调用的时候,已经注销掉了
            EventHandler<BaseWorldEventArgs> tempEvent = m_EventInitOnceWorld;
            if ( tempEvent != null )
            {
                BaseWorldEventArgs worldEventArgs = new BaseWorldEventArgs( this );
                tempEvent( this, worldEventArgs );
            }
        }

        /// <summary>
        /// 结束世界服务
        /// </summary>
        internal void OnExit()
        {
            // 在结束世界之前,调用一次
            EventHandler<BaseWorldEventArgs> tempEvent = m_EventExitWorld;
            if ( tempEvent != null )
            {
                BaseWorldEventArgs worldEventArgs = new BaseWorldEventArgs( this );
                tempEvent( this, worldEventArgs );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockSave = new SpinLock();
        #endregion
        /// <summary>
        /// 保存世界服务
        /// </summary>
        internal void OnSave()
        {
            if ( SpinLockEx.QuickTryEnter( ref m_LockSave ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.BaseWorldString003 );
                return;
            }
            else
            {
                // 保存数据
                EventHandler<BaseWorldEventArgs> tempEvent = m_EventSaveWorld;
                if ( tempEvent != null )
                {
                    // 保存数据中......
                    m_Saving = true;

                    LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.BaseWorldString001 );

                    BaseWorldEventArgs worldEventArgs = new BaseWorldEventArgs( this );
                    tempEvent( this, worldEventArgs );

                    LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.BaseWorldString002 );

                    // 保存数据结束......
                    m_Saving = false;
                }
            }
            m_LockSave.Exit();
        }

        /// <summary>
        /// 广播数据到整个世界服务
        /// </summary>
        /// <param name="state"></param>
        /// <param name="strText"></param>
        internal void OnBroadcast( object state, string strText )
        {
            // 广播数据
            EventHandler<BaseWorldEventArgs> tempEvent = m_EventBroadcast;
            if ( tempEvent != null )
            {
                BroadcastEventArgs worldEventArgs = new BroadcastEventArgs( this, strText, state );
                tempEvent( this, worldEventArgs );
            }
        }
        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BaseWorldEventArgs> m_EventStartSlice;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventStartSlice = new SpinLock();
        #endregion
        /// <summary>
        /// World可处理的时间片
        /// </summary>
        public event EventHandler<BaseWorldEventArgs> EventStartSlice
        {
            add
            {
                m_LockEventStartSlice.Enter();
                {
                    m_EventStartSlice += value;
                }
                m_LockEventStartSlice.Exit();
            }
            remove
            {
                m_LockEventStartSlice.Enter();
                {
                    m_EventStartSlice -= value;
                }
                m_LockEventStartSlice.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BaseWorldEventArgs> m_EventEndSlice;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventEndSlice = new SpinLock();
        #endregion
        /// <summary>
        /// World可处理的时间片
        /// </summary>
        public event EventHandler<BaseWorldEventArgs> EventEndSlice
        {
            add
            {
                m_LockEventEndSlice.Enter();
                {
                    m_EventEndSlice += value;
                }
                m_LockEventEndSlice.Exit();
            }
            remove
            {
                m_LockEventEndSlice.Enter();
                {
                    m_EventEndSlice -= value;
                }
                m_LockEventEndSlice.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BaseWorldEventArgs> m_EventInitOnceWorld;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventInitOnceWorld = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BaseWorldEventArgs> EventInitOnceWorld
        {
            add
            {
                m_LockEventInitOnceWorld.Enter();
                {
                    m_EventInitOnceWorld += value;
                }
                m_LockEventInitOnceWorld.Exit();
            }
            remove
            {
                m_LockEventInitOnceWorld.Enter();
                {
                    m_EventInitOnceWorld -= value;
                }
                m_LockEventInitOnceWorld.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BaseWorldEventArgs> m_EventExitWorld;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventExitWorld = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BaseWorldEventArgs> EventExitWorld
        {
            add
            {
                m_LockEventExitWorld.Enter();
                {
                    m_EventExitWorld += value;
                }
                m_LockEventExitWorld.Exit();
            }
            remove
            {
                m_LockEventExitWorld.Enter();
                {
                    m_EventExitWorld -= value;
                }
                m_LockEventExitWorld.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BaseWorldEventArgs> m_EventSaveWorld;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventSaveWorld = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BaseWorldEventArgs> EventSaveWorld
        {
            add 
            {
                m_LockEventSaveWorld.Enter();
                {
                    m_EventSaveWorld += value;
                }
                m_LockEventSaveWorld.Exit();
            }
            remove
            {
                m_LockEventSaveWorld.Enter();
                {
                    m_EventSaveWorld -= value;
                }
                m_LockEventSaveWorld.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BaseWorldEventArgs> m_EventBroadcast;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockEventBroadcast = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BaseWorldEventArgs> EventBroadcast
        {
            add
            {
                m_LockEventBroadcast.Enter();
                {
                    m_EventBroadcast += value;
                }
                m_LockEventBroadcast.Exit();
            }
            remove
            {
                m_LockEventBroadcast.Enter();
                {
                    m_EventBroadcast -= value;
                }
                m_LockEventBroadcast.Exit();
            }
        }

        #endregion
    }
}
#endregion