using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeCommandBars;

namespace Demo.Stock.X.D50
{
    public partial class D50Form : Form
    {
        public D50Form()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            //U50GlobalSetting.LoadGlobalRegistry();

            //if ( U50GlobalSetting.IsAutoLoadPolicySetting )
            //{
            //    if ( U50GlobalSetting.LoadConfigGlobalSetting() == false )
            //        MainForm.ShowPopupMessage( "读取策略文件失败！", "可能文件不存在或格式错误。。。", "请点击<配置策略>的<新建策略>" );
            //}

            //if ( U50GlobalSetting.IsAutoLoadTaskSetting )
            //{
            //    if ( U50GlobalSetting.LoadTaskGlobalSetting() == false )
            //        MainForm.ShowPopupMessage( "读取任务文件失败！", "可能文件不存在或格式错误。。。", "请点击<配置任务>的<新建任务>" );
            //}

            //m_ConfigForm.Initialize();
            //m_TaskForm.Initialize();
        }

        private void D50Form_Load( object sender, EventArgs eventArgs )
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


            foreach ( Control control in this.Controls )
            {
                if ( control is MdiClient )
                    axCommandBars.SetMDIClient( control.Handle.ToInt32() );
            }

            RibbonBar().EnableFrameTheme();
            axCommandBars.Options.KeyboardCuesShow = XTPKeyboardCuesShow.xtpKeyboardCuesShowWindowsDefault;

            this.axCommandBars.TabWorkspace.PaintManager.Position = XTPTabPosition.xtpTabPositionBottom;
            this.axCommandBars.ShowTabWorkspace( true );
            axCommandBars.EnableCustomization( true );
        }

        private RibbonBar RibbonBar()
        {
            return axCommandBars.ActiveMenuBar as RibbonBar;
        }

        private void CreateRibbonBar()
        {
            RibbonBar ribbonBar = axCommandBars.AddRibbonBar( "DemoSoftTeamRibbon" );
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

            CommandBarPopup controlConfig2 = (CommandBarPopup)groupFile.Add( XTPControlType.xtpControlButtonPopup, ResourceId.ID_FILE_SCAN_TASK, "扫描任务(&T)", false, false );
            controlConfig2.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_SCAN_ALL_TASK, "扫描全部(&N)", false, false );

            //int index = 1;
            //foreach ( var item in U50GlobalSetting.TaskInfos )
            //{
            //    CommandBarControl controlScanTask01 = controlConfig2.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_SCAN_TASK01 + index, string.Format( "{0}(&{1})", item.Name, index ), false, false );
            //    if ( index == 1 )
            //        controlScanTask01.BeginGroup = true;

            //    index++;
            //}


            // 开始 -> 报表
            RibbonGroup groupReport = tabHome.Groups.AddGroup( "报表(&R)", ResourceId.ID_GROUP_FILE );
            CommandBarPopup controlOpen = (CommandBarPopup)groupReport.Add( XTPControlType.xtpControlButtonPopup, ResourceId.ID_FILE_OPEN, "打开报表(&O)", false, false );
            controlOpen.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_OPEN_ALL, "打开全部(&A)", false, false );

            //int index2 = 1;
            //foreach ( var item in U50GlobalSetting.TaskInfos )
            //{
            //    CommandBarControl controlOpenPolicy01 = controlOpen.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_OPEN_POLICY01 + index2, string.Format( "打开<{0}>报表(&{1})", item.Name, index2 ), false, false );
            //    if ( index2 == 1 )
            //        controlOpenPolicy01.BeginGroup = true;

            //    index2++;
            //}

            CommandBarPopup ControlClose = (CommandBarPopup)groupReport.Add( XTPControlType.xtpControlButtonPopup, ResourceId.ID_FILE_CLOSE, "关闭报表(&C)", false, false );
            ControlClose.CommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, ResourceId.ID_FILE_CLOSE_ALL, "关闭全部(&A)", false, false );

            //int index3 = 1;
            //foreach ( var item in U50GlobalSetting.TaskInfos )
            //{
            //    CommandBarControl controlClosePolicy01 = ControlClose.CommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_FILE_CLOSE_POLICY01 + index3, string.Format( "关闭<{0}>报表(&{1})", item.Name, index3 ), false, false );
            //    if ( index3 == 1 )
            //        controlClosePolicy01.BeginGroup = true;

            //    index3++;
            //}

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



        private bool m_D50FormTrueClose = false;
        internal void EndD50Form()
        {
            this.Hide();
            this.m_D50FormTrueClose = true;
            this.Close();
            this.Dispose();
        }
        private void D50Form_FormClosing( object sender, FormClosingEventArgs eventArgs )
        {
            if ( m_D50FormTrueClose == true )
                return;

            eventArgs.Cancel = true;

            this.Hide();
        }

        private void axCommandBars_Customization( object sender, AxXtremeCommandBars._DCommandBarsEvents_CustomizationEvent eventArgs )
        {
            //eventArgs.options.ShowRibbonQuickAccessPage = true;
        }

        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case (int)XtremeCommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCUSTOMIZE:
                    axCommandBars.ShowCustomizeDialog( 3 );
                    break;
                default:
                    break;
            }
        }

        private void axCommandBars_UpdateEvent( object sender, AxXtremeCommandBars._DCommandBarsEvents_UpdateEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                default:
                    break;
            }
        }
    }
}
