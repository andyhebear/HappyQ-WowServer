using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Demo.Stock.X.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class GlobalSetting
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        private static string s_ConfigFilePath = "Demo.Stock.Config\\Global.config";
        public static string ConfigFilePath
        {
            get { return s_ConfigFilePath; }
            set { s_ConfigFilePath = value; }
        }

        private static bool s_IsAutoLoadConfigSetting = true;
        public static bool IsAutoLoadConfigSetting
        {
            get { return s_IsAutoLoadConfigSetting; }
            set { s_IsAutoLoadConfigSetting = value; }
        }

        private static bool s_IsPopStartupInfo = true;
        public static bool IsPopStartupInfo
        {
            get { return s_IsPopStartupInfo; }
            set { s_IsPopStartupInfo = value; }
        }

        private static uint s_ShowKLineLength = 20;
        public static uint ShowKLineLength
        {
            get { return s_ShowKLineLength; }
            set { s_ShowKLineLength = value; }
        }

        private static PlateInfo[] s_PlateInfos = new PlateInfo[0];
        public static PlateInfo[] PlateInfos
        {
            get { return s_PlateInfos; }
        }

        private static bool s_IsLoadGlobalSetting = false;
        public static bool IsLoadGlobalSetting
        {
            get { return s_IsLoadGlobalSetting; }
        }
        #endregion

        public static void LoadGlobalRegistry()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.X" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "GlobalSetting" );

            string strIsPopMessageInfo = (string)rkey4.GetValue( "IsPopStartupInfo", "True" );
            bool.TryParse( strIsPopMessageInfo, out s_IsPopStartupInfo );

            string strShowKLineLength = (string)rkey4.GetValue( "ShowKLineLength", "20" );
            uint.TryParse( strShowKLineLength, out s_ShowKLineLength );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }

        public static void SaveGlobalRegistry()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.X" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "GlobalSetting" );

            rkey4.SetValue( "IsPopStartupInfo", s_IsPopStartupInfo.ToString(), RegistryValueKind.String );
            rkey4.SetValue( "ShowKLineLength", s_ShowKLineLength.ToString(), RegistryValueKind.String );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }

        #region zh-CHS 共有的事件数据类 | en Public EventArgs Class
        public static event EventHandler LoadingGlobalSetting;
        public static event EventHandler LoadedGlobalSetting;
        #endregion
        public static bool LoadGlobalSetting()
        {
            PlateInfo[] plateInfos = LoadConfigSetting( GlobalSetting.ConfigFilePath );
            if ( plateInfos == null )
                return false;

            if ( LoadingGlobalSetting != null )
                LoadingGlobalSetting( null, EventArgs.Empty );

            s_SecurityDictionary.Clear();
            s_PriceDictionary.Clear();
            GlobalStockManager.Clear();

            s_PlateInfos = plateInfos;

            for ( int iIndex = 0; iIndex < s_PlateInfos.Length; iIndex++ )
            {
                PlateInfo plateInfo = s_PlateInfos[iIndex];

                for ( int iIndex2 = 0; iIndex2 < plateInfo.VarietyInfos.Length; iIndex2++ )
                {
                    VarietyInfo varietyInfo = plateInfo.VarietyInfos[iIndex2];

                    StockManager stockManager = new StockManager();
                    stockManager.StockPlate = plateInfo.Name;
                    stockManager.StockVariety = varietyInfo.Name;

                    for ( int iIndex3 = 0; iIndex3 < varietyInfo.FileInfos.Length; iIndex3++ )
                    {
                        FileInfo FileInfo = varietyInfo.FileInfos[iIndex3];

                        StockInfo stockInfo = new StockInfo();
                        if ( StockInfo.LoadFileFormatForMetaStock( FileInfo.StockName, FileInfo.StockSymbol, FileInfo.FilePath, ref  stockInfo ) == true )
                            stockManager.AddStockInfo( stockInfo );
                    }

                    GlobalStockManager.AddStockManager( stockManager );
                }
            }

            s_IsLoadGlobalSetting = true;

            if ( LoadedGlobalSetting != null )
                LoadedGlobalSetting( null, EventArgs.Empty );

            return true;
        }

        public static PlateInfo[] LoadConfigSetting( string strConfigFile )
        {
            if ( File.Exists( strConfigFile ) == false )
            {
                if ( strConfigFile == GlobalSetting.ConfigFilePath )
                    SaveConfigSetting( GlobalSetting.ConfigFilePath, GlobalSetting.PlateInfos );
                else
                    return null;
            }

            XDocument documentConfig = XDocument.Load( strConfigFile );
            if ( documentConfig == null )
                return null;

            XElement elementRoot = documentConfig.Element( (XName)"Demo.Stock" );
            if ( elementRoot == null )
                return null;

            XAttribute attributeVer = elementRoot.Attribute( (XName)"Ver" );
            if ( attributeVer == null )
                return null;

            //////////////////////////////////////////////////////////////////////////
            // <Settings>
            IEnumerable<XElement> elementStockPlates = elementRoot.Elements( (XName)"StockPlate" );
            if ( elementStockPlates == null )
                return null;

            List<PlateInfo> plateInfoList = new List<PlateInfo>();
            foreach ( var elementPlate in elementStockPlates )
            {
                XAttribute attributePlateName = elementPlate.Attribute( (XName)"Name" );
                if ( attributePlateName == null )
                    continue;

                PlateInfo plateInfo = new PlateInfo();
                plateInfo.Name = attributePlateName.Value;
                plateInfoList.Add( plateInfo );

                IEnumerable<XElement> elementStockVarietys = elementPlate.Elements( (XName)"StockVariety" );
                if ( elementStockVarietys == null )
                    continue;

                List<VarietyInfo> varietyInfoList = new List<VarietyInfo>();
                foreach ( var elementVariety in elementStockVarietys )
                {
                    XAttribute attributeVarietyName = elementVariety.Attribute( (XName)"Name" );
                    if ( attributeVarietyName == null )
                        continue;

                    VarietyInfo varietyInfo = new VarietyInfo();
                    varietyInfo.Name = attributeVarietyName.Value;
                    varietyInfoList.Add( varietyInfo );

                    IEnumerable<XElement> elementFileInfos = elementVariety.Elements( (XName)"FileInfo" );
                    if ( elementFileInfos == null )
                        continue;

                    List<FileInfo> fileInfoList = new List<FileInfo>();
                    foreach ( var elementFileInfo in elementFileInfos )
                    {
                        FileInfo fileInfo = new FileInfo();

                        XAttribute attributeInfoName = elementFileInfo.Attribute( (XName)"Name" );
                        if ( attributeInfoName != null )
                            fileInfo.StockName = attributeInfoName.Value;

                        XAttribute attributeInfoSymbol = elementFileInfo.Attribute( (XName)"Symbol" );
                        if ( attributeInfoSymbol != null )
                            fileInfo.StockSymbol = attributeInfoSymbol.Value;

                        fileInfo.FilePath = elementFileInfo.Value;

                        fileInfoList.Add( fileInfo );
                    }

                    varietyInfo.FileInfos = fileInfoList.ToArray();
                }

                plateInfo.VarietyInfos = varietyInfoList.ToArray();
            }

            return plateInfoList.ToArray();
        }

        public static void SaveConfigSetting( string strConfigFile, PlateInfo[] plateInfos )
        {
            if ( plateInfos == null )
                return;

            if ( File.Exists( strConfigFile ) == true )
            {
                File.SetAttributes( strConfigFile, FileAttributes.Archive );
                File.Delete( strConfigFile );
            }

            XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );

            for ( int iIndex = 0; iIndex < plateInfos.Length; iIndex++ )
            {
                PlateInfo plateInfo = plateInfos[iIndex];

                XElement elementPlate = new XElement( "StockPlate", new XAttribute( "Name", plateInfo.Name ) );

                if ( plateInfo.VarietyInfos == null )
                    continue;

                for ( int iIndex2 = 0; iIndex2 < plateInfo.VarietyInfos.Length; iIndex2++ )
                {
                    VarietyInfo varietyInfo = plateInfo.VarietyInfos[iIndex2];

                    XElement elementVariety = new XElement( "StockVariety", new XAttribute( "Name", varietyInfo.Name ) );

                    if ( varietyInfo.FileInfos == null )
                        continue;

                    for ( int iIndex3 = 0; iIndex3 < varietyInfo.FileInfos.Length; iIndex3++ )
                    {
                        FileInfo fileInfo = varietyInfo.FileInfos[iIndex3];

                        XElement elementFileInfo = new XElement( "FileInfo", fileInfo.FilePath );
                        elementFileInfo.Add( new XAttribute( "Name", fileInfo.StockName ) );
                        elementFileInfo.Add( new XAttribute( "Symbol", fileInfo.StockSymbol ) );

                        elementVariety.Add( elementFileInfo );
                    }

                    elementPlate.Add( elementVariety );
                }

                elementRoot.Add( elementPlate );
            }

            XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            documentConfig.Save( strConfigFile );
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static Dictionary<string, MSFL.MSFLSecurityInfo[]> s_SecurityDictionary = new Dictionary<string, MSFL.MSFLSecurityInfo[]>();
        #endregion
        public static bool TryLoadMsflSecurityInfo( string strFilePath, out MSFL.MSFLSecurityInfo[] msflSecurityInfoArray )
        {
            msflSecurityInfoArray = new MSFL.MSFLSecurityInfo[0];

            if ( s_SecurityDictionary.TryGetValue( strFilePath, out msflSecurityInfoArray ) == true )
                return true;

            if ( Directory.Exists( strFilePath ) == false )
                return false;

            byte dirNumber = 0;

            int iErr = MSFL.MSFL1_OpenDirectory( strFilePath, ref dirNumber, MSFL.MSFL_DIR_FORCE_USER_IN );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return false;

            MSFL.MSFLDirectoryStatus msflDirectoryStatus = new MSFL.MSFLDirectoryStatus();
            msflDirectoryStatus.dwTotalSize = (uint)Marshal.SizeOf( msflDirectoryStatus );

            iErr = MSFL.MSFL1_GetDirectoryStatus( dirNumber, string.Empty, ref msflDirectoryStatus );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return false;

            if ( msflDirectoryStatus.bExists == false || msflDirectoryStatus.bOpen == false || msflDirectoryStatus.bMetaStockDir == false )
                return false;

            List<MSFL.MSFLSecurityInfo> msflSecurityInfoList = new List<MSFL.MSFLSecurityInfo>();

            MSFL.MSFLSecurityInfo msflSecurityInfo = new MSFL.MSFLSecurityInfo();
            msflSecurityInfo.dwTotalSize = (uint)Marshal.SizeOf( msflSecurityInfo );

            iErr = MSFL.MSFL1_GetFirstSecurityInfo( dirNumber, ref msflSecurityInfo );
            while ( iErr == (int)MSFL.MSFL_ERR.MSFL_NO_ERR || iErr == (int)MSFL.MSFL_Messages.MSFL_MSG_LAST_SECURITY_IN_DIR )
            {
                msflSecurityInfoList.Add( msflSecurityInfo );

                if ( iErr == (int)MSFL.MSFL_Messages.MSFL_MSG_LAST_SECURITY_IN_DIR )
                    break;

                msflSecurityInfo = new MSFL.MSFLSecurityInfo();
                msflSecurityInfo.dwTotalSize = (uint)Marshal.SizeOf( msflSecurityInfo );

                iErr = MSFL.MSFL1_GetNextSecurityInfo( msflSecurityInfo.hSecurity, ref msflSecurityInfo );
            }

            MSFL.MSFL1_CloseDirectory( dirNumber );

            msflSecurityInfoArray = msflSecurityInfoList.ToArray();
            s_SecurityDictionary.Add( strFilePath, msflSecurityInfoArray );

            return true;
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static Dictionary<string, MSFL.MSFLPriceRecord[]> s_PriceDictionary = new Dictionary<string, MSFL.MSFLPriceRecord[]>();
        #endregion
        public static bool TryLoadMsflPriceInfo( string stockName, string stockSymbol, string strFilePath, out MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            msflPriceRecordArray = new MSFL.MSFLPriceRecord[0];

            string strStockCode = GetStockCode( stockName, stockSymbol );
            if ( s_PriceDictionary.TryGetValue( strStockCode, out msflPriceRecordArray ) == true )
                return true;

            if ( Directory.Exists( strFilePath ) == false )
                return false;

            byte dirNumber = 0;

            int iErr = MSFL.MSFL1_OpenDirectory( strFilePath, ref dirNumber, MSFL.MSFL_DIR_FORCE_USER_IN );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return false;

            MSFL.MSFLDirectoryStatus msflDirectoryStatus = new MSFL.MSFLDirectoryStatus();
            msflDirectoryStatus.dwTotalSize = (uint)Marshal.SizeOf( msflDirectoryStatus );

            iErr = MSFL.MSFL1_GetDirectoryStatus( dirNumber, string.Empty, ref msflDirectoryStatus );
            if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                return false;

            if ( msflDirectoryStatus.bExists == false || msflDirectoryStatus.bOpen == false || msflDirectoryStatus.bMetaStockDir == false )
                return false;

            MSFL.MSFLSecurityInfo msflSecurityInfo = new MSFL.MSFLSecurityInfo();
            msflSecurityInfo.dwTotalSize = (uint)Marshal.SizeOf( msflSecurityInfo );

            iErr = MSFL.MSFL1_GetFirstSecurityInfo( dirNumber, ref msflSecurityInfo );
            while ( iErr == (int)MSFL.MSFL_ERR.MSFL_NO_ERR || iErr == (int)MSFL.MSFL_Messages.MSFL_MSG_LAST_SECURITY_IN_DIR )
            {
                if ( msflSecurityInfo.szName == stockName && msflSecurityInfo.szSymbol == stockSymbol )
                {
                    iErr = MSFL.MSFL1_LockSecurity( msflSecurityInfo.hSecurity, MSFL.MSFL_LOCK_PREV_WRITE_LOCK );
                    if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                        break;

                    ushort wPriceRecCount = 0;
                    iErr = MSFL.MSFL1_GetDataRecordCount( msflSecurityInfo.hSecurity, ref wPriceRecCount );
                    if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                        break;

                    if ( wPriceRecCount > 0 )
                    {
                        iErr = MSFL.MSFL1_SeekBeginData( msflSecurityInfo.hSecurity );
                        if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                            break;

                        MSFL.DateTime sDateTime = new MSFL.DateTime();
                        msflPriceRecordArray = new MSFL.MSFLPriceRecord[wPriceRecCount];

                        iErr = MSFL.MSFL2_ReadMultipleRecs( msflSecurityInfo.hSecurity, msflPriceRecordArray, ref sDateTime, ref wPriceRecCount, (int)MSFL.MSFL_FIND.MSFL_FIND_USE_CURRENT_POS );
                        if ( iErr != (int)MSFL.MSFL_ERR.MSFL_NO_ERR )
                            break;

                        // Unlock the security (we're done using it)
                        iErr = MSFL.MSFL1_UnlockSecurity( msflSecurityInfo.hSecurity );

                        iErr = MSFL.MSFL1_CloseDirectory( dirNumber );

                        s_PriceDictionary.Add( strStockCode, msflPriceRecordArray );

                        return true;
                    }

                    break;
                }

                if ( iErr == (int)MSFL.MSFL_Messages.MSFL_MSG_LAST_SECURITY_IN_DIR )
                    break;

                iErr = MSFL.MSFL1_GetNextSecurityInfo( msflSecurityInfo.hSecurity, ref msflSecurityInfo );
            }

            MSFL.MSFL1_CloseDirectory( dirNumber );

            return false;
        }

        #region zh-CHS GetStockCode静态方法 | en GetStockCode Static Methods
        public static string GetStockCode( string stockName, string stockSymbol )
        {
            return stockName + "[" + stockSymbol + "]";
        }

        #region zh-CHS 共有的结构 | en Public struct
        public struct StockCode
        {
            public string StockName;
            public string StockSymbol;
        }
        #endregion
        public static StockCode GetStockCode( string stockStockCode )
        {
            StockCode stockCode = new StockCode();

            int iIndex = stockStockCode.IndexOf( '[' );
            stockCode.StockName = stockStockCode.Substring( 0, iIndex );
            stockCode.StockSymbol = stockStockCode.Substring( iIndex + 1, ( stockStockCode.Length - 1 ) - ( iIndex + 1 ) );

            return stockCode;
        }
        #endregion
    }
}
