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
    public partial class DocumentMSRKControl : UserControl
    {
        public DocumentMSRKControl()
        {
            InitializeComponent();
        }

        public const int COLUMN_NUMBER = 0;
        public const int COLUMN_NAME = 1;
        public const int COLUMN_FILE = 2;

        string NEW_ITEM_NAME = "点击这儿设置报表名称";
        string NEW_ITEM_FILE = "点击这儿添加指定的报表文件名";


        private bool m_bisInit = false;

        private void DocumentMSRKControl_Load( object sender, EventArgs e )
        {
            if ( m_bisInit == true )
                return;
            else
                m_bisInit = true;


            ReportRecord Record;
            ReportRecordItem Item;
            ReportColumn Column;

            // define the columns
            Column = axReportControl1.Columns.Add( COLUMN_NUMBER, "NO.", 30, true );
            Column.Editable = false;

            Column = axReportControl1.Columns.Add( COLUMN_NAME, "日期", 250, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl1.Columns.Add( COLUMN_FILE, "MRA", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl1.Columns.Add( COLUMN_FILE, "MRH", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl1.Columns.Add( COLUMN_FILE, "MRL", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl1.Columns.Add( COLUMN_FILE, "MRCK-H", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl1.Columns.Add( COLUMN_FILE, "MRK线类型", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl1.Columns.Add( COLUMN_FILE, "MRK线变量信息", 400, true );
            Column.DrawHeaderRowsVGrid = false;
            Column.EditOptions.AddExpandButton();

            axReportControl1.PaintManager.VerticalGridStyle = XTPReportGridStyle.xtpGridSolid;
            axReportControl1.AllowEdit = true;
            axReportControl1.FocusSubItems = true;
            axReportControl1.AllowColumnRemove = false;

            // New item row (header row)
            Record = axReportControl1.HeaderRecords.Add();

            axReportControl1.PaintManager.HeaderRowsDividerStyle = XTPReportFixedRowsDividerStyle.xtpReportFixedRowsDividerOutlook;
            axReportControl1.ShowHeaderRows = true;
            axReportControl1.HeaderRowsAllowEdit = true;

            //Item = Record.AddItem( "" );
            //Item = Record.AddItem( NEW_ITEM_NAME );
            //Item = Record.AddItem( NEW_ITEM_FILE );

            //ClearHeaderRow( true );

            axReportControl1.Populate();
            axReportControl1.SetCustomDraw( XTPReportCustomDraw.xtpCustomBeforeDrawRow );


            // define the columns
            Column = axReportControl2.Columns.Add( COLUMN_NUMBER, "NO.", 30, true );
            Column.Editable = false;

            Column = axReportControl2.Columns.Add( COLUMN_NAME, "日期", 250, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl2.Columns.Add( COLUMN_FILE, "MSA", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl2.Columns.Add( COLUMN_FILE, "MSH", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl2.Columns.Add( COLUMN_FILE, "MSL", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl2.Columns.Add( COLUMN_FILE, "MSCK-L", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl2.Columns.Add( COLUMN_FILE, "MSK线类型", 400, true );
            Column.DrawHeaderRowsVGrid = false;

            Column = axReportControl2.Columns.Add( COLUMN_FILE, "MSK线变量信息", 400, true );
            Column.DrawHeaderRowsVGrid = false;
            Column.EditOptions.AddExpandButton();

            axReportControl2.PaintManager.VerticalGridStyle = XTPReportGridStyle.xtpGridSolid;
            axReportControl2.AllowEdit = true;
            axReportControl2.FocusSubItems = true;
            axReportControl2.AllowColumnRemove = false;

            // New item row (header row)
            Record = axReportControl2.HeaderRecords.Add();

            axReportControl2.PaintManager.HeaderRowsDividerStyle = XTPReportFixedRowsDividerStyle.xtpReportFixedRowsDividerOutlook;
            axReportControl2.ShowHeaderRows = true;
            axReportControl2.HeaderRowsAllowEdit = true;

            //Item = Record.AddItem( "" );
            //Item = Record.AddItem( NEW_ITEM_NAME );
            //Item = Record.AddItem( NEW_ITEM_FILE );

            //ClearHeaderRow( true );

            axReportControl2.Populate();
            axReportControl2.SetCustomDraw( XTPReportCustomDraw.xtpCustomBeforeDrawRow );
        }
    }
}
