using Demo.Mmose.Gui.CommandBars;
using Demo.Mmose.Gui.CommandBars.ActiveX;

namespace Demo.GOSE.SGL.Editor
{
    partial class SGLEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SGLEditorForm ) );
            this.axImageManager = new Demo.Mmose.Gui.CommandBars.ActiveX.AxImageManager();
            this.axCommandBars = new Demo.Mmose.Gui.CommandBars.ActiveX.AxCommandBars();
            ( (System.ComponentModel.ISupportInitialize)( this.axImageManager ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axCommandBars ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axImageManager
            // 
            this.axImageManager.Enabled = true;
            this.axImageManager.Location = new System.Drawing.Point( 42, 12 );
            this.axImageManager.Name = "axImageManager";
            this.axImageManager.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axImageManager.OcxState" ) ) );
            this.axImageManager.Size = new System.Drawing.Size( 24, 24 );
            this.axImageManager.TabIndex = 0;
            // 
            // axCommandBars
            // 
            this.axCommandBars.Enabled = true;
            this.axCommandBars.Location = new System.Drawing.Point( 12, 12 );
            this.axCommandBars.Name = "axCommandBars";
            this.axCommandBars.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axCommandBars.OcxState" ) ) );
            this.axCommandBars.Size = new System.Drawing.Size( 24, 24 );
            this.axCommandBars.TabIndex = 1;
            this.axCommandBars.UpdateEvent += new Demo.Mmose.Gui.CommandBars.ActiveX._DCommandBarsEvents_UpdateEventHandler( this.axCommandBars_UpdateEvent );
            this.axCommandBars.Execute += new Demo.Mmose.Gui.CommandBars.ActiveX._DCommandBarsEvents_ExecuteEventHandler( this.axCommandBars_Execute );
            this.axCommandBars.Customization += new Demo.Mmose.Gui.CommandBars.ActiveX._DCommandBarsEvents_CustomizationEventHandler( this.axCommandBars_Customization );
            // 
            // SGLEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 792, 573 );
            this.Controls.Add( this.axCommandBars );
            this.Controls.Add( this.axImageManager );
            this.IsMdiContainer = true;
            this.Name = "SGLEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo.GOSE.SGL.Editor.Form(注册qq:285372272 价格:600元)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.SGLEditorForm_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axImageManager ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axCommandBars ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxImageManager axImageManager;
        public AxCommandBars axCommandBars;
    }
}