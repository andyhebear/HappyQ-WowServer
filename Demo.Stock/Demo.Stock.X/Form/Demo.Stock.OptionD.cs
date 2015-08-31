using System;
using System.Windows.Forms;

namespace Demo.Stock.X
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OptionDControl : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public OptionDControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnVisibleChanged( EventArgs eventArgs )
        {
            base.OnVisibleChanged( eventArgs );

            if ( this.Visible == true )
            {
                MainForm.Instance.AxSkinFramework.ApplyWindow( this.Handle.ToInt32() );
                this.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            }
        }
    }
}
