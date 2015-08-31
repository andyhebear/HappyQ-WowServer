#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2006 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System.IO;
using Demo_G.O.S.E.ServerEngine.Util;
using Demo_G.O.S.E.ServerEngine.Network;
#endregion

namespace Demo_R.O.S.E.LoginServer.Network
{
    #region zh-CHS EncryptionRequest Ack 类 | en EncryptionRequest Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class EncryptionRequestAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal EncryptionRequestAck()
            : base( 0x7FF, 34 /*6 + 28*/ )
        {
            WriterStream.Write( (ushort)34 /*6 + 28*/ );    // 字段大小
            WriterStream.Write( (ushort)base.PacketID );    // 字段编号
            WriterStream.Write( (ushort)0x00 );             // 字段保留
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)0xAF02 );
            WriterStream.Write( (ushort)0xBD46 );
            WriterStream.Write( (ushort)0x0009 );
            WriterStream.Write( (ushort)0x0012 );
            WriterStream.Write( (byte)0x00 );

            WriterStream.Write( (uint)0xCDCDCDCD );
            WriterStream.Write( (uint)0xCDCDCDCD );
            WriterStream.Write( (uint)0xCDCDCDCD );
            WriterStream.Write( (uint)0xCDCDCDCD );
            WriterStream.Write( (ushort)0xCDCD );
            WriterStream.Write( (byte)0xD3 );
        }
    }
    #endregion

    #region zh-CHS AccountLogin Ack/Rej类 | en AccountLogin Ack/Rej Class

    #region zh-CHS AccountLogin Ack 类 | en AccountLogin Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class AccountLoginAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal AccountLoginAck( ServerInfo[] serverInfo )
            : base( 0x708, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // 字段大小
            WriterStream.Write( (ushort)base.PacketID );    // 字段编号
            WriterStream.Write( (ushort)0x00 );             // 字段保留
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (uint)0x0C000000 );
            WriterStream.Write( (sbyte)0x0 );

            // 写入Channels信息
            for ( int iIndex = 0; iIndex < serverInfo.Length; iIndex++ )
            {
                WriterStream.Write( (sbyte)( 48 + iIndex ) );
                WriterStream.WriteAsciiNull( serverInfo[iIndex].ServerName );
                WriterStream.Write( (int)serverInfo[iIndex].ServerGuid );
            }


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );     // 字段大小
        }
    }
    #endregion

    #region zh-CHS AccountLogin Rej 类 | en AccountLogin Rej Class
    /// <summary>
    /// 1 - general error
    /// 2 - BAD USERNAME
    /// 3 - BAD PASSWORD
    /// 4 - your account is already logged 
    /// 5 - BANNED
    /// 6 - top up account
    /// 7 - cannot connect to server please try again
    /// 8 - server exceeded
    /// 9 - account have not been verified
    /// 10 - login failed
    /// 11 - IP capacity is full
    /// </summary>
    internal sealed class AccountLoginRej : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal AccountLoginRej( LoginReason alrReason )
            : base( 0x708, 11 /*6 + 5*/ )
        {
            WriterStream.Write( (ushort)11 /*6 + 5*/ );     // 字段大小
            WriterStream.Write( (ushort)base.PacketID );    // 字段编号
            WriterStream.Write( (ushort)0x00 );             // 字段保留
            //////////////////////////////////////////////////////////////////////////


            if ( alrReason == LoginReason.GeneralError )
            {
                WriterStream.Write( (sbyte)0x01 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.NameError )
            {
                WriterStream.Write( (sbyte)0x02 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.PasswordError )
            {
                WriterStream.Write( (sbyte)0x03 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.InUse )
            {
                WriterStream.Write( (sbyte)0x04 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.Blocked )
            {
                WriterStream.Write( (sbyte)0x05 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.TopUpAccount )
            {
                WriterStream.Write( (sbyte)0x06 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.ServerError )
            {
                WriterStream.Write( (sbyte)0x07 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.ServerCapacityFull )
            {
                WriterStream.Write( (sbyte)0x08 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.AccountInvalid )
            {
                WriterStream.Write( (sbyte)0x09 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.LoginFailed )
            {
                WriterStream.Write( (sbyte)0x10 );
                WriterStream.Write( (int)0x0 );
            }
            else if ( alrReason == LoginReason.IPCapacityFull )
            {
                WriterStream.Write( (sbyte)0x11 );
                WriterStream.Write( (int)0x0 );
            }
            else
            {
                WriterStream.Write( (sbyte)0x05 );
                WriterStream.Write( (int)0x0 );
            }
        }
    }
    #endregion

    #endregion

    #region zh-CHS GetServerNameList Ack 类 | en GetServerNameList Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class GetServerNameListAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal GetServerNameListAck( ServerInfo[] serverInfo, int iChannelGuid )
            : base( 0x704, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // 字段大小
            WriterStream.Write( (ushort)base.PacketID );    // 字段编号
            WriterStream.Write( (ushort)0x00 );             // 字段保留
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (int)iChannelGuid );
            WriterStream.Write( (sbyte)serverInfo.Length );

            for ( int iIndex = 0; iIndex < serverInfo.Length; iIndex++ )
            {
                WriterStream.Write( (ushort)serverInfo[iIndex].ServerGuid );

                WriterStream.Write( (sbyte)0x0 );
                WriterStream.Write( (ushort)0x0 );

                WriterStream.WriteAsciiNull( serverInfo[iIndex].ServerName );
            }


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion

    #region zh-CHS GetServerIP Ack 类 | en GetServerIP Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class GetServerIPAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal GetServerIPAck( ServerInfo serverInfo, int iAccountsGuid )
            : base( 0x70A, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // 字段大小
            WriterStream.Write( (ushort)base.PacketID );    // 字段编号
            WriterStream.Write( (ushort)0x00 );             // 字段保留
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (sbyte)serverInfo.FullPercent );
            WriterStream.Write( (uint)iAccountsGuid );
            WriterStream.Write( (uint)0x87654321 );
            WriterStream.WriteAsciiNull( serverInfo.Address.Address.ToString() );
            WriterStream.Write( (ushort)serverInfo.Address.Port );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion
}
#endregion