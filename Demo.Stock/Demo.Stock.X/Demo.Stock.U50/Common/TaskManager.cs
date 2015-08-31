using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo.Stock.X.U50.Common
{
    public class TaskManager
    {
        private static TaskManager s_TaskInstance = new TaskManager();
        public static TaskManager Instance
        {
            get { return s_TaskInstance; }
        }

        private Dictionary<string, U50TaskInfo> m_TaskInfoByGuid = new Dictionary<string, U50TaskInfo>();
        public U50TaskInfo GetTaskInfoByGuid( string strTaskGuid )
        {
            U50TaskInfo outPolicyInfo = null;
            if ( m_TaskInfoByGuid.TryGetValue( strTaskGuid, out outPolicyInfo ) == true )
                return outPolicyInfo;
            else
                return null;
        }

        public void RemoveTaskInfoByGuid( string strTaskGuid )
        {
            m_TaskInfoByGuid.Remove( strTaskGuid );

            if ( RemoveTaskInfo != null )
                RemoveTaskInfo( this, EventArgs.Empty );
        }

        public U50TaskInfo[] ToArray()
        {
            List<U50TaskInfo> policyInfoList = new List<U50TaskInfo>();

            foreach ( var item in m_TaskInfoByGuid )
                policyInfoList.Add( item.Value );

            return policyInfoList.ToArray();
        }

        public void FromConfigTaskInfo( U50TaskInfo[] taskInfoArray )
        {
            for ( int iIndex = 0; iIndex < taskInfoArray.Length; iIndex++ )
                AddTaskInfo( taskInfoArray[iIndex] );
        }

        public event EventHandler AddedTaskInfo;
        public event EventHandler RemoveTaskInfo;
        public void AddTaskInfo( U50TaskInfo taskInfo )
        {
            m_TaskInfoByGuid.Add( taskInfo.Guid, taskInfo );

            if ( AddedTaskInfo != null )
                AddedTaskInfo( this, EventArgs.Empty );
        }

        public event EventHandler RefreshTaskInfo;
        public void OnRefreshStockInfo()
        {
            if ( RefreshTaskInfo != null )
                RefreshTaskInfo( this, EventArgs.Empty );
        }
    }
}
