using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.X.U50.Common;

namespace Demo.Stock.X.U50
{
    public partial class DocumentReport : UserControl
    {
        public DocumentReport()
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


        private U50ReportInfo m_ReportInfo = null;
        public void Init( U50ReportInfo ReportInfo )
        {
            if ( ReportInfo == null )
                return;
            else
                m_ReportInfo = ReportInfo;
            MessageBox.Show( m_ReportInfo.ReportArray.Length.ToString() );

            foreach ( var item in m_ReportInfo.ReportArray )
            {
                ListViewItem listViewItem = new ListViewItem( item.Symbol );
                //ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem();
                //subListViewItem1.Text = item.Symbol;

                ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem();
                subListViewItem2.Text = item.ReportSubInfo.S_Date.ToString();

                ListViewItem.ListViewSubItem subListViewItem3 = new ListViewItem.ListViewSubItem();
                subListViewItem3.Text = item.ReportSubInfo.KLineNumber.ToString();

                ListViewItem.ListViewSubItem subListViewItem4 = new ListViewItem.ListViewSubItem();
                subListViewItem4.Text = item.ReportSubInfo.Q_U50.ToString();

                ListViewItem.ListViewSubItem subListViewItem5 = new ListViewItem.ListViewSubItem();
                subListViewItem5.Text = item.ReportSubInfo.Vsc.ToString();

                ListViewItem.ListViewSubItem subListViewItem6 = new ListViewItem.ListViewSubItem();
                subListViewItem6.Text = item.ReportSubInfo.Close.ToString();

                listViewItem.SubItems.Add( subListViewItem2 );
                listViewItem.SubItems.Add( subListViewItem3 );
                listViewItem.SubItems.Add( subListViewItem4 );
                listViewItem.SubItems.Add( subListViewItem5 );
                listViewItem.SubItems.Add( subListViewItem6 );

                this.listView1.Items.Add( listViewItem );
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if ( MainForm.Instance.U50Form.KLineViewForm.Visible == true )
                MainForm.Instance.U50Form.KLineViewForm.Activate();
            else
                MainForm.Instance.U50Form.KLineViewForm.Show();

            MainForm.Instance.U50Form.KLineViewForm.ShowNewReport();
        }
    }
}
