namespace Demo_R.O.S.E.LoginServer.LoginServer.ConfigInfo
{
    partial class ConfigInfoForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ConfigInfoForm ) );
            this.CommandBars = new Demo_G.O.S.E.GUI.CommandBars.ActiveX.AxCommandBars();
            this.ImageManagerGalleryStyles = new Demo_G.O.S.E.GUI.CommandBars.ActiveX.AxImageManager();
            ( (System.ComponentModel.ISupportInitialize)( this.CommandBars ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ImageManagerGalleryStyles ) ).BeginInit();
            this.SuspendLayout();
            // 
            // CommandBars
            // 
            this.CommandBars.Enabled = true;
            this.CommandBars.Location = new System.Drawing.Point( 0, 1 );
            this.CommandBars.Name = "CommandBars";
            this.CommandBars.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "CommandBars.OcxState" ) ) );
            this.CommandBars.Size = new System.Drawing.Size( 24, 24 );
            this.CommandBars.TabIndex = 0;
            this.CommandBars.UpdateEvent += new Demo_G.O.S.E.GUI.CommandBars.ActiveX._DCommandBarsEvents_UpdateEventHandler( this.axCommandBars_UpdateEvent );
            this.CommandBars.Execute += new Demo_G.O.S.E.GUI.CommandBars.ActiveX._DCommandBarsEvents_ExecuteEventHandler( this.axCommandBars_Execute );
            this.CommandBars.Customization += new Demo_G.O.S.E.GUI.CommandBars.ActiveX._DCommandBarsEvents_CustomizationEventHandler( this.axCommandBars_Customization );
            // 
            // ImageManagerGalleryStyles
            // 
            this.ImageManagerGalleryStyles.Enabled = true;
            this.ImageManagerGalleryStyles.Location = new System.Drawing.Point( 30, 1 );
            this.ImageManagerGalleryStyles.Name = "ImageManagerGalleryStyles";
            this.ImageManagerGalleryStyles.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "ImageManagerGalleryStyles.OcxState" ) ) );
            this.ImageManagerGalleryStyles.Size = new System.Drawing.Size( 24, 24 );
            this.ImageManagerGalleryStyles.TabIndex = 4;
            // 
            // ConfigInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 632, 453 );
            this.Controls.Add( this.ImageManagerGalleryStyles );
            this.Controls.Add( this.CommandBars );
            this.Name = "ConfigInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigInfoForm";
            this.Load += new System.EventHandler( this.ConfigInfoForm_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.CommandBars ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ImageManagerGalleryStyles ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private Demo_G.O.S.E.GUI.CommandBars.ActiveX.AxCommandBars CommandBars;
        private Demo_G.O.S.E.GUI.CommandBars.ActiveX.AxImageManager ImageManagerGalleryStyles;
    }
}