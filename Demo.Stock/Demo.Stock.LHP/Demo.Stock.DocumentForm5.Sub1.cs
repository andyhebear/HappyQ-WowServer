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
    public partial class DocumentForm5Sub1 : UserControl
    {
        public DocumentForm5Sub1()
        {
            InitializeComponent();
        }

        public void InitSRReport( SRReport srReport )
        {
            int iIndex = 0;
            foreach ( var item in srReport.SRDynamicData.srTrendDataArray )
            {
                iIndex++;
                ListViewItem listViewItem = new ListViewItem( iIndex.ToString() );

                ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem();
                subListViewItem1.Text = item.CSR.ToString();

                ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem();
                subListViewItem2.Text = item.SRTrendInfo.SRStaticInfoB.StockData.StockDate.ToShortDateString();

                ListViewItem.ListViewSubItem subListViewItem3 = new ListViewItem.ListViewSubItem();
                subListViewItem3.Text = item.SRTrendInfo.SRStaticInfoA.StockData.StockDate.ToShortDateString();

                ListViewItem.ListViewSubItem subListViewItem4 = new ListViewItem.ListViewSubItem();

                switch ( item.SRTrendInfo.TrendInfo )
                {
                    case SRStaticData.TrendType.Down:

                        subListViewItem4.Text = "↘";
                        break;
                    case SRStaticData.TrendType.Up:

                        subListViewItem4.Text = "↗";
                        break;
                    default:

                        subListViewItem4.Text = "None";
                        break;
                }

                ListViewItem.ListViewSubItem subListViewItem5 = new ListViewItem.ListViewSubItem();
                subListViewItem5.Text = ( item.SRTrendInfo.RelativelyPercent * 100 ).ToString() + "%";

                ListViewItem.ListViewSubItem subListViewItem6 = new ListViewItem.ListViewSubItem();
                subListViewItem6.Text = item.SRTrendInfo.RelativelyNumber.ToString();

                listViewItem.SubItems.Add( subListViewItem1 );
                listViewItem.SubItems.Add( subListViewItem2 );
                listViewItem.SubItems.Add( subListViewItem3 );
                listViewItem.SubItems.Add( subListViewItem4 );
                listViewItem.SubItems.Add( subListViewItem5 );
                listViewItem.SubItems.Add( subListViewItem6 );

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
            this.LabelCPFInfo.Text = srReport.SRDynamicData.StockCPF.ToString();
            this.LabelCRPFInfo.Text = srReport.SRDynamicData.StockCRPF.ToString() + "%";
        }
    }
}
