using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Demo_G.O.S.E.HardwareID.Tool
{
    public partial class HardwareIDForm : Form
    {
        public HardwareIDForm()
        {
            InitializeComponent();

            // We make the following call to allow testing in an unprotected state.
            // "LoadWinlicenseDll" will set up the environment variables with your custom valued in WinlicenseSDK.ini
            // NOTE: In your release version, before protecting, you have to REMOVE this call!!!

//#if _DEBUG_MODE_
//            WinlicenseSDK.WLLoadWinlicenseDll();
//#endif

            //CheckSerialNumber.Init( "Password.Key" );
        }

        private void HardwareIDButton_Click( object sender, EventArgs eventArgs )
        {
            if ( this.NameInfoTextBox.Text == string.Empty )
            {
                MessageBox.Show( "请填写你需要注册的名称信息。", "DemoSoft" );
                return;
            }

            if ( this.CompanyInfoTextBox.Text == string.Empty )
            {
                MessageBox.Show( "请填写你需要注册的公司/组织/社团的信息。", "DemoSoft" );
                return;
            }

            if ( this.CustomInfoRichTextBox.Text == string.Empty )
            {
                if ( MessageBox.Show( "你可以填写一些对软件改进的建议或其它的信息，你是否想继续填写完需求信息。", "DemoSoft", MessageBoxButtons.YesNo ) == DialogResult.Yes )
                    return;
            }

            StreamWriter streamWriter = File.CreateText( "HardwareID.txt" );

            StringBuilder strFileInfo = new StringBuilder();
            strFileInfo.Append( "NameInfo: " );
            strFileInfo.Append( this.NameInfoTextBox.Text );
            streamWriter.WriteLine( strFileInfo.ToString() );
            streamWriter.WriteLine( string.Empty );

            strFileInfo.Length = 0;
            strFileInfo.Append( "CompanyInfo: " );
            strFileInfo.Append( this.CompanyInfoTextBox.Text );
            streamWriter.WriteLine( strFileInfo.ToString() );
            streamWriter.WriteLine( string.Empty );

            strFileInfo.Length = 0;
            strFileInfo.Append( "CustomInfo: " );
            strFileInfo.Append( this.CustomInfoRichTextBox.Text );
            streamWriter.WriteLine( strFileInfo.ToString() );
            streamWriter.WriteLine( string.Empty );

            strFileInfo.Length = 0;
            strFileInfo.Append( "CHardwareIDInfo: " );
            StringBuilder strHardwarID = new StringBuilder( 100 );
            Kernel32.GetEnvironmentVariable( "WLHardwareGetID", strHardwarID, 100 );
            strFileInfo.Append( strHardwarID.ToString() );
            streamWriter.Write( strFileInfo.ToString() );

            MessageBox.Show( "硬件唯一序号已写入 HardwareID.txt" );

            streamWriter.Close();
        }
    }

    /// <summary>
    /// Class: WinlicenseSDK
    /// Description: Wrapper for the Winlicense SDK APIs
    /// </summary>
    class WinlicenseSDK
    {
        [DllImport( "WinlicenseSDK.dll", EntryPoint = "WLLoadWinlicenseDll", CallingConvention = CallingConvention.StdCall )]
        public static extern void WLLoadWinlicenseDll();
    }
}