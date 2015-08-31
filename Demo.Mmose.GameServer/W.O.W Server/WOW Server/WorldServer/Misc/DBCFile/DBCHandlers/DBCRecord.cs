#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
//
// This file is a part of the G.O.S.E(Game Online Server Engine) for .NET.
//
//           2007-2008 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions outlined
// in the accompanying license agreement.
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Wow.WorldServer.DBC
{
    /// <summary>
    /// 
    /// </summary>
    public class DBCRecord
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DBCFile m_DBCFile = null;
        /// <summary>
        /// 
        /// </summary>
        private uint m_iOffset = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbcFile"></param>
        /// <param name="iOffset"></param>
        public DBCRecord( DBCFile dbcFile, uint iOffset )
        {
            m_DBCFile = dbcFile;
            m_iOffset = iOffset;
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iField"></param>
        /// <returns></returns>
		public float GetFloat(uint iField)
		{
            if ( iField >= m_DBCFile.FieldCount )
            {
                Debug.WriteLine( "DBCRecord.GetFloat(...) - iField >= m_DBCFile.FieldCount error!" );
                return 0;
            }

            CONVERT_FLOAT_INT_UINT returnConvert = new CONVERT_FLOAT_INT_UINT();

            returnConvert.uiUint = GetUInt( iField );

            return returnConvert.fFloat;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iField"></param>
        /// <returns></returns>
        public uint GetUInt( uint iField )
		{
            if ( iField >= m_DBCFile.FieldCount )
            {
                Debug.WriteLine( "DBCRecord.GetUInt(...) - iField >= m_DBCFile.FieldCount error!" );
                return 0;
            }

            uint iOffset = m_iOffset + ( iField * 4 );
            return (uint)m_DBCFile.Data[iOffset] | (uint)m_DBCFile.Data[++iOffset] << 8 | (uint)m_DBCFile.Data[++iOffset] << 16 | (uint)m_DBCFile.Data[++iOffset] << 24;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public uint GetOffsetUInt( uint offset )
		{
            uint iOffset = m_iOffset + offset;
            if ( iOffset + 4 > m_DBCFile.Data.Length )
            {
                Debug.WriteLine( "DBCRecord.GetOffsetUInt(...) - iOffset + 4 > m_DBCFile.Data.Length error!" );
                return 0;
            }

            return (uint)m_DBCFile.Data[iOffset] | (uint)m_DBCFile.Data[++iOffset] << 8 | (uint)m_DBCFile.Data[++iOffset] << 16 | (uint)m_DBCFile.Data[++iOffset] << 24;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iField"></param>
        /// <returns></returns>
        public int GetInt( uint iField )
		{
            if ( iField >= m_DBCFile.FieldCount )
            {
                Debug.WriteLine( "DBCRecord.GetInt(...) - iField >= m_DBCFile.FieldCount error!" );
                return 0;
            }

            uint iOffset = m_iOffset + ( iField * 4 );
            return (int)m_DBCFile.Data[iOffset] | (int)m_DBCFile.Data[++iOffset] << 8 | (int)m_DBCFile.Data[++iOffset] << 16 | (int)m_DBCFile.Data[++iOffset] << 24;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public byte GetOffsetByte( uint offset )
        {
            uint iOffset = m_iOffset + offset;
            if ( iOffset + 1 > m_DBCFile.Data.Length )
            {
                Debug.WriteLine( "DBCRecord.GetOffsetUInt(...) - iOffset + 1 > m_DBCFile.Data.Length error!" );
                return 0;
            }

            return m_DBCFile.Data[iOffset];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iField"></param>
        /// <returns></returns>
        public bool GetBool( uint iField )
        {
            if ( iField >= m_DBCFile.FieldCount )
            {
                Debug.WriteLine( "DBCRecord.GetBool(...) - iField >= m_DBCFile.FieldCount error!" );
                return false;
            }

            uint iOffset = m_iOffset + ( iField * 4 );
            uint iBool = GetUInt( iField );
            if ( iBool == 0 )
                return false;
            else
                return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iField"></param>
        /// <returns></returns>
        public string GetString( uint iField )
		{
            if ( iField >= m_DBCFile.FieldCount )
            {
                Debug.WriteLine( "DBCRecord.GetString(...) - iField >= m_DBCFile.FieldCount error!" );
                return string.Empty;
            }

            uint iStringOffset = GetUInt( iField );
            if ( iStringOffset >= m_DBCFile.StringSize )
            {
                Debug.WriteLine( "DBCRecord.GetString(...) - iStringOffset >= m_DBCFile.StringSize error!" );
                return string.Empty;
            }

            uint iOffset = m_DBCFile.StringTableIndex + iStringOffset;

            int iCount = 0;
            while ( m_DBCFile.Data[iOffset + iCount] != 0 ) iCount++;

            return Encoding.UTF8.GetString( m_DBCFile.Data, (int)iOffset, iCount );
		}
        #endregion
    }
}
#endregion