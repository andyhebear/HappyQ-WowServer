using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common.Srp;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class AuthLogonChallenge
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iCommand;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte CommandID
        {
            get { return m_iCommand; }
            set { m_iCommand = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iError;		                   // 0x00
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte ErrorInfo
        {
            get { return m_iError; }
            set { m_iError = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ushort m_iSize;		                   // 0x0026
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ushort PackSize
        {
            get { return m_iSize; }
            set { m_iSize = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_iGameName = new byte[4];	   // 'Wow'
        /// <summary>
        /// 
        /// </summary>
        private string m_strGameName = string.Empty;	   // 'Wow'
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string GameName
        {
            get { return m_strGameName; }
            set { m_strGameName = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iVersion1;	                   // 0x00
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte Version1
        {
            get { return m_iVersion1; }
            set { m_iVersion1 = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iVersion2;	                   // 0x08 (0.8.0)
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte Version2
        {
            get { return m_iVersion2; }
            set { m_iVersion2 = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iVersion3;	                   // 0x00
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte Version3
        {
            get { return m_iVersion3; }
            set { m_iVersion3 = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ushort m_iBuild;		                   // 3734
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ushort Build
        {
            get { return m_iBuild; }
            set { m_iBuild = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_iPlatform = new byte[4];	   // 'x86'
        /// <summary>
        /// 
        /// </summary>
        private string m_strPlatform = string.Empty;	   // 'x86'
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Platform
        {
            get { return m_strPlatform; }
            set { m_strPlatform = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_iOS = new byte[4];		       // 'Win'
        /// <summary>
        /// 
        /// </summary>
        private string m_strOS = string.Empty;		   // 'Win'
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string OS
        {
            get { return m_strOS; }
            set { m_strOS = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_iCountry = new byte[4];	       // 'enUS'
        /// <summary>
        /// 
        /// </summary>
        private string m_strCountry = string.Empty;	   // 'enUS'
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Country
        {
            get { return m_strCountry; }
            set { m_strCountry = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iTimeZoneBias;                   // -419
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint TimeZoneBias
        {
            get { return m_iTimeZoneBias; }
            set { m_iTimeZoneBias = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iIP;			                   // client ip
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint IP
        {
            get { return m_iIP; }
            set { m_iIP = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iAccountNameLength;		       // length of account name
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte AccountNameLength
        {
            get { return m_iAccountNameLength; }
            set { m_iAccountNameLength = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_iAccountName = new byte[50];   // account name
        /// <summary>
        /// 
        /// </summary>
        private string m_strAccountName = string.Empty; // account name
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string AccountName
        {
            get { return m_strAccountName; }
            set { m_strAccountName = value; }
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetReader"></param>
        /// <returns></returns>
        public static AuthLogonChallenge ReadAuthLogonChallenge( PacketReader packetReader )
        {
            AuthLogonChallenge authLogonChallenge = new AuthLogonChallenge();

            authLogonChallenge.CommandID = packetReader.ReadByte();
            authLogonChallenge.ErrorInfo = packetReader.ReadByte();
            authLogonChallenge.PackSize = packetReader.ReadUInt16();

            packetReader.ReadBuffer( ref authLogonChallenge.m_iGameName, 0, 4 );
            authLogonChallenge.GameName = authLogonChallenge.m_iGameName.ConvertToString();

            authLogonChallenge.Version1 = packetReader.ReadByte();
            authLogonChallenge.Version2 = packetReader.ReadByte();
            authLogonChallenge.Version3 = packetReader.ReadByte();
            authLogonChallenge.Build = packetReader.ReadUInt16();

            packetReader.ReadBuffer( ref authLogonChallenge.m_iPlatform, 0, 4 );
            authLogonChallenge.Platform = authLogonChallenge.m_iPlatform.ConvertToString();

            packetReader.ReadBuffer( ref authLogonChallenge.m_iOS, 0, 4 );
            authLogonChallenge.OS = authLogonChallenge.m_iOS.ConvertToString();

            packetReader.ReadBuffer( ref authLogonChallenge.m_iCountry, 0, 4 );
            authLogonChallenge.Country = authLogonChallenge.m_iCountry.ConvertToString();

            authLogonChallenge.TimeZoneBias = packetReader.ReadUInt32();
            authLogonChallenge.IP = packetReader.ReadUInt32();
            authLogonChallenge.AccountNameLength = packetReader.ReadByte();

            // 不用了
            //packetReader.ReadBuffer( ref authLogonChallenge.m_iAccountName, 0, authLogonChallenge.AccountNameLength );
            //authLogonChallenge.AccountName = Utility.ByteArrayToString( authLogonChallenge.AccountName, 0, authLogonChallenge.AccountNameLength );

            authLogonChallenge.AccountName = packetReader.ReadUTF8StringSafe();

            return authLogonChallenge;
        }
        #endregion
    }



    //------------------------------------------------------------------------



    #region zh-CHS Auth_AuthChallengeResult 类 | en Auth_AuthChallengeResult Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Auth_AuthChallengeResult : Packet
    {
        //internal class AuthLogonChallenge_Result
        //{
        //    public byte m_iCommand = (byte)RealmListOpCode.CMSG_AUTH_CHALLENGE_RESULT; // 0x00 CMD_AUTH_LOGON_CHALLENGE
        //    public byte m_iError = 0;		           // 0 - ok
        //    public byte m_iUnk = 0;		           // 0x00
        //    public byte[] m_iB = new byte[32];
        //    public byte m_iGLen = 1;		           // 0x01
        //    public byte[] m_iG = new byte[1];
        //    public byte m_iNLen = 32;		           // 0x20
        //    public byte[] m_iN = new byte[32];
        //    public byte[] m_iS = new byte[32];
        //    public byte[] m_iUnk2 = new byte[16];
        //    public byte m_iUnk3 = 0;
        //}

        /// <summary>
        /// 等于 AuthLogonChallenge_Result 结构
        /// </summary>
        public Auth_AuthChallengeResult( SecureRemotePassword srp )
            : base( (long)AuthOpCode.CMSG_AUTH_CHALLENGE_RESULT, 0 )
        {
            WriterStream.Write( (byte)AuthOpCode.CMSG_AUTH_CHALLENGE_RESULT );
            WriterStream.Write( (byte)LogineErrorInfo.LOGIN_SUCCESS );
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)0 );

            WriterStream.Write( srp.PublicEphemeralValueB.GetBytes( 32 ), 0, 32 );

            WriterStream.Write( (byte)1 );
            WriterStream.Write( srp.Generator.GetBytes( 1 ), 0, 1 );

            WriterStream.Write( (byte)32 );
            WriterStream.Write( srp.Modulus.GetBytes( 32 ), 0, 32 );

            WriterStream.Write( srp.Salt.GetBytes( 32 ), 0, 32 );

            BigInteger unknown = new BigInteger();
            unknown.GenRandomBits( 128 /* 16 * 8 */ , new Random( 10 ) );/* 随机数 16字节 */
            WriterStream.Write( unknown.GetBytes( 16 ), 0, 16 );

            WriterStream.Write( (byte)0 );
        }
    }
    #endregion

    #region zh-CHS Auth_AuthChallengeResultError 类 | en Auth_AuthChallengeResultError Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Auth_AuthChallengeResultError : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Auth_AuthChallengeResultError( LogineErrorInfo iErrorInfo )
            : base( (long)AuthOpCode.CMSG_AUTH_CHALLENGE_RESULT, 3 )
        {
            WriterStream.Write( (byte)AuthOpCode.CMSG_AUTH_CHALLENGE_RESULT );
            WriterStream.Write( (byte)0 );
            WriterStream.Write( (byte)iErrorInfo ); //  错误信息
        }
    }
    #endregion
}
