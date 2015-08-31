namespace Demo.Stock.X.Tools
{
    partial class MSFLViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MSFLViewForm ) );
            this.ListViewSecurity = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.ListViewPrice = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderBrowserDialogView = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListViewSecurity
            // 
            this.ListViewSecurity.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10} );
            this.ListViewSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewSecurity.FullRowSelect = true;
            this.ListViewSecurity.Location = new System.Drawing.Point( 0, 25 );
            this.ListViewSecurity.MultiSelect = false;
            this.ListViewSecurity.Name = "ListViewSecurity";
            this.ListViewSecurity.Size = new System.Drawing.Size( 809, 261 );
            this.ListViewSecurity.TabIndex = 0;
            this.ListViewSecurity.UseCompatibleStateImageBehavior = false;
            this.ListViewSecurity.View = System.Windows.Forms.View.Details;
            this.ListViewSecurity.VirtualMode = true;
            this.ListViewSecurity.SelectedIndexChanged += new System.EventHandler( this.ListViewSecurity_SelectedIndexChanged );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "股票名称";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "股票代码";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "周期类型";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "初始日期";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "结束日期";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "初始时间";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "最终时间";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "开始时间";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "结束时间";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Collection日期";
            this.columnHeader10.Width = 100;
            // 
            // ListViewPrice
            // 
            this.ListViewPrice.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18} );
            this.ListViewPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewPrice.FullRowSelect = true;
            this.ListViewPrice.Location = new System.Drawing.Point( 0, 0 );
            this.ListViewPrice.Name = "ListViewPrice";
            this.ListViewPrice.Size = new System.Drawing.Size( 809, 284 );
            this.ListViewPrice.TabIndex = 1;
            this.ListViewPrice.UseCompatibleStateImageBehavior = false;
            this.ListViewPrice.View = System.Windows.Forms.View.Details;
            this.ListViewPrice.VirtualMode = true;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "股票日期";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "股票时间";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "开盘价";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "最高价";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "收盘价";
            this.columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "最低价";
            this.columnHeader16.Width = 100;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "成交量";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "未平仓合约";
            this.columnHeader18.Width = 100;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add( this.ListViewSecurity );
            this.splitContainer.Panel1.Controls.Add( this.menuStrip );
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add( this.ListViewPrice );
            this.splitContainer.Size = new System.Drawing.Size( 809, 574 );
            this.splitContainer.SplitterDistance = 286;
            this.splitContainer.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem} );
            this.menuStrip.Location = new System.Drawing.Point( 0, 0 );
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size( 809, 25 );
            this.menuStrip.TabIndex = 1;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem} );
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size( 58, 21 );
            this.FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size( 141, 22 );
            this.OpenToolStripMenuItem.Text = "打开目录(&D)";
            this.OpenToolStripMenuItem.Click += new System.EventHandler( this.OpenToolStripMenuItem_Click );
            // 
            // FolderBrowserDialogView
            // 
            this.FolderBrowserDialogView.Description = "选择MetaStock文件档案的目录";
            this.FolderBrowserDialogView.ShowNewFolderButton = false;
            // 
            // MSFLViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 809, 574 );
            this.Controls.Add( this.splitContainer );
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MSFLViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Metastock浏览器";
            this.Load += new System.EventHandler( this.MSFLViewForm_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.MSFLViewForm_FormClosing );
            this.splitContainer.Panel1.ResumeLayout( false );
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout( false );
            this.splitContainer.ResumeLayout( false );
            this.menuStrip.ResumeLayout( false );
            this.menuStrip.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ListView ListViewSecurity;
        private System.Windows.Forms.ListView ListViewPrice;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialogView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
    }
}