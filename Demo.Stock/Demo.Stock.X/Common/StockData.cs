using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.X.Common
{
    /// <summary>
    /// 
    /// </summary>
    public enum StockDataVer
    {
        VER_0_0_1_0 = 0x01,
    }

    /// <summary>
    /// 
    /// </summary>
    public class StockData : IComparable, IComparable<StockData>
    {
        private StockDataVer m_StockDataVer = StockDataVer.VER_0_0_1_0;
        public StockDataVer StockDataVer
        {
            get { return m_StockDataVer; }
        }

        // 
        private DateTime m_TradingDateTime = DateTime.MinValue;
        public DateTime TradingDateTime
        {
            get { return m_TradingDateTime; }
            set { m_TradingDateTime = value; }
        }

        // 交易时间
        private DateTime m_TradingDate = DateTime.MinValue;
        public DateTime TradingDate
        {
            get { return m_TradingDate; }
            set { m_TradingDate = value; }
        }

        // 交易时间
        private DateTime m_TradingTime = DateTime.MinValue;
        public DateTime TradingTime
        {
            get { return m_TradingTime; }
            set { m_TradingTime = value; }
        }

        // 开盘价
        private float m_OpenPrice = 0;
        public float OpenPrice
        {
            get { return m_OpenPrice; }
            set { m_OpenPrice = value; }
        }

        // 收盘价
        private float m_ClosePrice = 0;
        public float ClosePrice
        {
            get { return m_ClosePrice; }
            set { m_ClosePrice = value; }
        }

        // 最高价
        private float m_HighestPrice = 0;
        public float HighestPrice
        {
            get { return m_HighestPrice; }
            set { m_HighestPrice = value; }
        }

        // 最低价
        private float m_MinimumPrice = 0;
        public float MinimumPrice
        {
            get { return m_MinimumPrice; }
            set { m_MinimumPrice = value; }
        }

        // 成交量
        private float m_TradingVolume = 0;
        public float TradingVolume
        {
            get { return m_TradingVolume; }
            set { m_TradingVolume = value; }
        }

        // 成交金额
        private float m_OpenInterest = 0;
        public float OpenInterest
        {
            get { return m_OpenInterest; }
            set { m_OpenInterest = value; }
        }

        #region IComparable 成员

        public int CompareTo( object obj )
        {
            StockData stockData = obj as StockData;
            if ( stockData == null )
                throw new NotImplementedException();
            else
            {
                if ( stockData.TradingDate > this.TradingDate )
                    return 1;
                else if ( stockData.TradingDate < this.TradingDate )
                    return -1;
                else
                    return 0;
            }
        }

        #endregion

        #region IComparable<StockData> 成员

        public int CompareTo( StockData other )
        {
            if ( other == null )
                throw new NotImplementedException();
            else
            {
                if ( other.TradingDate > this.TradingDate )
                    return 1;
                else if ( other.TradingDate < this.TradingDate )
                    return -1;
                else
                    return 0;
            }
        }

        #endregion
    }
}
