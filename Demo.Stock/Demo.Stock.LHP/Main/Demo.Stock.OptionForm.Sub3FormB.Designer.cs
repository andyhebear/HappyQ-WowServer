namespace Demo.Stock.LHP.Main
{
    partial class OptionControlSub3FromB
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
            this.CheckBoxTrigger = new System.Windows.Forms.CheckBox();
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.checkBoxRun = new System.Windows.Forms.CheckBox();
            this.checkBoxSpace = new System.Windows.Forms.CheckBox();
            this.checkBoxEnd = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.labelSpace = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBoxTask = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.dateTimePickerTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.RadioButtonDay = new System.Windows.Forms.RadioButton();
            this.RadioButtonMonth = new System.Windows.Forms.RadioButton();
            this.RadioButtonWeek = new System.Windows.Forms.RadioButton();
            this.RadioButtonOne = new System.Windows.Forms.RadioButton();
            this.comboBoxTask = new System.Windows.Forms.ComboBox();
            this.labelTask = new System.Windows.Forms.Label();
            this.dateTimePickerRun = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSpaceTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSpace = new System.Windows.Forms.DateTimePicker();
            this.groupBoxSetting.SuspendLayout();
            this.groupBoxTask.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxTrigger
            // 
            this.CheckBoxTrigger.AutoSize = true;
            this.CheckBoxTrigger.Location = new System.Drawing.Point( 3, 14 );
            this.CheckBoxTrigger.Name = "CheckBoxTrigger";
            this.CheckBoxTrigger.Size = new System.Drawing.Size( 84, 16 );
            this.CheckBoxTrigger.TabIndex = 0;
            this.CheckBoxTrigger.Text = "启用触发器";
            this.CheckBoxTrigger.UseVisualStyleBackColor = true;
            this.CheckBoxTrigger.CheckedChanged += new System.EventHandler( this.CheckBoxTrigger_CheckedChanged );
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Controls.Add( this.dateTimePickerSpace );
            this.groupBoxSetting.Controls.Add( this.dateTimePickerSpaceTime );
            this.groupBoxSetting.Controls.Add( this.dateTimePickerRun );
            this.groupBoxSetting.Controls.Add( this.checkBoxRun );
            this.groupBoxSetting.Controls.Add( this.checkBoxSpace );
            this.groupBoxSetting.Controls.Add( this.checkBoxEnd );
            this.groupBoxSetting.Controls.Add( this.dateTimePickerTimeEnd );
            this.groupBoxSetting.Controls.Add( this.labelSpace );
            this.groupBoxSetting.Controls.Add( this.dateTimePickerEnd );
            this.groupBoxSetting.Location = new System.Drawing.Point( 3, 406 );
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size( 450, 109 );
            this.groupBoxSetting.TabIndex = 4;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "高级设置";
            // 
            // checkBoxRun
            // 
            this.checkBoxRun.AutoSize = true;
            this.checkBoxRun.Location = new System.Drawing.Point( 12, 50 );
            this.checkBoxRun.Name = "checkBoxRun";
            this.checkBoxRun.Size = new System.Drawing.Size( 204, 16 );
            this.checkBoxRun.TabIndex = 3;
            this.checkBoxRun.Text = "运行时间超过以下时间时停止任务";
            this.checkBoxRun.UseVisualStyleBackColor = true;
            this.checkBoxRun.CheckedChanged += new System.EventHandler( this.checkBoxRun_CheckedChanged );
            // 
            // checkBoxSpace
            // 
            this.checkBoxSpace.AutoSize = true;
            this.checkBoxSpace.Location = new System.Drawing.Point( 12, 20 );
            this.checkBoxSpace.Name = "checkBoxSpace";
            this.checkBoxSpace.Size = new System.Drawing.Size( 96, 16 );
            this.checkBoxSpace.TabIndex = 0;
            this.checkBoxSpace.Text = "重复任务间隔";
            this.checkBoxSpace.UseVisualStyleBackColor = true;
            this.checkBoxSpace.CheckedChanged += new System.EventHandler( this.checkBoxSpace_CheckedChanged );
            // 
            // checkBoxEnd
            // 
            this.checkBoxEnd.AutoSize = true;
            this.checkBoxEnd.Location = new System.Drawing.Point( 12, 80 );
            this.checkBoxEnd.Name = "checkBoxEnd";
            this.checkBoxEnd.Size = new System.Drawing.Size( 72, 16 );
            this.checkBoxEnd.TabIndex = 5;
            this.checkBoxEnd.Text = "过期日期";
            this.checkBoxEnd.UseVisualStyleBackColor = true;
            this.checkBoxEnd.CheckedChanged += new System.EventHandler( this.checkBoxEnd_CheckedChanged );
            // 
            // dateTimePickerTimeEnd
            // 
            this.dateTimePickerTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTimeEnd.Location = new System.Drawing.Point( 217, 74 );
            this.dateTimePickerTimeEnd.Name = "dateTimePickerTimeEnd";
            this.dateTimePickerTimeEnd.ShowUpDown = true;
            this.dateTimePickerTimeEnd.Size = new System.Drawing.Size( 82, 21 );
            this.dateTimePickerTimeEnd.TabIndex = 7;
            // 
            // labelSpace
            // 
            this.labelSpace.AutoSize = true;
            this.labelSpace.Location = new System.Drawing.Point( 196, 18 );
            this.labelSpace.Name = "labelSpace";
            this.labelSpace.Size = new System.Drawing.Size( 53, 12 );
            this.labelSpace.TabIndex = 0;
            this.labelSpace.Text = "持续时间";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point( 85, 75 );
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size( 126, 21 );
            this.dateTimePickerEnd.TabIndex = 6;
            // 
            // groupBoxTask
            // 
            this.groupBoxTask.Controls.Add( this.label2 );
            this.groupBoxTask.Controls.Add( this.panel1 );
            this.groupBoxTask.Controls.Add( this.RadioButtonDay );
            this.groupBoxTask.Controls.Add( this.RadioButtonMonth );
            this.groupBoxTask.Controls.Add( this.RadioButtonWeek );
            this.groupBoxTask.Controls.Add( this.RadioButtonOne );
            this.groupBoxTask.Location = new System.Drawing.Point( 15, 65 );
            this.groupBoxTask.Name = "groupBoxTask";
            this.groupBoxTask.Size = new System.Drawing.Size( 438, 217 );
            this.groupBoxTask.TabIndex = 3;
            this.groupBoxTask.TabStop = false;
            this.groupBoxTask.Text = "设置任务";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point( 59, 13 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 2, 202 );
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.groupBoxInfo );
            this.panel1.Controls.Add( this.dateTimePickerTimeBegin );
            this.panel1.Controls.Add( this.dateTimePickerBegin );
            this.panel1.Controls.Add( this.label3 );
            this.panel1.Location = new System.Drawing.Point( 67, 13 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 359, 198 );
            this.panel1.TabIndex = 1;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add( this.panelInfo );
            this.groupBoxInfo.Location = new System.Drawing.Point( 6, 30 );
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size( 347, 165 );
            this.groupBoxInfo.TabIndex = 3;
            this.groupBoxInfo.TabStop = false;
            // 
            // panelInfo
            // 
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point( 3, 17 );
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size( 341, 145 );
            this.panelInfo.TabIndex = 0;
            // 
            // DateTimePickerTimeBegin
            // 
            this.dateTimePickerTimeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTimeBegin.Location = new System.Drawing.Point( 195, 3 );
            this.dateTimePickerTimeBegin.Name = "DateTimePickerTimeBegin";
            this.dateTimePickerTimeBegin.ShowUpDown = true;
            this.dateTimePickerTimeBegin.Size = new System.Drawing.Size( 82, 21 );
            this.dateTimePickerTimeBegin.TabIndex = 1;
            // 
            // dateTimePickerBegin
            // 
            this.dateTimePickerBegin.Location = new System.Drawing.Point( 63, 3 );
            this.dateTimePickerBegin.Name = "dateTimePickerBegin";
            this.dateTimePickerBegin.Size = new System.Drawing.Size( 126, 21 );
            this.dateTimePickerBegin.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 4, 8 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 53, 12 );
            this.label3.TabIndex = 0;
            this.label3.Text = "开始日期";
            // 
            // RadioButtonDay
            // 
            this.RadioButtonDay.AutoSize = true;
            this.RadioButtonDay.Location = new System.Drawing.Point( 6, 51 );
            this.RadioButtonDay.Name = "RadioButtonDay";
            this.RadioButtonDay.Size = new System.Drawing.Size( 47, 16 );
            this.RadioButtonDay.TabIndex = 1;
            this.RadioButtonDay.Text = "每天";
            this.RadioButtonDay.UseVisualStyleBackColor = true;
            this.RadioButtonDay.CheckedChanged += new System.EventHandler( this.RadioButtonDay_CheckedChanged );
            // 
            // RadioButtonMonth
            // 
            this.RadioButtonMonth.AutoSize = true;
            this.RadioButtonMonth.Location = new System.Drawing.Point( 6, 113 );
            this.RadioButtonMonth.Name = "RadioButtonMonth";
            this.RadioButtonMonth.Size = new System.Drawing.Size( 47, 16 );
            this.RadioButtonMonth.TabIndex = 3;
            this.RadioButtonMonth.Text = "每月";
            this.RadioButtonMonth.UseVisualStyleBackColor = true;
            this.RadioButtonMonth.CheckedChanged += new System.EventHandler( this.RadioButtonMonth_CheckedChanged );
            // 
            // RadioButtonWeek
            // 
            this.RadioButtonWeek.AutoSize = true;
            this.RadioButtonWeek.Location = new System.Drawing.Point( 6, 82 );
            this.RadioButtonWeek.Name = "RadioButtonWeek";
            this.RadioButtonWeek.Size = new System.Drawing.Size( 47, 16 );
            this.RadioButtonWeek.TabIndex = 2;
            this.RadioButtonWeek.Text = "每周";
            this.RadioButtonWeek.UseVisualStyleBackColor = true;
            this.RadioButtonWeek.CheckedChanged += new System.EventHandler( this.RadioButtonWeek_CheckedChanged );
            // 
            // RadioButtonOne
            // 
            this.RadioButtonOne.AutoSize = true;
            this.RadioButtonOne.Checked = true;
            this.RadioButtonOne.Location = new System.Drawing.Point( 6, 20 );
            this.RadioButtonOne.Name = "RadioButtonOne";
            this.RadioButtonOne.Size = new System.Drawing.Size( 47, 16 );
            this.RadioButtonOne.TabIndex = 0;
            this.RadioButtonOne.TabStop = true;
            this.RadioButtonOne.Text = "一次";
            this.RadioButtonOne.UseVisualStyleBackColor = true;
            this.RadioButtonOne.CheckedChanged += new System.EventHandler( this.RadioButtonOne_CheckedChanged );
            // 
            // comboBoxTask
            // 
            this.comboBoxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTask.FormattingEnabled = true;
            this.comboBoxTask.Items.AddRange( new object[] {
            "用户自定义"} );
            this.comboBoxTask.Location = new System.Drawing.Point( 72, 39 );
            this.comboBoxTask.Name = "comboBoxTask";
            this.comboBoxTask.Size = new System.Drawing.Size( 121, 20 );
            this.comboBoxTask.TabIndex = 1;
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.Location = new System.Drawing.Point( 13, 42 );
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size( 53, 12 );
            this.labelTask.TabIndex = 2;
            this.labelTask.Text = "开始任务";
            // 
            // dateTimePickerRun
            // 
            this.dateTimePickerRun.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerRun.Location = new System.Drawing.Point( 217, 45 );
            this.dateTimePickerRun.Name = "dateTimePickerRun";
            this.dateTimePickerRun.ShowUpDown = true;
            this.dateTimePickerRun.Size = new System.Drawing.Size( 82, 21 );
            this.dateTimePickerRun.TabIndex = 8;
            // 
            // dateTimePickerSpaceTime
            // 
            this.dateTimePickerSpaceTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerSpaceTime.Location = new System.Drawing.Point( 255, 15 );
            this.dateTimePickerSpaceTime.Name = "dateTimePickerSpaceTime";
            this.dateTimePickerSpaceTime.ShowUpDown = true;
            this.dateTimePickerSpaceTime.Size = new System.Drawing.Size( 82, 21 );
            this.dateTimePickerSpaceTime.TabIndex = 9;
            // 
            // dateTimePickerSpace
            // 
            this.dateTimePickerSpace.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerSpace.Location = new System.Drawing.Point( 108, 15 );
            this.dateTimePickerSpace.Name = "dateTimePickerSpace";
            this.dateTimePickerSpace.ShowUpDown = true;
            this.dateTimePickerSpace.Size = new System.Drawing.Size( 82, 21 );
            this.dateTimePickerSpace.TabIndex = 9;
            // 
            // OptionControlSub3FromB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.CheckBoxTrigger );
            this.Controls.Add( this.groupBoxSetting );
            this.Controls.Add( this.groupBoxTask );
            this.Controls.Add( this.comboBoxTask );
            this.Controls.Add( this.labelTask );
            this.Name = "OptionControlSub3FromB";
            this.Size = new System.Drawing.Size( 780, 518 );
            this.Load += new System.EventHandler( this.OptionControlSub3FromB_Load );
            this.groupBoxSetting.ResumeLayout( false );
            this.groupBoxSetting.PerformLayout();
            this.groupBoxTask.ResumeLayout( false );
            this.groupBoxTask.PerformLayout();
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.groupBoxInfo.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox CheckBoxTrigger;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        public System.Windows.Forms.CheckBox checkBoxRun;
        public System.Windows.Forms.CheckBox checkBoxSpace;
        public System.Windows.Forms.CheckBox checkBoxEnd;
        public System.Windows.Forms.DateTimePicker dateTimePickerTimeEnd;
        private System.Windows.Forms.Label labelSpace;
        public System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.GroupBox groupBoxTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        public System.Windows.Forms.DateTimePicker dateTimePickerTimeBegin;
        public System.Windows.Forms.DateTimePicker dateTimePickerBegin;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.RadioButton RadioButtonDay;
        public System.Windows.Forms.RadioButton RadioButtonMonth;
        public System.Windows.Forms.RadioButton RadioButtonWeek;
        public System.Windows.Forms.RadioButton RadioButtonOne;
        public System.Windows.Forms.ComboBox comboBoxTask;
        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.Panel panelInfo;
        public System.Windows.Forms.DateTimePicker dateTimePickerSpace;
        public System.Windows.Forms.DateTimePicker dateTimePickerSpaceTime;
        public System.Windows.Forms.DateTimePicker dateTimePickerRun;
    }
}
