namespace Demo.Stock.LHP
{
    partial class ScanUpControlSub1
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
            this.GroupBoxDCLP = new System.Windows.Forms.GroupBox();
            this.RadioButtonDCLPAnyOne = new System.Windows.Forms.RadioButton();
            this.ListBoxDCLPSelect = new System.Windows.Forms.ListBox();
            this.ListBoxDCLP = new System.Windows.Forms.ListBox();
            this.RadioButtonDCLPOr = new System.Windows.Forms.RadioButton();
            this.ButtonDCLPUp = new System.Windows.Forms.Button();
            this.ButtonDCLPDown = new System.Windows.Forms.Button();
            this.GroupBoxDCHP = new System.Windows.Forms.GroupBox();
            this.RadioButtonDCHPAnyOne = new System.Windows.Forms.RadioButton();
            this.ListBoxDCHP = new System.Windows.Forms.ListBox();
            this.ListBoxDCHPSelect = new System.Windows.Forms.ListBox();
            this.RadioButtonDCHPOr = new System.Windows.Forms.RadioButton();
            this.ButtonDCHPUp = new System.Windows.Forms.Button();
            this.ButtonDCHPDown = new System.Windows.Forms.Button();
            this.NumericUpDownUpDay = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxAllowDCHP = new System.Windows.Forms.CheckBox();
            this.CheckBoxAllowDCLP = new System.Windows.Forms.CheckBox();
            this.CheckBoxHighPirce = new System.Windows.Forms.CheckBox();
            this.LabelDateNow = new System.Windows.Forms.Label();
            this.LabelKLineNumber = new System.Windows.Forms.Label();
            this.NumericUpDownKLineNumber = new System.Windows.Forms.NumericUpDown();
            this.LabelDateNowInfo = new System.Windows.Forms.Label();
            this.CheckBoxUpDay = new System.Windows.Forms.CheckBox();
            this.GroupBoxDCLP.SuspendLayout();
            this.GroupBoxDCHP.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownUpDay ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLineNumber ) ).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxDCLP
            // 
            this.GroupBoxDCLP.Controls.Add( this.RadioButtonDCLPAnyOne );
            this.GroupBoxDCLP.Controls.Add( this.ListBoxDCLPSelect );
            this.GroupBoxDCLP.Controls.Add( this.ListBoxDCLP );
            this.GroupBoxDCLP.Controls.Add( this.RadioButtonDCLPOr );
            this.GroupBoxDCLP.Controls.Add( this.ButtonDCLPUp );
            this.GroupBoxDCLP.Controls.Add( this.ButtonDCLPDown );
            this.GroupBoxDCLP.Location = new System.Drawing.Point( 5, 176 );
            this.GroupBoxDCLP.Name = "GroupBoxDCLP";
            this.GroupBoxDCLP.Size = new System.Drawing.Size( 106, 237 );
            this.GroupBoxDCLP.TabIndex = 117;
            this.GroupBoxDCLP.TabStop = false;
            this.GroupBoxDCLP.Text = "DCLP设置";
            // 
            // RadioButtonDCLPAnyOne
            // 
            this.RadioButtonDCLPAnyOne.AutoSize = true;
            this.RadioButtonDCLPAnyOne.Checked = true;
            this.RadioButtonDCLPAnyOne.Location = new System.Drawing.Point( 6, 19 );
            this.RadioButtonDCLPAnyOne.Name = "RadioButtonDCLPAnyOne";
            this.RadioButtonDCLPAnyOne.Size = new System.Drawing.Size( 59, 16 );
            this.RadioButtonDCLPAnyOne.TabIndex = 97;
            this.RadioButtonDCLPAnyOne.TabStop = true;
            this.RadioButtonDCLPAnyOne.Text = "任意值";
            this.RadioButtonDCLPAnyOne.UseVisualStyleBackColor = true;
            this.RadioButtonDCLPAnyOne.CheckedChanged += new System.EventHandler( this.RadioButtonDCLPAnyOne_CheckedChanged );
            // 
            // ListBoxDCLPSelect
            // 
            this.ListBoxDCLPSelect.FormattingEnabled = true;
            this.ListBoxDCLPSelect.ItemHeight = 12;
            this.ListBoxDCLPSelect.Items.AddRange( new object[] {
            "DCLP-313",
            "DCLP-214",
            "DCLP-115",
            "DCLP-412",
            "DCLP-511"} );
            this.ListBoxDCLPSelect.Location = new System.Drawing.Point( 6, 63 );
            this.ListBoxDCLPSelect.Name = "ListBoxDCLPSelect";
            this.ListBoxDCLPSelect.Size = new System.Drawing.Size( 90, 64 );
            this.ListBoxDCLPSelect.TabIndex = 96;
            // 
            // ListBoxDCLP
            // 
            this.ListBoxDCLP.FormattingEnabled = true;
            this.ListBoxDCLP.ItemHeight = 12;
            this.ListBoxDCLP.Location = new System.Drawing.Point( 6, 162 );
            this.ListBoxDCLP.Name = "ListBoxDCLP";
            this.ListBoxDCLP.Size = new System.Drawing.Size( 90, 64 );
            this.ListBoxDCLP.TabIndex = 94;
            // 
            // RadioButtonDCLPOr
            // 
            this.RadioButtonDCLPOr.AutoSize = true;
            this.RadioButtonDCLPOr.Location = new System.Drawing.Point( 6, 41 );
            this.RadioButtonDCLPOr.Name = "RadioButtonDCLPOr";
            this.RadioButtonDCLPOr.Size = new System.Drawing.Size( 35, 16 );
            this.RadioButtonDCLPOr.TabIndex = 98;
            this.RadioButtonDCLPOr.Text = "或";
            this.RadioButtonDCLPOr.UseVisualStyleBackColor = true;
            this.RadioButtonDCLPOr.CheckedChanged += new System.EventHandler( this.RadioButtonDCLPOr_CheckedChanged );
            // 
            // ButtonDCLPUp
            // 
            this.ButtonDCLPUp.Location = new System.Drawing.Point( 42, 133 );
            this.ButtonDCLPUp.Name = "ButtonDCLPUp";
            this.ButtonDCLPUp.Size = new System.Drawing.Size( 24, 23 );
            this.ButtonDCLPUp.TabIndex = 103;
            this.ButtonDCLPUp.Text = "↑";
            this.ButtonDCLPUp.UseVisualStyleBackColor = true;
            this.ButtonDCLPUp.Click += new System.EventHandler( this.ButtonDCLPUp_Click );
            // 
            // ButtonDCLPDown
            // 
            this.ButtonDCLPDown.Location = new System.Drawing.Point( 72, 133 );
            this.ButtonDCLPDown.Name = "ButtonDCLPDown";
            this.ButtonDCLPDown.Size = new System.Drawing.Size( 24, 23 );
            this.ButtonDCLPDown.TabIndex = 104;
            this.ButtonDCLPDown.Text = "↓";
            this.ButtonDCLPDown.UseVisualStyleBackColor = true;
            this.ButtonDCLPDown.Click += new System.EventHandler( this.ButtonDCLPDown_Click );
            // 
            // GroupBoxDCHP
            // 
            this.GroupBoxDCHP.Controls.Add( this.RadioButtonDCHPAnyOne );
            this.GroupBoxDCHP.Controls.Add( this.ListBoxDCHP );
            this.GroupBoxDCHP.Controls.Add( this.ListBoxDCHPSelect );
            this.GroupBoxDCHP.Controls.Add( this.RadioButtonDCHPOr );
            this.GroupBoxDCHP.Controls.Add( this.ButtonDCHPUp );
            this.GroupBoxDCHP.Controls.Add( this.ButtonDCHPDown );
            this.GroupBoxDCHP.Location = new System.Drawing.Point( 236, 176 );
            this.GroupBoxDCHP.Name = "GroupBoxDCHP";
            this.GroupBoxDCHP.Size = new System.Drawing.Size( 105, 237 );
            this.GroupBoxDCHP.TabIndex = 116;
            this.GroupBoxDCHP.TabStop = false;
            this.GroupBoxDCHP.Text = "DCHP设置";
            // 
            // RadioButtonDCHPAnyOne
            // 
            this.RadioButtonDCHPAnyOne.AutoSize = true;
            this.RadioButtonDCHPAnyOne.Checked = true;
            this.RadioButtonDCHPAnyOne.Location = new System.Drawing.Point( 6, 20 );
            this.RadioButtonDCHPAnyOne.Name = "RadioButtonDCHPAnyOne";
            this.RadioButtonDCHPAnyOne.Size = new System.Drawing.Size( 59, 16 );
            this.RadioButtonDCHPAnyOne.TabIndex = 99;
            this.RadioButtonDCHPAnyOne.TabStop = true;
            this.RadioButtonDCHPAnyOne.Text = "任意值";
            this.RadioButtonDCHPAnyOne.UseVisualStyleBackColor = true;
            this.RadioButtonDCHPAnyOne.CheckedChanged += new System.EventHandler( this.RadioButtonDCHPAnyOne_CheckedChanged );
            // 
            // ListBoxDCHP
            // 
            this.ListBoxDCHP.FormattingEnabled = true;
            this.ListBoxDCHP.ItemHeight = 12;
            this.ListBoxDCHP.Location = new System.Drawing.Point( 6, 162 );
            this.ListBoxDCHP.Name = "ListBoxDCHP";
            this.ListBoxDCHP.Size = new System.Drawing.Size( 90, 64 );
            this.ListBoxDCHP.TabIndex = 95;
            // 
            // ListBoxDCHPSelect
            // 
            this.ListBoxDCHPSelect.FormattingEnabled = true;
            this.ListBoxDCHPSelect.ItemHeight = 12;
            this.ListBoxDCHPSelect.Items.AddRange( new object[] {
            "DCHP-313",
            "DCHP-214",
            "DCHP-115",
            "DCHP-412",
            "DCHP-511"} );
            this.ListBoxDCHPSelect.Location = new System.Drawing.Point( 6, 63 );
            this.ListBoxDCHPSelect.Name = "ListBoxDCHPSelect";
            this.ListBoxDCHPSelect.Size = new System.Drawing.Size( 90, 64 );
            this.ListBoxDCHPSelect.TabIndex = 93;
            // 
            // RadioButtonDCHPOr
            // 
            this.RadioButtonDCHPOr.AutoSize = true;
            this.RadioButtonDCHPOr.Location = new System.Drawing.Point( 6, 42 );
            this.RadioButtonDCHPOr.Name = "RadioButtonDCHPOr";
            this.RadioButtonDCHPOr.Size = new System.Drawing.Size( 35, 16 );
            this.RadioButtonDCHPOr.TabIndex = 100;
            this.RadioButtonDCHPOr.Text = "或";
            this.RadioButtonDCHPOr.UseVisualStyleBackColor = true;
            this.RadioButtonDCHPOr.CheckedChanged += new System.EventHandler( this.RadioButtonDCHPOr_CheckedChanged );
            // 
            // ButtonDCHPUp
            // 
            this.ButtonDCHPUp.Location = new System.Drawing.Point( 42, 133 );
            this.ButtonDCHPUp.Name = "ButtonDCHPUp";
            this.ButtonDCHPUp.Size = new System.Drawing.Size( 24, 23 );
            this.ButtonDCHPUp.TabIndex = 102;
            this.ButtonDCHPUp.Text = "↑";
            this.ButtonDCHPUp.UseVisualStyleBackColor = true;
            this.ButtonDCHPUp.Click += new System.EventHandler( this.ButtonDCHPUp_Click );
            // 
            // ButtonDCHPDown
            // 
            this.ButtonDCHPDown.Location = new System.Drawing.Point( 72, 133 );
            this.ButtonDCHPDown.Name = "ButtonDCHPDown";
            this.ButtonDCHPDown.Size = new System.Drawing.Size( 24, 23 );
            this.ButtonDCHPDown.TabIndex = 101;
            this.ButtonDCHPDown.Text = "↓";
            this.ButtonDCHPDown.UseVisualStyleBackColor = true;
            this.ButtonDCHPDown.Click += new System.EventHandler( this.ButtonDCHPDown_Click );
            // 
            // NumericUpDownUpDay
            // 
            this.NumericUpDownUpDay.Location = new System.Drawing.Point( 119, 63 );
            this.NumericUpDownUpDay.Name = "NumericUpDownUpDay";
            this.NumericUpDownUpDay.Size = new System.Drawing.Size( 60, 21 );
            this.NumericUpDownUpDay.TabIndex = 113;
            // 
            // CheckBoxAllowDCHP
            // 
            this.CheckBoxAllowDCHP.AutoSize = true;
            this.CheckBoxAllowDCHP.Checked = true;
            this.CheckBoxAllowDCHP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAllowDCHP.Location = new System.Drawing.Point( 236, 154 );
            this.CheckBoxAllowDCHP.Name = "CheckBoxAllowDCHP";
            this.CheckBoxAllowDCHP.Size = new System.Drawing.Size( 174, 16 );
            this.CheckBoxAllowDCHP.TabIndex = 110;
            this.CheckBoxAllowDCHP.Text = "在样本K线内必须排斥的DCHP";
            this.CheckBoxAllowDCHP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxAllowDCHP.UseVisualStyleBackColor = true;
            this.CheckBoxAllowDCHP.CheckedChanged += new System.EventHandler( this.CheckBoxAllowDCHP_CheckedChanged );
            // 
            // CheckBoxAllowDCLP
            // 
            this.CheckBoxAllowDCLP.AutoSize = true;
            this.CheckBoxAllowDCLP.Checked = true;
            this.CheckBoxAllowDCLP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAllowDCLP.Location = new System.Drawing.Point( 5, 154 );
            this.CheckBoxAllowDCLP.Name = "CheckBoxAllowDCLP";
            this.CheckBoxAllowDCLP.Size = new System.Drawing.Size( 174, 16 );
            this.CheckBoxAllowDCLP.TabIndex = 111;
            this.CheckBoxAllowDCLP.Text = "在样本K线内必须出现的DCLP";
            this.CheckBoxAllowDCLP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxAllowDCLP.UseVisualStyleBackColor = true;
            this.CheckBoxAllowDCLP.CheckedChanged += new System.EventHandler( this.CheckBoxAllowDCLP_CheckedChanged );
            // 
            // CheckBoxHighPirce
            // 
            this.CheckBoxHighPirce.AutoSize = true;
            this.CheckBoxHighPirce.Location = new System.Drawing.Point( 5, 95 );
            this.CheckBoxHighPirce.Name = "CheckBoxHighPirce";
            this.CheckBoxHighPirce.Size = new System.Drawing.Size( 288, 16 );
            this.CheckBoxHighPirce.TabIndex = 112;
            this.CheckBoxHighPirce.Text = "是否要求当前K线的最高价是样本K线中的最高价？";
            this.CheckBoxHighPirce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxHighPirce.UseVisualStyleBackColor = true;
            // 
            // LabelDateNow
            // 
            this.LabelDateNow.Location = new System.Drawing.Point( 74, 5 );
            this.LabelDateNow.Name = "LabelDateNow";
            this.LabelDateNow.Size = new System.Drawing.Size( 127, 14 );
            this.LabelDateNow.TabIndex = 120;
            // 
            // LabelKLineNumber
            // 
            this.LabelKLineNumber.AutoSize = true;
            this.LabelKLineNumber.Location = new System.Drawing.Point( 3, 35 );
            this.LabelKLineNumber.Name = "LabelKLineNumber";
            this.LabelKLineNumber.Size = new System.Drawing.Size( 227, 12 );
            this.LabelKLineNumber.TabIndex = 119;
            this.LabelKLineNumber.Text = "趋势分析(上升)样本K线数目( 3 - 1000 )";
            // 
            // NumericUpDownKLineNumber
            // 
            this.NumericUpDownKLineNumber.Location = new System.Drawing.Point( 236, 33 );
            this.NumericUpDownKLineNumber.Maximum = new decimal( new int[] {
            1000,
            0,
            0,
            0} );
            this.NumericUpDownKLineNumber.Minimum = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            this.NumericUpDownKLineNumber.Name = "NumericUpDownKLineNumber";
            this.NumericUpDownKLineNumber.Size = new System.Drawing.Size( 45, 21 );
            this.NumericUpDownKLineNumber.TabIndex = 118;
            this.NumericUpDownKLineNumber.Value = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            // 
            // LabelDateNowInfo
            // 
            this.LabelDateNowInfo.AutoSize = true;
            this.LabelDateNowInfo.Location = new System.Drawing.Point( 3, 5 );
            this.LabelDateNowInfo.Name = "LabelDateNowInfo";
            this.LabelDateNowInfo.Size = new System.Drawing.Size( 65, 12 );
            this.LabelDateNowInfo.TabIndex = 122;
            this.LabelDateNowInfo.Text = "扫描起始日";
            // 
            // CheckBoxUpDay
            // 
            this.CheckBoxUpDay.AutoSize = true;
            this.CheckBoxUpDay.Location = new System.Drawing.Point( 5, 64 );
            this.CheckBoxUpDay.Name = "CheckBoxUpDay";
            this.CheckBoxUpDay.Size = new System.Drawing.Size( 108, 16 );
            this.CheckBoxUpDay.TabIndex = 123;
            this.CheckBoxUpDay.Text = "需连续上升天数";
            this.CheckBoxUpDay.UseVisualStyleBackColor = true;
            this.CheckBoxUpDay.CheckedChanged += new System.EventHandler( this.CheckBoxUpDay_CheckedChanged );
            // 
            // ScanUpControlSub1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.CheckBoxUpDay );
            this.Controls.Add( this.LabelDateNowInfo );
            this.Controls.Add( this.LabelDateNow );
            this.Controls.Add( this.LabelKLineNumber );
            this.Controls.Add( this.NumericUpDownKLineNumber );
            this.Controls.Add( this.GroupBoxDCLP );
            this.Controls.Add( this.GroupBoxDCHP );
            this.Controls.Add( this.NumericUpDownUpDay );
            this.Controls.Add( this.CheckBoxAllowDCHP );
            this.Controls.Add( this.CheckBoxAllowDCLP );
            this.Controls.Add( this.CheckBoxHighPirce );
            this.Name = "ScanUpControlSub1";
            this.Size = new System.Drawing.Size( 580, 520 );
            this.Load += new System.EventHandler( this.ScanUpControlSub1_Load );
            this.GroupBoxDCLP.ResumeLayout( false );
            this.GroupBoxDCLP.PerformLayout();
            this.GroupBoxDCHP.ResumeLayout( false );
            this.GroupBoxDCHP.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownUpDay ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLineNumber ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxDCLP;
        private System.Windows.Forms.RadioButton RadioButtonDCLPAnyOne;
        private System.Windows.Forms.ListBox ListBoxDCLPSelect;
        private System.Windows.Forms.ListBox ListBoxDCLP;
        private System.Windows.Forms.RadioButton RadioButtonDCLPOr;
        private System.Windows.Forms.Button ButtonDCLPUp;
        private System.Windows.Forms.Button ButtonDCLPDown;
        private System.Windows.Forms.GroupBox GroupBoxDCHP;
        private System.Windows.Forms.RadioButton RadioButtonDCHPAnyOne;
        private System.Windows.Forms.ListBox ListBoxDCHP;
        private System.Windows.Forms.ListBox ListBoxDCHPSelect;
        private System.Windows.Forms.RadioButton RadioButtonDCHPOr;
        private System.Windows.Forms.Button ButtonDCHPUp;
        private System.Windows.Forms.Button ButtonDCHPDown;
        private System.Windows.Forms.NumericUpDown NumericUpDownUpDay;
        private System.Windows.Forms.CheckBox CheckBoxAllowDCHP;
        private System.Windows.Forms.CheckBox CheckBoxAllowDCLP;
        private System.Windows.Forms.CheckBox CheckBoxHighPirce;
        private System.Windows.Forms.Label LabelDateNow;
        private System.Windows.Forms.Label LabelKLineNumber;
        private System.Windows.Forms.NumericUpDown NumericUpDownKLineNumber;
        private System.Windows.Forms.Label LabelDateNowInfo;
        private System.Windows.Forms.CheckBox CheckBoxUpDay;
    }
}
