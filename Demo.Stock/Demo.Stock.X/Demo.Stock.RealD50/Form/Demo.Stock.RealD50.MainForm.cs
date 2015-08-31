using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.X.RealD50
{
    public partial class RealD50Form : Form
    {
        public RealD50Form()
        {
            InitializeComponent();
        }

        private void RealD50Form_Load( object sender, EventArgs eventArgs )
        {

        }

        public void EndRealD50Form()
        {
            this.Hide();
            this.m_RealD50FormTrueClose = true;
            this.Close();
            this.Dispose();
        }

        private bool m_RealD50FormTrueClose = false;
        private void RealD50Form_FormClosing( object sender, FormClosingEventArgs eventArgs )
        {
            if ( m_RealD50FormTrueClose == true )
                return;

            eventArgs.Cancel = true;

            this.Hide();
        }
    }
}
