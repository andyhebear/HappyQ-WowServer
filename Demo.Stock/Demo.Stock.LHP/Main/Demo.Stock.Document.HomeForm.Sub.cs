using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Demo.Stock.LHP.Main
{
    public partial class HomeControlSub : UserControl
    {
        public HomeControlSub()
        {
            InitializeComponent();
        }

        private void HomeControlSub_Load( object sender, EventArgs e )
        {
            //StreamReader sr = new StreamReader( "Demo.Stock.Resource\\StartPage.xaml" );
            //axLabel.Caption = sr.ReadToEnd();
            //sr.Close();
        }
    }
}
