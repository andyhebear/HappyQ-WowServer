namespace Demo.Stock.LHP
{
    partial class DownScanOptionForm
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
            this.Panel = new System.Windows.Forms.Panel();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.button2 = new System.Windows.Forms.Button();
            this.ButtonScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Location = new System.Drawing.Point( 202, 5 );
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size( 580, 520 );
            this.Panel.TabIndex = 10;
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point( 3, 5 );
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size( 193, 520 );
            this.TreeView.TabIndex = 9;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point( 697, 531 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 85, 29 );
            this.button2.TabIndex = 7;
            this.button2.Text = "取消扫描";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ButtonScan
            // 
            this.ButtonScan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonScan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonScan.Location = new System.Drawing.Point( 595, 531 );
            this.ButtonScan.Name = "ButtonScan";
            this.ButtonScan.Size = new System.Drawing.Size( 96, 29 );
            this.ButtonScan.TabIndex = 8;
            this.ButtonScan.Text = "开始扫描";
            this.ButtonScan.UseVisualStyleBackColor = true;
            // 
            // DownScanOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 784, 564 );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.TreeView );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.ButtonScan );
            this.Name = "DownScanOptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Demo";
            this.Load += new System.EventHandler( this.DownScanOptionForm_Load );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ButtonScan;
    }
}