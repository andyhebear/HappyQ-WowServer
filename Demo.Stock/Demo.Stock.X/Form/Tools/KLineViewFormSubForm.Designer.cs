namespace Demo.Stock.X.Tools
{
    partial class KLineViewFormSubForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( KLineViewFormSubForm ) );
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.ButtonReverseSelect = new System.Windows.Forms.Button();
            this.ButtonAllSelect = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point( 0, 31 );
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size( 592, 292 );
            this.checkedListBox.TabIndex = 0;
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 592, 29 );
            this.axShortcutCaption.TabIndex = 4;
            // 
            // ButtonReverseSelect
            // 
            this.ButtonReverseSelect.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonReverseSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonReverseSelect.Location = new System.Drawing.Point( 81, 338 );
            this.ButtonReverseSelect.Name = "ButtonReverseSelect";
            this.ButtonReverseSelect.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonReverseSelect.TabIndex = 5;
            this.ButtonReverseSelect.Text = "反向选择";
            this.ButtonReverseSelect.UseVisualStyleBackColor = true;
            this.ButtonReverseSelect.Click += new System.EventHandler( this.ButtonReverseSelect_Click );
            // 
            // ButtonAllSelect
            // 
            this.ButtonAllSelect.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.ButtonAllSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonAllSelect.Location = new System.Drawing.Point( 0, 338 );
            this.ButtonAllSelect.Name = "ButtonAllSelect";
            this.ButtonAllSelect.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonAllSelect.TabIndex = 5;
            this.ButtonAllSelect.Text = "全部选择";
            this.ButtonAllSelect.UseVisualStyleBackColor = true;
            this.ButtonAllSelect.Click += new System.EventHandler( this.ButtonAllSelect_Click );
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonOK.Location = new System.Drawing.Point( 436, 338 );
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonOK.TabIndex = 5;
            this.ButtonOK.Text = "确定";
            this.ButtonOK.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonCancel.Location = new System.Drawing.Point( 517, 338 );
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // KLineViewFormSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 592, 373 );
            this.Controls.Add( this.ButtonCancel );
            this.Controls.Add( this.ButtonAllSelect );
            this.Controls.Add( this.ButtonOK );
            this.Controls.Add( this.ButtonReverseSelect );
            this.Controls.Add( this.checkedListBox );
            this.Controls.Add( this.axShortcutCaption );
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 800, 600 );
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 600, 400 );
            this.Name = "KLineViewFormSubForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择股票";
            this.TopMost = true;
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox;
        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.Button ButtonReverseSelect;
        private System.Windows.Forms.Button ButtonAllSelect;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;


    }
}