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
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
#endregion

namespace Demo_R.O.S.E.Common
{
    /// <summary>
    /// Defines for creating data tables
    /// </summary>
    public class ROSECrypt
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 不允许实例化
        /// </summary>
        private ROSECrypt()
        {
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 服务端加密的数据种子
        /// </summary>
        private static byte[] s_ByteCryptTableBuffer    = null;
        #endregion
        /// <summary>
        /// 服务端加密的数据种子
        /// </summary>
        public byte[] CryptTableBuffer
        {
            get { return ROSECrypt.s_ByteCryptTableBuffer; }
        }
        #endregion

        #region zh-CHS 静态方法 | en Static Method
        #region zh-CHS 静态成员变量 | en Static Member Variables
        /// <summary>
        /// 客户端加密的种子
        /// </summary>
        private static byte[] s_ByteSumBuffer   = null;
        /// <summary>
        /// 
        /// </summary>
        private static ROSECrypt s_ROSECrypt    = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public static ROSECrypt Instance( string strFileName )
        {
            if ( s_ROSECrypt == null )
            {
                if ( ROSECrypt.BuildCheckSum( out ROSECrypt.s_ByteSumBuffer, strFileName ) == false)
                {
                    System.Diagnostics.Debug.WriteLine( "ROSECrypt.Instance(...) - s_ROSECrypt == null error!" );

                    return null;
                }

                if ( s_ByteSumBuffer.Length <= 0 )
                {
                    System.Diagnostics.Debug.WriteLine( "ROSECrypt.Instance(...) - s_ByteSumBuffer.Length <= 0 error!" );

                    return null;
                }
                
                ROSECrypt.BuildCryptTable( out ROSECrypt.s_ByteCryptTableBuffer, s_ByteSumBuffer );

                if ( s_ByteCryptTableBuffer.Length <= 0 )
                {
                    System.Diagnostics.Debug.WriteLine( "ROSECrypt.Instance(...) - s_ByteCryptTableBuffer.Length <= 0 error!" );

                    return null;
                }

                s_ROSECrypt = new ROSECrypt();
            }

            return s_ROSECrypt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ROSECrypt Instance()
        {
            return ROSECrypt.Instance( "TRose.exe" );
        }

        /// <summary>
        /// Decrypt a packet
        /// </summary>
        /// <param name="bytePacket"></param>
        /// <param name="byteCryptTable"></param>
        public static void CryptPacket( ref byte[] bytePacket, byte[] byteCryptTable )
        {
            ushort l_iPackSize = (ushort)( ( bytePacket[0] | ( bytePacket[1] << 8 ) ) - 2 );

            for ( int iIndex = 0; iIndex < l_iPackSize; iIndex++ )
            {
                uint tmp1 = ( (uint)( byteCryptTable[0] | ( byteCryptTable[1] << 8 ) | ( byteCryptTable[2] << 16 ) | ( byteCryptTable[3] << 24 ) ) + (uint)1 ) & 0xFF;
                byte tmp2 = byteCryptTable[tmp1 + 8];
                uint tmp3 = ( (uint)( byteCryptTable[4] | ( byteCryptTable[5] << 8 ) | ( byteCryptTable[6] << 16 ) | ( byteCryptTable[7]) << 24 )  + tmp2 ) & 0xFF;
                byte tmp4 = byteCryptTable[tmp3 + 8];

                byteCryptTable[0] = (byte)( tmp1 & 0xFF );
                byteCryptTable[1] = (byte)( ( tmp1 >> 8 ) & 0xFF );
                byteCryptTable[2] = (byte)( ( tmp1 >> 16 ) & 0xFF );
                byteCryptTable[3] = (byte)( ( tmp1 >> 24 ) & 0xFF );

                byteCryptTable[4] = (byte)( tmp3 & 0xFF );
                byteCryptTable[5] = (byte)( ( tmp3 >> 8 ) & 0xFF );
                byteCryptTable[6] = (byte)( ( tmp3 >> 16 ) & 0xFF );
                byteCryptTable[7] = (byte)( ( tmp3 >> 24 ) & 0xFF );

                byteCryptTable[tmp3 + 8] = tmp2;
                byteCryptTable[tmp1 + 8] = tmp4;

                bytePacket[iIndex + 2] = (byte)(byteCryptTable[( ( tmp4 + tmp2 ) & 0xFF ) + 8] ^ bytePacket[iIndex + 2]);
            }
        }
        #endregion

        #region zh-CHS 私有方法 | en Private Method
        /// <summary>
        /// Build a checksum table from a copy of TRose.exe
        /// </summary>
        /// <param name="byteSumBuffer"></param>
        /// <param name="strPath"></param>
        /// <returns></returns>
        private static bool BuildCheckSum( out byte[] byteSumBuffer, string strPath )
        {
            byteSumBuffer = new byte[0];

            byte[] l_bBuffer = new byte[0x200]; // 0x200 == 512
            int l_iBytesRead = 0;

            string l_strPath = strPath;
            if ( l_strPath == null )
                l_strPath = "TRose.exe";
            else if ( l_strPath == string.Empty )
                l_strPath = "TRose.exe";

            if ( File.Exists( l_strPath ) == false )
            {
                byteSumBuffer = new byte[] { 0x32, 0x31, 0x2D, 0x30, 0x76, 0x70, 0x76, 0x61, 0x73, 0x40, 0x23, 0x24, 0x21, 0x53, 0x44, 0x40, 0x54, 0x40, 0x23, 0x25, 0x53, 0x44, 0x61, 0x64, 0x61, 0x73, 0x64, 0x32, 0x31, 0x31, 0x32, 0x34, 0x40, 0x23, 0x66, 0x64 };
                return true;
            }

            FileStream l_FileStream = File.Open( l_strPath, FileMode.Open, FileAccess.Read );
            l_FileStream.Seek( -512, SeekOrigin.End );
            l_iBytesRead = l_FileStream.Read( l_bBuffer, 0, 512 );
            l_FileStream.Close();

            if ( l_iBytesRead != 0x200 )
                return false;

            ushort l_iKeyLen = l_bBuffer[0x0F];
            byte[] l_iKeyCryptBuffer = { 0x94, 0x20, 0x5F, 0x53, 0x14, 0xF2, 0x61, 0x11, 0x54, 0xFF, 0x72, 0x99, 0x44, 0xF4, 0xA1, 0xAA, 0xBA, 0xC2, 0x54, 0x52, 0x6F, 0x73, 0x65, 0x2E, 0x65, 0x78, 0x65 };

            byte[] l_bKeyBuffer = new byte[l_iKeyLen + 1];
            for ( int iIndex = 0; iIndex < l_iKeyLen; iIndex++ )
                l_bKeyBuffer[iIndex] = (byte)(l_iKeyCryptBuffer[iIndex] ^ l_bBuffer[0x18A + iIndex]);

            int l_CryptSumLen = 0;
            int l_iMultiplier = 1;
            for ( int iIndex = l_iKeyLen; iIndex > 0; iIndex-- )
            {
                int l_iTmp = ( l_bKeyBuffer[iIndex - 1] - 0x30 ) * l_iMultiplier;
                l_iMultiplier *= 0x0A;
                l_CryptSumLen += l_iTmp;
            }
            l_bKeyBuffer = null;

            byte[] l_CryptSumTable = { 0x34, 0x5C, 0x3D, 0x52, 0xCE, 0xF3, 0x12, 0xD4, 0x05, 0x91, 0xEE, 0xFF, 0x49, 0xC2, 0xD2 };

            int l_iTmp2 = 0;
            byteSumBuffer = new byte[l_CryptSumLen];
            for ( int iIndex = 0; iIndex < l_CryptSumLen; iIndex++ )
            {
                byteSumBuffer[iIndex] = (byte)( l_CryptSumTable[l_iTmp2] ^ l_bBuffer[0x87 + iIndex] );

                if ( l_iTmp2 == 0x0E )
                    l_iTmp2 = 0;
                else
                    l_iTmp2++;
            }

            return true;
        }

        /// <summary>
        /// Build a crypttable and cryptstatus from our checksum
        /// </summary>
        /// <param name="byteCryptTable"></param>
        /// <param name="byteCheckSum"></param>
        private static void BuildCryptTable( out byte[] byteCryptTable, byte[] byteCheckSum )
        {
            byteCryptTable = new byte[256+8]; // 0x100 == 256

            for ( int iIndex = 0; iIndex < 0x008; iIndex++ )
                byteCryptTable[iIndex] = 0;

            for ( int iIndex = 0; iIndex < 0x100; iIndex++ )
                byteCryptTable[iIndex + 8] = (byte)iIndex;

            int l_Modifier = 0;
            int l_iCryptSumPos = 0;
            for ( int iIndex = 0; iIndex < 0x40 * 4; iIndex++ )
            {
                int l_CurPos = byteCryptTable[8 + iIndex];

                l_Modifier = ( byteCheckSum[l_iCryptSumPos] + l_CurPos + l_Modifier ) & 0xFF;
                byteCryptTable[8 + iIndex] = byteCryptTable[l_Modifier + 8];
                byteCryptTable[l_Modifier + 8] = (byte)l_CurPos;

                l_iCryptSumPos = ++l_iCryptSumPos % byteCheckSum.Length;
            }
        }

        #endregion
    }
}
#endregion