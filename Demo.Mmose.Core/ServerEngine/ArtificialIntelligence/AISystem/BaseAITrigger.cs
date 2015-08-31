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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server;
#endregion

namespace Demo.Mmose.Core.AIEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseAITrigger
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// ��ʼ��ʱ��Ƭ
        /// </summary>
        /// <param name="delayTimeSpan">�ӳٵ�ʱ��</param>
        public BaseAITrigger( long iAIEventType )
            : this( iAIEventType, AIProcessPriority.Normal, TimeSpan.Zero )
        {
        }

        /// <summary>
        /// ��ʼ��ʱ��Ƭ
        /// </summary>
        /// <param name="delayTimeSpan">�ӳٵ�ʱ��</param>
        public BaseAITrigger( long iAIEventType, AIProcessPriority processPriority )
            : this( iAIEventType, processPriority, TimeSpan.Zero )
        {
        }

        /// <summary>
        /// ��ʼ��ʱ��Ƭ
        /// </summary>
        /// <param name="delayTimeSpan">�ӳٵ�ʱ��</param>
        public BaseAITrigger( long iAIEventType, TimeSpan expirationTimeSpan )
            : this( iAIEventType, AIProcessPriority.Normal, expirationTimeSpan )
        {
        }

        /// <summary>
        /// ��ʼ��ʱ��Ƭ
        /// </summary>
        /// <param name="delayTimeSpan">�ӳٵ�ʱ��</param>
        /// <param name="intervalTimeSpan">�����ʱ��</param>
        /// <param name="iCount">���õĴ���</param>
        public BaseAITrigger( long iAIEventType, AIProcessPriority processPriority, TimeSpan expirationTimeSpan )
        {
            m_iAITriggerType = iAIEventType;
            m_ProcessPriority = processPriority;
            m_ExpirationTimeSpan = expirationTimeSpan;

            if ( m_ExpirationTimeSpan == TimeSpan.Zero )
                m_ExpirationDateTime = DateTime.MaxValue; // �������,���ʾΪ���ô������ź�
            else
                m_ExpirationDateTime = DateTime.Now + expirationTimeSpan;

            if ( DefRegCreation == true )
                RegCreation();
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �����˹����ܵ��¼�����
        /// </summary>
        private long m_iAITriggerType;
        #endregion
        /// <summary>
        /// �����˹����ܵ��¼�����
        /// </summary>
        public long AITriggerType
        {
            get { return m_iAITriggerType; }
            set { m_iAITriggerType = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �����������ȼ�
        /// </summary>
        private AIProcessPriority m_ProcessPriority;
        #endregion
        /// <summary>
        /// �����������ȼ�
        /// </summary>
        public AIProcessPriority ProcessPriority
        {
            get { return m_ProcessPriority; }
            set { m_ProcessPriority = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ������������ʱ����
        /// </summary>
        private TimeSpan m_ExpirationTimeSpan;
        #endregion
        /// <summary>
        /// ������������ʱ����
        /// </summary>
        public TimeSpan ExpirationTimeSpan
        {
            get { return m_ExpirationTimeSpan; }
            set { m_ExpirationTimeSpan = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ������������ʱ��
        /// </summary>
        private DateTime m_ExpirationDateTime;
        #endregion
        /// <summary>
        /// ������������ʱ��
        /// </summary>
        public DateTime ExpirationDateTime
        {
            get { return m_ExpirationDateTime; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// Ψһ�����
        /// </summary>
        private Serial m_Serial = Serial.Zero;
        #endregion
        /// <summary>
        /// Ψһ�����
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ��������չ����
        /// </summary>
        private object m_ExtendData = null;
        #endregion
        /// <summary>
        /// ��������չ����
        /// </summary>
        public object ExtendData
        {
            get { return m_ExtendData; }
            set { m_ExtendData = value; }
        }

        /// <summary>
        /// �����Ƿ���Ҫ���㴴�����õĴ���
        /// </summary>
        protected virtual bool DefRegCreation
        {
            get { return true; }
        }
        #endregion

        #region zh-CHS �ڲ����� | en Internal Properties
        /// <summary>
        /// �ڲ�ʹ�õ����
        /// </summary>
        internal Serial InternalSerial
        {
            get { return m_Serial; }
            set { m_Serial = value; }
        }
        #endregion

        /// <summary>
        /// ���ĳ��ʱ��Ƭ���ʹ���������
        /// </summary>
        protected void RegCreation()
        {
            AIProfile l_AIProfile = GetProfile();

            if ( l_AIProfile != null )
                l_AIProfile.RegCreation(); // ���ĳ��AI���������͵Ĵ�������
        }

        /// <summary>
        /// ����ĳ��ʱ��Ƭ�Ĵ�����Ϣ
        /// </summary>
        /// <returns></returns>
        public AIProfile GetProfile()
        {
            if ( OneServer.Profiling == false )
                return null;

            string l_strName = ToString();

            if ( l_strName == null )
                l_strName = "null";

            AIProfile l_AIProfile = null;
            //s_Profiles.TryGetValue( l_strName, out l_timerProfile );

            //if ( l_timerProfile == null )
            //    s_Profiles[l_strName] = l_timerProfile = new AIProfile();

            return l_AIProfile;
        }

        /// <summary>
        /// ����ʱ��Ƭ�Ķ����ַ���
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetType().FullName;
        }

        #region zh-CHS ��̬���� | en Static Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// TimerProfile������Ϣ����,��������Ϊ�ؼ��ֹ���8��
        /// </summary>
        private static Dictionary<string, AIProfile> s_Profiles = new Dictionary<string, AIProfile>();
        #endregion
        /// <summary>
        /// ʱ��Ƭ�Ĵ�����Ϣ����,��������Ϊ�ؼ��ֹ���8��
        /// </summary>
        internal static Dictionary<string, AIProfile> Profiles
        {
            get { return s_Profiles; }
        }
        #endregion
    }
}
#endregion