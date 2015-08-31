using Demo.Mmose.Core.Util;

namespace Demo.Mmose.Xyz
{
    /// <summary>
    /// 
    /// </summary>
    internal enum XyzCommentVersion
    {
        XyzCommentVer01 = 0x01,

        MaxValue = 0x01,
    }

    /// <summary>
    /// 
    /// </summary>
    internal enum XyzCommentCompression
    {
        None = 0x00,
        Deflate = 0x01,
        Bzip2 = 0x02,
        Lzw = 0x03,
        Ppmd = 0x04,

        MaxValue = 0x04,
        Invalid = 0xFF,
    }

    /// <summary>
    /// 
    /// </summary>
    internal class XyzCommentReader
    {
        internal static readonly byte XYZ_COMMENT_TAG = 0x02;

        // 00 ~ 01: 标识符号 : 是否是评论信息的标识（ 0x02 标识为评论信息 ）
        // 01 ~ 02: 评论信息的版本号 ( 当前支持 0x01 版本 )
        // 02 ~ 10: 对应XYZ文件内实体的唯一序号 ( 0 为XYZ主文件的主要评论信息, 1... 为其它XYZ文件内实体的评论信息 )
        // 10 ~ 11: 评论信息的压缩方式 （0xFF 为该评论信息已删除, 0 为无压缩, 1... 为其它压缩方式）
        // 11 ~ 13: 评论信息被压缩后的有效长度 （ 如果该评论信息已删除，当有新增的评论信息压缩后的有效长度小于此评论信息的有效长度则覆盖掉此评论信息，然后在此评论信息尾部新增一个新的空XYZ文件内实体来填充剩余的字节 ）
        // 13 ~ 15: 原评论信息的有效长度
        // 15 ~ 31: 原评论信息的CRC校验字节

        // 31 ~ ..: 评论信息被压缩后的字节

        private XyzCommentReader()
        {
        }

        private byte m_CommentTag = XYZ_COMMENT_TAG;
        public byte Tag
        {
            get { return m_CommentTag; }
        }

        private XyzCommentVersion m_CommentVersion = XyzCommentVersion.XyzCommentVer01;
        public XyzCommentVersion Version
        {
            get { return m_CommentVersion; }
        }

        ulong m_EntryId = 0;
        public ulong EntryId
        {
            get { return m_EntryId; }
        }

        private XyzCommentCompression m_CompressionType = XyzCommentCompression.Invalid;
        public XyzCommentCompression CompressionType
        {
            get { return m_CompressionType; }
        }

        private ushort m_CompressedLength = 0;
        public ushort CompressedLength
        {
            get { return m_CompressedLength; }
        }

        private byte[] m_CompressedData = null;
        public byte[] CompressedData
        {
            get { return m_CompressedData; }
        }

        private ushort m_UncompressedLength = 0;
        public ushort UncompressedLength
        {
            get { return m_UncompressedLength; }
        }

        private byte[] m_UncompressedData = null;
        public byte[] UncompressedData
        {
            get { return m_UncompressedData; }
        }

        private byte[] m_Crc = new byte[16];
        public byte[] Crc
        {
            get { return m_Crc; }
        }

        private ulong m_ValueOffset = 0;
        public ulong Offset
        {
            get { return m_ValueOffset; }
        }

        private string m_CommentValue = string.Empty;
        public string Value
        {
            get { return m_CommentValue; }
        }


        private bool m_IsCommentDeleted = true;
        public bool IsDeleted
        {
            get { return m_IsCommentDeleted; }
        }

        public static XyzCommentReader GetXyzComment( System.IO.Stream stream )
        {
            // 00 ~ 01: 标识符号 : 是否是评论信息的标识（ 0x02 标识为评论信息 ）(读取)
            int iCommentTag = stream.ReadByte();
            if ( iCommentTag != XYZ_COMMENT_TAG )
                return null;

            // 01 ~ 02: 评论信息的版本号 ( 当前支持 0x01 版本 )(读取)
            int iCommentVer = stream.ReadByte();
            if ( iCommentVer > (int)XyzCommentVersion.MaxValue )
                return null;

            switch ( iCommentVer )
            {
                case (int)XyzCommentVersion.XyzCommentVer01:

                    return GetXyzCommentVer01( stream );
                default:
                    return null;
            }
        }

        private static XyzCommentReader GetXyzCommentVer01( System.IO.Stream stream )
        {
            XyzCommentReader xyzCommentReader = new XyzCommentReader();
            xyzCommentReader.m_CommentTag = XYZ_COMMENT_TAG;
            xyzCommentReader.m_CommentVersion = XyzCommentVersion.XyzCommentVer01;

            byte[] byteULong = new byte[8];

            // 02 ~ 10: 对应XYZ文件内实体的唯一序号 ( 0 为XYZ主文件的主要评论信息, 1... 为其它XYZ文件内实体的评论信息 )(读取)
            int iCount = stream.Read( byteULong, 0, byteULong.Length );
            if (iCount != byteULong.Length)
                return null;
            else
                xyzCommentReader.m_EntryId = byteULong.ConvertToUInt64();

            // 10 ~ 11: 评论信息的压缩方式 （0xFF 为该评论信息已删除, 0 为无压缩, 1... 为其它压缩方式）(读取)
            int iCompressionType = stream.ReadByte();
            if ( iCompressionType == (int)XyzCommentCompression.Invalid )
            {
                xyzCommentReader.m_CompressionType = XyzCommentCompression.Invalid;
                xyzCommentReader.m_IsCommentDeleted = true;
            }
            else if ( iCompressionType > (int)XyzCommentCompression.MaxValue )
                return null;
            else
            {
                xyzCommentReader.m_CompressionType = (XyzCommentCompression)iCompressionType;
                xyzCommentReader.m_IsCommentDeleted = false;
            }

            byte[] byteUShort = new byte[2];

            // 11 ~ 13: 评论信息被压缩后的有效长度 （ 如果该评论信息已删除，当有新增的评论信息压缩后的有效长度小于此评论信息的有效长度则覆盖掉此评论信息，然后在此评论信息尾部新增一个新的空XYZ文件内实体来填充剩余的字节 ）(读取)
            iCount = stream.Read( byteUShort, 0, byteUShort.Length );
            if ( iCount != byteUShort.Length )
                return null;
            else
                xyzCommentReader.m_CompressedLength = byteUShort.ConvertToUInt16();

            // 13 ~ 15: 原评论信息的有效长度(读取)
            iCount = stream.Read( byteUShort, 0, byteUShort.Length );
            if ( iCount != byteUShort.Length )
                return null;
            else
                xyzCommentReader.m_UncompressedLength = byteUShort.ConvertToUInt16();

            byte[] byteCrc = new byte[16];

            // 15 ~ 31: 原评论信息的CRC校验字节(读取)
            iCount = stream.Read( byteCrc, 0, byteCrc.Length );
            if ( iCount != byteCrc.Length )
                return null;
            else
                xyzCommentReader.m_Crc = byteCrc;

            xyzCommentReader.m_ValueOffset = (ulong)stream.Position;

            byte[] byteValue = new byte[xyzCommentReader.CompressedLength];

            // 31 ~ ..: 评论信息被压缩后的字节(读取)
            iCount = stream.Read( byteValue, 0, byteValue.Length );
            if ( iCount != byteValue.Length )
                return null;

            byte[] byteData = null;
            switch ( xyzCommentReader.CompressionType )
            {
                case XyzCommentCompression.None:

                    byteData = byteValue;
                    break;
                case XyzCommentCompression.Deflate:

                    break;
                case XyzCommentCompression.Bzip2:

                    break;
                case XyzCommentCompression.Lzw:

                    break;
                case XyzCommentCompression.Ppmd:

                    break;
                default:

                    return null;
            }

            if ( byteData == null )
                return null;
            else
                xyzCommentReader.m_CommentValue = XyzConstants.UTF8.GetString( byteData );

            return xyzCommentReader;
        }
    }
}
