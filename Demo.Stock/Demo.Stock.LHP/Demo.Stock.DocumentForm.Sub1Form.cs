using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.LHP
{
    public partial class DocumentFormSub1Form : Form
    {
        public DocumentFormSub1Form()
        {
            InitializeComponent();
        }

        private void numericUpDown5_ValueChanged( object sender, EventArgs e )
        {

        }

        private void label5_Click( object sender, EventArgs e )
        {

        }

        private void label21_Click( object sender, EventArgs e )
        {

        }

        private void DocumentFormSub1Form_FormClosing( object sender, FormClosingEventArgs e )
        {
            e.Cancel = true;

            this.Visible = false;
        }
    }
}
