using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Win32;
using Demo.Mmose.Gui.CommandBars;
using Demo.Mmose.Gui.CommandBars.ActiveX;
using System.Reflection;
using System.Globalization;

namespace Demo.GOSE.SGL.Editor
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SGLEditorForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public SGLEditorForm()
        {
            InitializeComponent();

#if !DEMO
            //CheckSerialNumber.Init( "Password.Key" );
#endif
        }

        private void SGLEditorForm_Load( object sender, EventArgs e )
        {
            CommandBarsGlobalSettings commandBarsGlobalSettings = new CommandBarsGlobalSettings();
            commandBarsGlobalSettings.ResourceFile = "Demo.Mmose.Gui.Resource.dll";

            CreateRibbonBar();

            LoadIcons();

            axCommandBars.KeyBindings.Add( ResourceID.FCONTROL, System.Convert.ToInt32( 'O' ), ResourceID.ID_FILE_OPEN );

            axCommandBars.StatusBar.AddPane( 0 );
            axCommandBars.StatusBar.AddPane( ResourceID.ID_INDICATOR_CAPS );
            axCommandBars.StatusBar.AddPane( ResourceID.ID_INDICATOR_NUM );
            axCommandBars.StatusBar.AddPane( ResourceID.ID_INDICATOR_SCRL );
            axCommandBars.StatusBar.Visible = true;

            RibbonBar().EnableFrameTheme();

            axCommandBars.Options.KeyboardCuesShow = XTPKeyboardCuesShow.xtpKeyboardCuesShowWindowsDefault;

            foreach ( Control control in this.Controls )
            {
                if ( control is MdiClient )
                    axCommandBars.SetMDIClient( control.Handle.ToInt32() );
            }

            axCommandBars.EnableCustomization( true );
        }

        private RibbonBar RibbonBar()
        {
            return axCommandBars.ActiveMenuBar as RibbonBar;
        }

        private void CreateRibbonBar()
        {
            RibbonBar ribbonBar = axCommandBars.AddRibbonBar( "DemoSoft Team Ribbon" );
            ribbonBar.EnableDocking( XTPToolBarFlags.xtpFlagStretched );

            CommandBarPopup controlFile = ribbonBar.AddSystemButton();
            controlFile.IconId = ResourceID.ID_SYSTEM_ICON;
            controlFile.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_FILE_OPEN, "打开(&O)...", false, false );
            
            CommandBarControl control = controlFile.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_FILE_CLOSE, "关闭(&C)", false, false );
            control.BeginGroup = true;
            control = controlFile.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_APP_EXIT, "退出(E&)", false, false );
            controlFile.CommandBar.SetIconSize( 32, 32 );

            CommandBarControl controlAbout = ribbonBar.Controls.Add( XTPControlType.xtpControlButton, ResourceID.ID_APP_ABOUT, "关于(&A)", false, false );
            controlAbout.Flags = XTPControlFlags.xtpFlagRightAlign;

            RibbonTab tabHome = ribbonBar.InsertTab( 0, "开始(&H)" );
            tabHome.Id = ResourceID.ID_TAB_HOME;

            RibbonGroup groupFile = tabHome.Groups.AddGroup( "文件(&F)", ResourceID.ID_GROUP_FILE );
            groupFile.Add( XTPControlType.xtpControlButton, ResourceID.ID_FILE_OPEN, "打开(&O)", false, false );
            groupFile.Add( XTPControlType.xtpControlButton, ResourceID.ID_FILE_CLOSE, "关闭(&C)", false, false );

            RibbonTab tabView = ribbonBar.InsertTab( 2, "视图(&V)" );
            tabView.Id = ResourceID.ID_TAB_VIEW;

            RibbonGroup groupShowHide = tabView.Groups.AddGroup( "显示/隐藏", ResourceID.ID_GROUP_SHOWHIDE );
            groupShowHide.Add( XTPControlType.xtpControlCheckBox, ResourceID.ID_VIEW_STATUS_BAR, "状态栏", false, false );
            groupShowHide.Add( XTPControlType.xtpControlCheckBox, ResourceID.ID_VIEW_WORKSPACE, "工作区", false, false );

            RibbonTab tabTools = ribbonBar.InsertTab( 3, "工具(&T)" );
            tabTools.Id = ResourceID.ID_TAB_TOOLS;

            RibbonGroup groupPatchTool = tabTools.Groups.AddGroup( "工具集", ResourceID.ID_GROUP_TOOLS );
            groupPatchTool.Add( XTPControlType.xtpControlButton, ResourceID.ID_PATCH_TOOL, "产生补丁程序", false, false );
            //groupPatchTool.Add( XTPControlType.xtpControlButton, ResourceID.ID_PATCH_FILE, "Patch EXE", false, false );

            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceID.ID_WELCOME, "Welcome", false, false );
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceID.ID_TO, "To", false, false );
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceID.ID_DEMO_SOFT, "DemoSoft", false, false );
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceID.ID_TEAM, "Team", false, false );
        }

        private void LoadIcons()
        {
            axCommandBars.Options.UseSharedImageList = false;

            axCommandBars.Icons.LoadBitmap( "SystemIcon.png", ResourceID.ID_SYSTEM_ICON, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "LargeIcons.png", new object[] { ResourceID.ID_PATCH_FILE, ResourceID.ID_FILE_OPEN, ResourceID.ID_PATCH_TOOL, 0, 0, 0, ResourceID.ID_FILE_CLOSE, 0, 0, 0, 0, 0, 0 }, XTPImageState.xtpImageNormal );

            ToolTipContext toolTipContext = axCommandBars.ToolTipContext;
            toolTipContext.Style = XTPToolTipStyle.xtpToolTipOffice2007;
            toolTipContext.ShowTitleAndDescription( true, XTPToolTipIcon.xtpToolTipIconNone );
            toolTipContext.SetMargin( 2, 2, 2, 2 );
            toolTipContext.MaxTipWidth = 180;
        }

        private void axCommandBars_Customization( object sender, _DCommandBarsEvents_CustomizationEvent eventArgs )
        {
            eventArgs.options.ShowRibbonQuickAccessPage = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private byte[] m_ByteFileBuffer = new byte[0];
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_ByteFileBuffer2 = new byte[0];

        private void axCommandBars_Execute( object sender, _DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case ResourceID.ID_SGL_ADD_PATH:
                    SGLEditorDocumentForm sglAddPath = this.ActiveMdiChild as SGLEditorDocumentForm;
                    if ( sglAddPath == null )
                        return;
                    else
                        sglAddPath.AddPath();

                    break;
                case ResourceID.ID_INSERT:
                    SGLEditorDocumentForm sglInsertForm = this.ActiveMdiChild as SGLEditorDocumentForm;
                    if ( sglInsertForm == null )
                        return;
                    else
                        sglInsertForm.InsertImage();

                    break;
                case ResourceID.ID_INSERT_MULTI:
                    SGLEditorDocumentForm sglInsertMultiForm = this.ActiveMdiChild as SGLEditorDocumentForm;
                    if ( sglInsertMultiForm == null )
                        return;
                    else
                    {
                        MessageBox.Show( "将自动检索文件的偏移信息\r\n中心位置 X 86 Y 49\r\n譬如：Offset[0086X0049].tga" );

                        OpenFileDialog openInsertMultiFileDialog = new OpenFileDialog();
                        openInsertMultiFileDialog.DefaultExt = "tga";
                        openInsertMultiFileDialog.FilterIndex = 6;
                        openInsertMultiFileDialog.Multiselect = true;
                        openInsertMultiFileDialog.Filter = HelperMethods.CreateDialogFilter( true );

                        if ( openInsertMultiFileDialog.ShowDialog() == DialogResult.OK )
                        {
                            foreach(string strFileName in openInsertMultiFileDialog.FileNames)
                            {
                                sglInsertMultiForm.PageOpenImageControl.LoadImage( strFileName );

                                sglInsertMultiForm.InsertImage();
                            }
                        }
                    }

                    break;
                case ResourceID.ID_INSERT_MULTI_IMAGE:
                    SGLEditorDocumentForm sglInsertMultiImageForm = this.ActiveMdiChild as SGLEditorDocumentForm;
                    if ( sglInsertMultiImageForm == null )
                        return;
                    else
                    {
                        MessageBox.Show( "将自动检索文件的序号信息和帧号信息和偏移信息\r\n第 21 序号 第 0 帧(按数字从小到大自动排列) 中心位置 X 86 Y 49\r\n譬如：Image[0021]Frame[0000]Offset[0086X0049].tga" );

                        OpenFileDialog openInsertMultiImageFileDialog = new OpenFileDialog();
                        openInsertMultiImageFileDialog.DefaultExt = "tga";
                        openInsertMultiImageFileDialog.FilterIndex = 6;
                        openInsertMultiImageFileDialog.Multiselect = true;
                        openInsertMultiImageFileDialog.Filter = HelperMethods.CreateDialogFilter( true );

                        if ( openInsertMultiImageFileDialog.ShowDialog() == DialogResult.OK )
                        {

                            Dictionary<int, List<int>> fileNameDictionary1 = new Dictionary<int,List<int>>();
                            Dictionary<int, Dictionary<int, string>> fileNameDictionary2 = new Dictionary<int,Dictionary<int,string>>();

                            foreach ( string strFileName in openInsertMultiImageFileDialog.FileNames )
                            {
                                string strImageIndex = string.Empty;
                                string strFrameIndex = string.Empty;

                                int iIndex = strFileName.IndexOf( "Image[" );
                                if ( iIndex != -1 )
                                {
                                    iIndex += "Image[".Length;

                                    int iIndex2 = strFileName.IndexOf( "]", iIndex );
                                    if ( iIndex2 != -1 )
                                    {
                                        strImageIndex = strFileName.Substring( iIndex, iIndex2 - iIndex );
                                    }
                                    else
                                        continue;
                                }
                                else
                                    continue;

                                int iIndex3 = strFileName.IndexOf( "Frame[" );
                                if ( iIndex3 != -1 )
                                {
                                    iIndex3 += "Frame[".Length;

                                    int iIndex4 = strFileName.IndexOf( "]", iIndex3 );
                                    if ( iIndex4 != -1 )
                                    {
                                        strFrameIndex = strFileName.Substring( iIndex3, iIndex4 - iIndex3 );
                                    }
                                    else
                                        continue;
                                }
                                else
                                    continue;

                                int iImageIndex = int.Parse( strImageIndex );
                                int iFrameIndex = int.Parse( strFrameIndex );

                                List<int> list = null;
                                fileNameDictionary1.TryGetValue(iImageIndex, out list);
                                if ( list == null )
                                    list = new List<int>();

                                list.Add( iFrameIndex );
                                fileNameDictionary1[iImageIndex] = list;

                                Dictionary<int, string> dictionary = null;
                                fileNameDictionary2.TryGetValue( iImageIndex, out dictionary );
                                if ( dictionary == null )
                                    dictionary = new Dictionary<int, string>();

                                dictionary[iFrameIndex] = strFileName;
                                fileNameDictionary2[iImageIndex] = dictionary;
                            }

                            foreach ( KeyValuePair<int, List<int>> item in fileNameDictionary1 )
                            {
                                if ( item.Key >= sglInsertMultiImageForm.ListViewSGLImage.Items.Count )
                                    continue;

                                if ( item.Value == null )
                                    continue;

                                if ( item.Value.Count <= 0 )
                                    continue;

                                int[] iBubbleArrary = item.Value.ToArray();
                                if ( iBubbleArrary.Length <= 0 )
                                    continue;

                                BubbleSorter bubbleSorter = new BubbleSorter();
                                bubbleSorter.Sort( iBubbleArrary );

                                foreach ( int itemInt in iBubbleArrary )
                                {
                                    Dictionary<int, string> dictionary = null;
                                    fileNameDictionary2.TryGetValue(item.Key, out dictionary);

                                    if ( dictionary == null )
                                        continue;

                                    string strFileName = string.Empty;
                                    dictionary.TryGetValue( itemInt, out strFileName );

                                    if ( strFileName == string.Empty )
                                        continue;

                                    //MessageBox.Show( item.Key.ToString() + "-" + itemInt.ToString() + "-" + strFileName );
                                    sglInsertMultiImageForm.ListViewSGLImage.SelectedIndices.Clear();
                                    sglInsertMultiImageForm.ListViewSGLImage.SelectedIndices.Add( item.Key );
                                    sglInsertMultiImageForm.ListViewSGLImage.EnsureVisible( item.Key );

                                    sglInsertMultiImageForm.PageOpenImageControl.LoadImage( strFileName );

                                    sglInsertMultiImageForm.InsertImage();
                                }
                            }
                        }
                    }

                    break;
                case ResourceID.ID_REPLACE:
                    SGLEditorDocumentForm sglReplaceForm = this.ActiveMdiChild as SGLEditorDocumentForm;
                    if ( sglReplaceForm == null )
                        return;
                    else
                        sglReplaceForm.ReplaceImage();

                    break;
                case ResourceID.ID_DELETE:
                    SGLEditorDocumentForm sglDeleteForm = this.ActiveMdiChild as SGLEditorDocumentForm;
                    if ( sglDeleteForm == null )
                        return;
                    else
                        sglDeleteForm.DeleteImage();

                    break;
                case (int)XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCUSTOMIZE:
                    axCommandBars.ShowCustomizeDialog( 3 );
                    break;
                case ResourceID.ID_APP_ABOUT:
                    MessageBox.Show( "Version " + System.Diagnostics.FileVersionInfo.GetVersionInfo( System.Reflection.Assembly.GetExecutingAssembly().Location ).FileMajorPart + "." + System.Diagnostics.FileVersionInfo.GetVersionInfo( System.Reflection.Assembly.GetExecutingAssembly().Location ).FileMinorPart + "\n注册qq:285372272 价格:600元" );


                    break;
                case ResourceID.ID_PATCH_TOOL:
#if !DEMO
                    if ( m_ByteFileBuffer.Length <= 0 )
                    {
                        using ( FileStream fileStream2 = File.Open( Directory.GetCurrentDirectory() + "/Demo.Mmose.Sgl.Patch.Bin", FileMode.Open, FileAccess.Read ) )
                        {
                            m_ByteFileBuffer = new byte[fileStream2.Length];
                            fileStream2.Read( m_ByteFileBuffer, 0, m_ByteFileBuffer.Length );
                            fileStream2.Close();
                        }
                    }

                    if ( m_ByteFileBuffer.Length <= 0 )
                        break;

                    SaveFileDialog m_SaveFileDialog = new SaveFileDialog();
                    m_SaveFileDialog.DefaultExt = "exe";
                    m_SaveFileDialog.Filter = "Path exe (*.exe)|*.exe";
                    m_SaveFileDialog.RestoreDirectory = true;

                    if ( m_SaveFileDialog.ShowDialog() == DialogResult.OK ) 
                    {
                        OpenFileDialog m_OpenFileDialog = new OpenFileDialog();
                        m_OpenFileDialog.DefaultExt = "Patch";
                        m_OpenFileDialog.Filter = "Path Data (*.Patch)|*.Patch";
                        m_OpenFileDialog.Multiselect = true;
                        m_SaveFileDialog.RestoreDirectory = true;

                        if ( m_OpenFileDialog.ShowDialog() == DialogResult.OK )
                        {
                            if ( m_OpenFileDialog.FileNames.Length <= 0 )
                                break;

                            using ( FileStream fileStream = File.Create( m_SaveFileDialog.FileName ) )
                            {
                                if ( m_ByteFileBuffer2.Length <= 0 )
                                {
                                    m_ByteFileBuffer2 = new byte[m_ByteFileBuffer.Length];

                                    for ( int iIndex = 0; iIndex < m_ByteFileBuffer.Length; iIndex++ )
                                    {
                                        m_ByteFileBuffer2[iIndex] = m_ByteFileBuffer[( m_ByteFileBuffer.Length - iIndex ) - 1];
                                    }
                                }

                                fileStream.Write( m_ByteFileBuffer2, 0, m_ByteFileBuffer2.Length );

                                byte[] byteUINT = new byte[sizeof( uint )];

                                // File Count
                                byteUINT[0] = (byte)( m_OpenFileDialog.FileNames.Length & 0xFF );
                                byteUINT[1] = (byte)( ( m_OpenFileDialog.FileNames.Length & 0xFF00 ) >> 8 );
                                byteUINT[2] = (byte)( ( m_OpenFileDialog.FileNames.Length & 0xFF0000 ) >> 16 );
                                byteUINT[3] = (byte)( ( m_OpenFileDialog.FileNames.Length & 0xFF000000 ) >> 24 );
                                fileStream.Write( byteUINT, 0, byteUINT.Length );

                                foreach ( string strFile in m_OpenFileDialog.FileNames )
                                {
                                    byte[] byteFileBuffer3 = new byte[0];
                                    using ( FileStream fileStream3 = File.Open( strFile, FileMode.Open, FileAccess.Read ) )
                                    {
                                        byteFileBuffer3 = new byte[fileStream3.Length];
                                        fileStream3.Read( byteFileBuffer3, 0, byteFileBuffer3.Length );
                                    }

                                    fileStream.Write( byteFileBuffer3, 0, byteFileBuffer3.Length );
                                }

                                fileStream.Close();
                            }
                        }
                    }
#else
            MessageBox.Show( SGLEditorDocumentForm.TryMessageInfo );
#endif
                    break;
                case ResourceID.ID_PATCH_FILE:

                    OpenFileDialog m_SavePatchFileDialog = new OpenFileDialog();
                    m_SavePatchFileDialog.DefaultExt = "exe";
                    m_SavePatchFileDialog.Filter = "Change Path Exe (*.exe)|*.exe";
                    m_SavePatchFileDialog.RestoreDirectory = true;

                    if ( m_SavePatchFileDialog.ShowDialog() == DialogResult.OK )
                    {
                        byte[] bytePatchFileBuffer = new byte[0];
                        using ( FileStream fileStream2 = File.Open( m_SavePatchFileDialog.FileName, FileMode.Open, FileAccess.Read ) )
                        {
                            bytePatchFileBuffer = new byte[fileStream2.Length];
                            fileStream2.Read( bytePatchFileBuffer, 0, bytePatchFileBuffer.Length );
                        }

                        if ( bytePatchFileBuffer.Length <= 0 )
                            break;

                        using ( FileStream fileStream = File.Create( Directory.GetCurrentDirectory() + "/Demo.Mmose.Sgl.Patch.Bin" ) )
                        {
                            byte[] byteFileBuffer2 = new byte[bytePatchFileBuffer.Length];

                            for ( int iIndex = 0; iIndex < bytePatchFileBuffer.Length; iIndex++ )
                            {
                                byteFileBuffer2[iIndex] = bytePatchFileBuffer[( bytePatchFileBuffer.Length - iIndex ) - 1];
                            }
                            
                            fileStream.Write( byteFileBuffer2, 0, byteFileBuffer2.Length );
                            fileStream.Close();
                        }
                    }

                    break;
                case ResourceID.ID_APP_EXIT:
                    this.Close();
                    break;
                case (int)XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCONTROLTAB:
                    break;
                case ResourceID.ID_VIEW_STATUS_BAR:
                    axCommandBars.StatusBar.Visible = !axCommandBars.StatusBar.Visible;
                    axCommandBars.RecalcLayout();
                    break;
                case ResourceID.ID_VIEW_WORKSPACE:
                    eventArgs.control.Checked = !eventArgs.control.Checked;
                    axCommandBars.ShowTabWorkspace( eventArgs.control.Checked );
                    break;
                case ResourceID.ID_FILE_CLOSE:
                    this.ActiveMdiChild.Close();
                    break;
                case ResourceID.ID_FILE_OPEN:
                    OpenFileDialog openFileDialog = new OpenFileDialog();

                    RegistryKey rkey = Registry.CurrentUser;
                    RegistryKey rkey1 = rkey.OpenSubKey("Software", true);
                    RegistryKey rkey2 = rkey1.CreateSubKey("DemoSoft");
                    RegistryKey rkey3 = rkey2.CreateSubKey("Demo G.O.S.E.SGL.Editor");
                    string strFullPath = (string)rkey2.GetValue("OpenFilePath", "" );
                    rkey3.Close();
                    rkey2.Close();
                    rkey1.Close();

                    openFileDialog.InitialDirectory = strFullPath;
                    openFileDialog.Filter = "SGL 文件 (*.sgl)|*.sgl|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if ( openFileDialog.ShowDialog( axCommandBars ) == DialogResult.OK )
                    {
                        strFullPath = Path.GetFullPath(openFileDialog.FileName);

                        rkey = Registry.CurrentUser;
                        rkey1 = rkey.OpenSubKey("Software", true);
                        rkey2 = rkey1.CreateSubKey("DemoSoft");
                        rkey3 = rkey2.CreateSubKey("Demo G.O.S.E.SGL.Editor");
                        rkey3.SetValue("OpenFilePath", strFullPath, RegistryValueKind.String);
                        rkey3.Close();
                        rkey2.Close();
                        rkey1.Close();

                        if ( openFileDialog.FileName.Length != 0 )
                            LoadNewSGLFile( openFileDialog.FileName );
                    }
                    break;
                default:
                    break;
            };
        }

        private void axCommandBars_UpdateEvent( object sender, _DCommandBarsEvents_UpdateEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case ResourceID.ID_VIEW_STATUS_BAR:
                    eventArgs.control.Checked = axCommandBars.StatusBar.Visible;
                    break;
                case ResourceID.ID_FILE_CLOSE:
                    eventArgs.control.Enabled = ( this.MdiChildren.Length != 0 ? true : false );
                    break;
                case ResourceID.ID_WELCOME:
                case ResourceID.ID_TO:
                case ResourceID.ID_DEMO_SOFT:
                case ResourceID.ID_TEAM:
                    eventArgs.control.Enabled = ( this.MdiChildren.Length != 0 ? true : false );
                    break;
                case (int)XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCONTROLTAB:
                    break;
                default:
                    break;
            }
        }

        private void LoadNewSGLFile( String stringFileName )
        {
            SGLEditorDocumentForm documentForm = new SGLEditorDocumentForm();

            if ( documentForm.OpenSGLFile( stringFileName ) == false )
                return;

            documentForm.Text = "文档 " + stringFileName;
            documentForm.MdiParent = this;
            documentForm.SGLEditorForm = this;
            documentForm.Show();

            this.Text = "DemoSoft - " + documentForm.Text;
            axCommandBars.EnableOffice2007FrameHandle( documentForm.Handle.ToInt32() );

            documentForm.WindowState = FormWindowState.Maximized;

            this.Refresh();
        }
    }

    /// <summary>
    /// 一、冒泡排序(Bubble)
    /// </summary>
    public class BubbleSorter
    {
        public void Sort( int[] list )
        {
            int i, j, temp;
            bool done = false;
            j = 1;
            while ( ( j < list.Length ) && ( !done ) )
            {
                done = true;
                for ( i = 0; i < list.Length - j; i++ )
                {
                    if ( list[i] > list[i + 1] )
                    {
                        done = false;
                        temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                }
                j++;
            }
        }
    }
}