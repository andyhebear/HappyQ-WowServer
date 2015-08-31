namespace Demo_R.O.S.E.STL.Editor
{
    partial class STLEditorForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KoreanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JapaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChinaTaiwanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OtherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CoalitionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.填充中文空字符串ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView ) ).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.STL";
            this.openFileDialog.FileName = "*.STL";
            this.openFileDialog.Filter = "STL 文件 (*.STL)|*.STL|所有文件 (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "STL 文件 (*.STL)|*.STL|所有文件 (*.*)|*.*";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.HelpToolStripMenuItem} );
            this.menuStrip.Location = new System.Drawing.Point( 0, 0 );
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size( 792, 24 );
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.LoadToolStripMenuItem,
            this.toolStripSeparator3,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.CloseToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem} );
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size( 59, 20 );
            this.FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size( 136, 22 );
            this.LoadToolStripMenuItem.Text = "读取文件(&L)";
            this.LoadToolStripMenuItem.Click += new System.EventHandler( this.LoadToolStripMenuItem_Click );
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size( 133, 6 );
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size( 136, 22 );
            this.SaveToolStripMenuItem.Text = "保存(&S)";
            this.SaveToolStripMenuItem.Click += new System.EventHandler( this.SaveToolStripMenuItem_Click );
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size( 136, 22 );
            this.SaveAsToolStripMenuItem.Text = "另存为(&A)";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler( this.SaveAsToolStripMenuItem_Click );
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size( 133, 6 );
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Enabled = false;
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size( 136, 22 );
            this.CloseToolStripMenuItem.Text = "关闭(&C)";
            this.CloseToolStripMenuItem.Click += new System.EventHandler( this.CloseToolStripMenuItem_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 133, 6 );
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size( 136, 22 );
            this.ExitToolStripMenuItem.Text = "退出(&X)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler( this.ExitToolStripMenuItem_Click );
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.LanguageToolStripMenuItem,
            this.CommentToolStripMenuItem,
            this.OtherToolStripMenuItem} );
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size( 59, 20 );
            this.EditToolStripMenuItem.Text = "编辑(&E)";
            // 
            // LanguageToolStripMenuItem
            // 
            this.LanguageToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.KoreanToolStripMenuItem,
            this.EnglishToolStripMenuItem,
            this.JapaneseToolStripMenuItem,
            this.ChinaTaiwanToolStripMenuItem,
            this.ChinaToolStripMenuItem} );
            this.LanguageToolStripMenuItem.Enabled = false;
            this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            this.LanguageToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.LanguageToolStripMenuItem.Text = "语言(&L)";
            // 
            // KoreanToolStripMenuItem
            // 
            this.KoreanToolStripMenuItem.Name = "KoreanToolStripMenuItem";
            this.KoreanToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.KoreanToolStripMenuItem.Text = "韩文(&K)";
            this.KoreanToolStripMenuItem.Click += new System.EventHandler( this.KoreanToolStripMenuItem_Click );
            // 
            // EnglishToolStripMenuItem
            // 
            this.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem";
            this.EnglishToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.EnglishToolStripMenuItem.Text = "英文(&E)";
            this.EnglishToolStripMenuItem.Click += new System.EventHandler( this.EnglishToolStripMenuItem_Click );
            // 
            // JapaneseToolStripMenuItem
            // 
            this.JapaneseToolStripMenuItem.Name = "JapaneseToolStripMenuItem";
            this.JapaneseToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.JapaneseToolStripMenuItem.Text = "日文(&J)";
            this.JapaneseToolStripMenuItem.Click += new System.EventHandler( this.JapaneseToolStripMenuItem_Click );
            // 
            // ChinaTaiwanToolStripMenuItem
            // 
            this.ChinaTaiwanToolStripMenuItem.Name = "ChinaTaiwanToolStripMenuItem";
            this.ChinaTaiwanToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.ChinaTaiwanToolStripMenuItem.Text = "中文-繁体(&T)";
            this.ChinaTaiwanToolStripMenuItem.Click += new System.EventHandler( this.ChinaTaiwanToolStripMenuItem_Click );
            // 
            // ChinaToolStripMenuItem
            // 
            this.ChinaToolStripMenuItem.Name = "ChinaToolStripMenuItem";
            this.ChinaToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.ChinaToolStripMenuItem.Text = "中文-简体(&C)";
            this.ChinaToolStripMenuItem.Click += new System.EventHandler( this.ChinaToolStripMenuItem_Click );
            // 
            // CommentToolStripMenuItem
            // 
            this.CommentToolStripMenuItem.Enabled = false;
            this.CommentToolStripMenuItem.Name = "CommentToolStripMenuItem";
            this.CommentToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.CommentToolStripMenuItem.Text = "显示注释";
            this.CommentToolStripMenuItem.Click += new System.EventHandler( this.CommentToolStripMenuItem_Click );
            // 
            // OtherToolStripMenuItem
            // 
            this.OtherToolStripMenuItem.Enabled = false;
            this.OtherToolStripMenuItem.Name = "OtherToolStripMenuItem";
            this.OtherToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.OtherToolStripMenuItem.Text = "显示扩展信息";
            this.OtherToolStripMenuItem.Click += new System.EventHandler( this.OtherToolStripMenuItem_Click );
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.CoalitionFileToolStripMenuItem,
            this.填充中文空字符串ToolStripMenuItem} );
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size( 59, 20 );
            this.工具ToolStripMenuItem.Text = "工具(&T)";
            // 
            // CoalitionFileToolStripMenuItem
            // 
            this.CoalitionFileToolStripMenuItem.Name = "CoalitionFileToolStripMenuItem";
            this.CoalitionFileToolStripMenuItem.Size = new System.Drawing.Size( 178, 22 );
            this.CoalitionFileToolStripMenuItem.Text = "合并STL文件(&F)";
            this.CoalitionFileToolStripMenuItem.Click += new System.EventHandler( this.CoalitionFileToolStripMenuItem_Click );
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem} );
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size( 59, 20 );
            this.HelpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size( 274, 22 );
            this.AboutToolStripMenuItem.Text = "关于 Demo R.O.S.E.STL.Editor(&A)...";
            this.AboutToolStripMenuItem.Click += new System.EventHandler( this.AboutToolStripMenuItem_Click );
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point( 0, 24 );
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size( 792, 549 );
            this.dataGridView.TabIndex = 1;
            // 
            // 填充中文空字符串ToolStripMenuItem
            // 
            this.填充中文空字符串ToolStripMenuItem.Enabled = false;
            this.填充中文空字符串ToolStripMenuItem.Name = "填充中文空字符串ToolStripMenuItem";
            this.填充中文空字符串ToolStripMenuItem.Size = new System.Drawing.Size( 178, 22 );
            this.填充中文空字符串ToolStripMenuItem.Text = "填充(中文)空字符串";
            this.填充中文空字符串ToolStripMenuItem.Click += new System.EventHandler( this.填充中文空字符串ToolStripMenuItem_Click );
            // 
            // STLEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 792, 573 );
            this.Controls.Add( this.dataGridView );
            this.Controls.Add( this.menuStrip );
            this.MainMenuStrip = this.menuStrip;
            this.Name = "STLEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo R.O.S.E.STL.Editor.Form";
            this.menuStrip.ResumeLayout( false );
            this.menuStrip.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KoreanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JapaneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChinaTaiwanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OtherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CoalitionFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 填充中文空字符串ToolStripMenuItem;
    }
}


