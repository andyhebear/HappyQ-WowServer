namespace Demo.Stock.LHP
{
    partial class PrimaryScanOptionForm2
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
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
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
            this.Panel.TabIndex = 10;
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.TreeView.Location = new System.Drawing.Point( 3, 5 );
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size( 193, 520 );
            this.TreeView.TabIndex = 9;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point( 697, 531 );
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size( 85, 29 );
            this.ButtonCancel.TabIndex = 7;
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
            this.ButtonOK.TabIndex = 8;
            this.ButtonOK.Text = "确定";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler( this.ButtonOK_Click );
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonLoad.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonLoad.Location = new System.Drawing.Point( 3, 531 );
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size( 129, 29 );
            this.ButtonLoad.TabIndex = 8;
            this.ButtonLoad.Text = "读取UTMR/DTMS策略";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler( this.ButtonLoad_Click );
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonSave.Location = new System.Drawing.Point( 138, 531 );
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size( 129, 29 );
            this.ButtonSave.TabIndex = 7;
            this.ButtonSave.Text = "保存UTMR/DTMS策略";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler( this.ButtonSave_Click );
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "MSRKStrategy";
            this.saveFileDialog.Filter = "UTMR/DTMS策略 文件|*.MSRKStrategy";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "MSRKStrategy";
            this.openFileDialog.Filter = "UTMR/DTMS策略 文件|*.MSRKStrategy";
            // 
            // PrimaryScanOptionForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 784, 564 );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.TreeView );
            this.Controls.Add( this.ButtonSave );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.ButtonLoad );
            this.Controls.Add( this.ButtonOK );
            this.MaximumSize = new System.Drawing.Size( 1024, 768 );
            this.MinimumSize = new System.Drawing.Size( 800, 600 );
            this.Name = "PrimaryScanOptionForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UTMR/DTMS策略设置";
            this.Load += new System.EventHandler( this.PrimaryScanOptionForm_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.PrimaryScanOptionForm2_FormClosing );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}