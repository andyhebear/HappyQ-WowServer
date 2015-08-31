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
    public partial class ScanControlSub3 : UserControl
    {
        ScanControlSub3A m_ScanControlSub3A = null;
        ScanControlSub3B m_ScanControlSub3B = null;
        ScanControlSub3C m_ScanControlSub3C = null;
        ScanControlSub3D m_ScanControlSub3D = null;
        ScanControlSub3E m_ScanControlSub3E = null;
       
        public ScanControlSub3()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            m_ScanControlSub3A = new ScanControlSub3A();
            m_ScanControlSub3A.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 0, "静态SR点刷选", m_ScanControlSub3A.Handle.ToInt32(), 0 );

            m_ScanControlSub3B = new ScanControlSub3B();
            m_ScanControlSub3B.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 1, "趋势线群(动态SR点)刷选", m_ScanControlSub3B.Handle.ToInt32(), 0 );

            m_ScanControlSub3C = new ScanControlSub3C();
            m_ScanControlSub3C.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 2, "当前K线参数刷选", m_ScanControlSub3C.Handle.ToInt32(), 0 );


            m_ScanControlSub3D = new ScanControlSub3D();
            m_ScanControlSub3D.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 3, "SRCK价格比较", m_ScanControlSub3D.Handle.ToInt32(), 0 );

            m_ScanControlSub3E = new ScanControlSub3E();
            m_ScanControlSub3E.Parent = this.axTabControl;

            this.axTabControl.InsertItem( 4, "其它参数刷选", m_ScanControlSub3E.Handle.ToInt32(), 0 );
        }

        private void checkBox7_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void radioButton5_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void radioButton3_CheckedChanged( object sender, EventArgs e )
        {

        }
    }
}
