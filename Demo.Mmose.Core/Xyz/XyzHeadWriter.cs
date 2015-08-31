using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Mmose.Core.Util;
using System.IO;

namespace Demo.Mmose.Xyz
{
    internal class XyzHeadWriter
    {
        public readonly static XyzHeadReader DEFUALT = new XyzHeadReader();

        public static bool WriteXyzHead( System.IO.Stream stream, XyzHeadReader xyzHead )
        {
            switch ( xyzHead.Version )
            {
                case XyzHeadVersion.XyzHeadVer01:

                    return WriteXyzHeadVer01( stream, xyzHead );
                default:
                    break;
            }

            return false;
        }

        private static bool WriteXyzHeadVer01( System.IO.Stream stream, XyzHeadReader xyzHead )
        {
            if ( stream == null )
                throw new ArgumentNullException( "stream" );

            if ( xyzHead == null )
                throw new ArgumentNullException( "xyzHead" );

            byte[] byteULong = new byte[8];

            // 00 ~ 03: 标识符号 : 是否是XYZ的标识(写入)
            stream.Write( xyzHead.Tag, 0, xyzHead.Tag.Length );

            // 03 ~ 04: XYZ文件版本号(写入)
            stream.WriteByte( (byte)xyzHead.Version );

            // 04 ~ 05: XYZ文件内实体名称的加密方式 （ 0 为无加密, 1... 为其它加密方式 ）(写入)
            stream.WriteByte( (byte)xyzHead.EncryptType );

            // 05 ~ 13: 主评论信息的文件偏移(写入)
            xyzHead.CommentOffset.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // 13 ~ 21: 第一个XYZ文件内实体的文件偏移(写入)
            xyzHead.FirstEntryOffset.ToArrayInByte( ref byteULong, 0 );
            stream.Write( byteULong, 0, byteULong.Length );

            // XYZ文件内实体评论的信息(写入)
            if ( xyzHead.CommentReader == null  )
            {
                if ( xyzHead.CommentOffset > 0 )
                    throw new ArgumentException( "xyzHead.CommentReader == null && xyzHead.CommentOffset > 0 error!", "xyzComment.CommentReader & xyzComment.CommentOffset" );
                else
                    return true;
            }

            stream.Seek( (long)xyzHead.CommentOffset, SeekOrigin.Begin );
            XyzCommentWriter.WriteComment( stream, xyzHead.CommentReader );

            return true;
        }
    }
}
