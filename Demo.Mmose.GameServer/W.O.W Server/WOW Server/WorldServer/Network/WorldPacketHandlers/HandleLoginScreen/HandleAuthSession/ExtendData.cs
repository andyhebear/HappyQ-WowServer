using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Misc.Zip.Dll;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class AuthSession
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iClientBuild;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ClientBuild
        {
            get { return m_iClientBuild; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iUnknown;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Unknown
        {
            get { return m_iUnknown; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
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
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iClientSeed;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ClientSeed
        {
            get { return m_iClientSeed; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_byteDigest = new byte[20];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] Digest
        {
            get { return m_byteDigest; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_RealSize = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RealSize
        {
            get { return m_RealSize; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Word_AddonInfo m_AddonInfo = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Word_AddonInfo AddonInfo
        {
            get { return m_AddonInfo; }
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetReader"></param>
        /// <returns></returns>
        public static AuthSession ReadWorldAuthSession( PacketReader packetReader )
        {
            AuthSession worldAuthSession = new AuthSession();

            worldAuthSession.m_iClientBuild = packetReader.ReadUInt32();
            worldAuthSession.m_iUnknown = packetReader.ReadUInt32();
            worldAuthSession.m_strAccountName = packetReader.ReadUTF8StringSafe();
            worldAuthSession.m_iClientSeed = packetReader.ReadUInt32();

            packetReader.ReadBuffer( ref worldAuthSession.m_byteDigest, 0, 20 );

            worldAuthSession.m_RealSize = packetReader.ReadUInt32();

            if ( worldAuthSession.m_RealSize <= 0 )
            {
                Debug.WriteLine( "AuthSession.ReadWorldAuthSession(...) - worldAuthSession.m_RealSize <= 0 error!" );

                return worldAuthSession;
            }

            if ( packetReader.Position + 5 > packetReader.Size )
            {
                Debug.WriteLine( "AuthSession.ReadWorldAuthSession(...) - packetReader.Position + 5 > packetReader.Size error!" );

                return worldAuthSession;
            }

            byte[] outBuffer = null;
            bool bIsOK = MemoryZip.ZlibDecompressor( packetReader.Buffer, (int)packetReader.Position, (int)packetReader.Size - (int)packetReader.Position, out outBuffer );

            if ( bIsOK == false )
            {
                Debug.WriteLine( "AuthSession.ReadWorldAuthSession(...) - bIsOK == false error!" );

                return worldAuthSession;
            }
            
            worldAuthSession.m_AddonInfo = new Word_AddonInfo( outBuffer );

            return worldAuthSession;
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed partial class WorldExtendData : IPacketEncoder
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private AuthSession m_WorldAuthSession = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public AuthSession AuthSession
        {
            get { return m_WorldAuthSession; }
            set { m_WorldAuthSession = value; }
        }
    }
}
