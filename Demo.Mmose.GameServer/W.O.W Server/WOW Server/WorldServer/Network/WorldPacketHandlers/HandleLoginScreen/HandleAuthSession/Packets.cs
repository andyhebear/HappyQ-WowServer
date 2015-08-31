using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    #region zh-CHS Word_AuthResponse 类 | en Word_AuthResponse Class
    /// <summary>
    /// Realm_PacketHandlers.Realm_HandleRequestSessionResult(...)中处理
    /// </summary>
    internal sealed class Word_AuthResponse : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_AuthResponse( bool bIsTBC )
            : base( (long)WordOpCode.SMSG_AUTH_RESPONSE, 0 )
        {
            WriterStream.Write( (ushort)ByteOrder.NetToHost( 13 ) /* 2 + 11 */ );                   // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_AUTH_RESPONSE );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)ResponseCodes.AUTH_OK );

            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (byte)0x00 );

            WriterStream.Write( (byte)0x02 );

            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (byte)0x00 );

            if ( bIsTBC )
                WriterStream.Write( (byte)0x01 );
            else
                WriterStream.Write( (byte)0x00 );
        }
    }
    #endregion

    #region zh-CHS Word_AuthResponsePending 类 | en Word_AuthResponsePending Class
    /// <summary>
    /// WaitQueueLogins.Enqueue(...)中处理
    /// </summary>
    internal sealed class Word_AuthResponsePending : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_AuthResponsePending( uint iPosition )
            : base( (long)WordOpCode.SMSG_AUTH_RESPONSE, 0 )
        {
            WriterStream.Write( (ushort)ByteOrder.NetToHost( 16 ) /* 2 + 14 */ );                   // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_AUTH_RESPONSE );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)ResponseCodes.AUTH_WAIT_QUEUE );

            WriterStream.Write( (byte)0x2C );
            WriterStream.Write( (byte)0x73 );
            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (byte)0x00 );

            WriterStream.Write( (uint)0x00 );
            WriterStream.Write( (byte)0x00 );

            WriterStream.Write( (uint)iPosition );
        }
    }
    #endregion

    #region zh-CHS Word_AuthResponseError 类 | en Word_AuthResponseError Class
    /// <summary>
    /// Realm_PacketHandlers.Realm_HandleRequestSessionResult(...)中处理
    /// </summary>
    internal sealed class Word_AuthResponseError : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_AuthResponseError( uint iErrorInfo )
            : base( (long)WordOpCode.SMSG_AUTH_RESPONSE, 0 )
        {
            WriterStream.Write( (ushort)ByteOrder.NetToHost( 6 ) /* 2 + 4 */ );                   // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_AUTH_RESPONSE );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)iErrorInfo );
        }
    }
    #endregion

    #region zh-CHS Word_AddonInfo 类 | en Word_AddonInfo Class
    /// <summary>
    /// Realm_PacketHandlers.Realm_HandleRequestSessionResult(...)中处理
    /// </summary>
    internal sealed class Word_AddonInfo : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        private static byte[] PublicKey = new byte[] { 0x02, 0x01, 0x01, 0xC3, 0x5B, 0x50, 0x84, 0xB9, 0x3E, 0x32, 0x42, 0x8C, 0xD0, 0xC7, 0x48, 0xFA, 0x0E, 0x5D, 0x54, 0x5A, 0xA3, 0x0E, 0x14, 0xBA, 0x9E, 0x0D, 0xB9, 0x5D, 0x8B, 0xEE, 0xB6, 0x84, 0x93, 0x45, 0x75, 0xFF, 0x31, 0xFE, 0x2F, 0x64, 0x3F, 0x3D, 0x6D, 0x07, 0xD9, 0x44, 0x9B, 0x40, 0x85, 0x59, 0x34, 0x4E, 0x10, 0xE1, 0xE7, 0x43, 0x69, 0xEF, 0x7C, 0x16, 0xFC, 0xB4, 0xED, 0x1B, 0x95, 0x28, 0xA8, 0x23, 0x76, 0x51, 0x31, 0x57, 0x30, 0x2B, 0x79, 0x08, 0x50, 0x10, 0x1C, 0x4A, 0x1A, 0x2C, 0xC8, 0x8B, 0x8F, 0x05, 0x2D, 0x22, 0x3D, 0xDB, 0x5A, 0x24, 0x7A, 0x0F, 0x13, 0x50, 0x37, 0x8F, 0x5A, 0xCC, 0x9E, 0x04, 0x44, 0x0E, 0x87, 0x01, 0xD4, 0xA3, 0x15, 0x94, 0x16, 0x34, 0xC6, 0xC2, 0xC3, 0xFB, 0x49, 0xFE, 0xE1, 0xF9, 0xDA, 0x8C, 0x50, 0x3C, 0xBE, 0x2C, 0xBB, 0x57, 0xED, 0x46, 0xB9, 0xAD, 0x8B, 0xC6, 0xDF, 0x0E, 0xD6, 0x0F, 0xBE, 0x80, 0xB3, 0x8B, 0x1E, 0x77, 0xCF, 0xAD, 0x22, 0xCF, 0xB7, 0x4B, 0xCF, 0xFB, 0xF0, 0x6B, 0x11, 0x45, 0x2D, 0x7A, 0x81, 0x18, 0xF2, 0x92, 0x7E, 0x98, 0x56, 0x5D, 0x5E, 0x69, 0x72, 0x0A, 0x0D, 0x03, 0x0A, 0x85, 0xA2, 0x85, 0x9C, 0xCB, 0xFB, 0x56, 0x6E, 0x8F, 0x44, 0xBB, 0x8F, 0x02, 0x22, 0x68, 0x63, 0x97, 0xBC, 0x85, 0xBA, 0xA8, 0xF7, 0xB5, 0x40, 0x68, 0x3C, 0x77, 0x86, 0x6F, 0x4B, 0xD7, 0x88, 0xCA, 0x8A, 0xD7, 0xCE, 0x36, 0xF0, 0x45, 0x6E, 0xD5, 0x64, 0x79, 0x0F, 0x17, 0xFC, 0x64, 0xDD, 0x10, 0x6F, 0xF3, 0xF5, 0xE0, 0xA6, 0xC3, 0xFB, 0x1B, 0x8C, 0x29, 0xEF, 0x8E, 0xE5, 0x34, 0xCB, 0xD1, 0x2A, 0xCE, 0x79, 0xC3, 0x9A, 0x0D, 0x36, 0xEA, 0x01, 0xE0, 0xAA, 0x91, 0x20, 0x54, 0xF0, 0x72, 0xD8, 0x1E, 0xC7, 0x89, 0xD2, 0x00, 0x00, 0x00, 0x00, 0x00 };

        /// <summary>
        /// 
        /// </summary>
        public Word_AddonInfo( byte[] unPacked )
            : base( (long)WordOpCode.SMSG_ADDON_INFO, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + 4 */ );                   // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_ADDON_INFO );  // ID
            //////////////////////////////////////////////////////////////////////////

            string name = string.Empty;
            ushort Enable = 0; // based on the parsed files from retool
            uint crc = 0;
            uint unknown = 0;

            PacketReader packetReader = new PacketReader( unPacked, unPacked.Length, 0 );

            while ( packetReader.Position < packetReader.Size )
            {
                name = packetReader.ReadUTF8StringSafe();
                Enable = packetReader.ReadUInt16();
                crc = packetReader.ReadUInt32();
                unknown = packetReader.ReadUInt32();

                if ( name == null || name == string.Empty )
                    continue;

                LOGs.WriteLine( LogMessageType.MSG_HACK, "Word_AddonInfo...... {0} {1} {2} {3} {4} {5}", name, Enable, crc, unknown, packetReader.Position, packetReader.Size );

                // Hacky fix, Yea I know its a hacky fix I will make a proper handler one's I got the crc crap
                //if ( crc != 0x4C1C776D ) // CRC of public key version 2.0.1
                {
                    //LOGs.WriteLine( LogMessageType.MSG_HACK, "Word_AddonInfo...... 0 " );
                    //WriterStream.Write( PublicKey, 0, PublicKey.Length/*264 大小*/ ); // part of the hacky fix
                }
                //else
                {
                    LOGs.WriteLine( LogMessageType.MSG_HACK, "Word_AddonInfo...... 1 " );
                    WriterStream.Write( (byte)0x02 );
                    WriterStream.Write( (byte)0x01 );
                    WriterStream.Write( (byte)0x00 );
                    WriterStream.Write( (uint)0x00 );
                    WriterStream.Write( (byte)0x00 );
                }
            }

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion
}
