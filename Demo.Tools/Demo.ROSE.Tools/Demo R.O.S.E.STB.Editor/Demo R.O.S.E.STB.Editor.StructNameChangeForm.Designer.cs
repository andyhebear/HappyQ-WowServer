namespace Demo_R.O.S.E.STB.Editor
{
    partial class StructNameChangeForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxOriginal = new System.Windows.Forms.TextBox();
            this.textBoxChange = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point( 405, 32 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 75, 23 );
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point( 405, 78 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 75, 23 );
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBoxOriginal
            // 
            this.textBoxOriginal.Location = new System.Drawing.Point( 30, 34 );
            this.textBoxOriginal.Name = "textBoxOriginal";
            this.textBoxOriginal.ReadOnly = true;
            this.textBoxOriginal.Size = new System.Drawing.Size( 357, 21 );
            this.textBoxOriginal.TabIndex = 2;
            // 
            // textBoxChange
            // 
            this.textBoxChange.Location = new System.Drawing.Point( 30, 80 );
            this.textBoxChange.Name = "textBoxChange";
            this.textBoxChange.Size = new System.Drawing.Size( 357, 21 );
            this.textBoxChange.TabIndex = 2;
            // 
            // StructNameChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 491, 145 );
            this.Controls.Add( this.textBoxChange );
            this.Controls.Add( this.textBoxOriginal );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StructNameChangeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Demo R.O.S.E.STB.Editor.StructNameChangeForm";
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox textBoxOriginal;
        public System.Windows.Forms.TextBox textBoxChange;
    }
}

