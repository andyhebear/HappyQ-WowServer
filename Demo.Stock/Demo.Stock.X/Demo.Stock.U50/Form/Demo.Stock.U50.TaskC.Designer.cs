namespace Demo.Stock.X.U50
{
    partial class TaskCControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TaskCControl ) );
            this.ButtonReverseSelect = new System.Windows.Forms.Button();
            this.ButtonAllSelect = new System.Windows.Forms.Button();
            this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.ComboBoxVariety = new System.Windows.Forms.ComboBox();
            this.ComboBoxPlate = new System.Windows.Forms.ComboBox();
            this.RadioButtonSelect = new System.Windows.Forms.RadioButton();
            this.RadioButtonALL = new System.Windows.Forms.RadioButton();
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.ButtonGetStock = new System.Windows.Forms.Button();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonReverseSelect
            // 
            this.ButtonReverseSelect.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonReverseSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonReverseSelect.Location = new System.Drawing.Point( 252, 333 );
            this.ButtonReverseSelect.Name = "ButtonReverseSelect";
            this.ButtonReverseSelect.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonReverseSelect.TabIndex = 9;
            this.ButtonReverseSelect.Text = "反向选择";
            this.ButtonReverseSelect.UseVisualStyleBackColor = true;
            this.ButtonReverseSelect.Click += new System.EventHandler( this.ButtonReverseSelect_Click );
            // 
            // ButtonAllSelect
            // 
            this.ButtonAllSelect.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonAllSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonAllSelect.Location = new System.Drawing.Point( 171, 333 );
            this.ButtonAllSelect.Name = "ButtonAllSelect";
            this.ButtonAllSelect.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonAllSelect.TabIndex = 9;
            this.ButtonAllSelect.Text = "全部选择";
            this.ButtonAllSelect.UseVisualStyleBackColor = true;
            this.ButtonAllSelect.Click += new System.EventHandler( this.ButtonAllSelect_Click );
            // 
            // CheckedListBox
            // 
            this.CheckedListBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.CheckedListBox.CheckOnClick = true;
            this.CheckedListBox.FormattingEnabled = true;
            this.CheckedListBox.Location = new System.Drawing.Point( 0, 131 );
            this.CheckedListBox.Name = "CheckedListBox";
            this.CheckedListBox.Size = new System.Drawing.Size( 330, 196 );
            this.CheckedListBox.TabIndex = 8;
            // 
            // ComboBoxVariety
            // 
            this.ComboBoxVariety.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ComboBoxVariety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxVariety.Enabled = false;
            this.ComboBoxVariety.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ComboBoxVariety.FormattingEnabled = true;
            this.ComboBoxVariety.Location = new System.Drawing.Point( 18, 105 );
            this.ComboBoxVariety.Name = "ComboBoxVariety";
            this.ComboBoxVariety.Size = new System.Drawing.Size( 173, 20 );
            this.ComboBoxVariety.TabIndex = 7;
            // 
            // ComboBoxPlate
            // 
            this.ComboBoxPlate.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ComboBoxPlate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPlate.Enabled = false;
            this.ComboBoxPlate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ComboBoxPlate.FormattingEnabled = true;
            this.ComboBoxPlate.Location = new System.Drawing.Point( 18, 79 );
            this.ComboBoxPlate.Name = "ComboBoxPlate";
            this.ComboBoxPlate.Size = new System.Drawing.Size( 173, 20 );
            this.ComboBoxPlate.TabIndex = 7;
            this.ComboBoxPlate.SelectedIndexChanged += new System.EventHandler( this.ComboBoxPlate_SelectedIndexChanged );
            // 
            // RadioButtonSelect
            // 
            this.RadioButtonSelect.AutoSize = true;
            this.RadioButtonSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonSelect.Location = new System.Drawing.Point( 3, 57 );
            this.RadioButtonSelect.Name = "RadioButtonSelect";
            this.RadioButtonSelect.Size = new System.Drawing.Size( 77, 17 );
            this.RadioButtonSelect.TabIndex = 6;
            this.RadioButtonSelect.Text = "制定股票";
            this.RadioButtonSelect.UseVisualStyleBackColor = true;
            this.RadioButtonSelect.CheckedChanged += new System.EventHandler( this.RadioButtonSelect_CheckedChanged );
            // 
            // RadioButtonALL
            // 
            this.RadioButtonALL.AutoSize = true;
            this.RadioButtonALL.Checked = true;
            this.RadioButtonALL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioButtonALL.Location = new System.Drawing.Point( 3, 35 );
            this.RadioButtonALL.Name = "RadioButtonALL";
            this.RadioButtonALL.Size = new System.Drawing.Size( 77, 17 );
            this.RadioButtonALL.TabIndex = 6;
            this.RadioButtonALL.TabStop = true;
            this.RadioButtonALL.Text = "所有股票";
            this.RadioButtonALL.UseVisualStyleBackColor = true;
            this.RadioButtonALL.CheckedChanged += new System.EventHandler( this.RadioButtonALL_CheckedChanged );
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 330, 29 );
            this.axShortcutCaption.TabIndex = 3;
            // 
            // ButtonGetStock
            // 
            this.ButtonGetStock.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonGetStock.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonGetStock.Location = new System.Drawing.Point( 233, 35 );
            this.ButtonGetStock.Name = "ButtonGetStock";
            this.ButtonGetStock.Size = new System.Drawing.Size( 94, 23 );
            this.ButtonGetStock.TabIndex = 9;
            this.ButtonGetStock.Text = "获取所需股票";
            this.ButtonGetStock.UseVisualStyleBackColor = true;
            this.ButtonGetStock.Click += new System.EventHandler( this.ButtonGetStock_Click );
            // 
            // LabelInfo
            // 
            this.LabelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.LabelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelInfo.Location = new System.Drawing.Point( 0, 362 );
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size( 330, 50 );
            this.LabelInfo.TabIndex = 11;
            this.LabelInfo.Text = "选择股票的详细信息";
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 338 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 89, 12 );
            this.label1.TabIndex = 12;
            this.label1.Text = "(共有几只股票)";
            // 
            // TaskCControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.LabelInfo );
            this.Controls.Add( this.ButtonReverseSelect );
            this.Controls.Add( this.ButtonGetStock );
            this.Controls.Add( this.ButtonAllSelect );
            this.Controls.Add( this.axShortcutCaption );
            this.Controls.Add( this.CheckedListBox );
            this.Controls.Add( this.ComboBoxVariety );
            this.Controls.Add( this.RadioButtonALL );
            this.Controls.Add( this.ComboBoxPlate );
            this.Controls.Add( this.RadioButtonSelect );
            this.Name = "TaskCControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            this.Load += new System.EventHandler( this.TaskCControl_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonReverseSelect;
        private System.Windows.Forms.Button ButtonAllSelect;
        private System.Windows.Forms.CheckedListBox CheckedListBox;
        private System.Windows.Forms.ComboBox ComboBoxVariety;
        private System.Windows.Forms.ComboBox ComboBoxPlate;
        private System.Windows.Forms.RadioButton RadioButtonSelect;
        private System.Windows.Forms.RadioButton RadioButtonALL;
        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.Button ButtonGetStock;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.Label label1;
    }
}
