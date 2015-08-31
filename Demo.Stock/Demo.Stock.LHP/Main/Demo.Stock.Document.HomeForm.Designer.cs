namespace Demo.Stock.LHP.Main
{
    partial class DocumentHomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( DocumentHomeForm ) );
            this.axTaskPanel = new AxXtremeTaskPanel.AxTaskPanel();
            this.axImageManager = new AxXtremeCommandBars.AxImageManager();
            this.Panel = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.Splitter();
            ( (System.ComponentModel.ISupportInitialize)( this.axTaskPanel ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axImageManager ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axTaskPanel
            // 
            this.axTaskPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTaskPanel.Location = new System.Drawing.Point( 0, 0 );
            this.axTaskPanel.Name = "axTaskPanel";
            this.axTaskPanel.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axTaskPanel.OcxState" ) ) );
            this.axTaskPanel.Size = new System.Drawing.Size( 280, 732 );
            this.axTaskPanel.TabIndex = 0;
            this.axTaskPanel.ItemClick += new AxXtremeTaskPanel._DTaskPanelEvents_ItemClickEventHandler( this.axTaskPanel_ItemClick );
            // 
            // axImageManager
            // 
            this.axImageManager.Enabled = true;
            this.axImageManager.Location = new System.Drawing.Point( 12, 12 );
            this.axImageManager.Name = "axImageManager";
            this.axImageManager.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axImageManager.OcxState" ) ) );
            this.axImageManager.Size = new System.Drawing.Size( 24, 24 );
            this.axImageManager.TabIndex = 0;
            // 
            // Panel
            // 
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point( 280, 0 );
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size( 728, 732 );
            this.Panel.TabIndex = 1;
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point( 280, 0 );
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size( 3, 732 );
            this.splitter.TabIndex = 3;
            this.splitter.TabStop = false;
            // 
            // DocumentHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1008, 732 );
            this.Controls.Add( this.splitter );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.axTaskPanel );
            this.Controls.Add( this.axImageManager );
            this.Name = "DocumentHomeForm";
            this.Text = "Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.DocumentHomeForm_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axTaskPanel ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axImageManager ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeTaskPanel.AxTaskPanel axTaskPanel;
        private AxXtremeCommandBars.AxImageManager axImageManager;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Splitter splitter;
    }
}