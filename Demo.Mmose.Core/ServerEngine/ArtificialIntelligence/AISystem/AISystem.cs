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
using Demo.Mmose.Core.Collections;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.AIEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class AISystem
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Slice()
        {
        }

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_Serial = Serial.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
        }
        #endregion

        #region zh-CHS 内部属性 | en Internal Properties
        /// <summary>
        /// 
        /// </summary>
        internal Serial InternalSerial
        {
            get { return m_Serial; }
            set { m_Serial = value; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS AITrigger 方法 | en Public AITrigger Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// AI系统(触发器类型)的集合
        /// </summary>
        private MultiDictionary<long, BaseAITrigger> m_AITrigger = new MultiDictionary<long, BaseAITrigger>( false );
        /// <summary>
        /// AI系统(触发器类型)的集合锁
        /// </summary>
        private object m_LockAITrigger = new object();
        /// <summary>
        /// 
        /// </summary>
        private ExclusiveSerial m_AITriggerExclusiveSerial = new ExclusiveSerial();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTriggerType"></param>
        /// <param name="processPriority"></param>
        /// <returns></returns>
        public Serial RegisterAITrigger( BaseAITrigger aiTrigger )
        {
            aiTrigger.InternalSerial = m_AITriggerExclusiveSerial.GetExclusiveSerial();

            Monitor.Enter( m_LockAITrigger );
            {
                m_AITrigger.Add( aiTrigger.AITriggerType, aiTrigger );
            }
            Monitor.Exit( m_LockAITrigger );

            return aiTrigger.Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTriggerType"></param>
        /// <param name="processPriority"></param>
        /// <returns></returns>
        public BaseAITrigger RegisterAITrigger( long iAIEventType )
        {
            BaseAITrigger l_newBaseAITrigger = new BaseAITrigger( iAIEventType );
            l_newBaseAITrigger.InternalSerial = m_AITriggerExclusiveSerial.GetExclusiveSerial();

            Monitor.Enter( m_LockAITrigger );
            {
                m_AITrigger.Add( l_newBaseAITrigger.AITriggerType, l_newBaseAITrigger );
            }
            Monitor.Exit( m_LockAITrigger );

            return l_newBaseAITrigger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTriggerType"></param>
        /// <param name="processPriority"></param>
        /// <returns></returns>
        public BaseAITrigger RegisterAITrigger( long iAIEventType, AIProcessPriority processPriority )
        {
            BaseAITrigger l_newBaseAITrigger = new BaseAITrigger( iAIEventType, processPriority );
            l_newBaseAITrigger.InternalSerial = m_AITriggerExclusiveSerial.GetExclusiveSerial();

            Monitor.Enter( m_LockAITrigger );
            {
                m_AITrigger.Add( l_newBaseAITrigger.AITriggerType, l_newBaseAITrigger );
            }
            Monitor.Exit( m_LockAITrigger );

            return l_newBaseAITrigger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTriggerType"></param>
        /// <param name="processPriority"></param>
        /// <returns></returns>
        public BaseAITrigger RegisterAITrigger( long iAIEventType, TimeSpan expirationTimeSpan )
        {
            BaseAITrigger l_newBaseAITrigger = new BaseAITrigger( iAIEventType, expirationTimeSpan );
            l_newBaseAITrigger.InternalSerial = m_AITriggerExclusiveSerial.GetExclusiveSerial();

            Monitor.Enter( m_LockAITrigger );
            {
                m_AITrigger.Add( l_newBaseAITrigger.AITriggerType, l_newBaseAITrigger );
            }
            Monitor.Exit( m_LockAITrigger );

            return l_newBaseAITrigger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTriggerType"></param>
        /// <param name="processPriority"></param>
        /// <returns></returns>
        public BaseAITrigger RegisterAITrigger( long iAIEventType, AIProcessPriority processPriority, TimeSpan expirationTimeSpan )
        {
            BaseAITrigger l_newBaseAITrigger = new BaseAITrigger( iAIEventType, processPriority, expirationTimeSpan );
            l_newBaseAITrigger.InternalSerial = m_AITriggerExclusiveSerial.GetExclusiveSerial();

            Monitor.Enter( m_LockAITrigger );
            {
                m_AITrigger.Add( l_newBaseAITrigger.AITriggerType, l_newBaseAITrigger );
            }
            Monitor.Exit( m_LockAITrigger );

            return l_newBaseAITrigger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nTriggerID"></param>
        public bool RemoveAITrigger( BaseAITrigger aiTrigger )
        {
            bool l_bReturn = false;

            Monitor.Enter( m_LockAITrigger );
            {
                l_bReturn = m_AITrigger.Remove( aiTrigger.AITriggerType, aiTrigger );
            }
            Monitor.Exit( m_LockAITrigger );

            return l_bReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nTriggerID"></param>
        public ICollection<BaseAITrigger> GetAITriggerInfo( long iAIEventType )
        {
            ICollection<BaseAITrigger> l_AITriggerInfo = null;

            Monitor.Enter( m_LockAIEvent );
            {
                l_AITriggerInfo = m_AITrigger[iAIEventType];
            }
            Monitor.Exit( m_LockAIEvent );

            return l_AITriggerInfo;
        }
        #endregion

        #region zh-CHS BaseAIEvent方法 | en Public BaseAIEvent Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// AI系统(接受触发器事件类型)的集合
        /// </summary>
        private MultiDictionary<long, BaseAIEvent> m_AIEvent = new MultiDictionary<long, BaseAIEvent>( false );
        /// <summary>
        /// AI系统(接受触发器事件类型)的集合锁
        /// </summary>
        private object m_LockAIEvent = new object();
        /// <summary>
        /// 
        /// </summary>
        private ExclusiveSerial m_AIEventExclusiveSerial = new ExclusiveSerial();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTriggerType"></param>
        /// <param name="processPriority"></param>
        /// <returns></returns>
        public Serial RegisterAIEvent( BaseAIEvent aiEventInfo )
        {
            aiEventInfo.InternalSerial = m_AIEventExclusiveSerial.GetExclusiveSerial();
            
            Monitor.Enter( m_LockAIEvent );
            {
                m_AIEvent.Add( aiEventInfo.AIEventType, aiEventInfo );
            }
            Monitor.Exit( m_LockAIEvent );

            return aiEventInfo.Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iTriggerType"></param>
        /// <param name="processPriority"></param>
        /// <returns></returns>
        public BaseAIEvent RegisterAIEvent( long iAIEventType )
        {
            BaseAIEvent l_newBaseAIEvent = new BaseAIEvent( iAIEventType );
            l_newBaseAIEvent.InternalSerial = m_AIEventExclusiveSerial.GetExclusiveSerial();

            Monitor.Enter( m_LockAIEvent );
            {
                m_AIEvent.Add( l_newBaseAIEvent.AIEventType, l_newBaseAIEvent );
            }
            Monitor.Exit( m_LockAIEvent );

            return l_newBaseAIEvent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nTriggerID"></param>
        public void RemoveAIEvent( BaseAIEvent aiEventInfo )
        {
            Monitor.Enter( m_LockAIEvent );
            {
                m_AIEvent.Remove( aiEventInfo.AIEventType, aiEventInfo );
            }
            Monitor.Exit( m_LockAIEvent );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nTriggerID"></param>
        public ICollection<BaseAIEvent> GetAIEventInfo( long iAIEventType )
        {
            ICollection<BaseAIEvent> l_AIEventInfo = null;

            Monitor.Enter( m_LockAIEvent );
            {
                l_AIEventInfo = m_AIEvent[iAIEventType];
            }
            Monitor.Exit( m_LockAIEvent );

            return l_AIEventInfo;
        }
        #endregion

        #endregion

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        internal void Update()
        {
            //CAgent* pAgent	= NULL;
            //float fDistance	= 0.f;

            //TriggerRecordStruct* pRecord;
            //TRIGGER_MAP::iterator it;

            //unsigned long nCurTime = timeGetTime();

            ////
            //// Delete expired trigger records.
            //// Records with expiration time 0 never expire.
            ////
            //// For records that are not expired, update position
            //// if the dynamic flag is set.
            ////
            //it = m_mapTriggerMap.begin();
            //while( it != m_mapTriggerMap.end() )
            //{
            //    pRecord = it->second;
            //    if( (pRecord->nExpirationTime != 0) && (pRecord->nExpirationTime < nCurTime) )
            //    {
            //        delete(pRecord);
            //        it = m_mapTriggerMap.erase(it);
            //    }
            //    else {
            //        // Update position if dynamic flag is set.
            //        // Reset time-stamp.
            //        if(pRecord->bDynamicSourcePos == true)
            //        {
            //            pRecord->vPos = g_pAgentList[pRecord->idSource]->GetPosition();
            //            pRecord->nTimeStamp = nCurTime;
            //        }

            //        ++it;
            //    }		
            //}


            ////
            //// Trigger Agents.
            ////

            //// Make sure triggers are not getting removed while in this loop.
            //m_bTriggerCriticalSection = true;

            //// Loop thru agents.
            //for(unsigned long iAgent=0; iAgent < g_nNumAgents; ++iAgent)
            //{
            //    pAgent = g_pAgentList[iAgent];

            //    // Check if it's time for this Agent to update.
            //    if( (pAgent->GetTriggerUpdateRate() > 0.f) && (nCurTime > pAgent->GetNextTriggerUpdate()) )
            //    {
            //        pAgent->SetNextTriggerUpdate(nCurTime + (unsigned long)(pAgent->GetTriggerUpdateRate() * 1000.f));

            //        // Loop through existing trigger records.
            //        for(it = m_mapTriggerMap.begin(); it != m_mapTriggerMap.end(); ++it)
            //        {
            //            pRecord = it->second;

            //            // Check if this Agent responds to this trigger.
            //            if( !(pRecord->eTriggerType & pAgent->GetTriggerFlags()) )
            //                continue;

            //            // Check that trigger source is not the Agent itself.
            //            if( pRecord->idSource == iAgent)
            //                continue;

            //            // Check radius.
            //            fDistance = DIST(pRecord->vPos, pAgent->GetPosition());
            //            if(fDistance > (pAgent->GetTriggerDistance() + pRecord->fRadius) )
            //                continue;

            //            // HandleTrigger returns true if the Agent responded to the trigger.
            //            if( pAgent->HandleTrigger(pRecord) )
            //            {
            //                // Only pay attention to the highest priority 
            //                // trigger at any one instant.
            //                break;
            //            }
            //        }
            //    }
            //}

            //m_bTriggerCriticalSection = false;
        }
        #endregion
    }
}
#endregion