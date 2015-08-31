using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.X.U50
{
    public partial class PolicyEControlSub4 : UserControl
    {
        public PolicyEControlSub4()
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

        private void ConfigEControlSub4_Load( object sender, EventArgs e )
        {
            CheckBoxAllow_CheckedChanged( this, EventArgs.Empty );
        }

        private void CheckBoxAllow_CheckedChanged( object sender, EventArgs e )
        {
            if ( CheckBoxAllow.Checked == false )
            {
                this.RadioButtonAny.Enabled = false;
                this.RadioButtonYes.Enabled = false;
                this.RadioButtonNo.Enabled = false;
            }
            else
            {
                this.RadioButtonAny.Enabled = true;
                this.RadioButtonYes.Enabled = true;
                this.RadioButtonNo.Enabled = true;

                if ( this.RadioButtonAny.Checked == true )
                    RadioButtonAny_CheckedChanged( this, EventArgs.Empty );
                if ( this.RadioButtonYes.Checked == true )
                    RadioButtonYes_CheckedChanged( this, EventArgs.Empty );
                else if ( this.RadioButtonNo.Checked == true )
                    RadioButtonNo_CheckedChanged( this, EventArgs.Empty );
            }
        }

        private void RadioButtonAny_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void RadioButtonYes_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void RadioButtonNo_CheckedChanged( object sender, EventArgs e )
        {

        }
    }
}
