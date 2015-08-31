using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeCommandBars;
using Microsoft.Win32;
using System.IO;
using Demo.Stock.X.Common;

namespace Demo.Stock.X
{
    public partial class ConfigAControl : UserControl
    {
        private bool m_IsInitializing = false;

        public ConfigAControl()
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

        private void ConfigAControl_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            MainForm.Instance.AxCommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler( axCommandBars_Execute );
        }

        private string GetRegistryOpenFilePath()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.X" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "OptionForm" );
            RegistryKey rkey5 = rkey4.CreateSubKey( "ConfigForm" );

            string strFullPath = (string)rkey5.GetValue( "ConfigAControl.OpenFilePath", "" );

            rkey5.Close();
            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();

            return strFullPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void SetRegistryOpenFilePath( string strFullPath )
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.X" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "OptionForm" );
            RegistryKey rkey5 = rkey4.CreateSubKey( "ConfigForm" );

            rkey5.SetValue( "ConfigAControl.OpenFilePath", strFullPath, RegistryValueKind.String );

            rkey5.Close();
            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }

        private void ButtonAdd_Click( object sender, EventArgs eventArgs )
        {
            this.FolderBrowserDialog.SelectedPath = GetRegistryOpenFilePath();

            if ( this.FolderBrowserDialog.ShowDialog( MainForm.Instance.AxSkinFramework ) == DialogResult.OK )
            {
                SetRegistryOpenFilePath( this.FolderBrowserDialog.SelectedPath );

                MSFL.MSFLSecurityInfo[] msflSecurityInfoArray = null;

                if ( GlobalSetting.TryLoadMsflSecurityInfo( this.FolderBrowserDialog.SelectedPath, out msflSecurityInfoArray ) == true )
                {
                    ConfigASubForm configASubForm = new ConfigASubForm( msflSecurityInfoArray );

                    if ( configASubForm.ShowDialog() == DialogResult.OK )
                    {
                        msflSecurityInfoArray = configASubForm.ToSecurityInfo();

                        for ( int iIndex = 0; iIndex < msflSecurityInfoArray.Length; iIndex++ )
                        {
                            MSFL.MSFLSecurityInfo msflSecurityInfo = msflSecurityInfoArray[iIndex];
                            string securityInfo = GlobalSetting.GetStockCode( msflSecurityInfo.szName, msflSecurityInfo.szSymbol );

                            ListViewItem listViewItem = new ListViewItem( msflSecurityInfo.szName );
                            ListViewItem.ListViewSubItem listViewSubItem1 = new ListViewItem.ListViewSubItem( listViewItem, msflSecurityInfo.szSymbol );
                            ListViewItem.ListViewSubItem listViewSubItem2 = new ListViewItem.ListViewSubItem( listViewItem, this.FolderBrowserDialog.SelectedPath );

                            listViewItem.SubItems.Add( listViewSubItem1 );
                            listViewItem.SubItems.Add( listViewSubItem2 );

                            bool bIsOK = true;
                            foreach ( ListViewItem item in this.ListView.Items )
                            {
                                string securityInfo2 = GlobalSetting.GetStockCode( item.Text, item.SubItems[1].Text );

                                if ( securityInfo == securityInfo2 )
                                {
                                    bIsOK = false;
                                    break;
                                }
                            }

                            if ( bIsOK == true )
                                this.ListView.Items.Add( listViewItem );
                            else
                                MainForm.ShowPopupMessage( securityInfo, "已经存在" );
                        }

                        if ( ButtonSaveChanged != null )
                            ButtonSaveChanged( this, EventArgs.Empty );
                    }
                }
                else
                    MainForm.ShowPopupMessage( "尝试读取股票信息失败", "可能不是MetaStock数据的存放位置" );
            }
        }

        private void ContextMenuStripDelete_Opening( object sender, CancelEventArgs eventArgs )
        {
            eventArgs.Cancel = true;

            if ( this.ButtonAdd.Enabled == false )
                return;

            ListViewHitTestInfo listViewHitTestInfo  = this.ListView.HitTest( this.ListView.PointToClient( Cursor.Position ) );

            if ( listViewHitTestInfo == null )
                return;

            if ( listViewHitTestInfo.Item == null )
                return;

            if ( this.ListView.SelectedItems.Contains( listViewHitTestInfo.Item ) == false )
                return;

            if ( listViewHitTestInfo.Location != ListViewHitTestLocations.Label )
                return;

            CommandBar popupCommandBar = MainForm.Instance.AxCommandBars.Add( "ConfigAControl", XTPBarPosition.xtpBarPopup );

            CommandBarControl commandBarControl = popupCommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_CONFIGA_CONTROL_LISTVIEW_DELETE, "删除(&D)", -1, false );

            popupCommandBar.ShowPopup( XTPTrackPopupFlags.TPM_RIGHTBUTTON, null, null );
        }

        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case ResourceId.ID_CONFIGA_CONTROL_LISTVIEW_DELETE:

                    if ( this.ListView.SelectedIndices.Count <= 0 )
                        break;

                    int iIndex = 0;
                    foreach ( int indexListView in this.ListView.SelectedIndices )
                    {
                        ListView.Items.RemoveAt( indexListView - iIndex );
                        iIndex++;
                    }

                    if ( ButtonSaveChanged != null )
                        ButtonSaveChanged( this, EventArgs.Empty );

                    break;
                default:

                    break;
            }
        }

        private void ListView_SelectedIndexChanged( object sender, EventArgs e )
        {
            ListViewHitTestInfo listViewHitTestInfo = this.ListView.HitTest( this.ListView.PointToClient( Cursor.Position ) );

            if ( listViewHitTestInfo == null )
                return;

            if ( listViewHitTestInfo.Item == null )
                return;

            if ( this.ListView.SelectedItems.Contains( listViewHitTestInfo.Item ) == false )
                return;

            if ( listViewHitTestInfo.Location != ListViewHitTestLocations.Label )
                return;

            StockInfo stockInfo = new StockInfo();

            StockInfo.LoadFileFormatForDStock( listViewHitTestInfo.Item.Text, ref stockInfo );

            string strStockeInfo = "股票的详细信息：                                            ";
            strStockeInfo += string.Format( "股票的代码 - {0}                                     ", stockInfo.StockCode );
            strStockeInfo += string.Format( "股票的全称 - {0}", stockInfo.StockName );

            this.LabelStockeInfo.Text = strStockeInfo;
        }

        public event EventHandler ButtonSaveChanged;
    }
}
