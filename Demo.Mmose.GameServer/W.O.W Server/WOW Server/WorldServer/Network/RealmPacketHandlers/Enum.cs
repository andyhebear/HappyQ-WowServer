using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// Login OpCode Client
    /// </summary>
    internal enum RealmOpCode
    {
        // Initialization of server/client connection...
        SMSG_REGISTER_REALM = 1,
        CMSG_REGISTER_REALM_RESULT = 2,

        // Upon client connect (for WS)
        SMSG_REQUEST_SESSION = 3,
        CMSG_REQUEST_SESSION_RESULT = 4,

        // Ping/Pong
        SMSG_PING = 5,
        CMSG_PONG = 6,

        // SQL Query Execute
        SMSG_SQL_EXECUTE = 7,
    }
}
