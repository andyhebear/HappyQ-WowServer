using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;

namespace Demo.Stock.LHP
{
    public partial class DocumentForm4Sub1 : UserControl
    {
        private Dictionary<ListViewItem, DocumentFormSub1Form> m_AllDocumenFormInfo = new Dictionary<ListViewItem, DocumentFormSub1Form>();

        public DocumentForm4Sub1()
        {
            InitializeComponent();
        }

        public void InitPSRReport( PSRReport psrReport )
        {
            foreach ( var item in psrReport.SRInfos )
            {
                ListViewItem listViewItem = new ListViewItem( item.Number.ToString() );

                ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem();
                subListViewItem1.Text = item.StockAverage.ToString();

                ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem();
                subListViewItem2.Text = item.StockDate.ToLongDateString();

                ListViewItem.ListViewSubItem subListViewItem3 = new ListViewItem.ListViewSubItem();

                switch ( item.SRPointType )
                {
                    case PSRReport.SRPointType.DCHP:

                        subListViewItem3.Text = "DCHP";
                        break;
                    case PSRReport.SRPointType.DCLP:

                        subListViewItem3.Text = "DCLP";
                        break;
                    case PSRReport.SRPointType.GULK:

                        subListViewItem3.Text = "GULK";
                        break;
                    case PSRReport.SRPointType.GUHK:

                        subListViewItem3.Text = "GUHK";
                        break;
                    case PSRReport.SRPointType.GDLK:

                        subListViewItem3.Text = "GDLK";
                        break;
                    case PSRReport.SRPointType.GDHK:

                        subListViewItem3.Text = "GDHK";
                        break;
                    default:

                        subListViewItem3.Text = "None";
                        break;
                }

                ListViewItem.ListViewSubItem subListViewItem4 = new ListViewItem.ListViewSubItem();
                subListViewItem4.Text = item.StrongPercentum.ToString();

                ListViewItem.ListViewSubItem subListViewItem5 = new ListViewItem.ListViewSubItem();
                subListViewItem5.Text = item.RelativelyNumber.ToString();

                listViewItem.SubItems.Add( subListViewItem1 );
                listViewItem.SubItems.Add( subListViewItem2 );
                listViewItem.SubItems.Add( subListViewItem3 );
                listViewItem.SubItems.Add( subListViewItem4 );
                listViewItem.SubItems.Add( subListViewItem5 );

                this.ListView.Items.Add( listViewItem );
            }

            this.LabelOpenInfo.Text = psrReport.StockOpen.ToString();
            this.LabelCloseInfo.Text = psrReport.StockClose.ToString();
            this.LabelHighInfo.Text = psrReport.StockHigh.ToString();
            this.LabelLowInfo.Text = psrReport.StockLow.ToString();
            this.LabelVolumeInfo.Text = psrReport.StockVolume.ToString();

            switch ( psrReport.Trend )
            {
                case PSRReport.StockTrend.Up:

                    this.LabelTrendInfo.Text = "升";
                    break;
                case PSRReport.StockTrend.Down:

                    this.LabelTrendInfo.Text = "降";
                    break;
                default:

                    this.LabelTrendInfo.Text = "无";
                    break;
            }

            this.LabelPriceChangeInfo.Text = psrReport.PriceFloat.ToString();
        }

        public void InitSRReport( SRReport srReport )
        {
            int iIndex = 0;
            foreach ( var item in srReport.SRStaticData.srStaticInfoArray )
            {
                iIndex++;

                ListViewItem listViewItem = new ListViewItem( iIndex.ToString() );

                ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem();
                //subListViewItem1.Text = item.StockAverage.ToString();
                //subListViewItem1.Text = "" + item.StockAverage.ToString() + "/" + item.StockAverageHigh.ToString() + "/" + item.StockAverageLow.ToString();
                switch ( item.SRPointType )
                {
                    case SRStaticData.SRPointType.DCHP:

                        subListViewItem1.Text = item.StockAverageHigh.ToString();
                        break;
                    case SRStaticData.SRPointType.DCLP:

                        subListViewItem1.Text = item.StockAverageLow.ToString();
                        break;
                    case SRStaticData.SRPointType.GULK:

                        subListViewItem1.Text = item.StockAverageHigh.ToString();
                        break;
                    case SRStaticData.SRPointType.GUHK:

                        subListViewItem1.Text = item.StockAverageLow.ToString();
                        break;
                    case SRStaticData.SRPointType.GDLK:

                        subListViewItem1.Text = item.StockAverageHigh.ToString();
                        break;
                    case SRStaticData.SRPointType.GDHK:

                        subListViewItem1.Text = item.StockAverageLow.ToString();
                        break;
                    default:

                        subListViewItem1.Text = string.Empty;
                        break;
                }


                ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem();
                subListViewItem2.Text = item.StockData.StockDate.ToLongDateString();

                ListViewItem.ListViewSubItem subListViewItem3 = new ListViewItem.ListViewSubItem();

                switch ( item.SRPointType )
                {
                    case SRStaticData.SRPointType.DCHP:

                        subListViewItem3.Text = "DCHP";
                        break;
                    case SRStaticData.SRPointType.DCLP:

                        subListViewItem3.Text = "DCLP";
                        break;
                    case SRStaticData.SRPointType.GULK:

                        subListViewItem3.Text = "GULK";
                        break;
                    case SRStaticData.SRPointType.GUHK:

                        subListViewItem3.Text = "GUHK";
                        break;
                    case SRStaticData.SRPointType.GDLK:

                        subListViewItem3.Text = "GDLK";
                        break;
                    case SRStaticData.SRPointType.GDHK:

                        subListViewItem3.Text = "GDHK";
                        break;
                    default:

                        subListViewItem3.Text = "None";
                        break;
                }

                ListViewItem.ListViewSubItem subListViewItem4 = new ListViewItem.ListViewSubItem();
                subListViewItem4.Text = ( item.RelativelyPercent * 100 ).ToString() + "%";

                ListViewItem.ListViewSubItem subListViewItem5 = new ListViewItem.ListViewSubItem();
                subListViewItem5.Text = item.RelativelyNumber.ToString();

                listViewItem.SubItems.Add( subListViewItem1 );
                listViewItem.SubItems.Add( subListViewItem2 );
                listViewItem.SubItems.Add( subListViewItem3 );
                listViewItem.SubItems.Add( subListViewItem4 );
                listViewItem.SubItems.Add( subListViewItem5 );

                this.ListView.Items.Add( listViewItem );
            }

            this.LabelOpenInfo.Text = srReport.SRDynamicData.CurrentStock.StockOpen.ToString();
            this.LabelCloseInfo.Text = srReport.SRDynamicData.CurrentStock.StockClose.ToString();
            this.LabelHighInfo.Text = srReport.SRDynamicData.CurrentStock.StockHigh.ToString();
            this.LabelLowInfo.Text = srReport.SRDynamicData.CurrentStock.StockLow.ToString();
            this.LabelVolumeInfo.Text = srReport.SRDynamicData.CurrentStock.StockVolume.ToString();

            switch ( srReport.SRDynamicData.Trend )
            {
                case SRDynamicData.StockTrend.Up:

                    this.LabelTrendInfo.Text = "↑";
                    break;
                case SRDynamicData.StockTrend.Down:

                    this.LabelTrendInfo.Text = "↓";
                    break;
                default:

                    this.LabelTrendInfo.Text = "↔";
                    break;
            }

            this.LabelPriceChangeInfo.Text = srReport.SRDynamicData.PriceFloat.ToString() + "%";
        }

        private void ListView_SelectedIndexChanged( object sender, EventArgs e )
        {

        }

        private void ListView_DoubleClick( object sender, EventArgs e )
        {
            Point cursorPoint = this.ListView.PointToClient( Cursor.Position );
            ListViewItem listViewItem = this.ListView.GetItemAt( cursorPoint.X, cursorPoint.Y );
            if ( listViewItem == null )
                return;

            DocumentFormSub1Form outDocumentFormSub1Form = null;
            if ( m_AllDocumenFormInfo.TryGetValue( listViewItem, out outDocumentFormSub1Form ) == false )
            {
                outDocumentFormSub1Form = new DocumentFormSub1Form();

                m_AllDocumenFormInfo.Add( listViewItem, outDocumentFormSub1Form );

                outDocumentFormSub1Form.Show();
            }
            else
            {
                if ( outDocumentFormSub1Form.Visible == true )
                    outDocumentFormSub1Form.Activate();
                else
                    outDocumentFormSub1Form.Visible = true;
            }
        }
    }
}
