#region zh-CHS ��Ȩ���� (C) 2006 - 2006 DemoSoft Corporation. ��������Ȩ�� | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

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
// mailto:caihuanqing@gamil.com

#region zh-CHS �������ֿռ� | en Include namespace
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections.Generic;
#endregion

namespace Demo_R.O.S.E.STB.Editor
{
    /// <summary>
    /// STB���ݵĶ�ȡ
    /// </summary>
    public class STBData
    {
        #region zh-CHS �ṹ | en Struct
        /// <summary>
        /// STL�ļ��ַ���ID
        /// </summary>
        public struct STBFieldString
        {
            #region zh-CHS ��Ա���� | en Member Variables
            /// <summary>
            /// �ַ���ID(�ַ���)�ĳ���
            /// </summary>
            internal ushort m_strFieldStringLength;

            /// <summary>
            /// �ַ���ID(�ַ���)
            /// </summary>
            private string m_strFieldString;
            #endregion

            #region zh-CHS ���� | en Properties
            /// <summary>
            /// �ַ���ID(�ַ���)
            /// </summary>
            public string FieldString
            {
                get { return m_strFieldString; }
                set { m_strFieldString = value; }
            }
            #endregion
        }

        /// <summary>
        /// STL�ļ��ַ���ID
        /// </summary>
        public struct STBFieldStringArray
        {
            #region zh-CHS ��Ա���� | en Member Variables
            /// <summary>
            /// �ַ���ID(�ַ���)
            /// </summary>
            private STBFieldString[] m_STBFieldStringArray;
            #endregion

            #region zh-CHS ���� | en Properties
            /// <summary>
            /// �ַ���ID(�ַ���)
            /// </summary>
            public STBFieldString[] FieldString
            {
                get { return m_STBFieldStringArray; }
                set { m_STBFieldStringArray = value; }
            }
            #endregion
        }
        
        /// <summary>
        /// STL�ļ��ַ���ID
        /// </summary>
        public struct STBFieldComment
        {
            #region zh-CHS ��Ա���� | en Member Variables
            /// <summary>
            /// �ַ���ID(�ַ���)�ĳ���
            /// </summary>
            internal ushort m_strFieldCommentLength;

            /// <summary>
            /// �ַ���ID(�ַ���)
            /// </summary>
            private string m_strFieldComment;
            #endregion

            #region zh-CHS ���� | en Properties
            /// <summary>
            /// �ַ���ID(�ַ���)
            /// </summary>
            public string FieldComment
            {
                get { return m_strFieldComment; }
                set { m_strFieldComment = value; }
            }
            #endregion
        }
        #endregion

        #region zh-CHS ��Ա���� | en Member Variables
        /// <summary>
        /// STB���ļ���
        /// </summary>
        private string m_strFileName;

        /// <summary>
        /// STB�ļ�ͷ�ı�ʾ
        /// </summary>
        private string m_strFileType;

        /// <summary>
        /// STB���ݵ�ƫ��
        /// </summary>
        private uint m_iDataOffset;

        /// <summary>
        /// STB������
        /// </summary>
        private uint m_iRowCount;

        /// <summary>
        /// STB���ֶ���
        /// </summary>
        private uint m_iFieldCount;

        /// <summary>
        /// δ֪�ֶ�
        /// </summary>
        private uint m_iUnknown;

        /// <summary>
        /// STL���ַ���ID
        /// </summary>
        private STBFieldComment[] m_STBFieldComment = new STBFieldComment[0];

        /// <summary>
        /// STL���ַ���ID
        /// </summary>
        private STBFieldStringArray[] m_STBFieldStringArray = new STBFieldStringArray[0];

        /// <summary>
        /// STB���еĵ�ǰ��ȡ�
        /// </summary>
        private ushort[] m_ColumnsWidth;

        /// <summary>
        /// STB���б�ͷ��Ԫ��ı����ı���
        /// </summary>
        private string[] m_ColumnsHeaderText;

        /// <summary>
        /// δ֪�ֶ�2���ַ�������
        /// </summary>
        private ushort m_iStructNameLength;

        /// <summary>
        /// δ֪�ֶ�2���ַ���
        /// </summary>
        private string m_strStructName;

        /// <summary>
        /// STB����ϸ����
        /// </summary>
        private DataTable m_DataTable;
        #endregion

        #region zh-CHS ���� | en Properties
        /// <summary>
        /// STB���ļ���
        /// </summary>
        public string FileName
        {
            get { return m_strFileName; }
        }

        /// <summary>
        /// STB�ļ�ͷ�ı�ʾ
        /// </summary>
        public string FileType
        {
            get { return m_strFileType; }
        }

        /// <summary>
        /// STB������
        /// </summary>
        public uint RowCount
        {
            get { return m_iRowCount; }
        }

        /// <summary>
        /// STB���ֶ���
        /// </summary>
        public uint FieldCount
        {
            get { return m_iFieldCount; }
        }

        /// <summary>
        /// δ֪�ֶ�
        /// </summary>
        public uint Unknown
        {
            get { return m_iUnknown; }
        }

        /// <summary>
        /// STB���еĵ�ǰ��ȡ�
        /// </summary>
        public ushort[] ColumnsWidth
        {
            get { return m_ColumnsWidth; }
            set { m_ColumnsWidth = value; }
        }

        /// <summary>
        /// STB���б�ͷ��Ԫ��ı����ı���
        /// </summary>
        public string[] ColumnsHeaderText
        {
            get { return m_ColumnsHeaderText; }
            set { m_ColumnsHeaderText = value; }
        }

        /// <summary>
        /// δ֪�ֶ�2���ַ���
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
        /// STB����ϸ����
        /// </summary>
        public DataTable DataTable
        {
            get { return m_DataTable; }
            set { m_DataTable = value; }
        }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// �������
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

        #region zh-CHS ��̬���� | en Static Method
        /// <summary>
        /// ��������ҳ(949)
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
        /// �������Ĵ���ҳ(936)
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
        /// ��������ҳ(949)
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

                stbData.m_ColumnsWidth = new ushort[stbData.m_iFieldCount + 1]; // ��Ϊ����һ�������ֶ�, ������Ҫ��һ, �����ǲ������
                for ( int iIndex = 0; iIndex < stbData.m_ColumnsWidth.Length; iIndex++ )
                    stbData.m_ColumnsWidth[iIndex] = l_FileReader.ReadUInt16();

                stbData.m_ColumnsHeaderText = new string[stbData.m_ColumnsWidth.Length];    // ��Ϊ����һ�������ֶ�, ������Ҫ��һ, �����ǲ������
                stbData.m_ColumnsHeaderText[0] = "#";   // һ��������������, �����ǲ������
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
        /// �������Ĵ���ҳ(936)
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

                stbData.m_ColumnsWidth = new ushort[stbData.m_iFieldCount + 1]; // ��Ϊ����һ�������ֶ�, ������Ҫ��һ, �����ǲ������
                for ( int iIndex = 0; iIndex < stbData.m_ColumnsWidth.Length; iIndex++ )
                    stbData.m_ColumnsWidth[iIndex] = l_FileReader.ReadUInt16();

                stbData.m_ColumnsHeaderText = new string[stbData.m_ColumnsWidth.Length];    // ��Ϊ����һ�������ֶ�, ������Ҫ��һ, �����ǲ������
                stbData.m_ColumnsHeaderText[0] = "#";   // һ��������������, �����ǲ������
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