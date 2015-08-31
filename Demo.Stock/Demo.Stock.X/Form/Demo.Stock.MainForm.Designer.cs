namespace Demo.Stock.X
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
            this.m_NotifyIcon = new System.Windows.Forms.NotifyIcon( this.components );
            this.m_AxPopupControl = new AxXtremeSuiteControls.AxPopupControl();
            this.m_AxCommandBars = new AxXtremeCommandBars.AxCommandBars();
            this.m_AxPopupControlMessage = new AxXtremeSuiteControls.AxPopupControl();
            this.m_PopupMessageTimer = new System.Windows.Forms.Timer( this.components );
            ( (System.ComponentModel.ISupportInitialize)( this.m_AxPopupControl ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.m_AxCommandBars ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.m_AxPopupControlMessage ) ).BeginInit();
            this.SuspendLayout();
            // 
            // m_NotifyIcon
            // 
            this.m_NotifyIcon.BalloonTipText = "程序已经完成启动！右键单击开始。。。";
            this.m_NotifyIcon.BalloonTipTitle = "Demo.Stock.X";
            this.m_NotifyIcon.Icon = ( (System.Drawing.Icon)( resources.GetObject( "m_NotifyIcon.Icon" ) ) );
            this.m_NotifyIcon.Text = "Demo.Stock.X";
            this.m_NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler( this.NotifyIcon_MouseClick );
            // 
            // m_AxPopupControl
            // 
            this.m_AxPopupControl.Enabled = true;
            this.m_AxPopupControl.Location = new System.Drawing.Point( 0, 1 );
            this.m_AxPopupControl.Name = "m_AxPopupControl";
            this.m_AxPopupControl.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "m_AxPopupControl.OcxState" ) ) );
            this.m_AxPopupControl.Size = new System.Drawing.Size( 24, 24 );
            this.m_AxPopupControl.TabIndex = 1;
            this.m_AxPopupControl.ItemClick += new AxXtremeSuiteControls._DPopupControlEvents_ItemClickEventHandler( this.axPopupControl_ItemClick );
            // 
            // m_AxCommandBars
            // 
            this.m_AxCommandBars.Enabled = true;
            this.m_AxCommandBars.Location = new System.Drawing.Point( 30, 1 );
            this.m_AxCommandBars.Name = "m_AxCommandBars";
            this.m_AxCommandBars.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "m_AxCommandBars.OcxState" ) ) );
            this.m_AxCommandBars.Size = new System.Drawing.Size( 24, 24 );
            this.m_AxCommandBars.TabIndex = 2;
            // 
            // m_AxPopupControlMessage
            // 
            this.m_AxPopupControlMessage.Enabled = true;
            this.m_AxPopupControlMessage.Location = new System.Drawing.Point( 60, 0 );
            this.m_AxPopupControlMessage.Name = "m_AxPopupControlMessage";
            this.m_AxPopupControlMessage.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "m_AxPopupControlMessage.OcxState" ) ) );
            this.m_AxPopupControlMessage.Size = new System.Drawing.Size( 24, 24 );
            this.m_AxPopupControlMessage.TabIndex = 3;
            this.m_AxPopupControlMessage.ItemClick += new AxXtremeSuiteControls._DPopupControlEvents_ItemClickEventHandler( this.axPopupControlMessage_ItemClick );
            // 
            // m_PopupMessageTimer
            // 
            this.m_PopupMessageTimer.Interval = 10000;
            this.m_PopupMessageTimer.Tick += new System.EventHandler( this.PopupMessageTimer_Tick );
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 300, 26 );
            this.Controls.Add( this.m_AxPopupControlMessage );
            this.Controls.Add( this.m_AxPopupControl );
            this.Controls.Add( this.m_AxCommandBars );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo.Stock.Form";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler( this.MainForm_Load );
            this.Shown += new System.EventHandler( this.MainForm_Shown );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.MainForm_FormClosing );
            ( (System.ComponentModel.ISupportInitialize)( this.m_AxPopupControl ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.m_AxCommandBars ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.m_AxPopupControlMessage ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.NotifyIcon m_NotifyIcon;
        private AxXtremeSuiteControls.AxPopupControl m_AxPopupControl;
        private AxXtremeCommandBars.AxCommandBars m_AxCommandBars;
        private AxXtremeSuiteControls.AxPopupControl m_AxPopupControlMessage;
        private System.Windows.Forms.Timer m_PopupMessageTimer;

    }
}

