using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.LHP.Common
{
    public class SRStaticDataManager
    {
        private static SRStaticDataManager s_ReportInstance = new SRStaticDataManager();
        public static SRStaticDataManager Instance
        {
            get { return s_ReportInstance; }
        }

        private Dictionary<string, SRStaticData> m_StaticDataBySymbol = new Dictionary<string, SRStaticData>();
        public SRStaticData GetStockDataByStockCode( string strSymbol )
        {
            SRStaticData outSRStaticData = null;
            if ( m_StaticDataBySymbol.TryGetValue( strSymbol, out outSRStaticData ) == true )
                return outSRStaticData;
            else
                return null;
        }

        private HashSet<SRStaticData> m_StaticDataArray = new HashSet<SRStaticData>();
        public IEnumerable<SRStaticData> ToArray()
        {
            return m_StaticDataArray;
        }

        public void AddStockInfo( SRStaticData srStaticData )
        {
            SRStaticData outStaticData = null;
            if ( m_StaticDataBySymbol.TryGetValue( srStaticData.StockSymbol, out outStaticData ) == true )
                return;

            m_StaticDataBySymbol.Add( srStaticData.StockSymbol, srStaticData );

            m_StaticDataArray.Add( srStaticData );
        }
    }
}
