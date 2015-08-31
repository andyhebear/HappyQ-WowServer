namespace Demo.Stock.LHP
{
    partial class ScanControlSub2CSRDownFiltrate
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.numericUpDown4 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point( 5, 37 );
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size( 120, 16 );
            this.checkBox1.TabIndex = 39;
            this.checkBox1.Text = "绝对价格触发比较";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point( 5, 95 );
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size( 120, 16 );
            this.checkBox2.TabIndex = 38;
            this.checkBox2.Text = "相对价格触发比较";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point( 39, 123 );
            this.numericUpDown4.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size( 46, 21 );
            this.numericUpDown4.TabIndex = 43;
            this.numericUpDown4.Value = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 22, 125 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 11, 12 );
            this.label5.TabIndex = 42;
            this.label5.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 91, 125 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 11, 12 );
            this.label3.TabIndex = 41;
            this.label3.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point( 20, 62 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 29, 12 );
            this.label7.TabIndex = 40;
            this.label7.Text = "小于";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point( 55, 59 );
            this.maskedTextBox2.Mask = "999";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size( 30, 21 );
            this.maskedTextBox2.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point( 270, 10 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 17, 12 );
            this.label9.TabIndex = 48;
            this.label9.Text = "至";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 110, 10 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 17, 12 );
            this.label8.TabIndex = 49;
            this.label8.Text = "从";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point( 293, 4 );
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size( 131, 21 );
            this.dateTimePicker2.TabIndex = 47;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point( 133, 4 );
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size( 131, 21 );
            this.dateTimePicker1.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 10 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 101, 12 );
            this.label1.TabIndex = 45;
            this.label1.Text = "SR点日期时间范围";
            // 
            // ScanControlSub2CSRDownFiltrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.label9 );
            this.Controls.Add( this.label8 );
            this.Controls.Add( this.dateTimePicker2 );
            this.Controls.Add( this.dateTimePicker1 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.checkBox1 );
            this.Controls.Add( this.checkBox2 );
            this.Controls.Add( this.numericUpDown4 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label7 );
            this.Controls.Add( this.maskedTextBox2 );
            this.Name = "ScanControlSub2CSRDownFiltrate";
            this.Size = new System.Drawing.Size( 580, 500 );
            ( (System.ComponentModel.ISupportInitialize)( this.numericUpDown4 ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
    }
}
