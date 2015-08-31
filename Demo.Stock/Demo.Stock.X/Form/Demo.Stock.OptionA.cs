using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Demo.Stock.X
{
    public partial class OptionAControl : UserControl
    {
        public OptionAControl()
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

        private void TrackBarKLine_Scroll( object sender, EventArgs eventArgs )
        {
            this.NumericUpDownKLine.Value = this.TrackBarKLine.Value;
        }

        private void ButtonSetConfigFile_Click( object sender, EventArgs eventArgs )
        {
            if ( SetConfigFile != null )
                SetConfigFile();
        }

        #region zh-CHS 私有方法 | en Private Methods
        private string GetRegistryOpenFilePath()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.X" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "OptionForm" );

            string strFullPath = (string)rkey4.GetValue( "OptionAControl.OpenFilePath", "" );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();

            return strFullPath;
        }

        private void SetRegistryOpenFilePath( string strFullPath )
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.X" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "OptionForm" );

            rkey4.SetValue( "OptionAControl.OpenFilePath", strFullPath, RegistryValueKind.String );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }
        #endregion

        public event EventHandlerNone SetConfigFile;
    }

    public delegate bool EventHandlerChanged();
    public delegate void EventHandlerNone();
}
