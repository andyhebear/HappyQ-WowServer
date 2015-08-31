#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Threading;
using System.Windows.Forms;
#endregion

namespace Demo.Stock.X
{
    internal static class Program
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
        private static void Main()
        {
            bool bCreatedNew = false;
            Mutex mutex = new Mutex( true, "Demo.Stock.X", out bCreatedNew );
            if ( bCreatedNew == false )
            {
                MessageBox.Show( "Demo.Stock.X程序已经运行了！", "Demo.Stock.X" );
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

#region zh-CHS 包含名字空间 | en Include namespace
#endregion



#region zh-CHS 私有常量 | en Private Constants
#endregion

#region zh-CHS 内部常量 | en Internal Constants
#endregion

#region zh-CHS 保护常量 | en Protected Constants
#endregion

#region zh-CHS 内部保护常量 | en Protected Internal Constants
#endregion

#region zh-CHS 共有常量 | en Public Constants
#endregion



#region zh-CHS 私有成员变量 | en Private Member Variables
#endregion

#region zh-CHS 内部成员变量 | en Internal Member Variables
#endregion

#region zh-CHS 保护成员变量 | en Protected Member Variables
#endregion

#region zh-CHS 内部保护成员变量 | en Protected Internal Member Variables
#endregion

#region zh-CHS 共有成员变量 | en Public Member Variables
#endregion



#region zh-CHS 私有静态成员变量 | en Private Static Member Variables
#endregion

#region zh-CHS 内部静态成员变量 | en Internal Static Member Variables
#endregion

#region zh-CHS 保护静态成员变量 | en Protected Static Member Variables
#endregion

#region zh-CHS 内部保护静态成员变量 | en Protected Internal Static Member Variables
#endregion

#region zh-CHS 共有静态成员变量 | en Public Static Member Variables
#endregion



#region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
#endregion



#region zh-CHS 私有属性 | en Private Properties
#endregion

#region zh-CHS 内部属性 | en Internal Properties
#endregion

#region zh-CHS 保护属性 | en Protected Properties
#endregion

#region zh-CHS 内部保护属性 | en Protected Internal Properties
#endregion

#region zh-CHS 共有属性 | en Public Properties
#endregion



#region zh-CHS 属性覆盖 | en Override Properties
#endregion


#region zh-CHS 属性重写 | en New Properties
#endregion



#region zh-CHS 私有静态属性 | en Private Static Properties
#endregion

#region zh-CHS 内部静态属性 | en Internal Static Properties
#endregion

#region zh-CHS 保护静态属性 | en Protected Static Properties
#endregion

#region zh-CHS 内部保护静态属性 | en Protected Internal Static Properties
#endregion

#region zh-CHS 共有静态属性 | en Public Static Properties
#endregion



#region zh-CHS 私有方法 | en Private Methods
#endregion

#region zh-CHS 内部方法 | en Internal Methods
#endregion

#region zh-CHS 保护方法 | en Protected Methods
#endregion

#region zh-CHS 内部保护方法 | en Protected Internal Methods
#endregion

#region zh-CHS 共有方法 | en Public Methods
#endregion



#region zh-CHS 抽象方法 | en Abstract Methods
#endregion


#region zh-CHS 方法覆盖 | en Override Methods
#endregion


#region zh-CHS 方法重写 | en New Methods
#endregion



#region zh-CHS 私有静态方法 | en Private Static Methods
#endregion

#region zh-CHS 内部静态方法 | en Internal Static Methods
#endregion

#region zh-CHS 保护静态方法 | en Protected Static Methods
#endregion

#region zh-CHS 内部保护静态方法 | en Protected Internal Static Methods
#endregion

#region zh-CHS 共有静态方法 | en Public Static Methods
#endregion



#region zh-CHS 私有事件 | en Private Event
#endregion

#region zh-CHS 内部事件 | en Internal Event
#endregion

#region zh-CHS 保护事件 | en Protected Event
#endregion

#region zh-CHS 内部保护事件 | en Protected Internal Event
#endregion

#region zh-CHS 共有事件 | en Public Event
#endregion



#region zh-CHS 私有静态事件 | en Private Static Event
#endregion

#region zh-CHS 内部静态事件 | en Internal Static Event
#endregion

#region zh-CHS 保护静态事件 | en Protected Static Event
#endregion

#region zh-CHS 内部保护静态事件 | en Protected Internal Static Event
#endregion

#region zh-CHS 共有静态事件 | en Public Static Event
#endregion



#region zh-CHS 私有的事件处理函数 | en Private Event Handlers
#endregion

#region zh-CHS 内部的事件处理函数 | en Internal Event Handlers
#endregion

#region zh-CHS 保护的事件处理函数 | en Protected Event Handlers
#endregion

#region zh-CHS 内部保护的事件处理函数 | en Protected Internal Event Handlers
#endregion

#region zh-CHS 共有的事件处理函数 | en Public Event Handlers
#endregion



#region zh-CHS 私有的事件数据类 | en Private EventArgs Class
#endregion

#region zh-CHS 内部的事件数据类 | en Internal EventArgs Class
#endregion

#region zh-CHS 保护的事件数据类 | en Protected EventArgs Class
#endregion

#region zh-CHS 内部保护的事件数据类 | en Protected Internal EventArgs Class
#endregion

#region zh-CHS 共有的事件数据类 | en Public EventArgs Class
#endregion



#region zh-CHS 私有委托 | en Private Delegate
#endregion

#region zh-CHS 内部委托 | en Internal Delegate
#endregion

#region zh-CHS 保护委托 | en Protected Delegate
#endregion

#region zh-CHS 内部保护委托 | en Protected Internal Delegate
#endregion

#region zh-CHS 共有委托 | en Public Delegate
#endregion



#region zh-CHS 接口 | en Interface
#endregion



#region zh-CHS 接口实现 | en Interface Implementation
#endregion



#region zh-CHS 枚举 | en Enum
#endregion



#region zh-CHS 私有的结构 | en Private Struct
#endregion

#region zh-CHS 内部的结构 | en Internal Struct
#endregion

#region zh-CHS 保护的结构 | en Protected Struct
#endregion

#region zh-CHS 内部保护的结构 | en Protected Internal Struct
#endregion

#region zh-CHS 共有的结构 | en Public Struct
#endregion



#region zh-CHS 私有的类 | en Private Class
#endregion

#region zh-CHS 内部的类 | en Internal Class
#endregion

#region zh-CHS 保护的类 | en Protected Class
#endregion

#region zh-CHS 内部保护的类 | en Protected Internal Class
#endregion

#region zh-CHS 共有的类 | en Public Class
#endregion



#region zh-CHS 引入DLL接口 | en DLL Import
#endregion