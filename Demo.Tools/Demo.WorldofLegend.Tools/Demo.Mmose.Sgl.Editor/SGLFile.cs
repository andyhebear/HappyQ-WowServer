using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace Demo.GOSE.SGL.Editor
{
    public class SGLFileInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public SGLHeader SGLHeader = new SGLHeader();

        /// <summary>
        /// 
        /// </summary>
        public SGLOffsetInfo SGLOffsetInfo = new SGLOffsetInfo();

        /// <summary>
        /// 
        /// </summary>
        public SGLImage[] SGLImage = new SGLImage[0];

        /// <summary>
        /// 
        /// </summary>
        ListViewItem[] ListViewItemArray = new ListViewItem[0];

        /// <summary>
        /// 
        /// </summary>
        ListView ListViewSGLImage = null;

        /// <summary>
        /// 
        /// </summary>
        FileStream SGLFileStream = null;

        String FileName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringFileName"></param>
        /// <returns></returns>
        public bool OpenSGLFile( String stringFileName, ListView listViewSGLImage )
        {
            FileName = stringFileName;
            SGLFileStream = File.Open( stringFileName, FileMode.Open, FileAccess.ReadWrite );

            SGLHeader.ByteTitle = new byte[SGLHeader.TitleSize];
            SGLFileStream.Read( SGLHeader.ByteTitle, 0, SGLHeader.TitleSize );

            string strTitle = Encoding.ASCII.GetString( SGLHeader.ByteTitle );

            if ( string.Equals( strTitle, SGLHeader.SGLTitle, StringComparison.CurrentCulture ) == false )
                return false;

            byte[] byteUINT = new byte[sizeof( uint )];

            SGLFileStream.Read( byteUINT, 0, byteUINT.Length );
            SGLHeader.Comp = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

            SGLFileStream.Read( byteUINT, 0, byteUINT.Length );
            SGLHeader.Offset = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

            SGLFileStream.Seek( SGLHeader.Offset, SeekOrigin.Begin );

            SGLFileStream.Read( byteUINT, 0, byteUINT.Length );
            SGLOffsetInfo.ImageCount = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

            SGLOffsetInfo.OffserTable = new uint[SGLOffsetInfo.ImageCount];
            SGLOffsetInfo.FilePosition = new long[SGLOffsetInfo.ImageCount];

            long iOffserPosition = SGLFileStream.Position;

            byte[] byteBuffer = new byte[byteUINT.Length * SGLOffsetInfo.ImageCount];
            SGLFileStream.Read( byteBuffer, 0, byteBuffer.Length );

            for ( int iIndex = 0, iOffserTable = 0; iIndex < byteBuffer.Length; iOffserTable++, iOffserPosition += byteUINT.Length )
            {
                SGLOffsetInfo.OffserTable[iOffserTable] = (uint)( byteBuffer[iIndex++] | ( byteBuffer[iIndex++] << 8 ) | ( byteBuffer[iIndex++] << 16 ) | ( byteBuffer[iIndex++] << 24 ) );
                SGLOffsetInfo.FilePosition[iOffserTable] = iOffserPosition;
            }

            ListViewItemArray = new ListViewItem[SGLOffsetInfo.OffserTable.Length];
            SGLImage = new SGLImage[SGLOffsetInfo.OffserTable.Length];
            for ( int iIndex = 0; iIndex < SGLImage.Length; iIndex++ )
            {
                SGLImage[iIndex] = new SGLImage();

                if ( SGLOffsetInfo.OffserTable[iIndex] == 0 )
                {
                    {
                        // NULL
                        ListViewItemArray[iIndex] = new ListViewItem( iIndex.ToString(), 0 );
                        ListViewItemArray[iIndex].SubItems.Add( SGLImage[iIndex].Format.ToString() );
                        ListViewItemArray[iIndex].SubItems.Add( SGLImage[iIndex].Frames.ToString() );
                        ListViewItemArray[iIndex].SubItems.Add( string.Empty );
                    }

                    continue;
                }

                SGLFileStream.Seek( SGLOffsetInfo.OffserTable[iIndex], SeekOrigin.Begin );

                SGLImage[iIndex].Unknown1 = (byte)SGLFileStream.ReadByte();
                SGLImage[iIndex].Format = (byte)SGLFileStream.ReadByte();

                SGLFileStream.Read( byteUINT, 0, byteUINT.Length );
                SGLImage[iIndex].Frames = (ushort)( byteUINT[0] | ( byteUINT[1] << 8 ) );
                SGLImage[iIndex].Unknown2 = (ushort)( byteUINT[2] | ( byteUINT[3] << 8 ) );

                {
                    ListViewItemArray[iIndex] = new ListViewItem( iIndex.ToString(), 0 );
                    ListViewItemArray[iIndex].SubItems.Add( SGLImage[iIndex].Format.ToString() );
                    ListViewItemArray[iIndex].SubItems.Add( SGLImage[iIndex].Frames.ToString() );
                    ListViewItemArray[iIndex].SubItems.Add( string.Empty );
                }

                SGLImage[iIndex].SGLFrames = new SGLFrame[SGLImage[iIndex].Frames];
                for ( int iIndex2 = 0; iIndex2 < SGLImage[iIndex].SGLFrames.Length; iIndex2++ )
                {
                    SGLImage[iIndex].SGLFrames[iIndex2] = new SGLFrame();
                    SGLImage[iIndex].SGLFrames[iIndex2].FilePosition = SGLFileStream.Position;

                    SGLFileStream.Read( byteUINT, 0, byteUINT.Length );
                    SGLImage[iIndex].SGLFrames[iIndex2].FrameWidth = (ushort)( byteUINT[0] | ( byteUINT[1] << 8 ) );
                    SGLImage[iIndex].SGLFrames[iIndex2].FrameHeight = (ushort)( byteUINT[2] | ( byteUINT[3] << 8 ) );

                    SGLFileStream.Read( byteUINT, 0, byteUINT.Length );
                    SGLImage[iIndex].SGLFrames[iIndex2].CenterX = (ushort)( byteUINT[0] | ( byteUINT[1] << 8 ) );
                    SGLImage[iIndex].SGLFrames[iIndex2].CenterY = (ushort)( byteUINT[2] | ( byteUINT[3] << 8 ) );

                    SGLImage[iIndex].SGLFrames[iIndex2].BlocksX = (byte)SGLFileStream.ReadByte();
                    SGLImage[iIndex].SGLFrames[iIndex2].BlocksY = (byte)SGLFileStream.ReadByte();

                    switch ( SGLImage[iIndex].Format )
                    {
                        case 0x02:
                            SGLImage[iIndex].SGLFrames[iIndex2].SGLFrameFormat02 = SGLFrameFormat02.GetSGLFrameFormat02( SGLFileStream, SGLImage[iIndex].SGLFrames[iIndex2] );

                            MessageBox.Show( "0x02" );
                            break;
                        case 0x82:
                            SGLImage[iIndex].SGLFrames[iIndex2].SGLFrameFormat82 = SGLFrameFormat82.GetSGLFrameFormat82( SGLFileStream, SGLImage[iIndex].SGLFrames[iIndex2] );

                            MessageBox.Show( "0x82" );
                            break;
                        case 0x88:
                            SGLImage[iIndex].SGLFrames[iIndex2].SGLFrameFormat88 = SGLFrameFormat88.GetSGLFrameFormat88( SGLFileStream, SGLImage[iIndex].SGLFrames[iIndex2] );

                            MessageBox.Show( "0x88" );
                            break;
                        case 0x06:
                            SGLImage[iIndex].SGLFrames[iIndex2].SGLFrameFormat06 = SGLFrameFormat06.GetSGLFrameFormat06( SGLFileStream, SGLImage[iIndex].SGLFrames[iIndex2] );

                            MessageBox.Show( "0x06" );
                            break;
                        case 0x18:
                        case 0x28:
                            SGLImage[iIndex].SGLFrames[iIndex2].SGLFrameFormat18Or28 = SGLFrameFormat18Or28.GetSGLFrameFormat18Or28( SGLFileStream, SGLImage[iIndex].SGLFrames[iIndex2] );

                            MessageBox.Show( "0x28" );
                            break;
                        case 0x11:
                        case 0x12:
                        case 0x22:
                            SGLImage[iIndex].SGLFrames[iIndex2].SGLFrameFormat11Or12Or22 = SGLFrameFormat11Or12Or22.GetSGLFrameFormat11Or12Or22( SGLFileStream, SGLImage[iIndex].SGLFrames[iIndex2] );

                            break;
                        case 0x62:
                            SGLImage[iIndex].SGLFrames[iIndex2].SGLFrameFormat62 = SGLFrameFormat62.GetSGLFrameFormat62( SGLFileStream, SGLImage[iIndex].SGLFrames[iIndex2] );

                            MessageBox.Show( "0x62" );
                            break;
                        default:

                            break;
                    }
                }
            }

            ListViewSGLImage = listViewSGLImage;
            listViewSGLImage.VirtualListSize = ListViewItemArray.Length;
            listViewSGLImage.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler( RetrieveVirtualItemEventHandler );
            listViewSGLImage.VirtualMode = true;

            return true;
        }

        private void RetrieveVirtualItemEventHandler( object sender, RetrieveVirtualItemEventArgs e )
        {
            e.Item = ListViewItemArray[e.ItemIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        public void InsertImage( int sglImageIndex, byte[] byteTgaBuffer, int x, int y )
        {
#if !DEMO
            TargaHeader targaHeader = TargaHeader.GetTargaHeader( byteTgaBuffer );

            byte[] dataBuffer = new byte[targaHeader.Width * targaHeader.Height * 2];

            for ( int iIndex = TargaHeader.TargaHeaderSize, iDataBufferIndex = 0; iIndex < targaHeader.Width * targaHeader.Height * 4 + TargaHeader.TargaHeaderSize; iIndex += 4, iDataBufferIndex += 2 )
            {
                dataBuffer[iDataBufferIndex] = (byte)( ( ( byteTgaBuffer[iIndex] & 0xF0 ) >> 4 ) | ( byteTgaBuffer[iIndex + 1] & 0xF0 ) );
                dataBuffer[iDataBufferIndex + 1] = (byte)( ( ( byteTgaBuffer[iIndex + 2] & 0xF0 ) >> 4 ) | ( byteTgaBuffer[iIndex + 3] & 0xF0 ) );
            }

            SGLImage.BlockInfo refBlockInfo = new SGLImage.BlockInfo();
            refBlockInfo.Width = targaHeader.Width;
            refBlockInfo.Height = targaHeader.Height;
            refBlockInfo.BlocksX = ( refBlockInfo.Width / 256 + 1 );
            refBlockInfo.BlocksY = ( refBlockInfo.Height / 256 + 1 );
            refBlockInfo.BlockSizeArray = new SGLImage.BlockInfo.BlockSize[refBlockInfo.BlocksX, refBlockInfo.BlocksY];

            //MessageBox.Show( string.Format( "{0}:{1}", refBlockInfo.Width, refBlockInfo.Height ) );
            int byteRLE16Size = 0;
            for ( int iIndexY = 0; iIndexY < refBlockInfo.BlocksY; iIndexY++ )
            {
                for ( int iIndexX = 0; iIndexX < refBlockInfo.BlocksX; iIndexX++ )
                {
                    refBlockInfo.BlockSizeArray[iIndexX, iIndexY] = new SGLImage.BlockInfo.BlockSize();

                    if ( iIndexX == ( refBlockInfo.BlocksX - 1 ) )
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth = ( ( refBlockInfo.Width - 1 ) % 256 );
                    else
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth = 255;

                    if ( iIndexY == ( refBlockInfo.BlocksY - 1 ) )
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight = ( ( refBlockInfo.Height - 1 ) % 256 );
                    else
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight = 255;

                    byte[] byteBuffer = new byte[( refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight + 1 ) * ( refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth + 1 ) * 2];

                    for ( int iHeight = 0; iHeight < refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight + 1; iHeight++ )
                    {
                        int byteBufferIndex = ( iHeight * ( refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth + 1 ) * 2 );

                        for ( int iWidth = 0; iWidth < ( refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth + 1 ); iWidth++ )
                        {
                            byteBuffer[byteBufferIndex + ( iWidth * 2 )] = dataBuffer[( ( ( iIndexY * 255 ) + iHeight ) * refBlockInfo.Width * 2 ) + ( iIndexX * 255 * 2 ) + ( iWidth * 2 )];
                            byteBuffer[byteBufferIndex + ( iWidth * 2 ) + 1] = dataBuffer[( ( ( iIndexY * 255 ) + iHeight ) * refBlockInfo.Width * 2 ) + ( iIndexX * 255 * 2 ) + ( iWidth * 2 ) + 1];
                        }
                    }

                    //FileStream fileStream = File.Open( string.Format( "f:\\[{0}][{1}]-x1.bin", refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth, refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight ), FileMode.Create );
                    //fileStream.Write( byteBuffer, 0, byteBuffer.Length );
                    //fileStream.Close();

                    byte[] byteBufferRLE16 = Editor.SGLImage.SGLEncodeRLE16( byteBuffer );
                    if ( byteBufferRLE16 == null )
                        return;
                    else
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].byteRLE16 = byteBufferRLE16;

                    byteRLE16Size += byteBufferRLE16.Length;

                    //fileStream = File.Open( string.Format( "f:\\[{0}][{1}]-o1.bin", refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth, refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight ), FileMode.Create );
                    //fileStream.Write( byteBufferRLE16, 0, byteBufferRLE16.Length );
                    //fileStream.Close();
                }
            }

            byte[] byteRLE16 = Editor.SGLImage.SGLEncodeRLE16( dataBuffer );
            if ( byteRLE16 == null )
                return;

            byte[] byteUSHORT = new byte[sizeof( ushort )];
            byte[] byteUINT = new byte[sizeof( uint )];

            SGLFileStream.Seek( 0, SeekOrigin.End );

            uint iPosition = (uint)SGLFileStream.Position;

            SGLImage sglImage = SGLImage[sglImageIndex];

            if ( sglImage.Format == 0 )
                sglImage.Format = 0x12;

            SGLFileStream.WriteByte( sglImage.Unknown1 );
            SGLFileStream.WriteByte( sglImage.Format );

            sglImage.Frames++;

            byteUSHORT[0] = (byte)( sglImage.Frames & 0xFF );
            byteUSHORT[1] = (byte)( ( sglImage.Frames & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( sglImage.Unknown2 & 0xFF );
            byteUSHORT[1] = (byte)( ( sglImage.Unknown2 & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            for ( int iIndex = 0; iIndex < sglImage.SGLFrames.Length; iIndex++ )
            {
                SGLFrame sglFrame = sglImage.SGLFrames[iIndex];

                SaveFrame( SGLFileStream, sglFrame, sglImage );
            }

            // 开始插入
            SGLFrame sglFrameInsert = new SGLFrame();

            sglFrameInsert.FrameWidth = targaHeader.Width;
            sglFrameInsert.FrameHeight = targaHeader.Height;

            sglFrameInsert.CenterX = (ushort)x;
            sglFrameInsert.CenterY = (ushort)y;

            sglFrameInsert.BlocksX = (byte)refBlockInfo.BlocksX;
            sglFrameInsert.BlocksY = (byte)refBlockInfo.BlocksY;

            switch ( sglImage.Format )
            {
                case 0x02:

                    break;
                case 0x82:

                    break;
                case 0x88:

                    break;
                case 0x06:

                    break;
                case 0x18:
                case 0x28:

                    break;
                case 0x11:
                case 0x12:
                case 0x22:
                    //sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray = new SGLFrameFormat11Or12Or22.SGLFrameData[1];
                    //sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray[0].BlockWidth = (byte)( sglFrameInsert.FrameWidth - 1 );
                    //sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray[0].BlockHeight = (byte)( sglFrameInsert.FrameHeight - 1 );

                    //sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray[0].BlockSize = (uint)byteRLE16.Length;
                    //sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray[0].BlockData = byteRLE16;

                    sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray = new SGLFrameFormat11Or12Or22.SGLFrameData[refBlockInfo.BlocksX * refBlockInfo.BlocksY];

                    for ( int iIndexY = 0; iIndexY < refBlockInfo.BlocksY; iIndexY++ )
                    {
                        for ( int iIndexX = 0; iIndexX < refBlockInfo.BlocksX; iIndexX++ )
                        {
                            sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray[iIndexY * refBlockInfo.BlocksX + iIndexX].BlockWidth = (byte)refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth;
                            sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray[iIndexY * refBlockInfo.BlocksX + iIndexX].BlockHeight = (byte)refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight;

                            sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray[iIndexY * refBlockInfo.BlocksX + iIndexX].BlockSize = (uint)refBlockInfo.BlockSizeArray[iIndexX, iIndexY].byteRLE16.Length;
                            sglFrameInsert.SGLFrameFormat11Or12Or22.SGLFrameDataArray[iIndexY * refBlockInfo.BlocksX + iIndexX].BlockData = refBlockInfo.BlockSizeArray[iIndexX, iIndexY].byteRLE16;
                        }
                    }

                    break;
                case 0x62:

                    break;
                default:

                    break;
            }

            SGLFrame[] sglFrameArray = sglImage.SGLFrames;
            sglImage.SGLFrames = new SGLFrame[sglFrameArray.Length + 1];
            for ( int iIndex = 0; iIndex < sglFrameArray.Length; iIndex++ )
                sglImage.SGLFrames[iIndex] = sglFrameArray[iIndex];

            sglImage.SGLFrames[sglFrameArray.Length] = sglFrameInsert;

            SaveFrame( SGLFileStream, sglFrameInsert, sglImage );

            SGLFileStream.Seek( SGLOffsetInfo.FilePosition[sglImageIndex], SeekOrigin.Begin );

            byteUINT[0] = (byte)( iPosition & 0xFF );
            byteUINT[1] = (byte)( ( iPosition & 0xFF00 ) >> 8 );
            byteUINT[2] = (byte)( ( iPosition & 0xFF0000 ) >> 16 );
            byteUINT[3] = (byte)( ( iPosition & 0xFF000000 ) >> 24 );

            SGLOffsetInfo.OffserTable[sglImageIndex] = iPosition;

            SGLFileStream.Write( byteUINT, 0, byteUINT.Length );

            SGLFileStream.Flush();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReplaceImage( int sglImageIndex, int sglFrameIndex, byte[] byteTgaBuffer, int x, int y )
        {
#if !DEMO
            TargaHeader targaHeader = TargaHeader.GetTargaHeader( byteTgaBuffer );

            byte[] dataBuffer = new byte[targaHeader.Width * targaHeader.Height * 2];

            for ( int iIndex = TargaHeader.TargaHeaderSize, iDataBufferIndex = 0; iIndex < targaHeader.Width * targaHeader.Height * 4 + TargaHeader.TargaHeaderSize; iIndex += 4, iDataBufferIndex += 2 )
            {
                dataBuffer[iDataBufferIndex] = (byte)( ( ( byteTgaBuffer[iIndex] & 0xF0 ) >> 4 ) | ( byteTgaBuffer[iIndex + 1] & 0xF0 ) );
                dataBuffer[iDataBufferIndex + 1] = (byte)( ( ( byteTgaBuffer[iIndex + 2] & 0xF0 ) >> 4 ) | ( byteTgaBuffer[iIndex + 3] & 0xF0 ) );
            }

            //FileStream fileStreamx = File.Open( "f:\\xxxxx1.bin", FileMode.Create );
            //fileStreamx.Write( dataBuffer, 0, dataBuffer.Length );
            //fileStreamx.Close();

            SGLImage.BlockInfo refBlockInfo = new SGLImage.BlockInfo();
            refBlockInfo.Width = targaHeader.Width;
            refBlockInfo.Height = targaHeader.Height;
            refBlockInfo.BlocksX = ( refBlockInfo.Width / 256 + 1 );
            refBlockInfo.BlocksY = ( refBlockInfo.Height / 256 + 1 );
            refBlockInfo.BlockSizeArray = new SGLImage.BlockInfo.BlockSize[refBlockInfo.BlocksX, refBlockInfo.BlocksY];

            //MessageBox.Show( string.Format( "{0}:{1}", refBlockInfo.Width, refBlockInfo.Height ) );
            int byteRLE16Size = 0;
            for ( int iIndexY = 0; iIndexY < refBlockInfo.BlocksY; iIndexY++ )
            {
                for ( int iIndexX = 0; iIndexX < refBlockInfo.BlocksX; iIndexX++ )
                {
                    refBlockInfo.BlockSizeArray[iIndexX, iIndexY] = new SGLImage.BlockInfo.BlockSize();

                    if ( iIndexX == ( refBlockInfo.BlocksX - 1 ) )
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth = ( ( refBlockInfo.Width - 1 ) % 256 );
                    else
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth = 255;

                    if ( iIndexY == ( refBlockInfo.BlocksY - 1 ) )
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight = ( ( refBlockInfo.Height - 1 ) % 256 );
                    else
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight = 255;

                    byte[] byteBuffer = new byte[( refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight + 1 ) * ( refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth + 1 ) * 2];

                    for ( int iHeight = 0; iHeight < refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight + 1; iHeight++ )
                    {
                        int byteBufferIndex = ( iHeight * ( refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth + 1 ) * 2 );

                        for ( int iWidth = 0; iWidth < ( refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth + 1 ); iWidth++ )
                        {
                            byteBuffer[byteBufferIndex + ( iWidth * 2 )] = dataBuffer[( ( ( iIndexY * 255 ) + iHeight ) * refBlockInfo.Width * 2 ) + ( iIndexX * 255 * 2 ) + ( iWidth * 2 )];
                            byteBuffer[byteBufferIndex + ( iWidth * 2 ) + 1] = dataBuffer[( ( ( iIndexY * 255 ) + iHeight ) * refBlockInfo.Width * 2 ) + ( iIndexX * 255 * 2 ) + ( iWidth * 2 ) + 1];
                        }
                    }

                    //FileStream fileStream = File.Open( string.Format( "f:\\[{0}][{1}]-x1.bin", refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth, refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight ), FileMode.Create );
                    //fileStream.Write( byteBuffer, 0, byteBuffer.Length );
                    //fileStream.Close();

                    byte[] byteBufferRLE16 = Editor.SGLImage.SGLEncodeRLE16( byteBuffer );
                    if ( byteBufferRLE16 == null )
                        return;
                    else
                        refBlockInfo.BlockSizeArray[iIndexX, iIndexY].byteRLE16 = byteBufferRLE16;

                    byteRLE16Size += byteBufferRLE16.Length;

                    //fileStream = File.Open( string.Format( "f:\\[{0}][{1}]-o1.bin", refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth, refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight ), FileMode.Create );
                    //fileStream.Write( byteBufferRLE16, 0, byteBufferRLE16.Length );
                    //fileStream.Close();
                }
            }

            //byte[] byteRLE16 = new byte[byteRLE16Size];
            //if ( byteRLE16 == null )
            //    return;

            //int byteRLE16SizeIndex = 0;
            //for ( int iIndexY = 0; iIndexY < refBlockInfo.BlocksY; iIndexY++ )
            //{
            //    for ( int iIndexX = 0; iIndexX < refBlockInfo.BlocksX; iIndexX++ )
            //    {
            //        Buffer.BlockCopy( refBlockInfo.BlockSizeArray[iIndexX, iIndexY].byteRLE16, 0, byteRLE16, byteRLE16SizeIndex, refBlockInfo.BlockSizeArray[iIndexX, iIndexY].byteRLE16.Length );

            //        byteRLE16SizeIndex += refBlockInfo.BlockSizeArray[iIndexX, iIndexY].byteRLE16.Length;
            //    }
            //}

            //MessageBox.Show( "fff" );

            byte[] byteUSHORT = new byte[sizeof( ushort )];
            byte[] byteUINT = new byte[sizeof( uint )];

            SGLFileStream.Seek( 0, SeekOrigin.End );

            uint iPosition = (uint)SGLFileStream.Position;


            SGLImage sglImage = SGLImage[sglImageIndex];

            if ( sglImage.SGLFrames.Length == 0 )
                return;

            SGLFileStream.WriteByte( sglImage.Unknown1 );
            SGLFileStream.WriteByte( sglImage.Format );

            byteUSHORT[0] = (byte)( sglImage.Frames & 0xFF );
            byteUSHORT[1] = (byte)( ( sglImage.Frames & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( sglImage.Unknown2 & 0xFF );
            byteUSHORT[1] = (byte)( ( sglImage.Unknown2 & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            for ( int iIndex = 0; iIndex < sglImage.SGLFrames.Length; iIndex++ )
            {
                if ( sglFrameIndex == iIndex )
                {
                    SGLFrame sglFrame = new SGLFrame();

                    sglFrame.FrameWidth = targaHeader.Width;
                    sglFrame.FrameHeight = targaHeader.Height;

                    sglFrame.CenterX = (ushort)x;
                    sglFrame.CenterY = (ushort)y;

                    sglFrame.BlocksX = (byte)refBlockInfo.BlocksX;
                    sglFrame.BlocksY = (byte)refBlockInfo.BlocksY;

                    switch ( sglImage.Format )
                    {
                        case 0x02:

                            break;
                        case 0x82:

                            break;
                        case 0x88:

                            break;
                        case 0x06:

                            break;
                        case 0x18:
                        case 0x28:

                            break;
                        case 0x11:
                        case 0x12:
                        case 0x22:
                            sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray = new SGLFrameFormat11Or12Or22.SGLFrameData[refBlockInfo.BlocksX * refBlockInfo.BlocksY];

                            for ( int iIndexY = 0; iIndexY < refBlockInfo.BlocksY; iIndexY++ )
                            {
                                for ( int iIndexX = 0; iIndexX < refBlockInfo.BlocksX; iIndexX++ )
                                {
                                    sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[iIndexY * refBlockInfo.BlocksX + iIndexX].BlockWidth = (byte)refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockWidth;
                                    sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[iIndexY * refBlockInfo.BlocksX + iIndexX].BlockHeight = (byte)refBlockInfo.BlockSizeArray[iIndexX, iIndexY].BlockHeight;

                                    sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[iIndexY * refBlockInfo.BlocksX + iIndexX].BlockSize = (uint)refBlockInfo.BlockSizeArray[iIndexX, iIndexY].byteRLE16.Length;
                                    sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[iIndexY * refBlockInfo.BlocksX + iIndexX].BlockData = refBlockInfo.BlockSizeArray[iIndexX, iIndexY].byteRLE16;
                                }
                            }

                            break;
                        case 0x62:

                            break;
                        default:

                            break;
                    }

                    sglImage.SGLFrames[iIndex] = sglFrame;
                    SaveFrame( SGLFileStream, sglFrame, sglImage );
                }
                else
                {
                    SGLFrame sglFrame = sglImage.SGLFrames[iIndex];

                    SaveFrame( SGLFileStream, sglFrame, sglImage );
                }
            }

            SGLFileStream.Seek( SGLOffsetInfo.FilePosition[sglImageIndex], SeekOrigin.Begin );

            byteUINT[0] = (byte)( iPosition & 0xFF );
            byteUINT[1] = (byte)( ( iPosition & 0xFF00 ) >> 8 );
            byteUINT[2] = (byte)( ( iPosition & 0xFF0000 ) >> 16 );
            byteUINT[3] = (byte)( ( iPosition & 0xFF000000 ) >> 24 );

            SGLOffsetInfo.OffserTable[sglImageIndex] = iPosition;

            SGLFileStream.Write( byteUINT, 0, byteUINT.Length );

            SGLFileStream.Flush();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteImage( int sglImageIndex, int sglFrameIndex )
        {
#if !DEMO
            byte[] byteUSHORT = new byte[sizeof( ushort )];
            byte[] byteUINT = new byte[sizeof( uint )];

            SGLFileStream.Seek( 0, SeekOrigin.End );

            uint iPosition = (uint)SGLFileStream.Position;

            SGLImage sglImage = SGLImage[sglImageIndex];

            if ( sglImage.SGLFrames.Length == 0 )
                return;

            SGLFileStream.WriteByte( sglImage.Unknown1 );
            SGLFileStream.WriteByte( sglImage.Format );

            sglImage.Frames--;

            byteUSHORT[0] = (byte)( sglImage.Frames & 0xFF );
            byteUSHORT[1] = (byte)( ( sglImage.Frames & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( sglImage.Unknown2 & 0xFF );
            byteUSHORT[1] = (byte)( ( sglImage.Unknown2 & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            List<SGLFrame> sglFrameList = new List<SGLFrame>();
            for ( int iIndex = 0; iIndex < sglImage.SGLFrames.Length; iIndex++ )
            {
                if ( sglFrameIndex == iIndex )
                    continue;
                else
                {
                    SGLFrame sglFrame = sglImage.SGLFrames[iIndex];
                    sglFrameList.Add( sglFrame );

                    SaveFrame( SGLFileStream, sglFrame, sglImage );
                }
            }

            sglImage.SGLFrames = sglFrameList.ToArray();

            SGLFileStream.Seek( SGLOffsetInfo.FilePosition[sglImageIndex], SeekOrigin.Begin );

            byteUINT[0] = (byte)( iPosition & 0xFF );
            byteUINT[1] = (byte)( ( iPosition & 0xFF00 ) >> 8 );
            byteUINT[2] = (byte)( ( iPosition & 0xFF0000 ) >> 16 );
            byteUINT[3] = (byte)( ( iPosition & 0xFF000000 ) >> 24 );

            SGLOffsetInfo.OffserTable[sglImageIndex] = iPosition;

            SGLFileStream.Write( byteUINT, 0, byteUINT.Length );

            SGLFileStream.Flush();
#endif
       }

        public void SaveFrame( FileStream fileStream, SGLFrame sglFrame, SGLImage sglImage )
        {
            byte[] byteUINT = new byte[sizeof( uint )];
            byte[] byteUSHORT = new byte[sizeof( ushort )];

            sglFrame.FilePosition = fileStream.Position;

            byteUSHORT[0] = (byte)( sglFrame.FrameWidth & 0xFF );
            byteUSHORT[1] = (byte)( ( sglFrame.FrameWidth & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( sglFrame.FrameHeight & 0xFF );
            byteUSHORT[1] = (byte)( ( sglFrame.FrameHeight & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( sglFrame.CenterX & 0xFF );
            byteUSHORT[1] = (byte)( ( sglFrame.CenterX & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( sglFrame.CenterY & 0xFF );
            byteUSHORT[1] = (byte)( ( sglFrame.CenterY & 0xFF00 ) >> 8 );
            SGLFileStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            SGLFileStream.WriteByte( sglFrame.BlocksX );
            SGLFileStream.WriteByte( sglFrame.BlocksY );

            switch ( sglImage.Format )
            {
                case 0x02:

                    break;
                case 0x82:

                    break;
                case 0x88:

                    break;
                case 0x06:

                    break;
                case 0x18:
                case 0x28:

                    break;
                case 0x11:
                case 0x12:
                case 0x22:
                    sglFrame.SGLFrameFormat11Or12Or22.FileStream = fileStream;
                    sglFrame.SGLFrameFormat11Or12Or22.SGLFrame = sglFrame;
                    sglFrame.SGLFrameFormat11Or12Or22.FilePosition = fileStream.Position;

                    for ( int i = 0; i < sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray.Length; i++ )
                    {
                        SGLFileStream.WriteByte( sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[i].BlockWidth );
                        SGLFileStream.WriteByte( sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[i].BlockHeight );

                        byteUINT[0] = (byte)( sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[i].BlockSize & 0xFF );
                        byteUINT[1] = (byte)( ( sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[i].BlockSize & 0xFF00 ) >> 8 );
                        byteUINT[2] = (byte)( ( sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[i].BlockSize & 0xFF0000 ) >> 16 );
                        byteUINT[3] = (byte)( ( sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[i].BlockSize & 0xFF000000 ) >> 24 );
                        SGLFileStream.Write( byteUINT, 0, byteUINT.Length );

                        SGLFileStream.Write( sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[i].BlockData, 0, sglFrame.SGLFrameFormat11Or12Or22.SGLFrameDataArray[i].BlockData.Length );
                    }

                    break;
                case 0x62:

                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringFileName"></param>
        /// <returns></returns>
        public void CloseSGLFile()
        {
            SGLFileStream.Close();
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public const string SGLTitle = "Shanda Game Lib.";
        /// <summary>
        /// 
        /// </summary>
        public const int TitleSize = 32;

        /// <summary>
        /// [32]
        /// </summary>
        public byte[] ByteTitle = new byte[0];

        /// <summary>
        /// 
        /// </summary>
        public uint Comp = 0;

        /// <summary>
        /// 
        /// </summary>
        public uint Offset = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLOffsetInfo
    {
        /// <summary>
        /// 图象总数
        /// </summary>
        public uint ImageCount = 0;

        /// <summary>
        /// 图象的偏移量数组，指向 SGLImage
        /// [ImageCount]
        /// </summary>
        public uint[] OffserTable = new uint[0];

        /// <summary>
        /// 图象偏移量数组的文件地址，指向 OffserTable
        /// </summary>
        public long[] FilePosition = new long[0];

        /// <summary>
        /// [16, uiImageCount]
        /// </summary>
        public uint[,] Unknown3 = new uint[16, 0];
    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLImage
    {
        /// <summary>
        /// 
        /// </summary>
        public byte Unknown1 = 0;

        /// <summary>
        /// 图象的格式
        /// </summary>
        public byte Format = 0;

        /// <summary>
        /// 图象的帧数
        /// </summary>
        public ushort Frames = 0;

        /// <summary>
        /// 
        /// </summary>
        public ushort Unknown2 = 0;

        /// <summary>
        /// 帧数组[FrameCount] 
        /// </summary>
        public SGLFrame[] SGLFrames = new SGLFrame[0];


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] GetOriginBuffer()
        {
            if ( SGLFrames.Length <= 0 )
                return null;

            MemoryStream memoryStream = new MemoryStream();

            memoryStream.WriteByte( this.Unknown1 );

            if ( this.Format == 0 )
                this.Format = 0x12;
            memoryStream.WriteByte( this.Format );

            byte[] byteUSHORT = new byte[sizeof( ushort )];


            byteUSHORT[0] = (byte)( this.Frames & 0xFF );
            byteUSHORT[1] = (byte)( ( this.Frames & 0xFF00 ) >> 8 );
            memoryStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( this.Unknown2 & 0xFF );
            byteUSHORT[1] = (byte)( ( this.Unknown2 & 0xFF00 ) >> 8 );
            memoryStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            foreach ( SGLFrame sglFrame in SGLFrames )
            {
                byte[] byteFrameBuffer = sglFrame.GetOriginBuffer();
                if ( byteFrameBuffer == null )
                    return null;

                memoryStream.Write( byteFrameBuffer, 0, byteFrameBuffer.Length );
            }

            return memoryStream.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scrCol"></param>
        /// <returns></returns>
        public static void Blend( ushort scrCol, ref ushort desCol )
        {
            byte byteAlpha = (byte)( ( scrCol >> 12 ) & 0x0F );

            switch ( byteAlpha )
            {
                case 0x00:
                case 0x0F:

                    desCol = (ushort)( ( ( scrCol << 1 ) & 0x1E ) | ( ( ( scrCol >> 2 ) & 0x3C ) << 5 ) | ( ( ( scrCol >> 7 ) & 0x1E ) << 11 ) );

                    break;
                default:
                    byte byteB = (byte)( desCol & 0x1F );
                    byte byteG = (byte)( ( desCol >> 5 ) & 0x3F );
                    byte byteR = (byte)( ( desCol >> 11 ) & 0x1F );

                    desCol = (ushort)( ( byteAlpha * ( ( scrCol << 1 ) & 0x1E - byteB ) >> 4 + byteB ) |
                        ( ( byteAlpha * ( ( scrCol >> 2 ) & 0x3C - byteG ) >> 4 + byteG ) << 5 ) |
                        ( ( byteAlpha * ( ( scrCol >> 7 ) & 0x1E - byteR ) >> 4 + byteR ) << 11 ) );

                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scrCol"></param>
        /// <returns></returns>
        public static void Blend( byte iAlpha, ushort scrCol, ref ushort desCol )
        {
            switch ( iAlpha )
            {
                case 0x00:
                case 0x0F:

                    desCol = scrCol;

                    break;
                default:
                    byte byteScrB = (byte)( scrCol & 0x1F );
                    byte byteScrG = (byte)( ( scrCol >> 5 ) & 0x3F );
                    byte byteScrR = (byte)( ( scrCol >> 11 ) & 0x1F );

                    byte byteDesB = (byte)( desCol & 0x1F );
                    byte byteDesG = (byte)( ( desCol >> 5 ) & 0x3F );
                    byte byteDesR = (byte)( ( desCol >> 11 ) & 0x1F );

                    byte byteB = (byte)( iAlpha * ( byteScrB - byteDesB ) >> 8 + byteDesB );
                    byte byteG = (byte)( iAlpha * ( byteScrG - byteDesG ) >> 8 + byteDesG );
                    byte byteR = (byte)( iAlpha * ( byteScrR - byteDesR ) >> 8 + byteDesR );

                    desCol = (ushort)( byteB | ( byteG << 5 ) | ( byteR << 11 ) );

                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class BlockInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public class BlockSize
            {
                public int BlockWidth = 0;
                public int BlockHeight = 0;
                public byte[] byteRLE16 = new byte[0];
            }

            public int BlocksX = 0;
            public int BlocksY = 0;
            public int Width = 0;
            public int Height = 0;

            public BlockSize[,] BlockSizeArray = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteSrc"></param>
        /// <param name="byteDst"></param>
        public static byte[] SGLEncodeRLE16( byte[] inBuffer )
        {
            if ( inBuffer == null )
                return null;

            if ( inBuffer.Length <= 0 )
                return null;

            ushort iData = 0;
            ushort iNext = 0;
            int iInBufferIndex = 0;
            int iBakBufferIndex = 0;
            int iCount = 0;
            int iColorBit = 2; // 字节数 16 / 8

            List<byte[]> byteList = new List<byte[]>();

            while ( ( iInBufferIndex + iColorBit ) <= inBuffer.Length )
            {
                iBakBufferIndex = iInBufferIndex; // 记数指针

                iData = (ushort)( inBuffer[iInBufferIndex] | ( inBuffer[iInBufferIndex + 1] << 8 ) ); // 第一个像素

                iCount = 1;
                iInBufferIndex += iColorBit;

                while ( ( iCount < 0x7F ) && ( ( iInBufferIndex + iColorBit ) <= inBuffer.Length ) ) // 统计重复像素
                {
                    iNext = (ushort)( inBuffer[iInBufferIndex] | ( inBuffer[iInBufferIndex + 1] << 8 ) ); // 下一个像素
                    if ( iNext == iData )
                    {
                        iCount++;
                        iInBufferIndex += iColorBit;
                    }
                    else
                        break;
                }

                if ( iCount == 1 ) // 无重复像素
                {
                    while ( ( iCount < 0x7F ) && ( ( iInBufferIndex + iColorBit ) <= inBuffer.Length ) ) // 统计不重复像素
                    {
                        iNext = (ushort)( inBuffer[iInBufferIndex] | ( inBuffer[iInBufferIndex + 1] << 8 ) ); // 下一个像素
                        if ( iData != iNext )
                        {
                            if ( ( iInBufferIndex + (iColorBit * 2) ) <= inBuffer.Length )
                            {
                                ushort iNext2 = (ushort)( inBuffer[iInBufferIndex + 2] | ( inBuffer[iInBufferIndex + 3] << 8 ) ); // 再下一个像素
                                if ( iNext2 == iNext )
                                    break;
                            }

                            iCount++;
                            iData = iNext;
                            iInBufferIndex += iColorBit;
                        }
                        else
                            break;
                    }

                    byte[] tempBuffer = new byte[iCount * 2 + 1];

                    // 直接copy不重复像素
                    tempBuffer[0] = (byte)( 0x80 | iCount );
                    Buffer.BlockCopy( inBuffer, iBakBufferIndex, tempBuffer, 1, iCount * 2 );

                    byteList.Add( tempBuffer );
                }
                else // 重复像素
                {
                    byte[] tempBuffer = new byte[2 + 1];

                    tempBuffer[0] = (byte)iCount;
                    Buffer.BlockCopy( inBuffer, iBakBufferIndex, tempBuffer, 1, 2 );

                    byteList.Add( tempBuffer );
                }
            } // End of while
            

            int bufferSize = 0;
            foreach ( byte[] byteArray in byteList )
                bufferSize += byteArray.Length;

            byte[] retrunBuffer = new byte[bufferSize];

            int iIndex = 0;
            foreach ( byte[] byteArray in byteList )
            {
                foreach ( byte iByte in byteArray )
                {
                    retrunBuffer[iIndex] = iByte;
                    iIndex++;
                }
            }

            return retrunBuffer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteSrc"></param>
        /// <param name="byteDst"></param>
        public static bool SGLDecodeRLE16( byte[] byteSrc, ref byte[] byteDst )
        {
            if ( byteSrc == null || byteSrc == null )
                return false;

            if ( byteSrc.Length <= 0 || byteDst.Length <= 0 )
                return false;

            int byteSrcSize = byteSrc.Length;
            int byteDstSize = byteDst.Length;

            int indexSrc = 0;
            int indexDst = 0;
            while ( byteSrcSize > 0 || byteDstSize > 0 )
            {
                if ( ( byteSrc[indexSrc] & 0x80 ) == 0 )
                {
                    int iLength = byteSrc[indexSrc];
                    indexSrc++;
                    byteSrcSize -= 3 /* 1 + 2 */;

                    if ( iLength > byteDstSize )
                        iLength = byteDstSize;

                    byteDstSize -= ( iLength * 2 );

                    for ( int iIndex = 0; iIndex < iLength; iIndex++ )
                    {
                        byteDst[indexDst] = byteSrc[indexSrc];
                        indexDst++;

                        byteDst[indexDst] = byteSrc[indexSrc + 1];
                        indexDst++;
                    }

                    indexSrc += 2;
                }
                else
                {
                    int iLength = byteSrc[indexSrc] & 0x7F;
                    indexSrc++;
                    byteSrcSize -= ( iLength * 2 + 1 );

                    if ( iLength > byteDstSize )
                        iLength = byteDstSize;

                    byteDstSize -= ( iLength * 2 );

                    for ( int iIndex = 0; iIndex < iLength; iIndex++ )
                    {
                        byteDst[indexDst] = byteSrc[indexSrc];
                        indexDst++;
                        indexSrc++;

                        byteDst[indexDst] = byteSrc[indexSrc];
                        indexDst++;
                        indexSrc++;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteSrc"></param>
        /// <param name="byteDst"></param>
        public static bool SGLDecodeRLE8( byte[] byteSrc, ref byte[] byteDst )
        {
            if ( byteSrc == null || byteSrc == null )
                return false;

            if ( byteSrc.Length <= 0 || byteDst.Length <= 0 )
                return false;

            int byteSrcSize = byteSrc.Length;
            int byteDstSize = byteDst.Length;

            int indexSrc = 0;
            int indexDst = 0;
            while ( byteSrcSize > 0 || byteDstSize > 0 )
            {
                if ( ( byteSrc[indexSrc] & 0x80 ) == 0 )
                {
                    int iLength = byteSrc[indexSrc];
                    indexSrc++;
                    byteSrcSize -= 2 /* 1 + 1 */;

                    if ( iLength > byteDstSize )
                        iLength = byteDstSize;

                    byteDstSize -= iLength;

                    for ( int iIndex = 0; iIndex < iLength; iIndex++ )
                    {
                        byteDst[indexDst] = byteSrc[indexSrc];
                        indexDst++;
                    }

                    indexSrc++;
                }
                else
                {
                    int iLength = byteSrc[indexSrc] & 0x7F;
                    indexSrc++;
                    byteSrcSize -= ( iLength + 1 );

                    if ( iLength > byteDstSize )
                        iLength = byteDstSize;

                    byteDstSize -= iLength;

                    for ( int iIndex = 0; iIndex < iLength; iIndex++ )
                    {
                        byteDst[indexDst] = byteSrc[indexSrc];
                        indexDst++;
                        indexSrc++;
                    }
                }
            }

            return true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLFrame
    {
        /// <summary>
        /// 帧的宽度
        /// </summary>
        public ushort FrameWidth = 0;

        /// <summary>
        /// 帧的高度
        /// </summary>
        public ushort FrameHeight = 0;

        /// <summary>
        /// 帧的水平中心
        /// </summary>
        public ushort CenterX = 0;

        /// <summary>
        /// 帧的垂直中心
        /// </summary>
        public ushort CenterY = 0;

        /// <summary>
        /// 帧的水平块数
        /// </summary>
        public byte BlocksX = 0;

        /// <summary>
        /// 帧的垂直块数
        /// </summary>
        public byte BlocksY = 0;

        /// <summary>
        /// 图象偏移量数组的文件地址，指向 OffserTable
        /// </summary>
        public long FilePosition = 0;

        /// <summary>
        /// 
        /// </summary>
        public SGLFrameFormat02 SGLFrameFormat02 = new SGLFrameFormat02();

        /// <summary>
        /// 
        /// </summary>
        public SGLFrameFormat82 SGLFrameFormat82 = new SGLFrameFormat82();

        /// <summary>
        /// 
        /// </summary>
        public SGLFrameFormat88 SGLFrameFormat88 = new SGLFrameFormat88();

        /// <summary>
        /// 
        /// </summary>
        public SGLFrameFormat06 SGLFrameFormat06 = new SGLFrameFormat06();

        /// <summary>
        /// 
        /// </summary>
        public SGLFrameFormat18Or28 SGLFrameFormat18Or28 = new SGLFrameFormat18Or28();

        /// <summary>
        /// 
        /// </summary>
        public SGLFrameFormat11Or12Or22 SGLFrameFormat11Or12Or22 = new SGLFrameFormat11Or12Or22();

        /// <summary>
        /// 
        /// </summary>
        public SGLFrameFormat62 SGLFrameFormat62 = new SGLFrameFormat62();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] GetOriginBuffer()
        {
            MemoryStream memoryStream = new MemoryStream();

            byte[] byteUSHORT = new byte[sizeof( ushort )];

            byteUSHORT[0] = (byte)( this.FrameWidth & 0xFF );
            byteUSHORT[1] = (byte)( ( this.FrameWidth & 0xFF00 ) >> 8 );
            memoryStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( this.FrameHeight & 0xFF );
            byteUSHORT[1] = (byte)( ( this.FrameHeight & 0xFF00 ) >> 8 );
            memoryStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( this.CenterX & 0xFF );
            byteUSHORT[1] = (byte)( ( this.CenterX & 0xFF00 ) >> 8 );
            memoryStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            byteUSHORT[0] = (byte)( this.CenterY & 0xFF );
            byteUSHORT[1] = (byte)( ( this.CenterY & 0xFF00 ) >> 8 );
            memoryStream.Write( byteUSHORT, 0, byteUSHORT.Length );

            memoryStream.WriteByte( this.BlocksX );
            memoryStream.WriteByte( this.BlocksY );

            //switch ( Format )
            //{
            //    case 0x02:

            //        return null;
            //        break;
            //    case 0x82:

            //        return null;
            //        break;
            //    case 0x88:

            //        return null;
            //        break;
            //    case 0x06:

            //        return null;
            //        break;
            //    case 0x18:
            //    case 0x28:

            //        return null;
            //        break;
            //    case 0x11:
            //    case 0x12:
            //    case 0x22:

            byte[] byteFrameBuffer = SGLFrameFormat11Or12Or22.GetOriginBuffer();
            if ( byteFrameBuffer == null )
                return null;

            memoryStream.Write( byteFrameBuffer, 0, byteFrameBuffer.Length );

                //    break;
                //case 0x62:

                //    return null;
                //    break;
                //default:

                //    return null;
                //    break;
            //}

            return memoryStream.ToArray();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLFrameFormat82
    {
        //82: 未压缩，有Alpha通道 （高速版本）

        // 帧的像素数据 （BGR 565）[FrameWidth * FrameHeight * 2]
        public byte[] FrameData = new byte[0];

        // 帧的通明值[FrameWidth * FrameHeight * 2]
        public byte[] AlphaData = new byte[0];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sglFrame"></param>
        /// <returns></returns>
        public static SGLFrameFormat82 GetSGLFrameFormat82( FileStream fileStream, SGLFrame sglFrame )
        {
            SGLFrameFormat82 sglFrameFormat82 = new SGLFrameFormat82();

            sglFrameFormat82.FrameData = new byte[sglFrame.FrameWidth * sglFrame.FrameHeight * 2];
            fileStream.Read( sglFrameFormat82.FrameData, 0, sglFrameFormat82.FrameData.Length );

            sglFrameFormat82.AlphaData = new byte[sglFrame.FrameWidth * sglFrame.FrameHeight * 2];
            fileStream.Read( sglFrameFormat82.AlphaData, 0, sglFrameFormat82.AlphaData.Length );

            return sglFrameFormat82;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLFrameFormat88
    {
        //88: 未压缩 （高速版本）

        // 帧的像素数据 （BGR 565）[FrameWidth * FrameHeight * 2]
        public byte[] FrameData = new byte[0];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sglFrame"></param>
        /// <returns></returns>
        public static SGLFrameFormat88 GetSGLFrameFormat88( FileStream fileStream, SGLFrame sglFrame )
        {
            SGLFrameFormat88 sglFrameFormat88 = new SGLFrameFormat88();

            sglFrameFormat88.FrameData = new byte[sglFrame.FrameWidth * sglFrame.FrameHeight * 2];
            fileStream.Read( sglFrameFormat88.FrameData, 0, sglFrameFormat88.FrameData.Length );

            return sglFrameFormat88;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class SGLFrameFormat06
    {
        //06: 已压缩 有Alpha通道（高速版本）

        // 帧的压缩数据的大小
        public uint FrameSize = 0;

        // 帧的像素的压缩数据 （BGR 565）[FrameSize]
        public byte[] FrameData = new byte[0];

        // Alpha的压缩数据的大小
        public uint AlphaSize = 0;

        // Alpha的压缩数据[AlphaSize]
        public byte[] AlphaData = new byte[0];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sglFrame"></param>
        /// <returns></returns>
        public static SGLFrameFormat06 GetSGLFrameFormat06( FileStream fileStream, SGLFrame sglFrame )
        {
            SGLFrameFormat06 sglFrameFormat06 = new SGLFrameFormat06();

            byte[] byteUINT = new byte[sizeof( uint )];

            fileStream.Read( byteUINT, 0, byteUINT.Length );
            sglFrameFormat06.FrameSize = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

            sglFrameFormat06.FrameData = new byte[sglFrameFormat06.FrameSize];
            fileStream.Read( sglFrameFormat06.FrameData, 0, sglFrameFormat06.FrameData.Length );

            fileStream.Read( byteUINT, 0, byteUINT.Length );
            sglFrameFormat06.AlphaSize = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

            sglFrameFormat06.AlphaData = new byte[sglFrameFormat06.AlphaSize];
            fileStream.Read( sglFrameFormat06.AlphaData, 0, sglFrameFormat06.AlphaData.Length );

            return sglFrameFormat06;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLFrameFormat18Or28
    {
        //18, 28: 已压缩 （高速版本）

        // 帧的压缩数据的大小
        public uint FrameSize = 0;

        // 帧的压缩数据 （BGR 565）[FrameSize]
        public byte[] FrameData = new byte[0];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sglFrame"></param>
        /// <returns></returns>
        public static SGLFrameFormat18Or28 GetSGLFrameFormat18Or28( FileStream fileStream, SGLFrame sglFrame )
        {
            SGLFrameFormat18Or28 sglFrameFormat18Or28 = new SGLFrameFormat18Or28();

            byte[] byteUINT = new byte[sizeof( uint )];

            fileStream.Read( byteUINT, 0, byteUINT.Length );
            sglFrameFormat18Or28.FrameSize = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

            sglFrameFormat18Or28.FrameData = new byte[sglFrameFormat18Or28.FrameSize];
            fileStream.Read( sglFrameFormat18Or28.FrameData, 0, sglFrameFormat18Or28.FrameData.Length );

            return sglFrameFormat18Or28;
        }
    }

    public class SGLFrameFormat02Data
    {
        // 块的宽度
        public byte BlockWidth = 0;

        // 块的高度
        public byte BlockHeight = 0;

        // 块的像素数据 （BGR 565）[BlocksX * BlocksY * 2]
        public byte[] BlockData = new byte[0];
    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLFrameFormat02
    {
        //02: 未压缩，有分块（高速版本）

        public SGLFrameFormat02Data[] SGLFrameFormat02Data = new SGLFrameFormat02Data[0];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sglFrame"></param>
        /// <returns></returns>
        public static SGLFrameFormat02 GetSGLFrameFormat02( FileStream fileStream, SGLFrame sglFrame )
        {
            SGLFrameFormat02 sglFrameFormat02 = new SGLFrameFormat02();

            int iBlocksSize = sglFrame.BlocksX * sglFrame.BlocksY;

            sglFrameFormat02.SGLFrameFormat02Data = new SGLFrameFormat02Data[iBlocksSize];
            for ( int iIndex = 0; iIndex < iBlocksSize; iIndex++ )
            {
                sglFrameFormat02.SGLFrameFormat02Data[iIndex] = new SGLFrameFormat02Data();
                sglFrameFormat02.SGLFrameFormat02Data[iIndex].BlockWidth = (byte)fileStream.ReadByte();
                sglFrameFormat02.SGLFrameFormat02Data[iIndex].BlockHeight = (byte)fileStream.ReadByte();

                sglFrameFormat02.SGLFrameFormat02Data[iIndex].BlockData = new byte[sglFrameFormat02.SGLFrameFormat02Data[iIndex].BlockWidth * sglFrameFormat02.SGLFrameFormat02Data[iIndex].BlockHeight * 2];
                fileStream.Read( sglFrameFormat02.SGLFrameFormat02Data[iIndex].BlockData, 0, sglFrameFormat02.SGLFrameFormat02Data[iIndex].BlockData.Length );
            }

            return sglFrameFormat02;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct TargaHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public const int TargaHeaderSize = 18;

        public byte Length;
        public byte ColorMapType;
        public byte ImageType;
        public ushort ColorMapOrigin;
        public ushort ColorMapSize;
        public byte ColorMapEntrySize;
        public ushort XOrigin;
        public ushort YOrigin;
        public ushort Width;
        public ushort Height;
        public byte PixelSize;
        public byte ImageDescriptor;

        public static TargaHeader GetTargaHeader( byte[] targaBuffer )
        {
            TargaHeader targaHeader = new TargaHeader();

            targaHeader.Length = targaBuffer[0];
            targaHeader.ColorMapType = targaBuffer[1];
            targaHeader.ImageType = targaBuffer[2];

            targaHeader.ColorMapOrigin = (ushort)( targaBuffer[3] | targaBuffer[4] << 8 );
            targaHeader.ColorMapSize = (ushort)( targaBuffer[5] | targaBuffer[6] << 8 );

            targaHeader.ColorMapEntrySize = targaBuffer[7];

            targaHeader.XOrigin = (ushort)( targaBuffer[8] | targaBuffer[9] << 8 );
            targaHeader.YOrigin = (ushort)( targaBuffer[10] | targaBuffer[11] << 8 );

            targaHeader.Width = (ushort)( targaBuffer[12] | targaBuffer[13] << 8 );
            targaHeader.Height = (ushort)( targaBuffer[14] | targaBuffer[15] << 8 );

            targaHeader.PixelSize = targaBuffer[16];
            targaHeader.ImageDescriptor = targaBuffer[17];

            return targaHeader;
        }

        public static byte[] GetTargaHeader( ushort iWidth, ushort iHeight )
        {
            byte[] returnBuffer = new byte[18];

            returnBuffer[0] = 0;
            returnBuffer[1] = 0;
            returnBuffer[2] = 2;

            returnBuffer[3] = 0;
            returnBuffer[4] = 0;

            returnBuffer[5] = 0;
            returnBuffer[6] = 0;

            returnBuffer[7] = 24;

            returnBuffer[8] = 0;
            returnBuffer[9] = 0;

            returnBuffer[10] = 0;
            returnBuffer[11] = 0;

            returnBuffer[12] = (byte)( iWidth & 0x00FF );
            returnBuffer[13] = (byte)( ( iWidth & 0xFF00 ) >> 8 );

            returnBuffer[14] = (byte)( iHeight & 0x00FF );
            returnBuffer[15] = (byte)( ( iHeight & 0xFF00 ) >> 8 );

            returnBuffer[16] = 32;
            returnBuffer[17] = 0x20;

            return returnBuffer;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLFrameFormat11Or12Or22
    {
        //11, 12, 22: 已压缩，有分块（高画质版本）
        public struct SGLFrameData
        {
            // 块的宽度
            public byte BlockWidth;

            // 块的高度
            public byte BlockHeight;

            // 块的压缩数据的大小
            public uint BlockSize;

            // 块的像素的压缩数据 （BGRA 4444）[BlockSize]
            public byte[] BlockData;
        }

        // 文件偏移
        public long FilePosition = 0;

        /// <summary>
        /// 
        /// </summary>
        public SGLFrame SGLFrame;
        /// <summary>
        /// 
        /// </summary>
        public FileStream FileStream;

        /// <summary>
        /// 
        /// </summary>
        public SGLFrameData[] SGLFrameDataArray = new SGLFrameData[0];

        /// <summary>
        /// 
        /// </summary>
        public byte[] DecodeFrame32Buffer = new byte[0];

        /// <summary>
        /// 
        /// </summary>
        public MemoryStream DecodeFrame32Stream;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] GetOriginBuffer()
        {
            if ( DecodeFrame32Stream == null )
                if ( LoadImage() == false )
                    return null;

            if ( SGLFrameDataArray.Length <= 0 )
                return null;

            MemoryStream memoryStream = new MemoryStream();

            foreach ( SGLFrameData sglFrameData in SGLFrameDataArray )
            {
                memoryStream.WriteByte( sglFrameData.BlockWidth );
                memoryStream.WriteByte( sglFrameData.BlockHeight );

                byte[] byteUINT = new byte[sizeof( uint )];

                byteUINT[0] = (byte)( sglFrameData.BlockSize & 0xFF );
                byteUINT[1] = (byte)( ( sglFrameData.BlockSize & 0xFF00 ) >> 8 );
                byteUINT[2] = (byte)( ( sglFrameData.BlockSize & 0xFF0000 ) >> 16 );
                byteUINT[3] = (byte)( ( sglFrameData.BlockSize & 0xFF000000 ) >> 24 );
                memoryStream.Write( byteUINT, 0, byteUINT.Length );

                if ( sglFrameData.BlockData == null )
                    return null;

                memoryStream.Write( sglFrameData.BlockData, 0, sglFrameData.BlockData.Length );
            }

            return memoryStream.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="sglFrame"></param>
        /// <returns></returns>
        public bool LoadImage()
        {
            FileStream.Seek( FilePosition, SeekOrigin.Begin );

            this.DecodeFrame32Buffer = new byte[SGLFrame.FrameWidth * SGLFrame.FrameHeight * 4 + TargaHeader.TargaHeaderSize];
            //sglFrameFormat11Or12Or22.DecodeFrame32Buffer = new byte[sglFrame.FrameWidth * sglFrame.FrameHeight * 2];

            byte[] byteUINT = new byte[sizeof( uint )];

            int iIndexBlocks = 0;
            SGLFrameDataArray = new SGLFrameData[SGLFrame.BlocksY * SGLFrame.BlocksX];

            //MessageBox.Show( SGLFrame.BlocksY.ToString() );
            //MessageBox.Show( SGLFrame.BlocksX.ToString() );

            for ( int iBlocksY = 0; iBlocksY < SGLFrame.BlocksY; iBlocksY++ )
            {
                for ( int iBlocksX = 0; iBlocksX < SGLFrame.BlocksX; iBlocksX++ )
                {
                    SGLFrameData sglFrameData = new SGLFrameData();
                    sglFrameData.BlockWidth = (byte)FileStream.ReadByte();
                    sglFrameData.BlockHeight = (byte)FileStream.ReadByte();

                    //Debug.WriteLine( string.Format( "sglFrameData.BlockWidth = {0}, sglFrameData.BlockHeight = {1}", sglFrameData.BlockWidth, sglFrameData.BlockHeight ) );

                    FileStream.Read( byteUINT, 0, byteUINT.Length );
                    sglFrameData.BlockSize = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

                    sglFrameData.BlockData = new byte[sglFrameData.BlockSize];
                    FileStream.Read( sglFrameData.BlockData, 0, sglFrameData.BlockData.Length );

                    //FileStream fileStream = File.Open( string.Format( "f:\\[{0}][{1}]-o.bin", sglFrameData.BlockWidth, sglFrameData.BlockHeight ), FileMode.Create );
                    //fileStream.Write( sglFrameData.BlockData, 0, sglFrameData.BlockData.Length );
                    //fileStream.Close();

                    byte[] bufferRLE16 = new byte[( sglFrameData.BlockWidth + 1 ) * ( sglFrameData.BlockHeight + 1 ) * 2];
                    SGLImage.SGLDecodeRLE16( sglFrameData.BlockData, ref bufferRLE16 );

                    //fileStream = File.Open( string.Format( "f:\\[{0}][{1}]-x.bin", sglFrameData.BlockWidth, sglFrameData.BlockHeight ), FileMode.Create );
                    //fileStream.Write( bufferRLE16, 0, bufferRLE16.Length );
                    //fileStream.Close();

                    //MessageBox.Show( sglFrameData.BlockHeight.ToString() );
                    //MessageBox.Show( sglFrameData.BlockWidth.ToString() );

                    int iIndexLine = ( ( ( iBlocksY * 255 ) * SGLFrame.FrameWidth * 4 /* Width Line Szie */) + iBlocksX * 255 * 4 ) + TargaHeader.TargaHeaderSize;
                    //int iIndexLine = ( iBlocksY * 256 * ( sglFrame.FrameWidth * 2 /* Width Line Szie */) + iBlocksX * 256 * 2 );
                    int iIndexRLE16 = 0;
                    for ( int iIndexH = 0; iIndexH <= sglFrameData.BlockHeight; iIndexH++ )
                    {
                        int iIndexCurLine = iIndexLine;
                        for ( int iIndexW = 0; iIndexW <= sglFrameData.BlockWidth; iIndexW++ )
                        {
                            //if ( bufferRLE16[iIndexRLE16] == 0 && bufferRLE16[iIndexRLE16 + 1] == 0 )
                            //{
                            //    bufferRLE16[iIndexRLE16] = 0xFF;
                            //    bufferRLE16[iIndexRLE16 + 1] = 0xFF;
                            //}

                            //ushort scrCol = (ushort)( ( bufferRLE16[iIndexRLE16] | bufferRLE16[iIndexRLE16 + 1] << 8 ) );
                            //ushort desCol = (ushort)( sglFrameFormat11Or12Or22.DecodeFrame32Buffer[iIndexCurLine] | ( sglFrameFormat11Or12Or22.DecodeFrame32Buffer[iIndexCurLine + 1] << 8 ) );

                            //SGLImage.Blend( scrCol, ref desCol );
                            //sglFrameFormat11Or12Or22.DecodeFrame32Buffer[iIndexCurLine] = (byte)( desCol & 0xFF );
                            //iIndexCurLine++;
                            //iIndexRLE16++;
                            //sglFrameFormat11Or12Or22.DecodeFrame32Buffer[iIndexCurLine] = (byte)( ( desCol & 0xFF00 ) >> 8 );
                            //iIndexCurLine++;
                            //iIndexRLE16++;

                            //sglFrameFormat11Or12Or22.DecodeFrame32Buffer[iIndexCurLine] = bufferRLE16[iIndexRLE16];
                            //sglFrameFormat11Or12Or22.DecodeFrame32Buffer[iIndexCurLine] = (byte)( ( bufferRLE16[iIndexRLE16] & 0xF0 ) >> 4 );
                            //iIndexCurLine++;
                            //iIndexRLE16++;
                            //sglFrameFormat11Or12Or22.DecodeFrame32Buffer[iIndexCurLine] = bufferRLE16[iIndexRLE16];
                            //iIndexCurLine++;
                            //iIndexRLE16++;

                            this.DecodeFrame32Buffer[iIndexCurLine] = (byte)( ( bufferRLE16[iIndexRLE16] & 0x0F ) << 4 );
                            iIndexCurLine++;
                            this.DecodeFrame32Buffer[iIndexCurLine] = (byte)( bufferRLE16[iIndexRLE16] & 0xF0 );
                            iIndexCurLine++;
                            iIndexRLE16++;

                            this.DecodeFrame32Buffer[iIndexCurLine] = (byte)( ( bufferRLE16[iIndexRLE16] & 0x0F ) << 4 );
                            iIndexCurLine++;
                            this.DecodeFrame32Buffer[iIndexCurLine] = (byte)( bufferRLE16[iIndexRLE16] & 0xF0 );
                            iIndexCurLine++;
                            iIndexRLE16++;
                        }

                        iIndexLine += SGLFrame.FrameWidth * 4;
                        //iIndexLine += ( sglFrame.FrameWidth * 2 - 2 );
                    }

                    SGLFrameDataArray[iIndexBlocks] = sglFrameData;
                    iIndexBlocks++;
                }
            }

            Buffer.BlockCopy( TargaHeader.GetTargaHeader( SGLFrame.FrameWidth, SGLFrame.FrameHeight ), 0, this.DecodeFrame32Buffer, 0, TargaHeader.TargaHeaderSize );

            this.DecodeFrame32Stream = new MemoryStream( this.DecodeFrame32Buffer );
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sglFrame"></param>
        /// <returns></returns>
        public static SGLFrameFormat11Or12Or22 GetSGLFrameFormat11Or12Or22( FileStream fileStream, SGLFrame sglFrame )
        {
            SGLFrameFormat11Or12Or22 sglFrameFormat11Or12Or22 = new SGLFrameFormat11Or12Or22();

            sglFrameFormat11Or12Or22.FileStream = fileStream;
            sglFrameFormat11Or12Or22.SGLFrame = sglFrame;
            sglFrameFormat11Or12Or22.FilePosition = fileStream.Position;

            byte[] byteUINT = new byte[sizeof( uint )];

            for ( int iBlocksY = 0; iBlocksY < sglFrame.BlocksY; iBlocksY++ )
            {
                for ( int iBlocksX = 0; iBlocksX < sglFrame.BlocksX; iBlocksX++ )
                {
                    fileStream.Seek( 2, SeekOrigin.Current );

                    fileStream.Read( byteUINT, 0, byteUINT.Length );
                    uint iBlockSize = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

                    fileStream.Seek( iBlockSize, SeekOrigin.Current );
                }
            }

            return sglFrameFormat11Or12Or22;
        }
    }

    //62: 已压缩 有Alpha通道（高画质版本）
    public class SGLFrameFormat62Data
    {
        // 块的宽度
        public byte BlockWidth = 0;

        // 块的高度
        public byte BlockHeight = 0;

        // 块的压缩数据的大小
        public uint BlockSize = 0;

        // 块的像素的压缩数据 （BGRA 4444）[BlockSize]
        public byte[] BlockData = new byte[0];

        // Alpha的压缩数据的大小
        public uint AlphaSize = 0;

        // Alpha的压缩数据[AlphaSize]
        public byte[] AlphaData = new byte[0];
    }

    /// <summary>
    /// 
    /// </summary>
    public class SGLFrameFormat62
    {
        public SGLFrameFormat62Data[] SGLFrameFormat62Data = new SGLFrameFormat62Data[0];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sglFrame"></param>
        /// <returns></returns>
        public static SGLFrameFormat62 GetSGLFrameFormat62( FileStream fileStream, SGLFrame sglFrame )
        {
            SGLFrameFormat62 sglFrameFormat62 = new SGLFrameFormat62();

            int iBlocksSize = sglFrame.BlocksX * sglFrame.BlocksY;

            sglFrameFormat62.SGLFrameFormat62Data = new SGLFrameFormat62Data[iBlocksSize];
            for ( int iIndex = 0; iIndex < iBlocksSize; iIndex++ )
            {
                sglFrameFormat62.SGLFrameFormat62Data[iIndex] = new SGLFrameFormat62Data();

                sglFrameFormat62.SGLFrameFormat62Data[iIndex].BlockWidth = (byte)fileStream.ReadByte();
                sglFrameFormat62.SGLFrameFormat62Data[iIndex].BlockHeight = (byte)fileStream.ReadByte();

                byte[] byteUINT = new byte[sizeof( uint )];

                fileStream.Read( byteUINT, 0, byteUINT.Length );
                sglFrameFormat62.SGLFrameFormat62Data[iIndex].BlockSize = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

                sglFrameFormat62.SGLFrameFormat62Data[iIndex].BlockData = new byte[sglFrameFormat62.SGLFrameFormat62Data[iIndex].BlockSize];
                fileStream.Read( sglFrameFormat62.SGLFrameFormat62Data[iIndex].BlockData, 0, sglFrameFormat62.SGLFrameFormat62Data[iIndex].BlockData.Length );

                fileStream.Read( byteUINT, 0, byteUINT.Length );
                sglFrameFormat62.SGLFrameFormat62Data[iIndex].AlphaSize = (uint)( byteUINT[0] | ( byteUINT[1] << 8 ) | ( byteUINT[2] << 16 ) | ( byteUINT[3] << 24 ) );

                sglFrameFormat62.SGLFrameFormat62Data[iIndex].AlphaData = new byte[sglFrameFormat62.SGLFrameFormat62Data[iIndex].AlphaSize];
                fileStream.Read( sglFrameFormat62.SGLFrameFormat62Data[iIndex].AlphaData, 0, sglFrameFormat62.SGLFrameFormat62Data[iIndex].AlphaData.Length );
            }

            return sglFrameFormat62;
        }
    }
}
