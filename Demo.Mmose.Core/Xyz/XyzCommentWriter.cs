using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Mmose.Core.Util;
using System.Diagnostics;

namespace Demo.Mmose.Xyz
{
    internal class XyzCommentWriter
    {
        public static bool WriteComment( System.IO.Stream stream, XyzCommentReader xyzComment )
        {
            switch ( xyzComment.Version )
            {
                case XyzCommentVersion.XyzCommentVer01:

                    return WriteCommentVer01( stream, xyzComment );
                default:
                    break;
            }

            return false;
        }

        private static bool WriteCommentVer01( System.IO.Stream stream, XyzCommentReader xyzComment )
        {
            if ( stream == null )
                throw new ArgumentNullException( "stream" );

            if ( xyzComment == null )
                throw new ArgumentNullException( "xyzComment" );

            byte[] byteULong = new byte[8];

            // 00 ~ 01: 标识符号 : 是否是评论信息的标识（ 0x02 标识为评论信息 ）(写入)
            stream.WriteByte( xyzComment.Tag );

            // 01 ~ 02: 评论信息的版本号 ( 当前支持 0x01 版本 )(写入)
            stream.WriteByte( (byte)xyzComment.Version );

            // 02 ~ 10: 对应XYZ文件内实体的唯一序号 ( 0 为XYZ主文件的主要评论信息, 1... 为其它XYZ文件内实体的评论信息 )(写入)
            xyzComment.EntryId.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 10 ~ 11: 评论信息的压缩方式 （0xFF 为该评论信息已删除, 0 为无压缩, 1... 为其它压缩方式）(写入)
            stream.WriteByte( (byte)xyzComment.CompressionType );

            // 11 ~ 13: 评论信息被压缩后的有效长度 （ 如果该评论信息已删除，当有新增的评论信息压缩后的有效长度小于此评论信息的有效长度则覆盖掉此评论信息，然后在此评论信息尾部新增一个新的空XYZ文件内实体来填充剩余的字节 ）(写入)
            xyzComment.CompressedLength.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 13 ~ 15: 原评论信息的有效长度(写入)
            xyzComment.UncompressedLength.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 15 ~ 31: 原评论信息的CRC校验字节(写入)
            stream.Write( xyzComment.Crc, 0, xyzComment.Crc.Length );

            // 31 ~ ..: 评论信息被压缩后的字节
            if ( xyzComment.CompressedData == null )
            {
                if ( xyzComment.CompressedLength > 0 )
                    throw new ArgumentException( "xyzComment.CompressedData == null && xyzComment.CompressedData.Length > 0 error!", "xyzComment.CompressedData & xyzComment.CompressedLength" );
                else
                    return true;
            }

            if ( xyzComment.CompressedLength > xyzComment.CompressedData.Length )
                throw new ArgumentException( "xyzComment.CompressedLength > xyzComment.CompressedData.Length error!", "xyzComment.CompressedData & xyzComment.CompressedLength" );

            stream.Write( xyzComment.CompressedData, 0, xyzComment.CompressedLength );

            return true;
        }
    }
}
