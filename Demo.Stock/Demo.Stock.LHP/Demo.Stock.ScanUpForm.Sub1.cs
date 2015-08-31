using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.LHP
{
    public partial class ScanUpControlSub1 : UserControl
    {
        public ScanUpControlSub1()
        {
            InitializeComponent();
        }

        private void ScanUpControlSub1_Load( object sender, EventArgs e )
        {
            this.CheckBoxUpDay_CheckedChanged( this, EventArgs.Empty );

            this.RadioButtonDCHPAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonDCHPOr_CheckedChanged( this, EventArgs.Empty );

            this.RadioButtonDCLPAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonDCLPOr_CheckedChanged( this, EventArgs.Empty );

            this.CheckBoxAllowDCHP_CheckedChanged( this, EventArgs.Empty );
            this.CheckBoxAllowDCLP_CheckedChanged( this, EventArgs.Empty );

            this.LabelDateNow.Text = DateTime.Now.ToLongDateString();
        }

        private void ButtonDCLPUp_Click( object sender, EventArgs eventArgs )
        {
            List<object> itemList = new List<object>();

            foreach ( var item in this.ListBoxDCLP.SelectedItems )
            {
                this.ListBoxDCLPSelect.Items.Add( item );
                itemList.Add( item );
            }

            foreach ( var item in itemList )
                this.ListBoxDCLP.Items.Remove( item );
        }

        private void ButtonDCLPDown_Click( object sender, EventArgs eventArgs )
        {
            List<object> itemList = new List<object>();

            foreach ( var item in this.ListBoxDCLPSelect.SelectedItems )
            {
                this.ListBoxDCLP.Items.Add( item );
                itemList.Add( item );
            }

            foreach ( var item in itemList )
                this.ListBoxDCLPSelect.Items.Remove( item );
        }

        private void ButtonDCHPUp_Click( object sender, EventArgs eventArgs )
        {
            List<object> itemList = new List<object>();

            foreach ( var item in this.ListBoxDCHP.SelectedItems )
            {
                this.ListBoxDCHPSelect.Items.Add( item );
                itemList.Add( item );
            }

            foreach ( var item in itemList )
                this.ListBoxDCHP.Items.Remove( item );
        }

        private void ButtonDCHPDown_Click( object sender, EventArgs eventArgs )
        {
            List<object> itemList = new List<object>();

            foreach ( var item in this.ListBoxDCHPSelect.SelectedItems )
            {
                this.ListBoxDCHP.Items.Add( item );
                itemList.Add( item );
            }

            foreach ( var item in itemList )
                this.ListBoxDCHPSelect.Items.Remove( item );
        }

        private void RadioButtonDCLPAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonDCLPAnyOne.Checked == true )
            {
                this.ListBoxDCLPSelect.Enabled = false;
                this.ButtonDCLPUp.Enabled = false;
                this.ButtonDCLPDown.Enabled = false;
                this.ListBoxDCLP.Enabled = false;
            }
            else
            {
                this.ListBoxDCLPSelect.Enabled = true;
                this.ButtonDCLPUp.Enabled = true;
                this.ButtonDCLPDown.Enabled = true;
                this.ListBoxDCLP.Enabled = true;
            }
        }

        private void RadioButtonDCLPOr_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void RadioButtonDCHPAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonDCHPAnyOne.Checked == true )
            {
                this.ListBoxDCHPSelect.Enabled = false;
                this.ButtonDCHPUp.Enabled = false;
                this.ButtonDCHPDown.Enabled = false;
                this.ListBoxDCHP.Enabled = false;
            }
            else
            {
                this.ListBoxDCHPSelect.Enabled = true;
                this.ButtonDCHPUp.Enabled = true;
                this.ButtonDCHPDown.Enabled = true;
                this.ListBoxDCHP.Enabled = true;
            }
        }

        private void RadioButtonDCHPOr_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void CheckBoxAllowDCLP_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxAllowDCLP.Checked == true )
                this.GroupBoxDCLP.Enabled = true;
            else
                this.GroupBoxDCLP.Enabled = false;
        }

        private void CheckBoxAllowDCHP_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxAllowDCHP.Checked == true )
                this.GroupBoxDCHP.Enabled = true;
            else
                this.GroupBoxDCHP.Enabled = false;
        }

        private void CheckBoxUpDay_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxUpDay.Checked == true )
                this.NumericUpDownUpDay.Enabled = true;
            else
                this.NumericUpDownUpDay.Enabled = false;
        }
    }
}
