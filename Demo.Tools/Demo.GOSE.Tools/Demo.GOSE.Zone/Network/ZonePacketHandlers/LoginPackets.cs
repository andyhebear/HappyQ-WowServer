#region zh-CHS ��Ȩ���� (C) 2006 - 2007 DemoSoft Corporation. ��������Ȩ�� | en Copyright (C) 2006 - 2007 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2007 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS �������ֿռ� | en Include namespace
using System;
using System.Text;
using System.Collections.Generic;
using Demo.GOSE.ServerEngine.Network;
#endregion

namespace Demo.WOW.Zone.Network
{
    #region zh-CHS Buffer Packet �� | en Buffer Packet Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class BufferPacket : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal BufferPacket(byte[] byteBuffer, long iOffset, long iSize)
            : base( 0 )
        {
            WriterStream.Write( byteBuffer, (int)iOffset, (int)iSize );
        }
    }
    #endregion
}
#endregion