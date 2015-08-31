using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Stock.LHP.Common;
using System.Xml.Linq;
using System.IO;

namespace Demo.Stock.LHP.BaseSR.Common
{
    public class SROptionFormInfo
    {
        public class GeneralInfo
        {
            public double CKP;

            public int VAn;
            public long VA;

            public int RAPFn;
            public double CPF;
            public double APF;
            public double RAPF;
        }

        public enum BaseScanType
        {
            ScanNow,
            ScanSelect,
        }

        public class SRScanInfo
        {
            public BaseScanType ScanType = BaseScanType.ScanNow;
            public DateTime ScanDateTime = DateTime.Now;
            public float ScanSpace = 5;

            public bool AllowScanDCHP = true;
            public bool AllowDCHP313 = true;
            public bool AllowDCHP214 = true;
            public bool AllowDCHP115 = true;
            public bool AllowDCHP412 = true;
            public bool AllowDCHP511 = true;

            public bool AllowScanDCLP = true;
            public bool AllowDCLP313 = true;
            public bool AllowDCLP214 = true;
            public bool AllowDCLP115 = true;
            public bool AllowDCLP412 = true;
            public bool AllowDCLP511 = true;

            public bool AllowScanGapUp = true;
            public bool AllowGULK = true;
            public bool AllowGUHK = true;
            public float GapUpPS = 0.1F;
            public float GapUpVan = 0.0F;
            public float GapUpVG = 0.0F;

            public bool AllowScanGapDown = true;
            public bool AllowGDLK = true;
            public bool AllowGDHK = true;
            public float GapDownPS = 0.1F;
            public float GapDownVan = 0.0F;
            public float GapDownVG = 0.0F;

            public float SKN = 5.0F;
            public float SAM = 5.0F;

            public float UpTTR = 50.0F;
            public float UpTPR = 50.0F;

            public float DownTTR = 1.0F;
            public float DownTPR = 1.0F;

            public float BDN = 0.0F;
            public float BDP = 0.0F;

            public float BUN = 0.0F;
            public float BUP = 0.0F;
        }

        public enum SelectStockType
        {
            SelectGlobal,
            SelectThis,
        }

        public GeneralInfo m_GeneralInfo = new GeneralInfo();
        public SRScanInfo m_SRScanInfo = new SRScanInfo();

        SelectStockType m_SelectStockType = SelectStockType.SelectGlobal;
        public StockFileInfo[] m_StockFileInfos = new StockFileInfo[0];

        public static SROptionFormInfo LoadOptionFormInfo( string strConfigFile )
        {
            if ( File.Exists( strConfigFile ) == false )
                return null;

            XDocument documentConfig = XDocument.Load( strConfigFile );
            if ( documentConfig == null )
                return null;

            XElement elementRoot = documentConfig.Element( (XName)"Demo.Stock" );
            if ( elementRoot == null )
                return null;

            XAttribute attributeVer = elementRoot.Attribute( (XName)"Ver" );
            if ( attributeVer == null )
                return null;

            SROptionFormInfo optionFormInfo = new SROptionFormInfo();

            ////////////////////////////////////////////////////////////////////////////
            //// <Settings>
            //IEnumerable<XElement> elementStockFileInfos = elementRoot.Elements( (XName)"StockFileInfo" );
            //if ( elementStockFileInfos == null )
            //    return null;

            //List<StockFileInfo> stockFileInfoList = new List<StockFileInfo>();

            //foreach ( var elementStockFileInfo in elementStockFileInfos )
            //{
            //    XAttribute attributeName = elementStockFileInfo.Attribute( (XName)"Name" );
            //    if ( attributeName == null )
            //        continue;

            //    XAttribute attributeSymbol = elementStockFileInfo.Attribute( (XName)"Symbol" );
            //    if ( attributeSymbol == null )
            //        continue;

            //    StockFileInfo stockFileInfo = new StockFileInfo();
            //    stockFileInfo.StockName = attributeName.Value;
            //    stockFileInfo.StockSymbol = attributeSymbol.Value;
            //    stockFileInfo.StockFilePath = elementStockFileInfo.Value;

            //    stockFileInfoList.Add( stockFileInfo );
            //}

            //optionFormInfo.m_StockFileInfos = stockFileInfoList.ToArray();

            //XElement elementScanBaseInfo = elementRoot.Element( (XName)"TriggerInfos" );
            //if ( elementScanBaseInfo == null )
            //    return null;
            //else
            //{
            //    XAttribute attributeAllowTrigger = elementScanBaseInfo.Attribute( (XName)"AllowTrigger" );
            //    if ( attributeAllowTrigger == null )
            //        return null;
            //    else
            //        optionFormInfo.m_TriggerInfos.m_AllowTrigger = bool.Parse( attributeAllowTrigger.Value );
            //}

            return optionFormInfo;
        }

        public static void SaveOptionFormInfo( string strConfigFile, SROptionFormInfo optionFormInfo )
        {
            //if ( optionFormInfo == null )
            //    return;

            //if ( File.Exists( strConfigFile ) == true )
            //    File.Delete( strConfigFile );

            //XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );

            //for ( int iIndex = 0; iIndex < optionFormInfo.m_StockFileInfos.Length; iIndex++ )
            //{
            //    StockFileInfo stockFileInfo = optionFormInfo.m_StockFileInfos[iIndex];

            //    XElement elementStockFileInfo = new XElement( "StockFileInfo", new XAttribute( "Name", stockFileInfo.StockName ) );
            //    elementStockFileInfo.Add( new XAttribute( "Symbol", stockFileInfo.StockSymbol ) );
            //    elementStockFileInfo.Value = stockFileInfo.StockFilePath;

            //    elementRoot.Add( elementStockFileInfo );
            //}

            //XElement elementTriggerInfos = new XElement( "TriggerInfos", new XAttribute( "Ver", "0.0.1.0" ) );
            //{
            //    elementTriggerInfos.Add( new XAttribute( "AllowTrigger", optionFormInfo.m_TriggerInfos.m_AllowTrigger.ToString() ) );
            //}
            //elementRoot.Add( elementTriggerInfos );

            //XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            //documentConfig.Save( strConfigFile );
        }


    }
}
