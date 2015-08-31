namespace Demo.Stock.X.U50
{
    partial class PolicyEControlSub3
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
            this.RadioButtonBigAndSmall = new System.Windows.Forms.RadioButton();
            this.RadioButtonAny = new System.Windows.Forms.RadioButton();
            this.RadioButtonSmall = new System.Windows.Forms.RadioButton();
            this.RadioButtonBig = new System.Windows.Forms.RadioButton();
            this.MaskedTextBoxSmall = new System.Windows.Forms.MaskedTextBox();
            this.MaskedTextBoxBig = new System.Windows.Forms.MaskedTextBox();
            this.MaskedTextBoxSmall2 = new System.Windows.Forms.MaskedTextBox();
            this.LabelSmall = new System.Windows.Forms.Label();
            this.LabelBigAndSmallPercentage = new System.Windows.Forms.Label();
            this.LabelSmallPercentage = new System.Windows.Forms.Label();
            this.LabelBigPercentage = new System.Windows.Forms.Label();
            this.LabelBig = new System.Windows.Forms.Label();
            this.LabelBigAndSmall = new System.Windows.Forms.Label();
            this.MaskedTextBoxBig2 = new System.Windows.Forms.MaskedTextBox();
            this.CheckBoxAllow = new System.Windows.Forms.CheckBox();
            this.LabelBigAndSmall2 = new System.Windows.Forms.Label();
            this.LabelBigAndSmallPercentage2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RadioButtonBigAndSmall
            // 
            this.RadioButtonBigAndSmall.AutoSize = true;
            this.RadioButtonBigAndSmall.Checked = true;
            this.RadioButtonBigAndSmall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonBigAndSmall.Location = new System.Drawing.Point( 18, 169 );
            this.RadioButtonBigAndSmall.Name = "RadioButtonBigAndSmall";
            this.RadioButtonBigAndSmall.Size = new System.Drawing.Size( 149, 17 );
            this.RadioButtonBigAndSmall.TabIndex = 120;
            this.RadioButtonBigAndSmall.TabStop = true;
            this.RadioButtonBigAndSmall.Text = "指定大于和小于的 Vsc";
            this.RadioButtonBigAndSmall.UseVisualStyleBackColor = true;
            this.RadioButtonBigAndSmall.CheckedChanged += new System.EventHandler( this.RadioButtonBigAndSmall_CheckedChanged );
            // 
            // RadioButtonAny
            // 
            this.RadioButtonAny.AutoSize = true;
            this.RadioButtonAny.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonAny.Location = new System.Drawing.Point( 18, 26 );
            this.RadioButtonAny.Name = "RadioButtonAny";
            this.RadioButtonAny.Size = new System.Drawing.Size( 83, 17 );
            this.RadioButtonAny.TabIndex = 119;
            this.RadioButtonAny.TabStop = true;
            this.RadioButtonAny.Text = "任意Vsc值";
            this.RadioButtonAny.UseVisualStyleBackColor = true;
            this.RadioButtonAny.CheckedChanged += new System.EventHandler( this.RadioButtonAny_CheckedChanged );
            // 
            // RadioButtonSmall
            // 
            this.RadioButtonSmall.AutoSize = true;
            this.RadioButtonSmall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonSmall.Location = new System.Drawing.Point( 18, 114 );
            this.RadioButtonSmall.Name = "RadioButtonSmall";
            this.RadioButtonSmall.Size = new System.Drawing.Size( 101, 17 );
            this.RadioButtonSmall.TabIndex = 122;
            this.RadioButtonSmall.TabStop = true;
            this.RadioButtonSmall.Text = "指定小于 Vsc";
            this.RadioButtonSmall.UseVisualStyleBackColor = true;
            this.RadioButtonSmall.CheckedChanged += new System.EventHandler( this.RadioButtonSmall_CheckedChanged );
            // 
            // RadioButtonBig
            // 
            this.RadioButtonBig.AutoSize = true;
            this.RadioButtonBig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonBig.Location = new System.Drawing.Point( 18, 58 );
            this.RadioButtonBig.Name = "RadioButtonBig";
            this.RadioButtonBig.Size = new System.Drawing.Size( 101, 17 );
            this.RadioButtonBig.TabIndex = 121;
            this.RadioButtonBig.TabStop = true;
            this.RadioButtonBig.Text = "指定大于 Vsc";
            this.RadioButtonBig.UseVisualStyleBackColor = true;
            this.RadioButtonBig.CheckedChanged += new System.EventHandler( this.RadioButtonBig_CheckedChanged );
            // 
            // MaskedTextBoxSmall
            // 
            this.MaskedTextBoxSmall.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MaskedTextBoxSmall.Location = new System.Drawing.Point( 76, 139 );
            this.MaskedTextBoxSmall.Mask = "9990";
            this.MaskedTextBoxSmall.Name = "MaskedTextBoxSmall";
            this.MaskedTextBoxSmall.Size = new System.Drawing.Size( 38, 21 );
            this.MaskedTextBoxSmall.TabIndex = 116;
            this.MaskedTextBoxSmall.Text = "1000";
            this.MaskedTextBoxSmall.ValidatingType = typeof( int );
            // 
            // MaskedTextBoxBig
            // 
            this.MaskedTextBoxBig.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MaskedTextBoxBig.Location = new System.Drawing.Point( 76, 81 );
            this.MaskedTextBoxBig.Mask = "9990";
            this.MaskedTextBoxBig.Name = "MaskedTextBoxBig";
            this.MaskedTextBoxBig.Size = new System.Drawing.Size( 32, 21 );
            this.MaskedTextBoxBig.TabIndex = 117;
            this.MaskedTextBoxBig.Text = "   1";
            // 
            // MaskedTextBoxSmall2
            // 
            this.MaskedTextBoxSmall2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MaskedTextBoxSmall2.Location = new System.Drawing.Point( 76, 227 );
            this.MaskedTextBoxSmall2.Mask = "9990";
            this.MaskedTextBoxSmall2.Name = "MaskedTextBoxSmall2";
            this.MaskedTextBoxSmall2.Size = new System.Drawing.Size( 38, 21 );
            this.MaskedTextBoxSmall2.TabIndex = 115;
            this.MaskedTextBoxSmall2.Text = "1000";
            this.MaskedTextBoxSmall2.ValidatingType = typeof( int );
            // 
            // LabelSmall
            // 
            this.LabelSmall.AutoSize = true;
            this.LabelSmall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelSmall.Location = new System.Drawing.Point( 35, 142 );
            this.LabelSmall.Name = "LabelSmall";
            this.LabelSmall.Size = new System.Drawing.Size( 35, 12 );
            this.LabelSmall.TabIndex = 110;
            this.LabelSmall.Text = "Vsc <";
            // 
            // LabelBigAndSmallPercentage
            // 
            this.LabelBigAndSmallPercentage.AutoSize = true;
            this.LabelBigAndSmallPercentage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelBigAndSmallPercentage.Location = new System.Drawing.Point( 120, 198 );
            this.LabelBigAndSmallPercentage.Name = "LabelBigAndSmallPercentage";
            this.LabelBigAndSmallPercentage.Size = new System.Drawing.Size( 11, 12 );
            this.LabelBigAndSmallPercentage.TabIndex = 113;
            this.LabelBigAndSmallPercentage.Text = "%";
            // 
            // LabelSmallPercentage
            // 
            this.LabelSmallPercentage.AutoSize = true;
            this.LabelSmallPercentage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelSmallPercentage.Location = new System.Drawing.Point( 120, 142 );
            this.LabelSmallPercentage.Name = "LabelSmallPercentage";
            this.LabelSmallPercentage.Size = new System.Drawing.Size( 11, 12 );
            this.LabelSmallPercentage.TabIndex = 111;
            this.LabelSmallPercentage.Text = "%";
            // 
            // LabelBigPercentage
            // 
            this.LabelBigPercentage.AutoSize = true;
            this.LabelBigPercentage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelBigPercentage.Location = new System.Drawing.Point( 114, 84 );
            this.LabelBigPercentage.Name = "LabelBigPercentage";
            this.LabelBigPercentage.Size = new System.Drawing.Size( 11, 12 );
            this.LabelBigPercentage.TabIndex = 109;
            this.LabelBigPercentage.Text = "%";
            // 
            // LabelBig
            // 
            this.LabelBig.AutoSize = true;
            this.LabelBig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelBig.Location = new System.Drawing.Point( 35, 83 );
            this.LabelBig.Name = "LabelBig";
            this.LabelBig.Size = new System.Drawing.Size( 35, 12 );
            this.LabelBig.TabIndex = 114;
            this.LabelBig.Text = "Vsc >";
            // 
            // LabelBigAndSmall
            // 
            this.LabelBigAndSmall.AutoSize = true;
            this.LabelBigAndSmall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelBigAndSmall.Location = new System.Drawing.Point( 35, 198 );
            this.LabelBigAndSmall.Name = "LabelBigAndSmall";
            this.LabelBigAndSmall.Size = new System.Drawing.Size( 35, 12 );
            this.LabelBigAndSmall.TabIndex = 112;
            this.LabelBigAndSmall.Text = "Vsc >";
            // 
            // MaskedTextBoxBig2
            // 
            this.MaskedTextBoxBig2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MaskedTextBoxBig2.Location = new System.Drawing.Point( 76, 195 );
            this.MaskedTextBoxBig2.Mask = "9990";
            this.MaskedTextBoxBig2.Name = "MaskedTextBoxBig2";
            this.MaskedTextBoxBig2.Size = new System.Drawing.Size( 38, 21 );
            this.MaskedTextBoxBig2.TabIndex = 118;
            this.MaskedTextBoxBig2.Text = "   1";
            this.MaskedTextBoxBig2.ValidatingType = typeof( int );
            // 
            // CheckBoxAllow
            // 
            this.CheckBoxAllow.AutoSize = true;
            this.CheckBoxAllow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxAllow.Location = new System.Drawing.Point( 3, 3 );
            this.CheckBoxAllow.Name = "CheckBoxAllow";
            this.CheckBoxAllow.Size = new System.Drawing.Size( 258, 17 );
            this.CheckBoxAllow.TabIndex = 123;
            this.CheckBoxAllow.Text = "当日成交量与U50形态平均成交量比值(Vsc)";
            this.CheckBoxAllow.UseVisualStyleBackColor = true;
            this.CheckBoxAllow.CheckedChanged += new System.EventHandler( this.CheckBoxAllow_CheckedChanged );
            // 
            // LabelBigAndSmall2
            // 
            this.LabelBigAndSmall2.AutoSize = true;
            this.LabelBigAndSmall2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelBigAndSmall2.Location = new System.Drawing.Point( 35, 230 );
            this.LabelBigAndSmall2.Name = "LabelBigAndSmall2";
            this.LabelBigAndSmall2.Size = new System.Drawing.Size( 35, 12 );
            this.LabelBigAndSmall2.TabIndex = 112;
            this.LabelBigAndSmall2.Text = "Vsc <";
            // 
            // LabelBigAndSmallPercentage2
            // 
            this.LabelBigAndSmallPercentage2.AutoSize = true;
            this.LabelBigAndSmallPercentage2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelBigAndSmallPercentage2.Location = new System.Drawing.Point( 120, 230 );
            this.LabelBigAndSmallPercentage2.Name = "LabelBigAndSmallPercentage2";
            this.LabelBigAndSmallPercentage2.Size = new System.Drawing.Size( 11, 12 );
            this.LabelBigAndSmallPercentage2.TabIndex = 113;
            this.LabelBigAndSmallPercentage2.Text = "%";
            // 
            // PolicyEControlSub3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.CheckBoxAllow );
            this.Controls.Add( this.RadioButtonBigAndSmall );
            this.Controls.Add( this.RadioButtonAny );
            this.Controls.Add( this.RadioButtonSmall );
            this.Controls.Add( this.RadioButtonBig );
            this.Controls.Add( this.MaskedTextBoxSmall );
            this.Controls.Add( this.MaskedTextBoxBig );
            this.Controls.Add( this.MaskedTextBoxSmall2 );
            this.Controls.Add( this.LabelSmall );
            this.Controls.Add( this.LabelBigAndSmallPercentage2 );
            this.Controls.Add( this.LabelBigAndSmallPercentage );
            this.Controls.Add( this.LabelSmallPercentage );
            this.Controls.Add( this.LabelBigPercentage );
            this.Controls.Add( this.LabelBig );
            this.Controls.Add( this.LabelBigAndSmall2 );
            this.Controls.Add( this.LabelBigAndSmall );
            this.Controls.Add( this.MaskedTextBoxBig2 );
            this.Name = "PolicyEControlSub3";
            this.Size = new System.Drawing.Size( 330, 345 );
            this.Load += new System.EventHandler( this.ConfigEControlSub3_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton RadioButtonBigAndSmall;
        public System.Windows.Forms.RadioButton RadioButtonAny;
        public System.Windows.Forms.RadioButton RadioButtonSmall;
        public System.Windows.Forms.RadioButton RadioButtonBig;
        public System.Windows.Forms.MaskedTextBox MaskedTextBoxSmall;
        public System.Windows.Forms.MaskedTextBox MaskedTextBoxBig;
        public System.Windows.Forms.MaskedTextBox MaskedTextBoxSmall2;
        private System.Windows.Forms.Label LabelSmall;
        private System.Windows.Forms.Label LabelBigAndSmallPercentage;
        private System.Windows.Forms.Label LabelSmallPercentage;
        private System.Windows.Forms.Label LabelBigPercentage;
        private System.Windows.Forms.Label LabelBig;
        private System.Windows.Forms.Label LabelBigAndSmall;
        public System.Windows.Forms.MaskedTextBox MaskedTextBoxBig2;
        public System.Windows.Forms.CheckBox CheckBoxAllow;
        private System.Windows.Forms.Label LabelBigAndSmall2;
        private System.Windows.Forms.Label LabelBigAndSmallPercentage2;

    }
}
