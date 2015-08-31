using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.X.U50.Common
{
    public class PolicyManager
    {
        private static PolicyManager s_PolicyInstance = new PolicyManager();
        public static PolicyManager Instance
        {
            get { return s_PolicyInstance; }
        }

        private Dictionary<string, U50PolicyInfo> m_PolicyInfoByGuid = new Dictionary<string, U50PolicyInfo>();
        public U50PolicyInfo GetPolicyInfoByGuid( string strPolicyGuid )
        {
            U50PolicyInfo outPolicyInfo = null;
            if ( m_PolicyInfoByGuid.TryGetValue( strPolicyGuid, out outPolicyInfo ) == true )
                return outPolicyInfo;
            else
                return null;
        }

        public void RemovePolicyInfoByGuid( string strPolicyGuid )
        {
            m_PolicyInfoByGuid.Remove( strPolicyGuid );

            if ( RemovePolicyInfo != null )
                RemovePolicyInfo( this, EventArgs.Empty );
        }

        public U50PolicyInfo[] ToArray()
        {
            List<U50PolicyInfo> policyInfoList = new List<U50PolicyInfo>();

            foreach ( var item in m_PolicyInfoByGuid )
                policyInfoList.Add( item.Value );

            return policyInfoList.ToArray();
        }

        public void FromConfigPolicyInfo( U50PolicyInfo[] policyInfoArray )
        {
            for ( int iIndex = 0; iIndex < policyInfoArray.Length; iIndex++ )
                AddStockInfo( policyInfoArray[iIndex] );
        }

        public event EventHandler AddedPolicyInfo;
        public event EventHandler RemovePolicyInfo;
        public void AddStockInfo( U50PolicyInfo policyInfo )
        {
            m_PolicyInfoByGuid.Add( policyInfo.Guid, policyInfo );

            if ( AddedPolicyInfo != null )
                AddedPolicyInfo( this, EventArgs.Empty );
        }

        public event EventHandler RefreshPolicyInfo;
        public void OnRefreshStockInfo()
        {
            if ( RefreshPolicyInfo != null )
                RefreshPolicyInfo( this, EventArgs.Empty );
        }
    }
}
