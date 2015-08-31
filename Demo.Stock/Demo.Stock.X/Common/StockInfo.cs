using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Demo.Mmose.Core.Util;
using System.Diagnostics;
using System.Windows.Forms;

namespace Demo.Stock.X.Common
{
    /// <summary>
    /// 
    /// </summary>
    public enum StockInfoVer
    {
        VER_0_0_1_0 = 0x01,
    }

    /// <summary>
    /// 
    /// </summary>
    public class StockInfo
    {
        private StockInfoVer m_StockInfoVer = StockInfoVer.VER_0_0_1_0;
        public StockInfoVer StockInfoVer
        {
            get { return m_StockInfoVer; }
        }

        // 股票代码（股票全称 + 股票符号）
        private string m_StockCode = string.Empty;
        public string StockCode
        {
            get { return m_StockCode; }
        }

        // 股票全称
        private string m_StockName = string.Empty;
        public string StockName
        {
            get { return m_StockName; }
        }

        // 股票符号
        private string m_StockSymbol = string.Empty;
        public string StockSymbol
        {
            get { return m_StockSymbol; }
        }

        // 股票周期
        private Char m_Periodicity = Char.MinValue;
        public Char Periodicity
        {
            get { return m_Periodicity; }
        }

        private DateTime m_FirstDate = DateTime.MinValue;
        public DateTime FirstDate
        {
            get { return m_FirstDate; }
        }

        private DateTime m_LastDate = DateTime.MinValue;
        public DateTime LastDate
        {
            get { return m_LastDate; }
        }

        private DateTime m_FirstTime = DateTime.MinValue;
        public DateTime FirstTime
        {
            get { return m_FirstTime; }
        }

        private DateTime m_LastTime = DateTime.MinValue;
        public DateTime LastTime
        {
            get { return m_LastTime; }
        }

        private DateTime m_StartTime = DateTime.MinValue;
        public DateTime StartTime
        {
            get { return m_StartTime; }
        }

        private DateTime m_EndTime = DateTime.MinValue;
        public DateTime EndTime
        {
            get { return m_EndTime; }
        }

        private DateTime m_CollectionDate = DateTime.MinValue;
        public DateTime CollectionDate
        {
            get { return m_CollectionDate; }
        }

        // 股票文件路径
        private string m_StockFilePath = string.Empty;
        public string StockFilePath
        {
            get { return m_StockFilePath; }
            set { m_StockFilePath = value; }
        }

        private bool m_IsLoadFile = false;
        public bool IsLoadFile
        {
            get { return m_IsLoadFile; }
        }

        /// <summary>
        /// 股票交易时间检索, 股票数据
        /// </summary>
        private Dictionary<DateTime, StockData> m_DateTimeDictionary = new Dictionary<DateTime, StockData>();
        public StockData GetStockDataByTime( DateTime tradingDataTime )
        {
            StockData outStockData = null;
            if ( m_DateTimeDictionary.TryGetValue( tradingDataTime, out outStockData ) == true )
                return outStockData;
            else
                return null;
        }


        private bool m_IsDataChange = true;
        private StockData[] m_DateTimeStockData = new StockData[0];

        private void ToSortArray()
        {
            if ( m_IsDataChange == true )
            {
                List<StockData> stockDataList = new List<StockData>( 1024 );

                foreach ( var item in m_DateTimeDictionary )
                    stockDataList.Add( item.Value );

                m_DateTimeStockData = stockDataList.ToArray();
                Array.Sort<StockData>( m_DateTimeStockData );

                m_IsDataChange = false;
            }
        }

        public StockData[] GetStockDataRangeByTime( DateTime dataTimeStart )
        {
            ToSortArray();

            int iStart = -1;
            for ( int iIndex = 0; iIndex < m_DateTimeStockData.Length; iIndex++ )
            {
                StockData item = m_DateTimeStockData[iIndex];

                if ( item.TradingDate <= dataTimeStart )
                {
                    iStart = iIndex;
                    break;
                }
            }

            if ( iStart == -1 )
                return new StockData[0];

            StockData[] stockDataArray = new StockData[m_DateTimeStockData.Length - iStart];
            Array.Copy( m_DateTimeStockData, iStart, stockDataArray, 0, stockDataArray.Length );

            return stockDataArray;
        }

        public StockData[] GetStockDataRangeByTime( DateTime dataTimeStart, DateTime dataTimeEnd )
        {
            ToSortArray();

            if ( dataTimeStart <= dataTimeEnd )
                return new StockData[0];

            int iStart = -1;
            int iEnd = -1;
            for ( int iIndex = 0; iStart < m_DateTimeStockData.Length; iIndex++ )
            {
                StockData item = m_DateTimeStockData[iIndex];

                if ( item.TradingDate <= dataTimeStart && iStart == 0 )
                    iStart = iIndex;
                else if ( item.TradingDate <= dataTimeEnd && iEnd == 0 )
                {
                    iEnd = iIndex;
                    break;
                }
            }

            if ( iStart == -1 )
                return new StockData[0];

            if ( iEnd == -1 )
                iEnd = m_DateTimeStockData.Length;

            StockData[] stockDataArray = new StockData[iEnd - iStart];
            Array.Copy( m_DateTimeStockData, iStart, stockDataArray, 0, stockDataArray.Length );

            return stockDataArray;
        }

        public StockData[] GetStockDataRangeByKn( DateTime dataTimeStart, int iKn )
        {
            ToSortArray();

            if ( iKn < 3 )
                return new StockData[0];

            int iStart = -1;
            int iEnd = -1;
            for ( int iIndex = 0; iIndex < m_DateTimeStockData.Length; iIndex++ )
            {
                StockData item = m_DateTimeStockData[iIndex];

                if (item.TradingDate <= dataTimeStart)
                {
                    iStart = iIndex;

                    if ( ( iIndex + iKn ) < m_DateTimeStockData.Length )
                        iEnd = iStart + iKn;
                    else
                        iEnd = m_DateTimeStockData.Length;

                    break;
                }
            }

            if ( iStart == -1 )
                return new StockData[0];

            if ( iEnd == -1 )
                iEnd = m_DateTimeStockData.Length;

            StockData[] stockDataArray = new StockData[iEnd - iStart];
            Array.Copy( m_DateTimeStockData, iStart, stockDataArray, 0, stockDataArray.Length );

            return stockDataArray;
        }

        public IEnumerable<StockData> GetStockDataByTimeRange( DateTime beginTradingTime, DateTime endTradingTime )
        { 
            if ( beginTradingTime > endTradingTime )
                yield return null;

            foreach ( var item in m_DateTimeDictionary )
            {
                if ( item.Key >= beginTradingTime && item.Key <= endTradingTime )
                    yield return item.Value;
            }
        }

        /// <summary>
        /// 全部的股票数据
        /// </summary>
        private HashSet<StockData> m_StockDataArray = new HashSet<StockData>();
        public IEnumerable<StockData> ToArray()
        {
            return m_StockDataArray;
        }

        private void AddStockData( StockData stockData )
        {
            m_DateTimeDictionary.Add(stockData.TradingDateTime, stockData);

            m_StockDataArray.Add( stockData );

            m_IsDataChange = true;
        }

        public static bool LoadFileFormatForMetaStock( string stockName, string stockSymbol, string strFilePath, ref StockInfo stockInfo )
        {
            MSFL.MSFLSecurityInfo[] msflSecurityInfoArray = null;
            if ( GlobalSetting.TryLoadMsflSecurityInfo( strFilePath, out msflSecurityInfoArray ) == false )
                return false;

            int iErr = (int)MSFL.MSFL_ERR.MSFL_NO_ERR;
            StringBuilder dateString = new StringBuilder( MSFL.MSFL_MAX_NAME_LENGTH + 1 );

            for ( int iIndex = 0; iIndex < msflSecurityInfoArray.Length; iIndex++ )
            {
                MSFL.MSFLSecurityInfo msflSecurityInfo = msflSecurityInfoArray[iIndex];

                if ( msflSecurityInfo.szName == stockName && msflSecurityInfo.szSymbol == stockSymbol )
                {
                    stockInfo.m_StockCode = GlobalSetting.GetStockCode( msflSecurityInfo.szName, msflSecurityInfo.szSymbol );
                    
                    stockInfo.m_StockName = msflSecurityInfo.szName;
                    stockInfo.m_StockSymbol = msflSecurityInfo.szSymbol;

                    stockInfo.m_Periodicity = msflSecurityInfo.cPeriodicity;

                    iErr = MSFL.MSFL1_FormatDate( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lFirstDate );
                    stockInfo.m_FirstDate = DateTime.Parse( dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatDate( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lLastDate );
                    stockInfo.m_LastDate = DateTime.Parse( dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatTime( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lFirstTime, true );
                    string strFirstTime = dateString.ToString();
                    strFirstTime = strFirstTime.Substring( 0, strFirstTime.Length - 1 );
                    stockInfo.m_FirstTime = DateTime.Parse( strFirstTime );

                    iErr = MSFL.MSFL1_FormatTime( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lLastTime, true );
                    string strLastTime = dateString.ToString();
                    strLastTime = strLastTime.Substring( 0, strLastTime.Length - 1 );
                    stockInfo.m_LastTime = DateTime.Parse( strLastTime );

                    iErr = MSFL.MSFL1_FormatTime( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lStartTime, false );
                    stockInfo.m_StartTime = DateTime.Parse( dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatTime( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lEndTime, false );
                    stockInfo.m_EndTime = DateTime.Parse( dateString.ToString() );

                    iErr = MSFL.MSFL1_FormatDate( dateString, (ushort)dateString.Capacity, msflSecurityInfo.lCollectionDate );
                    stockInfo.m_CollectionDate = DateTime.Parse( dateString.ToString() );


                    MSFL.MSFLPriceRecord[] msflPriceInfoArray = null;
                    if ( GlobalSetting.TryLoadMsflPriceInfo( stockName, stockSymbol, strFilePath, out msflPriceInfoArray ) == false )
                        return true;

                    // numbers for summing price info
                    float fOpenSum = 0.0f, fHighSum = 0.0f, fLowSum = 0.0f, fCloseSum = 0.0f, fVolumeSum = 0.0f, fOpenIntSum = 0.0f;

                    StringBuilder szBuf = new StringBuilder( MSFL.MSFL_MAX_NAME_LENGTH + 1 );
                    for ( int iIndex2 = 0; iIndex2 < msflPriceInfoArray.Length; iIndex2++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecord = msflPriceInfoArray[iIndex2];

                        StockData stockData = new StockData();

                        if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_DATE ) == MSFL.MSFL_DATA_DATE )
                        {
                            iErr = MSFL.MSFL1_FormatDate( szBuf, (ushort)szBuf.Capacity, msflPriceRecord.lDate );
                            stockData.TradingDate = DateTime.Parse( szBuf.ToString() );
                        }

                        if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_TIME ) == MSFL.MSFL_DATA_TIME )
                        {
                            iErr = MSFL.MSFL1_FormatTime( szBuf, (ushort)szBuf.Capacity, msflPriceRecord.lTime, true );
                            string strTradingTime = szBuf.ToString();
                            strTradingTime = strLastTime.Substring( 0, strTradingTime.Length - 1 );
                            stockData.TradingTime = DateTime.Parse( strTradingTime );
                        }

                        stockData.TradingDateTime = stockData.TradingDate + stockData.TradingTime.TimeOfDay;
                        //Debug.WriteLine( stockData.TradingDateTime.ToString() );

                        if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_OPEN ) == MSFL.MSFL_DATA_OPEN )
                        {
                            fOpenSum += msflPriceRecord.fOpen;
                            stockData.OpenPrice = msflPriceRecord.fOpen;
                        }

                        if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_HIGH ) == MSFL.MSFL_DATA_HIGH )
                        {
                            fHighSum += msflPriceRecord.fHigh;
                            stockData.HighestPrice = msflPriceRecord.fHigh;
                        }

                        if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_LOW ) == MSFL.MSFL_DATA_LOW )
                        {
                            fLowSum += msflPriceRecord.fLow;
                            stockData.MinimumPrice = msflPriceRecord.fLow;
                        }

                        if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_CLOSE ) == MSFL.MSFL_DATA_CLOSE )
                        {
                            fCloseSum += msflPriceRecord.fClose;
                            stockData.ClosePrice = msflPriceRecord.fClose;
                        }

                        if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_VOLUME ) == MSFL.MSFL_DATA_VOLUME )
                        {
                            fVolumeSum += msflPriceRecord.fVolume;
                            stockData.TradingVolume = msflPriceRecord.fVolume;
                        }

                        if ( ( msflPriceRecord.wDataAvailable & MSFL.MSFL_DATA_OPENINT ) == MSFL.MSFL_DATA_OPENINT )
                        {
                            fOpenIntSum += msflPriceRecord.fOpenInt;
                            stockData.OpenInterest = msflPriceRecord.fOpenInt;
                        }

                        stockInfo.AddStockData( stockData );
                    } 

                    return true;
                }
            }

            return false;
        }

        public static bool LoadFileFormatForDStock( string strFile, ref StockInfo stockInfo )
        {
/*
            if ( File.Exists( strFile ) == false )
                return false;
            //else // 修改去掉只读
            //    File.SetAttributes( strFile, FileAttributes.Archive );

            FileStream fileStream  = File.Open( strFile, FileMode.Open );

            byte[] fileSign = new byte[6];
            fileStream.Read( fileSign, 0, fileSign.Length );
            if ( Encoding.ASCII.GetString( fileSign ) != "DStock" )
                return false;

            byte byStockInfoVer = (byte)fileStream.ReadByte();
            //stockInfo.StockInfoVer = (StockInfoVer)byStockInfoVer;

            byte[] byteStockCodeSize = new byte[4];
            fileStream.Read( byteStockCodeSize, 0, byteStockCodeSize.Length );
            byte[] byteStockCode = new byte[ConvertByteArray.ToInt( byteStockCodeSize )];
            fileStream.Read( byteStockCode, 0, byteStockCode.Length );
            stockInfo.StockCode = ConvertByteArray.ToString( byteStockCode );

            Debug.WriteLine( ConvertByteArray.ToString( byteStockCode ) );

            byte[] byteStockNameSize = new byte[4];
            fileStream.Read( byteStockNameSize, 0, byteStockNameSize.Length );
            byte[] byteStockName = new byte[ConvertByteArray.ToInt( byteStockNameSize )];
            fileStream.Read( byteStockName, 0, byteStockName.Length );
            stockInfo.StockName = ConvertByteArray.ToString( byteStockName );

            Debug.WriteLine( ConvertByteArray.ToString( byteStockName ) );

            byte[] byteStockDataCount = new byte[4];
            fileStream.Read( byteStockDataCount, 0, byteStockDataCount.Length );
            uint uiStockDataCount = ConvertByteArray.ToUInt( byteStockDataCount );

            for ( int iIndex = 0; iIndex < uiStockDataCount; iIndex++ )
            {
                StockData stockData = new StockData();

                byte byStockDataVer = (byte)fileStream.ReadByte();
                //stockData.StockDataVer = (StockDataVer)byStockDataVer;

                byte[] byteTradingTime = new byte[8];
                fileStream.Read( byteTradingTime, 0, byteTradingTime.Length );
                stockData.TradingTime = new DateTime( ConvertByteArray.ToLong( byteTradingTime ) );

                byte[] byteOpenPrice = new byte[4];
                fileStream.Read( byteOpenPrice, 0, byteOpenPrice.Length );
                stockData.OpenPrice = ConvertByteArray.ToUInt( byteOpenPrice );

                byte[] byteClosePrice = new byte[4];
                fileStream.Read( byteClosePrice, 0, byteClosePrice.Length );
                stockData.ClosePrice = ConvertByteArray.ToUInt( byteClosePrice );

                byte[] byteHighestPrice = new byte[4];
                fileStream.Read( byteHighestPrice, 0, byteHighestPrice.Length );
                stockData.HighestPrice = ConvertByteArray.ToUInt( byteHighestPrice );

                byte[] byteMinimumPrice = new byte[4];
                fileStream.Read( byteMinimumPrice, 0, byteMinimumPrice.Length );
                stockData.MinimumPrice = ConvertByteArray.ToUInt( byteMinimumPrice );

                byte[] byteDailyTurnover = new byte[8];
                fileStream.Read( byteDailyTurnover, 0, byteDailyTurnover.Length );
                stockData.TradingVolume = ConvertByteArray.ToULong( byteDailyTurnover );

                byte[] byteDailyAmount = new byte[8];
                fileStream.Read( byteDailyAmount, 0, byteDailyAmount.Length );
                stockData.OpenInterest = ConvertByteArray.ToULong( byteDailyAmount );

                stockInfo.AddStockData( stockData );
            }

            fileStream.Close();

            stockInfo.m_StockFilePath = strFile;
            stockInfo.m_IsLoadFile = true;
*/
            return true;
        }

        public static void SaveFileFormatForDStock( string strFile, StockInfo stockInfo )
        {
/*
            FileStream fileStream = File.Open( strFile, FileMode.CreateNew );

            byte[] fileSignNone = Encoding.ASCII.GetBytes( "123456" );
            fileStream.Write( fileSignNone, 0, fileSignNone.Length );

            fileStream.WriteByte( (byte)stockInfo.StockInfoVer );

            byte[] byteStockCode = ConvertByteArray.ToByteArray( stockInfo.StockCode );
            byte[] byteStockCodeSize = ConvertByteArray.ToByteArray( byteStockCode.Length );
            fileStream.Write( byteStockCodeSize, 0, byteStockCodeSize.Length );
            fileStream.Write( byteStockCode, 0, byteStockCode.Length );

            Debug.WriteLine( stockInfo.StockCode );

            byte[] byteStockName = ConvertByteArray.ToByteArray( stockInfo.StockName );
            byte[] byteStockNameSize = ConvertByteArray.ToByteArray( byteStockName.Length );
            fileStream.Write( byteStockNameSize, 0, byteStockNameSize.Length );
            fileStream.Write( byteStockName, 0, byteStockName.Length );

            Debug.WriteLine( stockInfo.StockName );

            uint uiStockDataCount = 0;
            long lStockDataCountPosition = fileStream.Position;
            byte[] byteStockDataCount = ConvertByteArray.ToByteArray( uiStockDataCount );
            fileStream.Write( byteStockDataCount, 0, byteStockDataCount.Length );

            foreach ( StockData stockData in stockInfo.ToArray() )
            {
                fileStream.WriteByte( (byte)stockData.StockDataVer );

                byte[] byteTradingTime = ConvertByteArray.ToByteArray( stockData.TradingTime.Ticks );
                fileStream.Write( byteTradingTime, 0, byteTradingTime.Length );

                byte[] byteOpenPrice = ConvertByteArray.ToByteArray( stockData.OpenPrice );
                fileStream.Write( byteOpenPrice, 0, byteOpenPrice.Length );

                byte[] byteClosePrice = ConvertByteArray.ToByteArray( stockData.ClosePrice );
                fileStream.Write( byteClosePrice, 0, byteClosePrice.Length );

                byte[] byteHighestPrice = ConvertByteArray.ToByteArray( stockData.HighestPrice );
                fileStream.Write( byteHighestPrice, 0, byteHighestPrice.Length );

                byte[] byteMinimumPrice = ConvertByteArray.ToByteArray( stockData.MinimumPrice );
                fileStream.Write( byteMinimumPrice, 0, byteMinimumPrice.Length );

                byte[] byteDailyTurnover = ConvertByteArray.ToByteArray( stockData.TradingVolume );
                fileStream.Write( byteDailyTurnover, 0, byteDailyTurnover.Length );

                byte[] byteDailyAmount = ConvertByteArray.ToByteArray( stockData.DailyAmount );
                fileStream.Write( byteDailyAmount, 0, byteDailyAmount.Length );

                uiStockDataCount++;
            }

            fileStream.Seek( lStockDataCountPosition, SeekOrigin.Begin );
            byteStockDataCount = ConvertByteArray.ToByteArray( uiStockDataCount );
            fileStream.Write( byteStockDataCount, 0, byteStockDataCount.Length );

            // 最后写入代表文件成功
            fileStream.Seek( 0, SeekOrigin.Begin );
            byte[] fileSign = Encoding.ASCII.GetBytes( "DStock" );
            fileStream.Write( fileSign, 0, fileSign.Length );

            fileStream.Flush();
            fileStream.Close();
*/
        }
    }
}
