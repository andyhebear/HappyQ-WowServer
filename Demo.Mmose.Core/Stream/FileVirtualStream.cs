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
using System.IO;
#endregion

namespace Demo.Mmose.Stream
{
    internal class FileVirtualStream : VirtualStream
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private FileStream m_FileStream = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileStream"></param>
        private FileVirtualStream( FileStream fileStream )
        {
            if ( fileStream == null )
                throw new Exception( "FileVirtualStream.FileVirtualStream(...) - fileStream == null error!" );

            m_FileStream = fileStream;
        }
        #endregion

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        internal static FileVirtualStream OpenFile( string path, FileAccess access )
        {
            FileVirtualStream fileVirtualStream = null;

            try
            {
                FileStream fileStream = File.Open( path, FileMode.Open, access );
                if ( fileVirtualStream != null )
                    fileVirtualStream = new FileVirtualStream( fileStream );
            }
            catch
            {
            }

            return fileVirtualStream;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static FileVirtualStream CreateFile( string path )
        {
            FileVirtualStream fileVirtualStream = null;

            try
            {
                FileStream fileStream = File.Open( path, FileMode.CreateNew, FileAccess.ReadWrite );
                if ( fileVirtualStream != null )
                    fileVirtualStream = new FileVirtualStream( fileStream );
            }
            catch
            {
            }

            return fileVirtualStream;
        }
        #endregion

        #region zh-CHS 属性覆盖 | en Override Properties
        /// <summary>
        /// 
        /// </summary>
        public override bool CanRead
        {
            get { return m_FileStream.CanRead; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool CanSeek
        {
            get { return m_FileStream.CanSeek; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool CanWrite
        {
            get { return m_FileStream.CanWrite; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override long Length
        {
            get { return m_FileStream.Length; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override long Position
        {
            get { return m_FileStream.Position; }
            set { m_FileStream.Position = value; }
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="numBytes"></param>
        /// <param name="userCallback"></param>
        /// <param name="stateObject"></param>
        /// <returns></returns>
        public override IAsyncResult BeginRead( byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject )
        {
            return m_FileStream.BeginWrite( array, offset, numBytes, userCallback, stateObject );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="numBytes"></param>
        /// <param name="userCallback"></param>
        /// <param name="stateObject"></param>
        /// <returns></returns>
        public override IAsyncResult BeginWrite( byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject )
        {
            return m_FileStream.BeginWrite( array, offset, numBytes, userCallback, stateObject  );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose( bool disposing )
        {
            m_FileStream.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public override int EndRead( IAsyncResult asyncResult )
        {
            return m_FileStream.EndRead( asyncResult );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncResult"></param>
        public override void EndWrite( IAsyncResult asyncResult )
        {
            m_FileStream.EndWrite( asyncResult );
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Flush()
        {
            m_FileStream.Flush();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override int Read( byte[] buffer, int offset, int count )
        {
            return m_FileStream.Read( buffer, offset, count );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int ReadByte()
        {
            return m_FileStream.ReadByte( );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public override long Seek( long offset, SeekOrigin origin )
        {
            return m_FileStream.Seek( offset, origin );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public override void SetLength( long value )
        {
            m_FileStream.SetLength( value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public override void Write( byte[] buffer, int offset, int count )
        {
            m_FileStream.Write( buffer, offset, count );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public override void WriteByte( byte value )
        {
            m_FileStream.WriteByte( value );
        }
        #endregion
    }
}
#endregion