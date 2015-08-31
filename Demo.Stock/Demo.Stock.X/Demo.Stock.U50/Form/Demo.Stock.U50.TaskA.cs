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
    public partial class TaskAControl : UserControl
    {
        public TaskAControl()
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

        public void ButtonNewTask_Click( object sender, EventArgs e )
        {
            if ( NewTaskInfo != null )
                NewTaskInfo();
        }

        public event EventHandlerNone NewTaskInfo;
    }
}
