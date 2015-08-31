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

namespace Demo_R.O.S.E.STL.Editor
{
    /// <summary>
    /// STL数据的读取
    /// </summary>
    public class STLData
    {
        #region zh-CHS 结构 | en Struct
        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum Language
        {
            /// <summary>
            /// 
            /// </summary>
            Korean = 0x01,
            /// <summary>
            /// 
            /// </summary>
            English = 0x02,
            /// <summary>
            /// 
            /// </summary>
            Japanese = 0x04,
            /// <summary>
            /// 
            /// </summary>
            ChinaTaiwan = 0x08,
            /// <summary>
            /// 
            /// </summary>
            China = 0x10
        }
        #endregion

        #region zh-CHS 结构 | en Struct
        /// <summary>
        /// STL文件头的标示
        /// </summary>
        public struct STLFileType
        {
            #region zh-CHS 成员变量 | en Member Variables
            /// <summary>
            /// STL文件头的标示长度
            /// </summary>
            internal byte m_strFileTypeLength;
            /// <summary>
            /// STL文件头的标示字符串
            /// </summary>
            private string m_strFileType;
            #endregion

            #region zh-CHS 属性 | en Properties
            /// <summary>
            /// STL文件头的标示字符串
            /// </summary>
            public string FileType
            {
                get { return m_strFileType; }
                set { m_strFileType = value; }
            }
            #endregion
        }

        /// <summary>
        /// STL文件字符串ID
        /// </summary>
        public struct STLStringID
        {
            #region zh-CHS 成员变量 | en Member Variables
            /// <summary>
            /// 字符串ID(字符串)的长度
            /// </summary>
            internal byte m_strStringIDLength;

            /// <summary>
            /// 字符串ID(字符串)
            /// </summary>
            private string m_strStringID;

            /// <summary>
            /// 字符串ID(整数)
            /// </summary>
            private uint m_iStringID;

            /// <summary>
            /// STL的字符串信息
            /// </summary>
            private object m_STLStringInfoKorean;

            /// <summary>
            /// STL的字符串信息
            /// </summary>
            private object m_STLStringInfoEnglish;

            /// <summary>
            /// STL的字符串信息
            /// </summary>
            private object m_STLStringInfoJapanese;

            /// <summary>
            /// STL的字符串信息
            /// </summary>
            private object m_STLStringInfoChinaTaiwan;

            /// <summary>
            /// STL的字符串信息
            /// </summary>
            private object m_STLStringInfoChina;
            #endregion

            #region zh-CHS 属性 | en Properties
            /// <summary>
            /// 字符串ID(整数)
            /// </summary>
            public uint ID
            {
                get { return m_iStringID; }
                set { m_iStringID = value; }
            }

            /// <summary>
            /// 字符串ID(字符串)
            /// </summary>
            public string StringID
            {
                get { return m_strStringID; }
                set { m_strStringID = value; }
            }

            /// <summary>
            /// 韩国的字符串信息
            /// </summary>
            public STLStringInfo KoreanString
            {
                get { return (STLStringInfo)m_STLStringInfoKorean; }
                set { m_STLStringInfoKorean = (object)value; }
            }
            /// <summary>
            /// 英语的字符串信息
            /// </summary>
            public STLStringInfo EnglishString
            {
                get { return (STLStringInfo)m_STLStringInfoEnglish; }
                set { m_STLStringInfoEnglish = (object)value; }
            }
            /// <summary>
            /// 日本的字符串信息
            /// </summary>
            public STLStringInfo JapaneseString
            {
                get { return (STLStringInfo)m_STLStringInfoJapanese; }
                set { m_STLStringInfoJapanese = (object)value; }
            }
            /// <summary>
            /// 中国台湾的字符串信息
            /// </summary>
            public STLStringInfo ChinaTaiwanString
            {
                get { return (STLStringInfo)m_STLStringInfoChinaTaiwan; }
                set { m_STLStringInfoChinaTaiwan = (object)value; }
            }
            /// <summary>
            /// 中文的字符串信息
            /// </summary>
            public STLStringInfo ChinaString
            {
                get { return (STLStringInfo)m_STLStringInfoChina; }
                set { m_STLStringInfoChina = (object)value; }
            }
            #endregion
        }

        /// <summary>
        /// STL文件字符串信息
        /// </summary>
        public struct STLStringInfo
        {
            #region zh-CHS 成员变量 | en Member Variables
            /// <summary>
            /// STL的字符串ID
            /// </summary>
            private STLStringID m_STLStringID;

            /// <summary>
            /// 字符串的信息在文件中的偏移位置
            /// </summary>
            internal uint m_iOffsetPosition;

            /// <summary>
            /// 字符串的信息的长度
            /// </summary>
            internal uint m_iStringLength;

            /// <summary>
            /// 字符串的信息
            /// </summary>
            private string m_strString;

            /// <summary>
            /// 字符串的信息的注解长度
            /// </summary>
            internal uint m_iStringCommentLength;

            /// <summary>
            /// 字符串的信息的注解
            /// </summary>
            private string m_strStringComment;

            /// <summary>
            /// m_strStringComment字段是否有效
            /// </summary>
            private bool m_bIsStringComment;

            /// <summary>
            /// 字符串的信息的注解长度
            /// </summary>
            internal uint m_iStringOtherComment01Length;

            /// <summary>
            /// 字符串的信息的注解
            /// </summary>
            private string m_strStringOtherComment01;

            /// <summary>
            /// m_strStringOtherComment01字段是否有效
            /// </summary>
            private bool m_bIsStringOtherComment01;

            /// <summary>
            /// 字符串的信息的注解长度
            /// </summary>
            internal uint m_iStringOtherComment02Length;

            /// <summary>
            /// 字符串的信息的注解
            /// </summary>
            private string m_strStringOtherComment02;

            /// <summary>
            /// m_strStringOtherComment02字段是否有效
            /// </summary>
            private bool m_bIsStringOtherComment02;
            #endregion

            #region zh-CHS 属性 | en Properties
            /// <summary>
            /// STL的字符串ID
            /// </summary>
            public STLStringID StringID
            {
                get { return m_STLStringID; }
                set { m_STLStringID = value; }
            }

            /// <summary>
            /// 字符串的信息
            /// </summary>
            public string String
            {
                get { return m_strString; }
                set { m_strString = value; }
            }

            /// <summary>
            /// 字符串的信息的注解
            /// </summary>
            public string StringComment
            {
                get { return m_strStringComment; }
                set { m_strStringComment = value; }
            }

            /// <summary>
            /// 字段是否有效
            /// </summary>
            public bool IsStringComment
            {
                get { return m_bIsStringComment; }
                set { m_bIsStringComment = value; }
            }

            /// <summary>
            /// 字符串的信息的注解扩展01
            /// </summary>
            public string StringOtherComment01
            {
                get { return m_strStringOtherComment01; }
                set { m_strStringOtherComment01 = value; }
            }

            /// <summary>
            /// 字段是否有效
            /// </summary>
            public bool IsStringOtherComment01
            {
                get { return m_bIsStringOtherComment01; }
                set { m_bIsStringOtherComment01 = value; }
            }

            /// <summary>
            /// 字符串的信息的注解扩展02
            /// </summary>
            public string StringOtherComment02
            {
                get { return m_strStringOtherComment02; }
                set { m_strStringOtherComment02 = value; }
            }

            /// <summary>
            /// 字段是否有效
            /// </summary>
            public bool IsStringOtherComment02
            {
                get { return m_bIsStringOtherComment02; }
                set { m_bIsStringOtherComment02 = value; }
            }
            #endregion
        }
        #endregion

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// STL的文件名
        /// </summary>
        private string m_strFileName = string.Empty;

        /// <summary>
        /// STL文件头的标示
        /// </summary>
        private STLFileType m_STLFileType = new STLFileType();

        /// <summary>
        /// STL的行数
        /// </summary>
        private uint m_iRowCount = 0;

        /// <summary>
        /// STL的字符串ID
        /// </summary>
        private STLStringID[] m_STLStringID = new STLStringID[0];

        /// <summary>
        /// STL的字符串信息
        /// </summary>
        private STLStringInfo[] m_STLStringInfoKorean = new STLStringInfo[0];

        /// <summary>
        /// STL的字符串信息
        /// </summary>
        private STLStringInfo[] m_STLStringInfoEnglish = new STLStringInfo[0];

        /// <summary>
        /// STL的字符串信息
        /// </summary>
        private STLStringInfo[] m_STLStringInfoJapanese = new STLStringInfo[0];

        /// <summary>
        /// STL的字符串信息
        /// </summary>
        private STLStringInfo[] m_STLStringInfoChinaTaiwan = new STLStringInfo[0];

        /// <summary>
        /// STL的字符串信息
        /// </summary>
        private STLStringInfo[] m_STLStringInfoChina = new STLStringInfo[0];

        /// <summary>
        /// STL的详细内容
        /// </summary>
        private DataTable m_DataTable = new DataTable();
        #endregion

        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// STL的文件名
        /// </summary>
        public string FileName
        {
            get { return m_strFileName; }
        }

        /// <summary>
        /// STL文件头的标示
        /// </summary>
        public STLFileType FileType
        {
            get { return m_STLFileType; }
        }

        /// <summary>
        /// STL的字符串ID
        /// </summary>
        public STLStringID[] StringID
        {
            get { return m_STLStringID; }
            set { m_STLStringID = value; }
        }

        /// <summary>
        /// 韩国的字符串信息
        /// </summary>
        public STLStringInfo[] KoreanString
        {
            get { return m_STLStringInfoKorean; }
            set { m_STLStringInfoKorean = value; }
        }
        /// <summary>
        /// 英语的字符串信息
        /// </summary>
        public STLStringInfo[] EnglishString
        {
            get { return m_STLStringInfoEnglish; }
            set { m_STLStringInfoEnglish = value; }
        }
        /// <summary>
        /// 日本的字符串信息
        /// </summary>
        public STLStringInfo[] JapaneseString
        {
            get { return m_STLStringInfoJapanese; }
            set { m_STLStringInfoJapanese = value; }
        }
        /// <summary>
        /// 中国台湾的字符串信息
        /// </summary>
        public STLStringInfo[] ChinaTaiwanString
        {
            get { return m_STLStringInfoChinaTaiwan; }
            set { m_STLStringInfoChinaTaiwan = value; }
        }
        /// <summary>
        /// 中文的字符串信息
        /// </summary>
        public STLStringInfo[] ChinaString
        {
            get { return m_STLStringInfoChina; }
            set { m_STLStringInfoChina = value; }
        }

        /// <summary>
        /// STL的行数
        /// </summary>
        public uint Length
        {
            get { return m_iRowCount; }
            set { m_iRowCount = value; }
        }

        /// <summary>
        /// STL的详细内容
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
            m_STLFileType = new STLFileType();
            m_iRowCount = 0;
            m_STLStringID = new STLStringID[0];
            m_STLStringInfoKorean = new STLStringInfo[0];
            m_STLStringInfoEnglish = new STLStringInfo[0];
            m_STLStringInfoJapanese = new STLStringInfo[0];
            m_STLStringInfoChinaTaiwan = new STLStringInfo[0];
            m_STLStringInfoChina = new STLStringInfo[0];
            m_DataTable = new DataTable();
        }
        #endregion

        #region zh-CHS 静态方法 | en Static Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stbCoalitionData"></param>
        /// <param name="stbData1"></param>
        /// <param name="languageKeep"></param>
        /// <param name="stbData2"></param>
        /// <returns></returns>
        public static bool CoalitionSTLData( ref STLData stbCoalitionData, STLData stbData1, Language languageKeep, STLData stbData2 )
        {
            stbCoalitionData.m_STLFileType = stbData1.FileType;
            stbCoalitionData.m_iRowCount = stbData1.Length > stbData2.Length ? stbData1.Length : stbData2.Length;

            if ( stbData1.StringID.Length == stbData2.StringID.Length )
            {
                // 检测是否相等
                for ( int iIndex = 0; iIndex < stbData1.StringID.Length; iIndex++ )
                {
                    if ( stbData1.StringID[iIndex].ID != stbData2.StringID[iIndex].ID )
                        return false;

                    if ( stbData1.StringID[iIndex].StringID != stbData2.StringID[iIndex].StringID )
                        return false;
                }

                // 产生新的STLStringID
                STLStringID[] l_STLStringID = new STLStringID[stbData1.StringID.Length];
                for ( int iIndex = 0; iIndex < l_STLStringID.Length; iIndex++ )
                {
                    l_STLStringID[iIndex].ID = stbData1.StringID[iIndex].ID;
                    l_STLStringID[iIndex].StringID = stbData1.StringID[iIndex].StringID;
                }
                stbCoalitionData.StringID = l_STLStringID;

                #region Korean
                // 复制Korean字符串
                STLStringInfo[] l_STLStringInfoKorean = new STLStringInfo[stbData1.KoreanString.Length];
                if ( ( languageKeep & Language.Korean ) == Language.Korean )
                {
                    for ( int iIndex = 0; iIndex < stbData1.KoreanString.Length; iIndex++ )
                    {
                        l_STLStringInfoKorean[iIndex].StringID = stbData1.KoreanString[iIndex].StringID;
                        l_STLStringInfoKorean[iIndex].String = stbData1.KoreanString[iIndex].String;
                        l_STLStringInfoKorean[iIndex].IsStringComment = stbData1.KoreanString[iIndex].IsStringComment;
                        l_STLStringInfoKorean[iIndex].StringComment = stbData1.KoreanString[iIndex].StringComment;
                        l_STLStringInfoKorean[iIndex].IsStringOtherComment01 = stbData1.KoreanString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoKorean[iIndex].StringOtherComment01 = stbData1.KoreanString[iIndex].StringOtherComment01;
                        l_STLStringInfoKorean[iIndex].IsStringOtherComment02 = stbData1.KoreanString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoKorean[iIndex].StringOtherComment02 = stbData1.KoreanString[iIndex].StringOtherComment02;
                    }
                }
                else
                {
                    for ( int iIndex = 0; iIndex < stbData2.KoreanString.Length; iIndex++ )
                    {
                        l_STLStringInfoKorean[iIndex].StringID = stbData2.KoreanString[iIndex].StringID;
                        l_STLStringInfoKorean[iIndex].String = stbData2.KoreanString[iIndex].String;
                        l_STLStringInfoKorean[iIndex].IsStringComment = stbData2.KoreanString[iIndex].IsStringComment;
                        l_STLStringInfoKorean[iIndex].StringComment = stbData2.KoreanString[iIndex].StringComment;
                        l_STLStringInfoKorean[iIndex].IsStringOtherComment01 = stbData2.KoreanString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoKorean[iIndex].StringOtherComment01 = stbData2.KoreanString[iIndex].StringOtherComment01;
                        l_STLStringInfoKorean[iIndex].IsStringOtherComment02 = stbData2.KoreanString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoKorean[iIndex].StringOtherComment02 = stbData2.KoreanString[iIndex].StringOtherComment02;
                    }
                }
                stbCoalitionData.KoreanString = l_STLStringInfoKorean;
                #endregion

                #region English
                // 复制English字符串
                STLStringInfo[] l_STLStringInfoEnglish = new STLStringInfo[stbData1.EnglishString.Length];
                if ( ( languageKeep & Language.English ) == Language.English )
                {
                    for ( int iIndex = 0; iIndex < stbData1.EnglishString.Length; iIndex++ )
                    {
                        l_STLStringInfoEnglish[iIndex].StringID = stbData1.EnglishString[iIndex].StringID;
                        l_STLStringInfoEnglish[iIndex].String = stbData1.EnglishString[iIndex].String;
                        l_STLStringInfoEnglish[iIndex].IsStringComment = stbData1.EnglishString[iIndex].IsStringComment;
                        l_STLStringInfoEnglish[iIndex].StringComment = stbData1.EnglishString[iIndex].StringComment;
                        l_STLStringInfoEnglish[iIndex].IsStringOtherComment01 = stbData1.EnglishString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoEnglish[iIndex].StringOtherComment01 = stbData1.EnglishString[iIndex].StringOtherComment01;
                        l_STLStringInfoEnglish[iIndex].IsStringOtherComment02 = stbData1.EnglishString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoEnglish[iIndex].StringOtherComment02 = stbData1.EnglishString[iIndex].StringOtherComment02;
                    }
                }
                else
                {
                    for ( int iIndex = 0; iIndex < stbData2.EnglishString.Length; iIndex++ )
                    {
                        l_STLStringInfoEnglish[iIndex].StringID = stbData2.EnglishString[iIndex].StringID;
                        l_STLStringInfoEnglish[iIndex].String = stbData2.EnglishString[iIndex].String;
                        l_STLStringInfoEnglish[iIndex].IsStringComment = stbData2.EnglishString[iIndex].IsStringComment;
                        l_STLStringInfoEnglish[iIndex].StringComment = stbData2.EnglishString[iIndex].StringComment;
                        l_STLStringInfoEnglish[iIndex].IsStringOtherComment01 = stbData2.EnglishString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoEnglish[iIndex].StringOtherComment01 = stbData2.EnglishString[iIndex].StringOtherComment01;
                        l_STLStringInfoEnglish[iIndex].IsStringOtherComment02 = stbData2.EnglishString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoEnglish[iIndex].StringOtherComment02 = stbData2.EnglishString[iIndex].StringOtherComment02;
                    }
                }
                stbCoalitionData.EnglishString = l_STLStringInfoEnglish;
                #endregion

                #region Japanese
                // 复制Japanese字符串
                STLStringInfo[] l_STLStringInfoJapanese = new STLStringInfo[stbData1.JapaneseString.Length];
                if ( ( languageKeep & Language.Japanese ) == Language.Japanese )
                {
                    for ( int iIndex = 0; iIndex < stbData1.JapaneseString.Length; iIndex++ )
                    {
                        l_STLStringInfoJapanese[iIndex].StringID = stbData1.JapaneseString[iIndex].StringID;
                        l_STLStringInfoJapanese[iIndex].String = stbData1.JapaneseString[iIndex].String;
                        l_STLStringInfoJapanese[iIndex].IsStringComment = stbData1.JapaneseString[iIndex].IsStringComment;
                        l_STLStringInfoJapanese[iIndex].StringComment = stbData1.JapaneseString[iIndex].StringComment;
                        l_STLStringInfoJapanese[iIndex].IsStringOtherComment01 = stbData1.JapaneseString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoJapanese[iIndex].StringOtherComment01 = stbData1.JapaneseString[iIndex].StringOtherComment01;
                        l_STLStringInfoJapanese[iIndex].IsStringOtherComment02 = stbData1.JapaneseString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoJapanese[iIndex].StringOtherComment02 = stbData1.JapaneseString[iIndex].StringOtherComment02;
                    }
                }
                else
                {
                    for ( int iIndex = 0; iIndex < stbData2.JapaneseString.Length; iIndex++ )
                    {
                        l_STLStringInfoJapanese[iIndex].StringID = stbData2.JapaneseString[iIndex].StringID;
                        l_STLStringInfoJapanese[iIndex].String = stbData2.JapaneseString[iIndex].String;
                        l_STLStringInfoJapanese[iIndex].IsStringComment = stbData2.JapaneseString[iIndex].IsStringComment;
                        l_STLStringInfoJapanese[iIndex].StringComment = stbData2.JapaneseString[iIndex].StringComment;
                        l_STLStringInfoJapanese[iIndex].IsStringOtherComment01 = stbData2.JapaneseString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoJapanese[iIndex].StringOtherComment01 = stbData2.JapaneseString[iIndex].StringOtherComment01;
                        l_STLStringInfoJapanese[iIndex].IsStringOtherComment02 = stbData2.JapaneseString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoJapanese[iIndex].StringOtherComment02 = stbData2.JapaneseString[iIndex].StringOtherComment02;
                    }
                }
                stbCoalitionData.JapaneseString = l_STLStringInfoJapanese;
                #endregion

                #region China_Taiwan
                // 复制China_Taiwan字符串
                STLStringInfo[] l_STLStringInfoChinaTaiwan = new STLStringInfo[stbData1.ChinaTaiwanString.Length];
                if ( ( languageKeep & Language.ChinaTaiwan ) == Language.ChinaTaiwan )
                {
                    for ( int iIndex = 0; iIndex < stbData1.ChinaTaiwanString.Length; iIndex++ )
                    {
                        l_STLStringInfoChinaTaiwan[iIndex].StringID = stbData1.ChinaTaiwanString[iIndex].StringID;
                        l_STLStringInfoChinaTaiwan[iIndex].String = stbData1.ChinaTaiwanString[iIndex].String;
                        l_STLStringInfoChinaTaiwan[iIndex].IsStringComment = stbData1.ChinaTaiwanString[iIndex].IsStringComment;
                        l_STLStringInfoChinaTaiwan[iIndex].StringComment = stbData1.ChinaTaiwanString[iIndex].StringComment;
                        l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment01 = stbData1.ChinaTaiwanString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment01 = stbData1.ChinaTaiwanString[iIndex].StringOtherComment01;
                        l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment02 = stbData1.ChinaTaiwanString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment02 = stbData1.ChinaTaiwanString[iIndex].StringOtherComment02;
                    }
                }
                else
                {
                    for ( int iIndex = 0; iIndex < stbData2.ChinaTaiwanString.Length; iIndex++ )
                    {
                        l_STLStringInfoChinaTaiwan[iIndex].StringID = stbData2.ChinaTaiwanString[iIndex].StringID;
                        l_STLStringInfoChinaTaiwan[iIndex].String = stbData2.ChinaTaiwanString[iIndex].String;
                        l_STLStringInfoChinaTaiwan[iIndex].IsStringComment = stbData2.ChinaTaiwanString[iIndex].IsStringComment;
                        l_STLStringInfoChinaTaiwan[iIndex].StringComment = stbData2.ChinaTaiwanString[iIndex].StringComment;
                        l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment01 = stbData2.ChinaTaiwanString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment01 = stbData2.ChinaTaiwanString[iIndex].StringOtherComment01;
                        l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment02 = stbData2.ChinaTaiwanString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment02 = stbData2.ChinaTaiwanString[iIndex].StringOtherComment02;
                    }
                }
                stbCoalitionData.ChinaTaiwanString = l_STLStringInfoChinaTaiwan;
                #endregion

                #region China
                // 复制China字符串
                STLStringInfo[] l_STLStringInfoChina = new STLStringInfo[stbData1.ChinaString.Length];
                if ( ( languageKeep & Language.China ) == Language.China )
                {
                    for ( int iIndex = 0; iIndex < stbData1.ChinaString.Length; iIndex++ )
                    {
                        l_STLStringInfoChina[iIndex].StringID = stbData1.ChinaString[iIndex].StringID;
                        l_STLStringInfoChina[iIndex].String = stbData1.ChinaString[iIndex].String;
                        l_STLStringInfoChina[iIndex].IsStringComment = stbData1.ChinaString[iIndex].IsStringComment;
                        l_STLStringInfoChina[iIndex].StringComment = stbData1.ChinaString[iIndex].StringComment;
                        l_STLStringInfoChina[iIndex].IsStringOtherComment01 = stbData1.ChinaString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoChina[iIndex].StringOtherComment01 = stbData1.ChinaString[iIndex].StringOtherComment01;
                        l_STLStringInfoChina[iIndex].IsStringOtherComment02 = stbData1.ChinaString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoChina[iIndex].StringOtherComment02 = stbData1.ChinaString[iIndex].StringOtherComment02;
                    }
                }
                else
                {
                    for ( int iIndex = 0; iIndex < stbData2.ChinaString.Length; iIndex++ )
                    {
                        l_STLStringInfoChina[iIndex].StringID = stbData2.ChinaString[iIndex].StringID;
                        l_STLStringInfoChina[iIndex].String = stbData2.ChinaString[iIndex].String;
                        l_STLStringInfoChina[iIndex].IsStringComment = stbData2.ChinaString[iIndex].IsStringComment;
                        l_STLStringInfoChina[iIndex].StringComment = stbData2.ChinaString[iIndex].StringComment;
                        l_STLStringInfoChina[iIndex].IsStringOtherComment01 = stbData2.ChinaString[iIndex].IsStringOtherComment01;
                        l_STLStringInfoChina[iIndex].StringOtherComment01 = stbData2.ChinaString[iIndex].StringOtherComment01;
                        l_STLStringInfoChina[iIndex].IsStringOtherComment02 = stbData2.ChinaString[iIndex].IsStringOtherComment02;
                        l_STLStringInfoChina[iIndex].StringOtherComment02 = stbData2.ChinaString[iIndex].StringOtherComment02;
                    }
                }
                stbCoalitionData.ChinaString = l_STLStringInfoChina;
                #endregion
            }
            else
            {
                STLStringID[] l_MaxSTLStringID = stbData1.StringID.Length > stbData2.StringID.Length ? stbData1.StringID : stbData2.StringID;
                STLStringID[] l_MinSTLStringID = stbData1.StringID.Length < stbData2.StringID.Length ? stbData1.StringID : stbData2.StringID;

                // 检测是否相等
                for ( int iIndex = 0; iIndex < l_MinSTLStringID.Length; iIndex++ )
                {
                    bool l_bIsFind = false;
                    for ( int iIndex1 = 0; iIndex1 < l_MaxSTLStringID.Length; iIndex1++ )
                    {
                        if ( l_MinSTLStringID[iIndex].ID == l_MaxSTLStringID[iIndex1].ID &&
                            l_MinSTLStringID[iIndex].StringID == l_MaxSTLStringID[iIndex1].StringID )
                            l_bIsFind = true;
                    }

                    if (l_bIsFind == false)
                        return false;
                }


                // 产生新的STLStringID
                STLStringID[] l_STLStringID = new STLStringID[l_MaxSTLStringID.Length];
                for ( int iIndex = 0; iIndex < l_MaxSTLStringID.Length; iIndex++ )
                {
                    l_STLStringID[iIndex].ID = l_MaxSTLStringID[iIndex].ID;
                    l_STLStringID[iIndex].StringID = l_MaxSTLStringID[iIndex].StringID;
                }
                stbCoalitionData.StringID = l_STLStringID;

                #region Korean
                // 复制Korean字符串
                if ( ( languageKeep & Language.Korean ) == Language.Korean )
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.KoreanString.Length > stbData2.KoreanString.Length ? stbData1.KoreanString : stbData2.KoreanString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.KoreanString.Length < stbData2.KoreanString.Length ? stbData1.KoreanString : stbData2.KoreanString;
                    STLStringInfo[] l_STLStringInfoKorean = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData1.KoreanString )
                        {
                            l_STLStringInfoKorean[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoKorean[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoKorean[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoKorean[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoKorean[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoKorean[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoKorean[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoKorean[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoKorean[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoKorean[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoKorean[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoKorean[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoKorean[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoKorean[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoKorean[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoKorean[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoKorean[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoKorean[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoKorean[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoKorean[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoKorean[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoKorean[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoKorean[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.KoreanString = l_STLStringInfoKorean;
                }
                else
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.KoreanString.Length > stbData2.KoreanString.Length ? stbData1.KoreanString : stbData2.KoreanString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.KoreanString.Length < stbData2.KoreanString.Length ? stbData1.KoreanString : stbData2.KoreanString;
                    STLStringInfo[] l_STLStringInfoKorean = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData2.KoreanString )
                        {
                            l_STLStringInfoKorean[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoKorean[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoKorean[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoKorean[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoKorean[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoKorean[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoKorean[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoKorean[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoKorean[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoKorean[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoKorean[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoKorean[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoKorean[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoKorean[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoKorean[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoKorean[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoKorean[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoKorean[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoKorean[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoKorean[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoKorean[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoKorean[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoKorean[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.KoreanString = l_STLStringInfoKorean;
                }

                #endregion

                #region English
                // 复制English字符串
                if ( ( languageKeep & Language.English ) == Language.English )
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.EnglishString.Length > stbData2.EnglishString.Length ? stbData1.EnglishString : stbData2.EnglishString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.EnglishString.Length < stbData2.EnglishString.Length ? stbData1.EnglishString : stbData2.EnglishString;
                    STLStringInfo[] l_STLStringInfoEnglish = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData1.EnglishString )
                        {
                            l_STLStringInfoEnglish[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoEnglish[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoEnglish[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoEnglish[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoEnglish[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoEnglish[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoEnglish[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoEnglish[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoEnglish[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoEnglish[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoEnglish[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoEnglish[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoEnglish[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoEnglish[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoEnglish[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoEnglish[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoEnglish[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoEnglish[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoEnglish[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoEnglish[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoEnglish[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoEnglish[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoEnglish[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.EnglishString = l_STLStringInfoEnglish;
                }
                else
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.EnglishString.Length > stbData2.EnglishString.Length ? stbData1.EnglishString : stbData2.EnglishString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.EnglishString.Length < stbData2.EnglishString.Length ? stbData1.EnglishString : stbData2.EnglishString;
                    STLStringInfo[] l_STLStringInfoEnglish = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData2.EnglishString )
                        {
                            l_STLStringInfoEnglish[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoEnglish[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoEnglish[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoEnglish[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoEnglish[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoEnglish[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoEnglish[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoEnglish[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoEnglish[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoEnglish[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoEnglish[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoEnglish[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoEnglish[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoEnglish[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoEnglish[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoEnglish[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoEnglish[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoEnglish[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoEnglish[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoEnglish[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoEnglish[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoEnglish[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoEnglish[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.EnglishString = l_STLStringInfoEnglish;
                }
                #endregion

                #region Japanese
                // 复制Japanese字符串
                if ( ( languageKeep & Language.Japanese ) == Language.Japanese )
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.JapaneseString.Length > stbData2.JapaneseString.Length ? stbData1.JapaneseString : stbData2.JapaneseString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.JapaneseString.Length < stbData2.JapaneseString.Length ? stbData1.JapaneseString : stbData2.JapaneseString;
                    STLStringInfo[] l_STLStringInfoJapanese = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData1.JapaneseString )
                        {
                            l_STLStringInfoJapanese[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoJapanese[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoJapanese[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoJapanese[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoJapanese[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoJapanese[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoJapanese[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoJapanese[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoJapanese[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoJapanese[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoJapanese[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoJapanese[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoJapanese[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoJapanese[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoJapanese[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoJapanese[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoJapanese[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoJapanese[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoJapanese[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoJapanese[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoJapanese[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoJapanese[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoJapanese[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.JapaneseString = l_STLStringInfoJapanese;
                }
                else
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.JapaneseString.Length > stbData2.JapaneseString.Length ? stbData1.JapaneseString : stbData2.JapaneseString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.JapaneseString.Length < stbData2.JapaneseString.Length ? stbData1.JapaneseString : stbData2.JapaneseString;
                    STLStringInfo[] l_STLStringInfoJapanese = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData2.JapaneseString )
                        {
                            l_STLStringInfoJapanese[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoJapanese[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoJapanese[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoJapanese[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoJapanese[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoJapanese[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoJapanese[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoJapanese[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoJapanese[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoJapanese[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoJapanese[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoJapanese[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoJapanese[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoJapanese[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoJapanese[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoJapanese[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoJapanese[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoJapanese[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoJapanese[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoJapanese[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoJapanese[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoJapanese[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoJapanese[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.JapaneseString = l_STLStringInfoJapanese;
                }
                #endregion

                #region ChinaTaiwan
                // 复制ChinaTaiwan字符串
                if ( ( languageKeep & Language.ChinaTaiwan ) == Language.ChinaTaiwan )
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.ChinaTaiwanString.Length > stbData2.ChinaTaiwanString.Length ? stbData1.ChinaTaiwanString : stbData2.ChinaTaiwanString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.ChinaTaiwanString.Length < stbData2.ChinaTaiwanString.Length ? stbData1.ChinaTaiwanString : stbData2.ChinaTaiwanString;
                    STLStringInfo[] l_STLStringInfoChinaTaiwan = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData1.ChinaTaiwanString )
                        {
                            l_STLStringInfoChinaTaiwan[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoChinaTaiwan[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoChinaTaiwan[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoChinaTaiwan[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoChinaTaiwan[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoChinaTaiwan[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoChinaTaiwan[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoChinaTaiwan[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoChinaTaiwan[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoChinaTaiwan[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoChinaTaiwan[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.ChinaTaiwanString = l_STLStringInfoChinaTaiwan;
                }
                else
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.ChinaTaiwanString.Length > stbData2.ChinaTaiwanString.Length ? stbData1.ChinaTaiwanString : stbData2.ChinaTaiwanString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.ChinaTaiwanString.Length < stbData2.ChinaTaiwanString.Length ? stbData1.ChinaTaiwanString : stbData2.ChinaTaiwanString;
                    STLStringInfo[] l_STLStringInfoChinaTaiwan = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData2.ChinaTaiwanString )
                        {
                            l_STLStringInfoChinaTaiwan[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoChinaTaiwan[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoChinaTaiwan[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoChinaTaiwan[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoChinaTaiwan[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoChinaTaiwan[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoChinaTaiwan[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoChinaTaiwan[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoChinaTaiwan[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoChinaTaiwan[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoChinaTaiwan[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoChinaTaiwan[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoChinaTaiwan[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.ChinaTaiwanString = l_STLStringInfoChinaTaiwan;
                }
                #endregion

                #region China
                // 复制China字符串
                if ( ( languageKeep & Language.China ) == Language.China )
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.ChinaString.Length > stbData2.ChinaString.Length ? stbData1.ChinaString : stbData2.ChinaString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.ChinaString.Length < stbData2.ChinaString.Length ? stbData1.ChinaString : stbData2.ChinaString;
                    STLStringInfo[] l_STLStringInfoChina = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData1.ChinaString )
                        {
                            l_STLStringInfoChina[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoChina[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoChina[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoChina[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoChina[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoChina[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoChina[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoChina[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoChina[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoChina[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoChina[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoChina[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoChina[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoChina[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoChina[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoChina[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoChina[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoChina[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoChina[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoChina[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoChina[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoChina[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoChina[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.ChinaString = l_STLStringInfoChina;
                }
                else
                {
                    STLStringInfo[] l_MaxSTLStringInfo = stbData1.ChinaString.Length > stbData2.ChinaString.Length ? stbData1.ChinaString : stbData2.ChinaString;
                    STLStringInfo[] l_MinSTLStringInfo = stbData1.ChinaString.Length < stbData2.ChinaString.Length ? stbData1.ChinaString : stbData2.ChinaString;
                    STLStringInfo[] l_STLStringInfoChina = new STLStringInfo[l_MaxSTLStringInfo.Length];

                    for ( int iIndex = 0; iIndex < l_MaxSTLStringInfo.Length; iIndex++ )
                    {
                        if ( l_MaxSTLStringInfo == stbData2.ChinaString )
                        {
                            l_STLStringInfoChina[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                            l_STLStringInfoChina[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                            l_STLStringInfoChina[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                            l_STLStringInfoChina[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                            l_STLStringInfoChina[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                            l_STLStringInfoChina[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                            l_STLStringInfoChina[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                            l_STLStringInfoChina[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                        }
                        else
                        {
                            bool l_bIsFind = false;
                            for ( int iIndex1 = 0; iIndex1 < l_MinSTLStringInfo.Length; iIndex1++ )
                            {
                                if ( l_MaxSTLStringInfo[iIndex].StringID.ID == l_MinSTLStringInfo[iIndex1].StringID.ID
                                    && l_MaxSTLStringInfo[iIndex].StringID.StringID == l_MinSTLStringInfo[iIndex1].StringID.StringID )
                                {
                                    l_STLStringInfoChina[iIndex].String = l_MinSTLStringInfo[iIndex1].String;
                                    l_STLStringInfoChina[iIndex].IsStringComment = l_MinSTLStringInfo[iIndex1].IsStringComment;
                                    l_STLStringInfoChina[iIndex].StringComment = l_MinSTLStringInfo[iIndex1].StringComment;
                                    l_STLStringInfoChina[iIndex].IsStringOtherComment01 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment01;
                                    l_STLStringInfoChina[iIndex].StringOtherComment01 = l_MinSTLStringInfo[iIndex1].StringOtherComment01;
                                    l_STLStringInfoChina[iIndex].IsStringOtherComment02 = l_MinSTLStringInfo[iIndex1].IsStringOtherComment02;
                                    l_STLStringInfoChina[iIndex].StringOtherComment02 = l_MinSTLStringInfo[iIndex1].StringOtherComment02;

                                    l_bIsFind = true;

                                    break;
                                }
                            }

                            if ( l_bIsFind == false )
                            {
                                l_STLStringInfoChina[iIndex].StringID = l_MaxSTLStringInfo[iIndex].StringID;
                                l_STLStringInfoChina[iIndex].String = l_MaxSTLStringInfo[iIndex].String;
                                l_STLStringInfoChina[iIndex].IsStringComment = l_MaxSTLStringInfo[iIndex].IsStringComment;
                                l_STLStringInfoChina[iIndex].StringComment = l_MaxSTLStringInfo[iIndex].StringComment;
                                l_STLStringInfoChina[iIndex].IsStringOtherComment01 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment01;
                                l_STLStringInfoChina[iIndex].StringOtherComment01 = l_MaxSTLStringInfo[iIndex].StringOtherComment01;
                                l_STLStringInfoChina[iIndex].IsStringOtherComment02 = l_MaxSTLStringInfo[iIndex].IsStringOtherComment02;
                                l_STLStringInfoChina[iIndex].StringOtherComment02 = l_MaxSTLStringInfo[iIndex].StringOtherComment02;
                            }
                        }
                    }
                    stbCoalitionData.ChinaString = l_STLStringInfoChina;
                }
                #endregion
            }

            return true;
        }

        /// <summary>
        /// 读取STL文件,没有使用DataTable中的数据
        /// </summary>
        /// <param name="stbData"></param>
        /// <param name="strFileName"></param>
        public static bool SaveSTLData( STLData stbData, string strFileName )
        {
            try
            {
                FileStream l_FileStream = File.Open( strFileName, FileMode.Create );
                BinaryWriter l_FileWriter = new BinaryWriter( l_FileStream, Encoding.ASCII );

                byte[] l_byteArray;

                l_byteArray = Encoding.UTF8.GetBytes( stbData.FileType.FileType );
                l_FileWriter.Write( (byte)l_byteArray.Length );
                l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                l_FileWriter.Write( (uint)stbData.Length );

                for ( int iIndex = 0; iIndex < stbData.StringID.Length; iIndex++ )
                {
                    l_byteArray = Encoding.UTF8.GetBytes( stbData.StringID[iIndex].StringID );
                    l_FileWriter.Write( (byte)l_byteArray.Length );
                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    l_FileWriter.Write( stbData.StringID[iIndex].ID );
                }

                uint[] l_iFieldOffsetPositionLanguageArray = new uint[5]; // 5种语的偏移点
                l_FileWriter.Write( (uint)l_iFieldOffsetPositionLanguageArray.Length );

                uint l_iOffsetPositionLanguage = (uint)l_FileWriter.BaseStream.Position; // 5种语言开始的偏移点

                l_FileWriter.Seek( 4 * l_iFieldOffsetPositionLanguageArray.Length, SeekOrigin.Current ); // 跳过语言的偏移位置的数据　等计算完以后再写

                #region Korean
                //////////////////////////////////////////////////////////////////////////

                l_iFieldOffsetPositionLanguageArray[0] = (uint)l_FileWriter.BaseStream.Position; // 第一种语言的偏移点

                uint[] l_iFieldOffsetPositionKoreanArray = new uint[stbData.Length]; //  第一种语言的详细数据的偏移点

                l_FileWriter.Seek( 4 * l_iFieldOffsetPositionKoreanArray.Length, SeekOrigin.Current ); // 跳过第一种语言的详细数据的偏移位置　等计算完以后再写

                for ( int iIndex = 0; iIndex < stbData.KoreanString.Length; iIndex++ )
                {
                    l_iFieldOffsetPositionKoreanArray[iIndex] = (uint)l_FileWriter.BaseStream.Position;

                    l_byteArray = Encoding.UTF8.GetBytes( stbData.KoreanString[iIndex].String );
                    if ( l_byteArray.Length > 0x7F )
                    {
                        l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                        l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                    }
                    else l_FileWriter.Write( (byte)l_byteArray.Length );

                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                    if ( stbData.KoreanString[iIndex].IsStringComment )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.KoreanString[iIndex].StringComment );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.KoreanString[iIndex].IsStringOtherComment01 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.KoreanString[iIndex].StringOtherComment01 );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.KoreanString[iIndex].IsStringOtherComment02 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.KoreanString[iIndex].StringOtherComment02 );

                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }
                }

                uint l_iCurrentOffsetPosition = (uint)l_FileWriter.BaseStream.Position;

                l_FileWriter.Seek( (int)l_iFieldOffsetPositionLanguageArray[0], SeekOrigin.Begin ); // 跳到第一语言的偏移点位置

                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionKoreanArray.Length; iIndex++ )
                    l_FileWriter.Write( (uint)l_iFieldOffsetPositionKoreanArray[iIndex] );

                l_FileWriter.Seek( (int)l_iCurrentOffsetPosition, SeekOrigin.Begin ); // 返回原来文件的偏移点位置
                #endregion

                #region English
                //////////////////////////////////////////////////////////////////////////

                l_iFieldOffsetPositionLanguageArray[1] = (uint)l_FileWriter.BaseStream.Position; // 第2种语言的偏移点

                uint[] l_iFieldOffsetPositionEnglishArray = new uint[stbData.Length]; //  第2种语言的详细数据的偏移点

                l_FileWriter.Seek( 4 * l_iFieldOffsetPositionEnglishArray.Length, SeekOrigin.Current ); // 跳过第2种语言的详细数据的偏移位置　等计算完以后再写

                for ( int iIndex = 0; iIndex < stbData.EnglishString.Length; iIndex++ )
                {
                    l_iFieldOffsetPositionEnglishArray[iIndex] = (uint)l_FileWriter.BaseStream.Position;

                    l_byteArray = Encoding.UTF8.GetBytes( stbData.EnglishString[iIndex].String );
                    if ( l_byteArray.Length > 0x7F )
                    {
                        l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                        l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                    }
                    else l_FileWriter.Write( (byte)l_byteArray.Length );

                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                    if ( stbData.EnglishString[iIndex].IsStringComment )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.EnglishString[iIndex].StringComment );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.EnglishString[iIndex].IsStringOtherComment01 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.EnglishString[iIndex].StringOtherComment01 );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.EnglishString[iIndex].IsStringOtherComment02 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.EnglishString[iIndex].StringOtherComment02 );

                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }
                }

                l_iCurrentOffsetPosition = (uint)l_FileWriter.BaseStream.Position;

                l_FileWriter.Seek( (int)l_iFieldOffsetPositionLanguageArray[1], SeekOrigin.Begin ); // 跳到第一语言的偏移点位置

                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionEnglishArray.Length; iIndex++ )
                    l_FileWriter.Write( (uint)l_iFieldOffsetPositionEnglishArray[iIndex] );

                l_FileWriter.Seek( (int)l_iCurrentOffsetPosition, SeekOrigin.Begin ); // 返回原来文件的偏移点位置
                #endregion

                #region Japanese
                //////////////////////////////////////////////////////////////////////////

                l_iFieldOffsetPositionLanguageArray[2] = (uint)l_FileWriter.BaseStream.Position; // 第2种语言的偏移点

                uint[] l_iFieldOffsetPositionJapaneseArray = new uint[stbData.Length]; //  第2种语言的详细数据的偏移点

                l_FileWriter.Seek( 4 * l_iFieldOffsetPositionJapaneseArray.Length, SeekOrigin.Current ); // 跳过第2种语言的详细数据的偏移位置　等计算完以后再写

                for ( int iIndex = 0; iIndex < stbData.JapaneseString.Length; iIndex++ )
                {
                    l_iFieldOffsetPositionJapaneseArray[iIndex] = (uint)l_FileWriter.BaseStream.Position;

                    l_byteArray = Encoding.UTF8.GetBytes( stbData.JapaneseString[iIndex].String );
                    if ( l_byteArray.Length > 0x7F )
                    {
                        l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                        l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                    }
                    else l_FileWriter.Write( (byte)l_byteArray.Length );

                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                    if ( stbData.JapaneseString[iIndex].IsStringComment )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.JapaneseString[iIndex].StringComment );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.JapaneseString[iIndex].IsStringOtherComment01 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.JapaneseString[iIndex].StringOtherComment01 );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.JapaneseString[iIndex].IsStringOtherComment02 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.JapaneseString[iIndex].StringOtherComment02 );

                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }
                }

                l_iCurrentOffsetPosition = (uint)l_FileWriter.BaseStream.Position;

                l_FileWriter.Seek( (int)l_iFieldOffsetPositionLanguageArray[2], SeekOrigin.Begin ); // 跳到第一语言的偏移点位置

                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionJapaneseArray.Length; iIndex++ )
                    l_FileWriter.Write( (uint)l_iFieldOffsetPositionJapaneseArray[iIndex] );

                l_FileWriter.Seek( (int)l_iCurrentOffsetPosition, SeekOrigin.Begin ); // 返回原来文件的偏移点位置
                #endregion

                #region China-Taiwan
                //////////////////////////////////////////////////////////////////////////

                l_iFieldOffsetPositionLanguageArray[3] = (uint)l_FileWriter.BaseStream.Position; // 第2种语言的偏移点

                uint[] l_iFieldOffsetPositionChinaTaiwanArray = new uint[stbData.Length]; //  第2种语言的详细数据的偏移点

                l_FileWriter.Seek( 4 * l_iFieldOffsetPositionChinaTaiwanArray.Length, SeekOrigin.Current ); // 跳过第2种语言的详细数据的偏移位置　等计算完以后再写

                for ( int iIndex = 0; iIndex < stbData.ChinaTaiwanString.Length; iIndex++ )
                {
                    l_iFieldOffsetPositionChinaTaiwanArray[iIndex] = (uint)l_FileWriter.BaseStream.Position;

                    l_byteArray = Encoding.UTF8.GetBytes( stbData.ChinaTaiwanString[iIndex].String );
                    if ( l_byteArray.Length > 0x7F )
                    {
                        l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                        l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                    }
                    else l_FileWriter.Write( (byte)l_byteArray.Length );

                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                    if ( stbData.ChinaTaiwanString[iIndex].IsStringComment )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.ChinaTaiwanString[iIndex].StringComment );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.ChinaTaiwanString[iIndex].IsStringOtherComment01 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.ChinaTaiwanString[iIndex].StringOtherComment01 );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.ChinaTaiwanString[iIndex].IsStringOtherComment02 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.ChinaTaiwanString[iIndex].StringOtherComment02 );

                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }
                }

                l_iCurrentOffsetPosition = (uint)l_FileWriter.BaseStream.Position;

                l_FileWriter.Seek( (int)l_iFieldOffsetPositionLanguageArray[3], SeekOrigin.Begin ); // 跳到第一语言的偏移点位置

                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionChinaTaiwanArray.Length; iIndex++ )
                    l_FileWriter.Write( (uint)l_iFieldOffsetPositionChinaTaiwanArray[iIndex] );

                l_FileWriter.Seek( (int)l_iCurrentOffsetPosition, SeekOrigin.Begin ); // 返回原来文件的偏移点位置
                #endregion

                #region China
                //////////////////////////////////////////////////////////////////////////

                l_iFieldOffsetPositionLanguageArray[4] = (uint)l_FileWriter.BaseStream.Position; // 第2种语言的偏移点

                uint[] l_iFieldOffsetPositionChinaArray = new uint[stbData.Length]; //  第2种语言的详细数据的偏移点

                l_FileWriter.Seek( 4 * l_iFieldOffsetPositionChinaArray.Length, SeekOrigin.Current ); // 跳过第2种语言的详细数据的偏移位置　等计算完以后再写

                for ( int iIndex = 0; iIndex < stbData.ChinaString.Length; iIndex++ )
                {
                    l_iFieldOffsetPositionChinaArray[iIndex] = (uint)l_FileWriter.BaseStream.Position;

                    l_byteArray = Encoding.UTF8.GetBytes( stbData.ChinaString[iIndex].String );
                    if ( l_byteArray.Length > 0x7F )
                    {
                        l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                        l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                    }
                    else l_FileWriter.Write( (byte)l_byteArray.Length );

                    l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );

                    if ( stbData.ChinaString[iIndex].IsStringComment )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.ChinaString[iIndex].StringComment );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.ChinaString[iIndex].IsStringOtherComment01 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.ChinaString[iIndex].StringOtherComment01 );
                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }

                    if ( stbData.ChinaString[iIndex].IsStringOtherComment02 )
                    {
                        l_byteArray = Encoding.UTF8.GetBytes( stbData.ChinaString[iIndex].StringOtherComment02 );

                        if ( l_byteArray.Length > 0x7F )
                        {
                            l_FileWriter.Write( (byte)(( l_byteArray.Length & 0x000000FF ) | 0x80) );
                            l_FileWriter.Write( (byte)( l_byteArray.Length >> 7 ) );
                        }
                        else l_FileWriter.Write( (byte)l_byteArray.Length );

                        l_FileWriter.Write( l_byteArray, 0, l_byteArray.Length );
                    }
                }

                l_iCurrentOffsetPosition = (uint)l_FileWriter.BaseStream.Position;

                l_FileWriter.Seek( (int)l_iFieldOffsetPositionLanguageArray[4], SeekOrigin.Begin ); // 跳到第一语言的偏移点位置

                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionChinaArray.Length; iIndex++ )
                    l_FileWriter.Write( (uint)l_iFieldOffsetPositionChinaArray[iIndex] );

                l_FileWriter.Seek( (int)l_iCurrentOffsetPosition, SeekOrigin.Begin ); // 返回原来文件的偏移点位置
                #endregion

                l_iCurrentOffsetPosition = (uint)l_FileWriter.BaseStream.Position;

                l_FileWriter.Seek( (int)l_iOffsetPositionLanguage, SeekOrigin.Begin ); // 跳到第一语言的偏移点位置

                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionLanguageArray.Length; iIndex++ )
                    l_FileWriter.Write( (uint)l_iFieldOffsetPositionLanguageArray[iIndex] );

                l_FileWriter.Seek( (int)l_iCurrentOffsetPosition, SeekOrigin.Begin ); // 返回原来文件的偏移点位置

                l_FileWriter.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 读取STL文件,并创建DataTable且数据保存于其中
        /// </summary>
        /// <param name="stbData"></param>
        /// <param name="strFileName"></param>
        public static bool LoadSTLData( ref STLData stbData, string strFileName )
        {
            try
            {
                FileStream l_FileStream = File.OpenRead( strFileName );
                BinaryReader l_FileReader = new BinaryReader( l_FileStream, Encoding.ASCII );

                bool IsComment = false;

                stbData.m_strFileName = strFileName;

                STLFileType l_STLFileType = new STLFileType();
                l_STLFileType.m_strFileTypeLength   = l_FileReader.ReadByte();
                l_STLFileType.FileType = Encoding.ASCII.GetString( l_FileReader.ReadBytes( l_STLFileType.m_strFileTypeLength ) );
                stbData.m_STLFileType = l_STLFileType;

                stbData.m_iRowCount = l_FileReader.ReadUInt32();

                stbData.m_DataTable = new DataTable();
                stbData.m_DataTable.Columns.Add( "ID" );
                stbData.m_DataTable.Columns.Add( "StringID" );
                stbData.m_DataTable.Columns.Add( "Korean" );
                stbData.m_DataTable.Columns.Add( "Comment (Korean)" );
                stbData.m_DataTable.Columns.Add( "Other 1 (Korean)" );
                stbData.m_DataTable.Columns.Add( "Other 2 (Korean)" );
                stbData.m_DataTable.Columns.Add( "English" );
                stbData.m_DataTable.Columns.Add( "Comment (English)" );
                stbData.m_DataTable.Columns.Add( "Other 1 (English)" );
                stbData.m_DataTable.Columns.Add( "Other 2 (English)" );
                stbData.m_DataTable.Columns.Add( "Japanese" );
                stbData.m_DataTable.Columns.Add( "Comment (Japanese)" );
                stbData.m_DataTable.Columns.Add( "Other 1 (Japanese)" );
                stbData.m_DataTable.Columns.Add( "Other 2 (Japanese)" );
                stbData.m_DataTable.Columns.Add( "China-Taiwan" );
                stbData.m_DataTable.Columns.Add( "Comment (China-Taiwan)" );
                stbData.m_DataTable.Columns.Add( "Other 1 (China-Taiwan)" );
                stbData.m_DataTable.Columns.Add( "Other 2 (China-Taiwan)" );
                stbData.m_DataTable.Columns.Add( "China" );
                stbData.m_DataTable.Columns.Add( "Comment (China)" );
                stbData.m_DataTable.Columns.Add( "Other 1 (China)" );
                stbData.m_DataTable.Columns.Add( "Other 2 (China)" );

                for ( int iIndex = 0; iIndex < stbData.Length; iIndex++ )
                    stbData.m_DataTable.Rows.Add( stbData.m_DataTable.NewRow() );

                STLStringID[] l_STLStringIDArray = new STLStringID[stbData.Length];
                for ( int iIndex = 0; iIndex < l_STLStringIDArray.Length; iIndex++ )
                {
                    l_STLStringIDArray[iIndex].m_strStringIDLength = l_FileReader.ReadByte();
                    l_STLStringIDArray[iIndex].StringID = Encoding.UTF8.GetString( l_FileReader.ReadBytes( l_STLStringIDArray[iIndex].m_strStringIDLength ) );
                    stbData.m_DataTable.Rows[iIndex][0] = l_STLStringIDArray[iIndex].StringID;

                    l_STLStringIDArray[iIndex].ID = l_FileReader.ReadUInt32();
                    stbData.m_DataTable.Rows[iIndex][1] = l_STLStringIDArray[iIndex].ID;
                }
                stbData.StringID = l_STLStringIDArray;

                uint l_iFieldCount = l_FileReader.ReadUInt32();
                uint[] l_iFieldOffsetPositionLanguageArray = new uint[l_iFieldCount];
                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionLanguageArray.Length; iIndex++ )
                    l_iFieldOffsetPositionLanguageArray[iIndex] = l_FileReader.ReadUInt32();
                
                #region Korean
                /************************************************************************/
                /*                           Korean                                     */
                /************************************************************************/
                uint[] l_iFieldOffsetPositionKoreanArray = new uint[stbData.Length];
                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionKoreanArray.Length; iIndex++ )
                    l_iFieldOffsetPositionKoreanArray[iIndex] = l_FileReader.ReadUInt32();

                STLStringInfo[] l_STLStringInfoKoreanArray = new STLStringInfo[stbData.Length];
                for ( int iIndex = 0; iIndex < l_STLStringInfoKoreanArray.Length; iIndex++ )
                {
                    l_STLStringInfoKoreanArray[iIndex].m_iOffsetPosition = l_iFieldOffsetPositionKoreanArray[iIndex];
                    l_STLStringInfoKoreanArray[iIndex].StringID = stbData.StringID[iIndex];

                    l_STLStringInfoKoreanArray[iIndex].m_iStringLength = l_FileReader.ReadByte();

                    if ( l_STLStringInfoKoreanArray[iIndex].m_iStringLength > 0x7F )
                    {
                        uint l_iStringLength = l_FileReader.ReadByte();
                        l_STLStringInfoKoreanArray[iIndex].m_iStringLength = ( l_STLStringInfoKoreanArray[iIndex].m_iStringLength & 0x7F ) | ( l_iStringLength << 7 );
                    }

                    l_STLStringInfoKoreanArray[iIndex].String = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoKoreanArray[iIndex].m_iStringLength ) );
                    stbData.m_DataTable.Rows[iIndex][2] = l_STLStringInfoKoreanArray[iIndex].String;

                    if ( l_STLStringInfoKoreanArray.Length == 1 )
                    {
                        if ( l_iFieldOffsetPositionLanguageArray[1] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else if ( iIndex == ( l_STLStringInfoKoreanArray.Length - 1 ) )
                    {
                        if ( l_iFieldOffsetPositionLanguageArray[1] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else
                    {
                        if ( l_iFieldOffsetPositionKoreanArray[iIndex + 1] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                        else
                            IsComment = true;
                    }

                    if ( IsComment == true )
                    {
                        l_STLStringInfoKoreanArray[iIndex].IsStringComment = true;

                        l_STLStringInfoKoreanArray[iIndex].m_iStringCommentLength = l_FileReader.ReadByte();

                        if ( l_STLStringInfoKoreanArray[iIndex].m_iStringCommentLength > 0x7F )
                        {
                            uint l_iStringCommentLength = l_FileReader.ReadByte();
                            l_STLStringInfoKoreanArray[iIndex].m_iStringCommentLength = ( l_STLStringInfoKoreanArray[iIndex].m_iStringCommentLength & 0x7F ) | ( l_iStringCommentLength << 7 );
                        }

                        l_STLStringInfoKoreanArray[iIndex].StringComment = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoKoreanArray[iIndex].m_iStringCommentLength ) );
                        stbData.m_DataTable.Rows[iIndex][3] = l_STLStringInfoKoreanArray[iIndex].StringComment;

                        if ( iIndex == ( l_STLStringInfoKoreanArray.Length - 1 ) )
                        {
                            if ( l_iFieldOffsetPositionLanguageArray[1] > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoKoreanArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoKoreanArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][4] = l_STLStringInfoKoreanArray[iIndex].StringOtherComment01;

                                if ( l_iFieldOffsetPositionLanguageArray[1] > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoKoreanArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoKoreanArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][5] = l_STLStringInfoKoreanArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                        else
                        {
                            if ( l_iFieldOffsetPositionKoreanArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoKoreanArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoKoreanArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][4] = l_STLStringInfoKoreanArray[iIndex].StringOtherComment01;

                                if ( l_iFieldOffsetPositionKoreanArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoKoreanArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoKoreanArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoKoreanArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][5] = l_STLStringInfoKoreanArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                    }

                    stbData.StringID[iIndex].KoreanString = l_STLStringInfoKoreanArray[iIndex];
                }
                stbData.KoreanString = l_STLStringInfoKoreanArray;
                #endregion

                #region English
                /************************************************************************/
                /*                           English                                    */
                /************************************************************************/
                uint[] l_iFieldOffsetPositionEnglishArray = new uint[stbData.Length];
                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionEnglishArray.Length; iIndex++ )
                    l_iFieldOffsetPositionEnglishArray[iIndex] = l_FileReader.ReadUInt32();

                STLStringInfo[] l_STLStringInfoEnglishArray = new STLStringInfo[stbData.Length];
                for ( int iIndex = 0; iIndex < l_STLStringInfoEnglishArray.Length; iIndex++ )
                {
                    l_STLStringInfoEnglishArray[iIndex].m_iOffsetPosition = l_iFieldOffsetPositionEnglishArray[iIndex];
                    l_STLStringInfoEnglishArray[iIndex].StringID = stbData.StringID[iIndex];

                    l_STLStringInfoEnglishArray[iIndex].m_iStringLength = l_FileReader.ReadByte();

                    if ( l_STLStringInfoEnglishArray[iIndex].m_iStringLength > 0x7F )
                    {
                        uint l_iStringLength = l_FileReader.ReadByte();
                        l_STLStringInfoEnglishArray[iIndex].m_iStringLength = ( l_STLStringInfoEnglishArray[iIndex].m_iStringLength & 0x7F ) | ( l_iStringLength << 7 );
                    }

                    l_STLStringInfoEnglishArray[iIndex].String = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoEnglishArray[iIndex].m_iStringLength ) );
                    stbData.m_DataTable.Rows[iIndex][6] = l_STLStringInfoEnglishArray[iIndex].String;

                    if ( l_STLStringInfoEnglishArray.Length == 1 )
                    {
                        if ( l_iFieldOffsetPositionLanguageArray[2] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else if ( iIndex == ( l_STLStringInfoEnglishArray.Length - 1 ) )
                    {
                        if ( l_iFieldOffsetPositionLanguageArray[2] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else
                    {
                        if ( l_iFieldOffsetPositionEnglishArray[iIndex + 1] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                        else
                            IsComment = true;
                    }

                    if ( IsComment == true )
                    {
                        l_STLStringInfoEnglishArray[iIndex].IsStringComment = true;

                        l_STLStringInfoEnglishArray[iIndex].m_iStringCommentLength = l_FileReader.ReadByte();

                        if ( l_STLStringInfoEnglishArray[iIndex].m_iStringCommentLength > 0x7F )
                        {
                            uint l_iStringCommentLength = l_FileReader.ReadByte();
                            l_STLStringInfoEnglishArray[iIndex].m_iStringCommentLength = ( l_STLStringInfoEnglishArray[iIndex].m_iStringCommentLength & 0x7F ) | ( l_iStringCommentLength << 7 );
                        }

                        l_STLStringInfoEnglishArray[iIndex].StringComment = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoEnglishArray[iIndex].m_iStringCommentLength ) );
                        stbData.m_DataTable.Rows[iIndex][7] = l_STLStringInfoEnglishArray[iIndex].StringComment;

                        if ( iIndex == ( l_STLStringInfoEnglishArray.Length - 1 ) )
                        {
                            if ( l_iFieldOffsetPositionLanguageArray[2] > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoEnglishArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoEnglishArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][8] = l_STLStringInfoEnglishArray[iIndex].StringOtherComment01;

                                if ( l_iFieldOffsetPositionLanguageArray[2] > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoEnglishArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoEnglishArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][9] = l_STLStringInfoEnglishArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                        else
                        {
                            if ( l_iFieldOffsetPositionEnglishArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoEnglishArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoEnglishArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][8] = l_STLStringInfoEnglishArray[iIndex].StringOtherComment01;

                                if ( l_iFieldOffsetPositionEnglishArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoEnglishArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoEnglishArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoEnglishArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][9] = l_STLStringInfoEnglishArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                    }

                    stbData.StringID[iIndex].EnglishString = l_STLStringInfoEnglishArray[iIndex];
                }
                stbData.EnglishString = l_STLStringInfoEnglishArray;
                #endregion

                #region Japanese
                /************************************************************************/
                /*                           Japanese                                   */
                /************************************************************************/
                uint[] l_iFieldOffsetPositionJapaneseArray = new uint[stbData.Length];
                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionJapaneseArray.Length; iIndex++ )
                    l_iFieldOffsetPositionJapaneseArray[iIndex] = l_FileReader.ReadUInt32();

                STLStringInfo[] l_STLStringInfoJapaneseArray = new STLStringInfo[stbData.Length];
                for ( int iIndex = 0; iIndex < l_STLStringInfoJapaneseArray.Length; iIndex++ )
                {
                    l_STLStringInfoJapaneseArray[iIndex].m_iOffsetPosition = l_iFieldOffsetPositionJapaneseArray[iIndex];
                    l_STLStringInfoJapaneseArray[iIndex].StringID = stbData.StringID[iIndex];

                    l_STLStringInfoJapaneseArray[iIndex].m_iStringLength = l_FileReader.ReadByte();

                    if ( l_STLStringInfoJapaneseArray[iIndex].m_iStringLength > 0x7F )
                    {
                        uint l_iStringLength = l_FileReader.ReadByte();
                        l_STLStringInfoJapaneseArray[iIndex].m_iStringLength = ( l_STLStringInfoJapaneseArray[iIndex].m_iStringLength & 0x7F ) | ( l_iStringLength << 7 );
                    }

                    l_STLStringInfoJapaneseArray[iIndex].String = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoJapaneseArray[iIndex].m_iStringLength ) );
                    stbData.m_DataTable.Rows[iIndex][10] = l_STLStringInfoJapaneseArray[iIndex].String;

                    if ( l_STLStringInfoJapaneseArray.Length == 1 )
                    {
                        if ( l_iFieldOffsetPositionLanguageArray[3] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else if ( iIndex == ( l_STLStringInfoJapaneseArray.Length - 1 ) )
                    {
                        if ( l_iFieldOffsetPositionLanguageArray[3] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else
                    {
                        if ( l_iFieldOffsetPositionJapaneseArray[iIndex + 1] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                        else
                            IsComment = true;
                    }

                    if ( IsComment == true )
                    {
                        l_STLStringInfoJapaneseArray[iIndex].IsStringComment = true;

                        l_STLStringInfoJapaneseArray[iIndex].m_iStringCommentLength = l_FileReader.ReadByte();

                        if ( l_STLStringInfoJapaneseArray[iIndex].m_iStringCommentLength > 0x7F )
                        {
                            uint l_iStringCommentLength = l_FileReader.ReadByte();
                            l_STLStringInfoJapaneseArray[iIndex].m_iStringCommentLength = ( l_STLStringInfoJapaneseArray[iIndex].m_iStringCommentLength & 0x7F ) | ( l_iStringCommentLength << 7 );
                        }

                        l_STLStringInfoJapaneseArray[iIndex].StringComment = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoJapaneseArray[iIndex].m_iStringCommentLength ) );
                        stbData.m_DataTable.Rows[iIndex][11] = l_STLStringInfoJapaneseArray[iIndex].StringComment;

                        if ( iIndex == ( l_STLStringInfoJapaneseArray.Length - 1 ) )
                        {
                            if ( l_iFieldOffsetPositionLanguageArray[3] > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoJapaneseArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoJapaneseArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][12] = l_STLStringInfoJapaneseArray[iIndex].StringOtherComment01;

                                if ( l_iFieldOffsetPositionLanguageArray[3] > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoJapaneseArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoJapaneseArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][13] = l_STLStringInfoJapaneseArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                        else
                        {
                            if ( l_iFieldOffsetPositionJapaneseArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoJapaneseArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoJapaneseArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][12] = l_STLStringInfoJapaneseArray[iIndex].StringOtherComment01;

                                if ( l_iFieldOffsetPositionJapaneseArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoJapaneseArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoJapaneseArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoJapaneseArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][13] = l_STLStringInfoJapaneseArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                    }

                    stbData.StringID[iIndex].JapaneseString = l_STLStringInfoJapaneseArray[iIndex];
                }
                stbData.JapaneseString = l_STLStringInfoJapaneseArray;
                #endregion

                #region China-Taiwan
                /************************************************************************/
                /*                           China-Taiwan                               */
                /************************************************************************/
                uint[] l_iFieldOffsetPositionChinaTaiwanArray = new uint[stbData.Length];
                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionChinaTaiwanArray.Length; iIndex++ )
                    l_iFieldOffsetPositionChinaTaiwanArray[iIndex] = l_FileReader.ReadUInt32();

                STLStringInfo[] l_STLStringInfoChinaTaiwanArray = new STLStringInfo[stbData.Length];
                for ( int iIndex = 0; iIndex < l_STLStringInfoChinaTaiwanArray.Length; iIndex++ )
                {
                    l_STLStringInfoChinaTaiwanArray[iIndex].m_iOffsetPosition = l_iFieldOffsetPositionChinaTaiwanArray[iIndex];
                    l_STLStringInfoChinaTaiwanArray[iIndex].StringID = stbData.StringID[iIndex];

                    l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringLength = l_FileReader.ReadByte();

                    if ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringLength > 0x7F )
                    {
                        uint l_iStringLength = l_FileReader.ReadByte();
                        l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringLength = ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringLength & 0x7F ) | ( l_iStringLength << 7 );
                    }

                    l_STLStringInfoChinaTaiwanArray[iIndex].String = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringLength ) );
                    stbData.m_DataTable.Rows[iIndex][14] = l_STLStringInfoChinaTaiwanArray[iIndex].String;

                    if ( l_STLStringInfoChinaTaiwanArray.Length == 1 )
                    {
                        if ( l_iFieldOffsetPositionLanguageArray[4] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else if ( iIndex == ( l_STLStringInfoChinaTaiwanArray.Length - 1 ) )
                    {
                        if ( l_iFieldOffsetPositionLanguageArray[4] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else
                    {
                        if ( l_iFieldOffsetPositionChinaTaiwanArray[iIndex + 1] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                        else
                            IsComment = true;
                    }

                    if ( IsComment == true )
                    {
                        l_STLStringInfoChinaTaiwanArray[iIndex].IsStringComment = true;

                        l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringCommentLength = l_FileReader.ReadByte();

                        if ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringCommentLength > 0x7F )
                        {
                            uint l_iStringCommentLength = l_FileReader.ReadByte();
                            l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringCommentLength = ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringCommentLength & 0x7F ) | ( l_iStringCommentLength << 7 );
                        }

                        l_STLStringInfoChinaTaiwanArray[iIndex].StringComment = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringCommentLength ) );
                        stbData.m_DataTable.Rows[iIndex][15] = l_STLStringInfoChinaTaiwanArray[iIndex].StringComment;

                        if ( iIndex == ( l_STLStringInfoChinaTaiwanArray.Length - 1 ) )
                        {
                            if ( l_iFieldOffsetPositionLanguageArray[4] > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoChinaTaiwanArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoChinaTaiwanArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][16] = l_STLStringInfoChinaTaiwanArray[iIndex].StringOtherComment01;

                                if ( l_iFieldOffsetPositionLanguageArray[4] > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoChinaTaiwanArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoChinaTaiwanArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][17] = l_STLStringInfoChinaTaiwanArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                        else
                        {
                            if ( l_iFieldOffsetPositionChinaTaiwanArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoChinaTaiwanArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoChinaTaiwanArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][16] = l_STLStringInfoChinaTaiwanArray[iIndex].StringOtherComment01;

                                if ( l_iFieldOffsetPositionChinaTaiwanArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoChinaTaiwanArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoChinaTaiwanArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaTaiwanArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][17] = l_STLStringInfoChinaTaiwanArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                    }

                    stbData.StringID[iIndex].ChinaTaiwanString = l_STLStringInfoChinaTaiwanArray[iIndex];
                }
                stbData.ChinaTaiwanString = l_STLStringInfoChinaTaiwanArray;
                #endregion

                #region China
                /************************************************************************/
                /*                           China                                      */
                /************************************************************************/
                uint[] l_iFieldOffsetPositionChinaArray = new uint[stbData.Length];
                for ( int iIndex = 0; iIndex < l_iFieldOffsetPositionChinaArray.Length; iIndex++ )
                    l_iFieldOffsetPositionChinaArray[iIndex] = l_FileReader.ReadUInt32();

                STLStringInfo[] l_STLStringInfoChinaArray = new STLStringInfo[stbData.Length];
                for ( int iIndex = 0; iIndex < l_STLStringInfoChinaArray.Length; iIndex++ )
                {
                    l_STLStringInfoChinaArray[iIndex].m_iOffsetPosition = l_iFieldOffsetPositionChinaArray[iIndex];
                    l_STLStringInfoChinaArray[iIndex].StringID = stbData.StringID[iIndex];

                    l_STLStringInfoChinaArray[iIndex].m_iStringLength = l_FileReader.ReadByte();

                    if ( l_STLStringInfoChinaArray[iIndex].m_iStringLength > 0x7F )
                    {
                        uint l_iStringLength = l_FileReader.ReadByte();
                        l_STLStringInfoChinaArray[iIndex].m_iStringLength = ( l_STLStringInfoChinaArray[iIndex].m_iStringLength & 0x7F ) | ( l_iStringLength << 7 );
                    }

                    l_STLStringInfoChinaArray[iIndex].String = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaArray[iIndex].m_iStringLength ) );
                    stbData.m_DataTable.Rows[iIndex][18] = l_STLStringInfoChinaArray[iIndex].String;

                    if ( l_STLStringInfoChinaArray.Length == 1 )
                    {
                        if ( l_FileReader.BaseStream.Length <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else if ( iIndex == ( l_STLStringInfoChinaArray.Length - 1 ) )
                    {
                        if ( l_FileReader.BaseStream.Length <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                    }
                    else
                    {
                        if ( l_iFieldOffsetPositionChinaArray[iIndex + 1] <= l_FileReader.BaseStream.Position )
                            IsComment = false;
                        else
                            IsComment = true;
                    }

                    if ( IsComment == true )
                    {
                        l_STLStringInfoChinaArray[iIndex].IsStringComment = true;

                        l_STLStringInfoChinaArray[iIndex].m_iStringCommentLength = l_FileReader.ReadByte();

                        if ( l_STLStringInfoChinaArray[iIndex].m_iStringCommentLength > 0x7F )
                        {
                            uint l_iStringCommentLength = l_FileReader.ReadByte();
                            l_STLStringInfoChinaArray[iIndex].m_iStringCommentLength = ( l_STLStringInfoChinaArray[iIndex].m_iStringCommentLength & 0x7F ) | ( l_iStringCommentLength << 7 );
                        }

                        l_STLStringInfoChinaArray[iIndex].StringComment = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaArray[iIndex].m_iStringCommentLength ) );
                        stbData.m_DataTable.Rows[iIndex][19] = l_STLStringInfoChinaArray[iIndex].StringComment;

                        if ( iIndex == ( l_STLStringInfoChinaArray.Length - 1 ) )
                        {
                            if ( l_FileReader.BaseStream.Length > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoChinaArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoChinaArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][20] = l_STLStringInfoChinaArray[iIndex].StringOtherComment01;

                                if ( l_FileReader.BaseStream.Length > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoChinaArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoChinaArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][21] = l_STLStringInfoChinaArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                        else
                        {
                            if ( l_iFieldOffsetPositionChinaArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                            {
                                l_STLStringInfoChinaArray[iIndex].IsStringOtherComment01 = true;

                                l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length = l_FileReader.ReadByte();

                                if ( l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length > 0x7F )
                                {
                                    uint iStringCommentLength = l_FileReader.ReadByte();
                                    l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length = ( l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length & 0x7F ) | ( iStringCommentLength << 7 );
                                }

                                l_STLStringInfoChinaArray[iIndex].StringOtherComment01 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment01Length ) );
                                stbData.m_DataTable.Rows[iIndex][20] = l_STLStringInfoChinaArray[iIndex].StringOtherComment01;

                                if ( l_iFieldOffsetPositionChinaArray[iIndex + 1] > l_FileReader.BaseStream.Position )
                                {
                                    l_STLStringInfoChinaArray[iIndex].IsStringOtherComment02 = true;

                                    l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length = l_FileReader.ReadByte();

                                    if ( l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length > 0x7F )
                                    {
                                        uint iStringCommentLength = l_FileReader.ReadByte();
                                        l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length = ( l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length & 0x7F ) | ( iStringCommentLength << 7 );
                                    }

                                    l_STLStringInfoChinaArray[iIndex].StringOtherComment02 = Encoding.UTF8.GetString( l_FileReader.ReadBytes( (int)l_STLStringInfoChinaArray[iIndex].m_iStringOtherComment02Length ) );
                                    stbData.m_DataTable.Rows[iIndex][21] = l_STLStringInfoChinaArray[iIndex].StringOtherComment02;
                                }
                            }
                        }
                    }

                    stbData.StringID[iIndex].ChinaString = l_STLStringInfoChinaArray[iIndex];
                }
                stbData.ChinaString = l_STLStringInfoChinaArray;
                #endregion

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

