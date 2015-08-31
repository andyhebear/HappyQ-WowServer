using System;
using System.Text;
using System.Collections.Generic;

namespace Demo_R.O.S.E.CharServer.CharServer.Network
{
    internal enum LoginServerOpCode : ushort
    {
        CMSG_ENCRYPTION_REQUEST = 0x0000,

        SMSG_xxxx = 0x0000,
    }
}