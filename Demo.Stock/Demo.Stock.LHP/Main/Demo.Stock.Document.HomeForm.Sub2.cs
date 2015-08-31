using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeReportControl;

namespace Demo.Stock.LHP.Main
{
    public partial class HomeControlSub2 : UserControl
    {
        public HomeControlSub2()
        {
            InitializeComponent();
        }

        public const int COLUMN_NUMBER = 0;
        public const int COLUMN_NAME = 1;
        public const int COLUMN_LIST = 2;
        public const int COLUMN_FILE = 3;

        string NEW_ITEM_NAME = "点击这儿设置报表名称";
        string NEW_ITEM_LIST = "点击这儿添加指定的股票清单文件名";
        string NEW_ITEM_FILE = "点击这儿添加指定的报表文件名";

        private bool m_bEnterPressed = false;
        private bool m_bisInit = false;
        private int m_iNumber = 0;


        private void HomeControlSub2_Load( object sender, EventArgs e )
        {
            if ( m_bisInit == true )
                return;
            else
                m_bisInit = true;

            ReportRecord Record;
            ReportRecordItem Item;
            ReportColumn Column;

            // define the columns
            Column = axReportControl.Columns.Add( COLUMN_NUMBER, "NO.", 30, true );
            Column.Editable = false;

            Column = axReportControl.Columns.Add( COLUMN_NAME, "策略名称", 250, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl.Columns.Add( COLUMN_LIST, "股票清单文件", 350, true );
            Column.DrawHeaderRowsVGrid = false;
            Column.EditOptions.AddExpandButton();

            Column = axReportControl.Columns.Add( COLUMN_FILE, "SR策略文件", 400, true );
            Column.DrawHeaderRowsVGrid = false;
            Column.EditOptions.AddExpandButton();

            axReportControl.PaintManager.VerticalGridStyle = XTPReportGridStyle.xtpGridSolid;
            axReportControl.AllowEdit = true;
            axReportControl.FocusSubItems = true;
            axReportControl.AllowColumnRemove = false;

            // New item row (header row)
            Record = axReportControl.HeaderRecords.Add();

            axReportControl.PaintManager.HeaderRowsDividerStyle = XTPReportFixedRowsDividerStyle.xtpReportFixedRowsDividerOutlook;
            axReportControl.ShowHeaderRows = true;
            axReportControl.HeaderRowsAllowEdit = true;

            Item = Record.AddItem( "" );
            Item = Record.AddItem( NEW_ITEM_NAME );
            Item = Record.AddItem( NEW_ITEM_LIST );
            Item = Record.AddItem( NEW_ITEM_FILE );

            ClearHeaderRow( true );

            axReportControl.Populate();
            axReportControl.SetCustomDraw( XTPReportCustomDraw.xtpCustomBeforeDrawRow );

        }

        private void ClearHeaderRow( bool bClear )
        {
            axReportControl.HeaderRecords[0][COLUMN_NAME].Value = bClear ? NEW_ITEM_NAME : "";
            axReportControl.HeaderRecords[0][COLUMN_LIST].Value = bClear ? NEW_ITEM_LIST : "";
            axReportControl.HeaderRecords[0][COLUMN_FILE].Value = bClear ? NEW_ITEM_FILE : "";
        }

        private void AddNewRecord()
        {
            string strName = System.Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_NAME].Value );
            string strList = System.Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_LIST].Value );
            string strFile = System.Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_FILE].Value );

            if ( strFile != NEW_ITEM_FILE && String.IsNullOrEmpty( strFile ) == false )
            {
                //if ( File.Exists( strFile ) == false )
                //    return;

                {
                    AddTask( strName == NEW_ITEM_NAME ? string.Empty : strName, strList, strFile );

                    ClearHeaderRow( true );

                    // Keep selection on New item row
                    axReportControl.Populate();
                    axReportControl.Navigator.CurrentFocusInHeadersRows = true;
                }
            }

            m_bEnterPressed = false;
        }

        private void AddTask( string strName, string strList, string strFile )
        {
            m_iNumber++;

            ReportRecordItem Item;
            ReportRecord Record = axReportControl.Records.Insert( 0 );

            Item = Record.AddItem( m_iNumber );
            Item = Record.AddItem( strName );
            Item = Record.AddItem( strList );
            Item = Record.AddItem( strFile );
        }

        public int HexToDecimal( string HexString )
        {
            char[] HexColor = HexString.ToCharArray();
            int DecimalColor = 0;
            int iLength = HexColor.Length - 1;
            int iDecimalNumber;

            foreach ( char cHexValue in HexColor )
            {
                if ( char.IsNumber( cHexValue ) )
                    iDecimalNumber = int.Parse( cHexValue.ToString() );
                else
                    iDecimalNumber = Convert.ToInt32( cHexValue ) - 55;

                DecimalColor += iDecimalNumber * ( Convert.ToInt32( Math.Pow( 16, iLength ) ) );

                iLength--;
            }

            return DecimalColor;
        }

        private void axReportControl_BeforeDrawRow( object sender, AxXtremeReportControl._DReportControlEvents_BeforeDrawRowEvent e )
        {
            // Before drawing of an every row,
            // adjust its presentation properties depending on
            // some specific conditions
            if ( e.row.Record == null )
                return;

            if ( e.row != axReportControl.HeaderRows[0] )
                return;

            if ( e.item.Index == COLUMN_NAME )
            {
                if ( Convert.ToString( e.row.Record[COLUMN_NAME].Value ) == NEW_ITEM_NAME )
                    e.metrics.ForeColor = Convert.ToUInt32( HexToDecimal( "808080" ) );
                else
                    e.metrics.ForeColor = Convert.ToUInt32( HexToDecimal( "000000" ) );
            }

            if ( e.item.Index == COLUMN_LIST )
            {
                if ( Convert.ToString( e.row.Record[COLUMN_LIST].Value ) == NEW_ITEM_LIST )
                    e.metrics.ForeColor = Convert.ToUInt32( HexToDecimal( "808080" ) );
                else
                    e.metrics.ForeColor = Convert.ToUInt32( HexToDecimal( "000000" ) );
            }

            if ( e.item.Index == COLUMN_FILE )
            {
                if ( Convert.ToString( e.row.Record[COLUMN_FILE].Value ) == NEW_ITEM_FILE )
                    e.metrics.ForeColor = Convert.ToUInt32( HexToDecimal( "808080" ) );
                else
                    e.metrics.ForeColor = Convert.ToUInt32( HexToDecimal( "000000" ) );
            }
        }

        private void axReportControl_InplaceButtonDown( object sender, AxXtremeReportControl._DReportControlEvents_InplaceButtonDownEvent e )
        {
            ReportRecordItem RecordItem;
            ReportInplaceButton Button;
            Button = e.button;

            RecordItem = e.button.Item;

            // If current field is of "Date" type, then show calendar. See Show_DatePicker method.
            if ( Button.Column.ItemIndex == COLUMN_LIST )
            {
                int l, t, r, b, nX, nY;
                l = t = r = b = 0;

                Button.GetRect( ref l, ref t, ref r, ref b );
                nX = r;
                nY = b + 1;


                this.openFileDialog.ShowDialog();

                axReportControl.Redraw();
            }

            if ( Button.Column.ItemIndex == COLUMN_FILE )
            {
                int l, t, r, b, nX, nY;
                l = t = r = b = 0;

                Button.GetRect( ref l, ref t, ref r, ref b );
                nX = r;
                nY = b + 1;


                this.openFileDialog.ShowDialog();

                axReportControl.Redraw();
            }
        }

        private void axReportControl_PreviewKeyDownEvent( object sender, AxXtremeReportControl._DReportControlEvents_PreviewKeyDownEvent e )
        {
            if ( e.keyCode == 13 && e.shift == 0 )
                m_bEnterPressed = true;
            else
                m_bEnterPressed = false;
        }

        private void axReportControl_KeyDownEvent( object sender, AxXtremeReportControl._DReportControlEvents_KeyDownEvent e )
        {
            if ( axReportControl.Navigator.CurrentFocusInHeadersRows && m_bEnterPressed )
                AddNewRecord();
        }

        private void axReportControl_MouseDownEvent( object sender, AxXtremeReportControl._DReportControlEvents_MouseDownEvent e )
        {
            if ( axReportControl.HeaderRows.Count > 0 )
            {
                int l, t, r, b;
                l = t = r = b = 0;

                axReportControl.HeaderRows[0].GetRect( ref l, ref t, ref r, ref b );

                // Whether the mouse click is beyond the header row
                if ( e.y > b )
                {
                    if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_NAME].Value ) == string.Empty )
                        axReportControl.HeaderRecords[0][COLUMN_NAME].Value = NEW_ITEM_NAME;

                    if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_LIST].Value ) == string.Empty )
                        axReportControl.HeaderRecords[0][COLUMN_LIST].Value = NEW_ITEM_LIST;

                    if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_FILE].Value ) == string.Empty )
                        axReportControl.HeaderRecords[0][COLUMN_FILE].Value = NEW_ITEM_FILE;
                    else
                        AddNewRecord();
                }
                else
                {
                    int l2, t2, r2, b2;
                    l2 = t2 = r2 = b2 = 0;

                    // ..or on the header row
                    if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_NAME].Value ) == NEW_ITEM_NAME )
                    {
                        ReportRecord Record = axReportControl.HeaderRecords[0];
                        axReportControl.HeaderRows[0].GetItemRect( Record[COLUMN_NAME], ref l2, ref t2, ref r2, ref b2 );

                        if ( e.y > t2 && e.y < b2 && e.x > l2 && e.x < r2 )
                        {
                            Record[COLUMN_NAME].Value = "";

                            if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_LIST].Value ) == string.Empty )
                                Record[COLUMN_LIST].Value = NEW_ITEM_LIST;

                            if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_FILE].Value ) == string.Empty )
                                Record[COLUMN_FILE].Value = NEW_ITEM_FILE;
                        }
                    }

                    if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_LIST].Value ) == NEW_ITEM_LIST )
                    {
                        ReportRecord Record = axReportControl.HeaderRecords[0];
                        axReportControl.HeaderRows[0].GetItemRect( Record[COLUMN_LIST], ref l2, ref t2, ref r2, ref b2 );

                        if ( e.y > t2 && e.y < b2 && e.x > l2 && e.x < r2 )
                        {
                            Record[COLUMN_LIST].Value = "";

                            if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_NAME].Value ) == string.Empty )
                                Record[COLUMN_NAME].Value = NEW_ITEM_NAME;

                            if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_FILE].Value ) == string.Empty )
                                Record[COLUMN_FILE].Value = NEW_ITEM_FILE;
                        }
                    }

                    if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_FILE].Value ) == NEW_ITEM_FILE )
                    {
                        ReportRecord Record = axReportControl.HeaderRecords[0];
                        axReportControl.HeaderRows[0].GetItemRect( Record[COLUMN_FILE], ref l2, ref t2, ref r2, ref b2 );
                        if ( e.y > t2 && e.y < b2 && e.x > l2 && e.x < r2 )
                        {
                            Record[COLUMN_FILE].Value = "";

                            if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_NAME].Value ) == string.Empty )
                                Record[COLUMN_NAME].Value = NEW_ITEM_NAME;

                            if ( Convert.ToString( axReportControl.HeaderRecords[0][COLUMN_LIST].Value ) == string.Empty )
                                Record[COLUMN_LIST].Value = NEW_ITEM_LIST;
                        }
                    }
                }
            }

        }



        private void axReportControl_ValueChanged( object sender, AxXtremeReportControl._DReportControlEvents_ValueChangedEvent e )
        {
            // Establish automatic correction of field values after it has been changed
            //if ( e.item.Index == COLUMN_FILE )
            //{
            //}

            // If this event was raised by Enter pressing - add new record
            if ( m_bEnterPressed )
                AddNewRecord();
        }
    }
}
