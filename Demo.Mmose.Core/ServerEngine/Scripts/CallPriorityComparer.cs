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
using System.Collections.Generic;
using System.Reflection;
#endregion

namespace Demo.Mmose.Core.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    public class CallPriorityComparer : IComparer<MethodInfo>
    {
        #region zh-CHS 静态方法 | en Static Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodInfoX"></param>
        /// <param name="methodInfoY"></param>
        /// <returns></returns>
        public int Compare( MethodInfo methodInfoX, MethodInfo methodInfoY )
        {
            if ( methodInfoX == null && methodInfoY == null )
                return 0;

            if ( methodInfoX == null )
                return 1;

            if ( methodInfoY == null )
                return -1;

            return GetPriority( methodInfoX ) - GetPriority( methodInfoY );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        private int GetPriority( MethodInfo methodInfo )
        {
            object[] objects = methodInfo.GetCustomAttributes( typeof( CallPriorityAttribute ), true );

            if ( objects == null )
                return 0;

            if ( objects.Length == 0 )
                return 0;

            CallPriorityAttribute attribute = objects[0] as CallPriorityAttribute;

            if ( attribute == null )
                return 0;

            return attribute.Priority;
        }
        #endregion
    }
}
#endregion

