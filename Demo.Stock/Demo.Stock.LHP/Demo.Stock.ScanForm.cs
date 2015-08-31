using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;
using Demo.Stock.LHP.BaseSR;

namespace Demo.Stock.LHP
{
    public partial class ScanOptionForm : Form
    {
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();

        private UserControl m_CurrentConfigControl = null;

        SRControlSub1 m_ScanControlSub1 = null;
        ScanControlSub2 m_ScanControlSub2 = null;
        ScanControlSub2A m_ScanControlSub2A = null;
        SRControlSub2 m_ScanControlSub2B = null;
        ScanControlSub2C m_ScanControlSub2C = null;
        ScanControlSub2D m_ScanControlSub2D = null;
        ScanControlSub3 m_ScanControlSub3 = null;

        private TreeNode m_MainTreeNode = null;

        private TreeNode m_MainTreeNode1 = null;

        private TreeNode m_MainTreeNode2 = null;

        private TreeNode m_MainTreeNodeSub = null;
        private TreeNode m_MainTreeNodeSub1 = null;
        private TreeNode m_MainTreeNodeSub2 = null;
        private TreeNode m_MainTreeNodeSub3 = null;
        //private TreeNode m_MainTreeNodeSub = null;
        //private TreeNode m_MainTreeNodeSub1 = null;

        public ScanOptionForm()
        {
            InitializeComponent();
            //Initialize();
        }

        public void Initialize()
        {
            //m_MainTreeNode = new TreeNode( "初级扫描" );
            //m_MainTreeNode1 = new TreeNode( "基础扫描" );
            //m_MainTreeNode2 = new TreeNode( "增强扫描" );

            //m_MainTreeNodeSub = new TreeNode( "当前趋势设定与筛选" );
            //m_MainTreeNodeSub1 = new TreeNode( "K线价格点设定" );
            //m_MainTreeNodeSub2 = new TreeNode( "SR点筛选" );
            //m_MainTreeNodeSub3 = new TreeNode( "趋势群筛选" );

            //// 设置
            //m_MainTreeNode1.Nodes.Add( m_MainTreeNodeSub );
            //m_MainTreeNode1.Nodes.Add( m_MainTreeNodeSub1 );
            //m_MainTreeNode1.Nodes.Add( m_MainTreeNodeSub2 );
            //m_MainTreeNode1.Nodes.Add( m_MainTreeNodeSub3 );
            //m_MainTreeNode1.Expand();

            //this.TreeView.Nodes.Add( m_MainTreeNode );
            //this.TreeView.Nodes.Add( m_MainTreeNode1 );
            //this.TreeView.Nodes.Add( m_MainTreeNode2 );

            //m_ScanControlSub1 = new ScanPrimaryControlSub1();
            //m_ScanControlSub1.Dock = DockStyle.Fill;
            //m_ScanControlSub1.Visible = false;

            //this.m_AllConfigControlInfo.Add( m_MainTreeNode, m_ScanControlSub1 );

            //this.Panel.Controls.Add( m_ScanControlSub1 );

            //m_ScanControlSub2 = new ScanControlSub2();
            //m_ScanControlSub2.Dock = DockStyle.Fill;
            //m_ScanControlSub2.Visible = false;

            //this.m_AllConfigControlInfo.Add( m_MainTreeNode1, m_ScanControlSub2 );

            //this.Panel.Controls.Add( m_ScanControlSub2 );

            //m_ScanControlSub2B = new ScanPrimaryControlSub2();
            //m_ScanControlSub2B.Dock = DockStyle.Fill;
            //m_ScanControlSub2B.Visible = false;

            //this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub, m_ScanControlSub2B );

            //this.Panel.Controls.Add( m_ScanControlSub2B );

            //m_ScanControlSub2A = new ScanControlSub2A();
            //m_ScanControlSub2A.Dock = DockStyle.Fill;
            //m_ScanControlSub2A.Visible = false;

            //this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1, m_ScanControlSub2A );

            //this.Panel.Controls.Add( m_ScanControlSub2A );

            //m_ScanControlSub2C = new ScanControlSub2C();
            //m_ScanControlSub2C.Dock = DockStyle.Fill;
            //m_ScanControlSub2C.Visible = false;

            //this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub2, m_ScanControlSub2C );

            //this.Panel.Controls.Add( m_ScanControlSub2C );

            //m_ScanControlSub2D = new ScanControlSub2D();
            //m_ScanControlSub2D.Dock = DockStyle.Fill;
            //m_ScanControlSub2D.Visible = false;

            //this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub3, m_ScanControlSub2D );

            //this.Panel.Controls.Add( m_ScanControlSub2D );

            //m_ScanControlSub3 = new ScanControlSub3();
            //m_ScanControlSub3.Dock = DockStyle.Fill;
            //m_ScanControlSub3.Visible = false;

            //this.m_AllConfigControlInfo.Add( m_MainTreeNode2, m_ScanControlSub3 );

            //this.Panel.Controls.Add( m_ScanControlSub3 );

            //LHPScanInfo lhpScanInfo = GlobalSetting.LoadLHPScanInfo( GlobalSetting.LHPScanInfoFilePath );
            //if ( lhpScanInfo != null )
            //    this.SetLHPScanInfo( lhpScanInfo );

            //this.TreeView.SelectedNode = m_MainTreeNodeSub;
        }

        private bool m_IsInitializing = false;
        private void ScanOptionForm_Load( object sender, EventArgs eventArgs )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

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

        private void ButtonScan_Click( object sender, EventArgs eventArgs )
        {
            LHPScanInfo getLHPScanInfo = this.GetLHPScanInfo();
            GlobalSetting.SaveLHPScanInfo( GlobalSetting.LHPScanInfoFilePath, getLHPScanInfo );

            //foreach ( StockFileInfo stockFileInfo in MainForm.Instance.OptionForm.GetStockFileInfos() )
            //    GlobalSetting.ScanSRStaticData( stockFileInfo, getLHPScanInfo );
        }

        public LHPScanInfo GetLHPScanInfo()
        {
            LHPScanInfo lhpScanInfo = new LHPScanInfo();
            //lhpScanInfo.m_ScanBaseInfo = m_ScanControlSub1.GetLHPScanBaseInfo();
            //lhpScanInfo.m_ScanNormalInfo = m_ScanControlSub2.GetLHPScanNormalInfo();

            //lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo = m_ScanControlSub2B.GetLHPScanTrendInfo();

            return lhpScanInfo;
        }

        public void SetLHPScanInfo( LHPScanInfo lhpScanInfo )
        {
            //m_ScanControlSub1.SetLHPScanBaseInfo( lhpScanInfo.m_ScanBaseInfo);
            //m_ScanControlSub2.SetLHPScanNormalInfo( lhpScanInfo.m_ScanNormalInfo );

            //m_ScanControlSub2B.SetLHPScanTrendInfo( lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo );

        }
    }
}
