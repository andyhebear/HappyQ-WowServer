using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.X.Common;

namespace Demo.Stock.X
{
    public partial class ConfigASubForm : Form
    {
        private Dictionary<string, MSFL.MSFLSecurityInfo> m_SecurityDictionary = new Dictionary<string, MSFL.MSFLSecurityInfo>();
        public ConfigASubForm( MSFL.MSFLSecurityInfo[] msflSecurityInfoArray )
        {
            InitializeComponent();

            for ( int iIndex = 0; iIndex < msflSecurityInfoArray.Length; iIndex++ )
            {
                MSFL.MSFLSecurityInfo msflSecurityInfo = msflSecurityInfoArray[iIndex];
                string securityInfo = msflSecurityInfo.szName + "[" + msflSecurityInfo.szSymbol + "]";

                m_SecurityDictionary.Add( securityInfo, msflSecurityInfo );

                this.checkedListBox.Items.Add( securityInfo );
            }
        }

        public MSFL.MSFLSecurityInfo[] ToSecurityInfo()
        {
            List<MSFL.MSFLSecurityInfo> msflSecurityInfoList = new List<MSFL.MSFLSecurityInfo>();


            for ( int iIndex = 0; iIndex < this.checkedListBox.Items.Count; iIndex++ )
            {
                bool bItemChecked = this.checkedListBox.GetItemChecked( iIndex );
                if ( bItemChecked == true )
                {
                    string securityInfo = (string)this.checkedListBox.Items[iIndex];

                    MSFL.MSFLSecurityInfo msflSecurityInfo;
                    if ( m_SecurityDictionary.TryGetValue( securityInfo, out msflSecurityInfo ) == true )
                        msflSecurityInfoList.Add( msflSecurityInfo );
                }
            }

            return msflSecurityInfoList.ToArray();
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

        private void ButtonAllSelect_Click( object sender, EventArgs e )
        {
            for ( int iIndex = 0; iIndex < this.checkedListBox.Items.Count; iIndex++ )
                this.checkedListBox.SetItemChecked( iIndex, true );
        }

        private void ButtonReverseSelect_Click( object sender, EventArgs e )
        {
            for ( int iIndex = 0; iIndex < this.checkedListBox.Items.Count; iIndex++ )
            {
                bool bItemChecked = this.checkedListBox.GetItemChecked( iIndex );
                this.checkedListBox.SetItemChecked( iIndex, !bItemChecked );
            }
        }
    }
}
