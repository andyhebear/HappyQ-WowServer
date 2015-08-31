using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.LHP.Common
{
    public class LHPPrimaryScanInfo
    {
        public enum BaseScanType
        {
            ScanNew,
            ScanAll,
        }

        public class ScanBaseInfo
        {
            public bool AllowPSR = true;
            public BaseScanType ScanType = BaseScanType.ScanNew;
            public int ScanSpace = 5;

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
            public float GapUpPercentum = 5.0F;

            public bool AllowScanGapDown = true;
            public bool AllowGDLK = true;
            public bool AllowGDHK = true;
            public float GapDownPercentum = 5.0F;
        }

        public enum NormalTrendCheckDCLP
        {
            ScanAnyOne,
            ScanSelect,
        }

        public enum NormalTrendCheckDCHP
        {
            ScanAnyOne,
            ScanSelect,
        }

        public class ScanUpTrendInfo
        {
            public bool AllowScanUpTrend = true;
            public int ScanContinueUpDate = 5;
            public bool ScanUpTrendNeedHigh = false;

            public bool AllowCheckDCLP = true;
            public NormalTrendCheckDCLP CheckDCLP = NormalTrendCheckDCLP.ScanAnyOne;
            public bool NeedDCLP313 = false;
            public bool NeedDCLP214 = false;
            public bool NeedDCLP115 = false;
            public bool NeedDCLP412 = false;
            public bool NeedDCLP511 = false;

            public bool AllowCheckDCHP = true;
            public NormalTrendCheckDCHP CheckDCHP = NormalTrendCheckDCHP.ScanAnyOne;
            public bool ExcludeDCHP313 = false;
            public bool ExcludeDCHP214 = false;
            public bool ExcludeDCHP115 = false;
            public bool ExcludeDCHP412 = false;
            public bool ExcludeDCHP511 = false;
        }

        public class ScanDownTrendInfo
        {
            public bool AllowScanDownTrend = true;
            public int ScanContinueDownDate = 5;
            public bool ScanDownTrendNeedLow = false;


            public bool AllowCheckDCHP = true;
            public NormalTrendCheckDCHP CheckDCHP = NormalTrendCheckDCHP.ScanAnyOne;
            public bool NeedDCHP313 = false;
            public bool NeedDCHP214 = false;
            public bool NeedDCHP115 = false;
            public bool NeedDCHP412 = false;
            public bool NeedDCHP511 = false;

            public bool AllowCheckDCLP = true;
            public NormalTrendCheckDCLP CheckDCLP = NormalTrendCheckDCLP.ScanAnyOne;
            public bool ExcludeDCLP313 = false;
            public bool ExcludeDCLP214 = false;
            public bool ExcludeDCLP115 = false;
            public bool ExcludeDCLP412 = false;
            public bool ExcludeDCLP511 = false;
        }

        public class ScanTrendInfo
        {
            public int ScanTrendSpace = 3;

            public ScanUpTrendInfo UpTrendInfo = new ScanUpTrendInfo();
            public ScanDownTrendInfo DownTrendInfo = new ScanDownTrendInfo();
        }

        public enum NormalScanDateType
        {
            ScanNow,
            ScanSelect,
        }

        public class ScanNormalInfo
        {
            public bool AllowScanSR = true;
            public NormalScanDateType ScanDateType = NormalScanDateType.ScanNow;
            public DateTime ScanDate = DateTime.Now;

            public ScanTrendInfo ScanTrendInfo = new ScanTrendInfo();
        }


        public ScanBaseInfo m_ScanBaseInfo = new ScanBaseInfo();

        public ScanNormalInfo m_ScanNormalInfo = new ScanNormalInfo();
    }

    public class LHPScanInfo
    {
        public enum BaseScanType
        {
            ScanNew,
            ScanAll,
        }

        public class ScanBaseInfo
        {
            public bool AllowPSR = true;
            public BaseScanType ScanType = BaseScanType.ScanNew;
            public int ScanSpace = 5;

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
            public int GapUpPercentum = 5;

            public bool AllowScanGapDown = true;
            public bool AllowGDLK = true;
            public bool AllowGDHK = true;
            public int GapDownPercentum = 5;
        }

        public enum NormalTrendCheckDCLP
        {
            ScanAnyOne,
            ScanSelect,
        }

        public enum NormalTrendCheckDCHP
        {
            ScanAnyOne,
            ScanSelect,
        }

        public class ScanUpTrendInfo
        {
            public bool AllowScanUpTrend = true;
            public int ScanContinueUpDate = 5;
            public bool ScanUpTrendNeedHigh = false;

            public bool AllowCheckDCLP = true;
            public NormalTrendCheckDCLP CheckDCLP = NormalTrendCheckDCLP.ScanAnyOne;
            public bool NeedDCLP313 = false;
            public bool NeedDCLP214 = false;
            public bool NeedDCLP115 = false;
            public bool NeedDCLP412 = false;
            public bool NeedDCLP511 = false;

            public bool AllowCheckDCHP = true;
            public NormalTrendCheckDCHP CheckDCHP = NormalTrendCheckDCHP.ScanAnyOne;
            public bool ExcludeDCHP313 = false;
            public bool ExcludeDCHP214 = false;
            public bool ExcludeDCHP115 = false;
            public bool ExcludeDCHP412 = false;
            public bool ExcludeDCHP511 = false;
        }

        public class ScanDownTrendInfo
        {
            public bool AllowScanDownTrend = true;
            public int ScanContinueDownDate = 5;
            public bool ScanDownTrendNeedLow = false;


            public bool AllowCheckDCHP = true;
            public NormalTrendCheckDCHP CheckDCHP = NormalTrendCheckDCHP.ScanAnyOne;
            public bool NeedDCHP313 = false;
            public bool NeedDCHP214 = false;
            public bool NeedDCHP115 = false;
            public bool NeedDCHP412 = false;
            public bool NeedDCHP511 = false;

            public bool AllowCheckDCLP = true;
            public NormalTrendCheckDCLP CheckDCLP = NormalTrendCheckDCLP.ScanAnyOne;
            public bool ExcludeDCLP313 = false;
            public bool ExcludeDCLP214 = false;
            public bool ExcludeDCLP115 = false;
            public bool ExcludeDCLP412 = false;
            public bool ExcludeDCLP511 = false;
        }

        public class ScanTrendInfo
        {
            public int ScanTrendSpace = 3;

            public ScanUpTrendInfo UpTrendInfo = new ScanUpTrendInfo();
            public ScanDownTrendInfo DownTrendInfo = new ScanDownTrendInfo();
        }

        public enum NormalScanDateType
        {
            ScanNow,
            ScanSelect,
        }

        public class ScanNormalInfo
        {
            public bool AllowScanSR = true;
            public NormalScanDateType ScanDateType = NormalScanDateType.ScanNow;
            public DateTime ScanDate = DateTime.Now;

            public ScanTrendInfo ScanTrendInfo = new ScanTrendInfo();
        }


        public ScanBaseInfo m_ScanBaseInfo = new ScanBaseInfo();

        public ScanNormalInfo m_ScanNormalInfo = new ScanNormalInfo();
    }


}
