using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using Demo.Mmose.Core.Util;

namespace Demo.Mmose.Xyz
{
    internal class XyzEntryWriter
    {

        public static bool WriteEntry( System.IO.Stream stream, XyzEntryReader xyzEntry )
        {
            switch ( xyzEntry.Version )
            {
                case XyzEntryVersion.XyzEntryVer01:

                    return WriteEntryVer01( stream, xyzEntry );
                default:
                    break;
            }

            return false;
        }


        private static bool WriteEntryVer01( System.IO.Stream stream, XyzEntryReader xyzEntry )
        {
            if ( stream == null )
                throw new ArgumentNullException( "stream" );

            if ( xyzEntry == null )
                throw new ArgumentNullException( "xyzEntry" );

            byte[] byteULong = new byte[8];

            // 000 ~ 001: 标识符号 : 是否是XYZ文件内实体的标识 （ 0x01 标识为XYZ文件内的实体 ）(写入)
            stream.WriteByte( xyzEntry.Tag );

            // 001 ~ 002: XYZ文件内实体的版本号 ( 当前支持 0x01 版本 )(写入)
            stream.WriteByte( (byte)xyzEntry.Version );

            // 002 ~ 010: XYZ文件内实体的唯一序号 ( 1... 以后的数字 )(写入)
            xyzEntry.EntryId.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 010 ~ 012: XYZ文件内实体名称的有效长度(写入)
            xyzEntry.NameLength.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 012 ~ 028: 校验原XYZ文件内实体名称的CRC字节码(写入)
            stream.Write( xyzEntry.NameCrc, 0, xyzEntry.NameCrc.Length );

            // 028 ~ 029: XYZ文件内实体的加密方式 （ 0 为无加密, 1... 为其它加密方式 ）(写入)
            stream.WriteByte( (byte)xyzEntry.EncryptType );

            // 029 ~ 030: XYZ文件内实体的压缩方式 （ 0xFF 为该XYZ文件内实体信息已删除, 0 为无压缩, 1... 为其它压缩方式 ）(写入)
            stream.WriteByte( (byte)xyzEntry.CompressionType );

            // 030 ~ 031: XYZ文件内实体的压缩等级 （ 0 为默认, 1... 为其它压缩等级 ）(写入)
            stream.WriteByte( xyzEntry.CompressionLevel );

            // 031 ~ 039: XYZ文件内实体被压缩后的有效长度 （ 0 是目录或0字节文件 ） （ 如果该XYZ文件内实体已删除，当有新增的XYZ文件内实体压缩后的有效长度小于此评论信息的有效长度则覆盖掉此评论信息，然后在此评论信息尾部新增一个新的空XYZ文件内实体来填充剩余的字节 ）(写入)
            xyzEntry.CompressedLength.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 039 ~ 047: XYZ文件内原文件的有效长度 （ 当压缩后的有效长度等于0时,值为0x0000000000000000是个0字节文件,值为0xFFFFFFFFFFFFFFFF是个目录文件）(写入)
            xyzEntry.UncompressedLength.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 039 ~ 047: XYZ文件内原文件的有效长度 （ 当压缩后的有效长度等于0时,值为0x0000000000000000是个0字节文件,值为0xFFFFFFFFFFFFFFFF是个目录文件）(写入)
            xyzEntry.UncompressedLength.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 047 ~ 055: XYZ文件内原文件的修改日期(写入)
            xyzEntry.DateTime.ToFileTimeUtc().ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 055 ~ 071: 原XYZ文件内实体的CRC校验字节码(写入)
            stream.Write( xyzEntry.Crc, 0, xyzEntry.Crc.Length );

            // 071 ~ 079: XYZ文件内实体评论信息的文件偏移 （ 0 为该评论信息不存在 ）(写入)
            xyzEntry.CommentOffset.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 071 ~ 079: XYZ文件内实体评论信息的文件偏移 （ 0 为该评论信息不存在 ）(写入)
            xyzEntry.CommentOffset.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 079 ~ 087: 下一个XYZ文件内实体的文件偏移 （ 0 为下一个XYZ文件内实体信息已不存在 ）(写入)
            xyzEntry.NextEntryOffset.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 087 ~ ...: XYZ文件内实体名称的字节(写入)
            if ( xyzEntry.NameData == null )
            {
                if ( xyzEntry.NameLength > 0 )
                    throw new ArgumentException( "xyzComment.CompressedData == null && xyzComment.CompressedData.Length > 0 error!", "xyzComment.CompressedData & xyzComment.CompressedLength" );
            }
            else
            {
                if ( xyzEntry.NameLength > (ulong)xyzEntry.NameData.Length )
                    throw new ArgumentException( "xyzComment.CompressedLength > xyzComment.CompressedData.Length error!", "xyzComment.CompressedData & xyzComment.CompressedLength" );

                stream.Write( xyzEntry.NameData, 0, (int)xyzEntry.NameLength );
            }

            // ... ~ ???: XYZ文件内实体信息被压缩后的字节(写入)
            if ( xyzEntry.CompressedData == null )
            {
                if ( xyzEntry.CompressedLength > 0 )
                    throw new ArgumentException( "xyzComment.CompressedData == null && xyzComment.CompressedData.Length > 0 error!", "xyzComment.CompressedData & xyzComment.CompressedLength" );
                else
                    return true;
            }

            if ( xyzEntry.CompressedLength > (ulong)xyzEntry.CompressedData.Length )
                throw new ArgumentException( "xyzComment.CompressedLength > xyzComment.CompressedData.Length error!", "xyzComment.CompressedData & xyzComment.CompressedLength" );

            stream.Write( xyzEntry.CompressedData, 0, (int)xyzEntry.CompressedLength );

            // XYZ文件内实体评论的信息(写入)
            if ( xyzEntry.CommentReader == null )
            {
                if ( xyzEntry.CommentOffset > 0 )
                    throw new ArgumentException( "xyzEntry.CommentReader == null && xyzEntry.CommentOffset > 0 error!", "xyzEntry.CommentReader & xyzEntry.CommentOffset" );
            }

            stream.Seek( (long)xyzEntry.CommentOffset, SeekOrigin.Begin );
            XyzCommentWriter.WriteComment( stream, xyzEntry.CommentReader );

           return false;
        }














        private System.IO.Stream zipStream;		//The zip stream which is instantiated
										//and closed after every operation
        private System.IO.Stream baseStream;		//The base stream from which the header 
										//and compressed data are read

		private long offset;
		private byte method;

		System.Security.Cryptography.MD5CryptoServiceProvider md5;
										//Required for creating CRC

		/// <summary>
		/// Creates a new Zip writer, used to write a zip archive.
		/// </summary>
		/// <param name="fileStream">
		/// the output stream to which the zip archive is written.
		/// </param>
        public XyzEntryWriter( System.IO.Stream fileStream )
		{
			baseStream = fileStream;
			md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		}

		/// <summary>
		/// Super Header format
		/// </summary>
		/// <param name="number">Number of files in the archive</param>
		/// <param name="mode">Mode of zipping can be either GZip or Deflate</param>
		public void WriteSuperHeader(Int16 number, byte mode)
		{
			baseStream.Seek(0, SeekOrigin.Begin);
			WriteLeInt16(number);
			baseStream.WriteByte(mode);
		}

		/// <summary>
		/// Writes the superheader
		/// Resets the pointer back to the original position
		/// </summary>
		/// <param name="number">Number of files in the archive</param>

		private void WriteSuperHeader(Int16 number)
		{
			try{
				long pos = baseStream.Position;
				baseStream.Seek(0, SeekOrigin.Begin);
				WriteLeInt16(number);
				baseStream.Seek(pos, SeekOrigin.Begin);
			}
			catch (IOException)
			{
				XyzConstants.ShowError(XyzConstants.IOError);
			}
			catch (ArgumentException)
			{
				XyzConstants.ShowError(XyzConstants.SeekError);
			}
		}

		/// <summary>
		/// Writes a stream of bytes into the stream.
		/// </summary>
		private void WriteBytes(byte []value)
		{
			foreach(byte b in value)
				baseStream.WriteByte(b);
		}
		/// <summary>
		/// Write an int16 in little endian byte order.
		/// </summary>
		private void WriteLeInt16(Int16 value)
		{
			baseStream.WriteByte((byte)value);
			baseStream.WriteByte((byte)(value >> 8));
		}

		/// <summary>
		/// Write an int32 in little endian byte order.
		/// </summary>
		private void WriteLeInt32(Int32 value)
		{
			WriteLeInt16((Int16)value);
			WriteLeInt16((Int16)(value >> 16));
		}

		/// <summary>
		/// Puts the next header in a predefined order
		/// </summary>
		/// <param name="entry">
		/// the XyzEntry which contains all the information
		/// </param>
		private void PutNextHeader(XyzEntry entry)
		{
			try{
                //WriteLeInt32(entry.Size);
                ////REcord the offset to write proper CRC and compressed size
                //offset = baseStream.Position;
                //WriteLeInt32(entry.CompressedLength);
                //WriteBytes(entry.GetCrc());
                //WriteLeInt32(entry.DosTime);
                //WriteLeInt16(entry.NameLength);
                //byte[] names = ConvertToArray(entry.Name);
                //baseStream.Write(names, 0, names.Length);
			}
			catch (IOException)
			{
				XyzConstants.ShowError(XyzConstants.IOError);
			}
			catch (ArgumentException)
			{
				XyzConstants.ShowError(XyzConstants.SeekError);
			}
		}

		/// <summary>
		/// Writes the compressed data into the basestream 
		/// It instantiates a memory stream which will serve 
		/// as a temp store and then compresses it using Gzip Stream or
		/// Deflate stream and writes it to the base stream
		/// </summary>
		private void WriteCompressedFile(FileStream fStream, XyzEntry entry)
		{
			MemoryStream ms = new MemoryStream();
			try
			{
				if (method == XyzConstants.DEFLATE)
					zipStream = new DeflateStream(ms, CompressionMode.Compress, 
						true);
				else if (method == XyzConstants.GZIP)
					zipStream = new GZipStream(ms, CompressionMode.Compress, 
						true);

				byte[] buffer = new byte[fStream.Length];
				fStream.Read(buffer, 0, buffer.Length);
				zipStream.Write(buffer, 0, buffer.Length);
				zipStream.Close();

				byte[] b = new byte[ms.Length];
				ms.Seek(0, SeekOrigin.Begin);
				ms.Read(b, 0, b.Length);
				baseStream.Write(b, 0, b.Length);
				//Go back and write the length and the CRC
				WriteCompressedLengthCRC((int)ms.Length, ComputeMD5(b), entry);
				
			}
			catch (IOException)
			{
				XyzConstants.ShowError(XyzConstants.IOError);
			}
			catch (ArgumentException)
			{
				XyzConstants.ShowError(XyzConstants.SeekError);
			}
			finally
			{
				ms.Close();
			}

		}

		private void WriteCompressedLengthCRC(Int32 value, byte[] crc, 
			XyzEntry entry)
		{
			try{
                //entry.CompressedLength = value;
				entry.SetCrc(crc);
				baseStream.Seek(offset, SeekOrigin.Begin);
                //WriteLeInt32(entry.CompressedLength);
				WriteBytes(crc);
				//Remove the recorded offset
				offset = -1;
				baseStream.Seek(0, SeekOrigin.End);
			}
			catch (IOException)
			{
				XyzConstants.ShowError(XyzConstants.IOError);
			}
			catch (ArgumentException)
			{
				XyzConstants.ShowError(XyzConstants.ArgumentError);
			}
	}

		private byte[] ConvertToArray(string name)
		{
			return System.Text.Encoding.ASCII.GetBytes(name);
		}

		/// <summary>
		/// Completes the header.This will update the superheader.
		/// </summary>
		/// <param name="numberOfFiles">
		/// The total number of files in the archive
		/// </param>
		public void CloseHeaders(Int16 numberOfFiles)
		{
			WriteSuperHeader(numberOfFiles);
		}

		/// <summary>
		/// Add a new entry to the zip
		/// </summary>
		/// <param name="entry">
		/// The details about the header of the entry
		/// </param>
		public void Add(XyzEntry entry)		{
			FileStream fs = null;
			try
			{
				fs = File.OpenRead(entry.Name);
                //entry.Size = (Int32)fs.Length;
				entry.DateTime = File.GetLastWriteTime(entry.Name);
				PutNextHeader(entry);
				WriteCompressedFile(fs, entry);
                //CompressionForm.statusMessage = XyzConstants.AddMessage;
			}
			catch (ArgumentOutOfRangeException)
			{
				XyzConstants.ShowError(XyzConstants.ArgumentError);
			}
			catch (ArgumentException)
			{
				
				XyzConstants.ShowError(XyzConstants.FileError);
			}
			catch (FileNotFoundException)
			{
				XyzConstants.ShowError(XyzConstants.FileNotFoundError);
			}
			catch (IOException)
			{
				XyzConstants.ShowError(XyzConstants.IOError);
			}
			catch (OutOfMemoryException)
			{
				XyzConstants.ShowError(XyzConstants.MemoryError);
			}
		}
		
		/// <summary>
		/// Sets default compression method. 
		/// </summary>
		/// <param name = "method">
		/// the Compression method which can be Gzip or deflate.
		/// </param>
		public byte Method
		{
			get
			{
				return method;
			}
			set
			{
				method = value;
			}
		}

		public byte[] ComputeMD5(byte[] input)
		{
			return md5.ComputeHash(input);
		}

		/// <summary>
		/// Remove an entry from the archive
		/// </summary>
		/// <param name="jump">
		/// The offset of the file to be removed
		/// </param>
        public void Remove( long jump, XyzEntry entry )
        {
            try
            {
                //long fileJump = XyzConstants.FixedHeaderSize +
                //        entry.NameLength
                //        +entry.CompressedLength;
                //baseStream.Seek( jump + fileJump, SeekOrigin.Begin );
                //long length = baseStream.Length - fileJump - jump;
                //byte[] b = new byte[length];
                //baseStream.Read( b, 0, (int)length );
                //baseStream.Seek( jump, SeekOrigin.Begin );
                //baseStream.Write( b, 0, (int)length );
                //baseStream.SetLength( baseStream.Length - fileJump );
                //CompressionForm.statusMessage = "Removed successfully";
            }
            catch ( ArgumentException )
            {

                XyzConstants.ShowError( XyzConstants.FileError );
            }
            catch ( IOException )
            {
                XyzConstants.ShowError( XyzConstants.IOError );
            }
        }
    }
}
