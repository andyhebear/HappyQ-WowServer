namespace Demo.Stock.LHP.Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
            this.axCommandBars = new AxXtremeCommandBars.AxCommandBars();
            this.openFileDialogSRReport = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSRStrategy = new System.Windows.Forms.OpenFileDialog();
            ( (System.ComponentModel.ISupportInitialize)( this.axCommandBars ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axCommandBars
            // 
            this.axCommandBars.Enabled = true;
            this.axCommandBars.Location = new System.Drawing.Point( 12, 12 );
            this.axCommandBars.Name = "axCommandBars";
            this.axCommandBars.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axCommandBars.OcxState" ) ) );
            this.axCommandBars.Size = new System.Drawing.Size( 24, 24 );
            this.axCommandBars.TabIndex = 0;
            this.axCommandBars.UpdateEvent += new AxXtremeCommandBars._DCommandBarsEvents_UpdateEventHandler( this.axCommandBars_UpdateEvent );
            this.axCommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler( this.axCommandBars_Execute );
            this.axCommandBars.Customization += new AxXtremeCommandBars._DCommandBarsEvents_CustomizationEventHandler( this.axCommandBars_Customization );
            // 
            // openFileDialogSRReport
            // 
            this.openFileDialogSRReport.DefaultExt = "SRReport";
            this.openFileDialogSRReport.Filter = "SR报表 文件|*.SRReport";
            // 
            // openFileDialogSRStrategy
            // 
            this.openFileDialogSRStrategy.DefaultExt = "SRStrategy";
            this.openFileDialogSRStrategy.Filter = "SR策略 文件|*.SRStrategy";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1008, 732 );
            this.Controls.Add( this.axCommandBars );
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SR Trading Wizard";
            this.Load += new System.EventHandler( this.MainForm_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.MainForm_FormClosing );
            ( (System.ComponentModel.ISupportInitialize)( this.axCommandBars ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        public AxXtremeCommandBars.AxCommandBars axCommandBars;
        private System.Windows.Forms.OpenFileDialog openFileDialogSRReport;
        private System.Windows.Forms.OpenFileDialog openFileDialogSRStrategy;

    }
}

