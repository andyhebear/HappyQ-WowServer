using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.X.Common;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Demo.Stock.X.Tools
{
    public partial class MSFLViewForm : Form
    {
        public MSFLViewForm()
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

        private void MSFLViewForm_Load( object sender, EventArgs e )
        {
            this.ListViewSecurity.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler( ListViewSecurity_RetrieveVirtualItemEventHandler );
            this.ListViewPrice.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler( ListViewPrice_RetrieveVirtualItemEventHandler );
        }

        private void MSFLViewForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( m_DirNumber != 0 )
            {
                MSFL.MSFL1_CloseDirectory( m_DirNumber );

                this.ListViewSecurity.Items.Clear();
                this.ListViewPrice.Items.Clear();
                m_SecurityDictionary.Clear();

                m_DirNumber = 0;
            }
        }

        private byte m_DirNumber = 0;
        private Dictionary<ListViewItem, IntPtr> m_SecurityDictionary = new Dictionary<ListViewItem, IntPtr>();

        private ListViewItem[] m_SecurityArray = new ListViewItem[0];
        private void OpenToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( this.FolderBrowserDialogView.ShowDialog() != DialogResult.OK )
                return;

            if ( m_DirNumber != 0 )
            {
                MSFL.MSFL1_CloseDirectory( m_DirNumber );

                this.ListViewSecurity.VirtualListSize = 0;
                this.ListViewSecurity.Items.Clear();
                this.ListViewPrice.VirtualListSize = 0;
                this.ListViewPrice.Items.Clear();
                m_SecurityDictionary.Clear();

                m_DirNumber = 0;
            }

            int iErr = MSFL.MSFL1_OpenDirectory( this.FolderBrowserDialogView.SelectedPath, ref m_DirNumber, MSFL.MSFL_DIR_FORCE_USER_IN );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return;

            MSFL.MSFLDirectoryStatus msflDirectoryStatus = new MSFL.MSFLDirectoryStatus();
            msflDirectoryStatus.dwTotalSize = (uint)Marshal.SizeOf( msflDirectoryStatus );

            iErr = MSFL.MSFL1_GetDirectoryStatus( m_DirNumber, string.Empty, ref msflDirectoryStatus );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return;

            //MSFL.DisplayMSFLError( iErr );

            MSFL.MSFLSecurityInfo msflSecurityInfo = new MSFL.MSFLSecurityInfo();
            msflSecurityInfo.dwTotalSize = (uint)Marshal.SizeOf( msflSecurityInfo );

            List<ListViewItem> listViewItemList = new List<ListViewItem>( 2048 );

            if ( msflDirectoryStatus.bExists &&         // if it exists
                msflDirectoryStatus.bOpen &&            // AND if it's open
                msflDirectoryStatus.bMetaStockDir )     // AND if it's a MetaStock directory...
            {
                StringBuilder dateString = new StringBuilder( MSFL.MSFL_MAX_NAME_LENGTH + 1 );

                iErr = MSFL.MSFL1_GetFirstSecurityInfo( m_DirNumber, ref msflSecurityInfo );
                while ( iErr == (int)MSFL.MSFL_ERR.MSFL_NO_ERR || iErr == (int)MSFL.MSFL_Messages.MSFL_MSG_LAST_SECURITY_IN_DIR )
                {
                    ListViewItem listViewItem = new ListViewItem(msflSecurityInfo.szName);
                    ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem( listViewItem, msflSecurityInfo.szSymbol );
                    ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem( listViewItem, msflSecurityInfo.cPeriodicity.ToString() );

                    iErr = MSFL.MSFL1_FormatDate( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lFirstDate );
                    ListViewItem.ListViewSubItem subListViewItem3 = new ListViewItem.ListViewSubItem( listViewItem, dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatDate( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lLastDate );
                    ListViewItem.ListViewSubItem subListViewItem4 = new ListViewItem.ListViewSubItem( listViewItem, dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatTime( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lFirstTime, true );
                    ListViewItem.ListViewSubItem subListViewItem5 = new ListViewItem.ListViewSubItem( listViewItem, dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatTime( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lLastTime, true );
                    ListViewItem.ListViewSubItem subListViewItem6 = new ListViewItem.ListViewSubItem( listViewItem, dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatTime( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lStartTime, false );
                    ListViewItem.ListViewSubItem subListViewItem7 = new ListViewItem.ListViewSubItem( listViewItem, dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatTime( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lEndTime, false );
                    ListViewItem.ListViewSubItem subListViewItem8 = new ListViewItem.ListViewSubItem( listViewItem, dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatDate( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lCollectionDate );
                    ListViewItem.ListViewSubItem subListViewItem9 = new ListViewItem.ListViewSubItem( listViewItem, dateString.ToString() );

                    listViewItem.SubItems.Add( subListViewItem1 );
                    listViewItem.SubItems.Add( subListViewItem2 );
                    listViewItem.SubItems.Add( subListViewItem3 );
                    listViewItem.SubItems.Add( subListViewItem4 );
                    listViewItem.SubItems.Add( subListViewItem5 );
                    listViewItem.SubItems.Add( subListViewItem6 );
                    listViewItem.SubItems.Add( subListViewItem7 );
                    listViewItem.SubItems.Add( subListViewItem8 );
                    listViewItem.SubItems.Add( subListViewItem9 );

                    m_SecurityDictionary.Add( listViewItem, msflSecurityInfo.hSecurity );

                    //this.ListViewSecurity.Items.Add( listViewItem );
                    listViewItemList.Add( listViewItem );

                    if ( iErr == (int)MSFL.MSFL_Messages.MSFL_MSG_LAST_SECURITY_IN_DIR )
                        break;

                    iErr = MSFL.MSFL1_GetNextSecurityInfo( msflSecurityInfo.hSecurity, ref msflSecurityInfo );
                }

                m_SecurityArray = listViewItemList.ToArray();
                this.ListViewSecurity.VirtualListSize = m_SecurityArray.Length;
            }
        }

        private void ListViewSecurity_RetrieveVirtualItemEventHandler( object sender, RetrieveVirtualItemEventArgs e )
        {
            e.Item = m_SecurityArray[e.ItemIndex];
        }

        private ListViewItem[] m_PriceArray = new ListViewItem[0];
        private void ListViewSecurity_SelectedIndexChanged( object sender, EventArgs e )
        {
            Point cursorPoint = this.ListViewSecurity.PointToClient( Cursor.Position );
            ListViewItem listViewItem = this.ListViewSecurity.GetItemAt( cursorPoint.X, cursorPoint.Y );
            if ( listViewItem == null )
                return;
            else
            {
                this.ListViewPrice.VirtualListSize = 0;
                this.ListViewPrice.Items.Clear();
            }

            IntPtr hSecurity = IntPtr.Zero;
            if ( m_SecurityDictionary.TryGetValue( listViewItem, out hSecurity ) == false )
                return;

            int iErr = MSFL.MSFL1_LockSecurity( hSecurity, MSFL.MSFL_LOCK_PREV_WRITE_LOCK );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return;

            ushort wPriceRecCount = 0;
            iErr = MSFL.MSFL1_GetDataRecordCount( hSecurity, ref wPriceRecCount );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return;

            if ( wPriceRecCount > 0 )
            {
                iErr = MSFL.MSFL1_SeekBeginData( hSecurity );
                if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                    return;

                MSFL.DateTime sDateTime = new MSFL.DateTime();
                MSFL.MSFLPriceRecord[] pPriceRec = new MSFL.MSFLPriceRecord[wPriceRecCount];

                iErr = MSFL.MSFL2_ReadMultipleRecs( hSecurity, pPriceRec, ref sDateTime, ref wPriceRecCount, (int)MSFL.MSFL_FIND.MSFL_FIND_USE_CURRENT_POS );
                if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                    return;

                // Unlock the security (we're done using it)
                iErr = MSFL.MSFL1_UnlockSecurity( hSecurity );

                // numbers for summing price info
                float fOpenSum = 0.0f, fHighSum = 0.0f, fLowSum = 0.0f, fCloseSum = 0.0f, fVolumeSum = 0.0f, fOpenIntSum = 0.0f;

                List<ListViewItem> listViewItemList = new List<ListViewItem>( 2048 );
                
                StringBuilder szBuf = new StringBuilder( MSFL.MSFL_MAX_NAME_LENGTH + 1 );
                for ( int iIndex = 0; iIndex < pPriceRec.Length; iIndex++ )
                {
                    MSFL.MSFLPriceRecord msflPriceRecord  = pPriceRec[iIndex];

                    listViewItem = new ListViewItem();
                    if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_DATE ) == MSFL.MSFL_DATA_DATE )
                    {
                        MSFL.MSFL1_FormatDate( szBuf, (ushort)szBuf.Capacity, msflPriceRecord.lDate );
                        listViewItem.Text = szBuf.ToString();
                    }
                    else
                        listViewItem.Text = "N/A";

                    ListViewItem.ListViewSubItem subListViewItem1 = new ListViewItem.ListViewSubItem();
                    if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_TIME ) == MSFL.MSFL_DATA_TIME )
                    {
                        MSFL.MSFL1_FormatTime( szBuf, (ushort)szBuf.Capacity, msflPriceRecord.lTime, true );
                        subListViewItem1.Text = szBuf.ToString();
                    }
                    else
                        subListViewItem1.Text = "N/A";

                    ListViewItem.ListViewSubItem subListViewItem2 = new ListViewItem.ListViewSubItem();
                    if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_OPEN ) == MSFL.MSFL_DATA_OPEN )
                    {
                        fOpenSum += msflPriceRecord.fOpen;
                        subListViewItem2.Text = msflPriceRecord.fOpen.ToString( "0.00", CultureInfo.InvariantCulture );
                    }
                    else
                        subListViewItem2.Text = "N/A";

                    ListViewItem.ListViewSubItem subListViewItem3 = new ListViewItem.ListViewSubItem();
                    if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_HIGH ) == MSFL.MSFL_DATA_HIGH )
                    {
                        fHighSum += msflPriceRecord.fHigh;
                        subListViewItem3.Text = msflPriceRecord.fHigh.ToString( "0.00", CultureInfo.InvariantCulture );
                    }
                    else
                        subListViewItem3.Text = "N/A";

                    ListViewItem.ListViewSubItem subListViewItem4 = new ListViewItem.ListViewSubItem();
                    if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_LOW ) == MSFL.MSFL_DATA_LOW )
                    {
                        fLowSum += msflPriceRecord.fLow;
                        subListViewItem4.Text = msflPriceRecord.fLow.ToString( "0.00", CultureInfo.InvariantCulture );
                    }
                    else
                        subListViewItem4.Text = "N/A";

                    ListViewItem.ListViewSubItem subListViewItem5 = new ListViewItem.ListViewSubItem();
                    if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_CLOSE ) == MSFL.MSFL_DATA_CLOSE )
                    {
                        fCloseSum += msflPriceRecord.fClose;
                        subListViewItem5.Text = msflPriceRecord.fClose.ToString( "0.00", CultureInfo.InvariantCulture );
                    }
                    else
                        subListViewItem5.Text = "N/A";

                    ListViewItem.ListViewSubItem subListViewItem6 = new ListViewItem.ListViewSubItem();
                    if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_VOLUME ) == MSFL.MSFL_DATA_VOLUME )
                    {
                        fVolumeSum += msflPriceRecord.fVolume;
                        subListViewItem6.Text = msflPriceRecord.fVolume.ToString( "0.", CultureInfo.InvariantCulture );
                    }
                    else
                        subListViewItem6.Text = "N/A";

                    ListViewItem.ListViewSubItem subListViewItem7 = new ListViewItem.ListViewSubItem();
                    if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_OPENINT ) == MSFL.MSFL_DATA_OPENINT )
                    {
                        fOpenIntSum += msflPriceRecord.fOpenInt;
                        subListViewItem7.Text = msflPriceRecord.fOpenInt.ToString( "0.00", CultureInfo.InvariantCulture );
                    }
                    else
                        subListViewItem7.Text = "N/A";

                    listViewItem.SubItems.Add( subListViewItem1 );
                    listViewItem.SubItems.Add( subListViewItem2 );
                    listViewItem.SubItems.Add( subListViewItem3 );
                    listViewItem.SubItems.Add( subListViewItem4 );
                    listViewItem.SubItems.Add( subListViewItem5 );
                    listViewItem.SubItems.Add( subListViewItem6 );
                    listViewItem.SubItems.Add( subListViewItem7 );

                    //this.ListViewPrice.Items.Add( listViewItem );
                    listViewItemList.Add( listViewItem );
                }

                m_PriceArray = listViewItemList.ToArray();
                this.ListViewPrice.VirtualListSize = m_PriceArray.Length;
            }
        }

        private void ListViewPrice_RetrieveVirtualItemEventHandler( object sender, RetrieveVirtualItemEventArgs e )
        {
            e.Item = m_PriceArray[e.ItemIndex];
        }
    }
}
