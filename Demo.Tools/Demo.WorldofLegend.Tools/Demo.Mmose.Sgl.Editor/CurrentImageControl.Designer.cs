using Demo.Mmose.Gui.Controls.ActiveX;
using Demo.Mmose.Gui.PropertyGrid.ActiveX;

namespace Demo.GOSE.SGL.Editor
{
    partial class CurrentImageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( CurrentImageControl ) );
            this.WorkspaceViewer = new Atalasoft.Imaging.WinControls.WorkspaceViewer();
            this.axPropertyGrid = new Demo.Mmose.Gui.PropertyGrid.ActiveX.AxPropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axPushButton2 = new Demo.Mmose.Gui.Controls.ActiveX.AxPushButton();
            this.axPushButton = new Demo.Mmose.Gui.Controls.ActiveX.AxPushButton();
            this.axPushButton1 = new Demo.Mmose.Gui.Controls.ActiveX.AxPushButton();
            ( (System.ComponentModel.ISupportInitialize)( this.axPropertyGrid ) ).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // WorkspaceViewer
            // 
            this.WorkspaceViewer.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray;
            this.WorkspaceViewer.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "WorkspaceViewer.BackgroundImage" ) ) );
            this.WorkspaceViewer.Centered = true;
            this.WorkspaceViewer.DisplayProfile = null;
            this.WorkspaceViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkspaceViewer.Location = new System.Drawing.Point( 0, 0 );
            this.WorkspaceViewer.Magnifier.BackColor = System.Drawing.Color.White;
            this.WorkspaceViewer.Magnifier.BorderColor = System.Drawing.Color.Black;
            this.WorkspaceViewer.Magnifier.Size = new System.Drawing.Size( 100, 100 );
            this.WorkspaceViewer.Name = "WorkspaceViewer";
            this.WorkspaceViewer.OutputProfile = null;
            this.WorkspaceViewer.Selection = null;
            this.WorkspaceViewer.Size = new System.Drawing.Size( 400, 400 );
            this.WorkspaceViewer.TabIndex = 10;
            this.WorkspaceViewer.Text = "workspaceViewer";
            // 
            // axPropertyGrid
            // 
            this.axPropertyGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.axPropertyGrid.Location = new System.Drawing.Point( 0, 0 );
            this.axPropertyGrid.Name = "axPropertyGrid";
            this.axPropertyGrid.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axPropertyGrid.OcxState" ) ) );
            this.axPropertyGrid.Size = new System.Drawing.Size( 196, 304 );
            this.axPropertyGrid.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.WorkspaceViewer );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.axPushButton2 );
            this.splitContainer1.Panel2.Controls.Add( this.axPushButton );
            this.splitContainer1.Panel2.Controls.Add( this.axPushButton1 );
            this.splitContainer1.Panel2.Controls.Add( this.axPropertyGrid );
            this.splitContainer1.Size = new System.Drawing.Size( 600, 400 );
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 12;
            // 
            // axPushButton2
            // 
            this.axPushButton2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.axPushButton2.Location = new System.Drawing.Point( 48, 386 );
            this.axPushButton2.Name = "axPushButton2";
            this.axPushButton2.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axPushButton2.OcxState" ) ) );
            this.axPushButton2.Size = new System.Drawing.Size( 100, 32 );
            this.axPushButton2.TabIndex = 13;
            this.axPushButton2.ClickEvent += new System.EventHandler( this.axPushButton2_ClickEvent );
            // 
            // axPushButton
            // 
            this.axPushButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.axPushButton.Location = new System.Drawing.Point( 48, 348 );
            this.axPushButton.Name = "axPushButton";
            this.axPushButton.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axPushButton.OcxState" ) ) );
            this.axPushButton.Size = new System.Drawing.Size( 100, 32 );
            this.axPushButton.TabIndex = 13;
            this.axPushButton.ClickEvent += new System.EventHandler( this.axPushButton_ClickEvent );
            // 
            // axPushButton1
            // 
            this.axPushButton1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.axPushButton1.Location = new System.Drawing.Point( 48, 310 );
            this.axPushButton1.Name = "axPushButton1";
            this.axPushButton1.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axPushButton1.OcxState" ) ) );
            this.axPushButton1.Size = new System.Drawing.Size( 100, 32 );
            this.axPushButton1.TabIndex = 12;
            this.axPushButton1.ClickEvent += new System.EventHandler( this.axPushButton1_ClickEvent );
            // 
            // CurrentImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.splitContainer1 );
            this.Name = "CurrentImageControl";
            this.Size = new System.Drawing.Size( 600, 400 );
            this.Load += new System.EventHandler( this.CurrentImage_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axPropertyGrid ) ).EndInit();
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton1 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        public Atalasoft.Imaging.WinControls.WorkspaceViewer WorkspaceViewer;
        private AxPropertyGrid axPropertyGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private AxPushButton axPushButton1;
        private AxPushButton axPushButton;
        private AxPushButton axPushButton2;

    }
}
