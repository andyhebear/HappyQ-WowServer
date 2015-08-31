using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.LHP.Common;

namespace Demo.Stock.LHP.Main
{
    public partial class OptionSub2From : Form
    {
        private Dictionary<string, MSFL.MSFLSecurityInfo> m_SecurityDictionary = new Dictionary<string, MSFL.MSFLSecurityInfo>();
        public OptionSub2From( MSFL.MSFLSecurityInfo[] msflSecurityInfoArray )
        {
            InitializeComponent();

            for ( int iIndex = 0; iIndex < msflSecurityInfoArray.Length; iIndex++ )
            {
                MSFL.MSFLSecurityInfo msflSecurityInfo = msflSecurityInfoArray[iIndex];
                string securityInfo = msflSecurityInfo.szName + "[" + msflSecurityInfo.szSymbol + "]";

                m_SecurityDictionary.Add( securityInfo, msflSecurityInfo );

                this.CheckedListBoxStock.Items.Add( securityInfo );
            }
        }

        public MSFL.MSFLSecurityInfo[] ToSecurityInfo()
        {
            List<MSFL.MSFLSecurityInfo> msflSecurityInfoList = new List<MSFL.MSFLSecurityInfo>();

            for ( int iIndex = 0; iIndex < this.CheckedListBoxStock.Items.Count; iIndex++ )
            {
                bool bItemChecked = this.CheckedListBoxStock.GetItemChecked( iIndex );
                if ( bItemChecked == true )
                {
                    string securityInfo = (string)this.CheckedListBoxStock.Items[iIndex];

                    MSFL.MSFLSecurityInfo msflSecurityInfo;
                    if ( m_SecurityDictionary.TryGetValue( securityInfo, out msflSecurityInfo ) == true )
                        msflSecurityInfoList.Add( msflSecurityInfo );
                }
            }

            return msflSecurityInfoList.ToArray();
        }

        private void ButtonAllSelect_Click( object sender, EventArgs e )
        {
            for ( int iIndex = 0; iIndex < this.CheckedListBoxStock.Items.Count; iIndex++ )
                this.CheckedListBoxStock.SetItemChecked( iIndex, true );
        }

        private void ButtonReverseSelect_Click( object sender, EventArgs e )
        {
            for ( int iIndex = 0; iIndex < this.CheckedListBoxStock.Items.Count; iIndex++ )
            {
                bool bItemChecked = this.CheckedListBoxStock.GetItemChecked( iIndex );
                this.CheckedListBoxStock.SetItemChecked( iIndex, !bItemChecked );
            }
        }
    }
}
