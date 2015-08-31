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
#endregion

namespace Demo.Wow.WorldServer.DBC
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILoad<T>
    {
        /// <summary>
        /// 
        /// </summary>
        uint ID { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbcRecord"></param>
        /// <returns></returns>
        bool Load( DBCRecord dbcRecord );
    }
}
#endregion