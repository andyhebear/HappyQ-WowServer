using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.LHP.Main
{
    public partial class OptionControlSub3FromA : UserControl
    {
        public OptionControlSub3FromA()
        {
            InitializeComponent();
        }

        private void OptionControlSub3FromA_Load( object sender, EventArgs e )
        {
            CheckBoxUTMR_DTMS_CheckedChanged( this, EventArgs.Empty );
        }

        private void ButtonStockList_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialogStockList.ShowDialog() == DialogResult.OK )
            {
            }
        }

        private void ButtonOpenSRFile_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialogSR.ShowDialog() == DialogResult.OK )
            {
            }
        }

        private void ButtonSaveSRFile_Click( object sender, EventArgs e )
        {
            if ( this.saveFileDialogSR.ShowDialog() == DialogResult.OK )
            {
            }
        }

        private void ButtonOpen_UTMR_DTMS_File_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialog_UTMR_DTMS.ShowDialog() == DialogResult.OK )
            {
            }
        }

        private void ButtonSave_UTMR_DTMS_File_Click( object sender, EventArgs e )
        {
            if ( this.saveFileDialog_UTMR_DTMS.ShowDialog() == DialogResult.OK )
            {
            }
        }

        private void CheckBoxUTMR_DTMS_CheckedChanged( object sender, EventArgs e )
        {
            groupBox.Enabled = this.CheckBoxUTMR_DTMS.Checked;
        }

    }
}
