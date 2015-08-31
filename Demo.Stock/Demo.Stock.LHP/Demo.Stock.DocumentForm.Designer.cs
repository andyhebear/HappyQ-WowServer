namespace Demo.Stock.LHP
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
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.ListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point( 0, 0 );
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add( this.ListView );
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Size = new System.Drawing.Size( 1008, 732 );
            this.SplitContainer.SplitterDistance = 274;
            this.SplitContainer.TabIndex = 1;
            // 
            // ListView
            // 
            this.ListView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3} );
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.FullRowSelect = true;
            this.ListView.Location = new System.Drawing.Point( 0, 0 );
            this.ListView.MultiSelect = false;
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size( 274, 732 );
            this.ListView.TabIndex = 0;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.SelectedIndexChanged += new System.EventHandler( this.ListView_SelectedIndexChanged );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "代号";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "收盘价";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "成交量";
            this.columnHeader3.Width = 80;
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1008, 732 );
            this.Controls.Add( this.SplitContainer );
            this.Name = "DocumentForm";
            this.Text = "Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.DocumentForm_Load );
            this.SplitContainer.Panel1.ResumeLayout( false );
            this.SplitContainer.Panel2.ResumeLayout( false );
            this.SplitContainer.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}