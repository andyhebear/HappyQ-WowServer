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

#endregion

namespace Demo.Mmose.Core.AIEngine.Trigger
{
    #region zh-CHS 枚举 | en Enum
    /// <summary>
    /// 触发器优先级的枚举定义
    /// </summary>
    public enum TriggerFrequency
    {
        /// <summary>
        /// 实时的时间片
        /// </summary>
        EveryTick,
        /// <summary>
        /// 10毫秒的时间片
        /// </summary>
        TenMS,
        /// <summary>
        /// 25毫秒的时间片
        /// </summary>
        TwentyFiveMS,
        /// <summary>
        /// 50毫秒的时间片
        /// </summary>
        FiftyMS,
        /// <summary>
        /// 250毫秒的时间片
        /// </summary>
        TwoFiftyMS,
        /// <summary>
        /// 1秒的时间片
        /// </summary>
        OneSecond,
        /// <summary>
        /// 5秒的时间片
        /// </summary>
        FiveSeconds,
        /// <summary>
        /// 1分钟的时间片
        /// </summary>
        OneMinute
    }

    /// <summary>
    /// 指定 Trigger 的调度优先级。
    /// </summary>
    public enum TriggerPriority
    {
        /// <summary>
        /// 可以将 Trigger 安排在具有任何其他优先级的线程之后。
        /// </summary>
        Lowest = 0,
        /// <summary>
        /// 可以将 Trigger 安排在具有 Normal 优先级的线程之后，在具有 Lowest 优先级的线程之前。
        /// </summary>
        BelowNormal = 1,
        /// <summary>
        /// 可以将 Trigger 安排在具有 AboveNormal 优先级的线程之后，在具有 BelowNormal 优先级的线程之前。默认情况下，线程具有 Normal 优先级。
        /// </summary>
        Normal = 2,
        /// <summary>
        /// 可以将 Trigger 安排在具有 Highest 优先级的线程之后，在具有 Normal 优先级的线程之前。
        /// </summary>
        AboveNormal = 3,
        /// <summary>
        /// 可以将 Trigger 安排在具有任何其他优先级的线程之前。
        /// </summary>
        Highest = 4,
    }
    #endregion
}
#endregion