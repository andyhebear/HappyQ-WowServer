#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AxXtremeCommandBars;
using AxXtremeSkinFramework;
using Demo.Stock.X.Common;
using Demo.Stock.X.D50;
using Demo.Stock.X.RealD50;
using Demo.Stock.X.RealU50;
using Demo.Stock.X.U50;
using Demo.Stock.X.Util;
using XtremeSuiteControls;
#endregion

namespace Demo.Stock.X
{
    public partial class MainForm : Form
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        private PopupControlItem m_PopupControlItemU50 = null;
        private PopupControlItem m_PopupControlItemD50 = null;
        private PopupControlItem m_PopupControlItem03 = null;
        private PopupControlItem m_PopupControlItem04 = null;
        private PopupControlItem m_PopupControlItem05 = null;
        private PopupControlItem m_PopupControlItem06 = null;
        private PopupControlItem m_PopupControlItem07 = null;
        private PopupControlItem m_PopupControlItem08 = null;

        private PopupControlItem m_PopupControlItemFlag01 = null;
        private PopupControlItem m_PopupControlItemFlag02 = null;
        private PopupControlItem m_PopupControlItemFlag03 = null;
        private PopupControlItem m_PopupControlItemFlag04 = null;
        private PopupControlItem m_PopupControlItemFlag05 = null;
        private PopupControlItem m_PopupControlItemFlag06 = null;
        private PopupControlItem m_PopupControlItemFlag07 = null;
        private PopupControlItem m_PopupControlItemFlag08 = null;

        private PopupControlItem m_PopupControlItemOpenAll = null;
        private PopupControlItem m_PopupControlItemCloseAll = null;

        private PopupControlItem m_PopupControlItemOption = null;
        private PopupControlItem m_PopupControlItemTools = null;
        private PopupControlItem m_PopupControlItemExit = null;

        private PopupControlItem m_PopupControlMessageItemMessage = null;
        private PopupControlItem m_PopupControlMessageItemMessage2 = null;
        private PopupControlItem m_PopupControlMessageItemMessage3 = null;
        private PopupControlItem m_PopupControlMessageItemClose = null;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        public MainForm()
        {
            s_StartForm = this;

            ( (System.ComponentModel.ISupportInitialize)( this.axSkinFramework ) ).BeginInit();
            this.Controls.Add( this.axSkinFramework );
            ( (System.ComponentModel.ISupportInitialize)( this.axSkinFramework ) ).EndInit();
            this.axSkinFramework.LoadSkin( "Demo.Stock.Styles\\Office2007.cjstyles", string.Empty );

            InitializeComponent();
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        private AxSkinFramework axSkinFramework = new AxSkinFramework();
        public AxSkinFramework AxSkinFramework
        {
            get { return axSkinFramework; }
        }

        public AxCommandBars AxCommandBars
        {
            get { return m_AxCommandBars; }
        }

        private OptionForm m_OptionForm = new OptionForm();
        public OptionForm OptionForm
        {
            get { return m_OptionForm; }
        }

        private ToolsForm m_ToolsForm = new ToolsForm();
        public ToolsForm ToolsForm
        {
            get { return m_ToolsForm; }
        }

        private U50Form m_U50Form = new U50Form();
        public U50Form U50Form
        {
            get { return m_U50Form; }
        }

        private D50Form m_D50Form = new D50Form();
        public D50Form D50Form
        {
            get { return m_D50Form; }
        }

        private RealD50Form m_RealD50Form = new RealD50Form();
        public RealD50Form RealD50Form
        {
            get { return m_RealD50Form; }
        }

        private RealU50Form m_RealU50Form = new RealU50Form();
        public RealU50Form RealU50Form
        {
            get { return m_RealU50Form; }
        }
        #endregion

        #region zh-CHS 共有静态属性 | en Public Static Properties
        private static MainForm s_StartForm = null;
        public static MainForm Instance
        {
            get { return s_StartForm; }
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        protected override void OnVisibleChanged( EventArgs eventArgs )
        {
            base.OnVisibleChanged( eventArgs );

            if ( this.Visible == true )
            {
                this.axSkinFramework.ApplyWindow( this.Handle.ToInt32() );
                this.BackColor = this.axSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            }
        }
        #endregion

        private void MainForm_Shown( object sender, EventArgs eventArgs )
        {
            if ( this.Visible == true )
                this.Hide(); // 不显示主窗口
        }

        #region zh-CHS 私有方法 | en Private Methods
        private void InitPopupControl()
        {
            this.m_AxPopupControl.SetSize( 200, 300 );
            this.m_AxPopupControl.Transparency = 200;
            this.m_AxPopupControl.VisualTheme = XTPPopupPaintTheme.xtpPopupThemeOffice2007;

            PopupControlItem Item = null;

            // m_PopupControlItem01
            m_PopupControlItemU50 = this.m_AxPopupControl.AddItem( 10, 20, 120, 40, "...U50形态...", -1, -1 );
            m_PopupControlItemU50.Button = true;
            m_PopupControlItemU50.HyperLink = false;
            m_PopupControlItemU50.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemFlag01
            m_PopupControlItemFlag01 = this.m_AxPopupControl.AddItem( 122, 22, 140, 40, "", -1, -1 );

            Item = this.m_AxPopupControl.AddItem( 10, 40, 140, 50, "--------------------------------------", -1, -1 );
            Item.HyperLink = false;
            Item.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItem02
            m_PopupControlItemD50 = this.m_AxPopupControl.AddItem( 10, 50, 120, 70, "...D50形态...", -1, -1 );
            m_PopupControlItemD50.Button = true;
            m_PopupControlItemD50.HyperLink = false;
            m_PopupControlItemD50.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemFlag02
            m_PopupControlItemFlag02 = this.m_AxPopupControl.AddItem( 122, 52, 140, 70, "", -1, -1 );

            Item = this.m_AxPopupControl.AddItem( 10, 70, 140, 80, "--------------------------------------", -1, -1 );
            Item.HyperLink = false;
            Item.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItem03
            m_PopupControlItem03 = this.m_AxPopupControl.AddItem( 10, 80, 120, 100, ".实时U50形态.", -1, -1 );
            m_PopupControlItem03.Button = true;
            m_PopupControlItem03.HyperLink = false;
            m_PopupControlItem03.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemFlag03
            m_PopupControlItemFlag03 = this.m_AxPopupControl.AddItem( 122, 82, 140, 100, "", -1, -1 );

            Item = this.m_AxPopupControl.AddItem( 10, 100, 140, 110, "--------------------------------------", -1, -1 );
            Item.HyperLink = false;
            Item.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItem04
            m_PopupControlItem04 = this.m_AxPopupControl.AddItem( 10, 110, 120, 130, ".实时D50形态.", -1, -1 );
            m_PopupControlItem04.Button = true;
            m_PopupControlItem04.HyperLink = false;
            m_PopupControlItem04.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemFlag04
            m_PopupControlItemFlag04 = this.m_AxPopupControl.AddItem( 122, 112, 140, 130, "", -1, -1 );

            Item = this.m_AxPopupControl.AddItem( 10, 130, 140, 140, "--------------------------------------", -1, -1 );
            Item.HyperLink = false;
            Item.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItem05
            m_PopupControlItem05 = this.m_AxPopupControl.AddItem( 10, 140, 120, 160, "...xxx形态...", -1, -1 );
            m_PopupControlItem05.Button = true;
            m_PopupControlItem05.HyperLink = false;
            m_PopupControlItem05.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemFlag05
            m_PopupControlItemFlag05 = this.m_AxPopupControl.AddItem( 122, 142, 140, 160, "", -1, -1 );

            Item = this.m_AxPopupControl.AddItem( 10, 160, 140, 170, "--------------------------------------", -1, -1 );
            Item.HyperLink = false;
            Item.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItem06
            m_PopupControlItem06 = this.m_AxPopupControl.AddItem( 10, 170, 120, 190, "...xxx形态...", -1, -1 );
            m_PopupControlItem06.Button = true;
            m_PopupControlItem06.HyperLink = false;
            m_PopupControlItem06.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemFlag06
            m_PopupControlItemFlag06 = this.m_AxPopupControl.AddItem( 122, 172, 140, 190, "", -1, -1 );

            Item = this.m_AxPopupControl.AddItem( 10, 190, 140, 200, "--------------------------------------", -1, -1 );
            Item.HyperLink = false;
            Item.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItem07
            m_PopupControlItem07 = this.m_AxPopupControl.AddItem( 10, 200, 120, 220, "...xxx形态...", -1, -1 );
            m_PopupControlItem07.Button = true;
            m_PopupControlItem07.HyperLink = false;
            m_PopupControlItem07.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemFlag07
            m_PopupControlItemFlag07 = this.m_AxPopupControl.AddItem( 122, 202, 140, 220, "", -1, -1 );

            Item = this.m_AxPopupControl.AddItem( 10, 220, 140, 230, "--------------------------------------", -1, -1 );
            Item.HyperLink = false;
            Item.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItem08
            m_PopupControlItem08 = this.m_AxPopupControl.AddItem( 10, 230, 120, 250, "...xxx形态...", -1, -1 );
            m_PopupControlItem08.Button = true;
            m_PopupControlItem08.HyperLink = false;
            m_PopupControlItem08.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemFlag08
            m_PopupControlItemFlag08 = this.m_AxPopupControl.AddItem( 122, 232, 140, 250, "", -1, -1 );

            Item = this.m_AxPopupControl.AddItem( 0, 250, 300, 260, "----------------------------------------------------------", -1, -1 );
            Item.HyperLink = false;
            Item.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemOpenAll
            m_PopupControlItemOpenAll = this.m_AxPopupControl.AddItem( 10, 260, 100, 280, "打开全部形态", -1, -1 );
            m_PopupControlItemOpenAll.Button = true;
            m_PopupControlItemOpenAll.HyperLink = false;
            m_PopupControlItemOpenAll.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemCloseAll
            m_PopupControlItemCloseAll = this.m_AxPopupControl.AddItem( 100, 260, 190, 280, "关闭全部形态", -1, -1 );
            m_PopupControlItemCloseAll.Button = true;
            m_PopupControlItemCloseAll.HyperLink = false;
            m_PopupControlItemCloseAll.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemOption
            m_PopupControlItemOption = this.m_AxPopupControl.AddItem( 160, 10, 190, 30, "选项", -1, -1 );
            m_PopupControlItemOption.Bold = true;
            m_PopupControlItemOption.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemTools
            m_PopupControlItemTools = this.m_AxPopupControl.AddItem( 160, 30, 190, 50, "工具", -1, -1 );
            m_PopupControlItemTools.Bold = true;
            m_PopupControlItemTools.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            // m_PopupControlItemTools
            m_PopupControlItemExit = this.m_AxPopupControl.AddItem( 160, 230, 190, 250, "退出", -1, -1 );
            m_PopupControlItemExit.Bold = true;
            m_PopupControlItemExit.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER | XTPItemAlignment.DT_SINGLELINE;

            this.CheckPopupControl();
        }

        private void CheckPopupControl()
        {
            if ( m_U50Form.Visible == true )
                m_PopupControlItemFlag01.SetIcon( DrawingEx.SetIcon( "Demo.Stock.Resource\\flag.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );
            else
                m_PopupControlItemFlag01.SetIcon( DrawingEx.SetIcon( "Demo.Stock.Resource\\flag2.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );

            if ( m_D50Form.Visible == true )
                m_PopupControlItemFlag02.SetIcon( DrawingEx.SetIcon( "Demo.Stock.Resource\\flag.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );
            else
                m_PopupControlItemFlag02.SetIcon( DrawingEx.SetIcon( "Demo.Stock.Resource\\flag2.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );

            if ( m_RealU50Form.Visible == true )
                m_PopupControlItemFlag03.SetIcon( DrawingEx.SetIcon( "Demo.Stock.Resource\\flag.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );
            else
                m_PopupControlItemFlag03.SetIcon( DrawingEx.SetIcon( "Demo.Stock.Resource\\flag2.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );

            if ( m_RealD50Form.Visible == true )
                m_PopupControlItemFlag04.SetIcon( DrawingEx.SetIcon( "Demo.Stock.Resource\\flag.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );
            else
                m_PopupControlItemFlag04.SetIcon( DrawingEx.SetIcon( "Demo.Stock.Resource\\flag2.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );

            //if ( m_U50Form.IsShowOpen == true )
            //    m_PopupControlItemFlag05.SetIcon( SetIcon( "Demo.Stock.Resource\\flag.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );
            //else
            //    m_PopupControlItemFlag05.SetIcon( SetIcon( "Demo.Stock.Resource\\flag2.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );

            //if ( m_U50Form.IsShowOpen == true )
            //    m_PopupControlItemFlag06.SetIcon( SetIcon( "Demo.Stock.Resource\\flag.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );
            //else
            //    m_PopupControlItemFlag06.SetIcon( SetIcon( "Demo.Stock.Resource\\flag2.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );

            //if ( m_U50Form.IsShowOpen == true )
            //    m_PopupControlItemFlag07.SetIcon( SetIcon( "Demo.Stock.Resource\\flag.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );
            //else
            //    m_PopupControlItemFlag07.SetIcon( SetIcon( "Demo.Stock.Resource\\flag2.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );

            //if ( m_U50Form.IsShowOpen == true )
            //    m_PopupControlItemFlag08.SetIcon( SetIcon( "Demo.Stock.Resource\\flag.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );
            //else
            //    m_PopupControlItemFlag08.SetIcon( SetIcon( "Demo.Stock.Resource\\flag2.ico" ), XTPPopupItemIcon.xtpPopupItemIconNormal );
        }
        #endregion
        private void MainForm_Load( object sender, EventArgs eventArgs )
        {
            this.Left = ( Screen.PrimaryScreen.Bounds.Width - this.Width ) / 2;
            this.Top = ( Screen.PrimaryScreen.Bounds.Height - this.Height ) / 2;

            this.m_AxCommandBars.ActiveMenuBar.Visible = false;

            MSFL.MSFL1_Initialize( "MSFL Main Form", "H.Q.Cai", MSFL.MSFL_DLL_INTERFACE_VERSION );

            this.InitPopupControl();
            this.InitPopupMessageControl();

            ProcessForm.StartProcessForm( Process_Initialize );
        }

        private void Process_Initialize( ProcessForm processForm )
        {
            GlobalSetting.LoadGlobalRegistry();

            if ( GlobalSetting.IsAutoLoadConfigSetting == true )
            {
                if ( GlobalSetting.LoadGlobalSetting() == false )
                    MainForm.ShowPopupMessage( "读取配置文件失败！", "可能文件不存在或格式错误。。。", "请点击<主选项>的<设置配置文件>" );
            }

            this.m_OptionForm.Initialize();
            this.m_U50Form.Initialize();
            this.m_D50Form.Initialize();

            this.m_NotifyIcon.Visible = true;
            if ( GlobalSetting.IsPopStartupInfo == true )
                this.m_NotifyIcon.ShowBalloonTip( 1000 );

            processForm.EndProcessForm();
        }

        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            MSFL.MSFL1_Shutdown();
        }

        private void NotifyIcon_MouseClick( object sender, MouseEventArgs eventArgs )
        {
            if ( eventArgs.Button == MouseButtons.Right )
            {
                this.CheckPopupControl();
                this.m_AxPopupControl.Close();
                this.m_AxPopupControl.Show();
            }
            else
                this.m_AxPopupControl.Close();
        }

        private void axPopupControl_ItemClick( object sender, AxXtremeSuiteControls._DPopupControlEvents_ItemClickEvent eventArgs )
        {
            if ( eventArgs.item == m_PopupControlItemU50 )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                if ( m_U50Form.Visible == true )
                    m_U50Form.Activate();
                else
                    m_U50Form.Show();
            }
            else if ( eventArgs.item == m_PopupControlItemD50 )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                if ( m_D50Form.Visible == true )
                    m_D50Form.Activate();
                else
                    m_D50Form.Show();
            }
            else if ( eventArgs.item == m_PopupControlItem03 )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                if ( m_RealU50Form.Visible == true )
                    m_RealU50Form.Activate();
                else
                    m_RealU50Form.Show();
            }
            else if ( eventArgs.item == m_PopupControlItem04 )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                if ( m_RealD50Form.Visible == true )
                    m_RealD50Form.Activate();
                else
                    m_RealD50Form.Show();
            }
            else if ( eventArgs.item == m_PopupControlItem05 )
            {
                //AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                //if ( popupControl != null )
                //    popupControl.Close();

            }
            else if ( eventArgs.item == m_PopupControlItem06 )
            {
                //AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                //if ( popupControl != null )
                //    popupControl.Close();

            }
            else if ( eventArgs.item == m_PopupControlItem07 )
            {
                //AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                //if ( popupControl != null )
                //    popupControl.Close();

            }
            else if ( eventArgs.item == m_PopupControlItem08 )
            {
                //AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                //if ( popupControl != null )
                //    popupControl.Close();

            }
            else if ( eventArgs.item == m_PopupControlItemOpenAll )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                if ( m_U50Form.Visible == true )
                    m_U50Form.Activate();
                else
                    m_U50Form.Show();

                if ( m_D50Form.Visible == true )
                    m_D50Form.Activate();
                else
                    m_D50Form.Show();

                if ( m_RealU50Form.Visible == true )
                    m_RealU50Form.Activate();
                else
                    m_RealU50Form.Show();

                if ( m_RealD50Form.Visible == true )
                    m_RealD50Form.Activate();
                else
                    m_RealD50Form.Show();
            }
            else if ( eventArgs.item == m_PopupControlItemCloseAll )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                m_U50Form.Close();
                m_D50Form.Close();
                m_RealU50Form.Close();
                m_RealD50Form.Close();
            }
            else if ( eventArgs.item == m_PopupControlItemOption )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                if ( m_OptionForm.Visible == true )
                    m_OptionForm.Activate();
                else
                    m_OptionForm.ShowDialog();
            }
            else if ( eventArgs.item == m_PopupControlItemTools )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                if ( m_ToolsForm.Visible == true )
                    m_ToolsForm.Activate();
                else
                    m_ToolsForm.ShowDialog();
            }
            else if ( eventArgs.item == m_PopupControlItemExit )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                m_U50Form.EndU50Form();
                m_D50Form.EndD50Form();
                m_RealU50Form.EndRealU50Form();
                m_RealD50Form.EndRealD50Form();

                this.Close();
            }
        }

        #region zh-CHS 共有静态方法 | en Public Static Methods
        #region zh-CHS 私有方法 | en Private Methods
        private Queue<PopupMessageString> m_PopupMessageQueue = new Queue<PopupMessageString>();
        private class PopupMessageString
        {
            public string Message = string.Empty;
            public string Message2 = string.Empty;
            public string Message3 = string.Empty;
        }

        private void InitPopupMessageControl()
        {
            this.m_AxPopupControlMessage.VisualTheme = XTPPopupPaintTheme.xtpPopupThemeOffice2003;
            this.m_AxPopupControlMessage.SetSize( 270, 100 );
            this.m_AxPopupControlMessage.Transparency = 200;
            this.m_AxPopupControlMessage.ShowDelay = 3000;

            m_AxPopupControlMessage.AddItem( 0, 0, 270, 100, "", Utility.HexToDecimal( "E1FFFF" ), 0 );

            m_PopupControlMessageItemMessage = m_AxPopupControlMessage.AddItem( 35, 20, 235, 40, "", -1, -1 );
            m_PopupControlMessageItemMessage.HyperLink = false;
            m_PopupControlMessageItemMessage.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER;

            m_PopupControlMessageItemMessage2 = m_AxPopupControlMessage.AddItem( 35, 40, 235, 60, "22222222", -1, -1 );
            m_PopupControlMessageItemMessage2.HyperLink = false;
            m_PopupControlMessageItemMessage2.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER;

            m_PopupControlMessageItemMessage3 = m_AxPopupControlMessage.AddItem( 35, 60, 235, 80, "3333333333333", -1, -1 );
            m_PopupControlMessageItemMessage3.HyperLink = false;
            m_PopupControlMessageItemMessage3.TextAlignment = XTPItemAlignment.DT_CENTER | XTPItemAlignment.DT_VCENTER;

            m_PopupControlMessageItemClose = m_AxPopupControlMessage.AddItem( 270 - 20, 2, 270 - 2, 2 + 18, "", -1, -1 );
            m_PopupControlMessageItemClose.SetIcons( DrawingEx.SetBitmap( "Demo.Stock.Resource\\CloseTooltip.bmp" ), 0, XTPPopupItemIcon.xtpPopupItemIconNormal | XTPPopupItemIcon.xtpPopupItemIconSelected | XTPPopupItemIcon.xtpPopupItemIconPressed );
        }

        private void axPopupControlMessage_ItemClick( object sender, AxXtremeSuiteControls._DPopupControlEvents_ItemClickEvent eventArgs )
        {
            if ( eventArgs.item == m_PopupControlMessageItemClose )
            {
                AxXtremeSuiteControls.AxPopupControl popupControl = sender as AxXtremeSuiteControls.AxPopupControl;
                if ( popupControl != null )
                    popupControl.Close();

                MainForm.Instance.m_PopupMessageTimer.Interval = 10;
            }
        }

        private void PopupMessageTimer_Tick( object sender, EventArgs e )
        {
            if ( this.m_PopupMessageQueue.Count <= 0 )
            {
                this.m_PopupMessageTimer.Enabled = false;
                return;
            }

            if ( this.m_PopupMessageTimer.Interval == 10 )
                this.m_PopupMessageTimer.Interval = this.m_AxPopupControlMessage.ShowDelay;

            this.m_AxPopupControlMessage.Close();

            PopupMessageString popupMessageString = this.m_PopupMessageQueue.Dequeue();
            this.m_PopupControlMessageItemMessage.Caption = popupMessageString.Message;
            this.m_PopupControlMessageItemMessage2.Caption = popupMessageString.Message2;
            this.m_PopupControlMessageItemMessage3.Caption = popupMessageString.Message3;
            this.m_AxPopupControlMessage.Show();
        }
        #endregion
        public static void ShowPopupMessage( string strMessage )
        {
            PopupMessageString popupMessageString = new PopupMessageString();
            popupMessageString.Message2 = strMessage;

            MainForm.Instance.m_PopupMessageQueue.Enqueue( popupMessageString );

            if ( MainForm.Instance.m_PopupMessageTimer.Enabled == false )
            {
                MainForm.Instance.m_PopupMessageTimer.Interval = 10;
                MainForm.Instance.m_PopupMessageTimer.Enabled = true;
            }
        }

        public static void ShowPopupMessage( string strMessage, string strMessage2 )
        {
            PopupMessageString popupMessageString = new PopupMessageString();
            popupMessageString.Message = strMessage;
            popupMessageString.Message3 = strMessage2;

            MainForm.Instance.m_PopupMessageQueue.Enqueue( popupMessageString );

            if ( MainForm.Instance.m_PopupMessageTimer.Enabled == false )
            {
                MainForm.Instance.m_PopupMessageTimer.Interval = 10;
                MainForm.Instance.m_PopupMessageTimer.Enabled = true;
            }
        }
        
        public static void ShowPopupMessage( string strMessage, string strMessage2, string strMessage3 )
        {
            PopupMessageString popupMessageString = new PopupMessageString();
            popupMessageString.Message = strMessage;
            popupMessageString.Message2 = strMessage2;
            popupMessageString.Message3 = strMessage3;

            MainForm.Instance.m_PopupMessageQueue.Enqueue( popupMessageString );

            if ( MainForm.Instance.m_PopupMessageTimer.Enabled == false )
            {
                MainForm.Instance.m_PopupMessageTimer.Interval = 10;
                MainForm.Instance.m_PopupMessageTimer.Enabled = true;
            }
        }
        #endregion
    }
}
