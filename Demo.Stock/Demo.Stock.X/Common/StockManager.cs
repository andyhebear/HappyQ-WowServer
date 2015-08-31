using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.X.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class StockManager
    {
        // 股票板块
        private string m_StockPlate = string.Empty;
        public string StockPlate
        {
            get { return m_StockPlate; }
            set { m_StockPlate = value; }
        }

        // 股票种类
        private string m_StockVariety = string.Empty;
        public string StockVariety
        {
            get { return m_StockVariety; }
            set { m_StockVariety = value; }
        }

        /// <summary>
        /// 股票代码检索股票信息
        /// </summary>
        private Dictionary<string, StockInfo> m_StockInfoByCode = new Dictionary<string, StockInfo>();
        public StockInfo GetStockDataByStockCode( string strStockCode )
        {
            StockInfo outStockInfo = null;
            if ( m_StockInfoByCode.TryGetValue( strStockCode, out outStockInfo ) == true )
                return outStockInfo;
            else
                return null;
        }

        /// <summary>
        /// 全部的股票信息
        /// </summary>
        private HashSet<StockInfo> m_StockInfoArray = new HashSet<StockInfo>();
        public IEnumerable<StockInfo> ToArray()
        {
            return m_StockInfoArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockInfo"></param>
        public void AddStockInfo( StockInfo stockInfo )
        {
            StockInfo outStockInfo = null;
            if ( m_StockInfoByCode.TryGetValue( stockInfo.StockCode, out outStockInfo ) == true )
                return;

            m_StockInfoByCode.Add( stockInfo.StockCode, stockInfo );

            //
            m_StockInfoArray.Add( stockInfo );
        }

    }
}
