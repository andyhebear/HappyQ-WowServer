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
    public partial class PolicyEControlSub6 : UserControl
    {
        public PolicyEControlSub6()
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

        private void ConfigEControlSub6_Load( object sender, EventArgs e )
        {
            CheckBoxAllow_CheckedChanged( this, EventArgs.Empty );
        }

        private void CheckBoxAllow_CheckedChanged( object sender, EventArgs e )
        {
            if ( CheckBoxAllow.Checked == false )
            {
                this.RadioButtonYes.Enabled = false;
                this.RadioButtonNo.Enabled = false;
                this.ButtonSetting.Enabled = false;
            }
            else
            {
                this.RadioButtonYes.Enabled = true;
                this.RadioButtonNo.Enabled = true;

                if ( this.RadioButtonYes.Checked == true )
                    RadioButtonYes_CheckedChanged( this, EventArgs.Empty );
                if ( this.RadioButtonNo.Checked == true )
                    RadioButtonNo_CheckedChanged( this, EventArgs.Empty );
            }
        }

        private void RadioButtonYes_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonYes.Checked == true )
            {
                this.ButtonSetting.Enabled = true;
            }
            else
            {
                this.ButtonSetting.Enabled = false;
            }
        }

        private void RadioButtonNo_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.RadioButtonNo.Checked == true )
            {
                this.ButtonSetting.Enabled = false;
            }
            else
            {
                this.ButtonSetting.Enabled = true;
            }
        }

        private void ButtonSetting_Click( object sender, EventArgs e )
        {
            if ( EventButtonSetting != null )
                EventButtonSetting( this, EventArgs.Empty );
        }

        public event EventHandler EventButtonSetting;
    }
}
