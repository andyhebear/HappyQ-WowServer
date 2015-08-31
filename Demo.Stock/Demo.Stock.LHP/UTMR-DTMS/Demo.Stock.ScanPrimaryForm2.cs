using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;

namespace Demo.Stock.LHP
{
    public partial class PrimaryScanOptionForm2 : Form
    {
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();

        private UserControl m_CurrentConfigControl = null;

        ScanPrimary2ControlSub1 m_ScanControlSub = null;
        ScanPrimary2ControlSub2 m_ScanControlSub2 = null;
        ScanPrimary2ControlSub2A m_ScanControlSub2A = null;
        ScanPrimary2ControlSub2B m_ScanControlSub2B = null;
        ScanPrimary2ControlSub2C m_ScanControlSub2C = null;
        ScanPrimary2ControlSub2D m_ScanControlSub2D = null;
        ScanPrimary2ControlSub2E m_ScanControlSub2E = null;
        ScanPrimary2ControlSub2F m_ScanControlSub2F = null;

        ScanPrimary2ControlSub3 m_ScanControlSub3 = null;
        ScanPrimary2ControlSub3A m_ScanControlSub3A = null;
        ScanPrimary2ControlSub3B m_ScanControlSub3B = null;
        ScanPrimary2ControlSub3C m_ScanControlSub3C = null;
        ScanPrimary2ControlSub3D m_ScanControlSub3D = null;
        ScanPrimary2ControlSub3E m_ScanControlSub3E = null;
        ScanPrimary2ControlSub3F m_ScanControlSub3F = null;

        ScanPrimary2ControlSub4 m_ScanControlSub4 = null;

        private TreeNode m_MainTreeNode = null;

        private TreeNode m_MainTreeNodeSub = null;
        private TreeNode m_MainTreeNodeSubA = null;
        private TreeNode m_MainTreeNodeSubB = null;
        private TreeNode m_MainTreeNodeSubC = null;
        private TreeNode m_MainTreeNodeSubD = null;
        private TreeNode m_MainTreeNodeSubE = null;
        private TreeNode m_MainTreeNodeSubF = null;

        private TreeNode m_MainTreeNodeSub1 = null;
        private TreeNode m_MainTreeNodeSub1A = null;
        private TreeNode m_MainTreeNodeSub1B = null;
        private TreeNode m_MainTreeNodeSub1C = null;
        private TreeNode m_MainTreeNodeSub1D = null;
        private TreeNode m_MainTreeNodeSub1E = null;
        private TreeNode m_MainTreeNodeSub1F = null;

        private TreeNode m_MainTreeNodeSub2 = null;

        public PrimaryScanOptionForm2()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            m_MainTreeNode = new TreeNode( "常规设置" );
            m_MainTreeNodeSub = new TreeNode( "UTMR扫描设置" );
            {
                m_MainTreeNodeSubA = new TreeNode( "MRHPK筛选" );
                m_MainTreeNodeSubB = new TreeNode( "MRLPK筛选" );
                m_MainTreeNodeSubC = new TreeNode( "MRGULK筛选" );
                m_MainTreeNodeSubD = new TreeNode( "MRGUHK筛选" );
                m_MainTreeNodeSubE = new TreeNode( "MRGDLK筛选" );
                m_MainTreeNodeSubF = new TreeNode( "MRGDHK筛选" );
                m_MainTreeNodeSub.Nodes.Add( m_MainTreeNodeSubA );
                m_MainTreeNodeSub.Nodes.Add( m_MainTreeNodeSubB );
                m_MainTreeNodeSub.Nodes.Add( m_MainTreeNodeSubC );
                m_MainTreeNodeSub.Nodes.Add( m_MainTreeNodeSubD );
                m_MainTreeNodeSub.Nodes.Add( m_MainTreeNodeSubE );
                m_MainTreeNodeSub.Nodes.Add( m_MainTreeNodeSubF );
                m_MainTreeNodeSub.Expand();
           }

            m_MainTreeNodeSub1 = new TreeNode( "DTMS扫描设置" );
            {
                m_MainTreeNodeSub1A = new TreeNode( "MSLPK筛选" );
                m_MainTreeNodeSub1B = new TreeNode( "MSHPK筛选" );
                m_MainTreeNodeSub1C = new TreeNode( "MSGULK筛选" );
                m_MainTreeNodeSub1D = new TreeNode( "MSGUHK筛选" );
                m_MainTreeNodeSub1E = new TreeNode( "MSGDLK筛选" );
                m_MainTreeNodeSub1F = new TreeNode( "MSGDHK筛选" );
                m_MainTreeNodeSub1.Nodes.Add( m_MainTreeNodeSub1A );
                m_MainTreeNodeSub1.Nodes.Add( m_MainTreeNodeSub1B );
                m_MainTreeNodeSub1.Nodes.Add( m_MainTreeNodeSub1C );
                m_MainTreeNodeSub1.Nodes.Add( m_MainTreeNodeSub1D );
                m_MainTreeNodeSub1.Nodes.Add( m_MainTreeNodeSub1E );
                m_MainTreeNodeSub1.Nodes.Add( m_MainTreeNodeSub1F );
                m_MainTreeNodeSub1.Expand();
            }

            m_MainTreeNodeSub2 = new TreeNode( "SR报表设置" );

            // 设置
            this.TreeView.Nodes.Add( m_MainTreeNode );
            this.TreeView.Nodes.Add( m_MainTreeNodeSub );
            this.TreeView.Nodes.Add( m_MainTreeNodeSub1 );
            this.TreeView.Nodes.Add( m_MainTreeNodeSub2 );

            {
                m_ScanControlSub = new ScanPrimary2ControlSub1();
                m_ScanControlSub.Dock = DockStyle.Fill;
                m_ScanControlSub.Visible = false;

                this.m_AllConfigControlInfo.Add( m_MainTreeNode, m_ScanControlSub );
                this.Panel.Controls.Add( m_ScanControlSub );
            }

            {
                m_ScanControlSub2 = new ScanPrimary2ControlSub2();
                m_ScanControlSub2.Dock = DockStyle.Fill;
                m_ScanControlSub2.Visible = false;

                this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub, m_ScanControlSub2 );
                this.Panel.Controls.Add( m_ScanControlSub2 );

                {
                    m_ScanControlSub2A = new ScanPrimary2ControlSub2A();
                    m_ScanControlSub2A.Dock = DockStyle.Fill;
                    m_ScanControlSub2A.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSubA, m_ScanControlSub2A );
                    this.Panel.Controls.Add( m_ScanControlSub2A );
                }

                {
                    m_ScanControlSub2B = new ScanPrimary2ControlSub2B();
                    m_ScanControlSub2B.Dock = DockStyle.Fill;
                    m_ScanControlSub2B.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSubB, m_ScanControlSub2B );
                    this.Panel.Controls.Add( m_ScanControlSub2B );
                }

                {
                    m_ScanControlSub2C = new ScanPrimary2ControlSub2C();
                    m_ScanControlSub2C.Dock = DockStyle.Fill;
                    m_ScanControlSub2C.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSubC, m_ScanControlSub2C );
                    this.Panel.Controls.Add( m_ScanControlSub2C );
                }

                {
                    m_ScanControlSub2D = new ScanPrimary2ControlSub2D();
                    m_ScanControlSub2D.Dock = DockStyle.Fill;
                    m_ScanControlSub2D.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSubD, m_ScanControlSub2D );
                    this.Panel.Controls.Add( m_ScanControlSub2D );
                }

                {
                    m_ScanControlSub2E = new ScanPrimary2ControlSub2E();
                    m_ScanControlSub2E.Dock = DockStyle.Fill;
                    m_ScanControlSub2E.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSubE, m_ScanControlSub2E );
                    this.Panel.Controls.Add( m_ScanControlSub2E );
                }

                {
                    m_ScanControlSub2F = new ScanPrimary2ControlSub2F();
                    m_ScanControlSub2F.Dock = DockStyle.Fill;
                    m_ScanControlSub2F.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSubF, m_ScanControlSub2F );
                    this.Panel.Controls.Add( m_ScanControlSub2F );
                }

            }

            {
                m_ScanControlSub3 = new ScanPrimary2ControlSub3();
                m_ScanControlSub3.Dock = DockStyle.Fill;
                m_ScanControlSub3.Visible = false;

                this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1, m_ScanControlSub3 );
                this.Panel.Controls.Add( m_ScanControlSub3 );

                {
                    m_ScanControlSub3A = new ScanPrimary2ControlSub3A();
                    m_ScanControlSub3A.Dock = DockStyle.Fill;
                    m_ScanControlSub3A.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1A, m_ScanControlSub3A );
                    this.Panel.Controls.Add( m_ScanControlSub3A );
                }

                {
                    m_ScanControlSub3B = new ScanPrimary2ControlSub3B();
                    m_ScanControlSub3B.Dock = DockStyle.Fill;
                    m_ScanControlSub3B.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1B, m_ScanControlSub3B );
                    this.Panel.Controls.Add( m_ScanControlSub3B );
                }

                {
                    m_ScanControlSub3C = new ScanPrimary2ControlSub3C();
                    m_ScanControlSub3C.Dock = DockStyle.Fill;
                    m_ScanControlSub3C.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1C, m_ScanControlSub3C );
                    this.Panel.Controls.Add( m_ScanControlSub3C );
                }

                {
                    m_ScanControlSub3D = new ScanPrimary2ControlSub3D();
                    m_ScanControlSub3D.Dock = DockStyle.Fill;
                    m_ScanControlSub3D.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1D, m_ScanControlSub3D );
                    this.Panel.Controls.Add( m_ScanControlSub3D );
                }

                {
                    m_ScanControlSub3E = new ScanPrimary2ControlSub3E();
                    m_ScanControlSub3E.Dock = DockStyle.Fill;
                    m_ScanControlSub3E.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1E, m_ScanControlSub3E );
                    this.Panel.Controls.Add( m_ScanControlSub3E );
                }

                {
                    m_ScanControlSub3F = new ScanPrimary2ControlSub3F();
                    m_ScanControlSub3F.Dock = DockStyle.Fill;
                    m_ScanControlSub3F.Visible = false;

                    this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1F, m_ScanControlSub3F );
                    this.Panel.Controls.Add( m_ScanControlSub3F );
                }

            }

            {
                m_ScanControlSub4 = new ScanPrimary2ControlSub4();
                m_ScanControlSub4.Dock = DockStyle.Fill;
                m_ScanControlSub4.Visible = false;

                this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub2, m_ScanControlSub4 );
                this.Panel.Controls.Add( m_ScanControlSub4 );
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

            if ( eventArgs.Node.Nodes.Count > 0 )
                eventArgs.Node.Expand();

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
            LHPPrimaryScanInfo getLHPScanInfo = this.GetLHPPrimaryScanInfo();
            GlobalSetting.SaveLHPPrimaryScanInfo( GlobalSetting.LHPPrimaryScanInfoFilePath, getLHPScanInfo );

            List<SRReport> srReportList = new List<SRReport>();
            //foreach ( StockFileInfo stockFileInfo in MainForm.Instance.OptionForm.GetStockFileInfos() )
            //{
            //    SRReport srReport = GlobalSetting.ScanSRStaticData( stockFileInfo, getLHPScanInfo );
            //    if ( srReport != null )
            //        srReportList.Add( srReport );
            //}

            GlobalSetting.SRReports = srReportList.ToArray();
            //MainForm.Instance.LoadNewFile_Static();
            //MainForm.Instance.LoadNewFile_Dynamic();

            this.Close();
        }

        private void ButtonCancel_Click( object sender, EventArgs e )
        {
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

        private void ButtonLoad_Click( object sender, EventArgs e )
        {
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
            }
        }

        private void ButtonSave_Click( object sender, EventArgs e )
        {
            if ( this.saveFileDialog.ShowDialog() == DialogResult.OK )
            {
            }
        }
        
        private bool m_isClose = false;
        internal bool IsClose
        {
            get { return m_isClose; }
            set { m_isClose = value; }
        }

        private void PrimaryScanOptionForm2_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( m_isClose == false )
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

    }
}
