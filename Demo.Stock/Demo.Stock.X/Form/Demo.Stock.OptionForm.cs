using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Demo.Stock.X.Common;

namespace Demo.Stock.X
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OptionForm : Form
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        private UserControl m_CurrentOptionControl = null;

        private Dictionary<TreeNode, UserControl> m_AllOptionControlInfo = new Dictionary<TreeNode, UserControl>();

        private OptionAControl m_SettingControl = null;
        private OptionDControl m_SearchControl = null;

        private TreeNode m_TreeNodeSetting = null;
        private TreeNode m_TreeNodeSettingSub = null;
        private TreeNode m_TreeNodeSearch = null;
        private TreeNode m_TreeNodeSearchSub = null;

        private ConfigForm m_ConfigForm = null;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        public OptionForm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            m_TreeNodeSetting = new TreeNode( "设置" );
            m_TreeNodeSettingSub = new TreeNode( "常规" );
            m_TreeNodeSearch = new TreeNode( "搜索结果" );
            m_TreeNodeSearchSub = new TreeNode( "常规" );

            InitOptionFormInfo();

            m_ConfigForm = new ConfigForm();
            m_ConfigForm.Initialize();
        }

        private void InitOptionFormInfo()
        {
            this.SuspendLayout();
            {
                m_TreeNodeSetting.Nodes.Add( m_TreeNodeSettingSub );

                m_SettingControl = new OptionAControl();
                m_SettingControl.Dock = DockStyle.Fill;
                m_SettingControl.Visible = false;

                this.m_AllOptionControlInfo.Add( m_TreeNodeSetting, m_SettingControl );
                this.m_AllOptionControlInfo.Add( m_TreeNodeSettingSub, m_SettingControl );

                this.Panel.Controls.Add( m_SettingControl );

                m_SettingControl.CheckBoxPopupInfo.Checked = GlobalSetting.IsPopStartupInfo;
                m_SettingControl.NumericUpDownKLine.Value = (decimal)GlobalSetting.ShowKLineLength;
                m_SettingControl.TrackBarKLine.Value = (int)GlobalSetting.ShowKLineLength;
                m_SettingControl.SetConfigFile += new EventHandlerNone( SettingControl_SetConfigFile );

                this.TreeView.Nodes.Add( m_TreeNodeSetting );
                //-------------------------------------

                PlateInfo[] plateInfos = GlobalSetting.PlateInfos;
                for ( int iIndex = 0; iIndex < plateInfos.Length; iIndex++ )
                {
                    PlateInfo plateInfo = plateInfos[iIndex];

                    TreeNode newTreeNodePlate = new TreeNode( plateInfo.Name );
                    TreeNode newTreeNodePlateSub = new TreeNode( "常规" );
                    TreeNode newTreeNodePlateSub2 = new TreeNode( "所有股票" );

                    newTreeNodePlate.Nodes.Add( newTreeNodePlateSub );
                    newTreeNodePlate.Nodes.Add( newTreeNodePlateSub2 );

                    OptionBControl optionBControl = new OptionBControl { Dock = DockStyle.Fill, Visible = false };

                    this.m_AllOptionControlInfo.Add( newTreeNodePlate, optionBControl );
                    this.m_AllOptionControlInfo.Add( newTreeNodePlateSub, optionBControl );

                    this.Panel.Controls.Add( optionBControl );

                    OptionFControl optionFControl = new OptionFControl { Dock = DockStyle.Fill, Visible = false };

                    this.m_AllOptionControlInfo.Add( newTreeNodePlateSub2, optionFControl );

                    this.Panel.Controls.Add( optionFControl );

                    // 
                    for ( int iIndex2 = 0; iIndex2 < plateInfo.VarietyInfos.Length; iIndex2++ )
                    {
                        VarietyInfo varietyInfo = plateInfo.VarietyInfos[iIndex2];
                        
                        TreeNode newTreeNodePlateSub3 = new TreeNode( varietyInfo.Name );
                        newTreeNodePlate.Nodes.Add( newTreeNodePlateSub3 );

                        OptionCControl optionCControlSub3 = new OptionCControl { Dock = DockStyle.Fill, Visible = false };

                        this.m_AllOptionControlInfo.Add( newTreeNodePlateSub3, optionCControlSub3 );

                        this.Panel.Controls.Add( optionCControlSub3 );

                        for ( int iIndex3 = 0; iIndex3 < varietyInfo.FileInfos.Length; iIndex3++ )
                        {
                            Demo.Stock.X.Common.FileInfo fileInfo = varietyInfo.FileInfos[iIndex3];

                            StockManager stockManager  = GlobalStockManager.GetStockManagerByPlateAndVariety( plateInfo.Name, varietyInfo.Name );
                            StockInfo stockInfo  = stockManager.GetStockDataByStockCode( fileInfo.StockName + "[" + fileInfo.StockSymbol + "]" );

                            ListViewItem listViewItem = new ListViewItem( stockInfo.StockName, 0 );
                            listViewItem.SubItems.Add( stockInfo.StockSymbol );
                            listViewItem.SubItems.Add( stockInfo.Periodicity.ToString() );
                            listViewItem.SubItems.Add( stockInfo.FirstDate.ToShortDateString() );
                            listViewItem.SubItems.Add( stockInfo.LastDate.ToShortDateString() );
                            listViewItem.SubItems.Add( stockInfo.FirstTime.ToLongTimeString() );
                            listViewItem.SubItems.Add( stockInfo.LastTime.ToLongTimeString() );
                            listViewItem.SubItems.Add( stockInfo.StartTime.ToShortTimeString() );
                            listViewItem.SubItems.Add( stockInfo.EndTime.ToShortTimeString() );
                            listViewItem.SubItems.Add( stockInfo.CollectionDate.ToShortDateString() );

                            optionCControlSub3.ListViewStockInfo.Items.Add( listViewItem );
                        }
                    }

                    this.TreeView.Nodes.Add( newTreeNodePlate );
                }
                //----------------------------------------------

                // 搜索结果
                m_TreeNodeSearch.Nodes.Add( m_TreeNodeSearchSub );

                m_SearchControl = new OptionDControl();
                m_SearchControl.Dock = DockStyle.Fill;
                m_SearchControl.Visible = false;

                this.m_AllOptionControlInfo.Add( m_TreeNodeSearch, m_SearchControl );
                this.m_AllOptionControlInfo.Add( m_TreeNodeSearchSub, m_SearchControl );

                this.Panel.Controls.Add( m_SearchControl );

                this.TreeView.Nodes.Add( m_TreeNodeSearch );
                //----------------------------------------------

                this.TreeView.SelectedNode = m_TreeNodeSettingSub;
            }
            this.ResumeLayout( false );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
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

        private void ReloadOptionFormInfo()
        {
            this.SuspendLayout();
            {
                m_AllOptionControlInfo.Clear();
                m_CurrentOptionControl = null;

                List<Control> controlList = new List<Control>();
                foreach ( Control control in this.Panel.Controls )
                {
                    if ( control != m_SettingControl && control != m_SearchControl )
                        controlList.Add( control );
                }

                foreach ( Control control in controlList )
                    this.Panel.Controls.Remove( control );

                this.TreeView.Nodes.Clear();

                this.m_AllOptionControlInfo.Add( m_TreeNodeSetting, m_SettingControl );
                this.m_AllOptionControlInfo.Add( m_TreeNodeSettingSub, m_SettingControl );

                this.TreeView.Nodes.Add( m_TreeNodeSetting );

                PlateInfo[] plateInfos = GlobalSetting.PlateInfos;
                for ( int iIndex = 0; iIndex < plateInfos.Length; iIndex++ )
                {
                    PlateInfo plateInfo = plateInfos[iIndex];

                    TreeNode newTreeNodePlate = new TreeNode( plateInfo.Name );
                    TreeNode newTreeNodePlateSub = new TreeNode( "常规" );
                    TreeNode newTreeNodePlateSub2 = new TreeNode( "所有股票" );

                    newTreeNodePlate.Nodes.Add( newTreeNodePlateSub );
                    newTreeNodePlate.Nodes.Add( newTreeNodePlateSub2 );

                    OptionBControl optionBControl = new OptionBControl { Dock = DockStyle.Fill, Visible = false };

                    this.m_AllOptionControlInfo.Add( newTreeNodePlate, optionBControl );
                    this.m_AllOptionControlInfo.Add( newTreeNodePlateSub, optionBControl );

                    this.Panel.Controls.Add( optionBControl );

                    OptionFControl optionFControl = new OptionFControl { Dock = DockStyle.Fill, Visible = false };

                    this.m_AllOptionControlInfo.Add( newTreeNodePlateSub2, optionFControl );

                    this.Panel.Controls.Add( optionFControl );

                    for ( int iIndex2 = 0; iIndex2 < plateInfo.VarietyInfos.Length; iIndex2++ )
                    {
                        VarietyInfo varietyInfo = plateInfo.VarietyInfos[iIndex2];

                        TreeNode newTreeNodePlateSub3 = new TreeNode( varietyInfo.Name );
                        newTreeNodePlate.Nodes.Add( newTreeNodePlateSub3 );

                        OptionCControl optionCControlSub3 = new OptionCControl { Dock = DockStyle.Fill, Visible = false };

                        this.m_AllOptionControlInfo.Add( newTreeNodePlateSub3, optionCControlSub3 );

                        this.Panel.Controls.Add( optionCControlSub3 );

                        for ( int iIndex3 = 0; iIndex3 < varietyInfo.FileInfos.Length; iIndex3++ )
                        {
                            Demo.Stock.X.Common.FileInfo fileInfo = varietyInfo.FileInfos[iIndex3];

                            StockManager stockManager = GlobalStockManager.GetStockManagerByPlateAndVariety( plateInfo.Name, varietyInfo.Name );
                            StockInfo stockInfo = stockManager.GetStockDataByStockCode( GlobalSetting.GetStockCode( fileInfo.StockName, fileInfo.StockSymbol ) );
                            if ( stockInfo == null )
                                continue;

                            ListViewItem listViewItem = new ListViewItem( stockInfo.StockName, 0 );
                            listViewItem.SubItems.Add( stockInfo.StockSymbol );
                            listViewItem.SubItems.Add( stockInfo.Periodicity.ToString() );
                            listViewItem.SubItems.Add( stockInfo.FirstDate.ToShortDateString() );
                            listViewItem.SubItems.Add( stockInfo.LastDate.ToShortDateString() );
                            listViewItem.SubItems.Add( stockInfo.FirstTime.ToLongTimeString() );
                            listViewItem.SubItems.Add( stockInfo.LastTime.ToLongTimeString() );
                            listViewItem.SubItems.Add( stockInfo.StartTime.ToShortTimeString() );
                            listViewItem.SubItems.Add( stockInfo.EndTime.ToShortTimeString() );
                            listViewItem.SubItems.Add( stockInfo.CollectionDate.ToShortDateString() );

                            optionCControlSub3.ListViewStockInfo.Items.Add( listViewItem );
                        }
                    }

                    this.TreeView.Nodes.Add( newTreeNodePlate );
                }

                // 搜索结果
                this.m_AllOptionControlInfo.Add( m_TreeNodeSearch, m_SearchControl );
                this.m_AllOptionControlInfo.Add( m_TreeNodeSearchSub, m_SearchControl );

                m_TreeNodeSearch.Nodes.Clear();
                m_TreeNodeSearch.Nodes.Add( m_TreeNodeSearchSub );

                this.TreeView.Nodes.Add( m_TreeNodeSearch );

                this.TreeView.SelectedNode = m_TreeNodeSetting;
            }
            this.ResumeLayout( false );
        }

        private void SettingControl_SetConfigFile()
        {
            if ( GlobalSetting.IsLoadGlobalSetting == false )
            {
                MainForm.ShowPopupMessage( "正在初始化数据", "请稍等片刻。。。" );
                ProcessForm.StartProcessForm( Process_InitializeLoad );
            }

            if ( m_ConfigForm.ShowDialog() == DialogResult.OK )
            {
                if ( GlobalSetting.LoadGlobalSetting() == false )
                {
                    MainForm.ShowPopupMessage( "读取配置文件失败！", "可能文件不存在或格式错误。。。" );
                    return;
                }

                ProcessForm.StartProcessForm( Process_Initialize );
            }
        }

        private void Process_InitializeLoad( ProcessForm processForm )
        {
            if ( GlobalSetting.LoadGlobalSetting() == true )
            {
                ReloadOptionFormInfo();
                m_ConfigForm.Initialize();
            }
            else
                MainForm.ShowPopupMessage( "读取配置文件失败！", "可能文件不存在或格式错误。。。" );

            processForm.EndProcessForm();
        }

        private void Process_Initialize( ProcessForm processForm )
        {
            if ( GlobalSetting.LoadGlobalSetting() == true )
                ReloadOptionFormInfo();
            else
                MainForm.ShowPopupMessage( "读取配置文件失败！", "可能文件不存在或格式错误。。。" );

            processForm.EndProcessForm();
        }

        private void TreeView_AfterSelect( object sender, TreeViewEventArgs eventArgs )
        {
            if ( eventArgs.Node == null )
                return;

            if ( eventArgs.Node.Parent == null )
            {
                this.TreeView.SelectedNode = eventArgs.Node.Nodes[0];
                return;
            }

            this.SuspendLayout();
            {
                UserControl outOptionControl = null;
                if ( m_AllOptionControlInfo.TryGetValue( eventArgs.Node, out outOptionControl ) == false )
                {
                    if ( this.m_CurrentOptionControl != null )
                        this.m_CurrentOptionControl.Visible = false;
                }
                else
                {
                    if ( this.m_CurrentOptionControl != null && outOptionControl != this.m_CurrentOptionControl )
                        this.m_CurrentOptionControl.Visible = false;

                    if ( outOptionControl != null )
                    {
                        outOptionControl.Visible = true;
                        this.m_CurrentOptionControl = outOptionControl;
                    }
                }
            }
            this.ResumeLayout( false );
        }

        private void TextBoxStockInfo_Enter( object sender, EventArgs e )
        {
            if ( this.TextBoxStockInfo.Text == "股票名称或代码" )
            {
                this.TextBoxStockInfo.ForeColor = SystemColors.WindowText;
                this.TextBoxStockInfo.Text = string.Empty;
            }
        }

        private void TextBoxStockInfo_Leave( object sender, EventArgs e )
        {
            if ( this.TextBoxStockInfo.Text == string.Empty )
            {
                this.TextBoxStockInfo.ForeColor = SystemColors.GrayText;
                this.TextBoxStockInfo.Text = "股票名称或代码";
            }
        }

        private int iSearchIndex = 0;
        private void ButtonSearch_Click( object sender, EventArgs e )
        {
            if ( this.TextBoxStockInfo.Text == string.Empty || this.TextBoxStockInfo.Text == "股票名称或代码" )
            {
                MainForm.ShowPopupMessage( "请输入一个股票名称或代码" );
                return;
            }

            iSearchIndex++;
            TreeNode newTreeNodeSearchSub = new TreeNode( string.Format( "结果{0}", iSearchIndex ) );
            m_TreeNodeSearch.Nodes.Add( newTreeNodeSearchSub );

            OptionEControl optionEControl = new OptionEControl();
            optionEControl.Dock = DockStyle.Fill;
            optionEControl.Visible = false;

            this.m_AllOptionControlInfo.Add( newTreeNodeSearchSub, optionEControl );

            this.Panel.Controls.Add( optionEControl );

            this.TreeView.SelectedNode = newTreeNodeSearchSub;
        }

        private void ButtonOK_Click( object sender, EventArgs eventArgs )
        {
            GlobalSetting.IsPopStartupInfo = m_SettingControl.CheckBoxPopupInfo.Checked;
            GlobalSetting.ShowKLineLength = (uint)m_SettingControl.NumericUpDownKLine.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();

            GlobalSetting.SaveGlobalRegistry();
        }
    }
}