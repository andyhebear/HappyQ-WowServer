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
using System.IO;
#endregion

namespace Demo.Mmose.Stream
{
    /// <summary>
    /// 
    /// </summary>
    internal class FileArchive : IStreamArchive
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 全局显示信息的字符串
        /// </summary>
        private static FileArchive s_FileArchive = new FileArchive();
        #endregion
        /// <summary>
        /// 全局显示信息的字符串
        /// </summary>
        public static FileArchive SingletonInstance
        {
            get { return s_FileArchive; }
        }
        #endregion

        #region zh-CHS IStreamArchive 实现 | en IStreamArchive Implementation

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_PackageName = ".\\";
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string PackageName
        {
            get { return m_PackageName; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="fileAccess"></param>
        /// <returns></returns>
        public VirtualStream OpenFile( string strFileName, FileAccess fileAccess )
        {
            return FileVirtualStream.OpenFile( m_PackageName + strFileName, fileAccess );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public VirtualStream CreateFile( string strFileName )
        {
            return FileVirtualStream.CreateFile( m_PackageName + strFileName );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        public void DeleteFile( string strFileName )
        {
            File.Delete( strFileName );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strArchiveName"></param>
        /// <returns></returns>
        public bool OpenPackage( string strArchivePath )
        {
            m_PackageName = strArchivePath;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strArchiveName"></param>
        /// <returns></returns>
        public bool CreatePackage( string strArchivePath )
        {
            if ( Directory.Exists(strArchivePath) == true )
            {
                m_PackageName = strArchivePath;
                return true;
            }

            DirectoryInfo directoryInfo = Directory.CreateDirectory( strArchivePath );
            if ( directoryInfo == null )
                return false;

            if ( directoryInfo.Exists == true )
            {
                m_PackageName = strArchivePath;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClosePackage()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IStreamArchive CreateInstance()
        {
            return this;
        }
        #endregion

        #endregion
    }
}
#endregion