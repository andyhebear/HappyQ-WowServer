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

namespace Demo.Mmose.Core.Entity.Suit.Ability.Spell
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseSpellHandler<T> where T : BaseSpell
    {
        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 给出脚本里面的可运动物体的数量(NPCs、Monster)
        /// </summary>
        public int Count
        {
            get { return m_Spells.Count; }
        }
        #endregion

        #region zh-CHS SpellHandler方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_Spells = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseTaxiNode"></param>
        public bool AddSpell( long lSpellSerial, T spellT )
        {
            if ( spellT == null )
            {
                Debug.WriteLine( "BaseSpellHandler.AddSpell(...) - spellT == null error!" );
                return false;
            }

            EventHandler<BeforeAddSpellCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeAddSpellCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddSpellCallEventArgs<T> eventArgs = new BeforeAddSpellCallEventArgs<T>( spellT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Spells.Add( lSpellSerial, spellT );

            EventHandler<AfterAddSpellCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterAddSpellCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddSpellCallEventArgs<T> eventArgs = new AfterAddSpellCallEventArgs<T>( spellT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T FindSpellOnSerial( long lSpellSerial )
        {
            return m_Spells.GetValue( lSpellSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RemoveSpell( long lSpellSerial )
        {
            T spellT = FindSpellOnSerial( lSpellSerial );
            if ( spellT == null )
                return false;

            EventHandler<BeforeRemoveSpellCallEventArgs<T>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveSpellCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveSpellCallEventArgs<T> eventArgs = new BeforeRemoveSpellCallEventArgs<T>( spellT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_Spells.Remove( lSpellSerial );

            EventHandler<AfterRemoveSpellCallEventArgs<T>> tempAfterEventArgs = m_ThreadEventAfterRemoveSpellCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveSpellCallEventArgs<T> eventArgs = new AfterRemoveSpellCallEventArgs<T>( spellT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(Spell)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_Spells.ToArrayValues();
        }

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddSpellCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddSpellCallEventArgs<T>> m_ThreadEventBeforeAddSpellCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeAddSpellCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddSpellCallEventArgs<T>> ThreadBeforeAddSpellCall
        {
            add
            {
                m_LockThreadEventBeforeAddSpellCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddSpellCall += value;
                }
                m_LockThreadEventBeforeAddSpellCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeAddSpellCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeAddSpellCall -= value;
                }
                m_LockThreadEventBeforeAddSpellCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddSpellCallEventArgs<T>> m_ThreadEventAfterAddSpellCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterAddSpellCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddSpellCallEventArgs<T>> ThreadAfterAddSpellCall
        {
            add
            {
                m_LockThreadEventAfterAddSpellCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddSpellCall += value;
                }
                m_LockThreadEventAfterAddSpellCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterAddSpellCall.EnterWriteLock();
                {
                    m_ThreadEventAfterAddSpellCall -= value;
                }
                m_LockThreadEventAfterAddSpellCall.ExitWriteLock();
            }
        }
        #endregion

        #region zh-CHS RemoveSpellCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveSpellCallEventArgs<T>> m_ThreadEventBeforeRemoveSpellCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventBeforeRemoveSpellCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveSpellCallEventArgs<T>> ThreadBeforeRemoveSpellCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveSpellCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveSpellCall += value;
                }
                m_LockThreadEventBeforeRemoveSpellCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveSpellCall.EnterWriteLock();
                {
                    m_ThreadEventBeforeRemoveSpellCall -= value;
                }
                m_LockThreadEventBeforeRemoveSpellCall.ExitWriteLock();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveSpellCallEventArgs<T>> m_ThreadEventAfterRemoveSpellCall;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockThreadEventAfterRemoveSpellCall = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveSpellCallEventArgs<T>> ThreadAfterRemoveSpellCall
        {
            add
            {
                m_LockThreadEventAfterRemoveSpellCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveSpellCall += value;
                }
                m_LockThreadEventAfterRemoveSpellCall.ExitWriteLock();
            }
            remove
            {
                m_LockThreadEventAfterRemoveSpellCall.EnterWriteLock();
                {
                    m_ThreadEventAfterRemoveSpellCall -= value;
                }
                m_LockThreadEventAfterRemoveSpellCall.ExitWriteLock();
            }
        }
        #endregion

        #endregion
    }
}
#endregion