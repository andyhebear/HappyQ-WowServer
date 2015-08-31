using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.X.U50.Common;
using Demo.Stock.X.Common;

namespace Demo.Stock.X.U50
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TaskCControl : UserControl
    {
        public TaskCControl()
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


        bool isInit = false;
        private void TaskCControl_Load( object sender, EventArgs e )
        {
            if ( isInit == true )
                return;
            else
                isInit = true;

            GlobalSetting_LoadedGlobalSetting( this, EventArgs.Empty );

            GlobalSetting.LoadingGlobalSetting += new EventHandler( GlobalSetting_LoadingGlobalSetting );
            GlobalSetting.LoadedGlobalSetting += new EventHandler( GlobalSetting_LoadedGlobalSetting );
        }

        public void GlobalSetting_LoadedGlobalSetting( object sender, EventArgs e )
        {
            this.ComboBoxPlate.Items.Clear();

            foreach ( var item in GlobalStockManager.ToArrayPlate() )
                this.ComboBoxPlate.Items.Add( item );

            if ( this.ComboBoxPlate.Items.Count > 1 )
                this.ComboBoxPlate.SelectedIndex = 0;
        }

        public void GlobalSetting_LoadingGlobalSetting( object sender, EventArgs e )
        {
        }

        private void ComboBoxPlate_SelectedIndexChanged( object sender, EventArgs e )
        {
            this.ComboBoxVariety.Items.Clear();
            this.ComboBoxVariety.Items.Add( "所有的股票" );

            foreach ( var item in GlobalStockManager.ToArrayVarietyByPlate( (string)this.ComboBoxPlate.Items[this.ComboBoxPlate.SelectedIndex] ) )
                this.ComboBoxVariety.Items.Add( item );

            this.ComboBoxVariety.SelectedIndex = 0;
        }

        public void SetConfigPolicy( U50Request policy )
        {
            if ( policy.Select == U50TaskSelectType.All )
            {
                this.RadioButtonALL.Checked = true;
            }
            else if ( policy.Select == U50TaskSelectType.Specify )
            {
                this.RadioButtonSelect.Checked = true;
            }

            this.ComboBoxPlate.Text = policy.Plate;
            this.ComboBoxVariety.Text = policy.Variety;

            foreach ( var item in policy.StockInfo )
            {
                string strStockCode = Demo.Stock.X.U50.Common.U50StockInfo.GetStockInfo( item.Plate, item.Variety, item.Name, item.Symbol );
                this.CheckedListBox.Items.Add( strStockCode );
            }

            ButtonAllSelect_Click( this, EventArgs.Empty );
        }

        public U50Request GetTaskRequest()
        {
            U50Request configPolicy = new U50Request();

            if ( this.RadioButtonALL.Checked == true )
            {
                configPolicy.Select = U50TaskSelectType.All;
            }
            else if ( this.RadioButtonSelect.Checked == true )
            {
                configPolicy.Select = U50TaskSelectType.Specify;
            }

            configPolicy.Plate = this.ComboBoxPlate.Text;
            configPolicy.Variety = this.ComboBoxVariety.Text;

            List<Demo.Stock.X.U50.Common.U50StockInfo> stockInfoList = new List<Demo.Stock.X.U50.Common.U50StockInfo>( 32 );
            for ( int iIndex = 0; iIndex < this.CheckedListBox.Items.Count; iIndex++ )
            {
                bool bChecked = this.CheckedListBox.GetItemChecked( iIndex );

                if ( bChecked == true )
                {
                    Demo.Stock.X.U50.Common.U50StockInfo stockInfo = Demo.Stock.X.U50.Common.U50StockInfo.GetStockInfo( this.CheckedListBox.Items[iIndex].ToString() );

                    stockInfoList.Add( stockInfo );
                }
            }

            configPolicy.StockInfo = stockInfoList.ToArray();

            return configPolicy;
        }

        private void ButtonAllSelect_Click( object sender, EventArgs e )
        {
            for ( int iIndex = 0; iIndex < this.CheckedListBox.Items.Count; iIndex++ )
                this.CheckedListBox.SetItemChecked( iIndex, true );            
        }

        private void ButtonReverseSelect_Click( object sender, EventArgs e )
        {
            for ( int iIndex = 0; iIndex < this.CheckedListBox.Items.Count; iIndex++ )
            {
                bool bChecked = this.CheckedListBox.GetItemChecked( iIndex );
                this.CheckedListBox.SetItemChecked( iIndex, !bChecked );
            }
        }

        private void RadioButtonALL_CheckedChanged( object sender, EventArgs e )
        {
            this.ComboBoxPlate.Enabled = false;
            this.ComboBoxVariety.Enabled = false;
        }

        private void RadioButtonSelect_CheckedChanged( object sender, EventArgs e )
        {
            this.ComboBoxPlate.Enabled = true;
            this.ComboBoxVariety.Enabled = true;
        }

        private void ButtonGetStock_Click( object sender, EventArgs e )
        {
            this.CheckedListBox.Items.Clear();

            if ( RadioButtonALL.Checked == true )
            {
                foreach ( var item in GlobalStockManager.ToArray() )
                {
                    foreach ( var item2 in item.ToArray() )
                    {
                        string strStockCode = Demo.Stock.X.U50.Common.U50StockInfo.GetStockInfo( item.StockPlate, item.StockVariety, item2.StockName, item2.StockSymbol );
                        this.CheckedListBox.Items.Add( strStockCode );
                    }
                }
            }
            else if ( RadioButtonSelect.Checked == true )
            {
                if ( this.ComboBoxVariety.Text == "所有的股票" )
                {
                    foreach ( string item in GlobalStockManager.ToArrayVarietyByPlate( this.ComboBoxPlate.Text ) )
                    {
                        StockManager stockManager = GlobalStockManager.GetStockManagerByPlateAndVariety( this.ComboBoxPlate.Text, item );
                        if ( stockManager == null )
                            continue;

                        foreach ( var item2 in stockManager.ToArray() )
                        {
                            string strStockCode = Demo.Stock.X.U50.Common.U50StockInfo.GetStockInfo( this.ComboBoxPlate.Text, item, item2.StockName, item2.StockSymbol );
                            this.CheckedListBox.Items.Add( strStockCode );
                        }
                    }
                }
                else
                {
                    StockManager stockManager = GlobalStockManager.GetStockManagerByPlateAndVariety( this.ComboBoxPlate.Text, this.ComboBoxVariety.Text );
                    if ( stockManager == null )
                        return;

                    foreach ( var item2 in stockManager.ToArray() )
                    {
                        string strStockCode = Demo.Stock.X.U50.Common.U50StockInfo.GetStockInfo( this.ComboBoxPlate.Text, this.ComboBoxVariety.Text, item2.StockName, item2.StockSymbol );
                        this.CheckedListBox.Items.Add( strStockCode );
                    }
                }
            }
        }
    }
}
