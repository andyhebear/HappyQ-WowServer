namespace Demo.Stock.X.U50
{
    partial class PolicyDControlSub0
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
            this.Label3 = new System.Windows.Forms.Label();
            this.ButtonCondition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point( 3, 8 );
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size( 149, 12 );
            this.Label3.TabIndex = 11;
            this.Label3.Text = "股价必须符合如下基本条件";
            // 
            // ButtonCondition
            // 
            this.ButtonCondition.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCondition.Enabled = false;
            this.ButtonCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonCondition.Location = new System.Drawing.Point( 257, 3 );
            this.ButtonCondition.Name = "ButtonCondition";
            this.ButtonCondition.Size = new System.Drawing.Size( 70, 23 );
            this.ButtonCondition.TabIndex = 24;
            this.ButtonCondition.Text = "条件设置";
            this.ButtonCondition.UseVisualStyleBackColor = true;
            this.ButtonCondition.Click += new System.EventHandler( this.ButtonCondition_Click );
            // 
            // ConfigDControlSub0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.ButtonCondition );
            this.Controls.Add( this.Label3 );
            this.Name = "ConfigDControlSub0";
            this.Size = new System.Drawing.Size( 330, 345 );
            this.Load += new System.EventHandler( this.ConfigBControlSub0_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button ButtonCondition;
    }
}
