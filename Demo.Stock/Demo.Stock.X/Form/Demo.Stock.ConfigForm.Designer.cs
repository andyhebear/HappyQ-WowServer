namespace Demo.Stock.X
{
    partial class ConfigForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ConfigForm ) );
            this.TreeView = new System.Windows.Forms.TreeView();
            this.ContextMenuStripDelete = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonNewItem = new System.Windows.Forms.Button();
            this.ButtonNewSubItem = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.ContextMenuStripDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.TreeView.ContextMenuStrip = this.ContextMenuStripDelete;
            this.TreeView.HideSelection = false;
            this.TreeView.LabelEdit = true;
            this.TreeView.Location = new System.Drawing.Point( 3, 12 );
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size( 140, 437 );
            this.TreeView.TabIndex = 1;
            this.TreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler( this.TreeView_AfterLabelEdit );
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
            // 
            // ContextMenuStripDelete
            // 
            this.ContextMenuStripDelete.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem} );
            this.ContextMenuStripDelete.Name = "ContextMenuStripDel";
            this.ContextMenuStripDelete.Size = new System.Drawing.Size( 95, 26 );
            this.ContextMenuStripDelete.Opening += new System.ComponentModel.CancelEventHandler( this.ContextMenuStripDelete_Opening );
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size( 94, 22 );
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // ButtonNewItem
            // 
            this.ButtonNewItem.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonNewItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonNewItem.Location = new System.Drawing.Point( 3, 463 );
            this.ButtonNewItem.Name = "ButtonNewItem";
            this.ButtonNewItem.Size = new System.Drawing.Size( 84, 23 );
            this.ButtonNewItem.TabIndex = 1;
            this.ButtonNewItem.Text = "新建项";
            this.ButtonNewItem.UseVisualStyleBackColor = true;
            this.ButtonNewItem.Click += new System.EventHandler( this.ButtonNewItem_Click );
            // 
            // ButtonNewSubItem
            // 
            this.ButtonNewSubItem.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonNewSubItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonNewSubItem.Location = new System.Drawing.Point( 90, 463 );
            this.ButtonNewSubItem.Name = "ButtonNewSubItem";
            this.ButtonNewSubItem.Size = new System.Drawing.Size( 84, 23 );
            this.ButtonNewSubItem.TabIndex = 1;
            this.ButtonNewSubItem.Text = "新建子项";
            this.ButtonNewSubItem.UseVisualStyleBackColor = true;
            this.ButtonNewSubItem.Click += new System.EventHandler( this.ButtonNewSubItem_Click );
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonSave.Enabled = false;
            this.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonSave.Location = new System.Drawing.Point( 263, 463 );
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size( 111, 23 );
            this.ButtonSave.TabIndex = 1;
            this.ButtonSave.Text = "保存";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler( this.ButtonSave_Click );
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonCancel.Location = new System.Drawing.Point( 394, 463 );
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size( 111, 23 );
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // Panel
            // 
            this.Panel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.Panel.Location = new System.Drawing.Point( 150, 12 );
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size( 355, 437 );
            this.Panel.TabIndex = 2;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.ButtonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size( 517, 498 );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.TreeView );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.ButtonNewSubItem );
            this.Controls.Add( this.ButtonSave );
            this.Controls.Add( this.ButtonNewItem );
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 600, 600 );
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 500, 500 );
            this.Name = "ConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置配置文件";
            this.Load += new System.EventHandler( this.ConfigForm_Load );
            this.ContextMenuStripDelete.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button ButtonNewItem;
        private System.Windows.Forms.Button ButtonNewSubItem;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripDelete;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}