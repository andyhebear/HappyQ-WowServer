using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.X.U50.Common
{
    public class U50ReportSub
    {
        public DateTime S_Date = DateTime.Now;
        public int KLineNumber = 0;

        public float Va_U50 = 0;
        public float Vsc = 0;
        public float Close = 0;
        public float Q_U50 = 0;
    }

    public class U50Report
    {
        public string Guid = string.Empty;
        public string Name = string.Empty;
        public string Symbol = string.Empty;

        public DateTime ScanTime = DateTime.Now;
        public TimeSpan ScanSpan = TimeSpan.Zero;

        public U50ReportSub ReportSubInfo = new U50ReportSub();
    }

    public class U50ReportInfo
    {
        public string Guid = string.Empty;

        public DateTime ScanTime = DateTime.Now;
        public TimeSpan ScanSpan = TimeSpan.Zero;

        public U50TaskInfo StaticTaskInfo = null;
        public U50PolicyInfo[] StaticReportInfo = new U50PolicyInfo[0];

        public U50Report[] ReportArray = new U50Report[0];
    }
}
