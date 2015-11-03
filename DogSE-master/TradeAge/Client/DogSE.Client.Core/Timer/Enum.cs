#region zh-CHS 2010 - 2010 DemoSoft �Ŷ� | en 2010-2010 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOCE(Massively Multiplayer Online Client Engine) for .NET.
//
//                              2006-2010 DemoSoft Team
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

#endregion

namespace DogSE.Client.Core.Timer
{
    /// <summary>
    /// ʱ��Ƭ���ȼ���ö�ٶ���
    /// </summary>
    public enum TimerFrequency
    {
        /// <summary>
        /// ʵʱ��ʱ��Ƭ
        /// </summary>
        EveryTick = 0,

        /// <summary>
        /// �뼶��
        /// ���뼶���У�100ms���һ��
        /// </summary>
        Second = 1,

        /// <summary>
        /// ���Ӽ���
        /// ��鰴��1sһ�Σ�����뼶�������
        /// </summary>
        Minute = 2,

        /// <summary>
        /// ���ڷ��Ӽ����
        /// �ȷ���ȴ����У�1���Ӽ��һ�Σ����������뼶��ȴ�����
        /// </summary>
        LongTime = 3,
    }

    /// <summary>
    /// ʱ��Ƭ���ִ�е�����
    /// </summary>
    public enum TimeSliceRunType
    {
        /// <summary>
        /// �ڲ��߳�
        /// </summary>
        None = 0,

        /// <summary>
        /// ҵ���߼��߳�ִ��
        /// </summary>
        LogicTask = 1,
    }
}
#endregion