using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeReportControl;

namespace Demo.Stock.LHP.BaseSR
{
    public partial class DocumentSRControl : UserControl
    {
        public DocumentSRControl()
        {
            InitializeComponent();
        }

        public const int COLUMN_NUMBER = 0;
        public const int COLUMN_NAME = 1;
        public const int COLUMN_FILE = 2;

        string NEW_ITEM_NAME = "点击这儿设置报表名称";
        string NEW_ITEM_FILE = "点击这儿添加指定的报表文件名";


        private bool m_bisInit = false;
        private void DocumentSRControl_Load( object sender, EventArgs e )
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

            Column = axReportControl.Columns.Add( COLUMN_NAME, "SR点平均价格", 250, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl.Columns.Add( COLUMN_FILE, "SR-H", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl.Columns.Add( COLUMN_FILE, "SR-L", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl.Columns.Add( COLUMN_FILE, "日期", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl.Columns.Add( COLUMN_FILE, "SR点类型", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl.Columns.Add( COLUMN_FILE, "SR点信息-1", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl.Columns.Add( COLUMN_FILE, "SR点信息-2", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl.Columns.Add( COLUMN_FILE, "SR点相对强度", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl.Columns.Add( COLUMN_FILE, "SR点相对序号", 400, true );
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

            //Item = Record.AddItem( "" );
            //Item = Record.AddItem( NEW_ITEM_NAME );
            //Item = Record.AddItem( NEW_ITEM_FILE );

            //ClearHeaderRow( true );

            axReportControl.Populate();
            axReportControl.SetCustomDraw( XTPReportCustomDraw.xtpCustomBeforeDrawRow );

        }
    }
}
