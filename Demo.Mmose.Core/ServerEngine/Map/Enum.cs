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

namespace Demo.Mmose.Core.Map
{
    #region zh-CHS 枚举 | en Enum
    /// <summary>
    /// 地图空间节点状态
    /// </summary>
    public enum SpaceNodeState
    {
        /// <summary>
        /// 地图空间节点内有玩家
        /// </summary>
        Activate = 0x01,
        /// <summary>
        /// 地图空间结点没有玩家
        /// </summary>
        Deactivate = 0x02,
    }
    #endregion
}
#endregion