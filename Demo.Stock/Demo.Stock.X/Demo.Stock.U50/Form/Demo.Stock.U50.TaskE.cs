using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.X.U50.Common;

namespace Demo.Stock.X.U50
{
    public partial class TaskEControl : UserControl
    {
        private U50StockInfo[] m_StockInfoArray = new U50StockInfo[0];

        public TaskEControl()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged( EventArgs eventArgs )
        {
            base.OnVisibleChanged( eventArgs );

            if ( this.Visible == true )
            {
                MainForm.Instance.AxSkinFramework.ApplyWindow( this.Handle.ToInt32() );
                this.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            }
        }

        public void SetConfigPolicy( U50Result policy )
        {

        }

        public U50Result GetTaskResult()
        {
            U50Result configPolicy = new U50Result();

            //configPolicy.StockInfo = m_StockInfoArray;

            return configPolicy;
        }
    }
}
