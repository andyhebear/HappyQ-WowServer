namespace Demo.Stock.LHP.BaseSR
{
    partial class SROptionForm
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
            this.Panel = new System.Windows.Forms.Panel();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonLoadSR = new System.Windows.Forms.Button();
            this.ButtonSaveSR = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.Panel.Location = new System.Drawing.Point( 202, 5 );
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size( 580, 520 );
            this.Panel.TabIndex = 1;
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.TreeView.Location = new System.Drawing.Point( 3, 5 );
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size( 193, 520 );
            this.TreeView.TabIndex = 0;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point( 697, 531 );
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size( 85, 29 );
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler( this.ButtonCancel_Click );
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonOK.Location = new System.Drawing.Point( 595, 531 );
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size( 96, 29 );
            this.ButtonOK.TabIndex = 4;
            this.ButtonOK.Text = "确定";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler( this.ButtonOK_Click );
            // 
            // ButtonLoadSR
            // 
            this.ButtonLoadSR.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonLoadSR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonLoadSR.Location = new System.Drawing.Point( 3, 531 );
            this.ButtonLoadSR.Name = "ButtonLoadSR";
            this.ButtonLoadSR.Size = new System.Drawing.Size( 96, 29 );
            this.ButtonLoadSR.TabIndex = 2;
            this.ButtonLoadSR.Text = "读取SR策略";
            this.ButtonLoadSR.UseVisualStyleBackColor = true;
            this.ButtonLoadSR.Click += new System.EventHandler( this.ButtonLoadSR_Click );
            // 
            // ButtonSaveSR
            // 
            this.ButtonSaveSR.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonSaveSR.Location = new System.Drawing.Point( 111, 531 );
            this.ButtonSaveSR.Name = "ButtonSaveSR";
            this.ButtonSaveSR.Size = new System.Drawing.Size( 85, 29 );
            this.ButtonSaveSR.TabIndex = 3;
            this.ButtonSaveSR.Text = "保存SR策略";
            this.ButtonSaveSR.UseVisualStyleBackColor = true;
            this.ButtonSaveSR.Click += new System.EventHandler( this.ButtonSaveSR_Click );
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "SRStrategy";
            this.openFileDialog.Filter = "SR策略 文件|*.SRStrategy";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "SRStrategy";
            this.saveFileDialog.Filter = "SR策略 文件|*.SRStrategy";
            // 
            // SROptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 784, 564 );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.TreeView );
            this.Controls.Add( this.ButtonSaveSR );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.ButtonLoadSR );
            this.Controls.Add( this.ButtonOK );
            this.MaximumSize = new System.Drawing.Size( 1024, 768 );
            this.MinimumSize = new System.Drawing.Size( 800, 600 );
            this.Name = "SROptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SR 策略配置";
            this.Load += new System.EventHandler( this.PrimaryScanOptionForm_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.SROptionForm_FormClosing );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonLoadSR;
        private System.Windows.Forms.Button ButtonSaveSR;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}