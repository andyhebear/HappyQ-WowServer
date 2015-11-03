#region zh-CHS 2010 - 2010 DemoSoft �Ŷ� | en 2010-2010 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOCE(Massively Multiplayer Online Client Engine) for .NET.
//
//                              2010-2010 DemoSoft Team
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


namespace DogSE.Client.Core.Timer
{
    #region zh-CHS ί�� | en Delegate
    /// <summary>
    /// ʱ��Ƭ��ί��
    /// </summary>
    public delegate void TimeSliceCallback();

    /// <summary>
    /// ����ָ�����ж����ʱ��Ƭ��ί��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tState"></param>
    public delegate void TimeSliceStateCallback<T>( T tState );


    /// <summary>
    /// Aura���¼�������
    /// </summary>
    public class StopTimeSliceEventArgs : EventArgs
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="timeSlice"></param>
        public StopTimeSliceEventArgs( TimeSlice timeSlice )
        {
            m_TimeSlice = timeSlice;
        }
        #endregion

        #region zh-CHS �������� | en Public Properties

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private TimeSlice m_TimeSlice;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public TimeSlice TimeSlice
        {
            get { return m_TimeSlice; }
        }

        #endregion
    }
    #endregion
}
#endregion