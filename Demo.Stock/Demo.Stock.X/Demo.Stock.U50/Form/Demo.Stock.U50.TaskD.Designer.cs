namespace Demo.Stock.X.U50
{
    partial class TaskDControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TaskDControl ) );
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ButtonUP = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Timer1 = new System.Windows.Forms.Timer( this.components );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axShortcutCaption
            // 
            this.axShortcutCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.axShortcutCaption.Enabled = true;
            this.axShortcutCaption.Location = new System.Drawing.Point( 0, 0 );
            this.axShortcutCaption.Name = "axShortcutCaption";
            this.axShortcutCaption.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axShortcutCaption.OcxState" ) ) );
            this.axShortcutCaption.Size = new System.Drawing.Size( 330, 29 );
            this.axShortcutCaption.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point( 3, 47 );
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size( 324, 88 );
            this.listBox1.TabIndex = 5;
            // 
            // ButtonUP
            // 
            this.ButtonUP.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonUP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonUP.Location = new System.Drawing.Point( 271, 138 );
            this.ButtonUP.Name = "ButtonUP";
            this.ButtonUP.Size = new System.Drawing.Size( 25, 23 );
            this.ButtonUP.TabIndex = 6;
            this.ButtonUP.Text = "↑";
            this.ButtonUP.UseVisualStyleBackColor = true;
            this.ButtonUP.Click += new System.EventHandler( this.ButtonUP_Click );
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point( 3, 167 );
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size( 324, 88 );
            this.listBox2.TabIndex = 5;
            // 
            // ButtonDown
            // 
            this.ButtonDown.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ButtonDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonDown.Location = new System.Drawing.Point( 302, 138 );
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size( 25, 23 );
            this.ButtonDown.TabIndex = 6;
            this.ButtonDown.Text = "↓";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Click += new System.EventHandler( this.ButtonDown_Click );
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1.Location = new System.Drawing.Point( 16, 20 );
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size( 77, 17 );
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "顺序扫描";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton2.Location = new System.Drawing.Point( 16, 42 );
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size( 77, 17 );
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "同步扫描";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point( 252, 270 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 75, 23 );
            this.button3.TabIndex = 9;
            this.button3.Text = "开始扫描";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler( this.button3_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 3, 32 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 95, 12 );
            this.label2.TabIndex = 10;
            this.label2.Text = "可选择U50的策略";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 1, 149 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 95, 12 );
            this.label3.TabIndex = 10;
            this.label3.Text = "选择后的U50策略";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.radioButton1 );
            this.groupBox1.Controls.Add( this.radioButton2 );
            this.groupBox1.Location = new System.Drawing.Point( 3, 270 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 104, 69 );
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "扫描模式";
            // 
            // Timer1
            // 
            this.Timer1.Interval = 10000;
            this.Timer1.Tick += new System.EventHandler( this.Timer1_Tick );
            // 
            // TaskDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.button3 );
            this.Controls.Add( this.ButtonDown );
            this.Controls.Add( this.ButtonUP );
            this.Controls.Add( this.listBox2 );
            this.Controls.Add( this.listBox1 );
            this.Controls.Add( this.axShortcutCaption );
            this.Name = "TaskDControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            this.Load += new System.EventHandler( this.TaskDControl_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ButtonUP;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer Timer1;
    }
}
