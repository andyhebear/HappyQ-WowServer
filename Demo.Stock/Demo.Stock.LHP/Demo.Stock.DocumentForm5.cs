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
    public partial class DocumentForm5 : Form
    {
        private Dictionary<ListViewItem, UserControl> m_AllDocumenInfo = new Dictionary<ListViewItem, UserControl>();

        private UserControl m_CurrentDocumen = null;

        DocumentForm5Sub1 m_DocumentFormSub5 = null;

        public DocumentForm5()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            m_DocumentFormSub5 = new DocumentForm5Sub1();
            m_DocumentFormSub5.Dock = DockStyle.Fill;
            this.SplitContainer.Panel2.Controls.Add( m_DocumentFormSub5 );

            m_CurrentDocumen = m_DocumentFormSub5;

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
            if ( this.m_CurrentDocumen != null && m_DocumentFormSub5 != this.m_CurrentDocumen )
                this.m_CurrentDocumen.Visible = false;

            m_DocumentFormSub5.Visible = true;
            this.m_CurrentDocumen = m_DocumentFormSub5;

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

            //    DocumentForm2Sub1 documentFormSub2 = new DocumentForm2Sub1();
            //    documentFormSub2.Visible = false;
            //    documentFormSub2.Dock = DockStyle.Fill;
            //    documentFormSub2.InitSRReport( item );
            //    this.SplitContainer.Panel2.Controls.Add( documentFormSub2 );

            //    m_AllDocumenInfo.Add( listViewItem, documentFormSub2 );
            //}
        }

        private void ListView_SelectedIndexChanged( object sender, EventArgs e )
        {
            Point cursorPoint = this.ListView.PointToClient( Cursor.Position );
            ListViewItem listViewItem = this.ListView.GetItemAt( cursorPoint.X, cursorPoint.Y );
            if ( listViewItem == null )
                return;

            UserControl outDocumentFormSub1 = null;
            if ( m_AllDocumenInfo.TryGetValue( listViewItem, out outDocumentFormSub1 ) == false )
            {
                if ( this.m_CurrentDocumen != null )
                    this.m_CurrentDocumen.Visible = false;
            }
            else
            {
                if ( this.m_CurrentDocumen != null && outDocumentFormSub1 != this.m_CurrentDocumen )
                    this.m_CurrentDocumen.Visible = false;

                if ( outDocumentFormSub1 != null )
                {
                    outDocumentFormSub1.Visible = true;
                    this.m_CurrentDocumen = outDocumentFormSub1;
                }
            }
        }
    }
}
