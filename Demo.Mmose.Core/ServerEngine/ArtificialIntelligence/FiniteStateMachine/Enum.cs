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

namespace Demo.Mmose.Core.AIEngine.FiniteStateMachine
{
    #region zh-CHS 枚举 | en Enum
    /// <summary>
    /// 
    /// </summary>
    public enum StateType
    {
        /// <summary>
        /// none
        /// </summary>
        NONE = 0,
        /// <summary>
        /// This type of StateEvent indicates a state is about to be entered.
        /// </summary>
        ENTER_START = 1,
        /// <summary>
        /// This type of StateEvent indicates a state is done being entered.
        /// </summary>
        ENTER_END = 2,
        /// <summary>
        /// This type of StateEvent indicates a state is about to be exited.
        /// </summary>
        EXIT_START = 3,
        /// <summary>
        /// This type of StateEvent indicates a state is done exiting.
        /// </summary>
        EXIT_END = 4,
        /// <summary>
        /// 
        /// </summary>
        EXECUTE_START = 5,
        /// <summary>
        /// 
        /// </summary>
        EXECUTE_END = 6
    }
    #endregion
}
#endregion