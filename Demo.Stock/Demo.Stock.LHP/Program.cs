using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Demo.Stock.LHP.Main;

namespace Demo.Stock.LHP
{
    static class Program
    {
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static XtremeCalendarControl.CalendarGlobalSettings s_CalendarGlobalSettings = new XtremeCalendarControl.CalendarGlobalSettings();
        private static XtremeCommandBars.CommandBarsGlobalSettings s_CommandBarsGlobalSettings = new XtremeCommandBars.CommandBarsGlobalSettings();
        private static XtremeSuiteControls.SuiteControlsGlobalSettings s_SuiteControlsGlobalSettings = new XtremeSuiteControls.SuiteControlsGlobalSettings();
        private static XtremeDockingPane.DockingPaneGlobalSettings s_DockingPaneGlobalSettings = new XtremeDockingPane.DockingPaneGlobalSettings();
        private static XtremeShortcutBar.ShortcutBarGlobalSettings s_ShortcutBarGlobalSettings = new XtremeShortcutBar.ShortcutBarGlobalSettings();
        private static XtremeSkinFramework.SkinFrameworkGlobalSettings s_SkinFrameworkGlobalSettings = new XtremeSkinFramework.SkinFrameworkGlobalSettings();
        private static XtremeTaskPanel.TaskPanelGlobalSettings s_TaskPanelGlobalSettings = new XtremeTaskPanel.TaskPanelGlobalSettings();
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bCreatedNew = false;
            Mutex mutex = new Mutex( true, "Demo.Stock.LHP", out bCreatedNew );
            if ( bCreatedNew == false )
            {
                MessageBox.Show( "Demo.Stock.LHP程序已经运行了！", "Demo.Stock.LHP" );
                return;
            }

            s_CalendarGlobalSettings.License =
                "Calendar Control Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
                "PRODUCT-ID: Codejock.Calendar.ActiveX.v12.1" + "\r\n" +
                "VALIDATE-CODE: WAD-FOY-VBC-AED";

            s_CommandBarsGlobalSettings.License =
                "CommandBars Control Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
                "PRODUCT-ID: Codejock.CommandBars.ActiveX.v12.1" + "\r\n" +
                "VALIDATE-CODE: QQS-PNF-OJV-VBX";

            s_SuiteControlsGlobalSettings.License =
                "Suite Controls Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
                "PRODUCT-ID: Codejock.Controls.ActiveX.v12.1" + "\r\n" +
                "VALIDATE-CODE: NSR-VTA-EXQ-TPT";

            s_DockingPaneGlobalSettings.License =
                "Docking Panes Control Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
                "PRODUCT-ID: Codejock.DockingPane.ActiveX.v12.1" + "\r\n" +
                "VALIDATE-CODE: UCY-KMS-CII-OCF";

            //m_PropertyGridGlobalSettings.License =
            //    "Property Grid Control Control Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
            //    "PRODUCT-ID: Codejock.PropertyGrid.ActiveX.v12.1" + "\r\n" +
            //    "VALIDATE-CODE: HVN-LFW-DIX-XRR";

            //m_ReportControlGlobalSettings.License =
            //    "Report Control Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
            //    "PRODUCT-ID: Codejock.ReportControl.ActiveX.v12.1" + "\r\n" +
            //    "VALIDATE-CODE: HIF-MPA-DRR-OPF";

            s_ShortcutBarGlobalSettings.License =
                "ShortcutBar Control Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
                "PRODUCT-ID: Codejock.ShortcutBar.ActiveX.v12.1" + "\r\n" +
                "VALIDATE-CODE: REV-QAQ-QMJ-ETA";

            s_SkinFrameworkGlobalSettings.License =
                "Skin Framework Control Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
                "PRODUCT-ID: Codejock.SkinFramework.ActiveX.v12.1" + "\r\n" +
                "VALIDATE-CODE: GGE-OLD-QQR-EJS";

            //s_SyntaxEditGlobalSettings.License =
            //    "Syntax Edit Control Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
            //    "PRODUCT-ID: Codejock.SyntaxEdit.ActiveX.v12.1" + "\r\n" +
            //    "VALIDATE-CODE: DPV-TGO-RWX-NGL";

            s_TaskPanelGlobalSettings.License =
                "TaskPanel Control Copyright (c) 2003-2008 Codejock Software" + "\r\n" +
                "PRODUCT-ID: Codejock.TaskPanel.ActiveX.v12.1" + "\r\n" +
                "VALIDATE-CODE: DJN-TXA-SGX-EFY";

            s_SuiteControlsGlobalSettings.ResourceFile = "Demo.Stock.Resource.dll";
            s_CalendarGlobalSettings.ResourceFile = "Demo.Stock.Resource.dll";
            s_CommandBarsGlobalSettings.ResourceFile = "Demo.Stock.Resource.dll";
            s_DockingPaneGlobalSettings.ResourceFile = "Demo.Stock.Resource.dll";
            s_ShortcutBarGlobalSettings.ResourceFile = "Demo.Stock.Resource.dll";
            s_TaskPanelGlobalSettings.ResourceFile = "Demo.Stock.Resource.dll";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new MainForm() );

            // keep the mutex reference alive until the normal termination of the program
            GC.KeepAlive( mutex );
        }
    }
}
