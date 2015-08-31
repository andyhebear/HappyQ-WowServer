namespace Demo.Stock.LHP.BaseSR
{
    partial class SRControlSub3
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.OpenFileDialogStock = new System.Windows.Forms.OpenFileDialog();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ListViewStock = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.SaveFileDialogStock = new System.Windows.Forms.SaveFileDialog();
            this.radioButtonGlobal = new System.Windows.Forms.RadioButton();
            this.radioButtonCustom = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size( 61, 4 );
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler( this.contextMenuStrip_Opening );
            // 
            // OpenFileDialogStock
            // 
            this.OpenFileDialogStock.DefaultExt = "listing";
            this.OpenFileDialogStock.Filter = "股票清单 文件|*.listing";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonSave.Location = new System.Drawing.Point( 97, 491 );
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size( 88, 28 );
            this.ButtonSave.TabIndex = 8;
            this.ButtonSave.Text = "保存股票清单";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler( this.ButtonSave_Click );
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "选择MetaStock文件档案的位置";
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonLoad.Location = new System.Drawing.Point( 3, 491 );
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size( 88, 28 );
            this.ButtonLoad.TabIndex = 7;
            this.ButtonLoad.Text = "读取股票清单";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler( this.ButtonLoad_Click );
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "股票信息文件的所在位置";
            this.columnHeader3.Width = 300;
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
            this.ListViewStock.ContextMenuStrip = this.contextMenuStrip;
            this.ListViewStock.FullRowSelect = true;
            this.ListViewStock.Location = new System.Drawing.Point( 0, 32 );
            this.ListViewStock.Name = "ListViewStock";
            this.ListViewStock.Size = new System.Drawing.Size( 580, 453 );
            this.ListViewStock.TabIndex = 6;
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
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonAdd.Location = new System.Drawing.Point( 489, 491 );
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size( 88, 28 );
            this.ButtonAdd.TabIndex = 9;
            this.ButtonAdd.Text = "添加股票";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler( this.ButtonAdd_Click );
            // 
            // SaveFileDialogStock
            // 
            this.SaveFileDialogStock.DefaultExt = "listing";
            this.SaveFileDialogStock.Filter = "股票清单 文件|*.listing";
            // 
            // radioButtonGlobal
            // 
            this.radioButtonGlobal.AutoSize = true;
            this.radioButtonGlobal.Checked = true;
            this.radioButtonGlobal.Location = new System.Drawing.Point( 3, 10 );
            this.radioButtonGlobal.Name = "radioButtonGlobal";
            this.radioButtonGlobal.Size = new System.Drawing.Size( 119, 16 );
            this.radioButtonGlobal.TabIndex = 10;
            this.radioButtonGlobal.TabStop = true;
            this.radioButtonGlobal.Text = "使用全局股票清单";
            this.radioButtonGlobal.UseVisualStyleBackColor = true;
            this.radioButtonGlobal.CheckedChanged += new System.EventHandler( this.radioButtonGlobal_CheckedChanged );
            // 
            // radioButtonCustom
            // 
            this.radioButtonCustom.AutoSize = true;
            this.radioButtonCustom.Location = new System.Drawing.Point( 128, 10 );
            this.radioButtonCustom.Name = "radioButtonCustom";
            this.radioButtonCustom.Size = new System.Drawing.Size( 107, 16 );
            this.radioButtonCustom.TabIndex = 10;
            this.radioButtonCustom.TabStop = true;
            this.radioButtonCustom.Text = "自定义股票清单";
            this.radioButtonCustom.UseVisualStyleBackColor = true;
            this.radioButtonCustom.CheckedChanged += new System.EventHandler( this.radioButtonCustom_CheckedChanged );
            // 
            // ScanPrimaryControlSub3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.radioButtonCustom );
            this.Controls.Add( this.radioButtonGlobal );
            this.Controls.Add( this.ButtonSave );
            this.Controls.Add( this.ButtonLoad );
            this.Controls.Add( this.ListViewStock );
            this.Controls.Add( this.ButtonAdd );
            this.Name = "ScanPrimaryControlSub3";
            this.Size = new System.Drawing.Size( 580, 520 );
            this.Load += new System.EventHandler( this.ScanPrimaryControlSub3_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogStock;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView ListViewStock;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogStock;
        private System.Windows.Forms.RadioButton radioButtonGlobal;
        private System.Windows.Forms.RadioButton radioButtonCustom;
    }
}
