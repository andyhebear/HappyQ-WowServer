namespace Demo.Stock.LHP.Main
{
    partial class HomeControlSub3
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( HomeControlSub3 ) );
            this.axReportControl = new AxXtremeReportControl.AxReportControl();
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ( (System.ComponentModel.ISupportInitialize)( this.axReportControl ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axReportControl
            // 
            this.axReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axReportControl.Location = new System.Drawing.Point( 0, 24 );
            this.axReportControl.Name = "axReportControl";
            this.axReportControl.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axReportControl.OcxState" ) ) );
            this.axReportControl.Size = new System.Drawing.Size( 728, 708 );
            this.axReportControl.TabIndex = 0;
            this.axReportControl.MouseDownEvent += new AxXtremeReportControl._DReportControlEvents_MouseDownEventHandler( this.axReportControl_MouseDownEvent );
            this.axReportControl.BeforeDrawRow += new AxXtremeReportControl._DReportControlEvents_BeforeDrawRowEventHandler( this.axReportControl_BeforeDrawRow );
            this.axReportControl.KeyDownEvent += new AxXtremeReportControl._DReportControlEvents_KeyDownEventHandler( this.axReportControl_KeyDownEvent );
            this.axReportControl.InplaceButtonDown += new AxXtremeReportControl._DReportControlEvents_InplaceButtonDownEventHandler( this.axReportControl_InplaceButtonDown );
            this.axReportControl.ValueChanged += new AxXtremeReportControl._DReportControlEvents_ValueChangedEventHandler( this.axReportControl_ValueChanged );
            this.axReportControl.PreviewKeyDownEvent += new AxXtremeReportControl._DReportControlEvents_PreviewKeyDownEventHandler( this.axReportControl_PreviewKeyDownEvent );
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 728, 24 );
            this.axShortcutCaption.TabIndex = 2;
            // 
            // HomeControlSub3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.axReportControl );
            this.Controls.Add( this.axShortcutCaption );
            this.Name = "HomeControlSub3";
            this.Size = new System.Drawing.Size( 728, 732 );
            this.Load += new System.EventHandler( this.HomeControlSub3_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axReportControl ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeReportControl.AxReportControl axReportControl;
        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
