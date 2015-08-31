using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.LHP
{
    public partial class UpScanOptionForm : Form
    {
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();

        private UserControl m_CurrentConfigControl = null;

        ScanUpControlSub1 m_ScanUpControlSub1 = null;
        ScanUpControlSub2 m_ScanUpControlSub2 = null;
        ScanUpControlSub3 m_ScanUpControlSub3 = null;
        ScanUpControlSub4 m_ScanUpControlSub4 = null;
        ScanUpControlSub5 m_ScanUpControlSub5 = null;

        private TreeNode m_MainTreeNode = null;
        private TreeNode m_MainTreeNodeSub1 = null;
        private TreeNode m_MainTreeNodeSub2 = null;
        private TreeNode m_MainTreeNodeSub3 = null;
        private TreeNode m_MainTreeNodeSub4 = null;
        private TreeNode m_MainTreeNodeSub5 = null;

        public UpScanOptionForm()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            m_MainTreeNode = new TreeNode( "DCUR扫描" );
            m_MainTreeNodeSub1 = new TreeNode( "UT股票筛选" );
            m_MainTreeNodeSub2 = new TreeNode( "UT优质股票筛选" );
            m_MainTreeNodeSub3 = new TreeNode( "UT静态SR点品质筛选" );
            m_MainTreeNodeSub4 = new TreeNode( "UT动态SR点品质筛选" );
            m_MainTreeNodeSub5 = new TreeNode( "SRCK价格点选择与比较" );

            // 设置
            m_MainTreeNode.Nodes.Add( m_MainTreeNodeSub1 );
            m_MainTreeNode.Nodes.Add( m_MainTreeNodeSub2 );
            m_MainTreeNode.Nodes.Add( m_MainTreeNodeSub3 );
            m_MainTreeNode.Nodes.Add( m_MainTreeNodeSub4 );
            m_MainTreeNode.Nodes.Add( m_MainTreeNodeSub5 );
            m_MainTreeNode.Expand();

            this.TreeView.Nodes.Add( m_MainTreeNode );

            m_ScanUpControlSub1 = new ScanUpControlSub1();
            m_ScanUpControlSub1.Dock = DockStyle.Fill;
            m_ScanUpControlSub1.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNode, m_ScanUpControlSub1 );
            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1, m_ScanUpControlSub1 );

            this.Panel.Controls.Add( m_ScanUpControlSub1 );

            m_ScanUpControlSub2 = new ScanUpControlSub2();
            m_ScanUpControlSub2.Dock = DockStyle.Fill;
            m_ScanUpControlSub2.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub2, m_ScanUpControlSub2 );

            this.Panel.Controls.Add( m_ScanUpControlSub2 );

            m_ScanUpControlSub3 = new ScanUpControlSub3();
            m_ScanUpControlSub3.Dock = DockStyle.Fill;
            m_ScanUpControlSub3.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub3, m_ScanUpControlSub3 );

            this.Panel.Controls.Add( m_ScanUpControlSub3 );

            m_ScanUpControlSub4 = new ScanUpControlSub4();
            m_ScanUpControlSub4.Dock = DockStyle.Fill;
            m_ScanUpControlSub4.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub4, m_ScanUpControlSub4 );

            this.Panel.Controls.Add( m_ScanUpControlSub4 );

            m_ScanUpControlSub5 = new ScanUpControlSub5();
            m_ScanUpControlSub5.Dock = DockStyle.Fill;
            m_ScanUpControlSub5.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub5, m_ScanUpControlSub5 );

            this.Panel.Controls.Add( m_ScanUpControlSub5 );

            //LHPPrimaryScanInfo getLHPScanInfo = GlobalSetting.LoadLHPPrimaryScanInfo( GlobalSetting.LHPPrimaryScanInfoFilePath );
            //if ( getLHPScanInfo != null )
            //    this.SetLHPPrimaryScanInfo( getLHPScanInfo );

            this.TreeView.SelectedNode = m_MainTreeNode;
        }

        private void GradeScanOptionForm_Load( object sender, EventArgs eventArgs )
        {

        }

        private void TreeView_AfterSelect( object sender, TreeViewEventArgs eventArgs )
        {
            if ( eventArgs.Node == null )
                return;

            if ( eventArgs.Node.Parent == null )
            {
                this.TreeView.SelectedNode = m_MainTreeNodeSub1;
                return;
            }

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

        }


    }
}
