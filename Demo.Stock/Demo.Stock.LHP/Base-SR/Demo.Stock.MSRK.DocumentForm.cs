using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.LHP.BaseSR
{
    public partial class DocumentMSRKForm : Form
    {
        private Dictionary<ListViewItem, UserControl> m_AllDocumenInfo = new Dictionary<ListViewItem, UserControl>();

        private UserControl m_CurrentDocumen = null;

        DocumentMSRKControl m_DocumentMSRKControl1 = null;

        public DocumentMSRKForm()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            m_DocumentMSRKControl1 = new DocumentMSRKControl();
            m_DocumentMSRKControl1.Dock = DockStyle.Fill;
            this.SplitContainer.Panel2.Controls.Add( m_DocumentMSRKControl1 );

            m_CurrentDocumen = m_DocumentMSRKControl1;

            //this.axTabControl.InsertItem( 0, "静态SR初级报表", m_DocumentFormSub1.Handle.ToInt32(), 0 );
        }

        private bool m_IsInitializing = false;
        private void DocumentMSRKForm_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            Initialize();
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
