using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// Login OpCode Client
    /// </summary>
    internal enum RealmOpCode
    {
        // Initialization of server/client connection...
        SMSG_REGISTER_REALM = 1,            // Server
        CMSG_REGISTER_REALM_RESULT = 2,     // Client

        // Upon client connect (for WS)
        SMSG_REQUEST_SESSION = 3,           // Server
        CMSG_REQUEST_SESSION_RESULT = 4,    // Client

        // Ping/Pong
        SMSG_PING = 5,                      // Server
        CMSG_PONG = 6,                      // Client

        // SQL Query Execute
        SMSG_SQL_EXECUTE = 7,               // Server
    }
}
