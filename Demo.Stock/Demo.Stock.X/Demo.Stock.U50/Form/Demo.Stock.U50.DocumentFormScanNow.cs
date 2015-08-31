using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.X.U50
{
    public partial class ScanNowDocumentForm : Form
    {
        public ScanNowDocumentForm()
        {
            InitializeComponent();
        }

        private void DocumentForm01_Load( object sender, EventArgs e )
        {
            this.Timer1.Enabled = true;
            //CreateTabControl();
        }

        public List<U50Form.ScanNowReport> m_ScanNowReportList = null;
        private Dictionary<U50Form.ScanNowReport, DocumentReport> m_ScanNowReport = new Dictionary<U50Form.ScanNowReport, DocumentReport>();
        private int iIndex = 0;
        public void AddReport( U50Form.ScanNowReport scanNowReport )
        {
            DocumentReport userU50Graph = new DocumentReport();
            userU50Graph.Parent = this.axTabControlStock;

            iIndex++;
            this.axTabControlStock.InsertItem( iIndex, scanNowReport.Name, userU50Graph.Handle.ToInt32(), 0 );

            m_ScanNowReport.Add( scanNowReport, userU50Graph );
        }

        private void Timer1_Tick( object sender, EventArgs e )
        {

            foreach ( var item in m_ScanNowReportList )
            {
                if ( item.IsOK == true )
                {
                    DocumentReport outDocumentReport = null;
                    if ( m_ScanNowReport.TryGetValue( item, out outDocumentReport ) == false )
                    {
                        item.IsShowOK = false;
                        item.IsAddShowOK = false;
                    }

                    if ( item.IsShowOK == false )
                    {
                        item.IsShowOK = true;
                        AddReport( item );
                    }

                    if ( item.IsAddShowOK == false )
                    {
                        item.IsAddShowOK = true;

                        if ( m_ScanNowReport.TryGetValue( item, out outDocumentReport ) == true )
                        {
                            outDocumentReport.Init( item.ReportInfo );
                        }
                    }
                }
                else
                {
                    if ( item.IsShowOK == true )
                        continue;
                    else
                    {
                        AddReport( item );
                        item.IsShowOK = true;
                    }
                }
            }
        }

        private void DocumentForm1_FormClosing( object sender, FormClosingEventArgs e )
        {
            this.Timer1.Enabled = false;
        }

        //private void CreateTabControl()
        //{
        //    DocumentReport userU50Graph = new DocumentReport();
        //    userU50Graph.Parent = this.axTabControlStock;

        //    this.axTabControlStock.InsertItem( 0, "报表01", userU50Graph.Handle.ToInt32(), 0 );


        //    userU50Graph = new DocumentReport();
        //    userU50Graph.Parent = this.axTabControlStock;

        //    this.axTabControlStock.InsertItem( 1, "报表02", userU50Graph.Handle.ToInt32(), 0 );


        //    userU50Graph = new DocumentReport();
        //    userU50Graph.Parent = this.axTabControlStock;

        //    this.axTabControlStock.InsertItem( 2, "报表03", userU50Graph.Handle.ToInt32(), 0 );
        //}
    }
}
