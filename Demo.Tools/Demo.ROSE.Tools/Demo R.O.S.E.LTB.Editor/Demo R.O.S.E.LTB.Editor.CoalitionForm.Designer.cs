namespace Demo_R.O.S.E.LTB.Editor
{
    partial class CoalitionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBoxSaveFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxFile1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxFile2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.openFileDialogFile1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogFile2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12, 15 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 83, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "第一个LTB文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 12, 57 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 83, 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "第二个LTB文件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 12, 99 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 77, 12 );
            this.label3.TabIndex = 2;
            this.label3.Text = "保存合并文件";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.label4 );
            this.groupBox1.Controls.Add( this.checkBox5 );
            this.groupBox1.Controls.Add( this.checkBox4 );
            this.groupBox1.Controls.Add( this.checkBox3 );
            this.groupBox1.Controls.Add( this.checkBox2 );
            this.groupBox1.Controls.Add( this.checkBox1 );
            this.groupBox1.Location = new System.Drawing.Point( 14, 144 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 365, 141 );
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "第一个文件需保留的语言";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 188, 64 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 161, 12 );
            this.label4.TabIndex = 3;
            this.label4.Text = "其余以第二个文件的语言为主";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point( 15, 108 );
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size( 78, 16 );
            this.checkBox5.TabIndex = 2;
            this.checkBox5.Text = "中文-中国";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point( 15, 86 );
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size( 78, 16 );
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "中文-台湾";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point( 15, 64 );
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size( 48, 16 );
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "日文";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point( 15, 42 );
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size( 48, 16 );
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "英文";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point( 15, 20 );
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size( 48, 16 );
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "韩文";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBoxSaveFile
            // 
            this.textBoxSaveFile.Location = new System.Drawing.Point( 101, 96 );
            this.textBoxSaveFile.Name = "textBoxSaveFile";
            this.textBoxSaveFile.Size = new System.Drawing.Size( 168, 21 );
            this.textBoxSaveFile.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 291, 6 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 88, 30 );
            this.button1.TabIndex = 6;
            this.button1.Text = "打开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // textBoxFile1
            // 
            this.textBoxFile1.Location = new System.Drawing.Point( 101, 12 );
            this.textBoxFile1.Name = "textBoxFile1";
            this.textBoxFile1.Size = new System.Drawing.Size( 168, 21 );
            this.textBoxFile1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 291, 48 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 88, 30 );
            this.button2.TabIndex = 7;
            this.button2.Text = "打开";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler( this.button2_Click );
            // 
            // textBoxFile2
            // 
            this.textBoxFile2.Location = new System.Drawing.Point( 101, 54 );
            this.textBoxFile2.Name = "textBoxFile2";
            this.textBoxFile2.Size = new System.Drawing.Size( 168, 21 );
            this.textBoxFile2.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point( 291, 90 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 88, 30 );
            this.button3.TabIndex = 8;
            this.button3.Text = "保存";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler( this.button3_Click );
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point( 66, 307 );
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size( 88, 30 );
            this.button4.TabIndex = 11;
            this.button4.Text = "合并";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler( this.button4_Click );
            // 
            // button5
            // 
            this.button5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button5.Location = new System.Drawing.Point( 241, 307 );
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size( 88, 30 );
            this.button5.TabIndex = 12;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // openFileDialogFile1
            // 
            this.openFileDialogFile1.DefaultExt = "*.STL";
            this.openFileDialogFile1.FileName = "*.STL";
            this.openFileDialogFile1.Filter = "STL 文件 (*.STL)|*.STL|所有文件 (*.*)|*.*";
            // 
            // openFileDialogFile2
            // 
            this.openFileDialogFile2.DefaultExt = "*.STL";
            this.openFileDialogFile2.FileName = "*.STL";
            this.openFileDialogFile2.Filter = "STL 文件 (*.STL)|*.STL|所有文件 (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "STL 文件 (*.STL)|*.STL|所有文件 (*.*)|*.*";
            // 
            // CoalitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 395, 354 );
            this.Controls.Add( this.button3 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button5 );
            this.Controls.Add( this.button4 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.textBoxFile2 );
            this.Controls.Add( this.textBoxFile1 );
            this.Controls.Add( this.textBoxSaveFile );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CoalitionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Demo R.O.S.E.LTB.Editor.CoalitionForm";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSaveFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxFile1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxFile2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.OpenFileDialog openFileDialogFile1;
        private System.Windows.Forms.OpenFileDialog openFileDialogFile2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label4;
    }
}

