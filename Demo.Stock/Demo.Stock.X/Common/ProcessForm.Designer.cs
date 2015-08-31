namespace Demo.Stock.X.Common
{
    partial class ProcessForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ProcessForm ) );
            this.m_Timer = new System.Windows.Forms.Timer( this.components );
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_Timer
            // 
            this.m_Timer.Interval = 1000;
            this.m_Timer.Tick += new System.EventHandler( this.Timer_Tick );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point( 64, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 173, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "正在处理数据中，请等待。。。";
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 300, 30 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessForm";
            this.Opacity = 0.75;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProcessForm";
            this.TopMost = true;
            this.Shown += new System.EventHandler( this.ProcessForm_Shown );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer m_Timer;
        private System.Windows.Forms.Label label1;

    }
}