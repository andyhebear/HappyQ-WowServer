using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Atalasoft.Imaging;
using Atalasoft.Imaging.Codec;
using Atalasoft.Imaging.Codec.Jpeg2000;
using Demo.Mmose.Gui.PropertyGrid;
using System.IO;

namespace Demo.GOSE.SGL.Editor
{
    public partial class CurrentImageControl : UserControl
    {
        public CurrentImageControl()
        {
            InitializeComponent();
        }

        private void CurrentImage_Load( object sender, EventArgs e )
        {
            CreatePropertyGrid();
        }

        private void CreatePropertyGrid()
        {
            PropertyGridItem Category = axPropertyGrid.AddCategory( "文件属性" );

            PropertyGridItem Item = Category.AddChildItem( PropertyItemType.PropertyItemString, "文件全路径", "c:\\11212.sgl" );
            Item.ReadOnly = true;

            Item = Category.AddChildItem( PropertyItemType.PropertyItemNumber, "包含图像数", 4 );
            Item.ReadOnly = true;

            Category.Expanded = true;


            Category = axPropertyGrid.AddCategory( "图像属性" );

            PropertyGridItem ImageAppearance = Category.AddChildItem( PropertyItemType.PropertyItemString, "图像信息", "" );
            ImageAppearance.ReadOnly = true;

            PropertyGridItem ImageFormatAppearance = ImageAppearance.AddChildItem( PropertyItemType.PropertyItemString, "图像大小", "100 : 100" );
            ImageFormatAppearance.ReadOnly = true;

            PropertyGridItem ImageDepthAppearance = ImageAppearance.AddChildItem( PropertyItemType.PropertyItemString, "图像位数", "16 bit" );
            ImageDepthAppearance.ReadOnly = true;

            ImageAppearance.ReadOnly = true;
            ImageAppearance.Expanded = true;

            Item = Category.AddChildItem( PropertyItemType.PropertyItemNumber, "图像格式", 12 );
            Item.ReadOnly = true;

            Category.Expanded = true;


            Category = axPropertyGrid.AddCategory( "帧属性" );

            Item = Category.AddChildItem( PropertyItemType.PropertyItemString, "当前帧", "1/1" );
            Item.ReadOnly = true;

            Item = Category.AddChildItem( PropertyItemType.PropertyItemString, "帧的中心", "0, 0" );
            Item.ReadOnly = true;

            Item = Category.AddChildItem( PropertyItemType.PropertyItemString, "帧的块数", "0, 0" );
            Item.ReadOnly = true;

            Category.Expanded = true;
        }

        private void axPushButton1_ClickEvent( object sender, EventArgs e )
        {
            if ( WorkspaceViewer.Image != null )
                SaveCurrentImage();
        }

        /// <summary>
        /// 
        /// </summary>
        SaveFileDialog m_SaveFileDialog = new SaveFileDialog();
        /// <summary>
        /// 
        /// </summary>
        private void SaveCurrentImage()
        {
            //show the save dialog
            m_SaveFileDialog.DefaultExt = "tga";
            m_SaveFileDialog.FilterIndex = 5;
            m_SaveFileDialog.Filter = HelperMethods.CreateDialogFilter( false );

            if ( m_SaveFileDialog.ShowDialog() == DialogResult.OK )
            {
                ImageType imageType = HelperMethods.GetImageType( m_SaveFileDialog.FilterIndex, false );
                ImageEncoder imageEncoder = HelperMethods.GetEncoderFromType( imageType );

                if ( imageEncoder != null )
                    WorkspaceViewer.Save( m_SaveFileDialog.FileName, imageEncoder );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private SGLEditorDocumentForm m_SGLEditorDocumentForm = null;
        /// <summary>
        /// 
        /// </summary>
        public SGLEditorDocumentForm SGLEditorDocumentForm
        {
            get { return m_SGLEditorDocumentForm; }
            set { m_SGLEditorDocumentForm = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        FolderBrowserDialog m_FolderBrowserDialog = new FolderBrowserDialog();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axPushButton_ClickEvent( object sender, EventArgs e )
        {
            MessageBox.Show( "解压的可能时间比较长 请等待分钟 或更长的时间" );

            if ( m_FolderBrowserDialog.ShowDialog() == DialogResult.OK )
            {
                for ( int i = 0; i < m_SGLEditorDocumentForm.m_SglFileInfo.SGLImage.Length; i++ )
                {
                    SGLImage sglImage = m_SGLEditorDocumentForm.m_SglFileInfo.SGLImage[i];
                    for ( int i2 = 0; i2 < sglImage.SGLFrames.Length; i2++ )
                    {
                        SGLFrame sglFrame = sglImage.SGLFrames[i2];

                        if ( sglFrame.SGLFrameFormat11Or12Or22.DecodeFrame32Stream == null )
                        {
                            if ( sglFrame.SGLFrameFormat11Or12Or22.LoadImage() == false )
                                break;
                            else
                            {
                                Workspace workspace = new Workspace();
                                workspace.Open( sglFrame.SGLFrameFormat11Or12Or22.DecodeFrame32Stream );

                                TgaEncoder encoder = new TgaEncoder();
                                StringBuilder strBuilder = new StringBuilder();

                                strBuilder.Append( m_FolderBrowserDialog.SelectedPath );
                                strBuilder.Append( "\\[" );

                                strBuilder.Append( Path.GetFileNameWithoutExtension( m_SGLEditorDocumentForm.m_SglFileName ) );

                                strBuilder.Append( "]Image[" );
                                strBuilder.Append( i.ToString( "D5" ) );
                                strBuilder.Append( "]" );

                                strBuilder.Append( "Frame[" );
                                strBuilder.Append( i2.ToString( "D3" ) );
                                strBuilder.Append( "]" );

                                strBuilder.Append( "Offset[" );
                                strBuilder.Append( sglFrame.CenterX.ToString( "D4" ) );
                                strBuilder.Append( "X" );
                                strBuilder.Append( sglFrame.CenterY.ToString( "D4" ) );
                                strBuilder.Append( "]" );
                                strBuilder.Append( ".tga" );

                                string imageName = strBuilder.ToString();
                                workspace.Save( imageName, encoder );
                            }
                        }

                    }
                }

                MessageBox.Show( "文件全部解压完成" );
            }
        }

        private void axPushButton2_ClickEvent( object sender, EventArgs e )
        {
#if !DEMO
            SGLEditorDocumentForm.BuildPath();
#else
            MessageBox.Show( SGLEditorDocumentForm.TryMessageInfo );
#endif

        }
    }

    /// <summary>
    /// A collection of static methods.
    /// </summary>
    public sealed class HelperMethods
    {
        //returns an encoder based on image type
        public static ImageEncoder GetEncoderFromType( ImageType type )
        {
            ImageEncoder encoder = null;
            switch ( type )
            {
                case ImageType.Jpeg:
                    encoder = new JpegEncoder();
                    break;
                case ImageType.Png:
                    encoder = new PngEncoder();
                    break;
				case ImageType.J2k:
					encoder = new Jp2Encoder();
					break;
                case ImageType.Bmp:
                    encoder = new BmpEncoder();
                    break;
                case ImageType.Emf:
                    encoder = new EmfEncoder();
                    break;
                case ImageType.Gif:
                    encoder = new GifEncoder();
                    break;
                case ImageType.Pcx:
                    encoder = new PcxEncoder();
                    break;
                case ImageType.Psd:
                    encoder = new PsdEncoder();
                    break;
                case ImageType.Tga:
                    encoder = new TgaEncoder();
                    break;
                case ImageType.Tiff:
                    encoder = new TiffEncoder();
                    break;
                case ImageType.Wbmp:
                    encoder = new WbmpEncoder();
                    break;
                case ImageType.Wmf:
                    encoder = new WmfEncoder();
                    break;
                case ImageType.Tla:
                    encoder = new TlaEncoder();
                    break;
                default:
                    MessageBox.Show( "当前的图像格式不支持" );
                    break;
            }

            return encoder;
        } 

        /// <summary>
        /// Creates the filter string for open and save dialogs.
        /// </summary>
        /// <param name="isOpenDialog">Set to true if this filter if for an open dialog.</param>
        /// <returns>The filter string for an open or save dialog.</returns>
        public static string CreateDialogFilter( bool isOpenDialog )
        {
            string filter = ( isOpenDialog ? "All Supported Images|*.jpg;*.png;*.tif;*.tiff;*.pcx;*.tga;*.bmp;*.wmf;*.emf;*.psd;*.wbmp;*.gif;*.tla;*.pcd;*.jp2;*.j2k;*.jpf;*.jb2;*.crw;*.dcr;*.nef;*.srf;*.orf;*.pdf|" : "" );
            filter += "Joint Photographic Experts Group (*.jpg)|*.jpg";
            filter += "|Portable Network Graphic (*.png)|*.png";
            filter += ( isOpenDialog ? "|Tagged Image File (*.tif, *.tiff)|*.tif;*.tiff" : "|Tagged Image File (*.tif)|*.tif" );
            filter += "|ZSoft PaintBrush (*.pcx)|*.pcx";
            filter += "|Truevision Targa (*.tga)|*.tga";
            filter += "|Windows Bitmap (*.bmp)|*.bmp";
            filter += "|Windows Meta File (*.wmf)|*.wmf";
            filter += "|Enhanced Windows Meta File (*.emf)|*.emf";
            filter += "|Adobe (tm) Photoshop format (*.psd)|*.psd";
            filter += "|Wireless Bitmap (*.wbmp)|*.wbmp";
            filter += "|Graphics Interchange Format (*.gif)|*.gif";
            filter += "|Smaller Animals TLA (*.tla)|*.tla";
            if ( isOpenDialog ) filter += "|Kodak (tm) PhotoCD (*.pcd)|*.pcd";

			filter += "|JPEG2000 (*.jpf *.jp2, *.jpc *.j2c *.j2k)|*.jpf;*.jp2;*.jpc;*.j2c;*.j2k";

            if ( isOpenDialog )
            {
				filter += "|PDF (*.pdf)|*.pdf";
            }
            else if ( AtalaImage.Edition == LicenseEdition.Document )
                filter += "|PDF (*.pdf)|*.pdf";

            if ( !isOpenDialog ) filter += "|Animated GIF (*.gif)|*.gif";
            if ( !isOpenDialog ) filter += "|RAW Images|*.cr2;*.crw;*.dcr;*.nef;*.orf;*.srf;*.dng";

			filter += "|JBIG2 (*.jb2) | *.jb2";
            return filter;
        }

        /// <summary>
        /// This method takes the filter index and returns the image type.
        /// </summary>
        /// <param name="filterIndex">Filter index from a file dialog.</param>
        /// <returns>ImageType</returns>
        public static ImageType GetImageType( int filterIndex, bool isOpenDialog )
        {
            if ( isOpenDialog ) filterIndex--;

            switch ( filterIndex )
            {
                case 1: return ImageType.Jpeg;
                case 2: return ImageType.Png;
                case 3: return ImageType.Tiff;
                case 4: return ImageType.Pcx;
                case 5: return ImageType.Tga;
                case 6: return ImageType.Bmp;
                case 7: return ImageType.Wmf;
                case 8: return ImageType.Emf;
                case 9: return ImageType.Psd;
                case 10: return ImageType.Wbmp;
                case 11: return ImageType.Gif;
                case 12: return ImageType.Tla;
                case 13: return ( isOpenDialog ? ImageType.Pcd : ImageType.J2k );
                case 14: return ( isOpenDialog ? ImageType.J2k : ImageType.Unknown );
                case 15: return ImageType.Gif;
            }

            return ImageType.Unknown;
        }

        /// <summary>
        /// Fills the command arrays with method types.
        /// </summary>
        /// <param name="channelCommand"></param>
        /// <param name="effectCommand"></param>
        /// <param name="filterCommand"></param>
        /// <param name="transformCommand"></param>
        public static void GetReflectionMethods( out Type[] channelCommand, out Type[] effectCommand, out Type[] filterCommand, out Type[] transformCommand )
        {
            // Just to make the compiler happy.
            channelCommand = null;
            effectCommand = null;
            filterCommand = null;
            transformCommand = null;

            // Load the assumebly.
            Assembly myAssembly = System.Reflection.Assembly.Load( "Atalasoft.Imaging" );
            if ( myAssembly == null )
                throw new ArgumentException( "Unable to load the Atalasoft.Imaging assembly." );

            // Get all of the assembly types.
            Type[] myTypes = myAssembly.GetExportedTypes();

            // Create temporary storage for the types.
            // 100 elements each should be enough.
            Type[] channels = new Type[100];
            Type[] effects = new Type[100];
            Type[] filters = new Type[100];
            Type[] transforms = new Type[100];

            int channelCount = 0;
            int effectCount = 0;
            int filterCount = 0;
            int transformCount = 0;

            // Loop through all of the types and fill out the arrays.
            foreach ( Type type in myTypes )
            {
                if ( type.IsClass && type.IsPublic )
                {
                    switch ( type.Namespace )
                    {
                        case "Atalasoft.Imaging.Imaging.Channels":
                            channels[channelCount] = type;
                            channelCount++;
                            break;
                        case "Atalasoft.Imaging.Imaging.Effects":
                            effects[effectCount] = type;
                            effectCount++;
                            break;
                        case "Atalasoft.Imaging.Imaging.Filters":
                            filters[filterCount] = type;
                            filterCount++;
                            break;
                        case "Atalasoft.Imaging.Imaging.Transforms":
                            transforms[transformCount] = type;
                            transformCount++;
                            break;
                    }
                }
            }

            // Copy the data to the arrays which were passed in.
            if ( channelCount > 0 )
            {
                channelCommand = new Type[channelCount];
                Array.Copy( channels, 0, channelCommand, 0, channelCount );
            }

            if ( effectCount > 0 )
            {
                effectCommand = new Type[effectCount];
                Array.Copy( effects, 0, effectCommand, 0, effectCount );
            }

            if ( filterCount > 0 )
            {
                filterCommand = new Type[filterCount];
                Array.Copy( filters, 0, filterCommand, 0, filterCount );
            }

            if ( transformCount > 0 )
            {
                transformCommand = new Type[transformCount];
                Array.Copy( transforms, 0, transformCommand, 0, transformCount );
            }

        }

        /// <summary>
        /// Break apart the command name to make it more readable.
        /// </summary>
        /// <param name="commandName">Command name to separate.</param>
        /// <returns>Formated command name.</returns>
        public static string SeparateCommandName( string commandName )
        {
            string letter = "";
            string nice = "";
            int lastPos = 0;

            for ( int i = 1; i < commandName.Length; i++ )
            {
                letter = commandName[i].ToString();
                if ( letter.ToUpper() == letter )
                {
                    nice += ( commandName.Substring( lastPos, i - lastPos ) + " " );
                    lastPos = i;
                }
            }

            nice.Trim();
            return nice;
        }
    }
}
