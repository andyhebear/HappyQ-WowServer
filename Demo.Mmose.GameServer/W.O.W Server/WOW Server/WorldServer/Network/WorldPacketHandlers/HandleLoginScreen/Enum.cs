using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponseCodes
    {
        public const byte RESPONSE_SUCCESS = 0x00;
        public const byte RESPONSE_FAILURE = 0x01;
        public const byte RESPONSE_CANCELLED = 0x02;
        public const byte RESPONSE_DISCONNECTED = 0x03;
        public const byte RESPONSE_FAILED_TO_CONNECT = 0x04;
        public const byte RESPONSE_CONNECTED = 0x05;
        public const byte RESPONSE_VERSION_MISMATCH = 0x06;

        public const byte CSTATUS_CONNECTING = 0x07;
        public const byte CSTATUS_NEGOTIATING_SECURITY = 0x08;
        public const byte CSTATUS_NEGOTIATION_COMPLETE = 0x09;
        public const byte CSTATUS_NEGOTIATION_FAILED = 0x0A;
        public const byte CSTATUS_AUTHENTICATING = 0x0B;

        public const byte AUTH_OK = 0x0C;
        public const byte AUTH_FAILED = 0x0D;
        public const byte AUTH_REJECT = 0x0E;
        public const byte AUTH_BAD_SERVER_PROOF = 0x0F;
        public const byte AUTH_UNAVAILABLE = 0x10;
        public const byte AUTH_SYSTEM_ERROR = 0x11;
        public const byte AUTH_BILLING_ERROR = 0x12;
        public const byte AUTH_BILLING_EXPIRED = 0x13;
        public const byte AUTH_VERSION_MISMATCH = 0x14;
        public const byte AUTH_UNKNOWN_ACCOUNT = 0x15;
        public const byte AUTH_INCORRECT_PASSWORD = 0x16;
        public const byte AUTH_SESSION_EXPIRED = 0x17;
        public const byte AUTH_SERVER_SHUTTING_DOWN = 0x18;
        public const byte AUTH_ALREADY_LOGGING_IN = 0x19;
        public const byte AUTH_LOGIN_SERVER_NOT_FOUND = 0x1A;
        public const byte AUTH_WAIT_QUEUE = 0x1B;
        public const byte AUTH_BANNED = 0x1C;
        public const byte AUTH_ALREADY_ONLINE = 0x1D;
        public const byte AUTH_NO_TIME = 0x1E;
        public const byte AUTH_DB_BUSY = 0x1F;
        public const byte AUTH_SUSPENDED = 0x20;
        public const byte AUTH_PARENTAL_CONTROL = 0x21;

        public const byte REALM_LIST_IN_PROGRESS = 0x22;
        public const byte REALM_LIST_SUCCESS = 0x23;
        public const byte REALM_LIST_FAILED = 0x24;
        public const byte REALM_LIST_INVALID = 0x25;
        public const byte REALM_LIST_REALM_NOT_FOUND = 0x26;

        public const byte ACCOUNT_CREATE_IN_PROGRESS = 0x27;
        public const byte ACCOUNT_CREATE_SUCCESS = 0x28;
        public const byte ACCOUNT_CREATE_FAILED = 0x29;

        public const byte CHAR_LIST_RETRIEVING = 0x2A;
        public const byte CHAR_LIST_RETRIEVED = 0x2B;
        public const byte CHAR_LIST_FAILED = 0x2C;

        public const byte CHAR_CREATE_IN_PROGRESS = 0x2D;
        public const byte CHAR_CREATE_SUCCESS = 0x2E;
        public const byte CHAR_CREATE_ERROR = 0x2F;
        public const byte CHAR_CREATE_FAILED = 0x30;
        public const byte CHAR_CREATE_NAME_IN_USE = 0x31;
        public const byte CHAR_CREATE_DISABLED = 0x32;
        public const byte CHAR_CREATE_PVP_TEAMS_VIOLATION = 0x33;
        public const byte CHAR_CREATE_SERVER_LIMIT = 0x34;
        public const byte CHAR_CREATE_ACCOUNT_LIMIT = 0x35;
        public const byte CHAR_CREATE_SERVER_QUEUE = 0x36;
        public const byte CHAR_CREATE_ONLY_EXISTING = 0x37;
        public const byte CHAR_CREATE_EXPANSION = 0x38;

        public const byte CHAR_DELETE_IN_PROGRESS = 0x39;
        public const byte CHAR_DELETE_SUCCESS = 0x3A;
        public const byte CHAR_DELETE_FAILED = 0x3B;
        public const byte CHAR_DELETE_FAILED_LOCKED_FOR_TRANSFER = 0x3C;

        public const byte CHAR_LOGIN_IN_PROGRESS = 0x3D;
        public const byte CHAR_LOGIN_SUCCESS = 0x3E;
        public const byte CHAR_LOGIN_NO_WORLD = 0x3F;
        public const byte CHAR_LOGIN_DUPLICATE_CHARACTER = 0x40;
        public const byte CHAR_LOGIN_NO_INSTANCES = 0x41;
        public const byte CHAR_LOGIN_FAILED = 0x42;
        public const byte CHAR_LOGIN_DISABLED = 0x43;
        public const byte CHAR_LOGIN_NO_CHARACTER = 0x44;
        public const byte CHAR_LOGIN_LOCKED_FOR_TRANSFER = 0x45;
        public const byte CHAR_LOGIN_LOCKED_BY_BILLING = 0x46;

        public const byte CHAR_NAME_NO_NAME = 0x47;
        public const byte CHAR_NAME_TOO_SHORT = 0x48;
        public const byte CHAR_NAME_TOO_LONG = 0x49;
        public const byte CHAR_NAME_INVALID_CHARACTER = 0x4A;
        public const byte CHAR_NAME_MIXED_LANGUAGES = 0x4B;
        public const byte CHAR_NAME_PROFANE = 0x4C;
        public const byte CHAR_NAME_RESERVED = 0x4D;
        public const byte CHAR_NAME_INVALID_APOSTROPHE = 0x4E;
        public const byte CHAR_NAME_MULTIPLE_APOSTROPHES = 0x4F;
        public const byte CHAR_NAME_THREE_CONSECUTIVE = 0x50;
        public const byte CHAR_NAME_INVALID_SPACE = 0x51;
        public const byte CHAR_NAME_CONSECUTIVE_SPACES = 0x52;
        public const byte CHAR_NAME_FAILURE = 0x53;
        public const byte CHAR_NAME_SUCCESS = 0x54;
    }
}
