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
    public partial class DownScanOptionForm : Form
    {
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();

        private UserControl m_CurrentConfigControl = null;

        ScanDownControlSub1 m_ScanDownControlSub1 = null;
        ScanDownControlSub2 m_ScanDownControlSub2 = null;
        ScanDownControlSub3 m_ScanDownControlSub3 = null;
        ScanDownControlSub4 m_ScanDownControlSub4 = null;
        ScanDownControlSub5 m_ScanDownControlSub5 = null;

        private TreeNode m_MainTreeNode = null;
        private TreeNode m_MainTreeNodeSub1 = null;
        private TreeNode m_MainTreeNodeSub2 = null;
        private TreeNode m_MainTreeNodeSub3 = null;
        private TreeNode m_MainTreeNodeSub4 = null;
        private TreeNode m_MainTreeNodeSub5 = null;

        public DownScanOptionForm()
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

            m_ScanDownControlSub1 = new ScanDownControlSub1();
            m_ScanDownControlSub1.Dock = DockStyle.Fill;
            m_ScanDownControlSub1.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNode, m_ScanDownControlSub1 );
            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1, m_ScanDownControlSub1 );

            this.Panel.Controls.Add( m_ScanDownControlSub1 );

            m_ScanDownControlSub2 = new ScanDownControlSub2();
            m_ScanDownControlSub2.Dock = DockStyle.Fill;
            m_ScanDownControlSub2.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub2, m_ScanDownControlSub2 );

            this.Panel.Controls.Add( m_ScanDownControlSub2 );

            m_ScanDownControlSub3 = new ScanDownControlSub3();
            m_ScanDownControlSub3.Dock = DockStyle.Fill;
            m_ScanDownControlSub3.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub3, m_ScanDownControlSub3 );

            this.Panel.Controls.Add( m_ScanDownControlSub3 );

            m_ScanDownControlSub4 = new ScanDownControlSub4();
            m_ScanDownControlSub4.Dock = DockStyle.Fill;
            m_ScanDownControlSub4.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub4, m_ScanDownControlSub4 );

            this.Panel.Controls.Add( m_ScanDownControlSub4 );

            m_ScanDownControlSub5 = new ScanDownControlSub5();
            m_ScanDownControlSub5.Dock = DockStyle.Fill;
            m_ScanDownControlSub5.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub5, m_ScanDownControlSub5 );

            this.Panel.Controls.Add( m_ScanDownControlSub5 );

            //LHPPrimaryScanInfo getLHPScanInfo = GlobalSetting.LoadLHPPrimaryScanInfo( GlobalSetting.LHPPrimaryScanInfoFilePath );
            //if ( getLHPScanInfo != null )
            //    this.SetLHPPrimaryScanInfo( getLHPScanInfo );

            this.TreeView.SelectedNode = m_MainTreeNode;
        }

        private void DownScanOptionForm_Load( object sender, EventArgs eventArgs )
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
    }
}
