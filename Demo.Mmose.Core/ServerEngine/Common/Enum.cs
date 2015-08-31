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

namespace Demo.Mmose.Core.Common
{
    #region zh-CHS 枚举 | en Enum
    /// <summary>
    /// 帐号的等级
    /// </summary>
    public enum AccessLevel
    {
        /// <summary>
        /// 玩家
        /// </summary>
        Player,
        /// <summary>
        /// 顾问
        /// </summary>
        Counselor,
        /// <summary>
        /// GM
        /// </summary>
        GameMaster,
        /// <summary>
        /// 
        /// </summary>
        Seer,
        /// <summary>
        /// 管理者
        /// </summary>
        Administrator,
        /// <summary>
        /// 开发者
        /// </summary>
        Developer,
        /// <summary>
        /// 拥有者
        /// </summary>
        Owner
    }
    #endregion
}
#endregion

