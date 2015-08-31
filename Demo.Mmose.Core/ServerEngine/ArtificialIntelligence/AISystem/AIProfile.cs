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

#endregion

namespace Demo.Mmose.Core.AIEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class AIProfile
    {
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �������õĴ���
        /// </summary>
        private int m_Created = 0;
        /// <summary>
        /// ��ʼ���õĴ���
        /// </summary>
        private int m_Started = 0;
        /// <summary>
        /// ֹͣ���õĴ���
        /// </summary>
        private int m_Stopped = 0;
        /// <summary>
        /// ���õĴ���
        /// </summary>
        private int m_Ticked = 0;
        /// <summary>
        /// �ܹ����õĴ���ʱ��
        /// </summary>
        private TimeSpan m_TotalProcTime = TimeSpan.Zero;
        /// <summary>
        /// ���õ���ߴ���ʱ��
        /// </summary>
        private TimeSpan m_PeakProcTime = TimeSpan.Zero;
        #endregion

        #region zh-CHS ���� | en Properties
        /// <summary>
        /// �������õĴ���
        /// </summary>
        public int Created
        {
            get { return m_Created; }
        }

        /// <summary>
        /// ��ʼ���õĴ���
        /// </summary>
        public int Started
        {
            get { return m_Started; }
        }

        /// <summary>
        /// ֹͣ���õĴ���
        /// </summary>
        public int Stopped
        {
            get { return m_Stopped; }
        }

        /// <summary>
        /// ���õĴ���
        /// </summary>
        public int Ticked
        {
            get { return m_Ticked; }
        }

        /// <summary>
        /// �ܹ����õĴ���ʱ��
        /// </summary>
        public TimeSpan TotalProcTime
        {
            get { return m_TotalProcTime; }
        }

        /// <summary>
        /// ���õ���ߴ���ʱ��
        /// </summary>
        public TimeSpan PeakProcTime
        {
            get { return m_PeakProcTime; }
        }

        /// <summary>
        /// ƽ�����õĴ���ʱ��
        /// </summary>
        public TimeSpan AverageProcTime
        {
            get
            {
                if ( m_Ticked == 0 )
                    return TimeSpan.Zero;

                return TimeSpan.FromTicks( m_TotalProcTime.Ticks / m_Ticked );
            }
        }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ���㴴�����õĴ���
        /// </summary>
        public void RegCreation()
        {
            ++m_Created;
        }

        /// <summary>
        /// ���㿪ʼ���õĴ���
        /// </summary>
        public void RegStart()
        {
            ++m_Started;
        }

        /// <summary>
        /// ����ֹͣ���õĴ���
        /// </summary>
        public void RegStopped()
        {
            ++m_Stopped;
        }

        /// <summary>
        /// �������еĴ���,��ߵĴ���ʱ��,�ܹ����õĴ���ʱ��
        /// </summary>
        /// <param name="procTime">��ǰ�Ĵ���ʱ��</param>
        public void RegTicked( TimeSpan procTime )
        {
            ++m_Ticked;

            m_TotalProcTime += procTime;

            if ( procTime > m_PeakProcTime )
                m_PeakProcTime = procTime;
        }
        #endregion
    }
}
#endregion
