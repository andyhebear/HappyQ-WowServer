namespace Demo.Stock.LHP.Main
{
    partial class HomeControlSub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( HomeControlSub ) );
            this.axCalendarCaptionBar = new AxXtremeCalendarControl.AxCalendarCaptionBar();
            ( (System.ComponentModel.ISupportInitialize)( this.axCalendarCaptionBar ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axCalendarCaptionBar
            // 
            this.axCalendarCaptionBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axCalendarCaptionBar.Enabled = true;
            this.axCalendarCaptionBar.Location = new System.Drawing.Point( 0, 0 );
            this.axCalendarCaptionBar.Name = "axCalendarCaptionBar";
            this.axCalendarCaptionBar.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axCalendarCaptionBar.OcxState" ) ) );
            this.axCalendarCaptionBar.Size = new System.Drawing.Size( 728, 732 );
            this.axCalendarCaptionBar.TabIndex = 0;
            // 
            // HomeControlSub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.axCalendarCaptionBar );
            this.Name = "HomeControlSub";
            this.Size = new System.Drawing.Size( 728, 732 );
            this.Load += new System.EventHandler( this.HomeControlSub_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axCalendarCaptionBar ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeCalendarControl.AxCalendarCaptionBar axCalendarCaptionBar;


    }
}
