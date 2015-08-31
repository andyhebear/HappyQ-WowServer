namespace Demo_G.O.S.E.HardwareID.Tool
{
    partial class HardwareIDForm
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
            this.HardwareIDButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameInfoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CompanyInfoTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CustomInfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HardwareIDButton
            // 
            this.HardwareIDButton.Location = new System.Drawing.Point( 124, 190 );
            this.HardwareIDButton.Name = "HardwareIDButton";
            this.HardwareIDButton.Size = new System.Drawing.Size( 137, 34 );
            this.HardwareIDButton.TabIndex = 0;
            this.HardwareIDButton.Text = "产生硬件唯一序号";
            this.HardwareIDButton.UseVisualStyleBackColor = true;
            this.HardwareIDButton.Click += new System.EventHandler( this.HardwareIDButton_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 17, 55 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 29, 12 );
            this.label1.TabIndex = 1;
            this.label1.Text = "名字";
            // 
            // NameInfoTextBox
            // 
            this.NameInfoTextBox.Location = new System.Drawing.Point( 52, 49 );
            this.NameInfoTextBox.Name = "NameInfoTextBox";
            this.NameInfoTextBox.Size = new System.Drawing.Size( 118, 21 );
            this.NameInfoTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 17, 100 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 29, 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "公司";
            // 
            // CompanyInfoTextBox
            // 
            this.CompanyInfoTextBox.Location = new System.Drawing.Point( 52, 97 );
            this.CompanyInfoTextBox.Name = "CompanyInfoTextBox";
            this.CompanyInfoTextBox.Size = new System.Drawing.Size( 118, 21 );
            this.CompanyInfoTextBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.CustomInfoRichTextBox );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Controls.Add( this.CompanyInfoTextBox );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Controls.Add( this.NameInfoTextBox );
            this.groupBox1.Location = new System.Drawing.Point( 12, 12 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 343, 162 );
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息填写";
            // 
            // CustomInfoRichTextBox
            // 
            this.CustomInfoRichTextBox.Location = new System.Drawing.Point( 192, 38 );
            this.CustomInfoRichTextBox.Name = "CustomInfoRichTextBox";
            this.CustomInfoRichTextBox.Size = new System.Drawing.Size( 137, 110 );
            this.CustomInfoRichTextBox.TabIndex = 3;
            this.CustomInfoRichTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 204, 17 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 113, 12 );
            this.label3.TabIndex = 1;
            this.label3.Text = "你想填写的需求信息";
            // 
            // HardwareIDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 384, 251 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.HardwareIDButton );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HardwareIDForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo.GOSE.HardwareID.Tool.Form";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button HardwareIDButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameInfoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CompanyInfoTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox CustomInfoRichTextBox;
        private System.Windows.Forms.Label label3;
    }
}

