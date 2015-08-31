using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeDockingPane;
using XtremeCommandBars;
using XtremeShortcutBar;
using XtremeTaskPanel;

namespace Demo.Stock.X.U50
{
    public partial class DocumentForm : Form
    {
        public DocumentForm()
        {
            InitializeComponent();
        }

        private void DocumentForm_Load( object sender, EventArgs e )
        {
            //this.axTabControl.PaintManager.OneNoteColors = true;
            //this.axTabControl.PaintManager.ShowIcons = true;

            this.SuspendLayout();

            CreateTaskPanel();

            CreateTabControl();

            this.ResumeLayout( false );
        }

        private void CreateTabControl()
        {
            //DocumentU50Graph userU50Graph = new DocumentU50Graph();
            //userU50Graph.Parent = this.axTabControlStock;

            //this.axTabControlStock.InsertItem( 0, "股票符号01", userU50Graph.Handle.ToInt32(), 0 );


            //userU50Graph = new DocumentU50Graph();
            //userU50Graph.Parent = this.axTabControlStock;

            //this.axTabControlStock.InsertItem( 1, "股票符号02", userU50Graph.Handle.ToInt32(), 0 );


            //userU50Graph = new DocumentU50Graph();
            //userU50Graph.Parent = this.axTabControlStock;

            //this.axTabControlStock.InsertItem( 2, "股票符号03", userU50Graph.Handle.ToInt32(), 0 );

            DocumentReport userU50Graph = new DocumentReport();
            userU50Graph.Parent = this.axTabControlStock;

            this.axTabControlStock.InsertItem( 0, "报表01", userU50Graph.Handle.ToInt32(), 0 );


            userU50Graph = new DocumentReport();
            userU50Graph.Parent = this.axTabControlStock;

            this.axTabControlStock.InsertItem( 1, "报表02", userU50Graph.Handle.ToInt32(), 0 );


            userU50Graph = new DocumentReport();
            userU50Graph.Parent = this.axTabControlStock;

            this.axTabControlStock.InsertItem( 2, "报表03", userU50Graph.Handle.ToInt32(), 0 );

        }

        private void CreateTaskPanel()
        {
            TaskPanelGroup Group = axTaskPanel1.Groups.Add( 0, "详细报表" );

            //Group.Items.Add( 0, "All or part of the file name:", XTPTaskPanelItemType.xtpTaskItemTypeText, 0 );
            TaskPanelGroupItem GroupItem = Group.Items.Add( 0, "", XTPTaskPanelItemType.xtpTaskItemTypeControl, 0 );
            GroupItem.Handle = this.treeView1.Handle.ToInt32();
            GroupItem.SetMargins( 0, 0, 0, 0 );

            Group = axTaskPanel1.Groups.Add( 0, "增强筛选" );

            //Group.Items.Add( 0, "All or part of the file name:", XTPTaskPanelItemType.xtpTaskItemTypeText, 0 );
            GroupItem = Group.Items.Add( 0, "", XTPTaskPanelItemType.xtpTaskItemTypeControl, 0 );
            GroupItem.Handle = this.panel1.Handle.ToInt32();

            Group.Expanded = false;
        }

        private DocumentFormSub1 m_DocumentFormSub1 = new DocumentFormSub1();
        private void axPushButton1_ClickEvent( object sender, EventArgs e )
        {
            m_DocumentFormSub1.ShowDialog();
        }

        public U50Form.ControlCommandInfo m_OpenCommandInfo = null;
        public U50Form.ControlCommandInfo m_CloseCommandInfo = null;
        private void DocumentForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( m_OpenCommandInfo != null )
                m_OpenCommandInfo.Form = null;

            if ( m_CloseCommandInfo != null )
            {
                m_CloseCommandInfo.IsShowOK = false;
                m_CloseCommandInfo.Form = null;
            }
        }
    }
}
