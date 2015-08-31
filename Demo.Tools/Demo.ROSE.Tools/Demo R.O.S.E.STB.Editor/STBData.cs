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

namespace Demo_R.O.S.E.STB.Editor
{
    /// <summary>
    /// STB数据的读取
    /// </summary>
    public class STBData
    {
        #region zh-CHS 结构 | en Struct
        /// <summary>
        /// STL文件字符串ID
        /// </summary>
        public struct STBFieldString
        {
            #region zh-CHS 成员变量 | en Member Variables
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

        /// <summary>
        /// STL文件字符串ID
        /// </summary>
        public struct STBFieldStringArray
        {
            #region zh-CHS 成员变量 | en Member Variables
            /// <summary>
            /// 字符串ID(字符串)
            /// </summary>
            private STBFieldString[] m_STBFieldStringArray;
            #endregion

            #region zh-CHS 属性 | en Properties
            /// <summary>
            /// 字符串ID(字符串)
            /// </summary>
            public STBFieldString[] FieldString
            {
                get { return m_STBFieldStringArray; }
                set { m_STBFieldStringArray = value; }
            }
            #endregion
        }
        
        /// <summary>
        /// STL文件字符串ID
        /// </summary>
        public struct STBFieldComment
        {
            #region zh-CHS 成员变量 | en Member Variables
            /// <summary>
            /// 字符串ID(字符串)的长度
            /// </summary>
            internal ushort m_strFieldCommentLength;

            /// <summary>
            /// 字符串ID(字符串)
            /// </summary>
            private string m_strFieldComment;
            #endregion

            #region zh-CHS 属性 | en Properties
            /// <summary>
            /// 字符串ID(字符串)
            /// </summary>
            public string FieldComment
            {
                get { return m_strFieldComment; }
                set { m_strFieldComment = value; }
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
        /// STB文件头的标示
        /// </summary>
        private string m_strFileType;

        /// <summary>
        /// STB数据的偏移
        /// </summary>
        private uint m_iDataOffset;

        /// <summary>
        /// STB的行数
        /// </summary>
        private uint m_iRowCount;

        /// <summary>
        /// STB的字段数
        /// </summary>
        private uint m_iFieldCount;

        /// <summary>
        /// 未知字段
        /// </summary>
        private uint m_iUnknown;

        /// <summary>
        /// STL的字符串ID
        /// </summary>
        private STBFieldComment[] m_STBFieldComment = new STBFieldComment[0];

        /// <summary>
        /// STL的字符串ID
        /// </summary>
        private STBFieldStringArray[] m_STBFieldStringArray = new STBFieldStringArray[0];

        /// <summary>
        /// STB的列的当前宽度。
        /// </summary>
        private ushort[] m_ColumnsWidth;

        /// <summary>
        /// STB的列标头单元格的标题文本。
        /// </summary>
        private string[] m_ColumnsHeaderText;

        /// <summary>
        /// 未知字段2的字符串长度
        /// </summary>
        private ushort m_iStructNameLength;

        /// <summary>
        /// 未知字段2的字符串
        /// </summary>
        private string m_strStructName;

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
        /// STB文件头的标示
        /// </summary>
        public string FileType
        {
            get { return m_strFileType; }
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
        /// 未知字段
        /// </summary>
        public uint Unknown
        {
            get { return m_iUnknown; }
        }

        /// <summary>
        /// STB的列的当前宽度。
        /// </summary>
        public ushort[] ColumnsWidth
        {
            get { return m_ColumnsWidth; }
            set { m_ColumnsWidth = value; }
        }

        /// <summary>
        /// STB的列标头单元格的标题文本。
        /// </summary>
        public string[] ColumnsHeaderText
        {
            get { return m_ColumnsHeaderText; }
            set { m_ColumnsHeaderText = value; }
        }

        /// <summary>
        /// 未知字段2的字符串
        /// </summary>
        public string StructName
        {
            get { return m_strStructName; }
            set { m_strStructName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public STBFieldComment[] FieldComment
        {
            get { return m_STBFieldComment; }
            set { m_STBFieldComment = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public STBFieldStringArray[] FieldStringArray
        {
            get { return m_STBFieldStringArray; }
            set { m_STBFieldStringArray = value; }
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
            m_strFileType = string.Empty;
            m_iDataOffset = 0;
            m_iRowCount = 0;
            m_iFieldCount = 0;
            m_iUnknown = 0;
            m_ColumnsWidth = null;
            m_ColumnsHeaderText = null;
            m_iStructNameLength = 0;
            m_strStructName = string.Empty;
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
        public static bool SaveSTBDataKorea( ref STBData stbData, string strFileName )
        {
            string l_strFieldInfo;
            byte[] l_byteArray;

            try
            {

                FileStream l_FileStream = File.Open( strFileName, FileMode.Create );
                BinaryWriter l_FileWriter = new BinaryWriter( l_FileStream, Encoding.ASCII );

                l_byteArray = Encoding.GetEncoding( 949 ).GetBytes( stbData.m_strFileType );
                l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                l_FileWriter.Seek( 4, SeekOrigin.Current );
                l_FileWriter.Write( stbData.m_DataTable.Rows.Count + 1 );
                l_FileWriter.Write( stbData.m_DataTable.Columns.Count - 1 );

                l_FileWriter.Write( stbData.m_iUnknown );

                for ( int iIndex = 0; iIndex < stbData.m_ColumnsWidth.Length; iIndex++ )
                    l_FileWriter.Write( stbData.m_ColumnsWidth[iIndex] );

                for ( int iIndex = 1; iIndex < stbData.m_ColumnsHeaderText.Length; iIndex++ )
                {
                    l_strFieldInfo = stbData.m_ColumnsHeaderText[iIndex];
                    l_byteArray = Encoding.GetEncoding( 949 ).GetBytes( l_strFieldInfo );
                    l_FileWriter.Write( (ushort)l_byteArray.Length );
                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                }

                l_byteArray = Encoding.GetEncoding( 949 ).GetBytes( stbData.m_strStructName );
                l_FileWriter.Write( (ushort)l_byteArray.Length );
                l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                for ( int iIndex = 0; iIndex < stbData.m_DataTable.Rows.Count; iIndex++ )
                {
                    l_strFieldInfo = stbData.m_DataTable.Rows[iIndex][1].ToString();
                    l_byteArray = Encoding.GetEncoding( 949 ).GetBytes( l_strFieldInfo );

                    l_FileWriter.Write( (ushort)l_byteArray.Length );
                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                }

                uint l_iDataOffset = (uint)l_FileWriter.BaseStream.Position;
                l_FileWriter.Seek( 4, SeekOrigin.Begin );
                l_FileWriter.Write( l_iDataOffset );

                l_FileWriter.Seek( (int)l_iDataOffset, SeekOrigin.Begin );

                for ( int iIndex = 0; iIndex < stbData.m_DataTable.Rows.Count; iIndex++ )
                {
                    int iColumnsCount = stbData.m_DataTable.Columns.Count - 2;

                    for ( int iIndex2 = 0; iIndex2 < iColumnsCount; iIndex2++ )
                    {
                        l_strFieldInfo = stbData.m_DataTable.Rows[iIndex][iIndex2 + 2].ToString();
                        l_byteArray = Encoding.GetEncoding( 949 ).GetBytes( l_strFieldInfo );

                        l_FileWriter.Write( (ushort)l_byteArray.Length );
                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }
                }

                l_FileWriter.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 简体中文代码页(936)
        /// </summary>
        /// <param name="stbData"></param>
        /// <param name="strFileName"></param>
        public static bool SaveSTBDataChina( ref STBData stbData, string strFileName )
        {
            string l_strFieldInfo;
            byte[] l_byteArray;

            try
            {

                FileStream l_FileStream = File.Open( strFileName, FileMode.Create );
                BinaryWriter l_FileWriter = new BinaryWriter( l_FileStream, Encoding.ASCII );

                l_byteArray = Encoding.GetEncoding( 936 ).GetBytes( stbData.m_strFileType );
                l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                l_FileWriter.Seek( 4, SeekOrigin.Current );
                l_FileWriter.Write( stbData.m_DataTable.Rows.Count + 1 );
                l_FileWriter.Write( stbData.m_DataTable.Columns.Count - 1 );

                l_FileWriter.Write( stbData.m_iUnknown );

                for ( int iIndex = 0; iIndex < stbData.m_ColumnsWidth.Length; iIndex++ )
                    l_FileWriter.Write( stbData.m_ColumnsWidth[iIndex] );

                for ( int iIndex = 1; iIndex < stbData.m_ColumnsHeaderText.Length; iIndex++ )
                {
                    l_strFieldInfo = stbData.m_ColumnsHeaderText[iIndex];
                    l_byteArray = Encoding.GetEncoding( 936 ).GetBytes( l_strFieldInfo );
                    l_FileWriter.Write( (ushort)l_byteArray.Length );
                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                }

                l_byteArray = Encoding.GetEncoding( 936 ).GetBytes( stbData.m_strStructName );
                l_FileWriter.Write( (ushort)l_byteArray.Length );
                l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                for ( int iIndex = 0; iIndex < stbData.m_DataTable.Rows.Count; iIndex++ )
                {
                    l_strFieldInfo = stbData.m_DataTable.Rows[iIndex][1].ToString();
                    l_byteArray = Encoding.GetEncoding( 949 ).GetBytes( l_strFieldInfo );

                    l_FileWriter.Write( (ushort)l_byteArray.Length );
                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                }

                uint l_iDataOffset = (uint)l_FileWriter.BaseStream.Position;
                l_FileWriter.Seek( 4, SeekOrigin.Begin );
                l_FileWriter.Write( l_iDataOffset );

                l_FileWriter.Seek( (int)l_iDataOffset, SeekOrigin.Begin );

                for ( int iIndex = 0; iIndex < stbData.m_DataTable.Rows.Count; iIndex++ )
                {
                    int iColumnsCount = stbData.m_DataTable.Columns.Count - 2;

                    for ( int iIndex2 = 0; iIndex2 < iColumnsCount; iIndex2++ )
                    {
                        l_strFieldInfo = stbData.m_DataTable.Rows[iIndex][iIndex2 + 2].ToString();
                        l_byteArray = Encoding.GetEncoding( 949 ).GetBytes( l_strFieldInfo );

                        l_FileWriter.Write( (ushort)l_byteArray.Length );
                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }
                }

                l_FileWriter.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 韩国代码页(949)
        /// </summary>
        /// <param name="stbData"></param>
        /// <param name="strFileName"></param>
        public static bool LoadSTBDataKorea( ref STBData stbData, string strFileName )
        {
            try
            {
                FileStream l_FileStream = File.OpenRead( strFileName );
                BinaryReader l_FileReader = new BinaryReader( l_FileStream, Encoding.ASCII );

                string l_strFieldInfo;
                ushort l_iFieldLength;

                stbData.m_strFileName = strFileName;
                stbData.m_strFileType = new string( l_FileReader.ReadChars( 4 ) );
                stbData.m_iDataOffset = l_FileReader.ReadUInt32();
                stbData.m_iRowCount = l_FileReader.ReadUInt32();
                stbData.m_iFieldCount = l_FileReader.ReadUInt32();
                stbData.m_iUnknown = l_FileReader.ReadUInt32();

                stbData.m_ColumnsWidth = new ushort[stbData.m_iFieldCount + 1]; // 因为加了一个索引字段, 所以需要加一, 但它是不保存的
                for ( int iIndex = 0; iIndex < stbData.m_ColumnsWidth.Length; iIndex++ )
                    stbData.m_ColumnsWidth[iIndex] = l_FileReader.ReadUInt16();

                stbData.m_ColumnsHeaderText = new string[stbData.m_ColumnsWidth.Length];    // 因为加了一个索引字段, 所以需要加一, 但它是不保存的
                stbData.m_ColumnsHeaderText[0] = "#";   // 一个索引标题文字, 但它是不保存的
                for ( int iIndex = 1; iIndex < stbData.m_ColumnsHeaderText.Length; iIndex++ )
                {
                    l_iFieldLength = l_FileReader.ReadUInt16();
                    l_strFieldInfo = Encoding.GetEncoding( 949 ).GetString( l_FileReader.ReadBytes( l_iFieldLength ) );
                    stbData.m_ColumnsHeaderText[iIndex] = l_strFieldInfo;
                }

                stbData.m_iStructNameLength = l_FileReader.ReadUInt16();
                stbData.m_strStructName = Encoding.GetEncoding( 949 ).GetString( l_FileReader.ReadBytes( (int)stbData.m_iStructNameLength ) );

                stbData.m_DataTable = new DataTable();
                for ( int iIndex = 0; iIndex < stbData.m_ColumnsHeaderText.Length; iIndex++ )
                    stbData.m_DataTable.Columns.Add( string.Empty );

                stbData.m_STBFieldComment = new STBFieldComment[stbData.m_iRowCount - 1];
                for ( int iIndex = 0; iIndex < stbData.m_STBFieldComment.Length; iIndex++ )
                    stbData.m_DataTable.Rows.Add( stbData.m_DataTable.NewRow() );

                for ( int iIndex = 0; iIndex < stbData.m_STBFieldComment.Length; iIndex++ )
                {
                    stbData.m_STBFieldComment[iIndex].m_strFieldCommentLength = l_FileReader.ReadUInt16();
                    stbData.m_STBFieldComment[iIndex].FieldComment = Encoding.GetEncoding( 949 ).GetString( l_FileReader.ReadBytes( stbData.m_STBFieldComment[iIndex].m_strFieldCommentLength ) );
                    stbData.m_DataTable.Rows[iIndex][1] = stbData.m_STBFieldComment[iIndex].FieldComment;
                }

                stbData.m_STBFieldStringArray = new STBFieldStringArray[stbData.m_iRowCount - 1];
                for ( int iIndex = 0; iIndex < stbData.m_STBFieldStringArray.Length; iIndex++ )
                {
                    stbData.m_STBFieldStringArray[iIndex].FieldString = new STBFieldString[stbData.m_iFieldCount - 1];

                    stbData.m_DataTable.Rows[iIndex][0] = iIndex.ToString();
                    for ( int iIndex2 = 0; iIndex2 < stbData.m_STBFieldStringArray[iIndex].FieldString.Length; iIndex2++ )
                    {
                        stbData.m_STBFieldStringArray[iIndex].FieldString[iIndex2].m_strFieldStringLength = l_FileReader.ReadUInt16();
                        stbData.m_STBFieldStringArray[iIndex].FieldString[iIndex2].FieldString = Encoding.GetEncoding( 949 ).GetString( l_FileReader.ReadBytes( stbData.m_STBFieldStringArray[iIndex].FieldString[iIndex2].m_strFieldStringLength ) );
                        stbData.m_DataTable.Rows[iIndex][iIndex2 + 2] = stbData.m_STBFieldStringArray[iIndex].FieldString[iIndex2].FieldString;
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

        /// <summary>
        /// 简体中文代码页(936)
        /// </summary>
        /// <param name="stbData"></param>
        /// <param name="strFileName"></param>
        public static bool LoadSTBDataChina( ref STBData stbData, string strFileName )
        {
            try
            {
                FileStream l_FileStream = File.OpenRead( strFileName );
                BinaryReader l_FileReader = new BinaryReader( l_FileStream, Encoding.ASCII );

                string l_strFieldInfo;
                ushort l_iFieldLength;

                stbData.m_strFileName = strFileName;
                stbData.m_strFileType = new string( l_FileReader.ReadChars( 4 ) );
                stbData.m_iDataOffset = l_FileReader.ReadUInt32();
                stbData.m_iRowCount = l_FileReader.ReadUInt32();
                stbData.m_iFieldCount = l_FileReader.ReadUInt32();
                stbData.m_iUnknown = l_FileReader.ReadUInt32();

                stbData.m_ColumnsWidth = new ushort[stbData.m_iFieldCount + 1]; // 因为加了一个索引字段, 所以需要加一, 但它是不保存的
                for ( int iIndex = 0; iIndex < stbData.m_ColumnsWidth.Length; iIndex++ )
                    stbData.m_ColumnsWidth[iIndex] = l_FileReader.ReadUInt16();

                stbData.m_ColumnsHeaderText = new string[stbData.m_ColumnsWidth.Length];    // 因为加了一个索引字段, 所以需要加一, 但它是不保存的
                stbData.m_ColumnsHeaderText[0] = "#";   // 一个索引标题文字, 但它是不保存的
                for ( int iIndex = 1; iIndex < stbData.m_ColumnsHeaderText.Length; iIndex++ )
                {
                    l_iFieldLength = l_FileReader.ReadUInt16();
                    l_strFieldInfo = Encoding.GetEncoding( 936 ).GetString( l_FileReader.ReadBytes( l_iFieldLength ) );
                    stbData.m_ColumnsHeaderText[iIndex] = l_strFieldInfo;
                }

                stbData.m_iStructNameLength = l_FileReader.ReadUInt16();
                stbData.m_strStructName = Encoding.GetEncoding( 936 ).GetString( l_FileReader.ReadBytes( (int)stbData.m_iStructNameLength ) );

                stbData.m_DataTable = new DataTable();
                for ( int iIndex = 0; iIndex < stbData.m_ColumnsHeaderText.Length; iIndex++ )
                    stbData.m_DataTable.Columns.Add( string.Empty );

                stbData.m_STBFieldComment = new STBFieldComment[stbData.m_iRowCount - 1];
                for ( int iIndex = 0; iIndex < stbData.m_STBFieldComment.Length; iIndex++ )
                    stbData.m_DataTable.Rows.Add( stbData.m_DataTable.NewRow() );

                for ( int iIndex = 0; iIndex < stbData.m_STBFieldComment.Length; iIndex++ )
                {
                    stbData.m_STBFieldComment[iIndex].m_strFieldCommentLength = l_FileReader.ReadUInt16();
                    stbData.m_STBFieldComment[iIndex].FieldComment = Encoding.GetEncoding( 949 ).GetString( l_FileReader.ReadBytes( stbData.m_STBFieldComment[iIndex].m_strFieldCommentLength ) );
                    stbData.m_DataTable.Rows[iIndex][1] = stbData.m_STBFieldComment[iIndex].FieldComment;
                }

                stbData.m_STBFieldStringArray = new STBFieldStringArray[stbData.m_iRowCount - 1];
                for ( int iIndex = 0; iIndex < stbData.m_STBFieldStringArray.Length; iIndex++ )
                {
                    stbData.m_STBFieldStringArray[iIndex].FieldString = new STBFieldString[stbData.m_iFieldCount - 1];

                    stbData.m_DataTable.Rows[iIndex][0] = iIndex.ToString();
                    for ( int iIndex2 = 0; iIndex2 < stbData.m_STBFieldStringArray[iIndex].FieldString.Length; iIndex2++ )
                    {
                        stbData.m_STBFieldStringArray[iIndex].FieldString[iIndex2].m_strFieldStringLength = l_FileReader.ReadUInt16();
                        stbData.m_STBFieldStringArray[iIndex].FieldString[iIndex2].FieldString = Encoding.GetEncoding( 949 ).GetString( l_FileReader.ReadBytes( stbData.m_STBFieldStringArray[iIndex].FieldString[iIndex2].m_strFieldStringLength ) );
                        stbData.m_DataTable.Rows[iIndex][iIndex2 + 2] = stbData.m_STBFieldStringArray[iIndex].FieldString[iIndex2].FieldString;
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

