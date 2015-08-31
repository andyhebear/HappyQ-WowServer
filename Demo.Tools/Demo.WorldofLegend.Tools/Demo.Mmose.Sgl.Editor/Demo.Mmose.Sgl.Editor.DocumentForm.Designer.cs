using Demo.Mmose.Gui.TaskPanel.ActiveX;
using Demo.Mmose.Gui.Controls.ActiveX;

namespace Demo.GOSE.SGL.Editor
{
    partial class SGLEditorDocumentForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SGLEditorDocumentForm ) );
            this.axTaskPanel = new Demo.Mmose.Gui.TaskPanel.ActiveX.AxTaskPanel();
            this.ListViewSGLImage = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.ListViewSGLFrame = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.Splitter1 = new System.Windows.Forms.Splitter();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.axTabControl = new Demo.Mmose.Gui.Controls.ActiveX.AxTabControl();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            ( (System.ComponentModel.ISupportInitialize)( this.axTaskPanel ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControl ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axTaskPanel
            // 
            this.axTaskPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTaskPanel.Location = new System.Drawing.Point( 0, 0 );
            this.axTaskPanel.Name = "axTaskPanel";
            this.axTaskPanel.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axTaskPanel.OcxState" ) ) );
            this.axTaskPanel.Size = new System.Drawing.Size( 294, 491 );
            this.axTaskPanel.TabIndex = 0;
            // 
            // ListViewSGLImage
            // 
            this.ListViewSGLImage.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewSGLImage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewSGLImage.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader14} );
            this.ListViewSGLImage.ContextMenuStrip = this.contextMenuStrip1;
            this.ListViewSGLImage.FullRowSelect = true;
            this.ListViewSGLImage.GridLines = true;
            this.ListViewSGLImage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewSGLImage.HideSelection = false;
            this.ListViewSGLImage.Location = new System.Drawing.Point( 316, 0 );
            this.ListViewSGLImage.MultiSelect = false;
            this.ListViewSGLImage.Name = "ListViewSGLImage";
            this.ListViewSGLImage.Size = new System.Drawing.Size( 245, 240 );
            this.ListViewSGLImage.TabIndex = 2;
            this.ListViewSGLImage.UseCompatibleStateImageBehavior = false;
            this.ListViewSGLImage.View = System.Windows.Forms.View.Details;
            this.ListViewSGLImage.SelectedIndexChanged += new System.EventHandler( this.ListViewSGLImage_SelectedIndexChanged );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "格式";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "帧数";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip2";
            this.contextMenuStrip1.Size = new System.Drawing.Size( 61, 4 );
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler( this.contextMenuStrip1_Opening );
            // 
            // ListViewSGLFrame
            // 
            this.ListViewSGLFrame.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewSGLFrame.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewSGLFrame.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10} );
            this.ListViewSGLFrame.ContextMenuStrip = this.contextMenuStrip2;
            this.ListViewSGLFrame.FullRowSelect = true;
            this.ListViewSGLFrame.GridLines = true;
            this.ListViewSGLFrame.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewSGLFrame.HideSelection = false;
            this.ListViewSGLFrame.Location = new System.Drawing.Point( 316, 246 );
            this.ListViewSGLFrame.MultiSelect = false;
            this.ListViewSGLFrame.Name = "ListViewSGLFrame";
            this.ListViewSGLFrame.Size = new System.Drawing.Size( 245, 229 );
            this.ListViewSGLFrame.TabIndex = 3;
            this.ListViewSGLFrame.UseCompatibleStateImageBehavior = false;
            this.ListViewSGLFrame.View = System.Windows.Forms.View.Details;
            this.ListViewSGLFrame.SelectedIndexChanged += new System.EventHandler( this.ListViewSGLFrame_SelectedIndexChanged );
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "序号";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "宽度";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "高度";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "中心X";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "中心Y";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "块数X";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "块数Y";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size( 61, 4 );
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler( this.contextMenuStripSGLFrame_Opening );
            // 
            // Splitter1
            // 
            this.Splitter1.BackColor = System.Drawing.SystemColors.Window;
            this.Splitter1.Location = new System.Drawing.Point( 294, 0 );
            this.Splitter1.Name = "Splitter1";
            this.Splitter1.Size = new System.Drawing.Size( 3, 491 );
            this.Splitter1.TabIndex = 6;
            this.Splitter1.TabStop = false;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "序号";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "格式";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "帧数";
            // 
            // axTabControl
            // 
            this.axTabControl.Location = new System.Drawing.Point( 567, 246 );
            this.axTabControl.Name = "axTabControl";
            this.axTabControl.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axTabControl.OcxState" ) ) );
            this.axTabControl.Size = new System.Drawing.Size( 245, 229 );
            this.axTabControl.TabIndex = 8;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "补丁";
            // 
            // SGLEditorDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size( 832, 491 );
            this.Controls.Add( this.ListViewSGLImage );
            this.Controls.Add( this.ListViewSGLFrame );
            this.Controls.Add( this.axTabControl );
            this.Controls.Add( this.Splitter1 );
            this.Controls.Add( this.axTaskPanel );
            this.Name = "SGLEditorDocumentForm";
            this.Text = "Demo.GOSE.SGL.Editor.DocumentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler( this.SGLEditorDocumentForm_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.SGLEditorDocumentForm_FormClosing );
            ( (System.ComponentModel.ISupportInitialize)( this.axTaskPanel ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControl ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxTaskPanel axTaskPanel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Splitter Splitter1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private AxTabControl axTabControl;
        public System.Windows.Forms.ListView ListViewSGLImage;
        public System.Windows.Forms.ListView ListViewSGLFrame;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader14;
    }
}