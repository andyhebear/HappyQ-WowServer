using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Common.Collections;

namespace Demo.Wow.WorldServer.Network
{
    internal class PendingLogins
    {
        #region zh-CHS 共有静态方法 | en Public Static Methods
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static SafeDictionary<long, NetState> s_PendingLogins = new SafeDictionary<long, NetState>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="realm"></param>
        public static void AddAuthenticate( long serial, NetState authenticateNetState )
        {
            s_PendingLogins.Add( serial, authenticateNetState );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public static void RemoveAuthenticate( long serial )
        {
            s_PendingLogins.Remove( serial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public static NetState GetAuthenticate( long serial )
        {
            return s_PendingLogins.GetValue( serial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static NetState[] ToArray()
        {
            return s_PendingLogins.ToArrayValues();
        }
        #endregion

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
        public static ExclusiveSerial ExclusiveSerial
        {
            get { return s_ExclusiveSerial; }
        }

        #endregion
    }
}
