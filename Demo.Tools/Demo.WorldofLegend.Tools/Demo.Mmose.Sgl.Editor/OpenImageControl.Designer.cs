using Demo.Mmose.Gui.Controls.ActiveX;
using Demo.Mmose.Gui.PropertyGrid.ActiveX;
using Demo.Mmose.Sgl.Editor;

namespace Demo.GOSE.SGL.Editor
{
    partial class OpenImageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OpenImageControl ) );
            this.WorkspaceViewer = new MyWorkspaceViewer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axLabelY = new Demo.Mmose.Gui.Controls.ActiveX.AxLabel();
            this.axLabelX = new Demo.Mmose.Gui.Controls.ActiveX.AxLabel();
            this.axFlatEditX = new Demo.Mmose.Gui.Controls.ActiveX.AxFlatEdit();
            this.axFlatEditY = new Demo.Mmose.Gui.Controls.ActiveX.AxFlatEdit();
            this.axPushButton1 = new Demo.Mmose.Gui.Controls.ActiveX.AxPushButton();
            this.axPropertyGrid = new Demo.Mmose.Gui.PropertyGrid.ActiveX.AxPropertyGrid();
            this.axPushButton2 = new Demo.Mmose.Gui.Controls.ActiveX.AxPushButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.axLabelY ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axLabelX ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axFlatEditX ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axFlatEditY ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPropertyGrid ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton2 ) ).BeginInit();
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
            this.WorkspaceViewer.Size = new System.Drawing.Size( 400, 454 );
            this.WorkspaceViewer.TabIndex = 11;
            this.WorkspaceViewer.Text = "workspaceViewer";
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
            this.splitContainer1.Panel2.Controls.Add( this.axLabelY );
            this.splitContainer1.Panel2.Controls.Add( this.axLabelX );
            this.splitContainer1.Panel2.Controls.Add( this.axFlatEditX );
            this.splitContainer1.Panel2.Controls.Add( this.axFlatEditY );
            this.splitContainer1.Panel2.Controls.Add( this.axPushButton1 );
            this.splitContainer1.Panel2.Controls.Add( this.axPropertyGrid );
            this.splitContainer1.Size = new System.Drawing.Size( 600, 454 );
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 12;
            // 
            // axLabelY
            // 
            this.axLabelY.Location = new System.Drawing.Point( 12, 379 );
            this.axLabelY.Name = "axLabelY";
            this.axLabelY.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axLabelY.OcxState" ) ) );
            this.axLabelY.Size = new System.Drawing.Size( 50, 18 );
            this.axLabelY.TabIndex = 15;
            // 
            // axLabelX
            // 
            this.axLabelX.Location = new System.Drawing.Point( 12, 351 );
            this.axLabelX.Name = "axLabelX";
            this.axLabelX.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axLabelX.OcxState" ) ) );
            this.axLabelX.Size = new System.Drawing.Size( 50, 18 );
            this.axLabelX.TabIndex = 15;
            // 
            // axFlatEditX
            // 
            this.axFlatEditX.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.axFlatEditX.Location = new System.Drawing.Point( 68, 348 );
            this.axFlatEditX.Name = "axFlatEditX";
            this.axFlatEditX.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axFlatEditX.OcxState" ) ) );
            this.axFlatEditX.Size = new System.Drawing.Size( 80, 18 );
            this.axFlatEditX.TabIndex = 14;
            // 
            // axFlatEditY
            // 
            this.axFlatEditY.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.axFlatEditY.Location = new System.Drawing.Point( 68, 378 );
            this.axFlatEditY.Name = "axFlatEditY";
            this.axFlatEditY.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axFlatEditY.OcxState" ) ) );
            this.axFlatEditY.Size = new System.Drawing.Size( 80, 18 );
            this.axFlatEditY.TabIndex = 14;
            // 
            // axPushButton1
            // 
            this.axPushButton1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.axPushButton1.Location = new System.Drawing.Point( 48, 310 );
            this.axPushButton1.Name = "axPushButton1";
            this.axPushButton1.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axPushButton1.OcxState" ) ) );
            this.axPushButton1.Size = new System.Drawing.Size( 100, 32 );
            this.axPushButton1.TabIndex = 13;
            this.axPushButton1.ClickEvent += new System.EventHandler( this.axPushButton1_ClickEvent );
            // 
            // axPropertyGrid
            // 
            this.axPropertyGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.axPropertyGrid.Location = new System.Drawing.Point( 0, 0 );
            this.axPropertyGrid.Name = "axPropertyGrid";
            this.axPropertyGrid.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axPropertyGrid.OcxState" ) ) );
            this.axPropertyGrid.Size = new System.Drawing.Size( 196, 304 );
            this.axPropertyGrid.TabIndex = 12;
            // 
            // axPushButton2
            // 
            this.axPushButton2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.axPushButton2.Location = new System.Drawing.Point( 48, 403 );
            this.axPushButton2.Name = "axPushButton2";
            this.axPushButton2.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axPushButton2.OcxState" ) ) );
            this.axPushButton2.Size = new System.Drawing.Size( 100, 32 );
            this.axPushButton2.TabIndex = 16;
            this.axPushButton2.ClickEvent += new System.EventHandler( this.axPushButton2_ClickEvent );
            // 
            // OpenImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.splitContainer1 );
            this.Name = "OpenImageControl";
            this.Size = new System.Drawing.Size( 600, 454 );
            this.Load += new System.EventHandler( this.OpenImage_Load );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.axLabelY ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axLabelX ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axFlatEditX ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axFlatEditY ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPropertyGrid ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton2 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private AxPropertyGrid axPropertyGrid;
        private AxPushButton axPushButton1;
        public MyWorkspaceViewer WorkspaceViewer;
        private AxLabel axLabelY;
        private AxLabel axLabelX;
        public AxFlatEdit axFlatEditX;
        public AxFlatEdit axFlatEditY;
        private AxPushButton axPushButton2;

    }
}
