using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;

namespace Demo.Stock.LHP.BaseSR
{
    public partial class SRControlSub2A : UserControl
    {
        public SRControlSub2A()
        {
            InitializeComponent();
        }

        private void SRControlSub2A_Load( object sender, EventArgs e )
        {
            this.CheckBoxDCHP_CheckedChanged( this, EventArgs.Empty );
            this.CheckBoxDCLP_CheckedChanged( this, EventArgs.Empty );
            this.CheckBoxGapUp_CheckedChanged( this, EventArgs.Empty );
            this.CheckBoxGapDown_CheckedChanged( this, EventArgs.Empty );

            //this.RadioButtonDCHPAnyOne_CheckedChanged( this, EventArgs.Empty );
            //this.RadioButtonDCHPOr_CheckedChanged( this, EventArgs.Empty );

            //this.RadioButtonDCLPAnyOne_CheckedChanged( this, EventArgs.Empty );
            //this.RadioButtonDCLPOr_CheckedChanged( this, EventArgs.Empty );

            //this.CheckBoxAllowDCHP_CheckedChanged( this, EventArgs.Empty );
            //this.CheckBoxAllowDCLP_CheckedChanged( this, EventArgs.Empty );

            //this.CheckBoxAllowDCDS_CheckedChanged( this, EventArgs.Empty );
        }

        private void CheckBoxAllowDCDS_CheckedChanged( object sender, EventArgs e )
        {
            //if ( CheckBoxAllowDCDS.Checked == true )
            //{
            //    this.LabelDownDay.Enabled = true;
            //    this.NumericUpDownDownDay.Enabled = true;

            //    this.CheckBoxLowPirce.Enabled = true;

            //    this.CheckBoxAllowDCHP.Enabled = true;
            //    this.GroupBoxDCHP.Enabled = true;

            //    this.CheckBoxAllowDCLP.Enabled = true;
            //    this.GroupBoxDCLP.Enabled = true;
            //}
            //else
            //{
            //    this.LabelDownDay.Enabled = false;
            //    this.NumericUpDownDownDay.Enabled = false;

            //    this.CheckBoxLowPirce.Enabled = false;

            //    this.CheckBoxAllowDCHP.Enabled = false;
            //    this.GroupBoxDCHP.Enabled = false;

            //    this.CheckBoxAllowDCLP.Enabled = false;
            //    this.GroupBoxDCLP.Enabled = false;
            //}
        }

        private void CheckBoxAllowDCHP_CheckedChanged( object sender, EventArgs e )
        {
            //if ( this.CheckBoxAllowDCHP.Checked == true )
            //    this.GroupBoxDCHP.Enabled = true;
            //else
            //    this.GroupBoxDCHP.Enabled = false;
        }

        private void CheckBoxAllowDCLP_CheckedChanged( object sender, EventArgs e )
        {
            //if ( this.CheckBoxAllowDCLP.Checked == true )
            //    this.GroupBoxDCLP.Enabled = true;
            //else
            //    this.GroupBoxDCLP.Enabled = false;
        }


        private void RadioButtonDCHPAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            //if ( this.RadioButtonDCHPAnyOne.Checked == true )
            //{
            //    this.ListBoxDCHPSelect.Enabled = false;
            //    this.ButtonDCHPUp.Enabled = false;
            //    this.ButtonDCHPDown.Enabled = false;
            //    this.ListBoxDCHP.Enabled = false;
            //}
            //else
            //{
            //    this.ListBoxDCHPSelect.Enabled = true;
            //    this.ButtonDCHPUp.Enabled = true;
            //    this.ButtonDCHPDown.Enabled = true;
            //    this.ListBoxDCHP.Enabled = true;
            //}
        }

        private void RadioButtonDCHPOr_CheckedChanged( object sender, EventArgs e )
        {
        }

        private void RadioButtonDCLPAnyOne_CheckedChanged( object sender, EventArgs e )
        {
            //if ( this.RadioButtonDCLPAnyOne.Checked == true )
            //{
            //    this.ListBoxDCLPSelect.Enabled = false;
            //    this.ButtonDCLPUp.Enabled = false;
            //    this.ButtonDCLPDown.Enabled = false;
            //    this.ListBoxDCLP.Enabled = false;
            //}
            //else
            //{
            //    this.ListBoxDCLPSelect.Enabled = true;
            //    this.ButtonDCLPUp.Enabled = true;
            //    this.ButtonDCLPDown.Enabled = true;
            //    this.ListBoxDCLP.Enabled = true;
            //}
        }

        private void RadioButtonDCLPOr_CheckedChanged( object sender, EventArgs e )
        {
        }

        private void ButtonDCHPUp_Click( object sender, EventArgs e )
        {
            //List<object> itemList = new List<object>();

            //foreach ( var item in this.ListBoxDCHP.SelectedItems )
            //{
            //    this.ListBoxDCHPSelect.Items.Add( item );
            //    itemList.Add( item );
            //}

            //foreach ( var item in itemList )
            //    this.ListBoxDCHP.Items.Remove( item );
        }

        private void ButtonDCHPDown_Click( object sender, EventArgs e )
        {
            //List<object> itemList = new List<object>();
            
            //foreach ( var item in this.ListBoxDCHPSelect.SelectedItems )
            //{
            //    this.ListBoxDCHP.Items.Add( item );
            //    itemList.Add( item );
            //}

            //foreach ( var item in itemList )
            //    this.ListBoxDCHPSelect.Items.Remove( item );
        }

        private void ButtonDCLPUp_Click( object sender, EventArgs e )
        {
            //List<object> itemList = new List<object>();

            //foreach ( var item in this.ListBoxDCLP.SelectedItems )
            //{
            //    this.ListBoxDCLPSelect.Items.Add( item );
            //    itemList.Add( item );
            //}

            //foreach ( var item in itemList )
            //    this.ListBoxDCLP.Items.Remove( item );
        }

        private void ButtonDCLPDown_Click( object sender, EventArgs e )
        {
            //List<object> itemList = new List<object>();

            //foreach ( var item in this.ListBoxDCLPSelect.SelectedItems )
            //{
            //    this.ListBoxDCLP.Items.Add( item );
            //    itemList.Add( item );
            //}

            //foreach ( var item in itemList )
            //    this.ListBoxDCLPSelect.Items.Remove( item );
        }

        public LHPPrimaryScanInfo.ScanDownTrendInfo GetLHPScanDownTrendInfo()
        {
            LHPPrimaryScanInfo.ScanDownTrendInfo lhpScanDownTrendInfo = new LHPPrimaryScanInfo.ScanDownTrendInfo();

            //lhpScanDownTrendInfo.AllowScanDownTrend = this.CheckBoxAllowDCDS.Checked;
            //lhpScanDownTrendInfo.ScanContinueDownDate = (int)this.NumericUpDownDownDay.Value;
            //lhpScanDownTrendInfo.ScanDownTrendNeedLow = this.CheckBoxLowPirce.Checked;


            //lhpScanDownTrendInfo.AllowCheckDCHP = this.CheckBoxAllowDCHP.Checked;

            //if ( this.RadioButtonDCHPAnyOne.Checked == true )
            //{
            //    lhpScanDownTrendInfo.CheckDCHP = LHPPrimaryScanInfo.NormalTrendCheckDCHP.ScanAnyOne;
            //}
            //else if ( this.RadioButtonDCHPOr.Checked == true )
            //{
            //    lhpScanDownTrendInfo.CheckDCHP = LHPPrimaryScanInfo.NormalTrendCheckDCHP.ScanSelect;
            //}

            //foreach ( string item in ListBoxDCHP.Items )
            //{
            //    switch ( item )
            //    {
            //        case "DCHP-313":

            //            lhpScanDownTrendInfo.NeedDCHP313 = true;
            //            break;
            //        case "DCHP-214":

            //            lhpScanDownTrendInfo.NeedDCHP214 = true;
            //            break;
            //        case "DCHP-115":

            //            lhpScanDownTrendInfo.NeedDCHP115 = true;
            //            break;
            //        case "DCHP-412":

            //            lhpScanDownTrendInfo.NeedDCHP412 = true;
            //            break;
            //        case "DCHP-511":

            //            lhpScanDownTrendInfo.NeedDCHP511 = true;
            //            break;

            //    }
            //}

            //lhpScanDownTrendInfo.AllowCheckDCLP = this.CheckBoxAllowDCLP.Checked;

            //if ( this.RadioButtonDCLPAnyOne.Checked == true )
            //{
            //    lhpScanDownTrendInfo.CheckDCLP = LHPPrimaryScanInfo.NormalTrendCheckDCLP.ScanAnyOne;
            //}
            //else if ( this.RadioButtonDCLPOr.Checked == true )
            //{
            //    lhpScanDownTrendInfo.CheckDCLP = LHPPrimaryScanInfo.NormalTrendCheckDCLP.ScanSelect;
            //}

            //foreach ( string item in ListBoxDCLP.Items )
            //{
            //    switch ( item )
            //    {
            //        case "DCLP-313":

            //            lhpScanDownTrendInfo.ExcludeDCLP313 = true;
            //            break;
            //        case "DCLP-214":

            //            lhpScanDownTrendInfo.ExcludeDCLP214 = true;
            //            break;
            //        case "DCLP-115":

            //            lhpScanDownTrendInfo.ExcludeDCLP115 = true;
            //            break;
            //        case "DCLP-412":

            //            lhpScanDownTrendInfo.ExcludeDCLP412 = true;
            //            break;
            //        case "DCLP-511":

            //            lhpScanDownTrendInfo.ExcludeDCLP511 = true;
            //            break;

            //    }
            //}

            return lhpScanDownTrendInfo;
        }

        public void SetLHPScanDownTrendInfo( LHPPrimaryScanInfo.ScanDownTrendInfo lhpScanDownTrendInfo )
        {
            //this.CheckBoxAllowDCDS.Checked = lhpScanDownTrendInfo.AllowScanDownTrend;
            //this.NumericUpDownDownDay.Value = lhpScanDownTrendInfo.ScanContinueDownDate;
            //this.CheckBoxLowPirce.Checked = lhpScanDownTrendInfo.ScanDownTrendNeedLow;

            //this.CheckBoxAllowDCHP.Checked = lhpScanDownTrendInfo.AllowCheckDCHP;

            //if ( lhpScanDownTrendInfo.CheckDCHP == LHPPrimaryScanInfo.NormalTrendCheckDCHP.ScanAnyOne )
            //{
            //    this.RadioButtonDCHPAnyOne.Checked = true;
            //}
            //else if ( lhpScanDownTrendInfo.CheckDCHP == LHPPrimaryScanInfo.NormalTrendCheckDCHP.ScanSelect )
            //{
            //    this.RadioButtonDCHPOr.Checked = true;
            //}

            //if ( lhpScanDownTrendInfo.NeedDCHP313 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-313" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-313" );
            //}

            //if ( lhpScanDownTrendInfo.NeedDCHP214 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-214" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-214" );
            //}

            //if ( lhpScanDownTrendInfo.NeedDCHP115 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-115" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-115" );
            //}

            //if ( lhpScanDownTrendInfo.NeedDCHP412 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-412" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-412" );
            //}

            //if ( lhpScanDownTrendInfo.NeedDCHP511 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-511" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-511" );
            //}


            //this.CheckBoxAllowDCLP.Checked = lhpScanDownTrendInfo.AllowCheckDCLP;

            //if ( lhpScanDownTrendInfo.CheckDCLP == LHPPrimaryScanInfo.NormalTrendCheckDCLP.ScanAnyOne )
            //{
            //    this.RadioButtonDCLPAnyOne.Checked = true;
            //}
            //else if ( lhpScanDownTrendInfo.CheckDCLP == LHPPrimaryScanInfo.NormalTrendCheckDCLP.ScanSelect )
            //{
            //    this.RadioButtonDCLPOr.Checked = true;
            //}

            //if ( lhpScanDownTrendInfo.ExcludeDCLP313 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-313" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-313" );
            //}

            //if ( lhpScanDownTrendInfo.ExcludeDCLP214 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-214" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-214" );
            //}

            //if ( lhpScanDownTrendInfo.ExcludeDCLP115 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-115" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-115" );
            //}

            //if ( lhpScanDownTrendInfo.ExcludeDCLP412 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-412" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-412" );
            //}

            //if ( lhpScanDownTrendInfo.ExcludeDCLP511 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-511" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-511" );
            //}
        }

        private void CheckBoxDCHP_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxDCHP.Checked == true )
                this.GroupBoxDCHP.Enabled = true;
            else
                this.GroupBoxDCHP.Enabled = false;
        }

        private void CheckBoxDCLP_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxDCLP.Checked == true )
                this.GroupBoxDCLP.Enabled = true;
            else
                this.GroupBoxDCLP.Enabled = false;
        }

        private void CheckBoxGapUp_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxGapUp.Checked == true )
                this.GroupBoxGapUp.Enabled = true;
            else
                this.GroupBoxGapUp.Enabled = false;
        }

        private void CheckBoxGapDown_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.CheckBoxGapDown.Checked == true )
                this.GroupBoxGapDown.Enabled = true;
            else
                this.GroupBoxGapDown.Enabled = false;
        }
    }
}
