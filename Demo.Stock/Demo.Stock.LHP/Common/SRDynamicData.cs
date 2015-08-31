using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.LHP.Common
{
    public class SRDynamicData
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

        public enum StockTrend
        {
            None,
            Up,
            Down,
        }

        public class TrendData
        {
            public string GUID = Guid.Empty.ToString(); //
            public SRStaticData.SRTrendInfo SRTrendInfo = null;
            public float CSR = 0; // 是一根趋势线在当前K线位置的价格函数值
        }

        public string StockName = string.Empty;
        public string StockSymbol = string.Empty;
        public StockData CurrentStock = new StockData();

        public float StockCPF = 0; // 是指当前K线的价格波动范围，是最高价与最低价的差值。
        public float StockCRPF = 0; // 是指当前K线的相对价格价格波动，是(HP－LP)/Close。
        public float StockAPF = 0; // 平均波动价格 APF：是指过去20天（包括当前K线），每一根K线的最高价（HP）与最低价（LP）差值的平均值。
        public float StockARPF = 0; // 平均相对价格波动率 ARPF：是指过去20天每天的最高价（HP）与最低价（LP）的差值与收盘价的比值的平均值。

        public float StaticSRCK_R = 0; // SRCK-R 代表当前K线的收盘价与CK上方最近的SR点（阻力点R）的下位价之间的百分比差。
        public float StaticSRCK_S = 0; //	SRCK-S是当前K线的收盘价与下方最近的SR点（支撑点－S）的上位价之间的百分比差。
        public float StaticSRCK_RV = 0; // SRCK-R 代表当前K线的收盘价与CK上方最近的SR点（阻力点R）的下位价之间的值。
        public float StaticSRCK_SV = 0; //	SRCK-S是当前K线的收盘价与下方最近的SR点（支撑点－S）的上位价之间的值。

        public float DynamicSRCK_R = 0; // SRCK-R 代表当前K线的收盘价与CK上方最近的SR点（阻力点R）的下位价之间的百分比差。
        public float DynamicSRCK_S = 0; //	SRCK-S是当前K线的收盘价与下方最近的SR点（支撑点－S）的上位价之间的百分比差。
        public float DynamicSRCK_RV = 0; // SRCK-R 代表当前K线的收盘价与CK上方最近的SR点（阻力点R）的下位价之间的值。
        public float DynamicSRCK_SV = 0; //	SRCK-S是当前K线的收盘价与下方最近的SR点（支撑点－S）的上位价之间的值。
 
        public float StockAverage = 0; // 
        public float PriceFloat = 0; // 价格浮动(当前收盘价和昨天的收盘价比较)
        public StockTrend Trend = StockTrend.None;

        public TrendData[] srTrendDataArray = new TrendData[0];
    }
}
