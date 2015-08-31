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
    public partial class SRControlSub2B : UserControl
    {
        public SRControlSub2B()
        {
            InitializeComponent();
        }

        private void ScanPrimaryControlSub2General_Load( object sender, EventArgs e )
        {
            //this.LabelNow.Text = DateTime.Now.ToLongDateString();
        }

        private void CheckBoxAllowSR_CheckedChanged( object sender, EventArgs e )
        {
            //if ( CheckBoxAllowSR.Checked == true )
            //{
            //    this.RadioButtonNow.Enabled = true;
            //    this.LabelNow.Enabled = true;

            //    this.RadioButtonSelect.Enabled = true;
            //    this.DateTimePickerSelect.Enabled = true;

            //    this.LabelKLineNumber.Enabled = true;
            //    this.NumericUpDownKLineNumber.Enabled = true;
            //}
            //else
            //{
            //    this.RadioButtonNow.Enabled = false;
            //    this.LabelNow.Enabled = false;

            //    this.RadioButtonSelect.Enabled = false;
            //    this.DateTimePickerSelect.Enabled = false;

            //    this.LabelKLineNumber.Enabled = false;
            //    this.NumericUpDownKLineNumber.Enabled = false;
            //}
        }

        public LHPPrimaryScanInfo.ScanNormalInfo GetLHPScanNormalInfo()
        {
            LHPPrimaryScanInfo.ScanNormalInfo lhpScanNormalInfo = new LHPPrimaryScanInfo.ScanNormalInfo();

            //lhpScanNormalInfo.AllowScanSR = this.CheckBoxAllowSR.Checked;

            //if ( this.RadioButtonNow.Checked == true )
            //{
            //    lhpScanNormalInfo.ScanDateType = LHPPrimaryScanInfo.NormalScanDateType.ScanNow;
            //    lhpScanNormalInfo.ScanDate = DateTime.Now;
            //}
            //else if ( this.RadioButtonSelect.Checked == true )
            //{
            //    lhpScanNormalInfo.ScanDateType = LHPPrimaryScanInfo.NormalScanDateType.ScanSelect;
            //    lhpScanNormalInfo.ScanDate = this.DateTimePickerSelect.Value;
            //}

            return lhpScanNormalInfo;
        }

        public void SetLHPScanNormalInfo( LHPPrimaryScanInfo.ScanNormalInfo lhpScanNormalInfo )
        {
            //this.CheckBoxAllowSR.Checked = lhpScanNormalInfo.AllowScanSR;

            //if ( lhpScanNormalInfo.ScanDateType == LHPPrimaryScanInfo.NormalScanDateType.ScanNow )
            //{
            //    this.RadioButtonNow.Checked = true;
            //}
            //else if ( lhpScanNormalInfo.ScanDateType == LHPPrimaryScanInfo.NormalScanDateType.ScanSelect )
            //{
            //    this.RadioButtonSelect.Checked = true;
            //}

            //this.DateTimePickerSelect.Value = lhpScanNormalInfo.ScanDate;
        }

        public LHPPrimaryScanInfo.ScanTrendInfo GetLHPScanTrendInfo()
        {
            LHPPrimaryScanInfo.ScanTrendInfo lhpScanTrendInfo = new LHPPrimaryScanInfo.ScanTrendInfo();

            //lhpScanTrendInfo.ScanTrendSpace = (int)this.NumericUpDownKLineNumber.Value;

            return lhpScanTrendInfo;
        }

        public void SetLHPScanTrendInfo( LHPPrimaryScanInfo.ScanTrendInfo lhpScanTrendInfo )
        {
            //this.NumericUpDownKLineNumber.Value = lhpScanTrendInfo.ScanTrendSpace;
        }
    }
}
