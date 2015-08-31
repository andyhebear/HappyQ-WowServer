using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Demo.Stock.X.Tools;
using Demo.Stock.X.U50.Common;
using XtremeCommandBars;

namespace Demo.Stock.X.U50
{
    public partial class U50Form : Form
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        private PolicyForm m_PolicyForm = new PolicyForm();
        #endregion
        public PolicyForm PolicyForm
        {
            get { return m_PolicyForm; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        private TaskForm m_TaskForm = new TaskForm();
        #endregion
        public TaskForm TaskForm
        {
            get { return m_TaskForm; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        private KLineViewForm m_KLineViewForm = new KLineViewForm();
        #endregion
        public KLineViewForm KLineViewForm
        {
            get { return m_KLineViewForm; }
        }
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        public U50Form()
        {
            InitializeComponent();

            m_KLineViewForm.FormClosing += new FormClosingEventHandler( KLineViewForm_FormClosing );
        }


        public void Initialize()
        {
            U50GlobalSetting.LoadGlobalRegistry();

            if ( U50GlobalSetting.IsAutoLoadPolicySetting == true )
            {
                if ( U50GlobalSetting.LoadPolicyGlobalSetting() == false )
                    MainForm.ShowPopupMessage( "读取策略文件失败！", "可能文件不存在或格式错误。。。", "请点击<配置策略>的<新建策略>" );
            }
            m_PolicyForm.Initialize();

            if ( U50GlobalSetting.IsAutoLoadTaskSetting == true )
            {
                if ( U50GlobalSetting.LoadTaskGlobalSetting() == false )
                    MainForm.ShowPopupMessage( "读取任务文件失败！", "可能文件不存在或格式错误。。。", "请点击<配置任务>的<新建任务>" );
            }
            m_TaskForm.Initialize();
        }
        #endregion

        private void KLineViewForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            e.Cancel = true;
            m_KLineViewForm.Hide();
        }

        private void U50Form_Load( object sender, EventArgs eventArgs )
        {
            CreateRibbonBar();

            LoadIcons();

            // 添加快捷键
            axCommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'N' ), ResourceId.ID_FILE_CONFIG_POLICY );

            // 添加状态栏
            axCommandBars.StatusBar.AddPane( 0 );
            axCommandBars.StatusBar.AddPane( ResourceId.ID_INDICATOR_CAPS );
            axCommandBars.StatusBar.AddPane( ResourceId.ID_INDICATOR_NUM );
            axCommandBars.StatusBar.AddPane( ResourceId.ID_INDICATOR_SCRL );
            axCommandBars.StatusBar.Visible = true;

            RibbonBar().EnableFrameTheme();
            axCommandBars.Options.KeyboardCuesShow = XTPKeyboardCuesShow.xtpKeyboardCuesShowWindowsDefault;

            foreach ( Control control in this.Controls )
            {
                if ( control is MdiClient )
                    axCommandBars.SetMDIClient( control.Handle.ToInt32() );
            }

            this.axCommandBars.TabWorkspace.PaintManager.Position = XTPTabPosition.xtpTabPositionBottom;
            this.axCommandBars.ShowTabWorkspace( true );
            axCommandBars.EnableCustomization( true );
        }

        private RibbonBar RibbonBar()
        {
            return axCommandBars.ActiveMenuBar as RibbonBar;
        }

        private void U50GlobalSetting_LoadingTaskSetting( object sender, EventArgs e )
        {
        }

        private CommandBarPopup m_ControlOpen = null;
        private CommandBarPopup m_ControlClose = null;
        private Dictionary<int, ControlCommandInfo> m_ControlCommandInfoDictionary = new Dictionary<int, ControlCommandInfo>();

        public class ControlCommandInfo
        {
            public int OpenID = 0;
            public int CloseID = 0;
            public DocumentForm Form = null;
            public bool IsShowOK = false;
            public bool IsOpen = false; 
            public string Name = string.Empty;

        }

        private void U50GlobalSetting_LoadedTaskSetting( object sender, EventArgs e )
        {
            m_ControlOpen.CommandBar.Controls.DeleteAll();
            m_ControlClose.CommandBar.Controls.DeleteAll();

            m_ControlCommandInfoDictionary.Clear();

            // 打开报表
            m_ControlOpen.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_OPEN_ALL, "打开全部报表(&A)", false, false );
            m_ControlOpen.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_OPEN_SCAN_POLICY, "扫描中的报表(&A)", false, false );

            // 关闭报表
            m_ControlClose.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_CLOSE_ALL, "关闭全部(&A)", false, false );

            int index = 1;
            foreach ( var item in TaskManager.Instance.ToArray() )
            {
                CommandBarControl controlOpenPolicy01 = m_ControlOpen.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_OPEN_POLICY01 + index, string.Format( "打开<{0}>报表", item.Name ), false, false );
                if ( index == 1 )
                    controlOpenPolicy01.BeginGroup = true;

                CommandBarControl controlClosePolicy01 = m_ControlClose.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_CLOSE_POLICY01 + index, string.Format( "关闭<{0}>报表", item.Name ), false, false );
                if ( index == 1 )
                    controlClosePolicy01.BeginGroup = true;

                ControlCommandInfo vOpen = new ControlCommandInfo();
                vOpen.IsShowOK = true;
                vOpen.OpenID = ResourceId.ID_FILE_OPEN_POLICY01 + index;
                vOpen.CloseID = ResourceId.ID_FILE_CLOSE_POLICY01 + index;
                vOpen.IsOpen = true;
                vOpen.Name = item.Name;

                m_ControlCommandInfoDictionary.Add( vOpen.OpenID, vOpen );

                ControlCommandInfo vClose = new ControlCommandInfo();
                vClose.IsShowOK = false;
                vClose.OpenID = vOpen.OpenID;
                vClose.CloseID = vOpen.CloseID;
                vClose.IsOpen = false;
                vClose.Name = item.Name;

                m_ControlCommandInfoDictionary.Add( vClose.CloseID, vClose );

                index++;
           }
        }

        private void CreateRibbonBar()
        {
            RibbonBar ribbonBar = axCommandBars.AddRibbonBar( "DemoSoft Team Ribbon" );
            ribbonBar.EnableDocking( XTPToolBarFlags.xtpFlagStretched );

            // 系统菜单
            CommandBarPopup popupSystem = ribbonBar.AddSystemButton();
            popupSystem.IconId = ResourceId.ID_SYSTEM_ICON;
            popupSystem.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_CONFIG_POLICY, "配置策略(&P)", false, false );
            popupSystem.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_CONFIG_TASK, "配置任务(&T)", false, false );
            CommandBarControl controlSystem = popupSystem.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_APP_HIDE, "退出(&E)", false, false );
            controlSystem.BeginGroup = true;
            popupSystem.CommandBar.SetIconSize( 32, 32 );

            // 关于菜单
            CommandBarControl controlAbout = ribbonBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_APP_ABOUT, "关于(&A)", false, false );
            controlAbout.Flags = XTPControlFlags.xtpFlagRightAlign;

            // 开始
            RibbonTab tabHome = ribbonBar.InsertTab( 0, "开始(&H)" );
            tabHome.Id = ResourceId.ID_TAB_HOME;

            // 开始 -> 文件
            RibbonGroup groupFile = tabHome.Groups.AddGroup( "文件(&F)", ResourceId.ID_GROUP_FILE );
            CommandBarPopup controlConfig = (CommandBarPopup)groupFile.Add( XTPControlType.xtpControlSplitButtonPopup, ResourceId.ID_FILE_CONFIG_POLICY, "配置策略(&P)", false, false );
            controlConfig.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_CONFIG_NEW_POLICY, "新建策略(&N)", false, false );

            CommandBarPopup controlConfig1 = (CommandBarPopup)groupFile.Add( XTPControlType.xtpControlSplitButtonPopup, ResourceId.ID_FILE_CONFIG_TASK, "配置任务(&T)", false, false );
            controlConfig1.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_CONFIG_NEW_TASK, "新建任务(&N)", false, false );

            //CommandBarPopup controlConfig2 = (CommandBarPopup)groupFile.Add( XTPControlType.xtpControlButtonPopup, ResourceId.ID_FILE_SCAN_TASK, "扫描任务(&T)", false, false );
            //controlConfig2.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_SCAN_ALL_TASK, "扫描全部(&N)", false, false );

            // 开始 -> 报表
            RibbonGroup groupReport = tabHome.Groups.AddGroup( "报表(&R)", ResourceId.ID_GROUP_FILE );
            m_ControlOpen = (CommandBarPopup)groupReport.Add( XTPControlType.xtpControlButtonPopup, ResourceId.ID_FILE_OPEN, "打开报表(&O)", false, false );
            m_ControlClose = (CommandBarPopup)groupReport.Add( XTPControlType.xtpControlButtonPopup, ResourceId.ID_FILE_CLOSE, "关闭报表(&C)", false, false );

            U50GlobalSetting.LoadingTaskSetting += new EventHandler( U50GlobalSetting_LoadingTaskSetting );
            U50GlobalSetting.LoadedTaskSetting += new EventHandler( U50GlobalSetting_LoadedTaskSetting );
            TaskManager.Instance.AddedTaskInfo += new EventHandler( U50GlobalSetting_LoadedTaskSetting );
            TaskManager.Instance.RemoveTaskInfo += new EventHandler( U50GlobalSetting_LoadedTaskSetting );
            TaskManager.Instance.RefreshTaskInfo += new EventHandler( U50GlobalSetting_LoadedTaskSetting );
            U50GlobalSetting_LoadedTaskSetting(this, EventArgs.Empty );

            // 视图
            RibbonTab tabView = ribbonBar.InsertTab( 2, "视图(&V)" );
            tabView.Id = ResourceId.ID_TAB_VIEW;

            // 视图 -> 显示
            RibbonGroup groupShow = tabView.Groups.AddGroup( "显示(&D)", ResourceId.ID_GROUP_SHOW );
            CommandBarControl controlWorkspace = groupShow.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_SHOW_WORKSPACE, "工作区(&W)", false, false );
            controlWorkspace.Checked = true;
            groupShow.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_SHOW_STATUS, "状态栏(&S)", false, false );

            // 视图 -> 图表
            RibbonGroup groupGraph = tabView.Groups.AddGroup( "图表(&D)", ResourceId.ID_GROUP_GRAPH );
            groupGraph.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_GRAPH_WORKSPACE, "主升浪幅度线(&W)", false, false );
            groupGraph.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_GRAPH_STATUS, "下跌浪幅度线(&S)", false, false );
            groupGraph.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_GRAPH_STATUS, "盘整浪幅度线(&S)", false, false );
            groupGraph.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_GRAPH_STATUS, "整理区幅度线(&S)", false, false );

            // 工具
            RibbonTab tabTools = ribbonBar.InsertTab( 3, "工具(&T)" );
            tabTools.Id = ResourceId.ID_TAB_TOOLS;

            // 工具 -> 内部工具
            RibbonGroup groupTools = tabTools.Groups.AddGroup( "内部工具(&I)", ResourceId.ID_GROUP_TOOLS );

            // Welcome To DemoSoft Team
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceId.ID_WELCOME, "Welcome", false, false );
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceId.ID_TO, "To", false, false );
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceId.ID_DEMO_SOFT, "DemoSoft", false, false );
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceId.ID_TEAM, "Team", false, false );
        }

        private void LoadIcons()
        {
            axCommandBars.Options.UseSharedImageList = false;

            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_FILE_CONFIG_POLICY, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_FILE_CONFIG_TASK, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_FILE_SCAN_TASK, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_FILE_OPEN, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_FILE_CLOSE, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_SYSTEM_ICON, XtremeCommandBars.XTPImageState.xtpImageNormal );

            axCommandBars.ToolTipContext.Style = XTPToolTipStyle.xtpToolTipOffice2007;
            axCommandBars.ToolTipContext.ShowTitleAndDescription( true, XTPToolTipIcon.xtpToolTipIconNone );
            axCommandBars.ToolTipContext.SetMargin( 2, 2, 2, 2 );
            axCommandBars.ToolTipContext.MaxTipWidth = 180;
        }

        private DocumentForm LoadNewFile( String stringFileName )
        {
            this.SuspendLayout();

            DocumentForm documentForm = new DocumentForm();

            //if ( documentForm.OpenSGLFile( stringFileName ) == false )
            //    return;

            documentForm.Text = stringFileName;
            documentForm.MdiParent = this;
            //documentForm.SGLEditorForm = this;
            //documentForm.WindowState = FormWindowState.Normal;
            documentForm.Show();

            this.Text = "DemoSoft - " + documentForm.Text;

            axCommandBars.EnableOffice2007FrameHandle( documentForm.Handle.ToInt32() );

            //documentForm.WindowState = FormWindowState.Maximized;

            this.ResumeLayout( false );
            this.Refresh();

            return documentForm;
        }

        private ScanNowDocumentForm LoadNewFileFromScanNow( String stringFileName )
        {
            this.SuspendLayout();

            ScanNowDocumentForm documentForm = new ScanNowDocumentForm();
            documentForm.m_ScanNowReportList = m_ScanNowReportList;

            //if ( documentForm.OpenSGLFile( stringFileName ) == false )
            //    return;

            documentForm.Text = stringFileName;
            documentForm.MdiParent = this;
            //documentForm.SGLEditorForm = this;
            //documentForm.WindowState = FormWindowState.Normal;
            documentForm.Show();

            this.Text = "DemoSoft - " + documentForm.Text;

            axCommandBars.EnableOffice2007FrameHandle( documentForm.Handle.ToInt32() );

            //documentForm.WindowState = FormWindowState.Maximized;

            this.ResumeLayout( false );
            this.Refresh();

            return documentForm;
        }

        private void axCommandBars_Customization( object sender, AxXtremeCommandBars._DCommandBarsEvents_CustomizationEvent eventArgs )
        {
            eventArgs.options.ShowRibbonQuickAccessPage = true;

            XtremeCommandBars.CommandBarControls cmbControls = this.axCommandBars.DesignerControls;
            if ( cmbControls.Count == 0 )
            {
            }
        }

        private ScanNowDocumentForm m_ScanNowDocumentForm = null;
        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case (int)XtremeCommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCUSTOMIZE:
                    axCommandBars.ShowCustomizeDialog( 3 );
                    break;
                case ResourceId.ID_FILE_CONFIG_POLICY:

                    m_PolicyForm.ShowDialog();

                    break;
                case ResourceId.ID_FILE_CONFIG_NEW_POLICY:

                    m_PolicyForm.NewPolicy();
                    m_PolicyForm.ShowDialog();

                    break;
                case ResourceId.ID_FILE_CONFIG_TASK:

                    m_TaskForm.ShowDialog();

                    break;
                case ResourceId.ID_FILE_CONFIG_NEW_TASK:

                    m_TaskForm.NewTask();
                    m_TaskForm.ShowDialog();

                    break;
                case ResourceId.ID_FILE_OPEN:
                case ResourceId.ID_FILE_OPEN_ALL:


                    break;
                case ResourceId.ID_FILE_OPEN_SCAN_POLICY:

                    if ( m_ScanNowDocumentForm == null )
                        m_ScanNowDocumentForm = LoadNewFileFromScanNow( "扫描中的报表" );
                    else if ( m_ScanNowDocumentForm.Visible == false )
                        m_ScanNowDocumentForm = LoadNewFileFromScanNow( "扫描中的报表" );
                    else
                        m_ScanNowDocumentForm.Activate();


                    break;
                case ResourceId.ID_FILE_CLOSE:
                case ResourceId.ID_FILE_CLOSE_ALL:

                    break;
                case ResourceId.ID_SHOW_STATUS:
                    axCommandBars.StatusBar.Visible = !axCommandBars.StatusBar.Visible;
                    break;
                case ResourceId.ID_SHOW_WORKSPACE:
                    eventArgs.control.Checked = !eventArgs.control.Checked;
                    axCommandBars.ShowTabWorkspace( eventArgs.control.Checked );
                    break;
                case ResourceId.ID_APP_HIDE:
                    this.Close();
                    break;
                default:

                    ControlCommandInfo outCommandInfo = null;
                    if ( m_ControlCommandInfoDictionary.TryGetValue( eventArgs.control.Id, out outCommandInfo ) == true )
                    {
                        if ( outCommandInfo.IsOpen == true )
                        {
                            if ( outCommandInfo.Form == null )
                            {
                                outCommandInfo.Form = LoadNewFile( outCommandInfo.Name );
                            }
                            else
                            {
                                if ( outCommandInfo.Form.Visible == true )
                                    outCommandInfo.Form.Activate();
                                else
                                {
                                    outCommandInfo.Form = LoadNewFile( outCommandInfo.Name );
                                }
                            }
                            outCommandInfo.Form.m_OpenCommandInfo = outCommandInfo;

                            ControlCommandInfo outCommandInfoClose = null;
                            if ( m_ControlCommandInfoDictionary.TryGetValue( outCommandInfo.CloseID, out outCommandInfoClose ) == true )
                            {
                                outCommandInfoClose.Form = outCommandInfo.Form;

                                outCommandInfoClose.IsShowOK = true;

                                outCommandInfoClose.Form.m_CloseCommandInfo = outCommandInfoClose;
                            }
                        }
                        else
                        {
                            if ( outCommandInfo.Form != null )
                            {
                                outCommandInfo.Form.Close();
                                outCommandInfo.Form = null;
                                outCommandInfo.IsShowOK = false;
                                outCommandInfo.Form.m_CloseCommandInfo = null;

                                ControlCommandInfo outBoolOpen = null;
                                if ( m_ControlCommandInfoDictionary.TryGetValue( outCommandInfo.OpenID, out outBoolOpen ) == true )
                                {
                                    outBoolOpen.Form = null;
                                    outBoolOpen.Form.m_OpenCommandInfo = null;
                                }
                            }
                            else
                            {
                            }
                        }
                    }

                    break;
            }
        }

        private void axCommandBars_UpdateEvent( object sender, AxXtremeCommandBars._DCommandBarsEvents_UpdateEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case ResourceId.ID_SHOW_STATUS:
                    eventArgs.control.Checked = axCommandBars.StatusBar.Visible;
                    break;
                case ResourceId.ID_WELCOME:
                case ResourceId.ID_TO:
                case ResourceId.ID_DEMO_SOFT:
                case ResourceId.ID_TEAM:
                    eventArgs.control.Enabled = ( this.MdiChildren.Length != 0 ? true : false );
                    break;
                case (int)XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCONTROLTAB:
                    break;
                default:

                    ControlCommandInfo outBool = null;
                    if ( m_ControlCommandInfoDictionary.TryGetValue( eventArgs.control.Id, out outBool ) == true )
                    {
                        eventArgs.control.Enabled = outBool.IsShowOK;
                    }

                    break;
            }
        }

        public void EndU50Form()
        {
            this.Hide();
            this.m_U50FormTrueClose = true;
            this.Close();
            this.Dispose();
        }

        public event FormOpenEventHandler FormOpen;
        public event FormCloseEventHandler FormClose;

        private bool m_U50FormTrueClose = false;
        private void U50Form_FormClosing( object sender, FormClosingEventArgs eventArgs )
        {
            if ( m_U50FormTrueClose == true )
                return;

            eventArgs.Cancel = true;

            this.Hide();

            if ( this.FormClose != null )
                this.FormClose( this, this );
        }

        public class ScanNowReport
        {
            public U50ReportInfo ReportInfo = null;
            public string Name = string.Empty;
            public bool IsOK = false;
            public bool IsShowOK = false;
            public bool IsAddShowOK = false;
        }

        private List<ScanNowReport> m_ScanNowReportList = new List<ScanNowReport>();
        public void AddToList( ScanNowReport scanNowReport )
        {
            m_ScanNowReportList.Add( scanNowReport );
        }

        private void Timer1_Tick_1( object sender, EventArgs e )
        {
            //MyClassReport myClassYYYYY = new MyClassReport();
            //myClassYYYYY.IsOK = true;
            //myClassYYYYY.Name = "211212";
            //AddToList( myClassYYYYY );
        }
    }

    public delegate void FormOpenEventHandler( object sender, Form formOpen );
    public delegate void FormCloseEventHandler( object sender, Form formClose );
}
