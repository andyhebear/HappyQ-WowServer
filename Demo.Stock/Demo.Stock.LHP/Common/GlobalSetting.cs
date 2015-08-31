using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace Demo.Stock.LHP.Common
{
    public static class GlobalSetting
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties
        private static string s_ConfigFilePath = "Demo.Stock.Config\\Global.config";
        public static string ConfigFilePath
        {
            get { return s_ConfigFilePath; }
            set { s_ConfigFilePath = value; }
        }

        private static string s_LHPPrimaryScanInfoFilePath = "Demo.Stock.Config\\LHPPrimaryScanInfo.config";
        public static string LHPPrimaryScanInfoFilePath
        {
            get { return s_LHPPrimaryScanInfoFilePath; }
            set { s_LHPPrimaryScanInfoFilePath = value; }
        }

        private static string s_LHPScanInfoFilePath = "Demo.Stock.Config\\LHPScanInfo.config";
        public static string LHPScanInfoFilePath
        {
            get { return s_LHPScanInfoFilePath; }
            set { s_LHPScanInfoFilePath = value; }
        }

        private static bool s_IsShowReport = true;
        public static bool IsShowReport
        {
            get { return s_IsShowReport; }
            set { s_IsShowReport = value; }
        }

        private static StockFileInfo[] s_StockFileInfos = new StockFileInfo[0];
        public static StockFileInfo[] StockFileInfos
        {
            get { return s_StockFileInfos; }
        }

        private static SRReport[] s_SRReports = new SRReport[0];
        public static SRReport[] SRReports
        {
            get { return s_SRReports; }
            set { s_SRReports = value; }
       }
        #endregion

        public static StockFileInfo[] LoadListing( string strConfigFile )
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

            return stockFileInfoList.ToArray();
        }

        public static void SaveListing( string strConfigFile, StockFileInfo[] stockFileInfos )
        {
            if ( stockFileInfos == null )
                return;

            if ( File.Exists( strConfigFile ) == true )
                MessageBox.Show( "文件已经存在!" );

            XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );

            for ( int iIndex = 0; iIndex < stockFileInfos.Length; iIndex++ )
            {
                StockFileInfo stockFileInfo = stockFileInfos[iIndex];

                XElement elementStockFileInfo = new XElement( "StockFileInfo", new XAttribute( "Name", stockFileInfo.StockName ) );
                elementStockFileInfo.Add( new XAttribute( "Symbol", stockFileInfo.StockSymbol ) );
                elementStockFileInfo.Value = stockFileInfo.StockFilePath;

                elementRoot.Add( elementStockFileInfo );
            }

            XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            documentConfig.Save( strConfigFile );
        }

        public static StockFileInfo[] LoadConfigSetting( string strConfigFile )
        {
            if ( File.Exists( strConfigFile ) == false )
            {
                if ( strConfigFile == GlobalSetting.ConfigFilePath )
                    SaveConfigSetting( GlobalSetting.ConfigFilePath, GlobalSetting.StockFileInfos );
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

            return stockFileInfoList.ToArray();
        }

        public static void SaveConfigSetting( string strConfigFile, StockFileInfo[] stockFileInfos )
        {
            if ( stockFileInfos == null )
                return;

            if ( File.Exists( strConfigFile ) == true )
            {
                File.SetAttributes( strConfigFile, FileAttributes.Archive );
                File.Delete( strConfigFile );
            }

            XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );

            for ( int iIndex = 0; iIndex < stockFileInfos.Length; iIndex++ )
            {
                StockFileInfo stockFileInfo = stockFileInfos[iIndex];

                XElement elementStockFileInfo = new XElement( "StockFileInfo", new XAttribute( "Name", stockFileInfo.StockName ) );
                elementStockFileInfo.Add( new XAttribute( "Symbol", stockFileInfo.StockSymbol ) );
                elementStockFileInfo.Value = stockFileInfo.StockFilePath;

                elementRoot.Add( elementStockFileInfo );
            }

            XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            documentConfig.Save( strConfigFile );
        }

        public static LHPPrimaryScanInfo LoadLHPPrimaryScanInfo( string strConfigFile )
        {
            if ( File.Exists( strConfigFile ) == false )
            {
                if ( strConfigFile == GlobalSetting.LHPScanInfoFilePath )
                    SaveLHPScanInfo( GlobalSetting.LHPScanInfoFilePath, new LHPScanInfo() );
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
            XElement elementLHPScanInfo = elementRoot.Element( (XName)"LHPScanInfo" );
            if ( elementLHPScanInfo == null )
                return null;

            LHPPrimaryScanInfo lhpScanInfo = new LHPPrimaryScanInfo();

            XElement elementScanBaseInfo = elementLHPScanInfo.Element( (XName)"ScanBaseInfo" );
            if ( elementScanBaseInfo == null )
                return null;
            else
            {
                XAttribute attributeAllowPSR = elementScanBaseInfo.Attribute( (XName)"AllowPSR" );
                if ( attributeAllowPSR == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowPSR = bool.Parse( attributeAllowPSR.Value );

                XAttribute attributeScanType = elementScanBaseInfo.Attribute( (XName)"ScanType" );
                if ( attributeScanType == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.ScanType = (LHPPrimaryScanInfo.BaseScanType)( int.Parse( attributeScanType.Value ) );

                XAttribute attributeScanSpace = elementScanBaseInfo.Attribute( (XName)"ScanSpace" );
                if ( attributeScanSpace == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.ScanSpace = int.Parse( attributeScanSpace.Value );

                XAttribute attributeAllowScanDCHP = elementScanBaseInfo.Attribute( (XName)"AllowScanDCHP" );
                if ( attributeAllowScanDCHP == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowScanDCHP = bool.Parse( attributeAllowScanDCHP.Value );

                XAttribute attributeAllowDCHP313 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP313" );
                if ( attributeAllowDCHP313 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP313 = bool.Parse( attributeAllowDCHP313.Value );

                XAttribute attributeAllowDCHP214 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP214" );
                if ( attributeAllowDCHP214 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP214 = bool.Parse( attributeAllowDCHP214.Value );

                XAttribute attributeAllowDCHP115 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP115" );
                if ( attributeAllowDCHP115 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP115 = bool.Parse( attributeAllowDCHP115.Value );

                XAttribute attributeAllowDCHP412 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP412" );
                if ( attributeAllowDCHP412 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP412 = bool.Parse( attributeAllowDCHP412.Value );

                XAttribute attributeAllowDCHP511 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP511" );
                if ( attributeAllowDCHP511 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP511 = bool.Parse( attributeAllowDCHP511.Value );

                XAttribute attributeAllowScanDCLP = elementScanBaseInfo.Attribute( (XName)"AllowScanDCLP" );
                if ( attributeAllowScanDCLP == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowScanDCLP = bool.Parse( attributeAllowScanDCLP.Value );

                XAttribute attributeAllowDCLP313 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP313" );
                if ( attributeAllowDCLP313 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP313 = bool.Parse( attributeAllowDCLP313.Value );

                XAttribute attributeAllowDCLP214 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP214" );
                if ( attributeAllowDCLP214 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP214 = bool.Parse( attributeAllowDCLP214.Value );

                XAttribute attributeAllowDCLP115 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP115" );
                if ( attributeAllowDCLP115 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP115 = bool.Parse( attributeAllowDCLP115.Value );

                XAttribute attributeAllowDCLP412 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP412" );
                if ( attributeAllowDCLP412 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP412 = bool.Parse( attributeAllowDCLP412.Value );

                XAttribute attributeAllowDCLP511 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP511" );
                if ( attributeAllowDCLP511 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP511 = bool.Parse( attributeAllowDCLP511.Value );

                XAttribute attributeAllowScanGapUp = elementScanBaseInfo.Attribute( (XName)"AllowScanGapUp" );
                if ( attributeAllowScanGapUp == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowScanGapUp = bool.Parse( attributeAllowScanGapUp.Value );

                XAttribute attributeAllowGULK = elementScanBaseInfo.Attribute( (XName)"AllowGULK" );
                if ( attributeAllowGULK == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowGULK = bool.Parse( attributeAllowGULK.Value );

                XAttribute attributeAllowGUHK = elementScanBaseInfo.Attribute( (XName)"AllowGUHK" );
                if ( attributeAllowGUHK == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowGULK = bool.Parse( attributeAllowGUHK.Value );

                XAttribute attributeGapUpPercentum = elementScanBaseInfo.Attribute( (XName)"GapUpPercentum" );
                if ( attributeGapUpPercentum == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.GapUpPercentum = float.Parse( attributeGapUpPercentum.Value );

                XAttribute attributeAllowScanGapDown = elementScanBaseInfo.Attribute( (XName)"AllowScanGapDown" );
                if ( attributeAllowScanGapDown == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowScanGapDown = bool.Parse( attributeAllowScanGapDown.Value );

                XAttribute attributeAllowGDLK = elementScanBaseInfo.Attribute( (XName)"AllowGDLK" );
                if ( attributeAllowGDLK == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowGDLK = bool.Parse( attributeAllowGDLK.Value );

                XAttribute attributeAllowGDHK = elementScanBaseInfo.Attribute( (XName)"AllowGDHK" );
                if ( attributeAllowGDHK == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowGDHK = bool.Parse( attributeAllowGDHK.Value );

                XAttribute attributeGapDownPercentum = elementScanBaseInfo.Attribute( (XName)"GapDownPercentum" );
                if ( attributeGapDownPercentum == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.GapDownPercentum = float.Parse( attributeGapDownPercentum.Value );
            }

            //XElement elementScanNormalInfo = elementLHPScanInfo.Element( (XName)"ScanNormalInfo" );
            //if ( elementScanNormalInfo == null )
            //    return null;
            //else
            //{
            //    XAttribute attributeAllowScanSR = elementScanNormalInfo.Attribute( (XName)"AllowScanSR" );
            //    if ( attributeAllowScanSR == null )
            //        return null;
            //    else
            //        lhpScanInfo.m_ScanNormalInfo.AllowScanSR = bool.Parse( attributeAllowScanSR.Value );

            //    XAttribute attributeScanDateType = elementScanNormalInfo.Attribute( (XName)"ScanDateType" );
            //    if ( attributeScanDateType == null )
            //        return null;
            //    else
            //        lhpScanInfo.m_ScanNormalInfo.ScanDateType = (LHPPrimaryScanInfo.NormalScanDateType)( int.Parse( attributeScanDateType.Value ) );

            //    XAttribute attributeScanDate = elementScanNormalInfo.Attribute( (XName)"ScanDate" );
            //    if ( attributeScanDate == null )
            //        return null;
            //    else
            //        lhpScanInfo.m_ScanNormalInfo.ScanDate = DateTime.Parse( attributeScanDate.Value );

            //    XElement elementScanTrendInfo = elementScanNormalInfo.Element( (XName)"ScanTrendInfo" );
            //    if ( elementScanTrendInfo == null )
            //        return null;
            //    else
            //    {
            //        XAttribute attributeScanTrendSpace = elementScanTrendInfo.Attribute( (XName)"ScanTrendSpace" );
            //        if ( attributeScanTrendSpace == null )
            //            return null;
            //        else
            //            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace = int.Parse( attributeScanTrendSpace.Value );

            //        XElement elementScanUpTrendInfo = elementScanTrendInfo.Element( (XName)"ScanUpTrendInfo" );
            //        if ( elementScanUpTrendInfo == null )
            //            return null;
            //        else
            //        {
            //            XAttribute attributeScanContinueUpDate = elementScanUpTrendInfo.Attribute( (XName)"ScanContinueUpDate" );
            //            if ( attributeScanContinueUpDate == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanContinueUpDate = int.Parse( attributeScanContinueUpDate.Value );

            //            XAttribute attributeScanUpTrendNeedHigh = elementScanUpTrendInfo.Attribute( (XName)"ScanUpTrendNeedHigh" );
            //            if ( attributeScanUpTrendNeedHigh == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanUpTrendNeedHigh = bool.Parse( attributeScanUpTrendNeedHigh.Value );

            //            XAttribute attributeAllowCheckDCLP = elementScanUpTrendInfo.Attribute( (XName)"AllowCheckDCLP" );
            //            if ( attributeAllowCheckDCLP == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowCheckDCLP = bool.Parse( attributeAllowCheckDCLP.Value );

            //            XAttribute attributeCheckDCLP = elementScanUpTrendInfo.Attribute( (XName)"CheckDCLP" );
            //            if ( attributeCheckDCLP == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.CheckDCLP = (LHPPrimaryScanInfo.NormalTrendCheckDCLP)int.Parse( attributeCheckDCLP.Value );

            //            XAttribute attributeNeedDCLP313 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP313" );
            //            if ( attributeNeedDCLP313 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP313 = bool.Parse( attributeNeedDCLP313.Value );

            //            XAttribute attributeNeedDCLP214 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP214" );
            //            if ( attributeNeedDCLP214 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP214 = bool.Parse( attributeNeedDCLP214.Value );

            //            XAttribute attributeNeedDCLP115 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP115" );
            //            if ( attributeNeedDCLP115 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP115 = bool.Parse( attributeNeedDCLP115.Value );

            //            XAttribute attributeNeedDCLP412 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP412" );
            //            if ( attributeNeedDCLP412 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP412 = bool.Parse( attributeNeedDCLP412.Value );

            //            XAttribute attributeNeedDCLP511 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP511" );
            //            if ( attributeNeedDCLP511 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP511 = bool.Parse( attributeNeedDCLP511.Value );

            //            XAttribute attributeAllowCheckDCHP = elementScanUpTrendInfo.Attribute( (XName)"AllowCheckDCHP" );
            //            if ( attributeAllowCheckDCHP == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowCheckDCHP = bool.Parse( attributeAllowCheckDCHP.Value );

            //            XAttribute attributeCheckDCHP = elementScanUpTrendInfo.Attribute( (XName)"CheckDCHP" );
            //            if ( attributeCheckDCHP == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.CheckDCHP = (LHPPrimaryScanInfo.NormalTrendCheckDCHP)int.Parse( attributeCheckDCHP.Value );

            //            XAttribute attributeExcludeDCHP313 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP313" );
            //            if ( attributeExcludeDCHP313 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP313 = bool.Parse( attributeExcludeDCHP313.Value );

            //            XAttribute attributeExcludeDCHP214 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP214" );
            //            if ( attributeExcludeDCHP214 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP214 = bool.Parse( attributeExcludeDCHP214.Value );

            //            XAttribute attributeExcludeDCHP115 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP115" );
            //            if ( attributeExcludeDCHP115 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP115 = bool.Parse( attributeExcludeDCHP115.Value );

            //            XAttribute attributeExcludeDCHP412 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP412" );
            //            if ( attributeExcludeDCHP412 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP412 = bool.Parse( attributeExcludeDCHP412.Value );

            //            XAttribute attributeExcludeDCHP511 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP511" );
            //            if ( attributeExcludeDCHP511 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP511 = bool.Parse( attributeExcludeDCHP511.Value );
            //        }

            //        XElement elementScanDownTrendInfo = elementScanTrendInfo.Element( (XName)"ScanDownTrendInfo" );
            //        if ( elementScanDownTrendInfo == null )
            //            return null;
            //        else
            //        {
            //            XAttribute attributeScanContinueDownDate = elementScanDownTrendInfo.Attribute( (XName)"ScanContinueDownDate" );
            //            if ( attributeScanContinueDownDate == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanContinueDownDate = int.Parse( attributeScanContinueDownDate.Value );

            //            XAttribute attributeScanDownTrendNeedLow = elementScanDownTrendInfo.Attribute( (XName)"ScanDownTrendNeedLow" );
            //            if ( attributeScanDownTrendNeedLow == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanContinueDownDate = int.Parse( attributeScanContinueDownDate.Value );

            //            XAttribute attributeAllowCheckDCHP = elementScanDownTrendInfo.Attribute( (XName)"AllowCheckDCHP" );
            //            if ( attributeAllowCheckDCHP == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowCheckDCHP = bool.Parse( attributeAllowCheckDCHP.Value );

            //            XAttribute attributeCheckDCHP = elementScanDownTrendInfo.Attribute( (XName)"CheckDCHP" );
            //            if ( attributeCheckDCHP == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.CheckDCHP = (LHPPrimaryScanInfo.NormalTrendCheckDCHP)int.Parse( attributeCheckDCHP.Value );

            //            XAttribute attributeNeedDCHP313 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP313" );
            //            if ( attributeNeedDCHP313 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP313 = bool.Parse( attributeNeedDCHP313.Value );

            //            XAttribute attributeNeedDCHP214 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP214" );
            //            if ( attributeNeedDCHP214 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP214 = bool.Parse( attributeNeedDCHP214.Value );

            //            XAttribute attributeNeedDCHP115 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP115" );
            //            if ( attributeNeedDCHP115 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP115 = bool.Parse( attributeNeedDCHP115.Value );

            //            XAttribute attributeNeedDCHP412 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP412" );
            //            if ( attributeNeedDCHP412 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP412 = bool.Parse( attributeNeedDCHP412.Value );

            //            XAttribute attributeNeedDCHP511 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP511" );
            //            if ( attributeNeedDCHP511 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP511 = bool.Parse( attributeNeedDCHP511.Value );

            //            XAttribute attributeAllowCheckDCLP = elementScanDownTrendInfo.Attribute( (XName)"AllowCheckDCLP" );
            //            if ( attributeAllowCheckDCLP == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowCheckDCLP = bool.Parse( attributeAllowCheckDCLP.Value );

            //            XAttribute attributeCheckDCLP = elementScanDownTrendInfo.Attribute( (XName)"CheckDCLP" );
            //            if ( attributeCheckDCLP == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.CheckDCLP = (LHPPrimaryScanInfo.NormalTrendCheckDCLP)int.Parse( attributeCheckDCLP.Value );


            //            XAttribute attributeExcludeDCLP313 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP313" );
            //            if ( attributeExcludeDCLP313 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP313 = bool.Parse( attributeExcludeDCLP313.Value );

            //            XAttribute attributeExcludeDCLP214 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP214" );
            //            if ( attributeExcludeDCLP214 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP214 = bool.Parse( attributeExcludeDCLP214.Value );

            //            XAttribute attributeExcludeDCLP115 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP115" );
            //            if ( attributeExcludeDCLP115 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP115 = bool.Parse( attributeExcludeDCLP115.Value );

            //            XAttribute attributeExcludeDCLP412 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP412" );
            //            if ( attributeExcludeDCLP412 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP412 = bool.Parse( attributeExcludeDCLP412.Value );

            //            XAttribute attributeExcludeDCLP511 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP511" );
            //            if ( attributeExcludeDCLP511 == null )
            //                return null;
            //            else
            //                lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP511 = bool.Parse( attributeExcludeDCLP511.Value );
            //        }
            //    }
            //}

            return lhpScanInfo;
        }

        public static void SaveLHPPrimaryScanInfo( string strConfigFile, LHPPrimaryScanInfo lhpScanInfo )
        {
            if ( lhpScanInfo == null )
                return;

            if ( File.Exists( strConfigFile ) == true )
            {
                File.SetAttributes( strConfigFile, FileAttributes.Archive );
                File.Delete( strConfigFile );
            }

            XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );
            {
                XElement elementLHPScanInfo = new XElement( "LHPScanInfo" );
                {
                    XElement elementScanBaseInfo = new XElement( "ScanBaseInfo", new XAttribute( "AllowPSR", lhpScanInfo.m_ScanBaseInfo.AllowPSR.ToString() ) );
                    {
                        elementScanBaseInfo.Add( new XAttribute( "ScanType", ( (int)lhpScanInfo.m_ScanBaseInfo.ScanType ).ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "ScanSpace", lhpScanInfo.m_ScanBaseInfo.ScanSpace.ToString() ) );

                        elementScanBaseInfo.Add( new XAttribute( "AllowScanDCHP", lhpScanInfo.m_ScanBaseInfo.AllowScanDCHP.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP313", lhpScanInfo.m_ScanBaseInfo.AllowDCHP313.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP214", lhpScanInfo.m_ScanBaseInfo.AllowDCHP214.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP115", lhpScanInfo.m_ScanBaseInfo.AllowDCHP115.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP412", lhpScanInfo.m_ScanBaseInfo.AllowDCHP412.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP511", lhpScanInfo.m_ScanBaseInfo.AllowDCHP511.ToString() ) );

                        elementScanBaseInfo.Add( new XAttribute( "AllowScanDCLP", lhpScanInfo.m_ScanBaseInfo.AllowScanDCLP.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP313", lhpScanInfo.m_ScanBaseInfo.AllowDCLP313.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP214", lhpScanInfo.m_ScanBaseInfo.AllowDCLP214.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP115", lhpScanInfo.m_ScanBaseInfo.AllowDCLP115.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP412", lhpScanInfo.m_ScanBaseInfo.AllowDCLP412.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP511", lhpScanInfo.m_ScanBaseInfo.AllowDCLP511.ToString() ) );

                        elementScanBaseInfo.Add( new XAttribute( "AllowScanGapUp", lhpScanInfo.m_ScanBaseInfo.AllowScanGapUp.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowGULK", lhpScanInfo.m_ScanBaseInfo.AllowGULK.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowGUHK", lhpScanInfo.m_ScanBaseInfo.AllowGUHK.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "GapUpPercentum", lhpScanInfo.m_ScanBaseInfo.GapUpPercentum.ToString() ) );

                        elementScanBaseInfo.Add( new XAttribute( "AllowScanGapDown", lhpScanInfo.m_ScanBaseInfo.AllowScanGapDown.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowGDLK", lhpScanInfo.m_ScanBaseInfo.AllowGDLK.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowGDHK", lhpScanInfo.m_ScanBaseInfo.AllowGDHK.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "GapDownPercentum", lhpScanInfo.m_ScanBaseInfo.GapDownPercentum.ToString() ) );
                    }
                    elementLHPScanInfo.Add( elementScanBaseInfo );

                    //XElement elementScanNormalInfo = new XElement( "ScanNormalInfo", new XAttribute( "AllowScanSR", lhpScanInfo.m_ScanNormalInfo.AllowScanSR.ToString() ) );
                    //{
                    //    elementScanNormalInfo.Add( new XAttribute( "ScanDateType", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanDateType ).ToString() ) );
                    //    elementScanNormalInfo.Add( new XAttribute( "ScanDate", lhpScanInfo.m_ScanNormalInfo.ScanDate.ToString() ) );

                    //    XElement elementScanTrendInfo = new XElement( "ScanTrendInfo", new XAttribute( "ScanTrendSpace", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace.ToString() ) );
                    //    {
                    //        XElement elementScanUpTrendInfo = new XElement( "ScanUpTrendInfo", new XAttribute( "AllowScanUpTrend", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowScanUpTrend.ToString() ) );
                    //        {
                    //            elementScanUpTrendInfo.Add( new XAttribute( "ScanContinueUpDate", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanContinueUpDate.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "ScanUpTrendNeedHigh", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanUpTrendNeedHigh.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "AllowCheckDCLP", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowCheckDCLP.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "CheckDCLP", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.CheckDCLP ).ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP313", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP313.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP214", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP214.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP115", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP115.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP412", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP412.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP511", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP511.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "AllowCheckDCHP", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowCheckDCHP.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "CheckDCHP", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.CheckDCHP ).ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP313", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP313.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP214", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP214.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP115", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP115.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP412", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP412.ToString() ) );
                    //            elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP511", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP511.ToString() ) );
                    //        }
                    //        elementScanTrendInfo.Add( elementScanUpTrendInfo );

                    //        XElement elementScanDownTrendInfo = new XElement( "ScanDownTrendInfo", new XAttribute( "AllowScanDownTrend", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowScanDownTrend.ToString() ) );
                    //        {
                    //            elementScanDownTrendInfo.Add( new XAttribute( "ScanContinueDownDate", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanContinueDownDate.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "ScanDownTrendNeedLow", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanDownTrendNeedLow.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "AllowCheckDCHP", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowCheckDCHP.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "CheckDCHP", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.CheckDCHP ).ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP313", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP313.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP214", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP214.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP115", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP115.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP412", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP412.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP511", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP511.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "AllowCheckDCLP", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowCheckDCLP.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "CheckDCLP", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.CheckDCLP ).ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP313", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP313.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP214", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP214.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP115", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP115.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP412", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP412.ToString() ) );
                    //            elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP511", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP511.ToString() ) );
                    //        }
                    //        elementScanTrendInfo.Add( elementScanDownTrendInfo );

                    //    }
                    //    elementScanNormalInfo.Add( elementScanTrendInfo );

                    //}
                    //elementLHPScanInfo.Add( elementScanNormalInfo );

                }
                elementRoot.Add( elementLHPScanInfo );

            }

            XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            documentConfig.Save( strConfigFile );
        }

        public static LHPScanInfo LoadLHPScanInfo( string strConfigFile )
        {
            if ( File.Exists( strConfigFile ) == false )
            {
                if ( strConfigFile == GlobalSetting.LHPScanInfoFilePath )
                    SaveLHPScanInfo( GlobalSetting.LHPScanInfoFilePath, new LHPScanInfo() );
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
            XElement elementLHPScanInfo = elementRoot.Element( (XName)"LHPScanInfo" );
            if ( elementLHPScanInfo == null )
                return null;

            LHPScanInfo lhpScanInfo = new LHPScanInfo();

            XElement elementScanBaseInfo = elementLHPScanInfo.Element( (XName)"ScanBaseInfo" );
            if ( elementScanBaseInfo == null )
                return null;
            else
            {
                XAttribute attributeAllowPSR = elementScanBaseInfo.Attribute( (XName)"AllowPSR" );
                if ( attributeAllowPSR == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowPSR = bool.Parse( attributeAllowPSR.Value );

                XAttribute attributeScanType = elementScanBaseInfo.Attribute( (XName)"ScanType" );
                if ( attributeScanType == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.ScanType = (LHPScanInfo.BaseScanType)( int.Parse( attributeScanType.Value ) );

                XAttribute attributeScanSpace = elementScanBaseInfo.Attribute( (XName)"ScanSpace" );
                if ( attributeScanSpace == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.ScanSpace = int.Parse( attributeScanSpace.Value );

                XAttribute attributeAllowScanDCHP = elementScanBaseInfo.Attribute( (XName)"AllowScanDCHP" );
                if ( attributeAllowScanDCHP == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowScanDCHP = bool.Parse( attributeAllowScanDCHP.Value );

                XAttribute attributeAllowDCHP313 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP313" );
                if ( attributeAllowDCHP313 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP313 = bool.Parse( attributeAllowDCHP313.Value );

                XAttribute attributeAllowDCHP214 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP214" );
                if ( attributeAllowDCHP214 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP214 = bool.Parse( attributeAllowDCHP214.Value );

                XAttribute attributeAllowDCHP115 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP115" );
                if ( attributeAllowDCHP115 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP115 = bool.Parse( attributeAllowDCHP115.Value );

                XAttribute attributeAllowDCHP412 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP412" );
                if ( attributeAllowDCHP412 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP412 = bool.Parse( attributeAllowDCHP412.Value );

                XAttribute attributeAllowDCHP511 = elementScanBaseInfo.Attribute( (XName)"AllowDCHP511" );
                if ( attributeAllowDCHP511 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP511 = bool.Parse( attributeAllowDCHP511.Value );

                XAttribute attributeAllowScanDCLP = elementScanBaseInfo.Attribute( (XName)"AllowScanDCLP" );
                if ( attributeAllowScanDCLP == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowScanDCLP = bool.Parse( attributeAllowScanDCLP.Value );

                XAttribute attributeAllowDCLP313 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP313" );
                if ( attributeAllowDCLP313 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP313 = bool.Parse( attributeAllowDCLP313.Value );

                XAttribute attributeAllowDCLP214 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP214" );
                if ( attributeAllowDCLP214 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP214 = bool.Parse( attributeAllowDCLP214.Value );

                XAttribute attributeAllowDCLP115 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP115" );
                if ( attributeAllowDCLP115 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP115 = bool.Parse( attributeAllowDCLP115.Value );

                XAttribute attributeAllowDCLP412 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP412" );
                if ( attributeAllowDCLP412 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP412 = bool.Parse( attributeAllowDCLP412.Value );

                XAttribute attributeAllowDCLP511 = elementScanBaseInfo.Attribute( (XName)"AllowDCLP511" );
                if ( attributeAllowDCLP511 == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP511 = bool.Parse( attributeAllowDCLP511.Value );

                XAttribute attributeAllowScanGapUp = elementScanBaseInfo.Attribute( (XName)"AllowScanGapUp" );
                if ( attributeAllowScanGapUp == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowScanGapUp = bool.Parse( attributeAllowScanGapUp.Value );

                XAttribute attributeAllowGULK = elementScanBaseInfo.Attribute( (XName)"AllowGULK" );
                if ( attributeAllowGULK == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowGULK = bool.Parse( attributeAllowGULK.Value );

                XAttribute attributeAllowGUHK = elementScanBaseInfo.Attribute( (XName)"AllowGUHK" );
                if ( attributeAllowGUHK == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowGULK = bool.Parse( attributeAllowGUHK.Value );

                XAttribute attributeGapUpPercentum = elementScanBaseInfo.Attribute( (XName)"GapUpPercentum" );
                if ( attributeGapUpPercentum == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.GapUpPercentum = int.Parse( attributeGapUpPercentum.Value );

                XAttribute attributeAllowScanGapDown = elementScanBaseInfo.Attribute( (XName)"AllowScanGapDown" );
                if ( attributeAllowScanGapDown == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowScanGapDown = bool.Parse( attributeAllowScanGapDown.Value );

                XAttribute attributeAllowGDLK = elementScanBaseInfo.Attribute( (XName)"AllowGDLK" );
                if ( attributeAllowGDLK == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowGDLK = bool.Parse( attributeAllowGDLK.Value );

                XAttribute attributeAllowGDHK = elementScanBaseInfo.Attribute( (XName)"AllowGDHK" );
                if ( attributeAllowGDHK == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.AllowGDHK = bool.Parse( attributeAllowGDHK.Value );

                XAttribute attributeGapDownPercentum = elementScanBaseInfo.Attribute( (XName)"GapDownPercentum" );
                if ( attributeGapDownPercentum == null )
                    return null;
                else
                    lhpScanInfo.m_ScanBaseInfo.GapDownPercentum = int.Parse( attributeGapDownPercentum.Value );
            }

            XElement elementScanNormalInfo = elementLHPScanInfo.Element( (XName)"ScanNormalInfo" );
            if ( elementScanNormalInfo == null )
                return null;
            else
            {
                XAttribute attributeAllowScanSR = elementScanNormalInfo.Attribute( (XName)"AllowScanSR" );
                if ( attributeAllowScanSR == null )
                    return null;
                else
                    lhpScanInfo.m_ScanNormalInfo.AllowScanSR = bool.Parse( attributeAllowScanSR.Value );

                XAttribute attributeScanDateType = elementScanNormalInfo.Attribute( (XName)"ScanDateType" );
                if ( attributeScanDateType == null )
                    return null;
                else
                    lhpScanInfo.m_ScanNormalInfo.ScanDateType = (LHPScanInfo.NormalScanDateType)( int.Parse( attributeScanDateType.Value ) );

                XAttribute attributeScanDate = elementScanNormalInfo.Attribute( (XName)"ScanDate" );
                if ( attributeScanDate == null )
                    return null;
                else
                    lhpScanInfo.m_ScanNormalInfo.ScanDate = DateTime.Parse( attributeScanDate.Value );

                XElement elementScanTrendInfo = elementScanNormalInfo.Element( (XName)"ScanTrendInfo" );
                if ( elementScanTrendInfo == null )
                    return null;
                else
                {
                    XAttribute attributeScanTrendSpace = elementScanTrendInfo.Attribute( (XName)"ScanTrendSpace" );
                    if ( attributeScanTrendSpace == null )
                        return null;
                    else
                        lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace = int.Parse( attributeScanTrendSpace.Value );

                    XElement elementScanUpTrendInfo = elementScanTrendInfo.Element( (XName)"ScanUpTrendInfo" );
                    if ( elementScanUpTrendInfo == null )
                        return null;
                    else
                    {
                        XAttribute attributeScanContinueUpDate = elementScanUpTrendInfo.Attribute( (XName)"ScanContinueUpDate" );
                        if ( attributeScanContinueUpDate == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanContinueUpDate = int.Parse( attributeScanContinueUpDate.Value );

                        XAttribute attributeScanUpTrendNeedHigh = elementScanUpTrendInfo.Attribute( (XName)"ScanUpTrendNeedHigh" );
                        if ( attributeScanUpTrendNeedHigh == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanUpTrendNeedHigh = bool.Parse( attributeScanUpTrendNeedHigh.Value );

                        XAttribute attributeAllowCheckDCLP = elementScanUpTrendInfo.Attribute( (XName)"AllowCheckDCLP" );
                        if ( attributeAllowCheckDCLP == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowCheckDCLP = bool.Parse( attributeAllowCheckDCLP.Value );

                        XAttribute attributeCheckDCLP = elementScanUpTrendInfo.Attribute( (XName)"CheckDCLP" );
                        if ( attributeCheckDCLP == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.CheckDCLP = (LHPScanInfo.NormalTrendCheckDCLP)int.Parse( attributeCheckDCLP.Value );

                        XAttribute attributeNeedDCLP313 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP313" );
                        if ( attributeNeedDCLP313 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP313 = bool.Parse( attributeNeedDCLP313.Value );

                        XAttribute attributeNeedDCLP214 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP214" );
                        if ( attributeNeedDCLP214 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP214 = bool.Parse( attributeNeedDCLP214.Value );

                        XAttribute attributeNeedDCLP115 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP115" );
                        if ( attributeNeedDCLP115 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP115 = bool.Parse( attributeNeedDCLP115.Value );

                        XAttribute attributeNeedDCLP412 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP412" );
                        if ( attributeNeedDCLP412 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP412 = bool.Parse( attributeNeedDCLP412.Value );

                        XAttribute attributeNeedDCLP511 = elementScanUpTrendInfo.Attribute( (XName)"NeedDCLP511" );
                        if ( attributeNeedDCLP511 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP511 = bool.Parse( attributeNeedDCLP511.Value );

                        XAttribute attributeAllowCheckDCHP = elementScanUpTrendInfo.Attribute( (XName)"AllowCheckDCHP" );
                        if ( attributeAllowCheckDCHP == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowCheckDCHP = bool.Parse( attributeAllowCheckDCHP.Value );

                        XAttribute attributeCheckDCHP = elementScanUpTrendInfo.Attribute( (XName)"CheckDCHP" );
                        if ( attributeCheckDCHP == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.CheckDCHP = (LHPScanInfo.NormalTrendCheckDCHP)int.Parse( attributeCheckDCHP.Value );

                        XAttribute attributeExcludeDCHP313 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP313" );
                        if ( attributeExcludeDCHP313 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP313 = bool.Parse( attributeExcludeDCHP313.Value );

                        XAttribute attributeExcludeDCHP214 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP214" );
                        if ( attributeExcludeDCHP214 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP214 = bool.Parse( attributeExcludeDCHP214.Value );

                        XAttribute attributeExcludeDCHP115 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP115" );
                        if ( attributeExcludeDCHP115 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP115 = bool.Parse( attributeExcludeDCHP115.Value );

                        XAttribute attributeExcludeDCHP412 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP412" );
                        if ( attributeExcludeDCHP412 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP412 = bool.Parse( attributeExcludeDCHP412.Value );

                        XAttribute attributeExcludeDCHP511 = elementScanUpTrendInfo.Attribute( (XName)"ExcludeDCHP511" );
                        if ( attributeExcludeDCHP511 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP511 = bool.Parse( attributeExcludeDCHP511.Value );
                    }

                    XElement elementScanDownTrendInfo = elementScanTrendInfo.Element( (XName)"ScanDownTrendInfo" );
                    if ( elementScanDownTrendInfo == null )
                        return null;
                    else
                    {
                        XAttribute attributeScanContinueDownDate = elementScanDownTrendInfo.Attribute( (XName)"ScanContinueDownDate" );
                        if ( attributeScanContinueDownDate == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanContinueDownDate = int.Parse( attributeScanContinueDownDate.Value );

                        XAttribute attributeScanDownTrendNeedLow = elementScanDownTrendInfo.Attribute( (XName)"ScanDownTrendNeedLow" );
                        if ( attributeScanDownTrendNeedLow == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanContinueDownDate = int.Parse( attributeScanContinueDownDate.Value );

                        XAttribute attributeAllowCheckDCHP = elementScanDownTrendInfo.Attribute( (XName)"AllowCheckDCHP" );
                        if ( attributeAllowCheckDCHP == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowCheckDCHP = bool.Parse( attributeAllowCheckDCHP.Value );

                        XAttribute attributeCheckDCHP = elementScanDownTrendInfo.Attribute( (XName)"CheckDCHP" );
                        if ( attributeCheckDCHP == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.CheckDCHP = (LHPScanInfo.NormalTrendCheckDCHP)int.Parse( attributeCheckDCHP.Value );

                        XAttribute attributeNeedDCHP313 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP313" );
                        if ( attributeNeedDCHP313 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP313 = bool.Parse( attributeNeedDCHP313.Value );

                        XAttribute attributeNeedDCHP214 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP214" );
                        if ( attributeNeedDCHP214 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP214 = bool.Parse( attributeNeedDCHP214.Value );

                        XAttribute attributeNeedDCHP115 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP115" );
                        if ( attributeNeedDCHP115 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP115 = bool.Parse( attributeNeedDCHP115.Value );

                        XAttribute attributeNeedDCHP412 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP412" );
                        if ( attributeNeedDCHP412 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP412 = bool.Parse( attributeNeedDCHP412.Value );

                        XAttribute attributeNeedDCHP511 = elementScanDownTrendInfo.Attribute( (XName)"NeedDCHP511" );
                        if ( attributeNeedDCHP511 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP511 = bool.Parse( attributeNeedDCHP511.Value );

                        XAttribute attributeAllowCheckDCLP = elementScanDownTrendInfo.Attribute( (XName)"AllowCheckDCLP" );
                        if ( attributeAllowCheckDCLP == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowCheckDCLP = bool.Parse( attributeAllowCheckDCLP.Value );

                        XAttribute attributeCheckDCLP = elementScanDownTrendInfo.Attribute( (XName)"CheckDCLP" );
                        if ( attributeCheckDCLP == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.CheckDCLP = (LHPScanInfo.NormalTrendCheckDCLP)int.Parse( attributeCheckDCLP.Value );


                        XAttribute attributeExcludeDCLP313 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP313" );
                        if ( attributeExcludeDCLP313 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP313 = bool.Parse( attributeExcludeDCLP313.Value );

                        XAttribute attributeExcludeDCLP214 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP214" );
                        if ( attributeExcludeDCLP214 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP214 = bool.Parse( attributeExcludeDCLP214.Value );

                        XAttribute attributeExcludeDCLP115 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP115" );
                        if ( attributeExcludeDCLP115 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP115 = bool.Parse( attributeExcludeDCLP115.Value );

                        XAttribute attributeExcludeDCLP412 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP412" );
                        if ( attributeExcludeDCLP412 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP412 = bool.Parse( attributeExcludeDCLP412.Value );

                        XAttribute attributeExcludeDCLP511 = elementScanDownTrendInfo.Attribute( (XName)"ExcludeDCLP511" );
                        if ( attributeExcludeDCLP511 == null )
                            return null;
                        else
                            lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP511 = bool.Parse( attributeExcludeDCLP511.Value );
                    }
                }
            }

            return lhpScanInfo;
        }

        public static void SaveLHPScanInfo( string strConfigFile, LHPScanInfo lhpScanInfo )
        {
            if ( lhpScanInfo == null )
                return;

            if ( File.Exists( strConfigFile ) == true )
            {
                File.SetAttributes( strConfigFile, FileAttributes.Archive );
                File.Delete( strConfigFile );
            }

            XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );
            {
                XElement elementLHPScanInfo = new XElement( "LHPScanInfo" );
                {
                    XElement elementScanBaseInfo = new XElement( "ScanBaseInfo", new XAttribute( "AllowPSR", lhpScanInfo.m_ScanBaseInfo.AllowPSR.ToString() ) );
                    {
                        elementScanBaseInfo.Add( new XAttribute( "ScanType", ( (int)lhpScanInfo.m_ScanBaseInfo.ScanType ).ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "ScanSpace", lhpScanInfo.m_ScanBaseInfo.ScanSpace.ToString() ) );

                        elementScanBaseInfo.Add( new XAttribute( "AllowScanDCHP", lhpScanInfo.m_ScanBaseInfo.AllowScanDCHP.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP313", lhpScanInfo.m_ScanBaseInfo.AllowDCHP313.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP214", lhpScanInfo.m_ScanBaseInfo.AllowDCHP214.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP115", lhpScanInfo.m_ScanBaseInfo.AllowDCHP115.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP412", lhpScanInfo.m_ScanBaseInfo.AllowDCHP412.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCHP511", lhpScanInfo.m_ScanBaseInfo.AllowDCHP511.ToString() ) );

                        elementScanBaseInfo.Add( new XAttribute( "AllowScanDCLP", lhpScanInfo.m_ScanBaseInfo.AllowScanDCLP.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP313", lhpScanInfo.m_ScanBaseInfo.AllowDCLP313.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP214", lhpScanInfo.m_ScanBaseInfo.AllowDCLP214.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP115", lhpScanInfo.m_ScanBaseInfo.AllowDCLP115.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP412", lhpScanInfo.m_ScanBaseInfo.AllowDCLP412.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowDCLP511", lhpScanInfo.m_ScanBaseInfo.AllowDCLP511.ToString() ) );

                        elementScanBaseInfo.Add( new XAttribute( "AllowScanGapUp", lhpScanInfo.m_ScanBaseInfo.AllowScanGapUp.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowGULK", lhpScanInfo.m_ScanBaseInfo.AllowGULK.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowGUHK", lhpScanInfo.m_ScanBaseInfo.AllowGUHK.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "GapUpPercentum", lhpScanInfo.m_ScanBaseInfo.GapUpPercentum.ToString() ) );

                        elementScanBaseInfo.Add( new XAttribute( "AllowScanGapDown", lhpScanInfo.m_ScanBaseInfo.AllowScanGapDown.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowGDLK", lhpScanInfo.m_ScanBaseInfo.AllowGDLK.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "AllowGDHK", lhpScanInfo.m_ScanBaseInfo.AllowGDHK.ToString() ) );
                        elementScanBaseInfo.Add( new XAttribute( "GapDownPercentum", lhpScanInfo.m_ScanBaseInfo.GapDownPercentum.ToString() ) );
                    }
                    elementLHPScanInfo.Add( elementScanBaseInfo );

                    XElement elementScanNormalInfo = new XElement( "ScanNormalInfo", new XAttribute( "AllowScanSR", lhpScanInfo.m_ScanNormalInfo.AllowScanSR.ToString() ) );
                    {
                        elementScanNormalInfo.Add( new XAttribute( "ScanDateType", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanDateType ).ToString() ) );
                        elementScanNormalInfo.Add( new XAttribute( "ScanDate", lhpScanInfo.m_ScanNormalInfo.ScanDate.ToString() ) );

                        XElement elementScanTrendInfo = new XElement( "ScanTrendInfo", new XAttribute( "ScanTrendSpace", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace.ToString() ) );
                        {
                            XElement elementScanUpTrendInfo = new XElement( "ScanUpTrendInfo", new XAttribute( "AllowScanUpTrend", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowScanUpTrend.ToString() ) );
                            {
                                elementScanUpTrendInfo.Add( new XAttribute( "ScanContinueUpDate", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanContinueUpDate.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "ScanUpTrendNeedHigh", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanUpTrendNeedHigh.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "AllowCheckDCLP", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowCheckDCLP.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "CheckDCLP", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.CheckDCLP ).ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP313", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP313.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP214", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP214.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP115", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP115.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP412", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP412.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "NeedDCLP511", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP511.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "AllowCheckDCHP", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowCheckDCHP.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "CheckDCHP", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.CheckDCHP ).ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP313", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP313.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP214", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP214.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP115", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP115.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP412", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP412.ToString() ) );
                                elementScanUpTrendInfo.Add( new XAttribute( "ExcludeDCHP511", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP511.ToString() ) );
                            }
                            elementScanTrendInfo.Add( elementScanUpTrendInfo );

                            XElement elementScanDownTrendInfo = new XElement( "ScanDownTrendInfo", new XAttribute( "AllowScanDownTrend", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowScanDownTrend.ToString() ) );
                            {
                                elementScanDownTrendInfo.Add( new XAttribute( "ScanContinueDownDate", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanContinueDownDate.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "ScanDownTrendNeedLow", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanDownTrendNeedLow.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "AllowCheckDCHP", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowCheckDCHP.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "CheckDCHP", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.CheckDCHP ).ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP313", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP313.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP214", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP214.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP115", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP115.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP412", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP412.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "NeedDCHP511", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP511.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "AllowCheckDCLP", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowCheckDCLP.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "CheckDCLP", ( (int)lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.CheckDCLP ).ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP313", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP313.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP214", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP214.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP115", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP115.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP412", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP412.ToString() ) );
                                elementScanDownTrendInfo.Add( new XAttribute( "ExcludeDCLP511", lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP511.ToString() ) );
                            }
                            elementScanTrendInfo.Add( elementScanDownTrendInfo );

                        }
                        elementScanNormalInfo.Add( elementScanTrendInfo );

                    }
                    elementLHPScanInfo.Add( elementScanNormalInfo );

                }
                elementRoot.Add( elementLHPScanInfo );

            }

            XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            documentConfig.Save( strConfigFile );
        }

        public static SRReport ScanSRStaticData( StockFileInfo stockFileInfo, LHPPrimaryScanInfo lhpScanInfo )
        {
            MSFL.MSFLPriceRecord[] msflPriceRecordArray = new MSFL.MSFLPriceRecord[0];

            if ( GlobalSetting.TryLoadMsflPriceInfo( stockFileInfo.StockName, stockFileInfo.StockSymbol, stockFileInfo.StockFilePath, out msflPriceRecordArray ) == false )
                return null;

            if (msflPriceRecordArray.Length <= 0)
                return null;

            // 开始获取静态数据
            SRStaticData srStaticData = new SRStaticData();

            // 获取最新的股票数据
            SRStaticData.StockData stockData = new SRStaticData.StockData();
            stockData.StockDate = MSFL.FormatDate( msflPriceRecordArray[msflPriceRecordArray.Length - 1].lDate );
            stockData.StockOpen = MSFL.FormatPrice( msflPriceRecordArray[msflPriceRecordArray.Length - 1].fOpen );
            stockData.StockClose = MSFL.FormatPrice( msflPriceRecordArray[msflPriceRecordArray.Length - 1].fClose );
            stockData.StockHigh = MSFL.FormatPrice( msflPriceRecordArray[msflPriceRecordArray.Length - 1].fHigh );
            stockData.StockLow = MSFL.FormatPrice( msflPriceRecordArray[msflPriceRecordArray.Length - 1].fLow );
            stockData.StockVolume = MSFL.FormatVolume( msflPriceRecordArray[msflPriceRecordArray.Length - 1].fVolume );

            // 初始化静态数据
            srStaticData.StockName = stockFileInfo.StockName;
            srStaticData.StockSymbol = stockFileInfo.StockSymbol;
            srStaticData.LastStock = stockData;

            //Debug.WriteLine( "*********************************************************************************" );
            //Debug.WriteLine( "Stock Name = " + srStaticData.StockName );
            //Debug.WriteLine( "Stock Symbol = " + srStaticData.StockSymbol );
            //Debug.WriteLine( string.Empty );
            //Debug.WriteLine( "---------------------------------------------------------------------------------");
            //Debug.WriteLine( "LastStock = " );
            //Debug.WriteLine( "           Stock Date = " + srStaticData.LastStock.StockDate.ToShortDateString() );
            //Debug.WriteLine( "           Stock Open =  " + srStaticData.LastStock.StockOpen.ToString() );
            //Debug.WriteLine( "           Stock Close =  " + srStaticData.LastStock.StockClose.ToString() );
            //Debug.WriteLine( "           Stock High =  " + srStaticData.LastStock.StockHigh.ToString() );
            //Debug.WriteLine( "           Stock Low =  " + srStaticData.LastStock.StockLow.ToString() );
            //Debug.WriteLine( "           Stock Volume =  " + srStaticData.LastStock.StockVolume.ToString() );
            //Debug.WriteLine( "---------------------------------------------------------------------------------" );
            //Debug.WriteLine( string.Empty );

            int iScanSpace = lhpScanInfo.m_ScanBaseInfo.ScanSpace > 0 ? lhpScanInfo.m_ScanBaseInfo.ScanSpace : int.MaxValue;

            List<SRStaticData.SRStaticInfo> listStaticInfo = new List<SRStaticData.SRStaticInfo>();
            for ( int iIndex = msflPriceRecordArray.Length - 2, iIndexQQQ = 0; iIndex >= 0 && iIndexQQQ < iScanSpace; iIndex--, iIndexQQQ++ )
            {
                MSFL.MSFLPriceRecord msflPriceRecord = msflPriceRecordArray[iIndex];

                DateTime stockDate = MSFL.FormatDate( msflPriceRecord.lDate );
                float fHigh = MSFL.FormatPrice( msflPriceRecord.fHigh );
                float fLow = MSFL.FormatPrice( msflPriceRecord.fLow );
                float fOpen = MSFL.FormatPrice( msflPriceRecord.fOpen );
                float fClose = MSFL.FormatPrice( msflPriceRecord.fClose );
                float fVolume = MSFL.FormatPrice( msflPriceRecord.fVolume );

                SRStaticData.SRStaticInfo staticInfo = new SRStaticData.SRStaticInfo();

                if ( lhpScanInfo.m_ScanBaseInfo.AllowScanGapUp == true && 
                    lhpScanInfo.m_ScanBaseInfo.AllowGULK == true && 
                    GlobalSetting.IsGULK( iIndex, msflPriceRecordArray ) == true )
                {
                    float fHKLow = MSFL.FormatPrice( msflPriceRecordArray[iIndex + 1].fLow );

                    if ( ( ( fHKLow - fHigh ) / fHigh * 100 ) >= lhpScanInfo.m_ScanBaseInfo.GapUpPercentum )
                    {
                        staticInfo.SRPointType |= SRStaticData.SRPointType.GULK;

                        float fEntity = fOpen > fClose ? fOpen : fClose;

                        staticInfo.GapPercentum = ( fLow - fHigh ) / fEntity;
                        staticInfo.StockAverageHigh = MSFL.FormatPrice( fEntity + ( fHigh - fEntity ) / 2 );

                        int iLeftCount = 0;
                        for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                        {
                            MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                            float fLeftHigh = MSFL.FormatPrice( msflPriceRecordLeft.fHigh );

                            if ( fLeftHigh < fHigh )
                                iLeftCount++;
                            else
                                break;
                        }

                        int iRightCount = 0;
                        for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                        {
                            MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                            float fRightHigh = MSFL.FormatPrice( msflPriceRecordRight.fHigh );

                            if ( fRightHigh < fHigh )
                                iRightCount++;
                            else
                                break;
                        }

                        staticInfo.LeftKLineNumber = iLeftCount;
                        staticInfo.RightLineNumber = iRightCount;

                        if ( fHigh > srStaticData.MaxDCHP )
                            srStaticData.MaxDCHP = fHigh;
                    }
                }

                if ( lhpScanInfo.m_ScanBaseInfo.AllowScanGapUp == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowGUHK == true &&
                    GlobalSetting.IsGUHK( iIndex, msflPriceRecordArray ) == true )
                {
                    float fLKHigh = MSFL.FormatPrice( msflPriceRecordArray[iIndex - 1].fHigh );

                    if ( ( ( fLow - fLKHigh ) / fLKHigh * 100 ) >= lhpScanInfo.m_ScanBaseInfo.GapUpPercentum )
                    {
                        staticInfo.SRPointType |= SRStaticData.SRPointType.GUHK;

                        float fAverageGapVolume = 0;
                        for ( int i2 = iIndex, k = 0; i2 >= 0 && k < 20; i2--, k++ )
                        {
                            float gapVolume = MSFL.FormatVolume( msflPriceRecordArray[i2].fVolume );

                            fAverageGapVolume += gapVolume;
                        }

                        fAverageGapVolume = fAverageGapVolume / 20;
                        staticInfo.GapVolumePercentum = MSFL.FormatVolume( ( ( fVolume - fAverageGapVolume ) / fAverageGapVolume ) * 100 );

                        float fLKOpen = MSFL.FormatPrice( msflPriceRecordArray[iIndex - 1].fOpen );
                        float fLKClose = MSFL.FormatPrice( msflPriceRecordArray[iIndex - 1].fClose );
                        float fLKEntity = fLKOpen > fLKClose ? fLKOpen : fLKClose;

                        float fEntity = fOpen < fClose ? fOpen : fClose;

                        staticInfo.GapPercentum = ( fLow - fLKHigh ) / fLKEntity;
                        staticInfo.GapPriceSpace = MSFL.FormatPrice( ( ( fLow - fLKHigh ) / fLKHigh * 100 ) );
                        staticInfo.StockAverageLow = MSFL.FormatPrice( fLow + ( fEntity - fLow ) / 2 );

                        int iLeftCount = 0;
                        for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                        {
                            MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                            float fLeftLow = MSFL.FormatPrice( msflPriceRecordLeft.fLow );

                            if ( fLeftLow > fLow )
                                iLeftCount++;
                            else
                                break;
                        }

                        int iRightCount = 0;
                        for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                        {
                            MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                            float fRightLow = MSFL.FormatPrice( msflPriceRecordRight.fLow );

                            if ( fRightLow > fLow )
                                iRightCount++;
                            else
                                break;
                        }

                        staticInfo.LeftKLineNumber = iLeftCount;
                        staticInfo.RightLineNumber = iRightCount;

                        if ( fLow < srStaticData.MinDCLP )
                            srStaticData.MinDCLP = fLow;
                    }
                }


                if ( lhpScanInfo.m_ScanBaseInfo.AllowScanGapDown == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowGDLK == true &&
                    GlobalSetting.IsGDLK( iIndex, msflPriceRecordArray ) == true )
                {
                    float fHKLow = MSFL.FormatPrice( msflPriceRecordArray[iIndex - 1].fLow );

                    if ( ( ( fHKLow - fHigh ) / fHigh * 100 ) >= lhpScanInfo.m_ScanBaseInfo.GapDownPercentum )
                    {
                        staticInfo.SRPointType |= SRStaticData.SRPointType.GDLK;

                        float fAverageGapVolume = 0;
                        for ( int i2 = iIndex, k = 0; i2 >= 0 && k < 20; i2--, k++ )
                        {
                            float gapVolume = MSFL.FormatVolume( msflPriceRecordArray[i2].fVolume );

                            fAverageGapVolume += gapVolume;
                        }

                        fAverageGapVolume = fAverageGapVolume / 20;
                        staticInfo.GapVolumePercentum = MSFL.FormatVolume( ( ( fVolume - fAverageGapVolume ) / fAverageGapVolume ) * 100 );

                        float fHKOpen = MSFL.FormatPrice( msflPriceRecordArray[iIndex - 1].fOpen );
                        float fHKClose = MSFL.FormatPrice( msflPriceRecordArray[iIndex - 1].fClose );
                        float fHKEntity = fHKOpen < fHKClose ? fHKOpen : fHKClose;

                        float fEntity = fOpen > fClose ? fOpen : fClose;

                        staticInfo.GapPercentum = ( fHKLow - fHigh ) / fHKEntity;
                        staticInfo.GapPriceSpace = MSFL.FormatPrice( ( ( fHKLow - fHigh ) / fHigh * 100 ) );
                        staticInfo.StockAverageHigh = MSFL.FormatPrice( fEntity + ( fHigh - fEntity ) / 2 );

                        int iLeftCount = 0;
                        for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                        {
                            MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                            float fLeftHigh = MSFL.FormatPrice( msflPriceRecordLeft.fHigh );

                            if ( fLeftHigh < fHigh )
                                iLeftCount++;
                            else
                                break;
                        }

                        int iRightCount = 0;
                        for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                        {
                            MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                            float fRightHigh = MSFL.FormatPrice( msflPriceRecordRight.fHigh );

                            if ( fRightHigh < fHigh )
                                iRightCount++;
                            else
                                break;
                        }

                        staticInfo.LeftKLineNumber = iLeftCount;
                        staticInfo.RightLineNumber = iRightCount;

                        if ( fHigh > srStaticData.MaxDCHP )
                            srStaticData.MaxDCHP = fHigh;
                    }
                }

                if ( lhpScanInfo.m_ScanBaseInfo.AllowScanGapDown == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowGDHK == true && 
                    GlobalSetting.IsGDHK( iIndex, msflPriceRecordArray ) == true )
                {
                    float fLKHigh = MSFL.FormatPrice( msflPriceRecordArray[iIndex + 1].fHigh );

                    if ( ( ( fLow - fLKHigh ) / fLKHigh * 100 ) >= lhpScanInfo.m_ScanBaseInfo.GapDownPercentum )
                    {
                        staticInfo.SRPointType |= SRStaticData.SRPointType.GDHK;

                        float fEntity = fOpen < fClose ? fOpen : fClose;

                        staticInfo.GapPercentum = ( fLow - fLKHigh ) / fEntity;
                        staticInfo.StockAverageLow = MSFL.FormatPrice( fLow + ( fEntity - fLow ) / 2 );

                        int iLeftCount = 0;
                        for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                        {
                            MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                            float fLeftLow = MSFL.FormatPrice( msflPriceRecordLeft.fLow );

                            if ( fLeftLow > fLow )
                                iLeftCount++;
                            else
                                break;
                        }

                        int iRightCount = 0;
                        for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                        {
                            MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                            float fRightLow = MSFL.FormatPrice( msflPriceRecordRight.fLow );

                            if ( fRightLow > fLow )
                                iRightCount++;
                            else
                                break;
                        }

                        staticInfo.LeftKLineNumber = iLeftCount;
                        staticInfo.RightLineNumber = iRightCount;

                        if ( fLow < srStaticData.MinDCLP )
                            srStaticData.MinDCLP = fLow;
                    }
                }

                if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCLP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP313 == true && 
                    GlobalSetting.IsDCLP_313( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType = SRStaticData.SRPointType.DCLP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_313;

                    float fEntity = fOpen < fClose ? fOpen : fClose;

                    staticInfo.StockAverageLow = MSFL.FormatPrice( fLow + ( fEntity - fLow ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftLow = MSFL.FormatPrice( msflPriceRecordLeft.fLow );

                        if ( fLeftLow > fLow )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightLow = MSFL.FormatPrice( msflPriceRecordRight.fLow );

                        if ( fRightLow > fLow )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fLow < srStaticData.MinDCLP )
                        srStaticData.MinDCLP = fLow;
                }
                else if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCLP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP214 == true && 
                    GlobalSetting.IsDCLP_214( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType |= SRStaticData.SRPointType.DCLP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_214;

                    float fEntity = fOpen < fClose ? fOpen : fClose;

                    staticInfo.StockAverageLow = MSFL.FormatPrice( fLow + ( fEntity - fLow ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftLow = MSFL.FormatPrice( msflPriceRecordLeft.fLow );

                        if ( fLeftLow > fLow )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightLow = MSFL.FormatPrice( msflPriceRecordRight.fLow );

                        if ( fRightLow > fLow )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fLow < srStaticData.MinDCLP )
                        srStaticData.MinDCLP = fLow;
                }
                else if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCLP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP115 == true && 
                    GlobalSetting.IsDCLP_115( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType |= SRStaticData.SRPointType.DCLP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_115;

                    float fEntity = fOpen < fClose ? fOpen : fClose;

                    staticInfo.StockAverageLow = MSFL.FormatPrice( fLow + ( fEntity - fLow ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftLow = MSFL.FormatPrice( msflPriceRecordLeft.fLow );

                        if ( fLeftLow > fLow )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightLow = MSFL.FormatPrice( msflPriceRecordRight.fLow );

                        if ( fRightLow > fLow )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fLow < srStaticData.MinDCLP )
                        srStaticData.MinDCLP = fLow;
                }
                else if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCLP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP412 == true && 
                    GlobalSetting.IsDCLP_412( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType |= SRStaticData.SRPointType.DCLP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_412;

                    float fEntity = fOpen < fClose ? fOpen : fClose;

                    staticInfo.StockAverageLow = MSFL.FormatPrice( fLow + ( fEntity - fLow ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftLow = MSFL.FormatPrice( msflPriceRecordLeft.fLow );

                        if ( fLeftLow > fLow )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightLow = MSFL.FormatPrice( msflPriceRecordRight.fLow );

                        if ( fRightLow > fLow )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fLow < srStaticData.MinDCLP )
                        srStaticData.MinDCLP = fLow;
                }
                else if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCLP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCLP511 == true && 
                    GlobalSetting.IsDCLP_511( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType |= SRStaticData.SRPointType.DCLP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_511;

                    float fEntity = fOpen < fClose ? fOpen : fClose;

                    staticInfo.StockAverageLow = MSFL.FormatPrice( fLow + ( fEntity - fLow ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftLow = MSFL.FormatPrice( msflPriceRecordLeft.fLow );

                        if ( fLeftLow > fLow )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightLow = MSFL.FormatPrice( msflPriceRecordRight.fLow );

                        if ( fRightLow > fLow )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fLow < srStaticData.MinDCLP )
                        srStaticData.MinDCLP = fLow;
                }

                if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCHP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP313 == true && 
                    GlobalSetting.IsDCHP_313( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType |= SRStaticData.SRPointType.DCHP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_313;

                    float fEntity = fOpen > fClose ? fOpen : fClose;

                    staticInfo.StockAverageHigh = MSFL.FormatPrice( fEntity + ( fHigh - fEntity ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftHigh = MSFL.FormatPrice( msflPriceRecordLeft.fHigh );

                        if ( fLeftHigh < fHigh )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightHigh = MSFL.FormatPrice( msflPriceRecordRight.fHigh );

                        if ( fRightHigh < fHigh )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fHigh > srStaticData.MaxDCHP )
                        srStaticData.MaxDCHP = fHigh;
                }
                else if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCHP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP214 == true && 
                    GlobalSetting.IsDCHP_214( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType |= SRStaticData.SRPointType.DCHP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_214;

                    float fEntity = fOpen > fClose ? fOpen : fClose;

                    staticInfo.StockAverageHigh = MSFL.FormatPrice( fEntity + ( fHigh - fEntity ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftHigh = MSFL.FormatPrice( msflPriceRecordLeft.fHigh );

                        if ( fLeftHigh < fHigh )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightHigh = MSFL.FormatPrice( msflPriceRecordRight.fHigh );

                        if ( fRightHigh < fHigh )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fHigh > srStaticData.MaxDCHP )
                        srStaticData.MaxDCHP = fHigh;
                }
                else if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCHP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP115 == true && 
                    GlobalSetting.IsDCHP_115( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType |= SRStaticData.SRPointType.DCHP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_115;

                    float fEntity = fOpen > fClose ? fOpen : fClose;

                    staticInfo.StockAverageHigh = MSFL.FormatPrice( fEntity + ( fHigh - fEntity ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftHigh = MSFL.FormatPrice( msflPriceRecordLeft.fHigh );

                        if ( fLeftHigh < fHigh )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightHigh = MSFL.FormatPrice( msflPriceRecordRight.fHigh );

                        if ( fRightHigh < fHigh )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fHigh > srStaticData.MaxDCHP )
                        srStaticData.MaxDCHP = fHigh;
                }
                else if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCHP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP412 == true && 
                    GlobalSetting.IsDCHP_412( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType |= SRStaticData.SRPointType.DCHP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_412;

                    float fEntity = fOpen > fClose ? fOpen : fClose;

                    staticInfo.StockAverageHigh = MSFL.FormatPrice( fEntity + ( fHigh - fEntity ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftHigh = MSFL.FormatPrice( msflPriceRecordLeft.fHigh );

                        if ( fLeftHigh < fHigh )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightHigh = MSFL.FormatPrice( msflPriceRecordRight.fHigh );

                        if ( fRightHigh < fHigh )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fHigh > srStaticData.MaxDCHP )
                        srStaticData.MaxDCHP = fHigh;
                }
                else if ( lhpScanInfo.m_ScanBaseInfo.AllowScanDCHP == true &&
                    lhpScanInfo.m_ScanBaseInfo.AllowDCHP511 == true && 
                    GlobalSetting.IsDCHP_511( iIndex, msflPriceRecordArray ) == true )
                {
                    staticInfo.SRPointType |= SRStaticData.SRPointType.DCHP;
                    staticInfo.DCPointType = SRStaticData.DCPointType.DC_511;

                    float fEntity = fOpen > fClose ? fOpen : fClose;

                    staticInfo.StockAverageHigh = MSFL.FormatPrice( fEntity + ( fHigh - fEntity ) / 2 );

                    int iLeftCount = 0;
                    for ( int iIndexLeft = iIndex - 1; iIndexLeft >= 0; iIndexLeft-- )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordLeft = msflPriceRecordArray[iIndexLeft];

                        float fLeftHigh = MSFL.FormatPrice( msflPriceRecordLeft.fHigh );

                        if ( fLeftHigh < fHigh )
                            iLeftCount++;
                        else
                            break;
                    }

                    int iRightCount = 0;
                    for ( int iIndexRight = iIndex + 1; iIndexRight < msflPriceRecordArray.Length; iIndexRight++ )
                    {
                        MSFL.MSFLPriceRecord msflPriceRecordRight = msflPriceRecordArray[iIndexRight];

                        float fRightHigh = MSFL.FormatPrice( msflPriceRecordRight.fHigh );

                        if ( fRightHigh < fHigh )
                            iRightCount++;
                        else
                            break;
                    }

                    staticInfo.LeftKLineNumber = iLeftCount;
                    staticInfo.RightLineNumber = iRightCount;

                    if ( fHigh > srStaticData.MaxDCHP )
                        srStaticData.MaxDCHP = fHigh;
                }

                if ( staticInfo.SRPointType == SRStaticData.SRPointType.None )
                    continue;

                SRStaticData.StockData stockDataX = new SRStaticData.StockData();
                stockDataX.StockDate = MSFL.FormatDate( msflPriceRecord.lDate );
                stockDataX.StockOpen = MSFL.FormatPrice( msflPriceRecord.fOpen );
                stockDataX.StockHigh = MSFL.FormatPrice( msflPriceRecord.fHigh );
                stockDataX.StockLow = MSFL.FormatPrice( msflPriceRecord.fLow );
                stockDataX.StockClose = MSFL.FormatPrice( msflPriceRecord.fClose );
                stockDataX.StockVolume = MSFL.FormatVolume( msflPriceRecord.fVolume );

                staticInfo.StockData = stockDataX;

                listStaticInfo.Add( staticInfo );
            }
            srStaticData.srStaticInfoArray = listStaticInfo.ToArray();

            List<SRStaticData.SRTrendInfo> listTrendInfo = new List<SRStaticData.SRTrendInfo>();
            for ( int iIndex = 0; iIndex < ( srStaticData.srStaticInfoArray.Length - 1 ); iIndex++ )
            {
                SRStaticData.SRStaticInfo srStaticInfoA = srStaticData.srStaticInfoArray[iIndex];

                for ( int iIndex2 = iIndex + 1; iIndex2 < srStaticData.srStaticInfoArray.Length; iIndex2++ )
                {
                    SRStaticData.SRStaticInfo srStaticInfoB = srStaticData.srStaticInfoArray[iIndex2];

                    if ( srStaticInfoA.StockData.StockDate <= srStaticInfoB.StockData.StockDate )
                        continue;

                    if ( ( (srStaticInfoA.SRPointType & SRStaticData.SRPointType.DCHP) == SRStaticData.SRPointType.DCHP ||
                        ( srStaticInfoA.SRPointType & SRStaticData.SRPointType.GULK ) == SRStaticData.SRPointType.GULK ||
                        ( srStaticInfoA.SRPointType & SRStaticData.SRPointType.GDLK ) == SRStaticData.SRPointType.GDLK )

                        &&

                        ( ( srStaticInfoB.SRPointType & SRStaticData.SRPointType.DCHP ) == SRStaticData.SRPointType.DCHP ||
                        ( srStaticInfoB.SRPointType & SRStaticData.SRPointType.GULK ) == SRStaticData.SRPointType.GULK ||
                        ( srStaticInfoB.SRPointType & SRStaticData.SRPointType.GDLK ) == SRStaticData.SRPointType.GDLK ) )
                    {
                        if ( srStaticInfoA.StockData.StockHigh < srStaticInfoB.StockData.StockHigh )
                        {
                            SRStaticData.SRTrendInfo srTrendInfo = new SRStaticData.SRTrendInfo();
                            srTrendInfo.SRStaticInfoA = srStaticInfoA;
                            srTrendInfo.SRStaticInfoB = srStaticInfoB;
                            srTrendInfo.TrendInfo = SRStaticData.TrendType.Down;
                            srTrendInfo.GUID = Guid.NewGuid().ToString(); // 

                            listTrendInfo.Add( srTrendInfo );
                        }
                    }
                    else if ( ( ( srStaticInfoA.SRPointType & SRStaticData.SRPointType.DCLP ) == SRStaticData.SRPointType.DCLP ||
                        ( srStaticInfoA.SRPointType & SRStaticData.SRPointType.GUHK ) == SRStaticData.SRPointType.GUHK ||
                        ( srStaticInfoA.SRPointType & SRStaticData.SRPointType.GDHK ) == SRStaticData.SRPointType.GDHK )
                        
                        &&
                        ( ( srStaticInfoB.SRPointType & SRStaticData.SRPointType.DCLP ) == SRStaticData.SRPointType.DCLP ||
                        ( srStaticInfoB.SRPointType & SRStaticData.SRPointType.GUHK ) == SRStaticData.SRPointType.GUHK ||
                        ( srStaticInfoB.SRPointType & SRStaticData.SRPointType.GDHK ) == SRStaticData.SRPointType.GDHK ) )
                    {
                        if ( srStaticInfoA.StockData.StockLow > srStaticInfoB.StockData.StockLow )
                        {
                            SRStaticData.SRTrendInfo srTrendInfo = new SRStaticData.SRTrendInfo();
                            srTrendInfo.SRStaticInfoA = srStaticInfoA;
                            srTrendInfo.SRStaticInfoB = srStaticInfoB;
                            srTrendInfo.TrendInfo = SRStaticData.TrendType.Up;
                            srTrendInfo.GUID = Guid.NewGuid().ToString(); // 

                            listTrendInfo.Add( srTrendInfo );
                        }
                    }
                    else
                        break;
                }
            }
            srStaticData.srTrendInfoArray = listTrendInfo.ToArray();

            SetStaticRelativelyNumber( srStaticData );
            SetTrendRelativelyNumber( srStaticData );

            // 开始计算动态值
            SRDynamicData srDynamicData = new SRDynamicData();

            // 初始化动态值
            srDynamicData.StockName = stockFileInfo.StockName;
            srDynamicData.StockSymbol = stockFileInfo.StockSymbol;

            for ( int i = ( msflPriceRecordArray.Length - 1 ); i >= 0; i-- )
            {
                MSFL.MSFLPriceRecord msflPriceRecord = msflPriceRecordArray[i];

                DateTime stockDate = MSFL.FormatDate( msflPriceRecord.lDate );

                if ( lhpScanInfo.m_ScanNormalInfo.ScanDate >= stockDate )
                {
                    SRDynamicData.StockData stockDataCurrent = new SRDynamicData.StockData();
                    stockDataCurrent.StockDate = stockDate;
                    stockDataCurrent.StockOpen = MSFL.FormatPrice( msflPriceRecord.fOpen );
                    stockDataCurrent.StockHigh = MSFL.FormatPrice( msflPriceRecord.fHigh );
                    stockDataCurrent.StockLow = MSFL.FormatPrice( msflPriceRecord.fLow );
                    stockDataCurrent.StockClose = MSFL.FormatPrice( msflPriceRecord.fClose );
                    stockDataCurrent.StockVolume = MSFL.FormatVolume( msflPriceRecord.fVolume );

                    // 初始化动态值当前的股票
                    srDynamicData.CurrentStock = stockDataCurrent;

                    srDynamicData.StockCPF = MSFL.FormatPrice( stockDataCurrent.StockHigh - stockDataCurrent.StockLow );
                    srDynamicData.StockCRPF = MSFL.FormatPrice( srDynamicData.StockCPF / stockDataCurrent.StockClose );

                    if ( i > 1 )
                    {
                        float fPerClose = MSFL.FormatPrice( msflPriceRecordArray[i - 1].fClose );

                        if ( fPerClose < stockDataCurrent.StockClose )
                        {
                            srDynamicData.PriceFloat = MSFL.FormatPrice( ( stockDataCurrent.StockClose - fPerClose ) / stockDataCurrent.StockClose );
                        }
                        else if ( fPerClose > stockDataCurrent.StockClose )
                        {
                            srDynamicData.PriceFloat = MSFL.FormatPrice( -( ( fPerClose - stockDataCurrent.StockClose ) / stockDataCurrent.StockClose ) );
                        }
                        else
                            srDynamicData.PriceFloat = 0F;
                    }

                    float fAverageAPF = 0;
                    float fAverageARPF = 0;
                    for ( int i2 = i, k = 0; i2 >= 0 && k < 20; i2--, k++ )
                    {
                        float fHigh = MSFL.FormatPrice( msflPriceRecordArray[i2].fHigh );
                        float fLow = MSFL.FormatPrice( msflPriceRecordArray[i2].fLow );
                        float fClose = MSFL.FormatPrice( msflPriceRecordArray[i2].fClose );

                        fAverageAPF += ( fHigh + fLow );
                        fAverageARPF += fAverageAPF / fClose;
                    }

                    srDynamicData.StockAPF = MSFL.FormatPrice( fAverageAPF / 20 );
                    srDynamicData.StockARPF = MSFL.FormatPrice( fAverageARPF / 20 );

                    List<SRDynamicData.TrendData> listTrendData = new List<SRDynamicData.TrendData>();
                    for ( int iIndex = 0; iIndex < ( srStaticData.srTrendInfoArray.Length - 1 ); iIndex++ )
                    {
                        SRStaticData.SRTrendInfo srSRTrendInfo = srStaticData.srTrendInfoArray[iIndex];

                        SRDynamicData.TrendData trendData = new SRDynamicData.TrendData();
                        trendData.GUID = srSRTrendInfo.GUID;
                        trendData.SRTrendInfo = srSRTrendInfo;
                        trendData.CSR = 0;

                        if ( srSRTrendInfo.SRStaticInfoA.StockData.StockDate >= stockDataCurrent.StockDate || srSRTrendInfo.SRStaticInfoB.StockData.StockDate >= stockDataCurrent.StockDate )
                            break;

                        int iNumMin = 0;
                        int iNumMax = 0;

                        int iNum = 1;
                        for ( int i6 = i; i6 >= 0; i6-- )
                        {
                            MSFL.MSFLPriceRecord msflPriceRecordX = msflPriceRecordArray[i6];

                            DateTime stockDateX = MSFL.FormatDate( msflPriceRecordX.lDate );

                            if ( stockDateX == srSRTrendInfo.SRStaticInfoA.StockData.StockDate )
                                iNumMin = iNum;

                            if ( stockDateX == srSRTrendInfo.SRStaticInfoB.StockData.StockDate )
                                iNumMax = iNum;

                            iNum++;
                        }
                        
                        if (srSRTrendInfo.TrendInfo == SRStaticData.TrendType.Down )
                        {
                            float G = ( srSRTrendInfo.SRStaticInfoA.StockData.StockHigh - srSRTrendInfo.SRStaticInfoB.StockData.StockHigh ) / ( iNumMax - iNumMin );
                            float DTLP = srSRTrendInfo.SRStaticInfoA.StockData.StockHigh - G * ( iNumMax - 1 );
                            trendData.CSR = MSFL.FormatPrice( DTLP );
                        }
                        else if (srSRTrendInfo.TrendInfo == SRStaticData.TrendType.Up)
                        {
                            float G = ( srSRTrendInfo.SRStaticInfoA.StockData.StockLow - srSRTrendInfo.SRStaticInfoB.StockData.StockLow ) / ( iNumMax - iNumMin );
                            float DTLP = srSRTrendInfo.SRStaticInfoA.StockData.StockLow - G * ( iNumMax - 1 );
                            trendData.CSR = MSFL.FormatPrice( DTLP );
                        }
                        else
                            break;

                        listTrendData.Add( trendData );
                    }
                    srDynamicData.srTrendDataArray = listTrendData.ToArray();

                    break;
                }
            }

            float fSRCK_R = float.MaxValue;
            float fSRCK_S = float.MinValue;
            for ( int iA = 0; iA < srStaticData.srStaticInfoArray.Length; iA++ )
            {
                SRStaticData.SRStaticInfo SRStaticInfo = srStaticData.srStaticInfoArray[iA];

                if ( ( SRStaticInfo.SRPointType & SRStaticData.SRPointType.DCHP ) == SRStaticData.SRPointType.DCHP )
                {
                    if ( SRStaticInfo.StockAverageHigh > srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageHigh < fSRCK_R )
                            fSRCK_R = SRStaticInfo.StockAverageHigh;
                    }
                    else if ( SRStaticInfo.StockAverageHigh < srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageHigh > fSRCK_S )
                            fSRCK_S = SRStaticInfo.StockAverageHigh;
                    }
                }

                if ( ( SRStaticInfo.SRPointType & SRStaticData.SRPointType.DCLP ) == SRStaticData.SRPointType.DCLP )
                {
                    if ( SRStaticInfo.StockAverageLow > srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageLow < fSRCK_R )
                            fSRCK_R = SRStaticInfo.StockAverageLow;
                    }
                    else if ( SRStaticInfo.StockAverageLow < srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageLow > fSRCK_S )
                            fSRCK_S = SRStaticInfo.StockAverageLow;
                    }
                }

                if ( ( SRStaticInfo.SRPointType & SRStaticData.SRPointType.GDHK ) == SRStaticData.SRPointType.GDHK )
                {
                    if ( SRStaticInfo.StockAverageLow > srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageLow < fSRCK_R )
                            fSRCK_R = SRStaticInfo.StockAverageLow;
                    }
                    else if ( SRStaticInfo.StockAverageLow < srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageLow > fSRCK_S )
                            fSRCK_S = SRStaticInfo.StockAverageLow;
                    }
                }

                if ( ( SRStaticInfo.SRPointType & SRStaticData.SRPointType.GDLK ) == SRStaticData.SRPointType.GDLK )
                {
                    if ( SRStaticInfo.StockAverageHigh > srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageHigh < fSRCK_R )
                            fSRCK_R = SRStaticInfo.StockAverageHigh;
                    }
                    else if ( SRStaticInfo.StockAverageHigh < srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageHigh > fSRCK_S )
                            fSRCK_S = SRStaticInfo.StockAverageHigh;
                    }
                }

                if ( ( SRStaticInfo.SRPointType & SRStaticData.SRPointType.GUHK ) == SRStaticData.SRPointType.GUHK )
                {
                    if ( SRStaticInfo.StockAverageLow > srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageLow < fSRCK_R )
                            fSRCK_R = SRStaticInfo.StockAverageLow;
                    }
                    else if ( SRStaticInfo.StockAverageLow < srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageLow > fSRCK_S )
                            fSRCK_S = SRStaticInfo.StockAverageLow;
                    }
                }

                if ( ( SRStaticInfo.SRPointType & SRStaticData.SRPointType.GULK ) == SRStaticData.SRPointType.GULK )
                {
                    if ( SRStaticInfo.StockAverageHigh > srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageHigh < fSRCK_R )
                            fSRCK_R = SRStaticInfo.StockAverageHigh;
                    }
                    else if ( SRStaticInfo.StockAverageHigh < srDynamicData.CurrentStock.StockClose )
                    {
                        if ( SRStaticInfo.StockAverageHigh > fSRCK_S )
                            fSRCK_S = SRStaticInfo.StockAverageHigh;
                    }
                }
            }

            if ( fSRCK_R != float.MaxValue )
            {
                MessageBox.Show( fSRCK_R.ToString() );
                srDynamicData.StaticSRCK_R = MSFL.FormatPrice( ( ( fSRCK_R - srDynamicData.CurrentStock.StockClose ) / srDynamicData.CurrentStock.StockClose ) * 100 );
                srDynamicData.StaticSRCK_RV = MSFL.FormatPrice( fSRCK_R );
            }
            if ( fSRCK_S != float.MinValue )
            {
                srDynamicData.StaticSRCK_S = MSFL.FormatPrice( ( ( srDynamicData.CurrentStock.StockClose - fSRCK_S ) / srDynamicData.CurrentStock.StockClose ) * 100 );
                srDynamicData.StaticSRCK_SV = MSFL.FormatPrice( fSRCK_S );
            }

            fSRCK_R = float.MaxValue;
            fSRCK_S = float.MinValue;
            for ( int i2 = 0; i2 < srDynamicData.srTrendDataArray.Length; i2++ )
            {
                SRDynamicData.TrendData trendData = srDynamicData.srTrendDataArray[i2];

                if ( trendData.CSR > srDynamicData.CurrentStock.StockClose )
                {
                    if ( trendData.CSR < fSRCK_R )
                        fSRCK_R = trendData.CSR;
                }
                else if ( trendData.CSR < srDynamicData.CurrentStock.StockClose )
                {
                    if ( trendData.CSR > fSRCK_S )
                        fSRCK_S = trendData.CSR;
                }
            }

            if ( fSRCK_R != float.MaxValue )
            {
                srDynamicData.DynamicSRCK_R = MSFL.FormatPrice( ( ( fSRCK_R - srDynamicData.CurrentStock.StockClose ) / srDynamicData.CurrentStock.StockClose ) * 100 );
                srDynamicData.DynamicSRCK_RV = MSFL.FormatPrice( fSRCK_R );
            }

            if ( fSRCK_S != float.MinValue )
            {
                srDynamicData.DynamicSRCK_S = MSFL.FormatPrice( ( ( srDynamicData.CurrentStock.StockClose - fSRCK_S ) / srDynamicData.CurrentStock.StockClose ) * 100 );
                srDynamicData.DynamicSRCK_SV = MSFL.FormatPrice( fSRCK_S );
            }

            SRReport srReport = new SRReport();
            srReport.SRStaticData = srStaticData;
            srReport.SRDynamicData = srDynamicData;

            return srReport;
        }

        private static void fff()
        {
            //if ( lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.AllowScanUpTrend == true )
            //{
            //    bool isOK = true;
            //    for ( int i3 = i - 1, j = 0; i3 >= 0 && j < lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace; i3--, j++ )
            //    {
            //        MSFL.MSFLPriceRecord msflPriceRecordUp = msflPriceRecordArray[i3];

            //        float fHighUp = MSFL.FormatPrice( msflPriceRecordUp.fHigh );

            //        if ( fHighUp >= stockDataCurrent.StockHigh )
            //        {
            //            isOK = false;
            //            break;
            //        }
            //    }

            //    if ( isOK == true )
            //    {
            //        float fCurrentHigh = stockDataCurrent.StockHigh;
            //        for ( int i4 = i - 1, j2 = 0; i4 >= 0 && j2 < lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanContinueUpDate; i4--, j2++ )
            //        {
            //            MSFL.MSFLPriceRecord msflPriceRecordUp2 = msflPriceRecordArray[i4];

            //            float fHighUp2 = MSFL.FormatPrice( msflPriceRecordUp2.fHigh );

            //            if ( fHighUp2 >= fCurrentHigh )
            //            {
            //                isOK = false;
            //                break;
            //            }
            //            else
            //                fCurrentHigh = fHighUp2;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ScanUpTrendNeedHigh == true )
            //        {
            //            if ( srStaticData.MaxDCHP >= srDynamicData.CurrentStock.StockHigh )
            //                isOK = false;
            //        }

            //        DateTime dateTimeStart = stockDataCurrent.StockDate;
            //        DateTime dateTimeEnd = DateTime.MaxValue;

            //        if ( i - lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace < 0)
            //            dateTimeEnd = MSFL.FormatDate( msflPriceRecordArray[0].lDate );
            //        else
            //            dateTimeEnd = MSFL.FormatDate( msflPriceRecordArray[i - lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace].lDate );

            //        SRStaticData.SRStaticInfo[] srStaticInfoArray = GlobalSetting.GetSRStaticData( srStaticData.srStaticInfoArray, dateTimeStart, dateTimeEnd );
            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP313 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_313 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP214 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_214 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP115 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_115 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP412 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_412 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.ExcludeDCHP511 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_115 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP313 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_313 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP214 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_214 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP115 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_115 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP412 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_412 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.UpTrendInfo.NeedDCLP511 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_511 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true )
            //            srDynamicData.Trend = SRDynamicData.StockTrend.Up;
            //    }
            //}

            //if ( lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.AllowScanDownTrend == true )
            //{
            //    bool isOK = true;
            //    for ( int i3 = i - 1, j = 0; i3 >= 0 && j < lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace; i3--, j++ )
            //    {
            //        MSFL.MSFLPriceRecord msflPriceRecordDown = msflPriceRecordArray[i3];

            //        float fLowDown = MSFL.FormatPrice( msflPriceRecordDown.fHigh );

            //        if ( fLowDown <= stockDataCurrent.StockLow )
            //        {
            //            isOK = false;
            //            break;
            //        }
            //    }

            //    if ( isOK == true )
            //    {
            //        float fCurrentLow = MSFL.FormatPrice( msflPriceRecord.fHigh );
            //        for ( int i4 = i - 1, j2 = 0; i4 >= 0 && j2 < lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanContinueDownDate; i4--, j2++ )
            //        {
            //            MSFL.MSFLPriceRecord msflPriceRecordDown2 = msflPriceRecordArray[i4];

            //            float fLowDown2 = MSFL.FormatPrice( msflPriceRecordDown2.fHigh );

            //            if ( fLowDown2 <= fCurrentLow )
            //            {
            //                isOK = false;
            //                break;
            //            }
            //            else
            //                fCurrentLow = fLowDown2;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ScanDownTrendNeedLow == true )
            //        {
            //            if ( srStaticData.MinDCLP <= srDynamicData.CurrentStock.StockLow )
            //                isOK = false;
            //        }

            //        DateTime dateTimeStart = stockDataCurrent.StockDate;
            //        DateTime dateTimeEnd = DateTime.MaxValue;

            //        if ( i - lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace < 0 )
            //            dateTimeEnd = MSFL.FormatDate( msflPriceRecordArray[0].lDate );
            //        else
            //            dateTimeEnd = MSFL.FormatDate( msflPriceRecordArray[i - lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.ScanTrendSpace].lDate );

            //        SRStaticData.SRStaticInfo[] srStaticInfoArray = GlobalSetting.GetSRStaticData( srStaticData.srStaticInfoArray, dateTimeStart, dateTimeEnd );
            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP313 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_313 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP214 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_214 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP115 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_115 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP412 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_412 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.ExcludeDCLP511 )
            //        {
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCLP && item.DCPointType == SRStaticData.DCPointType.DC_511 )
            //                {
            //                    isOK = false;
            //                    break;
            //                }
            //            }
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP313 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_313 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP214 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_214 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP115 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_115 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP412 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_412 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true && lhpScanInfo.m_ScanNormalInfo.ScanTrendInfo.DownTrendInfo.NeedDCHP511 )
            //        {
            //            bool isFind = false;
            //            foreach ( var item in srStaticInfoArray )
            //            {
            //                if ( item.SRPointType == SRStaticData.SRPointType.DCHP && item.DCPointType == SRStaticData.DCPointType.DC_511 )
            //                {
            //                    isFind = true;
            //                    break;
            //                }
            //            }

            //            if ( isFind == false )
            //                isOK = false;
            //        }

            //        if ( isOK == true )
            //            srDynamicData.Trend = SRDynamicData.StockTrend.Down;
            //    }
            //}
        }

        public static SRStaticData.SRStaticInfo[] GetSRStaticData( SRStaticData.SRStaticInfo[] srStaticInfoArray, DateTime dateTimeStart, DateTime dateTimeEnd )
        {
            List<SRStaticData.SRStaticInfo> srStaticInfoList = new List<SRStaticData.SRStaticInfo>();

            foreach ( var item in srStaticInfoArray )
            {
                if ( item.StockData.StockDate < dateTimeStart && item.StockData.StockDate >= dateTimeEnd )
                    srStaticInfoList.Add( item );
            }

            return srStaticInfoList.ToArray();
        }

        public static PSRReport GetPSRReport( SRReport srReport )
        {
            PSRReport PSRReport = new PSRReport();

            return null;
        }

        private static void SetStaticRelativelyNumber( SRStaticData srStaticData )
        {
            HashSet<int> hashSetSRStaticInfo = new HashSet<int>();
            foreach ( var item in srStaticData.srStaticInfoArray )
                hashSetSRStaticInfo.Add( item.LeftKLineNumber + item.RightLineNumber );

            List<int> KLineNumber = new List<int>( 1024 );
            while ( hashSetSRStaticInfo.Count > 0 )
            {
                int iLow = int.MaxValue;
                foreach ( var item2 in hashSetSRStaticInfo )
                {
                    if ( item2 < iLow )
                        iLow = item2;
                }

                if ( iLow != int.MaxValue )
                {
                    KLineNumber.Add( iLow );
                    hashSetSRStaticInfo.Remove( iLow );
                }
            }

            Dictionary<int, int> relativelyNumber = new Dictionary<int, int>();
            Dictionary<int, float> relativelyNumber2 = new Dictionary<int, float>();
            for ( int i = 0; i < KLineNumber.Count; i++ )
            {
                relativelyNumber.Add( KLineNumber[i], ( i + 1 ) );
                relativelyNumber2.Add( KLineNumber[i], MSFL.FormatPrice( (float)( i + 1 ) / (float)KLineNumber.Count ) );
            }

            foreach ( var item3 in srStaticData.srStaticInfoArray )
            {
                int outRelativelyNumber = 0;
                if ( relativelyNumber.TryGetValue( item3.LeftKLineNumber + item3.RightLineNumber, out outRelativelyNumber ) == true )
                {
                    float outRelativelyPercent = 0;
                    if ( relativelyNumber2.TryGetValue( item3.LeftKLineNumber + item3.RightLineNumber, out outRelativelyPercent ) == true )
                    {
                        item3.RelativelyNumber = outRelativelyNumber;
                        item3.RelativelyPercent = outRelativelyPercent;
                    }
                    else
                        throw new NotImplementedException();
                }
                else
                    throw new NotImplementedException();
            }
        }

        private static void SetTrendRelativelyNumber( SRStaticData srStaticData )
        {
            HashSet<int> hashSetSRStaticInfo = new HashSet<int>();
            foreach ( var item in srStaticData.srTrendInfoArray )
                hashSetSRStaticInfo.Add( item.SRStaticInfoA.LeftKLineNumber + item.SRStaticInfoA.RightLineNumber + item.SRStaticInfoB.LeftKLineNumber + item.SRStaticInfoB.RightLineNumber );

            List<int> KLineNumber = new List<int>( 1024 );
            while ( hashSetSRStaticInfo.Count > 0 )
            {
                int iLow = int.MaxValue;
                foreach ( var item2 in hashSetSRStaticInfo )
                {
                    if ( item2 < iLow )
                        iLow = item2;
                }

                if ( iLow != int.MaxValue )
                {
                    KLineNumber.Add( iLow );
                    hashSetSRStaticInfo.Remove( iLow );
                }
            }

            Dictionary<int, int> relativelyNumber = new Dictionary<int, int>();
            Dictionary<int, float> relativelyNumber2 = new Dictionary<int, float>();
            for ( int i = 0; i < KLineNumber.Count; i++ )
            {
                relativelyNumber.Add( KLineNumber[i], ( i + 1 ) );
                relativelyNumber2.Add( KLineNumber[i], MSFL.FormatPrice( (float)( i + 1 ) / (float)KLineNumber.Count ) );
            }

            foreach ( var item3 in srStaticData.srTrendInfoArray )
            {
                int outRelativelyNumber = 0;
                if ( relativelyNumber.TryGetValue( item3.SRStaticInfoA.LeftKLineNumber + item3.SRStaticInfoA.RightLineNumber + item3.SRStaticInfoB.LeftKLineNumber + item3.SRStaticInfoB.RightLineNumber, out outRelativelyNumber ) == true )
                {
                    float outRelativelyPercent = 0;
                    if ( relativelyNumber2.TryGetValue( item3.SRStaticInfoA.LeftKLineNumber + item3.SRStaticInfoA.RightLineNumber + item3.SRStaticInfoB.LeftKLineNumber + item3.SRStaticInfoB.RightLineNumber, out outRelativelyPercent ) == true )
                    {
                        item3.RelativelyNumber = outRelativelyNumber;
                        item3.RelativelyPercent = outRelativelyPercent;
                    }
                    else
                        throw new NotImplementedException();
                }
                else
                    throw new NotImplementedException();
            }
        }

        private static bool IsDCLP_313( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 3 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 3 ) < 0 )
                return false;

            float fLow = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fLow );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 2].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 3].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 2].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 3].fLow ) <= fLow )
                return false;

            return true;
        }

        private static bool IsDCLP_214( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 4 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 2 ) < 0 )
                return false;

            float fLow = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fLow );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 2].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 2].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 3].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 4].fLow ) <= fLow )
                return false;

            return true;
        }

        private static bool IsDCLP_115( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 5 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 1 ) < 0 )
                return false;

            float fLow = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fLow );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 2].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 3].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 4].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 5].fLow ) <= fLow )
                return false;

            return true;
        }

        private static bool IsDCLP_412( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 2 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 4 ) < 0 )
                return false;

            float fLow = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fLow );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 2].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 3].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 4].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 2].fLow ) <= fLow )
                return false;

            return true;
        }

        private static bool IsDCLP_511( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 1 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 5 ) < 0 )
                return false;

            float fLow = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fLow );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 2].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 3].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 4].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 5].fLow ) <= fLow )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fLow ) <= fLow )
                return false;

            return true;
        }

        private static bool IsDCHP_313( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 3 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 3 ) < 0 )
                return false;

            float fHigh = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fHigh );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 2].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 3].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 2].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 3].fHigh ) >= fHigh )
                return false;

            return true;
        }

        private static bool IsDCHP_214( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 4 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 2 ) < 0 )
                return false;

            float fHigh = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fHigh );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 2].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 2].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 3].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 4].fHigh ) >= fHigh )
                return false;

            return true;
        }

        private static bool IsDCHP_115( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 5 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 1 ) < 0 )
                return false;

            float fHigh = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fHigh );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 2].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 3].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 4].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 5].fHigh ) >= fHigh )
                return false;

            return true;
        }

        private static bool IsDCHP_412( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 2 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 4 ) < 0 )
                return false;

            float fHigh = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fHigh );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 2].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 3].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 4].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 2].fHigh ) >= fHigh )
                return false;

            return true;
        }

        private static bool IsDCHP_511( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 1 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            if ( ( currentIndex - 5 ) < 0 )
                return false;

            float fHigh = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fHigh );

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 2].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 3].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 4].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 5].fHigh ) >= fHigh )
                return false;

            if ( MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fHigh ) >= fHigh )
                return false;

            return true;
        }

        private static bool IsGULK( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 1 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            float fHigh = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fHigh );

            float fLow = MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fLow );

            if ( fHigh >= fLow )
                return false;

            return true;
        }

        private static bool IsGUHK( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex - 1 ) < 0 )
                return false;

            float fLow = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fLow );

            float fHigh = MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fHigh );

            if ( fLow <= fHigh )
                return false;

            return true;
        }

        private static bool IsGDLK( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex - 1 ) < 0 )
                return false;

            float fHigh = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fHigh );

            float fLow = MSFL.FormatPrice( msflPriceRecordArray[currentIndex - 1].fLow );

            if ( fHigh >= fLow )
                return false;



            return true;
        }

        private static bool IsGDHK( int currentIndex, MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            if ( ( currentIndex + 1 ) > ( msflPriceRecordArray.Length - 1 ) )
                return false;

            float fLow = MSFL.FormatPrice( msflPriceRecordArray[currentIndex].fLow );

            float fHigh = MSFL.FormatPrice( msflPriceRecordArray[currentIndex + 1].fHigh );

            if ( fLow <= fHigh )
                return false;

            return true;
        }

        public static SRDynamicData ScanSRDynamicData( StockFileInfo stockFileInfo, LHPScanInfo lhpScanInfo, SRStaticData srStaticData )
        {
            SRDynamicData srDynamicData = new SRDynamicData();



            return srDynamicData;
        }

        public static SRStaticData LoadSRStaticData( string strFile )
        {
            return null;
        }

        public static void SaveSRStaticData( string strFile, SRStaticData srStaticData )
        {

        }

        public static SRDynamicData LoadSRDynamicData( string strFile )
        {
            return null;
        }

        public static void SaveSRDynamicData( string strFile, SRDynamicData srDynamicData )
        {

        }

        public static void LoadGlobalRegistry()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.LHP" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "GlobalSetting" );

            string strIsShowReport = (string)rkey4.GetValue( "IsShowReport", "True" );
            bool.TryParse( strIsShowReport, out s_IsShowReport );

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
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.LHP" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "GlobalSetting" );

            rkey4.SetValue( "IsShowReport", s_IsShowReport.ToString(), RegistryValueKind.String );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }

        public static bool TryLoadMsflSecurityInfo( string strFilePath, out MSFL.MSFLSecurityInfo[] msflSecurityInfoArray )
        {
            msflSecurityInfoArray = new MSFL.MSFLSecurityInfo[0];

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

            return true;
        }

        public static bool TryLoadMsflPriceInfo( string stockName, string stockSymbol, string strFilePath, out MSFL.MSFLPriceRecord[] msflPriceRecordArray )
        {
            msflPriceRecordArray = new MSFL.MSFLPriceRecord[0];

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
