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
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Map;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Common.EventSkin
{
    /// <summary>
    /// 
    /// </summary>
    public static class GlobalEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public static class BaseCharacter
        {
            #region zh-CHS MoveTo 共有静态事件 | en Public Static Event

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private static EventHandler<MoveToEventArgs> m_MoveTo;
            /// <summary>
            /// 
            /// </summary>
            private static SpinLock m_LockMoveTo = new SpinLock();
            #endregion
            /// <summary>
            /// World可处理的时间片
            /// </summary>
            public static event EventHandler<MoveToEventArgs> MoveTo
            {
                add
                {
                    m_LockMoveTo.Enter();
                    {
                        m_MoveTo += value;
                    }
                    m_LockMoveTo.Exit();
                }
                remove
                {
                    m_LockMoveTo.Enter();
                    {
                        m_MoveTo -= value;
                    }
                    m_LockMoveTo.Exit();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="eventArgs"></param>
            internal static MoveToEventArgs InvokeMoveTo( Point3D newLocation, WorldEntity entity )
            {
                EventHandler<MoveToEventArgs> tempMoveTo = m_MoveTo;
                if ( tempMoveTo != null )
                {
                    MoveToEventArgs moveToEventArgs = new MoveToEventArgs( newLocation, entity );
                    if ( moveToEventArgs == null )
                        return null;

                    tempMoveTo( entity, moveToEventArgs );

                    return moveToEventArgs;
                }

                return null;
            }

            #endregion

            #region zh-CHS MoveToWorld 共有静态事件 | en Public Static Event

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private static EventHandler<MoveToWorldEventArgs> m_MoveToWorld;
            /// <summary>
            /// 
            /// </summary>
            private static SpinLock m_LockMoveToWorld = new SpinLock();
            #endregion
            /// <summary>
            /// World可处理的时间片
            /// </summary>
            public static event EventHandler<MoveToWorldEventArgs> MoveToWorld
            {
                add
                {
                    m_LockMoveToWorld.Enter();
                    {
                        m_MoveToWorld += value;
                    }
                    m_LockMoveToWorld.Exit();
                }
                remove
                {
                    m_LockMoveToWorld.Enter();
                    {
                        m_MoveToWorld -= value;
                    }
                    m_LockMoveToWorld.Exit();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="eventArgs"></param>
            internal static MoveToWorldEventArgs InvokeMoveToWorld( Point3D newLocation, BaseMap newMap, WorldEntity entity )
            {
                EventHandler<MoveToWorldEventArgs> tempMoveToWorld = m_MoveToWorld;
                if ( tempMoveToWorld != null )
                {
                    MoveToWorldEventArgs moveToWorldEventArgs = new MoveToWorldEventArgs( newLocation, newMap, entity );
                    if ( moveToWorldEventArgs == null )
                        return null;

                    tempMoveToWorld( entity, moveToWorldEventArgs );

                    return moveToWorldEventArgs;
                }

                return null;
            }

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public static class OneServer
        {
            #region zh-CHS Crashed 共有静态事件 | en Public Static Event

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private static EventHandler<CrashedEventArgs> m_Crashed;
            /// <summary>
            /// 
            /// </summary>
            private static SpinLock m_LockCrashed = new SpinLock();
            #endregion
            /// <summary>
            /// World可处理的时间片
            /// </summary>
            public static event EventHandler<CrashedEventArgs> Crashed
            {
                add
                {
                    m_LockCrashed.Enter();
                    {
                        m_Crashed += value;
                    }
                    m_LockCrashed.Exit();
                }
                remove
                {
                    m_LockCrashed.Enter();
                    {
                        m_Crashed -= value;
                    }
                    m_LockCrashed.Exit();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="eventArgs"></param>
            internal static void InvokeCrashed( Exception exception )
            {
                EventHandler<CrashedEventArgs> tempCrashed = m_Crashed;
                if ( tempCrashed != null )
                {
                    CrashedEventArgs crashedEventArgs = new CrashedEventArgs( exception );
                    if ( crashedEventArgs == null )
                        return;

                    tempCrashed( null, crashedEventArgs );
                }
            }

            #endregion

            #region zh-CHS Shutdown 共有静态事件 | en Public Static Event

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private static EventHandler<ShutdownEventArgs> m_Shutdown;
            /// <summary>
            /// 
            /// </summary>
            private static SpinLock m_LockShutdown = new SpinLock();
            #endregion
            /// <summary>
            /// World可处理的时间片
            /// </summary>
            public static event EventHandler<ShutdownEventArgs> Shutdown
            {
                add
                {
                    m_LockShutdown.Enter();
                    {
                        m_Shutdown += value;
                    }
                    m_LockShutdown.Exit();
                }
                remove
                {
                    m_LockShutdown.Enter();
                    {
                        m_Shutdown -= value;
                    }
                    m_LockShutdown.Exit();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="eventArgs"></param>
            internal static void InvokeShutdown()
            {
                EventHandler<ShutdownEventArgs> tempShutdown = m_Shutdown;
                if ( tempShutdown != null )
                {
                    ShutdownEventArgs shutdownEventArgs = new ShutdownEventArgs();
                    if ( shutdownEventArgs == null )
                        return;

                    tempShutdown( null, shutdownEventArgs );
                }
            }

            #endregion
        }


        /// <summary>
        /// 
        /// </summary>
        public static event SocketConnectEventHandler SocketConnect;
        /// <summary>
        /// 
        /// </summary>
        public static event AggressiveActionEventHandler AggressiveAction;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        public static void InvokeAggressiveAction( AggressiveActionEventArgs eventArgs )
        {
            if ( AggressiveAction != null )
                AggressiveAction( eventArgs );
        }

        /// <summary>
        /// 新的客户连接上来时回调
        /// </summary>
        /// <param name="eventArgs"></param>
        public static void InvokeSocketConnect( SocketConnectEventArgs eventArgs )
        {
            if ( SocketConnect != null )
                SocketConnect( eventArgs );
        }
    }
}
#endregion