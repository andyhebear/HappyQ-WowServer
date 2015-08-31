namespace Demo.Stock.X
{
    partial class OptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OptionForm ) );
            this.TreeView = new System.Windows.Forms.TreeView();
            this.TextBoxStockInfo = new System.Windows.Forms.TextBox();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point( 3, 12 );
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size( 140, 403 );
            this.TreeView.TabIndex = 0;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
            // 
            // TextBoxStockInfo
            // 
            this.TextBoxStockInfo.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.TextBoxStockInfo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBoxStockInfo.Location = new System.Drawing.Point( 2, 431 );
            this.TextBoxStockInfo.Name = "TextBoxStockInfo";
            this.TextBoxStockInfo.Size = new System.Drawing.Size( 120, 21 );
            this.TextBoxStockInfo.TabIndex = 0;
            this.TextBoxStockInfo.Text = "股票名称或代码";
            this.TextBoxStockInfo.Leave += new System.EventHandler( this.TextBoxStockInfo_Leave );
            this.TextBoxStockInfo.Enter += new System.EventHandler( this.TextBoxStockInfo_Enter );
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonSearch.Location = new System.Drawing.Point( 128, 431 );
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size( 73, 23 );
            this.ButtonSearch.TabIndex = 1;
            this.ButtonSearch.Text = "搜索股票";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler( this.ButtonSearch_Click );
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonOK.Location = new System.Drawing.Point( 244, 431 );
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size( 111, 23 );
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.Text = "确定";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler( this.ButtonOK_Click );
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonCancel.Location = new System.Drawing.Point( 361, 431 );
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
            this.Panel.Size = new System.Drawing.Size( 322, 403 );
            this.Panel.TabIndex = 2;
            // 
            // OptionForm
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size( 492, 473 );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.ButtonOK );
            this.Controls.Add( this.ButtonSearch );
            this.Controls.Add( this.TreeView );
            this.Controls.Add( this.TextBoxStockInfo );
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 600, 600 );
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 500, 500 );
            this.Name = "OptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主选项";
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.TextBox TextBoxStockInfo;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Panel Panel;
    }
}