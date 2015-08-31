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
    public partial class ScanControlSub2 : UserControl
    {
        public ScanControlSub2()
        {
            InitializeComponent();
        }

        private void ScanControlSub2_Load( object sender, EventArgs e )
        {
            this.LabelNow.Text = DateTime.Now.ToLongDateString();
        }

        public LHPScanInfo.ScanNormalInfo GetLHPScanNormalInfo()
        {
            LHPScanInfo.ScanNormalInfo lhpScanNormalInfo = new LHPScanInfo.ScanNormalInfo();

            lhpScanNormalInfo.AllowScanSR = this.CheckBoxAllowSR.Checked;

            if ( this.RadioButtonNow.Checked == true )
            {
                lhpScanNormalInfo.ScanDateType = LHPScanInfo.NormalScanDateType.ScanNow;
                lhpScanNormalInfo.ScanDate = DateTime.Now;
            }
            else if ( this.RadioButtonSelect.Checked == true )
            {
                lhpScanNormalInfo.ScanDateType = LHPScanInfo.NormalScanDateType.ScanSelect;
                lhpScanNormalInfo.ScanDate = this.DateTimePickerSelect.Value;
            }

            return lhpScanNormalInfo;
        }

        public void SetLHPScanNormalInfo( LHPScanInfo.ScanNormalInfo lhpScanNormalInfo )
        {
            this.CheckBoxAllowSR.Checked = lhpScanNormalInfo.AllowScanSR;

            if ( lhpScanNormalInfo.ScanDateType == LHPScanInfo.NormalScanDateType.ScanNow )
            {
                this.RadioButtonNow.Checked = true;
            }
            else if ( lhpScanNormalInfo.ScanDateType == LHPScanInfo.NormalScanDateType.ScanSelect )
            {
                this.RadioButtonSelect.Checked = true;
            }

            this.DateTimePickerSelect.Value = lhpScanNormalInfo.ScanDate;
        }


    }
}
