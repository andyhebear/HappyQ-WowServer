namespace Demo.Stock.X.U50
{
    partial class TaskBControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TaskBControl ) );
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.ToolTipScan = new System.Windows.Forms.ToolTip( this.components );
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 330, 29 );
            this.axShortcutCaption.TabIndex = 5;
            // 
            // ToolTipScan
            // 
            this.ToolTipScan.ToolTipTitle = "扫描信息";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1.Location = new System.Drawing.Point( 3, 86 );
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size( 77, 17 );
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "人工扫描";
            this.ToolTipScan.SetToolTip( this.radioButton1, "不自动执行本任务，在需要的时候手动执行。" );
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton2.Location = new System.Drawing.Point( 3, 61 );
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size( 77, 17 );
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "定时扫描";
            this.ToolTipScan.SetToolTip( this.radioButton2, "指定需要执行的时间后，每天自动执行本任务。" );
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton3.Location = new System.Drawing.Point( 3, 35 );
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size( 77, 17 );
            this.radioButton3.TabIndex = 8;
            this.radioButton3.Text = "自动扫描";
            this.ToolTipScan.SetToolTip( this.radioButton3, "每天当后台数据股票更新后，自动执行本任务。" );
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point( 91, 60 );
            this.maskedTextBox1.Mask = "90时90分";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size( 55, 21 );
            this.maskedTextBox1.TabIndex = 9;
            this.ToolTipScan.SetToolTip( this.maskedTextBox1, "输入需要执行本任务的时间" );
            this.maskedTextBox1.ValidatingType = typeof( System.DateTime );
            // 
            // TaskBControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.maskedTextBox1 );
            this.Controls.Add( this.radioButton3 );
            this.Controls.Add( this.radioButton2 );
            this.Controls.Add( this.radioButton1 );
            this.Controls.Add( this.axShortcutCaption );
            this.Name = "TaskBControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.ToolTip ToolTipScan;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}
