using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;

namespace Demo.Stock.LHP
{
    public partial class ScanPrimary2ControlSub1 : UserControl
    {
        public ScanPrimary2ControlSub1()
        {
            InitializeComponent();
        }

        private void ScanControlSub1_Load( object sender, EventArgs e )
        {
            this.CheckBoxDCHP_CheckedChanged( this, EventArgs.Empty );
            this.CheckBoxDCLP_CheckedChanged( this, EventArgs.Empty );
            this.CheckBoxGapUp_CheckedChanged( this, EventArgs.Empty );
            this.CheckBoxGapDown_CheckedChanged( this, EventArgs.Empty );

            this.CheckBoxAllowPSR_CheckedChanged( this, EventArgs.Empty );
        }

        private void CheckBoxDCHP_CheckedChanged( object sender, EventArgs eventArgs )
        {
            //if ( this.CheckBoxDCHP.Checked == true )
            //    this.GroupBoxDCHP.Enabled = true;
            //else
            //    this.GroupBoxDCHP.Enabled = false;
        }

        private void CheckBoxDCLP_CheckedChanged( object sender, EventArgs eventArgs )
        {
            //if ( this.CheckBoxDCLP.Checked == true )
            //    this.GroupBoxDCLP.Enabled = true;
            //else
            //    this.GroupBoxDCLP.Enabled = false;
        }

        private void CheckBoxGapUp_CheckedChanged( object sender, EventArgs eventArgs )
        {
            //if ( this.CheckBoxGapUp.Checked == true )
            //    this.GroupBoxGapUp.Enabled = true;
            //else
            //    this.GroupBoxGapUp.Enabled = false;
        }

        private void CheckBoxGapDown_CheckedChanged( object sender, EventArgs eventArgs )
        {
            //if ( this.CheckBoxGapDown.Checked == true )
            //    this.GroupBoxGapDown.Enabled = true;
            //else
            //    this.GroupBoxGapDown.Enabled = false;
        }

        private void CheckBoxAllowPSR_CheckedChanged( object sender, EventArgs eventArgs )
        {
            //if ( this.CheckBoxAllowPSR.Checked == true )
            //{
            //    this.RadioButtonScanNew.Enabled = true;
            //    this.RadioButtonScanAll.Enabled = true;

            //    this.LabelScanSpace.Enabled = true;
            //    this.NumericUpDownScanSpace.Enabled = true;

            //    this.CheckBoxDCHP.Enabled = true;
            //    this.CheckBoxDCLP.Enabled = true;
            //    this.CheckBoxGapUp.Enabled = true;
            //    this.CheckBoxGapDown.Enabled = true;

            //    if ( this.CheckBoxDCHP.Checked == true )
            //        this.GroupBoxDCHP.Enabled = true;

            //    if ( this.CheckBoxDCLP.Checked == true )
            //        this.GroupBoxDCLP.Enabled = true;

            //    if ( this.CheckBoxGapUp.Checked == true )
            //        this.GroupBoxGapUp.Enabled = true;

            //    if ( this.CheckBoxGapDown.Checked == true )
            //        this.GroupBoxGapDown.Enabled = true;
            //}
            //else
            //{
            //    this.RadioButtonScanNew.Enabled = false;
            //    this.RadioButtonScanAll.Enabled = false;

            //    this.LabelScanSpace.Enabled = false;
            //    this.NumericUpDownScanSpace.Enabled = false;

            //    this.CheckBoxDCHP.Enabled = false;
            //    this.CheckBoxDCLP.Enabled = false;
            //    this.CheckBoxGapUp.Enabled = false;
            //    this.CheckBoxGapDown.Enabled = false;

            //    this.GroupBoxDCHP.Enabled = false;
            //    this.GroupBoxDCLP.Enabled = false;
            //    this.GroupBoxGapUp.Enabled = false;
            //    this.GroupBoxGapDown.Enabled = false;
            //}
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
    }
}
