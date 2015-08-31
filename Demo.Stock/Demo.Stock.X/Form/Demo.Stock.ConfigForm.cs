using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Demo.Stock.X.Common;
using XtremeCommandBars;

namespace Demo.Stock.X
{
    public partial class ConfigForm : Form
    {
        #region zh-CHS 私有的类 | en Private Class
        private class TreeNodePlateName
        {
            public string PlateName = string.Empty;

            public Dictionary<TreeNode, string> VarietyName = new Dictionary<TreeNode, string>();
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();
        private Dictionary<TreeNode, TreeNodePlateName> m_PlateName = new Dictionary<TreeNode, TreeNodePlateName>();

        private UserControl m_CurrentConfigControl = null;
        private TreeNode m_CurrentDeleteTreeNode = null;

        private bool m_IsInitializing = false;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        public ConfigForm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.ButtonSave.Enabled = false;

            LoadConfigFormInfo();
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
        #endregion

        private void ConfigForm_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            MainForm.Instance.AxCommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler( axCommandBars_Execute );
        }

        private void LoadConfigFormInfo()
        {
            if ( m_IsInitializing == false )
                ConfigForm_Load( this, EventArgs.Empty );

            this.TreeView.Nodes.Clear();
            this.Panel.Controls.Clear();

            PlateInfo[] plateInfos = GlobalSetting.PlateInfos;

            for ( int iIndex = 0; iIndex < plateInfos.Length; iIndex++ )
            {
                PlateInfo plateInfo = plateInfos[iIndex];

                TreeNode newTreeNodeParent = new TreeNode( plateInfo.Name );

                // 
                TreeNodePlateName treeNodePlateName = new TreeNodePlateName();
                treeNodePlateName.PlateName = plateInfo.Name;

                TreeNode newTreeNodeAll = new TreeNode( "所有的股票" );
                newTreeNodeParent.Nodes.Add( newTreeNodeAll );

                ConfigBControl configBControlAll = new ConfigBControl();
                configBControlAll.Visible = false;
                configBControlAll.Dock = DockStyle.Fill;

                this.m_AllConfigControlInfo.Add( newTreeNodeParent, configBControlAll );
                this.m_AllConfigControlInfo.Add( newTreeNodeAll, configBControlAll );

                for ( int iIndex2 = 0; iIndex2 < plateInfo.VarietyInfos.Length; iIndex2++ )
                {
                    VarietyInfo varietyInfo = plateInfo.VarietyInfos[iIndex2];

                    TreeNode newTreeNodeSub = new TreeNode( varietyInfo.Name );
                    newTreeNodeParent.Nodes.Add( newTreeNodeSub );

                    // 
                    treeNodePlateName.VarietyName.Add( newTreeNodeSub, varietyInfo.Name );

                    ConfigAControl configAControlSub = new ConfigAControl();
                    configAControlSub.Visible = false;
                    configAControlSub.Dock = DockStyle.Fill;
                    configAControlSub.ButtonSaveChanged += new EventHandler( ConfigAControl_ButtonSaveChanged );

                    this.m_AllConfigControlInfo.Add( newTreeNodeSub, configAControlSub );

                    for ( int iIndex3 = 0; iIndex3 < varietyInfo.FileInfos.Length; iIndex3++ )
                    {
                        FileInfo fileInfo = varietyInfo.FileInfos[iIndex3];

                        ListViewItem listViewItemSub = new ListViewItem( fileInfo.StockName );
                        ListViewItem.ListViewSubItem listViewSubItemSub1 = new ListViewItem.ListViewSubItem( listViewItemSub, fileInfo.StockSymbol );
                        ListViewItem.ListViewSubItem listViewSubItemSub2 = new ListViewItem.ListViewSubItem( listViewItemSub, fileInfo.FilePath );

                        listViewItemSub.SubItems.Add( listViewSubItemSub1 );
                        listViewItemSub.SubItems.Add( listViewSubItemSub2 );

                        configAControlSub.ListView.Items.Add( listViewItemSub );

                        ListViewItem listViewItemAll = new ListViewItem( fileInfo.StockName );
                        ListViewItem.ListViewSubItem listViewSubItemAll1 = new ListViewItem.ListViewSubItem( listViewItemAll, fileInfo.StockSymbol );
                        ListViewItem.ListViewSubItem listViewSubItemAll2 = new ListViewItem.ListViewSubItem( listViewItemAll, fileInfo.FilePath );

                        listViewItemAll.SubItems.Add( listViewSubItemAll1 );
                        listViewItemAll.SubItems.Add( listViewSubItemAll2 );

                        configBControlAll.ListView.Items.Add( listViewItemAll );

                    }

                    this.Panel.Controls.Add( configAControlSub );
                }

                this.TreeView.Nodes.Add( newTreeNodeParent );
                this.Panel.Controls.Add( configBControlAll );

                m_PlateName.Add( newTreeNodeParent, treeNodePlateName );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        private int m_PlateCount = 0;
        #endregion
        private void ButtonNewItem_Click( object sender, EventArgs e )
        {
            TreeNodePlateName treeNodePlateName = new TreeNodePlateName();
            do
            {
                treeNodePlateName.PlateName = string.Format( "新建的板块{0}", m_PlateCount++ );

                bool isOK = true;
                foreach ( var item in m_PlateName )
                {
                    if ( item.Value.PlateName == treeNodePlateName.PlateName )
                    {
                        isOK = false;
                        break;
                    }
                }

                if ( isOK == true )
                    break;
            } while ( true );

            TreeNode newTreeNodePlate = new TreeNode( treeNodePlateName.PlateName );
            TreeNode newTreeNodeAll = new TreeNode( "所有的股票" );

            //
            m_PlateName.Add( newTreeNodePlate, treeNodePlateName );

            newTreeNodePlate.Nodes.Add( newTreeNodeAll );

            ConfigBControl configBControl = new ConfigBControl();
            configBControl.Visible = false;
            configBControl.Dock = DockStyle.Fill;

            this.m_AllConfigControlInfo.Add( newTreeNodePlate, configBControl );
            this.m_AllConfigControlInfo.Add( newTreeNodeAll, configBControl );

            this.TreeView.Nodes.Add( newTreeNodePlate );

            this.Panel.Controls.Add( configBControl );

            this.TreeView.SelectedNode = newTreeNodeAll;

            this.ButtonSave.Enabled = true;
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        private int m_VarietyCount = 0;
        #endregion
        private void ButtonNewSubItem_Click( object sender, EventArgs e )
        {
            TreeNode treeNodeSelected = this.TreeView.SelectedNode;
            if ( treeNodeSelected == null )
                return;

            TreeNode treeNodeParent = treeNodeSelected.Parent == null ? treeNodeSelected : treeNodeSelected.Parent;

            TreeNodePlateName outPlateName = null;
            if ( m_PlateName.TryGetValue( treeNodeParent, out outPlateName ) == false )
                return;

            string strVarietyName = string.Empty;
            do
            {
                strVarietyName = string.Format( "新建的分类{0}", m_VarietyCount++ );

                bool isOK = true;
                foreach ( var item in outPlateName.VarietyName )
                {
                    if ( item.Value == strVarietyName )
                    {
                        isOK = false;
                        break;
                    }
                }

                if ( isOK == true )
                    break;
            } while ( true );

            TreeNode newTreeNodeVariety = new TreeNode( strVarietyName );

            ConfigAControl configAControl = new ConfigAControl();
            configAControl.Dock = DockStyle.Fill;
            configAControl.ButtonSaveChanged += new EventHandler( ConfigAControl_ButtonSaveChanged );

            this.m_AllConfigControlInfo.Add( newTreeNodeVariety, configAControl );

            treeNodeParent.Nodes.Add( newTreeNodeVariety );

            // 
            outPlateName.VarietyName.Add( newTreeNodeVariety, strVarietyName );

            this.Panel.Controls.Add( configAControl );

            this.TreeView.SelectedNode = newTreeNodeVariety;

            this.ButtonSave.Enabled = true;
        }

        private void ConfigAControl_ButtonSaveChanged( object sender, EventArgs e )
        {
            this.ButtonSave.Enabled = true;
        }

        private void SaveConfigFormInfo()
        {
            List<PlateInfo> plateInfoList = new List<PlateInfo>();

            for ( int iIndex = 0; iIndex < this.TreeView.Nodes.Count; iIndex++ )
            {
                TreeNode treeNodeParent = this.TreeView.Nodes[iIndex];
                if ( treeNodeParent == null )
                    continue;

                PlateInfo plateInfo = new PlateInfo();
                plateInfo.Name = treeNodeParent.Text;
                plateInfo.VarietyInfos = new VarietyInfo[0];

                plateInfoList.Add( plateInfo );

                List<VarietyInfo> varietyInfoList = new List<VarietyInfo>();

                for ( int iIndex2 = 1; iIndex2 < treeNodeParent.Nodes.Count; iIndex2++ )
                {
                    TreeNode treeNodeParentSub = treeNodeParent.Nodes[iIndex2];
                    if ( treeNodeParentSub == null )
                        continue;

                    VarietyInfo varietyInfo = new VarietyInfo();
                    varietyInfo.Name = treeNodeParentSub.Text;
                    varietyInfo.FileInfos = new FileInfo[0];

                    varietyInfoList.Add( varietyInfo );

                    UserControl outUserControl = null;
                    if ( m_AllConfigControlInfo.TryGetValue( treeNodeParentSub, out outUserControl ) == true )
                    {
                        ConfigAControl outConfigAControl = outUserControl as ConfigAControl;
                        if ( outConfigAControl != null )
                        {
                            List<FileInfo> fileInfoList = new List<FileInfo>();

                            for ( int iIndex3 = 0; iIndex3 < outConfigAControl.ListView.Items.Count; iIndex3++ )
                            {
                                ListViewItem listViewItem = outConfigAControl.ListView.Items[iIndex3];

                                FileInfo fileInfo = new FileInfo();
                                fileInfo.StockName = listViewItem.Text;
                                fileInfo.StockSymbol = listViewItem.SubItems[1].Text;
                                fileInfo.FilePath = listViewItem.SubItems[2].Text;

                                fileInfoList.Add( fileInfo );
                            }

                            varietyInfo.FileInfos = fileInfoList.ToArray();
                        }
                    }
                }

                plateInfo.VarietyInfos = varietyInfoList.ToArray();
            }

            GlobalSetting.SaveConfigSetting( GlobalSetting.ConfigFilePath, plateInfoList.ToArray() );
        }

        private void ButtonSave_Click( object sender, EventArgs e )
        {
            ProcessForm.StartProcessForm( Process_Initialize );
        }

        private void Process_Initialize( ProcessForm processForm )
        {
            SaveConfigFormInfo();
            processForm.EndProcessForm();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TreeView_AfterSelect( object sender, TreeViewEventArgs eventArgs )
        {
            if ( eventArgs.Node == null )
                return;

            if ( eventArgs.Node.Parent == null )
                eventArgs.Node.Expand();

            this.SuspendLayout();
            {
                UserControl outUserControl = null;
                if ( m_AllConfigControlInfo.TryGetValue( eventArgs.Node, out outUserControl ) == false )
                {
                    if ( this.m_CurrentConfigControl != null )
                        this.m_CurrentConfigControl.Visible = false;
                }
                else
                {
                    if ( this.m_CurrentConfigControl != null && outUserControl != this.m_CurrentConfigControl )
                        this.m_CurrentConfigControl.Visible = false;

                    if ( outUserControl != null )
                    {
                        outUserControl.Visible = true;
                        this.m_CurrentConfigControl = outUserControl;
                    }
                }
            }
            this.ResumeLayout( false );
        }

        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case ResourceId.ID_CONFIG_FORM_TREEVIEW_DELETE:

                    if ( m_CurrentDeleteTreeNode == null )
                        break;

                    if ( m_CurrentDeleteTreeNode.Parent != null )
                    {
                        TreeNodePlateName outPlateName = null;
                        if ( m_PlateName.TryGetValue( m_CurrentDeleteTreeNode.Parent, out outPlateName ) == true )
                            outPlateName.VarietyName.Remove( m_CurrentDeleteTreeNode );
                    }
                    else
                        m_PlateName.Remove( m_CurrentDeleteTreeNode );

                    this.TreeView.Nodes.Remove( m_CurrentDeleteTreeNode );

                    m_AllConfigControlInfo.Remove( m_CurrentDeleteTreeNode );
                    foreach ( TreeNode item in m_CurrentDeleteTreeNode.Nodes )
                        m_AllConfigControlInfo.Remove( item );

                    m_CurrentDeleteTreeNode = null;

                    this.ButtonSave.Enabled = true;

                    break;
                default:

                    break;
            }

        }

        private void ContextMenuStripDelete_Opening( object sender, CancelEventArgs eventArgs )
        {
            eventArgs.Cancel = true;

            TreeViewHitTestInfo treeViewHitTestInfo = this.TreeView.HitTest( this.TreeView.PointToClient( Cursor.Position ) );
            if ( treeViewHitTestInfo == null )
            {
                m_CurrentDeleteTreeNode = null;
                return;
            }

            if ( treeViewHitTestInfo.Location != TreeViewHitTestLocations.Label )
            {
                m_CurrentDeleteTreeNode = null;
                return;
            }

            if ( treeViewHitTestInfo.Node == null )
            {
                m_CurrentDeleteTreeNode = null;
                return;
            }

            if ( treeViewHitTestInfo.Node.Parent != null && treeViewHitTestInfo.Node.Text == "所有的股票" )
            {
                m_CurrentDeleteTreeNode = null;
                return;
            }

            m_CurrentDeleteTreeNode = treeViewHitTestInfo.Node;

            CommandBar popupCommandBar = MainForm.Instance.AxCommandBars.Add( "ConfigAControl", XTPBarPosition.xtpBarPopup );

            CommandBarControl commandBarControl = popupCommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_CONFIG_FORM_TREEVIEW_DELETE, "删除(&D)", -1, false );

            popupCommandBar.ShowPopup( XTPTrackPopupFlags.TPM_RIGHTBUTTON, null, null );
        }

        private void TreeView_AfterLabelEdit( object sender, NodeLabelEditEventArgs eventArgs )
        {
            if ( eventArgs.Node.Parent != null )
            {
                if ( eventArgs.Node.Text == "所有的股票" )
                {
                    eventArgs.CancelEdit = true;
                    return;
                }
                else if ( eventArgs.Label == "所有的股票" )
                {
                    eventArgs.CancelEdit = true;
                    return;
                }

                TreeNodePlateName outPlateName = null;
                if ( m_PlateName.TryGetValue( eventArgs.Node.Parent, out outPlateName ) == false )
                {
                    eventArgs.CancelEdit = true;
                    return;
                }

                foreach ( var item in outPlateName.VarietyName )
                {
                    if ( item.Value == eventArgs.Label && item.Key != eventArgs.Node )
                    {
                        MainForm.ShowPopupMessage( eventArgs.Label, "名称已经存在!" );
                        eventArgs.CancelEdit = true;
                        return;
                    }
                }

                outPlateName.VarietyName[eventArgs.Node] = eventArgs.Label;
            }
            else
            {
                foreach ( var item in m_PlateName )
                {
                    if ( item.Value.PlateName == eventArgs.Label && item.Key != eventArgs.Node )
                    {
                        MainForm.ShowPopupMessage( eventArgs.Label, "名称已经存在!" );
                        eventArgs.CancelEdit = true;
                        return;
                    }
                }

                TreeNodePlateName outPlateName = null;
                if ( m_PlateName.TryGetValue( eventArgs.Node, out outPlateName ) == false )
                {
                    eventArgs.CancelEdit = true;
                    return;
                }

                outPlateName.PlateName = eventArgs.Label;
            }

            this.ButtonSave.Enabled = true;
        }
    }
}
