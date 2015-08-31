using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.X.U50.Common
{
    public class U50TaskInfo : ICloneable
    {
        public string Name = string.Empty;
        public string Guid = string.Empty;

        public U50General General = new U50General();
        public U50Request Request = new U50Request();
        public U50TaskPolicy Policy = new U50TaskPolicy();
        public U50Result Result = new U50Result();

        #region ICloneable 成员

        public object Clone()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public enum U50TaskSaneType
    {
        CustomScan = 0,
        AutoScan = 1,
        TimeScan = 2,
    }

    public class U50General
    {
        public U50TaskSaneType SaneType = U50TaskSaneType.CustomScan;
    }

    public enum U50TaskSelectType
    {
        None = 0,
        All = 1,
        Specify = 2,
    }

    public class U50StockInfo
    {
        public string Plate = string.Empty;
        public string Variety = string.Empty;
        public string Name = string.Empty;
        public string Symbol = string.Empty;

        string GetStockInfo()
        {
            return Plate + "-" + Variety + "[" + Name + "][" + Symbol + "]";
        }

        public static string GetStockInfo( string stockPlate, string stockVariety, string stockName, string stockSymbol )
        {
            return stockPlate + "-" + stockVariety + "[" + stockName + "][" + stockSymbol + "]";
        }

        public static U50StockInfo GetStockInfo( string stockStockCode )
        {
            U50StockInfo stockCode = new U50StockInfo();

            int iIndex = stockStockCode.IndexOf( '-' );
            stockCode.Plate = stockStockCode.Substring( 0, iIndex );
            int iIndex2 = stockStockCode.IndexOf( '[', iIndex );
            stockCode.Variety = stockStockCode.Substring( iIndex + 1, iIndex2 - ( iIndex + 1 ) );
            int iIndex3 = stockStockCode.IndexOf( "][", iIndex2 );
            stockCode.Name = stockStockCode.Substring( iIndex2 + 1, iIndex3 - ( iIndex2 + 1 ) );
            stockCode.Symbol = stockStockCode.Substring( iIndex3 + 2, ( stockStockCode.Length - 1 ) - ( iIndex3 + 2 ) );

            return stockCode;
        }
    }

    public class U50Request
    {
        public U50TaskSelectType Select = U50TaskSelectType.None;
        public string Plate = string.Empty;
        public string Variety = string.Empty;
        public U50StockInfo[] StockInfo = new U50StockInfo[0];
    }

    public enum U50ScanType
    {
        None = 0,
        Order = 1,
        Synchronization = 2,
    }

    public class U50TaskPolicy
    {
        public U50ScanType ScanType = U50ScanType.None;
        public string[] PolicyGuid = new string[0];
    }

    public class U50Result
    {
        public string LastReportGuid = string.Empty;
    }
}
