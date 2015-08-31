namespace Demo.Stock.LHP.Main
{
    partial class OptionControlSub3
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
            this.ListViewScan = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.ButtonNewScan = new System.Windows.Forms.Button();
            this.CheckBoxScan = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ListViewScan
            // 
            this.ListViewScan.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ListViewScan.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4} );
            this.ListViewScan.ContextMenuStrip = this.contextMenuStrip;
            this.ListViewScan.FullRowSelect = true;
            this.ListViewScan.Location = new System.Drawing.Point( 0, 39 );
            this.ListViewScan.Name = "ListViewScan";
            this.ListViewScan.Size = new System.Drawing.Size( 580, 481 );
            this.ListViewScan.TabIndex = 2;
            this.ListViewScan.UseCompatibleStateImageBehavior = false;
            this.ListViewScan.View = System.Windows.Forms.View.Details;
            this.ListViewScan.MouseDown += new System.Windows.Forms.MouseEventHandler( this.ListViewScan_MouseDown );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "扫描触发器名称";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "股票清单名称";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SR策略名称";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "UTMR/DTMS策略名称";
            this.columnHeader4.Width = 120;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size( 61, 4 );
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler( this.contextMenuStrip_Opening );
            // 
            // ButtonNewScan
            // 
            this.ButtonNewScan.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonNewScan.Location = new System.Drawing.Point( 465, 2 );
            this.ButtonNewScan.Name = "ButtonNewScan";
            this.ButtonNewScan.Size = new System.Drawing.Size( 112, 30 );
            this.ButtonNewScan.TabIndex = 1;
            this.ButtonNewScan.Text = "新建扫描触发器";
            this.ButtonNewScan.UseVisualStyleBackColor = true;
            this.ButtonNewScan.Click += new System.EventHandler( this.ButtonNewScan_Click );
            // 
            // CheckBoxScan
            // 
            this.CheckBoxScan.AutoSize = true;
            this.CheckBoxScan.Checked = true;
            this.CheckBoxScan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxScan.Location = new System.Drawing.Point( 3, 10 );
            this.CheckBoxScan.Name = "CheckBoxScan";
            this.CheckBoxScan.Size = new System.Drawing.Size( 132, 16 );
            this.CheckBoxScan.TabIndex = 0;
            this.CheckBoxScan.Text = "允许启动扫描触发器";
            this.CheckBoxScan.UseVisualStyleBackColor = true;
            this.CheckBoxScan.CheckedChanged += new System.EventHandler( this.CheckBoxScan_CheckedChanged );
            // 
            // OptionControlSub3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.ListViewScan );
            this.Controls.Add( this.ButtonNewScan );
            this.Controls.Add( this.CheckBoxScan );
            this.Name = "OptionControlSub3";
            this.Size = new System.Drawing.Size( 580, 520 );
            this.Load += new System.EventHandler( this.OptionControlSub3_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListViewScan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button ButtonNewScan;
        private System.Windows.Forms.CheckBox CheckBoxScan;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
    }
}
