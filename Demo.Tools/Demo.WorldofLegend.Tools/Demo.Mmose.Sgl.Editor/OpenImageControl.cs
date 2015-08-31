using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Demo.Mmose.Gui.PropertyGrid;

namespace Demo.GOSE.SGL.Editor
{
    public partial class OpenImageControl : UserControl
    {
        public OpenImageControl()
        {
            InitializeComponent();

            WorkspaceViewer.m_OpenImageControl = this;
        }

        private void OpenImage_Load( object sender, EventArgs e )
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
        private bool m_IsOpenImage = false;
        /// <summary>
        /// 
        /// </summary>
        public bool IsOpenImage
        {
            get { return m_IsOpenImage; }
        }

        private void axPushButton1_ClickEvent( object sender, EventArgs e )
        {
            OpenAndLoadImage();
        }

        OpenFileDialog m_OpenFileDialog = new OpenFileDialog();
        private void OpenAndLoadImage()
        {
            m_OpenFileDialog.DefaultExt = "tga";
            m_OpenFileDialog.FilterIndex = 6;
            m_OpenFileDialog.Filter = HelperMethods.CreateDialogFilter( true );

            if ( m_OpenFileDialog.ShowDialog() == DialogResult.OK )
            {
                WorkspaceViewer.m_IsFirst = true;
                WorkspaceViewer.Open( m_OpenFileDialog.FileName );
                m_IsOpenImage = true;
            }
        }

        public void LoadImage( string strFileName)
        {
            WorkspaceViewer.m_IsFirst = true;
            WorkspaceViewer.Open( strFileName );
            m_IsOpenImage = true;

            int iIndex = strFileName.IndexOf( "Offset[" );
            if ( iIndex != -1 )
            {
                iIndex += "Offset[".Length;

                int iIndex2 = strFileName.IndexOf( "X", iIndex );
                if ( iIndex2 != -1 )
                {
                    string strX = strFileName.Substring( iIndex, iIndex2 - iIndex );

                    iIndex2 += "X".Length;

                    int iIndex3 = strFileName.IndexOf( "]", iIndex2 );
                    if ( iIndex3 != -1 )
                    {
                        string strY = strFileName.Substring( iIndex2, iIndex3 - iIndex2 );

                        axFlatEditX.Text = strX;
                        axFlatEditY.Text = strY;

                        WorkspaceViewer.m_IsFirst = false;
                        WorkspaceViewer.m_Point = new Point( int.Parse( strX ), int.Parse( strY ) );
                    }
                }
            }
        }

        public bool m_IsBackgroundChange = false;
        private void axPushButton2_ClickEvent( object sender, EventArgs e )
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "tga";
            openFileDialog.FilterIndex = 0;
            openFileDialog.Filter = HelperMethods.CreateDialogFilter( true );

            if ( openFileDialog.ShowDialog() == DialogResult.OK )
            {
                WorkspaceViewer.BackgroundImageLayout = ImageLayout.None;
                WorkspaceViewer.BackgroundImage = Image.FromFile( openFileDialog.FileName );
                m_IsBackgroundChange = true;
            }
        }
    }
}
