using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.X.U50
{
    public partial class DocumentFormSub1 : Form
    {
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();

        private UserControl m_CurrentConfigControl = null;

        private TreeNode m_MainTreeNode = new TreeNode( "设置" );
        private TreeNode m_MainTreeNodeSub = new TreeNode( "常规" );

        private TreeNode m_PolicyTreeNode = new TreeNode( "增强刷选策略" );
        private TreeNode m_PolicyTreeNodeSub1 = new TreeNode( "形态函数" );
        private TreeNode m_PolicyTreeNodeSub2 = new TreeNode( "增强刷选" );

        private DocumentFormSub1ControlSub1 m_ConfigAControl = null;
        private PolicyDControl m_ConfigDControl = null;
        private PolicyEControl m_ConfigEControl = null;
       public DocumentFormSub1()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged( EventArgs eventArgs )
        {
            base.OnVisibleChanged( eventArgs );

            if ( this.Visible == true )
            {
                MainForm.Instance.AxSkinFramework.ApplyWindow( this.Handle.ToInt32() );
                this.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            }
        }

        private void DocumentFormSub1_Load( object sender, EventArgs e )
        {
            // 设置
            m_MainTreeNode.Nodes.Add( m_MainTreeNodeSub );
            this.TreeView.Nodes.Add( m_MainTreeNode );

            m_PolicyTreeNode.Nodes.Add( m_PolicyTreeNodeSub1 );
            m_PolicyTreeNode.Nodes.Add( m_PolicyTreeNodeSub2 );
            this.TreeView.Nodes.Add( m_PolicyTreeNode );

            m_ConfigAControl = new DocumentFormSub1ControlSub1();
            m_ConfigAControl.Dock = DockStyle.Fill;
            m_ConfigAControl.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNode, m_ConfigAControl );
            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub, m_ConfigAControl );

            this.Panel.Controls.Add( m_ConfigAControl );

            m_ConfigDControl = new PolicyDControl();
            m_ConfigDControl.Dock = DockStyle.Fill;
            m_ConfigDControl.Visible = false;

            this.Panel.Controls.Add( m_ConfigDControl );

            this.m_AllConfigControlInfo.Add( m_PolicyTreeNodeSub1, m_ConfigDControl );

            m_ConfigEControl = new PolicyEControl();
            m_ConfigEControl.Dock = DockStyle.Fill;
            m_ConfigEControl.Visible = false;

            this.Panel.Controls.Add( m_ConfigEControl );

            this.m_AllConfigControlInfo.Add( m_PolicyTreeNode, m_ConfigEControl );
            this.m_AllConfigControlInfo.Add( m_PolicyTreeNodeSub2, m_ConfigEControl );

            // 15801701440
            this.TreeView.SelectedNode = m_PolicyTreeNode;
        }

        private void TreeView_AfterSelect( object sender, TreeViewEventArgs eventArgs )
        {
            if ( eventArgs.Node == null )
                return;

            if ( eventArgs.Node.Parent == null )
            {
                eventArgs.Node.Expand();

                if ( eventArgs.Node == m_MainTreeNode )
                    this.TreeView.SelectedNode = m_MainTreeNodeSub;
                else if ( eventArgs.Node == m_PolicyTreeNode )
                    this.TreeView.SelectedNode = m_PolicyTreeNodeSub2;

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

        private void ButtonScan_Click( object sender, EventArgs e )
        {

        }
    }
}
