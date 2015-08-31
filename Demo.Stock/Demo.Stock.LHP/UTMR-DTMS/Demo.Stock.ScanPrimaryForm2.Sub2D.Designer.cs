namespace Demo.Stock.LHP
{
    partial class ScanPrimary2ControlSub2D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ScanPrimary2ControlSub2D ) );
            this.axTabControl = new AxXtremeSuiteControls.AxTabControl();
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControl ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axTabControl
            // 
            this.axTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTabControl.Location = new System.Drawing.Point( 0, 0 );
            this.axTabControl.Name = "axTabControl";
            this.axTabControl.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axTabControl.OcxState" ) ) );
            this.axTabControl.Size = new System.Drawing.Size( 580, 520 );
            this.axTabControl.TabIndex = 3;
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.axTabControl );
            this.Name = "Demo";
            this.Size = new System.Drawing.Size( 580, 520 );
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControl ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeSuiteControls.AxTabControl axTabControl;
    }
}
