using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.LHP.Common
{
    public class PSRReport
    {
        public enum SRPointType
        {
            None,
            DCHP,
            DCLP,
            GULK,
            GUHK,
            GDLK,
            GDHK,
        }

        public enum StockTrend
        {
            None,
            Up,
            Down,
        }

        public class SRInfo
        {
            public int Number = 0;

            public float StockHigh = 0;
            public float StockEntity = 0;
            public float StockAverage = 0;

            public DateTime StockDate = DateTime.MinValue;
            public SRPointType SRPointType = SRPointType.None;

            public float StrongPercentum = 0;
            public int RelativelyNumber = 0;
        }

        public string StockSymbol = string.Empty;
        public float StockOpen = 0;
        public float StockClose = 0;
        public float StockHigh = 0;
        public float StockLow = 0;
        public float StockVolume = 0;
        public StockTrend Trend = StockTrend.None;
        public float PriceFloat = 0;

        public SRInfo[] SRInfos = new SRInfo[0];
    }
}
