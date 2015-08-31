namespace Demo.Stock.X.U50
{
    partial class PolicyCControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PolicyCControl ) );
            this.ComboBoxSelectDateTime = new System.Windows.Forms.ComboBox();
            this.axDatePickerSelectDataTime = new AxXtremeCalendarControl.AxDatePicker();
            this.RadioButtonDataTimeNow = new System.Windows.Forms.RadioButton();
            this.RadioButtonSelectDataTime = new System.Windows.Forms.RadioButton();
            this.GroupBoxKLine = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TrackBarKLineStep = new System.Windows.Forms.TrackBar();
            this.TrackBarKLineStop = new System.Windows.Forms.TrackBar();
            this.NumericUpDownKLineStep = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownKLineStop = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownKLine = new System.Windows.Forms.NumericUpDown();
            this.TrackBarDateTimeKLine = new System.Windows.Forms.TrackBar();
            this.CheckBoxDataTime = new System.Windows.Forms.CheckBox();
            this.CheckBoxKLine = new System.Windows.Forms.CheckBox();
            this.NumericUpDownDataTimeStep = new System.Windows.Forms.NumericUpDown();
            this.axDatePickerDataTimeStop = new AxXtremeCalendarControl.AxDatePicker();
            this.ComboBoxDataTimeStop = new System.Windows.Forms.ComboBox();
            this.TrackBarDataTimeStep = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBoxDataTime = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.CheckBoxDataTimePriority = new System.Windows.Forms.CheckBox();
            this.CheckBoxKLinePriority = new System.Windows.Forms.CheckBox();
            this.LabelDataTimeNow = new System.Windows.Forms.Label();
            this.CheckBoxAllOutput = new System.Windows.Forms.CheckBox();
            this.CheckBoxOneOutput = new System.Windows.Forms.CheckBox();
            ( (System.ComponentModel.ISupportInitialize)( this.axDatePickerSelectDataTime ) ).BeginInit();
            this.GroupBoxKLine.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarKLineStep ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarKLineStop ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLineStep ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLineStop ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLine ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarDateTimeKLine ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownDataTimeStep ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axDatePickerDataTimeStop ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarDataTimeStep ) ).BeginInit();
            this.GroupBoxDataTime.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBoxSelectDateTime
            // 
            this.ComboBoxSelectDateTime.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ComboBoxSelectDateTime.Enabled = false;
            this.ComboBoxSelectDateTime.FormattingEnabled = true;
            this.ComboBoxSelectDateTime.Location = new System.Drawing.Point( 133, 57 );
            this.ComboBoxSelectDateTime.Name = "ComboBoxSelectDateTime";
            this.ComboBoxSelectDateTime.Size = new System.Drawing.Size( 194, 20 );
            this.ComboBoxSelectDateTime.TabIndex = 3;
            this.ComboBoxSelectDateTime.DropDown += new System.EventHandler( this.ComboBoxSelectDateTime_DropDown );
            // 
            // axDatePickerSelectDataTime
            // 
            this.axDatePickerSelectDataTime.Location = new System.Drawing.Point( 200, 86 );
            this.axDatePickerSelectDataTime.Name = "axDatePickerSelectDataTime";
            this.axDatePickerSelectDataTime.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axDatePickerSelectDataTime.OcxState" ) ) );
            this.axDatePickerSelectDataTime.Size = new System.Drawing.Size( 1, 1 );
            this.axDatePickerSelectDataTime.TabIndex = 5;
            // 
            // RadioButtonDataTimeNow
            // 
            this.RadioButtonDataTimeNow.AutoSize = true;
            this.RadioButtonDataTimeNow.Checked = true;
            this.RadioButtonDataTimeNow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonDataTimeNow.Location = new System.Drawing.Point( 3, 35 );
            this.RadioButtonDataTimeNow.Name = "RadioButtonDataTimeNow";
            this.RadioButtonDataTimeNow.Size = new System.Drawing.Size( 149, 17 );
            this.RadioButtonDataTimeNow.TabIndex = 1;
            this.RadioButtonDataTimeNow.TabStop = true;
            this.RadioButtonDataTimeNow.Text = "选择今天为扫描起始日";
            this.RadioButtonDataTimeNow.UseVisualStyleBackColor = true;
            this.RadioButtonDataTimeNow.CheckedChanged += new System.EventHandler( this.RadioButtonDataTimeNow_CheckedChanged );
            // 
            // RadioButtonSelectDataTime
            // 
            this.RadioButtonSelectDataTime.AutoSize = true;
            this.RadioButtonSelectDataTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonSelectDataTime.Location = new System.Drawing.Point( 3, 61 );
            this.RadioButtonSelectDataTime.Name = "RadioButtonSelectDataTime";
            this.RadioButtonSelectDataTime.Size = new System.Drawing.Size( 125, 17 );
            this.RadioButtonSelectDataTime.TabIndex = 2;
            this.RadioButtonSelectDataTime.Text = "改变扫描起始日为";
            this.RadioButtonSelectDataTime.UseVisualStyleBackColor = true;
            this.RadioButtonSelectDataTime.CheckedChanged += new System.EventHandler( this.RadioButtonSelectDataTime_CheckedChanged );
            // 
            // GroupBoxKLine
            // 
            this.GroupBoxKLine.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.GroupBoxKLine.Controls.Add( this.label4 );
            this.GroupBoxKLine.Controls.Add( this.label3 );
            this.GroupBoxKLine.Controls.Add( this.TrackBarKLineStep );
            this.GroupBoxKLine.Controls.Add( this.TrackBarKLineStop );
            this.GroupBoxKLine.Controls.Add( this.NumericUpDownKLineStep );
            this.GroupBoxKLine.Controls.Add( this.NumericUpDownKLineStop );
            this.GroupBoxKLine.Enabled = false;
            this.GroupBoxKLine.Location = new System.Drawing.Point( 3, 277 );
            this.GroupBoxKLine.Name = "GroupBoxKLine";
            this.GroupBoxKLine.Size = new System.Drawing.Size( 324, 106 );
            this.GroupBoxKLine.TabIndex = 11;
            this.GroupBoxKLine.TabStop = false;
            this.GroupBoxKLine.Text = "选择扫描前置的K线数目(向前微调)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 12, 65 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 71, 12 );
            this.label4.TabIndex = 3;
            this.label4.Text = "K线数量上限";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 12, 24 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 71, 12 );
            this.label3.TabIndex = 0;
            this.label3.Text = "K线数量步进";
            // 
            // TrackBarKLineStep
            // 
            this.TrackBarKLineStep.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.TrackBarKLineStep.LargeChange = 1;
            this.TrackBarKLineStep.Location = new System.Drawing.Point( 144, 13 );
            this.TrackBarKLineStep.Name = "TrackBarKLineStep";
            this.TrackBarKLineStep.Size = new System.Drawing.Size( 172, 42 );
            this.TrackBarKLineStep.TabIndex = 2;
            this.TrackBarKLineStep.TickFrequency = 2;
            this.TrackBarKLineStep.Scroll += new System.EventHandler( this.TrackBarKLineStep_Scroll );
            // 
            // TrackBarKLineStop
            // 
            this.TrackBarKLineStop.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.TrackBarKLineStop.Location = new System.Drawing.Point( 143, 57 );
            this.TrackBarKLineStop.Maximum = 200;
            this.TrackBarKLineStop.Minimum = 10;
            this.TrackBarKLineStop.Name = "TrackBarKLineStop";
            this.TrackBarKLineStop.Size = new System.Drawing.Size( 172, 42 );
            this.TrackBarKLineStop.SmallChange = 5;
            this.TrackBarKLineStop.TabIndex = 5;
            this.TrackBarKLineStop.TickFrequency = 10;
            this.TrackBarKLineStop.Value = 10;
            this.TrackBarKLineStop.Scroll += new System.EventHandler( this.TrackBarKLineStop_Scroll );
            // 
            // NumericUpDownKLineStep
            // 
            this.NumericUpDownKLineStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownKLineStep.Location = new System.Drawing.Point( 97, 22 );
            this.NumericUpDownKLineStep.Maximum = new decimal( new int[] {
            10,
            0,
            0,
            0} );
            this.NumericUpDownKLineStep.Name = "NumericUpDownKLineStep";
            this.NumericUpDownKLineStep.Size = new System.Drawing.Size( 46, 21 );
            this.NumericUpDownKLineStep.TabIndex = 1;
            // 
            // NumericUpDownKLineStop
            // 
            this.NumericUpDownKLineStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownKLineStop.Location = new System.Drawing.Point( 97, 63 );
            this.NumericUpDownKLineStop.Maximum = new decimal( new int[] {
            200,
            0,
            0,
            0} );
            this.NumericUpDownKLineStop.Minimum = new decimal( new int[] {
            10,
            0,
            0,
            0} );
            this.NumericUpDownKLineStop.Name = "NumericUpDownKLineStop";
            this.NumericUpDownKLineStop.Size = new System.Drawing.Size( 46, 21 );
            this.NumericUpDownKLineStop.TabIndex = 4;
            this.NumericUpDownKLineStop.Value = new decimal( new int[] {
            10,
            0,
            0,
            0} );
            // 
            // NumericUpDownKLine
            // 
            this.NumericUpDownKLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownKLine.Location = new System.Drawing.Point( 5, 215 );
            this.NumericUpDownKLine.Maximum = new decimal( new int[] {
            1000,
            0,
            0,
            0} );
            this.NumericUpDownKLine.Minimum = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            this.NumericUpDownKLine.Name = "NumericUpDownKLine";
            this.NumericUpDownKLine.Size = new System.Drawing.Size( 46, 21 );
            this.NumericUpDownKLine.TabIndex = 8;
            this.NumericUpDownKLine.Value = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            // 
            // TrackBarDateTimeKLine
            // 
            this.TrackBarDateTimeKLine.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.TrackBarDateTimeKLine.LargeChange = 10;
            this.TrackBarDateTimeKLine.Location = new System.Drawing.Point( 57, 215 );
            this.TrackBarDateTimeKLine.Maximum = 1000;
            this.TrackBarDateTimeKLine.Minimum = 3;
            this.TrackBarDateTimeKLine.Name = "TrackBarDateTimeKLine";
            this.TrackBarDateTimeKLine.Size = new System.Drawing.Size( 270, 42 );
            this.TrackBarDateTimeKLine.SmallChange = 10;
            this.TrackBarDateTimeKLine.TabIndex = 9;
            this.TrackBarDateTimeKLine.TickFrequency = 100;
            this.TrackBarDateTimeKLine.Value = 3;
            this.TrackBarDateTimeKLine.Scroll += new System.EventHandler( this.TrackBarDateTimeKLine_Scroll );
            // 
            // CheckBoxDataTime
            // 
            this.CheckBoxDataTime.AutoSize = true;
            this.CheckBoxDataTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxDataTime.Location = new System.Drawing.Point( 3, 83 );
            this.CheckBoxDataTime.Name = "CheckBoxDataTime";
            this.CheckBoxDataTime.Size = new System.Drawing.Size( 198, 17 );
            this.CheckBoxDataTime.TabIndex = 4;
            this.CheckBoxDataTime.Text = "允许移动扫描(基于扫描起始日)";
            this.CheckBoxDataTime.UseVisualStyleBackColor = true;
            this.CheckBoxDataTime.CheckedChanged += new System.EventHandler( this.CheckBoxDataTime_CheckedChanged );
            // 
            // CheckBoxKLine
            // 
            this.CheckBoxKLine.AutoSize = true;
            this.CheckBoxKLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxKLine.Location = new System.Drawing.Point( 3, 258 );
            this.CheckBoxKLine.Name = "CheckBoxKLine";
            this.CheckBoxKLine.Size = new System.Drawing.Size( 204, 17 );
            this.CheckBoxKLine.TabIndex = 10;
            this.CheckBoxKLine.Text = "允许移动扫描(基于样本K线数量)";
            this.CheckBoxKLine.UseVisualStyleBackColor = true;
            this.CheckBoxKLine.CheckedChanged += new System.EventHandler( this.CheckBoxKLine_CheckedChanged );
            // 
            // NumericUpDownDataTimeStep
            // 
            this.NumericUpDownDataTimeStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownDataTimeStep.Location = new System.Drawing.Point( 91, 20 );
            this.NumericUpDownDataTimeStep.Maximum = new decimal( new int[] {
            10,
            0,
            0,
            0} );
            this.NumericUpDownDataTimeStep.Name = "NumericUpDownDataTimeStep";
            this.NumericUpDownDataTimeStep.Size = new System.Drawing.Size( 46, 21 );
            this.NumericUpDownDataTimeStep.TabIndex = 1;
            // 
            // axDatePickerDataTimeStop
            // 
            this.axDatePickerDataTimeStop.Location = new System.Drawing.Point( 144, 86 );
            this.axDatePickerDataTimeStop.Name = "axDatePickerDataTimeStop";
            this.axDatePickerDataTimeStop.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axDatePickerDataTimeStop.OcxState" ) ) );
            this.axDatePickerDataTimeStop.Size = new System.Drawing.Size( 1, 1 );
            this.axDatePickerDataTimeStop.TabIndex = 5;
            // 
            // ComboBoxDataTimeStop
            // 
            this.ComboBoxDataTimeStop.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ComboBoxDataTimeStop.FormattingEnabled = true;
            this.ComboBoxDataTimeStop.Location = new System.Drawing.Point( 143, 63 );
            this.ComboBoxDataTimeStop.Name = "ComboBoxDataTimeStop";
            this.ComboBoxDataTimeStop.Size = new System.Drawing.Size( 172, 20 );
            this.ComboBoxDataTimeStop.TabIndex = 4;
            this.ComboBoxDataTimeStop.DropDown += new System.EventHandler( this.ComboBoxDataTimeStop_DropDown );
            // 
            // TrackBarDataTimeStep
            // 
            this.TrackBarDataTimeStep.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.TrackBarDataTimeStep.LargeChange = 1;
            this.TrackBarDataTimeStep.Location = new System.Drawing.Point( 143, 15 );
            this.TrackBarDataTimeStep.Name = "TrackBarDataTimeStep";
            this.TrackBarDataTimeStep.Size = new System.Drawing.Size( 172, 42 );
            this.TrackBarDataTimeStep.TabIndex = 2;
            this.TrackBarDataTimeStep.TickFrequency = 2;
            this.TrackBarDataTimeStep.Scroll += new System.EventHandler( this.TrackBarDataTimeStep_Scroll );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12, 66 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 113, 12 );
            this.label1.TabIndex = 3;
            this.label1.Text = "扫描起始日的终止日";
            // 
            // GroupBoxDataTime
            // 
            this.GroupBoxDataTime.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.GroupBoxDataTime.Controls.Add( this.label2 );
            this.GroupBoxDataTime.Controls.Add( this.TrackBarDataTimeStep );
            this.GroupBoxDataTime.Controls.Add( this.ComboBoxDataTimeStop );
            this.GroupBoxDataTime.Controls.Add( this.NumericUpDownDataTimeStep );
            this.GroupBoxDataTime.Controls.Add( this.label1 );
            this.GroupBoxDataTime.Controls.Add( this.axDatePickerDataTimeStop );
            this.GroupBoxDataTime.Enabled = false;
            this.GroupBoxDataTime.Location = new System.Drawing.Point( 3, 105 );
            this.GroupBoxDataTime.Name = "GroupBoxDataTime";
            this.GroupBoxDataTime.Size = new System.Drawing.Size( 324, 92 );
            this.GroupBoxDataTime.TabIndex = 6;
            this.GroupBoxDataTime.TabStop = false;
            this.GroupBoxDataTime.Text = "选择扫描前置日期的数目(向前微调)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 12, 22 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53, 12 );
            this.label2.TabIndex = 0;
            this.label2.Text = "日期步进";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 3, 200 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 107, 12 );
            this.label5.TabIndex = 7;
            this.label5.Text = "扫描的K线数量设置";
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 330, 29 );
            this.axShortcutCaption.TabIndex = 0;
            // 
            // CheckBoxDataTimePriority
            // 
            this.CheckBoxDataTimePriority.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.CheckBoxDataTimePriority.AutoSize = true;
            this.CheckBoxDataTimePriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxDataTimePriority.Location = new System.Drawing.Point( 171, 388 );
            this.CheckBoxDataTimePriority.Name = "CheckBoxDataTimePriority";
            this.CheckBoxDataTimePriority.Size = new System.Drawing.Size( 78, 17 );
            this.CheckBoxDataTimePriority.TabIndex = 6;
            this.CheckBoxDataTimePriority.Text = "日期优先";
            this.CheckBoxDataTimePriority.UseVisualStyleBackColor = true;
            this.CheckBoxDataTimePriority.CheckedChanged += new System.EventHandler( this.CheckBoxDataTimePriority_CheckedChanged );
            // 
            // CheckBoxKLinePriority
            // 
            this.CheckBoxKLinePriority.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.CheckBoxKLinePriority.AutoSize = true;
            this.CheckBoxKLinePriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxKLinePriority.Location = new System.Drawing.Point( 255, 388 );
            this.CheckBoxKLinePriority.Name = "CheckBoxKLinePriority";
            this.CheckBoxKLinePriority.Size = new System.Drawing.Size( 72, 17 );
            this.CheckBoxKLinePriority.TabIndex = 6;
            this.CheckBoxKLinePriority.Text = "K线优先";
            this.CheckBoxKLinePriority.UseVisualStyleBackColor = true;
            this.CheckBoxKLinePriority.CheckedChanged += new System.EventHandler( this.CheckBoxKLinePriority_CheckedChanged );
            // 
            // LabelDataTimeNow
            // 
            this.LabelDataTimeNow.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.LabelDataTimeNow.BackColor = System.Drawing.SystemColors.Control;
            this.LabelDataTimeNow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelDataTimeNow.Location = new System.Drawing.Point( 170, 35 );
            this.LabelDataTimeNow.Name = "LabelDataTimeNow";
            this.LabelDataTimeNow.Size = new System.Drawing.Size( 157, 14 );
            this.LabelDataTimeNow.TabIndex = 26;
            this.LabelDataTimeNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckBoxAllOutput
            // 
            this.CheckBoxAllOutput.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.CheckBoxAllOutput.AutoSize = true;
            this.CheckBoxAllOutput.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxAllOutput.Location = new System.Drawing.Point( 3, 388 );
            this.CheckBoxAllOutput.Name = "CheckBoxAllOutput";
            this.CheckBoxAllOutput.Size = new System.Drawing.Size( 78, 17 );
            this.CheckBoxAllOutput.TabIndex = 6;
            this.CheckBoxAllOutput.Text = "全部输出";
            this.CheckBoxAllOutput.UseVisualStyleBackColor = true;
            this.CheckBoxAllOutput.CheckedChanged += new System.EventHandler( this.CheckBoxAllOutput_CheckedChanged );
            // 
            // CheckBoxOneOutput
            // 
            this.CheckBoxOneOutput.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.CheckBoxOneOutput.AutoSize = true;
            this.CheckBoxOneOutput.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxOneOutput.Location = new System.Drawing.Point( 86, 388 );
            this.CheckBoxOneOutput.Name = "CheckBoxOneOutput";
            this.CheckBoxOneOutput.Size = new System.Drawing.Size( 78, 17 );
            this.CheckBoxOneOutput.TabIndex = 6;
            this.CheckBoxOneOutput.Text = "单次输出";
            this.CheckBoxOneOutput.UseVisualStyleBackColor = true;
            this.CheckBoxOneOutput.CheckedChanged += new System.EventHandler( this.CheckBoxOneOutput_CheckedChanged );
            // 
            // ConfigCControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.LabelDataTimeNow );
            this.Controls.Add( this.CheckBoxKLinePriority );
            this.Controls.Add( this.CheckBoxOneOutput );
            this.Controls.Add( this.CheckBoxAllOutput );
            this.Controls.Add( this.CheckBoxDataTimePriority );
            this.Controls.Add( this.axShortcutCaption );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.GroupBoxDataTime );
            this.Controls.Add( this.NumericUpDownKLine );
            this.Controls.Add( this.TrackBarDateTimeKLine );
            this.Controls.Add( this.GroupBoxKLine );
            this.Controls.Add( this.RadioButtonSelectDataTime );
            this.Controls.Add( this.RadioButtonDataTimeNow );
            this.Controls.Add( this.ComboBoxSelectDateTime );
            this.Controls.Add( this.axDatePickerSelectDataTime );
            this.Controls.Add( this.CheckBoxKLine );
            this.Controls.Add( this.CheckBoxDataTime );
            this.Name = "ConfigCControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            this.Load += new System.EventHandler( this.ConfigCControl_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axDatePickerSelectDataTime ) ).EndInit();
            this.GroupBoxKLine.ResumeLayout( false );
            this.GroupBoxKLine.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarKLineStep ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarKLineStop ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLineStep ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLineStop ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLine ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarDateTimeKLine ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownDataTimeStep ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axDatePickerDataTimeStop ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarDataTimeStep ) ).EndInit();
            this.GroupBoxDataTime.ResumeLayout( false );
            this.GroupBoxDataTime.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxSelectDateTime;
        private AxXtremeCalendarControl.AxDatePicker axDatePickerSelectDataTime;
        private System.Windows.Forms.RadioButton RadioButtonDataTimeNow;
        private System.Windows.Forms.RadioButton RadioButtonSelectDataTime;
        private System.Windows.Forms.GroupBox GroupBoxKLine;
        private System.Windows.Forms.NumericUpDown NumericUpDownKLine;
        private System.Windows.Forms.TrackBar TrackBarDateTimeKLine;
        private System.Windows.Forms.CheckBox CheckBoxDataTime;
        private System.Windows.Forms.CheckBox CheckBoxKLine;
        private System.Windows.Forms.NumericUpDown NumericUpDownDataTimeStep;
        private AxXtremeCalendarControl.AxDatePicker axDatePickerDataTimeStop;
        private System.Windows.Forms.ComboBox ComboBoxDataTimeStop;
        private System.Windows.Forms.TrackBar TrackBarDataTimeStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar TrackBarKLineStep;
        private System.Windows.Forms.NumericUpDown NumericUpDownKLineStep;
        private System.Windows.Forms.TrackBar TrackBarKLineStop;
        private System.Windows.Forms.NumericUpDown NumericUpDownKLineStop;
        private System.Windows.Forms.GroupBox GroupBoxDataTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.CheckBox CheckBoxDataTimePriority;
        private System.Windows.Forms.CheckBox CheckBoxKLinePriority;
        private System.Windows.Forms.Label LabelDataTimeNow;
        private System.Windows.Forms.CheckBox CheckBoxAllOutput;
        private System.Windows.Forms.CheckBox CheckBoxOneOutput;
    }
}
