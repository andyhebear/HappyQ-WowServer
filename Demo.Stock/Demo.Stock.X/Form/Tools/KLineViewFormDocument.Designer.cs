namespace Demo.Stock.X.Tools
{
    partial class KLineViewFormDocument
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
            Dundas.Charting.WinControl.Legend legend1 = new Dundas.Charting.WinControl.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( KLineViewFormDocument ) );
            this.chart1 = new Dundas.Charting.WinControl.Chart();
            ( (System.ComponentModel.ISupportInitialize)( this.chart1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Default";
            this.chart1.Legends.Add( legend1 );
            this.chart1.Location = new System.Drawing.Point( 0, 0 );
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size( 491, 414 );
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // KLineViewFormDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size( 491, 414 );
            this.Controls.Add( this.chart1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.Name = "KLineViewFormDocument";
            this.Text = "KLineViewFormDocument";
            this.Load += new System.EventHandler( this.KLineViewFormDocument_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.chart1 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private Dundas.Charting.WinControl.Chart chart1;
    }
}