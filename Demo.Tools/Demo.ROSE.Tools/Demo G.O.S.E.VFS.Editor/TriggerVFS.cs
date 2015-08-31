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
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#endregion

namespace Demo_G.O.S.E.VFS.Editor
{
    public class TriggerVFS
    {
        #region zh-CHS 结构 | en Struct
        [StructLayout( LayoutKind.Sequential )]
        public struct FileInfo
        {
            #region zh-CHS 成员变量 | en Member Variables
            public int m_iAttribute;
            public uint m_iChecksum;
            #endregion
        };

        public struct FileTree
        {
            #region zh-CHS 成员变量 | en Member Variables
            public uint m_iFileCount;
            public string[] m_strFiles;
            #endregion
        };
        #endregion

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iHandle = 0;
        /// <summary>
        /// 
        /// </summary>
        private uint m_iVfsCount = 0;
        /// <summary>
        /// 
        /// </summary>
        private string[] m_strVfsNames = new string[0];
        /// <summary>
        /// 
        /// </summary>
        private FileTree[] m_FileTree = new FileTree[0];
        #endregion

        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 
        /// </summary>
        public uint VFSCount
        {
            get { return m_iVfsCount; }
            set { m_iVfsCount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string[] VFSNames
        {
            get { return m_strVfsNames; }
            set { m_strVfsNames = value; }
        }

        public FileTree[] FileTreeArray
        {
            get { return m_FileTree; }
            set { m_FileTree = value; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIndexFile">文件名"data.idx"</param>
        /// <param name="bReadOnly"></param>
        /// <returns></returns>
        public bool OpenIndex( string strIndexFile, bool bReadOnly )
        {
            string strMode = string.Empty;
            if ( bReadOnly == true )
                strMode = "r";
            else
                strMode = "r+";

            m_iHandle = OpenVFS( strIndexFile, strMode );
            if ( m_iHandle == 0 )
                return false;

            m_iVfsCount = VGetVfsCount( m_iHandle );
            if ( m_iVfsCount == 0 )
                return false;

            m_iVfsCount--; // 移去讨厌的 ROOT.VFS | Remove the damned ROOT.VFS 

            m_strVfsNames = new string[m_iVfsCount];

            IntPtr l_strPtrVfsNames = Marshal.AllocHGlobal ((int)(IntPtr.Size * m_iVfsCount));
            for ( int iIndex = 0; iIndex < m_strVfsNames.Length; iIndex++ )
            {
                IntPtr l_PtrOffset = new IntPtr( l_strPtrVfsNames.ToInt64() + iIndex * IntPtr.Size );
                IntPtr l_strPtrVfsName = Marshal.AllocHGlobal( (int)260 ); // MAX_PATH == 260
                Marshal.WriteIntPtr( l_PtrOffset, l_strPtrVfsName );
            }

            VGetVfsNames( m_iHandle, l_strPtrVfsNames, m_iVfsCount, 260 );

            for ( int iIndex = 0; iIndex < m_strVfsNames.Length; iIndex++ )
            {
                IntPtr l_PtrOffset = new IntPtr(l_strPtrVfsNames.ToInt64() + iIndex*IntPtr.Size);
                IntPtr l_strPtrVfsName = Marshal.ReadIntPtr( l_PtrOffset );
                m_strVfsNames[iIndex] = Marshal.PtrToStringAnsi( l_strPtrVfsName );

                Marshal.FreeHGlobal( l_strPtrVfsName );
            }
            Marshal.FreeHGlobal( l_strPtrVfsNames );

            m_FileTree = new FileTree[m_iVfsCount];
            for ( int iIndex = 0; iIndex < m_FileTree.Length; iIndex++ )
            {
                m_FileTree[iIndex].m_iFileCount = VGetFileCount( m_iHandle, m_strVfsNames[iIndex] );

                m_FileTree[iIndex].m_strFiles = new string[m_FileTree[iIndex].m_iFileCount];

                IntPtr l_strPtrFiles = Marshal.AllocHGlobal( (int)( IntPtr.Size * m_FileTree[iIndex].m_iFileCount ) );
                for ( int iIndex2 = 0; iIndex2 < m_FileTree[iIndex].m_iFileCount; iIndex2++ )
                {
                    IntPtr l_PtrOffset = new IntPtr( l_strPtrFiles.ToInt64() + iIndex2 * IntPtr.Size );
                    IntPtr l_strPtrFile = Marshal.AllocHGlobal( (int)260 ); // MAX_PATH == 260
                    Marshal.WriteIntPtr( l_PtrOffset, l_strPtrFile );
                }

                VGetFileNames( m_iHandle, m_strVfsNames[iIndex], l_strPtrFiles, m_FileTree[iIndex].m_iFileCount, 260 );

                for ( int iIndex3 = 0; iIndex3 < m_FileTree[iIndex].m_iFileCount; iIndex3++ )
                {
                    IntPtr l_PtrOffset = new IntPtr( l_strPtrFiles.ToInt64() + iIndex3 * IntPtr.Size );
                    IntPtr l_strPtrFile = Marshal.ReadIntPtr( l_PtrOffset );
                    m_FileTree[iIndex].m_strFiles[iIndex3] = Marshal.PtrToStringAnsi( l_strPtrFile );

                    Marshal.FreeHGlobal( l_strPtrFile );
                }
                Marshal.FreeHGlobal( l_strPtrFiles );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint GetCurrentVersion()
        {
            return VGetCurVersion( m_iHandle );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint GetTotalFileCount()
        {
            return VGetTotFileCount( m_iHandle );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public bool GetFileInfo( string strFileName, ref FileInfo fileInfo )
        {
            uint iSomeHandle = VFileExists( m_iHandle, strFileName );

            if ( ( iSomeHandle & 0xFF ) != 0x0 ) // 如果最后两位为零的话代表文件不存在
            {
                VGetFileInfo( m_iHandle, strFileName, ref fileInfo, iSomeHandle );
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public bool SetFileInfo( string strFileName, ref FileInfo fileInfo )
        {
            uint iSomeHandle = VFileExists( m_iHandle, strFileName );

            if ( ( iSomeHandle & 0xFF ) != 0x0 ) // 如果最后两位为零的话代表文件不存在
            {
                VSetFileInfo( m_iHandle, strFileName, ref fileInfo );
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strVfsName"></param>
        /// <param name="bCreate"></param>
        /// <returns></returns>
        public bool AddVFS( string strVfsName, bool bCreate )
        {
            if ( File.Exists( strVfsName ) == false )
            {
                if ( bCreate == true )
                {
                    FileStream l_FileStream = File.Open( strVfsName, FileMode.Create );
                    l_FileStream.Close();
                }
            }

            uint iReturn = VAddVfs(m_iHandle, strVfsName);

            return iReturn == 0 ? false : true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strLocalPath"></param>
        /// <param name="strVfspath"></param>
        /// <param name="strTovfs"></param>
        /// <returns></returns>
        public uint AddFile( string strLocalPath, string strVfspath, string strTovfs )
        {
            FileInfo l_FileInfo = new FileInfo();
            if ( GetFileInfo( strVfspath, ref l_FileInfo ) == true )
                RemoveFile( strVfspath );

            l_FileInfo.m_iAttribute = 0xD3; // Meh, it works fine :) 
            l_FileInfo.m_iChecksum = 0x0;

            return VAddFile( m_iHandle, strTovfs, strLocalPath, strVfspath, (uint)l_FileInfo.m_iAttribute, l_FileInfo.m_iChecksum, 0, 0, 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ushort GetLastError()
        {
            return VGetError();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strVfspath"></param>
        /// <returns></returns>
        public bool RemoveFile( string strVfspath )
        {
            return VRemoveFile( m_iHandle, strVfspath ) == 0 ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public uint GetFileSize( string strFileName )
        {
            uint iFileHandle = VOpenFile( strFileName, m_iHandle );
            uint iSize = VFGetSize( iFileHandle );
            VCloseFile( iFileHandle );

            return iSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public uint GetFileLength( string strFileName )
        {
            return VGetFileLength( m_iHandle, strFileName );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="strLocalFile"></param>
        /// <returns></returns>
        public bool ExtractFile( string strFileName, string strLocalFile )
        {
            uint iFileHandle = VOpenFile( strFileName, m_iHandle );
            if ( iFileHandle == 0 )
                return false;

            uint iSize = VFGetSize( iFileHandle );
            if ( iFileHandle <= 0 )
            {
                VCloseFile( iFileHandle );
                return false;
            }

            IntPtr l_PtrBuffer = Marshal.AllocHGlobal( (int)iSize );
            if ( VFRead( l_PtrBuffer, 1, iSize, iFileHandle ) == iSize )
            {
                VCloseFile( iFileHandle );

                FileStream l_FileStream = File.Open( strLocalFile, FileMode.Create );
                BinaryWriter l_FileWriter = new BinaryWriter( l_FileStream, Encoding.ASCII );

                byte[] l_Buffer = new byte[iSize];
                Marshal.Copy( l_PtrBuffer, l_Buffer, 0, (int)iSize );

                l_FileWriter.Write( l_Buffer );
                l_FileWriter.Close();

                return true;
            }
            Marshal.FreeHGlobal( l_PtrBuffer );

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseIndex()
        {
            CloseVFS( m_iHandle );
            m_iHandle = 0;
        }
        #endregion

        #region zh-CHS 引入DLL接口 | en DLL Import
        [DllImport( "TriggerVFS.dll", EntryPoint = "_OpenVFS@8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi  )]
        private static extern uint OpenVFS( string idxFile, string strMode );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_CloseVFS@4", CallingConvention = CallingConvention.StdCall )]
        private static extern uint CloseVFS( uint iHandle );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VGetVfsCount@4", CallingConvention = CallingConvention.StdCall )]
        private static extern uint VGetVfsCount( uint iHandle );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VGetVfsNames@16", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi )]
        private static extern void VGetVfsNames( uint iHandle, IntPtr strNames, uint iMaxCount, uint iMaxlen );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VGetFileCount@8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi )]
        private static extern uint VGetFileCount( uint iHandle, string strVfsfile );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VGetFileNames@20", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi )]
        private static extern void VGetFileNames( uint iHandle, string strName, IntPtr strFiles, uint iMaxFiles, uint iMaxLen );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VGetCurVersion@4", CallingConvention = CallingConvention.StdCall )]
        private static extern uint VGetCurVersion( uint iHandle );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VGetTotFileCount@4", CallingConvention = CallingConvention.StdCall )]
        private static extern uint VGetTotFileCount( uint iHandle );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VOpenFile@8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi )]
        private static extern uint VOpenFile( string strPath, uint iHandle );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_vfgetsize@4", CallingConvention = CallingConvention.StdCall )]
        private static extern uint VFGetSize( uint iFileHandle );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VCloseFile@4", CallingConvention = CallingConvention.StdCall )]
        private static extern void VCloseFile( uint iFileHandle );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_vfread@16", CallingConvention = CallingConvention.StdCall )]
        private static extern uint VFRead( IntPtr ptrBuffer, uint iSize, uint iCount, uint iFileHandle );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VFileExists@8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi )]
        private static extern uint VFileExists( uint iHandle, string strFileName );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VRemoveFile@8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi )]
        private static extern uint VRemoveFile( uint iHandle, string strFileName );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VAddVfs@8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi )]
        private static extern uint VAddVfs( uint iHandle, string strVfsName );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VAddFile@36", CallingConvention = CallingConvention.StdCall )]
        private static extern uint VAddFile( uint iHandle, string strInsertVfs, string strLocalPath, string strVfsPath, uint iAttribute, uint iChecksum, uint iReserved, uint iReserved2, uint iReserved3);
        
        [DllImport( "TriggerVFS.dll", EntryPoint = "_VGetFileInfo@16", CallingConvention = CallingConvention.StdCall )]
        private static extern uint VGetFileInfo( uint iHandle, string strFileName, ref FileInfo strInfo, uint iSomeHandle);

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VGetError@0", CallingConvention = CallingConvention.StdCall )]
        private static extern ushort VGetError();

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VGetFileLength@8", CallingConvention = CallingConvention.StdCall )]
        private static extern uint VGetFileLength( uint iHandle, string strFileName );

        [DllImport( "TriggerVFS.dll", EntryPoint = "_VSetFileInfo@12", CallingConvention = CallingConvention.StdCall )]
        private static extern uint VSetFileInfo( uint iHandle, string strFileName, ref FileInfo strInfo);

        #region
        //[DllImport( "TriggerVFS.dll", EntryPoint = "_VFileExistsInVfs@8", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint VFileExistsInVfs( uint iFileHandle, string strVfsName );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_VSetCurVersion@8", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint VSetCurVersion( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_ComputeCrc@8", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint ComputeCrc( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_VClearBlankAll@8", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint VClearBlankAll( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_VGetStdVersion@4", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint VGetStdVersion( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_VSetStdVersion@8", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint VSetStdVersion( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_VTestFile@8", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint VTestFile( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "___ConvertPath@8", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint ConvertPath( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_vfeof@4", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint vfeof( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_vfgetdata@8", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint vfgetdata( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_vfseek@12", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint vfseek( uint iHandle );

        //[DllImport( "TriggerVFS.dll", EntryPoint = "_vftell@4", CallingConvention = CallingConvention.StdCall )]
        //private static extern uint vftell( uint iHandle );
        #endregion
        #endregion
    }
}
#endregion

