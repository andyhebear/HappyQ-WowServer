using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;
using Demo.Stock.LHP.BaseSR.Common;

namespace Demo.Stock.LHP.BaseSR
{
    public partial class SRControlSub1 : UserControl
    {
        public SRControlSub1()
        {
            InitializeComponent();
        }

        private void ScanControlSub1_Load( object sender, EventArgs e )
        {
            this.radioButtonCKPAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonCKPBig_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonCKPSmall_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonCKPBigAndSmall_CheckedChanged( this, EventArgs.Empty );

            this.radioButtonVaAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonVaBig_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonVaSmall_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonVaBigAndSmall_CheckedChanged( this, EventArgs.Empty );

            this.radioButtonCPFAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonCPFBig_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonCPFSmall_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonCPFBigAndSmall_CheckedChanged( this, EventArgs.Empty );

            this.radioButtonAPFAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonAPFBig_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonAPFSmall_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonAPFBigAndSmall_CheckedChanged( this, EventArgs.Empty );

            this.radioButtonRAPFAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.radioButton1RAPFBig_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonRAPFSmall_CheckedChanged( this, EventArgs.Empty );
            this.radioButtonRAPFBigAndSmall_CheckedChanged( this, EventArgs.Empty );
        }

        public LHPPrimaryScanInfo.ScanBaseInfo GetLHPScanBaseInfo()
        {
            LHPPrimaryScanInfo.ScanBaseInfo lhpScanBaseInfo = new LHPPrimaryScanInfo.ScanBaseInfo();

            //lhpScanBaseInfo.AllowPSR = this.CheckBoxAllowPSR.Checked;

            //if ( this.RadioButtonScanNew.Checked == true )
            //{
            //    lhpScanBaseInfo.ScanType = LHPPrimaryScanInfo.BaseScanType.ScanNew;
            //}
            //else if ( this.RadioButtonScanAll.Checked == true )
            //{
            //    lhpScanBaseInfo.ScanType = LHPPrimaryScanInfo.BaseScanType.ScanAll;
            //}

            //lhpScanBaseInfo.ScanSpace = (int)this.NumericUpDownScanSpace.Value;

            //lhpScanBaseInfo.AllowScanDCHP = this.CheckBoxDCHP.Checked;
            //lhpScanBaseInfo.AllowDCHP313 = this.CheckBoxDCHP313.Checked;
            //lhpScanBaseInfo.AllowDCHP214 = this.CheckBoxDCHP214.Checked;
            //lhpScanBaseInfo.AllowDCHP115 = this.CheckBoxDCHP115.Checked;
            //lhpScanBaseInfo.AllowDCHP412 = this.CheckBoxDCHP412.Checked;
            //lhpScanBaseInfo.AllowDCHP511 = this.CheckBoxDCHP511.Checked;

            //lhpScanBaseInfo.AllowScanDCLP = this.CheckBoxDCLP.Checked;
            //lhpScanBaseInfo.AllowDCLP313 = this.CheckBoxDCLP313.Checked;
            //lhpScanBaseInfo.AllowDCLP214 = this.CheckBoxDCLP214.Checked;
            //lhpScanBaseInfo.AllowDCLP115 = this.CheckBoxDCLP115.Checked;
            //lhpScanBaseInfo.AllowDCLP412 = this.CheckBoxDCLP412.Checked;
            //lhpScanBaseInfo.AllowDCLP511 = this.CheckBoxDCLP511.Checked;

            //lhpScanBaseInfo.AllowScanGapUp = this.CheckBoxGapUp.Checked;
            //lhpScanBaseInfo.AllowGULK = this.CheckBoxGULK.Checked;
            //lhpScanBaseInfo.AllowGUHK = this.CheckBoxGUHK.Checked;
            //lhpScanBaseInfo.GapUpPercentum = float.Parse(this.MaskedTextBoxGapUp.Text);

            //lhpScanBaseInfo.AllowScanGapDown = this.CheckBoxGapDown.Checked;
            //lhpScanBaseInfo.AllowGDLK = this.CheckBoxGDLK.Checked;
            //lhpScanBaseInfo.AllowGDHK = this.CheckBoxGDHK.Checked;
            //lhpScanBaseInfo.GapDownPercentum = float.Parse( this.MaskedTextBoxGapDown.Text );

            return lhpScanBaseInfo;
        }

        public void SetLHPScanBaseInfo( LHPPrimaryScanInfo.ScanBaseInfo lhpScanBaseInfo )
        {
            //this.CheckBoxAllowPSR.Checked = lhpScanBaseInfo.AllowPSR;

            //if ( lhpScanBaseInfo.ScanType == LHPPrimaryScanInfo.BaseScanType.ScanNew )
            //{
            //    this.RadioButtonScanNew.Checked = true;
            //}
            //else if ( lhpScanBaseInfo.ScanType == LHPPrimaryScanInfo.BaseScanType.ScanAll )
            //{
            //    this.RadioButtonScanAll.Checked = true;
            //}

            //this.NumericUpDownScanSpace.Value = lhpScanBaseInfo.ScanSpace;

            //this.CheckBoxDCHP.Checked = lhpScanBaseInfo.AllowScanDCHP;
            //this.CheckBoxDCHP313.Checked = lhpScanBaseInfo.AllowDCHP313;
            //this.CheckBoxDCHP214.Checked = lhpScanBaseInfo.AllowDCHP214;
            //this.CheckBoxDCHP115.Checked = lhpScanBaseInfo.AllowDCHP115;
            //this.CheckBoxDCHP412.Checked = lhpScanBaseInfo.AllowDCHP412;
            //this.CheckBoxDCHP511.Checked = lhpScanBaseInfo.AllowDCHP511;

            //this.CheckBoxDCLP.Checked = lhpScanBaseInfo.AllowScanDCLP;
            //this.CheckBoxDCLP313.Checked = lhpScanBaseInfo.AllowDCLP313;
            //this.CheckBoxDCLP214.Checked = lhpScanBaseInfo.AllowDCLP214;
            //this.CheckBoxDCLP115.Checked = lhpScanBaseInfo.AllowDCLP115;
            //this.CheckBoxDCLP412.Checked = lhpScanBaseInfo.AllowDCLP412;
            //this.CheckBoxDCLP511.Checked = lhpScanBaseInfo.AllowDCLP511;

            //this.CheckBoxGapUp.Checked = lhpScanBaseInfo.AllowScanGapUp;
            //this.CheckBoxGULK.Checked = lhpScanBaseInfo.AllowGULK;
            //this.CheckBoxGUHK.Checked = lhpScanBaseInfo.AllowGUHK;
            //this.MaskedTextBoxGapUp.Text = lhpScanBaseInfo.GapUpPercentum.ToString( "000.0" );

            //this.CheckBoxGapDown.Checked = lhpScanBaseInfo.AllowScanGapDown;
            //this.CheckBoxGDLK.Checked = lhpScanBaseInfo.AllowGDLK;
            //this.CheckBoxGDHK.Checked = lhpScanBaseInfo.AllowGDHK;
            //this.MaskedTextBoxGapDown.Text = lhpScanBaseInfo.GapDownPercentum.ToString( "000.0" );

            this.ScanControlSub1_Load( this, EventArgs.Empty );
        }


        public SROptionFormInfo.GeneralInfo GetSRGeneralInfo()
        {
            return null;
        }


        public void SetSRGeneralInfo( SROptionFormInfo.GeneralInfo generalInfo )
        {

        }

        internal void ButtonOK()
        {
        }

        internal void ButtonCancel()
        {
        }

        private void radioButtonCKPAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonCKPAnyOne.Checked == true )
            {
                this.maskedTextBoxCKPBig.Enabled = false;
                this.maskedTextBoxCKPSmall.Enabled = false;

                this.maskedTextBoxCKPBig2.Enabled = false;
                this.maskedTextBoxCKPSmall2.Enabled = false;
            }
        }

        private void radioButtonCKPBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonCKPBig.Checked == true )
            {
                this.maskedTextBoxCKPBig.Enabled = true;
                this.maskedTextBoxCKPSmall.Enabled = false;

                this.maskedTextBoxCKPBig2.Enabled = false;
                this.maskedTextBoxCKPSmall2.Enabled = false;
            }
        }

        private void radioButtonCKPSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonCKPSmall.Checked == true )
            {
                this.maskedTextBoxCKPBig.Enabled = false;
                this.maskedTextBoxCKPSmall.Enabled = true;

                this.maskedTextBoxCKPBig2.Enabled = false;
                this.maskedTextBoxCKPSmall2.Enabled = false;
            }
        }

        private void radioButtonCKPBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonCKPBigAndSmall.Checked == true )
            {
                this.maskedTextBoxCKPBig.Enabled = false;
                this.maskedTextBoxCKPSmall.Enabled = false;

                this.maskedTextBoxCKPBig2.Enabled = true;
                this.maskedTextBoxCKPSmall2.Enabled = true;
            }
        }

        private void radioButtonVaAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonVaAnyOne.Checked == true )
            {
                this.maskedTextBoxVaBig.Enabled = false;
                this.maskedTextBoxVaSmall.Enabled = false;

                this.maskedTextBoxVaBig2.Enabled = false;
                this.maskedTextBoxVaSmall2.Enabled = false;
            }
        }

        private void radioButtonVaBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonVaBig.Checked == true )
            {
                this.maskedTextBoxVaBig.Enabled = true;
                this.maskedTextBoxVaSmall.Enabled = false;

                this.maskedTextBoxVaBig2.Enabled = false;
                this.maskedTextBoxVaSmall2.Enabled = false;
            }
        }

        private void radioButtonVaSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonVaSmall.Checked == true )
            {
                this.maskedTextBoxVaBig.Enabled = false;
                this.maskedTextBoxVaSmall.Enabled = true;

                this.maskedTextBoxVaBig2.Enabled = false;
                this.maskedTextBoxVaSmall2.Enabled = false;
            }
        }

        private void radioButtonVaBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonVaBigAndSmall.Checked == true )
            {
                this.maskedTextBoxVaBig.Enabled = false;
                this.maskedTextBoxVaSmall.Enabled = false;

                this.maskedTextBoxVaBig2.Enabled = true;
                this.maskedTextBoxVaSmall2.Enabled = true;
            }
        }

        private void radioButtonCPFAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonCPFAnyOne.Checked == true )
            {
                this.maskedTextBoxCPFBig.Enabled = false;
                this.maskedTextBoxCPFSmall.Enabled = false;

                this.maskedTextBoxCPFBig2.Enabled = false;
                this.maskedTextBoxCPFSmall2.Enabled = false;
            }
        }

        private void radioButtonCPFBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonCPFBig.Checked == true )
            {
                this.maskedTextBoxCPFBig.Enabled = true;
                this.maskedTextBoxCPFSmall.Enabled = false;

                this.maskedTextBoxCPFBig2.Enabled = false;
                this.maskedTextBoxCPFSmall2.Enabled = false;
            }
        }

        private void radioButtonCPFSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonCPFSmall.Checked == true )
            {
                this.maskedTextBoxCPFBig.Enabled = false;
                this.maskedTextBoxCPFSmall.Enabled = true;

                this.maskedTextBoxCPFBig2.Enabled = false;
                this.maskedTextBoxCPFSmall2.Enabled = false;
            }
        }

        private void radioButtonCPFBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonCPFBigAndSmall.Checked == true )
            {
                this.maskedTextBoxCPFBig.Enabled = false;
                this.maskedTextBoxCPFSmall.Enabled = false;

                this.maskedTextBoxCPFBig2.Enabled = true;
                this.maskedTextBoxCPFSmall2.Enabled = true;
            }
        }

        private void radioButtonAPFAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonAPFAnyOne.Checked == true )
            {
                this.maskedTextBoxAPFBig.Enabled = false;
                this.maskedTextBoxAPFSmall.Enabled = false;

                this.maskedTextBoxAPFBig2.Enabled = false;
                this.maskedTextBoxAPFSmall2.Enabled = false;
            }
        }

        private void radioButtonAPFBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonAPFBig.Checked == true )
            {
                this.maskedTextBoxAPFBig.Enabled = true;
                this.maskedTextBoxAPFSmall.Enabled = false;

                this.maskedTextBoxAPFBig2.Enabled = false;
                this.maskedTextBoxAPFSmall2.Enabled = false;
            }
        }

        private void radioButtonAPFSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonAPFSmall.Checked == true )
            {
                this.maskedTextBoxAPFBig.Enabled = false;
                this.maskedTextBoxAPFSmall.Enabled = true;

                this.maskedTextBoxAPFBig2.Enabled = false;
                this.maskedTextBoxAPFSmall2.Enabled = false;
            }
        }

        private void radioButtonAPFBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonAPFBigAndSmall.Checked == true )
            {
                this.maskedTextBoxAPFBig.Enabled = false;
                this.maskedTextBoxAPFSmall.Enabled = false;

                this.maskedTextBoxAPFBig2.Enabled = true;
                this.maskedTextBoxAPFSmall2.Enabled = true;
            }
        }

        private void radioButtonRAPFAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonRAPFAnyOne.Checked == true )
            {
                this.maskedTextBoxRAPFBig.Enabled = false;
                this.maskedTextBoxRAPFSmall.Enabled = false;

                this.maskedTextBoxRAPFBig2.Enabled = false;
                this.maskedTextBoxRAPFSmall2.Enabled = false;
            }
        }

        private void radioButton1RAPFBig_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButton1RAPFBig.Checked == true )
            {
                this.maskedTextBoxRAPFBig.Enabled = true;
                this.maskedTextBoxRAPFSmall.Enabled = false;

                this.maskedTextBoxRAPFBig2.Enabled = false;
                this.maskedTextBoxRAPFSmall2.Enabled = false;
            }
        }

        private void radioButtonRAPFSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonRAPFSmall.Checked == true )
            {
                this.maskedTextBoxRAPFBig.Enabled = false;
                this.maskedTextBoxRAPFSmall.Enabled = true;

                this.maskedTextBoxRAPFBig2.Enabled = false;
                this.maskedTextBoxRAPFSmall2.Enabled = false;
            }
        }

        private void radioButtonRAPFBigAndSmall_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.radioButtonRAPFBigAndSmall.Checked == true )
            {
                this.maskedTextBoxRAPFBig.Enabled = false;
                this.maskedTextBoxRAPFSmall.Enabled = false;

                this.maskedTextBoxRAPFBig2.Enabled = true;
                this.maskedTextBoxRAPFSmall2.Enabled = true;
            }
        }

    }
}
