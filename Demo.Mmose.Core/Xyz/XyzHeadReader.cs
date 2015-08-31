using Demo.Mmose.Core.Util;

namespace Demo.Mmose.Xyz
{
    internal enum XyzHeadVersion
    {
        XyzHeadVer01 = 0x01,

        MaxValue = 0x01,
    }

    internal enum XyzHeadEncrypt
    {
        None = 0x00,
        Aes = 0x01,
        Des = 0x02,
        RC2 = 0x03,
        Rijndael = 0x04,
        TripleDes = 0x05,

        MaxValue = 0x05,
    }

    /// <summary>
    /// 
    /// </summary>
    internal class XyzHeadReader
    {
        internal static readonly byte[] XYZ_HEAD_TAG = new byte[] { 0x58, 0x59, 0x5A };

        // 00 ~ 03: 标识符号 : 是否是XYZ的标识
        // 03 ~ 04: XYZ文件版本号
        // 04 ~ 05: XYZ文件内实体名称的加密方式 （ 0 为无加密, 1... 为其它加密方式 ）
        // 05 ~ 13: 主评论信息的文件偏移
        // 13 ~ 21: 第一个XYZ文件内实体的文件偏移

        // 21 ~ ..: 其它XYZ文件内实体或评论信息的数据

        internal XyzHeadReader()
        {
        }

        private byte[] m_HeadTag = XyzHeadReader.XYZ_HEAD_TAG;
        public byte[] Tag
        {
            get { return m_HeadTag; }
        }

        private XyzHeadVersion m_HeadVersion = XyzHeadVersion.XyzHeadVer01;
        public XyzHeadVersion Version
        {
            get { return m_HeadVersion; }
        }

        private XyzHeadEncrypt m_EncryptType = XyzHeadEncrypt.None;
        public XyzHeadEncrypt EncryptType
        {
            get { return m_EncryptType; }
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

        private ulong m_FirstEntryOffset = 0;
        public ulong FirstEntryOffset
        {
            get { return m_FirstEntryOffset; }
        }


        public static XyzHeadReader ReadXyzHead( System.IO.Stream stream )
        {
            byte[] byteTag = new byte[3];

            // 00 ~ 03: 标识符号 : 是否是XYZ的标识(读取)
            int iCount = stream.Read( byteTag, 0, byteTag.Length );
            if ( iCount != byteTag.Length )
                return null;
            else if ( XyzConstants.CheckBytes( byteTag, XyzHeadReader.XYZ_HEAD_TAG ) == false )
                return null;

            // 03 ~ 04: XYZ文件版本号(读取)
            int iHeadVer = stream.ReadByte();
            if ( iHeadVer > (int)XyzHeadVersion.MaxValue )
                return null;

            switch ( iHeadVer )
            {
                case (int)XyzHeadVersion.XyzHeadVer01:

                    return ReadXyzHeadVer01( stream );
                default:
                    return null;
            }
        }

        private static XyzHeadReader ReadXyzHeadVer01( System.IO.Stream stream )
        {
            XyzHeadReader xyzCommentReader = new XyzHeadReader();
            xyzCommentReader.m_HeadTag = XyzHeadReader.XYZ_HEAD_TAG;
            xyzCommentReader.m_HeadVersion = XyzHeadVersion.XyzHeadVer01;

            // 04 ~ 05: XYZ文件内实体名称的加密方式 （ 0 为无加密, 1... 为其它加密方式 ）(读取)
            int iEncryptType = stream.ReadByte();
            if ( iEncryptType > (int)XyzHeadEncrypt.MaxValue )
                return null;
            else
                xyzCommentReader.m_EncryptType = (XyzHeadEncrypt)iEncryptType;

            switch ( xyzCommentReader.EncryptType )
            {
                case XyzHeadEncrypt.None:

                    break;
                case XyzHeadEncrypt.Aes:

                    break;
                case XyzHeadEncrypt.Des:

                    break;
                case XyzHeadEncrypt.RC2:

                    break;
                case XyzHeadEncrypt.Rijndael:

                    break;
                case XyzHeadEncrypt.TripleDes:

                    break;
                default:

                    return null;
            }

            byte[] byteULong = new byte[8];

            // 05 ~ 13: 主评论信息的文件偏移(读取)
            int iCount = stream.Read( byteULong, 0, byteULong.Length );
            if ( iCount != byteULong.Length )
                return null;
            else
                xyzCommentReader.m_CommentOffset = byteULong.ConvertToUInt64();

            // 13 ~ 21: 第一个XYZ文件内实体的文件偏移(读取)
            iCount = stream.Read( byteULong, 0, byteULong.Length );
            if ( iCount != byteULong.Length )
                return null;
            else
                xyzCommentReader.m_FirstEntryOffset = byteULong.ConvertToUInt64();


            if ( xyzCommentReader.CommentOffset == 0 )
                return xyzCommentReader;
            else if ( (ulong)stream.Length < xyzCommentReader.CommentOffset )
                return null;
            else
            {
                stream.Seek( (long)xyzCommentReader.CommentOffset, System.IO.SeekOrigin.Begin );

                // 13 ~ ..: 其它XYZ文件内实体或评论信息的数据(读取)
                xyzCommentReader.m_CommentReader = XyzCommentReader.GetXyzComment( stream );
            }

            return xyzCommentReader;
        }
    }
}
