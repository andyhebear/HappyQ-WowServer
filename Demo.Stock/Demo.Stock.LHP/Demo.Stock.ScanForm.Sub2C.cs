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
    public partial class ScanControlSub2C : UserControl
    {
        ScanControlSub2CSRPrice m_ScanControlSub2CSRPrice = null;
        ScanControlSub2CSRUpFiltrate m_ScanControlSub2CSRUpFiltrate = null;
        ScanControlSub2CSRDownFiltrate m_ScanControlSub2CSRDownFiltrate = null;

        public ScanControlSub2C()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            m_ScanControlSub2CSRPrice = new ScanControlSub2CSRPrice();
            m_ScanControlSub2CSRPrice.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 0, "静态SR价格点选择", m_ScanControlSub2CSRPrice.Handle.ToInt32(), 0 );


            m_ScanControlSub2CSRUpFiltrate = new ScanControlSub2CSRUpFiltrate();
            m_ScanControlSub2CSRUpFiltrate.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 1, "SR价格点上升刷选", m_ScanControlSub2CSRUpFiltrate.Handle.ToInt32(), 0 );

            m_ScanControlSub2CSRDownFiltrate = new ScanControlSub2CSRDownFiltrate();
            m_ScanControlSub2CSRDownFiltrate.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 2, "SR价格点下跌刷选", m_ScanControlSub2CSRDownFiltrate.Handle.ToInt32(), 0 );
        }

        private void ScanControlSub2C_Load( object sender, EventArgs e )
        {
        }
    }
}
