namespace Demo.Stock.LHP
{
    partial class ScanPrimary2ControlSub4
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
            this.radioButtonCustom = new System.Windows.Forms.RadioButton();
            this.radioButtonGlobal = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioButtonCustom
            // 
            this.radioButtonCustom.AutoSize = true;
            this.radioButtonCustom.Location = new System.Drawing.Point( 128, 14 );
            this.radioButtonCustom.Name = "radioButtonCustom";
            this.radioButtonCustom.Size = new System.Drawing.Size( 95, 16 );
            this.radioButtonCustom.TabIndex = 12;
            this.radioButtonCustom.TabStop = true;
            this.radioButtonCustom.Text = "自定义SR报表";
            this.radioButtonCustom.UseVisualStyleBackColor = true;
            // 
            // radioButtonGlobal
            // 
            this.radioButtonGlobal.AutoSize = true;
            this.radioButtonGlobal.Checked = true;
            this.radioButtonGlobal.Location = new System.Drawing.Point( 3, 14 );
            this.radioButtonGlobal.Name = "radioButtonGlobal";
            this.radioButtonGlobal.Size = new System.Drawing.Size( 119, 16 );
            this.radioButtonGlobal.TabIndex = 11;
            this.radioButtonGlobal.TabStop = true;
            this.radioButtonGlobal.Text = "使用拥有者SR报表";
            this.radioButtonGlobal.UseVisualStyleBackColor = true;
            // 
            // ScanPrimary2ControlSub4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.radioButtonCustom );
            this.Controls.Add( this.radioButtonGlobal );
            this.Name = "ScanPrimary2ControlSub4";
            this.Size = new System.Drawing.Size( 580, 520 );
            this.Load += new System.EventHandler( this.Demo_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonCustom;
        private System.Windows.Forms.RadioButton radioButtonGlobal;
    }
}
