using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XtremeCommandBars;
using Demo.Stock.X.U50.Common;
using Demo.Stock.X.Common;

namespace Demo.Stock.X.U50
{
    public partial class TaskForm : Form
    {
        private HashSet<string> m_TaskName = new HashSet<string>();
        private Dictionary<TreeNode, UserControl> m_AllConfigControlInfo = new Dictionary<TreeNode, UserControl>();
        private Dictionary<TreeNode, U50TaskInfo> m_TreeNodeTaskInfo = new Dictionary<TreeNode, U50TaskInfo>();
        
        private UserControl m_CurrentConfigControl = null;
        private TreeNode m_CurrentDelTreeNode = null;

        private TreeNode m_MainTreeNode = null;
        private TreeNode m_MainTreeNodeSub = null;

        TaskAControl m_TaskAControl = null;

        public TaskForm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            m_MainTreeNode = new TreeNode( "设置" );
            m_MainTreeNodeSub = new TreeNode( "常规" );

            // 设置
            m_MainTreeNode.Nodes.Add( m_MainTreeNodeSub );

            this.TreeView.Nodes.Add( m_MainTreeNode );

            m_TaskAControl = new TaskAControl();
            m_TaskAControl.Dock = DockStyle.Fill;
            m_TaskAControl.Visible = false;
            m_TaskAControl.NewTaskInfo += new EventHandlerNone( ConfigAControl_NewTaskInfo );

            this.m_AllConfigControlInfo.Add( m_MainTreeNode, m_TaskAControl );
            this.m_AllConfigControlInfo.Add( m_MainTreeNodeSub, m_TaskAControl );

            this.Panel.Controls.Add( m_TaskAControl );

            if ( U50GlobalSetting.IsLoadTaskGlobalSetting == true )
            {
                for ( int iIndex = 0; iIndex < U50GlobalSetting.TaskInfos.Length; iIndex++ )
                    NewTask( U50GlobalSetting.TaskInfos[iIndex] );
            }

            this.TreeView.SelectedNode = m_MainTreeNodeSub;
        }

        private void ConfigAControl_NewTaskInfo()
        {
            NewTask();
        }

        //private bool m_IsLoadTaskInfo = false;
        //private bool ConfigAControl_LoadTaskInfo()
        //{
        //    if ( IsLoadTaskGlobalSetting == false )
        //        ProcessForm.StartProcessForm( Process_LoadTaskInfo );

        //    return m_IsLoadTaskInfo;
        //}

        //private void Process_LoadTaskInfo( ProcessForm processForm )
        //{
        //    if ( LoadTaskGlobalSetting() == false )
        //        MainForm.ShowPopupMessage( "读取任务文件失败！", "可能文件不存在或格式错误。。。", "你可以新建一个策略" );
        //    else
        //    {
        //        for ( int iIndex = 0; iIndex < TaskInfos.Length; iIndex++ )
        //            NewTask( TaskInfos[iIndex] );

        //        m_IsLoadTaskInfo = true;
        //    }

        //    processForm.EndProcessForm();
        //}

        protected override void OnVisibleChanged( EventArgs eventArgs )
        {
            base.OnVisibleChanged( eventArgs );

            if ( this.Visible == true )
            {
                MainForm.Instance.AxSkinFramework.ApplyWindow( this.Handle.ToInt32() );
                this.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            }
        }

        private bool m_IsInitializing = false;
        private void TaskForm_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            MainForm.Instance.AxCommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler( axCommandBars_Execute );
        }

        // 用于取消和删除
        private List<TreeNode> m_NewTreeNode = new List<TreeNode>();
        private int m_TaskCount = 0;
        public void NewTask()
        {
            if ( m_IsInitializing == false )
                TaskForm_Load( this, EventArgs.Empty );

            U50TaskInfo taskInfo = new U50TaskInfo();
            taskInfo.Guid = Guid.NewGuid().ToString();

            do
            {
                taskInfo.Name = string.Format( "U50任务{0}", m_TaskCount++ );

                if ( m_TaskName.Contains( taskInfo.Name ) == false )
                    break;
            } while ( true );

            // U50策略01
            TreeNode newTreeNodeTask = new TreeNode( taskInfo.Name );
            TreeNode newTreeNodeTaskSub = new TreeNode( "常规" );
            TreeNode newTreeNodeTaskSub1 = new TreeNode( "需求" );
            TreeNode newTreeNodeTaskSub2 = new TreeNode( "策略" );
            TreeNode newTreeNodeTaskSub3 = new TreeNode( "扫描结果" );
            newTreeNodeTask.Nodes.Add( newTreeNodeTaskSub );
            newTreeNodeTask.Nodes.Add( newTreeNodeTaskSub1 );
            newTreeNodeTask.Nodes.Add( newTreeNodeTaskSub2 );
            newTreeNodeTask.Nodes.Add( newTreeNodeTaskSub3 );

            TaskBControl taskBControl = new TaskBControl();
            taskBControl.Dock = DockStyle.Fill;
            taskBControl.Visible = false;
            taskInfo.General = taskBControl.GetTaskGeneral();

            this.m_AllConfigControlInfo.Add( newTreeNodeTask, taskBControl );
            this.m_AllConfigControlInfo.Add( newTreeNodeTaskSub, taskBControl );

            this.Panel.Controls.Add( taskBControl );

            TaskCControl taskCControl = new TaskCControl();
            taskCControl.Dock = DockStyle.Fill;
            taskCControl.Visible = false;
            taskInfo.Request = taskCControl.GetTaskRequest();

            this.m_AllConfigControlInfo.Add( newTreeNodeTaskSub1, taskCControl );

            this.Panel.Controls.Add( taskCControl );

            TaskDControl taskDControl = new TaskDControl();
            taskDControl.Dock = DockStyle.Fill;
            taskDControl.Visible = false;
            taskInfo.Policy = taskDControl.GetTaskPolicy();

            this.m_AllConfigControlInfo.Add( newTreeNodeTaskSub2, taskDControl );

            this.Panel.Controls.Add( taskDControl );

            TaskEControl taskEControl = new TaskEControl();
            taskEControl.Dock = DockStyle.Fill;
            taskEControl.Visible = false;
            taskInfo.Result = taskEControl.GetTaskResult();

            this.m_AllConfigControlInfo.Add( newTreeNodeTaskSub3, taskEControl );

            this.Panel.Controls.Add( taskEControl );

            // 
            taskDControl.m_TaskInfo = taskInfo;
            taskDControl.m_TaskBControl = taskBControl;
            taskDControl.m_TaskCControl = taskCControl;
            taskDControl.m_TaskDControl = taskDControl;
            taskDControl.m_TaskEControl = taskEControl;

            this.TreeView.Nodes.Add( newTreeNodeTask );

            this.TreeView.SelectedNode = newTreeNodeTask;

            m_NewTreeNode.Add( newTreeNodeTask );

            m_TreeNodeTaskInfo.Add( newTreeNodeTask, taskInfo );
        }

        private void NewTask( U50TaskInfo taskInfo )
        {
            m_TaskName.Add( taskInfo.Name );

            // U50策略01
            TreeNode newTreeNodeTask = new TreeNode( string.Format( "U50任务{0}", m_TaskCount++ ) );
            TreeNode newTreeNodeTaskSub = new TreeNode( "常规" );
            TreeNode newTreeNodeTaskSub1 = new TreeNode( "需求" );
            TreeNode newTreeNodeTaskSub2 = new TreeNode( "策略" );
            TreeNode newTreeNodeTaskSub3 = new TreeNode( "扫描结果" );
            newTreeNodeTask.Nodes.Add( newTreeNodeTaskSub );
            newTreeNodeTask.Nodes.Add( newTreeNodeTaskSub1 );
            newTreeNodeTask.Nodes.Add( newTreeNodeTaskSub2 );
            newTreeNodeTask.Nodes.Add( newTreeNodeTaskSub3 );


            TaskBControl taskBControl = new TaskBControl();
            taskBControl.Dock = DockStyle.Fill;
            taskBControl.Visible = false;
            taskBControl.SetConfigPolicy( taskInfo.General );

            this.m_AllConfigControlInfo.Add( newTreeNodeTask, taskBControl );
            this.m_AllConfigControlInfo.Add( newTreeNodeTaskSub, taskBControl );

            this.Panel.Controls.Add( taskBControl );

            TaskCControl taskCControl = new TaskCControl();
            taskCControl.Dock = DockStyle.Fill;
            taskCControl.Visible = false;
            taskCControl.SetConfigPolicy( taskInfo.Request );

            this.m_AllConfigControlInfo.Add( newTreeNodeTaskSub1, taskCControl );

            this.Panel.Controls.Add( taskCControl );

            TaskDControl taskDControl = new TaskDControl();
            taskDControl.Dock = DockStyle.Fill;
            taskDControl.Visible = false;
            taskDControl.SetConfigPolicy( taskInfo.Policy );

            this.m_AllConfigControlInfo.Add( newTreeNodeTaskSub2, taskDControl );

            this.Panel.Controls.Add( taskDControl );

            TaskEControl taskEControl = new TaskEControl();
            taskEControl.Dock = DockStyle.Fill;
            taskEControl.Visible = false;
            taskEControl.SetConfigPolicy( taskInfo.Result );

            this.m_AllConfigControlInfo.Add( newTreeNodeTaskSub3, taskEControl );

            this.Panel.Controls.Add( taskEControl );

            // 
            taskDControl.m_TaskInfo = taskInfo;
            taskDControl.m_TaskBControl = taskBControl;
            taskDControl.m_TaskCControl = taskCControl;
            taskDControl.m_TaskDControl = taskDControl;
            taskDControl.m_TaskEControl = taskEControl;

            this.TreeView.Nodes.Add( newTreeNodeTask );

            this.TreeView.SelectedNode = newTreeNodeTask;

            m_TreeNodeTaskInfo.Add( newTreeNodeTask, taskInfo );
        }

        private void TreeView_AfterSelect( object sender, TreeViewEventArgs eventArgs )
        {
            if ( eventArgs.Node == null )
                return;

            if ( eventArgs.Node.Parent == null )
                eventArgs.Node.Expand();

            UserControl outOptionControl = null;
            if ( m_AllConfigControlInfo.TryGetValue( eventArgs.Node, out outOptionControl ) == false )
            {
                if ( this.m_CurrentConfigControl != null )
                    this.m_CurrentConfigControl.Visible = false;
            }
            else
            {
                if ( this.m_CurrentConfigControl != null && outOptionControl != this.m_CurrentConfigControl )
                    this.m_CurrentConfigControl.Visible = false;

                if ( outOptionControl != null )
                {
                    outOptionControl.Visible = true;
                    this.m_CurrentConfigControl = outOptionControl;
                }
            }
        }

        private void contextMenuStrip_Opening( object sender, CancelEventArgs eventArgs )
        {
            eventArgs.Cancel = true;
            m_CurrentDelTreeNode = null;

            TreeViewHitTestInfo treeViewHitTestInfo = this.TreeView.HitTest( this.TreeView.PointToClient( Cursor.Position ) );
            if ( treeViewHitTestInfo == null )
                return;

            if ( treeViewHitTestInfo.Location != TreeViewHitTestLocations.Label )
                return;

            TreeNode hitTreeNode = treeViewHitTestInfo.Node;
            if ( hitTreeNode == null )
                return;

            if ( hitTreeNode.Parent != null )
                return;

            if ( hitTreeNode == m_MainTreeNode )
                return;

            m_CurrentDelTreeNode = hitTreeNode;

            CommandBar popupCommandBar = MainForm.Instance.AxCommandBars.Add( "StartTaskFormPopup", XTPBarPosition.xtpBarPopup );
            popupCommandBar.Controls.Add( XTPControlType.xtpControlCheckBox, ResourceId.ID_TASK_FORM_DELETE, "删除(&D)", -1, false );
            popupCommandBar.ShowPopup( XTPTrackPopupFlags.TPM_RIGHTBUTTON, null, null );
        }

        private List<TreeNode> m_DeleteTreeNode = new List<TreeNode>();
        private void axCommandBars_Execute( object sender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent e )
        {
            switch ( e.control.Id )
            {
                case ResourceId.ID_TASK_FORM_DELETE:
                    if ( m_CurrentDelTreeNode != null )
                    {
                        this.TreeView.Nodes.Remove( m_CurrentDelTreeNode );
                        m_DeleteTreeNode.Add( m_CurrentDelTreeNode );

                        m_CurrentDelTreeNode = null;
                    }

                    break;
                default:
                    break;
            }
        }

        private void TreeView_AfterLabelEdit( object sender, NodeLabelEditEventArgs e )
        {
            if ( e.Node.Parent != null )
            {
                e.CancelEdit = true;
                return;
            }

            if ( e.Node == m_MainTreeNode )
            {
                e.CancelEdit = true;
                return;
            }

            if ( e.Label == string.Empty || e.Label == null )
            {
                e.CancelEdit = true;
                return;
            }

            U50TaskInfo outPolicyInfo = null;
            if ( m_TreeNodeTaskInfo.TryGetValue( e.Node, out outPolicyInfo ) == false )
            {
                e.CancelEdit = true;
                return;
            }

            if ( outPolicyInfo.Name == e.Label )
                return;

            if ( m_TaskName.Contains( e.Label ) == true )
            {
                MainForm.ShowPopupMessage( e.Label, "名称已经存在!" );
                e.CancelEdit = true;
                return;
            }

            m_TaskName.Remove( outPolicyInfo.Name );

            outPolicyInfo.Name = e.Label;

            m_TaskName.Add( outPolicyInfo.Name );

            TaskManager.Instance.OnRefreshStockInfo();
        }

        private void ButtonOK_Click( object sender, EventArgs e )
        {
            foreach ( var item in m_DeleteTreeNode )
            {
                UserControl outConfigControl = null;
                if ( this.m_AllConfigControlInfo.TryGetValue( item.Nodes[0], out outConfigControl ) == true )
                {
                    if ( outConfigControl == m_CurrentConfigControl )
                        this.TreeView.SelectedNode = m_MainTreeNodeSub;

                    this.Panel.Controls.Remove( outConfigControl );
                }

                if ( this.m_AllConfigControlInfo.TryGetValue( item.Nodes[1], out outConfigControl ) == true )
                {
                    if ( outConfigControl == m_CurrentConfigControl )
                        this.TreeView.SelectedNode = m_MainTreeNodeSub;

                    this.Panel.Controls.Remove( outConfigControl );
                }

                if ( this.m_AllConfigControlInfo.TryGetValue( item.Nodes[2], out outConfigControl ) == true )
                {
                    if ( outConfigControl == m_CurrentConfigControl )
                        this.TreeView.SelectedNode = m_MainTreeNodeSub;

                    this.Panel.Controls.Remove( outConfigControl );
                }

                if ( this.m_AllConfigControlInfo.TryGetValue( item.Nodes[3], out outConfigControl ) == true )
                {
                    if ( outConfigControl == m_CurrentConfigControl )
                        this.TreeView.SelectedNode = m_MainTreeNodeSub;
                    
                    this.Panel.Controls.Remove( outConfigControl );
                }

                this.m_AllConfigControlInfo.Remove( item.Nodes[0] );
                this.m_AllConfigControlInfo.Remove( item.Nodes[1] );
                this.m_AllConfigControlInfo.Remove( item.Nodes[2] );
                this.m_AllConfigControlInfo.Remove( item.Nodes[3] );
                this.m_AllConfigControlInfo.Remove( item );

                U50TaskInfo outTaskInfo = null;
                if ( this.m_TreeNodeTaskInfo.TryGetValue( item, out outTaskInfo ) == true )
                {
                    this.m_TreeNodeTaskInfo.Remove( item );
                    TaskManager.Instance.RemoveTaskInfoByGuid( outTaskInfo.Guid );
                }
            }

            foreach ( var item in m_TreeNodeTaskInfo )
            {
                UserControl outTaskControl = null;
                if ( m_AllConfigControlInfo.TryGetValue( item.Key.Nodes[0], out outTaskControl ) == false )
                    continue;

                TaskBControl taskBControl = outTaskControl as TaskBControl;
                if ( taskBControl == null )
                    continue;

                item.Value.General = taskBControl.GetTaskGeneral();

                if ( m_AllConfigControlInfo.TryGetValue( item.Key.Nodes[1], out outTaskControl ) == false )
                    continue;

                TaskCControl taskCControl = outTaskControl as TaskCControl;
                if ( taskCControl == null )
                    continue;

                item.Value.Request = taskCControl.GetTaskRequest();

                if ( m_AllConfigControlInfo.TryGetValue( item.Key.Nodes[2], out outTaskControl ) == false )
                    continue;

                TaskDControl taskDControl = outTaskControl as TaskDControl;
                if ( taskDControl == null )
                    continue;

                item.Value.Policy = taskDControl.GetTaskPolicy();

                if ( m_AllConfigControlInfo.TryGetValue( item.Key.Nodes[3], out outTaskControl ) == false )
                    continue;

                TaskEControl taskEControl = outTaskControl as TaskEControl;
                if ( taskDControl == null )
                    continue;

                item.Value.Result = taskEControl.GetTaskResult();

                if ( m_NewTreeNode.Contains( item.Key ) == true )
                    TaskManager.Instance.AddTaskInfo( item.Value );
            }

            U50GlobalSetting.SaveTaskSetting( U50GlobalSetting.TaskFilePath, TaskManager.Instance.ToArray() );
            U50GlobalSetting.SaveGlobalRegistry();

            m_NewTreeNode.Clear();
            m_DeleteTreeNode.Clear();
        }

        private void ButtonCancel_Click( object sender, EventArgs e )
        {
            foreach ( var item in m_NewTreeNode )
                this.TreeView.Nodes.Remove( item );

            foreach ( var item in m_DeleteTreeNode )
                this.TreeView.Nodes.Add( item );

            m_NewTreeNode.Clear();
            m_DeleteTreeNode.Clear();
        }

    }
}
