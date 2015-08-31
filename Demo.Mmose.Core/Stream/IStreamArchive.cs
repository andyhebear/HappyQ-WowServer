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
    public interface IStreamArchive
    {
        #region zh-CHS 接口 | en Interface
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="fileAccess"></param>
        /// <returns></returns>
        VirtualStream OpenFile( string strFileName, FileAccess fileAccess );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        VirtualStream CreateFile( string strFileName );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        void DeleteFile( string strFileName );

        /// <summary>
        /// 
        /// </summary>
        string PackageName { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strArchiveName"></param>
        /// <returns></returns>
        bool OpenPackage( string strArchiveName );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strArchiveName"></param>
        /// <returns></returns>
        bool CreatePackage( string strArchiveName );
        /// <summary>
        /// 
        /// </summary>
        void ClosePackage();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IStreamArchive CreateInstance();
        #endregion
    }
}
#endregion