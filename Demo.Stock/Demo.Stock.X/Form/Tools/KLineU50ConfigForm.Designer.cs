namespace Demo.Stock.X.Tools
{
    partial class KLineU50ConfigForm
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonCancel.Location = new System.Drawing.Point( 410, 438 );
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonCancel.TabIndex = 13;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // Panel
            // 
            this.Panel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.Panel.Location = new System.Drawing.Point( 155, 12 );
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size( 330, 412 );
            this.Panel.TabIndex = 12;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonOK.Location = new System.Drawing.Point( 329, 438 );
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonOK.TabIndex = 14;
            this.ButtonOK.Text = "开始搜索";
            this.ButtonOK.UseVisualStyleBackColor = true;
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.TreeView.HideSelection = false;
            this.TreeView.LabelEdit = true;
            this.TreeView.Location = new System.Drawing.Point( 8, 12 );
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size( 140, 412 );
            this.TreeView.TabIndex = 11;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
            // 
            // KLineU50ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 492, 473 );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.ButtonOK );
            this.Controls.Add( this.TreeView );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 600, 600 );
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 500, 500 );
            this.Name = "KLineU50ConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置U50策略";
            this.Load += new System.EventHandler( this.KLineU50ConfigForm_Load );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.TreeView TreeView;
    }
}