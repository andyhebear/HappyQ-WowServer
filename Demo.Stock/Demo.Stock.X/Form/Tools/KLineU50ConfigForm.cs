using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.X.Tools
{
    public partial class KLineU50ConfigForm : Form
    {
        public KLineU50ConfigForm()
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

        private TreeNode m_MainTreeNodeA = new TreeNode( "常规选项" );
        private TreeNode m_MainTreeNodeB = new TreeNode( "取样方法" );
        private TreeNode m_MainTreeNodeC = new TreeNode( "形态函数" );
        private TreeNode m_MainTreeNodeD = new TreeNode( "增强刷选" );

        KLineU50ConfigA m_KLineU50ConfigA = new KLineU50ConfigA();
        KLineU50ConfigB m_KLineU50ConfigB = new KLineU50ConfigB();
        KLineU50ConfigC m_KLineU50ConfigC = new KLineU50ConfigC();
        KLineU50ConfigD m_KLineU50ConfigD = new KLineU50ConfigD();

        private UserControl m_CurrentConfigControl = null;

        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();

        private void KLineU50ConfigForm_Load( object sender, EventArgs eventArgs )
        {

            m_KLineU50ConfigA.Dock = DockStyle.Fill;
            m_KLineU50ConfigA.Visible = false;

            m_KLineU50ConfigB.Dock = DockStyle.Fill;
            m_KLineU50ConfigB.Visible = false;

            m_KLineU50ConfigC.Dock = DockStyle.Fill;
            m_KLineU50ConfigC.Visible = false;

            m_KLineU50ConfigD.Dock = DockStyle.Fill;
            m_KLineU50ConfigD.Visible = false;

            this.m_AllConfigControlInfo.Add( m_MainTreeNodeA, m_KLineU50ConfigA );
            this.m_AllConfigControlInfo.Add( m_MainTreeNodeB, m_KLineU50ConfigB );
            this.m_AllConfigControlInfo.Add( m_MainTreeNodeC, m_KLineU50ConfigC );
            this.m_AllConfigControlInfo.Add( m_MainTreeNodeD, m_KLineU50ConfigD );

            this.Panel.Controls.Add( m_KLineU50ConfigA );
            this.Panel.Controls.Add( m_KLineU50ConfigB );
            this.Panel.Controls.Add( m_KLineU50ConfigC );
            this.Panel.Controls.Add( m_KLineU50ConfigD );

            this.TreeView.Nodes.Add( m_MainTreeNodeA );
            this.TreeView.Nodes.Add( m_MainTreeNodeB );
            this.TreeView.Nodes.Add( m_MainTreeNodeC );
            this.TreeView.Nodes.Add( m_MainTreeNodeD );

            this.TreeView.SelectedNode = m_MainTreeNodeA;
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
    }
}
