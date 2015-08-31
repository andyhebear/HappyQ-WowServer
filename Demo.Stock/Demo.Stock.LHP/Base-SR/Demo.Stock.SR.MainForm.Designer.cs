namespace Demo.Stock.LHP.BaseSR
{
    partial class SR_MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SR_MainForm ) );
            this.axCommandBars = new AxXtremeCommandBars.AxCommandBars();
            this.openFileDialogStrategy = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogReport = new System.Windows.Forms.OpenFileDialog();
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
            this.axCommandBars.TabIndex = 1;
            this.axCommandBars.UpdateEvent += new AxXtremeCommandBars._DCommandBarsEvents_UpdateEventHandler( this.axCommandBars_UpdateEvent );
            this.axCommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler( this.axCommandBars_Execute );
            this.axCommandBars.Customization += new AxXtremeCommandBars._DCommandBarsEvents_CustomizationEventHandler( this.axCommandBars_Customization );
            // 
            // openFileDialogReport
            // 
            this.openFileDialogStrategy.DefaultExt = "MSRKStrategy";
            this.openFileDialogStrategy.Filter = "UTMR/DTMS策略 文件|*.MSRKStrategy";
            // 
            // openFileDialogStrategy
            // 
            this.openFileDialogReport.DefaultExt = "MSRKReport";
            this.openFileDialogReport.Filter = "UTMR/DTMS报表 文件|*.MSRKReport";
            // 
            // SR_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1008, 732 );
            this.Controls.Add( this.axCommandBars );
            this.IsMdiContainer = true;
            this.Name = "SR_MainForm";
            this.Text = "SR 搜索";
            this.Load += new System.EventHandler( this.SR_MainForm_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.SR_MainForm_FormClosing );
            ( (System.ComponentModel.ISupportInitialize)( this.axCommandBars ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        public AxXtremeCommandBars.AxCommandBars axCommandBars;
        private System.Windows.Forms.OpenFileDialog openFileDialogStrategy;
        private System.Windows.Forms.OpenFileDialog openFileDialogReport;
    }
}