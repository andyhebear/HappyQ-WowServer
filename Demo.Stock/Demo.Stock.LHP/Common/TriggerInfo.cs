using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.LHP.Common
{
    public class TriggerInfos
    {
        public enum TriggerTask
        {
            TaskBegin,
            Tasking,
            TaskEnd
        }

        public enum TriggerDate
        {
            DateOne,
            DateDay,
            DateWeek,
            DateMonth
        }

        public class TriggerInfo
        {
            public string m_strTriggerName = string.Empty;
            public string m_strStockFile = string.Empty;
            public string m_strOpenSRFile = string.Empty;
            public string m_strSaveSRFile = string.Empty;

            public bool m_AllowUTMR_DTMS = false;
            public string m_strOpenUTMR_DTMSFile = string.Empty;
            public string m_strSaveUTMR_DTMSFile = string.Empty;

            public bool m_AllowTrigger = false;

            public TriggerTask m_TriggerTask = TriggerTask.Tasking;

            public TriggerDate m_TriggerDate = TriggerDate.DateDay;

            public int DateDay_TimeSpan = 1;

            public DateTime m_DateTimeBegin = DateTime.MaxValue;

            public bool m_AllowSpan = false;
            public DateTime m_TimeSpanSpan = DateTime.MinValue;
            public DateTime m_TimeSpanSpanTime = DateTime.MinValue;

            public bool m_AllowSpanRun = false;
            public DateTime m_TimeSpanRun = DateTime.MinValue;

            public bool m_AllowEnd = false;
            public DateTime m_DateTimeEnd = DateTime.MinValue;
        }

        public bool m_AllowTrigger = false;

        public TriggerInfo[] m_TriggerInfos = new TriggerInfo[0];
    }

}
