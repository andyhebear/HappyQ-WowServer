using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.X.U50.Common
{
    public class ReportManager
    {
        private static ReportManager s_ReportInstance = new ReportManager();
        public static ReportManager Instance
        {
            get { return s_ReportInstance; }
        }

        private Dictionary<string, U50ReportInfo> m_ReportInfoByGuid = new Dictionary<string, U50ReportInfo>();
        public U50ReportInfo GetReportInfoByGuid( string strReportGuid )
        {
            U50ReportInfo outReportInfo = null;
            if ( m_ReportInfoByGuid.TryGetValue( strReportGuid, out outReportInfo ) == true )
                return outReportInfo;
            else
                return null;
        }

        public void RemoveReportInfoByGuid( string strReportGuid )
        {
            m_ReportInfoByGuid.Remove( strReportGuid );

            if ( RemovePolicyInfo != null )
                RemovePolicyInfo( this, EventArgs.Empty );
        }

        public U50ReportInfo[] ToArray()
        {
            List<U50ReportInfo> reportInfoList = new List<U50ReportInfo>();

            foreach ( var item in m_ReportInfoByGuid )
                reportInfoList.Add( item.Value );

            return reportInfoList.ToArray();
        }

        public void FromConfigReportInfo( U50ReportInfo[] reportInfoArray )
        {
            for ( int iIndex = 0; iIndex < reportInfoArray.Length; iIndex++ )
                AddReportInfo( reportInfoArray[iIndex] );
        }

        public event EventHandler AddedPolicyInfo;
        public event EventHandler RemovePolicyInfo;
        public void AddReportInfo( U50ReportInfo reportInfo )
        {
            m_ReportInfoByGuid.Add( reportInfo.Guid, reportInfo );

            if ( AddedPolicyInfo != null )
                AddedPolicyInfo( this, EventArgs.Empty );
        }
    }
}
