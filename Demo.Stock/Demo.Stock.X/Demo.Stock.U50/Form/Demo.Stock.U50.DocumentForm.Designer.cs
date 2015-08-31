namespace Demo.Stock.X.U50
{
    partial class DocumentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( DocumentForm ) );
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode( "节点4" );
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode( "节点5" );
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode( "节点6" );
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode( "节点7" );
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode( "节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4} );
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode( "节点1" );
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode( "节点2" );
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode( "节点3" );
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axTaskPanel1 = new AxXtremeTaskPanel.AxTaskPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axPushButton1 = new AxXtremeSuiteControls.AxPushButton();
            this.axTabControlStock = new AxXtremeSuiteControls.AxTabControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.axTaskPanel1 ) ).BeginInit();
            this.panel1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControlStock ) ).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.axTaskPanel1 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.treeView1 );
            this.splitContainer1.Panel2.Controls.Add( this.panel1 );
            this.splitContainer1.Panel2.Controls.Add( this.axTabControlStock );
            this.splitContainer1.Size = new System.Drawing.Size( 784, 564 );
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.TabIndex = 2;
            // 
            // axTaskPanel1
            // 
            this.axTaskPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTaskPanel1.Location = new System.Drawing.Point( 0, 0 );
            this.axTaskPanel1.Name = "axTaskPanel1";
            this.axTaskPanel1.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axTaskPanel1.OcxState" ) ) );
            this.axTaskPanel1.Size = new System.Drawing.Size( 148, 564 );
            this.axTaskPanel1.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point( 448, 0 );
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点4";
            treeNode1.Text = "节点4";
            treeNode2.Name = "节点5";
            treeNode2.Text = "节点5";
            treeNode3.Name = "节点6";
            treeNode3.Text = "节点6";
            treeNode4.Name = "节点7";
            treeNode4.Text = "节点7";
            treeNode5.Name = "节点0";
            treeNode5.Text = "节点0";
            treeNode6.Name = "节点1";
            treeNode6.Text = "节点1";
            treeNode7.Name = "节点2";
            treeNode7.Text = "节点2";
            treeNode8.Name = "节点3";
            treeNode8.Text = "节点3";
            this.treeView1.Nodes.AddRange( new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8} );
            this.treeView1.Size = new System.Drawing.Size( 181, 479 );
            this.treeView1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.axPushButton1 );
            this.panel1.Location = new System.Drawing.Point( 448, 499 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 181, 62 );
            this.panel1.TabIndex = 6;
            // 
            // axPushButton1
            // 
            this.axPushButton1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.axPushButton1.Location = new System.Drawing.Point( 31, 18 );
            this.axPushButton1.Name = "axPushButton1";
            this.axPushButton1.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axPushButton1.OcxState" ) ) );
            this.axPushButton1.Size = new System.Drawing.Size( 118, 27 );
            this.axPushButton1.TabIndex = 0;
            this.axPushButton1.ClickEvent += new System.EventHandler( this.axPushButton1_ClickEvent );
            // 
            // axTabControlStock
            // 
            this.axTabControlStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTabControlStock.Location = new System.Drawing.Point( 0, 0 );
            this.axTabControlStock.Name = "axTabControlStock";
            this.axTabControlStock.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axTabControlStock.OcxState" ) ) );
            this.axTabControlStock.Size = new System.Drawing.Size( 632, 564 );
            this.axTabControlStock.TabIndex = 0;
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size( 784, 564 );
            this.Controls.Add( this.splitContainer1 );
            this.Name = "DocumentForm";
            this.Text = "Demo.Stock.U50.DocumentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.DocumentForm_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.DocumentForm_FormClosing );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.axTaskPanel1 ) ).EndInit();
            this.panel1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.axPushButton1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.axTabControlStock ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private AxXtremeSuiteControls.AxTabControl axTabControlStock;
        private AxXtremeTaskPanel.AxTaskPanel axTaskPanel1;
        private System.Windows.Forms.Panel panel1;
        private AxXtremeSuiteControls.AxPushButton axPushButton1;
        private System.Windows.Forms.TreeView treeView1;

    }
}