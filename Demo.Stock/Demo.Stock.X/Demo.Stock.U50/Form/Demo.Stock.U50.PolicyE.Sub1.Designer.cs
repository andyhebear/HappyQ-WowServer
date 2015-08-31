namespace Demo.Stock.X.U50
{
    partial class PolicyEControlSub1
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
            this.RadioButtonAny = new System.Windows.Forms.RadioButton();
            this.NumericUpDownKLine = new System.Windows.Forms.NumericUpDown();
            this.TrackBarKLine = new System.Windows.Forms.TrackBar();
            this.RadioButtonHighNow = new System.Windows.Forms.RadioButton();
            this.RadioButtonHigh = new System.Windows.Forms.RadioButton();
            this.CheckBoxAllow = new System.Windows.Forms.CheckBox();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLine ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarKLine ) ).BeginInit();
            this.SuspendLayout();
            // 
            // RadioButtonAny
            // 
            this.RadioButtonAny.AutoSize = true;
            this.RadioButtonAny.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonAny.Location = new System.Drawing.Point( 18, 26 );
            this.RadioButtonAny.Name = "RadioButtonAny";
            this.RadioButtonAny.Size = new System.Drawing.Size( 77, 17 );
            this.RadioButtonAny.TabIndex = 1;
            this.RadioButtonAny.Text = "任意H1值";
            this.RadioButtonAny.UseVisualStyleBackColor = true;
            this.RadioButtonAny.CheckedChanged += new System.EventHandler( this.RadioButtonAny_CheckedChanged );
            // 
            // NumericUpDownKLine
            // 
            this.NumericUpDownKLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownKLine.Location = new System.Drawing.Point( 18, 113 );
            this.NumericUpDownKLine.Maximum = new decimal( new int[] {
            1000,
            0,
            0,
            0} );
            this.NumericUpDownKLine.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.NumericUpDownKLine.Name = "NumericUpDownKLine";
            this.NumericUpDownKLine.Size = new System.Drawing.Size( 46, 21 );
            this.NumericUpDownKLine.TabIndex = 4;
            this.NumericUpDownKLine.Value = new decimal( new int[] {
            10,
            0,
            0,
            0} );
            // 
            // TrackBarKLine
            // 
            this.TrackBarKLine.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.TrackBarKLine.LargeChange = 10;
            this.TrackBarKLine.Location = new System.Drawing.Point( 67, 113 );
            this.TrackBarKLine.Maximum = 1000;
            this.TrackBarKLine.Minimum = 1;
            this.TrackBarKLine.Name = "TrackBarKLine";
            this.TrackBarKLine.Size = new System.Drawing.Size( 260, 42 );
            this.TrackBarKLine.SmallChange = 10;
            this.TrackBarKLine.TabIndex = 5;
            this.TrackBarKLine.TickFrequency = 100;
            this.TrackBarKLine.Value = 3;
            this.TrackBarKLine.Scroll += new System.EventHandler( this.TrackBarDateTimeKLine_Scroll );
            // 
            // RadioButtonHighNow
            // 
            this.RadioButtonHighNow.AutoSize = true;
            this.RadioButtonHighNow.Checked = true;
            this.RadioButtonHighNow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonHighNow.Location = new System.Drawing.Point( 18, 90 );
            this.RadioButtonHighNow.Name = "RadioButtonHighNow";
            this.RadioButtonHighNow.Size = new System.Drawing.Size( 257, 17 );
            this.RadioButtonHighNow.TabIndex = 3;
            this.RadioButtonHighNow.TabStop = true;
            this.RadioButtonHighNow.Text = "是过去多少个交易日内的最高价(相对今天)";
            this.RadioButtonHighNow.UseVisualStyleBackColor = true;
            this.RadioButtonHighNow.CheckedChanged += new System.EventHandler( this.RadioButtonHighNow_CheckedChanged );
            // 
            // RadioButtonHigh
            // 
            this.RadioButtonHigh.AutoSize = true;
            this.RadioButtonHigh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonHigh.Location = new System.Drawing.Point( 18, 58 );
            this.RadioButtonHigh.Name = "RadioButtonHigh";
            this.RadioButtonHigh.Size = new System.Drawing.Size( 143, 17 );
            this.RadioButtonHigh.TabIndex = 2;
            this.RadioButtonHigh.Text = "是U50形态中的最高价";
            this.RadioButtonHigh.UseVisualStyleBackColor = true;
            this.RadioButtonHigh.CheckedChanged += new System.EventHandler( this.RadioButtonHigh_CheckedChanged );
            // 
            // CheckBoxAllow
            // 
            this.CheckBoxAllow.AutoSize = true;
            this.CheckBoxAllow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxAllow.Location = new System.Drawing.Point( 3, 3 );
            this.CheckBoxAllow.Name = "CheckBoxAllow";
            this.CheckBoxAllow.Size = new System.Drawing.Size( 126, 17 );
            this.CheckBoxAllow.TabIndex = 0;
            this.CheckBoxAllow.Text = "H1的价格数据选项";
            this.CheckBoxAllow.UseVisualStyleBackColor = true;
            this.CheckBoxAllow.CheckedChanged += new System.EventHandler( this.CheckBoxAllow_CheckedChanged );
            // 
            // ConfigEControlSub1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.CheckBoxAllow );
            this.Controls.Add( this.RadioButtonAny );
            this.Controls.Add( this.NumericUpDownKLine );
            this.Controls.Add( this.TrackBarKLine );
            this.Controls.Add( this.RadioButtonHighNow );
            this.Controls.Add( this.RadioButtonHigh );
            this.Name = "ConfigEControlSub1";
            this.Size = new System.Drawing.Size( 330, 345 );
            this.Load += new System.EventHandler( this.ConfigEControlSub1_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLine ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarKLine ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton RadioButtonAny;
        public System.Windows.Forms.NumericUpDown NumericUpDownKLine;
        public System.Windows.Forms.TrackBar TrackBarKLine;
        public System.Windows.Forms.RadioButton RadioButtonHighNow;
        public System.Windows.Forms.RadioButton RadioButtonHigh;
        public System.Windows.Forms.CheckBox CheckBoxAllow;
    }
}
