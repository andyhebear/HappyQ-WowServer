namespace Demo.Stock.LHP.Main
{
    partial class OptionForm
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
            this.TreeView = new System.Windows.Forms.TreeView();
            this.Panel = new System.Windows.Forms.Panel();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.TreeView.Location = new System.Drawing.Point( 2, 2 );
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size( 193, 521 );
            this.TreeView.TabIndex = 1;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
            // 
            // Panel
            // 
            this.Panel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.Panel.Location = new System.Drawing.Point( 201, 2 );
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size( 580, 520 );
            this.Panel.TabIndex = 2;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point( 685, 528 );
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size( 96, 29 );
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler( this.ButtonCancel_Click );
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Enabled = false;
            this.ButtonOK.Location = new System.Drawing.Point( 583, 528 );
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size( 96, 29 );
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Text = "确定";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler( this.ButtonOK_Click );
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 784, 564 );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.ButtonOK );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.TreeView );
            this.MaximumSize = new System.Drawing.Size( 1024, 768 );
            this.MinimumSize = new System.Drawing.Size( 800, 600 );
            this.Name = "OptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "主程序配置";
            this.Load += new System.EventHandler( this.OptionForm_Load );
            this.Shown += new System.EventHandler( this.OptionForm_Shown );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.OptionForm_FormClosing );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOK;
    }
}