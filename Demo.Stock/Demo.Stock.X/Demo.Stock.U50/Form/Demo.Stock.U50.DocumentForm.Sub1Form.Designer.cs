namespace Demo.Stock.X.U50
{
    partial class DocumentFormSub1
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
            this.ButtonScan = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // ButtonScan
            // 
            this.ButtonScan.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonScan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonScan.Location = new System.Drawing.Point( 324, 437 );
            this.ButtonScan.Name = "ButtonScan";
            this.ButtonScan.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonScan.TabIndex = 0;
            this.ButtonScan.Text = "开始扫描";
            this.ButtonScan.UseVisualStyleBackColor = true;
            this.ButtonScan.Click += new System.EventHandler( this.ButtonScan_Click );
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonCancel.Location = new System.Drawing.Point( 405, 437 );
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonCancel.TabIndex = 0;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // Panel
            // 
            this.Panel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.Panel.Location = new System.Drawing.Point( 150, 12 );
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size( 330, 412 );
            this.Panel.TabIndex = 7;
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point( 3, 12 );
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size( 140, 412 );
            this.TreeView.TabIndex = 6;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
            // 
            // DocumentFormSub1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 492, 472 );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.TreeView );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.ButtonScan );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 600, 600 );
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 500, 500 );
            this.Name = "DocumentFormSub1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "增强扫描设置";
            this.Load += new System.EventHandler( this.DocumentFormSub1_Load );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button ButtonScan;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.TreeView TreeView;
    }
}