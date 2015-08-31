using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;
using XtremeCommandBars;

namespace Demo.Stock.LHP.Main
{
    public partial class OptionControlSub3 : UserControl
    {
        private bool m_IsCheckBoxScan = false;
        private Dictionary<ListViewItem, TriggerInfos.TriggerInfo> m_TriggerInfos = new Dictionary<ListViewItem, TriggerInfos.TriggerInfo>();
        private Dictionary<ListViewItem, TriggerInfos.TriggerInfo> m_AddTriggerInfos = new Dictionary<ListViewItem, TriggerInfos.TriggerInfo>();
        private Dictionary<ListViewItem, TriggerInfos.TriggerInfo> m_DeleteTriggerInfos = new Dictionary<ListViewItem, TriggerInfos.TriggerInfo>();

        public OptionControlSub3()
        {
            InitializeComponent();
        }

        private bool m_IsInitializing = false;
        private void OptionControlSub3_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            MainForm.Instance.axCommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler( axCommandBars_Execute );
        }

        private void ButtonNewScan_Click( object sender, EventArgs e )
        {
            OptionSub3From optionSub3From = new OptionSub3From();
            if ( optionSub3From.ShowDialog(this) == DialogResult.OK )
            {
                TriggerInfos.TriggerInfo triggerInfo = optionSub3From.GetTriggerInfo();

                ListViewItem listViewItem = new ListViewItem( triggerInfo.m_strTriggerName );

                ListViewItem.ListViewSubItem listViewSubItem = new ListViewItem.ListViewSubItem( listViewItem, triggerInfo.m_strStockFile );
                listViewItem.SubItems.Add( listViewSubItem );

                ListViewItem.ListViewSubItem listViewSubItem2 = new ListViewItem.ListViewSubItem( listViewItem, triggerInfo.m_strOpenSRFile );
                listViewItem.SubItems.Add( listViewSubItem2 );

                ListViewItem.ListViewSubItem listViewSubItem3 = new ListViewItem.ListViewSubItem( listViewItem, triggerInfo.m_strOpenUTMR_DTMSFile );
                listViewItem.SubItems.Add( listViewSubItem3 );

                m_TriggerInfos.Add( listViewItem, triggerInfo );
                m_AddTriggerInfos.Add( listViewItem, triggerInfo );
                this.ListViewScan.Items.Add( listViewItem );

                if ( ButtonSaveChanged != null )
                    ButtonSaveChanged( this, EventArgs.Empty );
            }
        }

        private void CheckBoxScan_CheckedChanged( object sender, EventArgs eventArgs )
        {
            this.ListViewScan.Enabled = this.CheckBoxScan.Checked;

            if ( ButtonSaveChanged != null )
                ButtonSaveChanged( this, EventArgs.Empty );
        }

        public TriggerInfos GetTriggerInfos()
        {
            TriggerInfos triggerInfos = new TriggerInfos();
            triggerInfos.m_AllowTrigger = this.CheckBoxScan.Checked;


            List<TriggerInfos.TriggerInfo> triggerInfoList = new List<TriggerInfos.TriggerInfo>();

            for ( int iIndex = 0; iIndex < this.ListViewScan.Items.Count; iIndex++ )
            {
                ListViewItem listViewItem = this.ListViewScan.Items[iIndex];

                TriggerInfos.TriggerInfo triggerInfo = null;
                if (m_TriggerInfos.TryGetValue(listViewItem, out triggerInfo) == true)
                    triggerInfoList.Add( triggerInfo );
            }

            triggerInfos.m_TriggerInfos = triggerInfoList.ToArray();

            return triggerInfos;
        }

        public void SetTriggerInfos( TriggerInfos triggerInfos )
        {
            m_TriggerInfos.Clear();

            m_IsCheckBoxScan = triggerInfos.m_AllowTrigger;
            this.CheckBoxScan.Checked = triggerInfos.m_AllowTrigger;
            this.ListViewScan.Enabled = triggerInfos.m_AllowTrigger;

            foreach ( var item in triggerInfos.m_TriggerInfos )
            {
                ListViewItem listViewItem = new ListViewItem( item.m_strTriggerName );

                ListViewItem.ListViewSubItem listViewSubItem = new ListViewItem.ListViewSubItem( listViewItem, item.m_strStockFile );
                listViewItem.SubItems.Add( listViewSubItem );

                ListViewItem.ListViewSubItem listViewSubItem2 = new ListViewItem.ListViewSubItem( listViewItem, item.m_strOpenSRFile );
                listViewItem.SubItems.Add( listViewSubItem2 );

                ListViewItem.ListViewSubItem listViewSubItem3 = new ListViewItem.ListViewSubItem( listViewItem, item.m_strOpenUTMR_DTMSFile );
                listViewItem.SubItems.Add( listViewSubItem3 );

                m_TriggerInfos.Add( listViewItem, item );
                this.ListViewScan.Items.Add( listViewItem );
            }
        }

        private void contextMenuStrip_Opening( object sender, CancelEventArgs eventArgs )
        {
            eventArgs.Cancel = true;

            ListViewHitTestInfo listViewHitTestInfo = this.ListViewScan.HitTest( this.ListViewScan.PointToClient( Cursor.Position ) );

            if ( listViewHitTestInfo == null )
                return;

            if ( listViewHitTestInfo.Item == null )
                return;

            if ( this.ListViewScan.SelectedItems.Contains( listViewHitTestInfo.Item ) == false )
                return;

            if ( listViewHitTestInfo.Location != ListViewHitTestLocations.Label )
                return;

            CommandBar popupCommandBar = MainForm.Instance.axCommandBars.Add( "ConfigAControl", XTPBarPosition.xtpBarPopup );

            CommandBarControl commandBarControl = popupCommandBar.Controls.Add( XTPControlType.xtpControlButton, ResourceId.ID_CONFIG_FORM2_DELETE, "删除(&D)", -1, false );

            popupCommandBar.ShowPopup( XTPTrackPopupFlags.TPM_RIGHTBUTTON, null, null );

        }

        private void ListViewScan_MouseDown( object sender, MouseEventArgs e )
        {
            if ( e.Clicks == 2 && e.Button == MouseButtons.Left )
            {
                ListViewHitTestInfo listViewHitTestInfo = this.ListViewScan.HitTest( this.ListViewScan.PointToClient( Cursor.Position ) );

                if ( listViewHitTestInfo == null )
                    return;

                if ( listViewHitTestInfo.Item == null )
                    return;

                if ( this.ListViewScan.SelectedItems.Contains( listViewHitTestInfo.Item ) == false )
                    return;

                if ( listViewHitTestInfo.Location != ListViewHitTestLocations.Label )
                    return;

                TriggerInfos.TriggerInfo triggerInfo = null;
                if ( m_TriggerInfos.TryGetValue( listViewHitTestInfo.Item, out triggerInfo ) == true )
                {
                    OptionSub3From optionSub3From = new OptionSub3From();
                    optionSub3From.SetTriggerInfo( triggerInfo );

                    if ( optionSub3From.ShowDialog(this) == DialogResult.OK )
                    {
                        triggerInfo = optionSub3From.GetTriggerInfo();

                        listViewHitTestInfo.Item.Text = triggerInfo.m_strTriggerName;

                        listViewHitTestInfo.Item.SubItems[1].Text = triggerInfo.m_strStockFile;
                        listViewHitTestInfo.Item.SubItems[2].Text = triggerInfo.m_strOpenSRFile;
                        listViewHitTestInfo.Item.SubItems[3].Text = triggerInfo.m_strOpenUTMR_DTMSFile;

                        m_TriggerInfos[listViewHitTestInfo.Item] = triggerInfo;
                    }
                }
           }
        }

        public event EventHandler ButtonSaveChanged;

        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs )
        {
            switch ( eventArgs.control.Id )
            {
                case ResourceId.ID_CONFIG_FORM2_DELETE:

                    if ( this.ListViewScan.SelectedIndices.Count <= 0 )
                        break;

                    int iIndex = 0;
                    foreach ( int indexListView in this.ListViewScan.SelectedIndices )
                    {
                        ListViewItem listViewItem = this.ListViewScan.Items[indexListView];

                        m_DeleteTriggerInfos.Add( listViewItem, m_TriggerInfos[listViewItem] );
                        m_TriggerInfos.Remove( listViewItem );

                        this.ListViewScan.Items.RemoveAt( indexListView - iIndex );
                        iIndex++;
                    }

                    if ( ButtonSaveChanged != null )
                        ButtonSaveChanged( this, EventArgs.Empty );

                    break;
                default:

                    break;
            }
        }

        internal void ButtonOK()
        {
            m_DeleteTriggerInfos.Clear();
            m_AddTriggerInfos.Clear();

            m_IsCheckBoxScan = this.CheckBoxScan.Checked;
        }

        internal void ButtonCancel()
        {
            foreach ( var listViewItem in m_DeleteTriggerInfos )
            {
                this.m_TriggerInfos.Add( listViewItem.Key, listViewItem.Value );
                this.ListViewScan.Items.Add( listViewItem.Key );
            }

            foreach ( var listViewItem in m_AddTriggerInfos )
            {
                this.m_TriggerInfos.Remove( listViewItem.Key );
                this.ListViewScan.Items.Remove( listViewItem.Key );
            }

            this.CheckBoxScan.Checked = m_IsCheckBoxScan;
        }
    }
}
