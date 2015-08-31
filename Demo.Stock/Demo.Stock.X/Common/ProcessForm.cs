using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Demo.Stock.X.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ProcessForm : Form
    {
        private ProcessForm()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged( EventArgs eventArgs )
        {
            base.OnVisibleChanged( eventArgs );

            if ( this.Visible == true )
            {
                MainForm.Instance.AxSkinFramework.ApplyWindow( this.Handle.ToInt32() );
                this.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            }
        }

        private void ProcessForm_Shown( object sender, EventArgs e )
        {
            this.m_Timer.Enabled = true;
        }

        private void Timer_Tick( object sender, EventArgs e )
        {
            this.m_Timer.Enabled = false;
            if ( Process != null )
                Process( this );
        }
        
        public void EndProcessForm()
        {
            base.Close();
        }

        public static void StartProcessForm( EventHandlerProcess eventHandler )
        {
            ProcessForm processForm = new ProcessForm();
            processForm.Process += eventHandler;
            processForm.ShowDialog();
        }

        public event EventHandlerProcess Process;
    }

    public delegate void EventHandlerProcess( ProcessForm processForm );
}
