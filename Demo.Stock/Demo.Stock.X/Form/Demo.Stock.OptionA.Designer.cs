namespace Demo.Stock.X
{
    partial class OptionAControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OptionAControl ) );
            this.LabelKLine = new System.Windows.Forms.Label();
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.CheckBoxPopupInfo = new System.Windows.Forms.CheckBox();
            this.ButtonSetConfigFile = new System.Windows.Forms.Button();
            this.NumericUpDownKLine = new System.Windows.Forms.NumericUpDown();
            this.TrackBarKLine = new System.Windows.Forms.TrackBar();
            this.m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLine ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarKLine ) ).BeginInit();
            this.SuspendLayout();
            // 
            // LabelKLine
            // 
            this.LabelKLine.AutoSize = true;
            this.LabelKLine.Location = new System.Drawing.Point( -2, 78 );
            this.LabelKLine.Name = "LabelKLine";
            this.LabelKLine.Size = new System.Drawing.Size( 107, 12 );
            this.LabelKLine.TabIndex = 9;
            this.LabelKLine.Text = "显示K线图时的长度";
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 330, 29 );
            this.axShortcutCaption.TabIndex = 8;
            // 
            // CheckBoxPopupInfo
            // 
            this.CheckBoxPopupInfo.AutoSize = true;
            this.CheckBoxPopupInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxPopupInfo.Location = new System.Drawing.Point( 0, 35 );
            this.CheckBoxPopupInfo.Name = "CheckBoxPopupInfo";
            this.CheckBoxPopupInfo.Size = new System.Drawing.Size( 210, 17 );
            this.CheckBoxPopupInfo.TabIndex = 5;
            this.CheckBoxPopupInfo.Text = "程序启动时是否显示气泡提示信息";
            this.CheckBoxPopupInfo.UseVisualStyleBackColor = true;
            // 
            // ButtonSetConfigFile
            // 
            this.ButtonSetConfigFile.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonSetConfigFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonSetConfigFile.Location = new System.Drawing.Point( 227, 131 );
            this.ButtonSetConfigFile.Name = "ButtonSetConfigFile";
            this.ButtonSetConfigFile.Size = new System.Drawing.Size( 97, 27 );
            this.ButtonSetConfigFile.TabIndex = 2;
            this.ButtonSetConfigFile.Text = "设置配置文件";
            this.ButtonSetConfigFile.UseVisualStyleBackColor = true;
            this.ButtonSetConfigFile.Click += new System.EventHandler( this.ButtonSetConfigFile_Click );
            // 
            // NumericUpDownKLine
            // 
            this.NumericUpDownKLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUpDownKLine.Location = new System.Drawing.Point( 111, 76 );
            this.NumericUpDownKLine.Name = "NumericUpDownKLine";
            this.NumericUpDownKLine.Size = new System.Drawing.Size( 53, 21 );
            this.NumericUpDownKLine.TabIndex = 6;
            // 
            // TrackBarKLine
            // 
            this.TrackBarKLine.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.TrackBarKLine.Location = new System.Drawing.Point( 170, 76 );
            this.TrackBarKLine.Maximum = 100;
            this.TrackBarKLine.Name = "TrackBarKLine";
            this.TrackBarKLine.Size = new System.Drawing.Size( 152, 45 );
            this.TrackBarKLine.TabIndex = 7;
            this.TrackBarKLine.TickFrequency = 5;
            this.TrackBarKLine.Scroll += new System.EventHandler( this.TrackBarKLine_Scroll );
            // 
            // m_OpenFileDialog
            // 
            this.m_OpenFileDialog.DefaultExt = "xml";
            this.m_OpenFileDialog.FileName = "X.Config.xml";
            this.m_OpenFileDialog.Filter = "配置文件(*.xml)|*.xml|所有文件(*.*)|*.*";
            this.m_OpenFileDialog.RestoreDirectory = true;
            // 
            // OptionAControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.TrackBarKLine );
            this.Controls.Add( this.NumericUpDownKLine );
            this.Controls.Add( this.LabelKLine );
            this.Controls.Add( this.axShortcutCaption );
            this.Controls.Add( this.CheckBoxPopupInfo );
            this.Controls.Add( this.ButtonSetConfigFile );
            this.Name = "OptionAControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.NumericUpDownKLine ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TrackBarKLine ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelKLine;
        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.Button ButtonSetConfigFile;
        public System.Windows.Forms.CheckBox CheckBoxPopupInfo;
        public System.Windows.Forms.NumericUpDown NumericUpDownKLine;
        private System.Windows.Forms.OpenFileDialog m_OpenFileDialog;
        public System.Windows.Forms.TrackBar TrackBarKLine;
    }
}
