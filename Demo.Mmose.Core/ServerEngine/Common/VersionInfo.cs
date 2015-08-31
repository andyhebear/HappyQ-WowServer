#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Collections;
using System.Text;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class VersionInfo : IComparable, IComparer
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMajor"></param>
        /// <param name="iMinor"></param>
        /// <param name="iRevision"></param>
        /// <param name="iPatch"></param>
        public VersionInfo( int iMajor, int iMinor, int iRevision, int iPatch )
        {
            m_Major         = iMajor;
            m_Minor         = iMinor;
            m_Revision      = iRevision;
            m_Patch         = iPatch;


            StringBuilder strBuilder = new StringBuilder( 16 );

            strBuilder.Append( m_Major );
            strBuilder.Append( '.' );
            strBuilder.Append( m_Minor );
            strBuilder.Append( '.' );
            strBuilder.Append( m_Revision );

            if ( m_Patch > 0 )
                strBuilder.Append( (char)( 'a' + ( m_Patch - 1 ) ) );

            m_SourceString = strBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFormat"></param>
        public VersionInfo( string strFormat )
        {
            try
            {
                strFormat = strFormat.ToLower();

                int iIndexOf1 = strFormat.IndexOf( '.' );
                int iIndexOf2 = strFormat.IndexOf( '.', iIndexOf1 + 1 );
                int iIndexOf3 = iIndexOf2 + 1;

                while ( iIndexOf3 < strFormat.Length && Char.IsDigit( strFormat, iIndexOf3 ) )
                    iIndexOf3++;

                m_Major = ConvertString.ToInt32( strFormat.Substring( 0, iIndexOf1 ) );
                m_Minor = ConvertString.ToInt32( strFormat.Substring( iIndexOf1 + 1, iIndexOf2 - iIndexOf1 - 1 ) );
                m_Revision = ConvertString.ToInt32( strFormat.Substring( iIndexOf2 + 1, iIndexOf3 - iIndexOf2 - 1 ) );

                if ( iIndexOf3 < strFormat.Length && !Char.IsWhiteSpace( strFormat, iIndexOf3 ) )
                    m_Patch = ( strFormat[iIndexOf3] - 'a' ) + 1;
                else
                    m_Patch = 0;

                m_SourceString = strFormat;
            }
            catch
            {
                m_Major = 0;
                m_Minor = 0;
                m_Revision = 0;
                m_Patch = 0;
                m_SourceString = string.Empty;
            }
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Major;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Major
        {
            get { return m_Major; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Minor;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Minor
        {
            get { return m_Minor; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Revision;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Revision
        {
            get { return m_Revision; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Patch;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Patch
        {
            get { return m_Patch; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_SourceString;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string SourceString
        {
            get { return m_SourceString; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return m_Major ^ m_Minor ^ m_Revision ^ m_Patch;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            if ( IsNull( xObject ) )
                return false;

            VersionInfo xClientVersion = xObject as VersionInfo;

            if ( IsNull( xClientVersion ) )
                return false;

            return m_Major == xClientVersion.m_Major        &&
                   m_Minor == xClientVersion.m_Minor        &&
                   m_Revision == xClientVersion.m_Revision  &&
                   m_Patch == xClientVersion.m_Patch;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_SourceString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public int CompareTo( object xObject )
        {
            if ( IsNull( xObject ) )
                return 1;

            VersionInfo xClientVersion = xObject as VersionInfo;

            if ( IsNull( xClientVersion ) )
                throw new ArgumentException();

            if ( m_Major > xClientVersion.m_Major )
                return 1;
            else if ( m_Major < xClientVersion.m_Major )
                return -1;
            else if ( m_Minor > xClientVersion.m_Minor )
                return 1;
            else if ( m_Minor < xClientVersion.m_Minor )
                return -1;
            else if ( m_Revision > xClientVersion.m_Revision )
                return 1;
            else if ( m_Revision < xClientVersion.m_Revision )
                return -1;
            else if ( m_Patch > xClientVersion.m_Patch )
                return 1;
            else if ( m_Patch < xClientVersion.m_Patch )
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <param name="yObject"></param>
        /// <returns></returns>
        public int Compare( object xObject, object yObject )
        {
            if ( IsNull( xObject ) && IsNull( yObject ) )
                return 0;
            else if ( IsNull( xObject ) )
                return -1;
            else if ( IsNull( yObject ) )
                return 1;

            VersionInfo xClientVersion = xObject as VersionInfo;
            VersionInfo yClientVersion = yObject as VersionInfo;

            if ( IsNull( xClientVersion ) || IsNull( yClientVersion ) )
                throw new ArgumentException();

            return xClientVersion.CompareTo( yClientVersion );
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xClientVersion"></param>
        /// <param name="yClientVersion"></param>
        /// <returns></returns>
        public static bool operator ==( VersionInfo xClientVersion, VersionInfo yClientVersion )
        {
            return ( Compare( xClientVersion, yClientVersion ) == 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xClientVersion"></param>
        /// <param name="yClientVersion"></param>
        /// <returns></returns>
        public static bool operator !=( VersionInfo xClientVersion, VersionInfo yClientVersion )
        {
            return ( Compare( xClientVersion, yClientVersion ) != 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xClientVersion"></param>
        /// <param name="yClientVersion"></param>
        /// <returns></returns>
        public static bool operator >=( VersionInfo xClientVersion, VersionInfo yClientVersion )
        {
            return ( Compare( xClientVersion, yClientVersion ) >= 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xClientVersion"></param>
        /// <param name="yClientVersion"></param>
        /// <returns></returns>
        public static bool operator >( VersionInfo xClientVersion, VersionInfo yClientVersion )
        {
            return ( Compare( xClientVersion, yClientVersion ) > 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xClientVersion"></param>
        /// <param name="yClientVersion"></param>
        /// <returns></returns>
        public static bool operator <=( VersionInfo xClientVersion, VersionInfo yClientVersion )
        {
            return ( Compare( xClientVersion, yClientVersion ) <= 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xClientVersion"></param>
        /// <param name="yClientVersion"></param>
        /// <returns></returns>
        public static bool operator <( VersionInfo xClientVersion, VersionInfo yClientVersion )
        {
            return ( Compare( xClientVersion, yClientVersion ) < 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xClientVersion"></param>
        /// <param name="yClientVersion"></param>
        /// <returns></returns>
        public static int Compare( VersionInfo xClientVersion, VersionInfo yClientVersion )
        {
            if ( IsNull( xClientVersion ) && IsNull( yClientVersion ) )
                return 0;
            else if ( IsNull( xClientVersion ) )
                return -1;
            else if ( IsNull( yClientVersion ) )
                return 1;

            return xClientVersion.CompareTo( yClientVersion );
        }
        #endregion

        #region zh-CHS 私有静态方法 | en Private Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsNull( object xObject )
        {
            return Object.ReferenceEquals( xObject, null );
        }
        #endregion
    }
}
#endregion

