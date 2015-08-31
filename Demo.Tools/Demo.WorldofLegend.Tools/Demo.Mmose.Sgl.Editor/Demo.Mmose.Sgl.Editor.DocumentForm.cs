using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Atalasoft.Imaging;
using Atalasoft.Imaging.Codec;
using Demo.Mmose.Gui.TaskPanel;
using Demo.Mmose.Gui.CommandBars;

namespace Demo.GOSE.SGL.Editor
{
    public partial class SGLEditorDocumentForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public static string TryMessageInfo = "你现在使用的是试用版，有功能限制，如果想完全使用请去注册。";

        /// <summary>
        /// 
        /// </summary>
        private SGLEditorForm m_SGLEditorForm = null;
        /// <summary>
        /// 
        /// </summary>
        public SGLEditorForm SGLEditorForm
        {
            get { return m_SGLEditorForm; }
            set { m_SGLEditorForm = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String m_SglFileName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public SGLFileInfo m_SglFileInfo = new SGLFileInfo();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringFileName"></param>
        /// <returns></returns>
        public bool OpenSGLFile( String stringFileName )
        {
            m_SglFileName = stringFileName;

            return m_SglFileInfo.OpenSGLFile( stringFileName, ListViewSGLImage );
        }

        public SGLEditorDocumentForm()
        {
            InitializeComponent();
        }

        private void SGLEditorDocumentForm_Load( object sender, EventArgs e )
        {
            TaskPanelGroup GroupListView1 = axTaskPanel.Groups.Add( ResourceID.ID_SGL_IMAGE, "SGL 图像" );

            TaskPanelGroupItem ItemListView1 = GroupListView1.Items.Add( ResourceID.ID_SGL_IMAGE_LISTVIEW, string.Empty, XTPTaskPanelItemType.xtpTaskItemTypeControl, -1 );
            ItemListView1.Handle = ListViewSGLImage.Handle.ToInt32();
            ListViewSGLImage.BackColor = System.Drawing.ColorTranslator.FromOle( (int)ItemListView1.BackColor );

            GroupListView1.Expanded = true;


            TaskPanelGroup GroupListView2 = axTaskPanel.Groups.Add( ResourceID.ID_SGL_FRAME, "SGL 帧" );

            TaskPanelGroupItem ItemListView2 = GroupListView2.Items.Add( ResourceID.ID_SGL_FRAME_LISTVIEW, string.Empty, XTPTaskPanelItemType.xtpTaskItemTypeControl, -1 );
            ItemListView2.Handle = ListViewSGLFrame.Handle.ToInt32();
            ListViewSGLFrame.BackColor = System.Drawing.ColorTranslator.FromOle( (int)ItemListView2.BackColor );
            GroupListView2.Expanded = true;

            axTaskPanel.Reposition();

            CreateTabControl();

        }

        private CurrentImageControl PageCurrentImageControl = null;
        public OpenImageControl PageOpenImageControl = null;
        private void CreateTabControl()
        {
            axTabControl.Dock = DockStyle.Fill;

            PageCurrentImageControl = new CurrentImageControl();
            PageCurrentImageControl.Parent = axTabControl;
            PageCurrentImageControl.SGLEditorDocumentForm = this;

            axTabControl.InsertItem( 0, "当前的图像帧", PageCurrentImageControl.Handle.ToInt32(), 300 );

            PageOpenImageControl = new OpenImageControl();
            PageOpenImageControl.Parent = axTabControl;
            PageOpenImageControl.SGLEditorDocumentForm = this;

            axTabControl.InsertItem( 1, "打开的图像帧", PageOpenImageControl.Handle.ToInt32(), 300 );
        }

        /// <summary>
        /// 
        /// </summary>
        public void InsertImage()
        {
#if !DEMO
            int x = 0;
            if ( int.TryParse( PageOpenImageControl.axFlatEditX.Text, out x ) == false )
            {
                MessageBox.Show( "打开的图像帧的面板中,中心X输入框中输入的数字" );
                return;
            }
            int y = 0;
            if ( int.TryParse( PageOpenImageControl.axFlatEditY.Text, out y ) == false )
            {
                MessageBox.Show( "打开的图像帧的面板中,中心Y输入框中输入的数字" );
                return;
            }

            if ( ListViewSGLImage.SelectedIndices.Count != 1 )
                return;

            byte[] imageBuffer = GetImageData();
            if ( imageBuffer == null )
                return;


            foreach ( int index in ListViewSGLImage.SelectedIndices )
            {
                SGLImage sglImage = m_SglFileInfo.SGLImage[index];

                foreach ( SGLFrame sglFrame in sglImage.SGLFrames )
                {
                    if ( sglFrame.SGLFrameFormat11Or12Or22.DecodeFrame32Stream == null )
                    {
                        if ( sglFrame.SGLFrameFormat11Or12Or22.LoadImage() == false )
                            break;
                    }
                }

                m_SglFileInfo.InsertImage( index, imageBuffer, x, y );

                int iIndex = 0;
                ListViewSGLFrame.Items.Clear();
                foreach ( SGLFrame sglFrame in sglImage.SGLFrames )
                {
                    ListViewItem listViewItem = new ListViewItem( iIndex.ToString(), 0 );
                    listViewItem.SubItems.Add( sglFrame.FrameWidth.ToString() );
                    listViewItem.SubItems.Add( sglFrame.FrameHeight.ToString() );
                    listViewItem.SubItems.Add( sglFrame.CenterX.ToString() );
                    listViewItem.SubItems.Add( sglFrame.CenterY.ToString() );
                    listViewItem.SubItems.Add( sglFrame.BlocksX.ToString() );
                    listViewItem.SubItems.Add( sglFrame.BlocksY.ToString() );

                    ListViewSGLFrame.Items.Add( listViewItem );

                    if ( iIndex == 0 )
                        ShowImage( sglImage, sglFrame );

                    iIndex++;
                }

                ListViewSGLImage.Items[index].SubItems[1].Text = "18";
                ListViewSGLImage.Items[index].SubItems[2].Text = sglImage.SGLFrames.Length.ToString();
                ListViewSGLImage.RedrawItems( index, index, true );
            }
#else
            MessageBox.Show( TryMessageInfo );
#endif
        }

        private byte[] GetImageData()
        {
            if ( PageOpenImageControl.WorkspaceViewer.Image == null )
                return null;

            AtalaImage atalaImage = null;
            if ( PageOpenImageControl.WorkspaceViewer.Image.PixelFormat == PixelFormat.Pixel32bppBgra )
                atalaImage = PageOpenImageControl.WorkspaceViewer.Image;
            else
                atalaImage = PageOpenImageControl.WorkspaceViewer.Image.GetChangedPixelFormat( PixelFormat.Pixel32bppBgra );

            byte[] memoryBuffer = new byte[atalaImage.Width * atalaImage.Height * 4 + 1042 + 18];
            MemoryStream memoryStream = new MemoryStream( memoryBuffer );

            TgaEncoder tgaEncoder = new TgaEncoder();
            tgaEncoder.Save( memoryStream, atalaImage, null );

            return memoryBuffer;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReplaceImage()
        {
#if !DEMO
            int x = 0;
            if ( int.TryParse( PageOpenImageControl.axFlatEditX.Text, out x ) == false )
            {
                MessageBox.Show( "打开的图像帧的面板中,中心X输入框中输入的数字" );
                return;
            }
            int y = 0;
            if ( int.TryParse( PageOpenImageControl.axFlatEditY.Text, out y ) == false )
            {
                MessageBox.Show( "打开的图像帧的面板中,中心Y输入框中输入的数字" );
                return;
            }

            if ( ListViewSGLImage.SelectedIndices.Count != 1 )
                return;

            if ( ListViewSGLFrame.SelectedIndices.Count != 1 )
                return;

            byte[] imageBuffer = GetImageData();
            if ( imageBuffer == null )
                return;

            foreach ( int index in ListViewSGLImage.SelectedIndices )
            {
                SGLImage sglImage = m_SglFileInfo.SGLImage[index];

                foreach ( int index2 in ListViewSGLFrame.SelectedIndices )
                {
                    m_SglFileInfo.ReplaceImage( index, index2, imageBuffer, x ,y );

                    ShowImage( sglImage, sglImage.SGLFrames[index2] );
                }
            }
#else
            MessageBox.Show( TryMessageInfo );
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteImage()
        {
#if !DEMO
            if ( ListViewSGLImage.SelectedIndices.Count != 1 )
                return;

            if ( ListViewSGLFrame.SelectedIndices.Count != 1 )
                return;

            foreach ( int index in ListViewSGLImage.SelectedIndices )
            {
                SGLImage sglImage = m_SglFileInfo.SGLImage[index];

                foreach ( int index2 in ListViewSGLFrame.SelectedIndices )
                {
                    m_SglFileInfo.DeleteImage( index, index2 );
                }

                int iIndex = 0;
                ListViewSGLFrame.Items.Clear();
                foreach ( SGLFrame sglFrame in sglImage.SGLFrames )
                {
                    ListViewItem listViewItem = new ListViewItem( iIndex.ToString(), 0 );
                    listViewItem.SubItems.Add( sglFrame.FrameWidth.ToString() );
                    listViewItem.SubItems.Add( sglFrame.FrameHeight.ToString() );
                    listViewItem.SubItems.Add( sglFrame.CenterX.ToString() );
                    listViewItem.SubItems.Add( sglFrame.CenterY.ToString() );
                    listViewItem.SubItems.Add( sglFrame.BlocksX.ToString() );
                    listViewItem.SubItems.Add( sglFrame.BlocksY.ToString() );

                    ListViewSGLFrame.Items.Add( listViewItem );

                    if ( iIndex == 0 )
                        ShowImage( sglImage, sglFrame );

                    iIndex++;
                }
            }
#else
            MessageBox.Show( TryMessageInfo );
#endif
        }

        private void ListViewSGLImage_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( ListViewSGLImage.SelectedIndices.Count > 1 )
                return;
            else if ( ListViewSGLImage.SelectedIndices.Count < 1 )
            {
                if ( PageCurrentImageControl.WorkspaceViewer.Image != null )
                    PageCurrentImageControl.WorkspaceViewer.Image = null;
            }

            ListViewSGLFrame.Items.Clear();
            foreach ( int index in ListViewSGLImage.SelectedIndices )
            {
                SGLImage sglImage = m_SglFileInfo.SGLImage[index];

                if ( sglImage.SGLFrames.Length == 0 )
                {
                    if ( PageCurrentImageControl.WorkspaceViewer.Image != null )
                        PageCurrentImageControl.WorkspaceViewer.Image = null;

                    break;
                }

                int iIndex = 0;
                foreach ( SGLFrame sglFrame in sglImage.SGLFrames )
                {
                    ListViewItem listViewItem = new ListViewItem( iIndex.ToString(), 0 );
                    listViewItem.SubItems.Add( sglFrame.FrameWidth.ToString() );
                    listViewItem.SubItems.Add( sglFrame.FrameHeight.ToString() );
                    listViewItem.SubItems.Add( sglFrame.CenterX.ToString() );
                    listViewItem.SubItems.Add( sglFrame.CenterY.ToString() );
                    listViewItem.SubItems.Add( sglFrame.BlocksX.ToString() );
                    listViewItem.SubItems.Add( sglFrame.BlocksY.ToString() );

                    ListViewSGLFrame.Items.Add( listViewItem );

                    if ( iIndex == 0 )
                        ShowImage( sglImage, sglFrame );

                    iIndex++;
                }
            }
        }
        private void ListViewSGLFrame_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( ListViewSGLImage.SelectedIndices.Count > 1 )
                return;
            else if ( ListViewSGLImage.SelectedIndices.Count < 1 )
            {
                if ( PageCurrentImageControl.WorkspaceViewer.Image != null )
                    PageCurrentImageControl.WorkspaceViewer.Image = null;
            }

            if ( ListViewSGLFrame.SelectedIndices.Count > 1 )
                return;
            else if ( ListViewSGLFrame.SelectedIndices.Count < 1 )
            {
                if ( PageCurrentImageControl.WorkspaceViewer.Image != null )
                    PageCurrentImageControl.WorkspaceViewer.Image = null;
            }

            foreach ( int index in ListViewSGLImage.SelectedIndices )
            {
                SGLImage sglImage = m_SglFileInfo.SGLImage[index];

                foreach ( int index2 in ListViewSGLFrame.SelectedIndices )
                {
                    SGLFrame sglFrame = sglImage.SGLFrames[index2];

                    ShowImage( sglImage, sglFrame );
                }
            }
        }

        private void ShowImage( SGLImage sglImage, SGLFrame sglFrame )
        {
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
                    if ( sglFrame.SGLFrameFormat11Or12Or22.DecodeFrame32Stream == null )
                    {
                        if ( sglFrame.SGLFrameFormat11Or12Or22.LoadImage() == false )
                            break;
                    }

                    PageCurrentImageControl.WorkspaceViewer.Open( sglFrame.SGLFrameFormat11Or12Or22.DecodeFrame32Stream );

                    break;
                case 0x62:

                    break;
                default:

                    break;
            }
        }

        private void contextMenuStripSGLFrame_Opening( object sender, CancelEventArgs e )
        {
            e.Cancel = true;

            if ( ListViewSGLImage.SelectedIndices.Count != 1 )
                return;

            if ( ListViewSGLFrame.SelectedIndices.Count > 1 )
                return;
            if ( ListViewSGLFrame.SelectedIndices.Count < 1 )
            {
                CommandBar popupCommandBar = m_SGLEditorForm.axCommandBars.Add( "SGLFramePopup", XTPBarPosition.xtpBarPopup );
                CommandBarControl commandBarControl = popupCommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_INSERT, "插入(&I)", -1, false );
                commandBarControl.Enabled = PageOpenImageControl.IsOpenImage;

                commandBarControl = popupCommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_INSERT_MULTI, "插入多文件(&R)", -1, false );
                commandBarControl.Enabled = true;

                popupCommandBar.ShowPopup( XTPTrackPopupFlags.TPM_RIGHTBUTTON, null, null );

                return;
            }

            ListViewHitTestInfo listViewHitTestInfo = ListViewSGLFrame.HitTest( ListViewSGLFrame.PointToClient( Cursor.Position ) );
            if ( listViewHitTestInfo == null )
                return;

            if ( listViewHitTestInfo.Item == null )
                return;

            CommandBar popupCommandBar2 = m_SGLEditorForm.axCommandBars.Add( "SGLFramePopup2", XTPBarPosition.xtpBarPopup );
            CommandBarControl commandBarControl2 = popupCommandBar2.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_INSERT, "插入(&I)", -1, false );
            commandBarControl2.Enabled = PageOpenImageControl.IsOpenImage;

            commandBarControl2 = popupCommandBar2.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_INSERT_MULTI, "插入多文件(&R)", -1, false );
            commandBarControl2.Enabled = true;

            commandBarControl2 = popupCommandBar2.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_REPLACE, "替换(&R)", -1, false );
            commandBarControl2.Enabled = PageOpenImageControl.IsOpenImage;

            commandBarControl2 = popupCommandBar2.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_DELETE, "删除(&R)", -1, false );
            commandBarControl2.Enabled = true;

            popupCommandBar2.ShowPopup( XTPTrackPopupFlags.TPM_RIGHTBUTTON, null, null );
        }

        private void SGLEditorDocumentForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            m_SglFileInfo.CloseSGLFile();
        }

        Dictionary<int, CommandBarControl> m_AddPathList = new Dictionary<int, CommandBarControl>();
        public void AddPath()
        {
            if ( ListViewSGLImage.SelectedIndices.Count != 1 )
                return;

            foreach ( int index in ListViewSGLImage.SelectedIndices )
            {
                bool bIsFind = false;
                foreach ( KeyValuePair<int,CommandBarControl> intItem in m_AddPathList )
                {
                    if ( index == intItem.Key )
                    {
                        bIsFind = true;
                        break;
                    }
                }

                if ( bIsFind == false )
                {
                    ListViewSGLImage.Items[index].SubItems[3].Text = "是";
                    m_AddPathList.Add( index, null );
                }
                else
                {
                    ListViewSGLImage.Items[index].SubItems[3].Text = string.Empty;
                    m_AddPathList.Remove( index );
                }

                ListViewSGLImage.RedrawItems( index, index, false );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        SaveFileDialog m_SaveFileDialog = new SaveFileDialog();
        public void BuildPath()
        {
#if !DEMO
            MessageBox.Show( "请确保打开的sgl文件名与传奇世界的文件名是对应的，否则产生应用补丁将无法找到该相同文件名！" );
            if ( m_AddPathList.Count <= 0 )
                return;

            //show the save dialog
            m_SaveFileDialog.DefaultExt = "patch";
            m_SaveFileDialog.Filter = "Path Data (*.patch)|*.patch";
            m_SaveFileDialog.RestoreDirectory = true;

            if ( m_SaveFileDialog.ShowDialog() == DialogResult.OK )
            {
                using ( FileStream fileStream = File.Create( m_SaveFileDialog.FileName ) )
                {
                    byte[] byteSglFileName = Encoding.Unicode.GetBytes(Path.GetFileName(m_SglFileName));

                    byte[] byteUINT = new byte[sizeof( uint )];

                    // FileName string Length
                    byteUINT[0] = (byte)( byteSglFileName.Length & 0xFF );
                    byteUINT[1] = (byte)( ( byteSglFileName.Length & 0xFF00 ) >> 8 );
                    byteUINT[2] = (byte)( ( byteSglFileName.Length & 0xFF0000 ) >> 16 );
                    byteUINT[3] = (byte)( ( byteSglFileName.Length & 0xFF000000 ) >> 24 );
                    fileStream.Write( byteUINT, 0, byteUINT.Length );

                    fileStream.Write( byteSglFileName, 0, byteSglFileName.Length );

                    // Path Count
                    byteUINT[0] = (byte)( m_AddPathList.Count & 0xFF );
                    byteUINT[1] = (byte)( ( m_AddPathList.Count & 0xFF00 ) >> 8 );
                    byteUINT[2] = (byte)( ( m_AddPathList.Count & 0xFF0000 ) >> 16 );
                    byteUINT[3] = (byte)( ( m_AddPathList.Count & 0xFF000000 ) >> 24 );
                    fileStream.Write( byteUINT, 0, byteUINT.Length );

                    foreach ( KeyValuePair<int, CommandBarControl> intItem in m_AddPathList )
                    {
                        // Image index
                        byteUINT[0] = (byte)( intItem.Key & 0xFF );
                        byteUINT[1] = (byte)( ( intItem.Key & 0xFF00 ) >> 8 );
                        byteUINT[2] = (byte)( ( intItem.Key & 0xFF0000 ) >> 16 );
                        byteUINT[3] = (byte)( ( intItem.Key & 0xFF000000 ) >> 24 );
                        fileStream.Write( byteUINT, 0, byteUINT.Length );

                        SGLImage sglImage = m_SglFileInfo.SGLImage[intItem.Key];
                        byte[] byteBuffer = sglImage.GetOriginBuffer();
                        if ( byteBuffer == null )
                        {
                            // Buffer Length
                            byteUINT[0] = (byte)( 0 & 0xFF );
                            byteUINT[1] = (byte)( ( 0 & 0xFF00 ) >> 8 );
                            byteUINT[2] = (byte)( ( 0 & 0xFF0000 ) >> 16 );
                            byteUINT[3] = (byte)( ( 0 & 0xFF000000 ) >> 24 );
                            fileStream.Write( byteUINT, 0, byteUINT.Length );

                            continue;
                        }
                        else if ( byteBuffer.Length <= 0 )
                        {
                            // Buffer Length
                            byteUINT[0] = (byte)( 0 & 0xFF );
                            byteUINT[1] = (byte)( ( 0 & 0xFF00 ) >> 8 );
                            byteUINT[2] = (byte)( ( 0 & 0xFF0000 ) >> 16 );
                            byteUINT[3] = (byte)( ( 0 & 0xFF000000 ) >> 24 );
                            fileStream.Write( byteUINT, 0, byteUINT.Length );

                            continue;
                        }
                        else
                        {
                            // Buffer Length
                            byteUINT[0] = (byte)( byteBuffer.Length & 0xFF );
                            byteUINT[1] = (byte)( ( byteBuffer.Length & 0xFF00 ) >> 8 );
                            byteUINT[2] = (byte)( ( byteBuffer.Length & 0xFF0000 ) >> 16 );
                            byteUINT[3] = (byte)( ( byteBuffer.Length & 0xFF000000 ) >> 24 );
                            fileStream.Write( byteUINT, 0, byteUINT.Length );

                            // Buffer
                            fileStream.Write( byteBuffer, 0, byteBuffer.Length );
                        }
                    }
                }
            }
#else
            MessageBox.Show( SGLEditorDocumentForm.TryMessageInfo );
#endif
        }

        private void contextMenuStrip1_Opening( object sender, CancelEventArgs e )
        {
            e.Cancel = true;

            if ( ListViewSGLImage.SelectedIndices.Count != 1 )
                return;

            ListViewHitTestInfo listViewHitTestInfo = ListViewSGLImage.HitTest( ListViewSGLImage.PointToClient( Cursor.Position ) );
            if ( listViewHitTestInfo == null )
                return;

            if ( listViewHitTestInfo.Item == null )
                return;

            CommandBar popupCommandBar2 = m_SGLEditorForm.axCommandBars.Add( "SGLImagePopup1", XTPBarPosition.xtpBarPopup );
            CommandBarControl commandBarControl2 = popupCommandBar2.Controls.Add( XTPControlType.xtpControlCheckBox, ResourceID.ID_SGL_ADD_PATH, "加入补丁列表(&A)", -1, false );

            commandBarControl2 = popupCommandBar2.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_INSERT_MULTI_IMAGE, "插入多帧的文件(&I)", -1, false );
            commandBarControl2.Enabled = true;

            bool bIsFind = false;
            foreach ( KeyValuePair<int, CommandBarControl> intItem in m_AddPathList )
            {
                if ( intItem.Key == listViewHitTestInfo.Item.Index )
                {
                    bIsFind = true;
                    break;
                }
            }
            commandBarControl2.Checked = bIsFind;

            popupCommandBar2.ShowPopup( XTPTrackPopupFlags.TPM_RIGHTBUTTON, null, null );
        }
    }
}