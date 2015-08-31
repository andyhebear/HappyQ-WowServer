using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeCommandBars;
using Demo.Stock.LHP.UTMR_DTMS;

namespace Demo.Stock.LHP.BaseSR
{
    public partial class SR_MainForm : Form
    {
        public SR_MainForm()
        {
            InitializeComponent();
        }

        private SROptionForm m_PrimaryScanOptionForm = new SROptionForm();
        private DocumentSRForm m_DocumentFormStatic = new DocumentSRForm();
        private DocumentMSRKForm m_DocumentFormStatic2 = new DocumentMSRKForm();

        private RibbonBar RibbonBar
        {
            get { return axCommandBars.ActiveMenuBar as RibbonBar; }
        }

        private void SR_MainForm_Load( object sender, EventArgs e )
        {
            CreateRibbonBar();

            LoadIcons();

            // 添加快捷键
            //axCommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'N' ), ResourceId.ID_FILE_CONFIG_POLICY );

            // 添加状态栏
            axCommandBars.StatusBar.AddPane( 0 );
            axCommandBars.StatusBar.AddPane( ResourceId.ID_INDICATOR_CAPS );
            axCommandBars.StatusBar.AddPane( ResourceId.ID_INDICATOR_NUM );
            axCommandBars.StatusBar.AddPane( ResourceId.ID_INDICATOR_SCRL );
            axCommandBars.StatusBar.Visible = true;
            axCommandBars.StatusBar.IdleText = "Sonima Inc. (Canada) All rights reserved *** (2009 Ver 1.1) *** Update : 2009-01-24";
            axCommandBars.StatusBar.SetPaneText( 0, axCommandBars.StatusBar.IdleText );

            RibbonBar.EnableFrameTheme();
            axCommandBars.Options.KeyboardCuesShow = XTPKeyboardCuesShow.xtpKeyboardCuesShowWindowsDefault;

            foreach ( Control control in this.Controls )
            {
                if ( control is MdiClient )
                    axCommandBars.SetMDIClient( control.Handle.ToInt32() );
            }

            this.axCommandBars.TabWorkspace.PaintManager.Position = XTPTabPosition.xtpTabPositionBottom;
            this.axCommandBars.ShowTabWorkspace( true );
            this.axCommandBars.EnableCustomization( true );
        }


        private void CreateRibbonBar()
        {
            RibbonBar ribbonBar = axCommandBars.AddRibbonBar( "DemoSoft Team Ribbon" );
            ribbonBar.EnableDocking( XTPToolBarFlags.xtpFlagStretched );

            // 系统菜单
            CommandBarPopup popupSystem = ribbonBar.AddSystemButton();
            popupSystem.IconId = ResourceId.ID_SYSTEM_ICON;
            popupSystem.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_CONFIG_SR, "配置(&P)", false, false );
            CommandBarControl controlSystem = popupSystem.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_APP_HIDE, "退出(&E)", false, false );
            controlSystem.BeginGroup = true;
            popupSystem.CommandBar.SetIconSize( 32, 32 );

            // 关于菜单
            CommandBarControl controlAbout = ribbonBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_APP_ABOUT, "关于(&A)", false, false );
            controlAbout.Flags = XTPControlFlags.xtpFlagRightAlign;

            // 主页
            RibbonTab primarySR = ribbonBar.InsertTab( 0, "主页(&H)" );
            primarySR.Id = ResourceId.ID_HOME_SR;

            // 初级SR报表 -> 初级SR生成
            RibbonGroup groupConfig = primarySR.Groups.AddGroup( "配置(&C)", ResourceId.ID_CONFIG_BUILD );
            CommandBarControl controlConfigApp = groupConfig.Add( XTPControlType.xtpControlButton, ResourceId.ID_CONFIG_SR, "配置策略(&O)", false, false );

            // 初级SR报表 -> 初级SR生成
            RibbonGroup groupPrimaryStockBuild = primarySR.Groups.AddGroup( "SR生成(&F)", ResourceId.ID_SR_BUILD );
            CommandBarControl controlBuildPrimaryReportS = groupPrimaryStockBuild.Add( XTPControlType.xtpControlButton, ResourceId.ID_BUILD_SR, "生成SR报表(&T)", false, false );
            CommandBarControl controlBuildPrimaryReportSsa = groupPrimaryStockBuild.Add( XTPControlType.xtpControlSplitButtonPopup, ResourceId.ID_NEW_UTMR_DTMS, "创建UTMR-DTMS报表(&T)", false, false );
            controlBuildPrimaryReportSsa.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_LOAD_UTMR_DTMS_FILE, "读取UTMR-DTMS报表(&L)", false, false );
            controlBuildPrimaryReportSsa.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_LOAD_UTMR_DTMS_CONFIG, "读取UTMR-DTMS策略(&L)", false, false );

            RibbonGroup groupPrimaryStockReport = primarySR.Groups.AddGroup( "SR报表(&F)", ResourceId.ID_SR_REPORT );
            CommandBarControl controlOpenPrimaryReportS = groupPrimaryStockReport.Add( XTPControlType.xtpControlButton, ResourceId.ID_REPORT_SR, "显示SR静态报表(&S)", false, false );
            CommandBarControl controlOpenPrimaryReportD = groupPrimaryStockReport.Add( XTPControlType.xtpControlButton, ResourceId.ID_REPORT_MSRK, "显示MSRK报表(&M)", false, false );

            // 视图
            RibbonTab tabView = ribbonBar.InsertTab( 3, "视图(&V)" );
            tabView.Id = ResourceId.ID_TAB_VIEW;

            // 视图 -> 报表
            RibbonGroup groupShow = tabView.Groups.AddGroup( "报表(&D)", ResourceId.ID_GROUP_SHOW );
            CommandBarControl controlWorkspace = groupShow.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_SHOW_WORKSPACE, "工作区(&W)", false, false );
            controlWorkspace.Checked = true;
            groupShow.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_SHOW_STATUS, "状态栏(&S)", false, false );

            // 工具
            RibbonTab tabTools = ribbonBar.InsertTab( 4, "工具(&T)" );
            tabTools.Id = ResourceId.ID_TAB_TOOLS;

            // 工具 -> 内部工具
            RibbonGroup groupTools = tabTools.Groups.AddGroup( "内部工具(&I)", ResourceId.ID_GROUP_TOOLS );

            // Welcome To DemoSoft Team
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceId.ID_WELCOME, "SR", false, false );
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceId.ID_TO, "Trading", false, false );
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceId.ID_DEMO_SOFT, "Wizard", false, false );
            //ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceId.ID_TEAM, "Team", false, false );
        }

        private void LoadIcons()
        {
            axCommandBars.Options.UseSharedImageList = false;

            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_CONFIG_SR, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_APP_HIDE, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_BUILD_SR, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_NEW_UTMR_DTMS, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_LOAD_UTMR_DTMS_FILE, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_LOAD_UTMR_DTMS_CONFIG, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_REPORT_SR, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_REPORT_MSRK, XTPImageState.xtpImageNormal );

            axCommandBars.ToolTipContext.Style = XTPToolTipStyle.xtpToolTipOffice2007;
            axCommandBars.ToolTipContext.ShowTitleAndDescription( true, XTPToolTipIcon.xtpToolTipIconNone );
            axCommandBars.ToolTipContext.SetMargin( 2, 2, 2, 2 );
            axCommandBars.ToolTipContext.MaxTipWidth = 180;
        }

        public void LoadNewFile_SR()
        {
            if ( m_DocumentFormStatic.Visible == false )
            {
                m_DocumentFormStatic = new DocumentSRForm();

                m_DocumentFormStatic.Text = "初级SR静态报表";
                m_DocumentFormStatic.MdiParent = this;
                m_DocumentFormStatic.Show();

                this.Text = "DemoSoft - " + m_DocumentFormStatic.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormStatic.Handle.ToInt32() );

            }
            else
                m_DocumentFormStatic.Activate();

            this.SuspendLayout();

            //m_DocumentFormStatic.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        public void LoadNewFile_MSRK()
        {
            if ( m_DocumentFormStatic2.Visible == false )
            {
                m_DocumentFormStatic2 = new DocumentMSRKForm();

                m_DocumentFormStatic2.Text = "初级MSRK报表";
                m_DocumentFormStatic2.MdiParent = this;
                m_DocumentFormStatic2.Show();

                this.Text = "DemoSoft - " + m_DocumentFormStatic2.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormStatic2.Handle.ToInt32() );

            }
            else
                m_DocumentFormStatic2.Activate();

            this.SuspendLayout();

            //m_DocumentFormStatic2.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case (int)XtremeCommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCUSTOMIZE:
                    axCommandBars.ShowCustomizeDialog( 3 );

                    break;
                case ResourceId.ID_CONFIG_SR:

                    m_PrimaryScanOptionForm.Show( this );
                    {
                    }

                    break;
                case ResourceId.ID_BUILD_SR:


                    break;
                case ResourceId.ID_NEW_UTMR_DTMS:

                    UTMR_DTMS_MainFrom utmr_dtms_MainFrom = new UTMR_DTMS_MainFrom();

                    utmr_dtms_MainFrom.Show();

                    break;
                case ResourceId.ID_LOAD_UTMR_DTMS_FILE:

                    if ( this.openFileDialogReport.ShowDialog() == DialogResult.OK )
                    {
                        UTMR_DTMS_MainFrom utmr_dtms_MainFromB = new UTMR_DTMS_MainFrom();

                        utmr_dtms_MainFromB.Show();
                    }

                    break;
                case ResourceId.ID_LOAD_UTMR_DTMS_CONFIG:

                    if ( this.openFileDialogStrategy.ShowDialog() == DialogResult.OK )
                    {
                        UTMR_DTMS_MainFrom utmr_dtms_MainFromA = new UTMR_DTMS_MainFrom();

                        utmr_dtms_MainFromA.Show();
                    }

                    break;
                case ResourceId.ID_REPORT_SR:

                    LoadNewFile_SR();

                    break;
                case ResourceId.ID_REPORT_MSRK:

                    LoadNewFile_MSRK();

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
                default:

                    break;
            }
        }


        private void axCommandBars_Customization( object sender, AxXtremeCommandBars._DCommandBarsEvents_CustomizationEvent eventArgs )
        {
            eventArgs.options.ShowRibbonQuickAccessPage = true;

            XtremeCommandBars.CommandBarControls cmbControls = this.axCommandBars.DesignerControls;
            if ( cmbControls.Count == 0 )
            {
            }
        }

        private bool m_isClose = false;
        private void SR_MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( m_isClose == false )
            {
                m_PrimaryScanOptionForm.IsClose = true;

                m_isClose = true;
                this.Close();
            }
        }
    }
}
