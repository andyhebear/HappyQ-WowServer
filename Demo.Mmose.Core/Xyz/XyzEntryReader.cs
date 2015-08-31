using System;
using Demo.Mmose.Core.Util;

namespace Demo.Mmose.Xyz
{
    internal enum XyzEntryVersion
    {
        XyzEntryVer01 = 0x01,

        MaxValue = 0x01,
    }

    internal enum XyzEntryEncrypt
    {
        None = 0x00,
        Aes = 0x01,
        Des = 0x02,
        RC2 = 0x03,
        Rijndael = 0x04,
        TripleDes = 0x05,

        MaxValue = 0x05,
    }

    internal enum XyzEntryCompression
    {
        None = 0x00,
        Deflate = 0x01,
        Bzip2 = 0x02,
        Lzw = 0x03,
        Ppmd = 0x04,

        MaxValue = 0x04,
        Invalid = 0xFF
    }

    /// <summary>
    /// 
    /// </summary>
    internal class XyzEntryReader
    {
        internal static readonly byte XYZ_ENTRY_TAG = 0x01;

        // 000 ~ 001: 标识符号 : 是否是XYZ文件内实体的标识 （ 0x01 标识为XYZ文件内的实体 ）
        // 001 ~ 002: XYZ文件内实体的版本号 ( 当前支持 0x01 版本 )
        // 002 ~ 010: XYZ文件内实体的唯一序号 ( 1... 以后的数字 )
        // 010 ~ 012: XYZ文件内实体名称的有效长度
        // 012 ~ 028: 校验原XYZ文件内实体名称的CRC字节码
        // 028 ~ 029: XYZ文件内实体的加密方式 （ 0 为无加密, 1... 为其它加密方式 ）
        // 029 ~ 030: XYZ文件内实体的压缩方式 （ 0xFF 为该XYZ文件内实体信息已删除, 0 为无压缩, 1... 为其它压缩方式 ）
        // 030 ~ 031: XYZ文件内实体的压缩等级 （ 0 为默认, 1... 为其它压缩等级 ）
        // 031 ~ 039: XYZ文件内实体被压缩后的有效长度 （ 0 是目录或0字节文件 ） （ 如果该XYZ文件内实体已删除，当有新增的XYZ文件内实体压缩后的有效长度小于此评论信息的有效长度则覆盖掉此评论信息，然后在此评论信息尾部新增一个新的空XYZ文件内实体来填充剩余的字节 ）
        // 039 ~ 047: XYZ文件内原文件的有效长度 （ 当压缩后的有效长度等于0时,值为0x0000000000000000是个0字节文件,值为0xFFFFFFFFFFFFFFFF是个目录文件）
        // 047 ~ 055: XYZ文件内原文件的修改日期
        // 055 ~ 071: 原XYZ文件内实体的CRC校验字节码
        // 071 ~ 079: XYZ文件内实体评论信息的文件偏移 （ 0 为该评论信息不存在 ）
        // 079 ~ 087: 下一个XYZ文件内实体的文件偏移 （ 0 为下一个XYZ文件内实体信息已不存在 ）

        // 087 ~ ...: XYZ文件内实体名称的字节
        // ... ~ ???: XYZ文件内实体信息被压缩后的字节

        private byte m_EntryTag = XYZ_ENTRY_TAG;
        public byte Tag
        {
            get { return m_EntryTag; }
        }

        private XyzEntryVersion m_EntryVersion = XyzEntryVersion.XyzEntryVer01;
        public XyzEntryVersion Version
        {
            get { return m_EntryVersion; }
        }

        ulong m_EntryId = 0;
        public ulong EntryId
        {
            get { return m_EntryId; }
        }

        private ushort m_NameLength = 0;		//Length of the variable sized name
        public ushort NameLength
        {
            get { return m_NameLength; }
        }

        private byte[] m_NameCrc = new byte[16];    //Array of 16 CRC bytes
        public byte[] NameCrc
        {
            get { return m_NameCrc; }
        }

        private XyzEntryEncrypt m_EncryptType = XyzEntryEncrypt.None;
        public XyzEntryEncrypt EncryptType
        {
            get { return m_EncryptType; }
        }

        private XyzEntryCompression m_CompressionType = XyzEntryCompression.Invalid;
        public XyzEntryCompression CompressionType
        {
            get { return m_CompressionType; }
        }

        private byte m_CompressionLevel = 0;
        public byte CompressionLevel
        {
            get { return m_CompressionLevel; }
        }

        private ulong m_CompressedLength = 0;
        public ulong CompressedLength
        {
            get { return m_CompressedLength; }
        }

        private ulong m_UncompressedLength = 0;
        public ulong UncompressedLength
        {
            get { return m_UncompressedLength; }
        }

        private DateTime m_DateTime;			//Time represented as an Int
        public DateTime DateTime
        {
            get { return m_DateTime; }
            set { this.m_DateTime = value; }
        }

        private byte[] m_Crc = new byte[16];    //Array of 16 CRC bytes
        public byte[] Crc
        {
            get { return m_Crc; }
        }

        private ulong m_CommentOffset = 0;
        public ulong CommentOffset
        {
            get { return m_CommentOffset; }
        }

        public string Comment
        {
            get { return m_CommentReader == null ? string.Empty : m_CommentReader.Value; }
        }

        private XyzCommentReader m_CommentReader = null;
        public XyzCommentReader CommentReader
        {
            get { return m_CommentReader; }
        }

        private ulong m_NextEntryOffset = 0;
        public ulong NextEntryOffset
        {
            get { return m_NextEntryOffset; }
        }

        private string m_Name = string.Empty;
        public string Name
        {
            get { return m_Name; }
        }

        private byte[] m_NameData = null;
        public byte[] NameData
        {
            get { return m_NameData; }
        }

        private byte[] m_Value = new byte[0];
        public byte[] Value
        {
            get { return m_Value; }
        }

        private byte[] m_CompressedData = null;
        public byte[] CompressedData
        {
            get { return m_CompressedData; }
        }

        private byte[] m_UncompressedData = null;
        public byte[] UncompressedData
        {
            get { return m_UncompressedData; }
        }

        private bool m_IsCommentDeleted = true;
        public bool IsDeleted
        {
            get { return m_IsCommentDeleted; }
        }

        public static XyzEntryReader GetXyzEntry( System.IO.Stream stream )
        {
            // 000 ~ 001: 标识符号 : 是否是XYZ文件内实体的标识 （ 0x01 标识为XYZ文件内的实体 ）(读取)
            int iEntryTag = stream.ReadByte();
            if ( iEntryTag != XYZ_ENTRY_TAG )
                return null;

            // 001 ~ 002: XYZ文件内实体的版本号 ( 当前支持 0x01 版本 )(读取)
            int iCommentVer = stream.ReadByte();
            if ( iCommentVer > (int)XyzCommentVersion.MaxValue )
                return null;

            switch ( iCommentVer )
            {
                case (int)XyzCommentVersion.XyzCommentVer01:

                    return GetXyzEntryVer01( stream );
                default:
                    return null;
            }
        }

        private static XyzEntryReader GetXyzEntryVer01( System.IO.Stream stream )
        {
            XyzEntryReader xyzEntryReader = new XyzEntryReader();
            xyzEntryReader.m_EntryTag = XYZ_ENTRY_TAG;
            xyzEntryReader.m_EntryVersion = XyzEntryVersion.XyzEntryVer01;

            byte[] byteULong = new byte[8];

            // 002 ~ 010: XYZ文件内实体的唯一序号 ( 1... 以后的数字 )(读取)
            int iCount = stream.Read( byteULong, 0, byteULong.Length );
            if ( iCount != byteULong.Length )
                return null;
            else
                xyzEntryReader.m_EntryId = byteULong.ConvertToUInt64();

            byte[] byteUShort = new byte[2];

            // 010 ~ 012: XYZ文件内实体名称的有效长度(读取)
            iCount = stream.Read( byteUShort, 0, byteUShort.Length );
            if ( iCount != byteUShort.Length )
                return null;
            else
                xyzEntryReader.m_NameLength = byteUShort.ConvertToUInt16();

            byte[] byteCrc = new byte[16];

            // 012 ~ 028: 校验原XYZ文件内实体名称的CRC字节码(读取)
            iCount = stream.Read( byteCrc, 0, byteCrc.Length );
            if ( iCount != byteCrc.Length )
                return null;
            else
                xyzEntryReader.m_NameCrc = byteCrc;

            // 028 ~ 029: XYZ文件内实体的加密方式 （ 0 为无加密, 1... 为其它加密方式 ）(读取)
            int iEncryptType = stream.ReadByte();
            if ( iEncryptType > (int)XyzEntryEncrypt.MaxValue )
                return null;
            else
                xyzEntryReader.m_EncryptType = (XyzEntryEncrypt)iEncryptType;

            // 029 ~ 030: XYZ文件内实体的压缩方式 （ 0xFF 为该XYZ文件内实体信息已删除, 0 为无压缩, 1... 为其它压缩方式 ）(读取)
            int iCompressionType = stream.ReadByte();
            if ( iCompressionType > (int)XyzEntryCompression.MaxValue )
                return null;
            else
                xyzEntryReader.m_CompressionType = (XyzEntryCompression)iCompressionType;

            // 030 ~ 031: XYZ文件内实体的压缩等级 （ 0 为默认, 1... 为其它压缩等级 ）(读取)
            xyzEntryReader.m_CompressionLevel = (byte)stream.ReadByte();

            // 031 ~ 039: XYZ文件内实体被压缩后的有效长度 （ 0 是目录或0字节文件 ） （ 如果该XYZ文件内实体已删除，当有新增的XYZ文件内实体压缩后的有效长度小于此评论信息的有效长度则覆盖掉此评论信息，然后在此评论信息尾部新增一个新的空XYZ文件内实体来填充剩余的字节 ）(读取)
            iCount = stream.Read( byteULong, 0, byteULong.Length );
            if ( iCount != byteULong.Length )
                return null;
            else
                xyzEntryReader.m_CompressedLength = byteULong.ConvertToUInt64();

            // 039 ~ 047: XYZ文件内原文件的有效长度 （ 当压缩后的有效长度等于0时,值为0x0000000000000000是个0字节文件,值为0xFFFFFFFFFFFFFFFF是个目录文件）(读取)
            iCount = stream.Read( byteULong, 0, byteULong.Length );
            if ( iCount != byteULong.Length )
                return null;
            else
                xyzEntryReader.m_UncompressedLength = byteULong.ConvertToUInt64();

            // 047 ~ 055: XYZ文件内原文件的修改日期(读取)
            iCount = stream.Read( byteULong, 0, byteULong.Length );
            if ( iCount != byteULong.Length )
                return null;
            else
                xyzEntryReader.m_DateTime = DateTime.FromFileTimeUtc( byteULong.ConvertToInt64() );

            // 055 ~ 071: 原XYZ文件内实体的CRC校验字节码(读取)
            iCount = stream.Read( byteCrc, 0, byteCrc.Length );
            if ( iCount != byteCrc.Length )
                return null;
            else
                xyzEntryReader.m_Crc = byteCrc;

            // 071 ~ 079: XYZ文件内实体评论信息的文件偏移 （ 0 为该评论信息不存在 ）(读取)
            iCount = stream.Read( byteULong, 0, byteULong.Length );
            if ( iCount != byteULong.Length )
                return null;
            else
                xyzEntryReader.m_CommentOffset = byteULong.ConvertToUInt64();

            // 079 ~ 087: 下一个XYZ文件内实体的文件偏移 （ 0 为下一个XYZ文件内实体信息已不存在 ）(读取)
            iCount = stream.Read( byteULong, 0, byteULong.Length );
            if ( iCount != byteULong.Length )
                return null;
            else
                xyzEntryReader.m_NextEntryOffset = byteULong.ConvertToUInt64();

            //byte[] byteData = null;
            //switch ( xyzEntryReader.EncryptType )
            //{
            //    case XyzEntryEncrypt.None:

            //        byteData = byteValue;
            //        break;
            //    case XyzEntryEncrypt.Aes:

            //        break;
            //    case XyzEntryEncrypt.Des:

            //        break;
            //    case XyzEntryEncrypt.RC2:

            //        break;
            //    case XyzEntryEncrypt.Rijndael:

            //        break;
            //    case XyzEntryEncrypt.TripleDes:

            //        break;
            //    default:

            //        return null;
            //}

            //if ( byteData == null )
            //    return null;
            //else
            //    xyzEntryReader.m_CommentValue = XyzConstants.UTF8.GetString( byteData );

            //byte[] byteData = null;
            //switch ( xyzEntryReader.CompressionType )
            //{
            //    case XyzCommentCompression.None:

            //        byteData = byteValue;
            //        break;
            //    case XyzEntryCompression.Deflate:

            //        break;
            //    case XyzEntryCompression.Bzip2:

            //        break;
            //    case XyzEntryCompression.Lzw:

            //        break;
            //    case XyzEntryCompression.Ppmd:

            //        break;
            //    default:

            //        return null;
            //}

            //if ( byteData == null )
            //    return null;
            //else
            //    xyzEntryReader.m_CommentValue = XyzConstants.UTF8.GetString( byteData );


            return xyzEntryReader;
        }


        //private System.IO.Stream zipStream;		//The zip stream which is instantiated
        //                                //and closed after every operation
		
        //private string zipName;			//Name given to the archive
        //private System.IO.Stream baseStream;		//The base stream from which the header 
        //                                //and compressed data are read

        //private Int16 numberOfFiles;
        //private byte method;

        //System.Security.Cryptography.MD5CryptoServiceProvider md5;
        //                                //Required for checking CRC

        ///// <summary>
        ///// Creates a new Zip input stream, reading a zip archive.
        ///// </summary>
        //public XyzEntryReader( System.IO.Stream fileStream, string name )
        //{
        //    zipName = name;
        //    baseStream = fileStream;
        //    numberOfFiles = -1;
        //    method = 255;
        //    md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        //}

        ///// <summary>
        ///// Reads the super header
        ///// Super header structure:
        /////		number of files - 2 byte
        /////		method of compression - 1 byte
        ///// </summary>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Thrown if the super header is tampered
        ///// </exception>
        ///// 
        //private void ReadSuperHeader()
        //{
        //    numberOfFiles = ReadLeInt16();
        //    method = ReadLeByte();
        //    if (method != XyzConstants.DEFLATE &&
        //        method != XyzConstants.GZIP)
        //        throw new ArgumentOutOfRangeException();
        //}

        //private int ReadBuf(byte[] outBuf, int length)
        //{
        //    return baseStream.Read(outBuf, 0, length);
        //}

        ///// <summary>
        ///// Read a byte from baseStream.
        ///// </summary>
        //private byte ReadLeByte()
        //{
        //    return (byte)baseStream.ReadByte();
        //}

        ///// <summary>
        ///// Read an unsigned short baseStream little endian byte order.
        ///// </summary>
        //private Int16 ReadLeInt16()
        //{
        //    return (Int16)( ReadLeByte()|(ReadLeByte() << 8));
        //}

        ///// <summary>
        ///// Read an int baseStream little endian byte order.
        ///// </summary>
        //private Int32 ReadLeInt32()
        //{
        //    return (UInt16)ReadLeInt16() | ((UInt16)ReadLeInt16() << 16);
        //}

        //private string ConvertToString(byte[] data)
        //{
        //    return System.Text.Encoding.ASCII.GetString(data, 0, data.Length);
        //}

        ///// <summary>
        ///// Open the next entry from the zip archive, and return its 
        ///// description. The method expects the pointer to be intact.
        ///// </summary>
        //private XyzEntry GetNextEntry()
        //{
        //    XyzEntry currentEntry = null;
        //    try
        //    {
        //        Int32 size = ReadLeInt32();
        //        if (size == -1)
        //            return new XyzEntry(String.Empty);

        //        Int32 csize = ReadLeInt32();
        //        byte[] crc = new byte[16];
        //        ReadBuf(crc, crc.Length);

        //        Int32 dostime = ReadLeInt32();
        //        Int16 nameLength = ReadLeInt16();

        //        byte[] buffer = new byte[nameLength];
        //        ReadBuf(buffer, nameLength);
        //        string name = ConvertToString(buffer);

        //        currentEntry = new XyzEntry(name);
        //        //currentEntry.Size = size;
        //        //currentEntry.CompressedSize = csize;
        //        //currentEntry.SetCrc(crc);
        //        //currentEntry.DosTime = dostime;
        //    }
        //    catch (ArgumentException)
        //    {
        //        XyzConstants.ShowError(XyzConstants.ArgumentError);
        //    }
        //    catch (ObjectDisposedException)
        //    {
        //        XyzConstants.ShowError(XyzConstants.CloseError);
        //    }
        //    return currentEntry;
        //}

        ///// <summary>
        ///// Writes the uncompressed data into the filename in the 
        ///// entry. It instantiates a memory stream which will serve 
        ///// as a temp store and decompresses it using Gzip Stream or
        ///// Deflate stream
        ///// </summary>
        //private void WriteUncompressedFile(XyzEntry entry, string completePath)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    try
        //    {
        //        //byte[] b = new byte[entry.CompressedSize];
        //        //baseStream.Read(b, 0, (int)entry.CompressedSize);
        //        //if (CheckCRC(entry.GetCrc(), b))
        //        //    ms.Write(b, 0, b.Length);
        //        //ms.Seek(0, SeekOrigin.Begin);
        //        //if (method == XyzConstants.DEFLATE)
        //        //    zipStream = new DeflateStream(ms, 
        //        //        CompressionMode.Decompress, false);
        //        //else if (method == XyzConstants.GZIP)
        //        //    zipStream = new GZipStream(ms, CompressionMode.Decompress, 
        //        //        false);

        //        //int index = entry.Name.LastIndexOf(XyzConstants.BackSlash);
        //        //string name = completePath + entry.Name.Substring(index + 1);
        //        //FileStream rewrite = new FileStream(name, FileMode.Create);
        //        //b = new byte[entry.Size];
        //        //zipStream.Read(b, 0, (int)entry.Size);

        //        //rewrite.Write(b, 0, (int)entry.Size);
        //        //rewrite.Close();
        //    }
        //    catch (IOException)
        //    {
        //        XyzConstants.ShowError(XyzConstants.IOError);
        //    }
        //    catch (ArgumentException)
        //    {
        //        XyzConstants.ShowError(XyzConstants.ArgumentError);
        //    }
        //    finally
        //    {
        //        zipStream.Close();
        //        ms.Close();
        //    }
        //}

        ///// <summary>
        ///// Extracts all the entries in the list of entries
        /////	</summary>
        ///// <param name="zipentries">
        /////	List of all the zip entries. Can be empty.
        ///// </param>
		
        //public void ExtractAll(List<XyzEntry> zipEntries, string startPath) {
        //    try
        //    {
        //        DirectoryInfo dir = new DirectoryInfo(startPath + zipName);
        //        if (!dir.Exists)
        //            dir.Create();
				
        //        int jump = 3;
        //        baseStream.Seek(jump, SeekOrigin.Begin);

        //        foreach (XyzEntry entry in zipEntries)
        //        {
        //            int index1 = entry.Name.IndexOf(XyzConstants.BackSlash);
        //            int index2 = entry.Name.LastIndexOf(XyzConstants.BackSlash);
        //            string relPath = entry.Name.Substring(index1 + 1, 
        //                index2 - index1);
        //            if (index1 == 0)
        //                relPath = String.Empty;

        //            if (relPath.Length != 0)
        //                dir.CreateSubdirectory(relPath);

        //            jump = XyzConstants.FixedHeaderSize + entry.NameLength;
        //            baseStream.Seek(jump, SeekOrigin.Current);
        //            WriteUncompressedFile(entry, startPath + zipName +
        //                XyzConstants.BackSlash + relPath);
        //        }
        //        //CompressionForm.statusMessage = String.Format(
        //        //    System.Threading.Thread.CurrentThread.CurrentUICulture,
        //        //    XyzConstants.ExtractMessage, startPath + zipName +
        //        //    XyzConstants.BackSlash);
        //    }
        //    catch (IOException)
        //    {
        //        XyzConstants.ShowError(XyzConstants.IOError);
        //    }
        //    catch (OutOfMemoryException)
        //    {
        //        XyzConstants.ShowError(XyzConstants.MemoryError);
        //    }
        //}

        ///// <summary>
        ///// Extracts the specified entry
        /////	</summary>
        ///// <param name="entry">
        /////	The entry that is to be extracted.Cannot be null
        ///// </param>
        ///// <param name="jump">
        /////	The offset from the SeekOrigin.Begin at which the 
        ///// comrpessed data is located
        ///// </param>
		
        //public void Extract(XyzEntry entry, long jump, string startPath)
        //{
        //    try{
        //        DirectoryInfo dir = new DirectoryInfo(startPath + zipName);
        //        if (!dir.Exists)
        //            dir.Create();
        //        int index1 = entry.Name.IndexOf(XyzConstants.BackSlash);
        //        int index2 = entry.Name.LastIndexOf(XyzConstants.BackSlash);
        //        string relPath = entry.Name.Substring(index1 + 1, 
        //            index2 - index1);
        //        if (index1 == 0)
        //            relPath = String.Empty;

        //        if(relPath.Length != 0)
        //            dir.CreateSubdirectory(relPath);
        //        baseStream.Seek(jump, SeekOrigin.Begin);
        //        jump = XyzConstants.FixedHeaderSize + entry.NameLength;
        //        baseStream.Seek(jump, SeekOrigin.Current);

        //        WriteUncompressedFile(entry, startPath + zipName + 
        //                XyzConstants.BackSlash + relPath);
        //        //CompressionForm.statusMessage = String.Format(
        //        //    System.Threading.Thread.CurrentThread.CurrentUICulture,
        //        //    XyzConstants.ExtractMessage, startPath + zipName +
        //        //    XyzConstants.BackSlash);
        //    }
        //    catch(IOException)
        //    {
        //        XyzConstants.ShowError(XyzConstants.IOError);
        //    }
        //    catch (OutOfMemoryException)
        //    {
        //        XyzConstants.ShowError(XyzConstants.MemoryError);
        //    }
        //}

        ///// <summary>
        ///// Gets all the entries in the file 
        ///// </summary>
        ///// <returns>
        /////	List of all the zip entries
        ///// </returns> 
		
		
        //public List<XyzEntry> GetAllEntries()
        //{
        //    List<XyzEntry> headers = null;
        //    try{
        //        if (method == 255 || numberOfFiles == -1)
        //        {
        //            baseStream.Seek(0, SeekOrigin.Begin);
        //            ReadSuperHeader();
        //        }
        //        headers = new List<XyzEntry>(numberOfFiles);
        //        baseStream.Seek(3, SeekOrigin.Begin);
        //        for (int i = 0; i < numberOfFiles; ++i)
        //        {
        //            XyzEntry entry = GetNextEntry();
        //            headers.Add(entry);
        //            //baseStream.Seek(entry.CompressedSize, SeekOrigin.Current);
        //        }
        //    }
        //    catch (IOException)
        //    {
        //        XyzConstants.ShowError(XyzConstants.IOError);
        //    }
			
        //    return headers;
        //}
        ///// <summary>
        ///// Gets the method of compression of the archive.
        ///// </summary>
        ///// <returns>
        ///// the XyzConstants.Deflate or XyzConstants.Gzip
        ///// </returns>
        //public byte Method
        //{
        //    get
        //    {
        //        return method;
        //    }
        //}

        ////Check the CRC of the byte array and return true if check successful
        ////false otherwise
        //private bool CheckCRC(byte[] crc, byte[] data)
        //{
        //    byte[] newCrc = md5.ComputeHash(data);
        //    for (int i = 0; i < crc.Length; ++i)
        //    {
        //        if (crc[i] != newCrc[i])
        //            return false;
        //    }
        //    return true;
        //}
    }
}
