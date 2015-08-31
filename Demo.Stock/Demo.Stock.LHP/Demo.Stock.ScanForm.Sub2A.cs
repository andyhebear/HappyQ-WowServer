using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.LHP
{
    public partial class ScanControlSub2A : UserControl
    {
        //ScanControlSub2AGeneral m_ScanControlSub2AGeneral = null;
        //ScanControlSub2ADown m_ScanControlSub2ADown = null;
        //ScanControlSub2AUp m_ScanControlSub2AUp = null;

        public ScanControlSub2A()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            //m_ScanControlSub2AGeneral = new ScanControlSub2AGeneral();
            //m_ScanControlSub2AGeneral.Parent = this.axTabControl;

            //this.axTabControl.InsertItem( 0, "常规", m_ScanControlSub2AGeneral.Handle.ToInt32(), 0 );

            //m_ScanControlSub2AUp = new ScanControlSub2AUp();
            //m_ScanControlSub2AUp.Parent = this.axTabControl;

            //this.axTabControl.InsertItem( 0, "上升趋势", m_ScanControlSub2AUp.Handle.ToInt32(), 0 );

            //m_ScanControlSub2ADown = new ScanControlSub2ADown();
            //m_ScanControlSub2ADown.Parent = this.axTabControl;

            //this.axTabControl.InsertItem( 1, "下跌趋势", m_ScanControlSub2ADown.Handle.ToInt32(), 0 );
        }

        private void ScanControlSub2A_Load( object sender, EventArgs e )
        {

        }
    }
}
