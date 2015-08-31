namespace Demo.Stock.X.U50
{
    partial class TaskDControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TaskDControlForm ) );
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonKLine = new System.Windows.Forms.Button();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.button1 = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "收盘价";
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( -2, 284 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 89, 12 );
            this.label1.TabIndex = 16;
            this.label1.Text = "(共有几只股票)";
            // 
            // ButtonKLine
            // 
            this.ButtonKLine.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonKLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonKLine.Location = new System.Drawing.Point( 271, 284 );
            this.ButtonKLine.Name = "ButtonKLine";
            this.ButtonKLine.Size = new System.Drawing.Size( 91, 23 );
            this.ButtonKLine.TabIndex = 14;
            this.ButtonKLine.Text = "显示K线图";
            this.ButtonKLine.UseVisualStyleBackColor = true;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "成交量";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "股票系数QA";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "股票代码";
            this.columnHeader1.Width = 100;
            // 
            // LabelInfo
            // 
            this.LabelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.LabelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelInfo.Location = new System.Drawing.Point( 0, 310 );
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size( 362, 50 );
            this.LabelInfo.TabIndex = 17;
            this.LabelInfo.Text = "选择股票的详细信息";
            // 
            // listView1
            // 
            this.listView1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.listView1.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4} );
            this.listView1.Location = new System.Drawing.Point( 0, 29 );
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size( 362, 249 );
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 362, 29 );
            this.axShortcutCaption.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point( 174, 284 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 91, 23 );
            this.button1.TabIndex = 14;
            this.button1.Text = "生成报表";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TaskDControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 362, 360 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.ButtonKLine );
            this.Controls.Add( this.LabelInfo );
            this.Controls.Add( this.listView1 );
            this.Controls.Add( this.axShortcutCaption );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskDControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.TaskDControlForm_FormClosing );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonKLine;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.ListView listView1;
        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.Button button1;
    }
}