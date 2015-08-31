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
using System.Diagnostics;
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Ability.Skill
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseSkillHandler<T> where T : BaseSkill
    {
        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 给出脚本里面的可运动物体的数量(NPCs、Monster)
        /// </summary>
        public int Count
        {
            get { return m_Skills.Count; }
        }
        #endregion

        #region zh-CHS SkillHandler方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_Skills = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseTaxiNode"></param>
        public bool AddSkill( long lSkillSerial, T skillT )
        {
            if ( skillT == null )
            {
                Debug.WriteLine( "BaseSkillHandler.AddSkill(...) - skillT == null error!" );
                return false;
            }

            EventHandler<BeforeAddSkillCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeAddSkillCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddSkillCallEventArgs<T> eventArgs = new BeforeAddSkillCallEventArgs<T>( skillT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Skills.Add( lSkillSerial, skillT );

            EventHandler<AfterAddSkillCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterAddSkillCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddSkillCallEventArgs<T> eventArgs = new AfterAddSkillCallEventArgs<T>( skillT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RemoveSkill( long lSkillSerial )
        {
            T skillT = FindSkillOnSerial( lSkillSerial );
            if ( skillT == null )
                return false;

            EventHandler<BeforeRemoveSkillCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveSkillCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveSkillCallEventArgs<T> eventArgs = new BeforeRemoveSkillCallEventArgs<T>( skillT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Skills.Remove( lSkillSerial );

            EventHandler<AfterRemoveSkillCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterRemoveSkillCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveSkillCallEventArgs<T> eventArgs = new AfterRemoveSkillCallEventArgs<T>( skillT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T FindSkillOnSerial( long lSkillSerial )
        {
            return m_Skills.GetValue( lSkillSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(Skill)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_Skills.ToArrayValues();
        }

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddSkillCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddSkillCallEventArgs<T>> m_ThreadEventBeforeAddSkillCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddSkillCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddSkillCallEventArgs<T>> ThreadBeforeAddSkillCall
        {
            add
            {
                m_LockThreadEventBeforeAddSkillCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddSkillCall += value;
                }
                m_LockThreadEventBeforeAddSkillCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddSkillCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddSkillCall -= value;
                }
                m_LockThreadEventBeforeAddSkillCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddSkillCallEventArgs<T>> m_ThreadEventAfterAddSkillCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterAddSkillCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddSkillCallEventArgs<T>> ThreadAfterAddSkillCall
        {
            add
            {
                m_LockThreadEventAfterAddSkillCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddSkillCall += value;
                }
                m_LockThreadEventAfterAddSkillCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterAddSkillCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddSkillCall -= value;
                }
                m_LockThreadEventAfterAddSkillCall.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS RemoveSkillCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveSkillCallEventArgs<T>> m_ThreadEventBeforeRemoveSkillCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeRemoveSkillCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveSkillCallEventArgs<T>> ThreadBeforeRemoveSkillCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveSkillCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveSkillCall += value;
                }
                m_LockThreadEventBeforeRemoveSkillCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveSkillCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveSkillCall -= value;
                }
                m_LockThreadEventBeforeRemoveSkillCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveSkillCallEventArgs<T>> m_ThreadEventAfterRemoveSkillCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterRemoveSkillCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveSkillCallEventArgs<T>> ThreadAfterRemoveSkillCall
        {
            add
            {
                m_LockThreadEventAfterRemoveSkillCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveSkillCall += value;
                }
                m_LockThreadEventAfterRemoveSkillCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterRemoveSkillCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveSkillCall -= value;
                }
                m_LockThreadEventAfterRemoveSkillCall.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion