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

#endregion

namespace Demo.Mmose.Core.Timer
{
    #region zh-CHS ö�� | en Enum
    /// <summary>
    /// ʱ��Ƭ���ȼ���ö�ٶ���
    /// </summary>
    public enum TimerFrequency
    {
        /// <summary>
        /// ʵʱ��ʱ��Ƭ
        /// </summary>
        EveryTick,
        /// <summary>
        /// 10�����ʱ��Ƭ
        /// </summary>
        TenMS,
        /// <summary>
        /// 25�����ʱ��Ƭ
        /// </summary>
        TwentyFiveMS,
        /// <summary>
        /// 50�����ʱ��Ƭ
        /// </summary>
        FiftyMS,
        /// <summary>
        /// 250�����ʱ��Ƭ
        /// </summary>
        TwoFiftyMS,
        /// <summary>
        /// 1���ʱ��Ƭ
        /// </summary>
        OneSecond,
        /// <summary>
        /// 5���ʱ��Ƭ
        /// </summary>
        FiveSeconds,
        /// <summary>
        /// 1���ӵ�ʱ��Ƭ
        /// </summary>
        OneMinute
    }

    /// <summary>
    /// ָ�� TimeSlice �ĵ������ȼ���
    /// </summary>
    public enum TimerPriority
    {
        /// <summary>
        /// ���Խ� TimeSlice �����ھ����κ��������ȼ����߳�֮��
        /// </summary>
        Lowest = 0,
        /// <summary>
        /// ���Խ� TimeSlice �����ھ��� Normal ���ȼ����߳�֮���ھ��� Lowest ���ȼ����߳�֮ǰ��
        /// </summary>
        BelowNormal = 1,
        /// <summary>
        /// ���Խ� TimeSlice �����ھ��� AboveNormal ���ȼ����߳�֮���ھ��� BelowNormal ���ȼ����߳�֮ǰ��Ĭ������£��߳̾��� Normal ���ȼ���
        /// </summary>
        Normal = 2,
        /// <summary>
        /// ���Խ� TimeSlice �����ھ��� Highest ���ȼ����߳�֮���ھ��� Normal ���ȼ����߳�֮ǰ��
        /// </summary>
        AboveNormal = 3,
        /// <summary>
        /// ���Խ� TimeSlice �����ھ����κ��������ȼ����߳�֮ǰ��
        /// </summary>
        Highest = 4,
    }
    #endregion
}
#endregion