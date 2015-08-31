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
using Demo.Mmose.Core.Common;
using Demo.Wow.Common;
using Demo.Mmose.Core.Common.Collections;
#endregion

namespace Demo.Wow.RealmServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    internal class RealmHandler
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static ExclusiveSerial s_ExclusiveSerial = new ExclusiveSerial();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static ExclusiveSerial RealmsExclusiveSerial
        {
            get { return s_ExclusiveSerial; }
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static SafeDictionary<long, Realm> s_Realms = new SafeDictionary<long, Realm>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public static void AddRealm( Serial serial, Realm realm )
        {
            s_Realms.Add( serial, realm );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public static void RemoveRealm( Serial serial )
        {
            s_Realms.Remove( serial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Realm[] RealmsToArray()
        {
            return s_Realms.ToArrayValues();
        }
        #endregion
    }
}
#endregion