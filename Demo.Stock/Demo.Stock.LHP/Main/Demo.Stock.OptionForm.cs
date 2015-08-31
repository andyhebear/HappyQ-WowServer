using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;
using Demo.Stock.LHP.Main.Common;

namespace Demo.Stock.LHP.Main
{
    public partial class OptionForm : Form
    {
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();

        private UserControl m_CurrentConfigControl = null;
    
        private TreeNode m_MainTreeNodeSub = null;
        private TreeNode m_MainTreeNodeSub1 = null;
        private TreeNode m_MainTreeNodeSub2 = null;

        OptionControlSub1 m_OptionControlSub1 = null;
        OptionControlSub2 m_OptionControlSub2 = null;
        OptionControlSub3 m_OptionControlSub3 = null;

        public OptionForm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            m_MainTreeNodeSub = new TreeNode( "常规设置" );
            m_MainTreeNodeSub1 = new TreeNode( "全局股票清单" );
            m_MainTreeNodeSub2 = new TreeNode( "扫描触发器" );

            // 设置
            this.TreeView.Nodes.Add( m_MainTreeNodeSub );
            this.TreeView.Nodes.Add( m_MainTreeNodeSub1 );
            this.TreeView.Nodes.Add( m_MainTreeNodeSub2 );

            {
                m_OptionControlSub1 = new OptionControlSub1();
                m_OptionControlSub1.Dock = DockStyle.Fill;
                m_OptionControlSub1.Visible = false;

                this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub, m_OptionControlSub1 );
                this.Panel.Controls.Add( m_OptionControlSub1 );
            }

            {
                m_OptionControlSub2 = new OptionControlSub2();
                m_OptionControlSub2.Dock = DockStyle.Fill;
                m_OptionControlSub2.Visible = false;
                m_OptionControlSub2.ButtonSaveChanged += new EventHandler( OptionControlSub2_ButtonSaveChanged );

                this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub1, m_OptionControlSub2 );
                this.Panel.Controls.Add( m_OptionControlSub2 );
            }

            {
                m_OptionControlSub3 = new OptionControlSub3();
                m_OptionControlSub3.Dock = DockStyle.Fill;
                m_OptionControlSub3.Visible = false;
                m_OptionControlSub3.ButtonSaveChanged += new EventHandler( OptionControlSub2_ButtonSaveChanged );

                this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub2, m_OptionControlSub3 );
                this.Panel.Controls.Add( m_OptionControlSub3 );
            }

            OptionFormInfo optionFormInfo = OptionFormInfo.LoadOptionFormInfo( OptionFormInfo.ConfigFilePath );
            m_OptionControlSub1.SetGeneralInfo( optionFormInfo.m_GeneralInfo );
            m_OptionControlSub2.SetStockFileInfos( optionFormInfo.m_StockFileInfos );
            m_OptionControlSub3.SetTriggerInfos( optionFormInfo.m_TriggerInfos );

            this.TreeView.SelectedNode = m_MainTreeNodeSub;
        }

        private void OptionControlSub2_ButtonSaveChanged( object sender, EventArgs eventArgs )
        {
            if ( this.ButtonOK.Enabled == false )
                this.ButtonOK.Enabled = true;
        }

        private bool m_IsInitializing = false;
        private void OptionForm_Load( object sender, EventArgs eventArgs )
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
            m_OptionControlSub2.ButtonOK();
            m_OptionControlSub3.ButtonOK();

            OptionFormInfo optionFormInfo = new OptionFormInfo();
            optionFormInfo.m_GeneralInfo = m_OptionControlSub1.GetGeneralInfo();
            optionFormInfo.m_StockFileInfos = m_OptionControlSub2.GetStockFileInfos();
            optionFormInfo.m_TriggerInfos = m_OptionControlSub3.GetTriggerInfos();

            OptionFormInfo.SaveOptionFormInfo( OptionFormInfo.ConfigFilePath, optionFormInfo );

            this.Close();
        }

        private void ButtonCancel_Click( object sender, EventArgs e )
        {
            m_OptionControlSub2.ButtonCancel();
            m_OptionControlSub3.ButtonCancel();

            this.Close();
        }

        public OptionFormInfo GetOptionFormInfo()
        {
            OptionFormInfo optionFormInfo = new OptionFormInfo();

            optionFormInfo.m_StockFileInfos = m_OptionControlSub2.GetStockFileInfos();
            optionFormInfo.m_TriggerInfos = m_OptionControlSub3.GetTriggerInfos();

            return optionFormInfo;
        }

        public void SetOptionFormInfo( OptionFormInfo optionFormInfo )
        {
            m_OptionControlSub2.SetStockFileInfos( optionFormInfo.m_StockFileInfos );
            m_OptionControlSub3.SetTriggerInfos( optionFormInfo.m_TriggerInfos );
        }

        private void OptionForm_Shown( object sender, EventArgs e )
        {
            m_OptionControlSub2.Initialize();
        }

        private bool m_isClose = false;
        internal bool IsClose
        {
            get { return m_isClose; }
            set { m_isClose = value; }
        }

        private void OptionForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( m_isClose == false )
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

    }
}
