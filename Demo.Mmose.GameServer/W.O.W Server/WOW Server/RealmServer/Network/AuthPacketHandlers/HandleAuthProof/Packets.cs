using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common.Srp;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class AuthLogonProof
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iCommand;                        // 0x01
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
        private byte[] m_iA = new byte[32];
        /// <summary>
        /// 
        /// </summary>
        private BigInteger m_iBigIntegerA = new BigInteger();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BigInteger PublicEphemeralValueA
        {
            get { return m_iBigIntegerA; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_iProof = new byte[20];
        /// <summary>
        /// 
        /// </summary>
        private BigInteger m_iBigIntegerProof = new BigInteger();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BigInteger ClientProof
        {
            get { return m_iBigIntegerProof; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_iCrcHash = new byte[20];
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iNumberOfKeys;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte NumberOfKeys
        {
            get { return m_iNumberOfKeys; }
            set { m_iNumberOfKeys = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte m_iUnknown;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte Unknown
        {
            get { return m_iUnknown; }
            set { m_iUnknown = value; }
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetReader"></param>
        /// <returns></returns>
        public static AuthLogonProof ReadAuthLogonProof( PacketReader packetReader )
        {
            AuthLogonProof authLogonProof = new AuthLogonProof();

            authLogonProof.CommandID = packetReader.ReadByte();

            packetReader.ReadBuffer( ref authLogonProof.m_iA, 0, authLogonProof.m_iA.Length );
            authLogonProof.m_iBigIntegerA = new BigInteger( authLogonProof.m_iA );

            packetReader.ReadBuffer( ref authLogonProof.m_iProof, 0, authLogonProof.m_iProof.Length );
            authLogonProof.m_iBigIntegerProof = new BigInteger( authLogonProof.m_iProof );

            packetReader.ReadBuffer( ref authLogonProof.m_iCrcHash, 0, authLogonProof.m_iCrcHash.Length );

            authLogonProof.NumberOfKeys = packetReader.ReadByte();
            authLogonProof.Unknown = packetReader.ReadByte();

            return authLogonProof;
        }
        #endregion
    }



    //------------------------------------------------------------------------




    #region zh-CHS Auth_AuthProofResult 类 | en Auth_AuthProofResult Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Auth_AuthProofResult : Packet
    {
        //internal class AuthLogonProof_Result
        //{
        //    public byte m_iCommand = 0;			       // 0x01 CMD_AUTH_LOGON_PROOF
        //    public byte m_iError = 0;
        //    public byte[] M2 = new byte[20];
        //    public uint m_iUnk = 0;
        //    public ushort m_iUnk2 = 0;
        //}

        /// <summary>
        /// 等于 AuthLogonProof_Result 结构
        /// </summary>
        public Auth_AuthProofResult( SecureRemotePassword srp )
            : base( (long)AuthOpCode.CMSG_AUTH_PROOF_RESULT, 0 )
        {
            WriterStream.Write( (byte)AuthOpCode.CMSG_AUTH_PROOF_RESULT );
            WriterStream.Write( (byte)LogineErrorInfo.LOGIN_SUCCESS );
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( srp.ServerSessionKeyProof.GetBytes( 20 ), 0, 20 );

            WriterStream.Fill( 0x0, 6 );
        }
    }
    #endregion

    #region zh-CHS Auth_AuthProofResultError 类 | en Auth_AuthProofResultError Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Auth_AuthProofResultError : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Auth_AuthProofResultError( LogineErrorInfo iErrorInfo )
            : base( (long)AuthOpCode.CMSG_AUTH_PROOF_RESULT, 0 )
        {
            WriterStream.Write( (byte)AuthOpCode.CMSG_AUTH_PROOF_RESULT );
            WriterStream.Write( (byte)iErrorInfo );
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)3 );
            WriterStream.Write( (byte)0 );
        }
    }
    #endregion
}
