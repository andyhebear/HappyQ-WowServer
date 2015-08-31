#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
//
// This file is a part of the G.O.S.E(Game Online Server Engine) for .NET.
//
//           2007-2008 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions outlined
// in the accompanying license agreement.
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.World;
using Demo.Wow.RealmServer.Common;
#endregion

namespace Demo.Wow.RealmServer.World
{
    /// <summary>
    /// 
    /// </summary>
    public class WowWorld : MmorpgWorld
    {
        #region zh-CHS InitOnceWorld方法 | en Static Method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        internal void InitOnceWorld( object sender, BaseWorldEventArgs eventArgs )
        {
            //////////////////////////////////////////////////////////////////////////
            // 读取全部的WowAccount帐号

            WowAccountHandler.StartLoadAccountTimeSlice();
        }

        #endregion

        #region zh-CHS WorldSlice方法 | en Static Method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void WorldSlice( object sender, BaseWorldEventArgs e )
        {
        }

        #endregion
    }
}
#endregion