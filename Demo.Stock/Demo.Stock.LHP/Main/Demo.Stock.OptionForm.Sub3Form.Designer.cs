namespace Demo.Stock.LHP.Main
{
    partial class OptionSub3From
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OptionSub3From ) );
            this.axTabControl = new AxXtremeSuiteControls.AxTabControl();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControl ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axTabControl
            // 
            this.axTabControl.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.axTabControl.Location = new System.Drawing.Point( 0, 0 );
            this.axTabControl.Name = "axTabControl";
            this.axTabControl.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axTabControl.OcxState" ) ) );
            this.axTabControl.Size = new System.Drawing.Size( 784, 518 );
            this.axTabControl.TabIndex = 0;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point( 604, 524 );
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size( 81, 28 );
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.Text = "确定";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler( this.ButtonOK_Click );
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point( 691, 524 );
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size( 81, 28 );
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler( this.ButtonCancel_Click );
            // 
            // OptionSub3From
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 784, 564 );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.ButtonOK );
            this.Controls.Add( this.axTabControl );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 1024, 768 );
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 800, 600 );
            this.Name = "OptionSub3From";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Demo";
            this.Load += new System.EventHandler( this.OptionSub3From_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControl ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeSuiteControls.AxTabControl axTabControl;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;

    }
}