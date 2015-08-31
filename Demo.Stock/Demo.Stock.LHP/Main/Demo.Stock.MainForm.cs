using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeCommandBars;
using Demo.Stock.LHP.Common;
using Demo.Stock.LHP.BaseSR;

namespace Demo.Stock.LHP.Main
{
    public partial class MainForm : Form
    {
        private static MainForm s_MainForm = null;
        public static MainForm Instance
        {
            get { return s_MainForm; }
        }

        private OptionForm m_MainOptionForm = new OptionForm();
        public OptionForm OptionForm
        {
            get { return m_MainOptionForm; }
        }

        private DocumentHomeForm m_DocumentHomeForm = new DocumentHomeForm();

        public MainForm()
        {
            s_MainForm = this;

            InitializeComponent();
        }

        private RibbonBar RibbonBar
        {
            get { return axCommandBars.ActiveMenuBar as RibbonBar; }
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            CreateRibbonBar();

            LoadIcons();

            // 添加快捷键
            axCommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'O' ), ResourceId.ID_CONFIG_STOCK );
            axCommandBars.KeyBindings.Add( ResourceId.FCONTROL, System.Convert.ToInt32( 'N' ), ResourceId.ID_NEW_SR );

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
            this.axCommandBars.ShowTabWorkspace( false );
            axCommandBars.EnableCustomization( true );

            MSFL.MSFL1_Initialize( "MSFL Main Form", "H.Q.Cai", MSFL.MSFL_DLL_INTERFACE_VERSION );

            this.LoadNewHomeDocument();
        }

        private void CreateRibbonBar()
        {
            RibbonBar ribbonBar = axCommandBars.AddRibbonBar( "DemoSoft Team Ribbon" );
            ribbonBar.EnableDocking( XTPToolBarFlags.xtpFlagStretched );

            // 系统菜单
            CommandBarPopup popupSystem = ribbonBar.AddSystemButton();
            popupSystem.IconId = ResourceId.ID_SYSTEM_ICON;
            popupSystem.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_CONFIG_STOCK, "配置程序(&O)", false, false );
            CommandBarControl controlSystem = popupSystem.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_APP_HIDE, "退出(&E)", false, false );
            controlSystem.BeginGroup = true;
            popupSystem.CommandBar.SetIconSize( 32, 32 );

            // 关于菜单
            CommandBarControl controlAbout = ribbonBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_APP_ABOUT, "关于(&A)", false, false );
            controlAbout.Flags = XTPControlFlags.xtpFlagRightAlign;

            // 主页
            RibbonTab primarySR = ribbonBar.InsertTab( 0, "主页(&H)" );
            primarySR.Id = ResourceId.ID_HOME;

            // 配置 -> 配置程序
            RibbonGroup groupConfig = primarySR.Groups.AddGroup( "配置(&C)", ResourceId.ID_CONFIG_BUILD );
            CommandBarControl controlConfigApp = groupConfig.Add( XTPControlType.xtpControlButton, ResourceId.ID_CONFIG_STOCK, "配置程序(&O)", false, false );

            // 生成SR -> 创建SR报表
            RibbonGroup groupPrimaryStockBuild = primarySR.Groups.AddGroup( "生成SR(&B)", ResourceId.ID_SR_BUILD );
            CommandBarControl controlBuildPrimaryReportS = groupPrimaryStockBuild.Add( XTPControlType.xtpControlSplitButtonPopup, ResourceId.ID_NEW_SR, "创建SR报表(&C)", false, false );
            controlBuildPrimaryReportS.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_LOAD_SR_FILE, "读取SR报表(&L)", false, false );
            controlBuildPrimaryReportS.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_LOAD_SR_CONFIG, "读取SR策略(&L)", false, false );

            // 视图
            RibbonTab tabView = ribbonBar.InsertTab( 3, "视图(&V)" );
            tabView.Id = ResourceId.ID_TAB_VIEW;

            // 视图 -> 报表
            RibbonGroup groupShow = tabView.Groups.AddGroup( "报表(&D)", ResourceId.ID_GROUP_SHOW );
            CommandBarControl controlWorkspace = groupShow.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_SHOW_WORKSPACE, "工作区(&W)", false, false );
            groupShow.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_SHOW_STATUS, "状态栏(&S)", false, false );

            // 工具
            RibbonTab tabTools = ribbonBar.InsertTab( 4, "工具(&T)" );
            tabTools.Id = ResourceId.ID_TAB_TOOLS;

            // 工具 -> 内部工具
            RibbonGroup groupTools = tabTools.Groups.AddGroup( "内部工具(&I)", ResourceId.ID_GROUP_TOOLS );

            // Welcome To DemoSoft Team
            ribbonBar.QuickAccessControls.Add( XTPControlType.xtpControlButton, ResourceId.ID_WELCOME, " Home ", false, false );
        }

        private void LoadIcons()
        {
            axCommandBars.Options.UseSharedImageList = false;

            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_CONFIG_STOCK, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_APP_HIDE, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_NEW_SR, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_LOAD_SR_FILE, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_LOAD_SR_CONFIG, XTPImageState.xtpImageNormal );

            axCommandBars.ToolTipContext.Style = XTPToolTipStyle.xtpToolTipOffice2007;
            axCommandBars.ToolTipContext.ShowTitleAndDescription( true, XTPToolTipIcon.xtpToolTipIconNone );
            axCommandBars.ToolTipContext.SetMargin( 2, 2, 2, 2 );
            axCommandBars.ToolTipContext.MaxTipWidth = 180;
        }

/*
        public void LoadNewFile_Dynamic()
        {
            if ( m_DocumentFormDynamic.Visible == false )
            {
                m_DocumentFormDynamic = new DocumentForm2();

                m_DocumentFormDynamic.Text = "初级SR动态报表";
                m_DocumentFormDynamic.MdiParent = this;
                m_DocumentFormDynamic.Show();

                this.Text = "DemoSoft - " + m_DocumentFormDynamic.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormDynamic.Handle.ToInt32() );

            }
            else
                m_DocumentFormDynamic.Activate();

            this.SuspendLayout();

            m_DocumentFormDynamic.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        public void LoadNewFile_StockDCUR()
        {
            if ( m_DocumentFormStockDCUR.Visible == false )
            {
                m_DocumentFormStockDCUR = new DocumentForm3();

                m_DocumentFormStockDCUR.Text = "优质UT股票清单";
                m_DocumentFormStockDCUR.MdiParent = this;
                m_DocumentFormStockDCUR.Show();

                this.Text = "DemoSoft - " + m_DocumentFormStockDCUR.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormStockDCUR.Handle.ToInt32() );

            }
            else
                m_DocumentFormStockDCUR.Activate();

            this.SuspendLayout();

            m_DocumentFormStockDCUR.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        public void LoadNewFile_StaticDCUR()
        {
            if ( m_DocumentFormStaticDCUR.Visible == false )
            {
                m_DocumentFormStaticDCUR = new DocumentForm4();

                m_DocumentFormStaticDCUR.Text = "优质UT静态报表";
                m_DocumentFormStaticDCUR.MdiParent = this;
                m_DocumentFormStaticDCUR.Show();

                this.Text = "DemoSoft - " + m_DocumentFormStaticDCUR.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormStaticDCUR.Handle.ToInt32() );

            }
            else
                m_DocumentFormStaticDCUR.Activate();

            this.SuspendLayout();

            m_DocumentFormStaticDCUR.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        public void LoadNewFile_DynamicDCUR()
        {
            if ( m_DocumentFormDynamicDCUR.Visible == false )
            {
                m_DocumentFormDynamicDCUR = new DocumentForm5();

                m_DocumentFormDynamicDCUR.Text = "优质UT动态报表";
                m_DocumentFormDynamicDCUR.MdiParent = this;
                m_DocumentFormDynamicDCUR.Show();

                this.Text = "DemoSoft - " + m_DocumentFormDynamicDCUR.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormDynamicDCUR.Handle.ToInt32() );

            }
            else
                m_DocumentFormDynamicDCUR.Activate();

            this.SuspendLayout();

            m_DocumentFormDynamicDCUR.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        public void LoadNewFile_QualityDCUR()
        {
            if ( m_DocumentFormQualityDCUR.Visible == false )
            {
                m_DocumentFormQualityDCUR = new DocumentForm6();

                m_DocumentFormQualityDCUR.Text = "DCUR股票清单";
                m_DocumentFormQualityDCUR.MdiParent = this;
                m_DocumentFormQualityDCUR.Show();

                this.Text = "DemoSoft - " + m_DocumentFormQualityDCUR.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormQualityDCUR.Handle.ToInt32() );

            }
            else
                m_DocumentFormQualityDCUR.Activate();

            this.SuspendLayout();

            m_DocumentFormQualityDCUR.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        public void LoadNewFile_StockDCDS()
        {
            if ( m_DocumentFormStockDCDS.Visible == false )
            {
                m_DocumentFormStockDCDS = new DocumentForm7();

                m_DocumentFormStockDCDS.Text = "优质DT股票清单";
                m_DocumentFormStockDCDS.MdiParent = this;
                m_DocumentFormStockDCDS.Show();

                this.Text = "DemoSoft - " + m_DocumentFormStockDCDS.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormStockDCDS.Handle.ToInt32() );

            }
            else
                m_DocumentFormStockDCDS.Activate();

            this.SuspendLayout();

            m_DocumentFormStockDCDS.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        public void LoadNewFile_StaticDCDS()
        {
            if ( m_DocumentFormStaticDCDS.Visible == false )
            {
                m_DocumentFormStaticDCDS = new DocumentForm8();

                m_DocumentFormStaticDCDS.Text = "优质DT静态报表";
                m_DocumentFormStaticDCDS.MdiParent = this;
                m_DocumentFormStaticDCDS.Show();

                this.Text = "DemoSoft - " + m_DocumentFormStaticDCDS.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormStaticDCDS.Handle.ToInt32() );

            }
            else
                m_DocumentFormStaticDCDS.Activate();

            this.SuspendLayout();

            m_DocumentFormStaticDCDS.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        public void LoadNewFile_DynamicDCDS()
        {
            if ( m_DocumentFormDynamicDCDS.Visible == false )
            {
                m_DocumentFormDynamicDCDS = new DocumentForm9();

                m_DocumentFormDynamicDCDS.Text = "优质DT动态报表";
                m_DocumentFormDynamicDCDS.MdiParent = this;
                m_DocumentFormDynamicDCDS.Show();

                this.Text = "DemoSoft - " + m_DocumentFormDynamicDCDS.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormDynamicDCDS.Handle.ToInt32() );

            }
            else
                m_DocumentFormDynamicDCDS.Activate();

            this.SuspendLayout();

            m_DocumentFormDynamicDCDS.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        public void LoadNewFile_QualityDCDS()
        {
            if ( m_DocumentFormQualityDCDS.Visible == false )
            {
                m_DocumentFormQualityDCDS = new DocumentForm10();

                m_DocumentFormQualityDCDS.Text = "DCDS股票清单";
                m_DocumentFormQualityDCDS.MdiParent = this;
                m_DocumentFormQualityDCDS.Show();

                this.Text = "DemoSoft - " + m_DocumentFormQualityDCDS.Text;

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentFormQualityDCDS.Handle.ToInt32() );

            }
            else
                m_DocumentFormQualityDCDS.Activate();

            this.SuspendLayout();

            m_DocumentFormQualityDCDS.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

*/

        public void LoadNewHomeDocument()
        {
            if ( m_DocumentHomeForm.Visible == false )
            {
                m_DocumentHomeForm = new DocumentHomeForm();

                m_DocumentHomeForm.Text = "  主页    ";
                m_DocumentHomeForm.MdiParent = this;
                m_DocumentHomeForm.Show();

                this.Text = "Sonima";

                axCommandBars.EnableOffice2007FrameHandle( m_DocumentHomeForm.Handle.ToInt32() );

            }
            else
                m_DocumentHomeForm.Activate();

            this.SuspendLayout();

            //m_DocumentHomeForm.InitSRReport( GlobalSetting.SRReports );

            this.ResumeLayout( false );
        }

        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case (int)XtremeCommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCUSTOMIZE:
                    axCommandBars.ShowCustomizeDialog( 3 );

                    break;
                case ResourceId.ID_WELCOME:

                    LoadNewHomeDocument();

                    break;
                case ResourceId.ID_CONFIG_STOCK:

                    m_MainOptionForm.Show( this );
                    {
                    }

                    break;
                case ResourceId.ID_NEW_SR:

                    SR_MainForm srMainForm = new SR_MainForm();

                    srMainForm.Show();

                    break;
                case ResourceId.ID_LOAD_SR_FILE:

                    if ( this.openFileDialogSRReport.ShowDialog() == DialogResult.OK )
                    {
                        SR_MainForm srMainFormReport = new SR_MainForm();

                        srMainFormReport.Show();
                    }

                    break;
                case ResourceId.ID_LOAD_SR_CONFIG:

                    if ( this.openFileDialogSRStrategy.ShowDialog() == DialogResult.OK )
                    {
                        SR_MainForm srMainFormStrategy = new SR_MainForm();

                        srMainFormStrategy.Show();
                    }

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
                case ResourceId.ID_WELCOME:

                    eventArgs.control.Enabled = !m_DocumentHomeForm.Visible;

                    break;
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
        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( m_isClose == false )
            {
                MSFL.MSFL1_Shutdown();

                m_MainOptionForm.IsClose = true;

                m_isClose = true;
                this.Close();
            }
        }
    }
}
