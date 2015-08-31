using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeCommandBars;

namespace Demo.Stock.LHP.UTMR_DTMS
{
    public partial class UTMR_DTMS_MainFrom : Form
    {
        PrimaryScanOptionForm2 m_UTMR_DTMS_OptionForm = new PrimaryScanOptionForm2();

        public UTMR_DTMS_MainFrom()
        {
            InitializeComponent();
        }

        private RibbonBar RibbonBar
        {
            get { return axCommandBars.ActiveMenuBar as RibbonBar; }
        }

        private void UTMR_DTMS_MainFrom_Load( object sender, EventArgs e )
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
            popupSystem.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_CONFIG_UTMR_DTMS, "配置(&P)", false, false );
            CommandBarControl controlSystem = popupSystem.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_APP_HIDE, "退出(&E)", false, false );
            controlSystem.BeginGroup = true;
            popupSystem.CommandBar.SetIconSize( 32, 32 );

            // 关于菜单
            CommandBarControl controlAbout = ribbonBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_APP_ABOUT, "关于(&A)", false, false );
            controlAbout.Flags = XTPControlFlags.xtpFlagRightAlign;

            // 主页
            RibbonTab primarySR = ribbonBar.InsertTab( 0, "主页(&H)" );
            primarySR.Id = ResourceId.ID_UTMR_DTMS;

            // 主页 -> 配置
            RibbonGroup groupConfig = primarySR.Groups.AddGroup( "配置(&C)", ResourceId.ID_CONFIG_BUILD );
            CommandBarControl controlConfigApp = groupConfig.Add( XTPControlType.xtpControlButton, ResourceId.ID_CONFIG_UTMR_DTMS, "配置策略(&O)", false, false );

            // 主页 -> UTMR-DTMS生成
            RibbonGroup groupPrimaryStockBuild = primarySR.Groups.AddGroup( "UTMR-DTMS生成(&F)", ResourceId.ID_UTMR_DTMS_BUILD );
            CommandBarControl controlBuildPrimaryReportS = groupPrimaryStockBuild.Add( XTPControlType.xtpControlButton, ResourceId.ID_BUILD_UTMR_DTMS, "生成UTMR-DTMS报表(&T)", false, false );

            // 主页 -> UTMR-DTMS报表
            RibbonGroup groupPrimaryStockReport = primarySR.Groups.AddGroup( "UTMR-DTMS报表(&F)", ResourceId.ID_UTMR_DTMS_REPORT );
            CommandBarControl controlOpenPrimaryReportS = groupPrimaryStockReport.Add( XTPControlType.xtpControlButton, ResourceId.ID_REPORT_UTMR, "显示UTMR报表(&S)", false, false );
            CommandBarControl controlOpenPrimaryReportD = groupPrimaryStockReport.Add( XTPControlType.xtpControlButton, ResourceId.ID_REPORT_DTMS, "显示DTMS报表(&M)", false, false );

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

            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_APP_HIDE, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_CONFIG_UTMR_DTMS, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_BUILD_UTMR_DTMS, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_REPORT_UTMR, XTPImageState.xtpImageNormal );
            axCommandBars.Icons.LoadBitmap( "Demo.Stock.Resource\\shiny-gear.png", ResourceId.ID_REPORT_DTMS, XTPImageState.xtpImageNormal );

            axCommandBars.ToolTipContext.Style = XTPToolTipStyle.xtpToolTipOffice2007;
            axCommandBars.ToolTipContext.ShowTitleAndDescription( true, XTPToolTipIcon.xtpToolTipIconNone );
            axCommandBars.ToolTipContext.SetMargin( 2, 2, 2, 2 );
            axCommandBars.ToolTipContext.MaxTipWidth = 180;
        }

        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case (int)XtremeCommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCUSTOMIZE:
                    axCommandBars.ShowCustomizeDialog( 3 );

                    break;
                case ResourceId.ID_CONFIG_UTMR_DTMS:

                    m_UTMR_DTMS_OptionForm.Show( this );

                    break;
                case ResourceId.ID_BUILD_UTMR_DTMS:


                    break;
                case ResourceId.ID_REPORT_UTMR:


                    break;
                case ResourceId.ID_REPORT_DTMS:


                    break;
                case ResourceId.ID_SHOW_STATUS:

                    axCommandBars.StatusBar.Visible = !axCommandBars.StatusBar.Visible;

                    break;
                case ResourceId.ID_SHOW_WORKSPACE:

                    eventArgs.control.Checked = !eventArgs.control.Checked;
                    axCommandBars.ShowTabWorkspace( eventArgs.control.Checked );

                    break;
                case ResourceId.ID_APP_HIDE:


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
        private void UTMR_DTMS_MainFrom_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( m_isClose == false )
            {
                m_UTMR_DTMS_OptionForm.IsClose = true;

                m_isClose = true;
                this.Close();
            }
        }
    }
}
