namespace Demo.Stock.X.U50
{
    partial class PolicyEControlSub6
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
            this.ButtonSetting = new System.Windows.Forms.Button();
            this.RadioButtonYes = new System.Windows.Forms.RadioButton();
            this.RadioButtonNo = new System.Windows.Forms.RadioButton();
            this.CheckBoxAllow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ButtonSetting
            // 
            this.ButtonSetting.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonSetting.Location = new System.Drawing.Point( 63, 22 );
            this.ButtonSetting.Name = "ButtonSetting";
            this.ButtonSetting.Size = new System.Drawing.Size( 93, 23 );
            this.ButtonSetting.TabIndex = 54;
            this.ButtonSetting.Text = "设置型态函数";
            this.ButtonSetting.UseVisualStyleBackColor = true;
            this.ButtonSetting.Click += new System.EventHandler( this.ButtonSetting_Click );
            // 
            // RadioButtonYes
            // 
            this.RadioButtonYes.AutoSize = true;
            this.RadioButtonYes.Checked = true;
            this.RadioButtonYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonYes.Location = new System.Drawing.Point( 18, 26 );
            this.RadioButtonYes.Name = "RadioButtonYes";
            this.RadioButtonYes.Size = new System.Drawing.Size( 41, 17 );
            this.RadioButtonYes.TabIndex = 52;
            this.RadioButtonYes.TabStop = true;
            this.RadioButtonYes.Text = "是";
            this.RadioButtonYes.UseVisualStyleBackColor = true;
            this.RadioButtonYes.CheckedChanged += new System.EventHandler( this.RadioButtonYes_CheckedChanged );
            // 
            // RadioButtonNo
            // 
            this.RadioButtonNo.AutoSize = true;
            this.RadioButtonNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonNo.Location = new System.Drawing.Point( 18, 58 );
            this.RadioButtonNo.Name = "RadioButtonNo";
            this.RadioButtonNo.Size = new System.Drawing.Size( 41, 17 );
            this.RadioButtonNo.TabIndex = 53;
            this.RadioButtonNo.Text = "否";
            this.RadioButtonNo.UseVisualStyleBackColor = true;
            this.RadioButtonNo.CheckedChanged += new System.EventHandler( this.RadioButtonNo_CheckedChanged );
            // 
            // CheckBoxAllow
            // 
            this.CheckBoxAllow.AutoSize = true;
            this.CheckBoxAllow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxAllow.Location = new System.Drawing.Point( 3, 3 );
            this.CheckBoxAllow.Name = "CheckBoxAllow";
            this.CheckBoxAllow.Size = new System.Drawing.Size( 252, 17 );
            this.CheckBoxAllow.TabIndex = 51;
            this.CheckBoxAllow.Text = "修改“U50形态品质过滤限制函数”的参数";
            this.CheckBoxAllow.UseVisualStyleBackColor = true;
            this.CheckBoxAllow.CheckedChanged += new System.EventHandler( this.CheckBoxAllow_CheckedChanged );
            // 
            // ConfigEControlSub6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.ButtonSetting );
            this.Controls.Add( this.RadioButtonYes );
            this.Controls.Add( this.RadioButtonNo );
            this.Controls.Add( this.CheckBoxAllow );
            this.Name = "ConfigEControlSub6";
            this.Size = new System.Drawing.Size( 330, 345 );
            this.Load += new System.EventHandler( this.ConfigEControlSub6_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonSetting;
        public System.Windows.Forms.RadioButton RadioButtonYes;
        public System.Windows.Forms.RadioButton RadioButtonNo;
        public System.Windows.Forms.CheckBox CheckBoxAllow;
    }
}
