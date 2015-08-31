namespace Demo.Stock.X
{
    partial class ConfigBControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ConfigBControl ) );
            this.LabelStockeInfo = new System.Windows.Forms.Label();
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.ColumnHeaderStockFilePath = new System.Windows.Forms.ColumnHeader();
            this.ListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // LabelStockeInfo
            // 
            this.LabelStockeInfo.BackColor = System.Drawing.SystemColors.Info;
            this.LabelStockeInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelStockeInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelStockeInfo.Location = new System.Drawing.Point( 0, 362 );
            this.LabelStockeInfo.Name = "LabelStockeInfo";
            this.LabelStockeInfo.Size = new System.Drawing.Size( 330, 50 );
            this.LabelStockeInfo.TabIndex = 9;
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 330, 29 );
            this.axShortcutCaption.TabIndex = 8;
            // 
            // ColumnHeaderStockFilePath
            // 
            this.ColumnHeaderStockFilePath.Text = "股票信息文件的所在位置";
            this.ColumnHeaderStockFilePath.Width = 300;
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
            this.ListView.Location = new System.Drawing.Point( 0, 29 );
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size( 330, 298 );
            this.ListView.TabIndex = 6;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
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
            // ConfigBControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.LabelStockeInfo );
            this.Controls.Add( this.axShortcutCaption );
            this.Controls.Add( this.ListView );
            this.Name = "ConfigBControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label LabelStockeInfo;
        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.ColumnHeader ColumnHeaderStockFilePath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ListView ListView;
    }
}
