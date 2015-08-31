namespace Demo.Stock.X.U50
{
    partial class TaskEControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TaskEControl ) );
            this.label1 = new System.Windows.Forms.Label();
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ButtonKLine = new System.Windows.Forms.Button();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 338 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 89, 12 );
            this.label1.TabIndex = 4;
            this.label1.Text = "(共有几只股票)";
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
            // listView1
            // 
            this.listView1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.listView1.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4} );
            this.listView1.Location = new System.Drawing.Point( 0, 29 );
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size( 330, 298 );
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "股票代码";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "股票系数QA";
            this.columnHeader2.Width = 80;
            // 
            // ButtonKLine
            // 
            this.ButtonKLine.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonKLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonKLine.Location = new System.Drawing.Point( 236, 333 );
            this.ButtonKLine.Name = "ButtonKLine";
            this.ButtonKLine.Size = new System.Drawing.Size( 91, 23 );
            this.ButtonKLine.TabIndex = 1;
            this.ButtonKLine.Text = "显示K线图";
            this.ButtonKLine.UseVisualStyleBackColor = true;
            // 
            // LabelInfo
            // 
            this.LabelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.LabelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelInfo.Location = new System.Drawing.Point( 0, 362 );
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size( 330, 50 );
            this.LabelInfo.TabIndex = 12;
            this.LabelInfo.Text = "选择股票的详细信息";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "成交量";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "收盘价";
            // 
            // TaskEControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.LabelInfo );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.listView1 );
            this.Controls.Add( this.ButtonKLine );
            this.Controls.Add( this.axShortcutCaption );
            this.Name = "TaskEControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button ButtonKLine;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
