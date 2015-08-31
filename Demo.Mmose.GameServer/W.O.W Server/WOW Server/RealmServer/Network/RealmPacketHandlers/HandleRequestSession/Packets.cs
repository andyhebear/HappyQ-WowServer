using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common.Srp;
using Demo.Mmose.Core.Network;
using Demo.Wow.RealmServer.Common;

namespace Demo.Wow.RealmServer.Network
{
    #region zh-CHS Realm_RequestSessionResult Àà | en Realm_RequestSessionResult Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Realm_RequestSessionResult : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Realm_RequestSessionResult( uint iSerial, WowAccount account, SecureRemotePassword srp )
            : base( (long)RealmOpCode.CMSG_REQUEST_SESSION_RESULT, 0 /* ProcessNet.REALM_HEAD_SIZE + ? */ )
        {
            WriterStream.Write( (byte)RealmOpCode.CMSG_REQUEST_SESSION_RESULT );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0 );                                        // ×Ö¶ÎÊ£Óà´óÐ¡
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)iSerial );
            WriterStream.Write( true );     // ³É¹¦

            WriterStream.Write( (uint)account.AccountGuid );
            WriterStream.Write( (int)account.AccessLevel );
            WriterStream.Write( (bool)account.IsTBC );

            byte[] byteSessionKey = srp.SessionKey.GetBytes( 40 );
            WriterStream.Write( byteSessionKey, 0, 40 );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 1, SeekOrigin.Begin );
            WriterStream.Write( (ushort)( WriterStream.Length - ProcessNet.REALM_HEAD_SIZE ) );
        }
    }
    #endregion

    #region zh-CHS Realm_RequestSessionResultError Àà | en Realm_RequestSessionResultError Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Realm_RequestSessionResultError : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Realm_RequestSessionResultError( uint iSerial )
            : base( (long)RealmOpCode.CMSG_REQUEST_SESSION_RESULT, 0 /* ProcessNet.REALM_HEAD_SIZE + 5 */ )
        {
            WriterStream.Write( (byte)RealmOpCode.CMSG_REQUEST_SESSION_RESULT );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)5 );                                        // ×Ö¶ÎÊ£Óà´óÐ¡

            WriterStream.Write( (uint)iSerial );
            WriterStream.Write( false );    // Ê§°Ü
        }
    }
    #endregion
}
