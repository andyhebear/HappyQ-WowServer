using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.X.Common;
using Demo.Mmose.Core.Util;
using System.Diagnostics;

namespace Demo.Stock.X.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RandomDStockForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private Random m_Random = new Random();

        private DateTime m_LowTradingTime = DateTime.Now - TimeSpan.FromDays( 90.0 );
        private DateTime m_HighTradingTime = DateTime.Now;
        private DateTime[] GetAllTradingTime()
        {
            int iDays = ( m_HighTradingTime - m_LowTradingTime ).Days;

            List<DateTime> tradingTime = new List<DateTime>( iDays );
            for ( int iIndex = 0; iIndex < iDays; iIndex++ )
                tradingTime.Add( m_LowTradingTime + TimeSpan.FromDays( (double)iIndex ) );

            return tradingTime.ToArray();
        }

        private float m_LowOpenPrice = 11;
        private float m_HighOpenPrice = 51;
        private float GetRandomOpenPrice()
        {
            return (float)m_Random.Next( (int)( m_HighOpenPrice - m_LowOpenPrice ) ) + m_LowOpenPrice;
        }

        private float m_LowClosePrice = 12;
        private float m_HighClosePrice = 52;
        private float GetRandomClosePrice()
        {
            return (float)m_Random.Next( (int)( m_HighClosePrice - m_LowClosePrice ) ) + m_LowClosePrice;
        }

        private float m_LowHighestPrice = 13;
        private float m_HighHighestPrice = 53;
        private float GetRandomHighestPrice()
        {
            return (float)m_Random.Next( (int)( m_HighHighestPrice - m_LowHighestPrice ) ) + m_LowHighestPrice;
        }

        private float m_LowMinimumPrice = 14;
        private float m_HighMinimumPrice = 54;
        private float GetRandomMinimumPrice( uint uiHighestPrice )
        {
            uint uiMinimumPrice = (uint)m_Random.Next( (int)( m_HighMinimumPrice - m_LowMinimumPrice ) ) + (uint)m_LowMinimumPrice;
            return uiMinimumPrice > uiHighestPrice ? uiHighestPrice : uiMinimumPrice;
        }

        private float m_LowDailyTurnover = 10000;
        private float m_HighDailyTurnover = 50000;
        private float GetRandomDailyTurnover()
        {
            return (float)m_Random.Next( (int)( m_HighDailyTurnover - m_LowDailyTurnover ) ) + m_LowDailyTurnover;
        }

        private float m_LowDailyAmount = 1000000;
        private float m_HighDailyAmount = 5000000;
        private float GetRandomDailyAmount()
        {
            return (float)m_Random.Next( (int)( m_HighDailyAmount - m_LowDailyAmount ) ) + m_LowDailyAmount;
        }

        private int m_RandomFileCount = 1;

        /// <summary>
        /// 
        /// </summary>
        public RandomDStockForm()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomDStockForm_Load( object sender, EventArgs e )
        {
            this.DateTimePickerLowTradingTime.Value = m_LowTradingTime;
            this.DateTimePickerHighTradingTime.Value = m_HighTradingTime;

            this.NumericUpDownLowOpenPrice.Value = (decimal)m_LowOpenPrice;
            this.NumericUpDownHighOpenPrice.Value = (decimal)m_HighOpenPrice;

            this.NumericUpDownLowClosePrice.Value = (decimal)m_LowClosePrice;
            this.NumericUpDownHighClosePrice.Value = (decimal)m_HighClosePrice;

            this.NumericUpDownLowHighestPrice.Value = (decimal)m_LowHighestPrice;
            this.NumericUpDownHighHighestPrice.Value = (decimal)m_HighHighestPrice;

            this.NumericUpDownLowMinimumPrice.Value = (decimal)m_LowMinimumPrice;
            this.NumericUpDownHighMinimumPrice.Value = (decimal)m_HighMinimumPrice;

            this.NumericUpDownLowDailyTurnover.Value = (decimal)m_LowDailyTurnover;
            this.NumericUpDown1HighDailyTurnover.Value = (decimal)m_HighDailyTurnover;

            this.NumericUpDownLowDailyAmount.Value = (decimal)m_LowDailyAmount;
            this.NumericUpDownHighDailyAmount.Value = (decimal)m_HighDailyAmount;

            this.NumericUpDownFileCount.Value = m_RandomFileCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFile_Click( object sender, EventArgs e )
        {
            char[] codeArray = this.RichTextBoxCode.Text.ToCharArray();
            char[] nameArray = this.RichTextBoxName.Text.ToCharArray();

            for ( int iIndex = 0; iIndex < m_RandomFileCount; iIndex++ )
            {
                StockInfo stockInfo = new StockInfo();

                StringBuilder strCode = new StringBuilder();
                for ( int i = 0; i < 6; i++ )
                    strCode.Append( RandomEx.RandomArray( codeArray ) );

                StringBuilder strName = new StringBuilder();
                for ( int i = 0; i < 10; i++ )
                    strName.Append( RandomEx.RandomArray( nameArray ) );

                //stockInfo.StockCode = strCode.ToString();
                //stockInfo.StockName = strName.ToString();

                DateTime[] allTradingTime = this.GetAllTradingTime();

                for ( int iIndex2 = 0; iIndex2 < allTradingTime.Length; iIndex2++ )
                {
                    StockData stockData = new StockData();

                    stockData.TradingTime = allTradingTime[iIndex2];
                    stockData.OpenPrice = this.GetRandomOpenPrice();
                    stockData.ClosePrice = this.GetRandomClosePrice();
                    stockData.HighestPrice = this.GetRandomHighestPrice();
                    stockData.MinimumPrice = this.GetRandomMinimumPrice( (uint)stockData.HighestPrice );
                    stockData.TradingVolume = this.GetRandomDailyTurnover();
                    stockData.OpenInterest = this.GetRandomDailyAmount();

                    //stockInfo.AddStockData( stockData );
                }

                StockInfo.SaveFileFormatForDStock( this.TextBoxFolder.Text + "\\" + stockInfo.StockCode + ".DStock", stockInfo );
            }
        }

        private void ButtonFolder_Click( object sender, EventArgs e )
        {
            this.FolderBrowserDialog.ShowDialog();
        }

        private void DateTimePickerLowTradingTime_ValueChanged( object sender, EventArgs e )
        {
            m_LowTradingTime = this.DateTimePickerLowTradingTime.Value;
        }

        private void DateTimePickerHighTradingTime_ValueChanged( object sender, EventArgs e )
        {
            m_HighTradingTime = this.DateTimePickerHighTradingTime.Value;
        }

        private void NumericUpDownLowOpenPrice_ValueChanged( object sender, EventArgs e )
        {
            m_LowOpenPrice = (uint)this.NumericUpDownLowOpenPrice.Value;
        }

        private void NumericUpDownHighOpenPrice_ValueChanged( object sender, EventArgs e )
        {
            m_HighOpenPrice = (uint)this.NumericUpDownHighOpenPrice.Value;
        }

        private void NumericUpDownLowClosePrice_ValueChanged( object sender, EventArgs e )
        {
            m_LowClosePrice = (uint)this.NumericUpDownLowClosePrice.Value;
        }

        private void NumericUpDownHighClosePrice_ValueChanged( object sender, EventArgs e )
        {
            m_HighClosePrice = (uint)this.NumericUpDownHighClosePrice.Value;
        }

        private void NumericUpDownLowHighestPrice_ValueChanged( object sender, EventArgs e )
        {
            m_LowHighestPrice = (uint)this.NumericUpDownLowHighestPrice.Value;
        }

        private void NumericUpDownHighHighestPrice_ValueChanged( object sender, EventArgs e )
        {
            m_HighHighestPrice = (uint)this.NumericUpDownHighHighestPrice.Value;
        }

        private void NumericUpDownLowMinimumPrice_ValueChanged( object sender, EventArgs e )
        {
            m_LowMinimumPrice = (uint)this.NumericUpDownLowMinimumPrice.Value;
        }

        private void NumericUpDownHighMinimumPrice_ValueChanged( object sender, EventArgs e )
        {
            m_HighMinimumPrice = (uint)this.NumericUpDownHighMinimumPrice.Value;
        }

        private void NumericUpDownLowDailyTurnover_ValueChanged( object sender, EventArgs e )
        {
            m_LowDailyTurnover = (ulong)this.NumericUpDownLowDailyTurnover.Value;
        }

        private void NumericUpDown1HighDailyTurnover_ValueChanged( object sender, EventArgs e )
        {
            m_HighDailyTurnover = (ulong)this.NumericUpDown1HighDailyTurnover.Value;
        }

        private void NumericUpDownLowDailyAmount_ValueChanged( object sender, EventArgs e )
        {
            m_LowDailyAmount = (ulong)this.NumericUpDownLowDailyAmount.Value;
        }

        private void NumericUpDownHighDailyAmount_ValueChanged( object sender, EventArgs e )
        {
            m_HighDailyAmount = (ulong)this.NumericUpDownHighDailyAmount.Value;
        }

        private void NumericUpDownFileCount_ValueChanged( object sender, EventArgs e )
        {
            m_RandomFileCount = (int)this.NumericUpDownFileCount.Value;
        }
    }
}
