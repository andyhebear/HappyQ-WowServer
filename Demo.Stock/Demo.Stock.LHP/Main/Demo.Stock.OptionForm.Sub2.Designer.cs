namespace Demo.Stock.LHP.Main
{
    partial class OptionControlSub2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OptionControlSub2 ) );
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ListViewStock = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.OpenFileDialogStock = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialogStock = new System.Windows.Forms.SaveFileDialog();
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
            this.axShortcutCaption.Size = new System.Drawing.Size( 580, 30 );
            this.axShortcutCaption.TabIndex = 0;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonAdd.Location = new System.Drawing.Point( 489, 489 );
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size( 88, 28 );
            this.ButtonAdd.TabIndex = 4;
            this.ButtonAdd.Text = "添加股票";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler( this.ButtonAdd_Click );
            // 
            // ListViewStock
            // 
            this.ListViewStock.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ListViewStock.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3} );
            this.ListViewStock.FullRowSelect = true;
            this.ListViewStock.Location = new System.Drawing.Point( 0, 30 );
            this.ListViewStock.Name = "ListViewStock";
            this.ListViewStock.Size = new System.Drawing.Size( 580, 453 );
            this.ListViewStock.TabIndex = 1;
            this.ListViewStock.UseCompatibleStateImageBehavior = false;
            this.ListViewStock.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "股票名称";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "股票代码";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "股票信息文件的所在位置";
            this.columnHeader3.Width = 300;
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "选择MetaStock文件档案的位置";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size( 61, 4 );
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler( this.contextMenuStrip_Opening );
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonLoad.Location = new System.Drawing.Point( 3, 489 );
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size( 88, 28 );
            this.ButtonLoad.TabIndex = 2;
            this.ButtonLoad.Text = "读取股票清单";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler( this.ButtonLoad_Click );
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonSave.Location = new System.Drawing.Point( 97, 489 );
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size( 88, 28 );
            this.ButtonSave.TabIndex = 3;
            this.ButtonSave.Text = "保存股票清单";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler( this.ButtonSave_Click );
            // 
            // OpenFileDialogStock
            // 
            this.OpenFileDialogStock.DefaultExt = "listing";
            this.OpenFileDialogStock.Filter = "股票清单 文件|*.listing";
            // 
            // SaveFileDialogStock
            // 
            this.SaveFileDialogStock.DefaultExt = "listing";
            this.SaveFileDialogStock.Filter = "股票清单 文件|*.listing";
            // 
            // OptionControlSub2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add( this.ListViewStock );
            this.Controls.Add( this.axShortcutCaption );
            this.Controls.Add( this.ButtonAdd );
            this.Controls.Add( this.ButtonSave );
            this.Controls.Add( this.ButtonLoad );
            this.Name = "OptionControlSub2";
            this.Size = new System.Drawing.Size( 580, 520 );
            this.Load += new System.EventHandler( this.OptionControlSub2_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.ListView ListViewStock;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogStock;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogStock;
    }
}
