namespace Demo.EncodeConvert.Tool
{
    partial class EncodeConvertForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ConversionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SourceComboBox = new System.Windows.Forms.ComboBox();
            this.TargetComboBox = new System.Windows.Forms.ComboBox();
            this.IncludeTextBox = new System.Windows.Forms.TextBox();
            this.AddFolderButton = new System.Windows.Forms.Button();
            this.AddFileButton = new System.Windows.Forms.Button();
            this.SubFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.InfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.RemoveFileButton = new System.Windows.Forms.Button();
            this.RemoveAllFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.AboutButton = new System.Windows.Forms.Button();
            this.BakFileCheckBox = new System.Windows.Forms.CheckBox();
            this.Labelnfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConversionButton
            // 
            this.ConversionButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ConversionButton.Location = new System.Drawing.Point( 419, 272 );
            this.ConversionButton.Name = "ConversionButton";
            this.ConversionButton.Size = new System.Drawing.Size( 75, 23 );
            this.ConversionButton.TabIndex = 4;
            this.ConversionButton.Text = "开始转换";
            this.ConversionButton.UseVisualStyleBackColor = true;
            this.ConversionButton.Click += new System.EventHandler( this.ConversionButton_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 53, 12 );
            this.label1.TabIndex = 13;
            this.label1.Text = "编码来源";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 154, 9 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53, 12 );
            this.label2.TabIndex = 14;
            this.label2.Text = "编码目标";
            // 
            // label3
            // 
            this.label3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 404, 9 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 29, 12 );
            this.label3.TabIndex = 16;
            this.label3.Text = "过滤";
            // 
            // SourceComboBox
            // 
            this.SourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceComboBox.FormattingEnabled = true;
            this.SourceComboBox.Items.AddRange( new object[] {
            "UTF-8",
            "Unicode",
            "Ascii",
            "Gb2312"} );
            this.SourceComboBox.Location = new System.Drawing.Point( 12, 38 );
            this.SourceComboBox.Name = "SourceComboBox";
            this.SourceComboBox.Size = new System.Drawing.Size( 121, 20 );
            this.SourceComboBox.TabIndex = 7;
            // 
            // TargetComboBox
            // 
            this.TargetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetComboBox.FormattingEnabled = true;
            this.TargetComboBox.Items.AddRange( new object[] {
            "UTF-8",
            "Unicode",
            "Ascii",
            "Gb2312"} );
            this.TargetComboBox.Location = new System.Drawing.Point( 156, 38 );
            this.TargetComboBox.Name = "TargetComboBox";
            this.TargetComboBox.Size = new System.Drawing.Size( 121, 20 );
            this.TargetComboBox.TabIndex = 8;
            // 
            // IncludeTextBox
            // 
            this.IncludeTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.IncludeTextBox.Location = new System.Drawing.Point( 297, 37 );
            this.IncludeTextBox.Name = "IncludeTextBox";
            this.IncludeTextBox.Size = new System.Drawing.Size( 100, 21 );
            this.IncludeTextBox.TabIndex = 9;
            this.IncludeTextBox.Text = "cs;txt";
            // 
            // AddFolderButton
            // 
            this.AddFolderButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.AddFolderButton.Location = new System.Drawing.Point( 419, 91 );
            this.AddFolderButton.Name = "AddFolderButton";
            this.AddFolderButton.Size = new System.Drawing.Size( 75, 23 );
            this.AddFolderButton.TabIndex = 0;
            this.AddFolderButton.Text = "添加文件夹";
            this.AddFolderButton.UseVisualStyleBackColor = true;
            this.AddFolderButton.Click += new System.EventHandler( this.AddFolderButton_Click );
            // 
            // AddFileButton
            // 
            this.AddFileButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.AddFileButton.Location = new System.Drawing.Point( 419, 147 );
            this.AddFileButton.Name = "AddFileButton";
            this.AddFileButton.Size = new System.Drawing.Size( 75, 23 );
            this.AddFileButton.TabIndex = 1;
            this.AddFileButton.Text = "添加文件";
            this.AddFileButton.UseVisualStyleBackColor = true;
            this.AddFileButton.Click += new System.EventHandler( this.AddFileButton_Click );
            // 
            // SubFolderCheckBox
            // 
            this.SubFolderCheckBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.SubFolderCheckBox.AutoSize = true;
            this.SubFolderCheckBox.Location = new System.Drawing.Point( 419, 125 );
            this.SubFolderCheckBox.Name = "SubFolderCheckBox";
            this.SubFolderCheckBox.Size = new System.Drawing.Size( 84, 16 );
            this.SubFolderCheckBox.TabIndex = 6;
            this.SubFolderCheckBox.Text = "包含子目录";
            this.SubFolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // InfoRichTextBox
            // 
            this.InfoRichTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.InfoRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.InfoRichTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.InfoRichTextBox.Location = new System.Drawing.Point( 14, 305 );
            this.InfoRichTextBox.Name = "InfoRichTextBox";
            this.InfoRichTextBox.ReadOnly = true;
            this.InfoRichTextBox.Size = new System.Drawing.Size( 486, 98 );
            this.InfoRichTextBox.TabIndex = 12;
            this.InfoRichTextBox.Text = "";
            this.InfoRichTextBox.WordWrap = false;
            // 
            // label4
            // 
            this.label4.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 295, 9 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 29, 12 );
            this.label4.TabIndex = 15;
            this.label4.Text = "包含";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.FilterTextBox.Location = new System.Drawing.Point( 406, 37 );
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size( 100, 21 );
            this.FilterTextBox.TabIndex = 10;
            // 
            // RemoveFileButton
            // 
            this.RemoveFileButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RemoveFileButton.Location = new System.Drawing.Point( 419, 184 );
            this.RemoveFileButton.Name = "RemoveFileButton";
            this.RemoveFileButton.Size = new System.Drawing.Size( 75, 23 );
            this.RemoveFileButton.TabIndex = 2;
            this.RemoveFileButton.Text = "移去文件";
            this.RemoveFileButton.UseVisualStyleBackColor = true;
            this.RemoveFileButton.Click += new System.EventHandler( this.RemoveFileButton_Click );
            // 
            // RemoveAllFileButton
            // 
            this.RemoveAllFileButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RemoveAllFileButton.Location = new System.Drawing.Point( 419, 213 );
            this.RemoveAllFileButton.Name = "RemoveAllFileButton";
            this.RemoveAllFileButton.Size = new System.Drawing.Size( 75, 23 );
            this.RemoveAllFileButton.TabIndex = 3;
            this.RemoveAllFileButton.Text = "移去全部";
            this.RemoveAllFileButton.UseVisualStyleBackColor = true;
            this.RemoveAllFileButton.Click += new System.EventHandler( this.RemoveAllFileButton_Click );
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*.*";
            this.openFileDialog.Filter = "所有文件|*.*|C# 文件|*.cs";
            this.openFileDialog.Multiselect = true;
            // 
            // FileListBox
            // 
            this.FileListBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.HorizontalScrollbar = true;
            this.FileListBox.ItemHeight = 12;
            this.FileListBox.Location = new System.Drawing.Point( 14, 74 );
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.FileListBox.Size = new System.Drawing.Size( 383, 220 );
            this.FileListBox.TabIndex = 11;
            // 
            // AboutButton
            // 
            this.AboutButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AboutButton.Location = new System.Drawing.Point( 419, 242 );
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size( 75, 23 );
            this.AboutButton.TabIndex = 5;
            this.AboutButton.Text = "关于";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler( this.AboutButton_Click );
            // 
            // BakFileCheckBox
            // 
            this.BakFileCheckBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.BakFileCheckBox.AutoSize = true;
            this.BakFileCheckBox.Checked = true;
            this.BakFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BakFileCheckBox.Location = new System.Drawing.Point( 406, 64 );
            this.BakFileCheckBox.Name = "BakFileCheckBox";
            this.BakFileCheckBox.Size = new System.Drawing.Size( 96, 16 );
            this.BakFileCheckBox.TabIndex = 6;
            this.BakFileCheckBox.Text = "是否备份文件";
            this.BakFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // Labelnfo
            // 
            this.Labelnfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Labelnfo.Location = new System.Drawing.Point( 406, 86 );
            this.Labelnfo.Name = "Labelnfo";
            this.Labelnfo.Size = new System.Drawing.Size( 100, 2 );
            this.Labelnfo.TabIndex = 17;
            // 
            // EncodeConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 512, 415 );
            this.Controls.Add( this.Labelnfo );
            this.Controls.Add( this.FileListBox );
            this.Controls.Add( this.InfoRichTextBox );
            this.Controls.Add( this.BakFileCheckBox );
            this.Controls.Add( this.SubFolderCheckBox );
            this.Controls.Add( this.FilterTextBox );
            this.Controls.Add( this.IncludeTextBox );
            this.Controls.Add( this.TargetComboBox );
            this.Controls.Add( this.SourceComboBox );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.AboutButton );
            this.Controls.Add( this.RemoveAllFileButton );
            this.Controls.Add( this.RemoveFileButton );
            this.Controls.Add( this.AddFileButton );
            this.Controls.Add( this.AddFolderButton );
            this.Controls.Add( this.ConversionButton );
            this.MinimumSize = new System.Drawing.Size( 520, 442 );
            this.Name = "EncodeConvertForm";
            this.Text = "Demo.EncodeConvert.Tool.Form";
            this.Load += new System.EventHandler( this.EncodeConvertForm_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConversionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SourceComboBox;
        private System.Windows.Forms.ComboBox TargetComboBox;
        private System.Windows.Forms.TextBox IncludeTextBox;
        private System.Windows.Forms.Button AddFolderButton;
        private System.Windows.Forms.Button AddFileButton;
        private System.Windows.Forms.CheckBox SubFolderCheckBox;
        private System.Windows.Forms.RichTextBox InfoRichTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.Button RemoveFileButton;
        private System.Windows.Forms.Button RemoveAllFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox FileListBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.CheckBox BakFileCheckBox;
        private System.Windows.Forms.Label Labelnfo;
    }
}



