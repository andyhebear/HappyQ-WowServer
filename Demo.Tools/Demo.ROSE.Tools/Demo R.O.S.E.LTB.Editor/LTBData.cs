#region zh-CHS 版权所有 (C) 2003 - 2004 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2003 - 2004 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2003-2004 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@gamil.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections.Generic;
#endregion

namespace Demo_R.O.S.E.LTB.Editor
{
    /// <summary>
    /// LTB数据的读取
    /// </summary>
    public class LTBData
    {
        #region zh-CHS 结构 | en Struct
        /// <summary>
        /// STL文件字符串ID
        /// </summary>
        public struct STBFieldInfo
        {
            #region zh-CHS 成员变量 | en Member Variables
            /// <summary>
            /// 
            /// </summary>
            internal uint m_strFieldoOffset;

            /// <summary>
            /// 字符串ID(字符串)的长度
            /// </summary>
            internal ushort m_strFieldStringLength;

            /// <summary>
            /// 字符串ID(字符串)
            /// </summary>
            private string m_strFieldString;
            #endregion

            #region zh-CHS 属性 | en Properties
            /// <summary>
            /// 字符串ID(字符串)
            /// </summary>
            public string FieldString
            {
                get { return m_strFieldString; }
                set { m_strFieldString = value; }
            }
            #endregion
        }
        #endregion

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// STB的文件名
        /// </summary>
        private string m_strFileName;

        /// <summary>
        /// STB的行数
        /// </summary>
        private uint m_iRowCount;

        /// <summary>
        /// STB的字段数
        /// </summary>
        private uint m_iFieldCount;

        /// <summary>
        /// 
        /// </summary>
        internal STBFieldInfo[] m_STBFieldInfoArray = new STBFieldInfo[0];

        /// <summary>
        /// STB的详细内容
        /// </summary>
        private DataTable m_DataTable;
        #endregion

        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// STB的文件名
        /// </summary>
        public string FileName
        {
            get { return m_strFileName; }
        }

        /// <summary>
        /// STB的行数
        /// </summary>
        public uint RowCount
        {
            get { return m_iRowCount; }
        }

        /// <summary>
        /// STB的字段数
        /// </summary>
        public uint FieldCount
        {
            get { return m_iFieldCount; }
        }

        /// <summary>
        /// STB的详细内容
        /// </summary>
        public DataTable DataTable
        {
            get { return m_DataTable; }
            set { m_DataTable = value; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 清除数据
        /// </summary>
        void Clear()
        {
            m_strFileName = string.Empty;
            m_iRowCount = 0;
            m_iFieldCount = 0;
            m_STBFieldInfoArray = new STBFieldInfo[0];
            m_DataTable.Columns.Clear();
            m_DataTable.Rows.Clear();
        }
        #endregion

        #region zh-CHS 静态方法 | en Static Method
        /// <summary>
        /// 韩国代码页(949)
        /// </summary>
        /// <param name="stbData"></param>
        /// <param name="strFileName"></param>
        public static bool SaveLTBData( ref LTBData stbData, string strFileName )
        {
            string l_strFieldInfo;
            byte[] l_byteArray;

            //try
            {
                FileStream l_FileStream = File.Open( strFileName, FileMode.Create );
                BinaryWriter l_FileWriter = new BinaryWriter( l_FileStream, Encoding.ASCII );

                l_FileWriter.Write( stbData.FieldCount );
                l_FileWriter.Write( (uint)stbData.m_DataTable.Rows.Count );

                long l_iOffset = ( stbData.m_DataTable.Rows.Count * stbData.FieldCount * 6 ) + l_FileWriter.BaseStream.Position; // 前面的两个(行数和列数)的大小为8字节
                long l_iFileOffset = l_iOffset;

                for ( int iIndex = 0; iIndex < stbData.m_DataTable.Rows.Count; iIndex++ )
                {
                    int iColumnsCount = stbData.m_DataTable.Columns.Count;

                    for ( int iIndex2 = 0; iIndex2 < iColumnsCount; iIndex2++ )
                    {
                        l_strFieldInfo = stbData.m_DataTable.Rows[iIndex][iIndex2].ToString();

                        if ( l_strFieldInfo == null || l_strFieldInfo == string.Empty )
                        {
                            l_FileWriter.Write( (uint)0 );
                            l_FileWriter.Write( (ushort)0 );
                        }
                        else
                        {
                            l_byteArray = Encoding.Unicode.GetBytes( l_strFieldInfo );

                            l_FileWriter.Write( (uint)l_iFileOffset );
                            l_FileWriter.Write( (ushort)l_strFieldInfo.Length );

                            long l_iOriginalOffset = l_FileWriter.BaseStream.Position;

                            l_FileWriter.Seek( (int)l_iFileOffset, SeekOrigin.Begin );

                            l_FileWriter.Write( l_byteArray );
                            l_iFileOffset = l_FileWriter.BaseStream.Position;

                            l_FileWriter.Seek( (int)l_iOriginalOffset, SeekOrigin.Begin );
                        }
                    }
                }

                l_FileWriter.Close();
            }
            //catch
            //{
            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// 韩国代码页(949)
        /// </summary>
        /// <param name="stbData"></param>
        /// <param name="strFileName"></param>
        public static bool LoadLTBData( ref LTBData stbData, string strFileName )
        {
            try
            {
                FileStream l_FileStream = File.OpenRead( strFileName );
                BinaryReader l_FileReader = new BinaryReader( l_FileStream, Encoding.ASCII );

                stbData.m_strFileName = strFileName;
                stbData.m_iFieldCount = l_FileReader.ReadUInt32();
                stbData.m_iRowCount = l_FileReader.ReadUInt32();

                stbData.m_DataTable = new DataTable();
                stbData.m_DataTable.Columns.Add( "ID" );
                stbData.m_DataTable.Columns.Add( "Korean" );
                stbData.m_DataTable.Columns.Add( "English" );
                stbData.m_DataTable.Columns.Add( "Japanese" );
                stbData.m_DataTable.Columns.Add( "China-Taiwan" );
                stbData.m_DataTable.Columns.Add( "China" );
                stbData.m_DataTable.Columns.Add( "Language1" );
                stbData.m_DataTable.Columns.Add( "Language2" );

                for ( int iIndex = 8; iIndex < stbData.m_iFieldCount; iIndex++ )
                    stbData.m_DataTable.Columns.Add( "Language" + (iIndex - 5) );

                for ( int iIndex = 0; iIndex < stbData.m_iRowCount; iIndex++ )
                    stbData.m_DataTable.Rows.Add( stbData.m_DataTable.NewRow() );

                stbData.m_STBFieldInfoArray = new STBFieldInfo[stbData.m_iFieldCount * stbData.m_iRowCount];
                for ( int iIndex = 0; iIndex < stbData.m_STBFieldInfoArray.Length; iIndex++ )
                {
                    stbData.m_STBFieldInfoArray[iIndex].m_strFieldoOffset = l_FileReader.ReadUInt32();
                    stbData.m_STBFieldInfoArray[iIndex].m_strFieldStringLength = l_FileReader.ReadUInt16();

                    if ( stbData.m_STBFieldInfoArray[iIndex].m_strFieldoOffset != 0 )
                    {
                        long l_iOffset = l_FileReader.BaseStream.Position;

                        l_FileReader.BaseStream.Seek( stbData.m_STBFieldInfoArray[iIndex].m_strFieldoOffset, SeekOrigin.Begin );

                        stbData.m_STBFieldInfoArray[iIndex].FieldString = Encoding.Unicode.GetString( l_FileReader.ReadBytes( stbData.m_STBFieldInfoArray[iIndex].m_strFieldStringLength * 2 ) );
                        // 下面替换上面 用于不是UNICODE的文件
                        //stbData.m_STBFieldInfoArray[iIndex].FieldString = Encoding.GetEncoding( 949 ).GetString( l_FileReader.ReadBytes( stbData.m_STBFieldInfoArray[iIndex].m_strFieldStringLength ) );

                        stbData.m_DataTable.Rows[(int)( iIndex / stbData.m_iFieldCount )][(int)( iIndex % stbData.m_iFieldCount )] = stbData.m_STBFieldInfoArray[iIndex].FieldString;

                        l_FileReader.BaseStream.Seek( l_iOffset, SeekOrigin.Begin );
                    }
                }

                l_FileReader.Close();
            }
            catch
            {
                stbData.Clear();
                return false;
            }

            return true;
        }
        #endregion
    };
}
#endregion

