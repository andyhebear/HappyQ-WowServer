using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.RealmServer.Network
{
    #region zh-CHS Realm_Pong �� | en Realm_Pong Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Realm_Pong : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Realm_Pong()
            : base( (long)RealmOpCode.CMSG_PONG, 0 /* ProcessNet.REALM_HEAD_SIZE + 0 */ )
        {
            WriterStream.Write( (byte)RealmOpCode.CMSG_PONG );   // �ֶα��
            WriterStream.Write( (ushort)0 );                     // �ֶ�ʣ���С
        }
    }
    #endregion
}
