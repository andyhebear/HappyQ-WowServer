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
using System.Threading;
using Demo.Mmose.Core.Common;

#endregion

namespace Demo.Mmose.Core.AIEngine
{
    /// <summary>
    /// AI系统(触发器类型)的集合的协调
    /// </summary>
    public static class AISystemManage
    {
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// AI系统(触发器类型)的集合
        /// </summary>
        private static Dictionary<long, AISystem> s_AISystem = new Dictionary<long, AISystem>( 100 );
        /// <summary>
        /// AI系统(触发器类型)的集合
        /// </summary>
        private static object s_LockAISystem = new object();
        /// <summary>
        /// 
        /// </summary>
        private static ExclusiveSerial s_ExclusiveSerial = new ExclusiveSerial();
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aiSystem"></param>
        /// <returns></returns>
        public static Serial RegisterAISystem( AISystem aiSystem )
        {
            Monitor.Enter( s_LockAISystem );
            {
                aiSystem.InternalSerial = s_ExclusiveSerial.GetExclusiveSerial();
                s_AISystem.Add( aiSystem.InternalSerial, aiSystem );
            }
            Monitor.Exit( s_LockAISystem );

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nTriggerID"></param>
        public static void RemoveAISystem( Serial iAISystemID )
        {
            Monitor.Enter( s_LockAISystem );
            {
                s_AISystem.Remove( iAISystemID );
            }
            Monitor.Exit( s_LockAISystem );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nTriggerID"></param>
        public static void RemoveAISystem( AISystem aiSystem )
        {
            RemoveAISystem( aiSystem.Serial );
        }
        #endregion
    }
}
#endregion