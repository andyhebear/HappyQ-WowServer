using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.LHP.Common
{
    public class SRStaticData
    {
        public class StockData
        {
            public DateTime StockDate = DateTime.MinValue;
            public float StockOpen = 0;
            public float StockHigh = 0;
            public float StockLow = 0;
            public float StockClose = 0;
            public float StockVolume = 0;
        }

        [Flags]
        public enum SRPointType
        {
            None = 0x0000,
            DCHP = 0x0001,
            DCLP = 0x0002,
            GULK = 0x0004,
            GUHK = 0x0008,
            GDLK = 0x0010,
            GDHK = 0x0020,
        }

        [Flags]
        public enum DCPointType
        {
            None = 0x0000,
            DC_313 = 0x0001,
            DC_214 = 0x0002,
            DC_115 = 0x0004,
            DC_412 = 0x0008,
            DC_511 = 0x0010,
        }

        public class SRStaticInfo
        {
            public string GUID = Guid.NewGuid().ToString(); // 
            
            public SRPointType SRPointType = SRPointType.None;
            public DCPointType DCPointType = DCPointType.None;

            public StockData StockData = new StockData();

            public float StockAverage = 0; // Stock的平均值
            public float StockAverageHigh = 0; // Stock的平均值高值
            public float StockAverageLow = 0; // Stock的平均值低值
            public float GapPercentum = 0; // 实际的缺口百分比
            public float GapPriceSpace = 0; // 实际的缺口百分比
            public float GapVolumePercentum = 0; // 实际的缺口20天平均成交量增量百分比

            // 会变化的
            public int RelativelyNumber = 0; // SR点相对序号
            public float RelativelyPercent = 0; // SR点相对百分比

            public int LeftKLineNumber = 0; // 左K线的数目
            public int RightLineNumber = 0; // 右K线的数目
        }

        public enum TrendType
        {
            None,
            Up,
            Down,
        }

        public class SRTrendInfo
        {
            public string GUID = Guid.NewGuid().ToString(); // 

            public TrendType TrendInfo = TrendType.None;
            public SRStaticInfo SRStaticInfoA = null;
            public SRStaticInfo SRStaticInfoB = null;

            public int RelativelyNumber = 0; // SR点相对序号
            public float RelativelyPercent = 0; // SR点相对百分比

            // 不确定是否需要
            //public int LeftKLineNumber = 0; // 左K线的数目
            //public int RightLineNumber = 0; // 右K线的数目
        }

        public string StockName = string.Empty;
        public string StockSymbol = string.Empty;
        public StockData LastStock = new StockData();

        public float MaxDCHP = float.MinValue; // 最大的
        public float MinDCLP = float.MaxValue; // 最小的

        //public int MaxDCHPLineNumber = 0; // 最大的DCHP左右K线
        //public int MaxDCLPLineNumber = 0; // 最大的DCLP左右K线
        //public float MaxGapUpVolume = 0; // 最大的向上缺口成交量
        //public float MaxGapDownVolume = 0; // 最大的向下缺口成交量

        public SRStaticInfo[] srStaticInfoArray = new SRStaticInfo[0];
        public SRTrendInfo[] srTrendInfoArray = new SRTrendInfo[0];
    }
}
