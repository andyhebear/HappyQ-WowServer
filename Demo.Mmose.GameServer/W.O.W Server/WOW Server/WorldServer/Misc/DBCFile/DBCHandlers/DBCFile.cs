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
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Wow.WorldServer.DBC
{
    /// <summary>
    /// 
    /// </summary>
    public class DBCFile
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_RecordCount;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RecordCount
        {
            get { return m_RecordCount; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_FieldCount;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FieldCount
        {
            get { return m_FieldCount; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_RecordSize;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint RecordSize
        {
            get { return m_RecordSize; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_StringSize;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint StringSize
        {
            get { return m_StringSize; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_Data = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] Data
        {
            get { return m_Data; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_StringTableIndex;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint StringTableIndex
        {
            get { return m_StringTableIndex; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public bool Open( string strFileName )
        {
            if ( m_Data != null )
            {
                Debug.WriteLine( "DBCFile.Open(...) - m_Data == null error!" );
                return false;
            }

            FileStream fileStream = File.Open( strFileName, FileMode.Open, FileAccess.Read );
            if ( fileStream == null )
            {
                Debug.WriteLine( "DBCFile.Open(...) - fileStream == null error!" );
                return false;
            }

            byte[] byteHeader = new byte[4];
            fileStream.Read( byteHeader, 0, 4 ); //'WDBC'

            if ( byteHeader[0] != 'W' || byteHeader[1] != 'D' || byteHeader[2] != 'B' || byteHeader[3] != 'C' )
            {
                Debug.WriteLine( "DBCFile.Open(...) - byteHeader[0] != 'W' || byteHeader[1] != 'D' || byteHeader[2] != 'B' || byteHeader[3] != 'C' error!" );
                return false;
            }

            byte[] byteRead = new byte[4];

            fileStream.Read( byteRead, 0, byteRead.Length ); // Number of records
            m_RecordCount = (uint)byteRead[0] | (uint)byteRead[1] << 8 | (uint)byteRead[2] << 16 | (uint)byteRead[3] << 24;

            fileStream.Read( byteRead, 0, byteRead.Length ); // Number of fields
            m_FieldCount = (uint)byteRead[0] | (uint)byteRead[1] << 8 | (uint)byteRead[2] << 16 | (uint)byteRead[3] << 24;

            fileStream.Read( byteRead, 0, byteRead.Length ); // Size of a record
            m_RecordSize = (uint)byteRead[0] | (uint)byteRead[1] << 8 | (uint)byteRead[2] << 16 | (uint)byteRead[3] << 24;

            fileStream.Read( byteRead, 0, byteRead.Length ); // String size
            m_StringSize = (uint)byteRead[0] | (uint)byteRead[1] << 8 | (uint)byteRead[2] << 16 | (uint)byteRead[3] << 24;

            m_Data = new byte[m_RecordSize * m_RecordCount + m_StringSize];
            fileStream.Read( m_Data, 0, m_Data.Length ); // String size

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}, {2}, {3}", m_RecordCount, m_FieldCount, m_RecordSize, m_StringSize );

            m_StringTableIndex = m_RecordSize * m_RecordCount;

            fileStream.Close();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRecord"></param>
        /// <returns></returns>
        public DBCRecord GetRecord( uint idRecord )
        {
            return new DBCRecord( this, idRecord * m_RecordSize );
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            m_Data = null;
        }
        #endregion
    }
}
#endregion