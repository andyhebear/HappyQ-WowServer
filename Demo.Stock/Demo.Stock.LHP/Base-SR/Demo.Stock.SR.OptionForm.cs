using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;
using Demo.Stock.LHP.BaseSR.Common;

namespace Demo.Stock.LHP.BaseSR
{
    public partial class SROptionForm : Form
    {
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();

        private UserControl m_CurrentConfigControl = null;

        SRControlSub1 m_ScanControlSub = null;
        SRControlSub2 m_ScanControlSub2 = null;
        SRControlSub3 m_ScanControlSub3 = null;

        private TreeNode m_MainTreeNode = null;
        private TreeNode m_MainTreeNodeSub = null;
        private TreeNode m_MainTreeNodeSub2 = null;

        public SROptionForm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            m_MainTreeNode = new TreeNode( "常规设置" );
            m_MainTreeNodeSub = new TreeNode( "股票扫描设置" );
            m_MainTreeNodeSub2 = new TreeNode( "股票清单设置" );

            {
                // 设置
                this.TreeView.Nodes.Add( m_MainTreeNode );

                m_ScanControlSub = new SRControlSub1();
                m_ScanControlSub.Dock = DockStyle.Fill;
                m_ScanControlSub.Visible = false;

                this.m_AllConfigControlInfo.Add( m_MainTreeNode, m_ScanControlSub );

                this.Panel.Controls.Add( m_ScanControlSub );
            }

            {
                this.TreeView.Nodes.Add( m_MainTreeNodeSub );

                m_ScanControlSub2 = new SRControlSub2();
                m_ScanControlSub2.Dock = DockStyle.Fill;
                m_ScanControlSub2.Visible = false;

                this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub, m_ScanControlSub2 );

                this.Panel.Controls.Add( m_ScanControlSub2 );
            }

            {
                this.TreeView.Nodes.Add( m_MainTreeNodeSub2 );

                m_ScanControlSub3 = new SRControlSub3();
                m_ScanControlSub3.Dock = DockStyle.Fill;
                m_ScanControlSub3.Visible = false;

                this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub2, m_ScanControlSub3 );

                this.Panel.Controls.Add( m_ScanControlSub3 );
            }

            LHPPrimaryScanInfo getLHPScanInfo = GlobalSetting.LoadLHPPrimaryScanInfo( GlobalSetting.LHPPrimaryScanInfoFilePath );
            if ( getLHPScanInfo != null )
                this.SetLHPPrimaryScanInfo( getLHPScanInfo );

            this.TreeView.SelectedNode = m_MainTreeNode;
        }

        private bool m_IsInitializing = false;
        private void PrimaryScanOptionForm_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            Initialize();
        }

        private void TreeView_AfterSelect( object sender, TreeViewEventArgs eventArgs )
        {
            if ( eventArgs.Node == null )
                return;

            UserControl outOptionControl = null;
            if ( m_AllConfigControlInfo.TryGetValue( eventArgs.Node, out outOptionControl ) == false )
            {
                if ( this.m_CurrentConfigControl != null )
                    this.m_CurrentConfigControl.Visible = false;
            }
            else
            {
                if ( this.m_CurrentConfigControl != null && outOptionControl != this.m_CurrentConfigControl )
                    this.m_CurrentConfigControl.Visible = false;

                if ( outOptionControl != null )
                {
                    outOptionControl.Visible = true;
                    this.m_CurrentConfigControl = outOptionControl;
                }
            }
        }

        private void ButtonOK_Click( object sender, EventArgs e )
        {
            m_ScanControlSub.ButtonOK();
            m_ScanControlSub2.ButtonOK();
            m_ScanControlSub3.ButtonOK();

            //LHPPrimaryScanInfo getLHPScanInfo = this.GetLHPPrimaryScanInfo();
            //GlobalSetting.SaveLHPPrimaryScanInfo( GlobalSetting.LHPPrimaryScanInfoFilePath, getLHPScanInfo );

            //List<SRReport> srReportList = new List<SRReport>();
            //foreach ( StockFileInfo stockFileInfo in MainForm.Instance.OptionForm.GetStockFileInfos() )
            //{
            //    SRReport srReport = GlobalSetting.ScanSRStaticData( stockFileInfo, getLHPScanInfo );
            //    if ( srReport != null )
            //        srReportList.Add( srReport );
            //}

            //GlobalSetting.SRReports = srReportList.ToArray();
            //MainForm.Instance.LoadNewFile_Static();
            //MainForm.Instance.LoadNewFile_Dynamic();

            this.Close();
        }

        private void ButtonCancel_Click( object sender, EventArgs e )
        {
            m_ScanControlSub.ButtonCancel();
            m_ScanControlSub2.ButtonCancel();
            m_ScanControlSub3.ButtonCancel();

            this.Close();
        }

        public LHPPrimaryScanInfo GetLHPPrimaryScanInfo()
        {
            LHPPrimaryScanInfo lhpScanInfo = new LHPPrimaryScanInfo();
            lhpScanInfo.m_ScanBaseInfo = m_ScanControlSub.GetLHPScanBaseInfo();

            return lhpScanInfo;
        }

        public void SetLHPPrimaryScanInfo( LHPPrimaryScanInfo lhpScanInfo )
        {
            m_ScanControlSub.SetLHPScanBaseInfo( lhpScanInfo.m_ScanBaseInfo );
        }

        private void ButtonLoadSR_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
            }
        }

        private void ButtonSaveSR_Click( object sender, EventArgs e )
        {
            if ( this.saveFileDialog.ShowDialog() == DialogResult.OK )
            {
            }
        }

        SROptionFormInfo GetSROptionInfo()
        {
            SROptionFormInfo SROptionFormInfo = new SROptionFormInfo();

            SROptionFormInfo.m_GeneralInfo = m_ScanControlSub.GetSRGeneralInfo();
            SROptionFormInfo.m_SRScanInfo = m_ScanControlSub2.GetSRScanInfo();

            return SROptionFormInfo;
        }


        void GetSROptionInfo( SROptionFormInfo srOptionInfo )
        {
            m_ScanControlSub.SetSRGeneralInfo( srOptionInfo.m_GeneralInfo );
            m_ScanControlSub2.SetSRScanInfo( srOptionInfo.m_SRScanInfo );
        }

        private bool m_isClose = false;
        internal bool IsClose
        {
            get { return m_isClose; }
            set { m_isClose = value; }
        }

        private void SROptionForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( m_isClose == false )
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

    }
}
