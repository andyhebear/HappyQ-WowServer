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
    public partial class SRControlSub2Up : UserControl
    {
        public SRControlSub2Up()
        {
            InitializeComponent();
        }

        private void ScanControlSub2BUp_Load( object sender, EventArgs e )
        {
            this.RadioButtonDCLPAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonDCLPOr_CheckedChanged( this, EventArgs.Empty );

            this.RadioButtonDCHPAnyOne_CheckedChanged( this, EventArgs.Empty );
            this.RadioButtonDCHPOr_CheckedChanged( this, EventArgs.Empty );

            this.CheckBoxAllowDCLP_CheckedChanged( this, EventArgs.Empty );
            this.CheckBoxAllowDCHP_CheckedChanged( this, EventArgs.Empty );

            this.CheckBoxAllowDCUR_CheckedChanged( this, EventArgs.Empty );
        }

        private void CheckBoxAllowDCUR_CheckedChanged( object sender, EventArgs e )
        {
            //if ( CheckBoxAllowDCUR.Checked == true )
            //{
            //    this.LabelUpDay.Enabled = true;
            //    this.NumericUpDownUpDay.Enabled = true;

            //    this.CheckBoxHighPirce.Enabled = true;

            //    this.CheckBoxAllowDCLP.Enabled = true;
            //    this.GroupBoxDCLP.Enabled = true;

            //    this.CheckBoxAllowDCHP.Enabled = true;
            //    this.GroupBoxDCHP.Enabled = true;
            //}
            //else
            //{
            //    this.LabelUpDay.Enabled = false;
            //    this.NumericUpDownUpDay.Enabled = false;

            //    this.CheckBoxHighPirce.Enabled = false;

            //    this.CheckBoxAllowDCLP.Enabled = false;
            //    this.GroupBoxDCLP.Enabled = false;

            //    this.CheckBoxAllowDCHP.Enabled = false;
            //    this.GroupBoxDCHP.Enabled = false;
            //}
        }

        private void CheckBoxAllowDCLP_CheckedChanged( object sender, EventArgs e )
        {
            //if ( this.CheckBoxAllowDCLP.Checked == true )
            //    this.GroupBoxDCLP.Enabled = true;
            //else
            //    this.GroupBoxDCLP.Enabled = false;
        }

        private void CheckBoxAllowDCHP_CheckedChanged( object sender, EventArgs e )
        {
            // if ( this.CheckBoxAllowDCHP.Checked == true )
            //    this.GroupBoxDCHP.Enabled = true;
            //else
            //    this.GroupBoxDCHP.Enabled = false;
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


        public LHPPrimaryScanInfo.ScanUpTrendInfo GetLHPScanUpTrendInfo()
        {
            LHPPrimaryScanInfo.ScanUpTrendInfo lhpScanUpTrendInfo = new LHPPrimaryScanInfo.ScanUpTrendInfo();

            //lhpScanUpTrendInfo.AllowScanUpTrend = this.CheckBoxAllowDCUR.Checked;
            //lhpScanUpTrendInfo.ScanContinueUpDate = (int)this.NumericUpDownUpDay.Value;
            //lhpScanUpTrendInfo.ScanUpTrendNeedHigh = this.CheckBoxHighPirce.Checked;



            //lhpScanUpTrendInfo.AllowCheckDCLP = this.CheckBoxAllowDCLP.Checked;

            //if ( this.RadioButtonDCLPAnyOne.Checked == true )
            //{
            //    lhpScanUpTrendInfo.CheckDCLP = LHPPrimaryScanInfo.NormalTrendCheckDCLP.ScanAnyOne;
            //}
            //else if ( this.RadioButtonDCLPOr.Checked == true )
            //{
            //    lhpScanUpTrendInfo.CheckDCLP = LHPPrimaryScanInfo.NormalTrendCheckDCLP.ScanSelect;
            //}

            //foreach ( string item in ListBoxDCLP.Items )
            //{
            //    switch ( item )
            //    {
            //        case "DCLP-313":

            //            lhpScanUpTrendInfo.NeedDCLP313 = true;
            //            break;
            //        case "DCLP-214":

            //            lhpScanUpTrendInfo.NeedDCLP214 = true;
            //            break;
            //        case "DCLP-115":

            //            lhpScanUpTrendInfo.NeedDCLP115 = true;
            //            break;
            //        case "DCLP-412":

            //            lhpScanUpTrendInfo.NeedDCLP412 = true;
            //            break;
            //        case "DCLP-511":

            //            lhpScanUpTrendInfo.NeedDCLP511 = true;
            //            break;

            //    }
            //}



            //lhpScanUpTrendInfo.AllowCheckDCHP = this.CheckBoxAllowDCHP.Checked;

            //if ( this.RadioButtonDCHPAnyOne.Checked == true )
            //{
            //    lhpScanUpTrendInfo.CheckDCHP = LHPPrimaryScanInfo.NormalTrendCheckDCHP.ScanAnyOne;
            //}
            //else if ( this.RadioButtonDCHPOr.Checked == true )
            //{
            //    lhpScanUpTrendInfo.CheckDCHP = LHPPrimaryScanInfo.NormalTrendCheckDCHP.ScanSelect;
            //}

            //foreach ( string item in ListBoxDCHP.Items )
            //{
            //    switch ( item )
            //    {
            //        case "DCHP-313":

            //            lhpScanUpTrendInfo.ExcludeDCHP313 = true;
            //            break;
            //        case "DCHP-214":

            //            lhpScanUpTrendInfo.ExcludeDCHP214 = true;
            //            break;
            //        case "DCHP-115":

            //            lhpScanUpTrendInfo.ExcludeDCHP115 = true;
            //            break;
            //        case "DCHP-412":

            //            lhpScanUpTrendInfo.ExcludeDCHP412 = true;
            //            break;
            //        case "DCHP-511":

            //            lhpScanUpTrendInfo.ExcludeDCHP511 = true;
            //            break;

            //    }
            //}

            return lhpScanUpTrendInfo;
        }

        public void SetLHPScanUpTrendInfo( LHPPrimaryScanInfo.ScanUpTrendInfo lhpScanUpTrendInfo )
        {
            //this.CheckBoxAllowDCUR.Checked = lhpScanUpTrendInfo.AllowScanUpTrend;
            //this.NumericUpDownUpDay.Value = lhpScanUpTrendInfo.ScanContinueUpDate;
            //this.CheckBoxHighPirce.Checked = lhpScanUpTrendInfo.ScanUpTrendNeedHigh;



            //this.CheckBoxAllowDCLP.Checked = lhpScanUpTrendInfo.AllowCheckDCLP;

            //if ( lhpScanUpTrendInfo.CheckDCLP == LHPPrimaryScanInfo.NormalTrendCheckDCLP.ScanAnyOne )
            //{
            //    this.RadioButtonDCLPAnyOne.Checked = true;
            //}
            //else if ( lhpScanUpTrendInfo.CheckDCLP == LHPPrimaryScanInfo.NormalTrendCheckDCLP.ScanSelect )
            //{
            //    this.RadioButtonDCLPOr.Checked = true;
            //}

            //if ( lhpScanUpTrendInfo.NeedDCLP313 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-313" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-313" );
            //}

            //if ( lhpScanUpTrendInfo.NeedDCLP214 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-214" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-214" );
            //}

            //if ( lhpScanUpTrendInfo.NeedDCLP115 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-115" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-115" );
            //}

            //if ( lhpScanUpTrendInfo.NeedDCLP412 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-412" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-412" );
            //}

            //if ( lhpScanUpTrendInfo.NeedDCLP511 == true )
            //{
            //    this.ListBoxDCLPSelect.Items.Remove( "DCLP-511" );
            //    this.ListBoxDCLP.Items.Add( "DCLP-511" );
            //}
            
            

            //this.CheckBoxAllowDCHP.Checked = lhpScanUpTrendInfo.AllowCheckDCHP;

            //if ( lhpScanUpTrendInfo.CheckDCHP == LHPPrimaryScanInfo.NormalTrendCheckDCHP.ScanAnyOne )
            //{
            //    this.RadioButtonDCHPAnyOne.Checked = true;
            //}
            //else if ( lhpScanUpTrendInfo.CheckDCHP == LHPPrimaryScanInfo.NormalTrendCheckDCHP.ScanSelect )
            //{
            //    this.RadioButtonDCHPOr.Checked = true;
            //}

            //if ( lhpScanUpTrendInfo.ExcludeDCHP313 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-313" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-313" );
            //}

            //if ( lhpScanUpTrendInfo.ExcludeDCHP214 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-214" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-214" );
            //}

            //if ( lhpScanUpTrendInfo.ExcludeDCHP115 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-115" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-115" );
            //}

            //if ( lhpScanUpTrendInfo.ExcludeDCHP412 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-412" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-412" );
            //}

            //if ( lhpScanUpTrendInfo.ExcludeDCHP511 == true )
            //{
            //    this.ListBoxDCHPSelect.Items.Remove( "DCHP-511" );
            //    this.ListBoxDCHP.Items.Add( "DCHP-511" );
            //}
        }
    }
}
