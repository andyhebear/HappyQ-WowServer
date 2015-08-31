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
    public partial class ScanPrimary2ControlSub2B : UserControl
    {
        ScanPrimary2ControlSub2BSub1 m_ScanControlSub2A = null;
        ScanPrimary2ControlSub2BSub2 m_ScanControlSub2B = null;
        ScanPrimary2ControlSub2BSub3 m_ScanControlSub2C = null;

        public ScanPrimary2ControlSub2B()
        {
            InitializeComponent();
            Initialize();
        }

        private void ScanPrimaryControlSub2General_Load( object sender, EventArgs e )
        {
            //this.LabelNow.Text = DateTime.Now.ToLongDateString();
        }

        private void Initialize()
        {
            m_ScanControlSub2A = new ScanPrimary2ControlSub2BSub1();
            m_ScanControlSub2A.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 0, "扫描设置A", m_ScanControlSub2A.Handle.ToInt32(), 0 );

            m_ScanControlSub2B = new ScanPrimary2ControlSub2BSub2();
            m_ScanControlSub2B.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 1, "扫描设置B", m_ScanControlSub2B.Handle.ToInt32(), 0 );


            m_ScanControlSub2C = new ScanPrimary2ControlSub2BSub3();
            m_ScanControlSub2C.Parent = this.axTabControl;
            this.axTabControl.InsertItem( 2, "扫描设置C", m_ScanControlSub2C.Handle.ToInt32(), 0 );
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
