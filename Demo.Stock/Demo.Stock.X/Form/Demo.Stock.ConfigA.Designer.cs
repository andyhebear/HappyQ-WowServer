namespace Demo.Stock.X
{
    partial class ConfigAControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ConfigAControl ) );
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.ListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeaderStockFilePath = new System.Windows.Forms.ColumnHeader();
            this.ContextMenuStripDelete = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.LabelStockeInfo = new System.Windows.Forms.Label();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
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
            this.axShortcutCaption.TabIndex = 3;
            // 
            // ListView
            // 
            this.ListView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ListView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.ColumnHeaderStockFilePath} );
            this.ListView.ContextMenuStrip = this.ContextMenuStripDelete;
            this.ListView.Location = new System.Drawing.Point( 0, 29 );
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size( 330, 298 );
            this.ListView.TabIndex = 1;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.SelectedIndexChanged += new System.EventHandler( this.ListView_SelectedIndexChanged );
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
            // ColumnHeaderStockFilePath
            // 
            this.ColumnHeaderStockFilePath.Text = "股票信息文件的所在位置";
            this.ColumnHeaderStockFilePath.Width = 300;
            // 
            // ContextMenuStripDelete
            // 
            this.ContextMenuStripDelete.Name = "ContextMenuStripDel";
            this.ContextMenuStripDelete.Size = new System.Drawing.Size( 61, 4 );
            this.ContextMenuStripDelete.Opening += new System.ComponentModel.CancelEventHandler( this.ContextMenuStripDelete_Opening );
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonAdd.Location = new System.Drawing.Point( 242, 333 );
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size( 85, 23 );
            this.ButtonAdd.TabIndex = 1;
            this.ButtonAdd.Text = "添加股票";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler( this.ButtonAdd_Click );
            // 
            // LabelStockeInfo
            // 
            this.LabelStockeInfo.BackColor = System.Drawing.SystemColors.Info;
            this.LabelStockeInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelStockeInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelStockeInfo.Location = new System.Drawing.Point( 0, 362 );
            this.LabelStockeInfo.Name = "LabelStockeInfo";
            this.LabelStockeInfo.Size = new System.Drawing.Size( 330, 50 );
            this.LabelStockeInfo.TabIndex = 5;
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "选择MetaStock文件档案的位置";
            // 
            // ConfigAControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.LabelStockeInfo );
            this.Controls.Add( this.ButtonAdd );
            this.Controls.Add( this.ListView );
            this.Controls.Add( this.axShortcutCaption );
            this.Name = "ConfigAControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            this.Load += new System.EventHandler( this.ConfigAControl_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        public System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ColumnHeader ColumnHeaderStockFilePath;
        public System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Label LabelStockeInfo;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripDelete;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
