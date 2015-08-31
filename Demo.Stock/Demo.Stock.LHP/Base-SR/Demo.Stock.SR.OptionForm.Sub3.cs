using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;
using Microsoft.Win32;
using Demo.Stock.LHP.Main;

namespace Demo.Stock.LHP.BaseSR
{
    public partial class SRControlSub3 : UserControl
    {
        List<ListViewItem> m_ListDelete = new List<ListViewItem>();
        List<ListViewItem> m_ListAdd = new List<ListViewItem>();

        public SRControlSub3()
        {
            InitializeComponent();
        }

        private bool m_IsInitializing = false;
        private void ScanPrimaryControlSub3_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            radioButtonGlobal_CheckedChanged( this, EventArgs.Empty );
            radioButtonCustom_CheckedChanged( this, EventArgs.Empty );

            MainForm.Instance.axCommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler( axCommandBars_Execute );
        }

        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case Demo.Stock.LHP.ResourceId.ID_SR_CONFIG_FORM_DELETE:

                    if ( this.ListViewStock.SelectedIndices.Count <= 0 )
                        break;

                    int iIndex = 0;
                    foreach ( int indexListView in this.ListViewStock.SelectedIndices )
                    {
                        m_ListDelete.Add( this.ListViewStock.Items[indexListView - iIndex] );
                        this.ListViewStock.Items.RemoveAt( indexListView - iIndex );
                        iIndex++;
                    }

                    if ( ButtonSaveChanged != null )
                        ButtonSaveChanged( this, EventArgs.Empty );

                    break;
                default:

                    break;
            }
        }

        private void radioButtonGlobal_CheckedChanged( object sender, EventArgs e )
        {
            if ( radioButtonGlobal.Checked == true)
            {
                this.ListViewStock.Enabled = false;

                this.ButtonLoad.Enabled = false;
                this.ButtonSave.Enabled = false;

                this.ButtonAdd.Enabled = false;
            }
        }

        private void radioButtonCustom_CheckedChanged( object sender, EventArgs e )
        {
            if ( radioButtonCustom.Checked == true )
            {
                this.ListViewStock.Enabled = true;

                this.ButtonLoad.Enabled = true;
                this.ButtonSave.Enabled = true;

                this.ButtonAdd.Enabled = true;
            }
        }
        public StockFileInfo[] GetStockFileInfos()
        {
            List<StockFileInfo> stockFileInfoList = new List<StockFileInfo>();

            for ( int iIndex = 0; iIndex < this.ListViewStock.Items.Count; iIndex++ )
            {
                ListViewItem listViewItem = this.ListViewStock.Items[iIndex];

                StockFileInfo stockFileInfo = new StockFileInfo();
                stockFileInfo.StockName = listViewItem.Text;
                stockFileInfo.StockSymbol = listViewItem.SubItems[1].Text;
                stockFileInfo.StockFilePath = listViewItem.SubItems[2].Text;

                stockFileInfoList.Add( stockFileInfo );
            }

            return stockFileInfoList.ToArray();
        }

        public void SetStockFileInfos( StockFileInfo[] stockFileInfoArray )
        {
            for ( int iIndex = 0; iIndex < stockFileInfoArray.Length; iIndex++ )
            {
                StockFileInfo stockFileInfo = stockFileInfoArray[iIndex];
                string securityInfo = GlobalSetting.GetStockCode( stockFileInfo.StockName, stockFileInfo.StockSymbol );

                ListViewItem listViewItem = new ListViewItem( stockFileInfo.StockName );
                ListViewItem.ListViewSubItem listViewSubItem1 = new ListViewItem.ListViewSubItem( listViewItem, stockFileInfo.StockSymbol );
                ListViewItem.ListViewSubItem listViewSubItem2 = new ListViewItem.ListViewSubItem( listViewItem, stockFileInfo.StockFilePath );

                listViewItem.SubItems.Add( listViewSubItem1 );
                listViewItem.SubItems.Add( listViewSubItem2 );

                bool bIsOK = true;
                foreach ( ListViewItem item in this.ListViewStock.Items )
                {
                    string securityInfo2 = GlobalSetting.GetStockCode( item.Text, item.SubItems[1].Text );

                    if ( securityInfo == securityInfo2 )
                    {
                        bIsOK = false;
                        break;
                    }
                }

                if ( bIsOK == true )
                    this.ListViewStock.Items.Add( listViewItem );
            }
        }

        private string GetRegistryOpenFilePath_Open()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.LHP" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "SR.OptionForm" );

            string strFullPath = (string)rkey4.GetValue( "OptionControlSub2.OpenFilePath_Open", "" );

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
        private void SetRegistryOpenFilePath_Open( string strFullPath )
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.LHP" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "SR.OptionForm" );

            rkey4.SetValue( "OptionControlSub2.OpenFilePath_Open", strFullPath, RegistryValueKind.String );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }

        private void ButtonLoad_Click( object sender, EventArgs e )
        {
            //this.OpenFileDialogStock.InitialDirectory = GetRegistryOpenFilePath_Open();

            if ( this.OpenFileDialogStock.ShowDialog() == DialogResult.OK )
            {
                //SetRegistryOpenFilePath_Open( this.OpenFileDialogStock.InitialDirectory );

                StockFileInfo[] stockFileInfoArray = GlobalSetting.LoadConfigSetting( this.OpenFileDialogStock.FileName );

                this.SetStockFileInfos( stockFileInfoArray );

                //if ( ButtonSaveChanged != null )
                //    ButtonSaveChanged( this, EventArgs.Empty );
            }

        }

        private string GetRegistryOpenFilePath_Save()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.LHP" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "SR.OptionForm" );

            string strFullPath = (string)rkey4.GetValue( "OptionControlSub2.OpenFilePath_Save", "" );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();

            return strFullPath;
        }

        private void SetRegistryOpenFilePath_Save( string strFullPath )
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.LHP" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "SR.OptionForm" );

            rkey4.SetValue( "OptionControlSub2.OpenFilePath_Save", strFullPath, RegistryValueKind.String );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }

        private void ButtonSave_Click( object sender, EventArgs e )
        {
            this.SaveFileDialogStock.InitialDirectory = GetRegistryOpenFilePath_Save();

            if ( this.SaveFileDialogStock.ShowDialog() == DialogResult.OK )
            {
                SetRegistryOpenFilePath_Save( this.SaveFileDialogStock.InitialDirectory );

                StockFileInfo[] stockFileInfoArray = this.GetStockFileInfos();

                GlobalSetting.SaveConfigSetting( this.SaveFileDialogStock.FileName, stockFileInfoArray );
            }
        }

        private string GetRegistryOpenFilePath()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.LHP" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "SR.OptionForm" );

            string strFullPath = (string)rkey4.GetValue( "OptionControlSub2.OpenFilePath", "" );

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
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.LHP" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "SR.OptionForm" );

            rkey4.SetValue( "OptionControlSub2.OpenFilePath", strFullPath, RegistryValueKind.String );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }

        private void ButtonAdd_Click( object sender, EventArgs e )
        {
            this.FolderBrowserDialog.SelectedPath = GetRegistryOpenFilePath();

            if ( this.FolderBrowserDialog.ShowDialog() == DialogResult.OK )
            {
                SetRegistryOpenFilePath( this.FolderBrowserDialog.SelectedPath );

                MSFL.MSFLSecurityInfo[] msflSecurityInfoArray = null;

                if ( GlobalSetting.TryLoadMsflSecurityInfo( this.FolderBrowserDialog.SelectedPath, out msflSecurityInfoArray ) == true )
                {
                    OptionSub2From configASubForm = new OptionSub2From( msflSecurityInfoArray );

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
                            foreach ( ListViewItem item in this.ListViewStock.Items )
                            {
                                string securityInfo2 = GlobalSetting.GetStockCode( item.Text, item.SubItems[1].Text );

                                if ( securityInfo == securityInfo2 )
                                {
                                    bIsOK = false;
                                    break;
                                }
                            }

                            if ( bIsOK == true )
                            {
                                m_ListAdd.Add( listViewItem );
                                this.ListViewStock.Items.Add( listViewItem );
                            }
                            else
                                //MainForm.ShowPopupMessage( securityInfo, "已经存在" );
                                MessageBox.Show( securityInfo, "已经存在" );
                        }

                        if ( ButtonSaveChanged != null )
                            ButtonSaveChanged( this, EventArgs.Empty );
                    }
                }
                else
                    //MainForm.ShowPopupMessage( "尝试读取股票信息失败", "可能不是MetaStock数据的存放位置" );
                    MessageBox.Show( "尝试读取股票信息失败", "可能不是MetaStock数据的存放位置" );
            }
        }

        internal void ButtonOK()
        {
            m_ListDelete.Clear();
            m_ListAdd.Clear();
        }

        internal void ButtonCancel()
        {
            foreach ( ListViewItem listViewItem in m_ListDelete )
            {
                if ( this.ListViewStock.Items.Contains( listViewItem ) == false )
                    this.ListViewStock.Items.Add( listViewItem );
            }

            foreach ( ListViewItem listViewItem in m_ListAdd )
            {
                if ( this.ListViewStock.Items.Contains( listViewItem ) == true )
                    this.ListViewStock.Items.Remove( listViewItem );
            }
        }

        private void contextMenuStrip_Opening( object sender, CancelEventArgs eventArgs )
        {
            eventArgs.Cancel = true;

            if ( this.ButtonAdd.Enabled == false )
                return;

            ListViewHitTestInfo listViewHitTestInfo = this.ListViewStock.HitTest( this.ListViewStock.PointToClient( Cursor.Position ) );

            if ( listViewHitTestInfo == null )
                return;

            if ( listViewHitTestInfo.Item == null )
                return;

            if ( this.ListViewStock.SelectedItems.Contains( listViewHitTestInfo.Item ) == false )
                return;

            if ( listViewHitTestInfo.Location != ListViewHitTestLocations.Label )
                return;

            XtremeCommandBars.CommandBar popupCommandBar = MainForm.Instance.axCommandBars.Add( "ConfigAControl", XtremeCommandBars.XTPBarPosition.xtpBarPopup );

            XtremeCommandBars.CommandBarControl commandBarControl = popupCommandBar.Controls.Add( XtremeCommandBars.XTPControlType.xtpControlButton, Demo.Stock.LHP.ResourceId.ID_SR_CONFIG_FORM_DELETE, "删除(&D)", -1, false );

            popupCommandBar.ShowPopup( XtremeCommandBars.XTPTrackPopupFlags.TPM_RIGHTBUTTON, null, null );
        }

        public event EventHandler ButtonSaveChanged;
    }
}
