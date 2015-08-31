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
using System.Collections.Generic;
using System.IO;
#endregion

namespace Demo.Mmose.Stream
{
    /// <summary>
    /// 
    /// </summary>
    public class VirtualFileManager
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private IStreamArchive[] m_StreamArchives = new IStreamArchive[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public IStreamArchive[] StreamArchives
        {
            get { return m_StreamArchives; }
        }
        #endregion

        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 全局显示信息的字符串
        /// </summary>
        private static VirtualFileManager s_VirtualFileManager = new VirtualFileManager();
        #endregion
        /// <summary>
        /// 全局显示信息的字符串
        /// </summary>
        public static VirtualFileManager SingletonInstance
        {
            get { return s_VirtualFileManager; }
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private IStreamArchive[] m_PackageArchives = new IStreamArchive[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public VirtualStream OpenFile( string strFileName, FileAccess fileAccess )
        {
            if ( String.IsNullOrEmpty( strFileName ) == true )
                throw new Exception( "VirtualFileManager.OpenFile(...) - String.IsNullOrEmpty() == true error!" );

            for ( int iIndex = 0; iIndex < m_PackageArchives.Length; ++iIndex )
            {
                IStreamArchive streamArchive = m_PackageArchives[iIndex];

                VirtualStream virtualStream = streamArchive.OpenFile( strFileName, fileAccess );

                if ( virtualStream == null )
                    continue;
                else
                    return virtualStream;
            }

            return FileArchive.SingletonInstance.OpenFile( strFileName, fileAccess );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFilePath"></param>
        public bool RegisterPackage( string strPackageFile )
        {
            if ( String.IsNullOrEmpty( strPackageFile ) == true )
                throw new Exception( "VirtualFileManager.RegisterPackage(...) - String.IsNullOrEmpty() == true error!" );

            for ( int iIndex = 0; iIndex < m_StreamArchives.Length; ++iIndex )
            {
                IStreamArchive streamArchive = m_StreamArchives[iIndex];

                if ( streamArchive.OpenPackage( strPackageFile ) == false )
                    continue;
                else
                {
                    streamArchive.ClosePackage();

                    IStreamArchive streamArchiveNew = streamArchive.CreateInstance();
                    if ( streamArchiveNew == null )
                        return false;

                    if ( streamArchiveNew.OpenPackage( strPackageFile ) == false )
                        return false;

                    IStreamArchive[] tempStream = new IStreamArchive[m_PackageArchives.Length + 1];

                    tempStream[0] = streamArchiveNew;

                    for ( int iIndex2 = 0; iIndex2 < m_PackageArchives.Length; ++iIndex2 )
                        tempStream[iIndex2 + 1] = m_PackageArchives[iIndex2];

                    m_PackageArchives = tempStream;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFilePath"></param>
        public void UnRegisterPackage( string strPackageFile )
        {
            if ( String.IsNullOrEmpty(strPackageFile) == true )
                throw new Exception( "VirtualFileManager.UnRegisterPackage(...) - String.IsNullOrEmpty() == true error!" );

            List<IStreamArchive> streamArchiveList = new List<IStreamArchive>( m_PackageArchives.Length );

            bool bIsFind = false;
            for ( int iIndex = 0; iIndex < m_PackageArchives.Length; ++iIndex )
            {
                IStreamArchive streamArchive = m_PackageArchives[iIndex];

                if ( streamArchive.PackageName == strPackageFile )
                {
                    bIsFind = true;
                    streamArchive.ClosePackage();
                }
                else
                    streamArchiveList.Add( streamArchive );
            }

            if ( bIsFind == true )
                m_PackageArchives = streamArchiveList.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamArchive"></param>
        public void RegisterStreamArchive( IStreamArchive streamArchive )
        {
            if ( streamArchive == null )
                throw new Exception( "VirtualFileManager.RegisterStreamArchive(...) - streamArchive == null error!" );

            IStreamArchive[] tempStream = new IStreamArchive[m_StreamArchives.Length + 1];

            for ( int iIndex = 0; iIndex < m_StreamArchives.Length; ++iIndex )
                tempStream[iIndex] = m_StreamArchives[iIndex];
            tempStream[m_StreamArchives.Length] = streamArchive;

            m_StreamArchives = tempStream;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamArchive"></param>
        public void UnRegisterStreamArchive( IStreamArchive streamArchive )
        {
            if ( streamArchive == null )
                throw new Exception( "VirtualFileManager.UnRegisterStreamArchive(...) - streamArchive == null error!" );

            List<IStreamArchive> streamArchiveList = new List<IStreamArchive>();

            foreach ( IStreamArchive itemStream in m_StreamArchives )
            {
                if ( itemStream != streamArchive )
                    streamArchiveList.Add( itemStream );
            }

            m_StreamArchives = streamArchiveList.ToArray();
        }
    }
}
#endregion