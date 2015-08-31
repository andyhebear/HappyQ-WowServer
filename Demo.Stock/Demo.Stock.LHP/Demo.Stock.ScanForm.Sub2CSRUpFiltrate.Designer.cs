namespace Demo.Stock.LHP
{
    partial class ScanControlSub2CSRUpFiltrate
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.numericUpDown3 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 10 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 101, 12 );
            this.label1.TabIndex = 39;
            this.label1.Text = "SR点日期时间范围";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point( 5, 37 );
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size( 120, 16 );
            this.checkBox6.TabIndex = 12;
            this.checkBox6.Text = "绝对价格触发比较";
            this.checkBox6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point( 5, 95 );
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size( 120, 16 );
            this.checkBox8.TabIndex = 11;
            this.checkBox8.Text = "相对价格触发比较";
            this.checkBox8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 91, 125 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 11, 12 );
            this.label2.TabIndex = 22;
            this.label2.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 22, 125 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 11, 12 );
            this.label4.TabIndex = 23;
            this.label4.Text = "+";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 20, 62 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 29, 12 );
            this.label6.TabIndex = 17;
            this.label6.Text = "大于";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point( 55, 59 );
            this.maskedTextBox1.Mask = "999";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size( 30, 21 );
            this.maskedTextBox1.TabIndex = 38;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point( 39, 123 );
            this.numericUpDown3.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size( 46, 21 );
            this.numericUpDown3.TabIndex = 26;
            this.numericUpDown3.Value = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point( 133, 4 );
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size( 131, 21 );
            this.dateTimePicker1.TabIndex = 40;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point( 293, 4 );
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size( 131, 21 );
            this.dateTimePicker2.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 110, 10 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 17, 12 );
            this.label8.TabIndex = 41;
            this.label8.Text = "从";
            this.label8.Click += new System.EventHandler( this.label8_Click );
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point( 270, 10 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 17, 12 );
            this.label9.TabIndex = 41;
            this.label9.Text = "至";
            this.label9.Click += new System.EventHandler( this.label8_Click );
            // 
            // ScanControlSub2CSRUpFiltrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.label9 );
            this.Controls.Add( this.label8 );
            this.Controls.Add( this.dateTimePicker2 );
            this.Controls.Add( this.dateTimePicker1 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.checkBox6 );
            this.Controls.Add( this.checkBox8 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.numericUpDown3 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.maskedTextBox1 );
            this.Controls.Add( this.label6 );
            this.Name = "ScanControlSub2CSRUpFiltrate";
            this.Size = new System.Drawing.Size( 580, 500 );
            ( (System.ComponentModel.ISupportInitialize)( this.numericUpDown3 ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
