﻿namespace Demo.Stock.X.U50
{
    partial class PolicyEControlSub2
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
            this.LabelBig = new System.Windows.Forms.Label();
            this.MaskedTextBoxBig2 = new System.Windows.Forms.MaskedTextBox();
            this.LabelBigAndSmall = new System.Windows.Forms.Label();
            this.CheckBoxAllow = new System.Windows.Forms.CheckBox();
            this.LabelBigAndSmall2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RadioButtonBigAndSmall
            // 
            this.RadioButtonBigAndSmall.AutoSize = true;
            this.RadioButtonBigAndSmall.Checked = true;
            this.RadioButtonBigAndSmall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonBigAndSmall.Location = new System.Drawing.Point( 18, 169 );
            this.RadioButtonBigAndSmall.Name = "RadioButtonBigAndSmall";
            this.RadioButtonBigAndSmall.Size = new System.Drawing.Size( 167, 17 );
            this.RadioButtonBigAndSmall.TabIndex = 105;
            this.RadioButtonBigAndSmall.TabStop = true;
            this.RadioButtonBigAndSmall.Text = "指定大于和小于的 Va-U50";
            this.RadioButtonBigAndSmall.UseVisualStyleBackColor = true;
            this.RadioButtonBigAndSmall.CheckedChanged += new System.EventHandler( this.RadioButtonBigAndSmall_CheckedChanged );
            // 
            // RadioButtonAny
            // 
            this.RadioButtonAny.AutoSize = true;
            this.RadioButtonAny.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonAny.Location = new System.Drawing.Point( 18, 26 );
            this.RadioButtonAny.Name = "RadioButtonAny";
            this.RadioButtonAny.Size = new System.Drawing.Size( 101, 17 );
            this.RadioButtonAny.TabIndex = 104;
            this.RadioButtonAny.TabStop = true;
            this.RadioButtonAny.Text = "任意Va-U50值";
            this.RadioButtonAny.UseVisualStyleBackColor = true;
            this.RadioButtonAny.CheckedChanged += new System.EventHandler( this.RadioButtonAny_CheckedChanged );
            // 
            // RadioButtonSmall
            // 
            this.RadioButtonSmall.AutoSize = true;
            this.RadioButtonSmall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonSmall.Location = new System.Drawing.Point( 18, 118 );
            this.RadioButtonSmall.Name = "RadioButtonSmall";
            this.RadioButtonSmall.Size = new System.Drawing.Size( 119, 17 );
            this.RadioButtonSmall.TabIndex = 107;
            this.RadioButtonSmall.TabStop = true;
            this.RadioButtonSmall.Text = "指定小于 Va-U50";
            this.RadioButtonSmall.UseVisualStyleBackColor = true;
            this.RadioButtonSmall.CheckedChanged += new System.EventHandler( this.RadioButtonSmall_CheckedChanged );
            // 
            // RadioButtonBig
            // 
            this.RadioButtonBig.AutoSize = true;
            this.RadioButtonBig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonBig.Location = new System.Drawing.Point( 18, 58 );
            this.RadioButtonBig.Name = "RadioButtonBig";
            this.RadioButtonBig.Size = new System.Drawing.Size( 119, 17 );
            this.RadioButtonBig.TabIndex = 106;
            this.RadioButtonBig.TabStop = true;
            this.RadioButtonBig.Text = "指定大于 Va-U50";
            this.RadioButtonBig.UseVisualStyleBackColor = true;
            this.RadioButtonBig.CheckedChanged += new System.EventHandler( this.RadioButtonBig_CheckedChanged );
            // 
            // MaskedTextBoxSmall
            // 
            this.MaskedTextBoxSmall.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MaskedTextBoxSmall.Location = new System.Drawing.Point( 94, 139 );
            this.MaskedTextBoxSmall.Mask = "9999999990";
            this.MaskedTextBoxSmall.Name = "MaskedTextBoxSmall";
            this.MaskedTextBoxSmall.Size = new System.Drawing.Size( 68, 21 );
            this.MaskedTextBoxSmall.TabIndex = 101;
            this.MaskedTextBoxSmall.Text = "1000000000";
            // 
            // MaskedTextBoxBig
            // 
            this.MaskedTextBoxBig.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MaskedTextBoxBig.Location = new System.Drawing.Point( 94, 80 );
            this.MaskedTextBoxBig.Mask = "9999999990";
            this.MaskedTextBoxBig.Name = "MaskedTextBoxBig";
            this.MaskedTextBoxBig.Size = new System.Drawing.Size( 68, 21 );
            this.MaskedTextBoxBig.TabIndex = 102;
            this.MaskedTextBoxBig.Text = "         1";
            // 
            // MaskedTextBoxSmall2
            // 
            this.MaskedTextBoxSmall2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MaskedTextBoxSmall2.Location = new System.Drawing.Point( 94, 227 );
            this.MaskedTextBoxSmall2.Mask = "9999999990";
            this.MaskedTextBoxSmall2.Name = "MaskedTextBoxSmall2";
            this.MaskedTextBoxSmall2.Size = new System.Drawing.Size( 68, 21 );
            this.MaskedTextBoxSmall2.TabIndex = 100;
            this.MaskedTextBoxSmall2.Text = "1000000000";
            this.MaskedTextBoxSmall2.ValidatingType = typeof( int );
            // 
            // LabelSmall
            // 
            this.LabelSmall.AutoSize = true;
            this.LabelSmall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelSmall.Location = new System.Drawing.Point( 35, 142 );
            this.LabelSmall.Name = "LabelSmall";
            this.LabelSmall.Size = new System.Drawing.Size( 53, 12 );
            this.LabelSmall.TabIndex = 95;
            this.LabelSmall.Text = "Va-U50 <";
            // 
            // LabelBig
            // 
            this.LabelBig.AutoSize = true;
            this.LabelBig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelBig.Location = new System.Drawing.Point( 35, 83 );
            this.LabelBig.Name = "LabelBig";
            this.LabelBig.Size = new System.Drawing.Size( 53, 12 );
            this.LabelBig.TabIndex = 99;
            this.LabelBig.Text = "Va-U50 >";
            // 
            // MaskedTextBoxBig2
            // 
            this.MaskedTextBoxBig2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MaskedTextBoxBig2.Location = new System.Drawing.Point( 94, 195 );
            this.MaskedTextBoxBig2.Mask = "9999999990";
            this.MaskedTextBoxBig2.Name = "MaskedTextBoxBig2";
            this.MaskedTextBoxBig2.Size = new System.Drawing.Size( 68, 21 );
            this.MaskedTextBoxBig2.TabIndex = 103;
            this.MaskedTextBoxBig2.Text = "         1";
            this.MaskedTextBoxBig2.ValidatingType = typeof( int );
            // 
            // LabelBigAndSmall
            // 
            this.LabelBigAndSmall.AutoSize = true;
            this.LabelBigAndSmall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelBigAndSmall.Location = new System.Drawing.Point( 35, 198 );
            this.LabelBigAndSmall.Name = "LabelBigAndSmall";
            this.LabelBigAndSmall.Size = new System.Drawing.Size( 53, 12 );
            this.LabelBigAndSmall.TabIndex = 97;
            this.LabelBigAndSmall.Text = "Va-U50 >";
            // 
            // CheckBoxAllow
            // 
            this.CheckBoxAllow.AutoSize = true;
            this.CheckBoxAllow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxAllow.Location = new System.Drawing.Point( 3, 3 );
            this.CheckBoxAllow.Name = "CheckBoxAllow";
            this.CheckBoxAllow.Size = new System.Drawing.Size( 192, 17 );
            this.CheckBoxAllow.TabIndex = 108;
            this.CheckBoxAllow.Text = "U50形态的平均成交量(Va-U50)";
            this.CheckBoxAllow.UseVisualStyleBackColor = true;
            this.CheckBoxAllow.CheckedChanged += new System.EventHandler( this.CheckBoxAllow_CheckedChanged );
            // 
            // LabelBigAndSmall2
            // 
            this.LabelBigAndSmall2.AutoSize = true;
            this.LabelBigAndSmall2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelBigAndSmall2.Location = new System.Drawing.Point( 35, 230 );
            this.LabelBigAndSmall2.Name = "LabelBigAndSmall2";
            this.LabelBigAndSmall2.Size = new System.Drawing.Size( 53, 12 );
            this.LabelBigAndSmall2.TabIndex = 97;
            this.LabelBigAndSmall2.Text = "Va-U50 <";
            // 
            // PolicyEControlSub2
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
            this.Controls.Add( this.LabelBig );
            this.Controls.Add( this.LabelBigAndSmall2 );
            this.Controls.Add( this.LabelBigAndSmall );
            this.Controls.Add( this.MaskedTextBoxBig2 );
            this.Name = "PolicyEControlSub2";
            this.Size = new System.Drawing.Size( 330, 345 );
            this.Load += new System.EventHandler( this.ConfigEControlSub2_Load );
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
        private System.Windows.Forms.Label LabelBig;
        public System.Windows.Forms.MaskedTextBox MaskedTextBoxBig2;
        private System.Windows.Forms.Label LabelBigAndSmall;
        public System.Windows.Forms.CheckBox CheckBoxAllow;
        private System.Windows.Forms.Label LabelBigAndSmall2;
    }
}
