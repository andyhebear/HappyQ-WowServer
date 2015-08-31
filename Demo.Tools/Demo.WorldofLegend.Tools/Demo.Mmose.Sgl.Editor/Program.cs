using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Demo.Mmose.Gui.CommandBars;
using Demo.Mmose.Gui.PropertyGrid;
using Demo.Mmose.Gui.TaskPanel;
using Demo.Mmose.Gui.Controls;

namespace Demo.GOSE.SGL.Editor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CommandBarsGlobalSettings commandBarsGlobalSettings = new CommandBarsGlobalSettings();
            commandBarsGlobalSettings.License = "CommandBars Control Copyright (c) 2003-2007 Codejock Software\r\nPRODUCT-ID: Codejock.CommandBars.ActiveX.v11.2\r\nVALIDATE-CODE: QQS-PNF-OJV-VBX";

            PropertyGridGlobalSettings propertyGridGlobalSettings = new PropertyGridGlobalSettings();
            propertyGridGlobalSettings.License = "Property Grid Control Copyright (c) 2003-2007 Codejock Software\r\nPRODUCT-ID: Codejock.PropertyGrid.ActiveX.v11.2\r\nVALIDATE-CODE: HVN-LFW-DIX-XRR";

            TaskPanelGlobalSettings taskPanelGlobalSettings = new TaskPanelGlobalSettings();
            taskPanelGlobalSettings.License = "TaskPanel Control Copyright (c) 2003-2007 Codejock Software\r\nPRODUCT-ID: Codejock.TaskPanel.ActiveX.v11.2\r\nVALIDATE-CODE: DJN-TXA-SGX-EFY";

            SuiteControlsGlobalSettings suiteControlsGlobalSettings = new SuiteControlsGlobalSettings();
            suiteControlsGlobalSettings.License = "Suite Controls Copyright (c) 2003-2007 Codejock Software\r\nPRODUCT-ID: Codejock.Controls.ActiveX.v11.2\r\nVALIDATE-CODE: NSR-VTA-EXQ-TPT";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new SGLEditorForm() );
        }
    }
}