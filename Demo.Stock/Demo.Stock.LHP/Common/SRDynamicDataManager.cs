using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.LHP.Common
{
    public class SRDynamicDataManager
    {
        private static SRDynamicDataManager s_ReportInstance = new SRDynamicDataManager();
        public static SRDynamicDataManager Instance
        {
            get { return s_ReportInstance; }
        }

        private Dictionary<string, SRDynamicData> m_DynamicDataBySymbol = new Dictionary<string, SRDynamicData>();
        public SRDynamicData GetStockDataByStockCode( string strSymbol )
        {
            SRDynamicData outSRDynamicData = null;
            if ( m_DynamicDataBySymbol.TryGetValue( strSymbol, out outSRDynamicData ) == true )
                return outSRDynamicData;
            else
                return null;
        }

        private HashSet<SRDynamicData> m_DynamicDataArray = new HashSet<SRDynamicData>();
        public IEnumerable<SRDynamicData> ToArray()
        {
            return m_DynamicDataArray;
        }

        public void AddStockInfo( SRDynamicData srDynamicData )
        {
            SRDynamicData outSRDynamicData = null;
            if ( m_DynamicDataBySymbol.TryGetValue( srDynamicData.StockSymbol, out outSRDynamicData ) == true )
                return;

            m_DynamicDataBySymbol.Add( srDynamicData.StockSymbol, srDynamicData );

            m_DynamicDataArray.Add( srDynamicData );
        }
    }
}
