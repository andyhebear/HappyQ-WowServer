namespace Demo.Stock.X
{
    partial class ToolsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ToolsForm ) );
            this.ButtonMSFLView = new System.Windows.Forms.Button();
            this.ButtonBackupSetting = new System.Windows.Forms.Button();
            this.ButtonRestoreSetting = new System.Windows.Forms.Button();
            this.FolderBrowserDialogSetting = new System.Windows.Forms.FolderBrowserDialog();
            this.ButtonKLineView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonMSFLView
            // 
            this.ButtonMSFLView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonMSFLView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonMSFLView.Location = new System.Drawing.Point( 237, 190 );
            this.ButtonMSFLView.Name = "ButtonMSFLView";
            this.ButtonMSFLView.Size = new System.Drawing.Size( 136, 28 );
            this.ButtonMSFLView.TabIndex = 0;
            this.ButtonMSFLView.Text = "MetaStock文件浏览";
            this.ButtonMSFLView.UseVisualStyleBackColor = true;
            this.ButtonMSFLView.Click += new System.EventHandler( this.ButtonMSFLView_Click );
            // 
            // ButtonBackupSetting
            // 
            this.ButtonBackupSetting.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonBackupSetting.Location = new System.Drawing.Point( 12, 12 );
            this.ButtonBackupSetting.Name = "ButtonBackupSetting";
            this.ButtonBackupSetting.Size = new System.Drawing.Size( 136, 28 );
            this.ButtonBackupSetting.TabIndex = 0;
            this.ButtonBackupSetting.Text = "备份设置文件";
            this.ButtonBackupSetting.UseVisualStyleBackColor = true;
            this.ButtonBackupSetting.Click += new System.EventHandler( this.ButtonBackupSetting_Click );
            // 
            // ButtonRestoreSetting
            // 
            this.ButtonRestoreSetting.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonRestoreSetting.Location = new System.Drawing.Point( 12, 46 );
            this.ButtonRestoreSetting.Name = "ButtonRestoreSetting";
            this.ButtonRestoreSetting.Size = new System.Drawing.Size( 136, 28 );
            this.ButtonRestoreSetting.TabIndex = 0;
            this.ButtonRestoreSetting.Text = "恢复设置文件";
            this.ButtonRestoreSetting.UseVisualStyleBackColor = true;
            this.ButtonRestoreSetting.Click += new System.EventHandler( this.ButtonRestoreSetting_Click );
            // 
            // ButtonKLineView
            // 
            this.ButtonKLineView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonKLineView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonKLineView.Location = new System.Drawing.Point( 237, 224 );
            this.ButtonKLineView.Name = "ButtonKLineView";
            this.ButtonKLineView.Size = new System.Drawing.Size( 136, 28 );
            this.ButtonKLineView.TabIndex = 0;
            this.ButtonKLineView.Text = "MetaStock策略图";
            this.ButtonKLineView.UseVisualStyleBackColor = true;
            this.ButtonKLineView.Click += new System.EventHandler( this.ButtonKLineView_Click );
            // 
            // ToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 384, 264 );
            this.Controls.Add( this.ButtonKLineView );
            this.Controls.Add( this.ButtonMSFLView );
            this.Controls.Add( this.ButtonRestoreSetting );
            this.Controls.Add( this.ButtonBackupSetting );
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 500, 400 );
            this.MinimumSize = new System.Drawing.Size( 400, 300 );
            this.Name = "ToolsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工具箱";
            this.Load += new System.EventHandler( this.ToolsForm_Load );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button ButtonMSFLView;
        private System.Windows.Forms.Button ButtonBackupSetting;
        private System.Windows.Forms.Button ButtonRestoreSetting;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialogSetting;
        private System.Windows.Forms.Button ButtonKLineView;
    }
}