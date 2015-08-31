namespace Demo.Stock.LHP
{
    partial class ScanControlSub2
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
            this.CheckBoxAllowSR = new System.Windows.Forms.CheckBox();
            this.DateTimePickerSelect = new System.Windows.Forms.DateTimePicker();
            this.RadioButtonSelect = new System.Windows.Forms.RadioButton();
            this.RadioButtonNow = new System.Windows.Forms.RadioButton();
            this.LabelNow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckBoxAllowSR
            // 
            this.CheckBoxAllowSR.AutoSize = true;
            this.CheckBoxAllowSR.Location = new System.Drawing.Point( 3, 3 );
            this.CheckBoxAllowSR.Name = "CheckBoxAllowSR";
            this.CheckBoxAllowSR.Size = new System.Drawing.Size( 120, 16 );
            this.CheckBoxAllowSR.TabIndex = 38;
            this.CheckBoxAllowSR.Text = "允许生成SR的报表";
            this.CheckBoxAllowSR.UseVisualStyleBackColor = true;
            // 
            // DateTimePickerSelect
            // 
            this.DateTimePickerSelect.Location = new System.Drawing.Point( 170, 43 );
            this.DateTimePickerSelect.Name = "DateTimePickerSelect";
            this.DateTimePickerSelect.Size = new System.Drawing.Size( 125, 21 );
            this.DateTimePickerSelect.TabIndex = 47;
            // 
            // RadioButtonSelect
            // 
            this.RadioButtonSelect.AutoSize = true;
            this.RadioButtonSelect.Location = new System.Drawing.Point( 19, 47 );
            this.RadioButtonSelect.Name = "RadioButtonSelect";
            this.RadioButtonSelect.Size = new System.Drawing.Size( 119, 16 );
            this.RadioButtonSelect.TabIndex = 46;
            this.RadioButtonSelect.Text = "改变扫描起始日为";
            this.RadioButtonSelect.UseVisualStyleBackColor = true;
            // 
            // RadioButtonNow
            // 
            this.RadioButtonNow.AutoSize = true;
            this.RadioButtonNow.Checked = true;
            this.RadioButtonNow.Location = new System.Drawing.Point( 19, 25 );
            this.RadioButtonNow.Name = "RadioButtonNow";
            this.RadioButtonNow.Size = new System.Drawing.Size( 143, 16 );
            this.RadioButtonNow.TabIndex = 45;
            this.RadioButtonNow.TabStop = true;
            this.RadioButtonNow.Text = "选择今天为扫描起始日";
            this.RadioButtonNow.UseVisualStyleBackColor = true;
            // 
            // LabelNow
            // 
            this.LabelNow.Location = new System.Drawing.Point( 168, 27 );
            this.LabelNow.Name = "LabelNow";
            this.LabelNow.Size = new System.Drawing.Size( 127, 14 );
            this.LabelNow.TabIndex = 44;
            // 
            // ScanControlSub2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.DateTimePickerSelect );
            this.Controls.Add( this.RadioButtonSelect );
            this.Controls.Add( this.RadioButtonNow );
            this.Controls.Add( this.LabelNow );
            this.Controls.Add( this.CheckBoxAllowSR );
            this.Name = "ScanControlSub2";
            this.Size = new System.Drawing.Size( 580, 520 );
            this.Load += new System.EventHandler( this.ScanControlSub2_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxAllowSR;
        private System.Windows.Forms.DateTimePicker DateTimePickerSelect;
        private System.Windows.Forms.RadioButton RadioButtonSelect;
        private System.Windows.Forms.RadioButton RadioButtonNow;
        private System.Windows.Forms.Label LabelNow;

    }
}
