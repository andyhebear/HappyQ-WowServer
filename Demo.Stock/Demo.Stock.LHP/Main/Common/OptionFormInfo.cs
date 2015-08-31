using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using Demo.Stock.LHP.Common;

namespace Demo.Stock.LHP.Main.Common
{
    public class OptionFormInfo
    {
        public class GeneralInfo
        {
        }

        public GeneralInfo m_GeneralInfo = new GeneralInfo();
        public StockFileInfo[] m_StockFileInfos = new StockFileInfo[0];
        public TriggerInfos m_TriggerInfos = new TriggerInfos();


        private static string s_ConfigFilePath = "Demo.Stock.Config\\Global.config";
        public static string ConfigFilePath
        {
            get { return s_ConfigFilePath; }
            set { s_ConfigFilePath = value; }
        }

        public static OptionFormInfo LoadOptionFormInfo( string strConfigFile )
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

            OptionFormInfo optionFormInfo = new OptionFormInfo();

            //////////////////////////////////////////////////////////////////////////
            // <Settings>
            IEnumerable<XElement> elementStockFileInfos = elementRoot.Elements( (XName)"StockFileInfo" );
            if ( elementStockFileInfos == null )
                return null;

            List<StockFileInfo> stockFileInfoList = new List<StockFileInfo>();

            foreach ( var elementStockFileInfo in elementStockFileInfos )
            {
                XAttribute attributeName = elementStockFileInfo.Attribute( (XName)"Name" );
                if ( attributeName == null )
                    continue;

                XAttribute attributeSymbol = elementStockFileInfo.Attribute( (XName)"Symbol" );
                if ( attributeSymbol == null )
                    continue;

                StockFileInfo stockFileInfo = new StockFileInfo();
                stockFileInfo.StockName = attributeName.Value;
                stockFileInfo.StockSymbol = attributeSymbol.Value;
                stockFileInfo.StockFilePath = elementStockFileInfo.Value;

                stockFileInfoList.Add( stockFileInfo );
            }

            optionFormInfo.m_StockFileInfos = stockFileInfoList.ToArray();

            XElement elementScanBaseInfo = elementRoot.Element( (XName)"TriggerInfos" );
            if ( elementScanBaseInfo == null )
                return null;
            else
            {
                XAttribute attributeAllowTrigger = elementScanBaseInfo.Attribute( (XName)"AllowTrigger" );
                if ( attributeAllowTrigger == null )
                    return null;
                else
                    optionFormInfo.m_TriggerInfos.m_AllowTrigger = bool.Parse( attributeAllowTrigger.Value );
            }

            return optionFormInfo;
        }

        public static void SaveOptionFormInfo( string strConfigFile, OptionFormInfo optionFormInfo )
        {
            if ( optionFormInfo == null )
                return;

            if ( File.Exists( strConfigFile ) == true )
                File.Delete( strConfigFile );

            XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );

            for ( int iIndex = 0; iIndex < optionFormInfo.m_StockFileInfos.Length; iIndex++ )
            {
                StockFileInfo stockFileInfo = optionFormInfo.m_StockFileInfos[iIndex];

                XElement elementStockFileInfo = new XElement( "StockFileInfo", new XAttribute( "Name", stockFileInfo.StockName ) );
                elementStockFileInfo.Add( new XAttribute( "Symbol", stockFileInfo.StockSymbol ) );
                elementStockFileInfo.Value = stockFileInfo.StockFilePath;

                elementRoot.Add( elementStockFileInfo );
            }

            XElement elementTriggerInfos = new XElement( "TriggerInfos", new XAttribute( "Ver", "0.0.1.0" ) );
            {
                elementTriggerInfos.Add( new XAttribute( "AllowTrigger", optionFormInfo.m_TriggerInfos.m_AllowTrigger.ToString() ) );
            }
            elementRoot.Add( elementTriggerInfos );

            XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            documentConfig.Save( strConfigFile );
        }

    }
}
