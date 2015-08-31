using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Demo.Stock.X.U50
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PolicyDControlSub0 : UserControl
    {
        [DllImport( "user32", EntryPoint = "PostMessage", SetLastError = true )]
        private static extern int PostMessage( int hwnd, int wMsg, int wParam, int lParam );
        private const short CB_SHOWDROPDOWN = 0X14F;

        private DateTime m_DateBegin = DateTime.Now;

        private DateTime m_DateEnd = DateTime.Now;

        private DateTime m_DateSelection = DateTime.Now;

        private TimeSpan m_SpanBegin = TimeSpan.FromDays( 0.0 );

        private TimeSpan m_SpanEnd = TimeSpan.FromDays( 0.0 );

        private PolicyDControlSubForm m_ConfigBControlSubForm = new PolicyDControlSubForm();

        /// <summary>
        /// 
        /// </summary>
        public PolicyDControlSub0()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnVisibleChanged( EventArgs eventArgs )
        {
            base.OnVisibleChanged( eventArgs );

            if ( this.Visible == true )
            {
                MainForm.Instance.AxSkinFramework.ApplyWindow( this.Handle.ToInt32() );
                this.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigBControlSub0_Load( object sender, EventArgs eventArgs )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void ButtonCondition_Click( object sender, EventArgs eventArgs )
        {
            m_ConfigBControlSubForm.ShowDialog();
        }
    }
}
