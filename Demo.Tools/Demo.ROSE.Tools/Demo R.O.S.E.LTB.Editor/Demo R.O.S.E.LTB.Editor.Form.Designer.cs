namespace Demo_R.O.S.E.LTB.Editor
{
    partial class LTBEditorForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.Language01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Language02ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CoalitionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutDemoROSESTBEditorAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.自动填充空的字符串ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView ) ).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.工具TToolStripMenuItem,
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
            this.toolStripSeparator2,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.toolStripSeparator3,
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
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.LoadToolStripMenuItem.Text = "读取文件(&L)";
            this.LoadToolStripMenuItem.Click += new System.EventHandler( this.LoadToolStripMenuItem_Click );
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size( 139, 6 );
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.SaveToolStripMenuItem.Text = "保存(&S)";
            this.SaveToolStripMenuItem.Click += new System.EventHandler( this.SaveToolStripMenuItem_Click );
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.SaveAsToolStripMenuItem.Text = "另存为...(&A)";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler( this.SaveAsToolStripMenuItem_Click );
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size( 139, 6 );
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Enabled = false;
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.CloseToolStripMenuItem.Text = "关闭(&C)";
            this.CloseToolStripMenuItem.Click += new System.EventHandler( this.CloseToolStripMenuItem_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 139, 6 );
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.ExitToolStripMenuItem.Text = "退出(&X)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler( this.ExitToolStripMenuItem_Click );
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.LanguageToolStripMenuItem} );
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
            this.ChinaToolStripMenuItem,
            this.Language01ToolStripMenuItem,
            this.Language02ToolStripMenuItem} );
            this.LanguageToolStripMenuItem.Enabled = false;
            this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            this.LanguageToolStripMenuItem.Size = new System.Drawing.Size( 112, 22 );
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
            this.EnglishToolStripMenuItem.Checked = true;
            this.EnglishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.ChinaTaiwanToolStripMenuItem.Checked = true;
            this.ChinaTaiwanToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChinaTaiwanToolStripMenuItem.Name = "ChinaTaiwanToolStripMenuItem";
            this.ChinaTaiwanToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.ChinaTaiwanToolStripMenuItem.Text = "中文-繁体(&T)";
            this.ChinaTaiwanToolStripMenuItem.Click += new System.EventHandler( this.ChinaTaiwanToolStripMenuItem_Click );
            // 
            // ChinaToolStripMenuItem
            // 
            this.ChinaToolStripMenuItem.Checked = true;
            this.ChinaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChinaToolStripMenuItem.Name = "ChinaToolStripMenuItem";
            this.ChinaToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.ChinaToolStripMenuItem.Text = "中文-简体(&C)";
            this.ChinaToolStripMenuItem.Click += new System.EventHandler( this.ChinaToolStripMenuItem_Click );
            // 
            // Language01ToolStripMenuItem
            // 
            this.Language01ToolStripMenuItem.Name = "Language01ToolStripMenuItem";
            this.Language01ToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.Language01ToolStripMenuItem.Text = "其它语言 01";
            this.Language01ToolStripMenuItem.Click += new System.EventHandler( this.Language01ToolStripMenuItem_Click );
            // 
            // Language02ToolStripMenuItem
            // 
            this.Language02ToolStripMenuItem.Name = "Language02ToolStripMenuItem";
            this.Language02ToolStripMenuItem.Size = new System.Drawing.Size( 142, 22 );
            this.Language02ToolStripMenuItem.Text = "其它语言 02";
            this.Language02ToolStripMenuItem.Click += new System.EventHandler( this.Language02ToolStripMenuItem_Click );
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.CoalitionFileToolStripMenuItem,
            this.自动填充空的字符串ToolStripMenuItem} );
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size( 59, 20 );
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // CoalitionFileToolStripMenuItem
            // 
            this.CoalitionFileToolStripMenuItem.Enabled = false;
            this.CoalitionFileToolStripMenuItem.Name = "CoalitionFileToolStripMenuItem";
            this.CoalitionFileToolStripMenuItem.Size = new System.Drawing.Size( 178, 22 );
            this.CoalitionFileToolStripMenuItem.Text = "合并LTB文件(&F)";
            this.CoalitionFileToolStripMenuItem.Click += new System.EventHandler( this.CoalitionFileToolStripMenuItem_Click );
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.AboutDemoROSESTBEditorAToolStripMenuItem} );
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size( 59, 20 );
            this.HelpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // AboutDemoROSESTBEditorAToolStripMenuItem
            // 
            this.AboutDemoROSESTBEditorAToolStripMenuItem.Name = "AboutDemoROSESTBEditorAToolStripMenuItem";
            this.AboutDemoROSESTBEditorAToolStripMenuItem.Size = new System.Drawing.Size( 274, 22 );
            this.AboutDemoROSESTBEditorAToolStripMenuItem.Text = "关于 Demo R.O.S.E.LTB.Editor(&A)...";
            this.AboutDemoROSESTBEditorAToolStripMenuItem.Click += new System.EventHandler( this.AboutDemoROSESTBEditorAToolStripMenuItem_Click );
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
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.LTB";
            this.openFileDialog.FileName = "*.LTB";
            this.openFileDialog.Filter = "LTB 文件 (*.LTB)|*.LTB|所有文件 (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "LTB 文件 (*.LTB)|*.LTB|所有文件 (*.*)|*.*";
            // 
            // 自动填充空的字符串ToolStripMenuItem
            // 
            this.自动填充空的字符串ToolStripMenuItem.Enabled = false;
            this.自动填充空的字符串ToolStripMenuItem.Name = "自动填充空的字符串ToolStripMenuItem";
            this.自动填充空的字符串ToolStripMenuItem.Size = new System.Drawing.Size( 178, 22 );
            this.自动填充空的字符串ToolStripMenuItem.Text = "填充(中文)空字符串";
            this.自动填充空的字符串ToolStripMenuItem.Click += new System.EventHandler( this.自动填充空的字符串ToolStripMenuItem_Click );
            // 
            // LTBEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 792, 573 );
            this.Controls.Add( this.dataGridView );
            this.Controls.Add( this.menuStrip );
            this.MainMenuStrip = this.menuStrip;
            this.Name = "LTBEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo R.O.S.E.LTB.Editor.Form";
            this.menuStrip.ResumeLayout( false );
            this.menuStrip.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutDemoROSESTBEditorAToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KoreanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JapaneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChinaTaiwanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Language01ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Language02ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CoalitionFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动填充空的字符串ToolStripMenuItem;
    }
}


