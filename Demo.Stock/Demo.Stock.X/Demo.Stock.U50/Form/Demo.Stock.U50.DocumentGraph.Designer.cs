﻿namespace Demo.Stock.X.U50
{
    partial class DocumentU50Graph
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
            this.chart1 = new Dundas.Charting.WinControl.Chart();
            ( (System.ComponentModel.ISupportInitialize)( this.chart1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point( 0, 0 );
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size( 400, 300 );
            this.chart1.TabIndex = 0;
            // 
            // UserU50Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add( this.chart1 );
            this.Name = "UserU50Graph";
            this.Size = new System.Drawing.Size( 400, 300 );
            this.Load += new System.EventHandler( this.UserU50Graph_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.chart1 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private Dundas.Charting.WinControl.Chart chart1;

    }
}
