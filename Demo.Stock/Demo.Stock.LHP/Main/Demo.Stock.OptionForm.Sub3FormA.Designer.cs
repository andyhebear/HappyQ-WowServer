namespace Demo.Stock.LHP.Main
{
    partial class OptionControlSub3FromA
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CheckBoxUTMR_DTMS = new System.Windows.Forms.CheckBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxStockList = new System.Windows.Forms.TextBox();
            this.ButtonStockList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxSRFile = new System.Windows.Forms.TextBox();
            this.ButtonOpenSRFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxUTMR_DTMSFile = new System.Windows.Forms.TextBox();
            this.ButtonOpen_UTMR_DTMS_File = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxSaveSRFile = new System.Windows.Forms.TextBox();
            this.ButtonSaveSRFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxSaveUTMR_DTMSFile = new System.Windows.Forms.TextBox();
            this.ButtonSave_UTMR_DTMS_File = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.openFileDialogSR = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_UTMR_DTMS = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSR = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog_UTMR_DTMS = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogStockList = new System.Windows.Forms.OpenFileDialog();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxUTMR_DTMS
            // 
            this.CheckBoxUTMR_DTMS.AutoSize = true;
            this.CheckBoxUTMR_DTMS.Location = new System.Drawing.Point( 5, 222 );
            this.CheckBoxUTMR_DTMS.Name = "CheckBoxUTMR_DTMS";
            this.CheckBoxUTMR_DTMS.Size = new System.Drawing.Size( 174, 16 );
            this.CheckBoxUTMR_DTMS.TabIndex = 11;
            this.CheckBoxUTMR_DTMS.Text = "允许继续扫描UTMR/DTMS策略";
            this.CheckBoxUTMR_DTMS.UseVisualStyleBackColor = true;
            this.CheckBoxUTMR_DTMS.CheckedChanged += new System.EventHandler( this.CheckBoxUTMR_DTMS_CheckedChanged );
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point( 86, 11 );
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size( 283, 21 );
            this.TextBoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 14 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 77, 12 );
            this.label1.TabIndex = 7;
            this.label1.Text = "扫描任务名称";
            // 
            // TextBoxStockList
            // 
            this.TextBoxStockList.Location = new System.Drawing.Point( 86, 58 );
            this.TextBoxStockList.Name = "TextBoxStockList";
            this.TextBoxStockList.Size = new System.Drawing.Size( 283, 21 );
            this.TextBoxStockList.TabIndex = 1;
            // 
            // ButtonStockList
            // 
            this.ButtonStockList.Location = new System.Drawing.Point( 375, 53 );
            this.ButtonStockList.Name = "ButtonStockList";
            this.ButtonStockList.Size = new System.Drawing.Size( 92, 28 );
            this.ButtonStockList.TabIndex = 2;
            this.ButtonStockList.Text = "选择股票清单";
            this.ButtonStockList.UseVisualStyleBackColor = true;
            this.ButtonStockList.Click += new System.EventHandler( this.ButtonStockList_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 3, 61 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 77, 12 );
            this.label2.TabIndex = 8;
            this.label2.Text = "股票清单文件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 3, 108 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 65, 12 );
            this.label3.TabIndex = 9;
            this.label3.Text = "SR策略文件";
            // 
            // TextBoxSRFile
            // 
            this.TextBoxSRFile.Location = new System.Drawing.Point( 86, 105 );
            this.TextBoxSRFile.Name = "TextBoxSRFile";
            this.TextBoxSRFile.Size = new System.Drawing.Size( 283, 21 );
            this.TextBoxSRFile.TabIndex = 3;
            // 
            // ButtonOpenSRFile
            // 
            this.ButtonOpenSRFile.Location = new System.Drawing.Point( 375, 100 );
            this.ButtonOpenSRFile.Name = "ButtonOpenSRFile";
            this.ButtonOpenSRFile.Size = new System.Drawing.Size( 92, 28 );
            this.ButtonOpenSRFile.TabIndex = 4;
            this.ButtonOpenSRFile.Text = "选择策略文件";
            this.ButtonOpenSRFile.UseVisualStyleBackColor = true;
            this.ButtonOpenSRFile.Click += new System.EventHandler( this.ButtonOpenSRFile_Click );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 6, 26 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 107, 12 );
            this.label4.TabIndex = 4;
            this.label4.Text = "UTMR/DTMS策略文件";
            // 
            // TextBoxUTMR_DTMSFile
            // 
            this.TextBoxUTMR_DTMSFile.Location = new System.Drawing.Point( 119, 23 );
            this.TextBoxUTMR_DTMSFile.Name = "TextBoxUTMR_DTMSFile";
            this.TextBoxUTMR_DTMSFile.Size = new System.Drawing.Size( 245, 21 );
            this.TextBoxUTMR_DTMSFile.TabIndex = 0;
            // 
            // ButtonOpen_UTMR_DTMS_File
            // 
            this.ButtonOpen_UTMR_DTMS_File.Location = new System.Drawing.Point( 370, 23 );
            this.ButtonOpen_UTMR_DTMS_File.Name = "ButtonOpen_UTMR_DTMS_File";
            this.ButtonOpen_UTMR_DTMS_File.Size = new System.Drawing.Size( 92, 28 );
            this.ButtonOpen_UTMR_DTMS_File.TabIndex = 1;
            this.ButtonOpen_UTMR_DTMS_File.Text = "选择策略文件";
            this.ButtonOpen_UTMR_DTMS_File.UseVisualStyleBackColor = true;
            this.ButtonOpen_UTMR_DTMS_File.Click += new System.EventHandler( this.ButtonOpen_UTMR_DTMS_File_Click );
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 3, 155 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 125, 12 );
            this.label5.TabIndex = 10;
            this.label5.Text = "SR策略生成的文件位置";
            // 
            // TextBoxSaveSRFile
            // 
            this.TextBoxSaveSRFile.Location = new System.Drawing.Point( 134, 152 );
            this.TextBoxSaveSRFile.Name = "TextBoxSaveSRFile";
            this.TextBoxSaveSRFile.Size = new System.Drawing.Size( 235, 21 );
            this.TextBoxSaveSRFile.TabIndex = 5;
            // 
            // ButtonSaveSRFile
            // 
            this.ButtonSaveSRFile.Location = new System.Drawing.Point( 375, 147 );
            this.ButtonSaveSRFile.Name = "ButtonSaveSRFile";
            this.ButtonSaveSRFile.Size = new System.Drawing.Size( 92, 28 );
            this.ButtonSaveSRFile.TabIndex = 6;
            this.ButtonSaveSRFile.Text = "保存策略文件";
            this.ButtonSaveSRFile.UseVisualStyleBackColor = true;
            this.ButtonSaveSRFile.Click += new System.EventHandler( this.ButtonSaveSRFile_Click );
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 6, 68 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 167, 12 );
            this.label6.TabIndex = 5;
            this.label6.Text = "UTMR/DTMS策略生成的文件位置";
            // 
            // TextBoxSaveUTMR_DTMSFile
            // 
            this.TextBoxSaveUTMR_DTMSFile.Location = new System.Drawing.Point( 179, 65 );
            this.TextBoxSaveUTMR_DTMSFile.Name = "TextBoxSaveUTMR_DTMSFile";
            this.TextBoxSaveUTMR_DTMSFile.Size = new System.Drawing.Size( 185, 21 );
            this.TextBoxSaveUTMR_DTMSFile.TabIndex = 2;
            // 
            // ButtonSave_UTMR_DTMS_File
            // 
            this.ButtonSave_UTMR_DTMS_File.Location = new System.Drawing.Point( 370, 60 );
            this.ButtonSave_UTMR_DTMS_File.Name = "ButtonSave_UTMR_DTMS_File";
            this.ButtonSave_UTMR_DTMS_File.Size = new System.Drawing.Size( 92, 28 );
            this.ButtonSave_UTMR_DTMS_File.TabIndex = 3;
            this.ButtonSave_UTMR_DTMS_File.Text = "保存策略文件";
            this.ButtonSave_UTMR_DTMS_File.UseVisualStyleBackColor = true;
            this.ButtonSave_UTMR_DTMS_File.Click += new System.EventHandler( this.ButtonSave_UTMR_DTMS_File_Click );
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add( this.label4 );
            this.groupBox.Controls.Add( this.ButtonOpen_UTMR_DTMS_File );
            this.groupBox.Controls.Add( this.label6 );
            this.groupBox.Controls.Add( this.ButtonSave_UTMR_DTMS_File );
            this.groupBox.Controls.Add( this.TextBoxSaveUTMR_DTMSFile );
            this.groupBox.Controls.Add( this.TextBoxUTMR_DTMSFile );
            this.groupBox.Location = new System.Drawing.Point( 5, 244 );
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size( 481, 107 );
            this.groupBox.TabIndex = 12;
            this.groupBox.TabStop = false;
            // 
            // openFileDialogSR
            // 
            this.openFileDialogSR.FileName = "openFileDialogSRFile";
            // 
            // openFileDialog_UTMR_DTMS
            // 
            this.openFileDialog_UTMR_DTMS.FileName = "openFileDialog3";
            // 
            // openFileDialogStockList
            // 
            this.openFileDialogStockList.FileName = "openFileDialogSRFile";
            // 
            // OptionControlSub3FromA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.groupBox );
            this.Controls.Add( this.ButtonSaveSRFile );
            this.Controls.Add( this.ButtonOpenSRFile );
            this.Controls.Add( this.ButtonStockList );
            this.Controls.Add( this.TextBoxSaveSRFile );
            this.Controls.Add( this.TextBoxSRFile );
            this.Controls.Add( this.TextBoxStockList );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.TextBoxName );
            this.Controls.Add( this.CheckBoxUTMR_DTMS );
            this.Name = "OptionControlSub3FromA";
            this.Size = new System.Drawing.Size( 780, 518 );
            this.Load += new System.EventHandler( this.OptionControlSub3FromA_Load );
            this.groupBox.ResumeLayout( false );
            this.groupBox.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox CheckBoxUTMR_DTMS;
        public System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TextBoxStockList;
        private System.Windows.Forms.Button ButtonStockList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TextBoxSRFile;
        private System.Windows.Forms.Button ButtonOpenSRFile;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TextBoxUTMR_DTMSFile;
        private System.Windows.Forms.Button ButtonOpen_UTMR_DTMS_File;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox TextBoxSaveSRFile;
        private System.Windows.Forms.Button ButtonSaveSRFile;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox TextBoxSaveUTMR_DTMSFile;
        private System.Windows.Forms.Button ButtonSave_UTMR_DTMS_File;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.OpenFileDialog openFileDialogSR;
        private System.Windows.Forms.OpenFileDialog openFileDialog_UTMR_DTMS;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSR;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_UTMR_DTMS;
        private System.Windows.Forms.OpenFileDialog openFileDialogStockList;
    }
}
