using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Misc.Zip.Dll;
using Demo.Mmose.Core.Common.Srp;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Wow.Common;
using Demo.Wow.WorldServer.Common;
using Demo.Wow.WorldServer.Entity.Common;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 服务端给客户端的信息包头(6字节)
    /// </summary>
    internal class WOWClientPacketHeader
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ushort m_iPacketSize;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ushort PacketSize
        {
            get { return m_iPacketSize; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iPacketID;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PacketID
        {
            get { return m_iPacketID; }
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetBuffer"></param>
        /// <returns></returns>
        public static WOWClientPacketHeader GetClientPacketHeader( byte[] packetBuffer )
        {
            WOWClientPacketHeader returnPacketHeader = new WOWClientPacketHeader();

            returnPacketHeader.m_iPacketSize = (ushort)( ( packetBuffer[0] << 8 ) | packetBuffer[1] );
            returnPacketHeader.m_iPacketID = (uint)( ( packetBuffer[2] ) | packetBuffer[3] << 8 | packetBuffer[4] << 16 | packetBuffer[5] << 24 );

            LOGs.WriteLine( LogMessageType.MSG_HACK, "GetClientPacketHeader...... 0 = {0} {1}", returnPacketHeader.m_iPacketSize, returnPacketHeader.m_iPacketID );

            return returnPacketHeader;
        }
        #endregion
    }


    // 客户端给服务端的信息包头(4字节)
    //internal struct WOWServerPacketHeader
    //{
    //    ushort m_iSize;
    //    ushort m_iCmd;
    //}

    //------------------------------------------------------------------------

    #region zh-CHS Word_AuthChallenge 类 | en Word_AuthChallenge Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_AuthChallenge : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_AuthChallenge( uint iServerSeed )
            : base( (long)WordOpCode.SMSG_AUTH_CHALLENGE, 0 )
        {
            WriterStream.Write( (ushort)ByteOrder.NetToHost(6) /* 2 + 4 */ );                   // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_AUTH_CHALLENGE );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)iServerSeed );
        }
    }
    #endregion

    #region zh-CHS Memory Packet 类 | en Memory Packet Class
    /// <summary>
    /// 
    /// </summary>
    public class MemoryPacket : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public static int MEMORY_PACKET_CAPACITY_SZIE = 1024;

        /// <summary>
        /// 
        /// </summary>
        public MemoryPacket()
            : base( 0, 0, MEMORY_PACKET_CAPACITY_SZIE )
        {
        }
    }
    #endregion

    #region zh-CHS SMSG_UPDATE_OBJECT 类 | en SMSG_UPDATE_OBJECT Class
    /// <summary>
    /// 
    /// </summary>
    public class UpdatePacket : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public static int UPDATE_PACKET_CAPACITY_SZIE = 1024;

        /// <summary>
        /// 
        /// </summary>
        public UpdatePacket()
            : base( (long)WordOpCode.SMSG_UPDATE_OBJECT, 0, 1024 )
        {
            WriterStream.Write( (ushort)0 /* ? */ );                      // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_UPDATE_OBJECT );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)0 );
            WriterStream.Write( (byte)0 );
        }

        /// <summary>
        /// 
        /// </summary>
        public void Write( Packet packet )
        {
            WriterStream.Write( packet.WriterStream.ToArray(), 0, (int)packet.WriterStream.Length );
        }

        /// <summary>
        /// 
        /// </summary>
        public void EndWrite( uint iUpdateCount )
        {
            WriterStream.Seek( 4, SeekOrigin.Begin );
            WriterStream.Write( (uint)iUpdateCount );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS SMSG_DESTROY_OBJECT 类 | en SMSG_DESTROY_OBJECT Class
    /// <summary>
    /// 
    /// </summary>
    public class DestroyPacket : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public DestroyPacket( EntityId entityId )
            : base( (long)WordOpCode.SMSG_DESTROY_OBJECT, 0 )
        {
            WriterStream.Write( (ushort)ByteOrder.NetToHost( 10 ) /* 2 + 8 */ );                      // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_UPDATE_OBJECT );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)entityId.High );
            WriterStream.Write( (uint)entityId.Low );
        }
    }
    #endregion
}
