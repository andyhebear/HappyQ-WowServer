using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeTaskPanel;
using XtremeReportControl;
using System.IO;

namespace Demo.Stock.LHP.Main
{
    public partial class DocumentHomeForm : Form
    {
        private UserControl m_CurrentControl = null;

        private Dictionary<TaskPanelGroupItem, UserControl> m_ControlInfo = new Dictionary<TaskPanelGroupItem, UserControl>();

        private TaskPanelGroupItem m_HomeControlSubItem = null;
        private HomeControlSub m_HomeControlSub = null;

        private TaskPanelGroupItem m_HomeControlSub1Item = null;
        private HomeControlSub1 m_HomeControlSub1 = null;

        private TaskPanelGroupItem m_HomeControlSub2Item = null;
        private HomeControlSub2 m_HomeControlSub2 = null;

        private TaskPanelGroupItem m_HomeControlSub3Item = null;
        private HomeControlSub3 m_HomeControlSub3 = null;

        private TaskPanelGroupItem m_HomeControlSub4Item = null;
        private HomeControlSub4 m_HomeControlSub4 = null;

        public DocumentHomeForm()
        {
            InitializeComponent();

            //this.axReportControl.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnOffice2007;
        }

        private void DocumentHomeForm_Load( object sender, EventArgs e )
        {
            CreateTaskPanel();
        }

        void CreateTaskPanel()
        {
            {
                TaskPanelGroup Group1 = this.axTaskPanel.Groups.Add( ResourceId.TASKITEM_SYSTEM_TASKS, "系统信息" );
                Group1.IconIndex = ResourceId.ID_TASKITEM_SYSTEM_TASKS;
                Group1.Tooltip = "配置你自定义的系统信息";
                Group1.Special = true;

                m_HomeControlSubItem = Group1.Items.Add( ResourceId.ID_TASKITEM_HIDECONTENTS, "   主页   ", XTPTaskPanelItemType.xtpTaskItemTypeLink, 1 );

                m_HomeControlSub = new HomeControlSub();
                m_HomeControlSub.Dock = DockStyle.Fill;
                m_HomeControlSub.Visible = true;

                this.m_CurrentControl = m_HomeControlSub;

                this.m_ControlInfo.Add( m_HomeControlSubItem, m_HomeControlSub );
                this.Panel.Controls.Add( m_HomeControlSub );
            }

            {
                TaskPanelGroup Group = this.axTaskPanel.Groups.Add( ResourceId.TASKITEM_SYSTEM_TASKS, "SR 快捷方式" );
                Group.IconIndex = ResourceId.ID_TASKITEM_SYSTEM_TASKS;
                Group.Tooltip = "配置你自定义的SR打开的快捷方式";
                Group.Special = true;

                {
                    m_HomeControlSub1Item = Group.Items.Add( ResourceId.ID_TASKITEM_HIDECONTENTS, "SR报表（快捷）", XTPTaskPanelItemType.xtpTaskItemTypeLink, 1 );

                    m_HomeControlSub1 = new HomeControlSub1();
                    m_HomeControlSub1.Dock = DockStyle.Fill;
                    m_HomeControlSub1.Visible = false;

                    this.m_ControlInfo.Add( m_HomeControlSub1Item, m_HomeControlSub1 );
                    this.Panel.Controls.Add( m_HomeControlSub1 );
                }

                {
                    m_HomeControlSub2Item = Group.Items.Add( ResourceId.ID_TASKITEM_HIDECONTENTS, "SR策略（快捷）", XTPTaskPanelItemType.xtpTaskItemTypeLink, 1 );

                    m_HomeControlSub2 = new HomeControlSub2();
                    m_HomeControlSub2.Dock = DockStyle.Fill;
                    m_HomeControlSub2.Visible = false;

                    this.m_ControlInfo.Add( m_HomeControlSub2Item, m_HomeControlSub2 );
                    this.Panel.Controls.Add( m_HomeControlSub2 );
                }
            }

            {
                TaskPanelGroup GroupA = this.axTaskPanel.Groups.Add( ResourceId.TASKITEM_SYSTEM_TASKS, "UTMR-DTMS 快捷方式" );
                GroupA.IconIndex = ResourceId.ID_TASKITEM_SYSTEM_TASKS;
                GroupA.Tooltip = "配置你自定义的UTMR-DTMS打开的快捷方式";
                GroupA.Special = true;

                {
                    m_HomeControlSub3Item = GroupA.Items.Add( ResourceId.ID_TASKITEM_HIDECONTENTS, "UTMR-DTMS报表（快捷）", XTPTaskPanelItemType.xtpTaskItemTypeLink, 1 );

                    m_HomeControlSub3 = new HomeControlSub3();
                    m_HomeControlSub3.Dock = DockStyle.Fill;
                    m_HomeControlSub3.Visible = false;

                    this.m_ControlInfo.Add( m_HomeControlSub3Item, m_HomeControlSub3 );
                    this.Panel.Controls.Add( m_HomeControlSub3 );
                }

                {
                    m_HomeControlSub4Item = GroupA.Items.Add( ResourceId.ID_TASKITEM_HIDECONTENTS, "UTMR-DTMS策略（快捷）", XTPTaskPanelItemType.xtpTaskItemTypeLink, 1 );

                    m_HomeControlSub4 = new HomeControlSub4();
                    m_HomeControlSub4.Dock = DockStyle.Fill;
                    m_HomeControlSub4.Visible = false;

                    this.m_ControlInfo.Add( m_HomeControlSub4Item, m_HomeControlSub4 );
                    this.Panel.Controls.Add( m_HomeControlSub4 );
                }
            }

            this.axTaskPanel.Icons = (XtremeTaskPanel.ImageManagerIcons)axImageManager.Icons;
            this.axTaskPanel.Icons.LoadIcon( "Demo.Stock.Resource\\SystemTasks.ico", ResourceId.ID_TASKITEM_SYSTEM_TASKS, XtremeTaskPanel.XTPImageState.xtpImageNormal );
            this.axTaskPanel.Reposition();
        }

        private void axTaskPanel_ItemClick( object sender, AxXtremeTaskPanel._DTaskPanelEvents_ItemClickEvent eventArgs )
        {
            if ( eventArgs.item == null )
                return;

            UserControl outControl = null;
            if ( m_ControlInfo.TryGetValue( eventArgs.item, out outControl ) == false )
            {
                if ( this.m_CurrentControl != null )
                    this.m_CurrentControl.Visible = false;
            }
            else
            {
                if ( this.m_CurrentControl != null && outControl != this.m_CurrentControl )
                    this.m_CurrentControl.Visible = false;

                if ( outControl != null )
                {
                    outControl.Visible = true;
                    this.m_CurrentControl = outControl;
                }
            }
        }

    }
}
