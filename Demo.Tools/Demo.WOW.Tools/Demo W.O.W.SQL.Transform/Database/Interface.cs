#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2006 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
#endregion

namespace Demo_W.O.W.Database
{
    #region zh-CHS 接口 | en Interface
    /// <summary>
    /// 用于数据库的IDumpable接口
    /// </summary>
    internal interface IDumpable
    {
        #region zh-CHS 接口 | en Interface
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        void Dump( TextWriter output );
        #endregion
    }
    #endregion
}
#endregion