namespace Demo.Stock.X.U50
{
    partial class DocumentReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( DocumentReport ) );
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "收盘价";
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 338 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 89, 12 );
            this.label1.TabIndex = 16;
            this.label1.Text = "(共有几只股票)";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "成交量";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "股票系数QA";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "股票代码";
            this.columnHeader1.Width = 100;
            // 
            // LabelInfo
            // 
            this.LabelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.LabelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelInfo.Location = new System.Drawing.Point( 0, 362 );
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size( 365, 50 );
            this.LabelInfo.TabIndex = 17;
            this.LabelInfo.Text = "选择股票的详细信息";
            // 
            // listView1
            // 
            this.listView1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.listView1.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7} );
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point( 0, 29 );
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size( 365, 298 );
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 365, 29 );
            this.axShortcutCaption.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point( 271, 333 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 91, 23 );
            this.button1.TabIndex = 20;
            this.button1.Text = "显示K线图";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // button2
            // 
            this.button2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point( 174, 333 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 91, 23 );
            this.button2.TabIndex = 20;
            this.button2.Text = "生成报表";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler( this.button1_Click );
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "扫描起始日期";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "K线数量";
            this.columnHeader4.Width = 100;
            // 
            // DocumentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.LabelInfo );
            this.Controls.Add( this.listView1 );
            this.Controls.Add( this.axShortcutCaption );
            this.Name = "DocumentReport";
            this.Size = new System.Drawing.Size( 365, 412 );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.ListView listView1;
        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
