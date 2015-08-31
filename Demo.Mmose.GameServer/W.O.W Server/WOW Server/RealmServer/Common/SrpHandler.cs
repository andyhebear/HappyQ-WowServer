#region zh-CHS 版权所有 (C) 2006 - 2007 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2007 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2007 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using Demo.Mmose.Core.Common.Srp;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Collections;
#endregion

namespace Demo.Wow.RealmServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    internal class SrpHandler
    {
        #region zh-CHS 共有静态方法 | en Public Static Methods
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static SafeDictionary<string, SecureRemotePassword> s_SRPs = new SafeDictionary<string, SecureRemotePassword>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public static void AddSRP( string strAccountName, SecureRemotePassword srp )
        {
            s_SRPs.Add( strAccountName, srp );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public static void RemoveSRP( string strAccountName )
        {
            s_SRPs.Remove( strAccountName );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public static SecureRemotePassword GetSRP( string strAccountName )
        {
            return s_SRPs.GetValue( strAccountName );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SecureRemotePassword[] SRPsToArray()
        {
            return s_SRPs.ToArrayValues();
        }
        #endregion
    }
}
#endregion