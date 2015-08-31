namespace Demo.Stock.X.U50
{
    partial class PolicyEControlSub4
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
            this.RadioButtonYes = new System.Windows.Forms.RadioButton();
            this.RadioButtonAny = new System.Windows.Forms.RadioButton();
            this.RadioButtonNo = new System.Windows.Forms.RadioButton();
            this.CheckBoxAllow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // RadioButtonYes
            // 
            this.RadioButtonYes.AutoSize = true;
            this.RadioButtonYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonYes.Location = new System.Drawing.Point( 18, 58 );
            this.RadioButtonYes.Name = "RadioButtonYes";
            this.RadioButtonYes.Size = new System.Drawing.Size( 41, 17 );
            this.RadioButtonYes.TabIndex = 48;
            this.RadioButtonYes.Text = "是";
            this.RadioButtonYes.UseVisualStyleBackColor = true;
            this.RadioButtonYes.CheckedChanged += new System.EventHandler( this.RadioButtonYes_CheckedChanged );
            // 
            // RadioButtonAny
            // 
            this.RadioButtonAny.AutoSize = true;
            this.RadioButtonAny.Checked = true;
            this.RadioButtonAny.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonAny.Location = new System.Drawing.Point( 18, 26 );
            this.RadioButtonAny.Name = "RadioButtonAny";
            this.RadioButtonAny.Size = new System.Drawing.Size( 65, 17 );
            this.RadioButtonAny.TabIndex = 50;
            this.RadioButtonAny.TabStop = true;
            this.RadioButtonAny.Text = "任意值";
            this.RadioButtonAny.UseVisualStyleBackColor = true;
            this.RadioButtonAny.CheckedChanged += new System.EventHandler( this.RadioButtonAny_CheckedChanged );
            // 
            // RadioButtonNo
            // 
            this.RadioButtonNo.AutoSize = true;
            this.RadioButtonNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonNo.Location = new System.Drawing.Point( 18, 94 );
            this.RadioButtonNo.Name = "RadioButtonNo";
            this.RadioButtonNo.Size = new System.Drawing.Size( 41, 17 );
            this.RadioButtonNo.TabIndex = 49;
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
            this.CheckBoxAllow.Size = new System.Drawing.Size( 72, 17 );
            this.CheckBoxAllow.TabIndex = 47;
            this.CheckBoxAllow.Text = "PS≧PH1";
            this.CheckBoxAllow.UseVisualStyleBackColor = true;
            this.CheckBoxAllow.CheckedChanged += new System.EventHandler( this.CheckBoxAllow_CheckedChanged );
            // 
            // ConfigEControlSub4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.RadioButtonYes );
            this.Controls.Add( this.RadioButtonAny );
            this.Controls.Add( this.RadioButtonNo );
            this.Controls.Add( this.CheckBoxAllow );
            this.Name = "ConfigEControlSub4";
            this.Size = new System.Drawing.Size( 330, 345 );
            this.Load += new System.EventHandler( this.ConfigEControlSub4_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton RadioButtonYes;
        public System.Windows.Forms.RadioButton RadioButtonAny;
        public System.Windows.Forms.RadioButton RadioButtonNo;
        public System.Windows.Forms.CheckBox CheckBoxAllow;

    }
}
