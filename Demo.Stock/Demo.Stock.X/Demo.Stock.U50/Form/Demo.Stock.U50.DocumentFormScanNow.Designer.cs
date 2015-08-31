namespace Demo.Stock.X.U50
{
    partial class ScanNowDocumentForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ScanNowDocumentForm ) );
            this.axTabControlStock = new AxXtremeSuiteControls.AxTabControl();
            this.Timer1 = new System.Windows.Forms.Timer( this.components );
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControlStock ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axTabControlStock
            // 
            this.axTabControlStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTabControlStock.Location = new System.Drawing.Point( 0, 0 );
            this.axTabControlStock.Name = "axTabControlStock";
            this.axTabControlStock.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axTabControlStock.OcxState" ) ) );
            this.axTabControlStock.Size = new System.Drawing.Size( 784, 564 );
            this.axTabControlStock.TabIndex = 1;
            // 
            // Timer1
            // 
            this.Timer1.Interval = 200;
            this.Timer1.Tick += new System.EventHandler( this.Timer1_Tick );
            // 
            // DocumentForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 784, 564 );
            this.Controls.Add( this.axTabControlStock );
            this.Name = "DocumentForm1";
            this.Text = "Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.DocumentForm01_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.DocumentForm1_FormClosing );
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControlStock ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeSuiteControls.AxTabControl axTabControlStock;
        private System.Windows.Forms.Timer Timer1;
    }
}