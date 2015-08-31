using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// RealmList OpCode Server
    /// </summary>
    internal enum AuthOpCode : uint
    {
        SMSG_AUTH_CHALLENGE = 0x00,           // Server
        CMSG_AUTH_CHALLENGE_RESULT = 0x00,    // Client

        SMSG_AUTH_PROOF = 0x01,               // Server
        CMSG_AUTH_PROOF_RESULT = 0x01,        // Client

        SMSG_AUTH_RECONNECT_CHALLENGE = 0x02, // Server
        SMSG_AUTH_RECONNECT_PROOF = 0x03,     // Server

        //Update Srv =4
        SMSG_REALM_LIST = 0x10,               // Server
        CMSG_REALM_LIST_RESULT = 0x10,        // Client

        SMSG_XFER_INITIATE = 0x30,
        SMSG_XFER_DATA = 0x31,
        SMSG_XFER_ACCEPT = 0x32,
        SMSG_XFER_RESUME = 0x33,
        SMSG_XFER_CANCEL = 0x34

        //AUTH_NO_CMD = 0xFF,
    }

    /// <summary>
    /// Realm Auth Proof Error Codes
    /// </summary>
    internal enum LogineErrorInfo : byte
    {
        LOGIN_SUCCESS = 0x00,              // Successfully logged in.
        LOGIN_IPBAN = 0x01,                // 2bd -- unable to connect (some internal problem) //LOGIN_FAILED = 0x01, // 2, B, C, D // "Unable to connect"
        LOGIN_ACCOUNT_CLOSED = 0x03,       // "This account has been closed and is no longer in service -- Please check the registered email address of this account for further information.";
        LOGIN_NO_ACCOUNT = 0x04,           // (5)The information you have entered is not valid.  Please check the spelling of the account name and password.  If you need help in retrieving a lost or stolen password and account
        LOGIN_ACCOUNT_IN_USE = 0x06,       // This account is already logged in.  Please check the spelling and try again.
        LOGIN_PREORDER_TIME_LIMIT = 0x07,  // "You have used up your prepaid time for this account. Please purchase more to continue playing";
        LOGIN_SERVER_FULL = 0x08,          // Could not log in at this time.  Please try again later.
        LOGIN_WRONG_BUILD_NUMBER = 0x09,   // Unable to validate game version.  This may be caused by file corruption or the interference of another program.
        LOGIN_UPDATE_CLIENT = 0x0A,        // not official name
        LOGIN_ACCOUNT_FREEZED = 0x0C,
        LOGIN_PARENTALCONTROL = 0x0F       // "17"="LOGIN_PARENTALCONTROL" // "Access to this account has been blocked by parental controls.  Your settings may be changed in your account preferences at http://www.worldofwarcraft.com.";
    }

    /// <summary>
    /// 
    /// </summary>
    internal enum CLIENT_VERSIONS
    {
        CLIENT_MIN = CLIENT_2_2_3,

        CLIENT_2_0_3 = 6299,
        CLIENT_2_0_5 = 6320,
        CLIENT_2_0_6 = 6337,
        CLIENT_2_0_7 = 6383,
        CLIENT_2_0_9 = 6438,
        CLIENT_2_1_1 = 6739,
        CLIENT_2_1_2 = 6803,
        CLIENT_2_1_3 = 6898,
        CLIENT_2_2_0 = 7272,
        CLIENT_2_2_2 = 7318,
        CLIENT_2_2_3 = 7359,
        CLIENT_2_3_0 = 7561,

        CLIENT_MAX = CLIENT_2_3_0,
    }
}
