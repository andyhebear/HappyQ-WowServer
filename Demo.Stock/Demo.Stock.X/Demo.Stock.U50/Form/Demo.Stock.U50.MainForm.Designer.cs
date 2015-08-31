namespace Demo.Stock.X.U50
{
    partial class U50Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( U50Form ) );
            this.axCommandBars = new AxXtremeCommandBars.AxCommandBars();
            this.Timer1 = new System.Windows.Forms.Timer( this.components );
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
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 5000;
            this.Timer1.Tick += new System.EventHandler( this.Timer1_Tick_1 );
            // 
            // U50Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 792, 573 );
            this.Controls.Add( this.axCommandBars );
            this.IsMdiContainer = true;
            this.Name = "U50Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "U50策略";
            this.Load += new System.EventHandler( this.U50Form_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.U50Form_FormClosing );
            ( (System.ComponentModel.ISupportInitialize)( this.axCommandBars ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeCommandBars.AxCommandBars axCommandBars;
        private System.Windows.Forms.Timer Timer1;
    }
}