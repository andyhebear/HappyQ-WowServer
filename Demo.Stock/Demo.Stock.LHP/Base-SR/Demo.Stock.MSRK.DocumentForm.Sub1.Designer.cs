namespace Demo.Stock.LHP.BaseSR
{
    partial class DocumentMSRKControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( DocumentMSRKControl ) );
            this.GroupBoxStockInfo = new System.Windows.Forms.GroupBox();
            this.LabelPriceChangeInfo = new System.Windows.Forms.Label();
            this.LabelTrendInfo = new System.Windows.Forms.Label();
            this.LabelVolumeInfo = new System.Windows.Forms.Label();
            this.LabelLowInfo = new System.Windows.Forms.Label();
            this.LabelHighInfo = new System.Windows.Forms.Label();
            this.LabelCloseInfo = new System.Windows.Forms.Label();
            this.LabelOpenInfo = new System.Windows.Forms.Label();
            this.LabelPriceChange = new System.Windows.Forms.Label();
            this.LabelTrend = new System.Windows.Forms.Label();
            this.LabelVolume = new System.Windows.Forms.Label();
            this.LabelLow = new System.Windows.Forms.Label();
            this.LabelHigh = new System.Windows.Forms.Label();
            this.LabelClose = new System.Windows.Forms.Label();
            this.LabelOpen = new System.Windows.Forms.Label();
            this.axReportControl1 = new AxXtremeReportControl.AxReportControl();
            this.axReportControl2 = new AxXtremeReportControl.AxReportControl();
            this.GroupBoxStockInfo.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.axReportControl1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axReportControl2 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxStockInfo
            // 
            this.GroupBoxStockInfo.Controls.Add( this.LabelPriceChangeInfo );
            this.GroupBoxStockInfo.Controls.Add( this.LabelTrendInfo );
            this.GroupBoxStockInfo.Controls.Add( this.LabelVolumeInfo );
            this.GroupBoxStockInfo.Controls.Add( this.LabelLowInfo );
            this.GroupBoxStockInfo.Controls.Add( this.LabelHighInfo );
            this.GroupBoxStockInfo.Controls.Add( this.LabelCloseInfo );
            this.GroupBoxStockInfo.Controls.Add( this.LabelOpenInfo );
            this.GroupBoxStockInfo.Controls.Add( this.LabelPriceChange );
            this.GroupBoxStockInfo.Controls.Add( this.LabelTrend );
            this.GroupBoxStockInfo.Controls.Add( this.LabelVolume );
            this.GroupBoxStockInfo.Controls.Add( this.LabelLow );
            this.GroupBoxStockInfo.Controls.Add( this.LabelHigh );
            this.GroupBoxStockInfo.Controls.Add( this.LabelClose );
            this.GroupBoxStockInfo.Controls.Add( this.LabelOpen );
            this.GroupBoxStockInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxStockInfo.Location = new System.Drawing.Point( 0, 222 );
            this.GroupBoxStockInfo.Name = "GroupBoxStockInfo";
            this.GroupBoxStockInfo.Size = new System.Drawing.Size( 579, 66 );
            this.GroupBoxStockInfo.TabIndex = 3;
            this.GroupBoxStockInfo.TabStop = false;
            this.GroupBoxStockInfo.Text = "当前K线信息";
            // 
            // LabelPriceChangeInfo
            // 
            this.LabelPriceChangeInfo.Location = new System.Drawing.Point( 510, 42 );
            this.LabelPriceChangeInfo.Name = "LabelPriceChangeInfo";
            this.LabelPriceChangeInfo.Size = new System.Drawing.Size( 53, 12 );
            this.LabelPriceChangeInfo.TabIndex = 1;
            this.LabelPriceChangeInfo.Text = "+000%";
            this.LabelPriceChangeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTrendInfo
            // 
            this.LabelTrendInfo.Location = new System.Drawing.Point( 416, 42 );
            this.LabelTrendInfo.Name = "LabelTrendInfo";
            this.LabelTrendInfo.Size = new System.Drawing.Size( 53, 12 );
            this.LabelTrendInfo.TabIndex = 1;
            this.LabelTrendInfo.Text = "↔";
            this.LabelTrendInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelVolumeInfo
            // 
            this.LabelVolumeInfo.Location = new System.Drawing.Point( 334, 42 );
            this.LabelVolumeInfo.Name = "LabelVolumeInfo";
            this.LabelVolumeInfo.Size = new System.Drawing.Size( 41, 12 );
            this.LabelVolumeInfo.TabIndex = 1;
            this.LabelVolumeInfo.Text = "00000000";
            this.LabelVolumeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelLowInfo
            // 
            this.LabelLowInfo.Location = new System.Drawing.Point( 252, 42 );
            this.LabelLowInfo.Name = "LabelLowInfo";
            this.LabelLowInfo.Size = new System.Drawing.Size( 41, 12 );
            this.LabelLowInfo.TabIndex = 1;
            this.LabelLowInfo.Text = "000";
            this.LabelLowInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelHighInfo
            // 
            this.LabelHighInfo.Location = new System.Drawing.Point( 170, 42 );
            this.LabelHighInfo.Name = "LabelHighInfo";
            this.LabelHighInfo.Size = new System.Drawing.Size( 41, 12 );
            this.LabelHighInfo.TabIndex = 1;
            this.LabelHighInfo.Text = "000";
            this.LabelHighInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelCloseInfo
            // 
            this.LabelCloseInfo.Location = new System.Drawing.Point( 88, 42 );
            this.LabelCloseInfo.Name = "LabelCloseInfo";
            this.LabelCloseInfo.Size = new System.Drawing.Size( 41, 12 );
            this.LabelCloseInfo.TabIndex = 1;
            this.LabelCloseInfo.Text = "000";
            this.LabelCloseInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelOpenInfo
            // 
            this.LabelOpenInfo.Location = new System.Drawing.Point( 6, 42 );
            this.LabelOpenInfo.Name = "LabelOpenInfo";
            this.LabelOpenInfo.Size = new System.Drawing.Size( 41, 12 );
            this.LabelOpenInfo.TabIndex = 1;
            this.LabelOpenInfo.Text = "000";
            this.LabelOpenInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelPriceChange
            // 
            this.LabelPriceChange.AutoSize = true;
            this.LabelPriceChange.Location = new System.Drawing.Point( 510, 17 );
            this.LabelPriceChange.Name = "LabelPriceChange";
            this.LabelPriceChange.Size = new System.Drawing.Size( 53, 12 );
            this.LabelPriceChange.TabIndex = 0;
            this.LabelPriceChange.Text = "价格变动";
            // 
            // LabelTrend
            // 
            this.LabelTrend.AutoSize = true;
            this.LabelTrend.Location = new System.Drawing.Point( 416, 17 );
            this.LabelTrend.Name = "LabelTrend";
            this.LabelTrend.Size = new System.Drawing.Size( 53, 12 );
            this.LabelTrend.TabIndex = 0;
            this.LabelTrend.Text = "趋势方向";
            // 
            // LabelVolume
            // 
            this.LabelVolume.AutoSize = true;
            this.LabelVolume.Location = new System.Drawing.Point( 334, 17 );
            this.LabelVolume.Name = "LabelVolume";
            this.LabelVolume.Size = new System.Drawing.Size( 41, 12 );
            this.LabelVolume.TabIndex = 0;
            this.LabelVolume.Text = "成交量";
            // 
            // LabelLow
            // 
            this.LabelLow.AutoSize = true;
            this.LabelLow.Location = new System.Drawing.Point( 252, 17 );
            this.LabelLow.Name = "LabelLow";
            this.LabelLow.Size = new System.Drawing.Size( 41, 12 );
            this.LabelLow.TabIndex = 0;
            this.LabelLow.Text = "最低价";
            // 
            // LabelHigh
            // 
            this.LabelHigh.AutoSize = true;
            this.LabelHigh.Location = new System.Drawing.Point( 170, 17 );
            this.LabelHigh.Name = "LabelHigh";
            this.LabelHigh.Size = new System.Drawing.Size( 41, 12 );
            this.LabelHigh.TabIndex = 0;
            this.LabelHigh.Text = "最高价";
            // 
            // LabelClose
            // 
            this.LabelClose.AutoSize = true;
            this.LabelClose.Location = new System.Drawing.Point( 88, 17 );
            this.LabelClose.Name = "LabelClose";
            this.LabelClose.Size = new System.Drawing.Size( 41, 12 );
            this.LabelClose.TabIndex = 0;
            this.LabelClose.Text = "收盘价";
            // 
            // LabelOpen
            // 
            this.LabelOpen.AutoSize = true;
            this.LabelOpen.Location = new System.Drawing.Point( 6, 17 );
            this.LabelOpen.Name = "LabelOpen";
            this.LabelOpen.Size = new System.Drawing.Size( 41, 12 );
            this.LabelOpen.TabIndex = 0;
            this.LabelOpen.Text = "开盘价";
            // 
            // axReportControl1
            // 
            this.axReportControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axReportControl1.Location = new System.Drawing.Point( 0, 0 );
            this.axReportControl1.Name = "axReportControl1";
            this.axReportControl1.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axReportControl1.OcxState" ) ) );
            this.axReportControl1.Size = new System.Drawing.Size( 579, 222 );
            this.axReportControl1.TabIndex = 4;
            // 
            // axReportControl2
            // 
            this.axReportControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.axReportControl2.Location = new System.Drawing.Point( 0, 300 );
            this.axReportControl2.Name = "axReportControl2";
            this.axReportControl2.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axReportControl2.OcxState" ) ) );
            this.axReportControl2.Size = new System.Drawing.Size( 579, 222 );
            this.axReportControl2.TabIndex = 5;
            // 
            // DocumentMSRKControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.axReportControl2 );
            this.Controls.Add( this.GroupBoxStockInfo );
            this.Controls.Add( this.axReportControl1 );
            this.Name = "DocumentMSRKControl";
            this.Size = new System.Drawing.Size( 579, 522 );
            this.Load += new System.EventHandler( this.DocumentMSRKControl_Load );
            this.GroupBoxStockInfo.ResumeLayout( false );
            this.GroupBoxStockInfo.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.axReportControl1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axReportControl2 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxStockInfo;
        private System.Windows.Forms.Label LabelPriceChangeInfo;
        private System.Windows.Forms.Label LabelTrendInfo;
        private System.Windows.Forms.Label LabelVolumeInfo;
        private System.Windows.Forms.Label LabelLowInfo;
        private System.Windows.Forms.Label LabelHighInfo;
        private System.Windows.Forms.Label LabelCloseInfo;
        private System.Windows.Forms.Label LabelOpenInfo;
        private System.Windows.Forms.Label LabelPriceChange;
        private System.Windows.Forms.Label LabelTrend;
        private System.Windows.Forms.Label LabelVolume;
        private System.Windows.Forms.Label LabelLow;
        private System.Windows.Forms.Label LabelHigh;
        private System.Windows.Forms.Label LabelClose;
        private System.Windows.Forms.Label LabelOpen;
        private AxXtremeReportControl.AxReportControl axReportControl1;
        private AxXtremeReportControl.AxReportControl axReportControl2;
    }
}
