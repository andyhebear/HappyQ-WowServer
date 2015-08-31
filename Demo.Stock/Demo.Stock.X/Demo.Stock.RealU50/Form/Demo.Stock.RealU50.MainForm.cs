using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.X.RealU50
{
    public partial class RealU50Form : Form
    {
        public RealU50Form()
        {
            InitializeComponent();
        }

        private void RealU50Form_Load( object sender, EventArgs eventArgs )
        {

        }

        public void EndRealU50Form()
        {
            this.Hide();
            this.m_RealU50FormTrueClose = true;
            this.Close();
            this.Dispose();
        }

        private bool m_RealU50FormTrueClose = false;
        private void RealU50Form_FormClosing( object sender, FormClosingEventArgs eventArgs )
        {
            if ( m_RealU50FormTrueClose == true )
                return;

            eventArgs.Cancel = true;

            this.Hide();
        }

    }
}
