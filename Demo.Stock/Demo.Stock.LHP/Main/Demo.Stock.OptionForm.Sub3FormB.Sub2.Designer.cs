namespace Demo.Stock.LHP.Main
{
    partial class OptionControlSub3FromBSub2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            ( (System.ComponentModel.ISupportInitialize)( this.numericUpDown ) ).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 14 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 29, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "每隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 101, 14 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 65, 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "天发生一次";
            // 
            // numericUpDown1
            // 
            this.numericUpDown.Location = new System.Drawing.Point( 38, 12 );
            this.numericUpDown.Name = "numericUpDown1";
            this.numericUpDown.Size = new System.Drawing.Size( 57, 21 );
            this.numericUpDown.TabIndex = 2;
            // 
            // OptionControlSub3FromBSub2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.numericUpDown );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Name = "OptionControlSub3FromBSub2";
            this.Size = new System.Drawing.Size( 347, 165 );
            ( (System.ComponentModel.ISupportInitialize)( this.numericUpDown ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numericUpDown;
    }
}
