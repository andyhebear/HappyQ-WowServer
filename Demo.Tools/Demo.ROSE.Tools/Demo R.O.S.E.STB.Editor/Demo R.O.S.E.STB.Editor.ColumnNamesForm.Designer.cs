namespace Demo_R.O.S.E.STB.Editor
{
    partial class ColumnNamesForm
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 12;
            this.listBox.Location = new System.Drawing.Point( 0, 0 );
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size( 252, 328 );
            this.listBox.TabIndex = 0;
            this.listBox.DoubleClick += new System.EventHandler( this.listBox_DoubleClick );
            // 
            // ColumnNamesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 252, 333 );
            this.Controls.Add( this.listBox );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColumnNamesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Demo R.O.S.E.STB.Editor.ColumnNames";
            this.ResumeLayout( false );

        }

        #endregion

        public System.Windows.Forms.ListBox listBox;

    }
}

