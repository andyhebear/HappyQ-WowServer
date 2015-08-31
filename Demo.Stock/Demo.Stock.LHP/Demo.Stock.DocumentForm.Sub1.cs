using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;
using System.Collections;

namespace Demo.Stock.LHP
{
    public partial class DocumentFormSub1 : UserControl
    {
        private Dictionary<ListViewItem, DocumentFormSub1Form> m_AllDocumenFormInfo = new Dictionary<ListViewItem, DocumentFormSub1Form>();

        public DocumentFormSub1()
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
            m_ListViewItemInfo.Clear();
            this.ListView.Items.Clear();

            InsertMain( srReport.SRStaticData.LastStock, srReport.SRDynamicData.StaticSRCK_R, srReport.SRDynamicData.StaticSRCK_RV, srReport.SRDynamicData.StaticSRCK_S, srReport.SRDynamicData.StaticSRCK_SV, srReport.SRStaticData.LastStock.StockDate );

            int iIndex = 0;
            for ( int iIndexA = 0; iIndexA < srReport.SRStaticData.srStaticInfoArray.Length; iIndexA++ )
            {
                SRStaticData.SRStaticInfo item = srReport.SRStaticData.srStaticInfoArray[iIndexA];

                iIndex++;

                if ( ( item.SRPointType & SRStaticData.SRPointType.DCHP ) == SRStaticData.SRPointType.DCHP )
                {
                    StringBuilder strText = new StringBuilder();
                    strText.Append( "<DCHP>" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCLP ) == SRStaticData.SRPointType.DCLP )
                        strText.Append( "|DCLP" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GULK ) == SRStaticData.SRPointType.GULK )
                        strText.Append( "|GULK" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GUHK ) == SRStaticData.SRPointType.GUHK )
                        strText.Append( "|GUHK" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDLK ) == SRStaticData.SRPointType.GDLK )
                        strText.Append( "|GDLK" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDHK ) == SRStaticData.SRPointType.GDHK )
                        strText.Append( "|GDHK" );

                    string strText2 = strText.ToString();
                    Insert( item, strText2 == "<DCHP>" ? "DCHP" : strText2, iIndex, SRStaticData.SRPointType.DCHP, string.Empty, string.Empty );
                }

                if ( ( item.SRPointType & SRStaticData.SRPointType.DCLP ) == SRStaticData.SRPointType.DCLP )
                {
                    StringBuilder strText = new StringBuilder();

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCHP ) == SRStaticData.SRPointType.DCHP )
                        strText.Append( "DCHP|" );

                    strText.Append( "<DCLP>" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GULK ) == SRStaticData.SRPointType.GULK )
                        strText.Append( "|GULK" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GUHK ) == SRStaticData.SRPointType.GUHK )
                        strText.Append( "|GUHK" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDLK ) == SRStaticData.SRPointType.GDLK )
                        strText.Append( "|GDLK" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDHK ) == SRStaticData.SRPointType.GDHK )
                        strText.Append( "|GDHK" );

                    string strText2 = strText.ToString();
                    Insert( item, strText2 == "<DCLP>" ? "DCLP" : strText2, iIndex, SRStaticData.SRPointType.DCLP, string.Empty, string.Empty );
                }

                if ( ( item.SRPointType & SRStaticData.SRPointType.GULK ) == SRStaticData.SRPointType.GULK )
                {
                    StringBuilder strText = new StringBuilder();

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCHP ) == SRStaticData.SRPointType.DCHP )
                        strText.Append( "DCHP|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCLP ) == SRStaticData.SRPointType.DCLP )
                        strText.Append( "DCLP|" );

                    strText.Append( "<GULK>" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GUHK ) == SRStaticData.SRPointType.GUHK )
                        strText.Append( "|GUHK" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDLK ) == SRStaticData.SRPointType.GDLK )
                        strText.Append( "|GDLK" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDHK ) == SRStaticData.SRPointType.GDHK )
                        strText.Append( "|GDHK" );

                    string strGPS = srReport.SRStaticData.srStaticInfoArray[iIndexA - 1].GapPriceSpace.ToString();
                    float fVG = srReport.SRStaticData.srStaticInfoArray[iIndexA - 1].GapVolumePercentum;
                    string strVG = fVG > 0 ? ( "+" + fVG.ToString() ) : fVG.ToString();
                    string strText2 = strText.ToString();
                    Insert( item, strText2 == "<GULK>" ? "GULK" : strText2, iIndex, SRStaticData.SRPointType.GULK, strGPS, strVG );
                }

                if ( ( item.SRPointType & SRStaticData.SRPointType.GUHK ) == SRStaticData.SRPointType.GUHK )
                {
                    StringBuilder strText = new StringBuilder();

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCHP ) == SRStaticData.SRPointType.DCHP )
                        strText.Append( "DCHP|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCLP ) == SRStaticData.SRPointType.DCLP )
                        strText.Append( "DCLP|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GULK ) == SRStaticData.SRPointType.GULK )
                        strText.Append( "GULK|" );

                    strText.Append( "<GUHK>" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDLK ) == SRStaticData.SRPointType.GDLK )
                        strText.Append( "|GDLK" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDHK ) == SRStaticData.SRPointType.GDHK )
                        strText.Append( "|GDHK" );

                    string strText2 = strText.ToString();
                    Insert( item, strText2 == "<GUHK>" ? "GUHK" : strText2, iIndex, SRStaticData.SRPointType.GUHK, string.Empty, string.Empty );
                }

                if ( ( item.SRPointType & SRStaticData.SRPointType.GDLK ) == SRStaticData.SRPointType.GDLK )
                {
                    StringBuilder strText = new StringBuilder();

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCHP ) == SRStaticData.SRPointType.DCHP )
                        strText.Append( "DCHP|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCLP ) == SRStaticData.SRPointType.DCLP )
                        strText.Append( "DCLP|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GULK ) == SRStaticData.SRPointType.GULK )
                        strText.Append( "GULK|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GUHK ) == SRStaticData.SRPointType.GUHK )
                        strText.Append( "GUHK|" );

                    strText.Append( "<GDLK>" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDHK ) == SRStaticData.SRPointType.GDHK )
                        strText.Append( "|GDHK" );

                    string strText2 = strText.ToString();
                    Insert( item, strText2 == "<GDLK>" ? "GDLK" : strText2, iIndex, SRStaticData.SRPointType.GDLK, string.Empty, string.Empty );
                }

                if ( ( item.SRPointType & SRStaticData.SRPointType.GDHK ) == SRStaticData.SRPointType.GDHK )
                {
                    StringBuilder strText = new StringBuilder();

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCHP ) == SRStaticData.SRPointType.DCHP )
                        strText.Append( "DCHP|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.DCLP ) == SRStaticData.SRPointType.DCLP )
                        strText.Append( "DCLP|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GULK ) == SRStaticData.SRPointType.GULK )
                        strText.Append( "GULK|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GUHK ) == SRStaticData.SRPointType.GUHK )
                        strText.Append( "GUHK|" );

                    if ( ( item.SRPointType & SRStaticData.SRPointType.GDLK ) == SRStaticData.SRPointType.GDLK )
                        strText.Append( "GDLK|" );

                    strText.Append( "<GDHK>" );

                    string strGPS = srReport.SRStaticData.srStaticInfoArray[iIndexA - 1].GapPriceSpace.ToString();
                    float fVG = srReport.SRStaticData.srStaticInfoArray[iIndexA - 1].GapVolumePercentum;
                    string strVG = fVG > 0 ? ( "+" + fVG.ToString() ) : fVG.ToString();
                    string strText2 = strText.ToString();
                    Insert( item, strText2 == "<GDHK>" ? "GDHK" : strText2, iIndex, SRStaticData.SRPointType.GDHK, strGPS, strVG );
                }

                if ( item.SRPointType == SRStaticData.SRPointType.None )
                    continue;
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

            this.ListView.ListViewItemSorter = new ListViewItemComparer( 1, m_ListViewItemInfo, bisturn );
        }

        private void InsertMain( SRStaticData.StockData stockData, float fSRCK_R, float fSRCK_RV, float fSRCK_S, float fSRCK_SV, DateTime dateTime )
        {
            ListViewItemInfo listViewItemInfo = new ListViewItemInfo();

            ListViewItem listViewItem = new ListViewItem( "SRCK-R" );
            listViewItem.ForeColor = Color.Red;
            listViewItemInfo.Column = -2;

            ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem();
            subListViewItem1.Text = string.Empty;
            listViewItemInfo.Column1 = MSFL.FormatPrice( stockData.StockClose ) - 0.002F;

            ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem();
            subListViewItem2.Text = string.Empty;
            //subListViewItem2.Text = fSRCK_SV.ToString();
            listViewItemInfo.Column2 = fSRCK_SV + 0.002F;

            ListViewItem.ListViewSubItem subListViewItem3 = new ListViewItem.ListViewSubItem();
            subListViewItem3.Text = fSRCK_R.ToString() + "%";
            listViewItemInfo.Column3 = fSRCK_RV - 0.006F;

            ListViewItem.ListViewSubItem subListViewItem4 = new ListViewItem.ListViewSubItem();
            subListViewItem4.Text = string.Empty;
            listViewItemInfo.Column4 = dateTime - TimeSpan.FromHours( 1.0 );

            ListViewItem.ListViewSubItem subListViewItem5 = new ListViewItem.ListViewSubItem();
            subListViewItem5.Text = string.Empty;

            ListViewItem.ListViewSubItem subListViewItem6 = new ListViewItem.ListViewSubItem();
            subListViewItem6.Text = string.Empty;

            ListViewItem.ListViewSubItem subListViewItem7 = new ListViewItem.ListViewSubItem();
            subListViewItem7.Text = string.Empty;

            ListViewItem.ListViewSubItem subListViewItem8 = new ListViewItem.ListViewSubItem();
            subListViewItem8.Text = string.Empty;
            listViewItemInfo.Column8 = -2;

            ListViewItem.ListViewSubItem subListViewItem9 = new ListViewItem.ListViewSubItem();
            subListViewItem9.Text = string.Empty;
            listViewItemInfo.Column9 = -2;

            listViewItem.SubItems.Add( subListViewItem1 );
            listViewItem.SubItems.Add( subListViewItem2 );
            listViewItem.SubItems.Add( subListViewItem3 );
            listViewItem.SubItems.Add( subListViewItem4 );
            listViewItem.SubItems.Add( subListViewItem5 );
            listViewItem.SubItems.Add( subListViewItem6 );
            listViewItem.SubItems.Add( subListViewItem7 );
            listViewItem.SubItems.Add( subListViewItem8 );
            listViewItem.SubItems.Add( subListViewItem9 );

            this.ListView.Items.Add( listViewItem );
            m_ListViewItemInfo.Add( listViewItem, listViewItemInfo );

            listViewItemInfo = new ListViewItemInfo();

            listViewItem = new ListViewItem( "CK" );
            listViewItem.ForeColor = Color.Blue;
            listViewItemInfo.Column = -1;

            subListViewItem1 = new ListViewItem.ListViewSubItem();
            subListViewItem1.Text = MSFL.FormatPrice( stockData.StockClose ).ToString();
            listViewItemInfo.Column1 = MSFL.FormatPrice( stockData.StockClose );

            subListViewItem2 = new ListViewItem.ListViewSubItem();
            subListViewItem2.Text = string.Empty;
            //subListViewItem2.Text = MSFL.FormatPrice( stockData.StockLow ).ToString();
            listViewItemInfo.Column2 = fSRCK_SV + 0.004F;

            subListViewItem3 = new ListViewItem.ListViewSubItem();
            subListViewItem3.Text = string.Empty;
            //subListViewItem3.Text = MSFL.FormatPrice( stockData.StockHigh ).ToString();
            listViewItemInfo.Column3 = fSRCK_RV - 0.004F;

            subListViewItem4 = new ListViewItem.ListViewSubItem();
            subListViewItem4.Text = stockData.StockDate.ToShortDateString();
            listViewItemInfo.Column4 = dateTime;

            subListViewItem5 = new ListViewItem.ListViewSubItem();
            subListViewItem5.Text = stockData.StockOpen > stockData.StockClose ? "↘" : "↗";

            subListViewItem6 = new ListViewItem.ListViewSubItem();
            subListViewItem6.Text = string.Empty;

            subListViewItem7 = new ListViewItem.ListViewSubItem();
            subListViewItem7.Text = string.Empty;

            subListViewItem8 = new ListViewItem.ListViewSubItem();
            subListViewItem8.Text = string.Empty;
            listViewItemInfo.Column8 = -1;

            subListViewItem9 = new ListViewItem.ListViewSubItem();
            subListViewItem9.Text = string.Empty;
            listViewItemInfo.Column9 = -1;

            listViewItem.SubItems.Add( subListViewItem1 );
            listViewItem.SubItems.Add( subListViewItem2 );
            listViewItem.SubItems.Add( subListViewItem3 );
            listViewItem.SubItems.Add( subListViewItem4 );
            listViewItem.SubItems.Add( subListViewItem5 );
            listViewItem.SubItems.Add( subListViewItem6 );
            listViewItem.SubItems.Add( subListViewItem7 );
            listViewItem.SubItems.Add( subListViewItem8 );
            listViewItem.SubItems.Add( subListViewItem9 );

            this.ListView.Items.Add( listViewItem );
            m_ListViewItemInfo.Add( listViewItem, listViewItemInfo );


            listViewItemInfo = new ListViewItemInfo();

            listViewItem = new ListViewItem( "SRCK-S" );
            listViewItem.ForeColor = Color.Green;
            listViewItemInfo.Column = 0;

            subListViewItem1 = new ListViewItem.ListViewSubItem();
            subListViewItem1.Text = string.Empty;
            listViewItemInfo.Column1 = MSFL.FormatPrice( stockData.StockClose ) + 0.002F;

            subListViewItem2 = new ListViewItem.ListViewSubItem();
            subListViewItem2.Text = fSRCK_S.ToString() + "%";
            listViewItemInfo.Column2 = fSRCK_SV + 0.006F;

            subListViewItem3 = new ListViewItem.ListViewSubItem();
            subListViewItem3.Text = string.Empty;
            //subListViewItem3.Text = fSRCK_RV.ToString();
            listViewItemInfo.Column3 = fSRCK_RV - 0.002F;

            subListViewItem4 = new ListViewItem.ListViewSubItem();
            subListViewItem4.Text = string.Empty;
            listViewItemInfo.Column4 = dateTime + TimeSpan.FromHours( 1.0 );

            subListViewItem5 = new ListViewItem.ListViewSubItem();
            subListViewItem5.Text = string.Empty;

            subListViewItem6 = new ListViewItem.ListViewSubItem();
            subListViewItem6.Text = string.Empty;

            subListViewItem7 = new ListViewItem.ListViewSubItem();
            subListViewItem7.Text = string.Empty;

            subListViewItem8 = new ListViewItem.ListViewSubItem();
            subListViewItem8.Text = string.Empty;
            listViewItemInfo.Column8 = 0;

            subListViewItem9 = new ListViewItem.ListViewSubItem();
            subListViewItem9.Text = string.Empty;
            listViewItemInfo.Column9 = 0;

            listViewItem.SubItems.Add( subListViewItem1 );
            listViewItem.SubItems.Add( subListViewItem2 );
            listViewItem.SubItems.Add( subListViewItem3 );
            listViewItem.SubItems.Add( subListViewItem4 );
            listViewItem.SubItems.Add( subListViewItem5 );
            listViewItem.SubItems.Add( subListViewItem6 );
            listViewItem.SubItems.Add( subListViewItem7 );
            listViewItem.SubItems.Add( subListViewItem8 );
            listViewItem.SubItems.Add( subListViewItem9 );

            this.ListView.Items.Add( listViewItem );
            m_ListViewItemInfo.Add( listViewItem, listViewItemInfo );
        }

        private void Insert( SRStaticData.SRStaticInfo srStaticInfo, string strText, int iIndex, SRStaticData.SRPointType srPointType, string strGPS, string strVG )
        {
            ListViewItemInfo listViewItemInfo = new ListViewItemInfo();

            ListViewItem listViewItem = new ListViewItem( iIndex.ToString() );
            listViewItemInfo.Column = iIndex;

            ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem();
            switch ( srPointType )
            {
                case SRStaticData.SRPointType.DCHP:

                    subListViewItem1.Text = srStaticInfo.StockAverageHigh.ToString();
                    listViewItemInfo.Column1 = srStaticInfo.StockAverageHigh;
                    break;
                case SRStaticData.SRPointType.DCLP:

                    subListViewItem1.Text = srStaticInfo.StockAverageLow.ToString();
                    listViewItemInfo.Column1 = srStaticInfo.StockAverageLow;
                    break;
                case SRStaticData.SRPointType.GULK:

                    subListViewItem1.Text = srStaticInfo.StockAverageHigh.ToString();
                    listViewItemInfo.Column1 = srStaticInfo.StockAverageHigh;
                    break;
                case SRStaticData.SRPointType.GUHK:

                    subListViewItem1.Text = srStaticInfo.StockAverageLow.ToString();
                    listViewItemInfo.Column1 = srStaticInfo.StockAverageLow;
                    break;
                case SRStaticData.SRPointType.GDLK:

                    subListViewItem1.Text = srStaticInfo.StockAverageHigh.ToString();
                    listViewItemInfo.Column1 = srStaticInfo.StockAverageHigh;
                    break;
                case SRStaticData.SRPointType.GDHK:

                    subListViewItem1.Text = srStaticInfo.StockAverageLow.ToString();
                    listViewItemInfo.Column1 = srStaticInfo.StockAverageLow;
                    break;
                default:

                    subListViewItem1.Text = string.Empty;
                    listViewItemInfo.Column1 = 0F;
                    break;
            }

            float fEntity = 0;
            
            ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem();
            subListViewItem2.ForeColor = Color.Green;
            switch ( srPointType )
            {
                case SRStaticData.SRPointType.DCHP:

                    subListViewItem2.Text = srStaticInfo.StockData.StockHigh.ToString();
                    listViewItemInfo.Column2 = srStaticInfo.StockData.StockHigh;
                    break;
                case SRStaticData.SRPointType.DCLP:

                    fEntity = srStaticInfo.StockData.StockOpen > srStaticInfo.StockData.StockClose ? srStaticInfo.StockData.StockClose : srStaticInfo.StockData.StockOpen;
                    subListViewItem2.Text = fEntity.ToString();
                    listViewItemInfo.Column2 = fEntity;
                    break;
                case SRStaticData.SRPointType.GULK:

                    subListViewItem2.Text = srStaticInfo.StockData.StockHigh.ToString();
                    listViewItemInfo.Column2 = srStaticInfo.StockData.StockHigh;
                    break;
                case SRStaticData.SRPointType.GUHK:

                    fEntity = srStaticInfo.StockData.StockOpen > srStaticInfo.StockData.StockClose ? srStaticInfo.StockData.StockClose : srStaticInfo.StockData.StockOpen;
                    subListViewItem2.Text = fEntity.ToString();
                    listViewItemInfo.Column2 = fEntity;
                    break;
                case SRStaticData.SRPointType.GDLK:

                    subListViewItem2.Text = srStaticInfo.StockData.StockHigh.ToString();
                    listViewItemInfo.Column2 = srStaticInfo.StockData.StockHigh;
                    break;
                case SRStaticData.SRPointType.GDHK:

                    fEntity = srStaticInfo.StockData.StockOpen > srStaticInfo.StockData.StockClose ? srStaticInfo.StockData.StockClose : srStaticInfo.StockData.StockOpen;
                    subListViewItem2.Text = fEntity.ToString();
                    listViewItemInfo.Column2 = fEntity;
                    break;
                default:

                    subListViewItem2.Text = string.Empty;
                    break;
            }

            ListViewItem.ListViewSubItem subListViewItem3 = new ListViewItem.ListViewSubItem();
            subListViewItem3.ForeColor = Color.Red;
            switch ( srPointType )
            {
                case SRStaticData.SRPointType.DCHP:

                    fEntity = srStaticInfo.StockData.StockOpen > srStaticInfo.StockData.StockClose ? srStaticInfo.StockData.StockOpen : srStaticInfo.StockData.StockClose;
                    subListViewItem3.Text = fEntity.ToString();
                    listViewItemInfo.Column3 = fEntity;
                    break;
                case SRStaticData.SRPointType.DCLP:

                    subListViewItem3.Text = srStaticInfo.StockData.StockLow.ToString();
                    listViewItemInfo.Column3 = srStaticInfo.StockData.StockLow;
                    break;
                case SRStaticData.SRPointType.GULK:

                    fEntity = srStaticInfo.StockData.StockOpen > srStaticInfo.StockData.StockClose ? srStaticInfo.StockData.StockOpen : srStaticInfo.StockData.StockClose;
                    subListViewItem3.Text = fEntity.ToString();
                    listViewItemInfo.Column3 = fEntity;
                    break;
                case SRStaticData.SRPointType.GUHK:

                    subListViewItem3.Text = srStaticInfo.StockData.StockLow.ToString();
                    listViewItemInfo.Column3 = srStaticInfo.StockData.StockLow;
                    break;
                case SRStaticData.SRPointType.GDLK:

                    fEntity = srStaticInfo.StockData.StockOpen > srStaticInfo.StockData.StockClose ? srStaticInfo.StockData.StockOpen : srStaticInfo.StockData.StockClose;
                    subListViewItem3.Text = fEntity.ToString();
                    listViewItemInfo.Column3 = fEntity;
                    break;
                case SRStaticData.SRPointType.GDHK:

                    subListViewItem3.Text = srStaticInfo.StockData.StockLow.ToString();
                    listViewItemInfo.Column3 = srStaticInfo.StockData.StockLow;
                    break;
                default:

                    subListViewItem3.Text = string.Empty;
                    break;
            }
            ListViewItem.ListViewSubItem subListViewItem4 = new ListViewItem.ListViewSubItem();
            subListViewItem4.Text = srStaticInfo.StockData.StockDate.ToShortDateString();
            listViewItemInfo.Column4 = srStaticInfo.StockData.StockDate;

            ListViewItem.ListViewSubItem subListViewItem5 = new ListViewItem.ListViewSubItem();
            subListViewItem5.Text = strText;
            listViewItemInfo.Column5 = strText;

            ListViewItem.ListViewSubItem subListViewItem6 = new ListViewItem.ListViewSubItem();
            subListViewItem6.ForeColor = Color.Blue;
            switch ( srPointType )
            {
                case SRStaticData.SRPointType.DCHP:

                    subListViewItem6.Text = "LHKN(L)" + srStaticInfo.LeftKLineNumber.ToString();
                    listViewItemInfo.Column6 = subListViewItem6.Text;
                    break;
                case SRStaticData.SRPointType.DCLP:

                    subListViewItem6.Text = "HLKN(L)" + srStaticInfo.LeftKLineNumber.ToString();
                    listViewItemInfo.Column6 = subListViewItem6.Text;
                    break;
                case SRStaticData.SRPointType.GULK:

                    subListViewItem6.Text = "GPS↑ " + strGPS + "%";
                    listViewItemInfo.Column6 = subListViewItem6.Text;
                    break;
                case SRStaticData.SRPointType.GUHK:

                    subListViewItem6.Text = "GPS↑ " + srStaticInfo.GapPriceSpace.ToString() + "%";
                    listViewItemInfo.Column6 = subListViewItem6.Text;
                    break;
                case SRStaticData.SRPointType.GDLK:

                    subListViewItem6.Text = "GPS↓ " + srStaticInfo.GapPriceSpace.ToString() + "%";
                    listViewItemInfo.Column6 = subListViewItem6.Text;
                    break;
                case SRStaticData.SRPointType.GDHK:

                    subListViewItem6.Text = "GPS↓ " + strGPS + "%";
                    listViewItemInfo.Column6 = subListViewItem6.Text;
                    break;
                default:

                    subListViewItem6.Text = string.Empty;
                    break;
            }

            ListViewItem.ListViewSubItem subListViewItem7 = new ListViewItem.ListViewSubItem();
            subListViewItem7.ForeColor = Color.Blue;
            switch ( srPointType )
            {
                case SRStaticData.SRPointType.DCHP:

                    subListViewItem7.Text = "LHKN(R)" + srStaticInfo.RightLineNumber.ToString();
                    listViewItemInfo.Column7 = subListViewItem7.Text;
                    break;
                case SRStaticData.SRPointType.DCLP:

                    subListViewItem7.Text = "HLKN(R)" + srStaticInfo.RightLineNumber.ToString();
                    listViewItemInfo.Column7 = subListViewItem7.Text;
                    break;
                case SRStaticData.SRPointType.GULK:

                    subListViewItem7.Text = "VG " + strVG + "%";
                    listViewItemInfo.Column7 = subListViewItem7.Text;
                    break;
                case SRStaticData.SRPointType.GUHK:

                    strVG = srStaticInfo.GapVolumePercentum > 0 ? ( "+" + srStaticInfo.GapVolumePercentum.ToString() ) : srStaticInfo.GapVolumePercentum.ToString();
                    subListViewItem7.Text = "VG " + strVG + "%";
                    listViewItemInfo.Column7 = subListViewItem7.Text;
                    break;
                case SRStaticData.SRPointType.GDLK:

                    strVG = srStaticInfo.GapVolumePercentum > 0 ? ( "+" + srStaticInfo.GapVolumePercentum.ToString() ) : srStaticInfo.GapVolumePercentum.ToString();
                    subListViewItem7.Text = "VG " + strVG + "%";
                    listViewItemInfo.Column7 = subListViewItem7.Text;
                    break;
                case SRStaticData.SRPointType.GDHK:

                    subListViewItem7.Text = "VG " + strVG + "%";
                    listViewItemInfo.Column7 = subListViewItem7.Text;
                    break;
                default:

                    subListViewItem7.Text = string.Empty;
                    break;
            }

            ListViewItem.ListViewSubItem subListViewItem8 = new ListViewItem.ListViewSubItem();
            subListViewItem8.Text = ( srStaticInfo.RelativelyPercent * 100 ).ToString() + "%";
            listViewItemInfo.Column8 = srStaticInfo.RelativelyPercent * 100;

            ListViewItem.ListViewSubItem subListViewItem9 = new ListViewItem.ListViewSubItem();
            subListViewItem9.Text = srStaticInfo.RelativelyNumber.ToString();
            listViewItemInfo.Column9 = srStaticInfo.RelativelyNumber;

            listViewItem.SubItems.Add( subListViewItem1 );
            listViewItem.SubItems.Add( subListViewItem2 );
            listViewItem.SubItems.Add( subListViewItem3 );
            listViewItem.SubItems.Add( subListViewItem4 );
            listViewItem.SubItems.Add( subListViewItem5 );
            listViewItem.SubItems.Add( subListViewItem6 );
            listViewItem.SubItems.Add( subListViewItem7 );
            listViewItem.SubItems.Add( subListViewItem8 );
            listViewItem.SubItems.Add( subListViewItem9 );

            this.ListView.Items.Add( listViewItem );

            m_ListViewItemInfo.Add( listViewItem, listViewItemInfo );
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

        bool bisturn = true;
        private void ListView_ColumnClick( object sender, ColumnClickEventArgs e )
        {
            if ( e.Column == 1 )
            {
                if ( bisturn == true )
                    bisturn = false;
                else
                    bisturn = true;
            }

            this.ListView.ListViewItemSorter = new ListViewItemComparer( e.Column, m_ListViewItemInfo, bisturn );
        }


        Dictionary<ListViewItem, ListViewItemInfo> m_ListViewItemInfo = new Dictionary<ListViewItem, ListViewItemInfo>();
        public class ListViewItemInfo
        {
            public int Column = 0;
            public float Column1 = 0;
            public float Column2 = 0;
            public float Column3 = 0;
            public DateTime Column4 = DateTime.MinValue;
            public string Column5 = string.Empty;
            public string Column6 = string.Empty;
            public string Column7 = string.Empty;
            public float Column8 = 0;
            public float Column9 = 0;
        }

        // Implements the manual sorting of items by columns.
        private class ListViewItemComparer : IComparer
        {
            private int m_Column = 0;
            private bool m_IsTurn = false;
            private Dictionary<ListViewItem, ListViewItemInfo> m_ListViewItemInfo = null;
            public ListViewItemComparer()
            {
                m_Column = 0;
            }
            public ListViewItemComparer( int column, Dictionary<ListViewItem, ListViewItemInfo> listViewItemInfo, bool bisturn )
            {
                m_Column = column;
                m_ListViewItemInfo = listViewItemInfo;
                m_IsTurn = bisturn;
            }

            public int Compare( object x, object y )
            {
                ListViewItemInfo listViewItemInfoA = null;
                ListViewItemInfo listViewItemInfoB = null;

                m_ListViewItemInfo.TryGetValue( (ListViewItem)x, out listViewItemInfoA );
                m_ListViewItemInfo.TryGetValue( (ListViewItem)y, out listViewItemInfoB );
                switch ( m_Column )
                {
                    case 0:

                        return listViewItemInfoA.Column.CompareTo( listViewItemInfoB.Column );
                    case 1:
                        int fff = listViewItemInfoA.Column1.CompareTo( listViewItemInfoB.Column1 );
                        if ( m_IsTurn == true )
                            return fff;
                        else
                            if (fff > 0)
                                return -1;
                            else if (fff < 0)
                                return 1;
                            else
                                return 0;
                    case 2:

                        return listViewItemInfoA.Column2.CompareTo( listViewItemInfoB.Column2 );
                    case 3:

                        return listViewItemInfoA.Column3.CompareTo( listViewItemInfoB.Column3 );
                    case 4:

                        return listViewItemInfoA.Column4.CompareTo( listViewItemInfoB.Column4 );
                    case 5:

                        return String.Compare( ( (ListViewItem)x ).SubItems[m_Column].Text, ( (ListViewItem)y ).SubItems[m_Column].Text );
                    case 6:

                        return String.Compare( ( (ListViewItem)x ).SubItems[m_Column].Text, ( (ListViewItem)y ).SubItems[m_Column].Text );
                    case 7:

                        return String.Compare( ( (ListViewItem)x ).SubItems[m_Column].Text, ( (ListViewItem)y ).SubItems[m_Column].Text );
                    case 8:

                        return listViewItemInfoA.Column8.CompareTo( listViewItemInfoB.Column8 );
                    case 9:

                        return listViewItemInfoA.Column9.CompareTo( listViewItemInfoB.Column9 );
                    
                    default:
                        return String.Compare( ( (ListViewItem)x ).SubItems[m_Column].Text, ( (ListViewItem)y ).SubItems[m_Column].Text );
                }

            }
        }

    }
}
