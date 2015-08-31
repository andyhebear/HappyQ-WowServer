using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeCommandBars;
using Demo.Stock.X.Common;
using System.Runtime.InteropServices;
using Dundas.Charting.WinControl;

namespace Demo.Stock.X.Tools
{
    public partial class KLineViewForm : Form
    {
        private TabWorkspace m_Workspace = null;
        private KLineViewOptionForm m_KLineViewOptionForm = new KLineViewOptionForm();

        public KLineViewForm()
        {
            InitializeComponent();
        }

        CommandBarControl AddButton( CommandBarControls Controls, XTPControlType ControlType, int Id, string Caption )
        {
            return AddButton( Controls, ControlType, Id, Caption, false, "" );
        }
        CommandBarControl AddButton( CommandBarControls Controls, XTPControlType ControlType, int Id, string Caption, bool BeginGroup )
        {
            return AddButton( Controls, ControlType, Id, Caption, BeginGroup, "" );
        }
        CommandBarControl AddButton( CommandBarControls Controls, XTPControlType ControlType, int Id, string Caption, bool BeginGroup, string DescriptionText )
        {
            return AddButton( Controls, ControlType, Id, Caption, BeginGroup, "", XTPButtonStyle.xtpButtonAutomatic, "Controls" );
        }
        CommandBarControl AddButton( CommandBarControls Controls, XTPControlType ControlType, int Id, string Caption, bool BeginGroup, string DescriptionText, XTPButtonStyle ButtonStyle, string Category )
        {
            CommandBarControl Control = Controls.Add( ControlType, Id, Caption, -1, false );
            Control.BeginGroup = BeginGroup;
            Control.DescriptionText = DescriptionText;
            Control.Category = Category;
            if ( Control is CommandBarButton )
            {
                ( (CommandBarButton)Control ).Style = ButtonStyle;
            }
            return Control;
        }

        MdiClient FindMDIClient()
        {
            for ( int i = 0; i < this.Controls.Count; i = i + 1 )
            {
                if ( this.Controls[i] is MdiClient )
                {
                    return (MdiClient)this.Controls[i];
                }
            }
            return null;
        }

        private RibbonBar RibbonBar()
        {
            return axCommandBars.ActiveMenuBar as RibbonBar;
        }

        private void KLineViewForm_Load( object sender, EventArgs e )
        {
            CommandBarPopup ControlFile = (CommandBarPopup)AddButton( axCommandBars.ActiveMenuBar.Controls, XTPControlType.xtpControlPopup, ID.ID_FILE, "文件(&F)" );
            {
                AddButton( ControlFile.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_FILE_OPEN, "打开K线图(&O)" );
                AddButton( ControlFile.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_FILE_CLOSE, "关闭K线图(&C)", true );
                AddButton( ControlFile.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_FILE_EXIT, "退出(&E)", true );
            }

            CommandBarPopup ControlView = (CommandBarPopup)AddButton( axCommandBars.ActiveMenuBar.Controls, XTPControlType.xtpControlPopup, ID.ID_VIEW, "视图(&V)" );
            {
                AddButton( ControlView.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_CURVE, "显示价格曲线(&P)" );
                AddButton( ControlView.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_INFO, "显示价格信息(&P)" );

                CommandBarPopup ControlSearch = (CommandBarPopup)AddButton( ControlView.CommandBar.Controls, XTPControlType.xtpControlPopup, ID.ID_VIEW_SEARCH_TYPE, "搜索方式" );
                {
                    AddButton( ControlSearch.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_SEARCH_AUTO, "自动选择策略" );
                    AddButton( ControlSearch.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_SEARCH_U50, "U50策略" );
                    AddButton( ControlSearch.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_SEARCH_D50, "D50策略" );
                    ControlSearch.CommandBar.SetTearOffPopup( "选择策略", ID.ID_VIEW_SEARCH_TYPE, 150 );
                }

                CommandBarPopup ControlToolBars = (CommandBarPopup)AddButton( ControlView.CommandBar.Controls, XTPControlType.xtpControlPopup, ID.ID_VIEW_TOOLBAR, "工具栏(&T)" );
                AddButton( ControlToolBars.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_TOOLBAR_STANDARD, "工具栏(&T)" );
                AddButton( ControlToolBars.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_TOOLBAR_STATUSBAR, "状态栏(&S)" );

                AddButton( ControlView.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_OPTIONS, "选项(&O)...", true );
            }

            CommandBarPopup ControlHelp = (CommandBarPopup)AddButton( axCommandBars.ActiveMenuBar.Controls, XTPControlType.xtpControlPopup, ID.ID_HELP, "帮助(&H)" );
            {
                AddButton( ControlHelp.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_HELP_ABOUT, "关于(&A)..." );
            }


            CommandBar ToolBar = axCommandBars.Add( "标准", XTPBarPosition.xtpBarTop );
            {
                CommandBarButton Control = (CommandBarButton)AddButton( ToolBar.Controls, XTPControlType.xtpControlButton, ID.ID_FILE_OPEN, "打开K线图(&O)" );
                Control.Style = XTPButtonStyle.xtpButtonIconAndCaption;
                AddButton( ToolBar.Controls, XTPControlType.xtpControlButton, ID.ID_FILE_CLOSE, "关闭K线图(&C)" );

                Control = (CommandBarButton)AddButton( ToolBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_CURVE, "显示价格曲线(&P)" );
                Control.BeginGroup = true;
                AddButton( ToolBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_INFO, "显示价格信息(&P)" );
                CommandBarPopup ControlColorPopup = (CommandBarPopup)AddButton( ToolBar.Controls, XTPControlType.xtpControlPopup, ID.ID_VIEW_SEARCH_TYPE, "搜索方式", true );
                {
                    AddButton( ControlColorPopup.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_SEARCH_AUTO, "自动选择策略" );
                    AddButton( ControlColorPopup.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_SEARCH_U50, "U50策略" );
                    AddButton( ControlColorPopup.CommandBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_SEARCH_D50, "D50策略" );
                    ControlColorPopup.CommandBar.SetTearOffPopup( "选择策略", ID.ID_VIEW_SEARCH_TYPE, 150 );
                }

                Control = (CommandBarButton)AddButton( ToolBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_OPTIONS, "选项(&O)" );
                Control.BeginGroup = true;
            }

            CommandBar SearchBar = axCommandBars.Add( "选择策略", XTPBarPosition.xtpBarTop );
            {
                AddButton( SearchBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_SEARCH_AUTO, "自动选择策略" );
                AddButton( SearchBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_SEARCH_U50, "U50策略" );
                AddButton( SearchBar.Controls, XTPControlType.xtpControlButton, ID.ID_VIEW_SEARCH_D50, "D50策略" );
                SearchBar.BarID = ID.ID_VIEW_SEARCH_TYPE;
                SearchBar.Visible = false;
            }

            axCommandBars.KeyBindings.Add( ID.FCONTROL, 'O', ID.ID_FILE_OPEN );
            axCommandBars.KeyBindings.Add( ID.FCONTROL, 'C', ID.ID_FILE_CLOSE );

            axCommandBars.StatusBar.AddPane( 0 );
            axCommandBars.StatusBar.AddPane( ID.INDICATOR_CAPS );
            axCommandBars.StatusBar.AddPane( ID.INDICATOR_NUM );
            axCommandBars.StatusBar.AddPane( ID.INDICATOR_SCRL );
            axCommandBars.StatusBar.IdleText = "就绪";
            axCommandBars.StatusBar.Visible = true;

            axCommandBars.VisualTheme = XTPVisualTheme.xtpThemeOffice2007;
            axCommandBars.SetMDIClient( FindMDIClient().Handle.ToInt32() );
            axCommandBars.EnableCustomization( true );

            m_Workspace = axCommandBars.ShowTabWorkspace( true );
            m_Workspace.EnableGroups();
        }

        private byte m_DirNumber = 0;
        private string m_strSelectedPath = string.Empty;
        private Dictionary<ListViewItem, IntPtr> m_SecurityDictionary = new Dictionary<ListViewItem, IntPtr>();
        private void LoadNewDocument()
        {
            if ( this.FolderBrowserDialog.ShowDialog() != DialogResult.OK )
                return;
            else
            {
                m_strSelectedPath = this.FolderBrowserDialog.SelectedPath;
                ProcessForm.StartProcessForm( Process_LoadNewDocument );
            }
        }

        private void Process_LoadNewDocument( ProcessForm processForm )
        {
            if ( m_DirNumber != 0 )
            {
                MSFL.MSFL1_CloseDirectory( m_DirNumber );

                m_SecurityDictionary.Clear();
                m_DirNumber = 0;
            }

            do
            {
                int iErr = MSFL.MSFL1_OpenDirectory( m_strSelectedPath, ref m_DirNumber, MSFL.MSFL_DIR_FORCE_USER_IN );
                if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                    break;

                MSFL.MSFLDirectoryStatus msflDirectoryStatus = new MSFL.MSFLDirectoryStatus();
                msflDirectoryStatus.dwTotalSize = (uint)Marshal.SizeOf( msflDirectoryStatus );

                iErr = MSFL.MSFL1_GetDirectoryStatus( m_DirNumber, string.Empty, ref msflDirectoryStatus );
                if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                    break;

                //MSFL.DisplayMSFLError( iErr );

                List<MSFL.MSFLSecurityInfo> listMSFLSecurityInfo = new List<MSFL.MSFLSecurityInfo>( 1024 );

                MSFL.MSFLSecurityInfo msflSecurityInfo = new MSFL.MSFLSecurityInfo();
                msflSecurityInfo.dwTotalSize = (uint)Marshal.SizeOf( msflSecurityInfo );

                if ( msflDirectoryStatus.bExists &&         // if it exists
                    msflDirectoryStatus.bOpen &&            // AND if it's open
                    msflDirectoryStatus.bMetaStockDir )     // AND if it's a MetaStock directory...
                {
                    StringBuilder dateString = new StringBuilder( MSFL.MSFL_MAX_NAME_LENGTH + 1 );

                    iErr = MSFL.MSFL1_GetFirstSecurityInfo( m_DirNumber, ref msflSecurityInfo );
                    while ( iErr == (int)MSFL.MSFL_ERR.MSFL_NO_ERR || iErr == (int)MSFL.MSFL_Messages.MSFL_MSG_LAST_SECURITY_IN_DIR )
                    {
                        //m_SecurityDictionary.Add( listViewItem, msflSecurityInfo.hSecurity );

                        listMSFLSecurityInfo.Add( msflSecurityInfo );

                        if ( iErr == (int)MSFL.MSFL_Messages.MSFL_MSG_LAST_SECURITY_IN_DIR )
                            break;

                        msflSecurityInfo = new MSFL.MSFLSecurityInfo();
                        msflSecurityInfo.dwTotalSize = (uint)Marshal.SizeOf( msflSecurityInfo );

                        iErr = MSFL.MSFL1_GetNextSecurityInfo( msflSecurityInfo.hSecurity, ref msflSecurityInfo );
                    }
                }

                MSFL.MSFLSecurityInfo[] msflSecurityInfoArray = listMSFLSecurityInfo.ToArray();
                if ( msflSecurityInfoArray.Length <= 0 )
                    break;

                KLineViewFormSubForm klineViewFormSubForm = new KLineViewFormSubForm( msflSecurityInfoArray );
                if ( klineViewFormSubForm.ShowDialog() == DialogResult.OK )
                {
                    msflSecurityInfoArray = klineViewFormSubForm.ToSecurityInfo();
                    if ( msflSecurityInfoArray.Length > 0 )
                    {
                        for ( int iIndex = 0; iIndex < msflSecurityInfoArray.Length; iIndex++ )
                        {
                            MSFL.MSFLSecurityInfo msflSecurityInfoIndex = msflSecurityInfoArray[iIndex];
                            KLineViewFormDocument frmDocument = new KLineViewFormDocument( msflSecurityInfoIndex );
                            frmDocument.MdiParent = this;
                            frmDocument.Text = msflSecurityInfoIndex.szName + "[" + msflSecurityInfoIndex.szSymbol + "]";
                            frmDocument.Show();
                        }
                    }
                }
            } while ( false );

            processForm.EndProcessForm();
        }

        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent e )
        {
            switch ( e.control.Id )
            {
                case ID.ID_VIEW_OPTIONS:
                    m_KLineViewOptionForm.ShowDialog();

                    break;
                case ID.ID_VIEW_SEARCH_U50:
                    //if ( this.ActiveMdiChild == null )
                    //    break;

                    KLineU50ConfigForm klineU50ConfigForm = new KLineU50ConfigForm();

                    if ( klineU50ConfigForm.ShowDialog() == DialogResult.OK )
                    {
                    }

                    break;
                case ID.ID_VIEW_SEARCH_D50:
                    if ( this.ActiveMdiChild == null )
                        break;

                    KLineD50ConfigForm klineD50ConfigForm = new KLineD50ConfigForm();

                    if ( klineD50ConfigForm.ShowDialog() == DialogResult.OK )
                    {
                    }

                    break;
                case ID.ID_FILE_OPEN:
                    LoadNewDocument();

                    break;
                case ID.ID_FILE_CLOSE:
                    if ( this.ActiveMdiChild != null )
                        this.ActiveMdiChild.Close();

                    break;
                case ID.ID_VIEW_CURVE:

                    break;
                case ID.ID_VIEW_INFO:

                    break;
                default:
                    break;
            }
        }

        private void axCommandBars_UpdateEvent( object sender, AxXtremeCommandBars._DCommandBarsEvents_UpdateEvent e )
        {
            switch ( e.control.Id )
            {
                case ID.ID_VIEW_SEARCH_AUTO:
                case ID.ID_VIEW_SEARCH_U50:
                case ID.ID_VIEW_SEARCH_D50:
                    //if ( this.ActiveMdiChild == null )
                    //    e.control.Enabled = false;
                    //else
                    //    e.control.Enabled = true;

                    break;
                case ID.ID_FILE_CLOSE:
                    e.control.Enabled = ( this.ActiveMdiChild != null );

                    break;
                case ID.ID_VIEW_CURVE:
                    if ( this.ActiveMdiChild == null )
                        e.control.Enabled = false;

                        break;

                case ID.ID_VIEW_INFO:
                    if ( this.ActiveMdiChild == null )
                        e.control.Enabled = false;

                        break;
                case ID.ID_WELCOME:
                case ID.ID_TO:
                case ID.ID_DEMO_SOFT:
                case ID.ID_TEAM:
                    e.control.Enabled = false;

                    break;
                default:

                    break;
            }
        }

        private void axCommandBars_Customization( object sender, AxXtremeCommandBars._DCommandBarsEvents_CustomizationEvent e )
        {
        }

        public void ShowNewReport()
        {
            throw new NotImplementedException();
        }
    }
}
