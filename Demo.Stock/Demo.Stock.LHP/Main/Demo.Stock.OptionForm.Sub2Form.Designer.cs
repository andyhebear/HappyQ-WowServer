namespace Demo.Stock.LHP.Main
{
    partial class OptionSub2From
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OptionSub2From ) );
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.CheckedListBoxStock = new System.Windows.Forms.CheckedListBox();
            this.ButtonAllSelect = new System.Windows.Forms.Button();
            this.ButtonReverseSelect = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 784, 30 );
            this.axShortcutCaption.TabIndex = 0;
            // 
            // CheckedListBoxStock
            // 
            this.CheckedListBoxStock.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.CheckedListBoxStock.CheckOnClick = true;
            this.CheckedListBoxStock.FormattingEnabled = true;
            this.CheckedListBoxStock.Location = new System.Drawing.Point( 0, 30 );
            this.CheckedListBoxStock.Name = "CheckedListBoxStock";
            this.CheckedListBoxStock.Size = new System.Drawing.Size( 784, 484 );
            this.CheckedListBoxStock.TabIndex = 1;
            // 
            // ButtonAllSelect
            // 
            this.ButtonAllSelect.Location = new System.Drawing.Point( 0, 529 );
            this.ButtonAllSelect.Name = "ButtonAllSelect";
            this.ButtonAllSelect.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonAllSelect.TabIndex = 2;
            this.ButtonAllSelect.Text = "全部选择";
            this.ButtonAllSelect.UseVisualStyleBackColor = true;
            this.ButtonAllSelect.Click += new System.EventHandler( this.ButtonAllSelect_Click );
            // 
            // ButtonReverseSelect
            // 
            this.ButtonReverseSelect.Location = new System.Drawing.Point( 81, 529 );
            this.ButtonReverseSelect.Name = "ButtonReverseSelect";
            this.ButtonReverseSelect.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonReverseSelect.TabIndex = 3;
            this.ButtonReverseSelect.Text = "反向选择";
            this.ButtonReverseSelect.UseVisualStyleBackColor = true;
            this.ButtonReverseSelect.Click += new System.EventHandler( this.ButtonReverseSelect_Click );
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point( 628, 529 );
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonOK.TabIndex = 4;
            this.ButtonOK.Text = "确定";
            this.ButtonOK.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point( 709, 529 );
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // OptionSub2From
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 784, 564 );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.ButtonOK );
            this.Controls.Add( this.ButtonReverseSelect );
            this.Controls.Add( this.ButtonAllSelect );
            this.Controls.Add( this.CheckedListBoxStock );
            this.Controls.Add( this.axShortcutCaption );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionSub2From";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择股票";
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.CheckedListBox CheckedListBoxStock;
        private System.Windows.Forms.Button ButtonAllSelect;
        private System.Windows.Forms.Button ButtonReverseSelect;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
    }
}