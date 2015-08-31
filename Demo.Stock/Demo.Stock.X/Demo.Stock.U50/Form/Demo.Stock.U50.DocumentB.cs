using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeTaskPanel;

namespace Demo.Stock.X.U50
{
    public partial class DocumentControlB : UserControl
    {
        public DocumentControlB()
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

        private void DocumentControlB_Load( object sender, EventArgs e )
        {
            //this.panel1.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE ); ;

            //TaskPanelGroup Group = axTaskPanel1.Groups.Add( 0, "增强筛选" );

            ////Group.Items.Add( 0, "All or part of the file name:", XTPTaskPanelItemType.xtpTaskItemTypeText, 0 );
            //TaskPanelGroupItem GroupItem = Group.Items.Add( 0, "", XTPTaskPanelItemType.xtpTaskItemTypeControl, 0 );
            //GroupItem.Handle = this.panel1.Handle.ToInt32();

            //Group = axTaskPanel1.Groups.Add( 0, "详细报表" );

            //Group.Items.Add( 0, "All or part of the file name:", XTPTaskPanelItemType.xtpTaskItemTypeText, 0 );
            ////GroupItem = Group.Items.Add( 0, "", XTPTaskPanelItemType.xtpTaskItemTypeControl, 0 );
            ////GroupItem.Handle = this.panel1.Handle.ToInt32();
        }
    }
}
