namespace Demo.Stock.X
{
    partial class OptionCControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OptionCControl ) );
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.ListViewStockInfo = new System.Windows.Forms.ListView();
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
            this.ButtonScanAllStock = new System.Windows.Forms.Button();
            this.ButtonSelectTheStock = new System.Windows.Forms.Button();
            this.ButtonKLine = new System.Windows.Forms.Button();
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
            // ListViewStockInfo
            // 
            this.ListViewStockInfo.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ListViewStockInfo.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
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
            this.ListViewStockInfo.FullRowSelect = true;
            this.ListViewStockInfo.Location = new System.Drawing.Point( 0, 35 );
            this.ListViewStockInfo.MultiSelect = false;
            this.ListViewStockInfo.Name = "ListViewStockInfo";
            this.ListViewStockInfo.Size = new System.Drawing.Size( 330, 344 );
            this.ListViewStockInfo.TabIndex = 1;
            this.ListViewStockInfo.UseCompatibleStateImageBehavior = false;
            this.ListViewStockInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 1;
            this.columnHeader1.Text = "股票代码";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "股票名称";
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
            // ButtonScanAllStock
            // 
            this.ButtonScanAllStock.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonScanAllStock.Enabled = false;
            this.ButtonScanAllStock.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonScanAllStock.Location = new System.Drawing.Point( 119, 385 );
            this.ButtonScanAllStock.Name = "ButtonScanAllStock";
            this.ButtonScanAllStock.Size = new System.Drawing.Size( 101, 23 );
            this.ButtonScanAllStock.TabIndex = 1;
            this.ButtonScanAllStock.Text = "扫描全部股票";
            this.ButtonScanAllStock.UseVisualStyleBackColor = true;
            // 
            // ButtonSelectTheStock
            // 
            this.ButtonSelectTheStock.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonSelectTheStock.Enabled = false;
            this.ButtonSelectTheStock.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonSelectTheStock.Location = new System.Drawing.Point( 226, 385 );
            this.ButtonSelectTheStock.Name = "ButtonSelectTheStock";
            this.ButtonSelectTheStock.Size = new System.Drawing.Size( 101, 23 );
            this.ButtonSelectTheStock.TabIndex = 1;
            this.ButtonSelectTheStock.Text = "扫描所选股票";
            this.ButtonSelectTheStock.UseVisualStyleBackColor = true;
            // 
            // ButtonKLine
            // 
            this.ButtonKLine.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonKLine.Enabled = false;
            this.ButtonKLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonKLine.Location = new System.Drawing.Point( 3, 385 );
            this.ButtonKLine.Name = "ButtonKLine";
            this.ButtonKLine.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonKLine.TabIndex = 1;
            this.ButtonKLine.Text = "显示k⁮线图";
            this.ButtonKLine.UseVisualStyleBackColor = true;
            // 
            // OptionCControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.ListViewStockInfo );
            this.Controls.Add( this.axShortcutCaption );
            this.Controls.Add( this.ButtonKLine );
            this.Controls.Add( this.ButtonScanAllStock );
            this.Controls.Add( this.ButtonSelectTheStock );
            this.Name = "OptionCControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        public System.Windows.Forms.ListView ListViewStockInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button ButtonScanAllStock;
        private System.Windows.Forms.Button ButtonSelectTheStock;
        private System.Windows.Forms.Button ButtonKLine;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}
