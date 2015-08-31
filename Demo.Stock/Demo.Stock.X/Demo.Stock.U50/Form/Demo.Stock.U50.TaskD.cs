using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo.Stock.X.U50.Common;

namespace Demo.Stock.X.U50
{
    public partial class TaskDControl : UserControl
    {
        //TaskPolicyInfo[] m_PolicyInfoArray = new TaskPolicyInfo[0];
        public TaskDControl()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged( EventArgs eventArgs )
        {
            base.OnVisibleChanged( eventArgs );

            if ( this.Visible == true )
            {
                MainForm.Instance.AxSkinFramework.ApplyWindow( this.Handle.ToInt32() );
                this.BackColor = MainForm.Instance.AxSkinFramework.GetColor( XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE );
            }
        }

        bool m_IsInitializing = false;
        private void TaskDControl_Load( object sender, EventArgs e )
        {
            if ( m_IsInitializing == true )
                return;
            else
                m_IsInitializing = true;

            U50GlobalSetting_LoadedPolicySetting( this, EventArgs.Empty );

            U50GlobalSetting.LoadingPolicySetting += new EventHandler( U50GlobalSetting_LoadingPolicySetting );
            U50GlobalSetting.LoadedPolicySetting += new EventHandler( U50GlobalSetting_LoadedPolicySetting );
            PolicyManager.Instance.AddedPolicyInfo += new EventHandler( U50GlobalSetting_LoadedPolicySetting );
            PolicyManager.Instance.RemovePolicyInfo += new EventHandler( U50GlobalSetting_LoadedPolicySetting );
            PolicyManager.Instance.RefreshPolicyInfo += new EventHandler( U50GlobalSetting_LoadedPolicySetting );
        }

        // 名称 序号
        private List<string> m_SeletePolicyInfo = new List<string>();
        private List<string> m_SeletePolicyInfo2 = new List<string>();
        private Dictionary<string, string> m_SeletePolicyInfoA = new Dictionary<string, string>();
        private Dictionary<string, string> m_SeletePolicyInfoB = new Dictionary<string, string>();

        private void U50GlobalSetting_LoadedPolicySetting( object sender, EventArgs e )
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.m_SeletePolicyInfoA.Clear();
            this.m_SeletePolicyInfoB.Clear();

            List<string> seletePolicyInfo = new List<string>();
            List<string> seletePolicyInfo2 = new List<string>();

            foreach ( var item in PolicyManager.Instance.ToArray() )
            {
                if ( m_SeletePolicyInfo2.Contains( item.Guid ) == true )
                {
                    this.listBox2.Items.Add( item.Name );
                    seletePolicyInfo2.Add( item.Guid );

                    this.m_SeletePolicyInfoB.Add( item.Name, item.Guid );
                }
                else
                {
                    this.listBox1.Items.Add( item.Name );
                    seletePolicyInfo.Add( item.Guid );

                    this.m_SeletePolicyInfoA.Add( item.Name, item.Guid );
                }
            }

            m_SeletePolicyInfo = seletePolicyInfo;
            m_SeletePolicyInfo2 = seletePolicyInfo2;
        }

        private void U50GlobalSetting_LoadingPolicySetting( object sender, EventArgs e )
        {
        }

        public void SetConfigPolicy( U50TaskPolicy policy )
        {
            if ( policy.ScanType == U50ScanType.Order )
            {
                this.radioButton1.Checked = true;
            }
            else if ( policy.ScanType == U50ScanType.Synchronization )
            {
                this.radioButton2.Checked = true;
            }

            foreach ( var item in policy.PolicyGuid )
            {
                m_SeletePolicyInfo2.Add( item );

                U50GlobalSetting_LoadedPolicySetting( this, EventArgs.Empty );
            }
        }

        public U50TaskPolicy GetTaskPolicy()
        {
            U50TaskPolicy configPolicy = new U50TaskPolicy();

            if ( this.radioButton1.Checked == true )
            {
                configPolicy.ScanType = U50ScanType.Order;
            }
            else if ( this.radioButton2.Checked == true )
            {
                configPolicy.ScanType = U50ScanType.Synchronization;
            }

            List<string> seletePolicyInfo = new List<string>();
            foreach ( var item in m_SeletePolicyInfo2 )
            {
                seletePolicyInfo.Add( item );
            }

            configPolicy.PolicyGuid = m_SeletePolicyInfo2.ToArray();

            return configPolicy;
        }

        private void ButtonUP_Click( object sender, EventArgs e )
        {
            if ( this.listBox2.SelectedItem == null )
                return;

            foreach ( var item in this.listBox1.Items )
            {
                if ( item == this.listBox2.SelectedItem )
                    return;
            }

            string fff = (string)this.listBox2.SelectedItem;

            string strGuid = string.Empty;
            if ( m_SeletePolicyInfoB.TryGetValue( fff, out strGuid ) == true )
            {
                m_SeletePolicyInfoB.Remove( fff );
                m_SeletePolicyInfoA.Add( fff, strGuid );

                m_SeletePolicyInfo2.Remove( strGuid );
                m_SeletePolicyInfo.Add( strGuid );
            }

            this.listBox1.Items.Add( fff );
            this.listBox2.Items.Remove( fff );
        }

        private void ButtonDown_Click( object sender, EventArgs e )
        {
            if ( this.listBox1.SelectedItem == null )
                return;

            foreach ( var item in this.listBox2.Items )
            {
                if ( item == this.listBox1.SelectedItem )
                    return;
            }

            string fff = (string)this.listBox1.SelectedItem;

            string strGuid = string.Empty;
            if ( m_SeletePolicyInfoA.TryGetValue( fff, out strGuid ) == true )
            {
                m_SeletePolicyInfoA.Remove( fff );
                m_SeletePolicyInfoB.Add( fff, strGuid );

                m_SeletePolicyInfo.Remove( strGuid );
                m_SeletePolicyInfo2.Add( strGuid );
            }

            this.listBox2.Items.Add( fff );
            this.listBox1.Items.Remove( fff );
        }

        private TaskDControlForm m_TaskDControlForm = new TaskDControlForm();
        private void button1_Click( object sender, EventArgs e )
        {
            if ( m_TaskDControlForm.Visible == true )
            {
                //this.button1.Text = "<<";
                m_TaskDControlForm.Hide();
            }
            else
            {
                //this.button1.Text = ">>";
                m_TaskDControlForm.Show( this );
            }
        }

        public U50TaskInfo m_TaskInfo = null;
        public TaskBControl m_TaskBControl = null;
        public TaskCControl m_TaskCControl = null;
        public TaskDControl m_TaskDControl = null;
        public TaskEControl m_TaskEControl = null;
        private void button3_Click( object sender, EventArgs e )
        {
            if ( m_TaskInfo == null )
                return;

            U50TaskInfo taskInfo = new U50TaskInfo();
            taskInfo.Guid = m_TaskInfo.Guid;
            taskInfo.Name = m_TaskInfo.Name;
            taskInfo.General = m_TaskBControl.GetTaskGeneral();
            taskInfo.Request = m_TaskCControl.GetTaskRequest();
            taskInfo.Policy = m_TaskDControl.GetTaskPolicy();
            taskInfo.Result = m_TaskEControl.GetTaskResult();

            U50GlobalSetting.ScanTaskThread( taskInfo );

            this.button3.Enabled = false;
            this.Timer1.Enabled = true;

            //TaskPolicy taskPolicy = GetTaskPolicy();

            ////ReportInfo reportInfo = ScanTask( taskPolicy );
            //ReportInfo reportInfo = new ReportInfo();

            //for ( int i = 0; i < reportInfo.ReportArray.Length; i++ )
            //{
            //    Report report = reportInfo.ReportArray[i];
            //}
        }

        private void Timer1_Tick( object sender, EventArgs e )
        {
            this.Timer1.Enabled = false;

            this.button3.Enabled = true;

        }
    }
}
