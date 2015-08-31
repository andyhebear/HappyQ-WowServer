using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;

namespace Demo.Stock.LHP
{
    public partial class DocumentForm6 : Form
    {
        //private Dictionary<ListViewItem, UserControl> m_AllDocumenInfo = new Dictionary<ListViewItem, UserControl>();

        //private UserControl m_CurrentDocumen = null;

        //DocumentForm3Sub1 m_DocumentFormSub3 = null;

        public DocumentForm6()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            //m_DocumentFormSub3 = new DocumentForm3Sub1();
            //m_DocumentFormSub3.Dock = DockStyle.Fill;
            //this.SplitContainer.Panel2.Controls.Add( m_DocumentFormSub3 );

            //m_CurrentDocumen = m_DocumentFormSub3;

            //this.axTabControl.InsertItem( 0, "静态SR初级报表", m_DocumentFormSub1.Handle.ToInt32(), 0 );
        }

        private void DocumentForm_Load( object sender, EventArgs e )
        {

        }

        public void InitPSRReport( PSRReport[] psrReportArray )
        {
            //foreach ( var item in psrReportArray )
            //{
            //    ListViewItem listViewItem = new ListViewItem( item.StockSymbol );

            //    ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem();
            //    subListViewItem1.Text = item.StockClose.ToString();

            //    ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem();
            //    subListViewItem2.Text = item.StockVolume.ToString();

            //    listViewItem.SubItems.Add( subListViewItem1 );
            //    listViewItem.SubItems.Add( subListViewItem2 );

            //    this.ListView.Items.Add( listViewItem );

            //    DocumentFormSub1 documentFormSub1 = new DocumentFormSub1();
            //    documentFormSub1.InitPSRReport( item );
            //    documentFormSub1.Visible = false;
            //    documentFormSub1.Dock = DockStyle.Fill;
            //    this.SplitContainer.Panel2.Controls.Add( documentFormSub1 );

            //    m_AllDocumenInfo.Add( listViewItem, documentFormSub1 );
            //}
        }


        private SRReport[] m_CurrentSRReportArray = null;
        public void InitSRReport( SRReport[] srReportArray )
        {
            if ( m_CurrentSRReportArray == srReportArray )
                return;
            else
                m_CurrentSRReportArray = srReportArray;

            this.ListView.Items.Clear();
            //if ( this.m_CurrentDocumen != null && m_DocumentFormSub3 != this.m_CurrentDocumen )
            //    this.m_CurrentDocumen.Visible = false;

            //m_DocumentFormSub3.Visible = true;
            //this.m_CurrentDocumen = m_DocumentFormSub3;

            //foreach ( var item in srReportArray )
            //{
            //    ListViewItem listViewItem = new ListViewItem( item.SRDynamicData.StockSymbol );

            //    ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem();
            //    subListViewItem1.Text = item.SRDynamicData.CurrentStock.StockClose.ToString();

            //    ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem();
            //    subListViewItem2.Text = item.SRDynamicData.CurrentStock.StockVolume.ToString();

            //    ListViewItem.ListViewSubItem subListViewItem3 = new ListViewItem.ListViewSubItem();
            //    subListViewItem3.Text = item.SRDynamicData.StockAPF.ToString();

            //    ListViewItem.ListViewSubItem subListViewItem4 = new ListViewItem.ListViewSubItem();
            //    subListViewItem4.Text = item.SRDynamicData.StockARPF.ToString() + "%";

            //    listViewItem.SubItems.Add( subListViewItem1 );
            //    listViewItem.SubItems.Add( subListViewItem2 );
            //    listViewItem.SubItems.Add( subListViewItem3 );
            //    listViewItem.SubItems.Add( subListViewItem4 );

            //    this.ListView.Items.Add( listViewItem );

            //    //DocumentForm3Sub1 documentFormSub3 = new DocumentForm3Sub1();
            //    //documentFormSub3.Visible = false;
            //    //documentFormSub3.Dock = DockStyle.Fill;
            //    //documentFormSub3.InitSRReport( item );
            //    //this.SplitContainer.Panel2.Controls.Add( documentFormSub2 );

            //    //m_AllDocumenInfo.Add( listViewItem, documentFormSub3 );
            //}
        }
    }
}
