using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Demo.Stock.X.U50.Common;
using XtremeCommandBars;

namespace Demo.Stock.X.U50
{
    public partial class PolicyForm : Form
    {
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();
        private HashSet<string> m_PolicyName = new HashSet<string>();
        private Dictionary<TreeNode, U50PolicyInfo> m_TreeNodePolicyInfo = new Dictionary<TreeNode, U50PolicyInfo>();
        private Dictionary<PolicyEControl, TreeNode> m_ButtonSetting = new Dictionary<PolicyEControl, TreeNode>();

        private UserControl m_CurrentConfigControl = null;
        private TreeNode m_CurrentDelTreeNode = null;

        private TreeNode m_MainTreeNode = null;
        private TreeNode m_MainTreeNodeSub = null;

        PolicyAControl m_ConfigAControl = null;
        public PolicyForm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            m_MainTreeNode = new TreeNode( "设置" );
            m_MainTreeNodeSub = new TreeNode( "常规" );

            // 设置
            m_MainTreeNode.Nodes.Add( m_MainTreeNodeSub );

            this.TreeView.Nodes.Add( m_MainTreeNode );

            m_ConfigAControl = new PolicyAControl();
            m_ConfigAControl.Dock = DockStyle.Fill;
            m_ConfigAControl.Visible = false;
            m_ConfigAControl.NewPolicyInfo += new EventHandlerNone( ConfigAControl_NewPolicyInfo );

            this.m_AllConfigControlInfo.Add( m_MainTreeNode, m_ConfigAControl );
            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub, m_ConfigAControl );

            this.Panel.Controls.Add( m_ConfigAControl );

            if ( U50GlobalSetting.IsLoadPolicyGlobalSetting == true )
            {
                for ( int iIndex = 0; iIndex < U50GlobalSetting.PolicyInfos.Length; iIndex++ )
                    NewPolicy( U50GlobalSetting.PolicyInfos[iIndex] );
            }

            this.TreeView.SelectedNode = m_MainTreeNodeSub;
        }

        private void ConfigAControl_NewPolicyInfo()
        {
            NewPolicy();
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

        private bool m_IsInitializing = false;
        private void ConfigForm_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            MainForm.Instance.AxCommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler( axCommandBars_Execute );
        }

        // 用于取消和删除
        private List<TreeNode> m_NewTreeNode = new List<TreeNode>();
        private int m_PolicyCount = 0;
        public void NewPolicy()
        {
            if ( m_IsInitializing == false )
                ConfigForm_Load( this, EventArgs.Empty );

            U50PolicyInfo policyInfo = new U50PolicyInfo();
            policyInfo.Guid = Guid.NewGuid().ToString();

            do
            {
                policyInfo.Name = string.Format( "U50策略{0}", m_PolicyCount++ );

                if ( m_PolicyName.Contains( policyInfo.Name ) == false )
                    break;
            } while ( true );

            // U50策略01
            TreeNode newTreeNodePolicy = new TreeNode( policyInfo.Name );
            TreeNode newTreeNodePolicySub = new TreeNode( "常规选项" );
            TreeNode newTreeNodePolicySub1 = new TreeNode( "取样方法" );
            TreeNode newTreeNodePolicySub2 = new TreeNode( "形态函数" );
            TreeNode newTreeNodePolicySub3 = new TreeNode( "增强刷选" );
            newTreeNodePolicy.Nodes.Add( newTreeNodePolicySub );
            newTreeNodePolicy.Nodes.Add( newTreeNodePolicySub1 );
            newTreeNodePolicy.Nodes.Add( newTreeNodePolicySub2 );
            newTreeNodePolicy.Nodes.Add( newTreeNodePolicySub3 );


            PolicyBControl configBControl = new PolicyBControl { Dock = DockStyle.Fill, Visible = false };

            this.m_AllConfigControlInfo.Add( newTreeNodePolicy, configBControl );
            this.m_AllConfigControlInfo.Add( newTreeNodePolicySub, configBControl );

            this.Panel.Controls.Add( configBControl );

            PolicyCControl configCControl = new PolicyCControl { Dock = DockStyle.Fill, Visible = false };
            policyInfo.Policy = configCControl.GetConfigPolicy();

            this.m_AllConfigControlInfo.Add( newTreeNodePolicySub1, configCControl );

            this.Panel.Controls.Add( configCControl );

            PolicyDControl configDControl = new PolicyDControl { Dock = DockStyle.Fill, Visible = false };
            policyInfo.Filtrate = configDControl.GetConfigFiltrate();

            this.m_AllConfigControlInfo.Add( newTreeNodePolicySub2, configDControl );

            this.Panel.Controls.Add( configDControl );

            PolicyEControl configEControl = new PolicyEControl { Dock = DockStyle.Fill, Visible = false };
            configEControl.EventButtonSetting += new EventHandler( OnEventButtonSetting );
            m_ButtonSetting.Add( configEControl, newTreeNodePolicySub2 );
            policyInfo.Extend = configEControl.GetConfigExtend();

            this.m_AllConfigControlInfo.Add( newTreeNodePolicySub3, configEControl );

            this.Panel.Controls.Add( configEControl );

            this.TreeView.Nodes.Add( newTreeNodePolicy );

            this.TreeView.SelectedNode = newTreeNodePolicy;

            m_NewTreeNode.Add( newTreeNodePolicy );

            m_TreeNodePolicyInfo.Add( newTreeNodePolicy, policyInfo );
        }

        private void NewPolicy( U50PolicyInfo policyInfo )
        {
            m_PolicyName.Add( policyInfo.Name );

            // U50策略01
            TreeNode newTreeNodePolicy = new TreeNode( policyInfo.Name );
            TreeNode newTreeNodePolicySub = new TreeNode( "常规选项" );
            TreeNode newTreeNodePolicySub1 = new TreeNode( "取样方法" );
            TreeNode newTreeNodePolicySub2 = new TreeNode( "形态函数" );
            TreeNode newTreeNodePolicySub3 = new TreeNode( "增强刷选" );
            newTreeNodePolicy.Nodes.Add( newTreeNodePolicySub );
            newTreeNodePolicy.Nodes.Add( newTreeNodePolicySub1 );
            newTreeNodePolicy.Nodes.Add( newTreeNodePolicySub2 );
            newTreeNodePolicy.Nodes.Add( newTreeNodePolicySub3 );


            PolicyBControl configBControl = new PolicyBControl();
            configBControl.Dock = DockStyle.Fill;
            configBControl.Visible = false;

            this.m_AllConfigControlInfo.Add( newTreeNodePolicy, configBControl );
            this.m_AllConfigControlInfo.Add( newTreeNodePolicySub, configBControl );

            this.Panel.Controls.Add( configBControl );

            PolicyCControl configCControl = new PolicyCControl();
            configCControl.Dock = DockStyle.Fill;
            configCControl.Visible = false;
            configCControl.SetConfigPolicy( policyInfo.Policy );

            this.m_AllConfigControlInfo.Add( newTreeNodePolicySub1, configCControl );

            this.Panel.Controls.Add( configCControl );

            PolicyDControl configDControl = new PolicyDControl();
            configDControl.Dock = DockStyle.Fill;
            configDControl.Visible = false;
            configDControl.SetConfigFiltrate( policyInfo.Filtrate );

            this.m_AllConfigControlInfo.Add( newTreeNodePolicySub2, configDControl );

            this.Panel.Controls.Add( configDControl );

            PolicyEControl configEControl = new PolicyEControl();
            configEControl.Dock = DockStyle.Fill;
            configEControl.Visible = false;
            configEControl.EventButtonSetting += new EventHandler( OnEventButtonSetting );
            m_ButtonSetting.Add( configEControl, newTreeNodePolicySub2 );
            configEControl.SetConfigExtend( policyInfo.Extend );

            this.m_AllConfigControlInfo.Add( newTreeNodePolicySub3, configEControl );

            this.Panel.Controls.Add( configEControl );

            this.TreeView.Nodes.Add( newTreeNodePolicy );

            this.TreeView.SelectedNode = newTreeNodePolicy;

            m_TreeNodePolicyInfo.Add( newTreeNodePolicy, policyInfo );
        }

        #region OnEventButtonSetting
        //<summary>
        //Triggers the EventButtonSetting event.
        //</summary>
        private void OnEventButtonSetting( object sender, EventArgs e )
        {
            TreeNode outTreeNode = null;
            if ( m_ButtonSetting.TryGetValue( sender as PolicyEControl, out outTreeNode ) == true )
            {
                this.TreeView.SelectedNode = outTreeNode;
            }
        }
        #endregion

        private void TreeView_AfterSelect( object sender, TreeViewEventArgs eventArgs )
        {
            if ( eventArgs.Node == null )
                return;

            if ( eventArgs.Node.Parent == null )
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

        private void ContextMenuStripDelete_Opening( object sender, CancelEventArgs eventArgs )
        {
            eventArgs.Cancel = true;
            m_CurrentDelTreeNode = null;

            TreeViewHitTestInfo treeViewHitTestInfo = this.TreeView.HitTest( this.TreeView.PointToClient( Cursor.Position ) );
            if ( treeViewHitTestInfo == null )
                return;

            if ( treeViewHitTestInfo.Location != TreeViewHitTestLocations.Label )
                return;

            TreeNode hitTreeNode = treeViewHitTestInfo.Node;
            if ( hitTreeNode == null )
                return;

            if ( hitTreeNode.Parent != null )
                return;

            if ( hitTreeNode == m_MainTreeNode )
                return;

            m_CurrentDelTreeNode = hitTreeNode;

            CommandBar popupCommandBar = MainForm.Instance.AxCommandBars.Add( "StartConfigFormPopup", XTPBarPosition.xtpBarPopup );
            popupCommandBar.Controls.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_CONFIG_FORM_DELETE, "删除(&X)", -1, false );
            popupCommandBar.ShowPopup( XTPTrackPopupFlags.TPM_RIGHTBUTTON, null, null );
        }

        private void TreeView_AfterLabelEdit( object sender, NodeLabelEditEventArgs e )
        {
            if ( e.Node.Parent != null )
            {
                e.CancelEdit = true;
                return;
            }

            if ( e.Node == m_MainTreeNode )
            {
                e.CancelEdit = true;
                return;
            }

            if ( e.Label == string.Empty || e.Label == null )
            {
                e.CancelEdit = true;
                return;
            }

            U50PolicyInfo outPolicyInfo = null;
            if ( m_TreeNodePolicyInfo.TryGetValue( e.Node, out outPolicyInfo ) == false )
            {
                e.CancelEdit = true;
                return;
            }

            if ( outPolicyInfo.Name == e.Label )
                return;

            if ( m_PolicyName.Contains( e.Label ) == true )
            {
                MainForm.ShowPopupMessage( e.Label, "名称已经存在!" );
                e.CancelEdit = true;
                return;
            }

            m_PolicyName.Remove( outPolicyInfo.Name );

            outPolicyInfo.Name = e.Label;

            m_PolicyName.Add( outPolicyInfo.Name );

            PolicyManager.Instance.OnRefreshStockInfo();
        }

        // 用于取消和删除
        private List<TreeNode> m_DeleteTreeNode = new List<TreeNode>();
        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent e )
        {
            switch(e.control.Id)
            {
                case ResourceId.ID_CONFIG_FORM_DELETE:

                    if ( m_CurrentDelTreeNode != null )
                    {
                        this.TreeView.Nodes.Remove( m_CurrentDelTreeNode );
                        m_DeleteTreeNode.Add( m_CurrentDelTreeNode );

                        m_CurrentDelTreeNode = null;
                    }

                    break;
                default:
                    break;
            }
        }

        private void ButtonOK_Click( object sender, EventArgs e )
        {
            foreach ( var item in m_DeleteTreeNode )
            {
                UserControl outConfigControl = null;
                if ( this.m_AllConfigControlInfo.TryGetValue( item.Nodes[0], out outConfigControl ) == true )
                {
                    if ( outConfigControl == m_CurrentConfigControl )
                        this.TreeView.SelectedNode = m_MainTreeNodeSub;

                    this.Panel.Controls.Remove( outConfigControl );
                }

                if ( this.m_AllConfigControlInfo.TryGetValue( item.Nodes[1], out outConfigControl ) == true )
                {
                    if ( outConfigControl == m_CurrentConfigControl )
                        this.TreeView.SelectedNode = m_MainTreeNodeSub;

                    this.Panel.Controls.Remove( outConfigControl );
                }

                if ( this.m_AllConfigControlInfo.TryGetValue( item.Nodes[2], out outConfigControl ) == true )
                {
                    if ( outConfigControl == m_CurrentConfigControl )
                        this.TreeView.SelectedNode = m_MainTreeNodeSub;

                    this.Panel.Controls.Remove( outConfigControl );
                }

                if ( this.m_AllConfigControlInfo.TryGetValue( item.Nodes[3], out outConfigControl ) == true )
                {
                    if ( outConfigControl == m_CurrentConfigControl )
                        this.TreeView.SelectedNode = m_MainTreeNodeSub;

                    this.Panel.Controls.Remove( outConfigControl );
                }

                this.m_AllConfigControlInfo.Remove( item.Nodes[0] );
                this.m_AllConfigControlInfo.Remove( item.Nodes[1] );
                this.m_AllConfigControlInfo.Remove( item.Nodes[2] );
                this.m_AllConfigControlInfo.Remove( item.Nodes[3] );
                this.m_AllConfigControlInfo.Remove( item );


                U50PolicyInfo outPolicyInfo = null;
                if ( this.m_TreeNodePolicyInfo.TryGetValue( item, out outPolicyInfo ) == true )
                {
                    this.m_TreeNodePolicyInfo.Remove( item );
                    PolicyManager.Instance.RemovePolicyInfoByGuid( outPolicyInfo.Guid );
                }
            }

            foreach ( var item in m_TreeNodePolicyInfo )
            {
                UserControl outConfigControl = null;
                if ( m_AllConfigControlInfo.TryGetValue( item.Key.Nodes[1], out outConfigControl ) == false )
                    continue;

                PolicyCControl configCControl = outConfigControl as PolicyCControl;
                if ( configCControl == null )
                    continue;

                item.Value.Policy = configCControl.GetConfigPolicy();

                if ( m_AllConfigControlInfo.TryGetValue( item.Key.Nodes[2], out outConfigControl ) == false )
                    continue;

                PolicyDControl configDControl = outConfigControl as PolicyDControl;
                if ( configDControl == null )
                    continue;

                item.Value.Filtrate = configDControl.GetConfigFiltrate();

                if ( m_AllConfigControlInfo.TryGetValue( item.Key.Nodes[3], out outConfigControl ) == false )
                    continue;

                PolicyEControl configEControl = outConfigControl as PolicyEControl;
                if ( configEControl == null )
                    continue;

                item.Value.Extend = configEControl.GetConfigExtend();

                if ( m_NewTreeNode.Contains( item.Key ) == true )
                    PolicyManager.Instance.AddStockInfo( item.Value );
            }

            U50GlobalSetting.SavePolicySetting( U50GlobalSetting.PolicyFilePath, PolicyManager.Instance.ToArray() );
            U50GlobalSetting.SaveGlobalRegistry();

            m_NewTreeNode.Clear();
            m_DeleteTreeNode.Clear();
        }

        private void ButtonCancel_Click( object sender, EventArgs e )
        {
            foreach ( var item in m_NewTreeNode )
                this.TreeView.Nodes.Remove( item );

            foreach ( var item in m_DeleteTreeNode )
                this.TreeView.Nodes.Add( item );

            m_NewTreeNode.Clear();
            m_DeleteTreeNode.Clear();
        }
    }
}
