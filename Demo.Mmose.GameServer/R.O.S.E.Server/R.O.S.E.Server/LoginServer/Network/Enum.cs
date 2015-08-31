using System;
using System.Text;
using System.Collections.Generic;

namespace Demo_R.O.S.E.LoginServer.Network
{
    /// <summary>
    /// World Packet Opcodes
    /// </summary>
    internal enum LoginServerOpCode : ushort
    {
        CMSG_ENCRYPTION_REQUEST         = 0x0703,
        CMSG_GET_SERVER_NAME_LIST       = 0x0704,
        CMSG_ACCOUNT_LOGIN              = 0x0708,
        CMSG_GET_SERVER_IP              = 0x070A,

        CMSG_CONNECT_FROM_CHAR_SERVER   = 0x0500,

        SMSG_xxxx = 0x0000,
    }
}
