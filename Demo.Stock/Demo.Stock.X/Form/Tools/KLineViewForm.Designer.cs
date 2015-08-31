namespace Demo.Stock.X.Tools
{
    partial class KLineViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( KLineViewForm ) );
            this.axCommandBars = new AxXtremeCommandBars.AxCommandBars();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ( (System.ComponentModel.ISupportInitialize)( this.axCommandBars ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axCommandBars
            // 
            this.axCommandBars.Enabled = true;
            this.axCommandBars.Location = new System.Drawing.Point( 12, 2 );
            this.axCommandBars.Name = "axCommandBars";
            this.axCommandBars.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axCommandBars.OcxState" ) ) );
            this.axCommandBars.Size = new System.Drawing.Size( 24, 24 );
            this.axCommandBars.TabIndex = 0;
            this.axCommandBars.UpdateEvent += new AxXtremeCommandBars._DCommandBarsEvents_UpdateEventHandler( this.axCommandBars_UpdateEvent );
            this.axCommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler( this.axCommandBars_Execute );
            this.axCommandBars.Customization += new AxXtremeCommandBars._DCommandBarsEvents_CustomizationEventHandler( this.axCommandBars_Customization );
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "选择MetaStock文件的目录";
            // 
            // KLineViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 792, 573 );
            this.Controls.Add( this.axCommandBars );
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.IsMdiContainer = true;
            this.Name = "KLineViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "K线策略图浏览器";
            this.Load += new System.EventHandler( this.KLineViewForm_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axCommandBars ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeCommandBars.AxCommandBars axCommandBars;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    }
}