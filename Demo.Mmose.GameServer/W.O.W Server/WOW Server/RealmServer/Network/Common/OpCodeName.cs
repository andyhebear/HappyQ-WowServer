using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.RealmServer.Network.Common
{
    /// <summary>
    /// 
    /// </summary>
    internal class RealmOpCodeName
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<long, string> s_RealmOpCodeName = new Dictionary<long, string>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iOpCode"></param>
        public static string GetRealmOpCodeName( long iOpCode )
        {
            string strWordOpCodeName = string.Empty;

            if ( s_RealmOpCodeName.TryGetValue( iOpCode, out strWordOpCodeName ) == true )
                return strWordOpCodeName;
            else
                return "Unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitRealmOpCodeName()
        {
            s_RealmOpCodeName.Add( 1, "SMSG_REGISTER_REALM" );
            s_RealmOpCodeName.Add( 2, "CMSG_REGISTER_REALM_RESULT" );
            s_RealmOpCodeName.Add( 3, "SMSG_REQUEST_SESSION" );
            s_RealmOpCodeName.Add( 4, "CMSG_REQUEST_SESSION_RESULT" );
            s_RealmOpCodeName.Add( 5, "SMSG_PING" );
            s_RealmOpCodeName.Add( 6, "CMSG_PONG" );
            s_RealmOpCodeName.Add( 7, "SMSG_SQL_EXECUTE" );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class AuthOpCodeName
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<long, string> s_AuthOpCodeName = new Dictionary<long, string>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iOpCode"></param>
        public static string GetAuthOpCodeName( long iOpCode )
        {
            string strWordOpCodeName = string.Empty;

            if ( s_AuthOpCodeName.TryGetValue( iOpCode, out strWordOpCodeName ) == true )
                return strWordOpCodeName;
            else
                return "Unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitAuthOpCodeName()
        {
            s_AuthOpCodeName.Add( 0x00, "SMSG_AUTH_CHALLENGE" );
            s_AuthOpCodeName.Add( 0x01, "SMSG_AUTH_PROOF" );
            s_AuthOpCodeName.Add( 0x02, "SMSG_AUTH_RECONNECT_CHALLENGE" );
            s_AuthOpCodeName.Add( 0x03, "SMSG_AUTH_RECONNECT_PROOF" );
            s_AuthOpCodeName.Add( 0x10, "SMSG_REALM_LIST" );
            s_AuthOpCodeName.Add( 0x30, "SMSG_XFER_INITIATE" );
            s_AuthOpCodeName.Add( 0x31, "SMSG_XFER_DATA" );
            s_AuthOpCodeName.Add( 0x32, "SMSG_XFER_ACCEPT" );
            s_AuthOpCodeName.Add( 0x33, "SMSG_XFER_RESUME" );
            s_AuthOpCodeName.Add( 0x34, "SMSG_XFER_CANCEL" );
        }
    }
}
