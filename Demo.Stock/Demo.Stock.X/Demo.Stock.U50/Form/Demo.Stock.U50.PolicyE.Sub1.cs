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
    public partial class PolicyEControlSub1 : UserControl
    {
        public PolicyEControlSub1()
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

        private void ConfigEControlSub1_Load( object sender, EventArgs e )
        {
            CheckBoxAllow_CheckedChanged( this, EventArgs.Empty );
        }

        private void CheckBoxAllow_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxAllow.Checked == false )
            {
                this.RadioButtonAny.Enabled = false;
                this.RadioButtonHigh.Enabled = false;
                this.RadioButtonHighNow.Enabled = false;

                this.NumericUpDownKLine.Enabled = false;
                this.TrackBarKLine.Enabled = false;
            }
            else
            {
                this.RadioButtonAny.Enabled = true;
                this.RadioButtonHigh.Enabled = true;
                this.RadioButtonHighNow.Enabled = true;

                if ( this.RadioButtonAny.Checked == true )
                    RadioButtonAny_CheckedChanged( this, EventArgs.Empty );
                else if ( this.RadioButtonHigh.Checked == true )
                    RadioButtonHigh_CheckedChanged( this, EventArgs.Empty );
                else if ( this.RadioButtonHighNow.Checked == true )
                    RadioButtonHighNow_CheckedChanged( this, EventArgs.Empty );
            }
        }

        private void RadioButtonAny_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonAny.Checked == true )
            {
            }
            else
            {
                this.NumericUpDownKLine.Enabled = false;
                this.TrackBarKLine.Enabled = false;
            }
        }

        private void RadioButtonHigh_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonHigh.Checked == true )
            {
            }
            else
            {
                this.NumericUpDownKLine.Enabled = false;
                this.TrackBarKLine.Enabled = false;
            }

        }

        private void RadioButtonHighNow_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonHighNow.Checked == true )
            {
                this.NumericUpDownKLine.Enabled = true;
                this.TrackBarKLine.Enabled = true;
            }
            else
            {
                this.NumericUpDownKLine.Enabled = false;
                this.TrackBarKLine.Enabled = false;
            }
        }

        private void TrackBarDateTimeKLine_Scroll( object sender, EventArgs e )
        {
            this.NumericUpDownKLine.Value = this.TrackBarKLine.Value;
        }


    }
}
