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
    public partial class ScanControlSub2D : UserControl
    {
        ScanControlSub2DTrendFunction m_ScanControlSub2DTrendFunction = null;
        ScanControlSub2DTrendGroup m_ScanControlSub2DTrendGroup = null;

        public ScanControlSub2D()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            m_ScanControlSub2DTrendFunction = new ScanControlSub2DTrendFunction();
            m_ScanControlSub2DTrendFunction.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 0, "趋势函数设定", m_ScanControlSub2DTrendFunction.Handle.ToInt32(), 0 );


            m_ScanControlSub2DTrendGroup = new ScanControlSub2DTrendGroup();
            m_ScanControlSub2DTrendGroup.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 1, "趋势群过滤", m_ScanControlSub2DTrendGroup.Handle.ToInt32(), 0 );
        }

        private void ScanControlSub2D_Load( object sender, EventArgs e )
        {
        }
    }
}
