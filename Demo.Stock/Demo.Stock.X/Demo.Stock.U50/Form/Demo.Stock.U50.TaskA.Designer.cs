namespace Demo.Stock.X.U50
{
    partial class TaskAControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TaskAControl ) );
            this.axShortcutCaption = new AxXtremeShortcutBar.AxShortcutCaption();
            this.m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ButtonNewTask = new System.Windows.Forms.Button();
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
            this.axShortcutCaption.Size = new System.Drawing.Size( 330, 29 );
            this.axShortcutCaption.TabIndex = 4;
            // 
            // m_OpenFileDialog
            // 
            this.m_OpenFileDialog.FileName = "openFileDialog1";
            this.m_OpenFileDialog.RestoreDirectory = true;
            // 
            // ButtonNewTask
            // 
            this.ButtonNewTask.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonNewTask.Location = new System.Drawing.Point( 236, 35 );
            this.ButtonNewTask.Name = "ButtonNewTask";
            this.ButtonNewTask.Size = new System.Drawing.Size( 91, 27 );
            this.ButtonNewTask.TabIndex = 6;
            this.ButtonNewTask.Text = "新建任务";
            this.ButtonNewTask.UseVisualStyleBackColor = true;
            this.ButtonNewTask.Click += new System.EventHandler( this.ButtonNewTask_Click );
            // 
            // TaskAControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.ButtonNewTask );
            this.Controls.Add( this.axShortcutCaption );
            this.Name = "TaskAControl";
            this.Size = new System.Drawing.Size( 330, 412 );
            ( (System.ComponentModel.ISupportInitialize)( this.axShortcutCaption ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxXtremeShortcutBar.AxShortcutCaption axShortcutCaption;
        private System.Windows.Forms.OpenFileDialog m_OpenFileDialog;
        private System.Windows.Forms.Button ButtonNewTask;
    }
}
