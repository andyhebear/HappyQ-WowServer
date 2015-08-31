namespace Demo.Stock.X.Tools
{
    partial class KLineU50ConfigD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( KLineU50ConfigD ) );
            this.axShortcutCaption3 = new AxXtremeShortcutBar.AxShortcutCaption();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption3 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axShortcutCaption3
            // 
            this.axShortcutCaption3.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption3.Enabled = true;
            this.axShortcutCaption3.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption3.Name = "axShortcutCaption3";
            this.axShortcutCaption3.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption3.OcxState" ) ) );
            this.axShortcutCaption3.Size = new System.Drawing.Size( 330, 29 );
            this.axShortcutCaption3.TabIndex = 2;
            // 
            // KLineU50ConfigD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.axShortcutCaption3 );
            this.Name = "KLineU50ConfigD";
            this.Size = new System.Drawing.Size( 330, 412 );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption3 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption3;
    }
}
