using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;
using Demo.Stock.LHP.Main.Common;

namespace Demo.Stock.LHP.Main
{
    public partial class OptionControlSub1 : UserControl
    {
        public OptionControlSub1()
        {
            InitializeComponent();
        }

        private void OptionControlSub1_Load( object sender, EventArgs e )
        {

        }

        public OptionFormInfo.GeneralInfo GetGeneralInfo()
        {
            return new OptionFormInfo.GeneralInfo();
        }

        public void SetGeneralInfo( OptionFormInfo.GeneralInfo generalInfo )
        {
        }
    }
}
