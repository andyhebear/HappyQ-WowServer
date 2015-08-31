namespace Demo.Stock.LHP
{
    partial class ScanOptionForm
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
            this.ButtonScan = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // ButtonScan
            // 
            this.ButtonScan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonScan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonScan.Location = new System.Drawing.Point( 594, 528 );
            this.ButtonScan.Name = "ButtonScan";
            this.ButtonScan.Size = new System.Drawing.Size( 96, 29 );
            this.ButtonScan.TabIndex = 4;
            this.ButtonScan.Text = "开始扫描";
            this.ButtonScan.UseVisualStyleBackColor = true;
            this.ButtonScan.Click += new System.EventHandler( this.ButtonScan_Click );
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point( 696, 528 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 85, 29 );
            this.button2.TabIndex = 4;
            this.button2.Text = "取消扫描";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Panel
            // 
            this.Panel.Location = new System.Drawing.Point( 201, 2 );
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size( 580, 520 );
            this.Panel.TabIndex = 6;
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point( 2, 2 );
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size( 193, 520 );
            this.TreeView.TabIndex = 5;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
            // 
            // ScanOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 784, 564 );
            this.Controls.Add( this.Panel );
            this.Controls.Add( this.TreeView );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.ButtonScan );
            this.Name = "ScanOptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.Load += new System.EventHandler( this.ScanOptionForm_Load );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button ButtonScan;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.TreeView TreeView;
    }
}